using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductKeys.ViewModels
{
    public class ProductSoldView
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CutomerId { get; set; }
        public int StoreId { get; set; }
        public Nullable<System.DateTime> DateSold { get; set; }

        public virtual CustomerView Customer { get; set; }
        public virtual ProductView ProductView { get; set; }
        public virtual StoreView Store { get; set; }
    }
}