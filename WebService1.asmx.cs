using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Aramex
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        
        [WebMethod]
        public List<Table> GetList()
        {
            var table = Table.Load();
            return table;
        }
        [WebMethod]
        public double Calculate(string Country1,double Length,double Width,double Height,double Weight,string Type)
        {
            try
            {
                Result res = Calculation.GetCost(Country1, Length, Height, Weight, Width, Type);
                var dir = Server.MapPath("~\\Log");
                string dt = DateTime.Now.ToString();
                string filename = dt.Replace(".","").Replace(":","").Replace(" ", "") + ".txt";
                var file = Path.Combine(dir,filename);

                Directory.CreateDirectory(dir);
                File.WriteAllText(file,res.Message);
                return res.Resultat;
            }
            catch (Exception ex)
            {
                return -55.55;
            }
        }
    }
}
