using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mvc5GulpWebpackVue.Controllers.Api
{
    public class DataController : ApiController
    {
        public IEnumerable<Recipe> Get()
        {
            var list = new List<Recipe>();
            string[] ingredients = new string[] { "test", "test2" };

            list.Add(new Recipe { Name = "Steak", Description = "Juicy goodness", Ingredients = new string[] { "Brush", "Pepper" }, ImageURL = "http://www.omahasteaks.com/gifs/os/dd_01_filet.jpg" });
            list.Add(new Recipe { Name = "Chicken", Description = "Fresh off the bone", Ingredients = new string[] { "Seasoning", "Stuffing" }, ImageURL = "http://damndelicious.net/wp-content/uploads/2015/06/IMG_0319edit.jpg" });
            list.Add(new Recipe { Name = "Spaghetti", Description = "Old fashioned", Ingredients = new string[] { "Sauce", "Noodles" }, ImageURL = "https://cdn.instructables.com/FY0/BMNB/IB226AMH/FY0BMNBIB226AMH.MEDIUM.jpg" });
            return list;
        }
    }



    public class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Ingredients { get; set; }

        public string ImageURL { get; set; }
    }
}
