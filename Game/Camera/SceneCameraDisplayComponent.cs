using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070B3 RID: 28851
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneCameraDisplayComponent : EntityComponent
	{
		// Token: 0x1700A5D2 RID: 42450
		// (get) Token: 0x06045EF9 RID: 286457 RVA: 0x012539A8 File Offset: 0x01251BA8
		public BP_CineCamera_C CineCamera
		{
			get
			{
				SceneSubCamera top = this.CameraQueue.Top;
				if (top == null)
				{
					return null;
				}
				return top.Camera;
			}
		}

		// Token: 0x1700A5D3 RID: 42451
		// (get) Token: 0x06045EFA RID: 286458 RVA: 0x012539C0 File Offset: 0x01251BC0
		public SceneSubCamera CurSceneSubCamera
		{
			get
			{
				PriorityQueue<SceneSubCamera> cameraQueue = this.CameraQueue;
				if (cameraQueue == null)
				{
					return null;
				}
				return cameraQueue.Top;
			}
		}

		// Token: 0x1700A5D4 RID: 42452
		// (get) Token: 0x06045EFB RID: 286459 RVA: 0x012539D3 File Offset: 0x01251BD3
		public SceneSubCamera DefaultSceneSubCamera
		{
			get
			{
				return this.DefaultCamera;
			}
		}

		// Token: 0x06045EFC RID: 286460 RVA: 0x012539DB File Offset: 0x01251BDB
		protected override bool OnCreate(IEntityArgs args = null)
		{
			this.CameraModelInstanceInternal = ((args != null) ? args.GetP1<CameraModelInstance>() : null);
			return base.OnCreate(args);
		}

		// Token: 0x06045EFD RID: 286461 RVA: 0x012539F8 File Offset: 0x01251BF8
		protected override bool OnInit()
		{
			Comparison<SceneSubCamera> compare;
			if ((compare = SceneCameraDisplayComponent.<>O.<0>__Compare) == null)
			{
				compare = (SceneCameraDisplayComponent.<>O.<0>__Compare = new Comparison<SceneSubCamera>(SceneSubCamera.Compare));
			}
			this.CameraQueue = new PriorityQueue<SceneSubCamera>(compare);
			this.RemoveCameraList = new List<SceneSubCamera>();
			this.DefaultCamera = new SceneSubCamera();
			this.DefaultCamera.Camera = ControllerBase<CameraController>.Instance.SpawnCineCamera();
			this.DefaultCamera.Type = ESceneSubCameraType.Default;
			this.CameraQueue.Push(this.DefaultCamera);
			this.DefaultCineCameraInternal = this.DefaultCamera.Camera;
			this.SelfCenteredTimeDilation = 1f;
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.ClearWorld, new Action(this.OnClearWorld));
			Singleton<EventSystem>.Instance.Add<ESelfCenteredMode, float>(EEventName.OnSwitchSelfCenteredMode, new Action<ESelfCenteredMode, float>(this.OnSwitchSelfCenteredMode));
			this.AddEvents();
			return this.DefaultCineCameraInternal != null;
		}

		// Token: 0x06045EFE RID: 286462 RVA: 0x01253AF2 File Offset: 0x01251CF2
		private void AddEvents()
		{
			if (!Singleton<EventSystem>.Instance.Has<ECustomCameraMode, ECustomCameraMode?, string>(EEventName.CameraModeChanged, new Action<ECustomCameraMode, ECustomCameraMode?, string>(this.OnModeChanged)))
			{
				Singleton<EventSystem>.Instance.Add<ECustomCameraMode, ECustomCameraMode?, string>(EEventName.CameraModeChanged, new Action<ECustomCameraMode, ECustomCameraMode?, string>(this.OnModeChanged));
			}
		}

		// Token: 0x06045EFF RID: 286463 RVA: 0x01253B2D File Offset: 0x01251D2D
		private void RemoveEvents()
		{
			if (Singleton<EventSystem>.Instance.Has<ECustomCameraMode, ECustomCameraMode?, string>(EEventName.CameraModeChanged, new Action<ECustomCameraMode, ECustomCameraMode?, string>(this.OnModeChanged)))
			{
				Singleton<EventSystem>.Instance.Remove<ECustomCameraMode, ECustomCameraMode?, string>(EEventName.CameraModeChanged, new Action<ECustomCameraMode, ECustomCameraMode?, string>(this.OnModeChanged));
			}
		}

		// Token: 0x06045F00 RID: 286464 RVA: 0x01253B68 File Offset: 0x01251D68
		[NullableContext(1)]
		protected void OnModeChanged(ECustomCameraMode newMode, ECustomCameraMode? oldMode, string cameraName)
		{
			CameraModelInstance cameraModelInstanceInternal = this.CameraModelInstanceInternal;
			if (cameraName != ((cameraModelInstanceInternal != null) ? cameraModelInstanceInternal.CameraName : null))
			{
				return;
			}
			if (newMode == ECustomCameraMode.Scene && this.IsIdle())
			{
				Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.JYS, "SceneCameraDisplayComponent退出Scene相机", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Scene, 1f, EViewTargetBlendFunction.VTBlend_Linear, 0f, delegate
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Shadow.EnableCSMStable 1", null);
				}, this.CameraModelInstanceInternal.CameraName, null);
				this.ClearRemovedSceneCamera();
				return;
			}
			ECustomCameraMode? ecustomCameraMode = oldMode;
			ECustomCameraMode ecustomCameraMode2 = ECustomCameraMode.Scene;
			if (ecustomCameraMode.GetValueOrDefault() == ecustomCameraMode2 & ecustomCameraMode != null)
			{
				ecustomCameraMode = oldMode;
				if (!(newMode == ecustomCameraMode.GetValueOrDefault() & ecustomCameraMode != null))
				{
					this.ClearRemovedSceneCamera();
					return;
				}
			}
		}

		// Token: 0x06045F01 RID: 286465 RVA: 0x01253C38 File Offset: 0x01251E38
		protected void OnWorldDone()
		{
			this.DefaultCamera.Camera = ControllerBase<CameraController>.Instance.SpawnCineCamera();
			this.DefaultCineCameraInternal = this.DefaultCamera.Camera;
			ECustomCameraMode? cameraMode = this.CameraModelInstanceInternal.CameraMode;
			ECustomCameraMode ecustomCameraMode = ECustomCameraMode.Scene;
			if (cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null)
			{
				ControllerBase<CameraController>.Instance.SetViewTarget(this.DefaultCineCameraInternal, "SceneCamera.OnWorldDone", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, new bool?(false), new bool?(false), this.CameraModelInstanceInternal.CameraName, null, null);
			}
		}

		// Token: 0x06045F02 RID: 286466 RVA: 0x01253CC8 File Offset: 0x01251EC8
		protected void OnClearWorld()
		{
			if (this.DefaultCamera != null)
			{
				Singleton<ActorSystem>.Instance.Put("SceneCameraDisplayComponent.OnClearWorld", this.DefaultCineCameraInternal, null);
				this.DefaultCamera.Camera = null;
				this.DefaultCineCameraInternal = null;
			}
			this.UiInActiveCount = 0;
			this.ClearRemovedSceneCamera();
		}

		// Token: 0x06045F03 RID: 286467 RVA: 0x01253D14 File Offset: 0x01251F14
		protected override bool OnClear()
		{
			if (this.DefaultCineCameraInternal != null)
			{
				Singleton<ActorSystem>.Instance.Put("SceneCameraDisplayComponent.OnClear", this.DefaultCineCameraInternal, null);
				this.DefaultCineCameraInternal = null;
			}
			this.RemoveEvents();
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.ClearWorld, new Action(this.OnClearWorld));
			Singleton<EventSystem>.Instance.Remove<ESelfCenteredMode, float>(EEventName.OnSwitchSelfCenteredMode, new Action<ESelfCenteredMode, float>(this.OnSwitchSelfCenteredMode));
			this.CameraModelInstanceInternal = null;
			return true;
		}

		// Token: 0x06045F04 RID: 286468 RVA: 0x01253DA9 File Offset: 0x01251FA9
		protected override void OnChangeTimeDilation(float timeDilation)
		{
			BP_CineCamera_C defaultCineCameraInternal = this.DefaultCineCameraInternal;
			if (defaultCineCameraInternal != null && defaultCineCameraInternal.IsValid())
			{
				this.DefaultCineCameraInternal.CustomTimeDilation = timeDilation;
			}
		}

		// Token: 0x06045F05 RID: 286469 RVA: 0x01253DCC File Offset: 0x01251FCC
		public SceneSubCamera GetUnBoundSceneCamera(ESceneSubCameraType type)
		{
			if (this.CameraQueue.Empty)
			{
				return null;
			}
			if (!this.DefaultCamera.IsBinding)
			{
				this.RestDefaultSubSceneCamera();
				this.DefaultCamera.Type = type;
				this.DefaultCamera.IsBinding = true;
				this.CameraQueue.Update(this.DefaultCamera);
				return this.DefaultCamera;
			}
			SceneSubCamera sceneSubCamera = new SceneSubCamera();
			sceneSubCamera.Camera = ControllerBase<CameraController>.Instance.SpawnCineCamera();
			sceneSubCamera.Type = type;
			this.CameraQueue.Push(sceneSubCamera);
			return sceneSubCamera;
		}

		// Token: 0x06045F06 RID: 286470 RVA: 0x01253E58 File Offset: 0x01252058
		public void RemoveBoundSceneCamera(SceneSubCamera camera)
		{
			if (this.CameraQueue.Empty || camera == null)
			{
				return;
			}
			camera.IsBinding = false;
			if (this.DefaultCamera == camera)
			{
				this.RestDefaultSubSceneCamera();
				this.CameraQueue.Update(this.DefaultCamera);
				return;
			}
			this.CameraQueue.Remove(camera);
			this.RemoveCameraList.Add(camera);
			if (this.IsIdle())
			{
				this.DefaultCamera.CopyData(camera);
			}
		}

		// Token: 0x06045F07 RID: 286471 RVA: 0x01253ECC File Offset: 0x012520CC
		public bool IsIdle()
		{
			return !this.CameraQueue.Empty && this.CameraQueue.Top == this.DefaultCamera && !this.DefaultCamera.IsBinding;
		}

		// Token: 0x06045F08 RID: 286472 RVA: 0x01253F00 File Offset: 0x01252100
		public void ClearRemovedSceneCamera()
		{
			foreach (SceneSubCamera sceneSubCamera in this.RemoveCameraList)
			{
				sceneSubCamera.Clear();
			}
			this.RemoveCameraList.Clear();
		}

		// Token: 0x06045F09 RID: 286473 RVA: 0x01253F5C File Offset: 0x0125215C
		public void UpdateViewTarget(float? fadeIn = null, Action callback = null)
		{
			if (fadeIn != null)
			{
				ControllerBase<CameraController>.Instance.SetViewTarget(this.CurSceneSubCamera.Camera, "SceneCamera.UpdateViewTarget", fadeIn.Value, EViewTargetBlendFunction.VTBlend_Linear, 0f, new bool?(true), new bool?(true), this.CameraModelInstanceInternal.CameraName, callback, null);
				return;
			}
			ControllerBase<CameraController>.Instance.SetViewTarget(this.CurSceneSubCamera.Camera, "SceneCamera.UpdateViewTarget2", this.CurSceneSubCamera.FadeIn, this.CurSceneSubCamera.FadeInFunc, this.CurSceneSubCamera.FadeInExp, new bool?(true), new bool?(true), this.CameraModelInstanceInternal.CameraName, callback, this.CurSceneSubCamera.FadeInCurve);
		}

		// Token: 0x06045F0A RID: 286474 RVA: 0x01254011 File Offset: 0x01252211
		public void EnableExtraCameraAction()
		{
			this.EnablePerspectiveToOrthographicView(null);
		}

		// Token: 0x06045F0B RID: 286475 RVA: 0x0125401A File Offset: 0x0125221A
		public void EnablePerspectiveToOrthographicView(Action callback = null)
		{
			if (this.CurSceneSubCamera.IsCameraAberrationEnable && this.CurSceneSubCamera.CameraAberrationView != null)
			{
				this.CurSceneSubCamera.CameraAberrationView.EnablePerspectiveToOrthographicView(this.CurSceneSubCamera.Camera, callback);
			}
		}

		// Token: 0x06045F0C RID: 286476 RVA: 0x01254054 File Offset: 0x01252254
		public void EnableOrthographicToPerspectiveView(Action callback = null)
		{
			if (this.CurSceneSubCamera.IsCameraAberrationEnable && this.CurSceneSubCamera.CameraAberrationView != null)
			{
				this.CurSceneSubCamera.IsCameraAberrationEnable = false;
				this.CurSceneSubCamera.CameraAberrationView.EnableOrthographicToPerspectiveToView(this.CurSceneSubCamera.Camera, callback);
				return;
			}
			if (callback != null)
			{
				callback();
			}
		}

		// Token: 0x06045F0D RID: 286477 RVA: 0x012540B0 File Offset: 0x012522B0
		protected override void OnAfterTick(float deltaTime)
		{
			float second = deltaTime * 0.001f * this.SelfCenteredTimeDilation;
			SceneSubCamera curSceneSubCamera = this.CurSceneSubCamera;
			if (((curSceneSubCamera != null) ? curSceneSubCamera.CameraAberrationView : null) != null)
			{
				this.CurSceneSubCamera.CameraAberrationView.Update(second);
			}
		}

		// Token: 0x06045F0E RID: 286478 RVA: 0x012540F4 File Offset: 0x012522F4
		private void RestDefaultSubSceneCamera()
		{
			this.DefaultCamera.IsBinding = false;
			this.DefaultCamera.Camera.CameraComponent.bConstrainAspectRatio = false;
			this.DefaultCamera.Type = ESceneSubCameraType.Default;
			this.DefaultCamera.IsKeepUi = true;
			this.DefaultCamera.CanAcceptInput = false;
			this.DefaultCamera.FixInputData = null;
			this.DefaultCamera.FollowConfig = null;
		}

		// Token: 0x06045F0F RID: 286479 RVA: 0x01254160 File Offset: 0x01252360
		public void SetUiActive(bool isActive)
		{
			if (isActive)
			{
				if (this.UiInActiveCount > 0)
				{
					this.UiInActiveCount--;
				}
			}
			else
			{
				this.UiInActiveCount++;
			}
			if (this.UiInActiveCount != 0 && isActive)
			{
				return;
			}
			if (this.UiInActiveCount > 1 && !isActive)
			{
				return;
			}
			Singleton<UiLayer>.Instance.SetLayerActive(ELayerType.Pop, isActive);
			Singleton<UiLayer>.Instance.SetLayerActive(ELayerType.Float, isActive);
			if (isActive)
			{
				ModelBase<BattleUiModel>.Instance.ChildViewData.ShowBattleView(EBattleUiVisibleReason.CameraSeq, 0);
				ModelBase<InputDistributeModel>.Instance.RemoveInputDistributeTag("BlockAllInputTag", false);
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
				Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("SceneCameraDisplayComponent.SetUiActive");
				return;
			}
			ModelBase<BattleUiModel>.Instance.ChildViewData.HideBattleView(EBattleUiVisibleReason.CameraSeq, null, 0);
			ModelBase<InputDistributeModel>.Instance.SetInputDistributeTag("BlockAllInputTag");
			Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("SceneCameraDisplayComponent.SetUiActive");
		}

		// Token: 0x06045F10 RID: 286480 RVA: 0x0125423D File Offset: 0x0125243D
		private void OnSwitchSelfCenteredMode(ESelfCenteredMode selfCenterMode, float globalTimeDilation)
		{
			TimerSystem.Instance.Next(delegate(float _)
			{
				this.SelfCenteredTimeDilation = ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation;
			}, null, null);
		}

		// Token: 0x06045F11 RID: 286481 RVA: 0x01254258 File Offset: 0x01252458
		protected override bool OnEnd()
		{
			this.SelfCenteredTimeDilation = 1f;
			return true;
		}

		// Token: 0x06045F12 RID: 286482 RVA: 0x01254268 File Offset: 0x01252468
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneCameraDisplayComponent sceneCameraDisplayComponent = (SceneCameraDisplayComponent)componentTemplate;
			if (base.CanResetComponentProperty("CameraModelInstanceInternal"))
			{
				if (sceneCameraDisplayComponent.CameraModelInstanceInternal == null)
				{
					this.CameraModelInstanceInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CameraModelInstance>(this.CameraModelInstanceInternal), "CameraModelInstanceInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DefaultCineCameraInternal"))
			{
				if (sceneCameraDisplayComponent.DefaultCineCameraInternal == null)
				{
					this.DefaultCineCameraInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BP_CineCamera_C>(this.DefaultCineCameraInternal), "DefaultCineCameraInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CameraQueue"))
			{
				if (sceneCameraDisplayComponent.CameraQueue == null)
				{
					this.CameraQueue = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PriorityQueue<SceneSubCamera>>(this.CameraQueue), "CameraQueue"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RemoveCameraList"))
			{
				if (sceneCameraDisplayComponent.RemoveCameraList == null)
				{
					this.RemoveCameraList = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<SceneSubCamera>>(this.RemoveCameraList), "RemoveCameraList"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DefaultCamera"))
			{
				if (sceneCameraDisplayComponent.DefaultCamera == null)
				{
					this.DefaultCamera = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneSubCamera>(this.DefaultCamera), "DefaultCamera"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("UiInActiveCount"))
			{
				this.UiInActiveCount = sceneCameraDisplayComponent.UiInActiveCount;
			}
			if (base.CanResetComponentProperty("SelfCenteredTimeDilation"))
			{
				this.SelfCenteredTimeDilation = sceneCameraDisplayComponent.SelfCenteredTimeDilation;
			}
			return true;
		}

		// Token: 0x040272EA RID: 160490
		private CameraModelInstance CameraModelInstanceInternal;

		// Token: 0x040272EB RID: 160491
		private BP_CineCamera_C DefaultCineCameraInternal;

		// Token: 0x040272EC RID: 160492
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private PriorityQueue<SceneSubCamera> CameraQueue;

		// Token: 0x040272ED RID: 160493
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<SceneSubCamera> RemoveCameraList;

		// Token: 0x040272EE RID: 160494
		private SceneSubCamera DefaultCamera;

		// Token: 0x040272EF RID: 160495
		private int UiInActiveCount;

		// Token: 0x040272F0 RID: 160496
		private float SelfCenteredTimeDilation = 1f;

		// Token: 0x0200CCBF RID: 52415
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403ECB1 RID: 257201
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Comparison<SceneSubCamera> <0>__Compare;
		}
	}
}
