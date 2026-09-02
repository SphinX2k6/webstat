using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Battle;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200473B RID: 18235
	public class WuYinQuBattleStateFighting2 : WuYinQuBattleStateFighting1
	{
		// Token: 0x0602F542 RID: 193858 RVA: 0x00B3930D File Offset: 0x00B3750D
		[NullableContext(1)]
		public WuYinQuBattleStateFighting2(WuYinQuBattleActor Owner, EWuYinQuBattleState State, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<WuYinQuBattleActor, EWuYinQuBattleState> StateMachine = null) : base(Owner, State, StateMachine)
		{
		}

		// Token: 0x0602F543 RID: 193859 RVA: 0x00B39318 File Offset: 0x00B37518
		[NullableContext(2)]
		protected override PDA_WuYinQuBattleFightingData_C GetFightingData()
		{
			return this.Owner.WuYinQuFightingData.WuYinQuFightingData2;
		}

		// Token: 0x0602F544 RID: 193860 RVA: 0x00B3932C File Offset: 0x00B3752C
		protected override void OnEnter(EWuYinQuBattleState? lastState)
		{
			base.OnEnter(lastState);
			this.Owner.当前状态 = "战斗阶段2";
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "进入战斗阶段2", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602F545 RID: 193861 RVA: 0x00B3936C File Offset: 0x00B3756C
		protected override void OnExit(EWuYinQuBattleState lastState)
		{
			base.OnExit(lastState);
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "退出战斗阶段2", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}
}
