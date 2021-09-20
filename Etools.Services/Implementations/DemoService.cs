using Etools.Entities.EntityModels;
using Etools.Entities.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etools.Services.Implementations
{
    public interface IDemoService
    {
        public void Get();
        public void Post(int Id, string Name, int Age);
    }



    public class DemoService : IDemoService
    {

        public DemoService()
        {

        }
        public void Get()
        {
            var result = new GenericRepository<Demo>().GetResult(s => s.Id == 1, s=> s).ToList();
        }
        public void Post(int Id, string Name, int Age)
        {
            Demo model = new Demo();
            model.Id = Id;
            model.Name = Name;
            model.Age = Age;
            model.IsActive = true;
            new GenericRepository<Demo>().Add(model,1);
        }
    }
}

