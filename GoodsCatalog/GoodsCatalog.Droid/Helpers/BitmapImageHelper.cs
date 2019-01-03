﻿using System.Net;
using Android.Graphics;

namespace GoodsCatalog.Droid.Helpers
{
    public static class BitmapImageHelper
    {
        public static Bitmap GetBitmapFromUrl(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] bytes = webClient.DownloadData(url);
                if (bytes != null && bytes.Length > 0)
                {
                    return BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
                }
            }
            return null;
        }
    }
}
