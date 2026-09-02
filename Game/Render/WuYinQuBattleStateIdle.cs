using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200473F RID: 18239
	public class WuYinQuBattleStateIdle : WuYinQuBattleStateBase
	{
		// Token: 0x0602F554 RID: 193876 RVA: 0x00B39C74 File Offset: 0x00B37E74
		[NullableContext(1)]
		public WuYinQuBattleStateIdle(WuYinQuBattleActor Owner, EWuYinQuBattleState State, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<WuYinQuBattleActor, EWuYinQuBattleState> StateMachine = null) : base(Owner, State, StateMachine)
		{
		}

		// Token: 0x0602F555 RID: 193877 RVA: 0x00B39C7F File Offset: 0x00B37E7F
		protected override void OnStart()
		{
			this.OnEnter(new EWuYinQuBattleState?(EWuYinQuBattleState.Idle));
		}

		// Token: 0x0602F556 RID: 193878 RVA: 0x00B39C90 File Offset: 0x00B37E90
		protected override void OnEnter(EWuYinQuBattleState? lastState)
		{
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "进入idle状态", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.Owner.当前状态 = "静止状态";
		}

		// Token: 0x0602F557 RID: 193879 RVA: 0x00B39CC9 File Offset: 0x00B37EC9
		protected override void OnUpdate(float delta)
		{
		}

		// Token: 0x0602F558 RID: 193880 RVA: 0x00B39CCB File Offset: 0x00B37ECB
		protected override void OnExit(EWuYinQuBattleState lastState)
		{
		}
	}
}
