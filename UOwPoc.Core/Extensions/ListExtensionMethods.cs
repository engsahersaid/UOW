﻿//using System.Collections;
//using UOwPoc.Core.Models;

//namespace UOwPoc.Core.Extensions
//{
//    public static class ListExtensionMethods
//    {
//        public static PagingDescriptor Page(this IList list, int pageSize)
//        {
//            var actualPageSize = pageSize;

//            if (actualPageSize <= 0)
//            {
//                actualPageSize = list.Count;
//            }

//            var maxNumberOfPages =
//                (int)Math.Round(Math.Max(1, Math.Ceiling(((float)list.Count) / ((float)actualPageSize))));

//            return new PagingDescriptor(
//                actualPageSize,
//                maxNumberOfPages,
//                Enumerable
//                    .Range(0, maxNumberOfPages)
//                    .Select(pageZeroIndex => new PageBoundry(
//                                pageZeroIndex * actualPageSize,
//                                Math.Min((pageZeroIndex * actualPageSize) + (actualPageSize - 1), list.Count - 1)
//                            )).ToArray()
//            );
//        }
//    }
//}