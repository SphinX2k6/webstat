using System;
using System.Runtime.CompilerServices;

// Token: 0x02002BB5 RID: 11189
public static class TimeOfDayDefine
{
	// Token: 0x0400AC71 RID: 44145
	public const int TOD_MILLIONSECOND_PER_SECOND = 1000;

	// Token: 0x0400AC72 RID: 44146
	public const int TOD_SECOND_PER_MINUTE = 60;

	// Token: 0x0400AC73 RID: 44147
	public const int TOD_MINUTE_PER_HOUR = 60;

	// Token: 0x0400AC74 RID: 44148
	public const int TOD_HOUR_PER_DAY = 24;

	// Token: 0x0400AC75 RID: 44149
	public const int TOD_MINUTE_PER_DAY = 1440;

	// Token: 0x0400AC76 RID: 44150
	public const int TOD_SECOND_PER_HOUR = 3600;

	// Token: 0x0400AC77 RID: 44151
	public const int TOD_SECOND_PER_DAY = 86400;

	// Token: 0x0400AC78 RID: 44152
	public const int TOD_MILLIONSECOND_PER_DAY = 86400000;

	// Token: 0x0400AC79 RID: 44153
	public const int TOD_SAVE_CD_MINUTE = 2;

	// Token: 0x0400AC7A RID: 44154
	public const int TOD_SAVE_CD_SECONDS = 120;

	// Token: 0x0400AC7B RID: 44155
	public const int TOD_TICK_INTERVAL_SECOND = 0;

	// Token: 0x0400AC7C RID: 44156
	public const int TOD_TICK_INTERVAL_MILLIONSECOND = 0;

	// Token: 0x0400AC7D RID: 44157
	public const int TOD_RATE_RATIO = 10000;

	// Token: 0x0400AC7E RID: 44158
	public const int TOD_CIRCLE_ANGLE = 360;

	// Token: 0x0400AC7F RID: 44159
	public const int TOD_MIN_ADJUST_MINUTE = 30;

	// Token: 0x0400AC80 RID: 44160
	public const int TOD_MAX_ADJUST_DAY = 2;

	// Token: 0x0400AC81 RID: 44161
	[Nullable(1)]
	public const string TOD_CAMERA_SETTING_NAME = "1032";

	// Token: 0x0400AC82 RID: 44162
	public const int TOD_ANIMATION_LAST_SECOND = 2;

	// Token: 0x0400AC83 RID: 44163
	public const int DEFAULT_JUMP_HOUR = 12;
}
