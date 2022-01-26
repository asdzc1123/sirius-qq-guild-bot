#include "pch.h"
#include <stdio.h>



struct COpenAPI {
public:

	COpenAPI(COpenAPI* stack_memory_data) {
		this->message_func = stack_memory_data->message_func;
		this->messages_func = stack_memory_data->messages_func;
		this->post_message_func = stack_memory_data->post_message_func;
		this->retract_message_func = stack_memory_data->retract_message_func;
		this->guild_func = stack_memory_data->guild_func;
		this->guild_member_func = stack_memory_data->guild_member_func;
		this->guild_members_func = stack_memory_data->guild_members_func;
		this->delete_guild_member_func = stack_memory_data->delete_guild_member_func;
		this->guild_mute_func = stack_memory_data->guild_mute_func;
		this->channel_func = stack_memory_data->channel_func;
		this->channels_func = stack_memory_data->channels_func;
		this->post_channel_func = stack_memory_data->post_channel_func;
		this->patch_channel_func = stack_memory_data->patch_channel_func;
		this->delete_channel_func = stack_memory_data->delete_channel_func;
		this->me_func = stack_memory_data->me_func;
		this->me_guilds_func = stack_memory_data->me_guilds_func;
		this->member_add_role_func = stack_memory_data->member_add_role_func;
		this->member_delete_role_func = stack_memory_data->member_delete_role_func;
		this->member_mute_func = stack_memory_data->member_mute_func;
	}

	const char* OpenApiMessage(const char* channel_id, const char* msg_id) {
		typedef const char* (*Method)(const char* channel_id, const char* msg_id);
		return reinterpret_cast<Method>(message_func)(channel_id, msg_id);
	}

	const char* OpenApiMessages(const char* channel_id, const char* pager_json) {
		typedef const char* (*Method)(const char* channel_id, const char* pager_json);
		return reinterpret_cast<Method>(messages_func)(channel_id, pager_json);
	}

	const char* OpenApiPostMessage(const char* channel_id, const char* msg_json) {
		typedef const char* (*Method)(const char* channel_id, const char* msg_json);
		return reinterpret_cast<Method>(post_message_func)(channel_id, msg_json);
	}

	bool OpenApiRetractMessage(const char* channel_id, const char* msg_id) {
		typedef bool (*Method)(const char* channel_id, const char* msg_id);
		return reinterpret_cast<Method>(post_message_func)(channel_id, msg_id);
	}

	const char* OpenApiGuild(const char* guild_id) {
		typedef const char* (*Method)(const char* guild_id);
		return reinterpret_cast<Method>(guild_func)(guild_id);
	}

	const char* OpenApiGuildMember(const char* guild_id, const char* user_id) {
		typedef const char* (*Method)(const char* guild_id, const char* user_id);
		return reinterpret_cast<Method>(guild_func)(guild_id, user_id);
	}

	const char* OpenApiGuildMembers(const char* guild_id, const char* pager_json) {
		typedef const char* (*Method)(const char* guild_id, const char* pager_json);
		return reinterpret_cast<Method>(guild_members_func)(guild_id, pager_json);
	}

	bool OpenApiDeleteGuildMember(const char* guild_id, const char* user_id) {
		typedef const char* (*Method)(const char* guild_id, const char* user_id);
		return reinterpret_cast<Method>(delete_guild_member_func)(guild_id, user_id);
	}

	bool OpenApiGuildMute(const char* guild_id, const char* mute_json) {
		typedef bool (*Method)(const char* guild_id, const char* mute_json);
		return reinterpret_cast<Method>(guild_mute_func)(guild_id, mute_json);
	}

	const char* OpenApiChannel(const char* channel_id) {
		typedef const char* (*Method)(const char* channel_id);
		return reinterpret_cast<Method>(channel_func)(channel_id);
	}

	const char* OpenApiChannels(const char* guild_id) {
		typedef const char* (*Method)(const char* guild_id);
		return reinterpret_cast<Method>(channels_func)(guild_id);
	}

	const char* OpenApiPostChannel(const char* guild_id, const char* channel_value_objet_json) {
		typedef const char* (*Method)(const char* guild_id, const char* channel_value_objet_json);
		return reinterpret_cast<Method>(post_channel_func)(guild_id, channel_value_objet_json);
	}

	const char* OpenApiPatchChannel(const char* guild_id, const char* channel_value_objet_json) {
		typedef const char* (*Method)(const char* guild_id, const char* channel_value_objet_json);
		return reinterpret_cast<Method>(patch_channel_func)(guild_id, channel_value_objet_json);
	}

	bool OpenApiDeleteChannel(const char* guild_id) {
		typedef bool (*Method)(const char* guild_id);
		return reinterpret_cast<Method>(delete_channel_func)(guild_id);
	}

	const char* OpenApiMe() {
		typedef const char* (*Method)();
		return reinterpret_cast<Method>(me_func)();
	}

	const char* OpenApiMeGuilds(const char* pager_json) {
		typedef const char* (*Method)(const char* pager_json);
		return reinterpret_cast<Method>(me_guilds_func)(pager_json);
	}

	bool OpenApiMemberAddRole(const char* guild_id, const char* role_id, const char* user_id, const char* value_json) {
		typedef bool (*Method)(const char* guild_id, const char* role_id, const char* user_id, const char* value_json);
		return reinterpret_cast<Method>(member_add_role_func)(guild_id, role_id, user_id, value_json);
	}

	bool OpenApiMemberDeleteRole(const char* guild_id, const char* role_id, const char* user_id, const char* value_json) {
		typedef bool (*Method)(const char* guild_id, const char* role_id, const char* user_id, const char* value_json);
		return reinterpret_cast<Method>(member_delete_role_func)(guild_id, role_id, user_id, value_json);
	}

	bool OpenApiMemberMute(const char* guild_id, const char* user_id, const char* mute_json) {
		typedef bool (*Method)(const char* guild_id, const char* user_id, const char* mute_json);
		return reinterpret_cast<Method>(member_mute_func)(guild_id, user_id, mute_json);
	}

private:
	uintptr_t message_func = 0;
	uintptr_t messages_func = 0;
	uintptr_t post_message_func = 0;
	uintptr_t retract_message_func = 0;
	uintptr_t guild_func = 0;
	uintptr_t guild_member_func = 0;
	uintptr_t guild_members_func = 0;
	uintptr_t delete_guild_member_func = 0;
	uintptr_t guild_mute_func = 0;
	uintptr_t channel_func = 0;
	uintptr_t channels_func = 0;
	uintptr_t post_channel_func = 0;
	uintptr_t patch_channel_func = 0;
	uintptr_t delete_channel_func = 0;
	uintptr_t me_func = 0;
	uintptr_t me_guilds_func = 0;
	uintptr_t member_add_role_func = 0;
	uintptr_t member_delete_role_func = 0;
	uintptr_t member_mute_func = 0;
};

COpenAPI* api = nullptr;
extern "C" {

	void OpenApiInit(COpenAPI* c_open_api) {
		api = new COpenAPI(c_open_api);
	}

	/// <summary>
	///  IDȡ��Ϣ����
	/// </summary>
	/// <param name="channel_id">��Ƶ��</param>
	/// <param name="msg_id">��ϢID</param>
	/// <returns></returns>
	const char* OpenApiMessage(const char* channel_id, const char* msg_id) {
		return api->OpenApiMessage(channel_id, msg_id);
	}

	/// <summary>
	/// ������Ϣ
	/// </summary>
	/// <param name="channel_id">��Ƶ��ID</param>
	/// <param name="msg_json">��Ϣԭʼ����</param>
	/// <returns></returns>
	const char* OpenApiPostMessage(const char* channel_id, const char* msg_json) {
		return api->OpenApiPostMessage(channel_id, msg_json);
	}

	/// <summary>
	/// ������Ϣ
	/// </summary>
	/// <param name="channel_id">��Ƶ��ID</param>
	/// <param name="msg_id">��ϢID</param>
	/// <returns></returns>
	bool  OpenApiRetractMessage(const char* channel_id, const char* msg_id) {
		return api->OpenApiRetractMessage(channel_id, msg_id);
	}

	/// <summary>
	/// ȡƵ����Ϣ
	/// </summary>
	/// <param name="guild_id">Ƶ��ID</param>
	/// <returns></returns>
	const char* OpenApiGuild(const char* guild_id) {
		return api->OpenApiGuild(guild_id);
	}

	/// <summary>
	/// ��ȡƵ��Member��Ϣ
	/// </summary>
	/// <param name="guild_id">Ƶ��ID</param>
	/// <returns></returns>
	const char* OpenApiGuildMember(const char* guild_id, const char* user_id) {
		return api->OpenApiGuildMember(guild_id, user_id);
	}

	/// <summary>
	/// ȡƵ����Ա��Ϣ�б�
	/// </summary>
	/// <param name="guild_id">Ƶ��ID</param>
	/// <param name="pager_json">��ҳԭʼ����</param>
	/// <returns></returns>
	const char* OpenApiGuildMembers(const char* guild_id, const char* pager_json) {
		return api->OpenApiGuildMembers(guild_id, pager_json);
	}

	/// <summary>
	/// ɾ��Ƶ����Ա
	/// </summary>
	/// <param name="guild_id">Ƶ��ID</param>
	/// <param name="user_id">�û�ID</param>
	/// <returns></returns>
	bool  OpenApiDeleteGuildMember(const char* guild_id, const char* user_id) {
		return api->OpenApiDeleteGuildMember(guild_id, user_id);
	}

	/// <summary>
	/// Ƶ������
	/// </summary>
	/// <param name="guild_id">Ƶ��ID</param>
	/// <param name="mute_json">����ԭʼ����</param>
	/// <returns></returns>
	bool  OpenApiGuildMute(const char* guild_id, const char* mute_json) {
		return api->OpenApiDeleteGuildMember(guild_id, mute_json);
	}

	/// <summary>
	/// ȡ��Ƶ����Ϣ
	/// </summary>
	/// <param name="channel_id">��Ƶ��ID</param>
	/// <returns></returns>
	const char* OpenApiChannel(const char* channel_id) {
		return api->OpenApiChannel(channel_id);
	}

	/// <summary>
	/// ȡĳƵ������Ƶ���б�
	/// </summary>
	/// <param name="guild_id">Ƶ��ID</param>
	/// <returns></returns>
	const char* OpenApiChannels(const char* guild_id) {
		return api->OpenApiChannels(guild_id);
	}

	/// <summary>
	/// ������Ƶ��
	/// </summary>
	/// <param name="guild_id">Ƶ��ID</param>
	/// <param name="channel_value_objet_json">Ƶ������</param>
	/// <returns></returns>
	const char* OpenApiPostChannel(const char* guild_id, const char* channel_value_objet_json) {
		return api->OpenApiPostChannel(guild_id, channel_value_objet_json);
	}

	/// <summary>
	/// ������Ƶ����Ϣ
	/// </summary>
	/// <param name="guild_id">Ƶ��ID</param>
	/// <param name="channel_value_objet_json">Ƶ������</param>
	/// <returns></returns>
	const char* OpenApiPatchChannel(const char* guild_id, const char* channel_value_objet_json) {
		return api->OpenApiPatchChannel(guild_id, channel_value_objet_json);
	}

	/// <summary>
	/// ɾ����Ƶ��
	/// </summary>
	/// <param name="guild_id">Ƶ��ID</param>
	/// <returns></returns>
	bool OpenApiDeleteChannel(const char* guild_id) {
		return api->OpenApiDeleteChannel(guild_id);
	}

	/// <summary>
	/// ȡ����Bot��Ϣ
	/// </summary>
	/// <returns></returns>
	const char* OpenApiMe() {
		return api->OpenApiMe();
	}

	/// <summary>
	/// ȡ����Ƶ���б�
	/// </summary>
	/// <param name="pager_json">��ҳԭʼ����</param>
	/// <returns></returns>
	const char* OpenApiMeGuilds(const char* pager_json) {
		return api->OpenApiMeGuilds(pager_json);
	}

	/// <summary>
	/// ��Ա��ӽ�ɫ
	/// </summary>
	/// <param name="guild_id">Ƶ��ID</param>
	/// <param name="role_id">��ɫID</param>
	/// <param name="user_id">�û�ID</param>
	/// <param name="value_json">��ɫԭʼ����</param>
	/// <returns></returns>
	bool OpenApiMemberAddRole(const char* guild_id, const char* role_id, const char* user_id, const char* value_json) {
		return api->OpenApiMemberAddRole(guild_id, role_id, user_id, value_json);
	}

	/// <summary>
	/// ��Աɾ����ɫ
	/// </summary>
	/// <param name="guild_id">Ƶ��ID</param>
	/// <param name="role_id">��ɫID</param>
	/// <param name="user_id">�û�ID</param>
	/// <param name="value_json">��ɫԭʼ����</param>
	/// <returns></returns>
	bool OpenApiMemberDeleteRole(const char* guild_id, const char* role_id, const char* user_id, const char* value_json) {
		return api->OpenApiMemberDeleteRole(guild_id, role_id, user_id, value_json);
	}

	/// <summary>
	/// ��Ա����
	/// </summary>
	/// <param name="guild_id">Ƶ��ID</param>
	/// <param name="user_id">�û�ID</param>
	/// <param name="mute_json">����ԭʼ����</param>
	/// <returns></returns>
	bool OpenApiMemberMute(const char* guild_id, const char* user_id, const char* mute_json) {
		return api->OpenApiMemberMute(guild_id, user_id, mute_json);
	}
}