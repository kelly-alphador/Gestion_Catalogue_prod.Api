using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_catalogue_prod.Domaine.Core.DTO
{
    public class ApiRes<T>
    {
        public bool sucess {  get; set; }
        public string? Message {  get; set; }
        public T? data { get; set; }
    }
}
