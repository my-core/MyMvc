using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyMvc.Model
{
    /// <summary>
    /// 分页器
    /// </summary>
    public class Pager
    {
        public Pager(int pageIndex, int pageSize, string orderBy, bool ascending)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            OrderBy = orderBy;
            Ascending = ascending;
        }
        //当前页面索引
        public int _PageIndex;
        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }
        //页大小 
        public int _PageSize;
        public int PageSize
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }
        //排序字段
        public string _OrderBy;
        public string OrderBy
        {
            get { return _OrderBy; }
            set { _OrderBy = value; }
        }
        //升/降序
        public bool _Ascending;
        public bool Ascending
        {
            get { return _Ascending; }
            set { _Ascending = value; }
        }
    }
}
