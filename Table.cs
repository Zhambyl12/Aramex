using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Aramex
{
    public class Table
    {
        public string Country { get; set; }
        public double Docs { get; set; }
        public double Parcel { get; set; }
        public double T05 { get; set; }

        public static List<Table> Load()
        {
            var table = new List<Table>();
            using (StreamReader r = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/data.json")))
            {
                string json = r.ReadToEnd();
                table = JsonConvert.DeserializeObject<List<Table>>(json);
            }
            return table;
        }
    }
    public class Result
    {
        public double Resultat { get; set; }
        public string Message { get; set; }
    }
}