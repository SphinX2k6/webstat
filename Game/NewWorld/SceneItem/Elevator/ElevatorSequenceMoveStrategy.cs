using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Elevator
{
	// Token: 0x02004868 RID: 18536
	[NullableContext(1)]
	[Nullable(0)]
	public class ElevatorSequenceMoveStrategy : ElevatorMoveStrategyBase
	{
		// Token: 0x1700827E RID: 33406
		// (get) Token: 0x060303A0 RID: 197536 RVA: 0x00BB9B68 File Offset: 0x00BB7D68
		public bool IsInitializing
		{
			get
			{
				return this.IsInitializingFlag;
			}
		}

		// Token: 0x060303A1 RID: 197537 RVA: 0x00BB9B70 File Offset: 0x00BB7D70
		public override void InitFromConfig(LiftComponent config, ElevatorContext ctx, float _initLocationX, float _initLocationY, float _initLocationZ)
		{
			this.Ctx = ctx;
			if (config.StayPositions != null && config.StayPositions.Count > 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CK;
				string message = "Sequence电梯不应配置StayPositions, 已跳过";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityConfigId", ctx.EntityConfigId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x060303A2 RID: 197538 RVA: 0x00BB9BCB File Offset: 0x00BB7DCB
		public override void OnInit()
		{
			this.InitFloorSeqMarkConfig();
		}

		// Token: 0x060303A3 RID: 197539 RVA: 0x00BB9BD4 File Offset: 0x00BB7DD4
		public override void OnStart(Action tryStartAutoRun)
		{
			this.IsInitializingFlag = true;
			this.JumpElevatorSequenceToInitFloor(delegate
			{
				this.IsInitializingFlag = false;
				tryStartAutoRun();
			});
		}

		// Token: 0x060303A4 RID: 197540 RVA: 0x00BB9C0E File Offset: 0x00BB7E0E
		public override void OnClear()
		{
			base.OnClear();
			this.IsInitializingFlag = false;
			this.ExitAnimTickState();
			this.SequenceSkeletalMeshes.Clear();
			this.ReleaseElevatorSequenceActor();
		}

		// Token: 0x060303A5 RID: 197541 RVA: 0x00BB9C34 File Offset: 0x00BB7E34
		public override void TickMove(float deltaSeconds)
		{
			this.TickSequenceMove(deltaSeconds);
		}

		// Token: 0x060303A6 RID: 197542 RVA: 0x00BB9C3D File Offset: 0x00BB7E3D
		public override void CheckAndFinishMove(Action onMoveArrived)
		{
			if (this.IsSequenceTimeReached(this.SeqPlayedTime, this.SeqTargetTime))
			{
				this.SequenceMoveFinish(onMoveArrived);
			}
		}

		// Token: 0x060303A7 RID: 197543 RVA: 0x00BB9C5A File Offset: 0x00BB7E5A
		public override void PrepareMoveToFloor(Action onReady)
		{
			this.PrepareSequenceMove(this.Ctx.TargetFloor, onReady);
		}

		// Token: 0x060303A8 RID: 197544 RVA: 0x00BB9C6E File Offset: 0x00BB7E6E
		public override int GetFloorCount()
		{
			return this.FloorSeqMarks.Count;
		}

		// Token: 0x060303A9 RID: 197545 RVA: 0x00BB9C7C File Offset: 0x00BB7E7C
		public override float GetMoveDuration()
		{
			float num = MathF.Abs(this.SeqTargetTime - this.SeqPlayedTime);
			if (num <= 1000f)
			{
				return num;
			}
			return 1000f;
		}

		// Token: 0x060303AA RID: 197546 RVA: 0x00BB9CAC File Offset: 0x00BB7EAC
		private void SeekSequenceTo(float timeInSeconds)
		{
			ALevelSequenceActor elevatorSequenceActor = this.ElevatorSequenceActor;
			ULevelSequencePlayer ulevelSequencePlayer = (elevatorSequenceActor != null) ? elevatorSequenceActor.SequencePlayer : null;
			if (ulevelSequencePlayer == null)
			{
				return;
			}
			ulevelSequencePlayer.SetPlaybackPosition(new FMovieSceneSequencePlaybackParams
			{
				Time = timeInSeconds,
				PositionType = EMovieScenePositionType.Time,
				UpdateMethod = EUpdatePositionMethod.Jump
			});
		}

		// Token: 0x060303AB RID: 197547 RVA: 0x00BB9CF4 File Offset: 0x00BB7EF4
		private void PlaySequenceTo(float timeInSeconds)
		{
			ALevelSequenceActor elevatorSequenceActor = this.ElevatorSequenceActor;
			ULevelSequencePlayer ulevelSequencePlayer = (elevatorSequenceActor != null) ? elevatorSequenceActor.SequencePlayer : null;
			if (ulevelSequencePlayer == null)
			{
				return;
			}
			ulevelSequencePlayer.PlayToSeconds(timeInSeconds);
		}

		// Token: 0x060303AC RID: 197548 RVA: 0x00BB9D20 File Offset: 0x00BB7F20
		[NullableContext(2)]
		private void DestroyAllSpawnedActors(ULevelSequencePlayer player)
		{
			if (player == null)
			{
				return;
			}
			TArray<UObject> allSpawnedObjects = player.GetAllSpawnedObjects();
			if (allSpawnedObjects == null)
			{
				return;
			}
			for (int i = 0; i < allSpawnedObjects.Num(); i++)
			{
				UObject uobject = allSpawnedObjects.Get(i);
				if (uobject != null && uobject.IsValid())
				{
					AActor aactor = uobject as AActor;
					if (aactor != null)
					{
						aactor.K2_DestroyActor();
					}
				}
			}
		}

		// Token: 0x060303AD RID: 197549 RVA: 0x00BB9D70 File Offset: 0x00BB7F70
		private void TickSequenceMove(float deltaSeconds)
		{
			if (this.ElevatorSequenceActor == null || this.ElevatorSequence == null)
			{
				this.SeqPlayedTime = this.SeqTargetTime;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CK;
				string message = "TickSequenceMove: ElevatorSequenceActor 或 ElevatorSequence 异常丢失";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityConfigId", this.Ctx.EntityConfigId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			float num = deltaSeconds * 0.001f;
			if (num <= 0f)
			{
				return;
			}
			float num2 = MathF.Abs(this.SeqTargetTime - this.SeqPlayedTime);
			if (num + 0.001f >= num2)
			{
				this.SeqPlayedTime = this.SeqTargetTime;
				this.SeqAccumulatedTime = 0f;
				this.PlaySequenceTo(this.SeqPlayedTime);
				return;
			}
			float frameSeconds = Singleton<GameSettingsDeviceRender>.Instance.FrameSeconds;
			float num3 = (float.IsFinite(frameSeconds) && frameSeconds > 0f) ? frameSeconds : 0.016666668f;
			float num4 = num3 * 0.5f;
			float num5 = num3 * 3f;
			this.SeqAccumulatedTime += num;
			if (this.SeqAccumulatedTime < num4)
			{
				return;
			}
			float num6 = this.SeqAccumulatedTime;
			this.SeqAccumulatedTime = 0f;
			if (num6 > num5)
			{
				num6 = num5;
			}
			if (num6 + 0.001f >= num2)
			{
				this.SeqPlayedTime = this.SeqTargetTime;
			}
			else
			{
				int num7 = (this.SeqTargetTime > this.SeqPlayedTime) ? 1 : -1;
				this.SeqPlayedTime += num6 * (float)num7;
			}
			this.PlaySequenceTo(this.SeqPlayedTime);
		}

		// Token: 0x060303AE RID: 197550 RVA: 0x00BB9ED8 File Offset: 0x00BB80D8
		private void SequenceMoveFinish(Action onMoveArrived)
		{
			this.SeqPlayedTime = this.SeqTargetTime;
			this.PlaySequenceTo(this.SeqTargetTime);
			if (this.IsAnnularMoving)
			{
				this.IsAnnularMoving = false;
				float sequenceStartTime = this.GetSequenceStartTime();
				this.SeqPlayedTime = sequenceStartTime;
				this.SeqTargetTime = this.AnnularMoveTargetTime;
				this.SeqAccumulatedTime = 0f;
				this.SeekSequenceTo(sequenceStartTime);
				if (this.IsSequenceTimeReached(this.SeqPlayedTime, this.SeqTargetTime))
				{
					this.ExitAnimTickState();
					onMoveArrived();
				}
				return;
			}
			this.ExitAnimTickState();
			onMoveArrived();
		}

		// Token: 0x060303AF RID: 197551 RVA: 0x00BB9F68 File Offset: 0x00BB8168
		private unsafe bool PlayElevatorSequence(string targetMark)
		{
			if (this.ElevatorSequenceActor == null || this.ElevatorSequence == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CK;
				string message = "PlayElevatorSequence ElevatorSequenceActor未就绪";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", this.Ctx.EntityConfigId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurFloor", this.Ctx.CurFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TargetFloor", this.Ctx.TargetFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("TargetMark", targetMark);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("SeqPlayedTime", this.SeqPlayedTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("SeqTargetTime", this.SeqTargetTime);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
				return false;
			}
			float? markTimeInSeconds = this.GetMarkTimeInSeconds(this.ElevatorSequence, targetMark);
			if (markTimeInSeconds == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.CK;
				string message2 = "PlayElevatorSequence Mark配置非法";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityConfigId", this.Ctx.EntityConfigId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("CurFloor", this.Ctx.CurFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("TargetFloor", this.Ctx.TargetFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("TargetMark", targetMark);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("SeqPlayedTime", this.SeqPlayedTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 5) = new ValueTuple<string, object>("SeqTargetTime", this.SeqTargetTime);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 6));
				return false;
			}
			if (this.Ctx.IsAnnular && this.ElevatorSequenceActor != null && markTimeInSeconds.Value < this.SeqPlayedTime - 0.001f)
			{
				this.IsAnnularMoving = true;
				this.AnnularMoveTargetTime = markTimeInSeconds.Value;
				this.SeqTargetTime = this.GetSequenceEndTime();
				this.SeqAccumulatedTime = 0f;
				return true;
			}
			this.IsAnnularMoving = false;
			this.SeqTargetTime = markTimeInSeconds.Value;
			this.SeqAccumulatedTime = 0f;
			return true;
		}

		// Token: 0x060303B0 RID: 197552 RVA: 0x00BBA208 File Offset: 0x00BB8408
		private float? GetMarkTimeInSeconds(ULevelSequence levelSequence, string markName)
		{
			UMovieScene movieScene = levelSequence.GetMovieScene();
			if (movieScene == null)
			{
				return null;
			}
			FFrameRate tickResolution = movieScene.TickResolution;
			if (tickResolution.Numerator == 0)
			{
				return null;
			}
			for (int i = 0; i < movieScene.MarkedFrames.Num(); i++)
			{
				FMovieSceneMarkedFrame fmovieSceneMarkedFrame = movieScene.MarkedFrames.Get(i);
				if (fmovieSceneMarkedFrame.Label == markName)
				{
					return new float?((float)fmovieSceneMarkedFrame.FrameNumber.Value * (float)tickResolution.Denominator / (float)tickResolution.Numerator);
				}
			}
			return null;
		}

		// Token: 0x060303B1 RID: 197553 RVA: 0x00BBA2A4 File Offset: 0x00BB84A4
		private float GetSequenceStartTime()
		{
			ALevelSequenceActor elevatorSequenceActor = this.ElevatorSequenceActor;
			if (((elevatorSequenceActor != null) ? elevatorSequenceActor.SequencePlayer : null) == null)
			{
				return 0f;
			}
			FQualifiedFrameTime startTime = this.ElevatorSequenceActor.SequencePlayer.GetStartTime();
			return ((float)startTime.Time.FrameNumber.Value + startTime.Time.SubFrame) * (float)startTime.Rate.Denominator / (float)startTime.Rate.Numerator;
		}

		// Token: 0x060303B2 RID: 197554 RVA: 0x00BBA314 File Offset: 0x00BB8514
		private float GetSequenceEndTime()
		{
			ALevelSequenceActor elevatorSequenceActor = this.ElevatorSequenceActor;
			if (((elevatorSequenceActor != null) ? elevatorSequenceActor.SequencePlayer : null) == null)
			{
				return 0f;
			}
			FQualifiedFrameTime endTime = this.ElevatorSequenceActor.SequencePlayer.GetEndTime();
			return ((float)endTime.Time.FrameNumber.Value + endTime.Time.SubFrame) * (float)endTime.Rate.Denominator / (float)endTime.Rate.Numerator;
		}

		// Token: 0x060303B3 RID: 197555 RVA: 0x00BBA384 File Offset: 0x00BB8584
		private void ApplySequenceCenterOffset()
		{
			if (this.ElevatorSequenceActor == null)
			{
				return;
			}
			FVectorDouble fvectorDouble = new FVectorDouble();
			ULevelSequence sequence = this.ElevatorSequenceActor.GetSequence();
			if (!((sequence != null) ? new bool?(sequence.D_GetCenterOffset(ref fvectorDouble)) : null).GetValueOrDefault())
			{
				fvectorDouble.Set(0.0, 0.0, 0.0);
			}
			this.ElevatorSequenceActor.bOverrideInstanceData = true;
			UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData = this.ElevatorSequenceActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
			if (udefaultLevelSequenceInstanceData != null)
			{
				UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData2 = udefaultLevelSequenceInstanceData;
				FVector fvector = fvectorDouble.ToVector();
				udefaultLevelSequenceInstanceData2.TransformOrigin = new FTransform(ref fvector);
			}
		}

		// Token: 0x060303B4 RID: 197556 RVA: 0x00BBA429 File Offset: 0x00BB8629
		private bool IsSequenceTimeReached(float timeA, float timeB)
		{
			return MathF.Abs(timeA - timeB) <= 0.001f;
		}

		// Token: 0x060303B5 RID: 197557 RVA: 0x00BBA440 File Offset: 0x00BB8640
		private void InitSequenceSkeletalMeshes()
		{
			this.SequenceSkeletalMeshes.Clear();
			ALevelSequenceActor elevatorSequenceActor = this.ElevatorSequenceActor;
			ULevelSequencePlayer ulevelSequencePlayer = (elevatorSequenceActor != null) ? elevatorSequenceActor.SequencePlayer : null;
			ULevelSequence elevatorSequence = this.ElevatorSequence;
			if (ulevelSequencePlayer == null || elevatorSequence == null)
			{
				return;
			}
			ElevatorSequenceMoveStrategy.<>c__DisplayClass41_0 CS$<>8__locals1;
			CS$<>8__locals1.collected = new HashSet<USkeletalMeshComponent>();
			TArray<UObject> allSpawnedObjects = ulevelSequencePlayer.GetAllSpawnedObjects();
			if (allSpawnedObjects != null)
			{
				for (int i = 0; i < allSpawnedObjects.Num(); i++)
				{
					ElevatorSequenceMoveStrategy.<InitSequenceSkeletalMeshes>g__collectFromActor|41_0(allSpawnedObjects.Get(i), ref CS$<>8__locals1);
				}
			}
			SceneItemReferenceComponent component = this.Ctx.Entity.GetComponent<SceneItemReferenceComponent>();
			List<AActor> list = (component != null) ? component.GetAllRefActors() : null;
			if (list != null)
			{
				foreach (AActor obj in list)
				{
					ElevatorSequenceMoveStrategy.<InitSequenceSkeletalMeshes>g__collectFromActor|41_0(obj, ref CS$<>8__locals1);
				}
			}
			foreach (USkeletalMeshComponent uskeletalMeshComponent in CS$<>8__locals1.collected)
			{
				uskeletalMeshComponent.SetTickGroup(ETickingGroup.TG_PostUpdateWork);
				this.SequenceSkeletalMeshes.Add(uskeletalMeshComponent);
			}
		}

		// Token: 0x060303B6 RID: 197558 RVA: 0x00BBA56C File Offset: 0x00BB876C
		private void EnterAnimTickState()
		{
			if (this.IsAnimTickOptimizeActive)
			{
				return;
			}
			this.IsAnimTickOptimizeActive = true;
			this.AnimTickOriginalOptions.Clear();
			foreach (USkeletalMeshComponent uskeletalMeshComponent in this.SequenceSkeletalMeshes)
			{
				if (uskeletalMeshComponent != null && uskeletalMeshComponent.IsValid())
				{
					this.AnimTickOriginalOptions[uskeletalMeshComponent] = uskeletalMeshComponent.VisibilityBasedAnimTickOption;
					uskeletalMeshComponent.VisibilityBasedAnimTickOption = EVisibilityBasedAnimTickOption.AlwaysTickPoseAndRefreshBones;
				}
			}
		}

		// Token: 0x060303B7 RID: 197559 RVA: 0x00BBA5F8 File Offset: 0x00BB87F8
		private void ExitAnimTickState()
		{
			if (!this.IsAnimTickOptimizeActive)
			{
				return;
			}
			this.IsAnimTickOptimizeActive = false;
			foreach (KeyValuePair<USkeletalMeshComponent, EVisibilityBasedAnimTickOption> keyValuePair in this.AnimTickOriginalOptions)
			{
				USkeletalMeshComponent uskeletalMeshComponent;
				EVisibilityBasedAnimTickOption evisibilityBasedAnimTickOption;
				keyValuePair.Deconstruct(out uskeletalMeshComponent, out evisibilityBasedAnimTickOption);
				USkeletalMeshComponent uskeletalMeshComponent2 = uskeletalMeshComponent;
				EVisibilityBasedAnimTickOption visibilityBasedAnimTickOption = evisibilityBasedAnimTickOption;
				if (uskeletalMeshComponent2 != null && uskeletalMeshComponent2.IsValid())
				{
					uskeletalMeshComponent2.VisibilityBasedAnimTickOption = visibilityBasedAnimTickOption;
				}
			}
			this.AnimTickOriginalOptions.Clear();
		}

		// Token: 0x060303B8 RID: 197560 RVA: 0x00BBA684 File Offset: 0x00BB8884
		private void ReleaseElevatorSequenceActor()
		{
			this.ClearPendingRefActorReadyCallback();
			this.SequenceLoadRequestId++;
			if (this.ElevatorSequenceActor != null)
			{
				ULevelSequencePlayer sequencePlayer = this.ElevatorSequenceActor.SequencePlayer;
				if (sequencePlayer != null)
				{
					sequencePlayer.Stop();
				}
				this.DestroyAllSpawnedActors(sequencePlayer);
				ALevelSequenceActor sequenceActor = this.ElevatorSequenceActor;
				TimerSystem.Instance.Next(delegate(float _)
				{
					Singleton<ActorSystem>.Instance.Put("GamePlayElevatorComponent.ReleaseElevatorSequenceActor", sequenceActor, null);
				}, null, null);
				this.ElevatorSequenceActor = null;
			}
			this.ElevatorSequence = null;
		}

		// Token: 0x060303B9 RID: 197561 RVA: 0x00BBA704 File Offset: 0x00BB8904
		private unsafe void LoadSequenceAsync(Action<ULevelSequence> callback)
		{
			ElevatorSequenceMoveStrategy.<>c__DisplayClass45_0 CS$<>8__locals1 = new ElevatorSequenceMoveStrategy.<>c__DisplayClass45_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			ElevatorSequenceMoveStrategy.<>c__DisplayClass45_0 CS$<>8__locals2 = CS$<>8__locals1;
			ILiftFloorSeqMarkConfig floorSeqMarkConfig = this.FloorSeqMarkConfig;
			CS$<>8__locals2.sequencePath = ((floorSeqMarkConfig != null) ? floorSeqMarkConfig.SequencePath : null);
			if (string.IsNullOrEmpty(CS$<>8__locals1.sequencePath))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CK;
				string message = "LoadSequenceAsync 缺少SequencePath";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityConfigId", this.Ctx.EntityConfigId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			ElevatorSequenceMoveStrategy.<>c__DisplayClass45_0 CS$<>8__locals3 = CS$<>8__locals1;
			int num = this.SequenceLoadRequestId + 1;
			this.SequenceLoadRequestId = num;
			CS$<>8__locals3.requestId = num;
			Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(CS$<>8__locals1.sequencePath, delegate([Nullable(2)] ULevelSequence loadedSequence, string _)
			{
				if (CS$<>8__locals1.requestId != CS$<>8__locals1.<>4__this.SequenceLoadRequestId)
				{
					return;
				}
				if (loadedSequence == null || !loadedSequence.IsValid())
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.SceneItem;
					ELogAuthor author2 = ELogAuthor.CK;
					string message2 = "Sequence异步加载失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", CS$<>8__locals1.<>4__this.Ctx.EntityConfigId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SequencePath", CS$<>8__locals1.sequencePath);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				CS$<>8__locals1.callback(loadedSequence);
			}, 100, "js_undefined");
		}

		// Token: 0x060303BA RID: 197562 RVA: 0x00BBA7BC File Offset: 0x00BB89BC
		private bool InitElevatorSequenceActor(ULevelSequence sequence)
		{
			if (this.ElevatorSequenceActor != null)
			{
				return true;
			}
			this.ReleaseElevatorSequenceActor();
			this.ElevatorSequence = sequence;
			this.ElevatorSequenceActor = Singleton<ActorSystem>.Instance.Get<ALevelSequenceActor>(ALevelSequenceActor.StaticClass(), new FTransformDouble(), null, false);
			if (this.ElevatorSequenceActor == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CK;
				string message = "获取LevelSequenceActor失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityConfigId", this.Ctx.EntityConfigId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			this.ElevatorSequenceActor.SetSequence(sequence);
			ULevelSequencePlayer sequencePlayer = this.ElevatorSequenceActor.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Play();
				sequencePlayer.SetPlayRate(0f);
				sequencePlayer.Pause();
			}
			this.ApplySequenceCenterOffset();
			this.InitSequenceSkeletalMeshes();
			return true;
		}

		// Token: 0x060303BB RID: 197563 RVA: 0x00BBA87C File Offset: 0x00BB8A7C
		private void WaitRefActorsReady(Action onReady)
		{
			ElevatorSequenceMoveStrategy.<>c__DisplayClass47_0 CS$<>8__locals1 = new ElevatorSequenceMoveStrategy.<>c__DisplayClass47_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.onReady = onReady;
			this.ClearPendingRefActorReadyCallback();
			CS$<>8__locals1.refComp = this.Ctx.Entity.GetComponent<SceneItemReferenceComponent>();
			if (CS$<>8__locals1.refComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CK;
				string message = "Sequence电梯不存在SceneItemReferenceComponent";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityConfigId", this.Ctx.EntityConfigId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (CS$<>8__locals1.refComp.AllActorReady)
			{
				CS$<>8__locals1.onReady();
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.SceneItem;
			ELogAuthor author2 = ELogAuthor.CK;
			string message2 = "Sequence电梯引用Actor未全部就绪, 等待加载完成";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityConfigId", this.Ctx.EntityConfigId);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.PendingRefActorReadyCallback = new Action<string, AActor>(CS$<>8__locals1.<WaitRefActorsReady>g__Callback|0);
			CS$<>8__locals1.refComp.AddOnRefActorReadyCallback(this.PendingRefActorReadyCallback);
		}

		// Token: 0x060303BC RID: 197564 RVA: 0x00BBA96A File Offset: 0x00BB8B6A
		private void ClearPendingRefActorReadyCallback()
		{
			if (this.PendingRefActorReadyCallback == null)
			{
				return;
			}
			SceneItemReferenceComponent component = this.Ctx.Entity.GetComponent<SceneItemReferenceComponent>();
			if (component != null)
			{
				component.RemoveOnRefActorReadyCallback(this.PendingRefActorReadyCallback);
			}
			this.PendingRefActorReadyCallback = null;
		}

		// Token: 0x060303BD RID: 197565 RVA: 0x00BBA9A0 File Offset: 0x00BB8BA0
		private unsafe void InitFloorSeqMarkConfig()
		{
			this.FloorSeqMarks = new List<string>();
			SceneItemReferenceComponent component = this.Ctx.Entity.GetComponent<SceneItemReferenceComponent>();
			this.FloorSeqMarkConfig = ((component != null) ? component.GetLiftFloorSeqMarkConfig() : null);
			ILiftFloorSeqMarkConfig floorSeqMarkConfig = this.FloorSeqMarkConfig;
			if (string.IsNullOrEmpty((floorSeqMarkConfig != null) ? floorSeqMarkConfig.SequencePath : null) || this.FloorSeqMarkConfig.FloorMarks == null || this.FloorSeqMarkConfig.FloorMarks.Count == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CK;
				string message = "UseFloorSeqMarkMapping开启但SceneItemReferenceComponent映射配置缺失";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityConfigId", this.Ctx.EntityConfigId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			List<ILiftFloorSeqMark> list = new List<ILiftFloorSeqMark>();
			foreach (ILiftFloorSeqMark liftFloorSeqMark in this.FloorSeqMarkConfig.FloorMarks)
			{
				if (liftFloorSeqMark != null && liftFloorSeqMark.Floor != 0 && !string.IsNullOrEmpty(liftFloorSeqMark.Mark))
				{
					list.Add(liftFloorSeqMark);
				}
			}
			list.Sort((ILiftFloorSeqMark a, ILiftFloorSeqMark b) => a.Floor - b.Floor);
			if (list.Count == 0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.CK;
				string message2 = "FloorSeqMarkConfig中无有效楼层配置";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityConfigId", this.Ctx.EntityConfigId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				int num = i + 1;
				if (list[i].Floor != num)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.SceneItem;
					ELogAuthor author3 = ELogAuthor.CK;
					string message3 = "FloorSeqMarkConfig楼层配置非法, Floor必须从1开始且连续递增";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", this.Ctx.EntityConfigId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExpectedFloor", num);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ActualFloor", list[i].Floor);
					instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					return;
				}
			}
			this.FloorSeqMarks = new List<string>();
			foreach (ILiftFloorSeqMark liftFloorSeqMark2 in list)
			{
				this.FloorSeqMarks.Add(liftFloorSeqMark2.Mark);
			}
		}

		// Token: 0x060303BE RID: 197566 RVA: 0x00BBAC3C File Offset: 0x00BB8E3C
		[NullableContext(2)]
		private unsafe void JumpElevatorSequenceToInitFloor(Action onComplete = null)
		{
			int initFloor = this.Ctx.CurFloor;
			string targetMark = this.GetFloorMark(initFloor);
			if (!string.IsNullOrEmpty(targetMark))
			{
				this.LoadSequenceAsync(delegate(ULevelSequence loadedSequence)
				{
					this.WaitRefActorsReady(delegate
					{
						if (!this.InitElevatorSequenceActor(loadedSequence))
						{
							Action onComplete3 = onComplete;
							if (onComplete3 == null)
							{
								return;
							}
							onComplete3();
							return;
						}
						else
						{
							float? markTimeInSeconds = this.GetMarkTimeInSeconds(loadedSequence, targetMark);
							if (markTimeInSeconds == null)
							{
								Log instance2 = Singleton<Log>.Instance;
								ELogModule module2 = ELogModule.SceneItem;
								ELogAuthor author2 = ELogAuthor.CK;
								string message2 = "JumpElevatorSequenceToInitFloor Mark配置非法";
								<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityConfigId", this.Ctx.EntityConfigId);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Mark", targetMark);
								instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
								Action onComplete4 = onComplete;
								if (onComplete4 == null)
								{
									return;
								}
								onComplete4();
								return;
							}
							else
							{
								this.SeqPlayedTime = markTimeInSeconds.Value;
								this.SeqTargetTime = markTimeInSeconds.Value;
								this.PlaySequenceTo(markTimeInSeconds.Value);
								Log instance3 = Singleton<Log>.Instance;
								ELogModule module3 = ELogModule.SceneItem;
								ELogAuthor author3 = ELogAuthor.CK;
								string message3 = "JumpElevatorSequenceToInitFloor 完成";
								<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("EntityConfigId", this.Ctx.EntityConfigId);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("InitFloor", initFloor);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("TargetTime", markTimeInSeconds);
								instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
								Action onComplete5 = onComplete;
								if (onComplete5 == null)
								{
									return;
								}
								onComplete5();
								return;
							}
						}
					});
				});
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SceneItem;
			ELogAuthor author = ELogAuthor.CK;
			string message = "JumpElevatorSequenceToInitFloor 找不到初始楼层对应Mark";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", this.Ctx.EntityConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("InitFloor", initFloor);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			Action onComplete2 = onComplete;
			if (onComplete2 == null)
			{
				return;
			}
			onComplete2();
		}

		// Token: 0x060303BF RID: 197567 RVA: 0x00BBAD1C File Offset: 0x00BB8F1C
		private unsafe void PrepareSequenceMove(int targetFloor, Action onReady)
		{
			if (string.IsNullOrEmpty(this.GetFloorMark(targetFloor)))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CK;
				string message = "电梯楼层-SeqMark映射缺少目标楼层Mark";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", this.Ctx.EntityConfigId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurFloor", this.Ctx.CurFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TargetFloor", targetFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("FloorSeqMarkCount", this.FloorSeqMarks.Count);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				return;
			}
			this.LoadSequenceAsync(delegate(ULevelSequence loadedSequence)
			{
				this.WaitRefActorsReady(delegate
				{
					if (!this.InitElevatorSequenceActor(loadedSequence))
					{
						return;
					}
					onReady();
				});
			});
		}

		// Token: 0x060303C0 RID: 197568 RVA: 0x00BBAE18 File Offset: 0x00BB9018
		public unsafe override bool OnBeforeEnterMoving()
		{
			int targetFloor = this.Ctx.TargetFloor;
			string floorMark = this.GetFloorMark(targetFloor);
			if (string.IsNullOrEmpty(floorMark))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CK;
				string message = "OnBeforeEnterMoving Failed, Missing Target Mark";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", this.Ctx.EntityConfigId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurFloor", this.Ctx.CurFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TargetFloor", targetFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("FloorSeqMarkCount", this.FloorSeqMarks.Count);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				return false;
			}
			return this.PlayElevatorSequence(floorMark);
		}

		// Token: 0x060303C1 RID: 197569 RVA: 0x00BBAF02 File Offset: 0x00BB9102
		public override void OnEnterMovePhase()
		{
			this.EnterAnimTickState();
		}

		// Token: 0x060303C2 RID: 197570 RVA: 0x00BBAF0A File Offset: 0x00BB910A
		[NullableContext(2)]
		private string GetFloorMark(int floor)
		{
			if (floor < 1 || floor > this.FloorSeqMarks.Count)
			{
				return null;
			}
			return this.FloorSeqMarks[floor - 1];
		}

		// Token: 0x060303C4 RID: 197572 RVA: 0x00BBAF58 File Offset: 0x00BB9158
		[NullableContext(2)]
		[CompilerGenerated]
		internal static void <InitSequenceSkeletalMeshes>g__collectFromActor|41_0(UObject obj, ref ElevatorSequenceMoveStrategy.<>c__DisplayClass41_0 A_1)
		{
			if (obj != null && obj.IsValid())
			{
				AActor aactor = obj as AActor;
				if (aactor != null)
				{
					TArray<UActorComponent> tarray = aactor.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
					for (int i = 0; i < tarray.Num(); i++)
					{
						USkeletalMeshComponent uskeletalMeshComponent = tarray.Get(i) as USkeletalMeshComponent;
						if (uskeletalMeshComponent != null)
						{
							A_1.collected.Add(uskeletalMeshComponent);
						}
					}
					return;
				}
			}
		}

		// Token: 0x0401BB21 RID: 113441
		private const float SEQUENCE_TIME_EPSILON = 0.001f;

		// Token: 0x0401BB22 RID: 113442
		private const float MIN_STEP_FRAME_RATIO = 0.5f;

		// Token: 0x0401BB23 RID: 113443
		private const float MAX_STEP_FRAME_RATIO = 3f;

		// Token: 0x0401BB24 RID: 113444
		private const float DEFAULT_NOMINAL_FRAME_SECONDS = 0.016666668f;

		// Token: 0x0401BB25 RID: 113445
		[Nullable(2)]
		private ALevelSequenceActor ElevatorSequenceActor;

		// Token: 0x0401BB26 RID: 113446
		[Nullable(2)]
		private ULevelSequence ElevatorSequence;

		// Token: 0x0401BB27 RID: 113447
		private float SeqPlayedTime;

		// Token: 0x0401BB28 RID: 113448
		private float SeqTargetTime;

		// Token: 0x0401BB29 RID: 113449
		private float SeqAccumulatedTime;

		// Token: 0x0401BB2A RID: 113450
		[Nullable(2)]
		private ILiftFloorSeqMarkConfig FloorSeqMarkConfig;

		// Token: 0x0401BB2B RID: 113451
		private List<string> FloorSeqMarks = new List<string>();

		// Token: 0x0401BB2C RID: 113452
		private int SequenceLoadRequestId;

		// Token: 0x0401BB2D RID: 113453
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Action<string, AActor> PendingRefActorReadyCallback;

		// Token: 0x0401BB2E RID: 113454
		private bool IsAnnularMoving;

		// Token: 0x0401BB2F RID: 113455
		private float AnnularMoveTargetTime;

		// Token: 0x0401BB30 RID: 113456
		private bool IsAnimTickOptimizeActive;

		// Token: 0x0401BB31 RID: 113457
		private readonly List<USkeletalMeshComponent> SequenceSkeletalMeshes = new List<USkeletalMeshComponent>();

		// Token: 0x0401BB32 RID: 113458
		private readonly Dictionary<USkeletalMeshComponent, EVisibilityBasedAnimTickOption> AnimTickOriginalOptions = new Dictionary<USkeletalMeshComponent, EVisibilityBasedAnimTickOption>();

		// Token: 0x0401BB33 RID: 113459
		private bool IsInitializingFlag;
	}
}
