using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

namespace MPSP.Search.Jucesp
{
    public class Search
    {
        //Directory.GetCurrentDirectory() testar esse metodo no lugar do caminho chumbado
        public string Jucesp()
        {
            var driver = new ChromeDriver(@"C:\GIT\MPSP_SelectPage\JUCESP\bin\Debug\netcoreapp2.2");

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

            IWebElement tbl = driver.FindElements(By.CssSelector(".informacoes")).FirstOrDefault();
            IList<IWebElement> tds = tbl.FindElements(By.CssSelector("tbody tr td")).ToList();

            IWebElement tbl2 = driver.FindElements(By.Id("dados_endereco")).FirstOrDefault();
            IList<IWebElement> tds2 = tbl2.FindElements(By.CssSelector("tbody tr td")).ToList();

            var objToReturn = (from td in tds select ((IWebElement)td).Text).ToList();


            var check = driver.FindElement(By.XPath("//html[1]/body[1]/div[4]/form[1]/div[3]/div[4]/div[1]/div[1]/div[2]/table[1]/tbody[1]/tr[2]/td[1]/div[1]/table[1]/tbody[1]/tr[3]/td[1]/input[1]"));
            check.Click();

            var ok = driver.FindElement(By.XPath("//html[1]/body[1]/div[4]/form[1]/div[3]/div[4]/div[1]/div[1]/div[2]/table[1]/tbody[1]/tr[3]/td[1]/div[1]/input[1]"));
            ok.Click();

            driver.Close();

            return JsonConvert.SerializeObject(objToReturn);
        }
    }
}
