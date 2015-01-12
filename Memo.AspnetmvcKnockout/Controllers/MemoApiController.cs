using Memo.AspnetmvcKnockout.Data;
using Memo.AspnetmvcKnockout.Models.Api;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Memo.AspnetmvcKnockout.Controllers
{
    public class MemoApiController : ApiController
    {
        private MongoRepository<MemoEntity> _memoSvc = new MongoRepository<MemoEntity>();
        public MemoApiController()
        {
        }
        public IEnumerable<MemoReadModel> Get()
        {
            return _memoSvc.ToList().Select(o =>
            {
                return new MemoReadModel
                {
                    MemoText = o.MemoText,
                    CreatedDate = o.CreatedDate,
                    UpdatedDate = o.UpdatedDate,
                    Id = o.Id
                };
            });
        }
        public HttpResponseMessage Get(string id)
        {
            var result = _memoSvc.FirstOrDefault(x => x.Id == id);
            return Request.CreateResponse<MemoReadModel>(HttpStatusCode.OK, new MemoReadModel 
            {
                 Id = result.Id,
                 MemoText = result.MemoText,
                 CreatedDate = result.CreatedDate,
                 UpdatedDate = result.UpdatedDate
            });

        }
        [HttpPost]
        public HttpResponseMessage Create(MemoWriteModel value)
        {
            _memoSvc.Add(new MemoEntity 
            {
                 MemoText = value.MemoText,
                 CreatedDate = DateTime.Now,
                 UpdatedDate = DateTime.Now
            });

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPost]
        public HttpResponseMessage Update(MemoWriteModel value)
        {
            _memoSvc.Update(new MemoEntity
            {
                Id = value.Id,
                MemoText = value.MemoText, 
                UpdatedDate = DateTime.Now
            });

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            _memoSvc.Delete(_memoSvc.FirstOrDefault(x => x.Id == id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}