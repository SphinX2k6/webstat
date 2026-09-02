using System;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200511E RID: 20766
	public class RogueTalentTreeDefine
	{
		// Token: 0x06035784 RID: 219012 RVA: 0x00D6BB94 File Offset: 0x00D69D94
		public static int rogueLineIndex2NodeIndex(int lineIndex)
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

		// Token: 0x0401EBE7 RID: 125927
		public const int ROGUE_MAX_TALENT_NODES_IN_ROW = 6;

		// Token: 0x0401EBE8 RID: 125928
		public const int ROGUE_TALENT_TREE_TOP_LINE_OFFSET = 0;

		// Token: 0x0401EBE9 RID: 125929
		public const int ROGUE_TALENT_TREE_MID_LINE_OFFSET = 6;

		// Token: 0x0401EBEA RID: 125930
		public const int ROGUE_TALENT_TREE_BOTTOM_LINE_OFFSET = 12;

		// Token: 0x0401EBEB RID: 125931
		public const int ROGUE_TALENT_TREE_LEFT_LINE_OFFSET = 18;
	}
}
