using FineRestAPI.Models.Restaurant;
using FineRestAPI.Models.Web;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FineRestAPI.Models.DBLogic
{
    public class RestaurantContext : DbContext 
    {
        public RestaurantContext() : base("name=FineDb")
        {
           this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<RestaurantModel> RestaurantModels { get; set; }
        public DbSet<RestaurantOwner> RestaurantOwners { get; set; }
        public DbSet<WebUser> WebUsers { get; set; }


    }
}