using CoreAPIWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static CoreAPIWeb.Models.Common;

namespace CoreAPIWeb.Controllers
{
    /// <summary>
    /// This controller used to manupulate common entities 
    /// </summary>
    [Route("api")]
    public class CommonController : Controller
    {
        //Create common repositor constructor
        private ICommonRepository _iRepo;
        public CommonController(ICommonRepository repo)
        {
            _iRepo = repo;
        }
        /// <summary>
        /// Get List of countries based on given culture and if no culture passed english is returned by default
        /// </summary>
        /// <param name="language"></param>
        /// <returns>List of countries</returns>
     
        [HttpGet("countries/{language?}")]
        public IActionResult GetCountries(string language = "en")
        {
            List<Country> countries = _iRepo.GetAllCountries();
            return Ok(countries);
        }

        /// <summary>
        /// Get List of products based on given geographicid passed english is returned by default
        /// </summary>
        /// <param name="geographicId"></param>
        /// <returns>List of products</returns>

        [HttpGet("products/{geographicId?}")]
        public IActionResult GetProducts(string geographicId = "1")
        {
            List<Product> dt = GetDataForProducts(geographicId);
            return Ok(dt);
        }

        public List<Product> GetDataForProducts(string geographicId)
        {
        List<Product> products = new List<Product>();  
        products.Add(new Product(){ProductId=1,ProductName="BDC Global Stock Index OPaL™ Notes, Series 1",Language="en"});  
        products.Add(new Product(){ProductId=2,ProductName="Canadian Blue Chip Linked Deposit Notes, Series 1",Language="en"});  
        products.Add(new Product(){ProductId=3,ProductName="Canadian Equity Boosted Return Note Securities, Series 7",Language="en"});  
        return products;
        }

    }
   

}
