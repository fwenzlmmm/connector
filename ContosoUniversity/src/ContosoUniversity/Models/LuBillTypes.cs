using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class LuBillTypes
    {
        public string BillTypeDescription { get; set; }
        public string BillType { get; set; }
        public int BillTypeKey { get; set; }
        public Guid DescriptionId { get; set; }
        public int BillType1st2DigitsKey { get; set; }
        public string BillType1st2Digits { get; set; }
        public string BillType1st2DigitsDescription { get; set; }
        public int BillType3rdDigitKey { get; set; }
        public string BillType3rdDigit { get; set; }
        public string BillType3rdDigitDescription { get; set; }
        public short LoVersion { get; set; }
        public short HiVersion { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
