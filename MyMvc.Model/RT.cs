using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMvc.Model
{
    public static class RT
    {
        /// <summary>
        /// 成功
        /// </summary>
        public const int SUCCESS = 0;
        /// <summary>
        /// 失败
        /// </summary>
        public const int FAILED = -1;
        /// <summary>
        /// 存在
        /// </summary>
        public const int RES_EXIST = 10001;
        /// <summary>
        /// 不存在
        /// </summary>
        public const int RES_NOTEXIST = 10002;
        /// <summary>
        /// 密码错误
        /// </summary>
        public const int RES_PWD_ERROR = 10003;
        /// <summary>
        /// 锁定
        /// </summary>
        public const int RES_LOCK = 10004;
    }
}
