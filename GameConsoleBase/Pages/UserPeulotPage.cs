using GameConsoleBase.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleBase.Pages
{
    internal class UserPeulotPage : MenuScreen
    {
        public UserPeulotPage() : base("User Actions Menu")
        {
            AddMenuItem("View User Details", new UserDetails());
            AddMenuItem("Edit User Name", new UpdateName());
            AddMenuItem("Edit User Password", new UpdatePassword());
            AddMenuItem("Show History by Game name", new PlayHis(1));
			AddMenuItem("Show History by Score", new PlayHis(2));
			AddMenuItem("Show Last Game Details", new PlayHis(3));
        }

    }
}