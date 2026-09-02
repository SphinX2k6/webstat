using System;
using UnrealEngine;

// Token: 0x020025A7 RID: 9639
public class PhotographDefine
{
	// Token: 0x040092D5 RID: 37589
	public const int DEFAULT_FOV = 60;

	// Token: 0x040092D6 RID: 37590
	public const int MIN_FOV = 30;

	// Token: 0x040092D7 RID: 37591
	public const int MAX_FOV = 90;

	// Token: 0x040092D8 RID: 37592
	public const int MAX_DISTANCE_VALUE = 9999999;

	// Token: 0x040092D9 RID: 37593
	public const int DEFAULT_FILTER_CONFIGID = 1;

	// Token: 0x040092DA RID: 37594
	public const int FILTER_MIN_STRENGTH = 0;

	// Token: 0x040092DB RID: 37595
	public const int FILTER_MAX_STREGNTH = 100;

	// Token: 0x040092DC RID: 37596
	public const int FILTER_DEFAULT_STRENGTH = 100;

	// Token: 0x040092DD RID: 37597
	public const int DEFAULT_MANUAL_FOCUS_DISTANCE = 300;

	// Token: 0x040092DE RID: 37598
	public const int DEFAULT_FOCAL_LENTGH = 35;

	// Token: 0x040092DF RID: 37599
	public const int DEFAULT_APERTURE = 0;

	// Token: 0x040092E0 RID: 37600
	public const int MIN_TOUCH_MOVE_DIFFERENCE = -50000;

	// Token: 0x040092E1 RID: 37601
	public const int MAX_TOUCH_MOVE_DIFFERENCE = 50000;

	// Token: 0x040092E2 RID: 37602
	public static readonly FName SPAWN_SOCKET_NAME = new FName("HitCase");

	// Token: 0x040092E3 RID: 37603
	public const float SCREEN_SHOT_TEXTURE_SCALE = 1.5f;

	// Token: 0x040092E4 RID: 37604
	public const int MAX_HIGH_RES_MULTIPLIER = 4;

	// Token: 0x040092E5 RID: 37605
	public const int MIN_HIGH_RES_MULTIPLIER = 1;

	// Token: 0x040092E6 RID: 37606
	public const int MAX_LOD_BIAS = -7;

	// Token: 0x040092E7 RID: 37607
	public const int DEFAULT_LOD_BIAS = 0;

	// Token: 0x040092E8 RID: 37608
	public const int FIRST_SHARE_DROP_ID = 90005;

	// Token: 0x040092E9 RID: 37609
	public const float PHOTOGRAPH_CAMERA_BLEND_OUT = 0.5f;

	// Token: 0x040092EA RID: 37610
	public static readonly FName ignoreTouchTag = new FName("IgnoreTouch");

	// Token: 0x040092EB RID: 37611
	public const int DEFAULT_SHARE_WIDTH = 1750;

	// Token: 0x040092EC RID: 37612
	public const int DEFAULT_SHARE_HEIGHT = 986;
}
