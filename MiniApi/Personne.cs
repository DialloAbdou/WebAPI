using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Reflection;
using System.Security.Principal;

namespace MiniApi
{
    public class Personne
    {
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;

        //public static bool TryParse(string value, out Personne? personne)
        //{

        //    try
        //    {
        //        var data = value.Split(' ');
        //        personne = new Personne
        //        {
        //            Nom = data[0],
        //            Prenom = data[1]
        //        };

        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        personne = null;
        //        return false;
        //    }
        //}

        public static async ValueTask<Personne> BindAsync(HttpContext context, ParameterInfo info)
        {

            try
            {
                using var StreamReader = new StreamReader(context.Request.Body);
                var body = await StreamReader.ReadToEndAsync();
                var data = body.Split(' ');
               Personne personne = new Personne
                {
                    Nom = data[0],
                    Prenom = data[1]
                };

                return personne;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
