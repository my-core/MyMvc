using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.Model
{
    /// <summary>
    /// 角色权限关联
    /// </summary>
    public class RolePrivilegeModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID { get; set; }

        /// <summary>
        /// 权限Code
        /// </summary>
        public int PrivilegeID { get; set; }


    }
}
