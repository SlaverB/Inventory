using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;

namespace UI.NoEnoughMoneyPopup
{
    class NoEnoughMoneyPopupMediator : BaseWindowMediator<NoEnoughMoneyPopupView, WindowData>
    {
        public override void Mediate(BaseWindowView value, GameManagersContexts gameManagersContexts)
        {
            base.Mediate(value, gameManagersContexts);
        }

        public override void UnMediate()
        {
            base.UnMediate();
        }

        protected override void ShowStart()
        {
            base.ShowStart();
        }

    }
}
