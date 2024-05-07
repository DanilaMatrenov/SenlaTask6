using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenlaTask6WPFNET
{
   public class ClassBuffer
    {

        [DisplayName("Предмет")]
        public  string Name { get; set; }
        [DisplayName("Вес")]
        public  int Weight { get; set; }
        [DisplayName("Стоимость")]
        public int Cost { get; set; }

    }
    
}
