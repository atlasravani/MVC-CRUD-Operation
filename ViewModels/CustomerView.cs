using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductKeys.ViewModels
{
    public class CustomerView
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerView()
        {
            this.ProductSolds = new HashSet<ProductSoldView>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSoldView> ProductSolds { get; set; }
    }
}