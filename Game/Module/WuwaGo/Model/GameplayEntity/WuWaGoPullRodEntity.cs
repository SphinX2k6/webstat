using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AED RID: 19181
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoPullRodEntity : WuWaGoGameplayEntityBase
	{
		// Token: 0x06032021 RID: 204833 RVA: 0x00C83B81 File Offset: 0x00C81D81
		public WuWaGoPullRodEntity(int pbDataId, Vector coordinate, Rotator rotator, IWuWaGoPullRod config) : base(EWuWaGoEntityType.PullRod, pbDataId, coordinate, rotator)
		{
		}

		// Token: 0x06032022 RID: 204834 RVA: 0x00C83B9C File Offset: 0x00C81D9C
		public IPullRodInteractResult Interact()
		{
			EGameplayEntityState state = base.State;
			EGameplayEntityState egameplayEntityState = (base.State == EGameplayEntityState.Normal) ? EGameplayEntityState.Activated : EGameplayEntityState.Normal;
			this.SetState(egameplayEntityState);
			return new PullRodInteractResult
			{
				PreviousState = state,
				CurrentState = egameplayEntityState,
				StateAction = this.GetActionByState(state)
			};
		}

		// Token: 0x06032023 RID: 204835 RVA: 0x00C83BE6 File Offset: 0x00C81DE6
		[NullableContext(2)]
		public IWuWaGoInteractStateAction GetActionByState()
		{
			return this.GetActionByState(base.State);
		}

		// Token: 0x06032024 RID: 204836 RVA: 0x00C83BF4 File Offset: 0x00C81DF4
		[NullableContext(2)]
		public IWuWaGoInteractStateAction GetActionByState(EGameplayEntityState state)
		{
			return this.InteractConfig.FirstOrDefault(delegate(IWuWaGoInteractStateAction config)
			{
				EGameplayEntityState egameplayEntityState;
				return EGameplayEntityStateExtensions.TryFromString(config.EntityState, out egameplayEntityState) && egameplayEntityState == state;
			});
		}

		// Token: 0x06032025 RID: 204837 RVA: 0x00C83C25 File Offset: 0x00C81E25
		public override void RestoreInitialStateForGameOver()
		{
			base.RestoreInitialStateWithStateChanged();
		}

		// Token: 0x06032026 RID: 204838 RVA: 0x00C83C2D File Offset: 0x00C81E2D
		public override IRollbackCapture CaptureRollback()
		{
			return new PullRodRollbackCapture(this);
		}

		// Token: 0x06032027 RID: 204839 RVA: 0x00C83C35 File Offset: 0x00C81E35
		public void SyncPresentationForRollback()
		{
			base.SwitchSceneItemStateByGameplayEntityState(base.State, false, true);
		}

		// Token: 0x06032028 RID: 204840 RVA: 0x00C83C48 File Offset: 0x00C81E48
		[NullableContext(2)]
		public Vector GetFacingTargetWorldPosition()
		{
			AActor actorRaw = this.GetActorRaw();
			if (actorRaw == null || !actorRaw.IsValid())
			{
				return null;
			}
			TArray<AActor> tarray = new TArray<AActor>();
			actorRaw.GetAttachedActors(ref tarray, true);
			AActor aactor = (tarray.Num() > 0) ? tarray.Get(0) : null;
			AActor aactor2 = (aactor != null && aactor.IsValid()) ? aactor : actorRaw;
			if (aactor != null && aactor.IsValid())
			{
				TArray<AActor> tarray2 = new TArray<AActor>();
				aactor.GetAttachedActors(ref tarray2, true);
				AActor aactor3 = (tarray2.Num() > 0) ? tarray2.Get(0) : null;
				if (aactor3 != null && aactor3.IsValid())
				{
					aactor2 = aactor3;
				}
			}
			return Vector.Create(aactor2.D_K2_GetActorLocation());
		}

		// Token: 0x06032029 RID: 204841 RVA: 0x00C83CF4 File Offset: 0x00C81EF4
		protected override void OnStateChanged(EGameplayEntityState newState)
		{
			base.SwitchSceneItemStateByGameplayEntityState(newState, true, false);
		}

		// Token: 0x0401D402 RID: 119810
		public readonly IReadOnlyList<IWuWaGoInteractStateAction> InteractConfig = config.InteractConfig;
	}
}
