using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Health.Models {
    public class Medicine {
        
        private int idMedicine;
        private String name;
        private String description;
        private String producer;
        private double price;
        private int stock;

        public Medicine(){}

        public int getIdMedicine(){
            return this.idMedicine;
        }

        public void setIdMedicine(int idMedicine){
            this.idMedicine = idMedicine;
        }

        public String getName(){
            return name;
        }

        public void setName(String name){
            this.name = name;
        }

        public String getDescription(){
            return description;
        }

        public void setDescription(String description){
            this.description = description;
        }

        public String getProducer(){
            return producer;
        }

        public void setProducer(String producer){
            this.producer = producer;
        }

        public int getStock(){
            return this.stock;
        }

        public void setStock(int stock){
            this.stock = stock;
        }

        public double getPrice(){
            return this.price;
        }

        public void setPrice(double price){
            this.price = price;
        }
    }
}