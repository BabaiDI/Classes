using System;
using System.Collections.Generic;

namespace Task_1.Interface
{
    internal class Pagination<T> : List<T>
    {
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
            Clear();
            AddRange(list);
        }

        public int GetTotalPageSize()
        {
            return (int)Math.Ceiling((float)Count / PageSize);
        }

        public List<T> GetNextPage()
        {
            PageIndex++;
            return GetPage(PageIndex);
        }

        public List<T> GetCurrentPage()
        {
            return GetPage(PageIndex);
        }

        public List<T> GetPreviousPage()
        {
            PageIndex--;
            return GetPage(PageIndex);
        }

        public List<T> GetPage(int pageIndex)
        {
            int start = (pageIndex - 1) * PageSize;
            int end = Math.Min(Count - start, PageSize);
            return GetRange(start, end);
        }
    }
}