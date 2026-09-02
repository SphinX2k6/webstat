using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x020031D4 RID: 12756
public class NpcPerformImpactedState : NpcPerformBaseState
{
	// Token: 0x0601A719 RID: 108313 RVA: 0x007CD74D File Offset: 0x007CB94D
	[NullableContext(1)]
	public NpcPerformImpactedState(EntityHandle owner, ENpcPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<EntityHandle, ENpcPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}

	// Token: 0x0601A71A RID: 108314 RVA: 0x007CD758 File Offset: 0x007CB958
	protected override void OnEnter(ENpcPerformState? lastState)
	{
		CommonNpcPerformComponent component = this.Owner.Entity.GetComponent<CommonNpcPerformComponent>();
		if (component != null && component.IsMontagePlaying(EPerformGroup.DefaultGroup))
		{
			component.StopPerformMontage(EPerformMode.Ecology, new IStopMontageParam
			{
				Method = new EStopMethod?(EStopMethod.BlendOut),
				BlendOutTime = new float?(0f)
			}, null, null);
		}
		Singleton<EventSystem>.Instance.EmitWithTarget(this.Owner, EEventName.OnNpcBeenImpactedStart);
	}

	// Token: 0x0601A71B RID: 108315 RVA: 0x007CD7C3 File Offset: 0x007CB9C3
	protected override void OnExit(ENpcPerformState nextState)
	{
		Singleton<EventSystem>.Instance.EmitWithTarget(this.Owner, EEventName.OnNpcBeenImpactedEnd);
	}
}
