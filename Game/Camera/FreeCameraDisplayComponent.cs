using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070A7 RID: 28839
	[NullableContext(2)]
	[Nullable(0)]
	public class FreeCameraDisplayComponent : EntityComponent
	{
		// Token: 0x1700A5C9 RID: 42441
		// (get) Token: 0x06045E86 RID: 286342 RVA: 0x01250431 File Offset: 0x0124E631
		// (set) Token: 0x06045E87 RID: 286343 RVA: 0x01250439 File Offset: 0x0124E639
		public ACameraActor CameraActor { get; private set; }

		// Token: 0x06045E88 RID: 286344 RVA: 0x01250442 File Offset: 0x0124E642
		protected override bool OnCreate(IEntityArgs args = null)
		{
			this.CameraModelInstanceInternal = ((args != null) ? args.GetP1<CameraModelInstance>() : null);
			return base.OnCreate(args);
		}

		// Token: 0x06045E89 RID: 286345 RVA: 0x01250460 File Offset: 0x0124E660
		protected override bool OnInit()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.ClearWorld, new Action(this.OnClearWorld));
			if (ModelBase<GameModeModel>.Instance.WorldDone)
			{
				this.SpawnCamera();
			}
			return true;
		}

		// Token: 0x06045E8A RID: 286346 RVA: 0x012504B8 File Offset: 0x0124E6B8
		private void OnWorldDone()
		{
			this.SpawnCamera();
		}

		// Token: 0x06045E8B RID: 286347 RVA: 0x012504C0 File Offset: 0x0124E6C0
		private void SpawnCamera()
		{
			if (this.CameraActor != null)
			{
				return;
			}
			this.CameraActor = ControllerBase<CameraController>.Instance.SpawnCameraActor();
			this.CameraActor.CustomTimeDilation = base.TimeDilation;
			ECustomCameraMode? cameraMode = this.CameraModelInstanceInternal.CameraMode;
			ECustomCameraMode ecustomCameraMode = ECustomCameraMode.Free;
			if (cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null)
			{
				ControllerBase<CameraController>.Instance.SetViewTarget(this.CameraActor, "FreeCamera.OnWorldDone", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, new bool?(false), new bool?(false), this.CameraModelInstanceInternal.CameraName, null, null);
			}
		}

		// Token: 0x06045E8C RID: 286348 RVA: 0x01250552 File Offset: 0x0124E752
		private void OnClearWorld()
		{
			if (this.CameraActor != null)
			{
				Singleton<ActorSystem>.Instance.Put("FreeCameraDisplayComponent.OnClearWorld", this.CameraActor, null);
				this.CameraActor = null;
			}
		}

		// Token: 0x06045E8D RID: 286349 RVA: 0x0125057C File Offset: 0x0124E77C
		protected override bool OnClear()
		{
			if (this.CameraActor != null)
			{
				Singleton<ActorSystem>.Instance.Put("FreeCameraDisplayComponent.OnClear", this.CameraActor, null);
				this.CameraActor = null;
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

		// Token: 0x06045E8E RID: 286350 RVA: 0x01250629 File Offset: 0x0124E829
		protected override void OnChangeTimeDilation(float timeDilation)
		{
			ACameraActor cameraActor = this.CameraActor;
			if (cameraActor != null && cameraActor.IsValid())
			{
				this.CameraActor.CustomTimeDilation = timeDilation;
			}
		}

		// Token: 0x06045E8F RID: 286351 RVA: 0x0125064C File Offset: 0x0124E84C
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			FreeCameraDisplayComponent freeCameraDisplayComponent = (FreeCameraDisplayComponent)componentTemplate;
			if (base.CanResetComponentProperty("CameraModelInstanceInternal"))
			{
				if (freeCameraDisplayComponent.CameraModelInstanceInternal == null)
				{
					this.CameraModelInstanceInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CameraModelInstance>(this.CameraModelInstanceInternal), "CameraModelInstanceInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("<CameraActor>k__BackingField"))
			{
				if (freeCameraDisplayComponent.CameraActor == null)
				{
					this.CameraActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ACameraActor>(this.CameraActor), "<CameraActor>k__BackingField"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04027264 RID: 160356
		private CameraModelInstance CameraModelInstanceInternal;
	}
}
