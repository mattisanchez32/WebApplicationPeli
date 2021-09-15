using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplicationPeli.Models;

namespace WebApplicationPeli.Controllers
{
	public class GenerosController : Controller
	{
		HttpClientHandler clientHandler = new HttpClientHandler();

		Genero genero = new Genero();
		List<Genero> generos = new List<Genero>();


		public GenerosController()
		{
			clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors)
				=>
			{ return true; };
		}

		public IActionResult Index()
		{
			//IEnumerable<Genero> students = null;

			//using (var client = new HttpClient())
			//{
			//	client.BaseAddress = new Uri("https://peliapi2021.azurewebsites.net/api/");
			//	//HTTP GET
			//	var responseTask = client.GetAsync("generos");
			//	responseTask.Wait();

			//	var result = responseTask.Result;
			//	if (result.IsSuccessStatusCode)
			//	{
			//		var readTask = result.Content.ReadAsStringAsync();

			//		readTask.Wait();

			//		students = readTask.Result;
			//	}
			//	else //web api sent error response 
			//	{
			//		//log response status here..

			//		students = Enumerable.Empty<Genero>();

			//		ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
			//	}
			//}
			return View();
		}
	
	


		[HttpGet]
		public async Task<List<Genero>> GetGeneros()
		{
			generos = new List<Genero>();

			using(var httpClient = new HttpClient(clientHandler))
			{
				using(var response = await httpClient.GetAsync("https://peliapi2021.azurewebsites.net/api/generos"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					generos = JsonConvert.DeserializeObject<List<Genero>>(apiResponse);
				}
			}

			return generos;
		}



		[HttpGet]
		public async Task<Genero> GetByIdGeneros(int id)
		{
			genero = new Genero();

			using (var httpClient = new HttpClient(clientHandler))
			{
				using (var response = await httpClient.GetAsync("https://peliapi2021.azurewebsites.net/api/generos/" + id))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					genero = JsonConvert.DeserializeObject<Genero>(apiResponse);
				}
			}

			return genero;
		}

		//[HttpPost]
		//public async Task<Genero> PostGenero(Genero generoAdd)
		//{
		//	genero = new Genero();

		//	using (var httpClient = new HttpClient(clientHandler))

		//		var json = JsonConvert.SerializeObject(generoAdd);

		//		var content = new StringContent(JsonConvert.SerializeObject(generoAdd), Encoding.UTF8, "application/json");

		//	{
		//		using (var response = await httpClient. ("https://peliapi2021.azurewebsites.net/api/generos/" + id))
		//		{
		//			string apiResponse = await response.Content.ReadAsStringAsync();
		//			genero = JsonConvert.DeserializeObject<Genero>(apiResponse);
		//		}
		//	}

		//	return genero;
		//}
	}
}
