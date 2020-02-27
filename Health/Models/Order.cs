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
        public double total { get; set; }


        
        public List<Order> orders = new List<Order>();


        //public List<Medicine> Medicines = null;
        //Methods getters and setters
        //public void addMedicine(Medicine medicine){
        //    Medicines.Add(medicine);
        //}

    }
}