using CustomGenerics.Interfaces;
using System;

/*
 * @author: Victor Noe Hernández
 * @version: 1.0.0
 * @description: class for binary tree objects
 */

namespace CustomGenerics.Structures {
    public class BinaryTree<T> : DataStructure<T>{

        private Node<T> root = null;

        //Method for add element
        public void addValue(T value, Comparison<T> comparison){
            InsertValue(value, comparison);
        }

        //Method for add element
        protected override void InsertValue(T value, Comparison<T> comparison){
            var newNode = new Node<T>(value);
            if (this.root == null){
                this.root = newNode;
            }else{
                this.root.addNode(newNode, comparison);
            }
        }

        //Method for search value
        public T searchValue(T value, Comparison<T> comparison){
            var found = this.root.findNode(value, comparison);
            return found;
        }

        //Method for return incidents
        public void findIncidents(String objSearch){
            this.root.preOrder(root);
        }

        //Method for print elements
        public void traverse(){
            this.root.vistNode();
        }

        //Methods for delete element
        public void deleteValue(T value, Comparison<T> comparison){
            DeleteValue(value, comparison);
        }

        //Methods for delete element
        protected override void DeleteValue(T value, Comparison<T> comparison){
            this.root.deleteNode(this.root, value, comparison);
        }

        //Methods for return element
        protected override T GetValue(){
            throw new NotImplementedException();
        }
    }
}

