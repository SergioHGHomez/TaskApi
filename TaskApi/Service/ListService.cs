using ServiceLayer.Models;

namespace TaskApi.Service
{
    public class ListService : IListService
    {
        private Task_DBContext _dbContext;

        public ListService(Task_DBContext dbContext) {
            _dbContext = dbContext;
        }

        public void add(List list)
        {
            _dbContext.Lists.Add(list);
            _dbContext.SaveChanges();
        }

        public void delete(Guid id)
        {
            var listToDelete = _dbContext.Lists.FirstOrDefault(l => l.Id == id);
            if (listToDelete != null)
            {
                _dbContext.Lists.Remove(listToDelete);
            }
        }

        public IEnumerable<List> Get()
        {
            return _dbContext.Lists;
        }

        public void update(Guid id, List list)
        {
            var listToUpdate = _dbContext.Lists.FirstOrDefault(l => l.Id == id);
            if (listToUpdate != null)
            {
                listToUpdate.Name = list.Name;
                listToUpdate.Description = list.Description;
            }

        }
    }

    public interface IListService
    {

        IEnumerable<List> Get();
        void add(List list);
        void update(Guid id,  List list);
        void delete(Guid id);

    }
}
