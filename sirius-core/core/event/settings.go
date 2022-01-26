package event

type Settings struct {
	//频道事件
	Guild Handler
	//频道成员事件
	GuildMember Handler
	//子频道事件
	Channel Handler
	//消息事件
	Message Handler
	//表情表态事件
	MessageReaction Handler
	//@机器人 消息事件
	ATMessage Handler
	//私信消息事件
	DirectMessage Handler
	//音频机器人事件
	Audio Handler
}

type Handler struct {
	Address uintptr
	Enable  bool
	Handler interface{}
}

var GlobalSettings = Settings{}
