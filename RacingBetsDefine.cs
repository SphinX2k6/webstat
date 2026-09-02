using System;
using System.Runtime.CompilerServices;

// Token: 0x020026EC RID: 9964
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsDefine
{
	// Token: 0x040098FF RID: 39167
	public const int RACING_BETS_MAP_POINT_COUNT = 24;

	// Token: 0x04009900 RID: 39168
	public const int RACING_BETS_DICE_ANIM_COUNT = 10;

	// Token: 0x04009901 RID: 39169
	public const float RACING_BETS_DANGO_BROADCAST_MOVE_SPEED = 0.2f;

	// Token: 0x04009902 RID: 39170
	public const int RACING_BETS_DANGO_BROADCAST_INTERVAL = 5000;

	// Token: 0x04009903 RID: 39171
	public const int RACING_BETS_DANGO_ORDER_INTERVAL = 1000;

	// Token: 0x04009904 RID: 39172
	public const float RACING_BETS_FREE_CAMERA_TO_DICE_CAMERA_TIME = 1f;

	// Token: 0x04009905 RID: 39173
	public const float RACING_BETS_DICE_CAMERA_TO_FREE_CAMERA_TIME = 1f;

	// Token: 0x04009906 RID: 39174
	public const int RACING_BETS_DANGO_RANK_ITEM_OFFSET_INTERVAL = 20;

	// Token: 0x04009907 RID: 39175
	public const int RACING_BETS_DANGO_RANK_ITEM_LERP_INTERVAL = 1000;

	// Token: 0x04009908 RID: 39176
	public const int RACING_BETS_BULLET_SCREEN_MIN_ALPHA = 10;

	// Token: 0x04009909 RID: 39177
	public const int RACING_BETS_BULLET_SCREEN_MAX_ALPHA = 100;

	// Token: 0x0400990A RID: 39178
	public const int RACING_BETS_FOUR_DANGO = 4;

	// Token: 0x0400990B RID: 39179
	public const int RACING_BETS_SIX_DANGO = 6;

	// Token: 0x0400990C RID: 39180
	public const string CAMERA_DANGO_PREVIEW_SIX_PLAYER = "Camera_DangoPreview_6Player";

	// Token: 0x0400990D RID: 39181
	public const string CAMERA_DANGO_PREVIEW_FOUR_PLAYER = "Camera_DangoPreview_4Player";

	// Token: 0x0400990E RID: 39182
	public const string CAMERA_DANGO_PREVIEW_ONE_PLAYER = "Camera_DangoFocus_RaceEnd";

	// Token: 0x0400990F RID: 39183
	public const string CAMERA_DANGO_PREVIEW_START = "Camera_DangoPreview_Start";

	// Token: 0x04009910 RID: 39184
	public const string DANGO_PREVIEW_POINT_CASE_ONE_PLAYER = "DangoChampionCase";

	// Token: 0x04009911 RID: 39185
	public const string DANGO_GLOBAL_CONFIG_PATH = "/Game/Aki/Character/NPC/Tuanzi/CommonConfig/DangoGlobalConfig.DangoGlobalConfig";

	// Token: 0x04009912 RID: 39186
	public const string MPC_DICE_DATE_PATH = "/Game/Aki/Render/Data/MPC_DiceDate.MPC_DiceDate";

	// Token: 0x04009913 RID: 39187
	public const string RACING_BETS_AUDIO_STATE_GROUP = "dungeon_2_3_race_music";

	// Token: 0x04009914 RID: 39188
	public const string AUDIO_EVENT_BLACK_HOLE_SINK = "play_ui_fx_spl_rsnt_blackhole_sink";

	// Token: 0x04009915 RID: 39189
	private const float RACING_BETS_OFFSET_ZERO = 108f;

	// Token: 0x04009916 RID: 39190
	private const float RACING_BETS_OFFSET_ONE = 111.5f;

	// Token: 0x04009917 RID: 39191
	private const float RACING_BETS_OFFSET_TWO = 113.8f;

	// Token: 0x04009918 RID: 39192
	private const float RACING_BETS_OFFSET_THREE = 119.8f;

	// Token: 0x04009919 RID: 39193
	private const float RACING_BETS_OFFSET_FOUR = 120.1f;

	// Token: 0x0400991A RID: 39194
	private const float RACING_BETS_OFFSET_FIVE = 117.9f;

	// Token: 0x0400991B RID: 39195
	[StaticVariableRuleIgnore]
	public static readonly float[] RacingBetsDangoOddsOffsetList = new float[]
	{
		108f,
		111.5f,
		113.8f,
		119.8f,
		120.1f,
		117.9f
	};

	// Token: 0x0400991C RID: 39196
	[StaticVariableRuleIgnore]
	public static readonly int[] RacingBetsDiceIndexList = new int[]
	{
		1,
		2,
		4,
		5,
		6,
		7
	};
}
