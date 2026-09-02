using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.Ai;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Field;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Panel;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Opponent
{
	// Token: 0x020055F1 RID: 22001
	[NullableContext(1)]
	[Nullable(0)]
	public class OpponentArea
	{
		// Token: 0x060380B4 RID: 229556 RVA: 0x00E32AA8 File Offset: 0x00E30CA8
		private UniTask InitFunctionalArea(UUIItem functionalAreaItem)
		{
			OpponentArea.<InitFunctionalArea>d__12 <InitFunctionalArea>d__;
			<InitFunctionalArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitFunctionalArea>d__.<>4__this = this;
			<InitFunctionalArea>d__.functionalAreaItem = functionalAreaItem;
			<InitFunctionalArea>d__.<>1__state = -1;
			<InitFunctionalArea>d__.<>t__builder.Start<OpponentArea.<InitFunctionalArea>d__12>(ref <InitFunctionalArea>d__);
			return <InitFunctionalArea>d__.<>t__builder.Task;
		}

		// Token: 0x060380B5 RID: 229557 RVA: 0x00E32AF4 File Offset: 0x00E30CF4
		private UniTask InitRoleItem(UUIItem roleItem)
		{
			OpponentArea.<InitRoleItem>d__13 <InitRoleItem>d__;
			<InitRoleItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleItem>d__.<>4__this = this;
			<InitRoleItem>d__.roleItem = roleItem;
			<InitRoleItem>d__.<>1__state = -1;
			<InitRoleItem>d__.<>t__builder.Start<OpponentArea.<InitRoleItem>d__13>(ref <InitRoleItem>d__);
			return <InitRoleItem>d__.<>t__builder.Task;
		}

		// Token: 0x060380B6 RID: 229558 RVA: 0x00E32B40 File Offset: 0x00E30D40
		private UniTask InitHandArea(UUILayoutBase handAreaItem)
		{
			OpponentArea.<InitHandArea>d__14 <InitHandArea>d__;
			<InitHandArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitHandArea>d__.<>4__this = this;
			<InitHandArea>d__.handAreaItem = handAreaItem;
			<InitHandArea>d__.<>1__state = -1;
			<InitHandArea>d__.<>t__builder.Start<OpponentArea.<InitHandArea>d__14>(ref <InitHandArea>d__);
			return <InitHandArea>d__.<>t__builder.Task;
		}

		// Token: 0x060380B7 RID: 229559 RVA: 0x00E32B8C File Offset: 0x00E30D8C
		private UniTask InitCurveX()
		{
			OpponentArea.<InitCurveX>d__15 <InitCurveX>d__;
			<InitCurveX>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCurveX>d__.<>4__this = this;
			<InitCurveX>d__.<>1__state = -1;
			<InitCurveX>d__.<>t__builder.Start<OpponentArea.<InitCurveX>d__15>(ref <InitCurveX>d__);
			return <InitCurveX>d__.<>t__builder.Task;
		}

		// Token: 0x060380B8 RID: 229560 RVA: 0x00E32BD0 File Offset: 0x00E30DD0
		private UniTask InitDrawCardCurveY()
		{
			OpponentArea.<InitDrawCardCurveY>d__16 <InitDrawCardCurveY>d__;
			<InitDrawCardCurveY>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDrawCardCurveY>d__.<>4__this = this;
			<InitDrawCardCurveY>d__.<>1__state = -1;
			<InitDrawCardCurveY>d__.<>t__builder.Start<OpponentArea.<InitDrawCardCurveY>d__16>(ref <InitDrawCardCurveY>d__);
			return <InitDrawCardCurveY>d__.<>t__builder.Task;
		}

		// Token: 0x060380B9 RID: 229561 RVA: 0x00E32C14 File Offset: 0x00E30E14
		private UniTask InitDiscardCardCurveX()
		{
			OpponentArea.<InitDiscardCardCurveX>d__17 <InitDiscardCardCurveX>d__;
			<InitDiscardCardCurveX>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDiscardCardCurveX>d__.<>4__this = this;
			<InitDiscardCardCurveX>d__.<>1__state = -1;
			<InitDiscardCardCurveX>d__.<>t__builder.Start<OpponentArea.<InitDiscardCardCurveX>d__17>(ref <InitDiscardCardCurveX>d__);
			return <InitDiscardCardCurveX>d__.<>t__builder.Task;
		}

		// Token: 0x060380BA RID: 229562 RVA: 0x00E32C58 File Offset: 0x00E30E58
		private UniTask InitDiscardCardCurveY()
		{
			OpponentArea.<InitDiscardCardCurveY>d__18 <InitDiscardCardCurveY>d__;
			<InitDiscardCardCurveY>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDiscardCardCurveY>d__.<>4__this = this;
			<InitDiscardCardCurveY>d__.<>1__state = -1;
			<InitDiscardCardCurveY>d__.<>t__builder.Start<OpponentArea.<InitDiscardCardCurveY>d__18>(ref <InitDiscardCardCurveY>d__);
			return <InitDiscardCardCurveY>d__.<>t__builder.Task;
		}

		// Token: 0x060380BB RID: 229563 RVA: 0x00E32C9C File Offset: 0x00E30E9C
		private UniTask InitMoveLocationCurve()
		{
			OpponentArea.<InitMoveLocationCurve>d__19 <InitMoveLocationCurve>d__;
			<InitMoveLocationCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMoveLocationCurve>d__.<>4__this = this;
			<InitMoveLocationCurve>d__.<>1__state = -1;
			<InitMoveLocationCurve>d__.<>t__builder.Start<OpponentArea.<InitMoveLocationCurve>d__19>(ref <InitMoveLocationCurve>d__);
			return <InitMoveLocationCurve>d__.<>t__builder.Task;
		}

		// Token: 0x060380BC RID: 229564 RVA: 0x00E32CE0 File Offset: 0x00E30EE0
		private UniTask InitRecycleCurve()
		{
			OpponentArea.<InitRecycleCurve>d__20 <InitRecycleCurve>d__;
			<InitRecycleCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRecycleCurve>d__.<>4__this = this;
			<InitRecycleCurve>d__.<>1__state = -1;
			<InitRecycleCurve>d__.<>t__builder.Start<OpponentArea.<InitRecycleCurve>d__20>(ref <InitRecycleCurve>d__);
			return <InitRecycleCurve>d__.<>t__builder.Task;
		}

		// Token: 0x060380BD RID: 229565 RVA: 0x00E32D24 File Offset: 0x00E30F24
		private UniTask InitCardCurve()
		{
			OpponentArea.<InitCardCurve>d__21 <InitCardCurve>d__;
			<InitCardCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCardCurve>d__.<>4__this = this;
			<InitCardCurve>d__.<>1__state = -1;
			<InitCardCurve>d__.<>t__builder.Start<OpponentArea.<InitCardCurve>d__21>(ref <InitCardCurve>d__);
			return <InitCardCurve>d__.<>t__builder.Task;
		}

		// Token: 0x060380BE RID: 229566 RVA: 0x00E32D68 File Offset: 0x00E30F68
		public UniTask InitArea(UUILayoutBase handAreaItem, UUIItem functionalAreaItem, UUIItem roleItem, UUIItem filedAreaItem)
		{
			OpponentArea.<InitArea>d__22 <InitArea>d__;
			<InitArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitArea>d__.<>4__this = this;
			<InitArea>d__.handAreaItem = handAreaItem;
			<InitArea>d__.functionalAreaItem = functionalAreaItem;
			<InitArea>d__.roleItem = roleItem;
			<InitArea>d__.filedAreaItem = filedAreaItem;
			<InitArea>d__.<>1__state = -1;
			<InitArea>d__.<>t__builder.Start<OpponentArea.<InitArea>d__22>(ref <InitArea>d__);
			return <InitArea>d__.<>t__builder.Task;
		}

		// Token: 0x060380BF RID: 229567 RVA: 0x00E32DCC File Offset: 0x00E30FCC
		public void RegisterViewProxy(PhantomArenaBattleProxy proxy)
		{
			this.ViewProxy = proxy;
			this.AiManager = new PhantomArenaAiManager(proxy);
		}

		// Token: 0x060380C0 RID: 229568 RVA: 0x00E32DE4 File Offset: 0x00E30FE4
		public UniTask StartAiOperation()
		{
			OpponentArea.<StartAiOperation>d__24 <StartAiOperation>d__;
			<StartAiOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartAiOperation>d__.<>4__this = this;
			<StartAiOperation>d__.<>1__state = -1;
			<StartAiOperation>d__.<>t__builder.Start<OpponentArea.<StartAiOperation>d__24>(ref <StartAiOperation>d__);
			return <StartAiOperation>d__.<>t__builder.Task;
		}

		// Token: 0x060380C1 RID: 229569 RVA: 0x00E32E27 File Offset: 0x00E31027
		public void RefreshAll(bool isFromWorldDone)
		{
			this.RolePanel.RefreshAll(isFromWorldDone);
			this.FunctionalArea.RefreshAllBattleCard();
			this.RefreshFiledArea().Forget();
		}

		// Token: 0x060380C2 RID: 229570 RVA: 0x00E32E4B File Offset: 0x00E3104B
		public void RefreshLifeNumWithEffect()
		{
			this.RolePanel.RefreshLifeNumWithEffect();
		}

		// Token: 0x060380C3 RID: 229571 RVA: 0x00E32E58 File Offset: 0x00E31058
		public void Clear()
		{
			this.AiManager.Clear();
		}

		// Token: 0x060380C4 RID: 229572 RVA: 0x00E32E68 File Offset: 0x00E31068
		public UniTask CallHandCardListToFight(PhantomBattleFighterInfo[] cardInfoList)
		{
			OpponentArea.<CallHandCardListToFight>d__28 <CallHandCardListToFight>d__;
			<CallHandCardListToFight>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CallHandCardListToFight>d__.<>4__this = this;
			<CallHandCardListToFight>d__.cardInfoList = cardInfoList;
			<CallHandCardListToFight>d__.<>1__state = -1;
			<CallHandCardListToFight>d__.<>t__builder.Start<OpponentArea.<CallHandCardListToFight>d__28>(ref <CallHandCardListToFight>d__);
			return <CallHandCardListToFight>d__.<>t__builder.Task;
		}

		// Token: 0x060380C5 RID: 229573 RVA: 0x00E32EB4 File Offset: 0x00E310B4
		public UniTask CallLibraryCardListToFight(PhantomBattleFighterInfo[] cardInfoList)
		{
			OpponentArea.<CallLibraryCardListToFight>d__29 <CallLibraryCardListToFight>d__;
			<CallLibraryCardListToFight>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CallLibraryCardListToFight>d__.<>4__this = this;
			<CallLibraryCardListToFight>d__.cardInfoList = cardInfoList;
			<CallLibraryCardListToFight>d__.<>1__state = -1;
			<CallLibraryCardListToFight>d__.<>t__builder.Start<OpponentArea.<CallLibraryCardListToFight>d__29>(ref <CallLibraryCardListToFight>d__);
			return <CallLibraryCardListToFight>d__.<>t__builder.Task;
		}

		// Token: 0x060380C6 RID: 229574 RVA: 0x00E32F00 File Offset: 0x00E31100
		private UniTask InitFiledArea(UUIItem filedAreaItem)
		{
			OpponentArea.<InitFiledArea>d__30 <InitFiledArea>d__;
			<InitFiledArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitFiledArea>d__.<>4__this = this;
			<InitFiledArea>d__.filedAreaItem = filedAreaItem;
			<InitFiledArea>d__.<>1__state = -1;
			<InitFiledArea>d__.<>t__builder.Start<OpponentArea.<InitFiledArea>d__30>(ref <InitFiledArea>d__);
			return <InitFiledArea>d__.<>t__builder.Task;
		}

		// Token: 0x060380C7 RID: 229575 RVA: 0x00E32F4C File Offset: 0x00E3114C
		public UniTask RefreshFiledArea()
		{
			OpponentArea.<RefreshFiledArea>d__31 <RefreshFiledArea>d__;
			<RefreshFiledArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshFiledArea>d__.<>4__this = this;
			<RefreshFiledArea>d__.<>1__state = -1;
			<RefreshFiledArea>d__.<>t__builder.Start<OpponentArea.<RefreshFiledArea>d__31>(ref <RefreshFiledArea>d__);
			return <RefreshFiledArea>d__.<>t__builder.Task;
		}

		// Token: 0x060380C8 RID: 229576 RVA: 0x00E32F90 File Offset: 0x00E31190
		public UniTask LockFiledArea()
		{
			OpponentArea.<LockFiledArea>d__32 <LockFiledArea>d__;
			<LockFiledArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LockFiledArea>d__.<>4__this = this;
			<LockFiledArea>d__.<>1__state = -1;
			<LockFiledArea>d__.<>t__builder.Start<OpponentArea.<LockFiledArea>d__32>(ref <LockFiledArea>d__);
			return <LockFiledArea>d__.<>t__builder.Task;
		}

		// Token: 0x060380C9 RID: 229577 RVA: 0x00E32FD4 File Offset: 0x00E311D4
		public UniTask UnlockFiledArea()
		{
			OpponentArea.<UnlockFiledArea>d__33 <UnlockFiledArea>d__;
			<UnlockFiledArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UnlockFiledArea>d__.<>4__this = this;
			<UnlockFiledArea>d__.<>1__state = -1;
			<UnlockFiledArea>d__.<>t__builder.Start<OpponentArea.<UnlockFiledArea>d__33>(ref <UnlockFiledArea>d__);
			return <UnlockFiledArea>d__.<>t__builder.Task;
		}

		// Token: 0x060380CA RID: 229578 RVA: 0x00E33017 File Offset: 0x00E31217
		public void SwitchFieldState(bool isGamepad)
		{
			PhantomArenaFieldArea filedArea = this.FiledArea;
			if (filedArea != null)
			{
				filedArea.SwitchFieldState(!isGamepad);
			}
			this.RolePanel.SwitchFieldState(isGamepad);
		}

		// Token: 0x040200C4 RID: 131268
		public PhantomArenaBattleProxy ViewProxy;

		// Token: 0x040200C5 RID: 131269
		public OpponentFunctionArea FunctionalArea;

		// Token: 0x040200C6 RID: 131270
		public OpponentHandArea HandArea;

		// Token: 0x040200C7 RID: 131271
		public PhantomArenaOpponentRolePanel RolePanel;

		// Token: 0x040200C8 RID: 131272
		public PhantomArenaFieldArea FiledArea;

		// Token: 0x040200C9 RID: 131273
		private PhantomArenaAiManager AiManager;

		// Token: 0x040200CA RID: 131274
		public UCurveFloat DrawCardCurveX;

		// Token: 0x040200CB RID: 131275
		public UCurveFloat DrawCardCurveY;

		// Token: 0x040200CC RID: 131276
		public UCurveFloat DiscardCardCurveX;

		// Token: 0x040200CD RID: 131277
		public UCurveFloat DiscardCardCurveY;

		// Token: 0x040200CE RID: 131278
		public UCurveFloat MoveLocationCurve;

		// Token: 0x040200CF RID: 131279
		public UCurveFloat RecycleCurve;
	}
}
