using CustomGenerics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Structures {
    public class BinaryTree<T> : DataStructure<T>{

        private Node<T> root = null;

        public void addValue(T value, Comparison<T> comparison){
            InsertValue(value, comparison);
        }

        protected override void InsertValue(T value, Comparison<T> comparison){
            var newNode = new Node<T>(value);
            if (this.root == null){
                this.root = newNode;
            }else{
                this.root.addNode(newNode, comparison);
            }
        }

        public T searchValue(T value, Comparison<T> comparison){
            var found = this.root.findNode(value, comparison);
            return found;
        }

        public void traverse(){
            this.root.vistNode();
        }

        public void deleteValue(T value, Comparison<T> comparison){
            DeleteValue(value, comparison);
        }

        protected override void DeleteValue(T value, Comparison<T> comparison){
            this.root.deleteNode(this.root, value, comparison);
        }

        protected override T GetValue(){
            throw new NotImplementedException();
        }
    }
}

