using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200117E RID: 4478
[NullableContext(2)]
[Nullable(0)]
public class ActivityLinkageSubView : ActivitySubViewBase
{
	// Token: 0x170009F3 RID: 2547
	// (get) Token: 0x060075DD RID: 30173 RVA: 0x001ED783 File Offset: 0x001EB983
	// (set) Token: 0x060075DE RID: 30174 RVA: 0x001ED78B File Offset: 0x001EB98B
	protected ActivityLinkageData ActivityData { get; set; }

	// Token: 0x170009F4 RID: 2548
	// (get) Token: 0x060075DF RID: 30175 RVA: 0x001ED794 File Offset: 0x001EB994
	// (set) Token: 0x060075E0 RID: 30176 RVA: 0x001ED79C File Offset: 0x001EB99C
	private ActivityButtonItem ButtonItem { get; set; }

	// Token: 0x170009F5 RID: 2549
	// (get) Token: 0x060075E1 RID: 30177 RVA: 0x001ED7A5 File Offset: 0x001EB9A5
	// (set) Token: 0x060075E2 RID: 30178 RVA: 0x001ED7AD File Offset: 0x001EB9AD
	private int TabId { get; set; }

	// Token: 0x170009F6 RID: 2550
	// (get) Token: 0x060075E3 RID: 30179 RVA: 0x001ED7B6 File Offset: 0x001EB9B6
	// (set) Token: 0x060075E4 RID: 30180 RVA: 0x001ED7BE File Offset: 0x001EB9BE
	private ActivityLinkageTabData TabData { get; set; }

	// Token: 0x170009F7 RID: 2551
	// (get) Token: 0x060075E5 RID: 30181 RVA: 0x001ED7C7 File Offset: 0x001EB9C7
	// (set) Token: 0x060075E6 RID: 30182 RVA: 0x001ED7CF File Offset: 0x001EB9CF
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170009F8 RID: 2552
	// (get) Token: 0x060075E7 RID: 30183 RVA: 0x001ED7D8 File Offset: 0x001EB9D8
	// (set) Token: 0x060075E8 RID: 30184 RVA: 0x001ED7E0 File Offset: 0x001EB9E0
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<ActivityLinkageTabItem, ActivityLinkageTabData> TabLayout { [return: Nullable(new byte[]
	{
		2,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1
	})] set; }

	// Token: 0x170009F9 RID: 2553
	// (get) Token: 0x060075E9 RID: 30185 RVA: 0x001ED7E9 File Offset: 0x001EB9E9
	// (set) Token: 0x060075EA RID: 30186 RVA: 0x001ED7F1 File Offset: 0x001EB9F1
	private ActivityLinkageUrl? UrlConfig { get; set; }

	// Token: 0x060075EB RID: 30187 RVA: 0x001ED7FA File Offset: 0x001EB9FA
	protected override void OnSetData()
	{
		this.ActivityData = (ActivityLinkageData)this.ActivityBaseData;
	}

	// Token: 0x060075EC RID: 30188 RVA: 0x001ED810 File Offset: 0x001EBA10
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UTexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UTexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIInturnAnimController));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060075ED RID: 30189 RVA: 0x001ED983 File Offset: 0x001EBB83
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
	}

	// Token: 0x060075EE RID: 30190 RVA: 0x001ED9A1 File Offset: 0x001EBBA1
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
	}

	// Token: 0x060075EF RID: 30191 RVA: 0x001ED9C0 File Offset: 0x001EBBC0
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityLinkageSubView.<OnBeforeStartAsync>d__33 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityLinkageSubView.<OnBeforeStartAsync>d__33>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060075F0 RID: 30192 RVA: 0x001EDA03 File Offset: 0x001EBC03
	[NullableContext(1)]
	private CommonItemSmallItemGrid InitGridItem()
	{
		return new CommonItemSmallItemGrid
		{
			ShowReceivedCallBack = ((TItem _) => this.ActivityData.IsReceiveReward(this.TabId))
		};
	}

	// Token: 0x060075F1 RID: 30193 RVA: 0x001EDA1C File Offset: 0x001EBC1C
	[NullableContext(1)]
	private ActivityLinkageTabItem InitActivityLinkageTabItem()
	{
		ActivityLinkageTabItem activityLinkageTabItem = new ActivityLinkageTabItem();
		activityLinkageTabItem.SetToggleCallBack(new Action<int, ActivityLinkageTabData>(this.TabItemToggleClick));
		return activityLinkageTabItem;
	}

	// Token: 0x060075F2 RID: 30194 RVA: 0x001EDA35 File Offset: 0x001EBC35
	protected override void OnBeforeShow()
	{
		UUIInturnAnimController uiInturnAnimController = base.GetUiInturnAnimController(9);
		if (uiInturnAnimController == null)
		{
			return;
		}
		uiInturnAnimController.Play("", -1, false);
	}

	// Token: 0x060075F3 RID: 30195 RVA: 0x001EDA50 File Offset: 0x001EBC50
	[NullableContext(1)]
	public void TabItemToggleClick(int gridIndex, ActivityLinkageTabData tabData)
	{
		this.PlaySubViewSequence("Switch", false);
		this.TabLayout.SelectGridProxy(gridIndex, false);
		this.RefreshUi(tabData);
		LinkageSwitchModuleEvent linkageSwitchModuleEvent = new LinkageSwitchModuleEvent();
		linkageSwitchModuleEvent.i_activity_id = this.ActivityData.Id;
		linkageSwitchModuleEvent.i_activity_type = (int)this.ActivityData.Type;
		linkageSwitchModuleEvent.i_id = tabData.TabId;
		linkageSwitchModuleEvent.i_if_finish = ((tabData.IsReceive > false) ? 1 : 0);
		ControllerBase<LogReportController>.Instance.LogReport(linkageSwitchModuleEvent);
	}

	// Token: 0x060075F4 RID: 30196 RVA: 0x001EDACC File Offset: 0x001EBCCC
	[NullableContext(1)]
	private void RefreshUi(ActivityLinkageTabData tabData)
	{
		this.TabData = tabData;
		this.TabId = tabData.TabId;
		ActivityLinkage? config = ConfigActivityLinkageById.GetConfig(this.TabId, true);
		if (config == null)
		{
			return;
		}
		base.SetTextureByPath(config.Value.BgImage, base.GetTexture(0), null, null);
		this.RefreshTimerText();
		List<TItem> list = new List<TItem>();
		for (int i = 0; i < config.Value.RewardLength; i++)
		{
			list.Add(new TItem(new InventoryDefine.GetItemData(config.Value.Reward(i).Value.Key, 0), config.Value.Reward(i).Value.Value));
		}
		GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
		if (rewardLayout != null)
		{
			rewardLayout.RefreshByData(list, null, false);
		}
		this.RefreshButtonRedDot();
		int languageType = Singleton<LanguageSystem>.Instance.GetLanguageDefineByCode(Singleton<LanguageSystem>.Instance.PackageLanguage).LanguageType;
		ActivityLinkageInfo? config2 = ConfigActivityLinkageInfoByIdAndLanguage.GetConfig(this.TabId, languageType, true);
		if (config2 == null)
		{
			return;
		}
		base.SetTextureByPath(config2.Value.BigImage, base.GetTexture(1), null, null);
		bool p1IsNational = !ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk();
		this.UrlConfig = ConfigActivityLinkageUrlByIdAndIsNational.GetConfig(this.TabId, p1IsNational, true);
	}

	// Token: 0x060075F5 RID: 30197 RVA: 0x001EDC48 File Offset: 0x001EBE48
	private void RefreshTimerText()
	{
		bool show = ConfigActivityLinkageById.GetConfig(this.TabId, true).Value.Show;
		UUIText text = base.GetText(4);
		text.SetUIActive(show);
		if (show)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
			string newText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.TabData.EndTimeStamp / 1000L, localTextNew) ?? "";
			text.SetText(newText, true);
		}
	}

	// Token: 0x060075F6 RID: 30198 RVA: 0x001EDCC3 File Offset: 0x001EBEC3
	private void OnRefreshRedDot(int id)
	{
		if (id != this.ActivityData.Id)
		{
			return;
		}
		this.RewardLayout.RefreshWithoutDataSync();
		this.RefreshButtonRedDot();
	}

	// Token: 0x060075F7 RID: 30199 RVA: 0x001EDCE8 File Offset: 0x001EBEE8
	private void RefreshButtonRedDot()
	{
		bool redDotVisible = !this.ActivityData.IsReceiveReward(this.TabId);
		ActivityButtonItem buttonItem = this.ButtonItem;
		if (buttonItem == null)
		{
			return;
		}
		buttonItem.SetRedDotVisible(redDotVisible);
	}

	// Token: 0x060075F8 RID: 30200 RVA: 0x001EDD1C File Offset: 0x001EBF1C
	protected override void OnTimer(float gap)
	{
		if (this.ActivityData.IsNeedShowTabsChange())
		{
			List<ActivityLinkageTabData> tabInfoList = this.ActivityData.GetTabInfoList();
			this.TabLayout.RefreshByData(tabInfoList, null, false);
			this.TabLayout.SelectGridProxy(0, false);
			this.RefreshUi(tabInfoList[0]);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityData.Id);
		}
		this.RefreshTimerText();
	}

	// Token: 0x060075F9 RID: 30201 RVA: 0x001EDD8C File Offset: 0x001EBF8C
	private unsafe void OnClickGotoBtn()
	{
		if (string.IsNullOrEmpty(this.UrlConfig.Value.LinkUrl))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "联动页链接为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tabId", this.TabId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		string str = Singleton<PublicUtil>.Instance.OverridePackageId ?? ControllerBase<KuroSdkController>.Instance.GetPackageId();
		string text = this.UrlConfig.Value.LinkUrl + "?packageId=" + str;
		if (this.UrlConfig.Value.IsNeedToken)
		{
			text = text + "&" + Singleton<PublicUtil>.Instance.GetPublicInfo();
		}
		bool isNational = this.UrlConfig.Value.IsNational;
		if (!isNational)
		{
			text = text + "&language=" + Singleton<LanguageSystem>.Instance.PackageLanguage;
		}
		text = Singleton<PublicUtil>.Instance.GetExtendExternalUrl(text, this.UrlConfig.Value.IsInternalLink);
		string platformStr = ModelBase<KuroSdkModel>.Instance.GetPlatformStr();
		text = text + "&platform=" + platformStr;
		if (this.UrlConfig.Value.IsInternalLink)
		{
			ControllerBase<KuroSdkController>.Instance.SdkOpenUrlWnd("", text, true, true, true);
		}
		else
		{
			ControllerBase<KuroSdkController>.Instance.OpenExternalUrl(text);
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Activity;
		ELogAuthor author2 = ELogAuthor.CXJ;
		string message2 = "联动页打开链接";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("url", text);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("是否为国内包体", isNational);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		LinkageClickGoEvent linkageClickGoEvent = new LinkageClickGoEvent();
		linkageClickGoEvent.i_activity_id = this.ActivityData.Id;
		linkageClickGoEvent.i_activity_type = (int)this.ActivityData.Type;
		linkageClickGoEvent.i_id = this.TabId;
		ControllerBase<LogReportController>.Instance.LogReport(linkageClickGoEvent);
		ActivityLinkageData activityData = this.ActivityData;
		if (activityData == null || !activityData.IsReceiveReward(this.TabId))
		{
			ControllerBase<ActivityLinkageController>.Instance.RequestReward(this.TabId);
		}
	}

	// Token: 0x020074E1 RID: 29921
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028594 RID: 165268
		public const int TextureBg = 0;

		// Token: 0x04028595 RID: 165269
		public const int TextureImage = 1;

		// Token: 0x04028596 RID: 165270
		public const int TextStartDate = 2;

		// Token: 0x04028597 RID: 165271
		public const int TextEndDate = 3;

		// Token: 0x04028598 RID: 165272
		public const int TextLeftTime = 4;

		// Token: 0x04028599 RID: 165273
		public const int LayoutTabList = 5;

		// Token: 0x0402859A RID: 165274
		public const int ButtonGoto = 6;

		// Token: 0x0402859B RID: 165275
		public const int LayoutReward = 7;

		// Token: 0x0402859C RID: 165276
		public const int TextTitle = 8;

		// Token: 0x0402859D RID: 165277
		public const int ListAnimController = 9;
	}
}
