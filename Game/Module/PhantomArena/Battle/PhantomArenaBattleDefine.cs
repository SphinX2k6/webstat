using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle
{
	// Token: 0x020055A3 RID: 21923
	[NullableContext(1)]
	[Nullable(0)]
	public static class PhantomArenaBattleDefine
	{
		// Token: 0x0401FF25 RID: 130853
		[StaticVariableRuleIgnore]
		public static readonly int[] functionAreaTypeList = new int[]
		{
			0,
			0,
			0,
			0,
			0,
			0,
			1
		};

		// Token: 0x0401FF26 RID: 130854
		public const int CHECK_ATTACH_DISTANCE = 200;

		// Token: 0x0401FF27 RID: 130855
		public const int DISTANCE_MAX = 99999;

		// Token: 0x0401FF28 RID: 130856
		public const int HANDCARD_LIMIT = 6;

		// Token: 0x0401FF29 RID: 130857
		public const int HAND_PHANTOMARENA_INDEX = -1;

		// Token: 0x0401FF2A RID: 130858
		public const int INVALID_CARD_ID = -1;

		// Token: 0x0401FF2B RID: 130859
		public const int UNVALID_FIGHT_ID = -1;

		// Token: 0x0401FF2C RID: 130860
		public const int UNVALID_DURABILITY = -1;

		// Token: 0x0401FF2D RID: 130861
		public const int LIMIT_BATTLE_CARD_NUM = 4;

		// Token: 0x0401FF2E RID: 130862
		public const int COST_ONE = 1;

		// Token: 0x0401FF2F RID: 130863
		public const int COST_THREE = 3;

		// Token: 0x0401FF30 RID: 130864
		public const int AI_SENSE_ID = 80017;

		// Token: 0x0401FF31 RID: 130865
		public const string AI_HATE_ID = "80017";

		// Token: 0x0401FF32 RID: 130866
		public const int HIDETIPS_BY_FUNCTIONALDRAG_DISTANCE = 100;

		// Token: 0x0401FF33 RID: 130867
		public const int PLAY_STARTTIME_CARD_TWEEN_DELAY = 30;

		// Token: 0x0401FF34 RID: 130868
		public const float PLAY_TWEEN_DURATION = 0.5f;

		// Token: 0x0401FF35 RID: 130869
		public const float PLAY_RESET_POS_TWEEN_DURATION = 0.2f;

		// Token: 0x0401FF36 RID: 130870
		public const float PLAY_CHANGE_CARD_TWEEN_DURATION = 0.2f;

		// Token: 0x0401FF37 RID: 130871
		public const float PLAY_MOVE_DURATION = 0.2f;

		// Token: 0x0401FF38 RID: 130872
		public const float ACCUMULATE_TWEEN_TIME = 0.3f;

		// Token: 0x0401FF39 RID: 130873
		public const float DAMAGE_TWEEN_TIME = 0.4f;

		// Token: 0x0401FF3A RID: 130874
		public const float DAMAGE_COUNT_TWEEN_TIME = 0.2f;

		// Token: 0x0401FF3B RID: 130875
		public const float NPC_DISSOLVE_VALUE = 0.55f;

		// Token: 0x0401FF3C RID: 130876
		public const float NPC_DISSOLVE_TWEEN_TIME = 0.5f;

		// Token: 0x0401FF3D RID: 130877
		public const string ENTITY_COMPONENT_DISABLE_KEY = "PhantomArenaBattle";

		// Token: 0x0401FF3E RID: 130878
		public const string HIT_AUDIO = "play_ui_phantomarena_missile_shot_cardskill";

		// Token: 0x0401FF3F RID: 130879
		public const string DAMAGE_AUDIO = "play_ui_phantomarena_missile_shot_settlement";
	}
}
