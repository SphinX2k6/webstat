using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200237C RID: 9084
[NullableContext(1)]
[Nullable(0)]
public class BattlePassMainView : UiViewBase
{
	// Token: 0x06011632 RID: 71218 RVA: 0x004CA19D File Offset: 0x004C839D
	public BattlePassMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011633 RID: 71219 RVA: 0x004CA1B4 File Offset: 0x004C83B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06011634 RID: 71220 RVA: 0x004CA2C4 File Offset: 0x004C84C4
	protected override UniTask OnBeforeStartAsync()
	{
		BattlePassMainView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BattlePassMainView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011635 RID: 71221 RVA: 0x004CA307 File Offset: 0x004C8507
	protected override void OnStart()
	{
		this.TabComponent.SelectToggleByIndex(0, true);
	}

	// Token: 0x06011636 RID: 71222 RVA: 0x004CA316 File Offset: 0x004C8516
	private CommonTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new CommonTabItem();
	}

	// Token: 0x06011637 RID: 71223 RVA: 0x004CA320 File Offset: 0x004C8520
	private void ToggleCallBack(int index)
	{
		UiDynamicTab data = this.TabDataList[index];
		EUiTabViewName euiTabViewName = (EUiTabViewName)data.ChildViewName;
		CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
		this.TabViewComponent.ToggleCallBack(data, euiTabViewName, tabItemByIndex, this.WeaponObservers, null);
		this.RefreshTabToggleState();
		base.GetItem(2).SetUIActive(euiTabViewName != EUiTabViewName.BattlePassWeaponView);
		base.GetItem(4).SetUIActive(euiTabViewName != EUiTabViewName.BattlePassWeaponView);
		base.GetItem(5).SetUIActive(euiTabViewName != EUiTabViewName.BattlePassWeaponView);
		base.GetItem(6).SetUIActive(euiTabViewName != EUiTabViewName.BattlePassWeaponView);
		TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
		if (tabComponent != null)
		{
			tabComponent.SetPopupToggleVisible(euiTabViewName == EUiTabViewName.BattlePassWeaponView);
		}
		ModelBase<AdventureGuideModel>.Instance.CurrentGuideTabName = new EUiTabViewName?(euiTabViewName);
	}

	// Token: 0x06011638 RID: 71224 RVA: 0x004CA400 File Offset: 0x004C8600
	private void RefreshTabToggleState()
	{
		if (this.TabViewComponent.GetCurrentTabViewName(null) != EUiTabViewName.BattlePassWeaponView)
		{
			return;
		}
		BattlePassWeaponView battlePassWeaponView = this.TabViewComponent.GetCurrentTabView() as BattlePassWeaponView;
		EToggleState captionToggleState = this.TabComponent.GetCaptionToggleState();
		battlePassWeaponView.RefreshToggleState(captionToggleState);
	}

	// Token: 0x06011639 RID: 71225 RVA: 0x004CA468 File Offset: 0x004C8668
	private CommonTabData GetCommonData(int index)
	{
		UiDynamicTab uiDynamicTab = this.TabDataList[index];
		return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
	}

	// Token: 0x0601163A RID: 71226 RVA: 0x004CA4A0 File Offset: 0x004C86A0
	private void CloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0601163B RID: 71227 RVA: 0x004CA4A9 File Offset: 0x004C86A9
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnBattlePassLevelUpEvent, new Action(this.OnBattlePassLevelUp));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnBattlePassSkip, new Action<int>(this.HandleOnBattlePassSkip));
	}

	// Token: 0x0601163C RID: 71228 RVA: 0x004CA4E3 File Offset: 0x004C86E3
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBattlePassLevelUpEvent, new Action(this.OnBattlePassLevelUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBattlePassSkip, new Action<int>(this.HandleOnBattlePassSkip));
	}

	// Token: 0x0601163D RID: 71229 RVA: 0x004CA520 File Offset: 0x004C8720
	private void OnBattlePassLevelUp()
	{
		UiViewBase topView = Singleton<UiModel>.Instance.GetTopView(ELayerType.Pop);
		if (topView == null)
		{
			topView = Singleton<UiModel>.Instance.GetTopView(ELayerType.Normal);
		}
		if (topView.ViewInfo.Name == this.ViewInfo.Name)
		{
			ControllerBase<BattlePassController>.Instance.TryShowUpLevelView(false);
		}
	}

	// Token: 0x0601163E RID: 71230 RVA: 0x004CA572 File Offset: 0x004C8772
	private void HandleOnBattlePassSkip(int skipId)
	{
		this.HandleOnBattlePassSkipImpAsync(skipId).Forget();
	}

	// Token: 0x0601163F RID: 71231 RVA: 0x004CA580 File Offset: 0x004C8780
	private UniTask HandleOnBattlePassSkipImpAsync(int skipId)
	{
		BattlePassMainView.<HandleOnBattlePassSkipImpAsync>d__19 <HandleOnBattlePassSkipImpAsync>d__;
		<HandleOnBattlePassSkipImpAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HandleOnBattlePassSkipImpAsync>d__.<>4__this = this;
		<HandleOnBattlePassSkipImpAsync>d__.skipId = skipId;
		<HandleOnBattlePassSkipImpAsync>d__.<>1__state = -1;
		<HandleOnBattlePassSkipImpAsync>d__.<>t__builder.Start<BattlePassMainView.<HandleOnBattlePassSkipImpAsync>d__19>(ref <HandleOnBattlePassSkipImpAsync>d__);
		return <HandleOnBattlePassSkipImpAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011640 RID: 71232 RVA: 0x004CA5CC File Offset: 0x004C87CC
	private void OnClickPopupToggle(EToggleState state)
	{
		if (this.TabViewComponent.GetCurrentTabViewName(null) != EUiTabViewName.BattlePassWeaponView)
		{
			return;
		}
		BattlePassWeaponView battlePassWeaponView = this.TabViewComponent.GetCurrentTabView() as BattlePassWeaponView;
		if (battlePassWeaponView == null)
		{
			return;
		}
		battlePassWeaponView.OnClickFullLevelToggle(state);
	}

	// Token: 0x06011641 RID: 71233 RVA: 0x004CA62C File Offset: 0x004C882C
	public void BindTabViewRed(EUiTabViewName tabName, ERedDotName redName)
	{
		int num = -1;
		foreach (UiDynamicTab uiDynamicTab in this.TabDataList)
		{
			num++;
			if ((EUiTabViewName)uiDynamicTab.ChildViewName == tabName)
			{
				break;
			}
		}
		this.TabComponent.GetTabItemByIndex(num).BindRedDot(redName, new int?(0));
	}

	// Token: 0x06011642 RID: 71234 RVA: 0x004CA6AC File Offset: 0x004C88AC
	private void UnBindTabViewRed(EUiTabViewName tab)
	{
		int num = -1;
		foreach (UiDynamicTab uiDynamicTab in this.TabDataList)
		{
			num++;
			if ((EUiTabViewName)uiDynamicTab.ChildViewName == tab)
			{
				break;
			}
		}
		this.TabComponent.GetTabItemByIndex(num).UnBindRedDot();
	}

	// Token: 0x06011643 RID: 71235 RVA: 0x004CA728 File Offset: 0x004C8928
	protected override void OnBeforeShow()
	{
		this.TabViewComponent.SetCurrentTabViewState(true);
		this.BindTabViewRed(EUiTabViewName.BattlePassRewardView, ERedDotName.BattlePassReward);
		this.BindTabViewRed(EUiTabViewName.BattlePassTaskView, ERedDotName.BattlePassTask);
	}

	// Token: 0x06011644 RID: 71236 RVA: 0x004CA750 File Offset: 0x004C8950
	protected override void OnAfterHide()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.BattlePassMainViewHide);
		this.TabViewComponent.SetCurrentTabViewState(false);
		this.UnBindTabViewRed(EUiTabViewName.BattlePassRewardView);
		this.UnBindTabViewRed(EUiTabViewName.BattlePassTaskView);
	}

	// Token: 0x06011645 RID: 71237 RVA: 0x004CA784 File Offset: 0x004C8984
	public void RefreshLeftTime(float _)
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double num = (double)this.PassEndTime - serverTime;
		if (num < 0.0)
		{
			if (!this.WaitToDestroy)
			{
				ControllerBase<BattlePassController>.Instance.ShowTimePassConfirm();
			}
			return;
		}
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(num);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Text_GachaRemainingTime_Text", new <>z__ReadOnlySingleElementList<object>(remainTimeDataFormat.CountDownText));
	}

	// Token: 0x06011646 RID: 71238 RVA: 0x004CA7F4 File Offset: 0x004C89F4
	protected override void OnBeforeDestroy()
	{
		TimerHandle timerHandle = this.TimerHandle;
		if (timerHandle != null)
		{
			timerHandle.Remove();
		}
		this.TimerHandle = null;
		if (this.TabComponent != null)
		{
			this.TabComponent.Destroy(null);
			this.TabComponent = null;
		}
		if (this.TabViewComponent != null)
		{
			this.TabViewComponent.DestroyTabViewComponent();
			this.TabViewComponent = null;
		}
		this.TabDataList = new List<UiDynamicTab>();
		Singleton<UiSceneManager>.Instance.DestroyWeaponObserver(this.WeaponObservers.WeaponObserver);
		Singleton<UiSceneManager>.Instance.DestroyWeaponScabbardObserver(this.WeaponObservers.WeaponScabbardObserver);
		this.WeaponObservers = null;
	}

	// Token: 0x06011647 RID: 71239 RVA: 0x004CA88C File Offset: 0x004C8A8C
	protected override void OnBeforeCreate()
	{
		SkeletalObserverHandle skeletalObserverHandle = Singleton<UiSceneManager>.Instance.InitWeaponObserver(true);
		UiModelBase model = skeletalObserverHandle.Model;
		UiModelLoadingIconComponent uiModelLoadingIconComponent = (model != null) ? model.CheckGetComponent<UiModelLoadingIconComponent>() : null;
		if (uiModelLoadingIconComponent != null)
		{
			uiModelLoadingIconComponent.SetLoadingActive(false);
		}
		SkeletalObserverHandle weaponScabbardObserver = Singleton<UiSceneManager>.Instance.InitWeaponScabbardObserver();
		this.WeaponObservers = new WeaponSkeletalObserverHandles(skeletalObserverHandle, weaponScabbardObserver);
	}

	// Token: 0x0400888F RID: 34959
	[Nullable(2)]
	protected TabViewComponent<UiDynamicTab> TabViewComponent;

	// Token: 0x04008890 RID: 34960
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponentWithCaptionItem<CommonTabItem> TabComponent;

	// Token: 0x04008891 RID: 34961
	protected List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

	// Token: 0x04008892 RID: 34962
	private long PassEndTime;

	// Token: 0x04008893 RID: 34963
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x04008894 RID: 34964
	[Nullable(2)]
	private WeaponSkeletalObserverHandles WeaponObservers;

	// Token: 0x0200868F RID: 34447
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402D83B RID: 186427
		TabComponent,
		// Token: 0x0402D83C RID: 186428
		TabRootItem,
		// Token: 0x0402D83D RID: 186429
		Bg,
		// Token: 0x0402D83E RID: 186430
		TxtCountDown,
		// Token: 0x0402D83F RID: 186431
		EffectPanel1,
		// Token: 0x0402D840 RID: 186432
		EffectPanel2,
		// Token: 0x0402D841 RID: 186433
		EffectPanel3
	}
}
