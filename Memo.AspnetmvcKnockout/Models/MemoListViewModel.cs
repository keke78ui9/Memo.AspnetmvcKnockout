using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memo.AspnetmvcKnockout.Models
{
    public class MemoListViewModel
    {
        public IEnumerable<Memo.AspnetmvcKnockout.Models.Api.MemoReadModel> MemoList { get; set; }
    }
}