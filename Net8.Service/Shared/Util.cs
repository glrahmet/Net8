using Microsoft.EntityFrameworkCore;
using Net8.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Net8.Service.Shared
{
    public static class Util
    {
        public static void AddBaseModel<T>(T val, string olusturanKullaniciId, string ipAdresi = "")
        {
            if (val == null)
            {
                return;
            }
            BaseEntity obj = val as BaseEntity;
            //obj.OlusturanKullaniciId = !string.IsNullOrEmpty(olusturanKullaniciId) ? olusturanKullaniciId : null;
            //obj.OlusturmaTarihi = DateTime.Now;
            //obj.IpAdresi = !string.IsNullOrEmpty(ipAdresi) ? ipAdresi : null;
        }
        public static void UpdateBaseModel<T>(T val, string guncelleyenKullaniciId = null, string ipAdresi = "")
        {
            BaseEntity obj = val as BaseEntity;
            //obj.GuncellemeTarihi = DateTime.Now;
            //obj.GuncelleyenKullaniciId = !string.IsNullOrEmpty(guncelleyenKullaniciId) ? guncelleyenKullaniciId : obj.GuncelleyenKullaniciId;
            //obj.IpAdresi = ipAdresi;
        }
        public static Expression<Func<T, bool>> AndAlsoCustomLambdas<T>(
                                   this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {

            ParameterExpression param = expr1.Parameters[0];
            if (ReferenceEquals(param, expr2.Parameters[0]))
            {

                return Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(expr1.Body, expr2.Body), param);
            }

            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    expr1.Body,
                    Expression.Invoke(expr2, param)), param);
        }
        public static Expression<Func<T, bool>> OrElseCustomLambdas<T>(
                                    this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {

            ParameterExpression param = expr1.Parameters[0];
            if (ReferenceEquals(param, expr2.Parameters[0]))
            {

                return Expression.Lambda<Func<T, bool>>(
                    Expression.OrElse(expr1.Body, expr2.Body), param);
            }

            return Expression.Lambda<Func<T, bool>>(
                Expression.OrElse(
                    expr1.Body,
                    Expression.Invoke(expr2, param)), param);
        }
        public static string StringToSHA512(string input)
        {
            SHA512 sha512 = SHA512.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha512.ComputeHash(bytes);
            return HashedSHA512ByteArrayToString(hash);
        }

        private static string HashedSHA512ByteArrayToString(byte[] hashedBytes)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                result.Append(hashedBytes[i].ToString("X2"));
            }
            return result.ToString();
        }
        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
      
        public static bool IsNumericRegEx(string str)
        {
            return str.All(char.IsDigit);
        } 
 

        public static IQueryable<TSource> FromSqlRaw<TSource>(this DbContext db, string sql, params object[] parameters) where TSource : class
        {
            var item = db.Set<TSource>().FromSqlRaw(sql, parameters);
            return item;
        }


        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
          
        //public static Image Base64ToImage(string base64String)
        //{
        //    // Convert base 64 string to byte[]
        //    byte[] imageBytes = Convert.FromBase64String(base64String);
        //    // Convert byte[] to Image
        //    using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
        //    {
        //        Image image = Image.FromStream(ms, true);
        //        return image;
        //    }
        //}


        public static bool ContainsAny(string stringToTest, List<string> substrings)
        {
            if (string.IsNullOrEmpty(stringToTest) || substrings == null)
                return false;

            foreach (var substring in substrings)
            {
                if (stringToTest.Contains(substring, StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        public static string[] SplitMultipleCharacter(char[] _delimiters, string data)
        {
            Char[] delimiters = _delimiters;
            return data.Split(delimiters);
        }


        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (string.IsNullOrEmpty(email))
                return false;

            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }

    }
}
