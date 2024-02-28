using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "fs_logica");

            migrationBuilder.EnsureSchema(
                name: "fs_gestion");

            migrationBuilder.CreateTable(
                name: "catalogoProductos",
                schema: "fs_logica",
                columns: table => new
                {
                    id_catalogo_producto = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_producto = table.Column<string>(type: "text", nullable: false),
                    precio_unitario_producto = table.Column<int>(type: "integer", nullable: false),
                    cantidad_producto = table.Column<int>(type: "integer", nullable: false),
                    descripcion_producto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogoProductos", x => x.id_catalogo_producto);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                schema: "fs_gestion",
                columns: table => new
                {
                    id_usuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_usuario = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    apellidos_usuario = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    dni_usuario = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    tlf_usuario = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    email_usuario = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    clave_usuario = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    token_recuperacion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ExpiracionToken = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    rol_usuario = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    cuenta_confirmada = table.Column<bool>(type: "boolean", nullable: false),
                    foto_usuario = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "tiendas",
                schema: "fs_logica",
                columns: table => new
                {
                    id_tienda = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_tienda = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    direccion_tienda = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    codigopostal_tienda = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    id_usuario = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiendas", x => x.id_tienda);
                    table.ForeignKey(
                        name: "FK_tiendas_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalSchema: "fs_gestion",
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedidos",
                schema: "fs_logica",
                columns: table => new
                {
                    id_pedido = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    precio_pedido = table.Column<int>(type: "integer", nullable: false),
                    id_tienda = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos", x => x.id_pedido);
                    table.ForeignKey(
                        name: "FK_pedidos_tiendas_id_tienda",
                        column: x => x.id_tienda,
                        principalSchema: "fs_logica",
                        principalTable: "tiendas",
                        principalColumn: "id_tienda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogoProductoPedido",
                schema: "fs_logica",
                columns: table => new
                {
                    List_Cat_PedIdPedido = table.Column<long>(type: "bigint", nullable: false),
                    List_Ped_CatIdCatalogoProducto = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoProductoPedido", x => new { x.List_Cat_PedIdPedido, x.List_Ped_CatIdCatalogoProducto });
                    table.ForeignKey(
                        name: "FK_CatalogoProductoPedido_catalogoProductos_List_Ped_CatIdCata~",
                        column: x => x.List_Ped_CatIdCatalogoProducto,
                        principalSchema: "fs_logica",
                        principalTable: "catalogoProductos",
                        principalColumn: "id_catalogo_producto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogoProductoPedido_pedidos_List_Cat_PedIdPedido",
                        column: x => x.List_Cat_PedIdPedido,
                        principalSchema: "fs_logica",
                        principalTable: "pedidos",
                        principalColumn: "id_pedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoProductoPedido_List_Ped_CatIdCatalogoProducto",
                schema: "fs_logica",
                table: "CatalogoProductoPedido",
                column: "List_Ped_CatIdCatalogoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_id_tienda",
                schema: "fs_logica",
                table: "pedidos",
                column: "id_tienda");

            migrationBuilder.CreateIndex(
                name: "IX_tiendas_id_usuario",
                schema: "fs_logica",
                table: "tiendas",
                column: "id_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogoProductoPedido",
                schema: "fs_logica");

            migrationBuilder.DropTable(
                name: "catalogoProductos",
                schema: "fs_logica");

            migrationBuilder.DropTable(
                name: "pedidos",
                schema: "fs_logica");

            migrationBuilder.DropTable(
                name: "tiendas",
                schema: "fs_logica");

            migrationBuilder.DropTable(
                name: "usuarios",
                schema: "fs_gestion");
        }
    }
}
