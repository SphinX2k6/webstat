using System;
using System.Runtime.CompilerServices;

// Token: 0x020030D5 RID: 12501
[NullableContext(1)]
[Nullable(0)]
public static class KeepFollowingMoveLogicDefine
{
	// Token: 0x0400CE18 RID: 52760
	public const int DEBUG_RADIUS = 20;

	// Token: 0x0400CE19 RID: 52761
	public const int DEBUG_SEGMENTS = 10;

	// Token: 0x0400CE1A RID: 52762
	public const int DETECT_HEIGHT = 2;

	// Token: 0x0400CE1B RID: 52763
	public const string PROFILE_KEY = "KeepFollowing";

	// Token: 0x0400CE1C RID: 52764
	public const int CHECK_DIRECTION_ANGLE = 40;

	// Token: 0x0400CE1D RID: 52765
	[StaticVariableRuleIgnore]
	public static readonly int[] checkDirectionList = new int[]
	{
		0,
		1,
		2,
		3,
		4,
		-1
	};

	// Token: 0x0400CE1E RID: 52766
	[StaticVariableRuleIgnore]
	public static readonly int[] checkDistanceList = new int[]
	{
		0,
		100,
		200,
		300,
		400
	};

	// Token: 0x0400CE1F RID: 52767
	public const int MIN_ANGLE = 5;

	// Token: 0x0400CE20 RID: 52768
	public const float STAND_TOLERANCE_RATE = 0.4f;

	// Token: 0x0400CE21 RID: 52769
	public const int COMPENSATE_TOLERANCE_DISTANCE = 5;

	// Token: 0x0400CE22 RID: 52770
	public const int ANGLE_DIRECTION_TOLERANCE = 45;

	// Token: 0x0400CE23 RID: 52771
	public const float DECELERATION_SPEED_RATE = -5f;

	// Token: 0x0400CE24 RID: 52772
	public const int ROTATION_STOP_DELAY_STAND = 200;

	// Token: 0x0400CE25 RID: 52773
	public const float MIN_MOVE_SPEED_RATE = 0.3f;

	// Token: 0x0400CE26 RID: 52774
	public const int MODEL_BUFFER_TIME = 100;

	// Token: 0x0400CE27 RID: 52775
	public const int STAND_CHECK_TIME = 800;

	// Token: 0x0400CE28 RID: 52776
	public const int STAND_ROTATION_INTERVAL = 2000;

	// Token: 0x0400CE29 RID: 52777
	public const int SECOND_TO_MILLISECOND = 1000;

	// Token: 0x0400CE2A RID: 52778
	public const float HEIGHT_LIMIT = 800f;

	// Token: 0x0400CE2B RID: 52779
	public const int END_DISTANCE = 80;
}
