using MPSP.Persistency.Repositories;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using  MPSP.Model.Search;

namespace MPSP.Search.Jucesp
{
    public class Search : ISearch
    {

        private IJucespRepository _jucespRepository;
		static Random randNum = new Random();

		public Search(IJucespRepository jucespRepository)
        {
            _jucespRepository = jucespRepository;
        }


		public static int RandomNumber()
		{
			var number = randNum.Next(1000, 2000);
			return number;
		}


		//Directory.GetCurrentDirectory() testar esse metodo no lugar do caminho chumbado
		public MPSP.Model.Search.Jucesp Jucesp()
        {


            var driver = new ChromeDriver(@"C:\Users\lpsan\Documents\Leo\Repository_MPSP\MPSP_WEB_PROJECT_VS2019\MPSP\MPSP.Search.Jucesp\bin\Debug\netcoreapp2.2");

            driver.Url = "http://ec2-18-231-116-58.sa-east-1.compute.amazonaws.com/jucesp/index.html";
            var input = driver.FindElement(By.Id("ctl00_cphContent_frmBuscaSimples_txtPalavraChave"));
            input.SendKeys("342352");


            var btn_buscar = driver.FindElement(By.XPath("//html[1]/body[1]/div[4]/form[1]/div[3]/div[4]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[2]/input[1]"));
            btn_buscar.Click();



            var input_validacao = driver.FindElement(By.XPath("//html[1]/body[1]/div[4]/div[3]/div[4]/div[2]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[1]/div[2]/label[1]/input[1]"));
            input_validacao.SendKeys("342352");



            var btn_continuar = driver.FindElement(By.XPath("//html[1]/body[1]/div[4]/div[3]/div[4]/div[2]/div[1]/div[1]/table[1]/tbody[1]/tr[2]/td[1]/input[1]"));
            btn_continuar.Click();


            var id_empresa = driver.FindElement(By.XPath("//html[1]/body[1]/div[2]/form[1]/div[3]/div[4]/div[2]/div[1]/div[1]/div[2]/table[1]/tbody[1]/tr[2]/td[1]/a[1]"));
            id_empresa.Click();


			//--------------------------------Capturar dados(feito)

			var doc = new HtmlAgilityPack.HtmlDocument();
			doc.LoadHtml(driver.PageSource);

			System.Threading.Thread.Sleep(Search.RandomNumber());
			IWebElement tbl = driver.FindElements(By.CssSelector(".informacoes")).FirstOrDefault();
			IList<IWebElement> tds = tbl.FindElements(By.CssSelector("tbody tr td p:not([class='number']) span"));

			IWebElement tbl2 = driver.FindElements(By.Id("dados_endereco")).FirstOrDefault();
			IList<IWebElement> tds2 = tbl2.FindElements(By.CssSelector("tbody tr td span"));

			IList<String> nomes = new List<String>();
			foreach (IWebElement td in tds)
			{
				nomes.Add(td.Text);
				Console.WriteLine(td.Text);
			}

			foreach (IWebElement td in tds2)
			{
				nomes.Add(td.Text);
				Console.WriteLine(td.Text);
			}

			for (int i = 0; i < nomes.Count; i++)
			{

				if (nomes[i].Length == 0)
				{
					nomes.RemoveAt(i);
				}

				if (nomes[i].Contains("R$"))
				{
					var preco = nomes[i].Split('(');
					nomes.RemoveAt(i);
					nomes.Add(preco[0].ToString());
				}

			}

          
            var check = driver.FindElement(By.XPath("//html[1]/body[1]/div[4]/form[1]/div[3]/div[4]/div[1]/div[1]/div[2]/table[1]/tbody[1]/tr[2]/td[1]/div[1]/table[1]/tbody[1]/tr[3]/td[1]/input[1]"));
            check.Click();

            var ok = driver.FindElement(By.XPath("//html[1]/body[1]/div[4]/form[1]/div[3]/div[4]/div[1]/div[1]/div[2]/table[1]/tbody[1]/tr[3]/td[1]/div[1]/input[1]"));
            ok.Click();

			var j = 0;
			MPSP.Model.Search.Jucesp model = new MPSP.Model.Search.Jucesp();
			PropertyInfo[] properties = typeof(MPSP.Model.Search.Jucesp).GetProperties();
			for (int i = 0; i <= properties.Length-1; i++)
			{
				
				if (properties[i].PropertyType == typeof(Guid))
				{
					i++;
				}
				properties[i].SetValue(model, nomes[j]);
				j++;

			}

			driver.Close();

            return _jucespRepository.Add(model);
        }
    }
}
