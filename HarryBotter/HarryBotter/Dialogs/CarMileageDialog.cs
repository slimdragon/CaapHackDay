﻿using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;

namespace HarryBotter.Dialogs
{
    [Serializable]
    public class CarMileageDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            throw new NotImplementedException();
        }
    }
}