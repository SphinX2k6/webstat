using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005360 RID: 21344
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotReviewTalkItemData
	{
		// Token: 0x17008D77 RID: 36215
		// (get) Token: 0x06036717 RID: 222999 RVA: 0x00DBBB01 File Offset: 0x00DB9D01
		// (set) Token: 0x06036718 RID: 223000 RVA: 0x00DBBB09 File Offset: 0x00DB9D09
		public ITalkItem TalkItem { get; set; } = new ITalkItem();

		// Token: 0x17008D78 RID: 36216
		// (get) Token: 0x06036719 RID: 223001 RVA: 0x00DBBB12 File Offset: 0x00DB9D12
		// (set) Token: 0x0603671A RID: 223002 RVA: 0x00DBBB1A File Offset: 0x00DB9D1A
		public bool IsPlaying { get; set; }
	}
}
