using System;
using System.Collections.Generic;
using Health.Services;

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

        public bool saveClient()
        {
            try
            {
                codeClient++;
                this.ClientId = codeClient;
                Storage.Instance.orderList.Add(this);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }


    }
}