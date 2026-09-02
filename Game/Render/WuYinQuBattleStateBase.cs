using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004739 RID: 18233
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public abstract class WuYinQuBattleStateBase : StateBase<WuYinQuBattleActor, EWuYinQuBattleState>
	{
		// Token: 0x0602F539 RID: 193849 RVA: 0x00B391CD File Offset: 0x00B373CD
		protected WuYinQuBattleStateBase(WuYinQuBattleActor Owner, EWuYinQuBattleState State, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<WuYinQuBattleActor, EWuYinQuBattleState> StateMachine = null) : base(Owner, State, StateMachine)
		{
		}

		// Token: 0x0602F53A RID: 193850
		protected abstract override void OnEnter(EWuYinQuBattleState? lastState);

		// Token: 0x0602F53B RID: 193851
		protected abstract override void OnUpdate(float delta);

		// Token: 0x0602F53C RID: 193852
		protected abstract override void OnExit(EWuYinQuBattleState lastState);
	}
}
