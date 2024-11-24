using DL;
using MDBModels;
    namespace BL
{
    public class McdollibeeMenuServices
    {
        private Sqldbdata menuRepository = new Sqldbdata();

        public bool CreateMenu(menu menu) => menuRepository.CreateMenu(menu);
        public bool UpdateMenu(menu menu) => menuRepository.UpdateMenu(menu);
        public bool DeleteMenu(string code) => menuRepository.DeleteMenu(code);
    }
}
