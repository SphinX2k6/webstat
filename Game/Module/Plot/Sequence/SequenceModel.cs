using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.BaseSeqCharacter;
using AkiClient.Game.Aki.Sequence.Manager;
using CSharpScript.Game.Module.Plot.Flow;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence
{
	// Token: 0x0200538A RID: 21386
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SequenceModel : ModelBase<SequenceModel>
	{
		// Token: 0x17008D94 RID: 36244
		// (get) Token: 0x060368AC RID: 223404 RVA: 0x00DC941C File Offset: 0x00DC761C
		public bool DoNotHandlePlayerForControlEntityMode
		{
			get
			{
				return this.IsControlEntity && !ModelBase<PlotModel>.Instance.PlotConfig.HandlePlayerInControlEntityMode;
			}
		}

		// Token: 0x060368AD RID: 223405 RVA: 0x00DC943C File Offset: 0x00DC763C
		public void Reset()
		{
			this.IsPaused = null;
			this.Config = null;
			this.SequenceData = null;
			this.BindingActorMap.Clear();
			this.BindingEntityMap.Clear();
			this.ControlEntityMap.Clear();
			this.FrameEvents.Clear();
			this.ActionQueue.Clear();
			this.FrameEventsMap.Clear();
			this.IsViewTargetControl = null;
			this.IsSubtitleUiUse = null;
			this.PreviousMotionBlur = null;
			this.SubSeqLen = null;
			this.SubSeqIndex = -2;
			this.PlayRate = 1f;
			this.SeqMainCharacter = null;
			this.NeedsQueueLatentAction = null;
			this.CurLevelSeqActor = null;
			this.LatentActions.Clear();
			this.LastIndex = -2;
			this.NextIndex = -2;
			this.HidePlayerEntityHandle = null;
			this.CurSubtitleStartFrames.Clear();
			this.CurSubtitleEndFrames.Clear();
			this.CurShotStartFrames.Clear();
			this.CurShotEndFrames.Clear();
			this.CurFinalPos.Clear();
			this.IsFadeEnd.Clear();
			this.CurStartFrame = null;
			this.CurEndFrame = null;
			this.CurFrameRate = null;
			this.SelectedOption = null;
			this.CurSubtitle.Clear();
			this.Type = null;
			this.RelativeTransform = null;
			this.CurLanguageAudio = ELanguageAudio.All;
			this.NeedJumpWhenResume = false;
			this.AdditionSeqDirector = null;
			this.BlendInCharacters = new List<AActor>();
			this.BlendOutCharacters = new List<AActor>();
			this.NpcGroupPerform.Clear();
			this.NpcRelationMap.Clear();
			this.NeedHideNpcSet.Clear();
			this.QteKeyFrames.Clear();
			this.PlotBindingVehicle = null;
			this.NeedWaitSwitchSubLevelComplete = false;
			this.SkipUiWaiting = false;
			this.IsStartTransformBlending = false;
			this.StartTransformBlendElapsed = 0f;
			this.StartTransformBlendDuration = 0f;
			this.StartTransformBlendCallback = null;
			this.IsControlEntity = false;
			this.PauseFrame = null;
			if (this.ForceStreamHandle != null)
			{
				this.ForceStreamHandle.Cancel();
				this.ForceStreamHandle = null;
			}
		}

		// Token: 0x060368AE RID: 223406 RVA: 0x00DC9674 File Offset: 0x00DC7874
		[NullableContext(2)]
		public ULevelSequence GetCurrentSequence()
		{
			if (this.SubSeqIndex == -1)
			{
				return null;
			}
			if (this.SubSeqIndex == -2)
			{
				return null;
			}
			int subSeqIndex = this.SubSeqIndex;
			int? subSeqLen = this.SubSeqLen;
			if (!(subSeqIndex < subSeqLen.GetValueOrDefault() & subSeqLen != null))
			{
				return null;
			}
			BP_SequenceData_C sequenceData = this.SequenceData;
			if (sequenceData == null)
			{
				return null;
			}
			return sequenceData.剧情资源.Get(this.SubSeqIndex);
		}

		// Token: 0x060368AF RID: 223407 RVA: 0x00DC96D8 File Offset: 0x00DC78D8
		[NullableContext(2)]
		public SSequencesKeyFrames GetCurrentKeyFramesInfo()
		{
			BP_SequenceData_C sequenceData = this.SequenceData;
			bool flag;
			if (sequenceData == null)
			{
				flag = false;
			}
			else
			{
				BP_SequenceData_Generated_C generatedData = sequenceData.GeneratedData;
				flag = ((generatedData != null) ? new bool?(generatedData.KeyFrames.IsValidIndex(this.SubSeqIndex)) : null).GetValueOrDefault();
			}
			if (!flag)
			{
				return null;
			}
			return this.SequenceData.GeneratedData.KeyFrames.Get(this.SubSeqIndex);
		}

		// Token: 0x060368B0 RID: 223408 RVA: 0x00DC9742 File Offset: 0x00DC7942
		public bool IsFinish()
		{
			return this.SubSeqIndex == -1;
		}

		// Token: 0x17008D95 RID: 36245
		// (get) Token: 0x060368B1 RID: 223409 RVA: 0x00DC9750 File Offset: 0x00DC7950
		public bool HasBindingEntity
		{
			get
			{
				if (this.SequenceData == null)
				{
					return false;
				}
				TArray<FName> 绑定角色标签 = this.SequenceData.绑定角色标签;
				int num = 绑定角色标签.Num();
				for (int i = 0; i < num; i++)
				{
					FName fname = 绑定角色标签.Get(i);
					if (!(fname == SequenceDefine.HERO_TAG) && !fname.ToString().Contains("Perform_NPC") && !FNameUtil.IsEmpty(new FName?(fname)))
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x060368B2 RID: 223410 RVA: 0x00DC97C4 File Offset: 0x00DC79C4
		public bool WillFinish()
		{
			return this.NextIndex == -1;
		}

		// Token: 0x060368B3 RID: 223411 RVA: 0x00DC97CF File Offset: 0x00DC79CF
		public void QueueLatentAction(Action action)
		{
			this.LatentActions.Add(action);
		}

		// Token: 0x060368B4 RID: 223412 RVA: 0x00DC97E0 File Offset: 0x00DC79E0
		public void RunLatentActions()
		{
			foreach (Action action in this.LatentActions)
			{
				action();
			}
			this.LatentActions.Clear();
		}

		// Token: 0x060368B5 RID: 223413 RVA: 0x00DC983C File Offset: 0x00DC7A3C
		public bool GetLastFadeEnd()
		{
			return this.LastIndex >= 0 && this.IsFadeEnd.Count > this.LastIndex && this.IsFadeEnd[this.LastIndex];
		}

		// Token: 0x060368B6 RID: 223414 RVA: 0x00DC986D File Offset: 0x00DC7A6D
		[NullableContext(2)]
		public Transform GetLastTransform()
		{
			if (this.LastIndex < 0 || this.CurFinalPos.Count <= this.LastIndex)
			{
				return null;
			}
			return this.CurFinalPos[this.LastIndex];
		}

		// Token: 0x060368B7 RID: 223415 RVA: 0x00DC989E File Offset: 0x00DC7A9E
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ActionInfo> GetFrameEvents(string key)
		{
			return this.FrameEvents.GetValueOrDefault(key);
		}

		// Token: 0x060368B8 RID: 223416 RVA: 0x00DC98AC File Offset: 0x00DC7AAC
		public new EPlotSequenceType? GetType()
		{
			if (this.Type == null && !this.UseRuntimeData)
			{
				this.Type = new EPlotSequenceType?(this.SequenceData.类型);
			}
			return this.Type;
		}

		// Token: 0x060368B9 RID: 223417 RVA: 0x00DC98E4 File Offset: 0x00DC7AE4
		public bool HasSubtitle()
		{
			return this.CurSubtitleStartFrames.Count != 0 && this.CurSubtitleEndFrames.Count != 0;
		}

		// Token: 0x17008D96 RID: 36246
		// (get) Token: 0x060368BA RID: 223418 RVA: 0x00DC9903 File Offset: 0x00DC7B03
		public bool IsEnding
		{
			get
			{
				return this.State == ESequenceState.Ending;
			}
		}

		// Token: 0x17008D97 RID: 36247
		// (get) Token: 0x060368BB RID: 223419 RVA: 0x00DC990E File Offset: 0x00DC7B0E
		public bool IsPlaying
		{
			get
			{
				return this.State > ESequenceState.Null;
			}
		}

		// Token: 0x17008D98 RID: 36248
		// (get) Token: 0x060368BC RID: 223420 RVA: 0x00DC991C File Offset: 0x00DC7B1C
		public bool ShouldDelayToNextFrame
		{
			get
			{
				string flowName = ControllerBase<FlowController>.Instance.GetFlowName();
				return (string.IsNullOrEmpty(flowName) || !FlowLaunchResCheckHardCodingList.TempDisableNextFrameDelay.Contains(flowName)) && this.HasBindingEntity;
			}
		}

		// Token: 0x060368BD RID: 223421 RVA: 0x00DC9958 File Offset: 0x00DC7B58
		[NullableContext(2)]
		public void AddFinalPos(Transform trans)
		{
			if (trans == null)
			{
				this.CurFinalPos.Add(trans);
				return;
			}
			if (this.RelativeTransform != null)
			{
				Transform transform = Transform.Create();
				trans.ComposeTransforms(this.RelativeTransform, transform);
				this.CurFinalPos.Add(transform);
				return;
			}
			this.CurFinalPos.Add(trans);
		}

		// Token: 0x060368BE RID: 223422 RVA: 0x00DC99AC File Offset: 0x00DC7BAC
		public string GetPlayerBpClass()
		{
			PlayerInfoModel instance = ModelBase<PlayerInfoModel>.Instance;
			TSoftClassPtr<AActor> tsoftClassPtr;
			if (instance == null || instance.GetPlayerGender() != EPlayerGender.Male)
			{
				BP_SequenceData_Generated_C generatedData = this.SequenceData.GeneratedData;
				tsoftClassPtr = ((generatedData != null) ? generatedData.FemalePlayerBP : null);
			}
			else
			{
				BP_SequenceData_Generated_C generatedData2 = this.SequenceData.GeneratedData;
				tsoftClassPtr = ((generatedData2 != null) ? generatedData2.MalePlayerBP : null);
			}
			TSoftClassPtr<AActor> tsoftClassPtr2 = tsoftClassPtr;
			if (tsoftClassPtr2 != null)
			{
				return tsoftClassPtr2.ToAssetPathName();
			}
			ControllerBase<FlowController>.Instance.LogError("GeneratedDA不存在，联系演出刷DA", default(ReadOnlySpan<ValueTuple<string, object>>));
			PlayerInfoModel instance2 = ModelBase<PlayerInfoModel>.Instance;
			if (instance2 != null && instance2.GetPlayerGender() == EPlayerGender.Male)
			{
				return "/Game/Aki/Character/Role/MaleM/Nanzhu/Seq/BP_Nanzhu_Seq_V2.BP_Nanzhu_Seq_V2_C";
			}
			return "/Game/Aki/Character/Role/FemaleM/Nvzhu/Seq/BP_Nvzhu_Seq_V2.BP_Nvzhu_Seq_V2_C";
		}

		// Token: 0x060368BF RID: 223423 RVA: 0x00DC9A4C File Offset: 0x00DC7C4C
		public float GetCurrentPlayPosition()
		{
			if (this.State != ESequenceState.Playing)
			{
				return 0f;
			}
			float? num = new float?(0f);
			ALevelSequenceActor curLevelSeqActor = this.CurLevelSeqActor;
			int? num2;
			if (curLevelSeqActor == null)
			{
				num2 = null;
			}
			else
			{
				ULevelSequencePlayer sequencePlayer = curLevelSeqActor.SequencePlayer;
				num2 = ((sequencePlayer != null) ? new int?(sequencePlayer.GetCurrentTime().Time.FrameNumber.Value) : null);
			}
			int? num3 = num2;
			if (num3 != null)
			{
				float? num4 = num;
				int? num5 = num3;
				int? curStartFrame = this.CurStartFrame;
				num = num4 + ((num5 != null & curStartFrame != null) ? new float?((float)(num5.GetValueOrDefault() - curStartFrame.GetValueOrDefault())) : null) / this.CurFrameRate;
			}
			num += this.DurationOffset;
			return num.Value;
		}

		// Token: 0x060368C0 RID: 223424 RVA: 0x00DC9BB4 File Offset: 0x00DC7DB4
		public List<int> GetCurKeyFrames()
		{
			BP_SequenceData_C sequenceData = this.SequenceData;
			bool flag;
			if (sequenceData == null)
			{
				flag = (null != null);
			}
			else
			{
				BP_SequenceData_Generated_C generatedData = sequenceData.GeneratedData;
				flag = (((generatedData != null) ? generatedData.KeyFrames : null) != null);
			}
			if (!flag)
			{
				return new List<int>();
			}
			if (!this.SequenceData.GeneratedData.KeyFrames.IsValidIndex(this.SubSeqIndex))
			{
				return new List<int>();
			}
			return new List<int>(ObjectUtils.ueArrayToArray<int>(this.SequenceData.GeneratedData.KeyFrames.Get(this.SubSeqIndex).KeyFrames));
		}

		// Token: 0x0401F682 RID: 128642
		public ESequenceState State;

		// Token: 0x0401F683 RID: 128643
		public bool? IsPaused = new bool?(false);

		// Token: 0x0401F684 RID: 128644
		[Nullable(2)]
		public PlaySequenceData Config;

		// Token: 0x0401F685 RID: 128645
		[Nullable(2)]
		public BP_SequenceData_C SequenceData;

		// Token: 0x0401F686 RID: 128646
		[Nullable(2)]
		public USkeletalMesh MainSeqCharacterMesh;

		// Token: 0x0401F687 RID: 128647
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public TArray<UObject> TalkNpcList;

		// Token: 0x0401F688 RID: 128648
		public Dictionary<FName, AActor> BindingActorMap = new Dictionary<FName, AActor>();

		// Token: 0x0401F689 RID: 128649
		public Dictionary<FName, EntityHandle> BindingEntityMap = new Dictionary<FName, EntityHandle>();

		// Token: 0x0401F68A RID: 128650
		public Dictionary<int, SequenceEntityInfo> ControlEntityMap = new Dictionary<int, SequenceEntityInfo>();

		// Token: 0x0401F68B RID: 128651
		public Dictionary<string, List<ActionInfo>> FrameEvents = new Dictionary<string, List<ActionInfo>>();

		// Token: 0x0401F68C RID: 128652
		public Queue<string> ActionQueue = new Queue<string>(4);

		// Token: 0x0401F68D RID: 128653
		public Dictionary<int, HashSet<string>> FrameEventsMap = new Dictionary<int, HashSet<string>>();

		// Token: 0x0401F68E RID: 128654
		public bool? IsViewTargetControl = new bool?(false);

		// Token: 0x0401F68F RID: 128655
		public bool? IsSubtitleUiUse = new bool?(false);

		// Token: 0x0401F690 RID: 128656
		public bool? IsWaitRenderData = new bool?(false);

		// Token: 0x0401F691 RID: 128657
		public bool IsControlEntity;

		// Token: 0x0401F692 RID: 128658
		[Nullable(2)]
		public UKuroActorStreamingHandle ForceStreamHandle;

		// Token: 0x0401F693 RID: 128659
		public float? PreviousMotionBlur = new float?(0f);

		// Token: 0x0401F694 RID: 128660
		public int? SubSeqLen = new int?(0);

		// Token: 0x0401F695 RID: 128661
		public int SubSeqIndex = -2;

		// Token: 0x0401F696 RID: 128662
		public float PlayRate = 1f;

		// Token: 0x0401F697 RID: 128663
		[Nullable(2)]
		public BP_BaseRole_Seq_V2_C SeqMainCharacter;

		// Token: 0x0401F698 RID: 128664
		[Nullable(2)]
		public AActor BlendInCharacter;

		// Token: 0x0401F699 RID: 128665
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<AActor> BlendInCharacters = new List<AActor>();

		// Token: 0x0401F69A RID: 128666
		[Nullable(2)]
		public AActor BlendOutCharacter;

		// Token: 0x0401F69B RID: 128667
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<AActor> BlendOutCharacters = new List<AActor>();

		// Token: 0x0401F69C RID: 128668
		public bool? NeedsQueueLatentAction = new bool?(false);

		// Token: 0x0401F69D RID: 128669
		public List<Action> LatentActions = new List<Action>();

		// Token: 0x0401F69E RID: 128670
		public int LastIndex = -2;

		// Token: 0x0401F69F RID: 128671
		public int NextIndex = -2;

		// Token: 0x0401F6A0 RID: 128672
		[Nullable(2)]
		public EntityHandle HidePlayerEntityHandle;

		// Token: 0x0401F6A1 RID: 128673
		[Nullable(2)]
		public Action<bool> FinishCallback;

		// Token: 0x0401F6A2 RID: 128674
		public EPlotSequenceType? Type;

		// Token: 0x0401F6A3 RID: 128675
		[Nullable(2)]
		public Transform RelativeTransform;

		// Token: 0x0401F6A4 RID: 128676
		[Nullable(new byte[]
		{
			1,
			2
		})]
		public List<Transform> CurFinalPos = new List<Transform>();

		// Token: 0x0401F6A5 RID: 128677
		public List<bool> IsFadeEnd = new List<bool>();

		// Token: 0x0401F6A6 RID: 128678
		public ELanguageAudio CurLanguageAudio;

		// Token: 0x0401F6A7 RID: 128679
		public float? DurationOffset = new float?(0f);

		// Token: 0x0401F6A8 RID: 128680
		[Nullable(2)]
		public ALevelSequenceActor CurLevelSeqActor;

		// Token: 0x0401F6A9 RID: 128681
		public List<int> CurSubtitleStartFrames = new List<int>();

		// Token: 0x0401F6AA RID: 128682
		public List<int> CurSubtitleEndFrames = new List<int>();

		// Token: 0x0401F6AB RID: 128683
		public List<int> CurShotStartFrames = new List<int>();

		// Token: 0x0401F6AC RID: 128684
		public List<int> CurShotEndFrames = new List<int>();

		// Token: 0x0401F6AD RID: 128685
		public int? CurStartFrame = new int?(0);

		// Token: 0x0401F6AE RID: 128686
		public int? CurEndFrame = new int?(0);

		// Token: 0x0401F6AF RID: 128687
		public float? CurFrameRate = new float?(0f);

		// Token: 0x0401F6B0 RID: 128688
		public int? SelectedOption = new int?(0);

		// Token: 0x0401F6B1 RID: 128689
		public PlotSubtitleConfig CurSubtitle = new PlotSubtitleConfig();

		// Token: 0x0401F6B2 RID: 128690
		public bool NeedJumpWhenResume;

		// Token: 0x0401F6B3 RID: 128691
		public List<int> QteKeyFrames = new List<int>();

		// Token: 0x0401F6B4 RID: 128692
		public int? PauseFrame;

		// Token: 0x0401F6B5 RID: 128693
		public bool IsSubtitleConfigInit;

		// Token: 0x0401F6B6 RID: 128694
		public float DefaultGuardTime;

		// Token: 0x0401F6B7 RID: 128695
		public float DefaultAudioDelay;

		// Token: 0x0401F6B8 RID: 128696
		public float DefaultAudioTransitionDuration;

		// Token: 0x0401F6B9 RID: 128697
		public float? EndLeastTime;

		// Token: 0x0401F6BA RID: 128698
		public bool UseRuntimeData = true;

		// Token: 0x0401F6BB RID: 128699
		public bool IsSeamless;

		// Token: 0x0401F6BC RID: 128700
		public HashSet<int> MuteQteList = new HashSet<int>();

		// Token: 0x0401F6BD RID: 128701
		public bool IsMuteAllQte;

		// Token: 0x0401F6BE RID: 128702
		public FVectorDouble HidePos = new FVectorDouble(0.0, 0.0, -999999.0);

		// Token: 0x0401F6BF RID: 128703
		public float DisableMotionBlurFrame;

		// Token: 0x0401F6C0 RID: 128704
		public float BeginSwitchFrame;

		// Token: 0x0401F6C1 RID: 128705
		public bool TwiceAnimFlag;

		// Token: 0x0401F6C2 RID: 128706
		[Nullable(2)]
		public ALevelSequenceActor AdditionSeqDirector;

		// Token: 0x0401F6C3 RID: 128707
		public List<FName> NpcGroupPerform = new List<FName>();

		// Token: 0x0401F6C4 RID: 128708
		public Dictionary<FName, NpcRelation> NpcRelationMap = new Dictionary<FName, NpcRelation>();

		// Token: 0x0401F6C5 RID: 128709
		public HashSet<Entity> NeedHideNpcSet = new HashSet<Entity>();

		// Token: 0x0401F6C6 RID: 128710
		[Nullable(2)]
		public EntityHandle PlotBindingVehicle;

		// Token: 0x0401F6C7 RID: 128711
		public bool NeedWaitSwitchSubLevelComplete;

		// Token: 0x0401F6C8 RID: 128712
		public bool EnablingUiBlend;

		// Token: 0x0401F6C9 RID: 128713
		public bool IsStartTransformBlending;

		// Token: 0x0401F6CA RID: 128714
		public float StartTransformBlendElapsed;

		// Token: 0x0401F6CB RID: 128715
		public float StartTransformBlendDuration;

		// Token: 0x0401F6CC RID: 128716
		[Nullable(2)]
		public Action StartTransformBlendCallback;

		// Token: 0x0401F6CD RID: 128717
		public bool SkipUiWaiting;
	}
}
