using System;
using System.Collections.Generic;

namespace MyCircularBuffer
{
    public class CircularBuffer<T>
    {
        private T[] _buffer;
        private int _head;
        private int _tail;
        private int _bufferSize;
        private int _length;

        object _lock = new object();

        public CircularBuffer(int bufferSize)
        {
            _bufferSize = bufferSize;
            _buffer = new T[bufferSize];
            _head = bufferSize - 1;
        }

        public bool IsEmpty
        {
            get { return _length == 0; }
        }

        public bool IsFull
        {
            get { return _length == _bufferSize; }
        }

        private int NextPosition(int position)
        {
            return (position + 1) % _bufferSize;
        }

        public T Dequeue()
        {
            lock (_lock)
            {
                if (IsEmpty) throw new InvalidOperationException("Buffer is empty!");
                T dequeued = _buffer[_tail];
                _tail = NextPosition(_tail);
                _length--;
                return dequeued;
            }
        }

        public void Enqueue(T itemToAdd)
        {
            _head = NextPosition(_head);
            _buffer[_head] = itemToAdd;
            if (IsFull)
                _tail = NextPosition(_tail);
            else
                _length++;
        }

        public List<T> Peek()
        {
            if (IsEmpty)
                return null;
            else
            {
                List<T> list = new List<T>();
                for (int i = _tail; i <= _head; i = NextPosition(i))
                {
                    list.Add(_buffer[i]);
                }
                return list;
            }
        }
    }
}
