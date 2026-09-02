using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B50 RID: 11088
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueMainView : UiTickViewBase
{
	// Token: 0x060161A8 RID: 90536 RVA: 0x00621E64 File Offset: 0x00620064
	public SurvivorsRogueMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060161A9 RID: 90537 RVA: 0x00621F78 File Offset: 0x00620178
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(10, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(11, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIText)),
			new ValueTuple<int, Type>(22, typeof(USpineSkeletonAnimationComponent)),
			new ValueTuple<int, Type>(25, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action(this.OnClickedBtnUp)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnClickedBtnDown))
		};
	}

	// Token: 0x060161AA RID: 90538 RVA: 0x006221EC File Offset: 0x006203EC
	protected override UniTask OnCreateAsync()
	{
		SurvivorsRogueMainView.<OnCreateAsync>d__33 <OnCreateAsync>d__;
		<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCreateAsync>d__.<>4__this = this;
		<OnCreateAsync>d__.<>1__state = -1;
		<OnCreateAsync>d__.<>t__builder.Start<SurvivorsRogueMainView.<OnCreateAsync>d__33>(ref <OnCreateAsync>d__);
		return <OnCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060161AB RID: 90539 RVA: 0x00622230 File Offset: 0x00620430
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRogueMainView.<OnBeforeStartAsync>d__34 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueMainView.<OnBeforeStartAsync>d__34>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060161AC RID: 90540 RVA: 0x00622273 File Offset: 0x00620473
	protected override void OnStart()
	{
		this.ScrollViewComp.OnLateUpdate.Bind(delegate(float _)
		{
			this.InitCurSelectPos();
			this.ScrollViewComp.OnLateUpdate.Unbind();
		});
	}

	// Token: 0x060161AD RID: 90541 RVA: 0x00622291 File Offset: 0x00620491
	protected override void OnBeforeShow()
	{
		ControllerBase<SplashScreenController>.Instance.FinishCurTask(ESplashScreenSourceModuleType.None);
		this.RefreshFunctionButton();
		this.RefreshLevelInfo();
		Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(true, "");
		ControllerBase<SurvivorsActivityController>.Instance.CheckIsActivityClose();
	}

	// Token: 0x060161AE RID: 90542 RVA: 0x006222C4 File Offset: 0x006204C4
	protected override void OnAfterShow()
	{
		ControllerBase<SurvivorsRogueController>.Instance.TryOpenWeaponUnlockView().ContinueWith(delegate(bool isOpen)
		{
			if (!isOpen)
			{
				this.StartLevelUnlockFlow();
			}
		});
	}

	// Token: 0x060161AF RID: 90543 RVA: 0x006222E4 File Offset: 0x006204E4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.SurvivorsInstSettle, new Action<bool>(this.OnSurvivorsInstSettle));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
		Singleton<EventSystem>.Instance.Add(EEventName.ActivityCrossDayRefresh, new Action(this.OnActivityCrossDay));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnViewClose));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.SurvivorsRogueTalentNodeUpdate, new Action<int>(this.OnSurvivorsRogueTalentNodeUpdate));
	}

	// Token: 0x060161B0 RID: 90544 RVA: 0x0062237C File Offset: 0x0062057C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SurvivorsInstSettle, new Action<bool>(this.OnSurvivorsInstSettle));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
		Singleton<EventSystem>.Instance.Remove(EEventName.ActivityCrossDayRefresh, new Action(this.OnActivityCrossDay));
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnViewClose));
		Singleton<EventSystem>.Instance.Remove(EEventName.SurvivorsRogueTalentNodeUpdate, new Action<int>(this.OnSurvivorsRogueTalentNodeUpdate));
	}

	// Token: 0x060161B1 RID: 90545 RVA: 0x00622414 File Offset: 0x00620614
	protected override void OnBeforeDestroy()
	{
		this.ItemParallaxList.Clear();
		this.ScrollViewComp.OnScrollValueChange.Unbind();
		this.ScrollViewComp.OnPointerBeginDragCallBack.Unbind();
		this.ScrollViewComp.OnPointerEndDragCallBack.Unbind();
		USpineSkeletonAnimationComponent spine = base.GetSpine(22);
		if (spine != null)
		{
			spine.AnimationComplete.Remove(new Action<UTrackEntry>(this.OnAnimationComplete));
		}
		this.UnBindTweenerComplete();
	}

	// Token: 0x060161B2 RID: 90546 RVA: 0x00622488 File Offset: 0x00620688
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<UCurveFloat> LoadCurveFloat(string resId)
	{
		SurvivorsRogueMainView.<LoadCurveFloat>d__41 <LoadCurveFloat>d__;
		<LoadCurveFloat>d__.<>t__builder = AsyncUniTaskMethodBuilder<UCurveFloat>.Create();
		<LoadCurveFloat>d__.resId = resId;
		<LoadCurveFloat>d__.<>1__state = -1;
		<LoadCurveFloat>d__.<>t__builder.Start<SurvivorsRogueMainView.<LoadCurveFloat>d__41>(ref <LoadCurveFloat>d__);
		return <LoadCurveFloat>d__.<>t__builder.Task;
	}

	// Token: 0x060161B3 RID: 90547 RVA: 0x006224CC File Offset: 0x006206CC
	protected override void OnTick(float delta)
	{
		foreach (SurvivorsLevelInfoItem survivorsLevelInfoItem in this.LevelInfoItemMap.Values)
		{
			survivorsLevelInfoItem.OnTick(delta);
		}
	}

	// Token: 0x060161B4 RID: 90548 RVA: 0x00622524 File Offset: 0x00620724
	private void OnRefreshRedDot(int activityId)
	{
		if (this.ActivityDataBase.Id != activityId)
		{
			return;
		}
		this.RefreshFunctionButton();
	}

	// Token: 0x060161B5 RID: 90549 RVA: 0x0062253C File Offset: 0x0062073C
	private void OnActivityCrossDay()
	{
		this.RefreshFunctionButton();
		List<int> allLevelId = this.ActivityDataBase.GetAllLevelId();
		for (int i = allLevelId.Count - 1; i >= 0; i--)
		{
			int num = allLevelId[i];
			ISurvivorsLevelInfo currentLevelInfoByLevelId = this.ActivityDataBase.GetCurrentLevelInfoByLevelId(num);
			SurvivorsLevelItem survivorsLevelItem;
			SurvivorsLevelInfoItem survivorsLevelInfoItem;
			if (this.LevelItemMap.TryGetValue(num, out survivorsLevelItem) && this.LevelInfoItemMap.TryGetValue(num, out survivorsLevelInfoItem) && currentLevelInfoByLevelId != null)
			{
				survivorsLevelItem.Refresh(num, currentLevelInfoByLevelId.IsEndlessMode);
				survivorsLevelInfoItem.Refresh(currentLevelInfoByLevelId, false, i);
			}
		}
	}

	// Token: 0x060161B6 RID: 90550 RVA: 0x006225BE File Offset: 0x006207BE
	private void OnViewClose(EUiViewName viewName, int viewId)
	{
		if (viewName != EUiViewName.SurvivorsWeaponUnlockView)
		{
			return;
		}
		this.StartLevelUnlockFlow();
	}

	// Token: 0x060161B7 RID: 90551 RVA: 0x006225D4 File Offset: 0x006207D4
	private void OnSurvivorsRogueTalentNodeUpdate(int nodeId)
	{
		this.RefreshFunctionButton();
	}

	// Token: 0x060161B8 RID: 90552 RVA: 0x006225DC File Offset: 0x006207DC
	private void InitScrollView()
	{
		this.ScrollViewComp = base.GetScrollViewWithScrollbar(2);
		this.ScrollViewComp.ScrollToEaseType = LTweenEase.CurveFloat;
		this.ScrollViewComp.OnScrollValueChange.Bind(new Action<FVector2D>(this.OnScrollValueChange));
		this.ScrollViewComp.OnPointerBeginDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnPointerBeginDrag));
		this.ScrollViewComp.OnPointerEndDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnPointerEndDrag));
		this.ScrollContentInitPosY = this.ScrollViewComp.ContentUIItem.Get().GetAnchorOffsetY();
		this.ScrollContentLastPosY = this.ScrollContentInitPosY;
		this.CenterAreaHalfHeight = 100f;
		this.CenterPosY = this.ScrollViewComp.RootUIComp.Get().GetHeight() / 2f;
	}

	// Token: 0x060161B9 RID: 90553 RVA: 0x006226B0 File Offset: 0x006208B0
	private void InitParallaxItem()
	{
		TWeakObjectPtr<UUIItem> contentUIItem = base.GetScrollViewWithScrollbar(1).ContentUIItem;
		SurvivorsRogueParallaxItem item = new SurvivorsRogueParallaxItem
		{
			Item = contentUIItem,
			InitPosY = contentUIItem.Get().GetAnchorOffsetY(),
			ParallaxFactor = this.BackgroundParallaxFactor
		};
		this.ItemParallaxList.Add(item);
	}

	// Token: 0x060161BA RID: 90554 RVA: 0x00622708 File Offset: 0x00620908
	private void InitCurSelectPos()
	{
		int levelId = this.LevelInfo.LevelId;
		if (levelId != 0)
		{
			this.ScrollLevelIdToCenter(levelId);
		}
		else
		{
			int focusLevelId = this.ActivityDataBase.GetFocusLevelId();
			this.ScrollLevelIdToCenter(focusLevelId);
		}
		foreach (SurvivorsLevelInfoItem survivorsLevelInfoItem in this.LevelInfoItemMap.Values)
		{
			survivorsLevelInfoItem.SetSaveFile(this.LevelInfo);
		}
	}

	// Token: 0x060161BB RID: 90555 RVA: 0x00622790 File Offset: 0x00620990
	private bool OnPointerBeginDrag(ULGUIPointerEventData _)
	{
		this.IsDragging = true;
		return true;
	}

	// Token: 0x060161BC RID: 90556 RVA: 0x0062279A File Offset: 0x0062099A
	private bool OnPointerEndDrag(ULGUIPointerEventData _)
	{
		this.IsDragging = false;
		this.StartElasticMovement = true;
		return true;
	}

	// Token: 0x060161BD RID: 90557 RVA: 0x006227AC File Offset: 0x006209AC
	private void OnScrollValueChange(FVector2D inVector)
	{
		float y = inVector.Y;
		if (Math.Abs(y - this.LastScrollValue) < 1E-45f)
		{
			return;
		}
		this.LastScrollValue = y;
		float anchorOffsetY = this.ScrollViewComp.ContentUIItem.Get().GetAnchorOffsetY();
		this.ScrollContentLastPosY = anchorOffsetY;
		this.UpdateCurrentDiffArea(anchorOffsetY);
		this.UpdateParallaxItemPos(anchorOffsetY);
		this.UpdateLevelInfoPos();
		if (this.StartElasticMovement && Math.Abs(this.ScrollViewComp.GetVelocity().Y) < this.AutoAttachVelocityY)
		{
			SurvivorsRogueDiffAreaInfo survivorsRogueDiffAreaInfo = this.DiffAreaUiInfoList[this.CurrentDiff];
			this.ScrollLevelIdToBottom(survivorsRogueDiffAreaInfo.LowerBoundLevelId, true);
			this.StartElasticMovement = false;
		}
	}

	// Token: 0x060161BE RID: 90558 RVA: 0x0062285C File Offset: 0x00620A5C
	private void UpdateParallaxItemPos(float posY)
	{
		for (int i = 0; i < this.ItemParallaxList.Count; i++)
		{
			SurvivorsRogueParallaxItem survivorsRogueParallaxItem = this.ItemParallaxList[i];
			float val = survivorsRogueParallaxItem.InitPosY + (posY - this.ScrollContentInitPosY) * survivorsRogueParallaxItem.ParallaxFactor;
			survivorsRogueParallaxItem.Item.SetAnchorOffsetY(Math.Max(0f, val));
		}
	}

	// Token: 0x060161BF RID: 90559 RVA: 0x006228BC File Offset: 0x00620ABC
	protected void ScrollLevelIdToBottom(int levelId, bool tween = true)
	{
		SurvivorsLevelItem survivorsLevelItem;
		if (!this.LevelItemMap.TryGetValue(levelId, out survivorsLevelItem))
		{
			return;
		}
		FVector relativeLocation = this.ScrollViewComp.ContentUIItem.Get().RelativeLocation;
		FVector2D fvector2D = new FVector2D(ref relativeLocation);
		UUIItem bottomPosItem = survivorsLevelItem.GetBottomPosItem();
		this.ScrollViewComp.StopMovement();
		if (tween)
		{
			this.ScrollTweenerStart();
		}
		this.ScrollViewComp.ScrollToBottom(ref fvector2D, bottomPosItem, tween);
		if (tween && this.ScrollViewComp.Tweener != null)
		{
			this.ScrollViewComp.Tweener.SetDuration(this.ChangeAreaDuration);
			this.ScrollViewComp.Tweener.SetCurveFloat(this.UiCurveAreaMove);
			this.BindTweenerComplete();
		}
	}

	// Token: 0x060161C0 RID: 90560 RVA: 0x0062296C File Offset: 0x00620B6C
	protected void ScrollLevelIdToCenter(int levelId)
	{
		SurvivorsLevelItem survivorsLevelItem;
		if (!this.LevelItemMap.TryGetValue(levelId, out survivorsLevelItem))
		{
			return;
		}
		float num = -survivorsLevelItem.GetOriginalItem().GetAnchorOffsetY() - this.CenterPosY;
		if (num <= 0f)
		{
			return;
		}
		this.TempVector2D.Reset();
		this.TempVector2D.Y = (double)num;
		this.ScrollViewComp.StopMovement();
		this.ScrollViewComp.ContentUIItem.Get().SetAnchorOffset(this.TempVector2D.ToUeVector2D(false));
	}

	// Token: 0x060161C1 RID: 90561 RVA: 0x006229EE File Offset: 0x00620BEE
	private void ScrollTweenerStart()
	{
		this.IsTweenerComplete = false;
		this.ScrollViewComp.SetRayCastTargetForScrollView(false);
		this.SetLevelItemInteractive(false);
	}

	// Token: 0x060161C2 RID: 90562 RVA: 0x00622A0A File Offset: 0x00620C0A
	protected void ScrollTweenerEnd()
	{
		this.IsTweenerComplete = true;
		this.ScrollViewComp.SetRayCastTargetForScrollView(true);
		this.SetLevelItemInteractive(true);
	}

	// Token: 0x060161C3 RID: 90563 RVA: 0x00622A28 File Offset: 0x00620C28
	private void BindTweenerComplete()
	{
		if (this.IsBindTweenerComplete)
		{
			return;
		}
		if (this.ScrollViewComp.Tweener == null)
		{
			return;
		}
		this.IsBindTweenerComplete = true;
		this.ScrollViewComp.Tweener.OnCompleteCallBack.Bind(new Action(this.TweenerComplete));
	}

	// Token: 0x060161C4 RID: 90564 RVA: 0x00622A74 File Offset: 0x00620C74
	private void UnBindTweenerComplete()
	{
		this.IsBindTweenerComplete = false;
		ULTweener tweener = this.ScrollViewComp.Tweener;
		if (tweener == null)
		{
			return;
		}
		tweener.OnCompleteCallBack.Unbind();
	}

	// Token: 0x060161C5 RID: 90565 RVA: 0x00622A97 File Offset: 0x00620C97
	private void TweenerComplete()
	{
		if (base.IsDestroyOrDestroying)
		{
			return;
		}
		this.ScrollTweenerEnd();
	}

	// Token: 0x060161C6 RID: 90566 RVA: 0x00622AA8 File Offset: 0x00620CA8
	private bool IsTopArea()
	{
		return this.CurrentDiff == 2;
	}

	// Token: 0x060161C7 RID: 90567 RVA: 0x00622AB3 File Offset: 0x00620CB3
	private bool IsBottomArea()
	{
		return this.CurrentDiff == 0;
	}

	// Token: 0x060161C8 RID: 90568 RVA: 0x00622AC0 File Offset: 0x00620CC0
	private UniTask InitAllLevel()
	{
		SurvivorsRogueMainView.<InitAllLevel>d__63 <InitAllLevel>d__;
		<InitAllLevel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitAllLevel>d__.<>4__this = this;
		<InitAllLevel>d__.<>1__state = -1;
		<InitAllLevel>d__.<>t__builder.Start<SurvivorsRogueMainView.<InitAllLevel>d__63>(ref <InitAllLevel>d__);
		return <InitAllLevel>d__.<>t__builder.Task;
	}

	// Token: 0x060161C9 RID: 90569 RVA: 0x00622B04 File Offset: 0x00620D04
	private unsafe void InitDiffArea()
	{
		Span<int> areaBoundLevelIdBytes = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsActivityConfigByActivityId(this.ActivityDataBase.Id).Value.GetAreaBoundLevelIdBytes();
		float num = this.ScrollViewComp.RootUIComp.Get().GetHeight() * this.AreaBottomScale;
		for (int i = 0; i < areaBoundLevelIdBytes.Length; i++)
		{
			int num2 = *areaBoundLevelIdBytes[i];
			UUIItem originalItem = this.LevelItemMap[num2].GetOriginalItem();
			float height = originalItem.GetHeight();
			float anchorOffsetY = originalItem.GetAnchorOffsetY();
			SurvivorsRogueDiffAreaInfo item = new SurvivorsRogueDiffAreaInfo
			{
				Diff = ESurvivorsLevelDiff.Easy + i,
				LowerBoundLevelId = num2,
				LowerBoundPosY = anchorOffsetY - height + num
			};
			this.DiffAreaUiInfoList.Add(item);
		}
		this.CurrentUnlockDiff = (int)this.ActivityDataBase.GetCurrentUnlockDiffId();
		string animationName = this.diffIdToleSpineName[this.CurrentUnlockDiff];
		base.GetSpine(22).AnimationComplete.Add(new Action<UTrackEntry>(this.OnAnimationComplete));
		base.GetSpine(22).SetAnimation(0, animationName, true);
	}

	// Token: 0x060161CA RID: 90570 RVA: 0x00622C20 File Offset: 0x00620E20
	[NullableContext(2)]
	private void OnAnimationComplete(UTrackEntry entry)
	{
		if (entry == null)
		{
			return;
		}
		string animationName = entry.getAnimationName();
		int num = Array.IndexOf<string>(this.diffIdUnlockToSpineName, animationName);
		if (num != -1)
		{
			USpineSkeletonAnimationComponent spine = base.GetSpine(22);
			if (spine == null)
			{
				return;
			}
			spine.SetAnimation(0, this.diffIdToleSpineName[num], true);
		}
	}

	// Token: 0x060161CB RID: 90571 RVA: 0x00622C68 File Offset: 0x00620E68
	private void UpdateLevelInfoPos()
	{
		foreach (KeyValuePair<int, SurvivorsLevelItem> keyValuePair in this.LevelItemMap)
		{
			int key = keyValuePair.Key;
			FVectorDouble newLocation = keyValuePair.Value.GetRootActor().D_K2_GetActorLocation();
			SurvivorsLevelInfoItem survivorsLevelInfoItem;
			if (this.LevelInfoItemMap.TryGetValue(key, out survivorsLevelInfoItem))
			{
				FHitResult fhitResult = new FHitResult();
				survivorsLevelInfoItem.GetRootActor().D_K2_SetActorLocation(newLocation, false, ref fhitResult, false);
			}
		}
	}

	// Token: 0x060161CC RID: 90572 RVA: 0x00622CF8 File Offset: 0x00620EF8
	private void UpdateCurrentDiffArea(float posY)
	{
		ESurvivorsLevelDiff esurvivorsLevelDiff = ESurvivorsLevelDiff.Easy;
		for (int i = 1; i < this.DiffAreaUiInfoList.Count; i++)
		{
			SurvivorsRogueDiffAreaInfo survivorsRogueDiffAreaInfo = this.DiffAreaUiInfoList[i];
			float lowerBoundPosY = survivorsRogueDiffAreaInfo.LowerBoundPosY;
			if (posY + lowerBoundPosY > 0f)
			{
				break;
			}
			esurvivorsLevelDiff = survivorsRogueDiffAreaInfo.Diff;
		}
		if (this.CurrentDiff == (int)esurvivorsLevelDiff)
		{
			return;
		}
		this.GetDiffToggle((ESurvivorsLevelDiff)this.CurrentDiff).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.CurrentDiff = (int)esurvivorsLevelDiff;
		this.RefreshCurrentDiffInfo();
	}

	// Token: 0x060161CD RID: 90573 RVA: 0x00622D70 File Offset: 0x00620F70
	private void RefreshCurrentDiffInfo()
	{
		UUIText text = base.GetText(21);
		string textStringId = string.Empty;
		switch (this.CurrentDiff)
		{
		case 0:
			textStringId = "SurvivorsLevelSimple_TagName";
			break;
		case 1:
			textStringId = "SurvivorsLevelOrdinary_TagName";
			break;
		case 2:
			textStringId = "SurvivorsLevelDifficult_TagName";
			break;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
		this.GetDiffToggle((ESurvivorsLevelDiff)this.CurrentDiff).SetToggleState(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x060161CE RID: 90574 RVA: 0x00622DE4 File Offset: 0x00620FE4
	protected int GetNearestCenterLevelId()
	{
		int result = 0;
		int maxValue = int.MaxValue;
		float anchorOffsetY = this.ScrollViewComp.ContentUIItem.Get().GetAnchorOffsetY();
		float num = anchorOffsetY - this.CenterAreaHalfHeight;
		float num2 = anchorOffsetY + this.CenterAreaHalfHeight;
		foreach (KeyValuePair<int, SurvivorsLevelItem> keyValuePair in this.LevelItemMap)
		{
			int key = keyValuePair.Key;
			UUIItem originalItem = keyValuePair.Value.GetOriginalItem();
			float height = originalItem.GetHeight();
			float anchorOffsetY2 = originalItem.GetAnchorOffsetY();
			float num3 = height - anchorOffsetY2 - this.CenterPosY;
			if (num <= num3 && num3 <= num2 && Math.Abs(num3 - this.CenterPosY) < (float)maxValue)
			{
				result = key;
			}
		}
		return result;
	}

	// Token: 0x060161CF RID: 90575 RVA: 0x00622EB8 File Offset: 0x006210B8
	private UUIExtendToggle GetDiffToggle(ESurvivorsLevelDiff diff)
	{
		switch (diff)
		{
		case ESurvivorsLevelDiff.Easy:
			return base.GetExtendToggle(11);
		case ESurvivorsLevelDiff.Normal:
			return base.GetExtendToggle(10);
		case ESurvivorsLevelDiff.Challenge:
			return base.GetExtendToggle(9);
		default:
			return base.GetExtendToggle(10);
		}
	}

	// Token: 0x060161D0 RID: 90576 RVA: 0x00622EF4 File Offset: 0x006210F4
	private void SetLevelItemInteractive(bool enable)
	{
		foreach (SurvivorsLevelItem survivorsLevelItem in this.LevelItemMap.Values)
		{
			survivorsLevelItem.SetButtonInteractive(enable);
		}
	}

	// Token: 0x060161D1 RID: 90577 RVA: 0x00622F4C File Offset: 0x0062114C
	private void StartLevelUnlockFlow()
	{
		bool flag = false;
		foreach (KeyValuePair<int, SurvivorsLevelInfoItem> keyValuePair in this.LevelInfoItemMap)
		{
			int key = keyValuePair.Key;
			SurvivorsLevelInfoItem value = keyValuePair.Value;
			bool flag2 = this.ActivityDataBase.TryRemoveLevelNewUnlock(key, false);
			bool flag3 = this.ActivityDataBase.TryRemoveLevelNewUnlock(key, true);
			bool flag4 = this.ActivityDataBase.TryRemoveLevelNewFinished(key);
			if (flag3)
			{
				value.PlaySequenceByName(ESurvivorsLevelInfoSeqName.EndlessOpen);
				flag = true;
			}
			else if (flag2)
			{
				value.PlaySequenceByName(ESurvivorsLevelInfoSeqName.Unlock);
				flag = true;
			}
			else if (flag4)
			{
				value.PlaySequenceByName(ESurvivorsLevelInfoSeqName.Complete);
			}
		}
		if (flag)
		{
			this.ActivityDataBase.RefreshActivityRedDot();
		}
		if (this.ActivityDataBase.IsEndlessFirstOpenCheck())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SurvivorsLevelSelection_EndlessTips", Array.Empty<object>());
		}
		int currentUnlockDiffId = (int)this.ActivityDataBase.GetCurrentUnlockDiffId();
		if (currentUnlockDiffId > this.CurrentUnlockDiff)
		{
			this.CurrentUnlockDiff = currentUnlockDiffId;
			string animationName = this.diffIdUnlockToSpineName[this.CurrentUnlockDiff];
			base.GetSpine(22).SetAnimation(0, animationName, false);
		}
		Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(false, "");
	}

	// Token: 0x060161D2 RID: 90578 RVA: 0x00623090 File Offset: 0x00621290
	private void RefreshLevelInfo()
	{
		int num = this.LevelItemMap.Count;
		foreach (KeyValuePair<int, SurvivorsLevelItem> keyValuePair in this.LevelItemMap)
		{
			int key = keyValuePair.Key;
			SurvivorsLevelItem value = keyValuePair.Value;
			ISurvivorsLevelInfo currentLevelInfoByLevelId = this.ActivityDataBase.GetCurrentLevelInfoByLevelId(key);
			SurvivorsLevelInfoItem survivorsLevelInfoItem;
			if (this.LevelInfoItemMap.TryGetValue(key, out survivorsLevelInfoItem) && currentLevelInfoByLevelId != null)
			{
				value.Refresh(key, currentLevelInfoByLevelId.IsEndlessMode);
				survivorsLevelInfoItem.Refresh(currentLevelInfoByLevelId, false, num);
				num--;
			}
		}
	}

	// Token: 0x060161D3 RID: 90579 RVA: 0x0062313C File Offset: 0x0062133C
	private void RefreshFunctionButton()
	{
		string text = this.ActivityDataBase.GetFinishedRewardTaskCount().ToString();
		string text2 = this.ActivityDataBase.RewardTaskMap.Count.ToString();
		this.ButtonReward.SetDescText("SurvivorsReward", new string[]
		{
			text,
			text2
		});
		this.ButtonReward.SetRedDotVisible(this.ActivityDataBase.GetRewardRedDotState());
		string text3 = this.ActivityDataBase.GetAllItemUnlockCount().ToString();
		string text4 = this.ActivityDataBase.GetAllItemCount().ToString();
		this.ButtonHandbook.SetDescText("SurvivorsCollection", new string[]
		{
			text3,
			text4
		});
		Dictionary<int, SurvivorsTalentNode> talentNodeMap = this.ActivityDataBase.TalentNodeMap;
		int num = 0;
		using (Dictionary<int, SurvivorsTalentNode>.ValueCollection.Enumerator enumerator = talentNodeMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status == ESurvivorsTalentNodeStatus.Upgraded)
				{
					num++;
				}
			}
		}
		string text5 = talentNodeMap.Count.ToString();
		this.ButtonTalentTree.SetRedDotVisible(this.ActivityDataBase.GetTalentTreeRed());
		this.ButtonTalentTree.SetDescText("SurvivorsSkillTree", new string[]
		{
			num.ToString(),
			text5
		});
	}

	// Token: 0x060161D4 RID: 90580 RVA: 0x006232A0 File Offset: 0x006214A0
	private void OnClickedBtnReward()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsRogueRewardView, null, delegate(bool success, int viewId)
		{
			if (success)
			{
				base.AddChildViewById(viewId);
			}
		});
	}

	// Token: 0x060161D5 RID: 90581 RVA: 0x006232BE File Offset: 0x006214BE
	private void OnClickedBtnHandbook()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsHandbookView, null, null);
	}

	// Token: 0x060161D6 RID: 90582 RVA: 0x006232D1 File Offset: 0x006214D1
	private void OnClickedBtnTalentTree()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsTalentTreeView, null, null);
	}

	// Token: 0x060161D7 RID: 90583 RVA: 0x006232E4 File Offset: 0x006214E4
	private void OnClickedBtnUp()
	{
		if (this.IsDragging)
		{
			return;
		}
		if (!this.IsTweenerComplete)
		{
			return;
		}
		if (this.IsTopArea())
		{
			return;
		}
		SurvivorsRogueDiffAreaInfo survivorsRogueDiffAreaInfo = this.DiffAreaUiInfoList[this.CurrentDiff + 1];
		this.ScrollLevelIdToBottom(survivorsRogueDiffAreaInfo.LowerBoundLevelId, true);
	}

	// Token: 0x060161D8 RID: 90584 RVA: 0x00623330 File Offset: 0x00621530
	private void OnClickedBtnDown()
	{
		if (this.IsDragging)
		{
			return;
		}
		if (!this.IsTweenerComplete)
		{
			return;
		}
		if (this.IsBottomArea())
		{
			return;
		}
		SurvivorsRogueDiffAreaInfo survivorsRogueDiffAreaInfo = this.DiffAreaUiInfoList[this.CurrentDiff - 1];
		this.ScrollLevelIdToBottom(survivorsRogueDiffAreaInfo.LowerBoundLevelId, true);
	}

	// Token: 0x060161D9 RID: 90585 RVA: 0x0062337C File Offset: 0x0062157C
	private void OnSurvivorsInstSettle(bool success)
	{
		if (!success)
		{
			return;
		}
		this.LevelInfo = new SurvivorsActivityDefine.SurvivorsLevelInfo();
		foreach (SurvivorsLevelInfoItem survivorsLevelInfoItem in this.LevelInfoItemMap.Values)
		{
			survivorsLevelInfoItem.SetSaveFile(this.LevelInfo);
		}
	}

	// Token: 0x060161DA RID: 90586 RVA: 0x006233E8 File Offset: 0x006215E8
	private void OnButtonClickedCallback(int levelId)
	{
		bool isInfinite = this.ActivityDataBase.IsEndlessMode(levelId);
		if (!this.ActivityDataBase.GetLevelUnlockState(levelId, isInfinite))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SurvivorsEnterLockTips", Array.Empty<object>());
			return;
		}
		SurvivorsLevel value = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsLevel(levelId).Value;
		ModelBase<SurvivorsRogueModel>.Instance.SelectLevelInfo = this.LevelInfo;
		if (!this.LevelInfo.IsSaveFile)
		{
			this.LevelInfo.LevelId = levelId;
			this.LevelInfo.InstId = value.InstId;
			this.LevelInfo.IsEndless = this.ActivityDataBase.IsEndlessMode(levelId);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsLevelDetailView, null, null);
			return;
		}
		if (this.LevelInfo.LevelId != levelId)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SurvivorsEnterHasSaveTips", Array.Empty<object>());
			return;
		}
		SurvivorsExitViewParams param = new SurvivorsExitViewParams
		{
			IsExternal = true,
			Batch = this.LevelInfo.Batch,
			MaxBatch = this.LevelInfo.MaxBatch
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsRogueExitView, param, null);
	}

	// Token: 0x060161DB RID: 90587 RVA: 0x00623501 File Offset: 0x00621701
	private void OnCloseBtnClicked()
	{
		base.CloseMe(null);
	}

	// Token: 0x060161DC RID: 90588 RVA: 0x0062350C File Offset: 0x0062170C
	private void OnHelpBtnClicked()
	{
		SurvivorsActivityConfig? survivorsActivityConfig;
		int? num = (ModelBase<SurvivorsRogueModel>.Instance.GetRogueActivityConfig() != null) ? new int?(survivorsActivityConfig.GetValueOrDefault().HelpId) : null;
		if (num != null)
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(num.Value);
		}
	}

	// Token: 0x0400AA7E RID: 43646
	private readonly string[] diffIdToleSpineName = new string[]
	{
		"Idle1",
		"Idle2",
		"Idle3"
	};

	// Token: 0x0400AA7F RID: 43647
	private readonly string[] diffIdUnlockToSpineName = new string[]
	{
		"None",
		"Idle1to2",
		"Idle2to3"
	};

	// Token: 0x0400AA80 RID: 43648
	private const int CENTER_AREA_HALF_HEIGHT = 100;

	// Token: 0x0400AA81 RID: 43649
	protected SurvivorsActivityData ActivityDataBase;

	// Token: 0x0400AA82 RID: 43650
	protected UUIScrollViewWithScrollbarComponent ScrollViewComp;

	// Token: 0x0400AA83 RID: 43651
	[Nullable(2)]
	protected PopupCaptionItem CaptionItem;

	// Token: 0x0400AA84 RID: 43652
	[Nullable(2)]
	protected SurvivorsFunctionButtonItem ButtonTalentTree;

	// Token: 0x0400AA85 RID: 43653
	[Nullable(2)]
	protected SurvivorsFunctionButtonItem ButtonHandbook;

	// Token: 0x0400AA86 RID: 43654
	[Nullable(2)]
	protected SurvivorsFunctionButtonItem ButtonReward;

	// Token: 0x0400AA87 RID: 43655
	protected readonly Dictionary<int, SurvivorsLevelInfoItem> LevelInfoItemMap = new Dictionary<int, SurvivorsLevelInfoItem>();

	// Token: 0x0400AA88 RID: 43656
	protected readonly Dictionary<int, SurvivorsLevelItem> LevelItemMap = new Dictionary<int, SurvivorsLevelItem>();

	// Token: 0x0400AA89 RID: 43657
	private SurvivorsActivityDefine.SurvivorsLevelInfo LevelInfo;

	// Token: 0x0400AA8A RID: 43658
	[Nullable(2)]
	private UCurveFloat UiCurveAreaMove;

	// Token: 0x0400AA8B RID: 43659
	private readonly List<SurvivorsRogueParallaxItem> ItemParallaxList = new List<SurvivorsRogueParallaxItem>();

	// Token: 0x0400AA8C RID: 43660
	private float CenterPosY;

	// Token: 0x0400AA8D RID: 43661
	private float CenterAreaHalfHeight;

	// Token: 0x0400AA8E RID: 43662
	private float LastScrollValue = 0.001f;

	// Token: 0x0400AA8F RID: 43663
	protected float ScrollContentInitPosY;

	// Token: 0x0400AA90 RID: 43664
	protected float ScrollContentLastPosY;

	// Token: 0x0400AA91 RID: 43665
	protected bool IsDragging;

	// Token: 0x0400AA92 RID: 43666
	protected bool StartElasticMovement;

	// Token: 0x0400AA93 RID: 43667
	protected readonly List<SurvivorsRogueDiffAreaInfo> DiffAreaUiInfoList = new List<SurvivorsRogueDiffAreaInfo>();

	// Token: 0x0400AA94 RID: 43668
	protected int CurrentDiff = -1;

	// Token: 0x0400AA95 RID: 43669
	protected int CurrentUnlockDiff = -1;

	// Token: 0x0400AA96 RID: 43670
	private readonly float ChangeAreaDuration = ConfigCommonParamById.GetFloatConfig("SurvivorsRogueChangeAreaDuration").GetValueOrDefault();

	// Token: 0x0400AA97 RID: 43671
	private readonly float AreaBottomScale = ConfigCommonParamById.GetFloatConfig("SurvivorsRogueAreaBottomScale").GetValueOrDefault();

	// Token: 0x0400AA98 RID: 43672
	private readonly float BackgroundParallaxFactor = ConfigCommonParamById.GetFloatConfig("SurvivorsRogueBackgroundParallaxFactor").GetValueOrDefault();

	// Token: 0x0400AA99 RID: 43673
	private readonly float AutoAttachVelocityY = ConfigCommonParamById.GetFloatConfig("SurvivorsRogueAutoAttachVelocityY").GetValueOrDefault();

	// Token: 0x0400AA9A RID: 43674
	private readonly Vector2D TempVector2D = Vector2D.Create();

	// Token: 0x0400AA9B RID: 43675
	private bool IsTweenerComplete = true;

	// Token: 0x0400AA9C RID: 43676
	private bool IsBindTweenerComplete;
}
