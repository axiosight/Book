using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Common.Routes
{
    public static class RoutesApi
    {
        public static class Account
        {
            public const string Login = "api/account/login";
            public const string LogOut = "api/account/logout";
            public const string GetAccount = "api/account/getAccount";
        }

        public static class Book
        {
            public const string GetAllBooks = "api/book/getAllBooks";
            public const string GetSearchBooks = "api/boook/search";
            public const string AddBook = "api/book/addBook";
            public const string DeleteBook = "api/book/deleteBook/{id}";
        }

        public static class Admin
        {
            public const string GetAllOffices = "api/admin/getAllOffices";
            public const string GetAllLibrariens = "api/admin/getAllLibrariens";
            public const string AddOffice = "api/admin/addOffice";
            public const string UpdateOffice = "api/admin/updateOffice";
            public const string DeleteOffice = "api/admin/deleteOffice/{officeId}";
            public const string GetSearchOffice = "api/admin/searchOffice";
        }
    }
}