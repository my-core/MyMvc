using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.Model
{
    public class SysLogModel
    {
        /// <summary>
        /// 系统操作日志
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 模块
        /// </summary>
        public int? Module { get; set; }

        /// <summary>
        /// 操作
        /// </summary>
        public int? Operation { get; set; }

        /// <summary>
        /// 业务编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }


    }
}
