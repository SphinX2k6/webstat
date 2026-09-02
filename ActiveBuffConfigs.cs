using System;

// Token: 0x02002E70 RID: 11888
public class ActiveBuffConfigs
{
	// Token: 0x0400BBEC RID: 48108
	public const long NULL_BUFF_ID = 0L;

	// Token: 0x0400BBED RID: 48109
	public const long DYNAMIC_BUFF_ID = -3L;

	// Token: 0x0400BBEE RID: 48110
	public const int DEFAULT_BUFF_LEVEL = 1;

	// Token: 0x0400BBEF RID: 48111
	public const int DEFAULT_GE_SERVER_ID = -1;

	// Token: 0x0400BBF0 RID: 48112
	public const int DEFAULT_SERVER_GE_DURATION = -1;

	// Token: 0x0400BBF1 RID: 48113
	[StaticVariableRuleIgnore]
	public static readonly float? USE_INTERNAL_DURATION;

	// Token: 0x0400BBF2 RID: 48114
	public const int INVALID_BUFF_HANDLE = -1;

	// Token: 0x0400BBF3 RID: 48115
	public const long NULL_INSTIGATOR_ID = 0L;

	// Token: 0x0400BBF4 RID: 48116
	public const float MIN_BUFF_REMAIN_DURATION = 0.0001f;

	// Token: 0x0400BBF5 RID: 48117
	public const int SUCCESS_INSTANT_BUFF_HANDLE = -2;

	// Token: 0x0400BBF6 RID: 48118
	public const int INFINITY_DURATION = -1;

	// Token: 0x0400BBF7 RID: 48119
	public const float MIN_BUFF_PERIOD = 0.034f;

	// Token: 0x0400BBF8 RID: 48120
	public const float MIN_BUFF_EXECUTION_EFFECT_PERIOD = 0.2f;

	// Token: 0x0400BBF9 RID: 48121
	public const int BUFF_HANDLE_ID_BYTE = 28;

	// Token: 0x0400BBFA RID: 48122
	public const int BUFF_HANDLE_PREFIX_BYTE = 4;

	// Token: 0x0400BBFB RID: 48123
	public const int HANDLE_MASK = 268435455;
}
