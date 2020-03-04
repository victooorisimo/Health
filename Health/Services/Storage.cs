using CustomGenerics.Structures;
using Health.Models;
using System.Collections.Generic;

/*
 * @author: Victor Noe Hernández
 * @version: 1.0.0
 * @description: class for Storage instance
 */

namespace Health.Services {
    public class Storage {
        private static Storage _instance = null;
        public static Storage Instance {
            get {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }

        public Order newOrder = new Order();
        public List<Order> orderList = new List<Order>();
        public List<Medicine> medicinesReturn = new List<Medicine>();
        public BinaryTree<Medicine> treeList = new BinaryTree<Medicine>();
        public List<Medicine> medicinesList = new List<Medicine>();

    }
}