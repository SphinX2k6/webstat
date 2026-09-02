using System;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll
{
	// Token: 0x02006F4E RID: 28494
	public static class BigStuffedDefine
	{
		// Token: 0x06044F85 RID: 282501 RVA: 0x011F4E28 File Offset: 0x011F3028
		public static int calculateCellSize(int startIndex, int endIndex)
		{
			if (endIndex >= startIndex)
			{
				return endIndex - startIndex + 1;
			}
			return 36 - startIndex + 1 + endIndex;
		}

		// Token: 0x04026779 RID: 157561
		public const int BIGSTUFFEDDOLL_RINGCELLCOUNT = 36;

		// Token: 0x0402677A RID: 157562
		public const float SINGLECELL_ANGLE = 10f;
	}
}
