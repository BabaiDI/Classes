using System;
using System.Collections.Generic;

namespace Task_1.Interface
{
    internal class Pagination<T>
    {
        private List<T> list = new();
        private int pageIndex = 1;
        public int PageIndex
        {
            get => pageIndex;
            set
            {
                value = Math.Max(1, value);
                value = Math.Min(GetTotalPageSize(), value);

                pageIndex = value;
            }
        }
        private int pageSize;
        public int PageSize
        {
            get => pageSize;
            set
            {
                pageSize = (value > 1) ? value : 1;
            }
        }

        public Pagination(int pageSize)
        {
            this.pageSize = pageSize;
        }

        public void Update(List<T> list)
        {
            this.list = list;
        }

        public int GetTotalPageSize()
        {
            return (int)Math.Ceiling((float)list.Count / PageSize);
        }

        public List<T> NextPage()
        {
            PageIndex++;
            return GetPage();
        }

        public List<T> CurrentPage()
        {
            return GetPage();
        }

        public List<T> PreviousPage()
        {
            PageIndex--;
            return GetPage();
        }

        public List<T> GoToPage(int pageIndex)
        {
            PageIndex = pageIndex;
            return GetPage();
        }

        private List<T> GetPage()
        {
            int start = (PageIndex - 1) * PageSize;
            int count = Math.Min(list.Count - start, PageSize);
            return list.GetRange(start, count);
        }
    }
}