using XanutHeraxosneri.Models;

namespace XanutHeraxosneri.Data.function
{
    public class DbStatic
    {
   /*   public static void complete(ApplicationDbContext Db)
        {
            if (!Db.CategoryDb.Any())
            {
                Db.CategoryDb.AddRange(silenceCategory(Db).Select(c => c.Value));
            }
            if (!Db.ApranqnerDb.Any())
            {
                silenceAprancner(Db);
            }
            Db.SaveChanges();
        }
      public static void silenceAprancner(ApplicationDbContext Db)
        {
            Db.ApranqnerDb.AddRange(
                new Apranq
                {
                    Name = "J6+",
                    Available = 3,
                    IsFavorit = true,
                    Desc = "Nor bervac",
                    Longdesc = "CHinakan lav voraki",
                    Price = 100000,
                    img = "https://full.am/uploads/posting_image/user_27526/product_60778/42c0316ca4a38f320227d1566f733cac.jpg",
                    Apranctime = DateTime.Now,
                    categoryA = SilenceCategor["Samsung"]
                },
                new Apranq
                {
                    Name = "S8",
                    Available = 2,
                    IsFavorit = false,
                    Desc = "Nor bervac",
                    Longdesc = "CHinakan lav voraki",
                    Price = 250000,
                    img = "https://m.media-amazon.com/images/I/71KApmxcubL._AC_SL1500_.jpg",
                    Apranctime = DateTime.Now,

                    categoryA = SilenceCategor["Samsung"]
                },
                new Apranq
                {
                    Name = "Note 10",
                    Available = 20,
                    IsFavorit = true,
                    Desc = "Noravoj",
                    Longdesc = "Hianali Ekran ",
                    Price = 300000,
                    img = "https://images.samsung.com/ru/smartphones/galaxy-note10/buy/auraglow/img-note10p-auraglow-01.png",
                    Apranctime = DateTime.Now,
                    categoryA = SilenceCategor["Samsung"]
                },
         new Apranq
         {
             Name = "7 Plus",
             Available = 12,
             IsFavorit = false,
             Desc = "lavaguyneric",
             Longdesc = "Hianali Ekran ",
             Price = 300000,
             img = "https://img.promportal.su/foto/good_fotos/3663/36636922/apple-iphone-7-plus-128gb-novie-original-garantiya-dostavka-nalozhenim-platezhem-bez-predoplat_foto_largest.jpg",
             Apranctime = DateTime.Now,
             categoryA = SilenceCategor["Apple"]
         },
         new Apranq
         {
             Name = "13 Pro",
             Available = 7,
             IsFavorit = true,
             Desc = "Verjin model@",
             Longdesc = "Hianali Ekran 256gb",
             Price = 700000,
             img = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-pro-graphite-select?wid=940&hei=1112&fmt=png-alpha&.v=1631652957000",
             Apranctime = DateTime.Now,
             categoryA = SilenceCategor["Apple"]
         },
        new Apranq
        {
            Name = "Redmi",
            Available = 23,
            IsFavorit = false,
            Desc = "Hianali smartfon",
            Longdesc = "Hianali Ekran ",
            Price = 400000,
            img = "https://images.priceoye.pk/samsung-galaxy-a50-pakistan-priceoye-j79s3.jpg",
            Apranctime = DateTime.Now,
            categoryA = SilenceCategor["Xiaomi"]
        }
        );
        }


        public static Dictionary<string, Category> SilenceCategor { get; set; }
        public static Dictionary<string, Category> silenceCategory(ApplicationDbContext Db)
        {
            if (SilenceCategor == null)
            {
                SilenceCategor = new Dictionary<string, Category>();
                var list = new Category[]
                  {
                           new Category{Name="Samsung",DescCategory="Nor Bervac Chinakan"},
                           new Category{Name="Apple",DescCategory="ogtagorcvac AMN ic"},
                           new Category{Name="Xiaomi",DescCategory="nor Chinakan lav vorak"}
                  };
                foreach (var x in list)
                {
                    SilenceCategor.Add(x.Name, x);
                }

            }
            return SilenceCategor;
        }


*/




                public static void complete(ApplicationDbContext Db)
                {
                    if (!Db.CategoryDb.Any())
                    {
                        var list = new Category[]
                              {
                           new Category{Name="Samsung",DescCategory="Nor Bervac Chinakan"},
                           new Category{Name="Apple",DescCategory="ogtagorcvac AMN ic"},
                           new Category{Name="Xiaomi",DescCategory="nor Chinakan lav vorak"}
                               };
                        Db.CategoryDb.AddRange(list);
                        Db.SaveChanges();
                    }

                    if (!Db.ApranqnerDb.Any())
                    {
                        silenceAprancner(Db);
                    }
                    Db.SaveChanges();
                }
                public static void silenceAprancner(ApplicationDbContext Db)
                {

                    List<Category> z = new List<Category>();



                    foreach (var a in Db.CategoryDb)
                    {
                        z.Add(a);
                    }


                    Db.ApranqnerDb.AddRange(

                        new Apranq
                        {
                            Name = "J6+",
                            Available = 3,
                            IsFavorit = true,
                            Desc = "Nor bervac",
                            Longdesc = "CHinakan lav voraki",
                            Price = 100000,
                            img = "https://full.am/uploads/posting_image/user_27526/product_60778/42c0316ca4a38f320227d1566f733cac.jpg",
                            Apranctime = DateTime.Now,
                            categoryA = z.First()
                        },
                        new Apranq
                        {
                            Name = "S8",
                            Available = 2,
                            IsFavorit = false,
                            Desc = "Nor bervac",
                            Longdesc = "CHinakan lav voraki",
                            Price = 250000,
                            img = "https://m.media-amazon.com/images/I/71KApmxcubL._AC_SL1500_.jpg",
                            Apranctime = DateTime.Now,

                            categoryA = z.First()
                        },



                        new Apranq
                        {
                            Name = "Note 10",
                            Available = 20,
                            IsFavorit = true,
                            Desc = "Noravoj",
                            Longdesc = "Hianali Ekran ",
                            Price = 300000,
                            img = "https://images.samsung.com/ru/smartphones/galaxy-note10/buy/auraglow/img-note10p-auraglow-01.png",
                            Apranctime = DateTime.Now,
                            categoryA = z.First()
                        },
                 new Apranq
                 {
                     Name = "7 Plus",
                     Available = 12,
                     IsFavorit = false,
                     Desc = "lavaguyneric",
                     Longdesc = "Hianali Ekran ",
                     Price = 300000,
                     img = "https://img.promportal.su/foto/good_fotos/3663/36636922/apple-iphone-7-plus-128gb-novie-original-garantiya-dostavka-nalozhenim-platezhem-bez-predoplat_foto_largest.jpg",
                     Apranctime = DateTime.Now,
                     categoryA = z.FirstOrDefault(c => c.Name == "Apple")
                 },
                 new Apranq
                 {
                     Name = "13 Pro",
                     Available = 7,
                     IsFavorit = true,
                     Desc = "Verjin model@",
                     Longdesc = "Hianali Ekran 256gb",
                     Price = 700000,
                     img = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-pro-graphite-select?wid=940&hei=1112&fmt=png-alpha&.v=1631652957000",
                     Apranctime = DateTime.Now,

                     categoryA = z.FirstOrDefault(c => c.Name == "Apple")
                 },
                new Apranq
                {
                    Name = "Redmi",
                    Available = 23,
                    IsFavorit = false,
                    Desc = "Hianali smartfon",
                    Longdesc = "Hianali Ekran ",
                    Price = 400000,
                    img = "https://images.priceoye.pk/samsung-galaxy-a50-pakistan-priceoye-j79s3.jpg",
                    Apranctime = DateTime.Now,
                    categoryA = z.FirstOrDefault(c => c.Name == "Xiaomi")
                }
                );
                }

    }
}
