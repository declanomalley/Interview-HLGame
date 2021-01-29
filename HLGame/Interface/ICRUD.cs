using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLGame.Interface
{
    public interface ICRUD : IGet, IUpdate, Insert, IDelete
    {

    }

    public interface IGet
    {
        public void Get();
    }

    public interface IUpdate
    {
        public bool Update();
    }

    public interface Insert
    {
        public bool Insert();
    }

    public interface IDelete
    {
        public bool Delete();
    }
}
