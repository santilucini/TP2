using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso:BusinessEntity
    {
                
        public TiposCargo Cargo { get; set; }
        public int IDCurso { get; set; }
        public int IDDocente { get; set; }
        public enum TiposCargo 
        { 
            Tipo1,
            Tipo2,
            Tipo3,
            Tipo4
        }
    }
}
