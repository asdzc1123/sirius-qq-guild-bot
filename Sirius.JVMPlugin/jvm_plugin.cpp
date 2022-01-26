#include "pch.h"
#include "jvm_plugin.h"

JVMPlugin::JVMPlugin(JavaVM* p, const char* class_path) {
	vm = p;

	vm->AttachCurrentThread((void**)&env, nullptr);
	jclass clazz = env->FindClass(class_path);
	plugin_object = env->AllocObject(clazz);

	on_guild_event_method_id = env->GetMethodID(clazz, "nativeGuildEventHandler", "(Ljava/lang/String;)V");
	on_guild_member_event_method_id = env->GetMethodID(clazz, "nativeGuildMemberEventHandler", "(Ljava/lang/String;)V");
	on_channel_event_method_id = env->GetMethodID(clazz, "nativeChannelEventHandler", "(Ljava/lang/String;)V");
	on_message_event_method_id = env->GetMethodID(clazz, "nativeMessageEventHandler", "(Ljava/lang/String;)V");
	on_message_reaction_event_method_id = env->GetMethodID(clazz, "nativeMessageReactionEventHandler", "(Ljava/lang/String;)V");
	on_at_message_event_method_id = env->GetMethodID(clazz, "nativeMessageReactionEventHandler", "(Ljava/lang/String;)V");
	on_direct_message_event_method_id = env->GetMethodID(clazz, "nativeDirectMessageEventHandler", "(Ljava/lang/String;)V");
	on_audio_event_method_id = env->GetMethodID(clazz, "nativeAudioEventHandler", "(Ljava/lang/String;)V");
}



JVMPlugin::~JVMPlugin() {

}



void JVMPlugin::OnGuildEvent(const char* data_json) {
	env->CallVoidMethod(plugin_object, on_guild_event_method_id, env->NewStringUTF(data_json));
}


void JVMPlugin::OnGuildMemberEvent(const char* data_json) {
	env->CallVoidMethod(plugin_object, on_guild_member_event_method_id, env->NewStringUTF(data_json));
}


void JVMPlugin::OnChannelEvent(const char* data_json) {
	env->CallVoidMethod(plugin_object, on_channel_event_method_id, env->NewStringUTF(data_json));
}


void JVMPlugin::OnMessageEvent(const char* data_json) {
	env->CallVoidMethod(plugin_object, on_message_event_method_id, env->NewStringUTF(data_json));
}


void JVMPlugin::OnMessageReactionEvent(const char* data_json) {
	env->CallVoidMethod(plugin_object, on_message_reaction_event_method_id, env->NewStringUTF(data_json));
}


void JVMPlugin::OnATMessageEvent(const char* data_json) {
	env->CallVoidMethod(plugin_object, on_at_message_event_method_id, env->NewStringUTF(data_json));
}


void JVMPlugin::OnDirectMessageEvent(const char* data_json) {
	env->CallVoidMethod(plugin_object, on_direct_message_event_method_id, env->NewStringUTF(data_json));
}


void JVMPlugin::OnAudioEvent(const char* data_json) {
	env->CallVoidMethod(plugin_object, on_audio_event_method_id, env->NewStringUTF(data_json));
}
