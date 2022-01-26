using Sirius.CoreGoForCSharp;
using Sirius.PluginSupport;
using Sirius.Utils;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace Sirius.CoreCSharp
{
    public class Bot
    {
        private delegate void ReadyEventHandlerDelegate(IntPtr eventJson, IntPtr dataJson);

        private readonly ReadyEventHandlerDelegate readyEventHandlerDelegate;

        private readonly EventsHandler eventsHandler;

        private readonly Mutex eventMutex = new(false);

        public delegate List<IPluginFunc> GetPluginFuncsDelegate();

        //返回true时将值设置为null
        public Func<DTO.WSPaylod, bool>? ReadyEventHandler { get; set; }

        public GetPluginFuncsDelegate? PluginFuncsDelegate { get; set; }

        private void OnReadyEvent(IntPtr eventJson, IntPtr dataJson)
        {
            if (ReadyEventHandler is not null)
            {
                MutexAction(() =>
                {
                    if (ReadyEventHandler.Invoke(Util.JsonDecode<DTO.WSPaylod>(Marshal.PtrToStringUTF8(eventJson)!)!))
                    {
                        ReadyEventHandler = null;
                    }
                });
            }
        }

        public Bot()
        {
            eventsHandler = new(this);
            readyEventHandlerDelegate = OnReadyEvent;
        }

        public void MutexAction(Action action)
        {
            eventMutex.WaitOne();
            action();
            eventMutex.ReleaseMutex();
        }

        public void Login(BotEvents events, ulong appId, string accessToken)
        {
            eventsHandler.Init(events);
            CoreGo.Login(Marshal.GetFunctionPointerForDelegate(readyEventHandlerDelegate), appId, accessToken);
        }

        public void StartNetworkPluginServer(ushort bindPort)
        {
            CoreGo.StartNetworkPluginServer(bindPort);
        }

        public void SetGoLogOutputFuncAddress(IntPtr funcAddress)
        {
            CoreGo.SetGoLogOutputFunc(funcAddress);
        }

        public void SetOpenApiLogOutputFunc(IntPtr funcAddress)
        {
            CoreGo.SetOpenApiLogOutputFunc(funcAddress);
        }

        //public Plugin[] LoadPluginsJson()
        //{
        //    try
        //    {
        //        string text = File.ReadAllText(@".\Config.json");
        //        return Util.JsonDecode<Plugin[]>(text)!;
        //    }
        //    catch (Exception)
        //    {
        //        return Array.Empty<Plugin>();
        //    }
        //}

        //private bool FileCompare(string path1, string path2)
        //{
        //    int file1byte;
        //    int file2byte;
        //    FileStream fs1;
        //    FileStream fs2;

        //    if (path1 == path2)
        //    {
        //        return true;
        //    }


        //    fs1 = new FileStream(path1, FileMode.Open);
        //    fs2 = new FileStream(path2, FileMode.Open);

        //    if (fs1.Length != fs2.Length)
        //    {
        //        fs1.Close();
        //        fs2.Close();

        //        return false;
        //    }

        //    do
        //    {
        //        file1byte = fs1.ReadByte();
        //        file2byte = fs2.ReadByte();
        //    }
        //    while ((file1byte == file2byte) && (file1byte != -1));

        //    fs1.Close();
        //    fs2.Close();

        //    return ((file1byte - file2byte) == 0);
        //}

        //    public class Plugin
        //    {
        //        /// <summary>
        //        /// 是否是C#插件
        //        /// </summary>
        //        public bool IsCSharp { get; set; }

        //        public string ModuleName { get; set; } = string.Empty;

        //        public string Path { get; set; } = string.Empty;

        //        public bool IsEnable { get; set; } = false;

        //        [JsonIgnore]
        //        public IPlugin? Instance { get; set; }

        //        [JsonIgnore]
        //        public bool IsLoaded => null != Instance;

        //        public bool Load()
        //        {
        //            if (null == Instance)
        //            {
        //                if (IsCSharp)
        //                {
        //                    Instance = new CSharpPlugin(Path);
        //                }
        //                else
        //                {
        //                    Instance = new CPlugin(Path);
        //                }
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }

        //        public bool Unload()
        //        {
        //            if (null != Instance)
        //            {
        //                Instance.Unload(out WeakReference weakReference);
        //                Instance = null;
        //                for (int i = 0; weakReference.IsAlive && (i < 10); ++i)
        //                {
        //                    GC.Collect();
        //                    GC.WaitForPendingFinalizers();
        //                }
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }

        //        }
        //    //}

        //}

        internal class EventsHandler
        {
            private delegate void EventHandlerDelegate(IntPtr eventJson, IntPtr dataJson);

            private readonly Bot bot;

            private readonly EventHandlerDelegate onGuildEventDelegate;
            private readonly EventHandlerDelegate onGuildMemberEventDelegate;
            private readonly EventHandlerDelegate onChannelEventDelegate;
            private readonly EventHandlerDelegate onMessageEventDelegate;
            private readonly EventHandlerDelegate onMessageReactionEventDelegate;
            private readonly EventHandlerDelegate onATMessageEventDelegate;
            private readonly EventHandlerDelegate onDirectMessageEventDelegate;
            private readonly EventHandlerDelegate onAudioEventDelegate;

            public EventsHandler(Bot bot)
            {
                this.bot = bot;
                onGuildEventDelegate = OnGuildEvent;
                onGuildMemberEventDelegate = OnGuildMemberEvent;
                onChannelEventDelegate = OnChannelEvent;
                onMessageEventDelegate = OnMessageEvent;
                onMessageReactionEventDelegate = OnMessageReactionEvent;
                onATMessageEventDelegate = OnATMessageEvent;
                onDirectMessageEventDelegate = OnDirectMessageEvent;
                onAudioEventDelegate = OnAudioEvent;

            }

            public static EventsHandler Create(Bot bot) => new(bot);

            public void Init(BotEvents events)
            {
                if (events.EnableGuildEvent)
                    CoreGo.EnableGuildEventHandler(Marshal.GetFunctionPointerForDelegate(onGuildEventDelegate));
                if (events.EnableGuildMemberEvent)
                    CoreGo.EnableGuildMemberEventHandler(Marshal.GetFunctionPointerForDelegate(onGuildMemberEventDelegate));
                if (events.EnableChennelEvent)
                    CoreGo.EnableChannelEventHandler(Marshal.GetFunctionPointerForDelegate(onChannelEventDelegate));
                if (events.EnableMessageEvent)
                    CoreGo.EnableMessageEventHandler(Marshal.GetFunctionPointerForDelegate(onMessageEventDelegate));
                if (events.EnableMessageReactionEvent)
                    CoreGo.EnableMessageReactionEventHandler(Marshal.GetFunctionPointerForDelegate(onMessageReactionEventDelegate));
                if (events.EnableATMessageEvent)
                    CoreGo.EnableATMessageEventHandler(Marshal.GetFunctionPointerForDelegate(onATMessageEventDelegate));
                if (events.EnableDirectMessageEvent)
                    CoreGo.EnableDirectMessageEventHandler(Marshal.GetFunctionPointerForDelegate(onDirectMessageEventDelegate));
                if (events.EnableAudioEvent)
                    CoreGo.EnableAudioEventHandler(Marshal.GetFunctionPointerForDelegate(onAudioEventDelegate));
            }


            private void OnGuildEvent(IntPtr eventJson, IntPtr dataJson)
            {
                bot.MutexAction(() =>
                {
                    bot.PluginFuncsDelegate?.Invoke().ForEach(funcs => { new Thread(() => { funcs.OnGuildEvent(Marshal.PtrToStringUTF8(dataJson)!); }).Start(); });
                });
            }


            private void OnGuildMemberEvent(IntPtr eventJson, IntPtr dataJson)
            {
                bot.MutexAction(() =>
                {
                    bot.PluginFuncsDelegate?.Invoke().ForEach(funcs => { new Thread(() => { funcs.OnGuildMemberEvent(Marshal.PtrToStringUTF8(dataJson)!); }).Start(); });
                });
            }


            private void OnChannelEvent(IntPtr eventJson, IntPtr dataJson)
            {
                bot.MutexAction(() =>
                {
                    bot.PluginFuncsDelegate?.Invoke().ForEach(funcs => { new Thread(() => { funcs.OnChannelEvent(Marshal.PtrToStringUTF8(dataJson)!); }).Start(); });
                });
            }


            private void OnMessageEvent(IntPtr eventJson, IntPtr dataJson)
            {
                bot.MutexAction(() =>
                {
                    bot.PluginFuncsDelegate?.Invoke().ForEach(funcs => { new Thread(() => { funcs.OnMessageEvent(Marshal.PtrToStringUTF8(dataJson)!); }).Start(); });
                });

            }


            private void OnMessageReactionEvent(IntPtr eventJson, IntPtr dataJson)
            {
                bot.MutexAction(() =>
                {
                    bot.PluginFuncsDelegate?.Invoke().ForEach(funcs => { new Thread(() => { funcs.OnMessageReactionEvent(Marshal.PtrToStringUTF8(dataJson)!); }).Start(); });
                });
            }


            private void OnATMessageEvent(IntPtr eventJson, IntPtr dataJson)
            {
                bot.MutexAction(() =>
                {
                    bot.PluginFuncsDelegate?.Invoke().ForEach(funcs => { new Thread(() => { funcs.OnATMessageEvent(Marshal.PtrToStringUTF8(dataJson)!); }).Start(); });
                });
            }


            private void OnDirectMessageEvent(IntPtr eventJson, IntPtr dataJson)
            {
                bot.MutexAction(() =>
                {
                    bot.PluginFuncsDelegate?.Invoke().ForEach(funcs => { new Thread(() => { funcs.OnDirectMessageEvent(Marshal.PtrToStringUTF8(dataJson)!); }).Start(); });
                });
            }


            private void OnAudioEvent(IntPtr eventJson, IntPtr dataJson)
            {
                bot.MutexAction(() =>
                {
                    bot.PluginFuncsDelegate?.Invoke().ForEach(funcs => { new Thread(() => { funcs.OnAudioEvent(Marshal.PtrToStringUTF8(dataJson)!); }).Start(); });
                });
            }



        }
    }
}
