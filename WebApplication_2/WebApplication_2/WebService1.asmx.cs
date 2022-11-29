using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication3
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public int sum(int a, int b)
        {
            List<string> calcs;
            if (Session["calculation"] == null)
            {
                calcs = new List<string>();
            }
            else
            {
                calcs = (List<string>)Session["calculation"];

            }
            //5+7=12
            string calculations = a.ToString() + "+" + b.ToString() + " = " + (a + b).ToString();
            calcs.Add(calculations);
            Session["calculation"] = calcs;


            return a + b;
        }

        [WebMethod(EnableSession = true)]
        public List<string> getcalc()
        {

            if (Session["calculation"] == null)
            {
                List<string> calcs = new List<string>();
                calcs.Add("no calculations yet");

                return calcs;
            }
            else
            {

                return (List<string>)Session["calculation"];

            }

        }




    }
}