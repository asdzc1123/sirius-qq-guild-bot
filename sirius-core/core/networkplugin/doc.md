# 天狼星网络插件

## 事件

1. 连接 WebSocket `localhost:你绑定的端口/plugin/events`
2. 并携带查询参数`name`(也就是插件的名称,注意不能重复) 示例`ws:localhost:44444/plugin/events?name=小草`
3. 连接上之后会收到一个token(把他保存下来作为OpenAPI的Header传递)
4. 然后接收到的消息就全部是JSON了 格式如下

```json
{
  "name": "事件名称",
  "data": "事件的原始数据(也是JSON)"
}
```



#### 对应的事件

| 名称       | 对应的C#数据类型                    | JSON中的name字段           | 
|----------|------------------------------|------------------------|
| 频道事件     | `Sirius.DTO.Guild`           | `GuildEvent`           |
| 频道成员事件   | `Sirius.DTO.Member`          | `GuildMemberEvent`     |
| 子频道事件    | `Sirius.DTO.Channel`         | `ChannelEvent`         |
| 消息事件     | `Sirius.DTO.Message`         | `MessageEvent`         |
| 表情表态事件   | `Sirius.DTO.MessageReaction` | `MessageReactionEvent` |
| @机器人消息事件 | `Sirius.DTO.Message`         | `ATMessageEvent`       |
| 私聊消息事件   | `Sirius.DTO.Message`         | `DirectMessageEvent`   |
| 音频事件     | `Sirius.DTO.AudioAction`     | `AudioMessageEvent`    |

# OpenAPI

Post提交JSON

`localhost:你绑定的端口/openapi/API名称`

请求时需要携带一个查询参数name(跟创建WebSocket连接时候传的那个一样) 示例`http://localhost:44444/openapi/me?name=小草`  

请求时带上两个Header,分别是`name`和`token`  

并携带一个Header`Token`(WebSocket服务端发送给你的第一条数据)

JSON参数的实体类请参考C#的`Sirius.DTO` 或者腾讯官方的`botgo`


#### API列表

| 名称          | URL路径                  | 参数列表                                        |
|-------------|------------------------|---------------------------------------------|
| 获取消息信息      | `/message`             | `channel_id` `message_id`                   |
| 获取消息信息数组    | `/messages`            | `channel_id` `pager_json`                   |
| 发送消息        | `/post-message`        | `channel_id` `message_json`                 |
| 撤回消息        | `/retract-message`     | `channel_id` `message_id`                   |
| 获取频道信息      | `/guild`               | `guild_id`                                  |
| 获取频道成员信息    | `/guild-member`        | `guild_id` `user_id`                        |
| 获取频道成员信息数组  | `/guild-members`       | `guild_id` `pager_json`                     |
| 删除频道成员(踢人)  | `/delete-guild-member` | `guild_id` `user_id`                        |
| 频道全员禁言      | `/guild-mute`          | `guild_id` `mute_json`                      |
| 获取子频道信息     | `/channel`             | `channel_id`                                |
| 获取子频道信息数组   | `/channels`            | `guild_id`                                  |
| 添加子频道       | `/post-channel`        | `guild_id` `channel_value_object_json`      |
| 修改子频道       | `/patch-channel`       | `guild_id` `channel_value_object_json`      |
| 删除子频道       | `/delete-channel`      | `channel_id`                                |
| 获取自己的用户信息   | `/me`                  |                                             |
| 获取自己加入的频道数组 | `/me-guilds`           | `pager_json`                                |
| 成员添加角色      | `/member-add-role`     | `guild_id` `role_id` `user_id` `value_json` |
| 成员删除角色      | `/member-delete-role`  | `guild_id` `role_id` `user_id` `value_json` |
| 禁言成员        | `/member-mute`         | `guild_id` `user_id` `mute_json`            |
