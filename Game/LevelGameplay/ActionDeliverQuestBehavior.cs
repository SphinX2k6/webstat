using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Quest;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A12 RID: 27154
	public class ActionDeliverQuestBehavior : ActionParams
	{
		// Token: 0x040257DA RID: 153562
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IHandInItem> Items;

		// Token: 0x040257DB RID: 153563
		[Nullable(1)]
		public string DescText = "";

		// Token: 0x040257DC RID: 153564
		public int EntityId;

		// Token: 0x040257DD RID: 153565
		public bool? RepeatItems;
	}
}
