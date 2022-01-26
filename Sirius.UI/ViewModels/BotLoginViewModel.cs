using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Sirius.CoreCSharp;
using Sirius.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sirius.UI.ViewModels
{
    internal class BotLoginViewModel : ObservableObject
    {
        private readonly BotAccount botAccount = SiriusApplication.BotAccount;

        private readonly BotEvents botEvents = SiriusApplication.BotEvents;

        private readonly Action toShellViewAction;

        public BotLoginViewModel(Action toShellViewAction)
        {
            this.toShellViewAction = toShellViewAction;
            LoginCommand = new RelayCommand(Login);
        }

        public string BotId
        {
            get => botAccount.BotId == 0 ? "" : botAccount.BotId.ToString();
            set
            {
                if (0 == value.Length)
                {
                    SetProperty(botAccount.BotId, (ulong)0, botAccount, (target, val) => target.BotId = val, null);
                }
                else if (ulong.TryParse(value, out ulong botIdNumber))
                {
                    SetProperty(botAccount.BotId, botIdNumber, botAccount, (target, val) => target.BotId = val, null);
                }
                else
                {
                    SetProperty(botAccount.BotId, botAccount.BotId, botAccount, (target, val) => target.BotId = val, null);
                }
            }
        }
        public string BotToken
        {
            get => botAccount.BotToken;
            set => SetProperty(botAccount.BotToken, value, botAccount, (target, val) => target.BotToken = val, null);
        }

        public bool EnableGuildEvent
        {
            get => botEvents.EnableGuildEvent;
            set {
                SetProperty(botEvents.EnableGuildEvent, value, botEvents, (target, val) => target.EnableGuildEvent = val);
                SiriusApplication.UpdateLocalData();
            }
        }

        public bool EnableGuildMemberEvent
        {
            get => botEvents.EnableGuildMemberEvent;
            set {
                SetProperty(botEvents.EnableGuildMemberEvent, value, botEvents, (target, val) => target.EnableGuildMemberEvent = val);
                SiriusApplication.UpdateLocalData();
            }
        }

        public bool EnableChennelEvent
        {
            get => botEvents.EnableChennelEvent;
            set {
                SetProperty(botEvents.EnableChennelEvent, value, botEvents, (target, val) => target.EnableChennelEvent = val);
                SiriusApplication.UpdateLocalData();
            }
        }

        public bool EnableMessageEvent
        {
            get => botEvents.EnableMessageEvent;
            set {
                SetProperty(botEvents.EnableMessageEvent, value, botEvents, (target, val) => target.EnableMessageEvent = val);
                SiriusApplication.UpdateLocalData();
            }
        }

        public bool EnableMessageReactionEvent
        {
            get => botEvents.EnableMessageReactionEvent;
            set {
                SetProperty(botEvents.EnableMessageReactionEvent, value, botEvents, (target, val) => target.EnableMessageReactionEvent = val);
                SiriusApplication.UpdateLocalData();
            }
        }

        public bool EnableATMessageEvent
        {
            get => botEvents.EnableATMessageEvent;
            set {
                SetProperty(botEvents.EnableATMessageEvent, value, botEvents, (target, val) => target.EnableATMessageEvent = val);
                SiriusApplication.UpdateLocalData();
            }
        }

        public bool EnableDirectMessageEvent
        {
            get => botEvents.EnableDirectMessageEvent;
            set
            {
                SetProperty(botEvents.EnableDirectMessageEvent, value, botEvents, (target, val) => target.EnableDirectMessageEvent = val);
                SiriusApplication.UpdateLocalData();
            }
        }

        public bool EnableAudioEvent
        {
            get => botEvents.EnableAudioEvent;
            set
            {
                SetProperty(botEvents.EnableAudioEvent, value, botEvents, (target, val) => target.EnableAudioEvent = val);
                SiriusApplication.UpdateLocalData();
            }
        }

        public ICommand LoginCommand { get; }
        public void Login()
        {
            SiriusApplication.Bot.ReadyEventHandler = OnReadyEvent;
            SiriusApplication.Bot.Login(SiriusApplication.BotEvents, botAccount.BotId, botAccount.BotToken);
        }

        private bool OnReadyEvent(DTO.WSPaylod paylod)
        {
            if (DTO.OPCode.Dispatch == paylod.OPCode)
            {
                SiriusApplication.UpdateLocalData();
                toShellViewAction();
                return true;
            }
            return false;
        }
    }
}
