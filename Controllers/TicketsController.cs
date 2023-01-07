using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Linq;

namespace MovieTime.Controllers
{
    public class TicketsController : Controller
    {
        // GET: TicketController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TicketController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TicketController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostPayment()
        {
            XDocument xDocument = XDocument.Parse("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n" +
                "" +
                "@\"<Payment>\r\n\" + \"\\n\" +\r\n@\"    <Type>CreditCard</Type>\r\n\" + \"\\n\" " +                "+\r\n" +
                "@\"    <SingleUseToken>supt_ycyDB65WX8B2TCWvaSOGIz4j</SingleUseToken>\r\n\" + \"\\n\" +\r\n" +
                "@\"    <MaskedCardNumber>401200***0016</MaskedCardNumber>\r\n\" + \"\\n\" +\r\n" +
                "@\"    <CardType>visa</CardType>\r\n\" + \"\\n\" +\r\n" +
                "@\"    <CardLast4>0016</CardLast4>\r\n\" + \"\\n\" +\r\n" +
                "@\"    <ChargeAmount>1.01</ChargeAmount>\r\n\" + \"\\n\" +\r\n" +
                "@\"    <BillingStreet>6860 Dallas Pkwy</BillingStreet>\r\n\" + \"\\n\" +\r\n" +
                "@\"    <BillingZip>75024</BillingZip>\r\n\" + \"\\n\" +\r\n" +
                "@\"</Payment>\";");

            string xmlRequestBody = xDocument.ToString();

            // Create a New HttpClient object and dispose it when done, so the app doesn't leak resources
            using (HttpClient client = new HttpClient())
            {
                // Call asynchronous network methods in a try/catch block to handle exceptions
                try
                {
                    //HttpResponseMessage response =  client.PostAsync("your_external_url", new StringContent(xmlRequestBody, Encoding.UTF8, "text/xml")));

                    //response.EnsureSuccessStatusCode();

                    //// responseBody will contain the response XML document (hopefully!)
                    //string responseBody =  response.Content.ReadAsStringAsync();

                    //// parse the string into an XDocument
                    //XDocument responseDocument = XDocument.Parse(responseBody);

                    //Console.WriteLine(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Content("error " + ex.Message );
            }
        }

        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TicketController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
