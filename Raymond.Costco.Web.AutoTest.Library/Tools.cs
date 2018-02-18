﻿using System;
using System.Linq;

namespace Raymond.Costco.Web.AutoTest.Library
{
    public class Tools
    {
        public static string RandomString(int length)
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
