using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x02004850 RID: 18512
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemManipulableCastState : SceneItemManipulableBaseState
	{
		// Token: 0x06030287 RID: 197255 RVA: 0x00BAE5C4 File Offset: 0x00BAC7C4
		[NullableContext(1)]
		public SceneItemManipulableCastState(SceneItemManipulatableComponent sceneItem, [Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase>? cameraShake, [Nullable(2)] UKuroForceFeedbackEffect gamepadShake) : base(sceneItem)
		{
			this.CameraShake = cameraShake;
			this.GamepadShake = gamepadShake;
		}

		// Token: 0x06030288 RID: 197256 RVA: 0x00BAE62B File Offset: 0x00BAC82B
		[NullableContext(1)]
		public void SetFinishCallback(Action callback)
		{
			this.FinishCallback = callback;
		}

		// Token: 0x06030289 RID: 197257 RVA: 0x00BAE634 File Offset: 0x00BAC834
		public void SetHitCallback([Nullable(new byte[]
		{
			1,
			2,
			2,
			1
		})] Action<AActor, AActor, FVector, FHitResult> callback)
		{
			this.HitCallback = callback;
		}

		// Token: 0x0603028A RID: 197258 RVA: 0x00BAE63D File Offset: 0x00BAC83D
		[NullableContext(1)]
		public virtual void SetEnterCallback(Action callback)
		{
			this.EnterCallback = callback;
		}

		// Token: 0x0603028B RID: 197259 RVA: 0x00BAE648 File Offset: 0x00BAC848
		protected override void OnEnter()
		{
			base.StartCameraShake(this.CameraShake);
			base.StartGamepadShake(this.GamepadShake);
			this.Timer = 0f;
			this.AfterHit = false;
			this.SceneItem.ActorComp.Owner.OnActorHit.Clear();
			if (this.HitCallback != null)
			{
				this.SceneItem.ActorComp.Owner.OnActorHit.Add(this.HitCallback);
				this.SceneItem.ActorComp.Owner.OnActorHit.Add(new Action<AActor, AActor, FVector, FHitResult>(this.ModifyAfterHit));
			}
			this.SceneItem.NeedRemoveControllerId = true;
			this.SceneItem.OnCastItem();
			this.SceneItem.TryAddTagById(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.抛出中"]);
			if (!FNameUtil.IsNothing(this.SceneItem.ManipulateBaseConfig.投掷状态碰撞预设))
			{
				this.SceneItem.ActorComp.GetPrimitiveComponent().SetCollisionProfileName(this.SceneItem.ManipulateBaseConfig.投掷状态碰撞预设, true);
			}
			if (this.SceneItem.ManipulateBaseConfig.投掷状态CueId != null && this.SceneItem.ManipulateBaseConfig.投掷状态CueId.Num() > 0)
			{
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				BaseGameplayCueComponent cueComp;
				if (baseCharacter == null)
				{
					cueComp = null;
				}
				else
				{
					Entity entityNoBlueprint = baseCharacter.GetEntityNoBlueprint();
					cueComp = ((entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<BaseGameplayCueComponent>() : null);
				}
				this.CueComp = cueComp;
				if (this.CueComp == null)
				{
					return;
				}
				foreach (KeyValuePair<int, float> keyValuePair in this.SceneItem.ManipulateBaseConfig.投掷状态CueId)
				{
					int num;
					float num2;
					keyValuePair.Deconstruct(out num, out num2);
					int num3 = num;
					float num4 = num2;
					SceneItemManipulableCastState.<>c__DisplayClass22_0 CS$<>8__locals1 = new SceneItemManipulableCastState.<>c__DisplayClass22_0();
					CS$<>8__locals1.<>4__this = this;
					if (num4 > 0f)
					{
						CS$<>8__locals1.cueHandleId = this.CueComp.AddCue((long)num3, null);
						if (CS$<>8__locals1.cueHandleId != 0)
						{
							TimerHandle timerHandle = TimerSystem.Instance.Delay(new TTimerAction(CS$<>8__locals1.<OnEnter>g__RemoveCueFunc|0), num4 * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
							if (timerHandle == null)
							{
								Log instance = Singleton<Log>.Instance;
								ELogModule module = ELogModule.SceneItem;
								ELogAuthor author = ELogAuthor.CH;
								string message = "创建TimerHandle失败";
								ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CueId", num3);
								instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
								this.CueComp.RemoveCueByHandle((long)CS$<>8__locals1.cueHandleId);
							}
							else
							{
								this.CueTimerHandles.Add(CS$<>8__locals1.cueHandleId, timerHandle);
							}
						}
					}
				}
			}
		}

		// Token: 0x0603028C RID: 197260 RVA: 0x00BAE8D8 File Offset: 0x00BACAD8
		private void ModifyAfterHit(AActor selfActor, AActor otherActor, FVector vector, [Nullable(1)] FHitResult hitResult)
		{
			this.AfterHit = true;
		}

		// Token: 0x0603028D RID: 197261 RVA: 0x00BAE8E1 File Offset: 0x00BACAE1
		protected override void OnTick(float delta)
		{
		}

		// Token: 0x0603028E RID: 197262 RVA: 0x00BAE8E4 File Offset: 0x00BACAE4
		protected override void OnExit()
		{
			base.StopCameraShake();
			base.StopGamepadShake(this.GamepadShake);
			this.SceneItem.TryRemoveTagById(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.抛出中"]);
			this.NeedResetPhysicsMode = true;
			this.NeedNotifyServer = true;
			if (this.HitCallback != null)
			{
				this.SceneItem.ActorComp.Owner.OnActorHit.Clear();
			}
			if (this.CueTimerHandles != null && this.CueTimerHandles.Count > 0)
			{
				foreach (KeyValuePair<int, TimerHandle> keyValuePair in this.CueTimerHandles)
				{
					TimerSystem.Instance.Remove(keyValuePair.Value);
					BaseGameplayCueComponent cueComp = this.CueComp;
					if (cueComp != null)
					{
						cueComp.RemoveCueByHandle((long)keyValuePair.Key);
					}
				}
				this.CueTimerHandles.Clear();
			}
			this.CueComp = null;
		}

		// Token: 0x0603028F RID: 197263 RVA: 0x00BAE9E0 File Offset: 0x00BACBE0
		protected void StartCast()
		{
			double num = Vector.Dist(this.SceneItem.ActorComp.ActorLocationProxy, this.SceneItem.TargetActorComponent.ActorLocationProxy);
			float num2 = 1f;
			IThrowMotion motionConfig = this.SceneItem.Config.ThrowCfg.MotionConfig;
			if (motionConfig.Type == EThrowMotion.Projectile)
			{
				num2 = (motionConfig as IProjectileMotion).Velocity;
			}
			this.CastDuration = (float)(num / (double)num2);
			this.CastRotAxis = Vector.Create(UKismetMathLibrary.RandomUnitVector());
			this.StartLoc = Vector.Create(this.SceneItem.ActorComp.ActorLocation);
			this.StartRot = Rotator.Create(this.SceneItem.ActorComp.ActorRotation);
			this.SceneItem.ActorComp.PhysicsMode = SceneItemActorComponent.EPhysicsMode.Kinematic;
		}

		// Token: 0x06030290 RID: 197264 RVA: 0x00BAEAB4 File Offset: 0x00BACCB4
		protected void CalcDirection()
		{
			this.SceneItem.CalcCastTargetPoint();
			Vector vector = Vector.Create(this.SceneItem.CastTargetLocation);
			vector.SubtractionEqual(this.StartLoc);
			UCurveVector 投掷运动轨迹曲线 = this.SceneItem.ManipulateBaseConfig.投掷运动轨迹曲线;
			if (投掷运动轨迹曲线 != null && 投掷运动轨迹曲线.IsValid())
			{
				this.IsUsePath = (vector.Size() > (double)ConfigBase<ManipulateConfig>.Instance.DontUseLineDistance);
			}
			this.PathScaleFactor = (float)vector.Size();
			vector.Normalize(9.99999993922529E-09);
			this.CastDirection = Vector.Create(vector);
			Vector vector2 = Vector.Create();
			Vector vector3 = Vector.Create(Vector.UpVectorProxy);
			Singleton<GravityUtils>.Instance.RotatedVectorByActorInitGravity(this.SceneItem.ActorComp, vector3);
			this.CastDirection.CrossProduct(vector3, vector2);
			vector2.CrossProduct(this.CastDirection, this.CastVerticalDirection);
			this.CastVerticalDirection.Normalize(9.99999993922529E-09);
			this.CastVerticalDirection.CrossProduct(this.CastDirection, this.CastHorizontalDirection);
			this.CastHorizontalDirection.Normalize(9.99999993922529E-09);
		}

		// Token: 0x06030291 RID: 197265 RVA: 0x00BAEBD4 File Offset: 0x00BACDD4
		protected virtual void UpdateRotationAccordingToVelocity()
		{
			if (!this.SceneItem.ManipulateBaseConfig.随速度调整朝向)
			{
				return;
			}
			if (this.AfterHit)
			{
				return;
			}
			FVector componentVelocity = this.SceneItem.ActorComp.GetPrimitiveComponent().GetComponentVelocity();
			componentVelocity.Normalize(1E-08f);
			FVectorDouble fvectorDouble = UKismetMathLibrary.Conv_VectorToVectorDouble(componentVelocity);
			FVectorDouble actorLocation = this.SceneItem.ActorComp.ActorLocation;
			FVectorDouble actorLocation2 = this.SceneItem.ActorComp.ActorLocation;
			FVectorDouble fvectorDouble2 = actorLocation2 + fvectorDouble;
			FRotator value = UKismetMathLibrary.D_FindLookAtRotation(actorLocation, fvectorDouble2);
			this.SceneItem.ActorComp.SetActorRotation(value, "[ManipulableCastState.UpdateRotationAccordingToVelocity]", false);
		}

		// Token: 0x06030292 RID: 197266 RVA: 0x00BAEC78 File Offset: 0x00BACE78
		protected virtual void UpdateLocation(float alpha)
		{
			if (this.SceneItem.PlayingMatchSequence)
			{
				return;
			}
			Vector vector = Vector.Create();
			if (this.IsUsePath)
			{
				Vector vector2 = Vector.Create(this.SceneItem.ManipulateBaseConfig.投掷运动轨迹曲线.GetVectorValue(alpha));
				vector2.MultiplyEqual((double)this.PathScaleFactor);
				Vector vector3 = Vector.Create();
				Vector vector4 = Vector.Create();
				Vector vector5 = Vector.Create();
				this.CastDirection.Multiply(vector2.X, vector3);
				this.CastHorizontalDirection.Multiply(vector2.Y, vector4);
				this.CastVerticalDirection.Multiply(vector2.Z, vector5);
				vector.AdditionEqual(vector3).AdditionEqual(vector4).AdditionEqual(vector5);
				vector.AdditionEqual(this.StartLoc);
			}
			else
			{
				float blendExp = 3f;
				float num = UKismetMathLibrary.Ease(0f, 1f, alpha, EEasingFunc.EaseOut, blendExp, 2);
				Vector.Lerp(this.StartLoc, this.SceneItem.CastTargetLocation, (double)num, vector);
			}
			this.SceneItem.ActorComp.SetActorLocation(vector.ToUeVector(false), "[ManipulableCastState.UpdateLocation]", this.HitCallback != null);
		}

		// Token: 0x06030293 RID: 197267 RVA: 0x00BAEDA1 File Offset: 0x00BACFA1
		public bool HasHitCallback()
		{
			return this.HitCallback != null;
		}

		// Token: 0x06030294 RID: 197268 RVA: 0x00BAEDAC File Offset: 0x00BACFAC
		public void CallHitCallback(AActor selfActor, AActor otherActor)
		{
			Action<AActor, AActor, FVector, FHitResult> hitCallback = this.HitCallback;
			if (hitCallback == null)
			{
				return;
			}
			hitCallback(selfActor, otherActor, new FVector(), new FHitResult());
		}

		// Token: 0x0401BA57 RID: 113239
		[Nullable(new byte[]
		{
			0,
			1
		})]
		private readonly TSubclassOf<UCameraShakeBase>? CameraShake;

		// Token: 0x0401BA58 RID: 113240
		private readonly UKuroForceFeedbackEffect GamepadShake;

		// Token: 0x0401BA59 RID: 113241
		protected float CastDuration = --0f;

		// Token: 0x0401BA5A RID: 113242
		protected Vector CastRotAxis;

		// Token: 0x0401BA5B RID: 113243
		protected Vector StartLoc;

		// Token: 0x0401BA5C RID: 113244
		protected Rotator StartRot;

		// Token: 0x0401BA5D RID: 113245
		protected bool IsUsePath;

		// Token: 0x0401BA5E RID: 113246
		protected float PathScaleFactor = --0f;

		// Token: 0x0401BA5F RID: 113247
		protected Vector CastDirection;

		// Token: 0x0401BA60 RID: 113248
		protected Action FinishCallback;

		// Token: 0x0401BA61 RID: 113249
		[Nullable(new byte[]
		{
			2,
			2,
			2,
			1
		})]
		protected Action<AActor, AActor, FVector, FHitResult> HitCallback;

		// Token: 0x0401BA62 RID: 113250
		[Nullable(1)]
		private readonly Vector CastHorizontalDirection = Vector.Create();

		// Token: 0x0401BA63 RID: 113251
		[Nullable(1)]
		private readonly Vector CastVerticalDirection = Vector.Create();

		// Token: 0x0401BA64 RID: 113252
		protected bool AfterHit;

		// Token: 0x0401BA65 RID: 113253
		public bool NeedResetPhysicsMode = true;

		// Token: 0x0401BA66 RID: 113254
		public bool NeedNotifyServer = true;

		// Token: 0x0401BA67 RID: 113255
		[Nullable(1)]
		private readonly Dictionary<int, TimerHandle> CueTimerHandles = new Dictionary<int, TimerHandle>();

		// Token: 0x0401BA68 RID: 113256
		private BaseGameplayCueComponent CueComp;
	}
}
