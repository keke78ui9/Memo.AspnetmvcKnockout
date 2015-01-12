using System;

namespace Memo.AspnetmvcKnockout.Models.Api
{
    public class MemoWriteModel
    {
        public string Id { get; set; }
        public string MemoText { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}