using System;
using System.Collections.Generic;
using Aki.Config;
using UnrealEngine;

// Token: 0x0200118E RID: 4494
public class AdvanceNoticeNewAreaTabView : AdvanceNoticeTabViewBase
{
	// Token: 0x0600763C RID: 30268 RVA: 0x001EEAA0 File Offset: 0x001ECCA0
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

	// Token: 0x0600763D RID: 30269 RVA: 0x001EEB28 File Offset: 0x001ECD28
	protected override void RefreshView()
	{
		int currentSubTabId = this.ViewModel.CurrentSubTabId;
		AdvertisingTabRegion advertisingTabRegionById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabRegionById(currentSubTabId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), advertisingTabRegionById.SubTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), advertisingTabRegionById.Title, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), advertisingTabRegionById.Description, Array.Empty<object>());
		base.SetTextureWithPath(base.GetTexture(0), advertisingTabRegionById.MainPic);
	}

	// Token: 0x020074E8 RID: 29928
	private class EComponentDefine
	{
		// Token: 0x040285B8 RID: 165304
		public const int BgTexture = 0;

		// Token: 0x040285B9 RID: 165305
		public const int SubTitleText = 1;

		// Token: 0x040285BA RID: 165306
		public const int TitleText = 2;

		// Token: 0x040285BB RID: 165307
		public const int DescText = 3;

		// Token: 0x040285BC RID: 165308
		public const int DescScrollView = 4;
	}
}
