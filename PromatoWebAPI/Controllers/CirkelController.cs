using PromatoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PromatoWebAPI.Controllers
{
    public class CirkelController : ApiController
    {
        Cirkel[] cirkels = new Cirkel[]
        {
            new Cirkel {CirkelSvg = "<svg>yolo</svg>" }
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
        public HttpResponseMessage MooieCirkel()
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
                Content = new StringContent(httpCirkel.CirkelSvg),
            };


            return response;

        }
    }
}
