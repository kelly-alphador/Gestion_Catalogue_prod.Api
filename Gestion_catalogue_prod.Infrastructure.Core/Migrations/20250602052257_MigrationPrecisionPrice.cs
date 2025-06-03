using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_catalogue_prod.Infrastructure.Core.Migrations
{
    /// <inheritdoc />
    public partial class MigrationPrecisionPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "prix",
                table: "Produit",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 25);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "prix",
                table: "Produit",
                type: "decimal(18,2)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);
        }
    }
}
