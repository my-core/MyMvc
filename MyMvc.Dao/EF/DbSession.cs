
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMvc.Model;
using MyMvc.Dao;
namespace MyMvc.IDao
{
	/// <summary>
    /// 添加接口，起约束作用
    /// </summary>
    public partial class DbSession : IDbSession
    {
        #region ---获取数据访问层接口的仓储，数据访问层的统一入口---

		