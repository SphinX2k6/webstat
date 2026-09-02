using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070AB RID: 28843
	[NullableContext(1)]
	[Nullable(0)]
	public class OrbitalCameraPlayerComponent : EntityComponent
	{
		// Token: 0x06045ECB RID: 286411 RVA: 0x012525EF File Offset: 0x012507EF
		[NullableContext(2)]
		protected override bool OnCreate(IEntityArgs args = null)
		{
			this.CameraModelInstanceInternal = ((args != null) ? args.GetP1<CameraModelInstance>() : null);
			return base.OnCreate(args);
		}

		// Token: 0x06045ECC RID: 286412 RVA: 0x0125260C File Offset: 0x0125080C
		protected override bool OnStart()
		{
			this.DisplayComponent = base.Entity.GetComponent<SequenceCameraDisplayComponent>();
			this.DisableKey = new int?(base.Disable("[OrbitalCameraPlayerComponent.OnStart]"));
			Singleton<EventSystem>.Instance.Add<ECustomCameraMode, ECustomCameraMode?, string>(EEventName.CameraModeChanged, new Action<ECustomCameraMode, ECustomCameraMode?, string>(this.OnModeChanged));
			return true;
		}

		// Token: 0x06045ECD RID: 286413 RVA: 0x01252660 File Offset: 0x01250860
		protected override bool OnEnd()
		{
			this.CameraSequence = null;
			if (this.CameraSequenceActor != null)
			{
				ALevelSequenceActor tmp = this.CameraSequenceActor;
				TimerSystem.Instance.Next(delegate(float _)
				{
					Singleton<ActorSystem>.Instance.Put("OrbitalCameraPlayerComponent.OnEnd", tmp, null);
				}, null, null);
				this.CameraSequenceActor = null;
				this.CameraSequencePlayer = null;
			}
			Singleton<EventSystem>.Instance.Remove<ECustomCameraMode, ECustomCameraMode?, string>(EEventName.CameraModeChanged, new Action<ECustomCameraMode, ECustomCameraMode?, string>(this.OnModeChanged));
			return true;
		}

		// Token: 0x06045ECE RID: 286414 RVA: 0x012526D4 File Offset: 0x012508D4
		protected void OnModeChanged(ECustomCameraMode newMode, ECustomCameraMode? oldMode, string cameraName)
		{
			CameraModelInstance cameraModelInstanceInternal = this.CameraModelInstanceInternal;
			if (cameraName != ((cameraModelInstanceInternal != null) ? cameraModelInstanceInternal.CameraName : null))
			{
				return;
			}
			if (newMode == ECustomCameraMode.Orbital)
			{
				if (this.DisableKey != null)
				{
					base.Enable(new int?(this.DisableKey.Value), "[OrbitalCameraPlayerComponent.OnModeChanged] newMode == Orbital");
					this.DisableKey = null;
					return;
				}
			}
			else
			{
				ECustomCameraMode? ecustomCameraMode = oldMode;
				ECustomCameraMode ecustomCameraMode2 = ECustomCameraMode.Orbital;
				if (ecustomCameraMode.GetValueOrDefault() == ecustomCameraMode2 & ecustomCameraMode != null)
				{
					int value = this.DisableKey.GetValueOrDefault();
					if (this.DisableKey == null)
					{
						value = base.Disable("[OrbitalCameraPlayerComponent.OnModeChanged] oldMode == Orbital");
						this.DisableKey = new int?(value);
					}
				}
			}
		}

		// Token: 0x06045ECF RID: 286415 RVA: 0x01252780 File Offset: 0x01250980
		protected override void OnTick(float delta)
		{
			if (this.CameraSequenceActor != null)
			{
				float process = this.GetProcess();
				this.GetCurrentFrame(process);
				this.CameraSequencePlayer.PlayToFrame(this.CurrentFrame);
				return;
			}
			if (this.DisableKey != null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LCZ, "OrbitalCamera Impossible Tick!", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.DisableKey = new int?(base.Disable("[OrbitalCameraPlayerComponent.OnTick] CameraSequenceActor无效"));
		}

		// Token: 0x06045ED0 RID: 286416 RVA: 0x012527F4 File Offset: 0x012509F4
		public void PlayCameraOrbitalPath(string levelSequencePath, Vector startLocation, Vector endLocation, float blendInTime, float blendOutTime)
		{
			Singleton<Log>.Instance.Info(ELogModule.Test, ELogAuthor.LCZ, "Orbital Play", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.ResourcePath = levelSequencePath;
			this.StartLocation.FromUeVector(startLocation);
			this.EndLocation.FromUeVector(endLocation);
			this.BlendInTime = blendInTime;
			this.BlendOutTime = blendOutTime;
			this.EndLocation.Subtraction(this.StartLocation, this.Direct);
			this.Distance = (float)this.Direct.Size();
			this.Direct.DivisionEqual((double)this.Distance);
			this.SetupCameraSpline();
		}

		// Token: 0x06045ED1 RID: 286417 RVA: 0x01252890 File Offset: 0x01250A90
		public void PlayCameraOrbital(ULevelSequence levelSequence, FVector startLocation, FVector endLocation, float blendInTime, float blendOutTime)
		{
			Singleton<Log>.Instance.Info(ELogModule.Test, ELogAuthor.LCZ, "Orbital Play", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.CameraSequence = levelSequence;
			this.StartLocation.FromUeVector(startLocation);
			this.EndLocation.FromUeVector(endLocation);
			this.BlendInTime = blendInTime;
			this.BlendOutTime = blendOutTime;
			this.EndLocation.Subtraction(this.StartLocation, this.Direct);
			this.Distance = (float)this.Direct.Size();
			this.Direct.DivisionEqual((double)this.Distance);
			this.PlayInternal();
		}

		// Token: 0x06045ED2 RID: 286418 RVA: 0x0125292C File Offset: 0x01250B2C
		public void StopCameraOrbital()
		{
			Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LCZ, "Orbital Stop", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (string.IsNullOrEmpty(this.ResourcePath) && this.CameraSequence == null)
			{
				return;
			}
			this.CameraModelInstanceInternal.FightCamera.LogicComponent.SetRotation(CameraUtility.GetCameraDefaultFocusUeRotator());
			ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Orbital, this.BlendOutTime, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, this.CameraModelInstanceInternal.CameraName, null);
			this.CameraSequence = null;
			if (this.CameraSequenceActor != null)
			{
				this.CameraSequencePlayer.Stop();
				ALevelSequenceActor tmp = this.CameraSequenceActor;
				TimerSystem.Instance.Next(delegate(float _)
				{
					Singleton<ActorSystem>.Instance.Put("OrbitalCameraPlayerComponent.StopCameraOrbital", tmp, null);
				}, null, null);
				this.CameraSequenceActor = null;
				this.CameraSequencePlayer = null;
			}
			else
			{
				Singleton<Log>.Instance.Warn(ELogModule.Camera, ELogAuthor.LCZ, "Orbital: No CameraSequenceActor", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.ResourcePath = null;
		}

		// Token: 0x06045ED3 RID: 286419 RVA: 0x01252A20 File Offset: 0x01250C20
		private void SetupCameraSpline()
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(this.ResourcePath, new Action<ULevelSequence, string>(this.LoadComplete), 100, "js_undefined");
		}

		// Token: 0x06045ED4 RID: 286420 RVA: 0x01252A48 File Offset: 0x01250C48
		private void LoadComplete([Nullable(2)] ULevelSequence levelSequence, string path)
		{
			Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LCZ, "Orbital LoadComplete", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (path != this.ResourcePath)
			{
				return;
			}
			this.CameraSequence = levelSequence;
			this.PlayInternal();
		}

		// Token: 0x06045ED5 RID: 286421 RVA: 0x01252A8C File Offset: 0x01250C8C
		private void PlayInternal()
		{
			FMovieSceneSequencePlaybackSettings fmovieSceneSequencePlaybackSettings = new FMovieSceneSequencePlaybackSettings();
			fmovieSceneSequencePlaybackSettings.bDisableMovementInput = false;
			fmovieSceneSequencePlaybackSettings.bDisableLookAtInput = false;
			this.CameraSequenceActor = (Singleton<ActorSystem>.Instance.Get(ALevelSequenceActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, false) as ALevelSequenceActor);
			this.CameraSequenceActor.PlaybackSettings = fmovieSceneSequencePlaybackSettings;
			this.CameraSequenceActor.SetSequence(this.CameraSequence);
			this.CameraSequenceActor.bOverrideInstanceData = true;
			this.CameraSequencePlayer = this.CameraSequenceActor.SequencePlayer;
			this.CameraSequencePlayer.Play();
			this.CameraSequencePlayer.SetPlayRate(0f);
			this.CameraSequencePlayer.Pause();
			this.BindingActors.Add(this.DisplayComponent.CineCamera);
			this.CameraSequenceActor.SetBindingByTag(OrbitalCameraPlayerComponent.SequenceCamera, this.BindingActors, false, false);
			this.BindingActors.Empty(true);
			this.FrameLength = (float)this.CameraSequencePlayer.GetEndTime().Time.FrameNumber.Value;
			ControllerBase<CameraController>.Instance.EnterCameraMode(ECustomCameraMode.Orbital, this.BlendInTime, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, false, this.CameraModelInstanceInternal.CameraName, null);
		}

		// Token: 0x06045ED6 RID: 286422 RVA: 0x01252BB4 File Offset: 0x01250DB4
		private float GetProcess()
		{
			if (Global.BaseCharacter == null || (double)this.Distance < 1E-08)
			{
				return 0f;
			}
			Global.BaseCharacter.CharacterActorComponent.ActorLocationProxy.Subtraction(this.StartLocation, this.TmpVector);
			double currentValue = this.TmpVector.DotProduct(this.Direct) / (double)this.Distance;
			return (float)Singleton<MathUtils>.Instance.Clamp(currentValue, 0.0, 1.0);
		}

		// Token: 0x06045ED7 RID: 286423 RVA: 0x01252C3C File Offset: 0x01250E3C
		private void GetCurrentFrame(float process)
		{
			float num = process * this.FrameLength;
			float num2 = (float)Math.Floor((double)num);
			float subFrame = num - num2;
			this.CurrentFrame.FrameNumber = new FFrameNumber((int)num2);
			this.CurrentFrame.SubFrame = subFrame;
		}

		// Token: 0x06045ED8 RID: 286424 RVA: 0x01252C7B File Offset: 0x01250E7B
		protected override bool OnClear()
		{
			this.CameraModelInstanceInternal = null;
			return true;
		}

		// Token: 0x06045ED9 RID: 286425 RVA: 0x01252C88 File Offset: 0x01250E88
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			OrbitalCameraPlayerComponent orbitalCameraPlayerComponent = (OrbitalCameraPlayerComponent)componentTemplate;
			if (base.CanResetComponentProperty("CameraModelInstanceInternal"))
			{
				if (orbitalCameraPlayerComponent.CameraModelInstanceInternal == null)
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
				if (orbitalCameraPlayerComponent.DisplayComponent == null)
				{
					this.DisplayComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SequenceCameraDisplayComponent>(this.DisplayComponent), "DisplayComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CameraSequence"))
			{
				if (orbitalCameraPlayerComponent.CameraSequence == null)
				{
					this.CameraSequence = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ULevelSequence>(this.CameraSequence), "CameraSequence"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CameraSequenceActor"))
			{
				if (orbitalCameraPlayerComponent.CameraSequenceActor == null)
				{
					this.CameraSequenceActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ALevelSequenceActor>(this.CameraSequenceActor), "CameraSequenceActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CameraSequencePlayer"))
			{
				if (orbitalCameraPlayerComponent.CameraSequencePlayer == null)
				{
					this.CameraSequencePlayer = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ULevelSequencePlayer>(this.CameraSequencePlayer), "CameraSequencePlayer"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ResourcePath"))
			{
				this.ResourcePath = orbitalCameraPlayerComponent.ResourcePath;
			}
			if (base.CanResetComponentProperty("StartLocation") && orbitalCameraPlayerComponent.StartLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.StartLocation), "StartLocation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("EndLocation") && orbitalCameraPlayerComponent.EndLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.EndLocation), "EndLocation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("Direct") && orbitalCameraPlayerComponent.Direct != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.Direct), "Direct"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("Distance"))
			{
				this.Distance = orbitalCameraPlayerComponent.Distance;
			}
			if (base.CanResetComponentProperty("BlendInTime"))
			{
				this.BlendInTime = orbitalCameraPlayerComponent.BlendInTime;
			}
			if (base.CanResetComponentProperty("BlendOutTime"))
			{
				this.BlendOutTime = orbitalCameraPlayerComponent.BlendOutTime;
			}
			if (base.CanResetComponentProperty("FrameLength"))
			{
				this.FrameLength = orbitalCameraPlayerComponent.FrameLength;
			}
			if (base.CanResetComponentProperty("BindingActors") && orbitalCameraPlayerComponent.BindingActors != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.BindingActors), "BindingActors"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CurrentFrame") && orbitalCameraPlayerComponent.CurrentFrame != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<FFrameTime>(this.CurrentFrame), "CurrentFrame"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TmpVector") && orbitalCameraPlayerComponent.TmpVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpVector), "TmpVector"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("DisableKey"))
			{
				this.DisableKey = orbitalCameraPlayerComponent.DisableKey;
			}
			return true;
		}

		// Token: 0x0402729D RID: 160413
		[Nullable(2)]
		private CameraModelInstance CameraModelInstanceInternal;

		// Token: 0x0402729E RID: 160414
		private static readonly FName SequenceCamera = new FName("SequenceCamera");

		// Token: 0x0402729F RID: 160415
		[Nullable(2)]
		private SequenceCameraDisplayComponent DisplayComponent;

		// Token: 0x040272A0 RID: 160416
		[Nullable(2)]
		private ULevelSequence CameraSequence;

		// Token: 0x040272A1 RID: 160417
		[Nullable(2)]
		private ALevelSequenceActor CameraSequenceActor;

		// Token: 0x040272A2 RID: 160418
		[Nullable(2)]
		private ULevelSequencePlayer CameraSequencePlayer;

		// Token: 0x040272A3 RID: 160419
		[Nullable(2)]
		private string ResourcePath;

		// Token: 0x040272A4 RID: 160420
		private readonly Vector StartLocation = Vector.Create();

		// Token: 0x040272A5 RID: 160421
		private readonly Vector EndLocation = Vector.Create();

		// Token: 0x040272A6 RID: 160422
		private readonly Vector Direct = Vector.Create();

		// Token: 0x040272A7 RID: 160423
		private float Distance;

		// Token: 0x040272A8 RID: 160424
		private float BlendInTime;

		// Token: 0x040272A9 RID: 160425
		private float BlendOutTime;

		// Token: 0x040272AA RID: 160426
		private float FrameLength;

		// Token: 0x040272AB RID: 160427
		private readonly TArray<AActor> BindingActors = new TArray<AActor>();

		// Token: 0x040272AC RID: 160428
		private readonly FFrameTime CurrentFrame = new FFrameTime();

		// Token: 0x040272AD RID: 160429
		private readonly Vector TmpVector = Vector.Create();

		// Token: 0x040272AE RID: 160430
		private int? DisableKey;
	}
}
