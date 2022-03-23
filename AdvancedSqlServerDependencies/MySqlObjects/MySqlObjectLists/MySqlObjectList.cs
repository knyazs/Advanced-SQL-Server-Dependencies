using AdvancedSqlServerDependencies.SqlServer.Metadata;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedSqlServerDependencies.MySqlObjects.MySqlObjectLists
{
    public class MySqlObjectList : IList<MySqlObject>
    {
        private readonly IList<MySqlObject> _list = new List<MySqlObject>();

        public int RootCount
        {
            get
            {
                return this.Count(o => o.HierarchyLevel == 0);
            }
        }

        public int UniqueCount
        {
            get
            {
                return this.Select(d => d.ObjectNameFull).Distinct().Count();
            }
        }

        #region Implementation of IEnumerable

        public IEnumerator<MySqlObject> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection<T>

        public void Add(MySqlObject item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(MySqlObject item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(MySqlObject[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(MySqlObject item)
        {
            return _list.Remove(item);
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public bool IsReadOnly
        {
            get { return _list.IsReadOnly; }
        }

        #endregion

        #region Implementation of IList<MyDatabase>

        public int IndexOf(MySqlObject item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, MySqlObject item)
        {
            _list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public MySqlObject this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        #endregion
    }
}
