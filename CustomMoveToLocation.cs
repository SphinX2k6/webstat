using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;

// Token: 0x02002EA7 RID: 11943
[NullableContext(1)]
[Nullable(0)]
public class CustomMoveToLocation : CustomActionBase
{
	// Token: 0x06018836 RID: 100406 RVA: 0x006DFB26 File Offset: 0x006DDD26
	public CustomMoveToLocation(CharacterMoveComponent moveComp, CharacterAnimationComponent animComp, Vector targetLocation, [Nullable(2)] Action callback = null, [Nullable(2)] Action onStart = null, int modelBufferTime = 200)
	{
		this.MoveComp = moveComp;
		this.AnimComp = animComp;
		this.TargetLocation = targetLocation;
		this.Callback = callback;
		this.OnStart = onStart;
		this.ModelBufferTime = modelBufferTime;
	}

	// Token: 0x06018837 RID: 100407 RVA: 0x006DFB5C File Offset: 0x006DDD5C
	protected override void OnRunAction()
	{
		if (this.MoveComp == null || this.TargetLocation == null)
		{
			base.Finish(false);
			return;
		}
		MoveCharacterPoint value = new MoveCharacterPoint
		{
			Index = 0,
			Position = this.TargetLocation,
			MoveState = new EPatrolMoveState?(EPatrolMoveState.Walk)
		};
		MoveCharacterConfig config = new MoveCharacterConfig
		{
			Points = value,
			Navigation = true,
			IsFly = false,
			DebugMode = true,
			Loop = false,
			Callback = delegate(ELevelEventState result)
			{
				CharacterAnimationComponent animComp = this.AnimComp;
				FTransformDouble? ftransformDouble = (animComp != null) ? new FTransformDouble?(animComp.GetMeshTransform()) : null;
				if (ftransformDouble != null)
				{
					CharacterActorComponent actorComp = this.MoveComp.ActorComp;
					if (actorComp != null)
					{
						actorComp.SetActorLocation(this.TargetLocation.ToUeVector(false), "[CharacterCustomActionComponent]", false);
					}
					CharacterAnimationComponent animComp2 = this.AnimComp;
					if (animComp2 != null)
					{
						animComp2.SetModelBuffer(ftransformDouble.Value, (float)this.ModelBufferTime);
					}
				}
				CharacterUnifiedStateComponent component = this.MoveComp.Entity.GetComponent<CharacterUnifiedStateComponent>();
				if (component != null)
				{
					component.SetMoveState(ECharMoveState.Stand);
				}
				base.Finish(true);
			},
			ReturnTimeoutFailed = new float?((float)2),
			ReturnFalseWhenNavigationFailed = false,
			Distance = new float?((float)10)
		};
		this.MoveComp.MoveAlongPath(config, "CustomMoveToLocation.OnStart");
	}

	// Token: 0x06018838 RID: 100408 RVA: 0x006DFC1A File Offset: 0x006DDE1A
	protected override void OnAbort()
	{
		this.MoveComp.MoveController.StopMoveWithCallback(ELevelEventState.Success, null);
	}

	// Token: 0x0400BD2A RID: 48426
	private readonly CharacterMoveComponent MoveComp;

	// Token: 0x0400BD2B RID: 48427
	private readonly CharacterAnimationComponent AnimComp;

	// Token: 0x0400BD2C RID: 48428
	private readonly Vector TargetLocation;

	// Token: 0x0400BD2D RID: 48429
	private readonly int ModelBufferTime;
}
