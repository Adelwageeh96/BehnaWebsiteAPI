using BenhaWebsite.Core.Dtos.AuthenticationDtos;
using BenhaWebsite.Core.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using System.Numerics;
using System.Diagnostics;

namespace BenhaWebsite.EF.Repositories
{
	public class CodeforcesRepository : ICodeforcesRepository
	{
		private readonly HttpClient _httpClient;
		private const string BaseUrl = "https://codeforces.com/api/contest.standings?";
		private static string apiKey = "";
		private static string secret = "";
		private static string parameters = "";

		public CodeforcesRepository(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}


		public async Task<bool> CheckHandleValidity(string handle)
		{
			string apiUrl = $"https://codeforces.com/api/user.info?handles={handle}";
			HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();
				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

				CodeforcesApiResponse apiResponse = JsonSerializer.Deserialize<CodeforcesApiResponse>(jsonResponse, options);
				if (apiResponse.Status is "OK" && apiResponse.Result.Length > 0)
					return true;
			}
			return false;
		}
		private record CodeforcesApiResponse(string Status, User[] Result);
		private record User(string Handle, int Rating, string Rank);

		public async Task<string> GetContestStandings(ContestRequestDto request)
		{
			string contestId = request.ContestId;
			apiKey = request.ApiKey;
			secret = request.Secret;

			AddParam("apiKey", apiKey);
			AddParam("contestId", contestId);
			AddParam("count", "10");
			AddParam("from", "1");
			AddParam("showUnofficial", "false");
			long currentTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			AddParam("time", currentTimestamp.ToString());
			parameters = parameters.Substring(0, parameters.Length - 1);
			string sig = GenerateSig(parameters, secret);
			parameters += "&";
			AddParam("apiSig", sig);
			parameters = parameters.Substring(0, parameters.Length - 1);
			string url = BaseUrl + parameters;
			Debug.WriteLine($"Request URL: {url}");

			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					string responseBody = await response.Content.ReadAsStringAsync();
					Debug.WriteLine($"Response Body: {responseBody}");
					return responseBody;
				}
				else
				{
					return ($"Failed to retrieve standings. Status code: {response.StatusCode}");
				}
			}
		}
		private static string GenerateSig(string par, string secret)
		{
			string rand = Rand();
			string cur = rand + "/contest.standings?" + par;
			cur += "#" + secret;

			using (SHA512 sha512 = SHA512.Create())
			{
				byte[] messageDigest = sha512.ComputeHash(Encoding.UTF8.GetBytes(cur));
				long no = BitConverter.ToInt64(messageDigest, 0);
				string hashtext = no.ToString("x2");

				while (hashtext.Length < 32)
				{
					hashtext = "0" + hashtext;
				}

				return rand + hashtext;
			}
		}
		 
		private static string Rand()
		{
			Random rnd = new Random();
			int number = rnd.Next(999999);
			return number.ToString("D6");
		}

		private static void AddParam(string key, string val)
		{
			parameters += key;
			parameters += "=";
			parameters += val;
			parameters += "&";
		}
	}

}

