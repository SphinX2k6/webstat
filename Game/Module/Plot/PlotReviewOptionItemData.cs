using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005361 RID: 21345
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotReviewOptionItemData
	{
		// Token: 0x17008D79 RID: 36217
		// (get) Token: 0x0603671C RID: 223004 RVA: 0x00DBBB36 File Offset: 0x00DB9D36
		// (set) Token: 0x0603671D RID: 223005 RVA: 0x00DBBB3E File Offset: 0x00DB9D3E
		public ITalkItem TalkItem { get; set; } = new ITalkItem();

		// Token: 0x17008D7A RID: 36218
		// (get) Token: 0x0603671E RID: 223006 RVA: 0x00DBBB47 File Offset: 0x00DB9D47
		// (set) Token: 0x0603671F RID: 223007 RVA: 0x00DBBB4F File Offset: 0x00DB9D4F
		public int OptionIndex { get; set; }
	}
}
