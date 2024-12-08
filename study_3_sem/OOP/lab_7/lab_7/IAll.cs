using System;
namespace lab_7
{
    public interface IAll<T>
    {
        void Add(T item);
        void Delete(T item);
        void Get();
    }
}