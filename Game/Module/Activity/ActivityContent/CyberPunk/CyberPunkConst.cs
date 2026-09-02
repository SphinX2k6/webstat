using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x02006975 RID: 26997
	[NullableContext(1)]
	[Nullable(0)]
	public static class CyberPunkConst
	{
		// Token: 0x040254FA RID: 152826
		public const string CHALLENGE_ITEM_SPRITE_PATH = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity34/Cyberpunk/Challenge";

		// Token: 0x040254FB RID: 152827
		public const string HARD_COLOR = "FF1D28FF";

		// Token: 0x040254FC RID: 152828
		public const string NORMAL_COLOR = "FFFFFFFF";

		// Token: 0x040254FD RID: 152829
		public const int STORY_FUNCTION_ID = 1;

		// Token: 0x040254FE RID: 152830
		public const int ADAMSMASHER_FUNCTION_ID = 5;

		// Token: 0x040254FF RID: 152831
		public const int COLLAB_DIRECT_TRAIN_TASK_ID = 915700000;

		// Token: 0x04025500 RID: 152832
		public const int COLLAB_DIRECT_TRAIN_ACTIVITY_ID = 103000004;

		// Token: 0x04025501 RID: 152833
		public const int COLLAB_DIRECT_PRE_TRAIN_ACTIVITY_ID = 103000099;

		// Token: 0x04025502 RID: 152834
		public const int TRIAL_ROLE_JUMPPOOL_ID = 100068;

		// Token: 0x04025503 RID: 152835
		public const int ADAM_SMASHER_ENTRANCE_ID = 6090;

		// Token: 0x04025504 RID: 152836
		[StaticVariableRuleIgnore]
		public static readonly IReadOnlyList<string> AdamSmasherSceneEffectPathList = new string[]
		{
			"/Game/Aki/Effect/EffectGroup/ML1AdamSmasherMd00001/DA_Fx_Group_Adam_ML_MengyanBuff_02.DA_Fx_Group_Adam_ML_MengyanBuff_02",
			"/Game/Aki/Effect/MaterialController/DA_Lord/ML1AdamSmasherMd00001/DA_Fx_AdamSmasher_Buff_04.DA_Fx_AdamSmasher_Buff_04"
		};
	}
}
