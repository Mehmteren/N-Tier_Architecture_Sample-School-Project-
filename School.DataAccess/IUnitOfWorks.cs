using Core.DataAccess;
using Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public interface IUnitOfWorks
    {
        //IUnitOfWorks un görevi Birden fazla repository'yi bir arada yönetmek ve transaction (işlem bütünlüğü) yönetimini sağlamaktır.
        //Farklı varlıklarla ilgili birden fazla işlem yapılacaksa, bu işlemleri bir transaction içinde toplar ve işlem bütünlüğü sağlar.
        // Repository oluşturma(GenerateRepository) ve transaction işlemlerini(BeginTransactionAsync, CommitTransactionAsync, RollTransactionAsync) kapsar.

        //IUnitOfWorks, birden fazla repository'yi ve veritabanı işlemlerini transaction ile yönetmek için daha genel ve üst düzey bir arayüzdür.
        IEntityRepository<TEntity>GenerateRepository<TEntity>() where TEntity : BaseEntity, new();

        Task BeginTransactionAsync();
        Task RollTransactionAsync();
        Task CommitTransactionAsync();

    }
}
