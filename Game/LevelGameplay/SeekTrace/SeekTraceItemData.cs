using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SeekTrace
{
	// Token: 0x02006B0B RID: 27403
	[NullableContext(1)]
	[Nullable(0)]
	public class SeekTraceItemData
	{
		// Token: 0x04025D96 RID: 155030
		public ESeekTraceItemEffectType ItemType;

		// Token: 0x04025D97 RID: 155031
		public int[] BasePosition = new int[2];

		// Token: 0x04025D98 RID: 155032
		public readonly List<int[]> FilledPositionOffsetList = new List<int[]>();

		// Token: 0x04025D99 RID: 155033
		public readonly HashSet<int> FilledIndexSet = new HashSet<int>();

		// Token: 0x04025D9A RID: 155034
		public bool IsValid = true;
	}
}
