using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {

    public class GenderRUN {

        private LQGenderDataContext lQGenderDataContext;

        public GenderRUN() {
            lQGenderDataContext = new LQGenderDataContext();
        }

        public bool AddGender(string label) {
            try {
                lQGenderDataContext.agregarGenero(label);
                return true;
            } catch (Exception e) {
                var error = e.ToString();
                return false;
            }
        }

        public bool UpdateGender(int genderId,string label) {
            try {
                lQGenderDataContext.actualizarGenero(genderId, label);
                return true;
            } catch (Exception e) {
                var error = e.ToString();
                return false;
            }
        }

        public bool DeleteGenger(int genderId) {
            try {
                lQGenderDataContext.eliminarGenero(genderId);
                return true;
            } catch (Exception e) {
                var error = e.ToString();
                return false;
            }
        }

        public object ConsultarGenero(int genderId) {
            try {
                var gender = lQGenderDataContext.consultarGenero(genderId);
                return gender;
            } catch (Exception e) {
                var error = e.ToString();
                return null;
            }
        }

        public List<consultarGenerosResult> ConsultarGeneros() {
            try {
                var lista = lQGenderDataContext.consultarGeneros().ToList();
                return lista;
            } catch (Exception e) {
                var error = e.ToString();
                return null;
            }
        }
    }
}
