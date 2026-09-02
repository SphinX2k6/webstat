using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelAi
{
	// Token: 0x02006E13 RID: 28179
	public class SubNodesInfo
	{
		// Token: 0x0402612C RID: 155948
		[Nullable(1)]
		public List<LevelAiDecorator> SubDecorators = new List<LevelAiDecorator>();

		// Token: 0x0402612D RID: 155949
		public int LastFrameSubNodesTicked = -1;

		// Token: 0x0402612E RID: 155950
		public bool SubNodesExecuting;
	}
}
