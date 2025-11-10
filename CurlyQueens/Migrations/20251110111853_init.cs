using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CurlyQueens.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "منتجات لتغذية وترطيب الشعر الكيرلي وتحديد شكل الكيرلز", "Leave-in & Creams" },
                    { 2, "جل ومواد تثبيت تحافظ على شكل الكيرلز بعد التصفيف", "Gels & Stylers" },
                    { 3, "ماسكات عناية وترطيب عميق لعلاج الشعر الكيرلي", "Masks & Treatments" },
                    { 4, "أجهزة تصفيف وتنشيف الشعر مثل الديفيوزر والنانو البخاري", "Devices" },
                    { 5, "فرش وأمشاط مخصصة لفك التشابك وتحديد الكيرلز", "Brushes & Combs" },
                    { 6, "توك وبونيهات وأكسسوارات تحافظ على الشعر الكيرلي", "Accessories & Satin" },
                    { 7, "هير بيس وورد للعرايس والتسريحات الخاصة", "Hair Pieces & Bridal" },
                    { 8, "شامبوهات وبلسم مخصصة للشعر الكيرلي", "Shampoo & Conditioner" },
                    { 9, "سكرابات لفروة الرأس ومنتجات تنظيف عميق", "Scrubs & Scalp Care" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "كريم كيرلي غني بالزبدة لترطيب وتنعيم الشعر", "/images/cantu-leavein.jpg", "Cantu Shea Butter Leave-In", 250m },
                    { 2, 1, "كريم تعزيز الكيرلز من شيا مويسشر", "/images/sheamoisture-smoothie.jpg", "SheaMoisture Curl Enhancing Smoothie", 320m },
                    { 3, 2, "جل تثبيت ناعم بزيت الزيتون يحافظ على شكل الكيرلز", "/images/eco-gel.jpg", "Eco Styler Olive Oil Gel", 180m },
                    { 4, 2, "جل تحديد الكيرلز بخلاصة جوز الهند", "/images/jackie-gel.jpg", "Aunt Jackie's Curl Boss Gel", 210m },
                    { 5, 3, "ماسك علاجي بزيت باباسو لترطيب الشعر الجاف", "/images/mielle-mask.jpg", "Mielle Organics Babassu Oil Mask", 350m },
                    { 6, 3, "ماسك ترطيب عميق يصلح الشعر المتضرر", "/images/olaplex-mask.jpg", "Olaplex No.8 Moisture Mask", 480m },
                    { 7, 4, "دفيوزر لتنشيف الشعر الكيرلي بدون هيشان", "/images/diffuser.jpg", "Diffuser Professional Dryer", 600m },
                    { 8, 4, "جهاز بخار نانو لزيادة امتصاص الماسك وترطيب الشعر", "/images/nano-steamer.jpg", "Nano Steamer", 950m },
                    { 9, 5, "فرشة دنمان الكلاسيكية لتحديد الكيرلز", "/images/denman-brush.jpg", "Denman Brush D3", 230m },
                    { 10, 5, "مشط واسع الأسنان لفك التشابك بدون تقطيع", "/images/comb.jpg", "Wide Tooth Comb", 90m },
                    { 11, 6, "بونيه ستان يحافظ على شكل الكيرلز أثناء النوم", "/images/satin-bonnet.jpg", "Satin Bonnet", 120m },
                    { 12, 6, "توك ستان ناعمة للشعر الكيرلي", "/images/satin-scrunchies.jpg", "Satin Scrunchies Set", 80m },
                    { 13, 7, "هير بيس كيرلي للعرايس والتصوير", "/images/curly-bridal.jpg", "Curly Bridal Hair Piece", 400m },
                    { 14, 7, "إكسسوار شعر ورد أبيض أنيق", "/images/flower-accessory.jpg", "White Flower Hair Accessory", 150m },
                    { 15, 8, "شامبو مرطب بجوز الهند للشعر الكيرلي", "/images/maui-shampoo.jpg", "Maui Moisture Curl Shampoo", 250m },
                    { 16, 8, "بلسم مغذي بجوز الهند للشعر الكيرلي", "/images/maui-conditioner.jpg", "Maui Moisture Conditioner", 250m },
                    { 17, 9, "سكراب لفروة الرأس ينظفها بعمق ويحسن الدورة الدموية", "/images/scalp-scrub.jpg", "Scalp Scrub with Sea Salt", 200m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
