using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005370 RID: 21360
	internal class OptionReadNode
	{
		// Token: 0x0603675C RID: 223068 RVA: 0x00DBD3CF File Offset: 0x00DBB5CF
		public OptionReadNode(int talkItemId, int optionIndex)
		{
			this.TalkItemId = talkItemId;
			this.OptionIndex = optionIndex;
		}

		// Token: 0x0401F578 RID: 128376
		[Nullable(1)]
		public readonly List<int> DependencyGroupIndices = new List<int>();

		// Token: 0x0401F579 RID: 128377
		public readonly int TalkItemId;

		// Token: 0x0401F57A RID: 128378
		public readonly int OptionIndex;
	}
}
