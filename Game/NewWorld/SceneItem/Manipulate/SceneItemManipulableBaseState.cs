using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Gamepad;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x0200484C RID: 18508
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemManipulableBaseState
	{
		// Token: 0x0603025E RID: 197214 RVA: 0x00BAD7CC File Offset: 0x00BAB9CC
		[NullableContext(1)]
		public SceneItemManipulableBaseState(SceneItemManipulatableComponent sceneItem)
		{
			this.SceneItem = sceneItem;
			this.PropComp = sceneItem.PropComp;
			SceneItemActorComponent actorComp = sceneItem.ActorComp;
			UActorComponent ueActorComp;
			if (actorComp == null)
			{
				ueActorComp = null;
			}
			else
			{
				AActor owner = actorComp.Owner;
				ueActorComp = ((owner != null) ? owner.GetComponentByClass(UActorComponent.StaticClass()) : null);
			}
			this.UeActorComp = ueActorComp;
		}

		// Token: 0x0603025F RID: 197215 RVA: 0x00BAD820 File Offset: 0x00BABA20
		public void ChangeMoveController(bool isAutonomous)
		{
			this.OnChangeMoveController(isAutonomous);
		}

		// Token: 0x06030260 RID: 197216 RVA: 0x00BAD82C File Offset: 0x00BABA2C
		protected virtual void OnChangeMoveController(bool isAutonomous)
		{
			if (isAutonomous)
			{
				SceneItemManipulatableComponent sceneItem = this.SceneItem;
				SceneItemManipulatableComponent.EManipulatableState? emanipulatableState = (sceneItem != null) ? new SceneItemManipulatableComponent.EManipulatableState?(sceneItem.GetState()) : null;
				if (emanipulatableState != null)
				{
					switch (emanipulatableState.GetValueOrDefault())
					{
					case SceneItemManipulatableComponent.EManipulatableState.BeDrawing:
					case SceneItemManipulatableComponent.EManipulatableState.BeHolding:
					case SceneItemManipulatableComponent.EManipulatableState.BeCastingToTarget:
					case SceneItemManipulatableComponent.EManipulatableState.BeCastingToOutlet:
					case SceneItemManipulatableComponent.EManipulatableState.BeCastingProjectile:
					case SceneItemManipulatableComponent.EManipulatableState.BeDropping:
					{
						SceneItemManipulatableComponent sceneItem2 = this.SceneItem;
						if (sceneItem2 == null)
						{
							return;
						}
						sceneItem2.SetState(SceneItemManipulatableComponent.EManipulatableState.BeCastingFree, "OnChangeMoveController");
						return;
					}
					case SceneItemManipulatableComponent.EManipulatableState.BePrecasting:
					case SceneItemManipulatableComponent.EManipulatableState.BeCastingFree:
					case SceneItemManipulatableComponent.EManipulatableState.MatchingOutlet:
						break;
					default:
						return;
					}
				}
			}
			else
			{
				this.OnExit();
			}
		}

		// Token: 0x06030261 RID: 197217 RVA: 0x00BAD8B8 File Offset: 0x00BABAB8
		public void Enter(bool isAutonomous)
		{
			if (isAutonomous)
			{
				this.OnEnter();
				return;
			}
			this.OnSimulateEnter();
		}

		// Token: 0x06030262 RID: 197218 RVA: 0x00BAD8CA File Offset: 0x00BABACA
		protected virtual void OnEnter()
		{
		}

		// Token: 0x06030263 RID: 197219 RVA: 0x00BAD8CC File Offset: 0x00BABACC
		protected virtual void OnSimulateEnter()
		{
		}

		// Token: 0x06030264 RID: 197220 RVA: 0x00BAD8CE File Offset: 0x00BABACE
		public void Tick(float delta, bool isAutonomous)
		{
			if (isAutonomous)
			{
				this.OnTick(delta);
				return;
			}
			this.OnSimulateTick(delta);
		}

		// Token: 0x06030265 RID: 197221 RVA: 0x00BAD8E2 File Offset: 0x00BABAE2
		protected virtual void OnTick(float delta)
		{
		}

		// Token: 0x06030266 RID: 197222 RVA: 0x00BAD8E4 File Offset: 0x00BABAE4
		protected virtual void OnSimulateTick(float delta)
		{
		}

		// Token: 0x06030267 RID: 197223 RVA: 0x00BAD8E6 File Offset: 0x00BABAE6
		public void Exit(bool isAutonomous)
		{
			if (isAutonomous)
			{
				this.OnExit();
				return;
			}
			this.OnSimulateExit();
		}

		// Token: 0x06030268 RID: 197224 RVA: 0x00BAD8F8 File Offset: 0x00BABAF8
		protected virtual void OnExit()
		{
		}

		// Token: 0x06030269 RID: 197225 RVA: 0x00BAD8FA File Offset: 0x00BABAFA
		protected virtual void OnSimulateExit()
		{
		}

		// Token: 0x0603026A RID: 197226 RVA: 0x00BAD8FC File Offset: 0x00BABAFC
		protected void StartCameraShake([Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase>? shakeClass)
		{
			APlayerCameraManager characterCameraManager = Global.CharacterCameraManager;
			if (characterCameraManager != null && characterCameraManager.IsValid() && (shakeClass != null && shakeClass.GetValueOrDefault().IsValid()))
			{
				this.CurrentCameraShake = characterCameraManager.StartMatineeCameraShake(shakeClass.Value.As<UMatineeCameraShake>(), 1f, ECameraShakePlaySpace.CameraLocal, default(FRotator), 1f);
			}
		}

		// Token: 0x0603026B RID: 197227 RVA: 0x00BAD968 File Offset: 0x00BABB68
		protected void StopCameraShake()
		{
			APlayerCameraManager characterCameraManager = Global.CharacterCameraManager;
			if (characterCameraManager != null && characterCameraManager.IsValid())
			{
				UCameraShakeBase currentCameraShake = this.CurrentCameraShake;
				if (currentCameraShake != null && currentCameraShake.IsValid())
				{
					characterCameraManager.StopCameraShake(this.CurrentCameraShake, true);
				}
			}
		}

		// Token: 0x0603026C RID: 197228 RVA: 0x00BAD9A7 File Offset: 0x00BABBA7
		protected void StartGamepadShake(UKuroForceFeedbackEffect gamepadShake)
		{
			if (gamepadShake == null || !gamepadShake.IsValid())
			{
				return;
			}
			ControllerBase<GamepadController>.Instance.TriggerGamepadShakeByManipulatable(gamepadShake);
		}

		// Token: 0x0603026D RID: 197229 RVA: 0x00BAD9C6 File Offset: 0x00BABBC6
		protected void StopGamepadShake(UKuroForceFeedbackEffect gamepadShake)
		{
			if (gamepadShake == null || !gamepadShake.IsValid())
			{
				return;
			}
			ControllerBase<GamepadController>.Instance.StopManipulatableGamepadShake(gamepadShake);
		}

		// Token: 0x0603026E RID: 197230 RVA: 0x00BAD9E5 File Offset: 0x00BABBE5
		protected void OpenPhysicsSplit()
		{
			UActorComponent ueActorComp = this.UeActorComp;
			if (ueActorComp != null && ueActorComp.IsValid())
			{
				this.UeActorComp.bEnableAutoPhysicsSplit = true;
			}
		}

		// Token: 0x0603026F RID: 197231 RVA: 0x00BADA07 File Offset: 0x00BABC07
		protected void ClosePhysicsSplit()
		{
			UActorComponent ueActorComp = this.UeActorComp;
			if (ueActorComp != null && ueActorComp.IsValid())
			{
				this.UeActorComp.bEnableAutoPhysicsSplit = false;
				this.UeActorComp.KuroCreatePhysicsState(false);
			}
		}

		// Token: 0x06030270 RID: 197232 RVA: 0x00BADA35 File Offset: 0x00BABC35
		public virtual bool IsNoLockCasting()
		{
			return false;
		}

		// Token: 0x0401BA39 RID: 113209
		protected readonly SceneItemManipulatableComponent SceneItem;

		// Token: 0x0401BA3A RID: 113210
		protected readonly SceneItemPropertyComponent PropComp;

		// Token: 0x0401BA3B RID: 113211
		private UCameraShakeBase CurrentCameraShake;

		// Token: 0x0401BA3C RID: 113212
		protected Action EnterCallback;

		// Token: 0x0401BA3D RID: 113213
		protected readonly Action ExitCallback;

		// Token: 0x0401BA3E RID: 113214
		protected float Timer;

		// Token: 0x0401BA3F RID: 113215
		protected UActorComponent UeActorComp;
	}
}
