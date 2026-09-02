using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EA2 RID: 20130
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseRankView : UiViewBase
	{
		// Token: 0x06034028 RID: 213032 RVA: 0x00D02B5E File Offset: 0x00D00D5E
		public TowerDefenseRankView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06034029 RID: 213033 RVA: 0x00D02B68 File Offset: 0x00D00D68
		protected unsafe override void OnRegisterComponent()
		{
			this.Vm = (this.OpenParam as TowerDefenseRankViewModel);
			this.Vm.RegisterView(this);
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.Vm.ToggleAnonymousClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603402A RID: 213034 RVA: 0x00D02CD8 File Offset: 0x00D00ED8
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefenseRankView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefenseRankView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603402B RID: 213035 RVA: 0x00D02D1C File Offset: 0x00D00F1C
		protected override void OnStart()
		{
			if (ModelBase<TowerDefenseModel>.Instance.RankData.IsOwnSingleBestScore(this.Vm.InstanceId))
			{
				RankTabItem layoutItemByIndex = this.TabLayout.GetLayoutItemByIndex(0);
				if (layoutItemByIndex == null)
				{
					return;
				}
				layoutItemByIndex.SetToggleState(true, true);
				return;
			}
			else
			{
				RankTabItem layoutItemByIndex2 = this.TabLayout.GetLayoutItemByIndex(1);
				if (layoutItemByIndex2 == null)
				{
					return;
				}
				layoutItemByIndex2.SetToggleState(true, true);
				return;
			}
		}

		// Token: 0x0603402C RID: 213036 RVA: 0x00D02D78 File Offset: 0x00D00F78
		private UniTask InitTabLayout()
		{
			TowerDefenseRankView.<InitTabLayout>d__8 <InitTabLayout>d__;
			<InitTabLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTabLayout>d__.<>4__this = this;
			<InitTabLayout>d__.<>1__state = -1;
			<InitTabLayout>d__.<>t__builder.Start<TowerDefenseRankView.<InitTabLayout>d__8>(ref <InitTabLayout>d__);
			return <InitTabLayout>d__.<>t__builder.Task;
		}

		// Token: 0x0603402D RID: 213037 RVA: 0x00D02DBB File Offset: 0x00D00FBB
		private void InitRankScroll()
		{
			this.RankScroll = new LoopScrollView<TowerDefenseRankItem, TowerDefenseRankItemData>(base.GetLoopScrollViewComponent(2), base.GetItem(3).GetOwner() as AUIBaseActor, new Func<TowerDefenseRankItem>(this.InitRankItem), false);
		}

		// Token: 0x0603402E RID: 213038 RVA: 0x00D02DF0 File Offset: 0x00D00FF0
		private void InitAnonymousToggle()
		{
			EToggleState state = ModelBase<TowerDefenseModel>.Instance.RankData.IsOpenAnonymousName ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(5).SetToggleState(state, false, false, false);
		}

		// Token: 0x0603402F RID: 213039 RVA: 0x00D02E24 File Offset: 0x00D01024
		private UniTask InitOwnRankItem()
		{
			TowerDefenseRankView.<InitOwnRankItem>d__11 <InitOwnRankItem>d__;
			<InitOwnRankItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitOwnRankItem>d__.<>4__this = this;
			<InitOwnRankItem>d__.<>1__state = -1;
			<InitOwnRankItem>d__.<>t__builder.Start<TowerDefenseRankView.<InitOwnRankItem>d__11>(ref <InitOwnRankItem>d__);
			return <InitOwnRankItem>d__.<>t__builder.Task;
		}

		// Token: 0x06034030 RID: 213040 RVA: 0x00D02E67 File Offset: 0x00D01067
		private RankTabItem InitTabItem()
		{
			return new RankTabItem
			{
				OpenParam = this.Vm
			};
		}

		// Token: 0x06034031 RID: 213041 RVA: 0x00D02E7A File Offset: 0x00D0107A
		private TowerDefenseRankItem InitRankItem()
		{
			return new TowerDefenseRankItem(false)
			{
				OpenParam = this.Vm
			};
		}

		// Token: 0x06034032 RID: 213042 RVA: 0x00D02E90 File Offset: 0x00D01090
		private UniTask RefreshRankLayout(TowerDefenceDefine.ETabType tabType)
		{
			TowerDefenseRankView.<RefreshRankLayout>d__14 <RefreshRankLayout>d__;
			<RefreshRankLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshRankLayout>d__.<>4__this = this;
			<RefreshRankLayout>d__.tabType = tabType;
			<RefreshRankLayout>d__.<>1__state = -1;
			<RefreshRankLayout>d__.<>t__builder.Start<TowerDefenseRankView.<RefreshRankLayout>d__14>(ref <RefreshRankLayout>d__);
			return <RefreshRankLayout>d__.<>t__builder.Task;
		}

		// Token: 0x06034033 RID: 213043 RVA: 0x00D02EDC File Offset: 0x00D010DC
		private void RefreshAnonymousToggle(TowerDefenceDefine.ETabType tabType)
		{
			TowerDefenseRankItemData selfRankDataByTabType = ModelBase<TowerDefenseModel>.Instance.RankData.GetSelfRankDataByTabType(tabType);
			base.GetExtendToggle(5).RootUIComp.Get().SetUIActive(selfRankDataByTabType.IsInRank);
		}

		// Token: 0x06034034 RID: 213044 RVA: 0x00D02F1C File Offset: 0x00D0111C
		public void ResetLastTabItemSelected(TowerDefenceDefine.ETabType tabType)
		{
			RankTabItem layoutItemByIndex = this.TabLayout.GetLayoutItemByIndex((int)tabType);
			if (layoutItemByIndex != null)
			{
				layoutItemByIndex.SetToggleState(false, false);
			}
		}

		// Token: 0x06034035 RID: 213045 RVA: 0x00D02F44 File Offset: 0x00D01144
		public void RefreshContent(TowerDefenceDefine.ETabType tabType)
		{
			TowerDefenseRankView.<>c__DisplayClass17_0 CS$<>8__locals1 = new TowerDefenseRankView.<>c__DisplayClass17_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.tabType = tabType;
			UiAsyncTask task = new UiAsyncTask("TowerDefenseRankView.RefreshContent", delegate()
			{
				TowerDefenseRankView.<>c__DisplayClass17_0.<<RefreshContent>b__0>d <<RefreshContent>b__0>d;
				<<RefreshContent>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshContent>b__0>d.<>4__this = CS$<>8__locals1;
				<<RefreshContent>b__0>d.<>1__state = -1;
				<<RefreshContent>b__0>d.<>t__builder.Start<TowerDefenseRankView.<>c__DisplayClass17_0.<<RefreshContent>b__0>d>(ref <<RefreshContent>b__0>d);
				return <<RefreshContent>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
			this.RefreshAnonymousToggle(CS$<>8__locals1.tabType);
		}

		// Token: 0x06034036 RID: 213046 RVA: 0x00D02F94 File Offset: 0x00D01194
		public void RefreshContentShowName()
		{
			int startGridIndex = this.RankScroll.StartGridIndex;
			int endGridIndex = this.RankScroll.EndGridIndex;
			for (int i = startGridIndex; i <= endGridIndex; i++)
			{
				TowerDefenseRankItemData towerDefenseRankItemData = this.RankScroll.TryGetCachedData(i);
				if (towerDefenseRankItemData != null && towerDefenseRankItemData.IsSelfInData)
				{
					TowerDefenseRankItem towerDefenseRankItem = this.RankScroll.UnsafeGetGridProxy(i, false);
					if (towerDefenseRankItem != null)
					{
						towerDefenseRankItem.RefreshPlayerName();
					}
				}
			}
		}

		// Token: 0x0401E0F8 RID: 123128
		private TowerDefenseRankItem OwnRankItem;

		// Token: 0x0401E0F9 RID: 123129
		private LoopScrollView<TowerDefenseRankItem, TowerDefenseRankItemData> RankScroll;

		// Token: 0x0401E0FA RID: 123130
		private GenericLayout<RankTabItem, TowerDefenceDefine.ETabType> TabLayout;

		// Token: 0x0401E0FB RID: 123131
		private TowerDefenseRankViewModel Vm;

		// Token: 0x0200AE46 RID: 44614
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x040361C2 RID: 221634
			public const int TabLayout = 0;

			// Token: 0x040361C3 RID: 221635
			public const int TabItem = 1;

			// Token: 0x040361C4 RID: 221636
			public const int RankScroll = 2;

			// Token: 0x040361C5 RID: 221637
			public const int RankItem = 3;

			// Token: 0x040361C6 RID: 221638
			public const int OwnRankItem = 4;

			// Token: 0x040361C7 RID: 221639
			public const int AnonymousToggle = 5;

			// Token: 0x040361C8 RID: 221640
			public const int EmptyItem = 6;
		}
	}
}
