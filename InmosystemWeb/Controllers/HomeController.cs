using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;


namespace InmosystemWeb.Controllers
{
    public class HomeController : Controller
    {
        [SharePointContextFilter]
        public ActionResult Index()
        {
            User spUser = null;

            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

           /* using (var clientContext = new ClientContext("https://clres.sharepoint.com/Dev"))//spContext.CreateUserClientContextForSPHost())
            {
                if (clientContext != null)
                {
                    SecureString passWord = new SecureString();

                    foreach (char c in "Zona1234".ToCharArray()) passWord.AppendChar(c);

                    clientContext.Credentials = new SharePointOnlineCredentials("fvaldes@clres.onmicrosoft.com", passWord);
                    List modeloList = clientContext.Web.Lists.GetByTitle("Modulo");
                    CamlQuery query = new CamlQuery();//CamlQuery.CreateAllItemsQuery(100);
                    query.ViewXml = @"<View><ViewFields><FieldRef Name='DETALLE'/>
                                <FieldRef Name='CONTROL'/>
                                <FieldRef Name='TOTAL'/></ViewFields></View>";
                    ListItemCollection items = modeloList.GetItems(query);


                    clientContext.Load(items);

                    clientContext.ExecuteQuery();
                    return View(items);
                    foreach (var listitem in items)
                    {

                        Console.WriteLine(listitem["DETALLE"].ToString());
                        Console.WriteLine(listitem["CONTROL"].ToString());
                        Console.WriteLine(listitem["TOTAL"].ToString());

                    }
                }

            }*/
            using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                if (clientContext != null)
                {
                    spUser = clientContext.Web.CurrentUser;
                    

                    // clientContext.Load(spUser, user => user.Title);
                   
                    
                    clientContext.Load(spUser, user => user.Title);
                    clientContext.ExecuteQuery();
                    ViewBag.UserName = spUser.Title;
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult template2()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult template3()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
