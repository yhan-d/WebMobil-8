﻿namespace Identity101.Models.Role
{
    public class Roles
    {
        public static readonly string Admin = "Admin";
        public static readonly string User = "User";
        public static readonly string Passive = "Passive";

        public static List<string> RoleList = new List<string>()
        {
            Admin,User,Passive
        };
    }
}
