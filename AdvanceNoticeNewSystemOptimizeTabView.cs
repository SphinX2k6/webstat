using System;
using System.Collections.Generic;
using Aki.Config;
using UnrealEngine;

// Token: 0x02001195 RID: 4501
public class AdvanceNoticeNewSystemOptimizeTabView : AdvanceNoticeTabViewBase
{
	// Token: 0x0600765E RID: 30302 RVA: 0x001EFBB4 File Offset: 0x001EDDB4
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

	// Token: 0x0600765F RID: 30303 RVA: 0x001EFC3C File Offset: 0x001EDE3C
	protected override void RefreshView()
	{
		int currentSubTabId = this.ViewModel.CurrentSubTabId;
		AdvertisingTabSystem advertisingTabSystemById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabSystemById(currentSubTabId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), advertisingTabSystemById.SubTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), advertisingTabSystemById.Title, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), advertisingTabSystemById.Description, Array.Empty<object>());
		base.SetTextureWithPath(base.GetTexture(0), advertisingTabSystemById.MainPic);
		base.GetScrollViewWithScrollbar(4).SetScrollProgress(0f);
	}

	// Token: 0x020074F1 RID: 29937
	private class EComponentDefine
	{
		// Token: 0x04028600 RID: 165376
		public const int BgTexture = 0;

		// Token: 0x04028601 RID: 165377
		public const int SubTitleText = 1;

		// Token: 0x04028602 RID: 165378
		public const int TitleText = 2;

		// Token: 0x04028603 RID: 165379
		public const int DescText = 3;

		// Token: 0x04028604 RID: 165380
		public const int DescScrollView = 4;
	}
}
