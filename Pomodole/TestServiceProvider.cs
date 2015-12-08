﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodole
{
    public class TestServiceProvider : ServiceProvider
    {
        private IMainWindowViewModel mainWindowViewModel;
        public void SetMainWindowViewModel(IMainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }

        public override IMainWindowViewModel GetMainWindowViewModel()
        {
            return mainWindowViewModel;
        }
    }
}