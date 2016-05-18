using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyMvc.Common
{
    /// <summary>
    /// 对OrderBy的扩展
    /// </summary>
    public static class OrderByExtensions
    {
        /// <summary>
        /// 默认升序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName) where T : class
        {
            return OrderBy(source, propertyName, true);
            //上面代码执行没问题，但效率不好。因为每次都要动态生成表达式树，另外动态调用也会造成一定性能损失。
            //想提高效率的话，可把动态生成的表达式树缓存起来
            //return QueryableHelper<T>.OrderBy(source, propertyName, true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <param name="ascending">true-升序  false-降序</param>
        /// <returns></returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, bool ascending) where T : class
        {
            var type = typeof(T);
            var property = type.GetProperty(propertyName);
            if (property == null)
                throw new ArgumentException("propertyName", property + "不存在");

            var param = Expression.Parameter(type, "p");
            Expression propertyAccessExpression = Expression.MakeMemberAccess(param, property);
            var orderByExpression = Expression.Lambda(propertyAccessExpression, param);

            var methodName = ascending ? "OrderBy" : "OrderByDescending";
            var resultExp = Expression.Call(typeof(Queryable), methodName, new Type[] { type, property.PropertyType },
                                            source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<T>(resultExp);

            //上面代码执行没问题，但效率不好。因为每次都要动态生成表达式树，另外动态调用也会造成一定性能损失。
            //想提高效率的话，可把动态生成的表达式树缓存起来
            //return QueryableHelper<T>.OrderBy(source, propertyName, ascending);
        }
    }
    static class QueryableHelper<T> where T : class
    {
        private static Dictionary<string, LambdaExpression> cache = new Dictionary<string, LambdaExpression>();
        public static IQueryable<T> OrderBy(IQueryable<T> queryable, string propertyName, bool desc)
        {
            dynamic keySelector = GetLambdaExpression(propertyName);
            return desc ? Queryable.OrderByDescending(queryable, keySelector) : Queryable.OrderBy(queryable, keySelector);
        }
        private static LambdaExpression GetLambdaExpression(string propertyName)
        {
            if (cache.ContainsKey(propertyName)) return cache[propertyName];
            var param = Expression.Parameter(typeof(T));
            var body = Expression.Property(param, propertyName);
            var keySelector = Expression.Lambda(body, param);
            cache[propertyName] = keySelector;
            return keySelector;
        }
    }
}