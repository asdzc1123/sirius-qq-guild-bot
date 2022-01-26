#pragma once
#include <jni.h>
class JVMPlugin
{
public:
	JVMPlugin(JavaVM* p, const char* class_path);
	~JVMPlugin();
	void OnGuildEvent(const char* data_json);
	void OnGuildMemberEvent(const char* data_json);
	void OnChannelEvent(const char* data_json);
	void OnMessageEvent(const char* data_json);
	void OnMessageReactionEvent(const char* data_json);
	void OnATMessageEvent(const char* data_json);
	void OnDirectMessageEvent(const char* data_json);
	void OnAudioEvent(const char* data_json);

private:
	JavaVM* vm{ nullptr };
	JNIEnv* env{ nullptr };
	jobject plugin_object;

	jmethodID on_guild_event_method_id;
	jmethodID on_guild_member_event_method_id;
	jmethodID on_channel_event_method_id;
	jmethodID on_message_event_method_id;
	jmethodID on_message_reaction_event_method_id;
	jmethodID on_at_message_event_method_id;
	jmethodID on_direct_message_event_method_id;
	jmethodID on_audio_event_method_id;

};

