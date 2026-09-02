using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x02004851 RID: 18513
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemManipulableCastToOutletState : SceneItemManipulableCastState
	{
		// Token: 0x06030295 RID: 197269 RVA: 0x00BAEDCA File Offset: 0x00BACFCA
		public SceneItemManipulableCastToOutletState(SceneItemManipulatableComponent sceneItem, [Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase>? cameraShake, [Nullable(2)] UKuroForceFeedbackEffect gamepadShake) : base(sceneItem, cameraShake, gamepadShake)
		{
		}

		// Token: 0x06030296 RID: 197270 RVA: 0x00BAEDD5 File Offset: 0x00BACFD5
		public void SetTarget(Entity newValue)
		{
			this.TargetInternal = newValue;
		}

		// Token: 0x06030297 RID: 197271 RVA: 0x00BAEDDE File Offset: 0x00BACFDE
		public override void SetEnterCallback(Action callback)
		{
			this.EnterCallback = callback;
		}

		// Token: 0x06030298 RID: 197272 RVA: 0x00BAEDE8 File Offset: 0x00BACFE8
		protected override void OnEnter()
		{
			Entity targetInternal = this.TargetInternal;
			if (targetInternal == null || !targetInternal.Valid)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "被控物进入CastToTarget时,没有设置目标", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			base.OnEnter();
			this.SceneItem.IsCanBeHeld = false;
			this.SceneItem.TargetActorComponent = this.TargetInternal.GetComponent<BaseActorComponent>();
			this.SceneItem.TargetOutletComponent = this.TargetInternal.GetComponent<SceneItemOutletComponent>();
			if (this.NeedNotifyServer)
			{
				ControllerBase<LevelGamePlayController>.Instance.ManipulatableBeCastOrDrop2Server(this.SceneItem.Entity.Id, EControlState.LockBaseThrowing);
			}
			base.StartCast();
			base.CalcDirection();
		}

		// Token: 0x06030299 RID: 197273 RVA: 0x00BAEE98 File Offset: 0x00BAD098
		protected override void OnTick(float delta)
		{
			this.Timer += delta;
			float num = Singleton<MathUtils>.Instance.Clamp(this.Timer / this.CastDuration, 0f, 1f);
			UCurveFloat castCurve = this.SceneItem.CastCurve;
			if (castCurve != null && castCurve.IsValid())
			{
				num = this.SceneItem.CastCurve.GetFloatValue(num);
			}
			this.UpdateLocation(num);
			this.UpdateRotation(num);
			this.CheckFinish();
		}

		// Token: 0x0603029A RID: 197274 RVA: 0x00BAEF14 File Offset: 0x00BAD114
		protected override void OnExit()
		{
			base.OnExit();
			this.TargetInternal = null;
			this.SceneItem.StopSequence();
		}

		// Token: 0x0603029B RID: 197275 RVA: 0x00BAEF30 File Offset: 0x00BAD130
		private void UpdateRotation(float alpha)
		{
			float alpha2 = UKismetMathLibrary.Ease(0f, 1f, alpha, EEasingFunc.EaseInOut, 2f, 2);
			global::Rotator socketRotator = this.SceneItem.TargetOutletComponent.GetSocketRotator(this.SceneItem.Entity);
			global::Rotator rotator = global::Rotator.Create();
			global::Rotator.Lerp(this.StartRot, socketRotator, alpha2, rotator);
			this.SceneItem.ActorComp.SetActorRotation(rotator.ToUeRotator(), "[ManipulableCastToOutletState.UpdateRotation]", false);
		}

		// Token: 0x0603029C RID: 197276 RVA: 0x00BAEFA4 File Offset: 0x00BAD1A4
		private void CheckFinish()
		{
			if (this.Timer < this.CastDuration && this.CastDuration > 0f)
			{
				return;
			}
			if (this.SceneItem.PlayingMatchSequence)
			{
				return;
			}
			if (this.SceneItem.MatchSequence != null)
			{
				this.SceneItem.PlayingMatchSequence = true;
				this.SceneItem.PlayMatchSequence(delegate
				{
					this.MatchOutlet();
					this.SceneItem.PlayingMatchSequence = false;
				}, false);
			}
			else
			{
				this.MatchOutlet();
			}
			if (this.FinishCallback != null)
			{
				this.FinishCallback();
			}
		}

		// Token: 0x0603029D RID: 197277 RVA: 0x00BAF028 File Offset: 0x00BAD228
		private void MatchOutlet()
		{
			this.SceneItem.ActivatedOutlet = this.SceneItem.TargetOutletComponent;
			this.SceneItem.ActivatedOutlet.EntityInSocket = this.SceneItem;
			Entity entity = this.SceneItem.TargetOutletComponent.Entity;
			if (!this.SceneItem.ShouldPlayMismatchSequence(entity))
			{
				SceneItemManipulatableComponent sceneItem = this.SceneItem;
				if (sceneItem != null)
				{
					sceneItem.SetState(SceneItemManipulatableComponent.EManipulatableState.MatchingOutlet, "CastToOutlet Finish");
				}
				this.SceneItem.RequestAttachToOutlet();
				return;
			}
			this.SceneItem.CastFreeState.NeedResetPhysicsMode = false;
			SceneItemManipulatableComponent sceneItem2 = this.SceneItem;
			if (sceneItem2 != null)
			{
				sceneItem2.SetState(SceneItemManipulatableComponent.EManipulatableState.BeCastingFree, "CastToOutlet Finish");
			}
			SceneItemManipulatableComponent sceneItem3 = this.SceneItem;
			if (sceneItem3 == null)
			{
				return;
			}
			sceneItem3.TryPlayMismatchSequence(entity);
		}

		// Token: 0x0401BA69 RID: 113257
		[Nullable(2)]
		private Entity TargetInternal;
	}
}
