using System;
using System.Collections.Generic;
using Aki.Config;
using UnrealEngine;

// Token: 0x0200118D RID: 4493
public class AdvanceNoticeNewActivityTabView : AdvanceNoticeTabViewBase
{
	// Token: 0x06007639 RID: 30265 RVA: 0x001EE96C File Offset: 0x001ECB6C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent))
		};
	}

	// Token: 0x0600763A RID: 30266 RVA: 0x001EE9F4 File Offset: 0x001ECBF4
	protected override void RefreshView()
	{
		int currentSubTabId = this.ViewModel.CurrentSubTabId;
		AdvertisingTabActivity advertisingTabActivityById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabActivityById(currentSubTabId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), advertisingTabActivityById.SubTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), advertisingTabActivityById.Title, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), advertisingTabActivityById.Description, Array.Empty<object>());
		base.SetTextureWithPath(base.GetTexture(0), advertisingTabActivityById.MainPic);
		base.GetScrollViewWithScrollbar(4).SetScrollProgress(0f);
	}

	// Token: 0x020074E7 RID: 29927
	private class EComponentDefine
	{
		// Token: 0x040285B3 RID: 165299
		public const int BgTexture = 0;

		// Token: 0x040285B4 RID: 165300
		public const int SubTitleText = 1;

		// Token: 0x040285B5 RID: 165301
		public const int TitleText = 2;

		// Token: 0x040285B6 RID: 165302
		public const int DescText = 3;

		// Token: 0x040285B7 RID: 165303
		public const int DescScrollView = 4;
	}
}
