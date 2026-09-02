using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006466 RID: 25702
	[NullableContext(1)]
	[Nullable(0)]
	public static class RoverlikeTalentTreeDefine
	{
		// Token: 0x0604079B RID: 264091 RVA: 0x01085585 File Offset: 0x01083785
		public static int RoverlikeLineIndex2NodeIndex(int lineIndex)
		{
			if (lineIndex >= 18)
			{
				return lineIndex - 18;
			}
			if (lineIndex >= 12)
			{
				return lineIndex - 12;
			}
			if (lineIndex >= 6)
			{
				return lineIndex - 6;
			}
			return lineIndex;
		}

		// Token: 0x04024181 RID: 147841
		public const int ROVERLIKE_MAX_TALENT_NODES_IN_ROW = 6;

		// Token: 0x04024182 RID: 147842
		public const int ROVERLIKE_TALENT_TREE_TOP_LINE_OFFSET = 0;

		// Token: 0x04024183 RID: 147843
		public const int ROVERLIKE_TALENT_TREE_MID_LINE_OFFSET = 6;

		// Token: 0x04024184 RID: 147844
		public const int ROVERLIKE_TALENT_TREE_BOTTOM_LINE_OFFSET = 12;

		// Token: 0x04024185 RID: 147845
		public const int ROVERLIKE_TALENT_TREE_LEFT_LINE_OFFSET = 18;

		// Token: 0x04024186 RID: 147846
		public const string ROVERLIKE_TALENT_NODE_PREFAB_NOR = "UiItem_RoverRougeTalentTreeNorNode";

		// Token: 0x04024187 RID: 147847
		public const string ROVERLIKE_TALENT_NODE_PREFAB_SP = "UiItem_RoverRougeTalentTreeSPNode";

		// Token: 0x04024188 RID: 147848
		public const string ROVERLIKE_TALENT_TREE_TYPE_TEXT_LEFT = "RoverRogue_TalentTree_TypeLeft";

		// Token: 0x04024189 RID: 147849
		public const string ROVERLIKE_TALENT_TREE_TYPE_TEXT_MIDDLE = "RoverRogue_TalentTree_TypeMiddle";

		// Token: 0x0402418A RID: 147850
		public const string ROVERLIKE_TALENT_TREE_TYPE_TEXT_RIGHT = "RoverRogue_TalentTree_TypeRight";

		// Token: 0x0402418B RID: 147851
		public const string ROVERLIKE_TALENT_TREE_ACTIVATE_TEXT = "RoverRogue_TalentTree_Activate";

		// Token: 0x0402418C RID: 147852
		public const string ROVERLIKE_TALENT_TREE_NEXT_TITLE_UNLOCK = "RoverRogue_TalentTreeUnlockShow";

		// Token: 0x0402418D RID: 147853
		public const string ROVERLIKE_TALENT_TREE_NEXT_TITLE_UPGRADE = "PrefabTextItem_124464148_Text";
	}
}
