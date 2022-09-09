using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using T_Shirt_Store.WebUI.Models.Entities;
using T_Shirt_Store.WebUI.Models.Entities.Membership;

namespace T_Shirt_Store.WebUI.Models.DataContexts
{
    //public class T_Shirt_StoreDbContext : DbContext
    public class T_Shirt_StoreDbContext : IdentityDbContext<T_ShirtUser,
        T_ShirtRole,
        int,
        T_ShirtUserClaim,
        T_ShirtUserRole,
        T_ShirtUserLogin,
        T_ShirtRoleClaim,
        T_ShirtUserToken>
     
    {
        

        public T_Shirt_StoreDbContext(DbContextOptions<T_Shirt_StoreDbContext> options)
            : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductSize> Sizes { get; set; }
        public DbSet<ProductColor> Colors { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<BlogPostTag> BlogPostTagCloud { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<ProductPricing> ProductPricing { get; set; }
        public DbSet<ProductSizeColorItem> ProductSizeColorCollection { get; set; }
        public DbSet<BlogPostComment> BlogPostComments { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BlogPostTag>(e =>
            {
                e.HasKey(k => new { k.BlogPostId, k.PostTagId });
            });


            modelBuilder.Entity<ProductSpecification>(e =>
            {
                e.HasKey(k => new { k.ProductId, k.SpecificationId });
            });


            modelBuilder.Entity<ProductPricing>(e =>
            {
                e.HasKey(k => new { k.ProductId, k.ColorId, k.SizeId });
            });





            modelBuilder.Entity<T_ShirtUser>(e =>
            {
                e.ToTable("Users", "Membership");
            });

            modelBuilder.Entity<T_ShirtRole>(e =>
            {
                e.ToTable("Roles", "Membership");
            });

            modelBuilder.Entity<T_ShirtUserClaim>(e =>
            {
                e.ToTable("UserClaims", "Membership");
            });

            modelBuilder.Entity<T_ShirtUserToken>(e =>
            {
                e.HasKey(k => new { k.UserId, k.LoginProvider, k.Name });
                e.ToTable("UserTokens", "Membership");
            });

            modelBuilder.Entity<T_ShirtUserLogin>(e =>
            {
                e.HasKey(k => new { k.UserId, k.LoginProvider, k.ProviderKey });
                e.ToTable("UserLogins", "Membership");
            });

            modelBuilder.Entity<T_ShirtRoleClaim>(e =>
            {
                e.ToTable("RoleClaims", "Membership");
            });

            modelBuilder.Entity<T_ShirtUserRole>(e =>
            {
                e.HasKey(k => new { k.UserId, k.RoleId });
                e.ToTable("UserRoles", "Membership");
            });
        }
        }
}

