using System; 
using System.Linq; 

namespace Aramex
{
    public class Calculation
    {
        public static Result GetCost(string Country1, double Length, double Height, double Weight, double Width, string Type)
        {
            var table = Table.Load();
            var country_1 = table.Where(p => p.Country == Country1).FirstOrDefault();
            return GetCostWeight(country_1, Length, Height, Weight, Width, Type);
        }
        public static Result GetCostWeight(Table country, double Length, double Height, double Weight, double Width, string Type)
        {
            string Log = "Country: " + country.Country + Environment.NewLine + "Type: " + Type + Environment.NewLine + "Length: " + Length
                + Environment.NewLine + "Width: " + Width + Environment.NewLine + "Height: " + Height + Environment.NewLine + "Weight: " + Weight;

            double VWeight = (Length * Width * Height) / 5000;

            Log += Environment.NewLine+ "VWeight: " + VWeight + Environment.NewLine;

            if (VWeight > Weight)
                Weight = VWeight;
            double result = -99.99;
            Log += "Weight:" + Weight + Environment.NewLine;
            if (Type == "Docs")
            {
                Log += "Result=" + country.Docs.ToString() + "+(Math.Ceiling(" + Weight.ToString() + "-0,3))*" + country.T05.ToString()+
                    "=" + country.Docs.ToString()+ " + "+(Math.Ceiling(Weight - 0.3)).ToString() + "*" +country.T05.ToString();
                result = country.Docs + (Math.Ceiling(Weight - 0.3)) * country.T05;
                Log += "=" + result + Environment.NewLine;
            }
            else if (Type == "Parcel")
            {
                Log += "Result=" + country.Parcel.ToString() + "(" + Weight.ToString() + "-0,5)*" + country.T05.ToString()+
                    "="+ country.Parcel.ToString() +" + "+ (Weight - 0.5).ToString()+ "*" + country.T05.ToString();
                result = country.Parcel + (Weight - 0.5) * country.T05;
                Log += "=" + result + Environment.NewLine;
            }
            Log += "Result sended!"; 
            Result r = new Result();
            r.Resultat = result;
            r.Message = Log;
            return r;

        } 
    }
}