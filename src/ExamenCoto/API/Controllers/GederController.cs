using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers {

    [RoutePrefix("gender")]
    public class GederController : ApiController {
        private GenderRUN genero = new GenderRUN();

        [HttpPost]
        [Route("add")]
        public IHttpActionResult AgregarGenero(object obj) {
            try {
                dynamic json = obj;
                var label = json.label.Value;
                bool result = genero.AddGender(label);
                if (result) {
                    return Ok("Genero agregado");
                } else {
                    return BadRequest("Ocurrio un problema");
                }
            } catch (Exception) {
                return BadRequest("Ocurrio un problema");
            }
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult ActualizarGenero(object obj) {
            try {
                dynamic json = obj;
                var genderId = Convert.ToInt32(json.genderId.Value);
                var label = json.label.Value;
                bool result = genero.UpdateGender(genderId, label);
                if (result) {
                    return Ok("Genero actulizado");
                } else {
                    return BadRequest("Ocurrio un problema");
                }
            } catch (Exception) {
                return BadRequest("Ocurrio un problema");
            }
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult EliminarGenero(object obj) {
            try {
                dynamic json = obj;
                var genderId = Convert.ToInt32(json.genderId.Value);
                bool result = genero.DeleteGenger(genderId);
                if (result) {
                    return Ok("Genero eliminado");
                } else {
                    return BadRequest("Ocurrio un problema");
                }
            } catch (Exception) {
                return BadRequest("Ocurrio un problema");
            }
        }

        [HttpPost]
        [Route("readone")]
        public IHttpActionResult ConsultarGenero(object obj) {
            try {
                dynamic json = obj;
                var genderId = Convert.ToInt32(json.genderId.Value);
                var result = genero.ConsultarGenero(genderId);
                return Ok(result);
            } catch (Exception) {
                return BadRequest("Ocurrio un problema");
            }
        }

        [HttpPost]
        [Route("read")]
        public IHttpActionResult ConsultarGeneros() {
            try {
                var result = genero.ConsultarGeneros();
                return Ok(result);
            } catch (Exception) {
                return BadRequest("Ocurrio un problema");
            }
        }
    }
}
