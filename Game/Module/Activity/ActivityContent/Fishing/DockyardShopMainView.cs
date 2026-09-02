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

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067C5 RID: 26565
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardShopMainView : UiViewBase
	{
		// Token: 0x06042459 RID: 271449 RVA: 0x010FFCE2 File Offset: 0x010FDEE2
		public DockyardShopMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0604245A RID: 271450 RVA: 0x010FFD14 File Offset: 0x010FDF14
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604245B RID: 271451 RVA: 0x010FFDE0 File Offset: 0x010FDFE0
		private void InitCaption()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		}

		// Token: 0x0604245C RID: 271452 RVA: 0x010FFDF4 File Offset: 0x010FDFF4
		private UniTask RefreshCurrency(EUiTabViewName viewName)
		{
			DockyardShopMainView.<RefreshCurrency>d__13 <RefreshCurrency>d__;
			<RefreshCurrency>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCurrency>d__.<>4__this = this;
			<RefreshCurrency>d__.viewName = viewName;
			<RefreshCurrency>d__.<>1__state = -1;
			<RefreshCurrency>d__.<>t__builder.Start<DockyardShopMainView.<RefreshCurrency>d__13>(ref <RefreshCurrency>d__);
			return <RefreshCurrency>d__.<>t__builder.Task;
		}

		// Token: 0x0604245D RID: 271453 RVA: 0x010FFE40 File Offset: 0x010FE040
		private void RefreshBuyTabItemRedDot()
		{
			int shopId = ModelBase<DockyardModel>.Instance.ShopId;
			bool redDotActive = ModelBase<PayShopModel>.Instance.CheckShopItemCheckFlag((PayShopDefine.EPayShopTabType)shopId, 1);
			this.TabItemList[this.TabItemList.Count - 1].SetRedDotActive(redDotActive);
		}

		// Token: 0x0604245E RID: 271454 RVA: 0x010FFE84 File Offset: 0x010FE084
		private UniTask InitTabItem(UUIItem uiItem)
		{
			DockyardShopMainView.<InitTabItem>d__15 <InitTabItem>d__;
			<InitTabItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTabItem>d__.<>4__this = this;
			<InitTabItem>d__.uiItem = uiItem;
			<InitTabItem>d__.<>1__state = -1;
			<InitTabItem>d__.<>t__builder.Start<DockyardShopMainView.<InitTabItem>d__15>(ref <InitTabItem>d__);
			return <InitTabItem>d__.<>t__builder.Task;
		}

		// Token: 0x0604245F RID: 271455 RVA: 0x010FFED0 File Offset: 0x010FE0D0
		private UniTask InitTabComponent()
		{
			DockyardShopMainView.<InitTabComponent>d__16 <InitTabComponent>d__;
			<InitTabComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTabComponent>d__.<>4__this = this;
			<InitTabComponent>d__.<>1__state = -1;
			<InitTabComponent>d__.<>t__builder.Start<DockyardShopMainView.<InitTabComponent>d__16>(ref <InitTabComponent>d__);
			return <InitTabComponent>d__.<>t__builder.Task;
		}

		// Token: 0x06042460 RID: 271456 RVA: 0x010FFF14 File Offset: 0x010FE114
		private UniTask InitPlotPanel()
		{
			DockyardShopMainView.<InitPlotPanel>d__17 <InitPlotPanel>d__;
			<InitPlotPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPlotPanel>d__.<>4__this = this;
			<InitPlotPanel>d__.<>1__state = -1;
			<InitPlotPanel>d__.<>t__builder.Start<DockyardShopMainView.<InitPlotPanel>d__17>(ref <InitPlotPanel>d__);
			return <InitPlotPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06042461 RID: 271457 RVA: 0x010FFF57 File Offset: 0x010FE157
		private void InitUiBlur()
		{
			AUIBaseActor rootActor = this.RootActor;
			this.UiBlur = (((rootActor != null) ? rootActor.GetComponentByClass(TsUiBlur.StaticClass()) : null) as TsUiBlur);
			TsUiBlur uiBlur = this.UiBlur;
			if (uiBlur == null)
			{
				return;
			}
			uiBlur.SetEnableUiBlur(false);
		}

		// Token: 0x06042462 RID: 271458 RVA: 0x010FFF94 File Offset: 0x010FE194
		protected override UniTask OnBeforeStartAsync()
		{
			DockyardShopMainView.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DockyardShopMainView.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042463 RID: 271459 RVA: 0x010FFFD7 File Offset: 0x010FE1D7
		protected override void OnStart()
		{
			this.CacheData = Singleton<UiTimeDilation>.Instance.GetTimeDilationDataCopy();
			this.ShowPlotPanel("OpenShopView");
		}

		// Token: 0x06042464 RID: 271460 RVA: 0x010FFFF4 File Offset: 0x010FE1F4
		protected void PauseTimeDilation()
		{
			UiViewInfoForTimeDilation uiViewInfoForTimeDilation = new UiViewInfoForTimeDilation();
			uiViewInfoForTimeDilation.TimeDilation = 1f;
			uiViewInfoForTimeDilation.ViewId = base.GetViewId();
			UiViewInfo viewInfo = this.ViewInfo;
			uiViewInfoForTimeDilation.DebugName = ((viewInfo != null) ? new EUiViewName?(viewInfo.Name) : null);
			uiViewInfoForTimeDilation.Reason = "DockyardShopMainView.PauseTimeDilation";
			UiViewInfoForTimeDilation gameTimeDilation = uiViewInfoForTimeDilation;
			Singleton<UiTimeDilation>.Instance.SetGameTimeDilation(gameTimeDilation);
		}

		// Token: 0x06042465 RID: 271461 RVA: 0x0110005C File Offset: 0x010FE25C
		protected void ResumeTimeDilation()
		{
			if (this.CacheData != null)
			{
				UiViewInfoForTimeDilation gameTimeDilation = new UiViewInfoForTimeDilation
				{
					TimeDilation = this.CacheData.TimeDilation,
					ViewId = this.CacheData.ViewId,
					DebugName = this.CacheData.DebugName,
					Reason = "DockyardShopMainView.ResumeTimeDilation"
				};
				Singleton<UiTimeDilation>.Instance.SetGameTimeDilation(gameTimeDilation);
			}
		}

		// Token: 0x06042466 RID: 271462 RVA: 0x011000C1 File Offset: 0x010FE2C1
		protected override void OnBeforeShow()
		{
			this.HideCharacter();
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent != null)
			{
				tabViewComponent.SetCurrentTabViewState(true);
			}
			this.PauseTimeDilation();
		}

		// Token: 0x06042467 RID: 271463 RVA: 0x011000E1 File Offset: 0x010FE2E1
		protected override void OnBeforeHide()
		{
			this.ResumeTimeDilation();
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent != null)
			{
				tabViewComponent.SetCurrentTabViewState(false);
			}
			this.ShowCharacter();
		}

		// Token: 0x06042468 RID: 271464 RVA: 0x01100101 File Offset: 0x010FE301
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.PayShopGoodsBuy, new Action(this.HandleBuyItem));
			Singleton<EventSystem>.Instance.Add<EUiTabViewName?, UiTabViewBase>(EEventName.OpenTabView, new Action<EUiTabViewName?, UiTabViewBase>(this.OpenTabView));
		}

		// Token: 0x06042469 RID: 271465 RVA: 0x01100138 File Offset: 0x010FE338
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PayShopGoodsBuy, new Action(this.HandleBuyItem));
			Singleton<EventSystem>.Instance.Remove(EEventName.OpenTabView, new Action<EUiTabViewName?, UiTabViewBase>(this.OpenTabView));
		}

		// Token: 0x0604246A RID: 271466 RVA: 0x0110016F File Offset: 0x010FE36F
		private void HandleBuyItem()
		{
			this.ShowPlotPanel("BuyItem");
		}

		// Token: 0x0604246B RID: 271467 RVA: 0x0110017C File Offset: 0x010FE37C
		private void OpenTabView(EUiTabViewName? viewName, UiTabViewBase _)
		{
			if (viewName == EUiTabViewName.DockyardBuyTabView)
			{
				this.RefreshBuyTabItemRedDot();
			}
		}

		// Token: 0x0604246C RID: 271468 RVA: 0x011001B4 File Offset: 0x010FE3B4
		private void ToggleCallback(int tabIndex)
		{
			int currentTabIndex = this.CurrentTabIndex;
			this.CurrentTabIndex = tabIndex;
			if (currentTabIndex != -1)
			{
				this.TabItemList[currentTabIndex].SetToggleState(EToggleState.ETT_UnChecked, true);
			}
			UiDynamicTab data = this.TabDataList[tabIndex];
			EUiTabViewName euiTabViewName = (EUiTabViewName)data.ChildViewName;
			this.RefreshCurrency(euiTabViewName);
			if (euiTabViewName == EUiTabViewName.DockyardSellTabView)
			{
				this.TabViewComponent.ToggleCallBack(data, euiTabViewName, this.TabItemList[tabIndex], this.SellViewModel, null);
				return;
			}
			this.TabViewComponent.ToggleCallBack(data, euiTabViewName, this.TabItemList[tabIndex], null, null);
		}

		// Token: 0x0604246D RID: 271469 RVA: 0x01100261 File Offset: 0x010FE461
		private void CloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0604246E RID: 271470 RVA: 0x0110026C File Offset: 0x010FE46C
		private bool CanExecuteChange(int tabIndex, bool isForce)
		{
			if (this.CurrentTabIndex != -1 && (EUiTabViewName)this.TabDataList[this.CurrentTabIndex].ChildViewName == EUiTabViewName.DockyardSellTabView && this.SellViewModel.BackpackPanelModel.IsInSelectState)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SelectingQuit", Array.Empty<object>());
				return false;
			}
			return this.CurrentTabIndex != tabIndex;
		}

		// Token: 0x0604246F RID: 271471 RVA: 0x011002E0 File Offset: 0x010FE4E0
		protected void HideCharacter()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity != null)
			{
				ControllerBase<CreatureController>.Instance.SetActorVisible(getCurrentEntity.Entity, false, true, true, "DockyardShopMainView", false);
			}
		}

		// Token: 0x06042470 RID: 271472 RVA: 0x01100314 File Offset: 0x010FE514
		protected void ShowCharacter()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity != null)
			{
				ControllerBase<CreatureController>.Instance.SetActorVisible(getCurrentEntity.Entity, true, true, true, "DockyardShopMainView", false);
			}
		}

		// Token: 0x06042471 RID: 271473 RVA: 0x01100348 File Offset: 0x010FE548
		public void ShowPlotPanel(string performId)
		{
			this.PlotPanel.ShowPanel(performId);
		}

		// Token: 0x06042472 RID: 271474 RVA: 0x01100356 File Offset: 0x010FE556
		public void HidePlotPanel()
		{
			this.PlotPanel.HidePanel();
		}

		// Token: 0x06042473 RID: 271475 RVA: 0x01100363 File Offset: 0x010FE563
		public void NotifyUiBlur(bool isActive)
		{
			TsUiBlur uiBlur = this.UiBlur;
			if (uiBlur == null)
			{
				return;
			}
			uiBlur.SetEnableUiBlur(isActive);
		}

		// Token: 0x04024E70 RID: 151152
		protected PopupCaptionItem CaptionItem;

		// Token: 0x04024E71 RID: 151153
		protected TabViewComponent<UiDynamicTab> TabViewComponent;

		// Token: 0x04024E72 RID: 151154
		protected List<DockyardShopTabItem> TabItemList = new List<DockyardShopTabItem>();

		// Token: 0x04024E73 RID: 151155
		protected List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

		// Token: 0x04024E74 RID: 151156
		protected int CurrentTabIndex = -1;

		// Token: 0x04024E75 RID: 151157
		protected DockyardShopTabViewModel SellViewModel = new DockyardShopTabViewModel();

		// Token: 0x04024E76 RID: 151158
		protected DockyardShopPlotPanel PlotPanel;

		// Token: 0x04024E77 RID: 151159
		[Nullable(2)]
		protected TsUiBlur UiBlur;

		// Token: 0x04024E78 RID: 151160
		[Nullable(2)]
		protected IUiViewInfoForTimeDilation CacheData;

		// Token: 0x0200C809 RID: 51209
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D905 RID: 252165
			public const int CaptionItem = 0;

			// Token: 0x0403D906 RID: 252166
			public const int TabComponent = 1;

			// Token: 0x0403D907 RID: 252167
			public const int ShopTabItem = 2;

			// Token: 0x0403D908 RID: 252168
			public const int BuyTabItem = 3;

			// Token: 0x0403D909 RID: 252169
			public const int PlotItem = 4;
		}
	}
}
