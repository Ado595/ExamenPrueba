using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenPrueba.Helpers
{
    public static class HeperImage
    {
        public static byte[] ConvertFileToByte(IFormFile file)
        {
            if(file != null)
            {
                MemoryStream mstr = new MemoryStream();
                file.CopyTo(mstr);
                return mstr.ToArray();
            }
            else
            {
                return null;
            }
        }
        public static string GetUrl(byte[] imageData)
        {
            if(imageData != null)
            {
                string imageBase64Data = Convert.ToBase64String(imageData);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                return imageDataURL;
            }
            else
            {
                return null;
            }
        }
    }
}
