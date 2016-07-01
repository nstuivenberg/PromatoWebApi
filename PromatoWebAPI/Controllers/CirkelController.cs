using PromatoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace PromatoWebAPI.Controllers
{
    public class CirkelController : ApiController
    {
        Cirkel[] cirkels = new Cirkel[]
        {
            new Cirkel
            {
                CirkelSvg ="<svg height='100' width='100'><circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' /></svg>"
            }
        };

        /// <summary>
        /// Hier mogelijk XML of X-document in!
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetCirkel()
        {
            var httpCirkel = cirkels.FirstOrDefault();
            if (httpCirkel == null)
            {
                return NotFound();
            }
            return Ok("Test: " + httpCirkel.CirkelSvg.ToString());
        }

        //POST!
        [HttpPost]
        public HttpResponseMessage MooieCirkel([FromBody] string value)
        {
            var httpCirkel = cirkels.FirstOrDefault();
            if (httpCirkel == null)
            {
                var responseWrong = new HttpResponseMessage()
                {
                    Content = new StringContent("yolo"),
                };

                return responseWrong;
            }
            var response = new HttpResponseMessage()
            {
                Content = new StringContent("POST: " + httpCirkel.CirkelSvg)
            };


            return response;

        }
        /*
        public HttpResponseMessage CirkelFour([FromBody] string value)
        {

            var response = new HttpResponseMessage()
            {
                Content = new StringContent("POST NIEUW: " + value)
            };

            return response;
        }
        */

    }
}
