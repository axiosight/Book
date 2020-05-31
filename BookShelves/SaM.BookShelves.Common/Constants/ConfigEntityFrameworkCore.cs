using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Common.Constants
{
    public static class ConfigEntityFrameworkCore
    {
        public static class AppUser
        {
            public static readonly int MaxLengthUserName = 50;
            public static readonly int MaxLengthSurname = 50;
            public static readonly int MaxLengthFloor = 20;
            public static readonly int MaxLengthRoom = 1000;
        }

        public static class Author
        {
            public static readonly int MaxLengthName = 100;
        }

        public static class Book
        {
            public static readonly int MaxLengthName = 250;
            public static readonly int MaxLengthOriginalName = 250;
            public static readonly int MaxLengthDescription = 2000;
            public static readonly int MaxLengthYear = 2021;
        }

        public static class Library
        {
            public static readonly int MaxLengthName = 200;
            public static readonly int MaxLengthFloor = 20;
        }

        public static class Office
        {
            public static readonly int MaxLengthName = 200;
            public static readonly int MaxLengthAdress = 300;
        }

        public static class Preview
        {
            public static readonly int MaxLengthName = 200;
            public static readonly int MaxLengthExtension = 15;
            public static readonly int MaxLengthType = 50;
        }

        public static class Publisher
        {
            public static readonly int MaxLengthName = 250;
        }

        public static class Status
        {
            public static readonly int MaxLengthName = 250;
        }

        public static class Tag
        {
            public static readonly int MaxLengthName = 130;
        }
    }
}
