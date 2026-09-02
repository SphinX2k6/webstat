using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CE8 RID: 7400
[NullableContext(1)]
[Nullable(0)]
public class GachaMainView : UiTickViewBase
{
	// Token: 0x0600D907 RID: 55559 RVA: 0x003A2313 File Offset: 0x003A0513
	public GachaMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600D908 RID: 55560 RVA: 0x003A234C File Offset: 0x003A054C
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	private UniTask<GachaPoolItem> GetActorByPoolType(UUIItem parent, GachaDefine.EGachaViewType type)
	{
		GachaMainView.<GetActorByPoolType>d__4 <GetActorByPoolType>d__;
		<GetActorByPoolType>d__.<>t__builder = AsyncUniTaskMethodBuilder<GachaPoolItem>.Create();
		<GetActorByPoolType>d__.parent = parent;
		<GetActorByPoolType>d__.type = type;
		<GetActorByPoolType>d__.<>1__state = -1;
		<GetActorByPoolType>d__.<>t__builder.Start<GachaMainView.<GetActorByPoolType>d__4>(ref <GetActorByPoolType>d__);
		return <GetActorByPoolType>d__.<>t__builder.Task;
	}

	// Token: 0x0600D909 RID: 55561 RVA: 0x003A2398 File Offset: 0x003A0598
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	private UniTask<GachaPoolItem> GetSpineActorByResourceId(UUIItem parent, string resourceId, GachaDefine.EGachaViewType type)
	{
		GachaMainView.<GetSpineActorByResourceId>d__5 <GetSpineActorByResourceId>d__;
		<GetSpineActorByResourceId>d__.<>t__builder = AsyncUniTaskMethodBuilder<GachaPoolItem>.Create();
		<GetSpineActorByResourceId>d__.parent = parent;
		<GetSpineActorByResourceId>d__.resourceId = resourceId;
		<GetSpineActorByResourceId>d__.type = type;
		<GetSpineActorByResourceId>d__.<>1__state = -1;
		<GetSpineActorByResourceId>d__.<>t__builder.Start<GachaMainView.<GetSpineActorByResourceId>d__5>(ref <GetSpineActorByResourceId>d__);
		return <GetSpineActorByResourceId>d__.<>t__builder.Task;
	}

	// Token: 0x17001148 RID: 4424
	// (get) Token: 0x0600D90A RID: 55562 RVA: 0x003A23EB File Offset: 0x003A05EB
	private new int? OpenParam
	{
		get
		{
			return this.OpenParam as int?;
		}
	}

	// Token: 0x17001149 RID: 4425
	// (get) Token: 0x0600D90B RID: 55563 RVA: 0x003A23FD File Offset: 0x003A05FD
	private ProtoGachaInfo CurGachaInfo
	{
		get
		{
			return this.CurGachaPoolData.GachaInfo;
		}
	}

	// Token: 0x1700114A RID: 4426
	// (get) Token: 0x0600D90C RID: 55564 RVA: 0x003A240A File Offset: 0x003A060A
	private int CurShowPoolId
	{
		get
		{
			return this.CurGachaPoolData.PoolInfo.Id;
		}
	}

	// Token: 0x1700114B RID: 4427
	// (get) Token: 0x0600D90D RID: 55565 RVA: 0x003A241C File Offset: 0x003A061C
	private ProtoGachaPoolInfo CurShowPoolInfo
	{
		get
		{
			return this.CurGachaPoolData.PoolInfo;
		}
	}

	// Token: 0x1700114C RID: 4428
	// (get) Token: 0x0600D90E RID: 55566 RVA: 0x003A242C File Offset: 0x003A062C
	[Nullable(2)]
	private GachaPoolData CurGachaPoolData
	{
		[NullableContext(2)]
		get
		{
			int selectedGridIndex = this.GachaTagScrollView.GetGenericLayout().GetSelectedGridIndex();
			if (this.TagDataList == null || selectedGridIndex < 0 || selectedGridIndex >= this.TagDataList.Length)
			{
				return null;
			}
			return this.TagDataList[selectedGridIndex];
		}
	}

	// Token: 0x1700114D RID: 4429
	// (get) Token: 0x0600D90F RID: 55567 RVA: 0x003A246B File Offset: 0x003A066B
	private bool IsLock
	{
		get
		{
			return this.Operating;
		}
	}

	// Token: 0x0600D910 RID: 55568 RVA: 0x003A2473 File Offset: 0x003A0673
	private void Lock()
	{
		this.Operating = true;
	}

	// Token: 0x0600D911 RID: 55569 RVA: 0x003A247C File Offset: 0x003A067C
	private void Unlock()
	{
		this.Operating = false;
		if (this.GachaOperationQueue.Size == 0)
		{
			return;
		}
		GachaMainView.OperationParam operationParam = this.GachaOperationQueue.Pop();
		if (operationParam == null)
		{
			return;
		}
		switch (operationParam.OperationType)
		{
		case GachaMainView.EOperationType.RefreshGachaTag:
			this.RefreshGachaTag();
			return;
		case GachaMainView.EOperationType.RefreshGachaInfo:
			this.RefreshGachaInfo();
			return;
		case GachaMainView.EOperationType.SelectGachaTagByIndex:
			this.SelectGachaTagByIndex((int)((operationParam != null) ? operationParam.Param : null));
			return;
		default:
			return;
		}
	}

	// Token: 0x0600D912 RID: 55570 RVA: 0x003A24F0 File Offset: 0x003A06F0
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.ItemExChangeResponse, new Action<int, int>(this.OnItemExChangeResponse));
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshGachaMainView, new Action(this.RefreshGachaMainView));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.GachaPoolSelectResponse, new Action<int, int>(this.OnGachaPoolSelectResponse));
		Singleton<EventSystem>.Instance.Add(EEventName.CrossDay, new Action(this.OnCrossDay));
		Singleton<EventSystem>.Instance.Add(EEventName.GachaNewNotify, new Action(this.OnCrossDay));
		Singleton<EventSystem>.Instance.Add<string>(EEventName.PlaySequenceEventByStringParam, new Action<string>(this.OnPlaySequenceEventByStringParam));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.GachaAccumulateRewardClaimed, new Action<int>(this.OnGachaAccumulateRewardClaimed));
	}

	// Token: 0x0600D913 RID: 55571 RVA: 0x003A25C4 File Offset: 0x003A07C4
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ItemExChangeResponse, new Action<int, int>(this.OnItemExChangeResponse));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshGachaMainView, new Action(this.RefreshGachaMainView));
		Singleton<EventSystem>.Instance.Remove(EEventName.GachaPoolSelectResponse, new Action<int, int>(this.OnGachaPoolSelectResponse));
		Singleton<EventSystem>.Instance.Remove(EEventName.CrossDay, new Action(this.OnCrossDay));
		Singleton<EventSystem>.Instance.Remove(EEventName.GachaNewNotify, new Action(this.OnCrossDay));
		Singleton<EventSystem>.Instance.Remove(EEventName.PlaySequenceEventByStringParam, new Action<string>(this.OnPlaySequenceEventByStringParam));
		Singleton<EventSystem>.Instance.Remove(EEventName.GachaAccumulateRewardClaimed, new Action<int>(this.OnGachaAccumulateRewardClaimed));
	}

	// Token: 0x0600D914 RID: 55572 RVA: 0x003A2698 File Offset: 0x003A0898
	protected unsafe override void OnRegisterComponent()
	{
		int num = 35;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIInturnAnimController));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(34, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 5;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnHelpBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnShopBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnRecordBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnPreviewBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(18, new Action(this.OnChangeBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D915 RID: 55573 RVA: 0x003A2C27 File Offset: 0x003A0E27
	protected override void OnStart()
	{
		this.CountDownTimerHandle = TimerSystem.Instance.Forever(new TTimerAction(this.OnCountDown), 1000f, 1f, null, null, true);
		UUIItem item = base.GetItem(33);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600D916 RID: 55574 RVA: 0x003A2C68 File Offset: 0x003A0E68
	private void OnCountDown(float delta)
	{
		ProtoGachaInfo curGachaInfo = this.CurGachaInfo;
		if (curGachaInfo == null)
		{
			return;
		}
		double poolEndTimeByPoolInfo = curGachaInfo.GetPoolEndTimeByPoolInfo(this.CurShowPoolInfo);
		if (poolEndTimeByPoolInfo == 0.0)
		{
			return;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double remainTime = poolEndTimeByPoolInfo - serverTime;
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat9(remainTime);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), "Text_GachaRemainingTime_Text", new <>z__ReadOnlySingleElementList<object>(remainTimeDataFormat.CountDownText));
	}

	// Token: 0x0600D917 RID: 55575 RVA: 0x003A2CD9 File Offset: 0x003A0ED9
	private void OnPlaySequenceEventByStringParam(string name)
	{
		if (name != "ListAni")
		{
			return;
		}
		base.GetUiInturnAnimController(30).Play("", -1, false);
	}

	// Token: 0x0600D918 RID: 55576 RVA: 0x003A2D00 File Offset: 0x003A0F00
	private void OnCrossDay()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.GachaRefresh);
		confirmBoxDataNew.FunctionMap.Add(0, delegate
		{
			ControllerBase<GachaController>.Instance.GachaInfoRequest(false, false);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600D919 RID: 55577 RVA: 0x003A2D4C File Offset: 0x003A0F4C
	private void OnHelpBtnClick()
	{
		if (this.CurGachaInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Gacha, ELogAuthor.LPH, "OnHelpBtnClick CurGachaInfo is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.CurGachaInfo.UsePoolId == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SelfGacha_NoDetail_Tips", Array.Empty<object>());
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaPoolDetailView, this.CurGachaInfo.GetPoolInfo(this.CurGachaInfo.UsePoolId), null);
		OnClickGachaOperationLogEvent onClickGachaOperationLogEvent = new OnClickGachaOperationLogEvent();
		onClickGachaOperationLogEvent.i_gacha_id = this.CurGachaInfo.Id;
		onClickGachaOperationLogEvent.i_operation_type = 3;
		ControllerBase<LogReportController>.Instance.LogReport(onClickGachaOperationLogEvent);
	}

	// Token: 0x0600D91A RID: 55578 RVA: 0x003A2DF4 File Offset: 0x003A0FF4
	private void OnShopBtnClick()
	{
		int gachaJumpShopTabId = ConfigBase<CommonConfig>.Instance.GetGachaJumpShopTabId();
		ControllerBase<PayShopController>.Instance.OpenPayShopViewWithTab(PayShopDefine.EPayShopTabType.ExchangeEntry, gachaJumpShopTabId);
		OnClickGachaOperationLogEvent onClickGachaOperationLogEvent = new OnClickGachaOperationLogEvent();
		onClickGachaOperationLogEvent.i_gacha_id = this.CurGachaInfo.Id;
		onClickGachaOperationLogEvent.i_operation_type = 1;
		ControllerBase<LogReportController>.Instance.LogReport(onClickGachaOperationLogEvent);
	}

	// Token: 0x0600D91B RID: 55579 RVA: 0x003A2E44 File Offset: 0x003A1044
	private void OnRecordBtnClick()
	{
		GachaRecordClickLogEvent logData = new GachaRecordClickLogEvent();
		ControllerBase<LogReportController>.Instance.LogReport(logData);
		ProtoGachaInfo curGachaInfo = this.CurGachaInfo;
		if (curGachaInfo == null)
		{
			return;
		}
		int groupId = this.CurGachaInfo.GroupId;
		string gachaRecordUrlPrefix = ModelBase<GachaModel>.Instance.GetGachaRecordUrlPrefix();
		string serverArea = ModelBase<GachaModel>.Instance.GetServerArea();
		string platformStr = ModelBase<KuroSdkModel>.Instance.GetPlatformStr();
		string[] array = new string[6];
		array[0] = "{0}/aki/gacha/index.html#/record?";
		int num = 1;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(70, 6);
		defaultInterpolatedStringHandler.AppendLiteral("svr_id={1}&player_id=");
		int? num2 = ModelBase<PlayerInfoModel>.Instance.GetId();
		defaultInterpolatedStringHandler.AppendFormatted((num2 != null) ? num2.GetValueOrDefault().ToString() : null);
		defaultInterpolatedStringHandler.AppendLiteral("&lang=");
		defaultInterpolatedStringHandler.AppendFormatted(Singleton<LanguageSystem>.Instance.PackageLanguage);
		defaultInterpolatedStringHandler.AppendLiteral("&gacha_id=");
		ProtoGachaInfo curGachaInfo2 = this.CurGachaInfo;
		int? value;
		if (curGachaInfo2 == null)
		{
			num2 = null;
			value = num2;
		}
		else
		{
			value = new int?(curGachaInfo2.Id);
		}
		defaultInterpolatedStringHandler.AppendFormatted<int?>(value);
		defaultInterpolatedStringHandler.AppendLiteral("&gacha_type=");
		defaultInterpolatedStringHandler.AppendFormatted(groupId.ToString());
		defaultInterpolatedStringHandler.AppendLiteral("&svr_area=");
		defaultInterpolatedStringHandler.AppendFormatted(serverArea);
		defaultInterpolatedStringHandler.AppendLiteral("&record_id=");
		defaultInterpolatedStringHandler.AppendFormatted(ModelBase<GachaModel>.Instance.RecordId);
		array[num] = defaultInterpolatedStringHandler.ToStringAndClear();
		array[2] = "&resources_id=";
		int num3 = 3;
		ProtoGachaInfo curGachaInfo3 = this.CurGachaInfo;
		array[num3] = ((curGachaInfo3 != null) ? curGachaInfo3.ResourcesId : null);
		array[4] = "&platform=";
		array[5] = platformStr;
		string urlPattern = string.Concat(array);
		string url = Singleton<CdnServerDebugConfig>.Instance.TryGetGachaRecordDebugUrl(urlPattern, gachaRecordUrlPrefix, ModelBase<LoginModel>.Instance.GetServerId());
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			ControllerBase<KuroSdkController>.Instance.OpenWebView("", url, true, true, true, "Default");
		}
		else
		{
			ModelBase<MailModel>.Instance.OpenWebBrowser(url);
		}
		OnClickGachaOperationLogEvent onClickGachaOperationLogEvent = new OnClickGachaOperationLogEvent();
		onClickGachaOperationLogEvent.i_gacha_id = curGachaInfo.Id;
		onClickGachaOperationLogEvent.i_operation_type = 4;
		ControllerBase<LogReportController>.Instance.LogReport(onClickGachaOperationLogEvent);
	}

	// Token: 0x0600D91C RID: 55580 RVA: 0x003A303A File Offset: 0x003A123A
	private void OnBackBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600D91D RID: 55581 RVA: 0x003A3044 File Offset: 0x003A1244
	private void OnPreviewBtnClick()
	{
		GachaViewInfo? gachaViewInfo = ConfigBase<GachaConfig>.Instance.GetGachaViewInfo(this.CurShowPoolId);
		if (gachaViewInfo == null)
		{
			return;
		}
		int type = gachaViewInfo.Value.Type;
		int[] previewIdList = this.CurShowPoolInfo.PreviewIdList;
		if (ConfigBase<GachaConfig>.Instance.GetGachaRolePreviewTypeList().Contains(type))
		{
			List<int> list = new List<int>();
			foreach (int itemId in previewIdList)
			{
				list.Add(ConfigBase<GachaConfig>.Instance.GetGachaTextureInfo(itemId).Value.TrialId);
			}
			ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, 0, list, null, null);
		}
		else if (ConfigBase<GachaConfig>.Instance.GetGachaWeaponPreviewTypeList().Contains(type))
		{
			List<WeaponTrialData> list2 = new List<WeaponTrialData>();
			foreach (int itemId2 in previewIdList)
			{
				GachaTextureInfo? gachaTextureInfo = ConfigBase<GachaConfig>.Instance.GetGachaTextureInfo(itemId2);
				WeaponTrialData weaponTrialData = new WeaponTrialData();
				weaponTrialData.SetTrialId(gachaTextureInfo.Value.TrialId, true);
				list2.Add(weaponTrialData);
			}
			WeaponPreviewViewParam weaponPreviewViewParam = new WeaponPreviewViewParam();
			WeaponDataBase[] weaponDataList = list2.ToArray();
			weaponPreviewViewParam.WeaponDataList = weaponDataList;
			weaponPreviewViewParam.SelectedIndex = 0;
			WeaponPreviewViewParam param = weaponPreviewViewParam;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponPreviewView, param, null);
		}
		OnClickGachaOperationLogEvent onClickGachaOperationLogEvent = new OnClickGachaOperationLogEvent();
		onClickGachaOperationLogEvent.i_gacha_id = this.CurGachaInfo.Id;
		onClickGachaOperationLogEvent.i_operation_type = 2;
		ControllerBase<LogReportController>.Instance.LogReport(onClickGachaOperationLogEvent);
	}

	// Token: 0x0600D91E RID: 55582 RVA: 0x003A31CB File Offset: 0x003A13CB
	private void OnClickSelectPoolButton(int _)
	{
		this.OnChangeBtnClick();
	}

	// Token: 0x0600D91F RID: 55583 RVA: 0x003A31D4 File Offset: 0x003A13D4
	private void OnChangeBtnClick()
	{
		ProtoGachaInfo curGachaInfo = this.CurGachaInfo;
		if (curGachaInfo != null)
		{
			ControllerBase<GachaController>.Instance.OpenGachaSelectionView(curGachaInfo);
			this.AfterOpenCommonWeaponSelectView();
		}
	}

	// Token: 0x0600D920 RID: 55584 RVA: 0x003A31FC File Offset: 0x003A13FC
	protected override UniTask OnBeforeStartAsync()
	{
		GachaMainView.<OnBeforeStartAsync>d__55 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GachaMainView.<OnBeforeStartAsync>d__55>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D921 RID: 55585 RVA: 0x003A3240 File Offset: 0x003A1440
	protected override void OnBeforeShow()
	{
		if (!this.IsViewFirstShow)
		{
			ControllerBase<GachaController>.Instance.GachaInfoRequest(false, false);
		}
		this.IsViewFirstShow = false;
		GachaModel instance = ModelBase<GachaModel>.Instance;
		if (instance != null && instance.IsCacheShowNewNotify)
		{
			ModelBase<GachaModel>.Instance.IsCacheShowNewNotify = false;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.GachaRefresh);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
		GachaPoolItem curPoolItem = this.CurPoolItem;
		if (curPoolItem == null)
		{
			return;
		}
		curPoolItem.PlayStartSeq();
	}

	// Token: 0x0600D922 RID: 55586 RVA: 0x003A32AA File Offset: 0x003A14AA
	protected override void OnTick(float delta)
	{
		if (Singleton<Time>.Instance.ServerTimeStamp - this.LastRefreshTime >= 300000.0)
		{
			this.LastRefreshTime = Singleton<Time>.Instance.ServerTimeStamp;
			ControllerBase<GachaController>.Instance.GachaInfoRequest(false, false);
		}
	}

	// Token: 0x0600D923 RID: 55587 RVA: 0x003A32E4 File Offset: 0x003A14E4
	public void RefreshLeftTime()
	{
		ProtoGachaInfo curGachaInfo = this.CurGachaInfo;
		if (curGachaInfo == null)
		{
			return;
		}
		double poolEndTimeByPoolInfo = curGachaInfo.GetPoolEndTimeByPoolInfo(this.CurShowPoolInfo);
		if (poolEndTimeByPoolInfo == 0.0)
		{
			return;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double num = poolEndTimeByPoolInfo - serverTime;
		if (num <= 0.0)
		{
			ControllerBase<GachaController>.Instance.GachaInfoRequest(false, false);
			return;
		}
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat9(num);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), "Text_GachaRemainingTime_Text", new <>z__ReadOnlySingleElementList<object>(remainTimeDataFormat.CountDownText));
		double remainingTime = remainTimeDataFormat.RemainingTime;
		if (remainingTime > 0.0)
		{
			double num2 = remainingTime;
			this.TimerHandle = TimerSystem.RealTimeInstance.Delay(delegate(float _)
			{
				this.RefreshLeftTime();
			}, (float)(num2 * 1000.0), null, "GachaMainView.RefreshLeftTime", false, 1f);
		}
	}

	// Token: 0x0600D924 RID: 55588 RVA: 0x003A33BD File Offset: 0x003A15BD
	private void RefreshGachaMainView()
	{
		this.RefreshGachaTag();
		this.RefreshGachaBtn();
	}

	// Token: 0x0600D925 RID: 55589 RVA: 0x003A33CB File Offset: 0x003A15CB
	private void OnItemExChangeResponse(int i, int i1)
	{
		this.RefreshGachaInfo();
	}

	// Token: 0x0600D926 RID: 55590 RVA: 0x003A33D4 File Offset: 0x003A15D4
	private void RefreshGachaInfo()
	{
		if (this.IsLock)
		{
			GachaMainView.OperationParam element = new GachaMainView.OperationParam(GachaMainView.EOperationType.RefreshGachaInfo, null);
			this.GachaOperationQueue.Push(element);
			return;
		}
		this.Lock();
		this.RefreshGachaInfoAsync(false).ContinueWith(new Action(this.Unlock)).Forget();
	}

	// Token: 0x0600D927 RID: 55591 RVA: 0x003A3424 File Offset: 0x003A1624
	private UniTask RefreshGachaInfoAsync(bool gachaAccumulateAnimate = true)
	{
		GachaMainView.<RefreshGachaInfoAsync>d__62 <RefreshGachaInfoAsync>d__;
		<RefreshGachaInfoAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshGachaInfoAsync>d__.<>4__this = this;
		<RefreshGachaInfoAsync>d__.gachaAccumulateAnimate = gachaAccumulateAnimate;
		<RefreshGachaInfoAsync>d__.<>1__state = -1;
		<RefreshGachaInfoAsync>d__.<>t__builder.Start<GachaMainView.<RefreshGachaInfoAsync>d__62>(ref <RefreshGachaInfoAsync>d__);
		return <RefreshGachaInfoAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D928 RID: 55592 RVA: 0x003A3470 File Offset: 0x003A1670
	private UniTask RefreshGachaAccumulateBtn(bool needAnimate = true)
	{
		GachaMainView.<RefreshGachaAccumulateBtn>d__63 <RefreshGachaAccumulateBtn>d__;
		<RefreshGachaAccumulateBtn>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshGachaAccumulateBtn>d__.<>4__this = this;
		<RefreshGachaAccumulateBtn>d__.needAnimate = needAnimate;
		<RefreshGachaAccumulateBtn>d__.<>1__state = -1;
		<RefreshGachaAccumulateBtn>d__.<>t__builder.Start<GachaMainView.<RefreshGachaAccumulateBtn>d__63>(ref <RefreshGachaAccumulateBtn>d__);
		return <RefreshGachaAccumulateBtn>d__.<>t__builder.Task;
	}

	// Token: 0x0600D929 RID: 55593 RVA: 0x003A34BC File Offset: 0x003A16BC
	private void AutoOpenGachaAccumulateTips()
	{
		int gachaAccumulateId = this.CurGachaInfo.GachaAccumulateId;
		if (gachaAccumulateId == 0)
		{
			return;
		}
		if (ModelBase<GachaAccumulateModel>.Instance.IfGachaAccumulateNeedAutoOpenTips(gachaAccumulateId))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaAccumulateBonusView, gachaAccumulateId, null);
			ModelBase<GachaAccumulateModel>.Instance.SaveGachaAccumulateAutoOpenTips(gachaAccumulateId);
		}
	}

	// Token: 0x0600D92A RID: 55594 RVA: 0x003A3508 File Offset: 0x003A1708
	private void OnGachaAccumulateRewardClaimed(int accumulateId)
	{
		this.RefreshGachaAccumulateBtn(false).Forget();
		this.GachaTagScrollView.GetGenericLayout().GetSelectedGridIndex();
		GenericScrollViewNew<GachaTagItem, GachaPoolData> gachaTagScrollView = this.GachaTagScrollView;
		List<GachaTagItem> list = (gachaTagScrollView != null) ? gachaTagScrollView.GetScrollItemList() : null;
		if (list != null)
		{
			foreach (GachaTagItem gachaTagItem in list)
			{
				gachaTagItem.RefreshRedDot();
			}
		}
	}

	// Token: 0x0600D92B RID: 55595 RVA: 0x003A3588 File Offset: 0x003A1788
	private void OnGachaPoolSelectResponse(int _1, int _2)
	{
		int selectedGridIndex = this.GachaTagScrollView.GetGenericLayout().GetSelectedGridIndex();
		if (this.TagDataList == null || selectedGridIndex < 0 || selectedGridIndex >= this.TagDataList.Length)
		{
			return;
		}
		GachaPoolData gachaPoolData = this.TagDataList[selectedGridIndex];
		GenericScrollViewNew<GachaTagItem, GachaPoolData> gachaTagScrollView = this.GachaTagScrollView;
		GachaTagItem gachaTagItem = (gachaTagScrollView != null) ? gachaTagScrollView.GetScrollItemByIndex(selectedGridIndex) : null;
		if (gachaPoolData == null || gachaTagItem == null)
		{
			return;
		}
		ProtoGachaInfo gachaInfo = gachaPoolData.GachaInfo;
		int usePoolId = gachaInfo.UsePoolId;
		ProtoGachaPoolInfo poolInfo = gachaInfo.GetPoolInfo(usePoolId);
		if (poolInfo == null)
		{
			return;
		}
		gachaPoolData.PoolInfo = poolInfo;
		gachaTagItem.Refresh(gachaPoolData, true, selectedGridIndex);
		this.RefreshGachaInfo();
		this.PlaySwitchAnim();
	}

	// Token: 0x0600D92C RID: 55596 RVA: 0x003A361C File Offset: 0x003A181C
	private UniTask RefreshCurrency()
	{
		GachaMainView.<RefreshCurrency>d__67 <RefreshCurrency>d__;
		<RefreshCurrency>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshCurrency>d__.<>4__this = this;
		<RefreshCurrency>d__.<>1__state = -1;
		<RefreshCurrency>d__.<>t__builder.Start<GachaMainView.<RefreshCurrency>d__67>(ref <RefreshCurrency>d__);
		return <RefreshCurrency>d__.<>t__builder.Task;
	}

	// Token: 0x0600D92D RID: 55597 RVA: 0x003A3660 File Offset: 0x003A1860
	private void RefreshGachaBtn()
	{
		if (this.CurGachaPoolData == null)
		{
			return;
		}
		EffectiveGachaButtonInfo[] effectiveGachaButtons = ModelBase<GachaModel>.Instance.GetEffectiveGachaButtons(this.CurGachaInfo);
		EffectiveGachaButtonInfo effectiveGachaButtonInfo = Array.Find<EffectiveGachaButtonInfo>(effectiveGachaButtons, (EffectiveGachaButtonInfo button) => button.Times == this.GachaBtn1.Times);
		EffectiveGachaButtonInfo effectiveGachaButtonInfo2 = Array.Find<EffectiveGachaButtonInfo>(effectiveGachaButtons, (EffectiveGachaButtonInfo button) => button.Times == this.GachaBtn10.Times);
		bool flag = this.CurGachaInfo.UsePoolId != 0;
		this.GachaBtn1.GetRootItem().SetUIActive(effectiveGachaButtonInfo != null && flag);
		this.GachaBtn10.GetRootItem().SetUIActive(effectiveGachaButtonInfo2 != null && flag);
		if (effectiveGachaButtonInfo != null)
		{
			this.GachaBtn1.Refresh(this.CurGachaPoolData, effectiveGachaButtonInfo);
		}
		if (effectiveGachaButtonInfo2 != null)
		{
			this.GachaBtn10.Refresh(this.CurGachaPoolData, effectiveGachaButtonInfo2);
		}
		ProtoGachaInfo curGachaInfo = this.CurGachaInfo;
		bool flag2 = curGachaInfo != null && curGachaInfo.UsePoolId == 0;
		ButtonItem selectPoolButton = this.SelectPoolButton;
		if (selectPoolButton != null)
		{
			selectPoolButton.SetActive(flag2);
		}
		this.RefreshSelectBtnTag(flag2);
		ProtoGachaPoolInfo curShowPoolInfo = this.CurShowPoolInfo;
		bool flag3 = curShowPoolInfo != null && curShowPoolInfo.UiType == 5 && !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.FirstOpenCommonWeaponSelect, false);
		ButtonItem selectPoolButton2 = this.SelectPoolButton;
		if (selectPoolButton2 != null)
		{
			selectPoolButton2.SetRedDotVisible(flag2 && flag3);
		}
		GachaViewInfo? gachaViewInfo = ConfigBase<GachaConfig>.Instance.GetGachaViewInfo(this.CurShowPoolId);
		if (gachaViewInfo == null)
		{
			return;
		}
		int type = gachaViewInfo.Value.Type;
		GachaViewTypeInfo? gachaViewTypeConfig = ConfigBase<GachaConfig>.Instance.GetGachaViewTypeConfig(type);
		if (gachaViewTypeConfig == null)
		{
			return;
		}
		string gachaButtonTip = gachaViewTypeConfig.Value.GachaButtonTip;
		bool flag4 = StringUtils.IsBlank(gachaButtonTip);
		base.GetText(24).SetUIActive(!flag4);
		if (!flag4)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(24), gachaButtonTip, Array.Empty<object>());
		}
		this.RefreshDiscountList().Forget();
	}

	// Token: 0x0600D92E RID: 55598 RVA: 0x003A381C File Offset: 0x003A1A1C
	private void RefreshSelectBtnTag(bool isShowSelectPoolButton)
	{
		UUIItem item = base.GetItem(34);
		GachaTagInfo gachaTagInfo = isShowSelectPoolButton ? ModelBase<GachaModel>.Instance.GetSelectPoolButtonTag(this.CurGachaInfo) : null;
		if (gachaTagInfo == null)
		{
			this.SelectBtnTagItemA.SetUiActive(false);
			this.SelectBtnTagItemB.SetUiActive(false);
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(true);
		if (gachaTagInfo.Kind == EGachaTagKind.Custom)
		{
			this.SelectBtnTagItemA.SetUiActive(false);
			this.SelectBtnTagItemB.SetUiActive(true);
			this.SelectBtnTagItemB.SetContent(gachaTagInfo.Text);
			return;
		}
		this.SelectBtnTagItemB.SetUiActive(false);
		this.SelectBtnTagItemA.SetUiActive(true);
		if (gachaTagInfo.Kind == EGachaTagKind.Free)
		{
			this.SelectBtnTagItemA.SetLocalText("SaleTag_1", Array.Empty<object>());
			return;
		}
		this.SelectBtnTagItemA.SetLocalText("SaleTag_2", new object[]
		{
			gachaTagInfo.DiscountPct.Value
		});
	}

	// Token: 0x0600D92F RID: 55599 RVA: 0x003A3908 File Offset: 0x003A1B08
	private UniTask RefreshDiscountList()
	{
		GachaMainView.<RefreshDiscountList>d__70 <RefreshDiscountList>d__;
		<RefreshDiscountList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshDiscountList>d__.<>4__this = this;
		<RefreshDiscountList>d__.<>1__state = -1;
		<RefreshDiscountList>d__.<>t__builder.Start<GachaMainView.<RefreshDiscountList>d__70>(ref <RefreshDiscountList>d__);
		return <RefreshDiscountList>d__.<>t__builder.Task;
	}

	// Token: 0x0600D930 RID: 55600 RVA: 0x003A394C File Offset: 0x003A1B4C
	private UniTask EnsureDiscountItems(int count)
	{
		GachaMainView.<EnsureDiscountItems>d__71 <EnsureDiscountItems>d__;
		<EnsureDiscountItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<EnsureDiscountItems>d__.<>4__this = this;
		<EnsureDiscountItems>d__.count = count;
		<EnsureDiscountItems>d__.<>1__state = -1;
		<EnsureDiscountItems>d__.<>t__builder.Start<GachaMainView.<EnsureDiscountItems>d__71>(ref <EnsureDiscountItems>d__);
		return <EnsureDiscountItems>d__.<>t__builder.Task;
	}

	// Token: 0x0600D931 RID: 55601 RVA: 0x003A3998 File Offset: 0x003A1B98
	private void RefreshTimesText()
	{
		List<TableTextArgNew> list = new List<TableTextArgNew>();
		int todayResultCount = ModelBase<GachaModel>.Instance.TodayResultCount;
		if (todayResultCount >= 0)
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("gacha_daily_total_limit_times");
			TableTextArgNew item = new TableTextArgNew("GachaTotalRestCount", new <>z__ReadOnlyArray<object>(new object[]
			{
				todayResultCount,
				intConfig
			}));
			list.Add(item);
		}
		if (this.CurGachaInfo.DailyLimitTimes > 0)
		{
			int dailyLimitTimes = this.CurGachaInfo.DailyLimitTimes;
			int todayTimes = this.CurGachaInfo.TodayTimes;
			TableTextArgNew item2 = new TableTextArgNew("GachaPoolTodayRestCount", new <>z__ReadOnlyArray<object>(new object[]
			{
				dailyLimitTimes - todayTimes,
				dailyLimitTimes
			}));
			list.Add(item2);
		}
		if (this.CurGachaInfo.TotalLimitTimes > 0)
		{
			int totalLimitTimes = this.CurGachaInfo.TotalLimitTimes;
			int totalTimes = this.CurGachaInfo.TotalTimes;
			TableTextArgNew item3 = new TableTextArgNew("GachaPoolTotalRestCount", new <>z__ReadOnlyArray<object>(new object[]
			{
				totalLimitTimes - totalTimes,
				totalLimitTimes
			}));
			list.Add(item3);
		}
		this.TimesTextLayout.RefreshByData(list.ToList<TableTextArgNew>(), null, false);
	}

	// Token: 0x0600D932 RID: 55602 RVA: 0x003A3AC4 File Offset: 0x003A1CC4
	private void AfterOpenCommonWeaponSelectView()
	{
		ProtoGachaPoolInfo curShowPoolInfo = this.CurShowPoolInfo;
		if (curShowPoolInfo == null || curShowPoolInfo.UiType != 5)
		{
			return;
		}
		if (!LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.FirstOpenCommonWeaponSelect, false))
		{
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.FirstOpenCommonWeaponSelect, true);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnOpenCommonWeaponSelect);
			this.RefreshGachaBtn();
			int selectedGridIndex = this.GachaTagScrollView.GetGenericLayout().GetSelectedGridIndex();
			GenericScrollViewNew<GachaTagItem, GachaPoolData> gachaTagScrollView = this.GachaTagScrollView;
			GachaTagItem gachaTagItem = (gachaTagScrollView != null) ? gachaTagScrollView.GetScrollItemByIndex(selectedGridIndex) : null;
			if (gachaTagItem != null)
			{
				gachaTagItem.RefreshRedDot();
			}
		}
	}

	// Token: 0x0600D933 RID: 55603 RVA: 0x003A3B4C File Offset: 0x003A1D4C
	private UniTask InitBackGroundItem()
	{
		GachaMainView.<InitBackGroundItem>d__74 <InitBackGroundItem>d__;
		<InitBackGroundItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitBackGroundItem>d__.<>4__this = this;
		<InitBackGroundItem>d__.<>1__state = -1;
		<InitBackGroundItem>d__.<>t__builder.Start<GachaMainView.<InitBackGroundItem>d__74>(ref <InitBackGroundItem>d__);
		return <InitBackGroundItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D934 RID: 55604 RVA: 0x003A3B90 File Offset: 0x003A1D90
	private UniTask InitSpineBackgroundItem(string resourceId)
	{
		GachaMainView.<InitSpineBackgroundItem>d__75 <InitSpineBackgroundItem>d__;
		<InitSpineBackgroundItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSpineBackgroundItem>d__.<>4__this = this;
		<InitSpineBackgroundItem>d__.resourceId = resourceId;
		<InitSpineBackgroundItem>d__.<>1__state = -1;
		<InitSpineBackgroundItem>d__.<>t__builder.Start<GachaMainView.<InitSpineBackgroundItem>d__75>(ref <InitSpineBackgroundItem>d__);
		return <InitSpineBackgroundItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D935 RID: 55605 RVA: 0x003A3BDC File Offset: 0x003A1DDC
	private void PlaySwitchAnim()
	{
		GachaPoolItem curPoolItem = this.CurPoolItem;
		if (curPoolItem != null)
		{
			curPoolItem.SetActive(true);
		}
		if (this.UiViewSequence.HasSequenceNameInPlaying("Switch"))
		{
			this.UiViewSequence.ReplaySequence("Switch");
		}
		else
		{
			this.UiViewSequence.PlaySequence("Switch", false, null);
		}
		GachaPoolItem curPoolItem2 = this.CurPoolItem;
		if (curPoolItem2 == null)
		{
			return;
		}
		curPoolItem2.PlaySwitchSeq();
	}

	// Token: 0x0600D936 RID: 55606 RVA: 0x003A3C4C File Offset: 0x003A1E4C
	private void RefreshDetail()
	{
		ProtoGachaInfo curGachaInfo = this.CurGachaInfo;
		if (curGachaInfo == null)
		{
			return;
		}
		if (this.CurShowPoolInfo == null)
		{
			return;
		}
		GachaViewInfo? gachaViewInfo = ConfigBase<GachaConfig>.Instance.GetGachaViewInfo(this.CurShowPoolId);
		if (gachaViewInfo == null)
		{
			return;
		}
		int uiType = this.CurShowPoolInfo.UiType;
		GachaViewTypeInfo? gachaViewTypeConfig = ConfigBase<GachaConfig>.Instance.GetGachaViewTypeConfig(uiType);
		if (gachaViewTypeConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), gachaViewTypeConfig.Value.TypeText, Array.Empty<object>());
		double poolEndTimeByPoolInfo = curGachaInfo.GetPoolEndTimeByPoolInfo(this.CurShowPoolInfo);
		base.GetItem(11).SetUIActive(poolEndTimeByPoolInfo > 0.0);
		if (poolEndTimeByPoolInfo > 0.0)
		{
			this.RefreshLeftTime();
		}
		else if (this.TimerHandle != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
		int[] upList = this.CurShowPoolInfo.UpList;
		bool flag = ModelBase<GachaModel>.Instance.IsRolePool((GachaDefine.EGachaViewType)uiType);
		if (upList != null && upList.Length != 0)
		{
			UUIItem item = base.GetItem(15);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			GenericLayout<GachaSmallItemGrid, int> upItemLayout = this.UpItemLayout;
			if (upItemLayout != null)
			{
				upItemLayout.RefreshByData(upList.ToList<int>(), null, false);
			}
			string textStringId = flag ? "Text_GachaUpList1_Text" : "Text_GachaUpList2_Text";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), textStringId, Array.Empty<object>());
		}
		else
		{
			UUIItem item2 = base.GetItem(15);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
		}
		ProtoGachaPoolInfo[] validPoolList = curGachaInfo.GetValidPoolList();
		if (validPoolList != null && validPoolList.Length > 1 && curGachaInfo.UsePoolId != 0)
		{
			UUIButtonComponent button = base.GetButton(18);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(true);
			}
		}
		else
		{
			UUIButtonComponent button2 = base.GetButton(18);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(false);
			}
		}
		base.SetTextureByPath(gachaViewInfo.Value.UnderBgTexturePath, base.GetTexture(19), null, null);
		FColor color = FColor.FromHex(this.CurShowPoolInfo.ThemeColor);
		UUITexture texture = base.GetTexture(20);
		if (texture != null)
		{
			texture.SetColor(color);
		}
		UUITexture texture2 = base.GetTexture(21);
		texture2.SetUIActive(flag);
		if (flag)
		{
			texture2.SetColor(color);
		}
		base.GetText(10).SetText(this.CurShowPoolInfo.Title, true);
		base.GetText(13).SetText(this.CurShowPoolInfo.Description, true);
		base.GetText(28).SetText(this.CurShowPoolInfo.ComplianceDetail, true);
		base.GetText(28).SetUIActive(!StringUtils.IsEmpty(this.CurShowPoolInfo.ComplianceDetail));
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(29);
		if (scrollViewWithScrollbar == null)
		{
			return;
		}
		scrollViewWithScrollbar.SetScrollProgress(0f);
	}

	// Token: 0x0600D937 RID: 55607 RVA: 0x003A3F14 File Offset: 0x003A2114
	private void RefreshGachaTag()
	{
		if (this.IsLock)
		{
			GachaMainView.OperationParam element = new GachaMainView.OperationParam(GachaMainView.EOperationType.RefreshGachaTag, null);
			this.GachaOperationQueue.Push(element);
			return;
		}
		this.Lock();
		this.RefreshGachaTagAsync().ContinueWith(new Action(this.Unlock)).Forget();
	}

	// Token: 0x0600D938 RID: 55608 RVA: 0x003A3F60 File Offset: 0x003A2160
	private UniTask RefreshGachaTagAsync()
	{
		GachaMainView.<RefreshGachaTagAsync>d__79 <RefreshGachaTagAsync>d__;
		<RefreshGachaTagAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshGachaTagAsync>d__.<>4__this = this;
		<RefreshGachaTagAsync>d__.<>1__state = -1;
		<RefreshGachaTagAsync>d__.<>t__builder.Start<GachaMainView.<RefreshGachaTagAsync>d__79>(ref <RefreshGachaTagAsync>d__);
		return <RefreshGachaTagAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D939 RID: 55609 RVA: 0x003A3FA3 File Offset: 0x003A21A3
	private GachaTagItem CreateGachaTagItem()
	{
		return new GachaTagItem
		{
			SelectCallback = new Action<int>(this.SelectGachaTagByIndex),
			CanExecuteChange = new Func<int, bool>(this.CanToggleChange)
		};
	}

	// Token: 0x0600D93A RID: 55610 RVA: 0x003A3FCE File Offset: 0x003A21CE
	private CommonTextItem InitTimesTextItem()
	{
		return new CommonTextItem();
	}

	// Token: 0x0600D93B RID: 55611 RVA: 0x003A3FD5 File Offset: 0x003A21D5
	private GachaSmallItemGrid InitUpItem()
	{
		return new GachaSmallItemGrid();
	}

	// Token: 0x0600D93C RID: 55612 RVA: 0x003A3FDC File Offset: 0x003A21DC
	private void SelectGachaTagByIndex(int gridIndex)
	{
		if (this.IsLock)
		{
			GachaMainView.OperationParam element = new GachaMainView.OperationParam(GachaMainView.EOperationType.SelectGachaTagByIndex, gridIndex);
			this.GachaOperationQueue.Push(element);
			return;
		}
		this.Lock();
		this.SelectGachaTagByIndexAsync(gridIndex).ContinueWith(new Action(this.Unlock)).Forget();
	}

	// Token: 0x0600D93D RID: 55613 RVA: 0x003A4030 File Offset: 0x003A2230
	private UniTask SelectGachaTagByIndexAsync(int gridIndex)
	{
		GachaMainView.<SelectGachaTagByIndexAsync>d__84 <SelectGachaTagByIndexAsync>d__;
		<SelectGachaTagByIndexAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SelectGachaTagByIndexAsync>d__.<>4__this = this;
		<SelectGachaTagByIndexAsync>d__.gridIndex = gridIndex;
		<SelectGachaTagByIndexAsync>d__.<>1__state = -1;
		<SelectGachaTagByIndexAsync>d__.<>t__builder.Start<GachaMainView.<SelectGachaTagByIndexAsync>d__84>(ref <SelectGachaTagByIndexAsync>d__);
		return <SelectGachaTagByIndexAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D93E RID: 55614 RVA: 0x003A407C File Offset: 0x003A227C
	private bool CanToggleChange(int gridIndex)
	{
		GenericScrollViewNew<GachaTagItem, GachaPoolData> gachaTagScrollView = this.GachaTagScrollView;
		int? num;
		if (gachaTagScrollView == null)
		{
			num = null;
		}
		else
		{
			GenericLayout<GachaTagItem, GachaPoolData> genericLayout = gachaTagScrollView.GetGenericLayout();
			num = ((genericLayout != null) ? new int?(genericLayout.GetSelectedGridIndex()) : null);
		}
		int? num2 = num;
		return !(gridIndex == num2.GetValueOrDefault() & num2 != null);
	}

	// Token: 0x0600D93F RID: 55615 RVA: 0x003A40D4 File Offset: 0x003A22D4
	private void OpenExChangeTokenView(int _)
	{
		ProtoGachaInfo curGachaInfo = this.CurGachaInfo;
		int? num = (curGachaInfo != null) ? new int?(curGachaInfo.ItemId) : null;
		if (num != null)
		{
			int? num2 = num;
			int num3 = 0;
			if (!(num2.GetValueOrDefault() <= num3 & num2 != null))
			{
				int shopIdByGachaItemId = ConfigBase<GachaConfig>.Instance.GetShopIdByGachaItemId(num.Value);
				if (shopIdByGachaItemId <= 0)
				{
					return;
				}
				ControllerBase<PayShopController>.Instance.OpenExchangePopView(shopIdByGachaItemId, null);
				return;
			}
		}
	}

	// Token: 0x0600D940 RID: 55616 RVA: 0x003A4149 File Offset: 0x003A2349
	private void OnPrimaryCurrencyClick(int _)
	{
		ControllerBase<PayShopController>.Instance.OpenPayShopViewToRecharge();
	}

	// Token: 0x0600D941 RID: 55617 RVA: 0x003A4158 File Offset: 0x003A2358
	private void OpenExChangeSecondCurrencyView(int _)
	{
		int? num = ConfigBase<GachaConfig>.Instance.SecondCurrency();
		CommonExchangeData exchangeData = new CommonExchangeData();
		exchangeData.InitByItemId(num.Value);
		exchangeData.ConfirmNoClose = true;
		exchangeData.ConfirmCallBack = delegate(int itemId, int exChangeTime)
		{
			ExchangeSimulation exchangeSimulation = ModelBase<ItemExchangeModel>.Instance.CalculateConsume(itemId, 0, exChangeTime, false);
			if (exchangeSimulation == null || exChangeTime == 0)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.CommonExchangeView, null);
				return;
			}
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(exchangeData.GetSrcItemId(), 0);
			int num2 = exchangeSimulation.ConsumeCount - itemCountByConfigId;
			if (num2 <= 0)
			{
				ControllerBase<ItemExchangeController>.Instance.ItemExchangeRequest(itemId, exChangeTime, true, null);
				Singleton<UiManager>.Instance.CloseView(EUiViewName.CommonExchangeView, null);
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ExchangeNoEnough);
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				num2.ToString(),
				exchangeData.GetSrcName()
			});
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.CommonExchangeView, null);
				ControllerBase<PayShopController>.Instance.OpenPayShopViewToRecharge();
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		};
		ControllerBase<ItemExchangeController>.Instance.OpenExchangeViewByData(exchangeData);
	}

	// Token: 0x0600D942 RID: 55618 RVA: 0x003A41C6 File Offset: 0x003A23C6
	protected override void OnAfterHide()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x0600D943 RID: 55619 RVA: 0x003A41E8 File Offset: 0x003A23E8
	protected override void OnBeforeDestroy()
	{
		if (this.CountDownTimerHandle != null)
		{
			TimerSystem.Instance.Remove(this.CountDownTimerHandle);
			this.CountDownTimerHandle = null;
		}
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.Destroy(null);
	}

	// Token: 0x0600D944 RID: 55620 RVA: 0x003A421C File Offset: 0x003A241C
	public bool SelectGachaTagById(int gachaId)
	{
		int num = Array.FindIndex<GachaPoolData>(this.TagDataList, (GachaPoolData data) => data.GachaInfo.Id == gachaId);
		if (num >= 0 && num < this.TagDataList.Length)
		{
			this.SelectGachaTagByIndex(num);
			return true;
		}
		return false;
	}

	// Token: 0x0600D945 RID: 55621 RVA: 0x003A4268 File Offset: 0x003A2468
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		int num = int.Parse(configParams[0]);
		if (num != 0 && this.SelectGachaTagById(num) && this.GachaBtn1 != null)
		{
			UUIItem rootItem = this.GachaBtn1.GetRootItem();
			return new UUIItem[]
			{
				rootItem,
				rootItem
			};
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Guide;
		ELogAuthor author = ELogAuthor.JT;
		string message = "聚焦引导extraParam项配置有误";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x040067A6 RID: 26534
	[Nullable(2)]
	private GachaAccumulateTipsItem GachaAccumulateTipsItem;

	// Token: 0x040067A7 RID: 26535
	private readonly Dictionary<GachaDefine.EGachaViewType, GachaPoolItem> GachaPoolItemMap = new Dictionary<GachaDefine.EGachaViewType, GachaPoolItem>();

	// Token: 0x040067A8 RID: 26536
	private readonly Dictionary<int, GachaPoolItem> SpineGachaPoolItemMap = new Dictionary<int, GachaPoolItem>();

	// Token: 0x040067A9 RID: 26537
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<GachaTagItem, GachaPoolData> GachaTagScrollView;

	// Token: 0x040067AA RID: 26538
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GachaPoolData[] TagDataList;

	// Token: 0x040067AB RID: 26539
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<CommonTextItem, TableTextArgNew> TimesTextLayout;

	// Token: 0x040067AC RID: 26540
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<GachaSmallItemGrid, int> UpItemLayout;

	// Token: 0x040067AD RID: 26541
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x040067AE RID: 26542
	[Nullable(2)]
	private GachaButton GachaBtn1;

	// Token: 0x040067AF RID: 26543
	[Nullable(2)]
	private GachaButton GachaBtn10;

	// Token: 0x040067B0 RID: 26544
	[Nullable(2)]
	private ButtonItem SelectPoolButton;

	// Token: 0x040067B1 RID: 26545
	[Nullable(2)]
	private GachaDiscountTagItem SelectBtnTagItemA;

	// Token: 0x040067B2 RID: 26546
	[Nullable(2)]
	private GachaDiscountTagItem SelectBtnTagItemB;

	// Token: 0x040067B3 RID: 26547
	private readonly List<GachaDiscountTimesItem> DiscountItems = new List<GachaDiscountTimesItem>();

	// Token: 0x040067B4 RID: 26548
	[Nullable(2)]
	private GachaPoolItem CurPoolItem;

	// Token: 0x040067B5 RID: 26549
	private bool IsViewFirstShow;

	// Token: 0x040067B6 RID: 26550
	private double LastRefreshTime;

	// Token: 0x040067B7 RID: 26551
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x040067B8 RID: 26552
	[Nullable(2)]
	private TimerHandle CountDownTimerHandle;

	// Token: 0x040067B9 RID: 26553
	private readonly Queue<GachaMainView.OperationParam> GachaOperationQueue = new Queue<GachaMainView.OperationParam>(4);

	// Token: 0x040067BA RID: 26554
	private bool Operating;

	// Token: 0x0200803B RID: 32827
	[NullableContext(0)]
	private enum EOperationType
	{
		// Token: 0x0402B9EF RID: 178671
		RefreshGachaTag,
		// Token: 0x0402B9F0 RID: 178672
		RefreshGachaInfo,
		// Token: 0x0402B9F1 RID: 178673
		SelectGachaTagByIndex
	}

	// Token: 0x0200803C RID: 32828
	[NullableContext(2)]
	[Nullable(0)]
	private class OperationParam
	{
		// Token: 0x060482D5 RID: 295637 RVA: 0x0134FCCA File Offset: 0x0134DECA
		public OperationParam(GachaMainView.EOperationType operationType, object param = null)
		{
			this.OperationType = operationType;
			this.Param = param;
		}

		// Token: 0x0402B9F2 RID: 178674
		public GachaMainView.EOperationType OperationType;

		// Token: 0x0402B9F3 RID: 178675
		public object Param;
	}

	// Token: 0x0200803D RID: 32829
	[NullableContext(0)]
	private enum EGachaMainCom
	{
		// Token: 0x0402B9F5 RID: 178677
		CaptionItem,
		// Token: 0x0402B9F6 RID: 178678
		ShopBtn,
		// Token: 0x0402B9F7 RID: 178679
		PreviewBtn,
		// Token: 0x0402B9F8 RID: 178680
		HelpBtn,
		// Token: 0x0402B9F9 RID: 178681
		RecordBtn,
		// Token: 0x0402B9FA RID: 178682
		GachaBtnItem1,
		// Token: 0x0402B9FB RID: 178683
		GachaBtnItem10,
		// Token: 0x0402B9FC RID: 178684
		GachaPoolParentItem,
		// Token: 0x0402B9FD RID: 178685
		GachaPoolScrollView,
		// Token: 0x0402B9FE RID: 178686
		TypeText,
		// Token: 0x0402B9FF RID: 178687
		TitleText,
		// Token: 0x0402BA00 RID: 178688
		DateItem,
		// Token: 0x0402BA01 RID: 178689
		DateText,
		// Token: 0x0402BA02 RID: 178690
		DetailText,
		// Token: 0x0402BA03 RID: 178691
		TimesTextLayout,
		// Token: 0x0402BA04 RID: 178692
		UpItemRootItem,
		// Token: 0x0402BA05 RID: 178693
		UpItemTipText,
		// Token: 0x0402BA06 RID: 178694
		UpItemLayout,
		// Token: 0x0402BA07 RID: 178695
		ChangeBtn,
		// Token: 0x0402BA08 RID: 178696
		BgTexture,
		// Token: 0x0402BA09 RID: 178697
		ThemeTextMaskTexture,
		// Token: 0x0402BA0A RID: 178698
		RoleBgTexture,
		// Token: 0x0402BA0B RID: 178699
		SelectTipsItem,
		// Token: 0x0402BA0C RID: 178700
		SelectPoolButton,
		// Token: 0x0402BA0D RID: 178701
		TxtTips,
		// Token: 0x0402BA0E RID: 178702
		GuaranteedItem,
		// Token: 0x0402BA0F RID: 178703
		GuaranteedNumText,
		// Token: 0x0402BA10 RID: 178704
		GuaranteedText,
		// Token: 0x0402BA11 RID: 178705
		GachaComplianceText,
		// Token: 0x0402BA12 RID: 178706
		TextScroller,
		// Token: 0x0402BA13 RID: 178707
		LayoutTurnAniController,
		// Token: 0x0402BA14 RID: 178708
		GachaAccumulateTipsItem,
		// Token: 0x0402BA15 RID: 178709
		DiscountList,
		// Token: 0x0402BA16 RID: 178710
		DiscountTemplate,
		// Token: 0x0402BA17 RID: 178711
		SelectBtnTagRoot
	}
}
