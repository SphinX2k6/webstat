using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005174 RID: 20852
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueInfoView : UiViewBase
	{
		// Token: 0x06035A87 RID: 219783 RVA: 0x00D7A66A File Offset: 0x00D7886A
		[NullableContext(1)]
		public RogueInfoView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035A88 RID: 219784 RVA: 0x00D7A674 File Offset: 0x00D78874
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnToggleOverview));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnToggleToken));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action<EToggleState>(this.OnToggleSpecial));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035A89 RID: 219785 RVA: 0x00D7A8AF File Offset: 0x00D78AAF
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<RogueGainEntry, int>(EEventName.RoguelikeInfoSelectedToken, new Action<RogueGainEntry, int>(this.OnSelectedToken));
			Singleton<EventSystem>.Instance.Add(EEventName.RoguelikeDataUpdate, new Action(this.OnRoguelikeDataUpdate));
		}

		// Token: 0x06035A8A RID: 219786 RVA: 0x00D7A8E9 File Offset: 0x00D78AE9
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<RogueGainEntry, int>(EEventName.RoguelikeInfoSelectedToken, new Action<RogueGainEntry, int>(this.OnSelectedToken));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeDataUpdate, new Action(this.OnRoguelikeDataUpdate));
		}

		// Token: 0x06035A8B RID: 219787 RVA: 0x00D7A924 File Offset: 0x00D78B24
		private void OnRoguelikeDataUpdate()
		{
			RogueInfoOverview overviewPage = this.OverviewPage;
			if (overviewPage != null)
			{
				overviewPage.SetViewModel(this.Vm);
			}
			RogueInfoViewTokenDetail tokenDetailPage = this.TokenDetailPage;
			if (tokenDetailPage != null)
			{
				tokenDetailPage.SetViewModel(this.Vm);
			}
			RogueInfoViewTokenDetail tokenDetailPage2 = this.TokenDetailPage;
			if (tokenDetailPage2 != null)
			{
				tokenDetailPage2.RefreshSelectedDetail();
			}
			RogueInfoSpecialView specialPage = this.SpecialPage;
			if (specialPage == null)
			{
				return;
			}
			specialPage.Refresh(this.Vm.SpecialEntryList);
		}

		// Token: 0x06035A8C RID: 219788 RVA: 0x00D7A98B File Offset: 0x00D78B8B
		[NullableContext(1)]
		private void OnSelectedToken(RogueGainEntry token, int index)
		{
			this.TokenDetailPage.OnSelected(token, index);
		}

		// Token: 0x06035A8D RID: 219789 RVA: 0x00D7A99A File Offset: 0x00D78B9A
		private void OnToggleOverview(EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			this.ChangePage(0);
		}

		// Token: 0x06035A8E RID: 219790 RVA: 0x00D7A9A8 File Offset: 0x00D78BA8
		private void OnToggleToken(EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			this.ChangePage(1);
		}

		// Token: 0x06035A8F RID: 219791 RVA: 0x00D7A9B6 File Offset: 0x00D78BB6
		private void OnToggleSpecial(EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			this.ChangePage(2);
		}

		// Token: 0x06035A90 RID: 219792 RVA: 0x00D7A9C4 File Offset: 0x00D78BC4
		protected override UniTask OnBeforeStartAsync()
		{
			RogueInfoView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueInfoView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035A91 RID: 219793 RVA: 0x00D7AA08 File Offset: 0x00D78C08
		protected override void OnStart()
		{
			this.TopPanel.CloseCallback = delegate()
			{
				base.CloseMe(null);
			};
			this.ElementPanel.Refresh(this.Vm.GetElementInfoList());
			this.OverviewPage.SetViewModel(this.Vm);
			this.TokenDetailPage.SetViewModel(this.Vm);
			this.SpecialPage.Refresh(this.Vm.SpecialEntryList);
			ERogueInfoViewPage defaultPage = this.Vm.DefaultPage;
			int toggleIdByPage = this.GetToggleIdByPage(defaultPage);
			base.GetExtendToggle(toggleIdByPage).SetToggleState(EToggleState.ETT_Checked, false, false, false);
			this.ChangePage((int)defaultPage);
		}

		// Token: 0x06035A92 RID: 219794 RVA: 0x00D7AAA6 File Offset: 0x00D78CA6
		private int GetToggleIdByPage(ERogueInfoViewPage page)
		{
			if (page == ERogueInfoViewPage.Token)
			{
				return 5;
			}
			if (page != ERogueInfoViewPage.Special)
			{
				return 4;
			}
			return 9;
		}

		// Token: 0x06035A93 RID: 219795 RVA: 0x00D7AAB8 File Offset: 0x00D78CB8
		public void ChangePage(int page)
		{
			if (this.CurSelectPageType != null)
			{
				int? curSelectPageType = this.CurSelectPageType;
				int num = 0;
				if (curSelectPageType.GetValueOrDefault() == num & curSelectPageType != null)
				{
					this.OverviewPage.UiViewSequence.PlaySequence("Close", false, null);
				}
				else if (this.CurSelectPageType.GetValueOrDefault() == 1)
				{
					this.TokenDetailPage.UiViewSequence.PlaySequence("Close", false, null);
				}
				else
				{
					this.SpecialPage.UiViewSequence.PlaySequence("Close", false, null);
				}
			}
			this.TokenDetailPage.SetActive(page == 1);
			this.OverviewPage.SetActive(page == 0);
			this.SpecialPage.SetActive(page == 2);
			this.TokenDetailPage.Update(this.Vm.BuffEntryList);
			if (page == 0)
			{
				base.GetItem(8).SetUIActive(false);
				this.OverviewPage.UiViewSequence.PlaySequence("Start", false, null);
				return;
			}
			if (page == 1)
			{
				this.TokenDetailPage.UiViewSequence.PlaySequence("Start", false, null);
				bool flag = this.Vm.IsBuffEntryEmpty();
				base.GetItem(8).SetUIActive(flag);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "RogueNoTokenTips", Array.Empty<object>());
				if (!flag)
				{
					this.TokenDetailPage.SelectFirstGrid();
					return;
				}
			}
			else
			{
				this.SpecialPage.UiViewSequence.PlaySequence("Start", false, null);
				base.GetItem(8).SetUIActive(this.Vm.IsSpecialEntryEmpty());
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "RogueNoSpecialTips", Array.Empty<object>());
			}
		}

		// Token: 0x06035A94 RID: 219796 RVA: 0x00D7AC90 File Offset: 0x00D78E90
		private void RefreshViewModel()
		{
			RogueInfoViewModel rogueInfoViewModel = this.OpenParam as RogueInfoViewModel;
			if (rogueInfoViewModel == null)
			{
				return;
			}
			this.Vm = rogueInfoViewModel;
		}

		// Token: 0x0401ECE5 RID: 126181
		public TopPanel TopPanel;

		// Token: 0x0401ECE6 RID: 126182
		public ElementPanel ElementPanel;

		// Token: 0x0401ECE7 RID: 126183
		public RogueInfoViewTokenDetail TokenDetailPage;

		// Token: 0x0401ECE8 RID: 126184
		public RogueInfoOverview OverviewPage;

		// Token: 0x0401ECE9 RID: 126185
		private RogueInfoSpecialView SpecialPage;

		// Token: 0x0401ECEA RID: 126186
		[Nullable(1)]
		private RogueInfoViewModel Vm;

		// Token: 0x0401ECEB RID: 126187
		private int? CurSelectPageType;

		// Token: 0x0200B129 RID: 45353
		[NullableContext(0)]
		private class ERogueInfoViewDefine
		{
			// Token: 0x04036F2C RID: 225068
			public const int TitleItem = 0;

			// Token: 0x04036F2D RID: 225069
			public const int ItemContentItem = 1;

			// Token: 0x04036F2E RID: 225070
			public const int ElementInfoItem = 2;

			// Token: 0x04036F2F RID: 225071
			public const int TabItem = 3;

			// Token: 0x04036F30 RID: 225072
			public const int ToggleOverview = 4;

			// Token: 0x04036F31 RID: 225073
			public const int ToggleToken = 5;

			// Token: 0x04036F32 RID: 225074
			public const int TokenItem = 6;

			// Token: 0x04036F33 RID: 225075
			public const int OverviewItem = 7;

			// Token: 0x04036F34 RID: 225076
			public const int EmptyItem = 8;

			// Token: 0x04036F35 RID: 225077
			public const int ToggleSpecial = 9;

			// Token: 0x04036F36 RID: 225078
			public const int SpecialItem = 10;

			// Token: 0x04036F37 RID: 225079
			public const int EmptyText = 11;
		}
	}
}
