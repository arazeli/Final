using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace T_Shirt_Store.WebUI.AppCode.infrastructure
{
    public class BaseEntity : HistoryEntity
    {
        public int Id { get; set; }
     

    }


    public class HistoryEntity
    {
        public int? CreateById { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow.AddHours(4);
        public int? DeletedByID { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
}
