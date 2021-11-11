using Microsoft.EntityFrameworkCore.Migrations;

namespace Bageriet.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33361b89-2c10-4145-bf1c-42adec2560e4", "b7d7966d-b4fa-4d9c-b165-d4b1b261e3dc", "Admin", "ADMIN" },
                    { "df69299d-2360-4b2b-8734-53df5e101d15", "85914c8e-4218-4188-abf3-3fc151d46765", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "Address", "City", "Email", "Phone", "Title", "Visible", "Zip" },
                values: new object[] { 1, "Supergatan 100", "Växjö", "bageri_vaxjo@bv.se", "0470-707000", "Kontakt information", true, "350 00" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Description", "Image", "Name", "Visible" },
                values: new object[,]
                {
                    { 1, "Baguette är ett franskt vitt matbröd innehållande vetemjöl, vatten, jäst och salt, som med sin avlånga form och frasiga yta blivit en fransk symbol. Brödet är känsligt för uttorkning och bör därför ätas inom ett dygn efter bakning", "/images/products/baguette.png", "Baguette", true },
                    { 2, "Småfranska eller fralla är ett mindre och ofta runt franskbröd. Liknande bröd i de svenskspråkiga delarna av Finland heter semla, men bakas med inslag av bland annat fullkornsmjöl. I Skåne kallas småfranska i regel för bulle eller franskbrödsbulle för att skilja från vanliga söta bullar", "/images/products/smafranska.png", "Småfranska", true },
                    { 3, "Croissant [kroasaŋ´] är ett bakverk av smördeg format i en halvmåne ofta förknippat med Frankrike. Croissanter är i grunden en fransk version av giffel och har en slående likhet med vissa typer av sådana. Namnet croissant är franskt och kommer från ordet croître, med betydelsen växa.", "/images/products/croissant.png", "Croissant", true },
                    { 4, "Korvbröd är ett avlångt, decimeterlångt mjukt bröd bakat av vetemjöl. I brödet skärs en längsgående skåra som är avsedd att ge plats för en varm korv och måltiden kallas på svenska vanligen korv med bröd och internationellt hot dog. Industriellt tillverkade korvbröd brukar vara färdigskurna.", "/images/products/korvbrod.png", "Korvbröd", true },
                    { 5, "Pannkaka är en maträtt som gräddas i en pannkakslagg eller stekpanna på spisplattan, vissa varianter i en långpanna i ugnen. Standardingredienserna är ägg, vetemjöl och mjölk samt matfett och salt. I Sverige äts pannkaka traditionellt som efterrätt till ärtsoppa på torsdagar", "/images/products/pannkaka.png", "Pannkaka", true },
                    { 6, "Wienerbröd är ett bakverk som i grunden består av wienerdeg, som blir luftig och frasig vid bakning. Det finns i många varianter med olika fyllningar och garnityr.", "/images/products/wienerbrod.png", "Wienerbröd", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "33361b89-2c10-4145-bf1c-42adec2560e4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "df69299d-2360-4b2b-8734-53df5e101d15");

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
