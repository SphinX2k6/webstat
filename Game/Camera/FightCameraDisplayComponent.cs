using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SeamlessTravel;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070A5 RID: 28837
	[NullableContext(2)]
	[Nullable(0)]
	public class FightCameraDisplayComponent : EntityComponent
	{
		// Token: 0x1700A5C5 RID: 42437
		// (get) Token: 0x06045E72 RID: 286322 RVA: 0x0125003C File Offset: 0x0124E23C
		public ACameraActor CameraActor
		{
			get
			{
				return this.CameraActorInternal;
			}
		}

		// Token: 0x06045E73 RID: 286323 RVA: 0x01250044 File Offset: 0x0124E244
		protected override bool OnCreate(IEntityArgs args = null)
		{
			this.CameraModelInstanceInternal = ((args != null) ? args.GetP1<CameraModelInstance>() : null);
			return base.OnCreate(args);
		}

		// Token: 0x06045E74 RID: 286324 RVA: 0x0125005F File Offset: 0x0124E25F
		protected override bool OnInit()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.ClearWorld, new Action(this.OnClearWorld));
			return true;
		}

		// Token: 0x06045E75 RID: 286325 RVA: 0x0125009C File Offset: 0x0124E29C
		private void OnWorldDone()
		{
			if (ModelBase<SeamlessTravelModel>.Instance.IsSeamlessTravel)
			{
				ControllerBase<CameraController>.Instance.ReturnLockOnCameraMode(0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, this.CameraModelInstanceInternal.CameraName);
				return;
			}
			this.CameraActorInternal = ControllerBase<CameraController>.Instance.SpawnCameraActor();
			ECustomCameraMode? cameraMode = this.CameraModelInstanceInternal.CameraMode;
			ECustomCameraMode ecustomCameraMode = ECustomCameraMode.LockOn;
			if (cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null)
			{
				ControllerBase<CameraController>.Instance.SetViewTarget(this.CameraActorInternal, "FightCamera.OnWorldDone", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, new bool?(false), new bool?(false), this.CameraModelInstanceInternal.CameraName, null, null);
			}
		}

		// Token: 0x06045E76 RID: 286326 RVA: 0x01250144 File Offset: 0x0124E344
		private void OnClearWorld()
		{
			if (ModelBase<SeamlessTravelModel>.Instance.IsSeamlessTravel)
			{
				ControllerBase<CameraController>.Instance.ReturnLockOnCameraMode(0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, this.CameraModelInstanceInternal.CameraName);
				return;
			}
			if (this.CameraActorInternal != null)
			{
				Singleton<ActorSystem>.Instance.Put("FightCameraDisplayComponent.OnClearWorld", this.CameraActorInternal, null);
				this.CameraActorInternal = null;
			}
		}

		// Token: 0x06045E77 RID: 286327 RVA: 0x012501A8 File Offset: 0x0124E3A8
		protected override bool OnClear()
		{
			if (this.CameraActorInternal != null)
			{
				Singleton<ActorSystem>.Instance.Put("FightCameraDisplayComponent.OnClear", this.CameraActorInternal, null);
				this.CameraActorInternal = null;
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.WorldDone, new Action(this.OnWorldDone)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.ClearWorld, new Action(this.OnClearWorld)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.ClearWorld, new Action(this.OnClearWorld));
			}
			this.CameraModelInstanceInternal = null;
			return true;
		}

		// Token: 0x06045E78 RID: 286328 RVA: 0x01250255 File Offset: 0x0124E455
		protected override void OnChangeTimeDilation(float timeDilation)
		{
			ACameraActor cameraActorInternal = this.CameraActorInternal;
			if (cameraActorInternal != null && cameraActorInternal.IsValid())
			{
				this.CameraActorInternal.CustomTimeDilation = timeDilation;
			}
		}

		// Token: 0x06045E79 RID: 286329 RVA: 0x01250278 File Offset: 0x0124E478
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			FightCameraDisplayComponent fightCameraDisplayComponent = (FightCameraDisplayComponent)componentTemplate;
			if (base.CanResetComponentProperty("CameraModelInstanceInternal"))
			{
				if (fightCameraDisplayComponent.CameraModelInstanceInternal == null)
				{
					this.CameraModelInstanceInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CameraModelInstance>(this.CameraModelInstanceInternal), "CameraModelInstanceInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CameraActorInternal"))
			{
				if (fightCameraDisplayComponent.CameraActorInternal == null)
				{
					this.CameraActorInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ACameraActor>(this.CameraActorInternal), "CameraActorInternal"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0402725F RID: 160351
		private CameraModelInstance CameraModelInstanceInternal;

		// Token: 0x04027260 RID: 160352
		private ACameraActor CameraActorInternal;
	}
}
