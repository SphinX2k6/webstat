using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Opponent
{
	// Token: 0x020055F5 RID: 22005
	[NullableContext(1)]
	[Nullable(0)]
	public class OpponentHandArea : UiPanelBase
	{
		// Token: 0x06038101 RID: 229633 RVA: 0x00E33D90 File Offset: 0x00E31F90
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout))
			};
		}

		// Token: 0x06038102 RID: 229634 RVA: 0x00E33DB3 File Offset: 0x00E31FB3
		protected override void OnStart()
		{
			this.Layout = base.GetHorizontalLayout(0);
			this.OriginalSpace = this.Layout.GetSpacing();
		}

		// Token: 0x06038103 RID: 229635 RVA: 0x00E33DD4 File Offset: 0x00E31FD4
		private UniTask CreateHandCardItem()
		{
			OpponentHandArea.<CreateHandCardItem>d__11 <CreateHandCardItem>d__;
			<CreateHandCardItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateHandCardItem>d__.<>4__this = this;
			<CreateHandCardItem>d__.<>1__state = -1;
			<CreateHandCardItem>d__.<>t__builder.Start<OpponentHandArea.<CreateHandCardItem>d__11>(ref <CreateHandCardItem>d__);
			return <CreateHandCardItem>d__.<>t__builder.Task;
		}

		// Token: 0x06038104 RID: 229636 RVA: 0x00E33E18 File Offset: 0x00E32018
		private void CalculateLayoutSpace()
		{
			this.TotalWidth = 6f * this.GridWidth + 5f * this.OriginalSpace;
			this.TotalHeight = this.Layout.RootUIComp.Get().GetHeight();
			float spacing = this.OriginalSpace;
			if (this.HandCardItemList.Count > 6)
			{
				spacing = (this.TotalWidth - (float)this.HandCardItemList.Count * this.GridWidth) / (float)(this.HandCardItemList.Count - 1);
			}
			this.Layout.SetSpacing(spacing);
		}

		// Token: 0x06038105 RID: 229637 RVA: 0x00E33EB0 File Offset: 0x00E320B0
		private UniTask InitHandCardNum()
		{
			OpponentHandArea.<InitHandCardNum>d__13 <InitHandCardNum>d__;
			<InitHandCardNum>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitHandCardNum>d__.<>4__this = this;
			<InitHandCardNum>d__.<>1__state = -1;
			<InitHandCardNum>d__.<>t__builder.Start<OpponentHandArea.<InitHandCardNum>d__13>(ref <InitHandCardNum>d__);
			return <InitHandCardNum>d__.<>t__builder.Task;
		}

		// Token: 0x06038106 RID: 229638 RVA: 0x00E33EF4 File Offset: 0x00E320F4
		protected UniTask PlayStartTimeDrawCardTween(UUIItem fromItem)
		{
			OpponentHandArea.<PlayStartTimeDrawCardTween>d__14 <PlayStartTimeDrawCardTween>d__;
			<PlayStartTimeDrawCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartTimeDrawCardTween>d__.<>4__this = this;
			<PlayStartTimeDrawCardTween>d__.fromItem = fromItem;
			<PlayStartTimeDrawCardTween>d__.<>1__state = -1;
			<PlayStartTimeDrawCardTween>d__.<>t__builder.Start<OpponentHandArea.<PlayStartTimeDrawCardTween>d__14>(ref <PlayStartTimeDrawCardTween>d__);
			return <PlayStartTimeDrawCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x06038107 RID: 229639 RVA: 0x00E33F40 File Offset: 0x00E32140
		protected UniTask PlayEndTimeDiscardTween(UUIItem toItem)
		{
			OpponentHandArea.<PlayEndTimeDiscardTween>d__15 <PlayEndTimeDiscardTween>d__;
			<PlayEndTimeDiscardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayEndTimeDiscardTween>d__.<>4__this = this;
			<PlayEndTimeDiscardTween>d__.toItem = toItem;
			<PlayEndTimeDiscardTween>d__.<>1__state = -1;
			<PlayEndTimeDiscardTween>d__.<>t__builder.Start<OpponentHandArea.<PlayEndTimeDiscardTween>d__15>(ref <PlayEndTimeDiscardTween>d__);
			return <PlayEndTimeDiscardTween>d__.<>t__builder.Task;
		}

		// Token: 0x06038108 RID: 229640 RVA: 0x00E33F8C File Offset: 0x00E3218C
		protected UniTask PlayBackToRecycleTween(UUIItem toItem, int count)
		{
			OpponentHandArea.<PlayBackToRecycleTween>d__16 <PlayBackToRecycleTween>d__;
			<PlayBackToRecycleTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayBackToRecycleTween>d__.<>4__this = this;
			<PlayBackToRecycleTween>d__.toItem = toItem;
			<PlayBackToRecycleTween>d__.count = count;
			<PlayBackToRecycleTween>d__.<>1__state = -1;
			<PlayBackToRecycleTween>d__.<>t__builder.Start<OpponentHandArea.<PlayBackToRecycleTween>d__16>(ref <PlayBackToRecycleTween>d__);
			return <PlayBackToRecycleTween>d__.<>t__builder.Task;
		}

		// Token: 0x06038109 RID: 229641 RVA: 0x00E33FE0 File Offset: 0x00E321E0
		protected UniTask PlayDiscardCardTween(UUIItem toItem, int count)
		{
			OpponentHandArea.<PlayDiscardCardTween>d__17 <PlayDiscardCardTween>d__;
			<PlayDiscardCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayDiscardCardTween>d__.<>4__this = this;
			<PlayDiscardCardTween>d__.toItem = toItem;
			<PlayDiscardCardTween>d__.count = count;
			<PlayDiscardCardTween>d__.<>1__state = -1;
			<PlayDiscardCardTween>d__.<>t__builder.Start<OpponentHandArea.<PlayDiscardCardTween>d__17>(ref <PlayDiscardCardTween>d__);
			return <PlayDiscardCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x0603810A RID: 229642 RVA: 0x00E34034 File Offset: 0x00E32234
		protected UniTask PlayAddCardTween(int count)
		{
			OpponentHandArea.<PlayAddCardTween>d__18 <PlayAddCardTween>d__;
			<PlayAddCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAddCardTween>d__.<>4__this = this;
			<PlayAddCardTween>d__.count = count;
			<PlayAddCardTween>d__.<>1__state = -1;
			<PlayAddCardTween>d__.<>t__builder.Start<OpponentHandArea.<PlayAddCardTween>d__18>(ref <PlayAddCardTween>d__);
			return <PlayAddCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x0603810B RID: 229643 RVA: 0x00E34080 File Offset: 0x00E32280
		protected UniTask AddCardList(int count)
		{
			OpponentHandArea.<AddCardList>d__19 <AddCardList>d__;
			<AddCardList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AddCardList>d__.<>4__this = this;
			<AddCardList>d__.count = count;
			<AddCardList>d__.<>1__state = -1;
			<AddCardList>d__.<>t__builder.Start<OpponentHandArea.<AddCardList>d__19>(ref <AddCardList>d__);
			return <AddCardList>d__.<>t__builder.Task;
		}

		// Token: 0x0603810C RID: 229644 RVA: 0x00E340CC File Offset: 0x00E322CC
		protected UniTask DestroyCardList(int count)
		{
			OpponentHandArea.<DestroyCardList>d__20 <DestroyCardList>d__;
			<DestroyCardList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DestroyCardList>d__.<>4__this = this;
			<DestroyCardList>d__.count = count;
			<DestroyCardList>d__.<>1__state = -1;
			<DestroyCardList>d__.<>t__builder.Start<OpponentHandArea.<DestroyCardList>d__20>(ref <DestroyCardList>d__);
			return <DestroyCardList>d__.<>t__builder.Task;
		}

		// Token: 0x0603810D RID: 229645 RVA: 0x00E34117 File Offset: 0x00E32317
		public void RegisterBattleArea(OpponentArea area)
		{
			this.ParentArea = area;
		}

		// Token: 0x0603810E RID: 229646 RVA: 0x00E34120 File Offset: 0x00E32320
		public UUIItem GetLayoutItem()
		{
			return this.Layout.RootUIComp;
		}

		// Token: 0x0603810F RID: 229647 RVA: 0x00E34134 File Offset: 0x00E32334
		public UniTask RefreshHandCardNum(int handCardNum)
		{
			OpponentHandArea.<RefreshHandCardNum>d__23 <RefreshHandCardNum>d__;
			<RefreshHandCardNum>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshHandCardNum>d__.<>4__this = this;
			<RefreshHandCardNum>d__.handCardNum = handCardNum;
			<RefreshHandCardNum>d__.<>1__state = -1;
			<RefreshHandCardNum>d__.<>t__builder.Start<OpponentHandArea.<RefreshHandCardNum>d__23>(ref <RefreshHandCardNum>d__);
			return <RefreshHandCardNum>d__.<>t__builder.Task;
		}

		// Token: 0x06038110 RID: 229648 RVA: 0x00E34180 File Offset: 0x00E32380
		public UniTask StartTimeDrawCard(UUIItem fromItem)
		{
			OpponentHandArea.<StartTimeDrawCard>d__24 <StartTimeDrawCard>d__;
			<StartTimeDrawCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartTimeDrawCard>d__.<>4__this = this;
			<StartTimeDrawCard>d__.fromItem = fromItem;
			<StartTimeDrawCard>d__.<>1__state = -1;
			<StartTimeDrawCard>d__.<>t__builder.Start<OpponentHandArea.<StartTimeDrawCard>d__24>(ref <StartTimeDrawCard>d__);
			return <StartTimeDrawCard>d__.<>t__builder.Task;
		}

		// Token: 0x06038111 RID: 229649 RVA: 0x00E341CC File Offset: 0x00E323CC
		public UniTask EndTimeDiscardCard(UUIItem toItem)
		{
			OpponentHandArea.<EndTimeDiscardCard>d__25 <EndTimeDiscardCard>d__;
			<EndTimeDiscardCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EndTimeDiscardCard>d__.<>4__this = this;
			<EndTimeDiscardCard>d__.toItem = toItem;
			<EndTimeDiscardCard>d__.<>1__state = -1;
			<EndTimeDiscardCard>d__.<>t__builder.Start<OpponentHandArea.<EndTimeDiscardCard>d__25>(ref <EndTimeDiscardCard>d__);
			return <EndTimeDiscardCard>d__.<>t__builder.Task;
		}

		// Token: 0x06038112 RID: 229650 RVA: 0x00E34218 File Offset: 0x00E32418
		public UniTask BackToRecycle(int count)
		{
			OpponentHandArea.<BackToRecycle>d__26 <BackToRecycle>d__;
			<BackToRecycle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<BackToRecycle>d__.<>4__this = this;
			<BackToRecycle>d__.count = count;
			<BackToRecycle>d__.<>1__state = -1;
			<BackToRecycle>d__.<>t__builder.Start<OpponentHandArea.<BackToRecycle>d__26>(ref <BackToRecycle>d__);
			return <BackToRecycle>d__.<>t__builder.Task;
		}

		// Token: 0x06038113 RID: 229651 RVA: 0x00E34264 File Offset: 0x00E32464
		public UniTask DiscardCard(int count)
		{
			OpponentHandArea.<DiscardCard>d__27 <DiscardCard>d__;
			<DiscardCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DiscardCard>d__.<>4__this = this;
			<DiscardCard>d__.count = count;
			<DiscardCard>d__.<>1__state = -1;
			<DiscardCard>d__.<>t__builder.Start<OpponentHandArea.<DiscardCard>d__27>(ref <DiscardCard>d__);
			return <DiscardCard>d__.<>t__builder.Task;
		}

		// Token: 0x040200D9 RID: 131289
		private const int WAIT_ADD_CARD_TIME = 40;

		// Token: 0x040200DA RID: 131290
		protected float TotalWidth;

		// Token: 0x040200DB RID: 131291
		protected float TotalHeight;

		// Token: 0x040200DC RID: 131292
		protected float OriginalSpace;

		// Token: 0x040200DD RID: 131293
		protected float GridWidth;

		// Token: 0x040200DE RID: 131294
		protected OpponentArea ParentArea;

		// Token: 0x040200DF RID: 131295
		protected UUIHorizontalLayout Layout;

		// Token: 0x040200E0 RID: 131296
		protected List<OpponentHandCardItem> HandCardItemList = new List<OpponentHandCardItem>();

		// Token: 0x0200B633 RID: 46643
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x040385F9 RID: 230905
			public const int Layout = 0;
		}
	}
}
