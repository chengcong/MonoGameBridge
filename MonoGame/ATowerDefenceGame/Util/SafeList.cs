using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ATowerDefenceGame.Util
{
    public class SafeList<T> : IEnumerable<T>
    {
        public List<T> List;
        public List<T> Added;
        public List<T> Removed;

        public SafeList()
        {
            List = new List<T>();
            Added = new List<T>();
            Removed = new List<T>();
        }

        public void Add(T obj)
        {
            Added.Add(obj);
        }

        public void Remove(T obj)
        {
            Removed.Add(obj);
        }

        public void Commit()
        {
            if (Added.Any())
            {
                foreach (var obj in Added)
                    List.Add(obj);
                Added.Clear();
            }
            if (Removed.Any())
            {
                foreach (var obj in Removed)
                    List.Remove(obj);
                Removed.Clear();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}