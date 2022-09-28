﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz ";
        public static string MaintenanceTime = " Zaman doldu ";
        public static string ProductListed = " Ürünler listelendi";
        public static string CategoryListed = "   Category listelendi";
        public static string ProductCountOfCategoryError = " bu kategori de 10 dan fazla ürün olabilir.  ";
        public static string CategoryLimitExceded = "category sayısı doldu ";
    }
}
