using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera.SceneCameraRotator;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070B4 RID: 28852
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneCameraInputComponent : EntityComponent
	{
		// Token: 0x1700A5D5 RID: 42453
		// (get) Token: 0x06045F15 RID: 286485 RVA: 0x012543F7 File Offset: 0x012525F7
		public CameraModelInstance CameraModel
		{
			get
			{
				return this.CameraModelInstanceInternal;
			}
		}

		// Token: 0x06045F16 RID: 286486 RVA: 0x012543FF File Offset: 0x012525FF
		protected override bool OnCreate(IEntityArgs args = null)
		{
			this.CameraModelInstanceInternal = ((args != null) ? args.GetP1<CameraModelInstance>() : null);
			return base.OnCreate(args);
		}

		// Token: 0x06045F17 RID: 286487 RVA: 0x0125441A File Offset: 0x0125261A
		protected override bool OnStart()
		{
			this.DisplayComponent = base.Entity.GetComponent<SceneCameraDisplayComponent>();
			return this.DisplayComponent != null && this.DisplayComponent.Valid;
		}

		// Token: 0x06045F18 RID: 286488 RVA: 0x01254442 File Offset: 0x01252642
		protected override bool OnEnd()
		{
			this.ClearAllRotator();
			this.LastBuiltSubCamera = null;
			this.LastBuiltFixInputData = null;
			this.LastBuiltFollowConfig = null;
			this.DisplayComponent = null;
			return true;
		}

		// Token: 0x06045F19 RID: 286489 RVA: 0x01254468 File Offset: 0x01252668
		protected override void OnTick(float deltaTime)
		{
			if (this.DisplayComponent == null)
			{
				return;
			}
			SceneSubCamera curSceneSubCamera = this.DisplayComponent.CurSceneSubCamera;
			FightCameraLogicComponent fightLogic = this.GetFightLogic();
			if (this.ShouldRebuildConfig(curSceneSubCamera))
			{
				this.RebuildConfigRotator(curSceneSubCamera);
			}
			if (curSceneSubCamera == null || fightLogic == null)
			{
				return;
			}
			SceneCameraRotatorBase activeRotator = this.GetActiveRotator();
			if (activeRotator == null)
			{
				return;
			}
			activeRotator.OnTick(curSceneSubCamera, fightLogic, deltaTime);
		}

		// Token: 0x06045F1A RID: 286490 RVA: 0x012544BC File Offset: 0x012526BC
		[NullableContext(1)]
		public void SetLookAtTarget(Vector targetPosition, float blendInMs)
		{
			SceneCameraDisplayComponent displayComponent = this.DisplayComponent;
			SceneSubCamera sceneSubCamera = (displayComponent != null) ? displayComponent.CurSceneSubCamera : null;
			FightCameraLogicComponent fightLogic = this.GetFightLogic();
			if (sceneSubCamera == null || fightLogic == null)
			{
				return;
			}
			if (this.ShouldRebuildConfig(sceneSubCamera))
			{
				this.RebuildConfigRotator(sceneSubCamera);
			}
			SceneCameraBlendToTargetRotator sceneCameraBlendToTargetRotator = new SceneCameraBlendToTargetRotator();
			if (!sceneCameraBlendToTargetRotator.InitFromLookAtTarget(sceneSubCamera, fightLogic, targetPosition, blendInMs))
			{
				return;
			}
			this.SetOverrideRotator(sceneCameraBlendToTargetRotator);
		}

		// Token: 0x06045F1B RID: 286491 RVA: 0x01254514 File Offset: 0x01252714
		private SceneCameraRotatorBase GetActiveRotator()
		{
			if (this.OverrideRotator != null)
			{
				if (this.OverrideRotator.IsValid())
				{
					return this.OverrideRotator;
				}
				this.OverrideRotator.OnDeactivate();
				this.OverrideRotator = null;
			}
			if (this.ConfigRotator != null)
			{
				if (this.ConfigRotator.IsValid())
				{
					return this.ConfigRotator;
				}
				this.ConfigRotator.OnDeactivate();
				this.ConfigRotator = null;
			}
			return null;
		}

		// Token: 0x06045F1C RID: 286492 RVA: 0x0125457E File Offset: 0x0125277E
		private bool ShouldRebuildConfig(SceneSubCamera subCamera)
		{
			return subCamera != this.LastBuiltSubCamera || ((subCamera != null) ? subCamera.FixInputData : null) != this.LastBuiltFixInputData || ((subCamera != null) ? subCamera.FollowConfig : null) != this.LastBuiltFollowConfig;
		}

		// Token: 0x06045F1D RID: 286493 RVA: 0x012545B8 File Offset: 0x012527B8
		private void RebuildConfigRotator(SceneSubCamera subCamera)
		{
			this.ClearAllRotator();
			if (subCamera != null)
			{
				if (subCamera.CanAcceptInput && subCamera.FixInputData != null)
				{
					this.ConfigRotator = new SceneCameraInputRotator(subCamera.FixInputData);
					this.ConfigRotator.OnActivate();
				}
				else if (subCamera.FollowConfig != null)
				{
					this.ConfigRotator = new SceneCameraFollowTargetRotator(subCamera.FollowConfig);
					this.ConfigRotator.OnActivate();
				}
			}
			this.LastBuiltSubCamera = subCamera;
			this.LastBuiltFixInputData = ((subCamera != null) ? subCamera.FixInputData : null);
			this.LastBuiltFollowConfig = ((subCamera != null) ? subCamera.FollowConfig : null);
		}

		// Token: 0x06045F1E RID: 286494 RVA: 0x0125464B File Offset: 0x0125284B
		[NullableContext(1)]
		private void SetOverrideRotator(SceneCameraRotatorBase rotator)
		{
			if (this.OverrideRotator != null)
			{
				this.OverrideRotator.OnDeactivate();
			}
			this.OverrideRotator = rotator;
			this.OverrideRotator.OnActivate();
		}

		// Token: 0x06045F1F RID: 286495 RVA: 0x01254672 File Offset: 0x01252872
		private void ClearAllRotator()
		{
			if (this.OverrideRotator != null)
			{
				this.OverrideRotator.OnDeactivate();
				this.OverrideRotator = null;
			}
			if (this.ConfigRotator != null)
			{
				this.ConfigRotator.OnDeactivate();
				this.ConfigRotator = null;
			}
		}

		// Token: 0x06045F20 RID: 286496 RVA: 0x012546A8 File Offset: 0x012528A8
		private FightCameraLogicComponent GetFightLogic()
		{
			CameraModelInstance cameraModel = this.CameraModel;
			if (cameraModel == null)
			{
				return null;
			}
			FightCamera fightCamera = cameraModel.FightCamera;
			if (fightCamera == null)
			{
				return null;
			}
			return fightCamera.LogicComponent;
		}

		// Token: 0x06045F21 RID: 286497 RVA: 0x012546C6 File Offset: 0x012528C6
		protected override bool OnClear()
		{
			this.CameraModelInstanceInternal = null;
			return true;
		}

		// Token: 0x06045F22 RID: 286498 RVA: 0x012546D0 File Offset: 0x012528D0
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneCameraInputComponent sceneCameraInputComponent = (SceneCameraInputComponent)componentTemplate;
			if (base.CanResetComponentProperty("CameraModelInstanceInternal"))
			{
				if (sceneCameraInputComponent.CameraModelInstanceInternal == null)
				{
					this.CameraModelInstanceInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CameraModelInstance>(this.CameraModelInstanceInternal), "CameraModelInstanceInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DisplayComponent"))
			{
				if (sceneCameraInputComponent.DisplayComponent == null)
				{
					this.DisplayComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneCameraDisplayComponent>(this.DisplayComponent), "DisplayComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ConfigRotator"))
			{
				if (sceneCameraInputComponent.ConfigRotator == null)
				{
					this.ConfigRotator = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneCameraRotatorBase>(this.ConfigRotator), "ConfigRotator"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("OverrideRotator"))
			{
				if (sceneCameraInputComponent.OverrideRotator == null)
				{
					this.OverrideRotator = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneCameraRotatorBase>(this.OverrideRotator), "OverrideRotator"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LastBuiltSubCamera"))
			{
				if (sceneCameraInputComponent.LastBuiltSubCamera == null)
				{
					this.LastBuiltSubCamera = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneSubCamera>(this.LastBuiltSubCamera), "LastBuiltSubCamera"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LastBuiltFixInputData"))
			{
				if (sceneCameraInputComponent.LastBuiltFixInputData == null)
				{
					this.LastBuiltFixInputData = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneFixInputData>(this.LastBuiltFixInputData), "LastBuiltFixInputData"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LastBuiltFollowConfig"))
			{
				if (sceneCameraInputComponent.LastBuiltFollowConfig == null)
				{
					this.LastBuiltFollowConfig = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneCameraFollowConfig>(this.LastBuiltFollowConfig), "LastBuiltFollowConfig"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x040272F1 RID: 160497
		private CameraModelInstance CameraModelInstanceInternal;

		// Token: 0x040272F2 RID: 160498
		private SceneCameraDisplayComponent DisplayComponent;

		// Token: 0x040272F3 RID: 160499
		private SceneCameraRotatorBase ConfigRotator;

		// Token: 0x040272F4 RID: 160500
		private SceneCameraRotatorBase OverrideRotator;

		// Token: 0x040272F5 RID: 160501
		private SceneSubCamera LastBuiltSubCamera;

		// Token: 0x040272F6 RID: 160502
		private SceneFixInputData LastBuiltFixInputData;

		// Token: 0x040272F7 RID: 160503
		private SceneCameraFollowConfig LastBuiltFollowConfig;
	}
}
