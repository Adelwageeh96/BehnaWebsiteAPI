using BenhaWebsite.Core.Helpers;
using BenhaWebsite.Core.IRepositories;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BenhaWebsite.EF.Repositories
{
	public class MailingRepository : IMailingRepository
	{
		private readonly MailSettings _mailSettings;
		public MailingRepository(IOptions<MailSettings>mailSettings)
		{
			_mailSettings= mailSettings.Value;
		}
		public async Task SendEmailAsync(string emailTo,string subject,string body,IList<IFormFile>attachments=null)
		{
		
			var email = new MimeMessage
			{
				Sender = MailboxAddress.Parse(_mailSettings.Email),
				Subject = subject
			};
			email.To.Add(MailboxAddress.Parse(emailTo));

			var builer = new BodyBuilder();
			if(attachments is not null)
			{
				byte[] fileBytes;
				foreach (var file in attachments)
				{
					if (file.Length > 0)
					{
						using var ms= new MemoryStream();
						file.CopyTo(ms);
						fileBytes = ms.ToArray();
						builer.Attachments.Add(file.FileName,fileBytes,ContentType.Parse(file.ContentType));
					}
				}
			}
			builer.HtmlBody= body;
			email.Body=builer.ToMessageBody();
			email.From.Add(new MailboxAddress(_mailSettings.DisplayName,_mailSettings.Email));
			using var smtp = new SmtpClient();
			smtp.Connect(_mailSettings.Host, _mailSettings.Port,SecureSocketOptions.StartTls);
			smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
			await smtp.SendAsync(email);

			smtp.Disconnect(true);
		}

	}
}
