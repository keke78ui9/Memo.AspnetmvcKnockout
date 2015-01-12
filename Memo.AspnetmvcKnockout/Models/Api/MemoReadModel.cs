using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memo.AspnetmvcKnockout.Models.Api
{
    public class MemoReadModel
    {
        public string Id { get; set; }
        public string MemoText { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}