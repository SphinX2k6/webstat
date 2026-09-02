using System;
using System.Collections.Generic;
using Aki.Config;
using UnrealEngine;

// Token: 0x02001194 RID: 4500
public class AdvanceNoticeNewSkinTabView : AdvanceNoticeTabViewBase
{
	// Token: 0x0600765B RID: 30299 RVA: 0x001EFAAC File Offset: 0x001EDCAC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
	}

	// Token: 0x0600765C RID: 30300 RVA: 0x001EFB1C File Offset: 0x001EDD1C
	protected override void RefreshView()
	{
		int currentSubTabId = this.ViewModel.CurrentSubTabId;
		AdvertisingTabCostume advertisingTabCostumeById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabCostumeById(currentSubTabId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), advertisingTabCostumeById.SubTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), advertisingTabCostumeById.Title, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), advertisingTabCostumeById.Description, Array.Empty<object>());
		base.SetTextureWithPath(base.GetTexture(0), advertisingTabCostumeById.MainPic);
	}

	// Token: 0x020074F0 RID: 29936
	private class EComponentDefine
	{
		// Token: 0x040285FC RID: 165372
		public const int BgTexture = 0;

		// Token: 0x040285FD RID: 165373
		public const int SubTitleText = 1;

		// Token: 0x040285FE RID: 165374
		public const int TitleText = 2;

		// Token: 0x040285FF RID: 165375
		public const int DescText = 3;
	}
}
