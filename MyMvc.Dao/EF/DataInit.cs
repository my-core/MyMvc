using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyMvc.Dao
{
    /// <summary>
    /// 数据库初始化
    /// </summary>
    public class DataInit : DropCreateDatabaseIfModelChanges<WeiYunKeDbContext> 
    {
        protected override void Seed(WeiYunKeDbContext context)
        {
            //用户信息
            //var listUser = new List<UserInfo> 
            //{ 
            //    new UserInfo { UserName = "admin", Password = "123", Name="石头小神", Status=1, CreateTime = DateTime.Now }
            //};
            //listUser.ForEach(s => context.Users.Add(s));
            //context.SaveChanges();
        } 
    }
}