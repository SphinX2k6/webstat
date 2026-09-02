using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.CommonGamePlay
{
	// Token: 0x02004BD7 RID: 19415
	[NullableContext(2)]
	public interface IMapMoraleLvItemData
	{
		// Token: 0x17008707 RID: 34567
		// (get) Token: 0x06032AA9 RID: 207529
		// (set) Token: 0x06032AAA RID: 207530
		[Nullable(1)]
		string TitleId { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17008708 RID: 34568
		// (get) Token: 0x06032AAB RID: 207531
		// (set) Token: 0x06032AAC RID: 207532
		int Lv { get; set; }

		// Token: 0x17008709 RID: 34569
		// (get) Token: 0x06032AAD RID: 207533
		// (set) Token: 0x06032AAE RID: 207534
		string LvColor { get; set; }

		// Token: 0x1700870A RID: 34570
		// (get) Token: 0x06032AAF RID: 207535
		// (set) Token: 0x06032AB0 RID: 207536
		string BgColor { get; set; }
	}
}
