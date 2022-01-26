using PInvoke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Sirius.PluginSupport.C
{
    internal class CPluginFunc : IPluginFunc
    {
        private readonly CPluginFuncDelegate.InitOpenApi initOpenApi;
        private readonly CPluginFuncDelegate.OnStart onStart;
        private readonly CPluginFuncDelegate.OnStop onStop;
        private readonly CPluginFuncDelegate.OnGuildEvent? onGuildEvent;
        private readonly CPluginFuncDelegate.OnGuildMemberEvent? onGuildMemberEvent;
        private readonly CPluginFuncDelegate.OnChannelEvent? onChannelEvent;
        private readonly CPluginFuncDelegate.OnMessageEvent? onMessageEvent;
        private readonly CPluginFuncDelegate.OnMessageReactionEvent? onMessageReactionEvent;
        private readonly CPluginFuncDelegate.OnATMessageEvent? onATMessageEvent;
        private readonly CPluginFuncDelegate.OnDirectMessageEvent? onDirectMessageEvent;
        private readonly CPluginFuncDelegate.OnAudioEvent? onAudioEvent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <exception cref="Exception"></exception>
        private CPluginFunc(Kernel32.SafeLibraryHandle handle)
        {
            IntPtr funcAddress;

            funcAddress = Kernel32.GetProcAddress(handle, "InitOpenApi");
            if (IntPtr.Zero == funcAddress)
                throw new Exception("插件未导出InitOpenApi函数");
            else
                initOpenApi = Marshal.GetDelegateForFunctionPointer<CPluginFuncDelegate.InitOpenApi>(funcAddress);

            funcAddress = Kernel32.GetProcAddress(handle, "OnStart");
            if (IntPtr.Zero == funcAddress)
                throw new Exception("插件未导出OnStart函数");
            else
                onStart = Marshal.GetDelegateForFunctionPointer<CPluginFuncDelegate.OnStart>(funcAddress);

            funcAddress = Kernel32.GetProcAddress(handle, "OnStop");
            if (IntPtr.Zero == funcAddress)
                throw new Exception("插件未导出OnStop函数");
            else
                onStop = Marshal.GetDelegateForFunctionPointer<CPluginFuncDelegate.OnStop>(funcAddress);

            funcAddress = Kernel32.GetProcAddress(handle, "OnGuildEvent");
            if (IntPtr.Zero != funcAddress)
                onGuildEvent = Marshal.GetDelegateForFunctionPointer<CPluginFuncDelegate.OnGuildEvent>(funcAddress);

            funcAddress = Kernel32.GetProcAddress(handle, "OnGuildMemberEvent");
            if (IntPtr.Zero != funcAddress)
                onGuildMemberEvent = Marshal.GetDelegateForFunctionPointer<CPluginFuncDelegate.OnGuildMemberEvent>(funcAddress);

            funcAddress = Kernel32.GetProcAddress(handle, "OnGuildMemberEvent");
            if (IntPtr.Zero != funcAddress)
                onChannelEvent = Marshal.GetDelegateForFunctionPointer<CPluginFuncDelegate.OnChannelEvent>(funcAddress);

            funcAddress = Kernel32.GetProcAddress(handle, "OnMessageEvent");
            if (IntPtr.Zero != funcAddress)
                onMessageEvent = Marshal.GetDelegateForFunctionPointer<CPluginFuncDelegate.OnMessageEvent>(funcAddress);

            funcAddress = Kernel32.GetProcAddress(handle, "OnMessageReactionEvent");
            if (IntPtr.Zero != funcAddress)
                onMessageReactionEvent = Marshal.GetDelegateForFunctionPointer<CPluginFuncDelegate.OnMessageReactionEvent>(funcAddress);

            funcAddress = Kernel32.GetProcAddress(handle, "OnATMessageEvent");
            if (IntPtr.Zero != funcAddress)
                onATMessageEvent = Marshal.GetDelegateForFunctionPointer<CPluginFuncDelegate.OnATMessageEvent>(funcAddress);

            funcAddress = Kernel32.GetProcAddress(handle, "OnDirectMessageEvent");
            if (IntPtr.Zero != funcAddress)
                onDirectMessageEvent = Marshal.GetDelegateForFunctionPointer<CPluginFuncDelegate.OnDirectMessageEvent>(funcAddress);

            funcAddress = Kernel32.GetProcAddress(handle, "OnAudioEvent");
            if (IntPtr.Zero != funcAddress)
                onAudioEvent = Marshal.GetDelegateForFunctionPointer<CPluginFuncDelegate.OnAudioEvent>(funcAddress);
        }

        public static CPluginFunc CreateFormSafeLibraryHandle(Kernel32.SafeLibraryHandle handle) => new(handle);

        public void InitOpenApi()
        {
            CPluginFuncDelegate.COpenAPI data = CPluginFuncDelegate.COpenAPI.New();
            initOpenApi.Invoke(ref data);
        }

        void IPluginFunc.OnStart() => onStart.Invoke();
        void IPluginFunc.OnStop() => onStop.Invoke();
        void IPluginFunc.OnGuildEvent(string dataJson) => onGuildEvent?.Invoke(dataJson);
        void IPluginFunc.OnGuildMemberEvent(string dataJson) => onGuildMemberEvent?.Invoke(dataJson);
        void IPluginFunc.OnChannelEvent(string dataJson) => onChannelEvent?.Invoke(dataJson);
        void IPluginFunc.OnMessageEvent(string dataJson) => onMessageEvent?.Invoke(dataJson);
        void IPluginFunc.OnMessageReactionEvent(string dataJson) => onMessageReactionEvent?.Invoke(dataJson);
        void IPluginFunc.OnATMessageEvent(string dataJson) => onATMessageEvent?.Invoke(dataJson);
        void IPluginFunc.OnDirectMessageEvent(string dataJson) => onDirectMessageEvent?.Invoke(dataJson);
        void IPluginFunc.OnAudioEvent(string dataJson) => onAudioEvent?.Invoke(dataJson);
    }
}
