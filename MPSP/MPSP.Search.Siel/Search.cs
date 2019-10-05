using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Reflection;
using MPSP.Persistency.Repositories;

namespace MPSP.Search.Siel
{
	public class Search : ISearch
	{

		private ISielRepository _sielRepository;
		static Random randNum = new Random();

		public Search(ISielRepository sielRepository)
		{
			_sielRepository = sielRepository;
		}

		public static int RandomNumber()
		{
			var number = randNum.Next(2000, 2000);

			return number;
		}

		public Model.Search.Siel Siel()
		{
			IWebDriver driver = new ChromeDriver(@"C:\Users\lpsan\Documents\Leo\Repository_MPSP\MPSP_WEB_PROJECT_VS2019\MPSP\MPSP.Search.Jucesp\bin\Debug\netcoreapp2.2");

			try
			{
				driver.Url = "http://ec2-18-231-116-58.sa-east-1.compute.amazonaws.com/siel/login.html";
			}
			catch
			{
				Console.WriteLine("Não foi possível");
			}


			System.Threading.Thread.Sleep(Search.RandomNumber());

			var btn_enviar = driver.FindElement(By.XPath("//html[1]/body[1]/div[1]/div[1]/div[4]/form[1]/table[1]/tbody[1]/tr[3]/td[2]/input[1]"));
			btn_enviar.Click();

			System.Threading.Thread.Sleep(Search.RandomNumber());

			var input_nome = driver.FindElement(By.XPath("//html[1]/body[1]/div[1]/div[1]/div[4]/form[2]/fieldset[1]/table[1]/tbody[1]/tr[1]/td[2]/input[1]"));
			input_nome.SendKeys("Leo");

			System.Threading.Thread.Sleep(Search.RandomNumber());

			var inquerito = driver.FindElement(By.XPath("//html[1]/body[1]/div[1]/div[1]/div[4]/form[2]/fieldset[2]/table[1]/tbody[1]/tr[1]/td[2]/input[1]"));
			inquerito.SendKeys("243243");

			System.Threading.Thread.Sleep(Search.RandomNumber());


			var btn_enviar2 = driver.FindElement(By.XPath("//html[1]/body[1]/div[1]/div[1]/div[4]/form[2]/table[1]/tbody[1]/tr[1]/td[2]/input[1]"));
			btn_enviar2.Click();

			System.Threading.Thread.Sleep(Search.RandomNumber());


			//-------------------------------Captura de dados (feito)


			var doc = new HtmlAgilityPack.HtmlDocument();
			doc.LoadHtml(driver.PageSource);

			System.Threading.Thread.Sleep(Search.RandomNumber());


			var titulos = doc.DocumentNode.SelectNodes("//table[@class='lista']/tbody/tr/td[1]").ToList();
			var dados = doc.DocumentNode.SelectNodes("//table[@class='lista']/tbody/tr/td[2]").ToList();

			string[] titulo = new string[titulos.Count];
			var nomes = new string[dados.Count];


			for (int i = 0; i < titulos.Count; i++)
			{
				titulo[i] = titulos[i].InnerText.ToString();
				nomes[i] = dados[i].InnerText.ToString();

				Console.WriteLine(titulo[i].ToString() + ":" + nomes[i].ToString());

			}

			var j = 0;
			Model.Search.Siel model = new Model.Search.Siel();
			PropertyInfo[] properties = typeof(Model.Search.Siel).GetProperties();
			for (int i = 0; i <= properties.Length - 1; i++)
			{
				if (properties[i].PropertyType == typeof(Guid))
				{
					i++;
				}
				properties[i].SetValue(model, nomes[j]);
				j++;

			}
			////-----------------------------------end

			//RepositorySiel repository = new RepositorySiel();
			//repository.Insert(model);

			//-----------------------------------end
			System.Threading.Thread.Sleep(1000);

			driver.Close();


			return _sielRepository.Add(model);
		}


		

	}

	
}
