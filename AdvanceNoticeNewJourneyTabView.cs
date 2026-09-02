using System;
using System.Collections.Generic;
using Aki.Config;
using UnrealEngine;

// Token: 0x02001191 RID: 4497
public class AdvanceNoticeNewJourneyTabView : AdvanceNoticeTabViewBase
{
	// Token: 0x0600764B RID: 30283 RVA: 0x001EF380 File Offset: 0x001ED580
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

	// Token: 0x0600764C RID: 30284 RVA: 0x001EF408 File Offset: 0x001ED608
	protected override void RefreshView()
	{
		int currentSubTabId = this.ViewModel.CurrentSubTabId;
		AdvertisingTabStory advertisingTabStoryById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabStoryById(currentSubTabId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), advertisingTabStoryById.SubTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), advertisingTabStoryById.Title, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), advertisingTabStoryById.Description, Array.Empty<object>());
		base.SetTextureWithPath(base.GetTexture(0), advertisingTabStoryById.MainPic);
		base.GetScrollViewWithScrollbar(4).SetScrollProgress(0f);
	}

	// Token: 0x020074EB RID: 29931
	private class EComponentDefine
	{
		// Token: 0x040285D6 RID: 165334
		public const int BgTexture = 0;

		// Token: 0x040285D7 RID: 165335
		public const int SubTitleText = 1;

		// Token: 0x040285D8 RID: 165336
		public const int TitleText = 2;

		// Token: 0x040285D9 RID: 165337
		public const int DescText = 3;

		// Token: 0x040285DA RID: 165338
		public const int DescScrollView = 4;
	}
}
