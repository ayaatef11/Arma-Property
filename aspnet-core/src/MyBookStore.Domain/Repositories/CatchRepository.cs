using MyBookStore.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;

namespace MyBookStore.Repositories
{
    //    internal class CatchRepository : EfCoreRepository<T,G>, ICatchRepository
    //he issue you are experiencing with the generic types T and G in your CatchRepository
    //class likely stems from how they are defined or constrained. When you create a generic class in C#,
    //you need to ensure that the type parameters are correctly specified, and they must follow certain rules.
    //Let’s break down what could be causing the problem.
    internal class CatchRepository <T,G>: EfCoreRepository<T,G>, ICatchRepository where T : class
        where G:class
    {
        public CatchRepository(IDbContextProvider<ArmaPropertyDbContext> dbContextProvider)
            : base(dbContextProvider) // Pass it to the base constructor
        {
        }
        //for implementing the icatch repository interface
        //refers to the process of keeping track of changes made to entities
        //so that those changes can be saved back to the database.
        public bool? IsChangeTrackingEnabled => throw new NotImplementedException();
    }
}
