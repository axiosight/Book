using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Initializers
{
    public static class PreviewInitializer
    {
        public static async Task InitializeAsync(BookShelvesContext context)
        {
            if (!context.Previews.Any())
            {
                List<Preview> previews = new List<Preview>();

                #region config
                string template = @"..\SaM.BookShelves.Common\DataImages\Book{0}\{1}_{2}{3}";
                string templateName = "{0}_{1}";

                List<string> numbers = new List<string>()
                {
                    "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
                    "11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
                    "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"
                };
                #endregion

                #region Book1
                for (int i = 0; i < 22; i++)
                {
                    var flag = false;
                    if (numbers[i].Equals("00"))
                        flag = true;

                    var image = ConfigPreviewInitializer.LoaderPreview.Init(string.Format(template, numbers[1], ConfigPreviewInitializer.Previews.ISBN1, numbers[i], ConfigPreviewInitializer.Previews.Extension));
                    previews.Add(new Preview()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book1.Name),
                        Img = image,
                        Name = string.Format(templateName, ConfigPreviewInitializer.Previews.ISBN1, numbers[i]),
                        Extension = ConfigPreviewInitializer.Previews.Extension,
                        Type = ConfigPreviewInitializer.Previews.Type,
                        IsPreview = flag
                    }); ; ;
                }
                #endregion

                #region Book2
                for (int i = 0; i < 14; i++)
                {
                    var flag = false;
                    if (numbers[i].Equals("00"))
                        flag = true;
                    previews.Add(new Preview()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book2.Name),
                        Img = ConfigPreviewInitializer.LoaderPreview.Init(string.Format(template, numbers[2], ConfigPreviewInitializer.Previews.ISBN2, numbers[i], ConfigPreviewInitializer.Previews.Extension)),
                        Name = string.Format(templateName, ConfigPreviewInitializer.Previews.ISBN2, numbers[i]),
                        Extension = ConfigPreviewInitializer.Previews.Extension,
                        Type = ConfigPreviewInitializer.Previews.Type,
                        IsPreview = flag
                    });
                }
                #endregion

                #region Book3
                for (int i = 0; i < 15; i++)
                {
                    var flag = false;
                    if (numbers[i].Equals("00"))
                        flag = true;
                    previews.Add(new Preview()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book3.Name),
                        Img = ConfigPreviewInitializer.LoaderPreview.Init(string.Format(template, numbers[3], ConfigPreviewInitializer.Previews.ISBN3, numbers[i], ConfigPreviewInitializer.Previews.Extension)),
                        Name = string.Format(templateName, ConfigPreviewInitializer.Previews.ISBN3, numbers[i]),
                        Extension = ConfigPreviewInitializer.Previews.Extension,
                        Type = ConfigPreviewInitializer.Previews.Type,
                        IsPreview = flag
                    });
                }
                #endregion

                #region Book4
                for (int i = 0; i < 13; i++)
                {
                    var flag = false;
                    if (numbers[i].Equals("00"))
                        flag = true;
                    previews.Add(new Preview()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book4.Name),
                        Img = ConfigPreviewInitializer.LoaderPreview.Init(string.Format(template, numbers[4], ConfigPreviewInitializer.Previews.ISBN4, numbers[i], ConfigPreviewInitializer.Previews.Extension)),
                        Name = string.Format(templateName, ConfigPreviewInitializer.Previews.ISBN4, numbers[i]),
                        Extension = ConfigPreviewInitializer.Previews.Extension,
                        Type = ConfigPreviewInitializer.Previews.Type,
                        IsPreview = flag
                    });
                }
                #endregion

                #region Book5
                for (int i = 0; i < 16; i++)
                {
                    var flag = false;
                    if (numbers[i].Equals("00"))
                        flag = true;
                    previews.Add(new Preview()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book5.Name),
                        Img = ConfigPreviewInitializer.LoaderPreview.Init(string.Format(template, numbers[5], ConfigPreviewInitializer.Previews.ISBN5, numbers[i], ConfigPreviewInitializer.Previews.Extension)),
                        Name = string.Format(templateName, ConfigPreviewInitializer.Previews.ISBN5, numbers[i]),
                        Extension = ConfigPreviewInitializer.Previews.Extension,
                        Type = ConfigPreviewInitializer.Previews.Type,
                        IsPreview = flag
                    });
                }
                #endregion

                #region Book6
                for (int i = 0; i < 10; i++)
                {
                    var flag = false;
                    if (numbers[i].Equals("00"))
                        flag = true;
                    previews.Add(new Preview()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book6.Name),
                        Img = ConfigPreviewInitializer.LoaderPreview.Init(string.Format(template, numbers[6], ConfigPreviewInitializer.Previews.ISBN6, numbers[i], ConfigPreviewInitializer.Previews.Extension)),
                        Name = string.Format(templateName, ConfigPreviewInitializer.Previews.ISBN6, numbers[i]),
                        Extension = ConfigPreviewInitializer.Previews.Extension,
                        Type = ConfigPreviewInitializer.Previews.Type,
                        IsPreview = flag
                    });
                }
                #endregion

                #region Book7
                for (int i = 0; i < 16; i++)
                {
                    var flag = false;
                    if (numbers[i].Equals("00"))
                        flag = true;
                    previews.Add(new Preview()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book7.Name),
                        Img = ConfigPreviewInitializer.LoaderPreview.Init(string.Format(template, numbers[7], ConfigPreviewInitializer.Previews.ISBN7, numbers[7], ConfigPreviewInitializer.Previews.Extension)),
                        Name = string.Format(templateName, ConfigPreviewInitializer.Previews.ISBN7, numbers[i]),
                        Extension = ConfigPreviewInitializer.Previews.Extension,
                        Type = ConfigPreviewInitializer.Previews.Type,
                        IsPreview = flag
                    });
                }
                #endregion

                #region Book8
                for (int i = 0; i < 1; i++)
                {
                    var flag = false;
                    if (numbers[i].Equals("00"))
                        flag = true;
                    previews.Add(new Preview()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book8.Name),
                        Img = ConfigPreviewInitializer.LoaderPreview.Init(string.Format(template, numbers[8], ConfigPreviewInitializer.Previews.ISBN8, numbers[i], ConfigPreviewInitializer.Previews.Extension)),
                        Name = string.Format(templateName, ConfigPreviewInitializer.Previews.ISBN8, numbers[i]),
                        Extension = ConfigPreviewInitializer.Previews.Extension,
                        Type = ConfigPreviewInitializer.Previews.Type,
                        IsPreview = flag
                    });
                }
                #endregion

                #region Book9
                for (int i = 0; i < 1; i++)
                {
                    var flag = false;
                    if (numbers[i].Equals("00"))
                        flag = true;
                    previews.Add(new Preview()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book9.Name),
                        Img = ConfigPreviewInitializer.LoaderPreview.Init(string.Format(template, numbers[9], ConfigPreviewInitializer.Previews.ISBN9, numbers[i], ConfigPreviewInitializer.Previews.Extension)),
                        Name = string.Format(templateName, ConfigPreviewInitializer.Previews.ISBN9, numbers[i]),
                        Extension = ConfigPreviewInitializer.Previews.Extension,
                        Type = ConfigPreviewInitializer.Previews.Type,
                        IsPreview = flag
                    });
                }
                #endregion

                #region Book10
                for (int i = 0; i < 28; i++)
                {
                    var flag = false;
                    if (numbers[i].Equals("00"))
                        flag = true;
                    previews.Add(new Preview()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book10.Name),
                        Img = ConfigPreviewInitializer.LoaderPreview.Init(string.Format(template, numbers[10], ConfigPreviewInitializer.Previews.ISBN10, numbers[i], ConfigPreviewInitializer.Previews.Extension)),
                        Name = string.Format(templateName, ConfigPreviewInitializer.Previews.ISBN10, numbers[i]),
                        Extension = ConfigPreviewInitializer.Previews.Extension,
                        Type = ConfigPreviewInitializer.Previews.Type,
                        IsPreview = flag
                    });
                }
                #endregion

                #region Book11
                for (int i = 0; i < 2; i++)
                {
                    var flag = false;
                    if (numbers[i].Equals("00"))
                        flag = true;
                    previews.Add(new Preview()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book11.Name),
                        Img = ConfigPreviewInitializer.LoaderPreview.Init(string.Format(template, numbers[11], ConfigPreviewInitializer.Previews.ISBN11, numbers[i], ConfigPreviewInitializer.Previews.Extension)),
                        Name = string.Format(templateName, ConfigPreviewInitializer.Previews.ISBN11, numbers[i]),
                        Extension = ConfigPreviewInitializer.Previews.Extension,
                        Type = ConfigPreviewInitializer.Previews.Type,
                        IsPreview = flag
                    });
                }
                #endregion

                await context.AddRangeAsync(previews);
                await context.SaveChangesAsync();
            }
        }
    }
}
