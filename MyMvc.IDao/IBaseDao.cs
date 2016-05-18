using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using MyMvc.Model;
using Webdiyer.WebControls.Mvc;

namespace MyMvc.IDao
{
    public interface IBaseDao<T> where T : class ,new()
    {
        /// <summary>
        /// 获取IQueryable
        /// </summary>
        /// <returns>IQueryable</returns>
        IQueryable<T> GetQuery();

        /// <summary>
        /// 根据条件获取IQueryable
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <returns>IQueryable</returns>
        IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 根据主键属性得到实体
        /// </summary>
        /// <param name="objectId">主键属性值</param>
        /// <returns>实体</returns>
        T Find(object objectId);

        /// <summary>
        /// 根据条件获取唯一的实体
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <returns>实体</returns>
        T SingleOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 根据条件获取第一条实体
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <returns>实体</returns>
        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 获取最后一个实体
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <returns>实体</returns>
        T LastOrDefault();

        /// <summary>
        /// 根据条件获取最后一个实体
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <returns>实体</returns>
        T LastOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <returns>实体列表</returns>
        List<T> GetList(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 根据条件获取列表，并排序
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="ascending">是否升序</param>
        /// <returns></returns>
        List<T> GetList(Expression<Func<T, bool>> predicate, string orderBy, bool @ascending);

        #region MvcPager的分页方法
        /// <summary>
        /// 根据条件获取分页列表
        /// </summary>
        /// <param name="p">分页器</param>
        /// <param name="exp">查询条件表达式</param>
        /// <returns></returns>
        PagedList<T> GetPagedList(Pager p, Expression<Func<T, bool>> exp);
        /// <summary>
        /// 根据条件获取分页列表
        /// </summary>
        /// <param name="p">分页器</param>
        /// <returns></returns>
        PagedList<T> GetPagedList(Pager p);
        #endregion
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity">实体</param>
        int Add(T entity);


        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="list">实体集合</param>
        int AddList(IEnumerable<T> list);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="IsChange"></param>
        /// <returns></returns>
        int Update(T entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        int Delete(T entity);

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        int Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <returns>总数</returns>
        int Count();

        /// <summary>
        /// 根据条件获取总数
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <returns>总数</returns>
        int Count(Expression<Func<T, bool>> predicate);
    }
}
