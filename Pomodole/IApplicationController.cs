﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodole
{
    public interface IApplicationController : IApplicationMessageEvent
    {
        object GetView(ViewFor view);
        object GetViewModel(ViewModelFor viewModel);
    }
}
