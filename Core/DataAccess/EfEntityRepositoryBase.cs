using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{

    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext

        //EfEntityRepositoryBase sınıfının constructor'ında, TContext türündeki context parametresini alıyorum
        //ve bunu Context adlı protected ve readonly alana atıyorum.
        //Bu sayede, DbContext'e erişim sağlayarak veritabanı işlemlerini gerçekleştirebiliyorum.

    {
        protected readonly TContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public EfEntityRepositoryBase(TContext context) { 
            Context = context; 
            DbSet = context.Set<TEntity>();
            //    //EfEntityRepositoryBase sınıfının constructor'ında, TContext türündeki context parametresini alıyorum
            //ve bunu Context adlı protected ve readonly alana atıyorum.
            //Bu sayede, DbContext'e erişim sağlayarak veritabanı işlemlerini gerçekleştirebiliyorum.
        }
        public async Task AddAsync(TEntity input)
        {
            //AddAsync metodu, TEntity türündeki bir varlığı veritabanına eklemek için asenkron olarak çalışır.
            //Metodun içinde, DbSet.AddAsync(input) çağrısıyla input parametresinde verilen varlık,
            //veritabanına eklenmek üzere işaretlenir. Daha sonra, Context.SaveChangesAsync() çağrısıyla
            //ekleme işlemi veritabanına kalıcı olarak uygulanır.
            await DbSet.AddAsync(input);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity input)
        {
            DbSet.Remove(input);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            //DeleteByIdAsync metodu, Guid türündeki bir id parametresini kullanarak belirtilen varlığı
            //veritabanından silmek için asenkron olarak çalışır.Öncelikle, DbSet.Find(id) çağrısıyla
            //id'ye karşılık gelen varlık bulunur. Daha sonra, bu varlık DeleteAsync metoduna aktarılır
            //ve asenkron olarak silinir. Bu yapı, varlığı doğrudan id değeri üzerinden bulup silmeyi kolaylaştırır.
            var entity = DbSet.Find(id);
            await DeleteAsync(entity);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<ICollection<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            //GetListAsync metodu, bir koşula(predicate) uyan TEntity türündeki varlıkların listesini asenkron
            //olarak döndürmek için çalışır. Eğer predicate parametresi verilmezse(null olursa), tüm varlıkları
            //getirir.DbSet.Where(predicate) çağrısıyla belirtilen koşula göre filtreleme yapılır ve ardından
            //ToListAsync() çağrısıyla sonuçlar bir koleksiyona dönüştürülür.Bu asenkron yapı sayesinde işlem
            //sırasında uygulamanın bloklanması önlenir ve geniş veri kümeleriyle performanslı bir şekilde
            //çalışılabilir.
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task UpdateAsync(TEntity input)
        {
            DbSet.Update(input);
            await Context.SaveChangesAsync();
        }
    }
}
