using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Battle;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200473C RID: 18236
	public class WuYinQuBattleStateFighting3 : WuYinQuBattleStateFighting1
	{
		// Token: 0x0602F546 RID: 193862 RVA: 0x00B3939C File Offset: 0x00B3759C
		[NullableContext(1)]
		public WuYinQuBattleStateFighting3(WuYinQuBattleActor Owner, EWuYinQuBattleState State, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<WuYinQuBattleActor, EWuYinQuBattleState> StateMachine = null) : base(Owner, State, StateMachine)
		{
		}

		// Token: 0x0602F547 RID: 193863 RVA: 0x00B393A7 File Offset: 0x00B375A7
		[NullableContext(2)]
		protected override PDA_WuYinQuBattleFightingData_C GetFightingData()
		{
			return this.Owner.WuYinQuFightingData.WuYinQuFightingData3;
		}

		// Token: 0x0602F548 RID: 193864 RVA: 0x00B393BC File Offset: 0x00B375BC
		protected override void OnEnter(EWuYinQuBattleState? lastState)
		{
			base.OnEnter(lastState);
			this.Owner.当前状态 = "战斗阶段3";
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "进入战斗阶段3", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602F549 RID: 193865 RVA: 0x00B393FC File Offset: 0x00B375FC
		protected override void OnExit(EWuYinQuBattleState lastState)
		{
			base.OnExit(lastState);
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "退出战斗阶段3", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}
}
