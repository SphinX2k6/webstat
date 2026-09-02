using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029EA RID: 10730
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerView : UiViewBase
{
	// Token: 0x06015632 RID: 87602 RVA: 0x005ECAC4 File Offset: 0x005EACC4
	private static Dictionary<EShipTowerStageType, Func<ShipTowerStageItemBase>> GetStageTypeMap()
	{
		Dictionary<EShipTowerStageType, Func<ShipTowerStageItemBase>> dictionary = new Dictionary<EShipTowerStageType, Func<ShipTowerStageItemBase>>();
		dictionary.Add(EShipTowerStageType.OneTimeStage, () => new ShipTowerStageItemOneTime());
		dictionary.Add(EShipTowerStageType.RefreshStage, () => new ShipTowerStageItemRefresh());
		dictionary.Add(EShipTowerStageType.EndlessStage, () => new ShipTowerStageItemEndless());
		return dictionary;
	}

	// Token: 0x17001BEA RID: 7146
	// (get) Token: 0x06015633 RID: 87603 RVA: 0x005ECB48 File Offset: 0x005EAD48
	[Nullable(2)]
	public new ShipTowerViewParams OpenParam
	{
		[NullableContext(2)]
		get
		{
			return this.OpenParam as ShipTowerViewParams;
		}
	}

	// Token: 0x06015634 RID: 87604 RVA: 0x005ECB58 File Offset: 0x005EAD58
	public ShipTowerView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015635 RID: 87605 RVA: 0x005ECBF0 File Offset: 0x005EADF0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIText)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(22, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUISprite)),
			new ValueTuple<int, Type>(25, typeof(UUISprite)),
			new ValueTuple<int, Type>(27, typeof(UUISprite)),
			new ValueTuple<int, Type>(28, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnBuff)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnEndlessRecord)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickBtnLastStage)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickBtnNextStage)),
			new ValueTuple<int, Delegate>(22, new Action(this.OnClickBtnReward))
		};
	}

	// Token: 0x06015636 RID: 87606 RVA: 0x005ECF20 File Offset: 0x005EB120
	private void InitDataParam()
	{
		ShipTowerViewParams openParam = this.OpenParam;
		if (openParam == null || !openParam.IsOpenCover.GetValueOrDefault())
		{
			ModelBase<ShipTowerModel>.Instance.ClearChallengeStageData();
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.ShipTower;
		ELogAuthor author = ELogAuthor.CX;
		string message = "";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DataParam", this.OpenParam);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06015637 RID: 87607 RVA: 0x005ECF84 File Offset: 0x005EB184
	private UniTask CheckShowWelcomeView()
	{
		ShipTowerView.<CheckShowWelcomeView>d__41 <CheckShowWelcomeView>d__;
		<CheckShowWelcomeView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckShowWelcomeView>d__.<>4__this = this;
		<CheckShowWelcomeView>d__.<>1__state = -1;
		<CheckShowWelcomeView>d__.<>t__builder.Start<ShipTowerView.<CheckShowWelcomeView>d__41>(ref <CheckShowWelcomeView>d__);
		return <CheckShowWelcomeView>d__.<>t__builder.Task;
	}

	// Token: 0x06015638 RID: 87608 RVA: 0x005ECFC8 File Offset: 0x005EB1C8
	protected override UniTask OnCreateAsync()
	{
		ShipTowerView.<OnCreateAsync>d__42 <OnCreateAsync>d__;
		<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCreateAsync>d__.<>4__this = this;
		<OnCreateAsync>d__.<>1__state = -1;
		<OnCreateAsync>d__.<>t__builder.Start<ShipTowerView.<OnCreateAsync>d__42>(ref <OnCreateAsync>d__);
		return <OnCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015639 RID: 87609 RVA: 0x005ED00C File Offset: 0x005EB20C
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<UCurveFloat> LoadCurveFloat(string resId)
	{
		ShipTowerView.<LoadCurveFloat>d__43 <LoadCurveFloat>d__;
		<LoadCurveFloat>d__.<>t__builder = AsyncUniTaskMethodBuilder<UCurveFloat>.Create();
		<LoadCurveFloat>d__.resId = resId;
		<LoadCurveFloat>d__.<>1__state = -1;
		<LoadCurveFloat>d__.<>t__builder.Start<ShipTowerView.<LoadCurveFloat>d__43>(ref <LoadCurveFloat>d__);
		return <LoadCurveFloat>d__.<>t__builder.Task;
	}

	// Token: 0x0601563A RID: 87610 RVA: 0x005ED050 File Offset: 0x005EB250
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerView.<OnBeforeStartAsync>d__44 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerView.<OnBeforeStartAsync>d__44>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601563B RID: 87611 RVA: 0x005ED094 File Offset: 0x005EB294
	protected override void OnStart()
	{
		this.UpdateRedPoint();
		this.UiCompassRoot = base.GetItem(24);
		this.UiGear = base.GetSprite(26);
		this.UiBigGear = base.GetSprite(25);
		this.UiCompass = base.GetSprite(27);
		this.UiScrollViewStage = base.GetScrollViewWithScrollbar(21);
		this.UpdateFlipPageValue();
		this.UpdateChangeAreaValue();
		this.UpdateGearValue();
		this.UpdateCompassValue();
		this.UiScrollViewStage.ScrollToEaseType = LTweenEase.CurveFloat;
		this.UiScrollViewStage.OnScrollValueChange.Bind(new Action<FVector2D>(this.OnScrollValueChange));
		this.UiScrollViewStage.OnPointerBeginDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnPointerBeginDrag));
		this.UiScrollViewStage.OnPointerEndDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnPointerEndDrag));
		this.UiScrollViewStage.bCallTweenerCompleteCallbackWhenKill = true;
		UUIItem uuiitem = this.UiScrollViewStage.ContentUIItem.Get();
		this.ScrollContentInitPosY = ((uuiitem != null) ? uuiitem.GetAnchorOffsetY() : 0f);
		this.ScrollContentLastPosY = this.ScrollContentInitPosY;
		this.UiItemParallaxRoot = base.GetItem(20);
		this.ShowStageCfgList = ConfigBase<ShipTowerConfig>.Instance.GetAllShowStageCfg();
		this.InitParallaxItem();
		this.UpdateTopStageIndex(this.ScrollContentInitPosY);
		this.CheckInitDataParam();
		this.InitCurStageItemPos();
		this.AddHomeBtnExtraCallback();
	}

	// Token: 0x0601563C RID: 87612 RVA: 0x005ED1EA File Offset: 0x005EB3EA
	protected override void OnBeforeHide()
	{
		ModelBase<ShipTowerModel>.Instance.IsOpenedViewByWorld = false;
	}

	// Token: 0x0601563D RID: 87613 RVA: 0x005ED1F8 File Offset: 0x005EB3F8
	private void AddHomeBtnExtraCallback()
	{
		ShipTowerView.<>c__DisplayClass47_0 CS$<>8__locals1 = new ShipTowerView.<>c__DisplayClass47_0();
		ShipTowerView.<>c__DisplayClass47_0 CS$<>8__locals2 = CS$<>8__locals1;
		ShipTowerViewParams openParam = this.OpenParam;
		CS$<>8__locals2.isFromInstanceDungeon = ((openParam != null) ? openParam.IsFromInstanceDungeon : null);
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			ShipTowerView.<>c__DisplayClass47_0.<<AddHomeBtnExtraCallback>b__0>d <<AddHomeBtnExtraCallback>b__0>d;
			<<AddHomeBtnExtraCallback>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExtraCallback>b__0>d.<>4__this = CS$<>8__locals1;
			<<AddHomeBtnExtraCallback>b__0>d.<>1__state = -1;
			<<AddHomeBtnExtraCallback>b__0>d.<>t__builder.Start<ShipTowerView.<>c__DisplayClass47_0.<<AddHomeBtnExtraCallback>b__0>d>(ref <<AddHomeBtnExtraCallback>b__0>d);
			return <<AddHomeBtnExtraCallback>b__0>d.<>t__builder.Task;
		});
	}

	// Token: 0x0601563E RID: 87614 RVA: 0x005ED248 File Offset: 0x005EB448
	public void InitCurStageItemPos()
	{
		ShipTowerStageData focusingStageData = this.GetFocusingStageData();
		if (focusingStageData == null)
		{
			return;
		}
		this.ScrollToTopByIndex(0, false);
		UUIItem item = base.GetItem(7 + focusingStageData.OrderIndex - 1);
		float num = item.GetStretchTop() + item.GetHeight() / 2f;
		UUIItem uuiitem = this.UiScrollViewStage.RootUIComp.Get();
		float num2 = (uuiitem != null) ? uuiitem.GetHeight() : 0f;
		UUIItem uuiitem2 = this.UiScrollViewStage.ContentUIItem.Get();
		float val = ((uuiitem2 != null) ? uuiitem2.GetHeight() : 0f) - num2;
		float inY = Math.Max(0f, Math.Min(val, num - num2 / 2f));
		this.UiScrollViewStage.SetScrollValue(new FVector2D(0f, inY));
	}

	// Token: 0x0601563F RID: 87615 RVA: 0x005ED318 File Offset: 0x005EB518
	[NullableContext(2)]
	private ShipTowerStageData GetFocusingStageData()
	{
		ShipTowerViewParams openParam = this.OpenParam;
		if (openParam != null && openParam.StageId != null)
		{
			return ModelBase<ShipTowerModel>.Instance.GetStageDataById(openParam.StageId.Value);
		}
		return ModelBase<ShipTowerModel>.Instance.GetNextChallengeStageData(null);
	}

	// Token: 0x06015640 RID: 87616 RVA: 0x005ED364 File Offset: 0x005EB564
	private void InitParallaxItem()
	{
		UUIItem uiItemParallaxRoot = this.UiItemParallaxRoot;
		int num = uiItemParallaxRoot.UIChildren.Num();
		for (int i = 0; i < num; i++)
		{
			UUIItem uuiitem = uiItemParallaxRoot.UIChildren.Get(i);
			float valueByDisplayName = this.GetValueByDisplayName(uuiitem, 1, 1f);
			float initPosY = (uuiitem != null) ? uuiitem.GetAnchorOffsetY() : 0f;
			this.ItemParallaxList.Add(new ParallaxItem
			{
				Item = uuiitem,
				InitPosY = initPosY,
				ParallaxSub = valueByDisplayName
			});
		}
	}

	// Token: 0x06015641 RID: 87617 RVA: 0x005ED3E8 File Offset: 0x005EB5E8
	private float GetValueByDisplayName(UUIItem uiItem, int index = 1, float defaultValue = 1f)
	{
		string[] array = uiItem.GetDisplayName().Split('#', StringSplitOptions.None);
		if (index >= array.Length)
		{
			return defaultValue;
		}
		float num;
		if (!float.TryParse(array[index], out num))
		{
			return defaultValue;
		}
		return num / 100f;
	}

	// Token: 0x06015642 RID: 87618 RVA: 0x005ED424 File Offset: 0x005EB624
	private void UpdateFlipPageValue()
	{
		UUIItem uuiitem = this.UiScrollViewStage.RootUIComp.Get();
		if (uuiitem == null)
		{
			return;
		}
		this.FlipPageScrollDuration = this.GetValueByDisplayName(uuiitem, 1, 0.2f);
		this.FlipPageDistanceThreshold = this.GetValueByDisplayName(uuiitem, 2, 300f);
		this.FlipPageIntervalDistance = this.GetValueByDisplayName(uuiitem, 3, 2f);
	}

	// Token: 0x06015643 RID: 87619 RVA: 0x005ED482 File Offset: 0x005EB682
	private void UpdateChangeAreaValue()
	{
		this.ChangeAreaScrollDuration = this.GetValueByDisplayName(this.UiCompassRoot, 1, 1f);
	}

	// Token: 0x06015644 RID: 87620 RVA: 0x005ED49C File Offset: 0x005EB69C
	private void UpdateGearValue()
	{
		this.GearLength = this.GetValueByDisplayName(this.UiGear, 1, 300f);
		this.BigGearLength = this.GetValueByDisplayName(this.UiBigGear, 1, 600f);
	}

	// Token: 0x06015645 RID: 87621 RVA: 0x005ED4CE File Offset: 0x005EB6CE
	private void UpdateCompassValue()
	{
		this.CompassStartAngle = this.GetValueByDisplayName(this.UiCompass, 1, -45f);
		this.CompassEndAngle = this.GetValueByDisplayName(this.UiCompass, 2, 45f);
	}

	// Token: 0x06015646 RID: 87622 RVA: 0x005ED500 File Offset: 0x005EB700
	private void CheckInitDataParam()
	{
		ShipTowerViewParams openParam = this.OpenParam;
		int stageId = ((openParam != null) ? openParam.StageId : null) ?? ModelBase<ShipTowerModel>.Instance.TowerStageDataList[0].Id;
		ShipTowerViewParams openParam2 = this.OpenParam;
		int? applyTeamEditStageId = (openParam2 != null) ? new int?(openParam2.ApplyTeamEditStageId) : null;
		ShipTowerViewParams openParam3 = this.OpenParam;
		bool? flag = (openParam3 != null) ? openParam3.IsOpenStageDesc : null;
		ShipTowerViewParams openParam4 = this.OpenParam;
		bool? isOpenCover = (openParam4 != null) ? openParam4.IsOpenCover : null;
		if (flag.GetValueOrDefault())
		{
			ModelBase<ShipTowerModel>.Instance.OpenViewDesc(new ShipTowerDescViewParams
			{
				StageId = stageId,
				ApplyTeamEditStageId = applyTeamEditStageId,
				IsOpenCover = isOpenCover
			}, delegate(bool _, int _)
			{
				this.CheckNeedShowView();
			});
		}
	}

	// Token: 0x06015647 RID: 87623 RVA: 0x005ED5E4 File Offset: 0x005EB7E4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ShipTowerRewardReceive, new Action<int>(this.EventRewardReceive));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ShipTowerSureResetStage, new Action<int>(this.EventShipTowerStageUpdate));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ShipTowerStageUpdate, new Action<int>(this.EventShipTowerStageUpdate));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ShipTowerSureCoverChallenge, new Action<int>(this.EventShipTowerStageUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.ShipTowerBuffNewUpdate, new Action(this.UpdateBuffNew));
		Singleton<EventSystem>.Instance.Add(EEventName.ShipTowerEndlessRecordUpdate, new Action(this.UpdateEndlessRecord));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.EventOpenView));
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ShipTowerReward, base.GetItem(23), null, 0);
	}

	// Token: 0x06015648 RID: 87624 RVA: 0x005ED6C8 File Offset: 0x005EB8C8
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ShipTowerRewardReceive, new Action<int>(this.EventRewardReceive));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.ShipTowerSureResetStage, new Action<int>(this.EventShipTowerStageUpdate));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.ShipTowerStageUpdate, new Action<int>(this.EventShipTowerStageUpdate));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.ShipTowerSureCoverChallenge, new Action<int>(this.EventShipTowerStageUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.ShipTowerBuffNewUpdate, new Action(this.UpdateBuffNew));
		Singleton<EventSystem>.Instance.Remove(EEventName.ShipTowerEndlessRecordUpdate, new Action(this.UpdateEndlessRecord));
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.EventOpenView));
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ShipTowerReward, base.GetItem(23), 0);
	}

	// Token: 0x06015649 RID: 87625 RVA: 0x005ED7AC File Offset: 0x005EB9AC
	protected override void OnBeforeShow()
	{
		this.UpdateData();
		int num = 500;
		this.RefreshTimerHandle = TimerSystem.Instance.Forever(new TTimerAction(this.OnTimerRefresh), (float)num, 1f, null, null, true);
		ModelBase<ShipTowerModel>.Instance.CloseWelcomeView();
		this.UpdateRedPoint();
	}

	// Token: 0x0601564A RID: 87626 RVA: 0x005ED7FB File Offset: 0x005EB9FB
	[NullableContext(2)]
	private bool OnPointerBeginDrag(ULGUIPointerEventData eventData)
	{
		this.IsDragging = true;
		return true;
	}

	// Token: 0x0601564B RID: 87627 RVA: 0x005ED805 File Offset: 0x005EBA05
	[NullableContext(2)]
	private bool OnPointerEndDrag(ULGUIPointerEventData eventData)
	{
		this.IsDragging = false;
		return true;
	}

	// Token: 0x0601564C RID: 87628 RVA: 0x005ED810 File Offset: 0x005EBA10
	protected override void OnAfterPlayStartSequence()
	{
		ShipTowerViewParams openParam = this.OpenParam;
		if (openParam != null && openParam.IsOpenStageDesc.GetValueOrDefault())
		{
			return;
		}
		this.CheckNeedShowView();
	}

	// Token: 0x0601564D RID: 87629 RVA: 0x005ED844 File Offset: 0x005EBA44
	private UniTask CheckNeedShowView()
	{
		ShipTowerView.<CheckNeedShowView>d__63 <CheckNeedShowView>d__;
		<CheckNeedShowView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckNeedShowView>d__.<>4__this = this;
		<CheckNeedShowView>d__.<>1__state = -1;
		<CheckNeedShowView>d__.<>t__builder.Start<ShipTowerView.<CheckNeedShowView>d__63>(ref <CheckNeedShowView>d__);
		return <CheckNeedShowView>d__.<>t__builder.Task;
	}

	// Token: 0x0601564E RID: 87630 RVA: 0x005ED888 File Offset: 0x005EBA88
	private UniTask AwaitNeedShowView()
	{
		ShipTowerView.<AwaitNeedShowView>d__64 <AwaitNeedShowView>d__;
		<AwaitNeedShowView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AwaitNeedShowView>d__.<>1__state = -1;
		<AwaitNeedShowView>d__.<>t__builder.Start<ShipTowerView.<AwaitNeedShowView>d__64>(ref <AwaitNeedShowView>d__);
		return <AwaitNeedShowView>d__.<>t__builder.Task;
	}

	// Token: 0x0601564F RID: 87631 RVA: 0x005ED8C3 File Offset: 0x005EBAC3
	private void SetShipTowerMaskLayer(bool isShow)
	{
		Singleton<UiLayer>.Instance.SetShowMaskLayer("ShipTower.CheckNeedShowView", isShow);
	}

	// Token: 0x06015650 RID: 87632 RVA: 0x005ED8D5 File Offset: 0x005EBAD5
	private void EventOpenView(EUiViewName viewName, int _)
	{
		this.SetShipTowerMaskLayer(false);
	}

	// Token: 0x06015651 RID: 87633 RVA: 0x005ED8DE File Offset: 0x005EBADE
	protected override void OnAfterHide()
	{
		this.ClearTimer();
	}

	// Token: 0x06015652 RID: 87634 RVA: 0x005ED8E6 File Offset: 0x005EBAE6
	protected override void OnBeforeDestroy()
	{
		this.UiScrollViewStage.OnScrollValueChange.Unbind();
		this.UiScrollViewStage.OnPointerBeginDragCallBack.Unbind();
		this.UiScrollViewStage.OnPointerEndDragCallBack.Unbind();
		this.UnBindTweenerComplete();
	}

	// Token: 0x06015653 RID: 87635 RVA: 0x005ED91E File Offset: 0x005EBB1E
	protected override void OnAfterDestroy()
	{
	}

	// Token: 0x06015654 RID: 87636 RVA: 0x005ED920 File Offset: 0x005EBB20
	private UniTask InitStageItem()
	{
		ShipTowerView.<InitStageItem>d__70 <InitStageItem>d__;
		<InitStageItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitStageItem>d__.<>4__this = this;
		<InitStageItem>d__.<>1__state = -1;
		<InitStageItem>d__.<>t__builder.Start<ShipTowerView.<InitStageItem>d__70>(ref <InitStageItem>d__);
		return <InitStageItem>d__.<>t__builder.Task;
	}

	// Token: 0x06015655 RID: 87637 RVA: 0x005ED963 File Offset: 0x005EBB63
	private void OnClickBtnBuff()
	{
		ModelBase<ShipTowerModel>.Instance.OpenViewBuff(new ShipTowerBuffViewParams
		{
			OperationType = new EShipTowerBuffOperationType?(EShipTowerBuffOperationType.Preview)
		});
	}

	// Token: 0x06015656 RID: 87638 RVA: 0x005ED980 File Offset: 0x005EBB80
	private void OnClickBtnReward()
	{
		ModelBase<ShipTowerModel>.Instance.OpenViewReward(null);
	}

	// Token: 0x06015657 RID: 87639 RVA: 0x005ED98D File Offset: 0x005EBB8D
	private void OnClickBtnEndlessRecord()
	{
		ModelBase<ShipTowerModel>.Instance.OpenViewRecord(null);
	}

	// Token: 0x06015658 RID: 87640 RVA: 0x005ED99C File Offset: 0x005EBB9C
	private void OnClickBtnLastStage()
	{
		if (this.CurContentPosIsTop())
		{
			return;
		}
		for (int i = 0; i < this.ShowStageCfgList.Count; i++)
		{
			SlashTowerShowStage slashTowerShowStage = this.ShowStageCfgList[i];
			if (slashTowerShowStage.OutIndex + 1 < this.TopStageIndex)
			{
				this.ScrollToIndexOutUp(slashTowerShowStage.OutIndex);
				return;
			}
		}
		this.ScrollToIndexOutUp(0);
	}

	// Token: 0x06015659 RID: 87641 RVA: 0x005ED9FC File Offset: 0x005EBBFC
	private void OnClickBtnNextStage()
	{
		if (this.CurContentPosIsBottom())
		{
			return;
		}
		for (int i = 0; i < this.ShowStageCfgList.Count; i++)
		{
			SlashTowerShowStage slashTowerShowStage = this.ShowStageCfgList[i];
			if (slashTowerShowStage.OutIndex > this.TopStageIndex)
			{
				this.ScrollToIndexOutUp(slashTowerShowStage.OutIndex);
				return;
			}
		}
		this.ScrollToIndexOutUp(this.ShowStageCfgList[this.ShowStageCfgList.Count - 1].OutIndex);
	}

	// Token: 0x0601565A RID: 87642 RVA: 0x005EDA78 File Offset: 0x005EBC78
	private bool CurContentPosIsTop()
	{
		return this.LastScrollValue <= 0.05f;
	}

	// Token: 0x0601565B RID: 87643 RVA: 0x005EDA8A File Offset: 0x005EBC8A
	private bool CurContentPosIsBottom()
	{
		return this.LastScrollValue >= 0.95f;
	}

	// Token: 0x0601565C RID: 87644 RVA: 0x005EDA9C File Offset: 0x005EBC9C
	private void ScrollToIndexOutUp(int index)
	{
		if (!this.IsTweenerComplete)
		{
			return;
		}
		if (ModelBase<ShipTowerModel>.Instance.DebugParallaxSub)
		{
			this.UpdateChangeAreaValue();
		}
		this.UiScrollViewStage.ScrollToDuration = this.ChangeAreaScrollDuration;
		this.UiCureScrollTo = this.UiCureChangeArea;
		this.ScrollToTopByIndex(index, true);
	}

	// Token: 0x0601565D RID: 87645 RVA: 0x005EDAE9 File Offset: 0x005EBCE9
	public void ScrollToIndexFlipPage(int index, bool isUp = true)
	{
		this.UiScrollViewStage.ScrollToDuration = this.FlipPageScrollDuration;
		this.UiCureScrollTo = this.UiCureFlipPage;
		if (isUp)
		{
			this.ScrollToTopByIndex(index, true);
			return;
		}
		this.ScrollToBottomByIndex(index, true);
	}

	// Token: 0x0601565E RID: 87646 RVA: 0x005EDB1C File Offset: 0x005EBD1C
	private int GetShipTowerStageItemIndex(int index)
	{
		int num = 7;
		int max = 18;
		return MathCommon.Clamp(num + index, num, max);
	}

	// Token: 0x0601565F RID: 87647 RVA: 0x005EDB38 File Offset: 0x005EBD38
	private void ScrollToTopByIndex(int index, bool tween = true)
	{
		int shipTowerStageItemIndex = this.GetShipTowerStageItemIndex(index);
		UUIItem item = base.GetItem(shipTowerStageItemIndex);
		UUIItem uuiitem = this.UiScrollViewStage.ContentUIItem.Get();
		FVector2D fvector2D;
		if (uuiitem == null)
		{
			fvector2D = new FVector2D();
		}
		else
		{
			FVector relativeLocation = uuiitem.RelativeLocation;
			fvector2D = new FVector2D(ref relativeLocation);
		}
		FVector2D fvector2D2 = fvector2D;
		this.UiScrollViewStage.StopMovement();
		this.UiScrollViewStage.ScrollToTop(ref fvector2D2, item, tween);
		if (this.UiScrollViewStage.Tweener != null)
		{
			this.UiScrollViewStage.Tweener.SetCurveFloat(this.UiCureScrollTo);
		}
		if (tween)
		{
			this.ScrollTweenerStart();
			this.BindTweenerComplete();
		}
	}

	// Token: 0x06015660 RID: 87648 RVA: 0x005EDBD4 File Offset: 0x005EBDD4
	private void ScrollToBottomByIndex(int index, bool tween = true)
	{
		int shipTowerStageItemIndex = this.GetShipTowerStageItemIndex(index);
		UUIItem item = base.GetItem(shipTowerStageItemIndex);
		UUIItem uuiitem = this.UiScrollViewStage.ContentUIItem.Get();
		FVector2D fvector2D;
		if (uuiitem == null)
		{
			fvector2D = new FVector2D();
		}
		else
		{
			FVector relativeLocation = uuiitem.RelativeLocation;
			fvector2D = new FVector2D(ref relativeLocation);
		}
		FVector2D fvector2D2 = fvector2D;
		this.UiScrollViewStage.StopMovement();
		this.UiScrollViewStage.ScrollToBottom(ref fvector2D2, item, tween);
		if (this.UiScrollViewStage.Tweener != null)
		{
			this.UiScrollViewStage.Tweener.SetCurveFloat(this.UiCureScrollTo);
		}
		if (tween)
		{
			this.ScrollTweenerStart();
			this.BindTweenerComplete();
		}
	}

	// Token: 0x06015661 RID: 87649 RVA: 0x005EDC6D File Offset: 0x005EBE6D
	public void ScrollTweenerStart()
	{
		this.IsTweenerComplete = false;
		this.UiScrollViewStage.SetCanScroll(false);
		this.UiScrollViewStage.SetRayCastTargetForScrollView(false);
		this.SetStageItemClickEnable(false);
	}

	// Token: 0x06015662 RID: 87650 RVA: 0x005EDC98 File Offset: 0x005EBE98
	private void SetStageItemClickEnable(bool enable)
	{
		for (int i = 0; i < this.StageItemList.Count; i++)
		{
			this.StageItemList[i].SetClickEnable(enable);
		}
	}

	// Token: 0x06015663 RID: 87651 RVA: 0x005EDCCD File Offset: 0x005EBECD
	public void ScrollTweenerEnd()
	{
		this.IsTweenerComplete = true;
		this.UiScrollViewStage.SetCanScroll(true);
		this.UiScrollViewStage.SetRayCastTargetForScrollView(true);
		this.SetStageItemClickEnable(true);
	}

	// Token: 0x06015664 RID: 87652 RVA: 0x005EDCF8 File Offset: 0x005EBEF8
	private void BindTweenerComplete()
	{
		if (this.IsBindTweenerComplete)
		{
			return;
		}
		if (this.UiScrollViewStage.Tweener == null)
		{
			return;
		}
		this.IsBindTweenerComplete = true;
		this.UiScrollViewStage.Tweener.OnCompleteCallBack.Bind(new Action(this.TweenerComplete));
	}

	// Token: 0x06015665 RID: 87653 RVA: 0x005EDD44 File Offset: 0x005EBF44
	private void UnBindTweenerComplete()
	{
		this.IsBindTweenerComplete = false;
		ULTweener tweener = this.UiScrollViewStage.Tweener;
		if (tweener == null)
		{
			return;
		}
		tweener.OnCompleteCallBack.Unbind();
	}

	// Token: 0x06015666 RID: 87654 RVA: 0x005EDD67 File Offset: 0x005EBF67
	private void TweenerComplete()
	{
		TimerSystem.Instance.Next(delegate(float delta)
		{
			if (base.IsDestroyOrDestroying)
			{
				return;
			}
			this.ScrollTweenerEnd();
		}, null, null);
	}

	// Token: 0x06015667 RID: 87655 RVA: 0x005EDD84 File Offset: 0x005EBF84
	private void OnScrollValueChange(FVector2D inVector)
	{
		float y = inVector.Y;
		if (y == this.LastScrollValue)
		{
			return;
		}
		this.LastScrollValue = y;
		UUIItem uuiitem = this.UiScrollViewStage.ContentUIItem.Get();
		float num = (uuiitem != null) ? uuiitem.GetAnchorOffsetY() : 0f;
		float addPosY = num - this.ScrollContentLastPosY;
		this.ScrollContentLastPosY = num;
		this.UpdateTopStageIndex(num);
		this.UpdateParallaxItemPos(num);
		this.UpdateGearScroll(addPosY);
		this.UpdateCompassPercent(y);
	}

	// Token: 0x06015668 RID: 87656 RVA: 0x005EDDFC File Offset: 0x005EBFFC
	private void UpdateParallaxItemPos(float posY)
	{
		bool debugParallaxSub = ModelBase<ShipTowerModel>.Instance.DebugParallaxSub;
		for (int i = 0; i < this.ItemParallaxList.Count; i++)
		{
			IParallaxItem parallaxItem = this.ItemParallaxList[i];
			float num = debugParallaxSub ? this.GetValueByDisplayName(parallaxItem.Item, 1, 1f) : parallaxItem.ParallaxSub;
			float anchorOffsetY = parallaxItem.InitPosY + (posY - this.ScrollContentInitPosY) * num;
			parallaxItem.Item.SetAnchorOffsetY(anchorOffsetY);
		}
	}

	// Token: 0x06015669 RID: 87657 RVA: 0x005EDE78 File Offset: 0x005EC078
	public void UpdateGearScroll(float addPosY)
	{
		if (ModelBase<ShipTowerModel>.Instance.DebugParallaxSub)
		{
			this.UpdateGearValue();
		}
		float num = 360f;
		float num2 = addPosY / this.GearLength * num;
		float num3 = addPosY / this.BigGearLength * num;
		this.RotationGear.Yaw = this.RotationGear.Yaw + num2;
		this.RotationBigGear.Yaw = this.RotationBigGear.Yaw - num3;
		this.UiGear.SetUIRelativeRotation(this.RotationGear);
		this.UiBigGear.SetUIRelativeRotation(this.RotationBigGear);
	}

	// Token: 0x0601566A RID: 87658 RVA: 0x005EDF08 File Offset: 0x005EC108
	public void UpdateCompassPercent(float percent)
	{
		if (ModelBase<ShipTowerModel>.Instance.DebugParallaxSub)
		{
			this.UpdateCompassValue();
		}
		float num = this.CompassEndAngle - this.CompassStartAngle;
		float yaw = percent * num + this.CompassStartAngle;
		this.RotationCompass.Yaw = yaw;
		this.UiCompass.SetUIRelativeRotation(this.RotationCompass);
	}

	// Token: 0x0601566B RID: 87659 RVA: 0x005EDF60 File Offset: 0x005EC160
	private void UpdateTopStageIndex(float posY)
	{
		int num = this.TopStageIndex;
		for (int i = 7; i <= 18; i++)
		{
			UUIItem item = base.GetItem(i);
			float height = item.GetHeight();
			float num2 = item.GetStretchTop() + height;
			num = i - 7 + 1;
			if (posY <= num2)
			{
				break;
			}
		}
		if (this.TopStageIndex == num)
		{
			return;
		}
		this.TopStageIndex = num;
		for (int j = 0; j < this.ShowStageCfgList.Count; j++)
		{
			SlashTowerShowStage slashTowerShowStage = this.ShowStageCfgList[j];
			if (slashTowerShowStage.OutIndex >= this.TopStageIndex)
			{
				base.GetText(19).ShowTextNew(slashTowerShowStage.Name);
				return;
			}
		}
	}

	// Token: 0x0601566C RID: 87660 RVA: 0x005EE000 File Offset: 0x005EC200
	public void CheckFlipPage(float addPosY)
	{
		float scrollContentLastPosY = this.ScrollContentLastPosY;
		if (!this.IsTweenerComplete)
		{
			return;
		}
		if (this.LastScrollValue <= 0f || this.LastScrollValue >= 1f)
		{
			return;
		}
		if (this.IsDragging)
		{
			return;
		}
		if (ModelBase<ShipTowerModel>.Instance.DebugParallaxSub)
		{
			this.UpdateFlipPageValue();
		}
		if (Math.Abs(addPosY) > this.FlipPageIntervalDistance)
		{
			return;
		}
		UUIItem uuiitem = this.UiScrollViewStage.RootUIComp.Get();
		float num = (uuiitem != null) ? uuiitem.GetHeight() : 0f;
		for (int i = 0; i < this.ShowStageCfgList.Count; i++)
		{
			SlashTowerShowStage? slashTowerShowStage = (i > 0) ? new SlashTowerShowStage?(this.ShowStageCfgList[i - 1]) : null;
			SlashTowerShowStage slashTowerShowStage2 = this.ShowStageCfgList[i];
			if (slashTowerShowStage != null && slashTowerShowStage.Value.OutIndex + 1 == slashTowerShowStage2.OutIndex)
			{
				this.FlipPageNearStage(slashTowerShowStage.Value.OutIndex - 1, slashTowerShowStage.Value.OutIndex, num, addPosY > 0f);
				return;
			}
			if (this.IsFlipPageUp(slashTowerShowStage2.OutIndex, scrollContentLastPosY))
			{
				return;
			}
			float downContentPosY = scrollContentLastPosY + num;
			if (this.IsFlipPageDown(slashTowerShowStage2.OutIndex - 1, downContentPosY))
			{
				return;
			}
		}
	}

	// Token: 0x0601566D RID: 87661 RVA: 0x005EE160 File Offset: 0x005EC360
	private void FlipPageNearStage(int lastIndex, int nextIndex, float scrollHeight, bool isToDown)
	{
		float scrollContentLastPosY = this.ScrollContentLastPosY;
		float num = scrollContentLastPosY + scrollHeight;
		float stageItemPosY = this.GetStageItemPosY(lastIndex, false);
		float stageItemPosY2 = this.GetStageItemPosY(nextIndex, true);
		if (num < stageItemPosY + this.FlipPageDistanceThreshold * 0.5f)
		{
			return;
		}
		if (num < stageItemPosY2)
		{
			this.ScrollToIndexFlipPage(isToDown ? nextIndex : lastIndex, isToDown);
			return;
		}
		UUIItem uuiitem = this.UiScrollViewStage.ContentUIItem.Get();
		float num2 = (uuiitem != null) ? uuiitem.GetHeight() : 0f;
		if (stageItemPosY2 + scrollHeight >= num2)
		{
			if (num2 - scrollHeight - scrollContentLastPosY < this.FlipPageDistanceThreshold * 0.5f)
			{
				this.ScrollToIndexFlipPage(nextIndex, true);
				return;
			}
			this.ScrollToIndexFlipPage(isToDown ? nextIndex : lastIndex, isToDown);
			return;
		}
		else
		{
			if (scrollContentLastPosY > stageItemPosY2 + this.FlipPageDistanceThreshold * 0.5f)
			{
				return;
			}
			this.ScrollToIndexFlipPage(nextIndex, true);
			return;
		}
	}

	// Token: 0x0601566E RID: 87662 RVA: 0x005EE22C File Offset: 0x005EC42C
	private bool IsFlipPageUp(int index, float contentPosY)
	{
		float stageItemPosY = this.GetStageItemPosY(index, true);
		float flipPageDistanceThreshold = this.FlipPageDistanceThreshold;
		float num = contentPosY - stageItemPosY;
		if (num <= -flipPageDistanceThreshold || num >= flipPageDistanceThreshold)
		{
			return false;
		}
		if (num > -flipPageDistanceThreshold * 0.5f)
		{
			this.ScrollToIndexFlipPage(index, true);
			return true;
		}
		this.ScrollToIndexFlipPage(index - 1, false);
		return true;
	}

	// Token: 0x0601566F RID: 87663 RVA: 0x005EE278 File Offset: 0x005EC478
	private bool IsFlipPageDown(int index, float downContentPosY)
	{
		float stageItemPosY = this.GetStageItemPosY(index, false);
		float num = downContentPosY - stageItemPosY;
		if (num <= -this.FlipPageDistanceThreshold || num >= this.FlipPageDistanceThreshold)
		{
			return false;
		}
		if (num < this.FlipPageDistanceThreshold * 0.5f)
		{
			this.ScrollToIndexFlipPage(index, false);
			return true;
		}
		this.ScrollToIndexFlipPage(index + 1, true);
		return true;
	}

	// Token: 0x06015670 RID: 87664 RVA: 0x005EE2CC File Offset: 0x005EC4CC
	public float GetStageItemPosY(int index, bool isTop = true)
	{
		int shipTowerStageItemIndex = this.GetShipTowerStageItemIndex(index);
		UUIItem item = base.GetItem(shipTowerStageItemIndex);
		float stretchTop = item.GetStretchTop();
		if (!isTop)
		{
			return stretchTop + item.GetHeight();
		}
		return stretchTop;
	}

	// Token: 0x06015671 RID: 87665 RVA: 0x005EE2FD File Offset: 0x005EC4FD
	private void UpdateData()
	{
		this.UpdateEndlessRecord();
		this.UpdateRewardProgress();
		this.UpdateBuffNew();
	}

	// Token: 0x06015672 RID: 87666 RVA: 0x005EE314 File Offset: 0x005EC514
	private void UpdateBuffNew()
	{
		bool uiactive = ModelBase<ShipTowerModel>.Instance.IsExistFirstGetBuff();
		UUIItem item = base.GetItem(28);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x06015673 RID: 87667 RVA: 0x005EE340 File Offset: 0x005EC540
	private void UpdateEndlessRecord()
	{
		bool uiactive = ModelBase<ShipTowerModel>.Instance.IsEndlessRecordOpen();
		UUIButtonComponent button = base.GetButton(2);
		if (button == null)
		{
			return;
		}
		UUIItem uuiitem = button.RootUIComp.Get();
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetUIActive(uiactive);
	}

	// Token: 0x06015674 RID: 87668 RVA: 0x005EE37C File Offset: 0x005EC57C
	private void UpdateRewardProgress()
	{
		string rewardProgressText = ModelBase<ShipTowerModel>.Instance.GetRewardProgressText(true);
		string newText = ModelBase<ShipTowerModel>.Instance.GetCurrentStageSeasonName() + "(" + rewardProgressText + ")";
		base.GetText(3).SetText(newText, true);
		this.UpdateRemainTime();
	}

	// Token: 0x06015675 RID: 87669 RVA: 0x005EE3C4 File Offset: 0x005EC5C4
	private void UpdateRemainTime()
	{
		string rewardCountDownDesc = ModelBase<ShipTowerModel>.Instance.GetRewardCountDownDesc();
		UUIText text = base.GetText(4);
		if (text == null)
		{
			return;
		}
		text.SetText(rewardCountDownDesc, true);
	}

	// Token: 0x06015676 RID: 87670 RVA: 0x005EE3EF File Offset: 0x005EC5EF
	private void OnTimerRefresh(float delta)
	{
		this.UpdateRemainTime();
		if (ModelBase<ShipTowerModel>.Instance.TimeIsOver())
		{
			this.ClearTimer();
			ModelBase<ShipTowerModel>.Instance.CheckIsNeedShowConfirmSeasonUpdate(null);
		}
	}

	// Token: 0x06015677 RID: 87671 RVA: 0x005EE415 File Offset: 0x005EC615
	private void ClearTimer()
	{
		if (this.RefreshTimerHandle != null)
		{
			TimerSystem.Instance.Remove(this.RefreshTimerHandle);
			this.RefreshTimerHandle = null;
		}
	}

	// Token: 0x06015678 RID: 87672 RVA: 0x005EE438 File Offset: 0x005EC638
	private void CloseCallBack()
	{
		ShipTowerViewParams openParam = this.OpenParam;
		if (openParam != null && openParam.IsFromInstanceDungeon.GetValueOrDefault())
		{
			ModelBase<ShipTowerModel>.Instance.OpenConfirmBackWorld();
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x06015679 RID: 87673 RVA: 0x005EE473 File Offset: 0x005EC673
	private void EventRewardReceive(int _)
	{
		this.UpdateRewardProgress();
	}

	// Token: 0x0601567A RID: 87674 RVA: 0x005EE47C File Offset: 0x005EC67C
	private void EventShipTowerStageUpdate(int id)
	{
		ShipTowerStageItemBase shipTowerStageItemBase;
		if (this.StageItemMap.TryGetValue(id, out shipTowerStageItemBase))
		{
			shipTowerStageItemBase.UpdateData();
		}
	}

	// Token: 0x0601567B RID: 87675 RVA: 0x005EE49F File Offset: 0x005EC69F
	private void OnHelpClick()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(201);
	}

	// Token: 0x0601567C RID: 87676 RVA: 0x005EE4B0 File Offset: 0x005EC6B0
	private void UpdateRedPoint()
	{
		ServerStorageNumber serverStorageNumber = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.ShipTowerSeason) as ServerStorageNumber;
		if (serverStorageNumber != null)
		{
			serverStorageNumber.Set(new int?(ModelBase<ShipTowerModel>.Instance.CurSeason));
		}
		ActivityShipTowerController instance = ControllerBase<ActivityShipTowerController>.Instance;
		int? num;
		if (instance == null)
		{
			num = null;
		}
		else
		{
			ActivityShipTowerData data = instance.Data;
			num = ((data != null) ? new int?(data.Id) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault();
		if (valueOrDefault > 0)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, valueOrDefault);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotAdventurePeriodicityTabUpdate);
		ActivityShipTowerController instance2 = ControllerBase<ActivityShipTowerController>.Instance;
		bool? flag;
		if (instance2 == null)
		{
			flag = null;
		}
		else
		{
			ActivityShipTowerData data2 = instance2.Data;
			flag = ((data2 != null) ? new bool?(data2.RedPointShowState) : null);
		}
		bool? flag2 = flag;
		bool valueOrDefault2 = flag2.GetValueOrDefault();
		ModelBase<AdventureGuideModel>.Instance.ReportPeriodicActivityRedClear(EDungeonSubType.ShipTower, valueOrDefault2);
	}

	// Token: 0x0400A4A3 RID: 42147
	private const string MASK_LAYER_TAG = "ShipTower.CheckNeedShowView";

	// Token: 0x0400A4A4 RID: 42148
	[Nullable(2)]
	private PopupCaptionItem PopupCaption;

	// Token: 0x0400A4A5 RID: 42149
	public UUIScrollViewWithScrollbarComponent UiScrollViewStage;

	// Token: 0x0400A4A6 RID: 42150
	private UUIItem UiItemParallaxRoot;

	// Token: 0x0400A4A7 RID: 42151
	private readonly List<IParallaxItem> ItemParallaxList = new List<IParallaxItem>();

	// Token: 0x0400A4A8 RID: 42152
	private float LastScrollValue = 0.001f;

	// Token: 0x0400A4A9 RID: 42153
	private float ScrollContentInitPosY;

	// Token: 0x0400A4AA RID: 42154
	private float ScrollContentLastPosY;

	// Token: 0x0400A4AB RID: 42155
	private IReadOnlyList<SlashTowerShowStage> ShowStageCfgList;

	// Token: 0x0400A4AC RID: 42156
	private int TopStageIndex;

	// Token: 0x0400A4AD RID: 42157
	private readonly Dictionary<int, ShipTowerStageItemBase> StageItemMap = new Dictionary<int, ShipTowerStageItemBase>();

	// Token: 0x0400A4AE RID: 42158
	private readonly List<ShipTowerStageItemBase> StageItemList = new List<ShipTowerStageItemBase>();

	// Token: 0x0400A4AF RID: 42159
	[Nullable(2)]
	private TimerHandle RefreshTimerHandle;

	// Token: 0x0400A4B0 RID: 42160
	[Nullable(2)]
	public UCurveFloat UiCureChangeArea;

	// Token: 0x0400A4B1 RID: 42161
	public float ChangeAreaScrollDuration;

	// Token: 0x0400A4B2 RID: 42162
	[Nullable(2)]
	public UCurveFloat UiCureFlipPage;

	// Token: 0x0400A4B3 RID: 42163
	[Nullable(2)]
	public UCurveFloat UiCureScrollTo;

	// Token: 0x0400A4B4 RID: 42164
	public float FlipPageDistanceThreshold;

	// Token: 0x0400A4B5 RID: 42165
	public float FlipPageScrollDuration;

	// Token: 0x0400A4B6 RID: 42166
	public float FlipPageIntervalDistance;

	// Token: 0x0400A4B7 RID: 42167
	private UUIItem UiCompassRoot;

	// Token: 0x0400A4B8 RID: 42168
	private UUISprite UiGear;

	// Token: 0x0400A4B9 RID: 42169
	private UUISprite UiBigGear;

	// Token: 0x0400A4BA RID: 42170
	private UUISprite UiCompass;

	// Token: 0x0400A4BB RID: 42171
	private float GearLength;

	// Token: 0x0400A4BC RID: 42172
	private float BigGearLength;

	// Token: 0x0400A4BD RID: 42173
	private float CompassStartAngle;

	// Token: 0x0400A4BE RID: 42174
	private float CompassEndAngle;

	// Token: 0x0400A4BF RID: 42175
	private FRotator RotationCompass = new FRotator(0f, 0f, 0f);

	// Token: 0x0400A4C0 RID: 42176
	private FRotator RotationGear = new FRotator(0f, 0f, 0f);

	// Token: 0x0400A4C1 RID: 42177
	private FRotator RotationBigGear = new FRotator(0f, 0f, 0f);

	// Token: 0x0400A4C2 RID: 42178
	private bool IsBindTweenerComplete;

	// Token: 0x0400A4C3 RID: 42179
	private bool IsTweenerComplete = true;

	// Token: 0x0400A4C4 RID: 42180
	private bool IsDragging;

	// Token: 0x02008D5A RID: 36186
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F87B RID: 194683
		public const int ItemCaption = 0;

		// Token: 0x0402F87C RID: 194684
		public const int BtnBuff = 1;

		// Token: 0x0402F87D RID: 194685
		public const int BtnEndlessRecord = 2;

		// Token: 0x0402F87E RID: 194686
		public const int TxtRewardProgress = 3;

		// Token: 0x0402F87F RID: 194687
		public const int TxtCountDownTime = 4;

		// Token: 0x0402F880 RID: 194688
		public const int BtnLastStage = 5;

		// Token: 0x0402F881 RID: 194689
		public const int BtnNextStage = 6;

		// Token: 0x0402F882 RID: 194690
		public const int ItemOneTimeStage1 = 7;

		// Token: 0x0402F883 RID: 194691
		public const int ItemOneTimeStage2 = 8;

		// Token: 0x0402F884 RID: 194692
		public const int ItemOneTimeStage3 = 9;

		// Token: 0x0402F885 RID: 194693
		public const int ItemOneTimeStage4 = 10;

		// Token: 0x0402F886 RID: 194694
		public const int ItemOneTimeStage5 = 11;

		// Token: 0x0402F887 RID: 194695
		public const int ItemOneTimeStage6 = 12;

		// Token: 0x0402F888 RID: 194696
		public const int ItemRefreshStage1 = 13;

		// Token: 0x0402F889 RID: 194697
		public const int ItemRefreshStage2 = 14;

		// Token: 0x0402F88A RID: 194698
		public const int ItemRefreshStage3 = 15;

		// Token: 0x0402F88B RID: 194699
		public const int ItemRefreshStage4 = 16;

		// Token: 0x0402F88C RID: 194700
		public const int ItemRefreshStage5 = 17;

		// Token: 0x0402F88D RID: 194701
		public const int ItemEndlessStage = 18;

		// Token: 0x0402F88E RID: 194702
		public const int TxtCurrentArea = 19;

		// Token: 0x0402F88F RID: 194703
		public const int ItemParallaxRoot = 20;

		// Token: 0x0402F890 RID: 194704
		public const int ScrollViewStage = 21;

		// Token: 0x0402F891 RID: 194705
		public const int BtnReward = 22;

		// Token: 0x0402F892 RID: 194706
		public const int ItemRewardRedDot = 23;

		// Token: 0x0402F893 RID: 194707
		public const int ItemCompassRoot = 24;

		// Token: 0x0402F894 RID: 194708
		public const int SpriteBigGear = 25;

		// Token: 0x0402F895 RID: 194709
		public const int SpriteGear = 26;

		// Token: 0x0402F896 RID: 194710
		public const int SpriteCompass = 27;

		// Token: 0x0402F897 RID: 194711
		public const int ItemBuffNew = 28;
	}
}
