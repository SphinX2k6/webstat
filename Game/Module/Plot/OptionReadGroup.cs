using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005371 RID: 21361
	[NullableContext(1)]
	[Nullable(0)]
	internal class OptionReadGroup
	{
		// Token: 0x0603675D RID: 223069 RVA: 0x00DBD3F0 File Offset: 0x00DBB5F0
		public OptionReadGroup(ITalkItem talkItem, int talkItemIndex)
		{
			this.TalkItem = talkItem;
			this.TalkItemIndex = talkItemIndex;
		}

		// Token: 0x0401F57B RID: 128379
		public readonly List<int> OptionNodeIndices = new List<int>();

		// Token: 0x0401F57C RID: 128380
		public readonly ITalkItem TalkItem;

		// Token: 0x0401F57D RID: 128381
		public readonly int TalkItemIndex;
	}
}
