using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BeautyShop.Entities
{
    class DBContext : DbContext
    {
        private static DBEntities context { get; set; }
        public static DBEntities Context
        {
            get
            {
                if (context == null)
                {
                    context = new DBEntities();
                }
                return context;
            }
        }
    }

}
