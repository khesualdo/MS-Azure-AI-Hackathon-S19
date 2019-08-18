#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    string name = req.Query["name"];

    if (name == "lychee"){
        return (ActionResult)new OkObjectResult("Not Allowed | Lychee is the sole member of the genus Litchi in the soapberry family, Sapindaceae. It is a tropical tree native to the Guangdong and Fujian provinces of China, where cultivation is documented from 1059 AD.");
    } else if (name == "banana") {
        return (ActionResult)new OkObjectResult("Allowed | A banana is an edible fruit – botanically a berry – produced by several kinds of large herbaceous flowering plants in the genus Musa. In some countries, bananas used for cooking may be called plantains, distinguishing them from dessert bananas.");
    } else if (name == "blueberry") {
        return (ActionResult)new OkObjectResult("Allowed | Blueberries are perennial flowering plants with blue– or purple–colored berries. They are classified in the section Cyanococcus within the genus Vaccinium. Vaccinium also includes cranberries, bilberries, huckleberries and Madeira blueberries.");
    } else if (name == "avocado") {
        return (ActionResult)new OkObjectResult("Allowed | The avocado, a tree with probable origin in South Central Mexico, is classified as a member of the flowering plant family Lauraceae. The fruit of the plant, also called an avocado, is botanically a large berry containing a single large seed.");
    } else if (name == "pepino") {
        return (ActionResult)new OkObjectResult("Not Allowed | Solanum muricatum is a species of evergreen shrub native to South America and grown for its sweet edible fruit. It is known as pepino dulce or simply pepino.");
    } else if (name == "salak") {
        return (ActionResult)new OkObjectResult("Not Allowed | Salak is a species of palm tree native to Java and Sumatra in Indonesia. It is cultivated in other regions of Indonesia as a food crop, and reportedly naturalized in Bali, Lombok, Timor, Maluku, and Sulawesi.");
    } else {
        return (ActionResult)new OkObjectResult("Not Allowed");
    }
}