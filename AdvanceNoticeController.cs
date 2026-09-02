using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;

// Token: 0x02001181 RID: 4481
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class AdvanceNoticeController : ActivityControllerBase<AdvanceNoticeController>
{
	// Token: 0x06007613 RID: 30227 RVA: 0x001EE370 File Offset: 0x001EC570
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06007614 RID: 30228 RVA: 0x001EE372 File Offset: 0x001EC572
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityPreviewGuide";
	}

	// Token: 0x06007615 RID: 30229 RVA: 0x001EE379 File Offset: 0x001EC579
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new AdvanceNoticeSubView();
	}

	// Token: 0x06007616 RID: 30230 RVA: 0x001EE380 File Offset: 0x001EC580
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new AdvanceNoticeData();
	}

	// Token: 0x06007617 RID: 30231 RVA: 0x001EE387 File Offset: 0x001EC587
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06007618 RID: 30232 RVA: 0x001EE38C File Offset: 0x001EC58C
	public void OpenAdvanceNoticeView(int advertisingPageInfoId, int selectedTabId)
	{
		AdvanceNoticeViewModel advanceNoticeViewModel = new AdvanceNoticeViewModel();
		advanceNoticeViewModel.DefaultSelectedTabId = selectedTabId;
		AdvertisingPageInfo advertisingPageInfoById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingPageInfoById(advertisingPageInfoId);
		advanceNoticeViewModel.TabList = advertisingPageInfoById.GetTabIdArrayArray().ToList<int>();
		advanceNoticeViewModel.ActivityId = advertisingPageInfoById.ActivityId;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.AdvanceNoticeRootView, advanceNoticeViewModel, null);
	}
}
