using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.TimeTrackControl;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.NewWorld.SceneItem.RefCompController;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.StaticScene
{
	// Token: 0x02006ABD RID: 27325
	[NullableContext(1)]
	[Nullable(0)]
	public class SimpleLevelSequenceActor
	{
		// Token: 0x06043909 RID: 276745 RVA: 0x0116B164 File Offset: 0x01169364
		public SimpleLevelSequenceActor(ULevelSequence levelSequence)
		{
			FRotator frotator = new FRotator(0f, 0f, 0f);
			FVectorDouble fvectorDouble = new FVectorDouble(0.0, 0.0, 0.0);
			FVectorDouble fvectorDouble2 = new FVectorDouble(1.0, 1.0, 1.0);
			FVector fvector = fvectorDouble2;
			this.TempTransform = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
			base..ctor();
			this.LevelSequence = levelSequence;
			if (levelSequence.HasBindingTag(SimpleLevelSequenceActorConstants.CAMERA_TAG, true))
			{
				this.HasCameraTrack = true;
			}
			else
			{
				this.HasCameraTrack = false;
			}
			this.GenerateDirector();
		}

		// Token: 0x0604390A RID: 276746 RVA: 0x0116B2D7 File Offset: 0x011694D7
		[NullableContext(2)]
		public void AddOnPauseCallback(Action callback)
		{
			this.OnPauseCallback = callback;
		}

		// Token: 0x0604390B RID: 276747 RVA: 0x0116B2E0 File Offset: 0x011694E0
		public void ClearOnPausedCallback()
		{
			this.OnPauseCallback = null;
		}

		// Token: 0x0604390C RID: 276748 RVA: 0x0116B2E9 File Offset: 0x011694E9
		[NullableContext(2)]
		public void AddOnStopCallback(Action<bool> callback)
		{
			this.OnStopCallback = callback;
		}

		// Token: 0x0604390D RID: 276749 RVA: 0x0116B2F2 File Offset: 0x011694F2
		public void ClearOnStopCallback()
		{
			this.OnStopCallback = null;
		}

		// Token: 0x0604390E RID: 276750 RVA: 0x0116B2FB File Offset: 0x011694FB
		[NullableContext(2)]
		public void AddOnFinishedCallback(Action callback)
		{
			this.OnFinishedCallback = callback;
		}

		// Token: 0x0604390F RID: 276751 RVA: 0x0116B304 File Offset: 0x01169504
		public void ClearOnFinishedCallback()
		{
			this.OnFinishedCallback = null;
		}

		// Token: 0x06043910 RID: 276752 RVA: 0x0116B30D File Offset: 0x0116950D
		public void UpdateSettings(bool? inSettings)
		{
			this.IsKeepUi = inSettings.GetValueOrDefault();
		}

		// Token: 0x06043911 RID: 276753 RVA: 0x0116B31C File Offset: 0x0116951C
		public void SetCanPlayInLoading(bool canPlay)
		{
			this.CanPlayInLoading = canPlay;
		}

		// Token: 0x06043912 RID: 276754 RVA: 0x0116B325 File Offset: 0x01169525
		[NullableContext(2)]
		public UMovieSceneSequencePlayer GetPlayer()
		{
			ALevelSequenceActor director = this.Director;
			if (director == null)
			{
				return null;
			}
			return director.SequencePlayer;
		}

		// Token: 0x06043913 RID: 276755 RVA: 0x0116B338 File Offset: 0x01169538
		public bool IsDirectorValid()
		{
			ALevelSequenceActor director = this.Director;
			return director != null && director.IsValid();
		}

		// Token: 0x06043914 RID: 276756 RVA: 0x0116B34B File Offset: 0x0116954B
		[NullableContext(2)]
		public void SetTransformOriginActor(AActor actor)
		{
			if (this.Director == null)
			{
				return;
			}
			this.Director.bOverrideInstanceData = true;
			if (this.CameraSequenceData != null)
			{
				this.CameraSequenceData.TransformOriginActor = actor;
			}
		}

		// Token: 0x06043915 RID: 276757 RVA: 0x0116B376 File Offset: 0x01169576
		public bool IsPlaying()
		{
			if (this.IsPause)
			{
				return false;
			}
			if (this.ItsWay == EWayType.Default)
			{
				return true;
			}
			UMovieSceneSequencePlayer player = this.GetPlayer();
			return player != null && player.IsPlaying();
		}

		// Token: 0x06043916 RID: 276758 RVA: 0x0116B3A0 File Offset: 0x011695A0
		public bool ForceSwitchSceneCamera(bool isEnter)
		{
			ALevelSequenceActor director = this.Director;
			if (director == null || !director.IsValid())
			{
				Singleton<global::Log>.Instance.Info(ELogModule.SceneGameplay, ELogAuthor.JYS, "时间控制装置启动请求:失败，!this.Director?.IsValid()", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (!this.HasCameraTrack)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.SceneGameplay, ELogAuthor.JYS, "时间控制装置启动请求:失败，!this.HasCameraTrack", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.UiSequence = true;
			if (isEnter)
			{
				this.IsForcedSceneCamera = true;
				this.EnterSceneCamera(delegate
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.TimeTrackControlView, null, delegate(bool result, int _)
					{
						if (!result)
						{
							Singleton<global::Log>.Instance.Info(ELogModule.SceneGameplay, ELogAuthor.JYS, "时间控制装置启动请求:失败，OpenView(EUiViewName.TimeTrackControlView", default(ReadOnlySpan<ValueTuple<string, object>>));
							TsInteractionUtils.ClearCurrentOpenViewName();
							ControllerBase<TimeTrackController>.Instance.HandleTimeTrackControlViewClose();
							ControllerBase<TimeTrackController>.Instance.FinishCallback(false);
							return;
						}
						if (!ControllerBase<CameraController>.Instance.MainModel.IsToSceneCameraMode())
						{
							Singleton<global::Log>.Instance.Info(ELogModule.SceneGameplay, ELogAuthor.JYS, "时间控制装置启动请求:失败，IsToSceneCameraMode", default(ReadOnlySpan<ValueTuple<string, object>>));
							TsInteractionUtils.ClearCurrentOpenViewName();
							ControllerBase<TimeTrackController>.Instance.HandleTimeTrackControlViewClose();
							UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TimeTrackControlView);
							if (viewByName != null)
							{
								viewByName.CloseMe(null);
							}
							ControllerBase<TimeTrackController>.Instance.FinishCallback(false);
						}
					});
				});
			}
			else
			{
				this.IsForcedSceneCamera = false;
				this.ExitSceneCamera();
			}
			return true;
		}

		// Token: 0x06043917 RID: 276759 RVA: 0x0116B450 File Offset: 0x01169650
		public void SetOriginTransform()
		{
			if (this.Director == null)
			{
				return;
			}
			FVectorDouble fvectorDouble = new FVectorDouble();
			ULevelSequence sequence = this.Director.GetSequence();
			if (sequence == null || !sequence.D_GetCenterOffset(ref fvectorDouble))
			{
				fvectorDouble.Set(0.0, 0.0, 0.0);
			}
			this.Director.bOverrideInstanceData = true;
			UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData = this.Director.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
			if (udefaultLevelSequenceInstanceData != null)
			{
				UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData2 = udefaultLevelSequenceInstanceData;
				FVector fvector = new FVector((float)fvectorDouble.X, (float)fvectorDouble.Y, (float)fvectorDouble.Z);
				udefaultLevelSequenceInstanceData2.TransformOrigin = new FTransform(ref fvector);
			}
		}

		// Token: 0x06043918 RID: 276760 RVA: 0x0116B4F4 File Offset: 0x011696F4
		public void PlaySequence(DefaultLevelSequencePlayParam playParam)
		{
			ALevelSequenceActor director = this.Director;
			FQualifiedFrameTime fqualifiedFrameTime;
			if (director == null)
			{
				fqualifiedFrameTime = null;
			}
			else
			{
				ULevelSequencePlayer sequencePlayer = director.SequencePlayer;
				fqualifiedFrameTime = ((sequencePlayer != null) ? sequencePlayer.GetEndTime() : null);
			}
			FQualifiedFrameTime fqualifiedFrameTime2 = fqualifiedFrameTime;
			this.FadeInInTime = playParam.InTime;
			this.FadeInOutTime = playParam.OutTime;
			this.Character = playParam.Target;
			this.DefaultPlayParam = playParam;
			this.DefaultPlayParam.DelayUpdateFrame = 0;
			this.DefaultPlayParam.PlayedTime = 0f;
			this.DefaultPlayParam.TimeLength = ((fqualifiedFrameTime2 == null) ? 0f : (((float)fqualifiedFrameTime2.Time.FrameNumber.Value + fqualifiedFrameTime2.Time.SubFrame) * (float)fqualifiedFrameTime2.Rate.Denominator / (float)fqualifiedFrameTime2.Rate.Numerator));
			this.ItsWay = EWayType.Default;
			this.IsKeepUi = true;
			this.ForceTickOneFrameEventPause = true;
			this.CheckIsLoadingClosed();
		}

		// Token: 0x06043919 RID: 276761 RVA: 0x0116B5D4 File Offset: 0x011697D4
		public void PlayToMarkOld(string mark, float inTime, float outTime, bool jumpToEnd)
		{
			if (!this.CheckMarkValid(mark))
			{
				return;
			}
			this.Mark = mark;
			this.FadeInInTime = inTime;
			this.FadeOutOutTime = outTime;
			this.JumpToEnd = jumpToEnd;
			this.ItsWay = EWayType.Normal;
			this.CheckIsLoadingClosed();
		}

		// Token: 0x0604391A RID: 276762 RVA: 0x0116B60C File Offset: 0x0116980C
		public void PlayToMark(string mark, [Nullable(2)] RefCompDefine.TransitStruct tempInTransit, [Nullable(2)] RefCompDefine.TransitStruct tempOutTransit, RefCompDefine.PlayRateStruct playRateTransition, bool jumpToEnd)
		{
			if (!this.CheckMarkValid(mark))
			{
				return;
			}
			this.Mark = mark;
			if (tempInTransit != null)
			{
				this.TransitInType = tempInTransit.TransitType;
				ELevelSequenceTransition elevelSequenceTransition = this.TransitInType;
				if (elevelSequenceTransition != ELevelSequenceTransition.Camera)
				{
					if (elevelSequenceTransition == ELevelSequenceTransition.Mask)
					{
						this.DurationInTime = tempInTransit.Duration.GetValueOrDefault();
						this.FadeInInTime = tempInTransit.TransitFadeIn.GetValueOrDefault();
						this.FadeInOutTime = tempInTransit.TransitFadeOut.GetValueOrDefault();
						this.TransitInValid = tempInTransit.IsValid.GetValueOrDefault();
						this.InMask = tempInTransit.Mask;
					}
				}
				else
				{
					this.DurationInTime = tempInTransit.Duration.GetValueOrDefault();
					this.FadeInInTime = tempInTransit.Duration.GetValueOrDefault();
					this.FadeInOutTime = 0f;
					this.TransitInValid = tempInTransit.IsValid.GetValueOrDefault();
				}
			}
			if (tempOutTransit != null)
			{
				this.TransitOutType = tempOutTransit.TransitType;
				ELevelSequenceTransition elevelSequenceTransition = this.TransitOutType;
				if (elevelSequenceTransition != ELevelSequenceTransition.Camera)
				{
					if (elevelSequenceTransition == ELevelSequenceTransition.Mask)
					{
						this.DurationOutTime = tempOutTransit.Duration.GetValueOrDefault();
						this.FadeOutInTime = tempOutTransit.TransitFadeIn.GetValueOrDefault();
						this.FadeOutOutTime = tempOutTransit.TransitFadeOut.GetValueOrDefault();
						this.TransitOutValid = tempOutTransit.IsValid.GetValueOrDefault();
						this.OutMask = tempOutTransit.Mask;
					}
				}
				else
				{
					this.DurationOutTime = tempOutTransit.Duration.GetValueOrDefault();
					this.FadeOutInTime = 0f;
					this.FadeOutOutTime = tempOutTransit.Duration.GetValueOrDefault();
					this.TransitOutValid = tempOutTransit.IsValid.GetValueOrDefault();
				}
			}
			this.JumpToEnd = jumpToEnd;
			this.PlayRateTransition = playRateTransition;
			this.ItsWay = EWayType.Normal;
			this.CheckIsLoadingClosed();
		}

		// Token: 0x0604391B RID: 276763 RVA: 0x0116B7B4 File Offset: 0x011699B4
		public void PlayLoopBetweenMarks(ILoopRange loopRange, bool bReverse, [Nullable(2)] RefCompDefine.TransitStruct tempInTransit, [Nullable(2)] RefCompDefine.TransitStruct tempOutTransit, RefCompDefine.PlayRateStruct playRateTransition, bool jumpToEnd)
		{
			this.LoopStartMark = (bReverse ? loopRange.RightMark : loopRange.LeftMark);
			this.Mark = (bReverse ? loopRange.LeftMark : loopRange.RightMark);
			if (tempInTransit != null)
			{
				this.TransitInType = tempInTransit.TransitType;
				ELevelSequenceTransition elevelSequenceTransition = this.TransitInType;
				if (elevelSequenceTransition != ELevelSequenceTransition.Camera)
				{
					if (elevelSequenceTransition == ELevelSequenceTransition.Mask)
					{
						this.DurationInTime = tempInTransit.Duration.GetValueOrDefault();
						this.FadeInInTime = tempInTransit.TransitFadeIn.GetValueOrDefault();
						this.FadeInOutTime = tempInTransit.TransitFadeOut.GetValueOrDefault();
						this.TransitInValid = tempInTransit.IsValid.GetValueOrDefault();
						this.InMask = tempInTransit.Mask;
					}
				}
				else
				{
					this.DurationInTime = tempInTransit.Duration.GetValueOrDefault();
					this.FadeInInTime = tempInTransit.Duration.GetValueOrDefault();
					this.FadeInOutTime = 0f;
					this.TransitInValid = tempInTransit.IsValid.GetValueOrDefault();
				}
			}
			if (tempOutTransit != null)
			{
				this.TransitOutType = tempOutTransit.TransitType;
				ELevelSequenceTransition elevelSequenceTransition = this.TransitOutType;
				if (elevelSequenceTransition != ELevelSequenceTransition.Camera)
				{
					if (elevelSequenceTransition == ELevelSequenceTransition.Mask)
					{
						this.DurationOutTime = tempOutTransit.Duration.GetValueOrDefault();
						this.FadeOutInTime = tempOutTransit.TransitFadeIn.GetValueOrDefault();
						this.FadeOutOutTime = tempOutTransit.TransitFadeOut.GetValueOrDefault();
						this.TransitOutValid = tempOutTransit.IsValid.GetValueOrDefault();
						this.OutMask = tempOutTransit.Mask;
					}
				}
				else
				{
					this.DurationOutTime = tempOutTransit.Duration.GetValueOrDefault();
					this.FadeOutInTime = 0f;
					this.FadeOutOutTime = tempOutTransit.Duration.GetValueOrDefault();
					this.TransitOutValid = tempOutTransit.IsValid.GetValueOrDefault();
				}
			}
			this.PlayRateTransition = playRateTransition;
			this.JumpToEnd = jumpToEnd;
			this.ItsWay = EWayType.LoopBetweenMarks;
			this.CheckIsLoadingClosed();
		}

		// Token: 0x0604391C RID: 276764 RVA: 0x0116B980 File Offset: 0x01169B80
		[NullableContext(2)]
		public void PlayLoop(bool bReverse, int numLoops, RefCompDefine.TransitStruct tempInTransit, RefCompDefine.TransitStruct tempOutTransit, [Nullable(1)] RefCompDefine.PlayRateStruct playRateTransition)
		{
			this.Mark = "";
			if (tempInTransit != null)
			{
				this.TransitInType = tempInTransit.TransitType;
				ELevelSequenceTransition elevelSequenceTransition = this.TransitInType;
				if (elevelSequenceTransition != ELevelSequenceTransition.Camera)
				{
					if (elevelSequenceTransition == ELevelSequenceTransition.Mask)
					{
						this.DurationInTime = tempInTransit.Duration.GetValueOrDefault();
						this.FadeInInTime = tempInTransit.TransitFadeIn.GetValueOrDefault();
						this.FadeInOutTime = tempInTransit.TransitFadeOut.GetValueOrDefault();
						this.TransitInValid = tempInTransit.IsValid.GetValueOrDefault();
						this.InMask = tempInTransit.Mask;
					}
				}
				else
				{
					this.DurationInTime = tempInTransit.Duration.GetValueOrDefault();
					this.FadeInInTime = tempInTransit.Duration.GetValueOrDefault();
					this.FadeInOutTime = 0f;
					this.TransitInValid = tempInTransit.IsValid.GetValueOrDefault();
				}
			}
			if (tempOutTransit != null)
			{
				this.TransitOutType = tempOutTransit.TransitType;
				ELevelSequenceTransition elevelSequenceTransition = this.TransitOutType;
				if (elevelSequenceTransition != ELevelSequenceTransition.Camera)
				{
					if (elevelSequenceTransition == ELevelSequenceTransition.Mask)
					{
						this.DurationOutTime = tempOutTransit.Duration.GetValueOrDefault();
						this.FadeOutInTime = tempOutTransit.TransitFadeIn.GetValueOrDefault();
						this.FadeOutOutTime = tempOutTransit.TransitFadeOut.GetValueOrDefault();
						this.TransitOutValid = tempOutTransit.IsValid.GetValueOrDefault();
						this.OutMask = tempOutTransit.Mask;
					}
				}
				else
				{
					this.DurationOutTime = tempOutTransit.Duration.GetValueOrDefault();
					this.FadeOutInTime = 0f;
					this.FadeOutOutTime = tempOutTransit.Duration.GetValueOrDefault();
					this.TransitOutValid = tempOutTransit.IsValid.GetValueOrDefault();
				}
			}
			this.PlayRateTransition = playRateTransition;
			this.ReversedLoop = bReverse;
			this.NumLoops = numLoops;
			this.ItsWay = EWayType.Loop;
			this.CheckIsLoadingClosed();
		}

		// Token: 0x0604391D RID: 276765 RVA: 0x0116BB30 File Offset: 0x01169D30
		private void CheckIsLoadingClosed()
		{
			if (!this.CanPlayInLoading && !ModelBase<GameModeModel>.Instance.WorldDoneAndLoadingClosed)
			{
				if (!Singleton<EventSystem>.Instance.Has(EEventName.WorldDoneAndCloseLoading, new Action(this.DoPlay)))
				{
					Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.DoPlay));
					return;
				}
			}
			else
			{
				this.DoPlay();
			}
		}

		// Token: 0x0604391E RID: 276766 RVA: 0x0116BB94 File Offset: 0x01169D94
		private void DoPlay()
		{
			SequenceCameraPlayerComponent component = ControllerBase<CameraController>.Instance.MainModel.SequenceCamera.GetComponent<SequenceCameraPlayerComponent>();
			if (component != null && component.GetIsInCinematic())
			{
				this.PlayLevelSequence();
				return;
			}
			if (this.UiSequence)
			{
				this.PlayLevelSequence();
				return;
			}
			if (this.JumpToEnd || !this.HasCameraTrack)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelSequencePlayer;
				ELogAuthor author = ELogAuthor.JYS;
				string message = "DoPlayToMark为JumpToEnd或者没有camera轨道";
				string item = "CameraMode";
				CameraModel instance2 = ModelBase<CameraModel>.Instance;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (instance2 != null) ? instance2.MainModel.CameraMode : null);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.PlayLevelSequence();
				return;
			}
			if (!this.CameraBindFinished)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.LevelSequencePlayer;
				ELogAuthor author2 = ELogAuthor.JYS;
				string message2 = "DoPlayToMark首次绑定";
				string item2 = "CameraMode";
				CameraModel instance4 = ModelBase<CameraModel>.Instance;
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>(item2, (instance4 != null) ? instance4.MainModel.CameraMode : null);
				instance3.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				if (this.TransitInType == ELevelSequenceTransition.Mask)
				{
					this.GenerateBlackScreen(this.InMask, this.DurationInTime, this.FadeInInTime, this.FadeInOutTime, delegate
					{
						this.EnterSceneCamera(null);
					}, new Action(this.PlayLevelSequence));
					return;
				}
				this.EnterSceneCamera(new Action(this.PlayLevelSequence));
				return;
			}
			else
			{
				global::Log instance5 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.LevelSequencePlayer;
				ELogAuthor author3 = ELogAuthor.JYS;
				string message3 = "DoPlayToMark非首次绑定";
				string item3 = "CameraMode";
				CameraModel instance6 = ModelBase<CameraModel>.Instance;
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>(item3, (instance6 != null) ? instance6.MainModel.CameraMode : null);
				instance5.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				if (this.TransitInType == ELevelSequenceTransition.Mask)
				{
					this.GenerateBlackScreen(this.InMask, this.DurationInTime, this.FadeInInTime, this.FadeInOutTime, delegate
					{
						this.EnterSceneCamera(null);
					}, new Action(this.PlayLevelSequence));
					return;
				}
				this.EnterSceneCamera(new Action(this.PlayLevelSequence));
				return;
			}
		}

		// Token: 0x0604391F RID: 276767 RVA: 0x0116BD7C File Offset: 0x01169F7C
		public void PlayLevelSequence()
		{
			switch (this.ItsWay)
			{
			case EWayType.Default:
				this.PlayDefaultLevelSequence();
				return;
			case EWayType.Normal:
			case EWayType.GotoEndAndTransport:
				this.PlayLevelsequenceToMark(this.Mark, this.JumpToEnd);
				return;
			case EWayType.Loop:
				this.PlayLevelsequenceLooping(this.ReversedLoop, this.NumLoops);
				return;
			case EWayType.LoopBetweenMarks:
				this.PlayLevelsequenceLoopingBetweenMark(this.JumpToEnd);
				return;
			default:
				return;
			}
		}

		// Token: 0x06043920 RID: 276768 RVA: 0x0116BDE4 File Offset: 0x01169FE4
		private void PlayDefaultLevelSequence()
		{
			ALevelSequenceActor director = this.Director;
			if (director == null || !director.IsValid())
			{
				return;
			}
			this.Director.bOverrideInstanceData = true;
			ULevelSequencePlayer sequencePlayer = this.Director.SequencePlayer;
			if (sequencePlayer != null && sequencePlayer.IsValid())
			{
				TsBaseCharacter character = this.Character;
				if (character != null && character.IsValid())
				{
					if (this.DefaultPlayParam == null)
					{
						return;
					}
					if (this.TransformOriginActor == null)
					{
						this.TransformOriginActor = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true);
						AActor transformOriginActor = this.TransformOriginActor;
						TSubclassOf<UActorComponent> @class = USceneComponent.StaticClass();
						bool bManualAttachment = false;
						FTransformDouble ftransformDouble = this.TransformOriginActor.D_GetTransform();
						transformOriginActor.D_AddComponentByClass(@class, bManualAttachment, ftransformDouble, false, default(FName));
					}
					Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.DefaultLevelSequenceAfterTick), "SimpleLevelSequenceActor", ETickingGroup.TG_PostPhysics, false, 0, false);
					this.DefaultPlayAfterTickId = ticker.Id;
					this.DefaultPlayParam.InitPlayerRotator.DeepCopy(this.Character.CharacterActorComponent.ActorRotationProxy);
					this.DefaultPlayParam.InitPlayerFloorLocation.DeepCopy(this.Character.CharacterActorComponent.FloorLocation);
					sequencePlayer.Play();
					sequencePlayer.SetPlayRate(0f);
					sequencePlayer.Pause();
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Interaction;
					ELogAuthor author = ELogAuthor.LJM;
					string message = "LevelSequence默认播放";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("levelSequence", this.LevelSequence);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
			}
		}

		// Token: 0x06043921 RID: 276769 RVA: 0x0116BF60 File Offset: 0x0116A160
		private unsafe void PlayLevelsequenceToMark(string mark, bool jumpToEnd)
		{
			ALevelSequenceActor director = this.Director;
			if (director == null || !director.IsValid())
			{
				return;
			}
			this.Director.bOverrideInstanceData = true;
			ULevelSequencePlayer sequencePlayer = this.Director.SequencePlayer;
			if (sequencePlayer == null || !sequencePlayer.IsValid())
			{
				return;
			}
			if (this.LastPlayRateEaseHandleId != 0)
			{
				UKuroSequenceRuntimeFunctionLibrary.StopEasingPlayRate(this.Director, this.LastPlayRateEaseHandleId, false);
				this.LastPlayRateEaseHandleId = 0;
			}
			if (jumpToEnd)
			{
				sequencePlayer.Play();
				sequencePlayer.SetPlaybackPosition(new FMovieSceneSequencePlaybackParams(new FFrameTime(), 0f, mark, EMovieScenePositionType.MarkedFrame, EUpdatePositionMethod.Jump));
				RefCompDefine.PlayRateStruct playRateTransition = this.PlayRateTransition;
				this.CurPlayRate = ((playRateTransition != null) ? playRateTransition.PlayRateAbs : null).GetValueOrDefault(1f);
				ULevelSequencePlayer sequencePlayer2 = this.Director.SequencePlayer;
				if (sequencePlayer2 != null)
				{
					sequencePlayer2.SetPlayRate(this.CustomTimeDilation * this.CurPlayRate);
				}
				sequencePlayer.Pause();
			}
			else
			{
				EWayType itsWay = this.ItsWay;
				if (itsWay != EWayType.Normal)
				{
					if (itsWay == EWayType.GotoEndAndTransport)
					{
						sequencePlayer.PlayTo_Circle(new FMovieSceneSequencePlaybackParams(new FFrameTime(), 0f, mark, EMovieScenePositionType.MarkedFrame, EUpdatePositionMethod.Play), true, true);
						RefCompDefine.PlayRateStruct playRateTransition2 = this.PlayRateTransition;
						this.CurPlayRate = ((playRateTransition2 != null) ? playRateTransition2.PlayRateAbs : null).GetValueOrDefault(1f);
						RefCompDefine.PlayRateStruct playRateTransition3 = this.PlayRateTransition;
						float? num = (playRateTransition3 != null) ? playRateTransition3.EaseDuration : null;
						bool flag = num == null || num.GetValueOrDefault() == 0f;
						if (flag)
						{
							ULevelSequencePlayer sequencePlayer3 = this.Director.SequencePlayer;
							if (sequencePlayer3 != null)
							{
								sequencePlayer3.SetPlayRate(this.CustomTimeDilation * this.CurPlayRate);
							}
						}
						else
						{
							this.LastPlayRateEaseHandleId = UKuroSequenceRuntimeFunctionLibrary.EasePlayRateTo(this.Director, this.CustomTimeDilation * this.CurPlayRate, this.PlayRateTransition.EaseType, this.PlayRateTransition.EaseDuration.Value, this.PlayRateTransition.EaseExponent.Value);
						}
					}
				}
				else
				{
					sequencePlayer.PlayTo(new FMovieSceneSequencePlaybackParams(new FFrameTime(), 0f, mark, EMovieScenePositionType.MarkedFrame, EUpdatePositionMethod.Play));
					RefCompDefine.PlayRateStruct playRateTransition4 = this.PlayRateTransition;
					this.CurPlayRate = ((playRateTransition4 != null) ? playRateTransition4.PlayRateAbs : null).GetValueOrDefault(1f);
					RefCompDefine.PlayRateStruct playRateTransition5 = this.PlayRateTransition;
					float? num = (playRateTransition5 != null) ? playRateTransition5.EaseDuration : null;
					bool flag = num == null || num.GetValueOrDefault() == 0f;
					if (flag)
					{
						ULevelSequencePlayer sequencePlayer4 = this.Director.SequencePlayer;
						if (sequencePlayer4 != null)
						{
							sequencePlayer4.SetPlayRate(this.CustomTimeDilation * this.CurPlayRate);
						}
					}
					else
					{
						this.LastPlayRateEaseHandleId = UKuroSequenceRuntimeFunctionLibrary.EasePlayRateTo(this.Director, this.CustomTimeDilation * this.CurPlayRate, this.PlayRateTransition.EaseType, this.PlayRateTransition.EaseDuration.Value, this.PlayRateTransition.EaseExponent.Value);
					}
				}
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Interaction;
			ELogAuthor author = ELogAuthor.ZS;
			string message = "LevelSequence播放至对应mark";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("levelSequence", this.LevelSequence);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("mark", mark);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06043922 RID: 276770 RVA: 0x0116C2B0 File Offset: 0x0116A4B0
		private unsafe void PlayLevelsequenceLooping(bool bReverse, int numLoops)
		{
			ALevelSequenceActor director = this.Director;
			if (director == null || !director.IsValid())
			{
				return;
			}
			this.Director.bOverrideInstanceData = true;
			ULevelSequencePlayer sequencePlayer = this.Director.SequencePlayer;
			if (sequencePlayer == null || !sequencePlayer.IsValid())
			{
				return;
			}
			if (this.LastPlayRateEaseHandleId != 0)
			{
				UKuroSequenceRuntimeFunctionLibrary.StopEasingPlayRate(this.Director, this.LastPlayRateEaseHandleId, false);
				this.LastPlayRateEaseHandleId = 0;
			}
			if (this.ItsWay == EWayType.Loop)
			{
				if (!bReverse)
				{
					sequencePlayer.PlayLooping(numLoops);
				}
				else
				{
					sequencePlayer.PlayReverseLooping(numLoops);
				}
				RefCompDefine.PlayRateStruct playRateTransition = this.PlayRateTransition;
				this.CurPlayRate = ((playRateTransition != null) ? playRateTransition.PlayRateAbs : null).GetValueOrDefault(1f);
				RefCompDefine.PlayRateStruct playRateTransition2 = this.PlayRateTransition;
				float? num = (playRateTransition2 != null) ? playRateTransition2.EaseDuration : null;
				bool flag = num == null || num.GetValueOrDefault() == 0f;
				if (flag)
				{
					ULevelSequencePlayer sequencePlayer2 = this.Director.SequencePlayer;
					if (sequencePlayer2 != null)
					{
						sequencePlayer2.SetPlayRate(this.CustomTimeDilation * this.CurPlayRate);
					}
				}
				else
				{
					this.LastPlayRateEaseHandleId = UKuroSequenceRuntimeFunctionLibrary.EasePlayRateTo(this.Director, this.CustomTimeDilation * this.CurPlayRate, this.PlayRateTransition.EaseType, this.PlayRateTransition.EaseDuration.Value, this.PlayRateTransition.EaseExponent.Value);
				}
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Interaction;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "LevelSequence循环播放";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("levelSequence", this.LevelSequence);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("bReverse", bReverse);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("numLoops", numLoops);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x06043923 RID: 276771 RVA: 0x0116C494 File Offset: 0x0116A694
		private void PlayLevelsequenceLoopingBetweenMark(bool jumpToEnd)
		{
			ALevelSequenceActor director = this.Director;
			if (director == null || !director.IsValid())
			{
				return;
			}
			this.Director.bOverrideInstanceData = true;
			ULevelSequencePlayer player = this.Director.SequencePlayer;
			ULevelSequencePlayer player2 = player;
			if (player2 == null || !player2.IsValid())
			{
				return;
			}
			if (this.LastPlayRateEaseHandleId != 0)
			{
				UKuroSequenceRuntimeFunctionLibrary.StopEasingPlayRate(this.Director, this.LastPlayRateEaseHandleId, false);
				this.LastPlayRateEaseHandleId = 0;
			}
			RefCompDefine.PlayRateStruct playRateTransition = this.PlayRateTransition;
			this.CurPlayRate = ((playRateTransition != null) ? playRateTransition.PlayRateAbs : null).GetValueOrDefault(1f);
			RefCompDefine.PlayRateStruct playRateTransition2 = this.PlayRateTransition;
			float? num = (playRateTransition2 != null) ? playRateTransition2.EaseDuration : null;
			bool flag = num == null || num.GetValueOrDefault() == 0f;
			if (flag)
			{
				ULevelSequencePlayer sequencePlayer = this.Director.SequencePlayer;
				if (sequencePlayer != null)
				{
					sequencePlayer.SetPlayRate(this.CustomTimeDilation * this.CurPlayRate);
				}
			}
			else
			{
				this.LastPlayRateEaseHandleId = UKuroSequenceRuntimeFunctionLibrary.EasePlayRateTo(this.Director, this.CustomTimeDilation * this.CurPlayRate, this.PlayRateTransition.EaseType, this.PlayRateTransition.EaseDuration.Value, this.PlayRateTransition.EaseExponent.Value);
			}
			double? markValue = this.GetMarkValue(this.LoopStartMark);
			double? markValue2 = this.GetMarkValue(this.Mark);
			if (markValue == null || markValue2 == null)
			{
				return;
			}
			double? num2 = markValue;
			double? num3 = markValue2;
			if (num2.GetValueOrDefault() == num3.GetValueOrDefault() & num2 != null == (num3 != null))
			{
				return;
			}
			double num4 = (double)this.GetCurrentFrame();
			num3 = markValue;
			num2 = markValue2;
			bool flag2;
			if (num3.GetValueOrDefault() < num2.GetValueOrDefault() & (num3 != null & num2 != null))
			{
				double num5 = num4;
				num2 = markValue2;
				if (num5 > num2.GetValueOrDefault() & num2 != null)
				{
					flag2 = true;
					goto IL_23A;
				}
			}
			num2 = markValue;
			num3 = markValue2;
			if (num2.GetValueOrDefault() > num3.GetValueOrDefault() & (num2 != null & num3 != null))
			{
				double num6 = num4;
				num3 = markValue2;
				flag2 = (num6 < num3.GetValueOrDefault() & num3 != null);
			}
			else
			{
				flag2 = false;
			}
			IL_23A:
			bool flag3 = flag2;
			if (!this.JumpToEnd && !flag3)
			{
				player.PlayTo_Loop(new FMovieSceneSequencePlaybackParams(new FFrameTime(), 0f, this.Mark, EMovieScenePositionType.MarkedFrame, EUpdatePositionMethod.Play), this.LoopStartMark);
				return;
			}
			this.AddOnPauseCallback(delegate
			{
				this.ClearOnPausedCallback();
				player.PlayTo_Loop(new FMovieSceneSequencePlaybackParams(new FFrameTime(), 0f, this.Mark, EMovieScenePositionType.MarkedFrame, EUpdatePositionMethod.Play), this.LoopStartMark);
			});
			FMovieSceneSequencePlaybackParams fmovieSceneSequencePlaybackParams = new FMovieSceneSequencePlaybackParams(new FFrameTime(), 0f, this.LoopStartMark, EMovieScenePositionType.MarkedFrame, EUpdatePositionMethod.Jump);
			if (this.JumpToEnd)
			{
				player.Play();
				player.SetPlaybackPosition(fmovieSceneSequencePlaybackParams);
				player.Pause();
				return;
			}
			player.PlayTo(fmovieSceneSequencePlaybackParams);
		}

		// Token: 0x06043924 RID: 276772 RVA: 0x0116C778 File Offset: 0x0116A978
		private void GenerateDirector()
		{
			FMovieSceneSequencePlaybackSettings fmovieSceneSequencePlaybackSettings = new FMovieSceneSequencePlaybackSettings();
			fmovieSceneSequencePlaybackSettings.bDisableMovementInput = false;
			fmovieSceneSequencePlaybackSettings.bDisableLookAtInput = false;
			this.Director = (Singleton<ActorSystem>.Instance.Get(ALevelSequenceActor.StaticClass(), new FTransformDouble(), null, false) as ALevelSequenceActor);
			this.Director.PlaybackSettings = fmovieSceneSequencePlaybackSettings;
			this.Director.SetSequence(this.LevelSequence);
			this.CameraSequenceData = (this.Director.DefaultInstanceData as UDefaultLevelSequenceInstanceData);
			ULevelSequencePlayer sequencePlayer = this.Director.SequencePlayer;
			if (sequencePlayer == null || !sequencePlayer.IsValid())
			{
				return;
			}
			sequencePlayer.OnPause.Add(new Action(this.OnSequencePause));
			sequencePlayer.OnStop.Add(new Action(this.OnSequenceStop));
			sequencePlayer.OnFinished.Add(new Action(this.OnSequenceFinish));
		}

		// Token: 0x06043925 RID: 276773 RVA: 0x0116C850 File Offset: 0x0116AA50
		private void GenerateSphereTrace()
		{
			UTraceSphereElement cameraSphereTrace = this.CameraSphereTrace;
			if (cameraSphereTrace != null && cameraSphereTrace.IsValid())
			{
				return;
			}
			this.CameraSphereTrace = new UTraceSphereElement();
			this.CameraSphereTrace.bIsSingle = false;
			this.CameraSphereTrace.bTraceComplex = false;
			this.CameraSphereTrace.bIgnoreSelf = true;
			this.CameraSphereTrace.WorldContextObject = GlobalData.World;
			this.CameraSphereTrace.Radius = 10f;
			this.CameraSphereTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Camera);
		}

		// Token: 0x06043926 RID: 276774 RVA: 0x0116C8D4 File Offset: 0x0116AAD4
		private void OnSequenceStop()
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Level;
			ELogAuthor author = ELogAuthor.ZS;
			string message = "SimpleLevelSequenceActor OnSequenceStop";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("levelSequence", this.LevelSequence);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Action<bool> onStopCallback = this.OnStopCallback;
			if (onStopCallback != null)
			{
				onStopCallback(this.IsSequenceStopWithFinish);
			}
			ALevelSequenceActor director = this.Director;
			if (director == null || !director.IsValid() || this.JumpToEnd)
			{
				return;
			}
			if (this.TransitOutType == ELevelSequenceTransition.Mask && !this.UiSequence)
			{
				this.GenerateBlackScreen(this.OutMask, this.DurationOutTime, this.FadeOutInTime, this.FadeOutOutTime, delegate
				{
					ControllerBase<CameraController>.Instance.MainModel.SceneCamera.PlayerComponent.ExitSceneSubCamera(this.SceneCamera, null, new ELevelSequenceTransition?(this.TransitOutType));
				}, new Action(this.OnPlayEnd));
				return;
			}
			this.OnPlayEnd();
		}

		// Token: 0x06043927 RID: 276775 RVA: 0x0116C994 File Offset: 0x0116AB94
		private void OnSequencePause()
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Level;
			ELogAuthor author = ELogAuthor.ZS;
			string message = "SimpleLevelSequenceActor OnSequencePause";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("levelSequence", this.LevelSequence);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Action onPauseCallback = this.OnPauseCallback;
			if (onPauseCallback != null)
			{
				onPauseCallback();
			}
			if (this.JumpToEnd || this.ItsWay == EWayType.Default)
			{
				return;
			}
			if (this.TransitOutType == ELevelSequenceTransition.Mask && !this.UiSequence)
			{
				this.GenerateBlackScreen(this.OutMask, this.DurationOutTime, this.FadeOutInTime, this.FadeOutOutTime, delegate
				{
					ControllerBase<CameraController>.Instance.MainModel.SceneCamera.PlayerComponent.ExitSceneSubCamera(this.SceneCamera, null, new ELevelSequenceTransition?(this.TransitOutType));
				}, new Action(this.OnPlayEnd));
				return;
			}
			this.OnPlayEnd();
		}

		// Token: 0x06043928 RID: 276776 RVA: 0x0116CA40 File Offset: 0x0116AC40
		private void OnSequenceFinish()
		{
			Action onFinishedCallback = this.OnFinishedCallback;
			if (onFinishedCallback != null)
			{
				onFinishedCallback();
			}
			if (this.JumpToEnd)
			{
				return;
			}
			if (this.TransitOutType == ELevelSequenceTransition.Mask && !this.UiSequence)
			{
				this.GenerateBlackScreen(this.OutMask, this.DurationOutTime, this.FadeOutInTime, this.FadeOutOutTime, delegate
				{
					ControllerBase<CameraController>.Instance.MainModel.SceneCamera.PlayerComponent.ExitSceneSubCamera(this.SceneCamera, null, new ELevelSequenceTransition?(this.TransitOutType));
				}, new Action(this.OnPlayEnd));
				return;
			}
			this.OnPlayEnd();
		}

		// Token: 0x06043929 RID: 276777 RVA: 0x0116CAB5 File Offset: 0x0116ACB5
		private void OnPlayEnd()
		{
			Global.CharacterCameraManager.FadeAmount = 0f;
			if (this.HasCameraTrack)
			{
				if (ModelBase<StaticSceneModel>.Instance.IsNotAutoExitSceneCamera && this.IsForcedSceneCamera)
				{
					return;
				}
				if (this.UiSequence)
				{
					return;
				}
				this.ExitSceneCamera();
			}
		}

		// Token: 0x0604392A RID: 276778 RVA: 0x0116CAF4 File Offset: 0x0116ACF4
		private unsafe bool CheckMarkValid(string mark)
		{
			UMovieScene movieScene = this.LevelSequence.GetMovieScene();
			bool flag = false;
			if (movieScene != null)
			{
				for (int i = 0; i < movieScene.MarkedFrames.Num(); i++)
				{
					if (movieScene.MarkedFrames.Get(i).Label == mark)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Interaction;
				ELogAuthor author = ELogAuthor.ZS;
				string message = "mark配置不合法";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("levelSequence", this.LevelSequence);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("mark", mark);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			return true;
		}

		// Token: 0x0604392B RID: 276779 RVA: 0x0116CBA8 File Offset: 0x0116ADA8
		[NullableContext(2)]
		private void EnterSceneCamera(Action enterCameraCb = null)
		{
			ALevelSequenceActor director = this.Director;
			if (director == null || !director.IsValid())
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.LevelSequencePlayer, ELogAuthor.JYS, "SimpleLevelSeqeunce:EnterSceneCamera Director为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				Action enterCameraCb2 = enterCameraCb;
				if (enterCameraCb2 == null)
				{
					return;
				}
				enterCameraCb2();
				return;
			}
			else if (ModelBase<PlotModel>.Instance.IsInHighLevelPlot())
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Camera, ELogAuthor.JYS, "SimpleLevelSeqeunce:演出中触发了场景镜头切换 请检查配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				Action enterCameraCb3 = enterCameraCb;
				if (enterCameraCb3 == null)
				{
					return;
				}
				enterCameraCb3();
				return;
			}
			else
			{
				if (!this.IsKeepUi && !ModelBase<StaticSceneModel>.Instance.IsForceKeepUi && !this.IsPlaying())
				{
					ControllerBase<CameraController>.Instance.MainModel.SceneCamera.DisplayComponent.SetUiActive(false);
				}
				SceneSubCamera sceneCamera = this.SceneCamera;
				if (sceneCamera == null || !sceneCamera.IsBinding)
				{
					this.SceneCamera = ControllerBase<CameraController>.Instance.MainModel.SceneCamera.DisplayComponent.GetUnBoundSceneCamera(ESceneSubCameraType.Sequence);
					this.SceneCamera.IsKeepUi = this.IsKeepUi;
					if (!this.TransitInValid)
					{
						this.SceneCamera.FadeIn = 0f;
					}
					else
					{
						this.SceneCamera.FadeIn = ((this.FadeInInTime != 0f) ? this.FadeInInTime : this.DurationInTime);
					}
					if (!this.TransitOutValid)
					{
						this.SceneCamera.FadeOut = 0f;
					}
					else
					{
						this.SceneCamera.FadeOut = ((this.FadeOutOutTime != 0f) ? this.FadeOutOutTime : this.DurationOutTime);
					}
				}
				this.BindingActors.Empty(true);
				this.BindingActors.Add(this.SceneCamera.Camera);
				this.Director.SetBindingByTag(SimpleLevelSequenceActorConstants.CAMERA_TAG, this.BindingActors, true, false);
				ECustomCameraMode? cameraMode = ModelBase<CameraModel>.Instance.MainModel.CameraMode;
				ECustomCameraMode ecustomCameraMode = ECustomCameraMode.Scene;
				if (cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null)
				{
					this.CameraBindFinished = true;
					this.SceneCamera.IsBinding = true;
					ControllerBase<CameraController>.Instance.MainModel.SceneCamera.PlayerComponent.EnterSceneSubCamera(this.SceneCamera, null);
					Action enterCameraCb4 = enterCameraCb;
					if (enterCameraCb4 == null)
					{
						return;
					}
					enterCameraCb4();
					return;
				}
				else
				{
					if (!this.UiSequence)
					{
						ControllerBase<CameraController>.Instance.EnterCameraMode(ECustomCameraMode.Scene, (this.TransitInType == ELevelSequenceTransition.Mask) ? 0f : this.FadeInInTime, UnrealEngine.EViewTargetBlendFunction.VTBlend_Linear, 0f, null, false, "MainCamera", null);
						Action enterCameraCb5 = enterCameraCb;
						if (enterCameraCb5 != null)
						{
							enterCameraCb5();
						}
						this.CameraBindFinished = true;
						this.SceneCamera.IsBinding = true;
						return;
					}
					if (this.TransitInType == ELevelSequenceTransition.Mask)
					{
						Action <>9__2;
						this.GenerateBlackScreen(this.InMask, this.DurationInTime, this.FadeInInTime, this.FadeInOutTime, delegate
						{
							CameraController instance = ControllerBase<CameraController>.Instance;
							ECustomCameraMode mode = ECustomCameraMode.Scene;
							float blendTime = 0f;
							UnrealEngine.EViewTargetBlendFunction blendFunction = UnrealEngine.EViewTargetBlendFunction.VTBlend_Linear;
							float blendExp = 0f;
							Action callback;
							if ((callback = <>9__2) == null)
							{
								callback = (<>9__2 = delegate()
								{
									if (!ControllerBase<CameraController>.Instance.MainModel.IsToSceneCameraMode())
									{
										TsInteractionUtils.ClearCurrentOpenViewName();
										ControllerBase<TimeTrackController>.Instance.HandleTimeTrackControlViewClose();
										return;
									}
									Action enterCameraCb6 = enterCameraCb;
									if (enterCameraCb6 == null)
									{
										return;
									}
									enterCameraCb6();
								});
							}
							instance.EnterCameraMode(mode, blendTime, blendFunction, blendExp, callback, true, "MainCamera", null);
						}, null);
						return;
					}
					ControllerBase<CameraController>.Instance.EnterCameraMode(ECustomCameraMode.Scene, this.FadeInInTime, UnrealEngine.EViewTargetBlendFunction.VTBlend_Linear, 0f, delegate
					{
						if (!ControllerBase<CameraController>.Instance.MainModel.IsToSceneCameraMode())
						{
							TsInteractionUtils.ClearCurrentOpenViewName();
							ControllerBase<TimeTrackController>.Instance.HandleTimeTrackControlViewClose();
							return;
						}
						Action enterCameraCb6 = enterCameraCb;
						if (enterCameraCb6 == null)
						{
							return;
						}
						enterCameraCb6();
					}, true, "MainCamera", null);
					return;
				}
			}
		}

		// Token: 0x0604392C RID: 276780 RVA: 0x0116CEA4 File Offset: 0x0116B0A4
		private void ExitSceneCamera()
		{
			this.Director.ResetBindings();
			this.CameraBindFinished = false;
			SceneSubCamera sceneCamera = this.SceneCamera;
			if (sceneCamera == null || !sceneCamera.IsBinding)
			{
				this.OnExit();
				return;
			}
			if (this.UiSequence)
			{
				if (this.TransitOutType == ELevelSequenceTransition.Mask)
				{
					this.GenerateBlackScreen(this.InMask, this.DurationInTime, this.FadeInInTime, this.FadeInOutTime, delegate
					{
						this.SceneCamera.FadeOut = 0f;
						ControllerBase<CameraController>.Instance.MainModel.SceneCamera.PlayerComponent.ExitSceneSubCamera(this.SceneCamera, new Action(this.OnExit), new ELevelSequenceTransition?(this.TransitOutType));
					}, null);
					return;
				}
				this.SceneCamera.FadeOut = ((this.FadeOutOutTime != 0f) ? this.FadeOutOutTime : this.DurationOutTime);
				ControllerBase<CameraController>.Instance.MainModel.SceneCamera.PlayerComponent.ExitSceneSubCamera(this.SceneCamera, new Action(this.OnExit), new ELevelSequenceTransition?(this.TransitOutType));
				return;
			}
			else
			{
				if (this.TransitOutType == ELevelSequenceTransition.Mask)
				{
					this.OnExit();
					return;
				}
				ControllerBase<CameraController>.Instance.MainModel.SceneCamera.PlayerComponent.ExitSceneSubCamera(this.SceneCamera, new Action(this.OnExit), new ELevelSequenceTransition?(this.TransitOutType));
				return;
			}
		}

		// Token: 0x0604392D RID: 276781 RVA: 0x0116CFC4 File Offset: 0x0116B1C4
		private void OnExit()
		{
			this.SceneCamera = null;
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraInputController.Unlock(this);
			this.LockBySimpleLevelSequence = false;
			ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.SimpleLevelSequence, "SimpleLevelSequenceProcess", null, null);
			if (this.DefaultPlayAfterTickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.DefaultPlayAfterTickId);
				this.DefaultPlayAfterTickId = -1;
			}
			if (this.DefaultPlayParam != null && this.DefaultPlayParam.BindSetting.IsBindToTarget())
			{
				AActor transformOriginActor = this.TransformOriginActor;
				if (transformOriginActor != null)
				{
					transformOriginActor.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
				}
			}
			this.DefaultPlayParam = null;
			if (this.IsKeepUi || ModelBase<StaticSceneModel>.Instance.IsForceKeepUi)
			{
				return;
			}
			ControllerBase<CameraController>.Instance.MainModel.SceneCamera.DisplayComponent.SetUiActive(true);
		}

		// Token: 0x0604392E RID: 276782 RVA: 0x0116D0A0 File Offset: 0x0116B2A0
		[NullableContext(2)]
		private void GenerateBlackScreen(ETransitionMask? mask, float durationTime, float fadeInTime, float fadeOutTime, Action camCb = null, Action seqCb = null)
		{
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraInputController.Lock(this);
			this.LockBySimpleLevelSequence = true;
			LevelLoadingController instance = ControllerBase<LevelLoadingController>.Instance;
			ELoadingReason reason = ELoadingReason.SimpleLevelSequence;
			ELoadingPerform perform = ELoadingPerform.CameraFade;
			string context = "SimpleLevelSequenceProcess";
			TTimerAction <>9__1;
			Action callback = delegate()
			{
				Action camCb2 = camCb;
				if (camCb2 != null)
				{
					camCb2();
				}
				if (durationTime <= 0f)
				{
					Action seqCb2 = seqCb;
					if (seqCb2 != null)
					{
						seqCb2();
					}
					ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.SimpleLevelSequence, "SimpleLevelSequenceProcess", null, new float?(fadeOutTime));
					return;
				}
				TimerSystemInstance instance2 = TimerSystem.Instance;
				TTimerAction action;
				if ((action = <>9__1) == null)
				{
					action = (<>9__1 = delegate(float _)
					{
						Action seqCb3 = seqCb;
						if (seqCb3 != null)
						{
							seqCb3();
						}
						ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.SimpleLevelSequence, "SimpleLevelSequenceProcess", null, new float?(fadeOutTime));
					});
				}
				instance2.Delay(action, durationTime * 1000f, null, null, true, 1f);
			};
			object[] array = new object[2];
			array[0] = fadeInTime;
			int num = 1;
			ETransitionMask? etransitionMask = mask;
			ETransitionMask etransitionMask2 = ETransitionMask.BlackMask;
			array[num] = ((etransitionMask.GetValueOrDefault() == etransitionMask2 & etransitionMask != null) ? EFadeInScreenShowType.Black : EFadeInScreenShowType.White);
			instance.OpenLoading<ELoadingPerform>(reason, perform, context, callback, array);
		}

		// Token: 0x0604392F RID: 276783 RVA: 0x0116D148 File Offset: 0x0116B348
		public void SetSequenceData(ULevelSequence inSeq)
		{
			if (inSeq == this.LevelSequence)
			{
				return;
			}
			this.LevelSequence = inSeq;
			this.Director.SetSequence(inSeq);
		}

		// Token: 0x06043930 RID: 276784 RVA: 0x0116D168 File Offset: 0x0116B368
		public void Clear()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.WorldDoneAndCloseLoading, new Action(this.DoPlay)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.DoPlay));
			}
			if (this.SceneCamera != null)
			{
				if (this.SceneCamera.IsBinding)
				{
					if (!this.IsKeepUi && !ModelBase<StaticSceneModel>.Instance.IsForceKeepUi && !this.IsForcedSceneCamera)
					{
						ControllerBase<CameraController>.Instance.MainModel.SceneCamera.DisplayComponent.SetUiActive(true);
					}
					ControllerBase<CameraController>.Instance.MainModel.SceneCamera.PlayerComponent.ExitSceneSubCamera(this.SceneCamera, null, null);
				}
				ControllerBase<CameraController>.Instance.MainModel.SceneCamera.DisplayComponent.RemoveBoundSceneCamera(this.SceneCamera);
			}
			if (this.LastPlayRateEaseHandleId != 0)
			{
				ALevelSequenceActor director = this.Director;
				if (director != null && director.IsValid())
				{
					UKuroSequenceRuntimeFunctionLibrary.StopEasingPlayRate(this.Director, this.LastPlayRateEaseHandleId, false);
				}
				this.LastPlayRateEaseHandleId = 0;
			}
			ALevelSequenceActor director2 = this.Director;
			if (director2 != null && director2.IsValid())
			{
				ALevelSequenceActor tmp = this.Director;
				ULevelSequencePlayer sequencePlayer = tmp.SequencePlayer;
				if (sequencePlayer != null)
				{
					sequencePlayer.Stop();
				}
				TimerSystem.Instance.Next(delegate(float _)
				{
					Singleton<ActorSystem>.Instance.Put("SimpleLevelSequenceActor.Clear", tmp, null);
				}, null, null);
				this.Director = null;
			}
			UTraceSphereElement cameraSphereTrace = this.CameraSphereTrace;
			if (cameraSphereTrace != null && cameraSphereTrace.IsValid())
			{
				this.CameraSphereTrace.Dispose();
				this.CameraSphereTrace = null;
			}
			if (this.LockBySimpleLevelSequence)
			{
				ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraInputController.Unlock(this);
				this.LockBySimpleLevelSequence = false;
			}
			this.ClearOnPausedCallback();
		}

		// Token: 0x06043931 RID: 276785 RVA: 0x0116D330 File Offset: 0x0116B530
		public void PlayToMarkByCheckWay(string mark, [Nullable(2)] RefCompDefine.TransitStruct tempInTransit, [Nullable(2)] RefCompDefine.TransitStruct tempOutTransit, RefCompDefine.PlayRateStruct playRateTransition, bool jumpToEnd)
		{
			if (!this.CheckMarkValid(mark))
			{
				return;
			}
			this.Mark = mark;
			if (tempInTransit != null)
			{
				this.TransitInType = tempInTransit.TransitType;
				ELevelSequenceTransition elevelSequenceTransition = this.TransitInType;
				if (elevelSequenceTransition != ELevelSequenceTransition.Camera)
				{
					if (elevelSequenceTransition == ELevelSequenceTransition.Mask)
					{
						this.DurationInTime = tempInTransit.Duration.GetValueOrDefault();
						this.FadeInInTime = tempInTransit.TransitFadeIn.GetValueOrDefault();
						this.FadeInOutTime = tempInTransit.TransitFadeOut.GetValueOrDefault();
						this.TransitInValid = tempInTransit.IsValid.GetValueOrDefault();
						this.InMask = tempInTransit.Mask;
					}
				}
				else
				{
					this.DurationInTime = tempInTransit.Duration.GetValueOrDefault();
					this.FadeInInTime = tempInTransit.Duration.GetValueOrDefault();
					this.FadeInOutTime = 0f;
					this.TransitInValid = tempInTransit.IsValid.GetValueOrDefault();
				}
			}
			if (tempOutTransit != null)
			{
				this.TransitOutType = tempOutTransit.TransitType;
				ELevelSequenceTransition elevelSequenceTransition = this.TransitOutType;
				if (elevelSequenceTransition != ELevelSequenceTransition.Camera)
				{
					if (elevelSequenceTransition == ELevelSequenceTransition.Mask)
					{
						this.DurationOutTime = tempOutTransit.Duration.GetValueOrDefault();
						this.FadeOutInTime = tempOutTransit.TransitFadeIn.GetValueOrDefault();
						this.FadeOutOutTime = tempOutTransit.TransitFadeOut.GetValueOrDefault();
						this.TransitOutValid = tempOutTransit.IsValid.GetValueOrDefault();
						this.OutMask = tempOutTransit.Mask;
					}
				}
				else
				{
					this.DurationOutTime = tempOutTransit.Duration.GetValueOrDefault();
					this.FadeOutInTime = 0f;
					this.FadeOutOutTime = tempOutTransit.Duration.GetValueOrDefault();
					this.TransitOutValid = tempOutTransit.IsValid.GetValueOrDefault();
				}
			}
			this.JumpToEnd = jumpToEnd;
			this.PlayRateTransition = playRateTransition;
			this.CheckLatestWay();
			this.CheckIsLoadingClosed();
		}

		// Token: 0x06043932 RID: 276786 RVA: 0x0116D4D4 File Offset: 0x0116B6D4
		public double? GetMarkValue(string mark)
		{
			UMovieScene movieScene = this.LevelSequence.GetMovieScene();
			for (int i = 0; i < movieScene.MarkedFrames.Num(); i++)
			{
				if (movieScene.MarkedFrames.Get(i).Label == mark)
				{
					return new double?(this.ChangeToFrame((long)movieScene.MarkedFrames.Get(i).FrameNumber.Value));
				}
			}
			return null;
		}

		// Token: 0x06043933 RID: 276787 RVA: 0x0116D548 File Offset: 0x0116B748
		public void CheckLatestWay()
		{
			if (this.LevelSequence.GetMovieScene() == null)
			{
				return;
			}
			ULevelSequencePlayer sequencePlayer = this.Director.SequencePlayer;
			double value = this.GetMarkValue(this.Mark).Value;
			long num = (long)sequencePlayer.GetStartTime().Time.FrameNumber.Value;
			long num2 = (long)sequencePlayer.GetEndTime().Time.FrameNumber.Value;
			long num3 = (long)sequencePlayer.GetCurrentTime().Time.FrameNumber.Value;
			if (Math.Abs(value - (double)num3) > Math.Abs((double)(num2 - num) - Math.Abs(value - (double)num3)))
			{
				this.ItsWay = EWayType.GotoEndAndTransport;
				return;
			}
			this.ItsWay = EWayType.Normal;
		}

		// Token: 0x06043934 RID: 276788 RVA: 0x0116D5F8 File Offset: 0x0116B7F8
		private double ChangeToFrame(long num)
		{
			UMovieScene movieScene = this.LevelSequence.GetMovieScene();
			return (double)(num * (long)movieScene.DisplayRate.Numerator / (long)movieScene.TickResolution.Numerator);
		}

		// Token: 0x06043935 RID: 276789 RVA: 0x0116D62D File Offset: 0x0116B82D
		public void SetTimeDilation(float customTimeDilation)
		{
			if (this.CustomTimeDilation != customTimeDilation)
			{
				this.CustomTimeDilation = customTimeDilation;
				this.UpdateTimeDilation();
			}
		}

		// Token: 0x06043936 RID: 276790 RVA: 0x0116D648 File Offset: 0x0116B848
		private void UpdateTimeDilation()
		{
			if (this.LastPlayRateEaseHandleId != 0)
			{
				UKuroSequenceRuntimeFunctionLibrary.StopEasingPlayRate(this.Director, this.LastPlayRateEaseHandleId, false);
				this.LastPlayRateEaseHandleId = 0;
			}
			this.Director.SequencePlayer.SetPlayRate(this.CustomTimeDilation * this.CurPlayRate);
		}

		// Token: 0x06043937 RID: 276791 RVA: 0x0116D694 File Offset: 0x0116B894
		public int GetCurrentFrame()
		{
			if (this.Director == null)
			{
				return 0;
			}
			return this.Director.SequencePlayer.GetCurrentTime().Time.FrameNumber.Value;
		}

		// Token: 0x06043938 RID: 276792 RVA: 0x0116D6BF File Offset: 0x0116B8BF
		public bool IsReversePlay()
		{
			return this.ReversedLoop;
		}

		// Token: 0x06043939 RID: 276793 RVA: 0x0116D6C7 File Offset: 0x0116B8C7
		public void StopSequence()
		{
			if (this.Director == null)
			{
				return;
			}
			this.Director.SequencePlayer.Stop();
		}

		// Token: 0x0604393A RID: 276794 RVA: 0x0116D6E2 File Offset: 0x0116B8E2
		public void Pause()
		{
			if (this.Director == null)
			{
				return;
			}
			this.IsPause = true;
			if (this.ItsWay == EWayType.Default)
			{
				return;
			}
			this.Director.SequencePlayer.Pause();
		}

		// Token: 0x0604393B RID: 276795 RVA: 0x0116D70D File Offset: 0x0116B90D
		public void Resume()
		{
			if (this.Director == null)
			{
				return;
			}
			this.IsPause = false;
			if (this.ItsWay == EWayType.Default)
			{
				return;
			}
			this.Director.SequencePlayer.Play();
		}

		// Token: 0x0604393C RID: 276796 RVA: 0x0116D738 File Offset: 0x0116B938
		private void DefaultLevelSequenceAfterTick(float delta)
		{
			ALevelSequenceActor director = this.Director;
			if (director == null || !director.IsValid() || (this.IsPause && !this.ForceTickOneFrameEventPause))
			{
				return;
			}
			this.ForceTickOneFrameEventPause = false;
			this.Director.bOverrideInstanceData = true;
			ULevelSequencePlayer sequencePlayer = this.Director.SequencePlayer;
			this.Character = Global.BaseCharacter;
			if (sequencePlayer != null && sequencePlayer.IsValid())
			{
				TsBaseCharacter character = this.Character;
				if (character != null && character.IsValid())
				{
					if (this.DefaultPlayParam == null)
					{
						return;
					}
					BindTargetSetting bindSetting = this.DefaultPlayParam.BindSetting;
					if (bindSetting.IsBindToTarget())
					{
						this.TempVector.DeepCopy(bindSetting.AttachLocationOffset);
						FName fname = FNameUtil.IsNothing(bindSetting.AttachSocketName) ? Singleton<CharacterNameDefines>.Instance.ROOT : bindSetting.AttachSocketName;
						FVectorDouble fvectorDouble;
						if (fname != Singleton<CharacterNameDefines>.Instance.ROOT)
						{
							FTransformDouble ftransformDouble = this.Character.Mesh.D_GetSocketTransform(fname, ERelativeTransformSpace.RTS_Component);
							FTransformDouble ftransformDouble2 = this.Character.Mesh.D_GetSocketTransform(Singleton<CharacterNameDefines>.Instance.ROOT, ERelativeTransformSpace.RTS_Component);
							fvectorDouble = ftransformDouble.GetLocation();
							FVectorDouble fvectorDouble2 = ftransformDouble2.TransformPosition(fvectorDouble);
							this.TempVector2.DeepCopy(fvectorDouble2);
							this.TempVector.AdditionEqual(this.TempVector2);
						}
						CharacterActorComponent characterActorComponent = this.Character.CharacterActorComponent;
						this.TempRotator.DeepCopy(characterActorComponent.ActorRotationProxy);
						this.TempRotator.Pitch = 0f;
						this.TempRotator.Roll = 0f;
						this.TempRotator.Quaternion(this.TempQuat);
						this.TempQuat.RotateVector(this.TempVector, this.TempVector);
						this.TempVector.AdditionEqual(characterActorComponent.FloorLocation);
						this.TempRotator.AdditionEqual(bindSetting.AttachRotatorOffset);
						this.TempRotator.Quaternion(this.TempQuat);
						if (!this.DefaultPlayParam.HasLastFrameFloorLocationZ)
						{
							this.DefaultPlayParam.HasLastFrameFloorLocationZ = true;
							this.DefaultPlayParam.LastFrameFloorLocationZ = this.TempVector.Z;
						}
						double num = this.DefaultPlayParam.LastFrameFloorLocationZ;
						if (Math.Abs(num - this.TempVector.Z) >= (double)this.DefaultPlayParam.SmoothDelta)
						{
							num = Singleton<MathUtils>.Instance.Lerp(num, this.TempVector.Z, (double)Singleton<MathUtils>.Instance.Clamp(this.DefaultPlayParam.SmoothFactor * delta * 0.001f, 0f, 1f));
							this.DefaultPlayParam.LastFrameFloorLocationZ = num;
						}
						this.TempVector2.DeepCopy(this.TempVector);
						this.TempVector2.Z = num;
						fvectorDouble = this.TempVector2.ToUeVector(false);
						this.TempTransform.SetLocation(fvectorDouble);
						FQuat fquat = this.TempQuat.ToUeQuat();
						this.TempTransform.SetRotation(fquat);
						this.CameraSequenceData.TransformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(this.TempTransform);
					}
					else if (bindSetting.IsBindToTargetAndPutWorld())
					{
						this.TempRotator.DeepCopy(this.DefaultPlayParam.InitPlayerRotator);
						this.TempRotator.Roll = 0f;
						this.TempRotator.Quaternion(this.TempQuat);
						this.TempQuat.RotateVector(bindSetting.SpecificLocationOffset, this.TempVector);
						this.TempVector.AdditionEqual(this.DefaultPlayParam.InitPlayerFloorLocation);
						this.TempRotator.AdditionEqual(bindSetting.SpecificRotatorOffset);
						this.TempRotator.Quaternion(this.TempQuat);
						this.CameraSequenceData.TransformOriginActor = null;
						FVectorDouble fvectorDouble = this.TempVector.ToUeVector(false);
						this.TempTransform.SetLocation(fvectorDouble);
						FQuat fquat = this.TempQuat.ToUeQuat();
						this.TempTransform.SetRotation(fquat);
						this.CameraSequenceData.TransformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(this.TempTransform);
					}
					else if (bindSetting.IsBindToWorld())
					{
						bindSetting.WorldRotation.Quaternion(this.TempQuat);
						FVectorDouble fvectorDouble = bindSetting.WorldLocation.ToUeVector(false);
						this.TempTransform.SetLocation(fvectorDouble);
						FQuat fquat = this.TempQuat.ToUeQuat();
						this.TempTransform.SetRotation(fquat);
						this.CameraSequenceData.TransformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(this.TempTransform);
					}
					this.DefaultPlayParam.PlayedTime += delta * 0.001f;
					sequencePlayer.PlayToSeconds(this.DefaultPlayParam.PlayedTime);
					if (this.DefaultPlayParam.DelayUpdateFrame == this.DefaultPlayParam.MaxDelayUpdateFrame)
					{
						Rotator cameraActorRotator = this.CameraActorRotator;
						FRotator frotator = this.SceneCamera.Camera.K2_GetActorRotation();
						cameraActorRotator.DeepCopy(frotator);
					}
					if (this.DefaultPlayParam.FollowSetting.IsFollowTarget && this.DefaultPlayParam.DelayUpdateFrame >= this.DefaultPlayParam.MaxDelayUpdateFrame)
					{
						this.TempVector2.DeepCopy(this.Character.CharacterActorComponent.FloorLocation);
						Vector tempVector = this.TempVector3;
						FVectorDouble fvectorDouble = this.SceneCamera.Camera.D_K2_GetActorLocation();
						tempVector.DeepCopy(fvectorDouble);
						this.TempVector2.SubtractionEqual(this.TempVector3);
						this.TempVector2.Normalize(9.99999993922529E-09);
						this.TempVector2.Rotation(this.TempRotator);
						this.CameraActorRotator.Vector(this.TempVector4);
						if (this.DefaultPlayParam.FollowSetting.IsFollowTargetAngle)
						{
							Quat.FindBetween(this.TempVector2, this.TempVector4, this.TempQuat);
							float num2 = (float)(Math.Acos(Vector.DotProduct(this.TempVector2, this.TempVector4)) * 57.295780181884766);
							float num3 = this.DefaultPlayParam.FollowSetting.AngleFollowSpeed * delta * 0.001f;
							float num4 = (num3 > 1f || num3 < 0f) ? num2 : (num2 * num3);
							float alpha = Singleton<MathUtils>.Instance.Clamp(num4 / num2, 0f, 1f);
							Singleton<MathUtils>.Instance.SqLerpVector(this.TempVector4, this.TempVector2, alpha, this.TempVector2);
							this.TempVector2.Rotation(this.CameraActorRotator);
						}
						else if (this.DefaultPlayParam.FollowSetting.IsFollowTargetPitch)
						{
							float pitch = this.TempRotator.Pitch;
							float pitch2 = this.CameraActorRotator.Pitch;
							float num5 = Singleton<MathUtils>.Instance.WrapAngle(pitch - pitch2);
							float num6 = this.DefaultPlayParam.FollowSetting.PitchFollowSpeed * delta * 0.001f;
							float num7 = (num6 > 1f || num6 < 0f) ? num5 : (num5 * num6);
							this.CameraActorRotator.Pitch = Singleton<MathUtils>.Instance.WrapAngle(pitch2 + num7);
						}
						else if (this.DefaultPlayParam.FollowSetting.IsFollowTargetYaw)
						{
							float yaw = this.TempRotator.Yaw;
							float yaw2 = this.CameraActorRotator.Yaw;
							float num8 = Singleton<MathUtils>.Instance.WrapAngle(yaw - yaw2);
							float num9 = this.DefaultPlayParam.FollowSetting.YawFollowSpeed * delta * 0.001f;
							double num10 = (double)((num9 > 1f || num9 < 0f) ? num8 : (num8 * num9));
							this.CameraActorRotator.Yaw = (float)Singleton<MathUtils>.Instance.WrapAngle((double)yaw2 + num10);
						}
						this.SceneCamera.Camera.K2_SetActorRotation(this.CameraActorRotator.ToUeRotator(), true);
					}
					this.DefaultPlayParam.DelayUpdateFrame++;
					if (this.ProcessCollistion())
					{
						this.IsSequenceStopWithFinish = true;
						this.StopSequence();
					}
					if (this.DefaultPlayParam.PlayedTime >= this.DefaultPlayParam.TimeLength)
					{
						this.IsSequenceStopWithFinish = true;
						this.StopSequence();
					}
					return;
				}
			}
		}

		// Token: 0x0604393D RID: 276797 RVA: 0x0116DF0C File Offset: 0x0116C10C
		private bool ProcessCollistion()
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter != null && baseCharacter.IsValid())
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				if (characterActorComponent != null && characterActorComponent.Valid)
				{
					SceneSubCamera sceneCamera = this.SceneCamera;
					bool flag;
					if (sceneCamera == null)
					{
						flag = true;
					}
					else
					{
						BP_CineCamera_C camera = sceneCamera.Camera;
						flag = !((camera != null) ? new bool?(camera.IsValid()) : null).GetValueOrDefault();
					}
					if (!flag)
					{
						this.GenerateSphereTrace();
						this.CameraSphereTrace.ActorsToIgnore.Empty(true);
						this.CameraSphereTrace.ActorsToIgnore.Add(baseCharacter);
						Vector tempVector = this.TempVector;
						FVectorDouble fvectorDouble = this.SceneCamera.Camera.D_K2_GetActorLocation();
						tempVector.FromUeVector(fvectorDouble);
						Singleton<TraceElementCommon>.Instance.SetStartLocation(this.CameraSphereTrace, baseCharacter.CharacterActorComponent.ActorLocationProxy);
						Singleton<TraceElementCommon>.Instance.SetEndLocation(this.CameraSphereTrace, this.TempVector);
						return Singleton<TraceElementCommon>.Instance.SphereTrace(this.CameraSphereTrace, "SimpleLevelSequenceActor_CheckCollision_Camera");
					}
				}
			}
			return false;
		}

		// Token: 0x04025C06 RID: 154630
		[Nullable(2)]
		private ULevelSequence LevelSequence;

		// Token: 0x04025C07 RID: 154631
		[Nullable(2)]
		private ALevelSequenceActor Director;

		// Token: 0x04025C08 RID: 154632
		[Nullable(2)]
		private AActor TransformOriginActor;

		// Token: 0x04025C09 RID: 154633
		[Nullable(2)]
		private UDefaultLevelSequenceInstanceData CameraSequenceData;

		// Token: 0x04025C0A RID: 154634
		[Nullable(2)]
		private TsBaseCharacter Character;

		// Token: 0x04025C0B RID: 154635
		private readonly TArray<AActor> BindingActors = new TArray<AActor>();

		// Token: 0x04025C0C RID: 154636
		private float FadeInInTime;

		// Token: 0x04025C0D RID: 154637
		private float FadeInOutTime;

		// Token: 0x04025C0E RID: 154638
		private float FadeOutInTime;

		// Token: 0x04025C0F RID: 154639
		private float FadeOutOutTime;

		// Token: 0x04025C10 RID: 154640
		private float DurationInTime;

		// Token: 0x04025C11 RID: 154641
		private float DurationOutTime;

		// Token: 0x04025C12 RID: 154642
		private ELevelSequenceTransition TransitInType;

		// Token: 0x04025C13 RID: 154643
		private ELevelSequenceTransition TransitOutType;

		// Token: 0x04025C14 RID: 154644
		private bool TransitInValid;

		// Token: 0x04025C15 RID: 154645
		private bool TransitOutValid;

		// Token: 0x04025C16 RID: 154646
		private readonly bool HasCameraTrack;

		// Token: 0x04025C17 RID: 154647
		private bool JumpToEnd;

		// Token: 0x04025C18 RID: 154648
		private string Mark = "";

		// Token: 0x04025C19 RID: 154649
		private string LoopStartMark = "";

		// Token: 0x04025C1A RID: 154650
		private bool ReversedLoop;

		// Token: 0x04025C1B RID: 154651
		private int NumLoops = -1;

		// Token: 0x04025C1C RID: 154652
		private float CurPlayRate = 1f;

		// Token: 0x04025C1D RID: 154653
		[Nullable(2)]
		private RefCompDefine.PlayRateStruct PlayRateTransition;

		// Token: 0x04025C1E RID: 154654
		private int LastPlayRateEaseHandleId;

		// Token: 0x04025C1F RID: 154655
		private bool CameraBindFinished;

		// Token: 0x04025C20 RID: 154656
		private bool IsKeepUi;

		// Token: 0x04025C21 RID: 154657
		private bool CanPlayInLoading;

		// Token: 0x04025C22 RID: 154658
		private bool IsPause;

		// Token: 0x04025C23 RID: 154659
		private bool ForceTickOneFrameEventPause;

		// Token: 0x04025C24 RID: 154660
		private EWayType ItsWay = EWayType.Normal;

		// Token: 0x04025C25 RID: 154661
		[Nullable(2)]
		private SceneSubCamera SceneCamera;

		// Token: 0x04025C26 RID: 154662
		private bool IsForcedSceneCamera;

		// Token: 0x04025C27 RID: 154663
		private ETransitionMask? InMask = new ETransitionMask?(ETransitionMask.BlackMask);

		// Token: 0x04025C28 RID: 154664
		private ETransitionMask? OutMask = new ETransitionMask?(ETransitionMask.BlackMask);

		// Token: 0x04025C29 RID: 154665
		private bool LockBySimpleLevelSequence;

		// Token: 0x04025C2A RID: 154666
		private float CustomTimeDilation = 1f;

		// Token: 0x04025C2B RID: 154667
		private bool UiSequence;

		// Token: 0x04025C2C RID: 154668
		[Nullable(2)]
		private DefaultLevelSequencePlayParam DefaultPlayParam;

		// Token: 0x04025C2D RID: 154669
		private int DefaultPlayAfterTickId = -1;

		// Token: 0x04025C2E RID: 154670
		private bool IsSequenceStopWithFinish;

		// Token: 0x04025C2F RID: 154671
		[Nullable(2)]
		private UTraceSphereElement CameraSphereTrace;

		// Token: 0x04025C30 RID: 154672
		private readonly Rotator CameraActorRotator = Rotator.Create();

		// Token: 0x04025C31 RID: 154673
		private readonly Rotator TempRotator = Rotator.Create();

		// Token: 0x04025C32 RID: 154674
		private readonly Quat TempQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x04025C33 RID: 154675
		private readonly Vector TempVector = Vector.Create();

		// Token: 0x04025C34 RID: 154676
		private readonly Vector TempVector2 = Vector.Create();

		// Token: 0x04025C35 RID: 154677
		private readonly Vector TempVector3 = Vector.Create();

		// Token: 0x04025C36 RID: 154678
		private readonly Vector TempVector4 = Vector.Create();

		// Token: 0x04025C37 RID: 154679
		private FTransformDouble TempTransform;

		// Token: 0x04025C38 RID: 154680
		[Nullable(2)]
		private Action OnPauseCallback;

		// Token: 0x04025C39 RID: 154681
		[Nullable(2)]
		private Action<bool> OnStopCallback;

		// Token: 0x04025C3A RID: 154682
		[Nullable(2)]
		private Action OnFinishedCallback;
	}
}
