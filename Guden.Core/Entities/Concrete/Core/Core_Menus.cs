using Guden.Core.Entities;

namespace Guden.Entities.Concrete.Core
{
    public class Core_Menus:IEntity
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string Icon { get; set; }
        public string cName { get; set; }
        public int Status { get; set; }

    }
}
