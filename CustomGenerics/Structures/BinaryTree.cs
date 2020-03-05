using CustomGenerics.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

/*
 * @author: Victor Noe Hernández
 * @version: 1.0.0
 * @description: class for binary tree objects
 */

namespace CustomGenerics.Structures {
    public class BinaryTree<T> : DataStructure<T>, IEnumerable<T>{

        private Node<T> root = null;
        public static int cantElements = 0;

        public int cantsElements(){
            return cantElements;
        }

        //Method for add element
        public void addValue(T value, Comparison<T> comparison){
            InsertValue(value, comparison);
            cantElements++;
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
            return default(T);
        }

        public IEnumerator<T> GetEnumerator(){
            int iteration = 0;
            while (iteration < cantElements){
                yield return this.root.postOrder(this.root);
                iteration++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator(){
           return GetEnumerator();
        }
    }
}

