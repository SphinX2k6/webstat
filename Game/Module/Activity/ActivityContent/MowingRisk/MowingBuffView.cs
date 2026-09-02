using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x020066A4 RID: 26276
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingBuffView : UiViewBase
	{
		// Token: 0x060419D9 RID: 268761 RVA: 0x010D3104 File Offset: 0x010D1304
		public MowingBuffView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060419DA RID: 268762 RVA: 0x010D3110 File Offset: 0x010D1310
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.HandleOnClickLeftToggle));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.HandleOnClickRightToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060419DB RID: 268763 RVA: 0x010D321C File Offset: 0x010D141C
		protected override UniTask OnBeforeStartAsync()
		{
			MowingBuffView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MowingBuffView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419DC RID: 268764 RVA: 0x010D325F File Offset: 0x010D145F
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.MowingBasicBuffGridItemClick, new Action(this.HandleMowingBasicBuffGridItemClick));
			Singleton<EventSystem>.Instance.Add(EEventName.MowingSuperBuffGridItemClick, new Action(this.HandleMowingSuperBuffGridItemClick));
		}

		// Token: 0x060419DD RID: 268765 RVA: 0x010D3299 File Offset: 0x010D1499
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.MowingBasicBuffGridItemClick, new Action(this.HandleMowingBasicBuffGridItemClick));
			Singleton<EventSystem>.Instance.Remove(EEventName.MowingSuperBuffGridItemClick, new Action(this.HandleMowingSuperBuffGridItemClick));
		}

		// Token: 0x060419DE RID: 268766 RVA: 0x010D32D3 File Offset: 0x010D14D3
		protected override void OnStart()
		{
			this.RefreshCaption();
			this.RefreshCurrentTab();
			this.RefreshAllTabView(false);
			this.BindTogglesCanExecuteChange();
		}

		// Token: 0x060419DF RID: 268767 RVA: 0x010D32EE File Offset: 0x010D14EE
		protected override void OnBeforeDestroy()
		{
			ModelBase<MowingRiskModel>.Instance.ResetBuffViewCache();
			this.UnbindTogglesCanExecuteChange();
		}

		// Token: 0x060419E0 RID: 268768 RVA: 0x010D3300 File Offset: 0x010D1500
		private void HandleOnClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x060419E1 RID: 268769 RVA: 0x010D330C File Offset: 0x010D150C
		private void HandleOnClickLeftToggle(EToggleState state)
		{
			UiAsyncTask task = new UiAsyncTask("MowingBuffView.RefreshTab", delegate()
			{
				MowingBuffView.<<HandleOnClickLeftToggle>b__11_0>d <<HandleOnClickLeftToggle>b__11_0>d;
				<<HandleOnClickLeftToggle>b__11_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<HandleOnClickLeftToggle>b__11_0>d.<>4__this = this;
				<<HandleOnClickLeftToggle>b__11_0>d.<>1__state = -1;
				<<HandleOnClickLeftToggle>b__11_0>d.<>t__builder.Start<MowingBuffView.<<HandleOnClickLeftToggle>b__11_0>d>(ref <<HandleOnClickLeftToggle>b__11_0>d);
				return <<HandleOnClickLeftToggle>b__11_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x060419E2 RID: 268770 RVA: 0x010D333C File Offset: 0x010D153C
		private UniTask HandleOnClickLeftToggleAsync()
		{
			MowingBuffView.<HandleOnClickLeftToggleAsync>d__12 <HandleOnClickLeftToggleAsync>d__;
			<HandleOnClickLeftToggleAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleOnClickLeftToggleAsync>d__.<>4__this = this;
			<HandleOnClickLeftToggleAsync>d__.<>1__state = -1;
			<HandleOnClickLeftToggleAsync>d__.<>t__builder.Start<MowingBuffView.<HandleOnClickLeftToggleAsync>d__12>(ref <HandleOnClickLeftToggleAsync>d__);
			return <HandleOnClickLeftToggleAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419E3 RID: 268771 RVA: 0x010D3380 File Offset: 0x010D1580
		private void HandleOnClickRightToggle(EToggleState state)
		{
			UiAsyncTask task = new UiAsyncTask("MowingBuffView.RefreshTab", delegate()
			{
				MowingBuffView.<<HandleOnClickRightToggle>b__13_0>d <<HandleOnClickRightToggle>b__13_0>d;
				<<HandleOnClickRightToggle>b__13_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<HandleOnClickRightToggle>b__13_0>d.<>4__this = this;
				<<HandleOnClickRightToggle>b__13_0>d.<>1__state = -1;
				<<HandleOnClickRightToggle>b__13_0>d.<>t__builder.Start<MowingBuffView.<<HandleOnClickRightToggle>b__13_0>d>(ref <<HandleOnClickRightToggle>b__13_0>d);
				return <<HandleOnClickRightToggle>b__13_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x060419E4 RID: 268772 RVA: 0x010D33B0 File Offset: 0x010D15B0
		private UniTask HandleOnClickRightToggleAsync()
		{
			MowingBuffView.<HandleOnClickRightToggleAsync>d__14 <HandleOnClickRightToggleAsync>d__;
			<HandleOnClickRightToggleAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleOnClickRightToggleAsync>d__.<>4__this = this;
			<HandleOnClickRightToggleAsync>d__.<>1__state = -1;
			<HandleOnClickRightToggleAsync>d__.<>t__builder.Start<MowingBuffView.<HandleOnClickRightToggleAsync>d__14>(ref <HandleOnClickRightToggleAsync>d__);
			return <HandleOnClickRightToggleAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419E5 RID: 268773 RVA: 0x010D33F4 File Offset: 0x010D15F4
		private void HandleMowingBasicBuffGridItemClick()
		{
			MowingRiskModel instance = ModelBase<MowingRiskModel>.Instance;
			if (instance.CurrentBuffViewType == EMowingBuffTabViewType.Progress)
			{
				return;
			}
			IMowingBuffOverviewData data = instance.BuildOverviewViewData();
			this.OverviewPanel.RefreshByCustomDataAsync(data);
		}

		// Token: 0x060419E6 RID: 268774 RVA: 0x010D3428 File Offset: 0x010D1628
		private void HandleMowingSuperBuffGridItemClick()
		{
			MowingRiskModel instance = ModelBase<MowingRiskModel>.Instance;
			if (instance.CurrentBuffViewType == EMowingBuffTabViewType.Overview)
			{
				return;
			}
			IMowingBuffProgressData data = instance.BuildProgressViewData();
			MowingBuffProgress progressPanel = this.ProgressPanel;
			if (progressPanel == null)
			{
				return;
			}
			progressPanel.RefreshByCustomData(data);
		}

		// Token: 0x060419E7 RID: 268775 RVA: 0x010D345C File Offset: 0x010D165C
		private bool HandleLeftCanExecuteChange()
		{
			return ModelBase<MowingRiskModel>.Instance.CurrentBuffViewType > EMowingBuffTabViewType.Overview;
		}

		// Token: 0x060419E8 RID: 268776 RVA: 0x010D346B File Offset: 0x010D166B
		private bool HandleRightCanExecuteChange()
		{
			return ModelBase<MowingRiskModel>.Instance.CurrentBuffViewType != EMowingBuffTabViewType.Progress;
		}

		// Token: 0x060419E9 RID: 268777 RVA: 0x010D3480 File Offset: 0x010D1680
		private List<UniTask> BuildTabItemTodoList()
		{
			List<UniTask> list = new List<UniTask>();
			list.Add(this.CreateOverviewAsync());
			list.Add(this.CreateCaptionAsync());
			if (ModelBase<MowingRiskModel>.Instance.CurrentBuffViewUsage == EMowingBuffViewUsage.InBattle)
			{
				list.Add(this.CreateProgressAsync());
			}
			return list;
		}

		// Token: 0x060419EA RID: 268778 RVA: 0x010D34C8 File Offset: 0x010D16C8
		private UniTask CreateOverviewAsync()
		{
			MowingBuffView.<CreateOverviewAsync>d__20 <CreateOverviewAsync>d__;
			<CreateOverviewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateOverviewAsync>d__.<>4__this = this;
			<CreateOverviewAsync>d__.<>1__state = -1;
			<CreateOverviewAsync>d__.<>t__builder.Start<MowingBuffView.<CreateOverviewAsync>d__20>(ref <CreateOverviewAsync>d__);
			return <CreateOverviewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419EB RID: 268779 RVA: 0x010D350C File Offset: 0x010D170C
		private UniTask CreateProgressAsync()
		{
			MowingBuffView.<CreateProgressAsync>d__21 <CreateProgressAsync>d__;
			<CreateProgressAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateProgressAsync>d__.<>4__this = this;
			<CreateProgressAsync>d__.<>1__state = -1;
			<CreateProgressAsync>d__.<>t__builder.Start<MowingBuffView.<CreateProgressAsync>d__21>(ref <CreateProgressAsync>d__);
			return <CreateProgressAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419EC RID: 268780 RVA: 0x010D3550 File Offset: 0x010D1750
		private UniTask CreateCaptionAsync()
		{
			MowingBuffView.<CreateCaptionAsync>d__22 <CreateCaptionAsync>d__;
			<CreateCaptionAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCaptionAsync>d__.<>4__this = this;
			<CreateCaptionAsync>d__.<>1__state = -1;
			<CreateCaptionAsync>d__.<>t__builder.Start<MowingBuffView.<CreateCaptionAsync>d__22>(ref <CreateCaptionAsync>d__);
			return <CreateCaptionAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419ED RID: 268781 RVA: 0x010D3594 File Offset: 0x010D1794
		private void RefreshCaption()
		{
			IMowingBuffCaptionData mowingBuffCaptionData = ModelBase<MowingRiskModel>.Instance.BuildCaptionViewData();
			this.CaptionPanel.SetTitleByTextIdAndArgNew(mowingBuffCaptionData.TitleTextId, Array.Empty<object>());
			this.CaptionPanel.SetTitleIcon(mowingBuffCaptionData.IconPath);
		}

		// Token: 0x060419EE RID: 268782 RVA: 0x010D35D4 File Offset: 0x010D17D4
		private void RefreshCurrentTab()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(2);
			if (ModelBase<MowingRiskModel>.Instance.CurrentBuffViewUsage == EMowingBuffViewUsage.BeforeBattle)
			{
				extendToggle.RootUIComp.Get().SetUIActive(true);
				extendToggle2.RootUIComp.Get().SetUIActive(false);
				extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				extendToggle.IsSelfInteractive = false;
				return;
			}
			bool currentBuffViewType = ModelBase<MowingRiskModel>.Instance.CurrentBuffViewType != EMowingBuffTabViewType.Overview;
			extendToggle.RootUIComp.Get().SetActive(true, false);
			extendToggle2.RootUIComp.Get().SetActive(true, false);
			if (!currentBuffViewType)
			{
				extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
				extendToggle2.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
				return;
			}
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			extendToggle2.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x060419EF RID: 268783 RVA: 0x010D3698 File Offset: 0x010D1898
		private void RefreshAllTabView(bool playStarAnim)
		{
			MowingBuffView.<>c__DisplayClass25_0 CS$<>8__locals1 = new MowingBuffView.<>c__DisplayClass25_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.playStarAnim = playStarAnim;
			UiAsyncTask task = new UiAsyncTask("MowingBuffView.RefreshTab", delegate()
			{
				MowingBuffView.<>c__DisplayClass25_0.<<RefreshAllTabView>b__0>d <<RefreshAllTabView>b__0>d;
				<<RefreshAllTabView>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshAllTabView>b__0>d.<>4__this = CS$<>8__locals1;
				<<RefreshAllTabView>b__0>d.<>1__state = -1;
				<<RefreshAllTabView>b__0>d.<>t__builder.Start<MowingBuffView.<>c__DisplayClass25_0.<<RefreshAllTabView>b__0>d>(ref <<RefreshAllTabView>b__0>d);
				return <<RefreshAllTabView>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x060419F0 RID: 268784 RVA: 0x010D36DC File Offset: 0x010D18DC
		private UniTask RefreshAllTabViewAsync(bool playStarAnim)
		{
			MowingBuffView.<RefreshAllTabViewAsync>d__26 <RefreshAllTabViewAsync>d__;
			<RefreshAllTabViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAllTabViewAsync>d__.<>4__this = this;
			<RefreshAllTabViewAsync>d__.playStarAnim = playStarAnim;
			<RefreshAllTabViewAsync>d__.<>1__state = -1;
			<RefreshAllTabViewAsync>d__.<>t__builder.Start<MowingBuffView.<RefreshAllTabViewAsync>d__26>(ref <RefreshAllTabViewAsync>d__);
			return <RefreshAllTabViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419F1 RID: 268785 RVA: 0x010D3728 File Offset: 0x010D1928
		private UniTask RefreshOverviewTabViewAsync(bool playStarAnim)
		{
			MowingBuffView.<RefreshOverviewTabViewAsync>d__27 <RefreshOverviewTabViewAsync>d__;
			<RefreshOverviewTabViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshOverviewTabViewAsync>d__.<>4__this = this;
			<RefreshOverviewTabViewAsync>d__.playStarAnim = playStarAnim;
			<RefreshOverviewTabViewAsync>d__.<>1__state = -1;
			<RefreshOverviewTabViewAsync>d__.<>t__builder.Start<MowingBuffView.<RefreshOverviewTabViewAsync>d__27>(ref <RefreshOverviewTabViewAsync>d__);
			return <RefreshOverviewTabViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419F2 RID: 268786 RVA: 0x010D3774 File Offset: 0x010D1974
		private UniTask RefreshProgressTabViewAsync(bool playStarAnim)
		{
			MowingBuffView.<RefreshProgressTabViewAsync>d__28 <RefreshProgressTabViewAsync>d__;
			<RefreshProgressTabViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshProgressTabViewAsync>d__.<>4__this = this;
			<RefreshProgressTabViewAsync>d__.playStarAnim = playStarAnim;
			<RefreshProgressTabViewAsync>d__.<>1__state = -1;
			<RefreshProgressTabViewAsync>d__.<>t__builder.Start<MowingBuffView.<RefreshProgressTabViewAsync>d__28>(ref <RefreshProgressTabViewAsync>d__);
			return <RefreshProgressTabViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419F3 RID: 268787 RVA: 0x010D37C0 File Offset: 0x010D19C0
		private void BindTogglesCanExecuteChange()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(2);
			extendToggle.CanExecuteChange.Bind(new Func<bool>(this.HandleLeftCanExecuteChange));
			extendToggle2.CanExecuteChange.Bind(new Func<bool>(this.HandleRightCanExecuteChange));
		}

		// Token: 0x060419F4 RID: 268788 RVA: 0x010D380C File Offset: 0x010D1A0C
		private void UnbindTogglesCanExecuteChange()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(2);
			extendToggle.CanExecuteChange.Unbind();
			extendToggle2.CanExecuteChange.Unbind();
		}

		// Token: 0x04024A3B RID: 150075
		private MowingBuffOverview OverviewPanel;

		// Token: 0x04024A3C RID: 150076
		[Nullable(2)]
		private MowingBuffProgress ProgressPanel;

		// Token: 0x04024A3D RID: 150077
		private PopupCaptionItem CaptionPanel;

		// Token: 0x0200C6BB RID: 50875
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D313 RID: 250643
			public const int CaptionItem = 0;

			// Token: 0x0403D314 RID: 250644
			public const int LeftToggle = 1;

			// Token: 0x0403D315 RID: 250645
			public const int RightToggle = 2;

			// Token: 0x0403D316 RID: 250646
			public const int ContentItem = 3;
		}
	}
}
