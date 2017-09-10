using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Don.PhonebookCore2.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public abstract class PhonebookCore2RepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<PhonebookCore2DbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected PhonebookCore2RepositoryBase(IDbContextProvider<PhonebookCore2DbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add your common methods for all repositories
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="PhonebookCore2RepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class PhonebookCore2RepositoryBase<TEntity> : PhonebookCore2RepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected PhonebookCore2RepositoryBase(IDbContextProvider<PhonebookCore2DbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)!!!
    }
}
