﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class CircularDoublyLinkedList : IEnumerable
    {
        Registration head;
        int count;
        public void Add(Registration node)
        {
     

            if(head == null)
            {
                head = node;
                head.next = node;
                head.prev = node;
            }

            else
            {
                node.prev = head.prev;
                node.next = head;
                head.prev.next = node;
                head.prev = node;
            }
            count++;

        }

        public bool Remove(string num)
        {
            Registration current = head;
            Registration removedItem = null;

            // поиск удаляемого узла

            do
            {
                if (current.pass_num.Equals(num))
                {
                    removedItem = current;
                    break;
                }
                current = current.next;
            } while (current != head);

            if(removedItem != null)
            {
                if (count == 1)
                    head = null;
                else
                {
                    //если удаляется первый элемент
                    if (removedItem == head)
                        head = head.next;

                    removedItem.prev.next = removedItem.next;
                    removedItem.next.prev = removedItem.prev;
                }
                count--;
                return true;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public Registration FindPassport(string num)
        {
            Registration current = head;

            do
            {
                if (current.pass_num.Equals(num) && current.chekOut == null)
                    return current;
                current = current.next;

            } while (current != head);

            return null;
        }

        public void FindRooms(string num)
        {
            Program.rooms.Clear();
            Registration current = head;

            do
            {
                if (current.room_num.Equals(num) && current.chekOut == null)
                    Program.rooms.Add(current.pass_num);
                current = current.next;

            } while (current != head);
        }


        public bool Contains(string num)
        {
            Registration current = head;

            if (current == null)
                return false;
            do
            {
                if (current.pass_num.Equals(num))
                    return true;
                current = current.next;

            } while (current != head);
            return false;
        }

        public bool ContainsResident(string num)
        {
            Registration current = head;

            if (current == null)
                return false;
            do
            {
                if (current.pass_num.Equals(num) && current.chekOut == null)
                    return true;
                current = current.next;

            } while (current != head);
            return false;
        }

        public bool ContainsRoom(string num)
        {
            Registration current = head;

            if (current == null)
                return false;
            do
            {
                if (current.room_num.Equals(num))
                    return true;
                current = current.next;

            } while (current != head);
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Registration current = head;
            do
            {
                if (current != null)
                {
                    yield return current.pass_num;
                    current = current.next;
                }
            } while (current != head);
        }
    }
}
