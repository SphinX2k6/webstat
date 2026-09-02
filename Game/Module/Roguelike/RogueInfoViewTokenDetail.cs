using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200517B RID: 20859
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueInfoViewTokenDetail : UiPanelBase
	{
		// Token: 0x06035AB9 RID: 219833 RVA: 0x00D7B3B0 File Offset: 0x00D795B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035ABA RID: 219834 RVA: 0x00D7B43A File Offset: 0x00D7963A
		protected override void OnBeforeCreateImplement()
		{
			this.UiViewSequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.UiViewSequence);
		}

		// Token: 0x06035ABB RID: 219835 RVA: 0x00D7B454 File Offset: 0x00D79654
		protected override UniTask OnBeforeStartAsync()
		{
			RogueInfoViewTokenDetail.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueInfoViewTokenDetail.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035ABC RID: 219836 RVA: 0x00D7B498 File Offset: 0x00D79698
		private int SortBuffEntry(RogueGainEntry a, RogueGainEntry b)
		{
			RogueBuffPool? rogueBuffConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueBuffConfig(a.ConfigId);
			int? num = (rogueBuffConfig != null) ? new int?(rogueBuffConfig.GetValueOrDefault().Quality) : null;
			rogueBuffConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueBuffConfig(b.ConfigId);
			int? num2 = (rogueBuffConfig != null) ? new int?(rogueBuffConfig.GetValueOrDefault().Quality) : null;
			if (num == null || num2 == null)
			{
				return b.ConfigId - a.ConfigId;
			}
			return num2.Value - num.Value;
		}

		// Token: 0x06035ABD RID: 219837 RVA: 0x00D7B54A File Offset: 0x00D7974A
		protected override void OnStart()
		{
			this.DetailItem.SetActive(false);
		}

		// Token: 0x06035ABE RID: 219838 RVA: 0x00D7B558 File Offset: 0x00D79758
		protected override void OnAfterShow()
		{
			if (this.Vm != null && this.Vm.IsBuffEntryEmpty())
			{
				return;
			}
			this.LoopScrollView.SelectGridProxy(0, true);
		}

		// Token: 0x06035ABF RID: 219839 RVA: 0x00D7B580 File Offset: 0x00D79780
		public void SelectFirstGrid()
		{
			RogueInfoViewModel vm = this.Vm;
			if (vm != null && vm.IsBuffEntryEmpty())
			{
				return;
			}
			LoopScrollView<RogueInfoViewTokenDetailGrid, RogueGainEntry> loopScrollView = this.LoopScrollView;
			RogueGainEntry rogueGainEntry;
			if (loopScrollView == null)
			{
				rogueGainEntry = null;
			}
			else
			{
				RogueInfoViewTokenDetailGrid rogueInfoViewTokenDetailGrid = loopScrollView.UnsafeGetGridProxy(0, false);
				rogueGainEntry = ((rogueInfoViewTokenDetailGrid != null) ? rogueInfoViewTokenDetailGrid.GridData : null);
			}
			RogueGainEntry rogueGainEntry2 = rogueGainEntry;
			if (rogueGainEntry2 == null)
			{
				return;
			}
			this.OnSelected(rogueGainEntry2, 0);
		}

		// Token: 0x06035AC0 RID: 219840 RVA: 0x00D7B5CF File Offset: 0x00D797CF
		private RogueInfoViewTokenDetailGrid OnCreateGrid()
		{
			return new RogueInfoViewTokenDetailGrid();
		}

		// Token: 0x06035AC1 RID: 219841 RVA: 0x00D7B5D6 File Offset: 0x00D797D6
		public void Update(List<RogueGainEntry> dataList)
		{
			if (dataList.Count <= 0)
			{
				CommonSelectItem detailItem = this.DetailItem;
				if (detailItem != null)
				{
					detailItem.SetActive(false);
				}
			}
			LoopScrollView<RogueInfoViewTokenDetailGrid, RogueGainEntry> loopScrollView = this.LoopScrollView;
			if (loopScrollView == null)
			{
				return;
			}
			loopScrollView.ReloadData(this.GetSortedBuffEntryList(dataList), false);
		}

		// Token: 0x06035AC2 RID: 219842 RVA: 0x00D7B60C File Offset: 0x00D7980C
		public void OnSelected(RogueGainEntry data, int index)
		{
			int selectedGridIndex = this.LoopScrollView.GetSelectedGridIndex();
			this.LoopScrollView.SelectGridProxy(index, false);
			this.LoopScrollView.RefreshGridProxy(selectedGridIndex);
			this.DetailItem.SetActive(true);
			this.DetailItem.Update(data);
		}

		// Token: 0x06035AC3 RID: 219843 RVA: 0x00D7B656 File Offset: 0x00D79856
		public void SetViewModel(RogueInfoViewModel vm)
		{
			this.Vm = vm;
			this.Update(vm.BuffEntryList);
		}

		// Token: 0x06035AC4 RID: 219844 RVA: 0x00D7B66C File Offset: 0x00D7986C
		public void RefreshSelectedDetail()
		{
			if (this.DetailItem == null || this.Vm == null || !this.DetailItem.GetRootItem().IsUIActiveSelf())
			{
				return;
			}
			RogueGainEntry rogueGainEntry = this.DetailItem.RogueGainEntry;
			if (rogueGainEntry == null)
			{
				this.DetailItem.SetActive(false);
				return;
			}
			RogueGainEntry rogueGainEntry2 = null;
			foreach (RogueGainEntry rogueGainEntry3 in this.Vm.BuffEntryList)
			{
				if (rogueGainEntry3.IncId == rogueGainEntry.IncId)
				{
					rogueGainEntry2 = rogueGainEntry3;
					break;
				}
			}
			if (rogueGainEntry2 == null)
			{
				this.DetailItem.SetActive(false);
				return;
			}
			this.DetailItem.Update(rogueGainEntry2);
		}

		// Token: 0x06035AC5 RID: 219845 RVA: 0x00D7B72C File Offset: 0x00D7992C
		private List<RogueGainEntry> GetSortedBuffEntryList(List<RogueGainEntry> dataList)
		{
			List<RogueGainEntry> list = dataList.ToList<RogueGainEntry>();
			list.Sort(new Comparison<RogueGainEntry>(this.SortBuffEntry));
			return list;
		}

		// Token: 0x06035AC6 RID: 219846 RVA: 0x00D7B748 File Offset: 0x00D79948
		private UniTask RefreshTokenListAsync(List<RogueGainEntry> dataList)
		{
			RogueInfoViewTokenDetail.<RefreshTokenListAsync>d__18 <RefreshTokenListAsync>d__;
			<RefreshTokenListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTokenListAsync>d__.<>4__this = this;
			<RefreshTokenListAsync>d__.dataList = dataList;
			<RefreshTokenListAsync>d__.<>1__state = -1;
			<RefreshTokenListAsync>d__.<>t__builder.Start<RogueInfoViewTokenDetail.<RefreshTokenListAsync>d__18>(ref <RefreshTokenListAsync>d__);
			return <RefreshTokenListAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401ECF2 RID: 126194
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public LoopScrollView<RogueInfoViewTokenDetailGrid, RogueGainEntry> LoopScrollView;

		// Token: 0x0401ECF3 RID: 126195
		[Nullable(2)]
		public CommonSelectItem DetailItem;

		// Token: 0x0401ECF4 RID: 126196
		[Nullable(2)]
		public UiBehaviorLevelSequence UiViewSequence;

		// Token: 0x0401ECF5 RID: 126197
		[Nullable(2)]
		private RogueInfoViewModel Vm;

		// Token: 0x0200B12F RID: 45359
		[NullableContext(0)]
		private class ERogueInfoViewDetailDefine
		{
			// Token: 0x04036F42 RID: 225090
			public const int LoopScrollItem = 0;

			// Token: 0x04036F43 RID: 225091
			public const int GridItem = 1;

			// Token: 0x04036F44 RID: 225092
			public const int DetailItem = 2;
		}
	}
}
