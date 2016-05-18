using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Data;
using System.Linq.Expressions;
using System.Linq;
using MyMvc.Model;
using MyMvc.Common;
using Webdiyer.WebControls.Mvc;
using MyMvc.IDao;

namespace MyMvc.Dao
{
    /// <summary>
    /// 数据持久化通用实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDao<T> : IBaseDao<T> where T : class , new()
    {
        #region EF上下文的实例保证，线程内唯一
        //获取的实当前线程内部的上下文实例，而且保证了线程内上下文实例唯一
        private DbContext DbContext = EFContextFactory.GetCurrentDbContext();
        #endregion


        /// <summary>
        /// 获取IQueryable
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<T> GetQuery()
        {
            return DbContext.Set<T>();
        }

        /// <summary>
        /// 根据条件获取IQueryable
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        /// <returns>IQueryable</returns>
        public IQueryable<T> GetQuery(Expression<Func<T, bool>> exp)
        {
            return DbContext.Set<T>().Where(exp);
        }

        /// <summary>
        /// 根据主键属性得到实体
        /// </summary>
        /// <param name="objectId">主键属性值</param>
        /// <returns>实体</returns>
        public T Find(object objectId)
        {
            return DbContext.Set<T>().Find(objectId);
        }

        /// <summary>
        /// 根据指定SQL语句查询集合
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public IQueryable<T> SqlQueryList(string strSql)
        {
            return DbContext.Set<T>().SqlQuery(strSql).AsQueryable();
        }

        /// <summary>
        /// 根据指定SQL语句查询唯一实体
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public T SqlQueryEntity(string strSql)
        {
            return DbContext.Set<T>().SqlQuery(strSql).AsQueryable().SingleOrDefault();
        }

        /// <summary>
        /// 根据条件获取唯一的实体
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        /// <returns>实体</returns>
        public T SingleOrDefault(Expression<Func<T, bool>> exp)
        {
            return DbContext.Set<T>().SingleOrDefault(exp);
        }

        /// <summary>
        /// 根据条件获取第一条实体
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        /// <returns>实体</returns>
        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return DbContext.Set<T>().FirstOrDefault(exp);
        }

        /// <summary>
        /// 获取最后一个实体
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        /// <returns>实体</returns>
        public T LastOrDefault()
        {
            return DbContext.Set<T>().LastOrDefault();
        }

        /// <summary>
        /// 根据条件获取最后一个实体
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        /// <returns>实体</returns>
        public T LastOrDefault(Expression<Func<T, bool>> exp)
        {
            return DbContext.Set<T>().LastOrDefault(exp);
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        /// <returns>实体列表</returns>
        public List<T> GetList(Expression<Func<T, bool>> exp)
        {
            return DbContext.Set<T>().Where(exp).ToList();
        }

        /// <summary>
        /// 根据条件获取列表，并排序
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="ascending">是否升序</param>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T, bool>> exp, string orderBy, bool @ascending)
        {
            //return DbContext.Set<T>().Where(exp).ToList();
            //这里使用OrderByExtensions.cs文件的扩展
            return DbContext.Set<T>().Where(exp).OrderBy(orderBy, ascending).ToList();
            
        }

        /// <summary>
        /// 根据条件获取列表，并排序
        /// </summary>
        /// <param name="exp">sql语句</param>
        /// <returns></returns>
        public List<T> GetList(string sql)
        {
            return DbContext.Set<T>().SqlQuery(sql).ToList();
        }

        #region MvcPager的分页方法
        /// <summary>
        /// 根据条件获取分页列表
        /// </summary>
        /// <param name="p">分页器</param>
        /// <param name="exp">查询条件表达式</param>
        /// <returns></returns>
        public PagedList<T> GetPagedList(Pager p, Expression<Func<T, bool>> exp)
        {
            return DbContext.Set<T>().Where(exp).OrderBy(p.OrderBy, p.Ascending).ToPagedList(p.PageIndex, p.PageSize);
        }
        /// <summary>
        /// 根据条件获取分页列表
        /// </summary>
        /// <param name="p">分页器</param>
        /// <returns></returns>
        public PagedList<T> GetPagedList(Pager p)
        {
            return DbContext.Set<T>().OrderBy(p.OrderBy, p.Ascending).ToPagedList(p.PageIndex, p.PageSize);
        }
        #endregion

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity">实体</param>
        public int Add(T entity)
        {
            try
            {
                DbContext.Set<T>().Add(entity);
                return DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="list">实体集合</param>
        public int AddList(IEnumerable<T> list)
        {
            try
            {
                DbContext.Configuration.AutoDetectChangesEnabled = false;
                foreach (var item in list)
                {
                    DbContext.Set<T>().Add(item);
                }
               return DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DbContext.Configuration.AutoDetectChangesEnabled = true;
            }
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="IsChange"></param>
        /// <returns></returns>
        public int Update(T entity)
        {
            try
            {
                DbContext.Entry<T>(entity).State = EntityState.Modified;
                return DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public int Delete(T entity)
        {
            try
            {
                DbContext.Set<T>().Remove(entity);
                return DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        public int Delete(Expression<Func<T, bool>> exp)
        {
            try
            {
                var list = DbContext.Set<T>().Where(exp);
                DbContext.Configuration.AutoDetectChangesEnabled = false;
                foreach (var entity in list)
                {
                    DbContext.Set<T>().Remove(entity);
                }
               return DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DbContext.Configuration.AutoDetectChangesEnabled = true;
            }
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <returns>总数</returns>
        public int Count()
        {
            return DbContext.Set<T>().Count();
        }

        /// <summary>
        /// 根据条件获取总数
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        /// <returns>总数</returns>
        public int Count(Expression<Func<T, bool>> exp)
        {
            return DbContext.Set<T>().Count(exp);
        }
    }
}
