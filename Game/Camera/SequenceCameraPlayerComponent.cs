using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Sequence;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070B9 RID: 28857
	[NullableContext(1)]
	[Nullable(0)]
	public class SequenceCameraPlayerComponent : EntityComponent
	{
		// Token: 0x1700A5D9 RID: 42457
		// (get) Token: 0x06045F48 RID: 286536 RVA: 0x012555B4 File Offset: 0x012537B4
		public bool IsDitherEffectEnabled
		{
			get
			{
				return this.DitherEffectEnableSet.Count > 0;
			}
		}

		// Token: 0x06045F49 RID: 286537 RVA: 0x012555C4 File Offset: 0x012537C4
		public void SetPlayCameraSequenceEnabled(bool enabled)
		{
			this.IsPlayCameraSequenceEnabled = enabled;
		}

		// Token: 0x06045F4A RID: 286538 RVA: 0x012555CD File Offset: 0x012537CD
		public void SetDitherEffectEnable(ESequenceCameraDitherEffectEnum ditherEffectEnum)
		{
			this.DitherEffectEnableSet.Add(ditherEffectEnum);
		}

		// Token: 0x06045F4B RID: 286539 RVA: 0x012555DC File Offset: 0x012537DC
		public void SetDitherEffectDisable(ESequenceCameraDitherEffectEnum ditherEffectEnum)
		{
			this.DitherEffectEnableSet.Remove(ditherEffectEnum);
		}

		// Token: 0x06045F4C RID: 286540 RVA: 0x012555EC File Offset: 0x012537EC
		[NullableContext(2)]
		public void SetPawn(APawn pawn)
		{
			TsBaseCharacter tsBaseCharacter = pawn as TsBaseCharacter;
			if (tsBaseCharacter != null)
			{
				this.SetCharacter(tsBaseCharacter);
			}
		}

		// Token: 0x06045F4D RID: 286541 RVA: 0x0125560A File Offset: 0x0125380A
		public void SetCharacter(TsBaseCharacter character)
		{
			TsBaseCharacter oldCharacter = this.OldCharacter;
			if (oldCharacter != null && oldCharacter.IsValid())
			{
				this.OldCharacter = character;
				return;
			}
			this.Character = character;
		}

		// Token: 0x06045F4E RID: 286542 RVA: 0x0125562F File Offset: 0x0125382F
		[NullableContext(2)]
		protected override bool OnCreate(IEntityArgs args = null)
		{
			this.CameraModelInstanceInternal = ((args != null) ? args.GetP1<CameraModelInstance>() : null);
			return base.OnCreate(args);
		}

		// Token: 0x06045F4F RID: 286543 RVA: 0x0125564C File Offset: 0x0125384C
		public bool PlayCameraSequence(SSequenceCamera_Settings settings, bool resetFightCamera, FRotator additiveRotation, TsBaseCharacter target, FName socketName, FName lockSocketName, FVector relativeLocation, float radius, bool isShowLine, bool ignoreCharacterCollision = false, bool disableMovementInput = true, bool disableLookAtInput = true, bool disableMotionBlur = false, bool isIgnoreInitialSphereDetect = false, [Nullable(2)] SSequenceCamera_SpecificConfig specificConfig = null, int? skillEntityId = null, long? skillId = null)
		{
			if (!this.IsPlayCameraSequenceEnabled)
			{
				return false;
			}
			if (this.IsInCinematic)
			{
				if (!this.CheckBreakSequence(this.Character, target))
				{
					return false;
				}
				this.StopSequence();
			}
			if (this.DisplayComponent.CineCamera.GetAttachParentActor() != null)
			{
				this.DisplayComponent.CineCamera.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
			}
			this.ShowLog = isShowLine;
			this.RelativeLocation.FromUeVector(relativeLocation);
			this.CheckRadius = radius;
			this.OldCharacter = this.Character;
			this.Character = target;
			this.LockSocketName = lockSocketName;
			this.SocketName = socketName;
			this.IsEnableFrameAbstract = (settings.FrameAbstract.EnableFrameAbstract && settings.FrameAbstract.EnableFrameAbstractDelta > 0.05f);
			this.FrameAbstractDelta = settings.FrameAbstract.EnableFrameAbstractDelta;
			this.FrameAbstractTime = -1;
			this.CameraTransformTrack = (this.IsEnableFrameAbstract ? SequenceUtils.GetLevelSequenceTransformTrack(settings.CameraSequence, SequenceCameraPlayerComponent.SequenceCamera) : null);
			this.IsAttachToActor = this.IsEnableFrameAbstract;
			if (!this.IsAttachToActor && !FNameUtil.IsEmpty(new FName?(this.SocketName)))
			{
				AActor transformOriginActor = this.TransformOriginActor;
				if (transformOriginActor == null || !transformOriginActor.IsValid())
				{
					this.TransformOriginActor = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true);
					if (this.TransformOriginActor.K2_GetRootComponent() == null)
					{
						AActor transformOriginActor2 = this.TransformOriginActor;
						TSubclassOf<UActorComponent> @class = USceneComponent.StaticClass();
						bool bManualAttachment = false;
						FTransformDouble ftransformDouble = this.TransformOriginActor.D_GetTransform();
						transformOriginActor2.D_AddComponentByClass(@class, bManualAttachment, ftransformDouble, false, default(FName));
					}
				}
				this.TransformOriginActor.K2_AttachToComponent(this.Character.Mesh, this.SocketName, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
			}
			this.SetupCameraSequence(settings, disableMovementInput, disableLookAtInput, specificConfig);
			bool flag = this.Play(isIgnoreInitialSphereDetect, ignoreCharacterCollision);
			this.ResetFightCameraOnStop = resetFightCamera;
			this.ResetAdditiveRotation = new FRotator?(additiveRotation);
			if (flag)
			{
				this.BindSkillEndEvent(settings.IsFinishBySkillInterrupt, skillEntityId, skillId);
				this.HideHud(settings);
				Singleton<EventSystem>.Instance.Emit<bool, string>(EEventName.OnSequenceCameraStatus, true, this.CameraModelInstanceInternal.CameraName);
				ControllerBase<CameraNearClipController>.Instance.EnableSequenceCameraPlayerComponentNearClip(1f);
				Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.ZWY, "进入Sequence相机，最小近裁面", default(ReadOnlySpan<ValueTuple<string, object>>));
				if (disableMotionBlur)
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.MotionBlur.Amount 0", null);
				}
			}
			Singleton<EventSystem>.Instance.Emit<ULevelSequence, AActor, ALevelSequenceActor, FTransformDouble, bool, bool, string>(EEventName.PlayCameraLevelSequence, settings.CameraSequence, target, this.CameraSequenceActor, CameraUtility.GetRootTransform(target), flag, settings.IsStopModify, this.CameraModelInstanceInternal.CameraName);
			return flag;
		}

		// Token: 0x06045F50 RID: 286544 RVA: 0x012558E4 File Offset: 0x01253AE4
		private void BindSkillEndEvent(bool isFinishBySkillInterrupt, int? skillEntityId, long? skillId)
		{
			this.UnbindSkillEndEvent();
			if (skillEntityId == null || skillId == null)
			{
				return;
			}
			if (!isFinishBySkillInterrupt)
			{
				return;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(skillEntityId.Value);
			if (entity == null)
			{
				return;
			}
			this.BindSkillEntity = entity;
			this.BindSkillId = skillId;
			Singleton<EventSystem>.Instance.AddWithTarget(entity, EEventName.CharInterruptSkill, new Action<int, int>(this.OnCharInterruptSkill));
		}

		// Token: 0x06045F51 RID: 286545 RVA: 0x0125594C File Offset: 0x01253B4C
		private void UnbindSkillEndEvent()
		{
			if (this.BindSkillEntity != null && Singleton<EventSystem>.Instance.HasWithTarget(this.BindSkillEntity, EEventName.CharInterruptSkill, new Action<int, int>(this.OnCharInterruptSkill)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.BindSkillEntity, EEventName.CharInterruptSkill, new Action<int, int>(this.OnCharInterruptSkill));
			}
			this.BindSkillEntity = null;
			this.BindSkillId = null;
		}

		// Token: 0x06045F52 RID: 286546 RVA: 0x012559B4 File Offset: 0x01253BB4
		private void OnCharInterruptSkill(int skillEntityId, int skillId)
		{
			if (this.BindSkillEntity != null && this.BindSkillEntity.Id == skillEntityId)
			{
				long? bindSkillId = this.BindSkillId;
				long num = (long)skillId;
				if (bindSkillId.GetValueOrDefault() == num & bindSkillId != null)
				{
					Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.ZJL, "绑定的技能被打断，停止Sequence相机", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.StopSequence();
				}
			}
		}

		// Token: 0x06045F53 RID: 286547 RVA: 0x01255A17 File Offset: 0x01253C17
		public void StopSequence()
		{
			this.SequenceStopInternal();
		}

		// Token: 0x06045F54 RID: 286548 RVA: 0x01255A1F File Offset: 0x01253C1F
		public void SetBlendTime(float inBlendIn, float inBlendOut)
		{
			this.SequenceCameraBlendInTime = inBlendIn;
			this.SequenceCameraBlendOutTime = inBlendOut;
		}

		// Token: 0x06045F55 RID: 286549 RVA: 0x01255A2F File Offset: 0x01253C2F
		[NullableContext(2)]
		public ALevelSequenceActor GetCurrentLevelSequenceActor()
		{
			return this.CameraSequenceActor;
		}

		// Token: 0x06045F56 RID: 286550 RVA: 0x01255A37 File Offset: 0x01253C37
		public bool GetIsInCinematic()
		{
			return this.IsInCinematic;
		}

		// Token: 0x06045F57 RID: 286551 RVA: 0x01255A3F File Offset: 0x01253C3F
		[NullableContext(2)]
		public TsBaseCharacter GetCharacter()
		{
			return this.Character;
		}

		// Token: 0x06045F58 RID: 286552 RVA: 0x01255A48 File Offset: 0x01253C48
		public void ResetCameraRatioSetting()
		{
			SequenceCameraDisplayComponent displayComponent = this.DisplayComponent;
			UCineCameraComponent ucineCameraComponent;
			if (displayComponent == null)
			{
				ucineCameraComponent = null;
			}
			else
			{
				BP_CineCamera_C cineCamera = displayComponent.CineCamera;
				ucineCameraComponent = ((cineCamera != null) ? cineCamera.GetCineCameraComponent() : null);
			}
			UCineCameraComponent ucineCameraComponent2 = ucineCameraComponent;
			if (ucineCameraComponent2 == null)
			{
				return;
			}
			string defaultFilmbackPresetName = ucineCameraComponent2.GetDefaultFilmbackPresetName();
			ucineCameraComponent2.SetFilmbackPresetByName(defaultFilmbackPresetName);
			ucineCameraComponent2.bConstrainAspectRatio = false;
		}

		// Token: 0x06045F59 RID: 286553 RVA: 0x01255A8D File Offset: 0x01253C8D
		protected override bool OnStart()
		{
			this.InitTraceElements();
			this.DisplayComponent = base.Entity.GetComponent<SequenceCameraDisplayComponent>();
			return this.DisplayComponent.Valid;
		}

		// Token: 0x06045F5A RID: 286554 RVA: 0x01255AB4 File Offset: 0x01253CB4
		private void InitTraceElements()
		{
			this.SphereSingle = new UTraceSphereElement();
			this.SphereSingle.bIsSingle = true;
			this.SphereSingle.bIgnoreSelf = true;
			this.SphereSingle.SetTraceTypeQuery(KuroTraceTypeQuery.Camera);
			this.SphereMultiply = new UTraceSphereElement();
			this.SphereMultiply.bIsSingle = false;
			this.SphereMultiply.bIgnoreSelf = true;
			this.SphereMultiply.ActorsToIgnore = this.IgnoreActors;
			this.SphereMultiply.AddObjectTypeQuery(KuroObjectTypeQuery.Pawn);
			this.SphereMultiply.AddObjectTypeQuery(KuroObjectTypeQuery.PawnPlayer);
			this.SphereMultiply.AddObjectTypeQuery(KuroObjectTypeQuery.PawnMonster);
			this.CameraSphereTrace = new UTraceSphereElement();
			this.CameraSphereTrace.bIsSingle = true;
			this.CameraSphereTrace.bIgnoreSelf = true;
			this.CameraSphereTrace.bTraceComplex = true;
			this.CameraSphereTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Camera);
			this.CameraCheckSphereTrace = new UTraceSphereElement();
			this.CameraCheckSphereTrace.bIsSingle = true;
			this.CameraCheckSphereTrace.bIgnoreSelf = true;
			this.CameraCheckSphereTrace.bTraceComplex = true;
			if (this.ShowLog)
			{
				this.CameraCheckSphereTrace.DrawTime = 5f;
				this.CameraCheckSphereTrace.SetDrawDebugTrace(EDrawDebugTrace.ForDuration);
			}
			this.CameraCheckSphereTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Camera);
		}

		// Token: 0x06045F5B RID: 286555 RVA: 0x01255BFC File Offset: 0x01253DFC
		protected override bool OnEnd()
		{
			this.UnbindSkillEndEvent();
			this.DisplayComponent = null;
			this.BindingActors.Empty(true);
			if (this.CameraSequenceActor != null)
			{
				ULevelSequencePlayer sequencePlayer = this.CameraSequenceActor.SequencePlayer;
				if (sequencePlayer != null)
				{
					sequencePlayer.OnStop.Clear();
				}
				ALevelSequenceActor tmp = this.CameraSequenceActor;
				TimerSystem.Instance.Next(delegate(float _)
				{
					Singleton<ActorSystem>.Instance.Put("SequenceCameraPlayerComponent.OnEnd", tmp, null);
				}, null, null);
				this.CameraSequenceActor = null;
			}
			this.CameraSequence = null;
			this.LevelSequenceData = null;
			this.AnimInstance = null;
			this.OriginRootTransform = null;
			this.CharacterMoveComponent = null;
			this.SequenceCameraBlendInTime = 1f;
			this.SequenceCameraBlendOutTime = 1f;
			this.NeedWaitInPlot = false;
			this.IsInCinematic = false;
			if (this.IsHideHud)
			{
				ModelBase<BattleUiModel>.Instance.ChildViewData.ShowBattleView(EBattleUiVisibleReason.CameraSeq, 0);
				Singleton<UiLayer>.Instance.SetLayerRenderable(ELayerType.Float, true, "SeqCamera");
				Singleton<UiLayer>.Instance.SetLayerRenderable(ELayerType.Pop, true, "SeqCamera");
				Singleton<UiLayer>.Instance.SetLayerRenderable(ELayerType.Guide, true, "SeqCamera");
				Singleton<EventSystem>.Instance.Emit<bool, string>(EEventName.OnCameraSequenceSetUiVisible, true, this.CameraModelInstanceInternal.CameraName);
			}
			return true;
		}

		// Token: 0x06045F5C RID: 286556 RVA: 0x01255D38 File Offset: 0x01253F38
		protected override void OnAfterTick(float delta)
		{
			if (this.CameraSequenceActor != null)
			{
				TsBaseCharacter character = this.Character;
				if (character == null || !character.IsValid() || !this.GetTargetCharacter().IsValid())
				{
					this.StopSequence();
					return;
				}
				int entityIdNoBlueprint = this.Character.GetEntityIdNoBlueprint();
				if (entityIdNoBlueprint == 0 || Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint) == null)
				{
					this.StopSequence();
					return;
				}
			}
			if (this.LevelSequenceData == null || this.AnimInstance == null || this.OriginRootTransform == null)
			{
				if (this.BlendingOutRestTime > 0f)
				{
					this.BlendingOutRestTime = Math.Max(0f, this.BlendingOutRestTime - delta * 0.001f);
					this.ProcessSocketTransform();
					this.CheckCollision(true);
				}
				return;
			}
			this.ProcessPlatformMoving();
			this.ProcessTimeScale();
			this.PlayedTime += delta * 0.001f * this.PlaySpeed;
			this.CameraSequenceActor.SequencePlayer.PlayToSeconds(this.PlayedTime);
			this.ProcessSocketTransform();
			this.ProcessIkOffset();
			this.ProcessMeshPosition();
			this.CheckCollision(false);
			this.ProcessDitherEffect();
			if (this.PlayedTime >= this.TimeLength)
			{
				this.SequenceStopInternal();
				return;
			}
			if (this.IsHideHud && this.HideHudTime > 0f && this.PlayedTime >= this.HideHudTime)
			{
				ModelBase<BattleUiModel>.Instance.ChildViewData.ShowBattleView(EBattleUiVisibleReason.CameraSeq, 0);
				Singleton<UiLayer>.Instance.SetLayerRenderable(ELayerType.Float, true, "SeqCamera");
				Singleton<UiLayer>.Instance.SetLayerRenderable(ELayerType.Pop, true, "SeqCamera");
				Singleton<UiLayer>.Instance.SetLayerRenderable(ELayerType.Guide, true, "SeqCamera");
				Singleton<EventSystem>.Instance.Emit<bool, string>(EEventName.OnCameraSequenceSetUiVisible, true, this.CameraModelInstanceInternal.CameraName);
				this.IsHideHud = false;
			}
		}

		// Token: 0x06045F5D RID: 286557 RVA: 0x01255EF8 File Offset: 0x012540F8
		private void ProcessTimeScale()
		{
			TsBaseCharacter character = this.Character;
			float? num;
			if (character == null)
			{
				num = null;
			}
			else
			{
				Entity entityNoBlueprint = character.GetEntityNoBlueprint();
				if (entityNoBlueprint == null)
				{
					num = null;
				}
				else
				{
					PawnTimeScaleComponent component = entityNoBlueprint.GetComponent<PawnTimeScaleComponent>();
					num = ((component != null) ? new float?(component.CurrentTimeScale) : null);
				}
			}
			float? num2 = num;
			this.PlaySpeed = num2.GetValueOrDefault(1f);
		}

		// Token: 0x06045F5E RID: 286558 RVA: 0x01255F5F File Offset: 0x0125415F
		private TsBaseCharacter GetTargetCharacter()
		{
			return (this.Target ?? ControllerBase<CameraController>.Instance.GetCharacter()) as TsBaseCharacter;
		}

		// Token: 0x06045F5F RID: 286559 RVA: 0x01255F7C File Offset: 0x0125417C
		private void SetupCameraSequence(SSequenceCamera_Settings settings, bool disableMovementInput = true, bool disableLookAtInput = true, [Nullable(2)] SSequenceCamera_SpecificConfig specificConfig = null)
		{
			this.IsEnableCollision = true;
			this.SequenceCameraBlendInTime = settings.BlendInTime;
			this.SequenceCameraBlendOutTime = settings.BlendOutTime;
			this.NeedWaitInPlot = settings.NeedWaitInPlot;
			this.CameraSequence = settings.CameraSequence;
			if (this.CameraSequence == null)
			{
				return;
			}
			this.ResetCameraRatioSetting();
			SequenceCameraDisplayComponent displayComponent = this.DisplayComponent;
			if (displayComponent != null)
			{
				BP_CineCamera_C cineCamera = displayComponent.CineCamera;
				if (cineCamera != null)
				{
					cineCamera.ResetSeqCineCamSetting();
				}
			}
			FMovieSceneSequencePlaybackSettings fmovieSceneSequencePlaybackSettings = new FMovieSceneSequencePlaybackSettings();
			fmovieSceneSequencePlaybackSettings.bDisableMovementInput = disableMovementInput;
			fmovieSceneSequencePlaybackSettings.bDisableLookAtInput = disableLookAtInput;
			this.CameraSequenceActor = (Singleton<ActorSystem>.Instance.Get(ALevelSequenceActor.StaticClass(), new FTransformDouble(), null, false) as ALevelSequenceActor);
			this.CameraSequenceActor.PlaybackSettings = fmovieSceneSequencePlaybackSettings;
			this.CameraSequenceActor.SetSequence(this.CameraSequence);
			FQualifiedFrameTime startTime = this.CameraSequenceActor.SequencePlayer.GetStartTime();
			this.PlayedTime = ((float)startTime.Time.FrameNumber.Value + startTime.Time.SubFrame) * (float)startTime.Rate.Denominator / (float)startTime.Rate.Numerator;
			FQualifiedFrameTime endTime = this.CameraSequenceActor.SequencePlayer.GetEndTime();
			this.TimeLength = ((float)endTime.Time.FrameNumber.Value + endTime.Time.SubFrame) * (float)endTime.Rate.Denominator / (float)endTime.Rate.Numerator;
			if (settings.EnableSpecificSequenceTime)
			{
				this.TimeLength = Math.Min(this.TimeLength, settings.SpecificSequenceTime);
			}
			this.IsRecoverRotation = false;
			if (specificConfig != null)
			{
				this.TimeLength = Math.Min(this.TimeLength, specificConfig.OverrideSequenceTime);
				this.SequenceCameraBlendOutTime = specificConfig.OverrideBlendOutTime;
				if (specificConfig.IsRecoverRotation)
				{
					this.IsRecoverRotation = true;
					Rotator cameraRotator = this.CameraModelInstanceInternal.CameraRotator;
					this.RecoverRotation = new FRotator?(new FRotator(cameraRotator.Pitch, cameraRotator.Yaw, cameraRotator.Roll));
				}
			}
			this.SphereSingle.WorldContextObject = GlobalData.World;
			this.SphereMultiply.WorldContextObject = GlobalData.World;
			this.BindActors();
		}

		// Token: 0x06045F60 RID: 286560 RVA: 0x01256194 File Offset: 0x01254394
		private void HideHud(SSequenceCamera_Settings settings)
		{
			this.IsHideHud = settings.IsHideHud;
			if (this.IsHideHud)
			{
				this.HideHudTime = settings.HideHudTime;
				TArray<TEnumAsByte<EBattleUIChild>> visibleChild = settings.VisibleChild;
				int num = visibleChild.Num();
				if (num <= 0)
				{
					ModelBase<BattleUiModel>.Instance.ChildViewData.HideBattleView(EBattleUiVisibleReason.CameraSeq, null, 0);
				}
				else
				{
					List<EBattleUiChild> list = new List<EBattleUiChild>();
					for (int i = 0; i < num; i++)
					{
						list.Add((EBattleUiChild)visibleChild.Get(i));
					}
					ModelBase<BattleUiModel>.Instance.ChildViewData.HideBattleView(EBattleUiVisibleReason.CameraSeq, list, 0);
				}
				Singleton<UiLayer>.Instance.SetLayerRenderable(ELayerType.Float, false, "SeqCamera");
				Singleton<UiLayer>.Instance.SetLayerRenderable(ELayerType.Pop, false, "SeqCamera");
				Singleton<UiLayer>.Instance.SetLayerRenderable(ELayerType.Guide, false, "SeqCamera");
				Singleton<EventSystem>.Instance.Emit<bool, string>(EEventName.OnCameraSequenceSetUiVisible, false, this.CameraModelInstanceInternal.CameraName);
			}
		}

		// Token: 0x06045F61 RID: 286561 RVA: 0x01256278 File Offset: 0x01254478
		private void BindActors()
		{
			if (this.CameraSequenceActor == null)
			{
				return;
			}
			this.BindingActors.Add(this.DisplayComponent.CineCamera);
			this.CameraSequenceActor.SetBindingByTag(SequenceCameraPlayerComponent.SequenceCamera, this.BindingActors, false, false);
			this.BindingActors.Empty(true);
			if (this.Character != null)
			{
				this.BindingCharacterActors.Add(this.Character);
				this.CameraSequenceActor.SetBindingByTag(SequenceCameraPlayerComponent.RoleTag, this.BindingCharacterActors, false, false);
				this.BindingCharacterActors.Empty(true);
			}
		}

		// Token: 0x06045F62 RID: 286562 RVA: 0x01256308 File Offset: 0x01254508
		private bool Play(bool isIgnoreInitialSphereDetect, bool ignoreCharacterCollision)
		{
			bool result = false;
			if (!isIgnoreInitialSphereDetect && (this.CheckCameraLocation(ignoreCharacterCollision) || this.CheckSphereCollision()))
			{
				this.SequenceStopInternal();
			}
			else if (this.ActivateCamera())
			{
				this.PlaySequence();
				result = true;
			}
			else
			{
				this.SequenceStopInternal();
			}
			return result;
		}

		// Token: 0x06045F63 RID: 286563 RVA: 0x0125634C File Offset: 0x0125454C
		private bool CheckCameraLocation(bool ignoreCharacterCollision)
		{
			UMovieScene3DTransformTrack umovieScene3DTransformTrack = UKuroStaticLibrary.GetTrackByClass(UKuroStaticLibrary.GetSequenceTracksForObjectBindingID(this.CameraSequenceActor, SequenceCameraPlayerComponent.SequenceCamera), UMovieScene3DTransformTrack.StaticClass()) as UMovieScene3DTransformTrack;
			if (umovieScene3DTransformTrack == null)
			{
				return false;
			}
			FVectorDouble fvectorDouble = UKuroStaticLibrary.D_GetFirstLocationFromSeqTrack(umovieScene3DTransformTrack);
			TsBaseCharacter targetCharacter = this.GetTargetCharacter();
			FVectorDouble fvectorDouble2 = CameraUtility.GetRootTransform(targetCharacter).TransformPosition(fvectorDouble);
			this.SphereSingle.Radius = this.CameraModelInstanceInternal.FightCamera.LogicComponent.CollisionProbeSize;
			this.SphereSingle.ActorsToIgnore.Empty(true);
			if (ignoreCharacterCollision)
			{
				this.SphereSingle.ActorsToIgnore.Add(ControllerBase<CameraController>.Instance.GetCharacter());
			}
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.SphereSingle, fvectorDouble2);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.SphereSingle, fvectorDouble2);
			bool flag = Singleton<TraceElementCommon>.Instance.SphereTrace(this.SphereSingle, "SequenceCameraPlayerComponent_CheckCameraLocation");
			if (flag)
			{
				UKuroHitResult hitResult = this.SphereSingle.HitResult;
				TWeakObjectPtr<AActor>? tweakObjectPtr = (hitResult != null) ? new TWeakObjectPtr<AActor>?(hitResult.Actors.Get(0)) : null;
				if (((tweakObjectPtr != null) ? tweakObjectPtr.GetValueOrDefault() : null) == targetCharacter)
				{
					Singleton<Log>.Instance.Warn(ELogModule.Camera, ELogAuthor.LJM, "Seq相机初始位置与角色碰撞，请检查Seq的相机初始位置", default(ReadOnlySpan<ValueTuple<string, object>>));
					return false;
				}
			}
			return flag;
		}

		// Token: 0x06045F64 RID: 286564 RVA: 0x012564A4 File Offset: 0x012546A4
		private bool ActivateCamera()
		{
			if (this.CameraSequence == null)
			{
				return false;
			}
			TsBaseCharacter targetCharacter = this.GetTargetCharacter();
			if (targetCharacter == null)
			{
				return false;
			}
			if (this.CameraSequenceActor == null)
			{
				return false;
			}
			CharacterAnimationComponent component = targetCharacter.CharacterActorComponent.Entity.GetComponent<CharacterAnimationComponent>();
			if (component != null && component.Valid)
			{
				component.StopModelBuffer();
			}
			this.CameraSequenceActor.bOverrideInstanceData = true;
			UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData = this.CameraSequenceActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
			if (udefaultLevelSequenceInstanceData == null)
			{
				return false;
			}
			this.LevelSequenceData = udefaultLevelSequenceInstanceData;
			this.OriginRootTransform = new FTransformDouble?(CameraUtility.GetRootTransform(targetCharacter));
			BaseMoveComponent characterMoveComponent;
			if (targetCharacter == null)
			{
				characterMoveComponent = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = targetCharacter.CharacterActorComponent;
				characterMoveComponent = ((characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<BaseMoveComponent>() : null);
			}
			this.CharacterMoveComponent = characterMoveComponent;
			if (component != null && component.Valid)
			{
				UAnimInstance mainAnimInstance = component.MainAnimInstance;
				if (UKuroStaticLibrary.IsObjectClassByName(mainAnimInstance, Singleton<CharacterNameDefines>.Instance.ANIM_INSTANCE_ROLE))
				{
					this.AnimInstance = (mainAnimInstance as UKuroAnimInstanceRole);
				}
			}
			else
			{
				this.AnimInstance = null;
			}
			FTransformDouble? originMeshRelativeTransform;
			if (component == null)
			{
				originMeshRelativeTransform = null;
			}
			else
			{
				TsBaseCharacter actor = component.Actor;
				if (actor == null)
				{
					originMeshRelativeTransform = null;
				}
				else
				{
					USkeletalMeshComponent mesh = actor.Mesh;
					originMeshRelativeTransform = ((mesh != null) ? new FTransformDouble?(mesh.D_GetRelativeTransform()) : null);
				}
			}
			this.OriginMeshRelativeTransform = originMeshRelativeTransform;
			this.ProcessIkOffset();
			ULevelSequencePlayer sequencePlayer = this.CameraSequenceActor.SequencePlayer;
			sequencePlayer.Play();
			sequencePlayer.SetPlayRate(0f);
			sequencePlayer.Pause();
			sequencePlayer.JumpToSeconds(this.PlayedTime);
			return true;
		}

		// Token: 0x06045F65 RID: 286565 RVA: 0x01256608 File Offset: 0x01254808
		private void SequenceStopInternal()
		{
			this.UnbindSkillEndEvent();
			if (this.IsEnableFrameAbstract && this.OriginMeshRelativeTransform != null)
			{
				TsBaseCharacter character = this.Character;
				CharacterAnimationComponent characterAnimationComponent;
				if (character == null)
				{
					characterAnimationComponent = null;
				}
				else
				{
					CharacterActorComponent characterActorComponent = character.CharacterActorComponent;
					characterAnimationComponent = ((characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<CharacterAnimationComponent>() : null);
				}
				CharacterAnimationComponent characterAnimationComponent2 = characterAnimationComponent;
				if (characterAnimationComponent2 != null && characterAnimationComponent2.Valid)
				{
					USkeletalMeshComponent mesh = characterAnimationComponent2.Actor.Mesh;
					if (mesh != null)
					{
						FTransformDouble value = this.OriginMeshRelativeTransform.Value;
						mesh.D_K2_SetRelativeTransform(value, false, ref WorldGlobal.SweepHitResult, true);
					}
				}
			}
			if (this.ResetFightCameraOnStop)
			{
				this.CameraModelInstanceInternal.FightCamera.LogicComponent.ResetArmLengthAndRotation(this.ResetAdditiveRotation.Value);
				if (this.IsRecoverRotation)
				{
					this.CameraModelInstanceInternal.FightCamera.LogicComponent.SetRotation(this.RecoverRotation.Value);
					this.IsRecoverRotation = false;
				}
			}
			else
			{
				this.CameraModelInstanceInternal.FightCamera.LogicComponent.SetRotation(this.CameraModelInstanceInternal.SequenceCamera.DisplayComponent.CineCamera.K2_GetActorRotation());
			}
			FightCamera fightCamera = this.CameraModelInstanceInternal.FightCamera;
			bool flag;
			if (fightCamera == null)
			{
				flag = (null != null);
			}
			else
			{
				FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
				flag = (((logicComponent != null) ? logicComponent.CameraCollision : null) != null);
			}
			if (flag)
			{
				this.CameraModelInstanceInternal.FightCamera.LogicComponent.UnlockCameraNpcDither(ENpcDitherLockType.SequenceCameraPlayer);
			}
			bool seamlessLockState = ModelBase<PlotModel>.Instance.SeamlessLockState;
			this.ShowLog = false;
			this.IsInCinematic = false;
			if (this.IsHideHud)
			{
				ModelBase<BattleUiModel>.Instance.ChildViewData.ShowBattleView(EBattleUiVisibleReason.CameraSeq, 0);
				Singleton<UiLayer>.Instance.SetLayerRenderable(ELayerType.Float, true, "SeqCamera");
				Singleton<UiLayer>.Instance.SetLayerRenderable(ELayerType.Pop, true, "SeqCamera");
				Singleton<UiLayer>.Instance.SetLayerRenderable(ELayerType.Guide, true, "SeqCamera");
				Singleton<EventSystem>.Instance.Emit<bool, string>(EEventName.OnCameraSequenceSetUiVisible, true, this.CameraModelInstanceInternal.CameraName);
				this.IsHideHud = false;
			}
			this.SequenceCameraBlendOutTime = ((!this.IsHit) ? this.SequenceCameraBlendOutTime : 0f);
			if (!seamlessLockState)
			{
				ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Sequence, this.SequenceCameraBlendOutTime, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, this.CameraModelInstanceInternal.CameraName, null);
			}
			else
			{
				APlayerCameraManager playerCameraManager = ControllerBase<CameraController>.Instance.GetPlayerCameraManager("MainCamera");
				if (playerCameraManager != null)
				{
					AActor newViewTarget = null;
					FViewTargetTransitionParams defaultViewTargetTransitionParams = ControllerBase<CameraController>.Instance.GetDefaultViewTargetTransitionParams();
					playerCameraManager.ResetViewTarget(newViewTarget, defaultViewTargetTransitionParams);
				}
				ControllerBase<CameraController>.Instance.ResetViewTarget(0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, this.CameraModelInstanceInternal.CameraName, null);
			}
			this.CameraModelInstanceInternal.FightCamera.LogicComponent.ForceTickOutSide();
			this.BlendingOutRestTime = this.SequenceCameraBlendOutTime;
			if (this.CameraSequenceActor != null)
			{
				this.CameraSequenceActor.SequencePlayer.Stop();
				this.CameraSequenceActor.PlaybackSettings.bDisableMovementInput = false;
				this.CameraSequenceActor.PlaybackSettings.bDisableLookAtInput = false;
				ALevelSequenceActor tmp = this.CameraSequenceActor;
				TimerSystem.Instance.Next(delegate(float _)
				{
					Singleton<ActorSystem>.Instance.Put("SequenceCameraPlayerComponent.SequenceStopInternal", tmp, null);
				}, null, null);
				this.CameraSequenceActor = null;
			}
			this.CameraSequence = null;
			TsBaseCharacter character2 = this.Character;
			if (character2 != null && character2.IsValid())
			{
				CharRenderingComponent charRenderingComponent = this.Character.CharRenderingComponent;
				if (charRenderingComponent != null)
				{
					charRenderingComponent.OnFinalizedLevelSequence();
				}
			}
			this.NeedWaitInPlot = false;
			this.LevelSequenceData = null;
			this.AnimInstance = null;
			this.OriginRootTransform = null;
			this.OriginMeshRelativeTransform = null;
			this.Target = null;
			if (!FNameUtil.IsEmpty(new FName?(this.SocketName)))
			{
				AActor transformOriginActor = this.TransformOriginActor;
				if (transformOriginActor != null && transformOriginActor.IsValid())
				{
					this.TransformOriginActor.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
				}
			}
			this.SocketName = FNameUtil.EMPTY;
			Singleton<EventSystem>.Instance.Emit<bool, string>(EEventName.OnSequenceCameraStatus, false, this.CameraModelInstanceInternal.CameraName);
			ControllerBase<CameraNearClipController>.Instance.ClearSequenceCameraPlayerComponentNearClip();
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.MOTIONBLUR, EGameSettingsApplyReason.AnyTime, true);
		}

		// Token: 0x06045F66 RID: 286566 RVA: 0x012569D0 File Offset: 0x01254BD0
		private void ProcessPlatformMoving()
		{
			if (!this.CharacterMoveComponent.HasDeltaBaseMovementData)
			{
				return;
			}
			FTransformDouble value = this.OriginRootTransform.Value;
			FVectorDouble value2 = this.CharacterMoveComponent.DeltaBaseMovementOffset.Value;
			value.AddToTranslation(value2);
			FQuat fquat = this.CharacterMoveComponent.DeltaBaseMovementQuat.ToUeQuat();
			value.ConcatenateRotation(fquat);
			this.OriginRootTransform = new FTransformDouble?(value);
		}

		// Token: 0x06045F67 RID: 286567 RVA: 0x01256A38 File Offset: 0x01254C38
		private void ProcessIkOffset()
		{
			if (this.IsAttachToActor)
			{
				FTransformDouble actorTransform = this.Character.CharacterActorComponent.ActorTransform;
				FVectorDouble translation = actorTransform.GetTranslation();
				this.TmpTransformDouble.SetLocation(translation);
				FQuat fquat = actorTransform.GetRotation();
				this.TmpTransformDouble.SetRotation(fquat);
				FVector scale3D = actorTransform.GetScale3D();
				this.TmpTransformDouble.SetScale3D(scale3D);
				CameraUtility.GetRotatorInGravity(this.MeshRotator, this.TmpRotator);
				this.TmpRotator.Quaternion(this.TmpQuat);
				fquat = this.TmpQuat.ToUeQuat();
				this.TmpTransformDouble.ConcatenateRotation(fquat);
				FTransform transformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(this.TmpTransformDouble);
				this.LevelSequenceData.TransformOrigin = transformOrigin;
				return;
			}
			if (FNameUtil.IsEmpty(new FName?(this.SocketName)))
			{
				FTransform transformOrigin2 = UKismetMathLibrary.Conv_TransformDoubleToTransform(this.ConstructTransform(this.OriginRootTransform.Value));
				this.LevelSequenceData.TransformOrigin = transformOrigin2;
				return;
			}
			AActor transformOriginActor = this.TransformOriginActor;
			if (transformOriginActor != null && transformOriginActor.IsValid())
			{
				this.LevelSequenceData.TransformOriginActor = this.TransformOriginActor;
				SequenceCameraDisplayComponent displayComponent = this.DisplayComponent;
				if (((displayComponent != null) ? displayComponent.CineCamera : null) == null)
				{
					return;
				}
				FVectorDouble newLocation = this.DisplayComponent.CineCamera.D_K2_GetActorLocation();
				FHitResult fhitResult = new FHitResult();
				this.DisplayComponent.CineCamera.D_K2_SetActorLocation(newLocation, false, ref fhitResult, false);
			}
		}

		// Token: 0x06045F68 RID: 286568 RVA: 0x01256B9C File Offset: 0x01254D9C
		private void ProcessMeshPosition()
		{
			if (!this.IsEnableFrameAbstract || this.CameraTransformTrack == null || this.Character == null || this.FrameAbstractDelta < 0.05f)
			{
				return;
			}
			int num = (int)Math.Floor((double)(this.PlayedTime / this.FrameAbstractDelta));
			if (num != this.FrameAbstractTime)
			{
				this.FrameAbstractTime = num;
				float time = (float)num * this.FrameAbstractDelta;
				this.FrameAbstractRelativeCameraTransform = SequenceUtils.GetLevelSequenceTransform(this.CameraSequence, this.CameraTransformTrack, time).Inverse();
			}
			CharacterAnimationComponent component = this.Character.GetEntityNoBlueprint().GetComponent<CharacterAnimationComponent>();
			if (component == null || !component.Valid)
			{
				return;
			}
			FTransformDouble ftransformDouble = this.DisplayComponent.CineCamera.D_GetTransform();
			FTransformDouble ftransformDouble2 = this.FrameAbstractRelativeCameraTransform * ftransformDouble;
			TsBaseCharacter actor = component.Actor;
			if (actor == null)
			{
				return;
			}
			USkeletalMeshComponent mesh = actor.Mesh;
			if (mesh == null)
			{
				return;
			}
			mesh.D_K2_SetWorldTransform(ftransformDouble2, false, ref WorldGlobal.SweepHitResult, true);
		}

		// Token: 0x06045F69 RID: 286569 RVA: 0x01256C88 File Offset: 0x01254E88
		private void ProcessDitherEffect()
		{
			if (!this.IsDitherEffectEnabled)
			{
				return;
			}
			TsBaseCharacter character = this.Character;
			if (character == null || !character.IsValid())
			{
				return;
			}
			if (this.SocketTransform == null || !this.SocketTransform.GetValueOrDefault().IsValid())
			{
				return;
			}
			FightCamera fightCamera = this.CameraModelInstanceInternal.FightCamera;
			FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
			if (fightCameraLogicComponent == null)
			{
				return;
			}
			Vector tmpVector = this.TmpVector;
			FVectorDouble fvectorDouble = this.SocketTransform.Value.GetLocation();
			tmpVector.DeepCopy(fvectorDouble);
			Vector cameraLocation = this.CameraLocation;
			fvectorDouble = this.DisplayComponent.CineCamera.D_K2_GetActorLocation();
			cameraLocation.DeepCopy(fvectorDouble);
			Rotator cameraRotation = this.CameraRotation;
			FRotator frotator = this.DisplayComponent.CineCamera.K2_GetActorRotation();
			cameraRotation.DeepCopy(frotator);
			CameraUtility.GetRotatorInGravity(this.CameraRotation, this.CameraRotationInGravity);
			double num = Vector.DistSquared(this.TmpVector, this.CameraLocation);
			float outRangeB = 0.01f;
			float val = 1f;
			if (num < (double)fightCameraLogicComponent.StartHideDistanceSquared)
			{
				val = Singleton<MathUtils>.Instance.RangeClamp((float)Math.Sqrt(num), fightCameraLogicComponent.StartHideDistance, fightCameraLogicComponent.CompleteHideDistance, fightCameraLogicComponent.StartDitherValue, outRangeB);
			}
			float pitch = this.CameraRotationInGravity.Pitch;
			float val2 = 1f;
			if (pitch > fightCameraLogicComponent.StartHidePitch)
			{
				val2 = Singleton<MathUtils>.Instance.RangeClamp(pitch, fightCameraLogicComponent.StartHidePitch, fightCameraLogicComponent.CompleteHidePitch, fightCameraLogicComponent.StartDitherValue, outRangeB);
			}
			float dither = Math.Min(val, val2);
			this.Character.SetDitherEffect(dither, ECharacterDitherType.Fight);
		}

		// Token: 0x06045F6A RID: 286570 RVA: 0x01256E10 File Offset: 0x01255010
		[NullableContext(2)]
		private bool CheckBreakSequence(TsBaseCharacter character, TsBaseCharacter target)
		{
			if (target == null || !target.IsValid())
			{
				return false;
			}
			if (character == null || !character.IsValid())
			{
				return true;
			}
			if (character == target)
			{
				return true;
			}
			Entity entityNoBlueprint = character.GetEntityNoBlueprint();
			object obj = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CreatureDataComponent>() : null;
			Entity entityNoBlueprint2 = target.GetEntityNoBlueprint();
			CreatureDataComponent creatureDataComponent = (entityNoBlueprint2 != null) ? entityNoBlueprint2.GetComponent<CreatureDataComponent>() : null;
			object obj2 = obj;
			return obj2 != null && obj2.IsRole() && creatureDataComponent != null && creatureDataComponent.IsMonster();
		}

		// Token: 0x06045F6B RID: 286571 RVA: 0x01256E8C File Offset: 0x0125508C
		private void PlaySequence()
		{
			this.IgnoreActors.Empty(true);
			this.IgnoreActors.Add(ControllerBase<CameraController>.Instance.GetCharacter());
			if (this.Target != null)
			{
				this.IgnoreActors.Add(this.Target);
			}
			ControllerBase<CameraController>.Instance.EnterCameraMode(ECustomCameraMode.Sequence, this.SequenceCameraBlendInTime, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, false, this.CameraModelInstanceInternal.CameraName, null);
			FightCamera fightCamera = this.CameraModelInstanceInternal.FightCamera;
			if (((fightCamera != null) ? fightCamera.LogicComponent : null) != null)
			{
				this.CameraModelInstanceInternal.FightCamera.LogicComponent.LockCameraNpcDither(ENpcDitherLockType.SequenceCameraPlayer);
			}
			this.IsInCinematic = true;
		}

		// Token: 0x06045F6C RID: 286572 RVA: 0x01256F30 File Offset: 0x01255130
		private FTransformDouble ConstructTransform(FTransformDouble transform)
		{
			FQuat rotation = transform.GetRotation();
			FVectorDouble translation = transform.GetTranslation();
			FVector scale3D = transform.GetScale3D();
			return new FTransformDouble(ref rotation, ref translation, ref scale3D);
		}

		// Token: 0x06045F6D RID: 286573 RVA: 0x01256F60 File Offset: 0x01255160
		protected override void OnChangeTimeDilation(float timeDilation)
		{
		}

		// Token: 0x06045F6E RID: 286574 RVA: 0x01256F64 File Offset: 0x01255164
		private void ProcessSocketTransform()
		{
			TsBaseCharacter character = this.Character;
			if (character == null || !character.IsValid())
			{
				return;
			}
			if (FNameUtil.IsEmpty(new FName?(this.LockSocketName)))
			{
				CharacterAnimationComponent component = this.Character.GetEntityNoBlueprint().GetComponent<CharacterAnimationComponent>();
				this.SocketTransform = new FTransformDouble?(component.GetCameraTransform());
				return;
			}
			this.SocketTransform = this.GetBoneTransform(this.LockSocketName);
		}

		// Token: 0x06045F6F RID: 286575 RVA: 0x01256FD0 File Offset: 0x012551D0
		public void CheckCollision(bool isBlendOut)
		{
			if (this.SocketTransform == null || !this.SocketTransform.GetValueOrDefault().IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.ZQ, "CheckCollision  SocketTransform 不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.CameraSphereTrace.WorldContextObject = GlobalData.World;
			this.IgnoreActors.Empty(true);
			this.IgnoreActors.Add(ControllerBase<CameraController>.Instance.GetCharacter());
			this.CameraSphereTrace.ActorsToIgnore = this.IgnoreActors;
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.CameraSphereTrace, this.SocketTransform.Value.GetLocation());
			Vector cameraLocation = this.CameraLocation;
			FVectorDouble fvectorDouble = this.DisplayComponent.CineCamera.D_K2_GetActorLocation();
			cameraLocation.DeepCopy(fvectorDouble);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.CameraSphereTrace, this.CameraLocation);
			this.CameraSphereTrace.Radius = 10f;
			this.IsHit = Singleton<TraceElementCommon>.Instance.SphereTrace(this.CameraSphereTrace, "SequenceCameraPlayerComponent_ProcessHideShelterCharacter");
			if (this.IsHit && (isBlendOut || this.IsEnableCollision))
			{
				Singleton<TraceElementCommon>.Instance.GetHitLocation(this.CameraSphereTrace.HitResult, 0, this.HitLocation);
				this.DisplayComponent.CineCamera.D_K2_SetActorLocation(this.HitLocation.ToUeVector(false), false, ref WorldGlobal.SweepHitResult, false);
			}
		}

		// Token: 0x06045F70 RID: 286576 RVA: 0x0125713C File Offset: 0x0125533C
		public bool CheckSphereCollision()
		{
			if (this.CheckRadius == 0f)
			{
				return false;
			}
			this.CameraCheckSphereTrace.WorldContextObject = GlobalData.World;
			CharacterAnimationComponent component = this.Character.GetEntityNoBlueprint().GetComponent<CharacterAnimationComponent>();
			this.SocketTransform = new FTransformDouble?(component.GetCameraTransform());
			component.GetCameraPosition(this.SourceLocation);
			this.SourceForward.DeepCopy(this.Character.CharacterActorComponent.ActorForwardProxy);
			this.SourceForward.Multiply(this.RelativeLocation.X, this.SourceForward);
			this.HorizontalVector.DeepCopy(Vector.OneVectorProxy);
			this.HorizontalVector.Multiply(this.RelativeLocation.Y, this.HorizontalVector);
			this.Up.DeepCopy(Vector.UpVectorProxy);
			this.Up.Multiply(this.RelativeLocation.Z, this.Up);
			this.SourceLocation.Addition(this.SourceForward, this.SourceLocation);
			this.SourceLocation.Addition(this.HorizontalVector, this.SourceLocation);
			this.SourceLocation.Addition(this.Up, this.SourceLocation);
			this.IgnoreActors.Empty(true);
			this.IgnoreActors.Add(ControllerBase<CameraController>.Instance.GetCharacter());
			this.CameraCheckSphereTrace.ActorsToIgnore = this.IgnoreActors;
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.CameraCheckSphereTrace, this.SourceLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.CameraCheckSphereTrace, this.SourceLocation);
			this.CameraCheckSphereTrace.Radius = this.CheckRadius;
			return Singleton<TraceElementCommon>.Instance.SphereTrace(this.CameraCheckSphereTrace, "SequenceCameraPlayerComponent_ProcessHideShelterCharacter");
		}

		// Token: 0x06045F71 RID: 286577 RVA: 0x012572F4 File Offset: 0x012554F4
		public FTransformDouble? GetBoneTransform(FName boneName)
		{
			return new FTransformDouble?(this.Character.Mesh.D_GetSocketTransform(boneName, ERelativeTransformSpace.RTS_World));
		}

		// Token: 0x06045F72 RID: 286578 RVA: 0x0125730D File Offset: 0x0125550D
		public void SetCameraCollisionState(bool isEnableCollision)
		{
			this.IsEnableCollision = isEnableCollision;
		}

		// Token: 0x06045F73 RID: 286579 RVA: 0x01257318 File Offset: 0x01255518
		protected void DrawCube(FTransformDouble transform, float duration, float colorValue)
		{
			FLinearColor lineColor = new FLinearColor(colorValue, colorValue, colorValue, colorValue);
			FVectorDouble location = transform.GetLocation();
			FVector fvector = new FVector(10f, 10f, 10f);
			FVectorDouble extent = new FVectorDouble((double)fvector.X * 0.5, (double)fvector.Y * 0.5, (double)fvector.Z * 0.5);
			FRotator rotation = transform.Rotator();
			int num = 30;
			UKismetSystemLibrary.D_DrawDebugBox(GlobalData.World, location, extent, lineColor, rotation, duration, (float)num);
			FVectorDouble lineStart = UKismetMathLibrary.D_TransformLocation(transform, new FVectorDouble(0.5, 0.5, 0.5));
			FVectorDouble lineEnd = UKismetMathLibrary.D_TransformLocation(transform, new FVectorDouble(-0.5, -0.5, -0.5));
			int num2 = 15;
			UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, lineStart, lineEnd, lineColor, duration, (float)num2);
			FVectorDouble lineStart2 = UKismetMathLibrary.D_TransformLocation(transform, new FVectorDouble(0.5, -0.5, 0.5));
			FVectorDouble lineEnd2 = UKismetMathLibrary.D_TransformLocation(transform, new FVectorDouble(-0.5, 0.5, 0.5));
			UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, lineStart2, lineEnd2, lineColor, duration, (float)num2);
		}

		// Token: 0x06045F74 RID: 286580 RVA: 0x01257478 File Offset: 0x01255678
		public SeqCameraThings SaveSeqCamera()
		{
			return new SeqCameraThings
			{
				CameraLocation = this.DisplayComponent.CineCamera.D_K2_GetActorLocation(),
				CameraRotation = this.DisplayComponent.CineCamera.K2_GetActorRotation(),
				OriginRootTransform = this.OriginRootTransform,
				ConstrainAspectRatio = this.DisplayComponent.CineCamera.Constrain_Aspect_Ratio,
				CurrentAperture = this.DisplayComponent.CineCamera.Current_Aperture,
				CurrentFocalLength = this.DisplayComponent.CineCamera.Current_Focal_Length,
				FocusSettings = this.DisplayComponent.CineCamera.Focus_Settings,
				LensSettings = this.DisplayComponent.CineCamera.Lens_Settings,
				FieldOfView = this.DisplayComponent.CineCamera.GetCineCameraComponent().FieldOfView
			};
		}

		// Token: 0x06045F75 RID: 286581 RVA: 0x0125754B File Offset: 0x0125574B
		public bool GetIfNeedWaitInPlot()
		{
			return this.NeedWaitInPlot;
		}

		// Token: 0x06045F76 RID: 286582 RVA: 0x01257553 File Offset: 0x01255753
		protected override bool OnClear()
		{
			this.CameraModelInstanceInternal = null;
			return true;
		}

		// Token: 0x06045F77 RID: 286583 RVA: 0x01257560 File Offset: 0x01255760
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SequenceCameraPlayerComponent sequenceCameraPlayerComponent = (SequenceCameraPlayerComponent)componentTemplate;
			if (base.CanResetComponentProperty("CameraModelInstanceInternal"))
			{
				if (sequenceCameraPlayerComponent.CameraModelInstanceInternal == null)
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
				if (sequenceCameraPlayerComponent.DisplayComponent == null)
				{
					this.DisplayComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SequenceCameraDisplayComponent>(this.DisplayComponent), "DisplayComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IgnoreActors") && sequenceCameraPlayerComponent.IgnoreActors != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.IgnoreActors), "IgnoreActors"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CameraSequence"))
			{
				if (sequenceCameraPlayerComponent.CameraSequence == null)
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
				if (sequenceCameraPlayerComponent.CameraSequenceActor == null)
				{
					this.CameraSequenceActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ALevelSequenceActor>(this.CameraSequenceActor), "CameraSequenceActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PlayedTime"))
			{
				this.PlayedTime = sequenceCameraPlayerComponent.PlayedTime;
			}
			if (base.CanResetComponentProperty("TimeLength"))
			{
				this.TimeLength = sequenceCameraPlayerComponent.TimeLength;
			}
			if (base.CanResetComponentProperty("PlaySpeed"))
			{
				this.PlaySpeed = sequenceCameraPlayerComponent.PlaySpeed;
			}
			if (base.CanResetComponentProperty("SequenceCameraBlendInTime"))
			{
				this.SequenceCameraBlendInTime = sequenceCameraPlayerComponent.SequenceCameraBlendInTime;
			}
			if (base.CanResetComponentProperty("SequenceCameraBlendOutTime"))
			{
				this.SequenceCameraBlendOutTime = sequenceCameraPlayerComponent.SequenceCameraBlendOutTime;
			}
			if (base.CanResetComponentProperty("BlendingOutRestTime"))
			{
				this.BlendingOutRestTime = sequenceCameraPlayerComponent.BlendingOutRestTime;
			}
			if (base.CanResetComponentProperty("LevelSequenceData"))
			{
				if (sequenceCameraPlayerComponent.LevelSequenceData == null)
				{
					this.LevelSequenceData = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UDefaultLevelSequenceInstanceData>(this.LevelSequenceData), "LevelSequenceData"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("AnimInstance"))
			{
				if (sequenceCameraPlayerComponent.AnimInstance == null)
				{
					this.AnimInstance = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroAnimInstanceRole>(this.AnimInstance), "AnimInstance"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("OriginRootTransform"))
			{
				this.OriginRootTransform = sequenceCameraPlayerComponent.OriginRootTransform;
			}
			if (base.CanResetComponentProperty("OriginMeshRelativeTransform"))
			{
				this.OriginMeshRelativeTransform = sequenceCameraPlayerComponent.OriginMeshRelativeTransform;
			}
			if (base.CanResetComponentProperty("CharacterMoveComponent"))
			{
				if (sequenceCameraPlayerComponent.CharacterMoveComponent == null)
				{
					this.CharacterMoveComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseMoveComponent>(this.CharacterMoveComponent), "CharacterMoveComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsInCinematic"))
			{
				this.IsInCinematic = sequenceCameraPlayerComponent.IsInCinematic;
			}
			if (base.CanResetComponentProperty("IsHideHud"))
			{
				this.IsHideHud = sequenceCameraPlayerComponent.IsHideHud;
			}
			if (base.CanResetComponentProperty("HideHudTime"))
			{
				this.HideHudTime = sequenceCameraPlayerComponent.HideHudTime;
			}
			if (base.CanResetComponentProperty("BindingActors") && sequenceCameraPlayerComponent.BindingActors != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.BindingActors), "BindingActors"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("BindingCharacterActors") && sequenceCameraPlayerComponent.BindingCharacterActors != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.BindingCharacterActors), "BindingCharacterActors"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("ResetAdditiveRotation"))
			{
				this.ResetAdditiveRotation = sequenceCameraPlayerComponent.ResetAdditiveRotation;
			}
			if (base.CanResetComponentProperty("ResetFightCameraOnStop"))
			{
				this.ResetFightCameraOnStop = sequenceCameraPlayerComponent.ResetFightCameraOnStop;
			}
			if (base.CanResetComponentProperty("RecoverRotation"))
			{
				this.RecoverRotation = sequenceCameraPlayerComponent.RecoverRotation;
			}
			if (base.CanResetComponentProperty("IsRecoverRotation"))
			{
				this.IsRecoverRotation = sequenceCameraPlayerComponent.IsRecoverRotation;
			}
			if (base.CanResetComponentProperty("Target"))
			{
				if (sequenceCameraPlayerComponent.Target == null)
				{
					this.Target = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TsBaseCharacter>(this.Target), "Target"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("Character"))
			{
				if (sequenceCameraPlayerComponent.Character == null)
				{
					this.Character = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TsBaseCharacter>(this.Character), "Character"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("OldCharacter"))
			{
				if (sequenceCameraPlayerComponent.OldCharacter == null)
				{
					this.OldCharacter = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TsBaseCharacter>(this.OldCharacter), "OldCharacter"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SphereSingle"))
			{
				if (sequenceCameraPlayerComponent.SphereSingle == null)
				{
					this.SphereSingle = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceSphereElement>(this.SphereSingle), "SphereSingle"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SphereMultiply"))
			{
				if (sequenceCameraPlayerComponent.SphereMultiply == null)
				{
					this.SphereMultiply = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceSphereElement>(this.SphereMultiply), "SphereMultiply"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SocketName"))
			{
				this.SocketName = sequenceCameraPlayerComponent.SocketName;
			}
			if (base.CanResetComponentProperty("LockSocketName"))
			{
				this.LockSocketName = sequenceCameraPlayerComponent.LockSocketName;
			}
			if (base.CanResetComponentProperty("TransformOriginActor"))
			{
				if (sequenceCameraPlayerComponent.TransformOriginActor == null)
				{
					this.TransformOriginActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.TransformOriginActor), "TransformOriginActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RelativeLocation") && sequenceCameraPlayerComponent.RelativeLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.RelativeLocation), "RelativeLocation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("ShowLog"))
			{
				this.ShowLog = sequenceCameraPlayerComponent.ShowLog;
			}
			if (base.CanResetComponentProperty("CheckRadius"))
			{
				this.CheckRadius = sequenceCameraPlayerComponent.CheckRadius;
			}
			if (base.CanResetComponentProperty("IsEnableCollision"))
			{
				this.IsEnableCollision = sequenceCameraPlayerComponent.IsEnableCollision;
			}
			if (base.CanResetComponentProperty("NeedWaitInPlot"))
			{
				this.NeedWaitInPlot = sequenceCameraPlayerComponent.NeedWaitInPlot;
			}
			if (base.CanResetComponentProperty("IsPlayCameraSequenceEnabled"))
			{
				this.IsPlayCameraSequenceEnabled = sequenceCameraPlayerComponent.IsPlayCameraSequenceEnabled;
			}
			if (base.CanResetComponentProperty("IsEnableFrameAbstract"))
			{
				this.IsEnableFrameAbstract = sequenceCameraPlayerComponent.IsEnableFrameAbstract;
			}
			if (base.CanResetComponentProperty("FrameAbstractDelta"))
			{
				this.FrameAbstractDelta = sequenceCameraPlayerComponent.FrameAbstractDelta;
			}
			if (base.CanResetComponentProperty("FrameAbstractTime"))
			{
				this.FrameAbstractTime = sequenceCameraPlayerComponent.FrameAbstractTime;
			}
			if (base.CanResetComponentProperty("CameraTransformTrack"))
			{
				if (sequenceCameraPlayerComponent.CameraTransformTrack == null)
				{
					this.CameraTransformTrack = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UMovieSceneTrack>(this.CameraTransformTrack), "CameraTransformTrack"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FrameAbstractRelativeCameraTransform"))
			{
				this.FrameAbstractRelativeCameraTransform = sequenceCameraPlayerComponent.FrameAbstractRelativeCameraTransform;
			}
			if (base.CanResetComponentProperty("IsAttachToActor"))
			{
				this.IsAttachToActor = sequenceCameraPlayerComponent.IsAttachToActor;
			}
			if (base.CanResetComponentProperty("DitherEffectEnableSet") && sequenceCameraPlayerComponent.DitherEffectEnableSet != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<ESequenceCameraDitherEffectEnum>(this.DitherEffectEnableSet), "DitherEffectEnableSet"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("BindSkillEntity"))
			{
				if (sequenceCameraPlayerComponent.BindSkillEntity == null)
				{
					this.BindSkillEntity = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Entity>(this.BindSkillEntity), "BindSkillEntity"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("BindSkillId"))
			{
				this.BindSkillId = sequenceCameraPlayerComponent.BindSkillId;
			}
			if (base.CanResetComponentProperty("MeshRotator") && sequenceCameraPlayerComponent.MeshRotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.MeshRotator), "MeshRotator"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TmpVector") && sequenceCameraPlayerComponent.TmpVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpVector), "TmpVector"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TmpTransformDouble"))
			{
				this.TmpTransformDouble = sequenceCameraPlayerComponent.TmpTransformDouble;
			}
			if (base.CanResetComponentProperty("TmpRotator") && sequenceCameraPlayerComponent.TmpRotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.TmpRotator), "TmpRotator"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TmpQuat") && sequenceCameraPlayerComponent.TmpQuat != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TmpQuat), "TmpQuat"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CameraSphereTrace"))
			{
				if (sequenceCameraPlayerComponent.CameraSphereTrace == null)
				{
					this.CameraSphereTrace = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceSphereElement>(this.CameraSphereTrace), "CameraSphereTrace"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CameraCheckSphereTrace"))
			{
				if (sequenceCameraPlayerComponent.CameraCheckSphereTrace == null)
				{
					this.CameraCheckSphereTrace = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceSphereElement>(this.CameraCheckSphereTrace), "CameraCheckSphereTrace"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsHit"))
			{
				this.IsHit = sequenceCameraPlayerComponent.IsHit;
			}
			if (base.CanResetComponentProperty("HitLocation") && sequenceCameraPlayerComponent.HitLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.HitLocation), "HitLocation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CameraLocation") && sequenceCameraPlayerComponent.CameraLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.CameraLocation), "CameraLocation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CameraRotation") && sequenceCameraPlayerComponent.CameraRotation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.CameraRotation), "CameraRotation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CameraRotationInGravity") && sequenceCameraPlayerComponent.CameraRotationInGravity != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.CameraRotationInGravity), "CameraRotationInGravity"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("SocketTransform"))
			{
				this.SocketTransform = sequenceCameraPlayerComponent.SocketTransform;
			}
			return (!base.CanResetComponentProperty("SourceLocation") || sequenceCameraPlayerComponent.SourceLocation == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.SourceLocation), "SourceLocation")) && (!base.CanResetComponentProperty("SourceForward") || sequenceCameraPlayerComponent.SourceForward == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.SourceForward), "SourceForward")) && (!base.CanResetComponentProperty("HorizontalVector") || sequenceCameraPlayerComponent.HorizontalVector == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.HorizontalVector), "HorizontalVector")) && (!base.CanResetComponentProperty("Up") || sequenceCameraPlayerComponent.Up == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.Up), "Up"));
		}

		// Token: 0x04027303 RID: 160515
		private const string PROFILE_KEY1 = "SequenceCameraPlayerComponent_CheckCameraLocation";

		// Token: 0x04027304 RID: 160516
		private const string PROFILE_KEY2 = "SequenceCameraPlayerComponent_ProcessHideShelterCharacter";

		// Token: 0x04027305 RID: 160517
		private const double RELATIVE_LENGTH = 10000.0;

		// Token: 0x04027306 RID: 160518
		private const float MINI_FRAME_ABSTRACT_DELTA = 0.05f;

		// Token: 0x04027307 RID: 160519
		[StaticVariableRuleIgnore]
		private static readonly Stat SequenceTransformStat = Stat.Create("SequenceTransformStat", "", "");

		// Token: 0x04027308 RID: 160520
		private static readonly FName SequenceCamera = new FName("SequenceCamera");

		// Token: 0x04027309 RID: 160521
		private static readonly FName RoleTag = new FName("Role");

		// Token: 0x0402730A RID: 160522
		[Nullable(2)]
		private CameraModelInstance CameraModelInstanceInternal;

		// Token: 0x0402730B RID: 160523
		[Nullable(2)]
		private SequenceCameraDisplayComponent DisplayComponent;

		// Token: 0x0402730C RID: 160524
		private readonly TArray<AActor> IgnoreActors = new TArray<AActor>();

		// Token: 0x0402730D RID: 160525
		[Nullable(2)]
		private ULevelSequence CameraSequence;

		// Token: 0x0402730E RID: 160526
		[Nullable(2)]
		private ALevelSequenceActor CameraSequenceActor;

		// Token: 0x0402730F RID: 160527
		private float PlayedTime;

		// Token: 0x04027310 RID: 160528
		private float TimeLength;

		// Token: 0x04027311 RID: 160529
		private float PlaySpeed = 1f;

		// Token: 0x04027312 RID: 160530
		private float SequenceCameraBlendInTime = 1f;

		// Token: 0x04027313 RID: 160531
		private float SequenceCameraBlendOutTime = 1f;

		// Token: 0x04027314 RID: 160532
		private float BlendingOutRestTime;

		// Token: 0x04027315 RID: 160533
		[Nullable(2)]
		private UDefaultLevelSequenceInstanceData LevelSequenceData;

		// Token: 0x04027316 RID: 160534
		[Nullable(2)]
		private UKuroAnimInstanceRole AnimInstance;

		// Token: 0x04027317 RID: 160535
		private FTransformDouble? OriginRootTransform;

		// Token: 0x04027318 RID: 160536
		private FTransformDouble? OriginMeshRelativeTransform;

		// Token: 0x04027319 RID: 160537
		[Nullable(2)]
		private BaseMoveComponent CharacterMoveComponent;

		// Token: 0x0402731A RID: 160538
		private bool IsInCinematic;

		// Token: 0x0402731B RID: 160539
		private bool IsHideHud;

		// Token: 0x0402731C RID: 160540
		private float HideHudTime;

		// Token: 0x0402731D RID: 160541
		private readonly TArray<AActor> BindingActors = new TArray<AActor>();

		// Token: 0x0402731E RID: 160542
		private readonly TArray<AActor> BindingCharacterActors = new TArray<AActor>();

		// Token: 0x0402731F RID: 160543
		private FRotator? ResetAdditiveRotation;

		// Token: 0x04027320 RID: 160544
		private bool ResetFightCameraOnStop;

		// Token: 0x04027321 RID: 160545
		private FRotator? RecoverRotation;

		// Token: 0x04027322 RID: 160546
		private bool IsRecoverRotation;

		// Token: 0x04027323 RID: 160547
		[Nullable(2)]
		private TsBaseCharacter Target;

		// Token: 0x04027324 RID: 160548
		[Nullable(2)]
		private TsBaseCharacter Character;

		// Token: 0x04027325 RID: 160549
		[Nullable(2)]
		private TsBaseCharacter OldCharacter;

		// Token: 0x04027326 RID: 160550
		[Nullable(2)]
		private UTraceSphereElement SphereSingle;

		// Token: 0x04027327 RID: 160551
		[Nullable(2)]
		private UTraceSphereElement SphereMultiply;

		// Token: 0x04027328 RID: 160552
		private FName SocketName = FNameUtil.EMPTY;

		// Token: 0x04027329 RID: 160553
		private FName LockSocketName = FNameUtil.EMPTY;

		// Token: 0x0402732A RID: 160554
		[Nullable(2)]
		private AActor TransformOriginActor;

		// Token: 0x0402732B RID: 160555
		private readonly Vector RelativeLocation = Vector.Create(10000.0, 10000.0, 10000.0);

		// Token: 0x0402732C RID: 160556
		private bool ShowLog;

		// Token: 0x0402732D RID: 160557
		private float CheckRadius;

		// Token: 0x0402732E RID: 160558
		private bool IsEnableCollision = true;

		// Token: 0x0402732F RID: 160559
		private bool NeedWaitInPlot;

		// Token: 0x04027330 RID: 160560
		private bool IsPlayCameraSequenceEnabled = true;

		// Token: 0x04027331 RID: 160561
		private bool IsEnableFrameAbstract;

		// Token: 0x04027332 RID: 160562
		private float FrameAbstractDelta;

		// Token: 0x04027333 RID: 160563
		private int FrameAbstractTime;

		// Token: 0x04027334 RID: 160564
		[Nullable(2)]
		private UMovieSceneTrack CameraTransformTrack;

		// Token: 0x04027335 RID: 160565
		private FTransformDouble FrameAbstractRelativeCameraTransform;

		// Token: 0x04027336 RID: 160566
		private readonly bool DebugFrameAbstract;

		// Token: 0x04027337 RID: 160567
		private bool IsAttachToActor;

		// Token: 0x04027338 RID: 160568
		private readonly HashSet<ESequenceCameraDitherEffectEnum> DitherEffectEnableSet = new HashSet<ESequenceCameraDitherEffectEnum>();

		// Token: 0x04027339 RID: 160569
		[Nullable(2)]
		private Entity BindSkillEntity;

		// Token: 0x0402733A RID: 160570
		private long? BindSkillId;

		// Token: 0x0402733B RID: 160571
		private readonly Rotator MeshRotator = Rotator.Create(0f, -90f, 0f);

		// Token: 0x0402733C RID: 160572
		private readonly Vector TmpVector = Vector.Create();

		// Token: 0x0402733D RID: 160573
		private FTransformDouble TmpTransformDouble = new FTransformDouble();

		// Token: 0x0402733E RID: 160574
		private readonly Rotator TmpRotator = Rotator.Create();

		// Token: 0x0402733F RID: 160575
		private readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x04027340 RID: 160576
		[Nullable(2)]
		private UTraceSphereElement CameraSphereTrace;

		// Token: 0x04027341 RID: 160577
		[Nullable(2)]
		private UTraceSphereElement CameraCheckSphereTrace;

		// Token: 0x04027342 RID: 160578
		private bool IsHit;

		// Token: 0x04027343 RID: 160579
		private readonly Vector HitLocation = Vector.Create();

		// Token: 0x04027344 RID: 160580
		private readonly Vector CameraLocation = Vector.Create();

		// Token: 0x04027345 RID: 160581
		private readonly Rotator CameraRotation = Rotator.Create();

		// Token: 0x04027346 RID: 160582
		private readonly Rotator CameraRotationInGravity = Rotator.Create();

		// Token: 0x04027347 RID: 160583
		private FTransformDouble? SocketTransform;

		// Token: 0x04027348 RID: 160584
		private readonly Vector SourceLocation = Vector.Create();

		// Token: 0x04027349 RID: 160585
		private readonly Vector SourceForward = Vector.Create();

		// Token: 0x0402734A RID: 160586
		private readonly Vector HorizontalVector = Vector.Create();

		// Token: 0x0402734B RID: 160587
		private readonly Vector Up = Vector.Create();
	}
}
