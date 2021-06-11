using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;

namespace UI.NoEnoughMoneyPopup
{
    class NoEnoughMoneyPopupView : BaseWindowView
    {
        protected override void CreateMediator()
        {
            _mediator = new NoEnoughMoneyPopupMediator();
        }
    }
}
