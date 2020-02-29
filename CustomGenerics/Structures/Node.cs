using System;

/*
 * @author: Victor Noe Hernández
 * @version: 1.0.0
 * @description: class for Nodes
 */

namespace CustomGenerics.Structures{
    public class Node<T> {
        //Class atributes
        private Node<T> leftNode;
        private Node<T> rightNode;
        private T valueNode;

        //Constructor method.
        public Node(T value) {
            this.valueNode = value;
            this.rightNode = null;
            this.rightNode = null;
        }

        //Method for delete node. 
        public Node<T> deleteNode(Node<T> aux, T data, Comparison<T> comparison) {
            if (aux == null){
                return null;
            }else if (comparison.Invoke(data, aux.getValue()) < 0){
                Node<T> leftN = deleteNode(aux.getLeftNode(), data, comparison);
                aux.setLeftNode(leftN);
            }else if (comparison.Invoke(data, aux.getValue()) > 0) {
                Node<T> rightN = deleteNode(aux.getRightNode(), data, comparison);
                aux.setRightNode(rightN);
            } else {
                Node<T> prev = aux;
                if (prev.getRightNode() == null) {
                    aux = prev.getLeftNode();
                } else if (prev.getLeftNode() == null){
                    aux = prev.getRightNode();
                }else{
                    prev = changeNode(prev);
                }
                prev = null;
            }
            return aux;
        }

        //Method for change node. 
        protected Node<T> changeNode(Node<T> aux){
            Node<T> prev = aux;
            Node<T> anterior = aux.getLeftNode();
            while (anterior.getRightNode() != null){
                prev = anterior;
                anterior = anterior.getRightNode();
            }
            aux.setValue(anterior.getValue());
            if (prev == aux){
                prev.setLeftNode(anterior.getLeftNode());
            }else{
                prev.setRightNode(anterior.getLeftNode());
            }
            return anterior;
        }

        public T vistNode() {
            if (this.leftNode != null){
                this.leftNode.vistNode();
            }
            if (this.rightNode != null){
                this.rightNode.vistNode();
            }
            return this.getValue();
        }

        //Method for add node in tree
        public void addNode(Node<T> newNode, Comparison<T> comparison){
            if (comparison.Invoke(newNode.getValue(), this.getValue()) < 0) {
                if (this.leftNode == null){
                    this.leftNode = newNode;
                }else{
                    this.leftNode.addNode(newNode, comparison);
                }
            }else if (comparison.Invoke(newNode.getValue(), this.getValue()) > 0){
                if (rightNode == null){
                    this.rightNode = newNode;
                }else{
                    this.rightNode.addNode(newNode, comparison);
                }
            }
        }

        //
        public void preOrder(Node<T> auxiliar){

        }


        //Method for find element in tree
        public T findNode(T value, Comparison<T> comparison){
            //if (this.getValue().Equals(value)){
            //    return this.valueNode;
            //}else if ((comparison.Invoke(value, this.getValue()) < 0).Equals(this.leftNode) != null){
            //    return this.leftNode.findNode(value, comparison);
            //}else if ((comparison.Invoke(value, this.getValue()) > 0).Equals(this.rightNode) != null){
            //    return this.rightNode.findNode(value, comparison);
            //}
            return default(T);
        }

        //Methods getters and setters
        public void setLeftNode(Node<T> leftNode){
            this.leftNode = leftNode;
        }

        //Getters and setters
        public Node<T> getLeftNode(){
            return this.leftNode;
        }

        public void setRightNode(Node<T> rightNode){
            this.rightNode = rightNode;
        }

        public Node<T> getRightNode(){
            return this.rightNode;
        }

        public void setValue(T valueNode){
            this.valueNode = valueNode;
        }

        public T getValue(){
            return this.valueNode;
        }
    }
}

