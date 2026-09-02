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
	// Token: 0x02004EA5 RID: 20133
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseRankViewV2 : UiViewBase
	{
		// Token: 0x06034043 RID: 213059 RVA: 0x00D0322D File Offset: 0x00D0142D
		public TowerDefenseRankViewV2(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06034044 RID: 213060 RVA: 0x00D03238 File Offset: 0x00D01438
		protected unsafe override void OnRegisterComponent()
		{
			this.Vm = (this.OpenParam as TowerDefenseRankViewModelV2);
			this.Vm.RegisterView(this);
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034045 RID: 213061 RVA: 0x00D03364 File Offset: 0x00D01564
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefenseRankViewV2.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefenseRankViewV2.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034046 RID: 213062 RVA: 0x00D033A8 File Offset: 0x00D015A8
		private UniTask InitCaption()
		{
			TowerDefenseRankViewV2.<InitCaption>d__11 <InitCaption>d__;
			<InitCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCaption>d__.<>4__this = this;
			<InitCaption>d__.<>1__state = -1;
			<InitCaption>d__.<>t__builder.Start<TowerDefenseRankViewV2.<InitCaption>d__11>(ref <InitCaption>d__);
			return <InitCaption>d__.<>t__builder.Task;
		}

		// Token: 0x06034047 RID: 213063 RVA: 0x00D033EC File Offset: 0x00D015EC
		private UniTask InitAnonymousToggle()
		{
			TowerDefenseRankViewV2.<InitAnonymousToggle>d__12 <InitAnonymousToggle>d__;
			<InitAnonymousToggle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAnonymousToggle>d__.<>4__this = this;
			<InitAnonymousToggle>d__.<>1__state = -1;
			<InitAnonymousToggle>d__.<>t__builder.Start<TowerDefenseRankViewV2.<InitAnonymousToggle>d__12>(ref <InitAnonymousToggle>d__);
			return <InitAnonymousToggle>d__.<>t__builder.Task;
		}

		// Token: 0x06034048 RID: 213064 RVA: 0x00D03430 File Offset: 0x00D01630
		private void InitAnonymousToggleState()
		{
			EToggleState toggleState = ModelBase<TowerDefenseModel>.Instance.RankData.IsOpenAnonymousName ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			PopupCaptionToggleItem anonymousToggle = this.AnonymousToggle;
			if (anonymousToggle == null)
			{
				return;
			}
			anonymousToggle.InitToggleState(toggleState);
		}

		// Token: 0x06034049 RID: 213065 RVA: 0x00D03464 File Offset: 0x00D01664
		private void OnClickBackBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603404A RID: 213066 RVA: 0x00D03470 File Offset: 0x00D01670
		protected override void OnStart()
		{
			bool flag = ModelBase<TowerDefenseModel>.Instance.RankData.IsOwnSingleBestRecord(this.Vm.InstanceId);
			TowerDefenseRankTabItemV2 layoutItemByIndex = this.TabLayout.GetLayoutItemByIndex(flag ? 0 : 1);
			if (layoutItemByIndex == null)
			{
				return;
			}
			layoutItemByIndex.SetToggleState(true, true);
		}

		// Token: 0x0603404B RID: 213067 RVA: 0x00D034B8 File Offset: 0x00D016B8
		private UniTask InitTabLayout()
		{
			TowerDefenseRankViewV2.<InitTabLayout>d__16 <InitTabLayout>d__;
			<InitTabLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTabLayout>d__.<>4__this = this;
			<InitTabLayout>d__.<>1__state = -1;
			<InitTabLayout>d__.<>t__builder.Start<TowerDefenseRankViewV2.<InitTabLayout>d__16>(ref <InitTabLayout>d__);
			return <InitTabLayout>d__.<>t__builder.Task;
		}

		// Token: 0x0603404C RID: 213068 RVA: 0x00D034FB File Offset: 0x00D016FB
		private void InitRankScroll()
		{
			this.RankScroll = new LoopScrollView<TowerDefenseRankItemV2, TowerDefenseRankItemData>(base.GetLoopScrollViewComponent(1), base.GetItem(2).GetOwner() as AUIBaseActor, new Func<TowerDefenseRankItemV2>(this.InitRankItem), false);
		}

		// Token: 0x0603404D RID: 213069 RVA: 0x00D03530 File Offset: 0x00D01730
		private UniTask InitOwnRankItem()
		{
			TowerDefenseRankViewV2.<InitOwnRankItem>d__18 <InitOwnRankItem>d__;
			<InitOwnRankItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitOwnRankItem>d__.<>4__this = this;
			<InitOwnRankItem>d__.<>1__state = -1;
			<InitOwnRankItem>d__.<>t__builder.Start<TowerDefenseRankViewV2.<InitOwnRankItem>d__18>(ref <InitOwnRankItem>d__);
			return <InitOwnRankItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603404E RID: 213070 RVA: 0x00D03573 File Offset: 0x00D01773
		private TowerDefenseRankTabItemV2 InitTabItem()
		{
			return new TowerDefenseRankTabItemV2
			{
				OpenParam = this.Vm
			};
		}

		// Token: 0x0603404F RID: 213071 RVA: 0x00D03586 File Offset: 0x00D01786
		private TowerDefenseRankItemV2 InitRankItem()
		{
			return new TowerDefenseRankItemV2
			{
				OpenParam = this.Vm
			};
		}

		// Token: 0x06034050 RID: 213072 RVA: 0x00D0359C File Offset: 0x00D0179C
		private UniTask RefreshRankLayout(TowerDefenceDefine.ETabType tabType, bool playGridAnim)
		{
			TowerDefenseRankViewV2.<RefreshRankLayout>d__21 <RefreshRankLayout>d__;
			<RefreshRankLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshRankLayout>d__.<>4__this = this;
			<RefreshRankLayout>d__.tabType = tabType;
			<RefreshRankLayout>d__.playGridAnim = playGridAnim;
			<RefreshRankLayout>d__.<>1__state = -1;
			<RefreshRankLayout>d__.<>t__builder.Start<TowerDefenseRankViewV2.<RefreshRankLayout>d__21>(ref <RefreshRankLayout>d__);
			return <RefreshRankLayout>d__.<>t__builder.Task;
		}

		// Token: 0x06034051 RID: 213073 RVA: 0x00D035EF File Offset: 0x00D017EF
		public void ResetLastTabItemSelected(TowerDefenceDefine.ETabType tabType)
		{
			TowerDefenseRankTabItemV2 layoutItemByIndex = this.TabLayout.GetLayoutItemByIndex((int)tabType);
			if (layoutItemByIndex == null)
			{
				return;
			}
			layoutItemByIndex.SetToggleState(false, false);
		}

		// Token: 0x06034052 RID: 213074 RVA: 0x00D0360C File Offset: 0x00D0180C
		public void RefreshContent(TowerDefenceDefine.ETabType tabType)
		{
			TowerDefenseRankViewV2.<>c__DisplayClass23_0 CS$<>8__locals1 = new TowerDefenseRankViewV2.<>c__DisplayClass23_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.tabType = tabType;
			CS$<>8__locals1.isFirst = !this.HasPlayedListAnim;
			this.HasPlayedListAnim = true;
			if (!CS$<>8__locals1.isFirst)
			{
				LevelSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer != null)
				{
					sequencePlayer.StopSequenceByKey("Switch", false, false);
				}
				LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
				if (sequencePlayer2 != null)
				{
					sequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
				}
			}
			UiAsyncTask task = new UiAsyncTask("TowerDefenseRankViewV2.RefreshContent", delegate()
			{
				TowerDefenseRankViewV2.<>c__DisplayClass23_0.<<RefreshContent>b__0>d <<RefreshContent>b__0>d;
				<<RefreshContent>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshContent>b__0>d.<>4__this = CS$<>8__locals1;
				<<RefreshContent>b__0>d.<>1__state = -1;
				<<RefreshContent>b__0>d.<>t__builder.Start<TowerDefenseRankViewV2.<>c__DisplayClass23_0.<<RefreshContent>b__0>d>(ref <<RefreshContent>b__0>d);
				return <<RefreshContent>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
			this.RefreshAnonymousToggle(CS$<>8__locals1.tabType);
		}

		// Token: 0x06034053 RID: 213075 RVA: 0x00D036B0 File Offset: 0x00D018B0
		private void RefreshAnonymousToggle(TowerDefenceDefine.ETabType tabType)
		{
			TowerDefenseRankItemData selfRankDataByTabType = ModelBase<TowerDefenseModel>.Instance.RankData.GetSelfRankDataByTabType(tabType);
			PopupCaptionToggleItem anonymousToggle = this.AnonymousToggle;
			if (anonymousToggle == null)
			{
				return;
			}
			anonymousToggle.SetUiActive(selfRankDataByTabType.IsInRank);
		}

		// Token: 0x06034054 RID: 213076 RVA: 0x00D036E4 File Offset: 0x00D018E4
		public void RefreshContentShowName()
		{
			this.OwnRankItem.RefreshPlayerName();
			int startGridIndex = this.RankScroll.StartGridIndex;
			int endGridIndex = this.RankScroll.EndGridIndex;
			for (int i = startGridIndex; i <= endGridIndex; i++)
			{
				TowerDefenseRankItemData towerDefenseRankItemData = this.RankScroll.TryGetCachedData(i);
				if (towerDefenseRankItemData != null && towerDefenseRankItemData.IsSelfInData)
				{
					this.RankScroll.RefreshGridProxy(i);
				}
			}
		}

		// Token: 0x06034055 RID: 213077 RVA: 0x00D03743 File Offset: 0x00D01943
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.Clear();
		}

		// Token: 0x0401E102 RID: 123138
		[Nullable(2)]
		private PopupCaptionItem Caption;

		// Token: 0x0401E103 RID: 123139
		[Nullable(2)]
		private PopupCaptionToggleItem AnonymousToggle;

		// Token: 0x0401E104 RID: 123140
		private GenericLayout<TowerDefenseRankTabItemV2, TowerDefenceDefine.ETabType> TabLayout;

		// Token: 0x0401E105 RID: 123141
		private LoopScrollView<TowerDefenseRankItemV2, TowerDefenseRankItemData> RankScroll;

		// Token: 0x0401E106 RID: 123142
		private TowerDefenseRankItemV2 OwnRankItem;

		// Token: 0x0401E107 RID: 123143
		private TowerDefenseRankViewModelV2 Vm;

		// Token: 0x0401E108 RID: 123144
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0401E109 RID: 123145
		private bool HasPlayedListAnim;

		// Token: 0x0200AE50 RID: 44624
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x040361E8 RID: 221672
			public const int CaptionItem = 0;

			// Token: 0x040361E9 RID: 221673
			public const int LoopScrollView = 1;

			// Token: 0x040361EA RID: 221674
			public const int RankItem = 2;

			// Token: 0x040361EB RID: 221675
			public const int EmptyItem = 3;

			// Token: 0x040361EC RID: 221676
			public const int OwnerItem = 4;

			// Token: 0x040361ED RID: 221677
			public const int TabLayout = 5;

			// Token: 0x040361EE RID: 221678
			public const int TabItem = 6;
		}
	}
}
