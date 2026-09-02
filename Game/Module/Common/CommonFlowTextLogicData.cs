using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common
{
	// Token: 0x02005E43 RID: 24131
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonFlowTextLogicData<[Nullable(2)] T> : ICommonFlowTextLogicData<T>
	{
		// Token: 0x17009934 RID: 39220
		// (get) Token: 0x0603CB99 RID: 248729 RVA: 0x00F6BE64 File Offset: 0x00F6A064
		// (set) Token: 0x0603CB9A RID: 248730 RVA: 0x00F6BE6C File Offset: 0x00F6A06C
		public Func<ITalkItem, UUIText> GetTextComp { get; set; }

		// Token: 0x17009935 RID: 39221
		// (get) Token: 0x0603CB9B RID: 248731 RVA: 0x00F6BE75 File Offset: 0x00F6A075
		// (set) Token: 0x0603CB9C RID: 248732 RVA: 0x00F6BE7D File Offset: 0x00F6A07D
		public Action<ITalkItem, T> TextAnimStartDelegate { get; set; }

		// Token: 0x17009936 RID: 39222
		// (get) Token: 0x0603CB9D RID: 248733 RVA: 0x00F6BE86 File Offset: 0x00F6A086
		// (set) Token: 0x0603CB9E RID: 248734 RVA: 0x00F6BE8E File Offset: 0x00F6A08E
		public Action<ITalkItem, T> TextAnimFinishDelegate { get; set; }

		// Token: 0x17009937 RID: 39223
		// (get) Token: 0x0603CB9F RID: 248735 RVA: 0x00F6BE97 File Offset: 0x00F6A097
		// (set) Token: 0x0603CBA0 RID: 248736 RVA: 0x00F6BE9F File Offset: 0x00F6A09F
		public Action ClearDelegate { get; set; }
	}
}
