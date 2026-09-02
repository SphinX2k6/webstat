using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B3C RID: 19260
	[NullableContext(2)]
	public interface IMapSubViewListItemData
	{
		// Token: 0x17008621 RID: 34337
		// (get) Token: 0x060323D7 RID: 205783
		// (set) Token: 0x060323D8 RID: 205784
		[Nullable(1)]
		string LeftTextId { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17008622 RID: 34338
		// (get) Token: 0x060323D9 RID: 205785
		// (set) Token: 0x060323DA RID: 205786
		string LeftText { get; set; }

		// Token: 0x17008623 RID: 34339
		// (get) Token: 0x060323DB RID: 205787
		// (set) Token: 0x060323DC RID: 205788
		string RightTextId { get; set; }

		// Token: 0x17008624 RID: 34340
		// (get) Token: 0x060323DD RID: 205789
		// (set) Token: 0x060323DE RID: 205790
		string RightText { get; set; }

		// Token: 0x17008625 RID: 34341
		// (get) Token: 0x060323DF RID: 205791
		// (set) Token: 0x060323E0 RID: 205792
		bool ShowBtnHelp { get; set; }

		// Token: 0x17008626 RID: 34342
		// (get) Token: 0x060323E1 RID: 205793
		// (set) Token: 0x060323E2 RID: 205794
		Action OnBtnClickCb { get; set; }

		// Token: 0x17008627 RID: 34343
		// (get) Token: 0x060323E3 RID: 205795
		// (set) Token: 0x060323E4 RID: 205796
		bool ShowIcon { get; set; }

		// Token: 0x17008628 RID: 34344
		// (get) Token: 0x060323E5 RID: 205797
		// (set) Token: 0x060323E6 RID: 205798
		bool ShowSprite { get; set; }

		// Token: 0x17008629 RID: 34345
		// (get) Token: 0x060323E7 RID: 205799
		// (set) Token: 0x060323E8 RID: 205800
		bool ShowScaleIcon { get; set; }

		// Token: 0x1700862A RID: 34346
		// (get) Token: 0x060323E9 RID: 205801
		// (set) Token: 0x060323EA RID: 205802
		string ScaleIconPath { get; set; }
	}
}
