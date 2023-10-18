using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aspect.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReviewTitle",
                table: "ProductReviews",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewTitle",
                table: "ProductReviews");
        }
    }
}
