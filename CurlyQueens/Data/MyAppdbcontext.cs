using CurlyQueens.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CurlyQueens.Data
{
    public class MyAppdbcontext: IdentityDbContext<ApplicationUser>
    {
     
        public MyAppdbcontext(DbContextOptions<MyAppdbcontext> options)
          : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🌀 Category Seeding
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Leave-in & Creams", Description = "منتجات لتغذية وترطيب الشعر الكيرلي وتحديد شكل الكيرلز" },
                new Category { Id = 2, Name = "Gels & Stylers", Description = "جل ومواد تثبيت تحافظ على شكل الكيرلز بعد التصفيف" },
                new Category { Id = 3, Name = "Masks & Treatments", Description = "ماسكات عناية وترطيب عميق لعلاج الشعر الكيرلي" },
                new Category { Id = 4, Name = "Devices", Description = "أجهزة تصفيف وتنشيف الشعر مثل الديفيوزر والنانو البخاري" },
                new Category { Id = 5, Name = "Brushes & Combs", Description = "فرش وأمشاط مخصصة لفك التشابك وتحديد الكيرلز" },
                new Category { Id = 6, Name = "Accessories & Satin", Description = "توك وبونيهات وأكسسوارات تحافظ على الشعر الكيرلي" },
                new Category { Id = 7, Name = "Hair Pieces & Bridal", Description = "هير بيس وورد للعرايس والتسريحات الخاصة" },
                new Category { Id = 8, Name = "Shampoo & Conditioner", Description = "شامبوهات وبلسم مخصصة للشعر الكيرلي" },
                new Category { Id = 9, Name = "Scrubs & Scalp Care", Description = "سكرابات لفروة الرأس ومنتجات تنظيف عميق" }
            );

            // 🧴 Product Seeding
            modelBuilder.Entity<Product>().HasData(
                // Leave-in
                new Product { Id = 1, Name = "Cantu Shea Butter Leave-In", Description = "كريم كيرلي غني بالزبدة لترطيب وتنعيم الشعر", Price = 250, ImageUrl = "/Images/cantu-leavein.jpg", CategoryId = 1 },
                new Product { Id = 2, Name = "SheaMoisture Curl Enhancing Smoothie", Description = "كريم تعزيز الكيرلز من شيا مويسشر", Price = 320, ImageUrl = "/Images/sheamoisture-smoothie.jpg", CategoryId = 1 },

                // Gel
                new Product { Id = 3, Name = "Eco Styler Olive Oil Gel", Description = "جل تثبيت ناعم بزيت الزيتون يحافظ على شكل الكيرلز", Price = 180, ImageUrl = "/Images/eco-gel.jpg", CategoryId = 2 },
                new Product { Id = 4, Name = "Aunt Jackie's Curl Boss Gel", Description = "جل تحديد الكيرلز بخلاصة جوز الهند", Price = 210, ImageUrl = "/Images/jackie-gel.jpg", CategoryId = 2 },

                // Masks
                new Product { Id = 5, Name = "Mielle Organics Babassu Oil Mask", Description = "ماسك علاجي بزيت باباسو لترطيب الشعر الجاف", Price = 350, ImageUrl = "/Images/mielle-mask.jpg", CategoryId = 3 },
                new Product { Id = 6, Name = "Olaplex No.8 Moisture Mask", Description = "ماسك ترطيب عميق يصلح الشعر المتضرر", Price = 480, ImageUrl = "/Images/olaplex-mask.jpg", CategoryId = 3 },

                // Devices
                new Product { Id = 7, Name = "Diffuser Professional Dryer", Description = "دفيوزر لتنشيف الشعر الكيرلي بدون هيشان", Price = 600, ImageUrl = "/Images/diffuser.jpg", CategoryId = 4 },
                new Product { Id = 8, Name = "Nano Steamer", Description = "جهاز بخار نانو لزيادة امتصاص الماسك وترطيب الشعر", Price = 950, ImageUrl = "/Images/nano-steamer.jpg", CategoryId = 4 },

                // Brushes
                new Product { Id = 9, Name = "Denman Brush D3", Description = "فرشة دنمان الكلاسيكية لتحديد الكيرلز", Price = 230, ImageUrl = "/Images/denman-brush.jpg", CategoryId = 5 },
                new Product { Id = 10, Name = "Wide Tooth Comb", Description = "مشط واسع الأسنان لفك التشابك بدون تقطيع", Price = 90, ImageUrl = "/Images/comb.jpg", CategoryId = 5 },

                // Accessories
                new Product { Id = 11, Name = "Satin Bonnet", Description = "بونيه ستان يحافظ على شكل الكيرلز أثناء النوم", Price = 120, ImageUrl = "/Images/satin-bonnet.jpg", CategoryId = 6 },
                new Product { Id = 12, Name = "Satin Scrunchies Set", Description = "توك ستان ناعمة للشعر الكيرلي", Price = 80, ImageUrl = "/Images/satin-scrunchies.jpg", CategoryId = 6 },

                // Bridal & Pieces
                new Product { Id = 13, Name = "Curly Bridal Hair Piece", Description = "هير بيس كيرلي للعرايس والتصوير", Price = 400, ImageUrl = "/Images/curly-bridal.jpg", CategoryId = 7 },
                new Product { Id = 14, Name = "White Flower Hair Accessory", Description = "إكسسوار شعر ورد أبيض أنيق", Price = 150, ImageUrl = "/Images/flower-accessory.jpg", CategoryId = 7 },

                // Shampoo & Conditioner
                new Product { Id = 15, Name = "Maui Moisture Curl Shampoo", Description = "شامبو مرطب بجوز الهند للشعر الكيرلي", Price = 250, ImageUrl = "/Images/maui-shampoo.jpg", CategoryId = 8 },
                new Product { Id = 16, Name = "Maui Moisture Conditioner", Description = "بلسم مغذي بجوز الهند للشعر الكيرلي", Price = 250, ImageUrl = "/Images/maui-conditioner.jpg", CategoryId = 8 },

                // Scrubs
                new Product { Id = 17, Name = "Scalp Scrub with Sea Salt", Description = "سكراب لفروة الرأس ينظفها بعمق ويحسن الدورة الدموية", Price = 200, ImageUrl = "/Images/scalp-scrub.jpg", CategoryId = 9 }
            );
        }
    }
}

