using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070B7 RID: 28855
	[NullableContext(2)]
	[Nullable(0)]
	public class SequenceCameraDisplayComponent : EntityComponent
	{
		// Token: 0x1700A5D8 RID: 42456
		// (get) Token: 0x06045F3F RID: 286527 RVA: 0x0125530F File Offset: 0x0125350F
		public BP_CineCamera_C CineCamera
		{
			get
			{
				BP_CineCamera_C cineCameraInternal = this.CineCameraInternal;
				if (cineCameraInternal == null || !cineCameraInternal.IsValid())
				{
					this.CineCameraInternal = ControllerBase<CameraController>.Instance.SpawnCineCamera();
				}
				return this.CineCameraInternal;
			}
		}

		// Token: 0x06045F40 RID: 286528 RVA: 0x0125533E File Offset: 0x0125353E
		protected override bool OnCreate(IEntityArgs args = null)
		{
			this.CameraModelInstanceInternal = ((args != null) ? args.GetP1<CameraModelInstance>() : null);
			return base.OnCreate(args);
		}

		// Token: 0x06045F41 RID: 286529 RVA: 0x0125535C File Offset: 0x0125355C
		protected override bool OnInit()
		{
			this.CineCameraInternal = ControllerBase<CameraController>.Instance.SpawnCineCamera();
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.ClearWorld, new Action(this.OnClearWorld));
			return true;
		}

		// Token: 0x06045F42 RID: 286530 RVA: 0x012553B4 File Offset: 0x012535B4
		protected void OnWorldDone()
		{
			this.CineCameraInternal = ControllerBase<CameraController>.Instance.SpawnCineCamera();
			ECustomCameraMode? cameraMode = this.CameraModelInstanceInternal.CameraMode;
			ECustomCameraMode ecustomCameraMode = ECustomCameraMode.Sequence;
			if (cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null)
			{
				ControllerBase<CameraController>.Instance.SetViewTarget(this.CineCameraInternal, "SequenceCamera.OnWorldDone", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, new bool?(false), new bool?(false), this.CameraModelInstanceInternal.CameraName, null, null);
			}
		}

		// Token: 0x06045F43 RID: 286531 RVA: 0x0125542C File Offset: 0x0125362C
		protected void OnClearWorld()
		{
			if (this.CineCameraInternal != null)
			{
				Singleton<ActorSystem>.Instance.Put("SequenceCameraDisplayComponent.OnClearWorld", this.CineCameraInternal, null);
				this.CineCameraInternal = null;
			}
		}

		// Token: 0x06045F44 RID: 286532 RVA: 0x01255454 File Offset: 0x01253654
		protected override bool OnClear()
		{
			if (this.CineCameraInternal != null)
			{
				Singleton<ActorSystem>.Instance.Put("SequenceCameraDisplayComponent.OnClearWorld", this.CineCameraInternal, null);
				this.CineCameraInternal = null;
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.WorldDone, new Action(this.OnWorldDone)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.ClearWorld, new Action(this.OnClearWorld)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.ClearWorld, new Action(this.OnClearWorld));
			}
			return true;
		}

		// Token: 0x06045F45 RID: 286533 RVA: 0x012554FA File Offset: 0x012536FA
		protected override void OnChangeTimeDilation(float timeDilation)
		{
			BP_CineCamera_C cineCameraInternal = this.CineCameraInternal;
			if (cineCameraInternal != null && cineCameraInternal.IsValid())
			{
				this.CineCameraInternal.CustomTimeDilation = timeDilation;
			}
		}

		// Token: 0x06045F46 RID: 286534 RVA: 0x0125551C File Offset: 0x0125371C
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SequenceCameraDisplayComponent sequenceCameraDisplayComponent = (SequenceCameraDisplayComponent)componentTemplate;
			if (base.CanResetComponentProperty("CameraModelInstanceInternal"))
			{
				if (sequenceCameraDisplayComponent.CameraModelInstanceInternal == null)
				{
					this.CameraModelInstanceInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CameraModelInstance>(this.CameraModelInstanceInternal), "CameraModelInstanceInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CineCameraInternal"))
			{
				if (sequenceCameraDisplayComponent.CineCameraInternal == null)
				{
					this.CineCameraInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BP_CineCamera_C>(this.CineCameraInternal), "CineCameraInternal"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x040272FF RID: 160511
		private CameraModelInstance CameraModelInstanceInternal;

		// Token: 0x04027300 RID: 160512
		private BP_CineCamera_C CineCameraInternal;
	}
}
