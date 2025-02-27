using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //IEntityRepository görevi, Tek bir varlık türü (TEntity) üzerinde CRUD (Create, Read, Update, Delete) ve sorgulama işlemleri yapmak.
    //Tek bir varlıkla (örneğin Student, Course, vb.) ilgili temel veri erişim işlemlerini gerçekleştirir.
    //Ekleme, güncelleme, silme, ve sorgulama işlemleri için genel bir şablon sağlar.

    //IEntityRepository, tek bir varlık türü için CRUD işlemleri gibi temel veri erişim işlevlerini gerçekleştirmek için daha spesifik bir arayüzdür.
    public interface IEntityRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        Task AddAsync(TEntity input);
        Task UpdateAsync(TEntity input);
        Task DeleteAsync(TEntity input);
        Task DeleteByIdAsync(Guid id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<ICollection<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>predicate = null);
    }
}
