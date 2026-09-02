using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200273C RID: 10044
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsGamePlayView : UiViewBase, IUiCameraBehavior
{
	// Token: 0x06013D04 RID: 81156 RVA: 0x00583E5F File Offset: 0x0058205F
	public RacingBetsGamePlayView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013D05 RID: 81157 RVA: 0x00583E94 File Offset: 0x00582094
	protected unsafe override void OnRegisterComponent()
	{
		int num = 47;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(34, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(35, typeof(UUISliderComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(36, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(37, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(38, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(39, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(40, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(41, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(42, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(43, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(44, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(45, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(46, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 14;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickBulletScreenToggle));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickTextBulletScreenButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickIconBulletScreenButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickCloseButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickDangoSkillButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action<EToggleState>(this.OnClickDangoTextBulletToggle));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action<EToggleState>(this.OnClickTextBulletToggle));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(22, new Action(this.OnClickSpeedButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(31, new Action(this.OnClickBulletScreenCloseButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(32, new Action(this.OnClickBulletScreenSettingButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(35, new Action<float>(this.OnBulletScreenAlphaSliderValueChanged));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(36, new Action<EToggleState>(this.OnClickFullBulletScreenToggle));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(37, new Action<EToggleState>(this.OnClickHalfBulletScreenToggle));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(46, new Action(this.OnClickDetailButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013D06 RID: 81158 RVA: 0x00584700 File Offset: 0x00582900
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsGamePlayView.<OnBeforeStartAsync>d__22 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsGamePlayView.<OnBeforeStartAsync>d__22>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013D07 RID: 81159 RVA: 0x00584744 File Offset: 0x00582944
	private UniTask InitRacingBetsOrderList()
	{
		RacingBetsGamePlayView.<InitRacingBetsOrderList>d__23 <InitRacingBetsOrderList>d__;
		<InitRacingBetsOrderList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRacingBetsOrderList>d__.<>4__this = this;
		<InitRacingBetsOrderList>d__.<>1__state = -1;
		<InitRacingBetsOrderList>d__.<>t__builder.Start<RacingBetsGamePlayView.<InitRacingBetsOrderList>d__23>(ref <InitRacingBetsOrderList>d__);
		return <InitRacingBetsOrderList>d__.<>t__builder.Task;
	}

	// Token: 0x06013D08 RID: 81160 RVA: 0x00584788 File Offset: 0x00582988
	private UniTask InitRacingBetsDangoDiceList()
	{
		RacingBetsGamePlayView.<InitRacingBetsDangoDiceList>d__24 <InitRacingBetsDangoDiceList>d__;
		<InitRacingBetsDangoDiceList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRacingBetsDangoDiceList>d__.<>4__this = this;
		<InitRacingBetsDangoDiceList>d__.<>1__state = -1;
		<InitRacingBetsDangoDiceList>d__.<>t__builder.Start<RacingBetsGamePlayView.<InitRacingBetsDangoDiceList>d__24>(ref <InitRacingBetsDangoDiceList>d__);
		return <InitRacingBetsDangoDiceList>d__.<>t__builder.Task;
	}

	// Token: 0x06013D09 RID: 81161 RVA: 0x005847CC File Offset: 0x005829CC
	private void InitBulletScreen()
	{
		this.ShowIconBulletScreenPanel = false;
		this.ShowTextBulletScreenPanel = false;
		this.ShowBulletScreenSettingPanel = false;
		base.GetItem(5).SetUIActive(false);
		base.GetItem(8).SetUIActive(false);
		base.GetItem(33).SetUIActive(false);
		base.GetButton(31).RootUIComp.Get().SetUIActive(false);
		int racingBetsBulletScreenAlpha = ModelBase<RacingBetsModel>.Instance.GetRacingBetsBulletScreenAlpha();
		UUISliderComponent slider = base.GetSlider(35);
		slider.MaxValue = 100f;
		slider.MinValue = 10f;
		slider.Value = (float)racingBetsBulletScreenAlpha;
		this.BulletScreenMovePanel.GetRootItem().SetAlpha((float)racingBetsBulletScreenAlpha / 100f);
		int racingBetsBulletScreenShowType = ModelBase<RacingBetsModel>.Instance.GetRacingBetsBulletScreenShowType();
		bool flag = racingBetsBulletScreenShowType == 2;
		UUIExtendToggle extendToggle = base.GetExtendToggle(36);
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(37);
		extendToggle.SetToggleStateForce(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		extendToggle.bLockStateOnSelect = true;
		extendToggle2.SetToggleStateForce(flag ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked, false, false, false);
		extendToggle2.bLockStateOnSelect = true;
		this.BulletScreenMovePanel.SetBulletScreenShowType((ERacingBetsBulletScreenShowType)racingBetsBulletScreenShowType);
		UUIText text = base.GetText(34);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(racingBetsBulletScreenAlpha);
		defaultInterpolatedStringHandler.AppendLiteral("%");
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x06013D0A RID: 81162 RVA: 0x00584908 File Offset: 0x00582B08
	private void RefreshUi()
	{
		bool isReplayDungeon = ModelBase<RacingBetsModel>.Instance.IsReplayDungeon;
		base.GetItem(13).SetUIActive(false);
		base.GetExtendToggle(9).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		base.GetExtendToggle(10).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		this.ShowIconBulletScreenPanel = false;
		this.ShowTextBulletScreenPanel = false;
		base.GetItem(5).SetUIActive(false);
		base.GetItem(8).SetUIActive(false);
		base.GetButton(22).RootUIComp.Get().SetUIActive(isReplayDungeon);
		UUISprite spriteComponent = base.GetSprite(45);
		spriteComponent.SetUIActive(false);
		string resourceId = isReplayDungeon ? "SP_RaceScheduleTitleBgRec" : "SP_RaceScheduleTitleBg";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		this.SetSpriteByPath(resourcePath, spriteComponent, false, null, delegate(bool success)
		{
			spriteComponent.SetUIActive(success);
		});
		if (isReplayDungeon)
		{
			float num = this.ReplaySpeedList[this.CurReplaySpeedIndex];
			UGameplayStatics.SetGlobalTimeDilation(GlobalData.World, num);
			UUIText text = base.GetText(23);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("×");
			defaultInterpolatedStringHandler.AppendFormatted<float>(num, "F1");
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
	}

	// Token: 0x06013D0B RID: 81163 RVA: 0x00584A50 File Offset: 0x00582C50
	private void RefreshDangoOrderList(IReadOnlyList<DangoIdToDiceNum> dangoOrderList)
	{
		for (int i = 0; i < dangoOrderList.Count; i++)
		{
			this.DangoOrderItemList[i].Refresh(dangoOrderList[i], false, i);
			this.DangoOrderItemList[i].SetActive(true);
		}
		if (this.DangoOrderItemList.Count > dangoOrderList.Count)
		{
			for (int j = dangoOrderList.Count; j < this.DangoOrderItemList.Count; j++)
			{
				this.DangoOrderItemList[j].SetActive(false);
			}
		}
	}

	// Token: 0x06013D0C RID: 81164 RVA: 0x00584ADC File Offset: 0x00582CDC
	private void RefreshDangoDiceList(IReadOnlyList<DangoIdToDiceNum> dangoDiceList)
	{
		for (int i = 0; i < dangoDiceList.Count; i++)
		{
			this.DangoDiceItemList[i].Refresh(dangoDiceList[i], false, i);
			this.DangoDiceItemList[i].SetActive(true);
		}
		if (this.DangoDiceItemList.Count > dangoDiceList.Count)
		{
			for (int j = dangoDiceList.Count; j < this.DangoDiceItemList.Count; j++)
			{
				this.DangoDiceItemList[j].SetActive(false);
			}
		}
	}

	// Token: 0x06013D0D RID: 81165 RVA: 0x00584B68 File Offset: 0x00582D68
	private void RefreshDangoSettingPanel(bool isShow)
	{
		if (this.ShowBulletScreenSettingPanel == isShow)
		{
			return;
		}
		this.ShowBulletScreenSettingPanel = isShow;
		if (isShow)
		{
			if (this.UiViewSequence.HasSequenceNameInPlaying("FuncHide03"))
			{
				this.UiViewSequence.StopSequenceByKey("FuncHide03", false, false);
			}
			base.PlaySequence("FuncShow03", null, false);
			return;
		}
		if (this.UiViewSequence.HasSequenceNameInPlaying("FuncShow03"))
		{
			this.UiViewSequence.StopSequenceByKey("FuncShow03", false, false);
		}
		base.PlaySequence("FuncHide03", null, false);
	}

	// Token: 0x06013D0E RID: 81166 RVA: 0x00584BEC File Offset: 0x00582DEC
	private void RefreshTextBulletScreenPanel(bool isShow)
	{
		if (this.ShowTextBulletScreenPanel == isShow)
		{
			return;
		}
		this.ShowTextBulletScreenPanel = isShow;
		if (isShow)
		{
			if (this.UiViewSequence.HasSequenceNameInPlaying("FuncHide02"))
			{
				this.UiViewSequence.StopSequenceByKey("FuncHide02", false, false);
			}
			base.PlaySequence("FuncShow02", null, false);
			return;
		}
		if (this.UiViewSequence.HasSequenceNameInPlaying("FuncShow02"))
		{
			this.UiViewSequence.StopSequenceByKey("FuncShow02", false, false);
		}
		base.PlaySequence("FuncHide02", null, false);
	}

	// Token: 0x06013D0F RID: 81167 RVA: 0x00584C70 File Offset: 0x00582E70
	private void RefreshIconBulletScreenPanel(bool isShow)
	{
		if (this.ShowIconBulletScreenPanel == isShow)
		{
			return;
		}
		this.ShowIconBulletScreenPanel = isShow;
		if (isShow)
		{
			if (this.UiViewSequence.HasSequenceNameInPlaying("FuncHide01"))
			{
				this.UiViewSequence.StopSequenceByKey("FuncHide01", false, false);
			}
			base.PlaySequence("FuncShow01", null, false);
			return;
		}
		if (this.UiViewSequence.HasSequenceNameInPlaying("FuncShow01"))
		{
			this.UiViewSequence.StopSequenceByKey("FuncShow01", false, false);
		}
		base.PlaySequence("FuncHide01", null, false);
	}

	// Token: 0x06013D10 RID: 81168 RVA: 0x00584CF4 File Offset: 0x00582EF4
	public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
	{
		ControllerBase<UiCameraAnimationController>.Instance.PushCameraHandle(viewName, new int?(viewId), true);
	}

	// Token: 0x06013D11 RID: 81169 RVA: 0x00584D08 File Offset: 0x00582F08
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRacingBetsDiceAnim, new Action<int, CustomPromise>(this.OnRacingBetsDiceAnim));
		Singleton<EventSystem>.Instance.Add<int, IReadOnlyList<DangoIdToDiceNum>, CustomPromise>(EEventName.OnRacingBetsDangoOrderRefresh, new Action<int, IReadOnlyList<DangoIdToDiceNum>, CustomPromise>(this.OnRacingBetsDangoOrderRefresh));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>, bool>(EEventName.OnRacingBetsPushBulletScreen, new Action<IReadOnlyList<int>, bool>(this.OnRacingBetsPushBulletScreen));
		Singleton<EventSystem>.Instance.Add<CustomPromise>(EEventName.OnRacingBetsDungeonDangoRankChange, new Action<CustomPromise>(this.OnRacingBetsDungeonDangoRankChange));
		Singleton<EventSystem>.Instance.Add<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
	}

	// Token: 0x06013D12 RID: 81170 RVA: 0x00584DA4 File Offset: 0x00582FA4
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsDiceAnim, new Action<int, CustomPromise>(this.OnRacingBetsDiceAnim));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsDangoOrderRefresh, new Action<int, IReadOnlyList<DangoIdToDiceNum>, CustomPromise>(this.OnRacingBetsDangoOrderRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsPushBulletScreen, new Action<IReadOnlyList<int>, bool>(this.OnRacingBetsPushBulletScreen));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsDungeonDangoRankChange, new Action<CustomPromise>(this.OnRacingBetsDungeonDangoRankChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
	}

	// Token: 0x06013D13 RID: 81171 RVA: 0x00584E40 File Offset: 0x00583040
	[NullableContext(2)]
	public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
	{
		ControllerBase<UiCameraAnimationController>.Instance.DeepCopyCamera(ControllerBase<CameraController>.Instance.MainModel.FreeCamera.DisplayComponent.CameraActor);
		CameraController instance = ControllerBase<CameraController>.Instance;
		UiCamera uiCamera = Singleton<UiCameraAnimationManager>.Instance.UiCamera;
		instance.SetViewTarget((uiCamera != null) ? uiCamera.GetCameraActor() : null, "RacingBetsGamePlayView", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, null, "MainCamera", null, null);
		ControllerBase<UiCameraAnimationController>.Instance.PopCameraHandle(viewName, stackTopInfo, closeViewId, popOrDelete);
	}

	// Token: 0x06013D14 RID: 81172 RVA: 0x00584EC8 File Offset: 0x005830C8
	protected override void OnBeforeDestroy()
	{
		UGameplayStatics.SetGlobalTimeDilation(GlobalData.World, 1f);
	}

	// Token: 0x06013D15 RID: 81173 RVA: 0x00584ED9 File Offset: 0x005830D9
	private RacingBetsIconBulletScreenItem CreateIconBulletItem()
	{
		RacingBetsIconBulletScreenItem racingBetsIconBulletScreenItem = new RacingBetsIconBulletScreenItem();
		racingBetsIconBulletScreenItem.BindClickBulletScreenCallBack(new Action<RacingBetsBulletScreen>(this.OnClickBulletScreenItem));
		return racingBetsIconBulletScreenItem;
	}

	// Token: 0x06013D16 RID: 81174 RVA: 0x00584EF2 File Offset: 0x005830F2
	private RacingBetsTextBulletScreenItem CreateTextBulletItem()
	{
		RacingBetsTextBulletScreenItem racingBetsTextBulletScreenItem = new RacingBetsTextBulletScreenItem();
		racingBetsTextBulletScreenItem.BindClickBulletScreenCallBack(new Action<RacingBetsBulletScreen>(this.OnClickBulletScreenItem));
		return racingBetsTextBulletScreenItem;
	}

	// Token: 0x06013D17 RID: 81175 RVA: 0x00584F0B File Offset: 0x0058310B
	private void OnRacingBetsDangoOrderRefresh(int round, IReadOnlyList<DangoIdToDiceNum> dangoOrderList, CustomPromise promise)
	{
		this.RefreshDangoOrder(round, dangoOrderList, promise).Forget();
	}

	// Token: 0x06013D18 RID: 81176 RVA: 0x00584F1C File Offset: 0x0058311C
	private UniTask RefreshDangoOrder(int round, IReadOnlyList<DangoIdToDiceNum> dangoOrderList, CustomPromise promise)
	{
		RacingBetsGamePlayView.<RefreshDangoOrder>d__40 <RefreshDangoOrder>d__;
		<RefreshDangoOrder>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshDangoOrder>d__.<>4__this = this;
		<RefreshDangoOrder>d__.round = round;
		<RefreshDangoOrder>d__.dangoOrderList = dangoOrderList;
		<RefreshDangoOrder>d__.promise = promise;
		<RefreshDangoOrder>d__.<>1__state = -1;
		<RefreshDangoOrder>d__.<>t__builder.Start<RacingBetsGamePlayView.<RefreshDangoOrder>d__40>(ref <RefreshDangoOrder>d__);
		return <RefreshDangoOrder>d__.<>t__builder.Task;
	}

	// Token: 0x06013D19 RID: 81177 RVA: 0x00584F77 File Offset: 0x00583177
	private void OnRacingBetsDiceAnim(int diceCount, CustomPromise promise)
	{
		this.PlayDiceAnim(diceCount, promise).Forget();
	}

	// Token: 0x06013D1A RID: 81178 RVA: 0x00584F88 File Offset: 0x00583188
	private UniTask PlayDiceAnim(int diceCount, CustomPromise promise)
	{
		RacingBetsGamePlayView.<PlayDiceAnim>d__42 <PlayDiceAnim>d__;
		<PlayDiceAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayDiceAnim>d__.<>4__this = this;
		<PlayDiceAnim>d__.promise = promise;
		<PlayDiceAnim>d__.<>1__state = -1;
		<PlayDiceAnim>d__.<>t__builder.Start<RacingBetsGamePlayView.<PlayDiceAnim>d__42>(ref <PlayDiceAnim>d__);
		return <PlayDiceAnim>d__.<>t__builder.Task;
	}

	// Token: 0x06013D1B RID: 81179 RVA: 0x00584FD3 File Offset: 0x005831D3
	private void OnRacingBetsPushBulletScreen(IReadOnlyList<int> bulletList, bool isSelf)
	{
		this.BulletScreenMovePanel.PushBulletScreen(bulletList, isSelf);
	}

	// Token: 0x06013D1C RID: 81180 RVA: 0x00584FE2 File Offset: 0x005831E2
	private void OnRacingBetsDungeonDangoRankChange(CustomPromise promise)
	{
		this.RefreshDangoRank(promise).Forget();
	}

	// Token: 0x06013D1D RID: 81181 RVA: 0x00584FF0 File Offset: 0x005831F0
	private UniTask RefreshDangoRank(CustomPromise promise)
	{
		RacingBetsGamePlayView.<RefreshDangoRank>d__45 <RefreshDangoRank>d__;
		<RefreshDangoRank>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshDangoRank>d__.<>4__this = this;
		<RefreshDangoRank>d__.promise = promise;
		<RefreshDangoRank>d__.<>1__state = -1;
		<RefreshDangoRank>d__.<>t__builder.Start<RacingBetsGamePlayView.<RefreshDangoRank>d__45>(ref <RefreshDangoRank>d__);
		return <RefreshDangoRank>d__.<>t__builder.Task;
	}

	// Token: 0x06013D1E RID: 81182 RVA: 0x0058503C File Offset: 0x0058323C
	private void OnActivateUiCameraAnimationHandle(UiCameraHandleData handleData)
	{
		if (handleData.ViewName == EUiViewName.RacingBetsGamePlayView)
		{
			int gameplayMode = ModelBase<GameModeModel>.Instance.InstanceDungeon.Value.GameplayMode;
			InstanceGameplayMode? gameplayModeConfig = ConfigBase<InstanceDungeonConfig>.Instance.GetGameplayModeConfig(gameplayMode);
			if (gameplayModeConfig != null)
			{
				ControllerBase<CameraController>.Instance.MainModel.FreeCamera.LogicComponent.InitConfig(RacingBetsGamePlayView.ToFloatArray(gameplayModeConfig.Value.GetCameraParamsArray()));
			}
			ControllerBase<UiCameraAnimationController>.Instance.ExitUiCameraMode();
		}
	}

	// Token: 0x06013D1F RID: 81183 RVA: 0x005850C8 File Offset: 0x005832C8
	private void OnClickBulletScreenToggle(EToggleState state)
	{
		this.BulletScreenMovePanel.SetActive(state != EToggleState.ETT_Checked);
	}

	// Token: 0x06013D20 RID: 81184 RVA: 0x005850DC File Offset: 0x005832DC
	private void OnClickTextBulletScreenButton()
	{
		bool flag = !this.ShowTextBulletScreenPanel;
		base.GetButton(31).RootUIComp.Get().SetUIActive(flag);
		this.RefreshTextBulletScreenPanel(flag);
		this.RefreshDangoSettingPanel(false);
		this.RefreshIconBulletScreenPanel(false);
	}

	// Token: 0x06013D21 RID: 81185 RVA: 0x00585124 File Offset: 0x00583324
	private void OnClickIconBulletScreenButton()
	{
		bool flag = !this.ShowIconBulletScreenPanel;
		base.GetButton(31).RootUIComp.Get().SetUIActive(flag);
		this.RefreshIconBulletScreenPanel(flag);
		this.RefreshDangoSettingPanel(false);
		this.RefreshTextBulletScreenPanel(false);
	}

	// Token: 0x06013D22 RID: 81186 RVA: 0x0058516C File Offset: 0x0058336C
	private void OnClickDangoTextBulletToggle(EToggleState state)
	{
		base.GetExtendToggle(9).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		base.GetExtendToggle(10).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		List<RacingBetsBulletScreen> racingBetsBulletScreen = ModelBase<RacingBetsModel>.Instance.GetRacingBetsBulletScreen(ERacingBetsBulletScreenType.DangoText);
		this.TextBulletScroll.RefreshByData(racingBetsBulletScreen, null, false);
	}

	// Token: 0x06013D23 RID: 81187 RVA: 0x005851B8 File Offset: 0x005833B8
	private void OnClickTextBulletToggle(EToggleState state)
	{
		base.GetExtendToggle(9).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		base.GetExtendToggle(10).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		List<RacingBetsBulletScreen> racingBetsBulletScreen = ModelBase<RacingBetsModel>.Instance.GetRacingBetsBulletScreen(ERacingBetsBulletScreenType.Text);
		this.TextBulletScroll.RefreshByData(racingBetsBulletScreen, null, false);
	}

	// Token: 0x06013D24 RID: 81188 RVA: 0x00585204 File Offset: 0x00583404
	private void OnClickSpeedButton()
	{
		this.CurReplaySpeedIndex = (this.CurReplaySpeedIndex + 1) % this.ReplaySpeedList.Count;
		float num = this.ReplaySpeedList[this.CurReplaySpeedIndex];
		UGameplayStatics.SetGlobalTimeDilation(GlobalData.World, num);
		UUIText text = base.GetText(23);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("×");
		defaultInterpolatedStringHandler.AppendFormatted<float>(num, "F1");
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x06013D25 RID: 81189 RVA: 0x00585280 File Offset: 0x00583480
	private void OnClickBulletScreenCloseButton()
	{
		this.RefreshDangoSettingPanel(false);
		this.RefreshTextBulletScreenPanel(false);
		this.RefreshIconBulletScreenPanel(false);
		base.GetButton(31).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x06013D26 RID: 81190 RVA: 0x005852C0 File Offset: 0x005834C0
	private void OnBulletScreenAlphaSliderValueChanged(float value)
	{
		int num = (int)Math.Floor((double)value);
		ModelBase<RacingBetsModel>.Instance.SetRacingBetsBulletScreenAlpha(num);
		UUIText text = base.GetText(34);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(num);
		defaultInterpolatedStringHandler.AppendLiteral("%");
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		this.BulletScreenMovePanel.GetRootItem().SetAlpha((float)num / 100f);
	}

	// Token: 0x06013D27 RID: 81191 RVA: 0x0058532C File Offset: 0x0058352C
	private void OnClickBulletScreenSettingButton()
	{
		bool flag = !this.ShowBulletScreenSettingPanel;
		base.GetButton(31).RootUIComp.Get().SetUIActive(flag);
		this.RefreshDangoSettingPanel(flag);
		this.RefreshTextBulletScreenPanel(false);
		this.RefreshIconBulletScreenPanel(false);
	}

	// Token: 0x06013D28 RID: 81192 RVA: 0x00585373 File Offset: 0x00583573
	private void OnClickFullBulletScreenToggle(EToggleState state)
	{
		ModelBase<RacingBetsModel>.Instance.SetRacingBetsBulletScreenShowType(2);
		this.BulletScreenMovePanel.SetBulletScreenShowType(ERacingBetsBulletScreenShowType.Full);
		base.GetExtendToggle(37).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06013D29 RID: 81193 RVA: 0x0058539D File Offset: 0x0058359D
	private void OnClickHalfBulletScreenToggle(EToggleState state)
	{
		ModelBase<RacingBetsModel>.Instance.SetRacingBetsBulletScreenShowType(1);
		this.BulletScreenMovePanel.SetBulletScreenShowType(ERacingBetsBulletScreenShowType.Half);
		base.GetExtendToggle(36).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06013D2A RID: 81194 RVA: 0x005853C8 File Offset: 0x005835C8
	private void OnClickCloseButton()
	{
		if (this.IsPrepareLeave)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Dango_InGame_ExitError", Array.Empty<object>());
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RacingBetsExitDungeonConfirm);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			ModelBase<RacingBetsModel>.Instance.RacingBetsAbortDungeon();
			this.IsPrepareLeave = true;
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06013D2B RID: 81195 RVA: 0x00585424 File Offset: 0x00583624
	private void OnClickDetailButton()
	{
		int id = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData().GetCurLegMatchData().Id;
		List<int> param = new List<int>(ConfigBase<RacingBetsConfig>.Instance.GetRacingBetsLegMatches(id).Value.GetShowOrganListArray());
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsDangoTerrainView, param, null);
	}

	// Token: 0x06013D2C RID: 81196 RVA: 0x00585478 File Offset: 0x00583678
	private void OnClickDangoSkillButton()
	{
		RacingBetsDangoSkillViewParam param = new RacingBetsDangoSkillViewParam
		{
			DangoList = this.DungeonDangoSortList
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsDangoSkillView, param, null);
	}

	// Token: 0x06013D2D RID: 81197 RVA: 0x005854A8 File Offset: 0x005836A8
	private void OnClickBulletScreenItem(RacingBetsBulletScreen data)
	{
		if (this.NextBulletScreenAvailableSendTime > (long)Singleton<TimeUtil>.Instance.GetServerTimeStamp())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Dango_BulletChat_SendError", Array.Empty<object>());
			return;
		}
		this.NextBulletScreenAvailableSendTime = (long)Singleton<TimeUtil>.Instance.GetServerTimeStamp() + (long)this.BulletScreenSendInterval;
		ControllerBase<RacingBetsController>.Instance.RacingBetsBulletScreenRequest(data.Id);
	}

	// Token: 0x06013D2E RID: 81198 RVA: 0x00585508 File Offset: 0x00583708
	private static float[] ToFloatArray(int[] intArray)
	{
		float[] array = new float[intArray.Length];
		for (int i = 0; i < intArray.Length; i++)
		{
			array[i] = (float)intArray[i];
		}
		return array;
	}

	// Token: 0x04009A28 RID: 39464
	private const int DANGO_ORDER_ITEM_START_INDEX = 24;

	// Token: 0x04009A29 RID: 39465
	private const int DANGO_ORDER_ITEM_COUNT = 7;

	// Token: 0x04009A2A RID: 39466
	private const int DANGO_DICE_ITEM_START_INDEX = 38;

	// Token: 0x04009A2B RID: 39467
	private const int DANGO_DICE_ITEM_COUNT = 7;

	// Token: 0x04009A2C RID: 39468
	private bool ShowIconBulletScreenPanel;

	// Token: 0x04009A2D RID: 39469
	private bool ShowTextBulletScreenPanel;

	// Token: 0x04009A2E RID: 39470
	private bool ShowBulletScreenSettingPanel;

	// Token: 0x04009A2F RID: 39471
	private int BulletScreenSendInterval;

	// Token: 0x04009A30 RID: 39472
	private long NextBulletScreenAvailableSendTime;

	// Token: 0x04009A31 RID: 39473
	private int CurReplaySpeedIndex;

	// Token: 0x04009A32 RID: 39474
	private bool IsPrepareLeave;

	// Token: 0x04009A33 RID: 39475
	private List<float> ReplaySpeedList = new List<float>();

	// Token: 0x04009A34 RID: 39476
	private RacingBetsBulletScreenPanel BulletScreenMovePanel;

	// Token: 0x04009A35 RID: 39477
	private List<RacingBetsDungeonDangoInfo> DungeonDangoSortList = new List<RacingBetsDungeonDangoInfo>();

	// Token: 0x04009A36 RID: 39478
	private RacingBetsDangoRankPanel DangoRankPanel;

	// Token: 0x04009A37 RID: 39479
	private GenericScrollViewNew<RacingBetsIconBulletScreenItem, RacingBetsBulletScreen> IconBulletScroll;

	// Token: 0x04009A38 RID: 39480
	private GenericScrollViewNew<RacingBetsTextBulletScreenItem, RacingBetsBulletScreen> TextBulletScroll;

	// Token: 0x04009A39 RID: 39481
	private readonly List<RacingBetsDangoOrderItem> DangoOrderItemList = new List<RacingBetsDangoOrderItem>();

	// Token: 0x04009A3A RID: 39482
	private readonly List<RacingBetsDangoDiceItem> DangoDiceItemList = new List<RacingBetsDangoDiceItem>();

	// Token: 0x02008AEE RID: 35566
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402ED84 RID: 191876
		public const int DangoPanel = 0;

		// Token: 0x0402ED85 RID: 191877
		public const int DangoItem = 1;

		// Token: 0x0402ED86 RID: 191878
		public const int BulletScreenToggle = 2;

		// Token: 0x0402ED87 RID: 191879
		public const int TextBulletScreenButton = 3;

		// Token: 0x0402ED88 RID: 191880
		public const int IconBulletScreenButton = 4;

		// Token: 0x0402ED89 RID: 191881
		public const int IconBulletScreenPanel = 5;

		// Token: 0x0402ED8A RID: 191882
		public const int CloseButton = 6;

		// Token: 0x0402ED8B RID: 191883
		public const int DangoSkillButton = 7;

		// Token: 0x0402ED8C RID: 191884
		public const int TextBulletScreenPanel = 8;

		// Token: 0x0402ED8D RID: 191885
		public const int DangoTextBulletToggle = 9;

		// Token: 0x0402ED8E RID: 191886
		public const int TextBulletToggle = 10;

		// Token: 0x0402ED8F RID: 191887
		public const int TextBulletScrollView = 11;

		// Token: 0x0402ED90 RID: 191888
		public const int IconBulletScrollView = 12;

		// Token: 0x0402ED91 RID: 191889
		public const int DicePanel = 13;

		// Token: 0x0402ED92 RID: 191890
		public const int BulletScreenShowPanel = 14;

		// Token: 0x0402ED93 RID: 191891
		public const int DiceTexture = 15;

		// Token: 0x0402ED94 RID: 191892
		public const int DicePanelRoot = 16;

		// Token: 0x0402ED95 RID: 191893
		public const int DiceLayout = 17;

		// Token: 0x0402ED96 RID: 191894
		public const int DangoOrderPanel = 18;

		// Token: 0x0402ED97 RID: 191895
		public const int MaskPanel = 19;

		// Token: 0x0402ED98 RID: 191896
		public const int RoundText = 20;

		// Token: 0x0402ED99 RID: 191897
		public const int DangoOrderLayout = 21;

		// Token: 0x0402ED9A RID: 191898
		public const int SpeedButton = 22;

		// Token: 0x0402ED9B RID: 191899
		public const int SpeedText = 23;

		// Token: 0x0402ED9C RID: 191900
		public const int DangoOrderItem1 = 24;

		// Token: 0x0402ED9D RID: 191901
		public const int DangoOrderItem2 = 25;

		// Token: 0x0402ED9E RID: 191902
		public const int DangoOrderItem3 = 26;

		// Token: 0x0402ED9F RID: 191903
		public const int DangoOrderItem4 = 27;

		// Token: 0x0402EDA0 RID: 191904
		public const int DangoOrderItem5 = 28;

		// Token: 0x0402EDA1 RID: 191905
		public const int DangoOrderItem6 = 29;

		// Token: 0x0402EDA2 RID: 191906
		public const int DangoOrderItem7 = 30;

		// Token: 0x0402EDA3 RID: 191907
		public const int BulletScreenCloseButton = 31;

		// Token: 0x0402EDA4 RID: 191908
		public const int BulletScreenSettingButton = 32;

		// Token: 0x0402EDA5 RID: 191909
		public const int BulletScreenSettingPanel = 33;

		// Token: 0x0402EDA6 RID: 191910
		public const int BulletScreenAlphaText = 34;

		// Token: 0x0402EDA7 RID: 191911
		public const int BulletScreenAlphaSlider = 35;

		// Token: 0x0402EDA8 RID: 191912
		public const int FullBulletScreenToggle = 36;

		// Token: 0x0402EDA9 RID: 191913
		public const int HalfBulletScreenToggle = 37;

		// Token: 0x0402EDAA RID: 191914
		public const int DangoDiceItem1 = 38;

		// Token: 0x0402EDAB RID: 191915
		public const int DangoDiceItem2 = 39;

		// Token: 0x0402EDAC RID: 191916
		public const int DangoDiceItem3 = 40;

		// Token: 0x0402EDAD RID: 191917
		public const int DangoDiceItem4 = 41;

		// Token: 0x0402EDAE RID: 191918
		public const int DangoDiceItem5 = 42;

		// Token: 0x0402EDAF RID: 191919
		public const int DangoDiceItem6 = 43;

		// Token: 0x0402EDB0 RID: 191920
		public const int DangoDiceItem7 = 44;

		// Token: 0x0402EDB1 RID: 191921
		public const int LiveSprite = 45;

		// Token: 0x0402EDB2 RID: 191922
		public const int DetailButton = 46;
	}
}
