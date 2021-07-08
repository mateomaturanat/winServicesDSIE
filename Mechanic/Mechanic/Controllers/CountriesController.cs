using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mechanic.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Mechanic.Controllers
{
    public class CountriesController : Controller
    {
        private const string URL = "https://mechanicdsiewebservices.azurewebsites.net/api";

        // GET: Countries
        public Country DetailsCountry(int? id)
        {
            var cliente = new RestClient(URL + "CountriesApi/" + id);
            var peticion = new RestRequest(RestSharp.Method.GET);
            var respuesta = cliente.Execute(peticion);

            var datos = respuesta.Content;//
            Country country = JsonConvert.DeserializeObject<Country>(datos);

            return country;
        }
        public ActionResult Index()
        {
            var cliente = new RestClient(URL + "CountriesApi");//
            var peticion = new RestRequest(RestSharp.Method.GET);//
            var respuesta = cliente.Execute(peticion);//

            var datos = respuesta.Content;//
            var datosJson = JsonConvert.DeserializeObject<List<Country>>(datos);//

            return View(datosJson);
        }

        // GET: Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var country = this.DetailsCountry(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCountry,NameCountry,DescriptionCountry")] Country country)
        {
            if (ModelState.IsValid)
            {
                var cliente = new RestClient(URL + "CountriesApi");
                var peticion = new RestRequest(RestSharp.Method.POST);
                peticion.AddHeader("Content-Type", "application/json");
                peticion.AddParameter("", JsonConvert.SerializeObject(country), ParameterType.RequestBody);
                var respuesta = cliente.Execute(peticion);

                return RedirectToAction("Index");
            }

            return View(country);
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var country = this.DetailsCountry(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCountry,NameCountry,DescriptionCountry")] Country country)
        {
            if (ModelState.IsValid)
            {
                var cliente = new RestClient(URL + "UsuarioApi" + country.IdCountry);
                var peticion = new RestRequest(RestSharp.Method.PUT);
                peticion.AddHeader("Content-Type", "application/json");
                peticion.AddParameter("", JsonConvert.SerializeObject(country), ParameterType.RequestBody);
                var respuesta = cliente.Execute(peticion);//

                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var country = this.DetailsCountry(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = new RestClient(URL + "CountriesApi" + id);
            var peticion = new RestRequest(RestSharp.Method.PUT);
            var respuesta = cliente.Execute(peticion);

            return RedirectToAction("Index");
        }
    }
}
