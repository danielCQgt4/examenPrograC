using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {

    public class PersonRUN {

        private LQPersonDataContext lQPersonDataContext;

        public PersonRUN() {
            lQPersonDataContext = new LQPersonDataContext();
        }

        public bool AddPerson(string firstName, string lastName, int genderId) {
            try {
                lQPersonDataContext.agregarPersona(firstName, lastName, genderId);
                return true;
            } catch (Exception e) {
                var error = e.ToString();
                return false;
            }
        }

        public bool UpdatePerson(int personId, string firstName, string lastName, int genderId) {
            try {
                lQPersonDataContext.actualizarPersona(personId, firstName, lastName, genderId);
                return true;
            } catch (Exception e) {
                var error = e.ToString();
                return false;
            }
        }

        public bool DeletePerson(int personId) {
            try {
                lQPersonDataContext.eliminarPersonas(personId);
                return true;
            } catch (Exception e) {
                var error = e.ToString();
                return false;
            }
        }

        public object ConsultarPersona(int personId) {
            try {
                var person = lQPersonDataContext.consultarPersona(personId);
                return person;
            } catch (Exception e) {
                var error = e.ToString();
                return null;
            }
        }

        public List<consultarPersonasResult> ConsultarPersonas() {
            try {
                var people = lQPersonDataContext.consultarPersonas().ToList();
                return people;
            } catch (Exception e) {
                var error = e.ToString();
                return null;
            }
        }
    }
}
