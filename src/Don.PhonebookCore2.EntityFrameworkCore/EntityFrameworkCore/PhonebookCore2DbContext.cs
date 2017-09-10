﻿using Abp.Zero.EntityFrameworkCore;
using Don.PhonebookCore2.Authorization.Roles;
using Don.PhonebookCore2.Authorization.Users;
using Don.PhonebookCore2.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace Don.PhonebookCore2.EntityFrameworkCore
{
    public class PhonebookCore2DbContext : AbpZeroDbContext<Tenant, Role, User, PhonebookCore2DbContext>
    {
        /* Define an IDbSet for each entity of the application */
        
        public PhonebookCore2DbContext(DbContextOptions<PhonebookCore2DbContext> options)
            : base(options)
        {

        }
    }
}
