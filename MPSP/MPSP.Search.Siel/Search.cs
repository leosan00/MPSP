using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace MPSP.Search.Siel
{
	 public class Search
	{

		static Random randNum= new Random();
		public static int RandomNumber()
		{
			var number = randNum.Next(2000, 2000);

			return number;
		}

		public void Siel()
		{
			IWebDriver driver = new ChromeDriver(@"C:\GIT\MPSP_SelectPage\JUCESP\bin\Debug\netcoreapp2.2");

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

			var conexao = true;

			if (conexao == true)
			{
				Console.WriteLine("Conexão Sucesso");

				//-------------------------------Captura de dados (feito)


				var doc = new HtmlAgilityPack.HtmlDocument();
				doc.LoadHtml(driver.PageSource);

				System.Threading.Thread.Sleep(Search.RandomNumber());

				//SielModel model = new SielModel();



				//model.nome = doc.DocumentNode.SelectNodes("//table[@class='lista']/tbody/tr[2]/td[2]").FirstOrDefault().InnerHtml;
				//model.titulo = doc.DocumentNode.SelectNodes("//table[@class='lista']/tbody/tr[3]/td[2]").FirstOrDefault().InnerHtml;
				//model.dataNascimento= doc.DocumentNode.SelectNodes("//table[@class='lista']/tbody/tr[4]/td[2]").FirstOrDefault().InnerHtml;
				//model.zona= doc.DocumentNode.SelectNodes("//table[@class='lista']/tbody/tr[5]/td[2]").FirstOrDefault().InnerHtml;
				//model.endereco= doc.DocumentNode.SelectNodes("//table[@class='lista']/tbody/tr[6]/td[2]").FirstOrDefault().InnerHtml;
				//model.municipio= doc.DocumentNode.SelectNodes("//table[@class='lista']/tbody/tr[7]/td[2]").FirstOrDefault().InnerHtml;
				//model.uf= doc.DocumentNode.SelectNodes("//table[@class='lista']/tbody/tr[8]/td[2]").FirstOrDefault().InnerHtml;
				//model.dataDom= doc.DocumentNode.SelectNodes("//table[@class='lista']/tbody/tr[9]/td[2]").FirstOrDefault().InnerHtml;
				//model.nomePai= doc.DocumentNode.SelectNodes("//table[@class='lista']/tbody/tr[10]/td[2]").FirstOrDefault().InnerHtml;
				//model.nomeMae= doc.DocumentNode.SelectNodes("//table[@class='lista']/tbody/tr[11]/td[2]").FirstOrDefault().InnerHtml;
				//model.naturalidade= doc.DocumentNode.SelectNodes("//table[@class='lista']/tbody/tr[12]/td[2]").FirstOrDefault().InnerHtml;
				//model.codigo= doc.DocumentNode.SelectNodes("//table[@class='lista']/tbody/tr[13]/td[2]").FirstOrDefault().InnerHtml;

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

				// Siel model = new Siel();
				//PropertyInfo[] properties = typeof(SielModel).GetProperties();
				//for (int i = 0; i < dados.Count; i++)
				//{
				//	properties[i].SetValue(model, dados[i].InnerText.ToString());
				//	titulo[i] = titulos[i].InnerText.ToString();
				//}
				////-----------------------------------end

				//RepositorySiel repository = new RepositorySiel();
				//repository.Insert(model); 0



				//-----------------------------------end
			}






			System.Threading.Thread.Sleep(50000);

			driver.Close();
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}
}
