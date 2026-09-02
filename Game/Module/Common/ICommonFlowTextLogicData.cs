using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common
{
	// Token: 0x02005E42 RID: 24130
	[NullableContext(1)]
	public interface ICommonFlowTextLogicData<[Nullable(2)] T>
	{
		// Token: 0x17009930 RID: 39216
		// (get) Token: 0x0603CB91 RID: 248721
		// (set) Token: 0x0603CB92 RID: 248722
		Func<ITalkItem, UUIText> GetTextComp { get; set; }

		// Token: 0x17009931 RID: 39217
		// (get) Token: 0x0603CB93 RID: 248723
		// (set) Token: 0x0603CB94 RID: 248724
		Action<ITalkItem, T> TextAnimStartDelegate { get; set; }

		// Token: 0x17009932 RID: 39218
		// (get) Token: 0x0603CB95 RID: 248725
		// (set) Token: 0x0603CB96 RID: 248726
		Action<ITalkItem, T> TextAnimFinishDelegate { get; set; }

		// Token: 0x17009933 RID: 39219
		// (get) Token: 0x0603CB97 RID: 248727
		// (set) Token: 0x0603CB98 RID: 248728
		Action ClearDelegate { get; set; }
	}
}
