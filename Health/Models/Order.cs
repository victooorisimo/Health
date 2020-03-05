using Health.Services;
using System;
using System.Collections.Generic;

/*
 * @author: Victor Noe Hernández
 * @version: 1.0.0
 * @description: class for order objects
 */

namespace Health.Models {
    public class Order {
        //Class atributes
        public static int codeClient = 0;
        public int ClientId { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Nit { get; set; }
        public double Total { get; set; }

        public List<Medicine> medicines = new List<Medicine>();


        public bool saveOrder() {
            try {
                codeClient++;
                this.ClientId = codeClient;
                Storage.Instance.newOrder = this;
                Storage.Instance.orderList.Add(Storage.Instance.newOrder);
                return true;
            } catch {
                return false;
            }
        }
        
    }
}