using Memo.AspnetmvcKnockout.Data;
using Memo.AspnetmvcKnockout.Models;
using Memo.AspnetmvcKnockout.Models.Api;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Memo.AspnetmvcKnockout.Controllers
{
    public class HomeController : Controller
    {
        private MongoRepository<MemoEntity> _memoSvc = new MongoRepository<MemoEntity>();
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            IEnumerable<MemoReadModel> data = _memoSvc.ToList().Select(o => 
            {
                return new MemoReadModel
                {
                     Id = o.Id,
                     MemoText = o.MemoText,
                     CreatedDate = o.CreatedDate,
                     UpdatedDate = o.UpdatedDate
                };
            });
            MemoListViewModel vm = new MemoListViewModel();
            vm.MemoList = data;
            return View(vm);
        }
    }
}
