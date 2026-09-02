using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Sequence.Manager;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot.Sequence;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Flow
{
	// Token: 0x02005406 RID: 21510
	[NullableContext(1)]
	[Nullable(0)]
	public class FlowSequence
	{
		// Token: 0x17008E10 RID: 36368
		// (get) Token: 0x06036EB5 RID: 224949 RVA: 0x00DEF198 File Offset: 0x00DED398
		public bool IsInit
		{
			get
			{
				return this.IsInitInner;
			}
		}

		// Token: 0x17008E11 RID: 36369
		// (get) Token: 0x06036EB6 RID: 224950 RVA: 0x00DEF1A0 File Offset: 0x00DED3A0
		public bool IsPlaying
		{
			get
			{
				return this.IsPlayingInner;
			}
		}

		// Token: 0x06036EB7 RID: 224951 RVA: 0x00DEF1A8 File Offset: 0x00DED3A8
		public void Clear()
		{
			this.IsInitInner = false;
			this.IsPlayingInner = false;
			this.CurShowTalk = null;
			this.IdIndexMap.Clear();
			this.NextSequenceIndex = -2;
			this.CurTalkItem = null;
			this.Context = null;
			this.IsSubtitleShowed = false;
			this.IsOptionSelected = false;
			this.IsSkipping = false;
			this.NextTalkIndex = null;
			this.FinalPos = null;
			this.IsFadeEnd.Clear();
			this.FrameEventsMap.Clear();
			this.FrameEvents.Clear();
			this.LastId = -1;
			this.LastHasOption = false;
			this.CurrentQte.Clear();
			this.QteLatentAction.Clear();
			if (this.DelayEnableSkipTimer != null)
			{
				TimerSystem.Instance.Remove(this.DelayEnableSkipTimer);
			}
			this.DelayEnableSkipTimer = null;
			this.NpcPerformArray.Clear();
			this.NpcPerformRelationMap.Clear();
		}

		// Token: 0x06036EB8 RID: 224952 RVA: 0x00DEF290 File Offset: 0x00DED490
		public void Init(ShowTalk inParams, FlowContext context)
		{
			this.Clear();
			this.CurShowTalk = inParams;
			if (this.CurShowTalk == null || StringUtils.IsEmpty(this.CurShowTalk.SequenceDataAsset))
			{
				ControllerBase<FlowController>.Instance.LogError("[FlowSequence] 配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.CurShowTalk.TalkSequence != null)
			{
				for (int i = 0; i < this.CurShowTalk.TalkSequence.Count; i++)
				{
					foreach (int key in this.CurShowTalk.TalkSequence[i])
					{
						if (!this.IdIndexMap.TryAdd(key, i))
						{
							ControllerBase<FlowController>.Instance.LogError("[FlowSequence] 初始化分段时Id重复", default(ReadOnlySpan<ValueTuple<string, object>>));
						}
					}
				}
			}
			this.Context = context;
			this.Context.CurTalkId = -1;
			this.Context.CurOptionId = -1;
			this.Context.CurSubActionId = 0;
			this.NextSequenceIndex = 0;
			this.NextTalkIndex = new int?(0);
			this.IsInitInner = true;
			Singleton<EventSystem>.Instance.Add<float>(EEventName.PlotSequencePlay, new Action<float>(this.OnSequenceStart));
		}

		// Token: 0x06036EB9 RID: 224953 RVA: 0x00DEF3D8 File Offset: 0x00DED5D8
		private void OnSequenceStart(float viewBlendDuration)
		{
			float num = viewBlendDuration * 1000f;
			if (num > 20f && num < 180000f)
			{
				this.DelayEnableSkipTimer = TimerSystem.Instance.Delay(delegate(float _)
				{
					ControllerBase<FlowController>.Instance.EnableSkip(true);
					this.DelayEnableSkipTimer = null;
				}, num, null, null, true, 1f);
				return;
			}
			ControllerBase<FlowController>.Instance.EnableSkip(true);
		}

		// Token: 0x06036EBA RID: 224954 RVA: 0x00DEF430 File Offset: 0x00DED630
		public void Start(bool bSeamless)
		{
			if (!this.IsInit || this.IsPlaying)
			{
				return;
			}
			this.IsPlayingInner = true;
			EPlotLevel? plotLevel = ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel;
			EPlotLevel eplotLevel = EPlotLevel.LevelA;
			if (plotLevel.GetValueOrDefault() == eplotLevel & plotLevel != null)
			{
				ModelBase<SequenceModel>.Instance.Type = new EPlotSequenceType?(EPlotSequenceType.过场);
			}
			else if (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelB)
			{
				ModelBase<SequenceModel>.Instance.Type = new EPlotSequenceType?(EPlotSequenceType.站桩);
			}
			ControllerBase<PlotController>.Instance.PlotViewManager.EmitPlotStartShowTalk(this.CurShowTalk);
			ModelBase<PlotModel>.Instance.CurShowTalk = this.CurShowTalk;
			ModelBase<PlotModel>.Instance.ResetOptionReadState(this.CurShowTalk);
			List<ISequenceFrameEvent> list = new List<ISequenceFrameEvent>();
			if (this.CurShowTalk.TalkFrameEvents != null)
			{
				foreach (IShowTalkFrameEvent showTalkFrameEvent in this.CurShowTalk.TalkFrameEvents)
				{
					list.Add(showTalkFrameEvent.FrameEvent);
					Dictionary<int, HashSet<string>> frameEventsMap = ModelBase<SequenceModel>.Instance.FrameEventsMap;
					IShowTalkFrameEventPosition position = showTalkFrameEvent.Position;
					HashSet<string> hashSet2;
					if (!frameEventsMap.ContainsKey((position != null) ? position.TalkItemId : 0))
					{
						HashSet<string> hashSet = new HashSet<string>();
						hashSet.Add(showTalkFrameEvent.FrameEvent.EventKey);
						ModelBase<SequenceModel>.Instance.FrameEventsMap.Add(showTalkFrameEvent.Position.TalkItemId, hashSet);
					}
					else if (ModelBase<SequenceModel>.Instance.FrameEventsMap.TryGetValue(showTalkFrameEvent.Position.TalkItemId, out hashSet2))
					{
						hashSet2.Add(showTalkFrameEvent.FrameEvent.EventKey);
						ModelBase<SequenceModel>.Instance.FrameEventsMap[showTalkFrameEvent.Position.TalkItemId] = hashSet2;
					}
				}
			}
			List<string> list2 = new List<string>();
			EPlotLevel? plotLevel2 = ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel;
			if ((plotLevel2.GetValueOrDefault() == EPlotLevel.LevelB || plotLevel2.GetValueOrDefault() == EPlotLevel.ControlEntity) && this.CurShowTalk.TalkItems != null)
			{
				foreach (ITalkItem talkItem in this.CurShowTalk.TalkItems)
				{
					string sequenceMouthAnimKey = SequenceMouthAnimUtil.GetSequenceMouthAnimKey(talkItem);
					if (sequenceMouthAnimKey != null && !list2.Contains(sequenceMouthAnimKey))
					{
						list2.Add(sequenceMouthAnimKey);
					}
				}
			}
			if (!this.Context.IsBackground)
			{
				bool flag = ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.ControlEntity;
				ControllerBase<SequenceController>.Instance.Play(new PlaySequenceData
				{
					Path = this.CurShowTalk.SequenceDataAsset,
					ResetCamera = this.CurShowTalk.ResetCamera,
					FrameEvents = list,
					SeqBlendAnim = this.CurShowTalk.SeqBlendAnim
				}, list2, new Action<bool>(this.OnSequenceStop), !flag, true, this.Context.IsWaitRenderData, 1f, bSeamless, flag);
				return;
			}
			ControllerBase<SequenceController>.Instance.ManualFinish();
			ControllerBase<SequenceController>.Instance.LoadData(new PlaySequenceData
			{
				Path = this.CurShowTalk.SequenceDataAsset,
				ResetCamera = this.CurShowTalk.ResetCamera,
				FrameEvents = list
			}, new Action(this.Skip));
		}

		// Token: 0x06036EBB RID: 224955 RVA: 0x00DEF784 File Offset: 0x00DED984
		public void Stop(bool isForced = false)
		{
			if (!this.IsInit)
			{
				return;
			}
			if (this.IsPlaying)
			{
				this.IsPlayingInner = false;
				ControllerBase<SequenceController>.Instance.ManualFinish();
			}
			this.StopPromise().ContinueWith(new Action(this.FinalHandle)).Forget();
		}

		// Token: 0x06036EBC RID: 224956 RVA: 0x00DEF7C4 File Offset: 0x00DED9C4
		private UniTask StopPromise()
		{
			FlowSequence.<StopPromise>d__35 <StopPromise>d__;
			<StopPromise>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StopPromise>d__.<>4__this = this;
			<StopPromise>d__.<>1__state = -1;
			<StopPromise>d__.<>t__builder.Start<FlowSequence.<StopPromise>d__35>(ref <StopPromise>d__);
			return <StopPromise>d__.<>t__builder.Task;
		}

		// Token: 0x06036EBD RID: 224957 RVA: 0x00DEF808 File Offset: 0x00DEDA08
		private void FinalHandle()
		{
			this.Context.CurTalkId = -1;
			this.Context.CurOptionId = -1;
			this.Context.CurSubActionId = 0;
			this.Context.CurShowTalk = null;
			this.Context.CurShowTalkActionId = 0;
			ModelBase<PlotModel>.Instance.ClearOptionReadState();
			ModelBase<PlotModel>.Instance.CurShowTalk = null;
			ModelBase<PlotModel>.Instance.OptionEnable = true;
			ControllerBase<FlowController>.Instance.EnableSkip(false);
			Singleton<EventSystem>.Instance.Remove<float>(EEventName.PlotSequencePlay, new Action<float>(this.OnSequenceStart));
			this.Clear();
			Singleton<EventSystem>.Instance.Emit(EEventName.PlotEndShowTalk);
			ControllerBase<FlowController>.Instance.RunNextAction();
		}

		// Token: 0x06036EBE RID: 224958 RVA: 0x00DEF8B8 File Offset: 0x00DEDAB8
		public void Skip()
		{
			if (!this.IsInit || !this.IsPlaying || this.IsSkipping)
			{
				return;
			}
			this.IsSkipping = true;
			if (ModelBase<SequenceModel>.Instance.CurFinalPos.Count != 0)
			{
				this.FinalPos = new List<Transform>(ModelBase<SequenceModel>.Instance.CurFinalPos);
			}
			foreach (bool item in ModelBase<SequenceModel>.Instance.IsFadeEnd)
			{
				this.IsFadeEnd.Add(item);
			}
			foreach (KeyValuePair<string, List<ActionInfo>> keyValuePair in ModelBase<SequenceModel>.Instance.FrameEvents)
			{
				this.FrameEvents[keyValuePair.Key] = keyValuePair.Value;
			}
			foreach (KeyValuePair<int, HashSet<string>> keyValuePair2 in ModelBase<SequenceModel>.Instance.FrameEventsMap)
			{
				this.FrameEventsMap[keyValuePair2.Key] = keyValuePair2.Value;
			}
			foreach (KeyValuePair<int, HashSet<string>> keyValuePair3 in ModelBase<SequenceModel>.Instance.FrameEventsMap)
			{
				this.FrameEventsMap[keyValuePair3.Key] = keyValuePair3.Value;
			}
			foreach (Entity entity in ModelBase<SequenceModel>.Instance.NeedHideNpcSet)
			{
				ControllerBase<CreatureController>.Instance.SetEntityEnable(entity, true, "显示NPC", false);
			}
			ModelBase<SequenceModel>.Instance.NeedHideNpcSet.Clear();
			EntityHandle plotBindingVehicle = ModelBase<SequenceModel>.Instance.PlotBindingVehicle;
			if (((plotBindingVehicle != null) ? plotBindingVehicle.Entity : null) != null)
			{
				CreatureController instance = ControllerBase<CreatureController>.Instance;
				EntityHandle plotBindingVehicle2 = ModelBase<SequenceModel>.Instance.PlotBindingVehicle;
				instance.SetEntityEnable((plotBindingVehicle2 != null) ? plotBindingVehicle2.Entity : null, true, "Plot enable vehicle", false);
				ModelBase<SequenceModel>.Instance.PlotBindingVehicle = null;
			}
			foreach (FName fname in ModelBase<SequenceModel>.Instance.NpcGroupPerform)
			{
				this.NpcPerformArray.Add(fname);
				NpcRelation value;
				if (ModelBase<SequenceModel>.Instance.NpcRelationMap.TryGetValue(fname, out value))
				{
					this.NpcPerformRelationMap[fname] = value;
				}
			}
			ControllerBase<SequenceController>.Instance.ManualFinish();
			this.IsPlayingInner = false;
			if (this.CurrentQte.Count > 0)
			{
				foreach (int talkId in new List<int>(this.CurrentQte.Keys))
				{
					this.OnQteEnd(talkId);
				}
			}
			if (this.IsSubtitleShowed)
			{
				this.OnSubtitleEnd(new int?(this.CurTalkItem.Id));
				return;
			}
			if (this.HasOption() && !this.IsOptionSelected)
			{
				ITalkItem curTalkItem = this.CurTalkItem;
				this.RunSequenceFrameEventsWhenSkip((curTalkItem != null) ? new int?(curTalkItem.Id) : null);
				this.OnSelectOption(ControllerBase<FlowController>.Instance.GetRecommendedOption(this.CurTalkItem));
				return;
			}
			int? nextTalkIndex = this.NextTalkIndex;
			int count = this.CurShowTalk.TalkItems.Count;
			if (nextTalkIndex.GetValueOrDefault() >= count & nextTalkIndex != null)
			{
				ITalkItem curTalkItem2 = this.CurTalkItem;
				this.RunSequenceFrameEventsWhenSkip((curTalkItem2 != null) ? new int?(curTalkItem2.Id) : null);
				this.OnSequenceStop(false);
				return;
			}
			ITalkItem curTalkItem3 = this.CurTalkItem;
			this.RunSequenceFrameEventsWhenSkip((curTalkItem3 != null) ? new int?(curTalkItem3.Id) : null);
			int id = this.CurShowTalk.TalkItems[this.NextTalkIndex.Value].Id;
			this.OnSubtitleStart(id);
			this.OnSubtitleEnd(new int?(id));
		}

		// Token: 0x06036EBF RID: 224959 RVA: 0x00DEFD20 File Offset: 0x00DEDF20
		private void SubtitleActionCallback(bool result)
		{
			if (this.SubtitleActionPromise != null)
			{
				CustomPromise subtitleActionPromise = this.SubtitleActionPromise;
				this.SubtitleActionPromise = null;
				subtitleActionPromise.SetResult();
			}
			if (!this.IsSkipping)
			{
				return;
			}
			if (!result)
			{
				return;
			}
			if (this.HasOption())
			{
				this.OnSelectOption(ControllerBase<FlowController>.Instance.GetRecommendedOption(this.CurTalkItem));
				return;
			}
			int? nextTalkIndex = this.NextTalkIndex;
			int count = this.CurShowTalk.TalkItems.Count;
			if (nextTalkIndex.GetValueOrDefault() >= count & nextTalkIndex != null)
			{
				this.OnSequenceStop(false);
				return;
			}
			int id = this.CurShowTalk.TalkItems[this.NextTalkIndex.Value].Id;
			this.OnSubtitleStart(id);
			this.OnSubtitleEnd(new int?(id));
		}

		// Token: 0x06036EC0 RID: 224960 RVA: 0x00DEFDE0 File Offset: 0x00DEDFE0
		private void OptionActionCallback(bool result)
		{
			if (this.OptionActionPromise != null)
			{
				CustomPromise optionActionPromise = this.OptionActionPromise;
				this.OptionActionPromise = null;
				optionActionPromise.SetResult();
			}
			if (!result)
			{
				return;
			}
			if (!this.IsSkipping)
			{
				return;
			}
			int? nextTalkIndex = this.NextTalkIndex;
			int count = this.CurShowTalk.TalkItems.Count;
			if (nextTalkIndex.GetValueOrDefault() >= count & nextTalkIndex != null)
			{
				this.OnSequenceStop(false);
				return;
			}
			int id = this.CurShowTalk.TalkItems[this.NextTalkIndex.Value].Id;
			this.OnSubtitleStart(id);
			this.OnSubtitleEnd(new int?(id));
		}

		// Token: 0x06036EC1 RID: 224961 RVA: 0x00DEFE80 File Offset: 0x00DEE080
		private bool HasOption()
		{
			ITalkItem curTalkItem = this.CurTalkItem;
			if (((curTalkItem != null) ? curTalkItem.Options : null) == null)
			{
				return false;
			}
			ITalkItem curTalkItem2 = this.CurTalkItem;
			if (curTalkItem2 == null)
			{
				return false;
			}
			List<ITalkOption> options = curTalkItem2.Options;
			int? num = (options != null) ? new int?(options.Count) : null;
			int num2 = 0;
			return num.GetValueOrDefault() > num2 & num != null;
		}

		// Token: 0x06036EC2 RID: 224962 RVA: 0x00DEFEE4 File Offset: 0x00DEE0E4
		private void CheckLastAndSetNew()
		{
			if (this.LastHasOption && !this.IsOptionSelected)
			{
				FlowController instance = ControllerBase<FlowController>.Instance;
				string text = "遗漏选项";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Miss TalkItem Id", this.LastId);
				instance.LogError(text, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			ITalkItem curTalkItem = this.CurTalkItem;
			this.LastId = ((curTalkItem != null) ? curTalkItem.Id : -1);
			this.LastHasOption = this.HasOption();
		}

		// Token: 0x06036EC3 RID: 224963 RVA: 0x00DEFF54 File Offset: 0x00DEE154
		public void OnJumpTalk(int talkId)
		{
			if (!this.IsInit)
			{
				return;
			}
			this.NextSequenceIndex = this.IdIndexMap.GetValueOrDefault(talkId, -1);
			ControllerBase<SequenceController>.Instance.SetNextSequenceIndex(this.NextSequenceIndex);
			this.NextTalkIndex = new int?(-1);
			for (int i = 0; i < this.CurShowTalk.TalkItems.Count; i++)
			{
				if (this.CurShowTalk.TalkItems[i].Id == talkId)
				{
					this.NextTalkIndex = new int?(i);
					break;
				}
			}
			if (this.IsSkipping)
			{
				this.OnSubtitleStart(talkId);
				this.OnSubtitleEnd(new int?(talkId));
			}
		}

		// Token: 0x06036EC4 RID: 224964 RVA: 0x00DEFFF7 File Offset: 0x00DEE1F7
		public void OnFinishTalk()
		{
			if (!this.IsInit)
			{
				return;
			}
			this.NextSequenceIndex = -1;
			ControllerBase<SequenceController>.Instance.SetNextSequenceIndex(this.NextSequenceIndex);
			if (this.IsSkipping)
			{
				this.OnSequenceStop(false);
			}
		}

		// Token: 0x06036EC5 RID: 224965 RVA: 0x00DF0028 File Offset: 0x00DEE228
		public unsafe void OnSubtitleStart(int talkId)
		{
			if (!this.IsInit)
			{
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[FlowSequence][Subtitle] 字幕显示";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("talkId", talkId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ITalkItem talkItem = null;
			foreach (ITalkItem talkItem2 in this.CurShowTalk.TalkItems)
			{
				if (talkItem2.Id == talkId)
				{
					talkItem = talkItem2;
					break;
				}
			}
			if (this.GetNextTalkItem().Id != talkId)
			{
				FlowController instance2 = ControllerBase<FlowController>.Instance;
				string text = "[FlowSequence][Subtitle] Seq字幕顺序与编辑器对不上";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("talkId", talkId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SeqIndex", ModelBase<SequenceModel>.Instance.SubSeqIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("index in seq", this.NextTalkIndex);
				instance2.LogError(text, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				this.NextTalkIndex = new int?(this.CurShowTalk.TalkItems.IndexOf(talkItem));
			}
			this.NextTalkIndex++;
			if (talkItem == null)
			{
				FlowController instance3 = ControllerBase<FlowController>.Instance;
				string text2 = "[FlowSequence][Subtitle] 依赖编辑器的Seq找不到字幕";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("talkItem.ID", talkId);
				instance3.LogError(text2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			this.IsSubtitleShowed = true;
			this.Context.CurTalkId = talkId;
			this.Context.CurOptionId = -1;
			this.CurTalkItem = talkItem;
			this.CheckLastAndSetNew();
			this.IsOptionSelected = false;
		}

		// Token: 0x06036EC6 RID: 224966 RVA: 0x00DF0204 File Offset: 0x00DEE404
		public unsafe bool OnSubtitleEnd(int? id = null)
		{
			if (this.IsSkipping)
			{
				this.RunSequenceFrameEventsWhenSkip(new int?(id.Value));
			}
			if (!this.IsInit || !this.IsSubtitleShowed)
			{
				return false;
			}
			if (id != null)
			{
				int id2 = this.CurTalkItem.Id;
				int? num = id;
				if (!(id2 == num.GetValueOrDefault() & num != null))
				{
					FlowController instance = ControllerBase<FlowController>.Instance;
					string text = "[FlowSequence] 结束对话Id错误";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("cur", this.CurTalkItem.Id);
					instance.LogError(text, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return false;
				}
			}
			this.IsSubtitleShowed = false;
			this.SubtitleActionPromise = new CustomPromise();
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "[FlowSequence][Subtitle] 字幕关闭", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.RunSubActions(this.CurTalkItem.Actions, new Action<bool>(this.SubtitleActionCallback), false);
			return true;
		}

		// Token: 0x06036EC7 RID: 224967 RVA: 0x00DF031C File Offset: 0x00DEE51C
		public unsafe int OnQteStart(int id)
		{
			ITalkItem talkItem = null;
			foreach (ITalkItem talkItem2 in this.CurShowTalk.TalkItems)
			{
				if (talkItem2.Id == id)
				{
					talkItem = talkItem2;
					break;
				}
			}
			if (this.GetNextTalkItem().Id != id)
			{
				FlowController instance = ControllerBase<FlowController>.Instance;
				string text = "[FlowSequence][Subtitle] Qte在Seq中顺序与编辑器不符合";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SeqIndex", ModelBase<SequenceModel>.Instance.SubSeqIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("index in seq", this.NextTalkIndex);
				instance.LogError(text, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				this.NextTalkIndex = new int?(this.CurShowTalk.TalkItems.IndexOf(talkItem));
			}
			this.NextTalkIndex++;
			ITalkItemQte talkItemQte = talkItem as ITalkItemQte;
			this.CurrentQte[id] = talkItemQte;
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[FlowSequence][Subtitle] Qte开启";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return talkItemQte.QteId;
		}

		// Token: 0x06036EC8 RID: 224968 RVA: 0x00DF04A8 File Offset: 0x00DEE6A8
		public unsafe void OnQteExecute(int talkId, bool result)
		{
			ITalkItemQte talkItemQte;
			if (!this.CurrentQte.TryGetValue(talkId, out talkItemQte))
			{
				return;
			}
			this.QteLatentAction[talkId] = -1;
			if (talkItemQte.Options == null || talkItemQte.Options.Count == 0)
			{
				return;
			}
			for (int i = 0; i < talkItemQte.Options.Count; i++)
			{
				ITalkOption talkOption = talkItemQte.Options[i];
				if (talkOption.TypeParams != null)
				{
					switch (talkOption.TypeParams.Type)
					{
					case ETalkOptionParamType.QteSucceed:
						if (result)
						{
							this.OnQteOption(talkItemQte, i);
							global::Log instance = Singleton<global::Log>.Instance;
							ELogModule module = ELogModule.Plot;
							ELogAuthor author = ELogAuthor.FZX;
							string message = "[FlowSequence][Subtitle] Qte成功执行";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", talkId);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("optionIndex", i);
							instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						}
						break;
					case ETalkOptionParamType.QteFailed:
						if (!result)
						{
							this.OnQteOption(talkItemQte, i);
							global::Log instance2 = Singleton<global::Log>.Instance;
							ELogModule module2 = ELogModule.Plot;
							ELogAuthor author2 = ELogAuthor.FZX;
							string message2 = "[FlowSequence][Subtitle] Qte失败执行";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("id", talkId);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("optionIndex", i);
							instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
						}
						break;
					case ETalkOptionParamType.QteSucceedDelayExec:
						if (result)
						{
							this.QteLatentAction[talkId] = i;
						}
						break;
					case ETalkOptionParamType.QteFailedDelayExec:
						if (!result)
						{
							this.QteLatentAction[talkId] = i;
						}
						break;
					}
				}
			}
		}

		// Token: 0x06036EC9 RID: 224969 RVA: 0x00DF0648 File Offset: 0x00DEE848
		public unsafe void OnQteEnd(int talkId)
		{
			if (!this.CurrentQte.ContainsKey(talkId))
			{
				return;
			}
			if (!this.QteLatentAction.ContainsKey(talkId))
			{
				if (!this.IsSkipping)
				{
					return;
				}
				this.OnQteExecute(talkId, false);
			}
			ITalkItemQte talkItem = this.CurrentQte[talkId];
			int num = this.QteLatentAction[talkId];
			this.QteLatentAction.Remove(talkId);
			this.CurrentQte.Remove(talkId);
			if (num == -1)
			{
				return;
			}
			this.OnQteOption(talkItem, num);
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[FlowSequence][Subtitle] Qte关闭";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", talkId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("delay option index", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("delay no more", this.IsSkipping);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x06036ECA RID: 224970 RVA: 0x00DF0745 File Offset: 0x00DEE945
		public void OnSequenceStop(bool _)
		{
			this.CheckLastAndSetNew();
			this.IsPlayingInner = false;
			this.Stop(false);
		}

		// Token: 0x06036ECB RID: 224971 RVA: 0x00DF075C File Offset: 0x00DEE95C
		public bool OnSelectOption(int index)
		{
			if (!this.IsInit)
			{
				return false;
			}
			if (this.Context.CurOptionId != -1 || this.IsOptionSelected)
			{
				return false;
			}
			this.IsOptionSelected = true;
			ITalkItem curTalkItem = this.CurTalkItem;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[FlowSequence] 选择选项";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", index);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			List<ITalkOption> options = curTalkItem.Options;
			int num = (options != null) ? options.Count : 0;
			List<ActionInfo> actions = (index < num) ? curTalkItem.Options[index].Actions : null;
			if (index >= num)
			{
				ControllerBase<FlowController>.Instance.LogError("[FlowSequence] 选项超出下标", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			ControllerBase<FlowController>.Instance.SelectOption(curTalkItem.Id, index);
			this.OptionActionPromise = new CustomPromise();
			this.RunSubActions(actions, new Action<bool>(this.OptionActionCallback), false);
			return true;
		}

		// Token: 0x06036ECC RID: 224972 RVA: 0x00DF0844 File Offset: 0x00DEEA44
		private void OnQteOption(ITalkItem talkItem, int index)
		{
			if (talkItem.Options == null || talkItem.Options.Count == 0)
			{
				return;
			}
			ControllerBase<FlowController>.Instance.SelectOption(talkItem.Id, index);
			this.RunSubActions(talkItem.Options[index].Actions, null, true);
		}

		// Token: 0x06036ECD RID: 224973 RVA: 0x00DF0894 File Offset: 0x00DEEA94
		[NullableContext(2)]
		private void RunSubActions([Nullable(new byte[]
		{
			2,
			1
		})] List<ActionInfo> actions, Action<bool> callback = null, bool append = false)
		{
			ControllerBase<FlowController>.Instance.ExecuteSubActions(actions, delegate(bool result)
			{
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(result);
			}, append);
		}

		// Token: 0x06036ECE RID: 224974 RVA: 0x00DF08C8 File Offset: 0x00DEEAC8
		[NullableContext(2)]
		public ITalkItem CreateSubtitleFromTalkItem(int talkId)
		{
			if (!this.IsInit)
			{
				return null;
			}
			ITalkItem talkItem = null;
			foreach (ITalkItem talkItem2 in this.CurShowTalk.TalkItems)
			{
				if (talkItem2.Id == talkId)
				{
					talkItem = talkItem2;
					break;
				}
			}
			if (talkItem == null)
			{
				FlowController instance = ControllerBase<FlowController>.Instance;
				string text = "[FlowSequence] 剧情Seq找不到字幕";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("talkId", talkId);
				instance.LogError(text, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return talkItem;
		}

		// Token: 0x06036ECF RID: 224975 RVA: 0x00DF0960 File Offset: 0x00DEEB60
		[NullableContext(2)]
		public ITalkItem GetNextTalkItem()
		{
			if (this.NextTalkIndex != null && this.CurShowTalk != null && this.CurShowTalk.TalkItems.Count > 0)
			{
				int count = this.CurShowTalk.TalkItems.Count;
				int? nextTalkIndex = this.NextTalkIndex;
				if (count > nextTalkIndex.GetValueOrDefault() & nextTalkIndex != null)
				{
					return this.CurShowTalk.TalkItems[this.NextTalkIndex.Value];
				}
			}
			return null;
		}

		// Token: 0x06036ED0 RID: 224976 RVA: 0x00DF09DC File Offset: 0x00DEEBDC
		public unsafe void RunSequenceFrameEventsWhenSkip(int? id)
		{
			if (id == null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.JYS, "RunSequenceFrameEventsWhenSkip 但id为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			HashSet<string> hashSet = null;
			HashSet<string> hashSet2;
			if (this.FrameEventsMap.TryGetValue(id.Value, out hashSet2))
			{
				hashSet = hashSet2;
			}
			if (hashSet != null)
			{
				foreach (string text in hashSet)
				{
					List<ActionInfo> list;
					if (this.FrameEvents.TryGetValue(text, out list) && list.Count != 0)
					{
						global::Log instance = Singleton<global::Log>.Instance;
						ELogModule module = ELogModule.Plot;
						ELogAuthor author = ELogAuthor.JYS;
						string message = "RunSequenceFrameEventsWhenSkip";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", id);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("key", text);
						instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						ControllerBase<FlowController>.Instance.ExecuteSubActions(list, delegate(bool result)
						{
						}, false);
					}
				}
			}
		}

		// Token: 0x06036ED1 RID: 224977 RVA: 0x00DF0B18 File Offset: 0x00DEED18
		public List<int> GetAllQte()
		{
			List<int> list = new List<int>();
			ShowTalk curShowTalk = this.CurShowTalk;
			if (((curShowTalk != null) ? curShowTalk.TalkItems : null) != null)
			{
				foreach (ITalkItem talkItem in this.CurShowTalk.TalkItems)
				{
					if (talkItem.Type.GetValueOrDefault() == ETalkItemType.QTE)
					{
						list.Add((talkItem as ITalkItemQte).QteId);
					}
				}
			}
			return list;
		}

		// Token: 0x0401F9CF RID: 129487
		public const int FINISH_INDEX = -1;

		// Token: 0x0401F9D0 RID: 129488
		public const int INVALID_INDEX = -2;

		// Token: 0x0401F9D1 RID: 129489
		private bool IsInitInner;

		// Token: 0x0401F9D2 RID: 129490
		private bool IsPlayingInner;

		// Token: 0x0401F9D3 RID: 129491
		[Nullable(2)]
		private ShowTalk CurShowTalk;

		// Token: 0x0401F9D4 RID: 129492
		private readonly Dictionary<int, int> IdIndexMap = new Dictionary<int, int>();

		// Token: 0x0401F9D5 RID: 129493
		private int NextSequenceIndex = -2;

		// Token: 0x0401F9D6 RID: 129494
		[Nullable(2)]
		private ITalkItem CurTalkItem;

		// Token: 0x0401F9D7 RID: 129495
		[Nullable(2)]
		private FlowContext Context;

		// Token: 0x0401F9D8 RID: 129496
		private bool IsSubtitleShowed;

		// Token: 0x0401F9D9 RID: 129497
		private bool IsOptionSelected;

		// Token: 0x0401F9DA RID: 129498
		private bool IsSkipping;

		// Token: 0x0401F9DB RID: 129499
		private int? NextTalkIndex = new int?(0);

		// Token: 0x0401F9DC RID: 129500
		[Nullable(2)]
		private List<Transform> FinalPos;

		// Token: 0x0401F9DD RID: 129501
		private readonly List<bool> IsFadeEnd = new List<bool>();

		// Token: 0x0401F9DE RID: 129502
		private readonly Dictionary<int, HashSet<string>> FrameEventsMap = new Dictionary<int, HashSet<string>>();

		// Token: 0x0401F9DF RID: 129503
		private readonly Dictionary<string, List<ActionInfo>> FrameEvents = new Dictionary<string, List<ActionInfo>>();

		// Token: 0x0401F9E0 RID: 129504
		[Nullable(2)]
		public CustomPromise SubtitleActionPromise;

		// Token: 0x0401F9E1 RID: 129505
		[Nullable(2)]
		public CustomPromise OptionActionPromise;

		// Token: 0x0401F9E2 RID: 129506
		private readonly Dictionary<int, ITalkItemQte> CurrentQte = new Dictionary<int, ITalkItemQte>();

		// Token: 0x0401F9E3 RID: 129507
		private readonly Dictionary<int, int> QteLatentAction = new Dictionary<int, int>();

		// Token: 0x0401F9E4 RID: 129508
		[Nullable(2)]
		private TimerHandle DelayEnableSkipTimer;

		// Token: 0x0401F9E5 RID: 129509
		private readonly List<FName> NpcPerformArray = new List<FName>();

		// Token: 0x0401F9E6 RID: 129510
		private readonly Dictionary<FName, NpcRelation> NpcPerformRelationMap = new Dictionary<FName, NpcRelation>();

		// Token: 0x0401F9E7 RID: 129511
		private int LastId = -1;

		// Token: 0x0401F9E8 RID: 129512
		private bool LastHasOption;
	}
}
