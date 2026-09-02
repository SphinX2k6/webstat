using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054C7 RID: 21703
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaEntranceShopTabData : CommonTabData
	{
		// Token: 0x06037487 RID: 226439 RVA: 0x00E06B31 File Offset: 0x00E04D31
		public PhantomArenaEntranceShopTabData(string icon, [Nullable(2)] CommonTabTitleData titleData, string realTitleId, EUiTabViewName tabViewName) : base(icon, titleData, null)
		{
			this.RealTitleId = realTitleId;
			this.TabViewName = tabViewName;
		}

		// Token: 0x06037488 RID: 226440 RVA: 0x00E06B4B File Offset: 0x00E04D4B
		public string GetRealTitle()
		{
			return this.RealTitleId;
		}

		// Token: 0x06037489 RID: 226441 RVA: 0x00E06B53 File Offset: 0x00E04D53
		public EUiTabViewName GetTabViewName()
		{
			return this.TabViewName;
		}

		// Token: 0x0401FC58 RID: 130136
		private readonly string RealTitleId;

		// Token: 0x0401FC59 RID: 130137
		private readonly EUiTabViewName TabViewName;
	}
}
