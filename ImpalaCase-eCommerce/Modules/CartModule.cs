using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImpalaCase_eCommerce.Modules
{
    public class CartModule
    {
        public int Id { get; set; }
        public int LoginId { get; set; }
        public int CaseId { get; set; }
        public int Quantity { get; set; }

        // Constructor
        public CartModule(int id, int loginId, int caseId, int quantity)
        {
            Id = id;
            LoginId = loginId;
            CaseId = caseId;
            Quantity = quantity;
        }
    }

}