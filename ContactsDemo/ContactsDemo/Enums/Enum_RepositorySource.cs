using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDemo.Enums
{
    public static class Enum_RepositorySource
    {
        public enum Repository
        {
            SQLite,
            Azure,
            WebAPI,
            AWS,
            MongoDB,
            WCFService,
            PenAndPaper,
            Excel,
            IsPenAndPaperOrExcelWorse
        }

    }
}
