using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Webdiyer.WebControls.Mvc;
using MyMvc.IDao;
using MyMvc.IService;
using MyMvc.Model;

namespace MyMvc.Service
{
    /// <summary>
    /// 业务基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseService<T> : IBaseService<T> where T : class, new()
    {
        #region 仓储相关
        /// <summary>
        /// 当前仓储。在调用这个方法的时候必须给他赋值
        /// </summary>
        public IBaseDao<T> CurrentRepository { get; set; }
        /// <summary>
        /// 为了职责单一的原则，将获取线程内唯一实例的DbSession的逻辑放到工厂里面去了
        /// public IDAL.IDbSession _DbSession = DbSessionFactory.GetCurrentDbSession();
        /// </summary>
        //public IDbSession _dbSession = DbFactory.GetCurrentDbSession();
        /// <summary>
        /// 基类的构造函数.构造函数里面调用了此设置当前仓储的抽象方法
        /// </summary>
        //public BaseService()
        //{
        //    SetCurrentRepository();  
        //}
        /// <summary>
        /// 构造方法实现赋值 
        /// 约束子类必须实现这个抽象方法
        /// </summary>
       //public abstract void SetCurrentRepository();

        #endregion

        /// <summary>
        /// 获取IQueryable
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<T> GetQuery()
        {
            return CurrentRepository.GetQuery();
        }

        /// <summary>
        /// 根据条件获取IQueryable
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        /// <returns>IQueryable</returns>
        public IQueryable<T> GetQuery(Expression<Func<T, bool>> exp)
        {
            return CurrentRepository.GetQuery(exp);
        }

        /// <summary>
        /// 根据主键属性得到实体
        /// </summary>
        /// <param name="objectId">主键属性值</param>
        /// <returns>实体</returns>
        public T Find(object objectId)
        {
            return CurrentRepository.Find(objectId);
        }

        /// <summary>
        /// 根据条件获取唯一的实体
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        /// <returns>实体</returns>
        public T SingleOrDefault(Expression<Func<T, bool>> exp)
        {
            return CurrentRepository.SingleOrDefault(exp);
        }

        /// <summary>
        /// 根据条件获取第一条实体
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        /// <returns>实体</returns>
        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return CurrentRepository.FirstOrDefault(exp);
        }

        /// <summary>
        /// 获取最后一个实体
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        /// <returns>实体</returns>
        public T LastOrDefault()
        {
            return CurrentRepository.LastOrDefault();
        }

        /// <summary>
        /// 根据条件获取最后一个实体
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        /// <returns>实体</returns>
        public T LastOrDefault(Expression<Func<T, bool>> exp)
        {
            return CurrentRepository.LastOrDefault(exp);
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        /// <returns>实体列表</returns>
        public List<T> GetList(Expression<Func<T, bool>> exp)
        {
            return CurrentRepository.GetList(exp);
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
            return CurrentRepository.GetList(exp, orderBy, ascending);
        }

        /// <summary>
        /// 根据条件获取分页列表
        /// </summary>
        /// <param name="p">分页器</param>
        /// <param name="exp">查询条件表达式</param>
        /// <returns></returns>
        public PagedList<T> GetPagedList(Pager p, Expression<Func<T, bool>> exp)
        {
            return CurrentRepository.GetPagedList(p,exp);
        }
        /// <summary>
        /// 根据条件获取分页列表
        /// </summary>
        /// <param name="p">分页器</param>
        /// <returns></returns>
        public PagedList<T> GetPagedList(Pager p)
        {
            return CurrentRepository.GetPagedList(p);
        }
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity">实体</param>
        public int Add(T entity)
        {
            if (CurrentRepository.Add(entity) > 0)
            {
                return RT.SUCCESS;
            }
            return RT.FAILED;
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="list">实体集合</param>
        public int AddList(IEnumerable<T> list)
        {
            if (CurrentRepository.AddList(list) > 0)
            {
                return RT.SUCCESS;
            }
            return RT.FAILED;
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="IsChange"></param>
        /// <returns></returns>
        public int Update(T entity)
        {
            if (CurrentRepository.Update(entity) > 0)
            {
                return RT.SUCCESS;
            }
            return RT.FAILED;
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public int Delete(T entity)
        {
            if (CurrentRepository.Delete(entity) > 0)
            {
                return RT.SUCCESS;
            }
            return RT.FAILED;
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        public int Delete(Expression<Func<T, bool>> exp)
        {
            if (CurrentRepository.Delete(exp) > 0)
            {
                return RT.SUCCESS;
            }
            return RT.FAILED;
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <returns>总数</returns>
        public int Count()
        {
            return CurrentRepository.Count();
        }

        /// <summary>
        /// 根据条件获取总数
        /// </summary>
        /// <param name="exp">查询条件表达式</param>
        /// <returns>总数</returns>
        public int Count(Expression<Func<T, bool>> exp)
        {
            return CurrentRepository.Count(exp);
        }
    }
}
