using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DependentDropdown.Models;
using NUnit.Framework;

namespace DependentDropdown.Controllers
{
    public class DropDownController : Controller
    {
        // GET: DropDown
        
        public ActionResult Index()
        {
            locationEntities sd = new locationEntities();
            ViewBag.CountryList = new SelectList(GetCountryList(), "Cid", "Cname");
            return View();
        }

      
        public List<country> GetCountryList()
        {
            locationEntities sd = new locationEntities();
            List<country> countries = sd.countries.ToList();
            return countries;
        }

        
        public ActionResult GetStateList(int Cid)
        {
            locationEntities sd = new locationEntities();
            List<State> selectList = sd.States.Where(x => x.Cid == Cid).ToList();
            ViewBag.Slist = new SelectList(selectList, "Sid", "Sname");
            return PartialView("DisplayStates");
        }

        public ActionResult GetCityList(int Sid)
        {
            locationEntities sd = new locationEntities();
            List<City> selectList = sd.Cities.Where(x => x.Sid == Sid).ToList();
            ViewBag.Citylist = new SelectList(selectList, "Cityid", "Cityname");
            return PartialView("DisplayCities");
        }

    }
}