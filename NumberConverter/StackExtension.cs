using System.Collections.Generic;

namespace NumberConverter
{
    public static class StackExtension
    {
        public static bool IsEmpty<T>(this Stack<T> stack)
        {
            bool empty;

            empty = stack.Count == 0;

            return empty;
        }

        public static Stack<T> Reverse<T>(this Stack<T> stack)
        {
            Stack<T> reverse;
            T item;

            reverse = new Stack<T>();
            while (!stack.IsEmpty())
            {
                item = stack.Pop();
                reverse.Push(item);
            }

            return reverse;
        }
    }
}
