using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070BD RID: 28861
	[NullableContext(2)]
	[Nullable(0)]
	public class WidgetCameraDisplayComponent : EntityComponent
	{
		// Token: 0x1700A5DD RID: 42461
		// (get) Token: 0x06045FA7 RID: 286631 RVA: 0x0125AB85 File Offset: 0x01258D85
		// (set) Token: 0x06045FA8 RID: 286632 RVA: 0x0125AB8D File Offset: 0x01258D8D
		public BP_CineCamera_C CineCamera { get; private set; }

		// Token: 0x06045FA9 RID: 286633 RVA: 0x0125AB96 File Offset: 0x01258D96
		protected override bool OnCreate(IEntityArgs args = null)
		{
			this.CameraModelInstanceInternal = ((args != null) ? args.GetP1<CameraModelInstance>() : null);
			return base.OnCreate(args);
		}

		// Token: 0x06045FAA RID: 286634 RVA: 0x0125ABB4 File Offset: 0x01258DB4
		protected override bool OnInit()
		{
			this.CineCamera = ControllerBase<CameraController>.Instance.SpawnCineCamera();
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.OnUiManagerClearAsync, new Action(this.OnUiManagerClearAsync));
			return this.CineCamera != null;
		}

		// Token: 0x06045FAB RID: 286635 RVA: 0x0125AC14 File Offset: 0x01258E14
		private void OnWorldDone()
		{
			this.CineCamera = ControllerBase<CameraController>.Instance.SpawnCineCamera();
			ECustomCameraMode? cameraMode = this.CameraModelInstanceInternal.CameraMode;
			ECustomCameraMode ecustomCameraMode = ECustomCameraMode.Widget;
			if (cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null)
			{
				ControllerBase<CameraController>.Instance.SetViewTarget(this.CineCamera, "WidgetCamera.OnWorldDone", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, new bool?(false), new bool?(false), this.CameraModelInstanceInternal.CameraName, null, null);
			}
		}

		// Token: 0x06045FAC RID: 286636 RVA: 0x0125AC8C File Offset: 0x01258E8C
		private void OnUiManagerClearAsync()
		{
			if (this.CineCamera != null)
			{
				Singleton<ActorSystem>.Instance.Put("WidgetCameraDisplayComponent.OnUiManagerClearAsync", this.CineCamera, null);
				this.CineCamera = null;
			}
		}

		// Token: 0x06045FAD RID: 286637 RVA: 0x0125ACB4 File Offset: 0x01258EB4
		protected override bool OnClear()
		{
			if (this.CineCamera != null)
			{
				Singleton<ActorSystem>.Instance.Put("WidgetCameraDisplayComponent.OnClear", this.CineCamera, null);
				this.CineCamera = null;
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.WorldDone, new Action(this.OnWorldDone)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnUiManagerClearAsync, new Action(this.OnUiManagerClearAsync)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnUiManagerClearAsync, new Action(this.OnUiManagerClearAsync));
			}
			this.CameraModelInstanceInternal = null;
			return true;
		}

		// Token: 0x06045FAE RID: 286638 RVA: 0x0125AD61 File Offset: 0x01258F61
		protected override void OnChangeTimeDilation(float timeDilation)
		{
			BP_CineCamera_C cineCamera = this.CineCamera;
			if (cineCamera != null && cineCamera.IsValid())
			{
				this.CineCamera.CustomTimeDilation = timeDilation;
			}
		}

		// Token: 0x06045FAF RID: 286639 RVA: 0x0125AD84 File Offset: 0x01258F84
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			WidgetCameraDisplayComponent widgetCameraDisplayComponent = (WidgetCameraDisplayComponent)componentTemplate;
			if (base.CanResetComponentProperty("CameraModelInstanceInternal"))
			{
				if (widgetCameraDisplayComponent.CameraModelInstanceInternal == null)
				{
					this.CameraModelInstanceInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CameraModelInstance>(this.CameraModelInstanceInternal), "CameraModelInstanceInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("<CineCamera>k__BackingField"))
			{
				if (widgetCameraDisplayComponent.CineCamera == null)
				{
					this.CineCamera = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BP_CineCamera_C>(this.CineCamera), "<CineCamera>k__BackingField"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04027390 RID: 160656
		private CameraModelInstance CameraModelInstanceInternal;
	}
}
