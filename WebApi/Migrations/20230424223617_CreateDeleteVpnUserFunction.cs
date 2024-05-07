using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class CreateDeleteVpnUserFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION delete_vpn_user(v_user_id UUID)
                RETURNS VOID AS $$
                BEGIN
                    DELETE FROM public.""VpnUsersPayments""
                    WHERE ""VpnUserId"" = v_user_id;

                    DELETE FROM public.""VpnUsers""
                    WHERE ""Id"" = v_user_id;
                END;
                $$ LANGUAGE plpgsql;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS delete_vpn_user;");
        }

    }
}