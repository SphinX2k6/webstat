using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Sheriff.View.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View
{
	// Token: 0x02004FD2 RID: 20434
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffMainView : UiViewBase
	{
		// Token: 0x06034B0B RID: 215819 RVA: 0x00D36923 File Offset: 0x00D34B23
		public SheriffMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034B0C RID: 215820 RVA: 0x00D36938 File Offset: 0x00D34B38
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnTips));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034B0D RID: 215821 RVA: 0x00D36A20 File Offset: 0x00D34C20
		protected override UniTask OnBeforeStartAsync()
		{
			SheriffMainView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SheriffMainView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034B0E RID: 215822 RVA: 0x00D36A64 File Offset: 0x00D34C64
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
			int gameplayId = (int)this.OpenParam;
			this.Proxy = new SheriffMainProxy(gameplayId);
			this.Proxy.InitData();
			this.Proxy.InitGameDataOnBegin();
			this.Proxy.OnClueRecordsCallback = new Action(this.OnClueRecordsCallback);
			this.Proxy.OnAnalysisClueEndCallback = new Action<bool>(this.OnAnalysisClueEndCallback);
			this.Proxy.OnBackFromDetailClueCallback = new Action(this.OnBackFromDetailClueCallback);
			this.Proxy.OnCheckClueDetailCallback = new Action(this.OnCheckClueDetailCallback);
			this.Proxy.OnConclusionInfoCallback = new Action(this.OnConclusionInfoCallback);
			this.Proxy.OnGameplayAllEndCallback = new Action(this.OnGameplayAllEndCallback);
			this.Proxy.OnClickedReplayDialog = new Action(this.OnClickedReplayDialog);
			this.Proxy.OnRefreshHintButton = new Action<bool>(this.OnRefreshHintButton);
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickedClose));
			this.CaptionItem.SetHelpBtnActive(false);
			this.TabDataList = ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(EUiViewName.SheriffMainView);
			this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(1), EKeyMode.Default);
			base.GetButton(2).RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x06034B0F RID: 215823 RVA: 0x00D36BE4 File Offset: 0x00D34DE4
		protected override void OnBeforeShow()
		{
			this.RefreshDialogBeforeSelectClue();
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent == null)
			{
				return;
			}
			tabViewComponent.ToggleCallBack(this.TabDataList[0], EUiTabViewName.SheriffMainSelectCluePanel, null, this.Proxy, null);
		}

		// Token: 0x06034B10 RID: 215824 RVA: 0x00D36C28 File Offset: 0x00D34E28
		protected override void OnBeforeDestroy()
		{
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent != null)
			{
				tabViewComponent.DestroyTabViewComponent();
			}
			this.TabViewComponent = null;
		}

		// Token: 0x06034B11 RID: 215825 RVA: 0x00D36C44 File Offset: 0x00D34E44
		protected void RefreshDialogBeforeSelectClue()
		{
			List<string> beforeDialogStateId = this.Proxy.GetBeforeDialogStateId();
			this.DialogPanel.SetUiActive(beforeDialogStateId.Count > 0);
			this.DialogPanel.Refresh(beforeDialogStateId);
		}

		// Token: 0x06034B12 RID: 215826 RVA: 0x00D36C80 File Offset: 0x00D34E80
		protected void RefreshHintButton(bool isCurIndex)
		{
			bool flag = this.Proxy.CheckNeedHintButton();
			bool flag2 = isCurIndex && flag;
			base.GetButton(2).RootUIComp.Get().SetUIActive(flag2);
			if (flag2)
			{
				this.LevelSequencePlayer.PlayOrReplaySequenceByName("ClueNotice", false, null);
			}
		}

		// Token: 0x06034B13 RID: 215827 RVA: 0x00D36CD4 File Offset: 0x00D34ED4
		private void OnClueRecordsCallback()
		{
			this.CaptionItem.SetUiActive(false);
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent == null)
			{
				return;
			}
			tabViewComponent.ToggleCallBack(this.TabDataList[1], EUiTabViewName.SheriffMainAnalysisCluePanel, null, this.Proxy, null);
		}

		// Token: 0x06034B14 RID: 215828 RVA: 0x00D36D20 File Offset: 0x00D34F20
		private void OnAnalysisClueEndCallback(bool isSuccess)
		{
			this.CaptionItem.SetUiActive(true);
			this.RefreshHintButton(true);
			if (isSuccess)
			{
				this.RefreshDialogBeforeSelectClue();
			}
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent == null)
			{
				return;
			}
			tabViewComponent.ToggleCallBack(this.TabDataList[0], EUiTabViewName.SheriffMainSelectCluePanel, null, this.Proxy, null);
		}

		// Token: 0x06034B15 RID: 215829 RVA: 0x00D36D7C File Offset: 0x00D34F7C
		private void OnBackFromDetailClueCallback()
		{
			this.CaptionItem.SetUiActive(true);
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent == null)
			{
				return;
			}
			tabViewComponent.ToggleCallBack(this.TabDataList[0], EUiTabViewName.SheriffMainSelectCluePanel, null, this.Proxy, null);
		}

		// Token: 0x06034B16 RID: 215830 RVA: 0x00D36DC8 File Offset: 0x00D34FC8
		private void OnCheckClueDetailCallback()
		{
			this.CaptionItem.SetUiActive(false);
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent == null)
			{
				return;
			}
			tabViewComponent.ToggleCallBack(this.TabDataList[2], EUiTabViewName.SheriffMainClueDetailPanel, null, this.Proxy, null);
		}

		// Token: 0x06034B17 RID: 215831 RVA: 0x00D36E14 File Offset: 0x00D35014
		private void OnConclusionInfoCallback()
		{
			this.CaptionItem.SetUiActive(false);
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent == null)
			{
				return;
			}
			tabViewComponent.ToggleCallBack(this.TabDataList[3], EUiTabViewName.SheriffMainConclusionPanel, null, this.Proxy, null);
		}

		// Token: 0x06034B18 RID: 215832 RVA: 0x00D36E5E File Offset: 0x00D3505E
		private void OnGameplayAllEndCallback()
		{
			base.CloseMe(null);
		}

		// Token: 0x06034B19 RID: 215833 RVA: 0x00D36E67 File Offset: 0x00D35067
		private void OnClickedReplayDialog()
		{
			this.RefreshDialogBeforeSelectClue();
		}

		// Token: 0x06034B1A RID: 215834 RVA: 0x00D36E6F File Offset: 0x00D3506F
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent == null)
			{
				return null;
			}
			UiTabViewBase currentTabView = tabViewComponent.GetCurrentTabView();
			if (currentTabView == null)
			{
				return null;
			}
			return currentTabView.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x06034B1B RID: 215835 RVA: 0x00D36E8E File Offset: 0x00D3508E
		private void OnClickBtnTips()
		{
			this.Proxy.SetNeedHintToggle(true);
			this.Proxy.RefreshHintToggleState();
		}

		// Token: 0x06034B1C RID: 215836 RVA: 0x00D36EA8 File Offset: 0x00D350A8
		private void OnClickedClose()
		{
			if (this.Proxy.GetCurQuestionIndex() == 0)
			{
				base.CloseMe(null);
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SheriffCloseConfirm);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				base.CloseMe(null);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06034B1D RID: 215837 RVA: 0x00D36EF9 File Offset: 0x00D350F9
		private void OnRefreshHintButton(bool isCurIndex)
		{
			this.RefreshHintButton(isCurIndex);
		}

		// Token: 0x0401E5F8 RID: 124408
		protected SheriffMainDialogPanel DialogPanel;

		// Token: 0x0401E5F9 RID: 124409
		private List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

		// Token: 0x0401E5FA RID: 124410
		protected PopupCaptionItem CaptionItem;

		// Token: 0x0401E5FB RID: 124411
		protected SheriffMainProxy Proxy;

		// Token: 0x0401E5FC RID: 124412
		[Nullable(2)]
		protected TabViewComponent<UiDynamicTab> TabViewComponent;

		// Token: 0x0401E5FD RID: 124413
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200AF9D RID: 44957
		[NullableContext(0)]
		private static class EDefine
		{
			// Token: 0x040367FB RID: 223227
			public const int Caption = 0;

			// Token: 0x040367FC RID: 223228
			public const int Content = 1;

			// Token: 0x040367FD RID: 223229
			public const int BtnTips = 2;

			// Token: 0x040367FE RID: 223230
			public const int DialogItem = 3;
		}
	}
}
