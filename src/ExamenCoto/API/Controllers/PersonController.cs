using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers {
    [RoutePrefix("person")]
    public class PersonController : ApiController {
        private PersonRUN persona = new PersonRUN();

        [HttpPost]
        [Route("add")]
        public IHttpActionResult AgregarPersona(object obj) {
            try {
                dynamic json = obj;
                var firstName = json.firstName.Value;
                var lastName = json.lastName.Value;
                var genderId = Convert.ToInt32(json.genderId.Value);
                bool result = persona.AddPerson(firstName, lastName, genderId);
                if (result) {
                    return Ok("Persona agregada");
                } else {
                    return BadRequest("Ocurrio un problema");
                }
            } catch (Exception e) {
                return BadRequest("Ocurrio un problema");
            }
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult ActualizarPersona(object obj) {
            try {
                dynamic json = obj;
                var personId = Convert.ToInt32(json.personId.Value);
                var firstName = json.firstName.Value;
                var lastName = json.lastName.Value;
                var genderId = Convert.ToInt32(json.genderId.Value);
                bool result = persona.UpdatePerson(personId, firstName, lastName, genderId);
                if (result) {
                    return Ok("Persona modificada");
                } else {
                    return BadRequest("Ocurrio un problema");
                }
            } catch (Exception e) {
                return BadRequest("Ocurrio un problema");
            }
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult EliminarPersona(object obj) {
            try {
                dynamic json = obj;
                var personId = Convert.ToInt32(json.personId.Value);
                bool result = persona.DeletePerson(personId);
                if (result) {
                    return Ok("Persona eliminada");
                } else {
                    return BadRequest("Ocurrio un problema");
                }
            } catch (Exception e) {
                return BadRequest("Ocurrio un problema");
            }
        }

        [HttpPost]
        [Route("readone")]
        public IHttpActionResult ConsultarPersona(object obj) {
            try {
                dynamic json = obj;
                var personId = Convert.ToInt32(json.personId.Value);
                var result = persona.ConsultarPersona(personId);
                return Ok(result);
            } catch (Exception e) {
                return BadRequest("Ocurrio un problema");
            }
        }

        [HttpPost]
        [Route("read")]
        public IHttpActionResult ConsultarPersonas() {
            try {
                var result = persona.ConsultarPersonas();
                return Ok(result);
            } catch (Exception e) {
                return BadRequest("Ocurrio un problema");
            }
        }
    }
}
