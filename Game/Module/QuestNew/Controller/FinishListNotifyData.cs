using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuestNew.Controller
{
	// Token: 0x0200530F RID: 21263
	[NullableContext(1)]
	[Nullable(0)]
	public class FinishListNotifyData
	{
		// Token: 0x17008D11 RID: 36113
		// (get) Token: 0x06036485 RID: 222341 RVA: 0x00DAF10A File Offset: 0x00DAD30A
		// (set) Token: 0x06036486 RID: 222342 RVA: 0x00DAF112 File Offset: 0x00DAD312
		public List<int> QuestIds { get; set; } = new List<int>();

		// Token: 0x17008D12 RID: 36114
		// (get) Token: 0x06036487 RID: 222343 RVA: 0x00DAF11B File Offset: 0x00DAD31B
		// (set) Token: 0x06036488 RID: 222344 RVA: 0x00DAF123 File Offset: 0x00DAD323
		public EEventName EmitEventName { get; set; }

		// Token: 0x17008D13 RID: 36115
		// (get) Token: 0x06036489 RID: 222345 RVA: 0x00DAF12C File Offset: 0x00DAD32C
		// (set) Token: 0x0603648A RID: 222346 RVA: 0x00DAF134 File Offset: 0x00DAD334
		[Nullable(2)]
		public Action TryChangeTrackedQuest { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
