using System;
using System.Runtime.CompilerServices;

// Token: 0x020030E4 RID: 12516
[NullableContext(1)]
[Nullable(0)]
public static class FreeFollowingUtilsDefine
{
	// Token: 0x0400CF10 RID: 53008
	public const double FORWARD_OFFSET_SMOOTHING_TIME_SECONDS = 0.25;

	// Token: 0x0400CF11 RID: 53009
	public const double LEADER_SPEED_SMOOTHING_TIME_SECONDS = 0.2;

	// Token: 0x0400CF12 RID: 53010
	public const double LEADER_ACCELERATION_SMOOTHING_TIME_SECONDS = 0.12;

	// Token: 0x0400CF13 RID: 53011
	public const double ACCELERATION_PREDICTION_TIME_SECONDS = 0.18;

	// Token: 0x0400CF14 RID: 53012
	public const double MAX_LEADER_ACCELERATION_CMPS2 = 1200.0;

	// Token: 0x0400CF15 RID: 53013
	public const double REFERENCE_DIRECTION_SPEED_DEG_PER_SECOND = 180.0;

	// Token: 0x0400CF16 RID: 53014
	public const double REFERENCE_DIRECTION_DEAD_ZONE_DEGREES = 3.0;

	// Token: 0x0400CF17 RID: 53015
	public const double REFERENCE_DIRECTION_SNAP_ANGLE_DEGREES = 135.0;

	// Token: 0x0400CF18 RID: 53016
	public const double MOVEMENT_DIRECTION_MIN_SPEED_CMPS = 30.0;

	// Token: 0x0400CF19 RID: 53017
	public const double REVERSAL_TEASING_WINDOW_SECONDS = 1.5;

	// Token: 0x0400CF1A RID: 53018
	public const double REVERSAL_DETECT_DOT = -0.7071067811865476;

	// Token: 0x0400CF1B RID: 53019
	public const double REVERSAL_DETECT_MIN_SPEED_CMPS = 60.0;

	// Token: 0x0400CF1C RID: 53020
	public const double LOCAL_MOVEMENT_EXIT_RATE = 0.7;

	// Token: 0x0400CF1D RID: 53021
	public const double LOCAL_MOVEMENT_EXIT_CONFIRM_SECONDS = 0.2;

	// Token: 0x0400CF1E RID: 53022
	public const double HOLD_RADIUS_TOLERANCE = 1.0;

	// Token: 0x0400CF1F RID: 53023
	public const double WALK_ARRIVAL_HOLD_SECONDS = 0.3;

	// Token: 0x0400CF20 RID: 53024
	public const double WALK_BEHIND_TARGET_ENTER_ANGLE = 100.0;

	// Token: 0x0400CF21 RID: 53025
	public const double WALK_BEHIND_TARGET_RESET_ANGLE = 80.0;

	// Token: 0x0400CF22 RID: 53026
	public const double REJOIN_MIN_DURATION_SECONDS = 0.3;

	// Token: 0x0400CF23 RID: 53027
	public const double RECOVER_DURATION_SECONDS = 0.4;

	// Token: 0x0400CF24 RID: 53028
	public const double WALK_SIDE_SWITCH_MIN_ANGLE_DEGREES = 3.0;

	// Token: 0x0400CF25 RID: 53029
	public const double HIGH_SPEED_SIDE_SWITCH_MIN_ANGLE_DEGREES = 15.0;

	// Token: 0x0400CF26 RID: 53030
	public const double WALK_SIDE_SWITCH_MIN_RATE = 0.052335956242943835;

	// Token: 0x0400CF27 RID: 53031
	public const double HIGH_SPEED_SIDE_SWITCH_MIN_RATE = 0.25881904510252074;

	// Token: 0x0400CF28 RID: 53032
	[StaticVariableRuleIgnore]
	public static readonly string[] FreeFollowingStateNames = new string[]
	{
		"Stable",
		"FormationFollow",
		"Rejoin",
		"Recover"
	};

	// Token: 0x0400CF29 RID: 53033
	[StaticVariableRuleIgnore]
	public static readonly double[] FreeFollowingCandidateAngles = new double[]
	{
		0.0,
		-30.0,
		30.0,
		-60.0,
		60.0
	};
}
