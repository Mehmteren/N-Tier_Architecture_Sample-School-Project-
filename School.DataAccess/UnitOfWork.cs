using Core.DataAccess;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public class UnitOfWork : IUnitOfWorks
    {
        //_context alanı, SchoolDbContext türünde bir veritabanı bağlamını temsil eder.
        //veritabanı bağlantısını kurmak
        // Entity Framework aracılığıyla veritabanında sorgular çalıştırmak için kullanılır.
        //veritabanı üzerinde bir transaction başlatmak
        //veritabanına kayıt eklemek gibi işlemler _context üzerinden yapılır.

        //UnitOfWork sınıfı içinde birden fazla işlem yapılacaksa (örneğin birden
        //fazla tabloya veri eklemek), tüm işlemler aynı _context üzerinden yapılır.
        //Bu, tüm işlemlerin tek bir transaction içinde gerçekleştirilmesini
        //ve hata durumunda tüm işlemlerin geri alınmasını sağlar.

        //private dememin sebebide sadece unitofwork sınıfı tarafından erişilmesini istiyorum 
        //güvenlk amaçlı

        //readonly dememizin sebebi, _context değişkeninin yalnızca constructor içinde
        //set edilebilmesini ve sonrasında değiştirilemez olmasını sağlamaktır. 
        //Bu sayede _context veritabanı işlemlerinde kullanılabilir hale geliyor.
        private readonly SchoolDbContext _context;




        public UnitOfWork(SchoolDbContext context)


        //SchoolDbContext türündeki context parametresini UnitOfWork sınıfının
        //constructor'ına geçiriyorum ve bu parametreyi _context adlı private ve
        //readonly alana atıyorum. Bu sayede, veritabanı işlemlerimi EfEntityRepositoryBase
        //gibi repository sınıflarına aktararak veya doğrudan _context üzerinden gerçekleştirebiliyorum.
        {
            _context = context;
        }




        public async Task BeginTransactionAsync()
        //Yeni bir veritabanı işlemi (transaction) başlatır.
        //Birden fazla işlemin bir bütün olarak yapılmasını istediğinizde kullanılır.
        {
            await _context.Database.BeginTransactionAsync();
        }
        public async Task CommitTransactionAsync()
            //CommitTransactionAsync metodu, _context içerisindeki veritabanı işlemlerini onaylamak için
            //_context.Database.CommitTransactionAsync() çağrısını asenkron olarak gerçekleştirir.
            //Bu metot sayesinde, başlatılmış bir veritabanı işlemine ait tüm değişiklikler kalıcı hale getirilir
            //ve asenkron yapısıyla işlem sırasında uygulamanın bloklanması önlenir, böylece daha iyi performans ve
            //kullanıcı deneyimi sağlanır.
        {
            await _context.Database.CommitTransactionAsync();
        }
        public IEntityRepository<TEntity> GenerateRepository<TEntity>() where TEntity : BaseEntity, new()
            //GenerateRepository metodu, generic bir TEntity türü için bir EfEntityRepositoryBase<TEntity,
            //SchoolDbContext> nesnesi oluşturur ve _context parametresini bu nesneye aktarır. Bu sayede,
            //TEntity ile ilişkili veritabanı işlemleri EfEntityRepositoryBase üzerinden gerçekleştirilebilir.
            //where TEntity : BaseEntity, new() kısıtı, sadece BaseEntity sınıfından türeyen ve
            //bir parametresiz kurucuya sahip varlıklar için repository oluşturulmasını sağlar.
        {
            return new EfEntityRepositoryBase<TEntity,SchoolDbContext> (_context);
        }



        public async Task RollTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }
    }
}
