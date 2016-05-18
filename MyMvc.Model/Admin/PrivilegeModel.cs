using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.Model
{
    /// <summary>
    /// 权限
    /// </summary>
    public class PrivilegeModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 权限类别（1-模块 2-主窗体 3-工具栏）
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 权限编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 上级编码
        /// </summary>
        public string ParentCode { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 状态（0-停用 1-启用）
        /// </summary>
        public int Status { get; set; }


    }
}
