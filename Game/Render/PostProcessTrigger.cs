using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Battle;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004778 RID: 18296
	[NullableContext(2)]
	[Nullable(0)]
	public class PostProcessTrigger
	{
		// Token: 0x0602F75E RID: 194398 RVA: 0x00B47F28 File Offset: 0x00B46128
		[NullableContext(1)]
		public void Init(UBoxComponent innerBoxCollision, UBoxComponent outerBoxCollision, UKuroPostProcessComponent postProcess, double transitionTime, EWuYinQuState wuYinQuBattleState, string wuYinQuActorKey)
		{
			this.WuYinQuActorKey = wuYinQuActorKey;
			this.WuYinQuBattleState = new EWuYinQuState?(wuYinQuBattleState);
			this.StateMachine = new StateMachine<PostProcessTrigger, EPostProcessTriggerState>(this, null);
			this.StateMachine.AddState<PostProcessTriggerStateInside>(EPostProcessTriggerState.Inside, null);
			this.StateMachine.AddState<PostProcessTriggerStateOutside>(EPostProcessTriggerState.Outside, null);
			this.StateMachine.AddState<PostProcessTriggerStateInsideToOutside>(EPostProcessTriggerState.InsideToOutSide, null);
			this.StateMachine.AddState<PostProcessTriggerStateOutsideToInside>(EPostProcessTriggerState.OutsideToInside, null);
			this.StateMachine.Start(EPostProcessTriggerState.Outside);
			this.InnerBox = innerBoxCollision;
			this.OuterBox = outerBoxCollision;
			this.PostProcess = postProcess;
			this.TransitionTime = transitionTime;
			this.TargetState = new EPostProcessTriggerState?(EPostProcessTriggerState.Outside);
			this.PostProcess.BlendWeight = 0f;
			this.PostProcess.bUnbound = true;
			this.InnerBox.OnComponentBeginOverlapNoGcAlloc.Add(new Action<UPrimitiveComponent, AActor, UPrimitiveComponent>(this.OnInnerComponentBeginOverlap));
			this.OuterBox.OnComponentEndOverlap.Add(new Action<UPrimitiveComponent, AActor, UPrimitiveComponent, int>(this.OnOuterComponentEndOverlap));
			TArray<AActor> tarray = new TArray<AActor>();
			this.InnerBox.GetOverlappingActors(ref tarray, default(TSubclassOf<AActor>));
			if (tarray == null)
			{
				return;
			}
			for (int i = 0; i < tarray.Num(); i++)
			{
				if (this.IsRelativeActor(tarray.Get(i)))
				{
					this.TargetState = new EPostProcessTriggerState?(EPostProcessTriggerState.Inside);
				}
			}
		}

		// Token: 0x0602F75F RID: 194399 RVA: 0x00B48061 File Offset: 0x00B46261
		[NullableContext(1)]
		public string GetWuYinQuBattleKey()
		{
			return this.WuYinQuActorKey;
		}

		// Token: 0x0602F760 RID: 194400 RVA: 0x00B48069 File Offset: 0x00B46269
		public EWuYinQuState? GetWuYinQuBattleState()
		{
			return this.WuYinQuBattleState;
		}

		// Token: 0x0602F761 RID: 194401 RVA: 0x00B48071 File Offset: 0x00B46271
		public UKuroPostProcessComponent GetPostProcessComponent()
		{
			return this.PostProcess;
		}

		// Token: 0x0602F762 RID: 194402 RVA: 0x00B48079 File Offset: 0x00B46279
		private void OnInnerComponentBeginOverlap(UPrimitiveComponent overlappedComponent, AActor otherActor, UPrimitiveComponent otherComp)
		{
			if (!this.IsRelativeActor(otherActor))
			{
				return;
			}
			this.TargetState = new EPostProcessTriggerState?(EPostProcessTriggerState.Inside);
		}

		// Token: 0x0602F763 RID: 194403 RVA: 0x00B48094 File Offset: 0x00B46294
		private bool IsRelativeActor(AActor otherActor)
		{
			if (!UKismetSystemLibrary.IsValid(otherActor))
			{
				return false;
			}
			AActor myRoleTrigger = ControllerBase<RoleTriggerController>.Instance.GetMyRoleTrigger();
			return otherActor == myRoleTrigger;
		}

		// Token: 0x0602F764 RID: 194404 RVA: 0x00B480BD File Offset: 0x00B462BD
		private void OnOuterComponentEndOverlap(UPrimitiveComponent overlappedComponent, AActor otherActor, UPrimitiveComponent otherComp, int otherBodyIndex)
		{
			if (!this.IsRelativeActor(otherActor))
			{
				return;
			}
			this.TargetState = new EPostProcessTriggerState?(EPostProcessTriggerState.Outside);
		}

		// Token: 0x0602F765 RID: 194405 RVA: 0x00B480D8 File Offset: 0x00B462D8
		public void Tick(float deltaTime)
		{
			EPostProcessTriggerState? currentState = this.StateMachine.CurrentState;
			EPostProcessTriggerState? epostProcessTriggerState = this.TargetState;
			if (!(currentState.GetValueOrDefault() == epostProcessTriggerState.GetValueOrDefault() & currentState != null == (epostProcessTriggerState != null)))
			{
				epostProcessTriggerState = this.StateMachine.CurrentState;
				EPostProcessTriggerState epostProcessTriggerState2 = EPostProcessTriggerState.Inside;
				if (epostProcessTriggerState.GetValueOrDefault() == epostProcessTriggerState2 & epostProcessTriggerState != null)
				{
					this.StateMachine.Switch(EPostProcessTriggerState.InsideToOutSide);
				}
				else if (this.StateMachine.CurrentState.GetValueOrDefault() == EPostProcessTriggerState.Outside)
				{
					this.StateMachine.Switch(EPostProcessTriggerState.OutsideToInside);
				}
			}
			this.StateMachine.Update(deltaTime);
		}

		// Token: 0x0602F766 RID: 194406 RVA: 0x00B4817B File Offset: 0x00B4637B
		public void Dispose()
		{
			this.InnerBox.OnComponentBeginOverlapNoGcAlloc.Remove(new Action<UPrimitiveComponent, AActor, UPrimitiveComponent>(this.OnInnerComponentBeginOverlap));
			this.OuterBox.OnComponentEndOverlap.Remove(new Action<UPrimitiveComponent, AActor, UPrimitiveComponent, int>(this.OnOuterComponentEndOverlap));
		}

		// Token: 0x0401B1CF RID: 111055
		private UBoxComponent InnerBox;

		// Token: 0x0401B1D0 RID: 111056
		private UBoxComponent OuterBox;

		// Token: 0x0401B1D1 RID: 111057
		private UKuroPostProcessComponent PostProcess;

		// Token: 0x0401B1D2 RID: 111058
		public double TransitionTime;

		// Token: 0x0401B1D3 RID: 111059
		private EPostProcessTriggerState? TargetState;

		// Token: 0x0401B1D4 RID: 111060
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private StateMachine<PostProcessTrigger, EPostProcessTriggerState> StateMachine;

		// Token: 0x0401B1D5 RID: 111061
		private EWuYinQuState? WuYinQuBattleState;

		// Token: 0x0401B1D6 RID: 111062
		[Nullable(1)]
		private string WuYinQuActorKey = "";
	}
}
