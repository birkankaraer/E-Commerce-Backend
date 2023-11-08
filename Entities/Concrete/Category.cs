using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    /*Çıplak Class Kalmasın inheritance, Interface Imp. almıyorsa ilerde sıkıntı yaşanır demektir.
    Classın Category classı olması gibi*/
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
