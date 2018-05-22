using DistributedPartlyCloudDatabase.DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DistributedPartlyCloudDatabase.ORM;
using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;

namespace DistributedPartlyCloudDatabase.DAL.Repositories
{
    public class LikeRepository : RepositoryBase<DalLike>, ILikeRepository
    {
        private readonly DbContext context;

        public LikeRepository(DbContext dbContext)
            : base(dbContext)
        {
            context = (context ?? (AzureEntityModel)dbContext);
        }

        public new IEnumerable<DalLike> GetAll()
        {
            return context.Set<Like>().Select(like => new DalLike()
            {
                Id = like.Id,
                ImageId = like.ImageId,
                UserId = like.UserId
            });
        }

        public DalLike GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Create(DalLike e)
        {
            var like = new Like()
            {
                ImageId = e.ImageId,
                UserId = e.UserId
            };

            context.Set<Like>().Add(like);
        }
    }
}
