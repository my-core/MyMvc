using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyMvc.Dao
{
    /// <summary>
    /// 仓储类
    /// </summary>
    public class WeiYunKeDbContext : DbContext
    {
        //public DbSet<UserInfo> Users { get; set; }
        //public DbSet<RoleInfo> Roles { get; set; }
        //public DbSet<PrivilegeInfo> Privileges { get; set; }
        //public DbSet<RolePrivilegeInfo> RolePrivilege { get; set; }
        //public DbSet<UserRoleInfo> UserRole { get; set; }


        #region 构造
        public WeiYunKeDbContext()
            : base("Name=MvcDbContext")
        {
            DbContextInit();
        }

        public WeiYunKeDbContext(string connectionName)
            : base("Name=" + connectionName)
        {
            DbContextInit();
        }

        public WeiYunKeDbContext(DbConnection conection)
            : base(conection, false)
        {
            DbContextInit();
        }
        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        private void DbContextInit()
        {
            //设置数据库初始化策略
            Database.SetInitializer<WeiYunKeDbContext>(new DataInit());
            //禁用延迟加载
            this.Configuration.LazyLoadingEnabled = false;
            //禁用代理
            this.Configuration.ProxyCreationEnabled = false;
        }
        /// <summary>
        /// 当前上下文被初始化时调用这个方法。该方法的默认实现不执行任何操作，但它可以在派生类中，该模型可以在被锁定之前重写。
        /// </summary>
        /// <param name="modelBuilder">DbModelBuilder 用于将 CLR 类映射到数据库架构。 此以代码为中心的方法称作“Code First”，可用于生成实体数据模型 (EDM) 模型。 </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {           
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
