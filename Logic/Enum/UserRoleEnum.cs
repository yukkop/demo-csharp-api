using System.ComponentModel;

namespace Logic.Enum;

public enum UserRoleEnum
{
    [Description("super")]
    Super,
    [Description("admin")]
    Admin,
    [Description("vpn-user")]
    VpnUser,
    [Description("bot-system")]
    BotSystem,
    [Description("employer")]
    Employer
}