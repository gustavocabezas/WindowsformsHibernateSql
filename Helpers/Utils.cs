using System;

namespace WindowsformsHibernateSql.Helpers
{
    public static class Utils
    {
        public static string ConvertImageToBase64(byte[] imageBytes)
        {
            return Convert.ToBase64String(imageBytes);
        }
    }
}
