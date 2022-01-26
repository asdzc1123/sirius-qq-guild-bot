#pragma once

namespace jvm {
	void Init();
	void OnGuildEvent(const char* data_json);
	void OnGuildMemberEvent(const char* data_json);
	void OnChannelEvent(const char* data_json);
	void OnMessageEvent(const char* data_json);
	void OnMessageReactionEvent(const char* data_json);
	void OnATMessageEvent(const char* data_json);
	void OnDirectMessageEvent(const char* data_json);
	void OnAudioEvent(const char* data_json);
}