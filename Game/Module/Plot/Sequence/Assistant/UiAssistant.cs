using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Sequence.Manager;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.Module.Plot.Sequence.Qte;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence.Assistant
{
	// Token: 0x020053AB RID: 21419
	[NullableContext(1)]
	[Nullable(0)]
	public class UiAssistant : SeqBaseAssistant
	{
		// Token: 0x17008DB1 RID: 36273
		// (get) Token: 0x06036A01 RID: 223745 RVA: 0x00DD58BF File Offset: 0x00DD3ABF
		private Dictionary<int, int> PendingOptionResult
		{
			get
			{
				return this.SequenceQteManger.PendingOptionResult;
			}
		}

		// Token: 0x06036A02 RID: 223746 RVA: 0x00DD58CC File Offset: 0x00DD3ACC
		[NullableContext(0)]
		public override UniTask<bool> LoadPromise()
		{
			UiAssistant.<LoadPromise>d__9 <LoadPromise>d__;
			<LoadPromise>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LoadPromise>d__.<>4__this = this;
			<LoadPromise>d__.<>1__state = -1;
			<LoadPromise>d__.<>t__builder.Start<UiAssistant.<LoadPromise>d__9>(ref <LoadPromise>d__);
			return <LoadPromise>d__.<>t__builder.Task;
		}

		// Token: 0x06036A03 RID: 223747 RVA: 0x00DD590F File Offset: 0x00DD3B0F
		private void OnViewDone(bool result)
		{
			CustomPromise<bool> promise = this.Promise;
			if (promise != null)
			{
				promise.SetResult(result);
			}
			this.Promise = null;
		}

		// Token: 0x06036A04 RID: 223748 RVA: 0x00DD592C File Offset: 0x00DD3B2C
		[NullableContext(2)]
		public override void PreAllPlay(Action<bool> callback = null)
		{
			if (this.Model.IsSubtitleUiUse.GetValueOrDefault())
			{
				this.AddDialogueEvent();
			}
			ControllerBase<PlotController>.Instance.PlotViewManager.PlotDoingTextShow(this.Model.SequenceData.标识为演出制作中);
			string packageAudio = Singleton<LanguageSystem>.Instance.PackageAudio;
			if (!(packageAudio == "zh"))
			{
				if (!(packageAudio == "ja"))
				{
					if (!(packageAudio == "ko"))
					{
						if (!(packageAudio == "en"))
						{
							this.Model.CurLanguageAudio = ELanguageAudio.All;
						}
						else
						{
							this.Model.CurLanguageAudio = ELanguageAudio.en;
						}
					}
					else
					{
						this.Model.CurLanguageAudio = ELanguageAudio.ko;
					}
				}
				else
				{
					this.Model.CurLanguageAudio = ELanguageAudio.ja;
				}
			}
			else
			{
				this.Model.CurLanguageAudio = ELanguageAudio.zh;
			}
			this.SequenceQteManger.Init();
		}

		// Token: 0x06036A05 RID: 223749 RVA: 0x00DD5A00 File Offset: 0x00DD3C00
		public override void EachStop()
		{
			ControllerBase<PlotController>.Instance.PlotViewManager.HandleSubSequenceStop();
		}

		// Token: 0x06036A06 RID: 223750 RVA: 0x00DD5A14 File Offset: 0x00DD3C14
		[NullableContext(2)]
		public override void AllStop(Action<bool> callback = null)
		{
			if (this.Model.GetLastFadeEnd())
			{
				ModelBase<PlotModel>.Instance.IsFadeIn = true;
				ControllerBase<LevelLoadingController>.Instance.OpenLoading<ELoadingPerform>(ELoadingReason.Common, ELoadingPerform.CameraFade, "Plot_LastFadeEnd", null, new object[]
				{
					0,
					ControllerBase<LevelLoadingController>.Instance.CameraFade.ColorSearch()
				});
			}
		}

		// Token: 0x06036A07 RID: 223751 RVA: 0x00DD5A74 File Offset: 0x00DD3C74
		public override void End()
		{
			if (this.Model.IsSubtitleUiUse.GetValueOrDefault())
			{
				this.RemoveDialogueEvent();
			}
			ControllerBase<PlotController>.Instance.RemoveViewCallback(new TCallback(this.OnViewDone));
			this.QteManger.StopQte();
			this.SequenceQteManger.Clear();
			if (this.Promise != null)
			{
				this.Promise.SetResult(false);
				this.Promise = null;
			}
			ControllerBase<CommonQteController>.Instance.ClearPreloadQteRes();
			if (!ControllerBase<FlowController>.Instance.CollectSeamlessFinalize(ESeamlessFinalizeFlag.UiRemoveAspectView))
			{
				ControllerBase<PlotController>.Instance.RemoveAspectTransformView();
			}
		}

		// Token: 0x06036A08 RID: 223752 RVA: 0x00DD5B04 File Offset: 0x00DD3D04
		private void AddDialogueEvent()
		{
			if (this.SubtitleEventRegistered)
			{
				return;
			}
			this.SubtitleEventRegistered = true;
			UMovieSceneDialogueSubsystem umovieSceneDialogueSubsystem = UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UMovieSceneDialogueSubsystem.StaticClass()) as UMovieSceneDialogueSubsystem;
			UMovieSceneQteManager qteManager = umovieSceneDialogueSubsystem.GetQteManager();
			umovieSceneDialogueSubsystem.OnShowDialogueWithUnison.Add(new FOnDialogueWithUnisonEvent.FOnDialogueWithUnisonEvent_ScriptDelegate(this.OnShowDialogue));
			qteManager.OnQteStart.Add(new Action<FMovieSceneQteEventParam>(this.OnQteStart));
			qteManager.OnQteAnimEnd.Add(new Action<int>(this.OnQteAnimEnd));
		}

		// Token: 0x06036A09 RID: 223753 RVA: 0x00DD5B88 File Offset: 0x00DD3D88
		private void RemoveDialogueEvent()
		{
			if (!this.SubtitleEventRegistered)
			{
				return;
			}
			this.SubtitleEventRegistered = false;
			UMovieSceneDialogueSubsystem umovieSceneDialogueSubsystem = UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UMovieSceneDialogueSubsystem.StaticClass()) as UMovieSceneDialogueSubsystem;
			UMovieSceneQteManager qteManager = umovieSceneDialogueSubsystem.GetQteManager();
			umovieSceneDialogueSubsystem.OnShowDialogueWithUnison.Remove(new FOnDialogueWithUnisonEvent.FOnDialogueWithUnisonEvent_ScriptDelegate(this.OnShowDialogue));
			qteManager.OnQteStart.Remove(new Action<FMovieSceneQteEventParam>(this.OnQteStart));
			qteManager.OnQteAnimEnd.Remove(new Action<int>(this.OnQteAnimEnd));
		}

		// Token: 0x06036A0A RID: 223754 RVA: 0x00DD5C09 File Offset: 0x00DD3E09
		public void OnQteStart(FMovieSceneQteEventParam param)
		{
			if (this.Model.State != ESequenceState.Playing)
			{
				this.SequenceQteManger.EnqueueQteRelease(param.QteId);
				return;
			}
			this.SequenceQteManger.EnqueueQteStart(param);
		}

		// Token: 0x06036A0B RID: 223755 RVA: 0x00DD5C37 File Offset: 0x00DD3E37
		public void OnQteAnimEnd(int qteId)
		{
			if (this.Model.State != ESequenceState.Playing)
			{
				return;
			}
			this.SequenceQteManger.EnqueueQteAnimEnd(qteId);
		}

		// Token: 0x06036A0C RID: 223756 RVA: 0x00DD5C54 File Offset: 0x00DD3E54
		public void OnShowDialogue(bool bShow, in FText dialogueId, int guardTime, int audioDelay, int audioTransitionDuration, ELanguageAudio languageAudio, int autoPlayDelay, in TArray<int> unisonIdList)
		{
			if (this.Model.State != ESequenceState.Playing)
			{
				return;
			}
			float guardTime2 = (float)guardTime / 0.03f;
			this.CacheDialogueQueue.Push(new CacheDialogueData(bShow, dialogueId.ToString(), guardTime2, (float)audioDelay, (float)audioTransitionDuration, languageAudio, (float)autoPlayDelay, unisonIdList));
		}

		// Token: 0x06036A0D RID: 223757 RVA: 0x00DD5CA0 File Offset: 0x00DD3EA0
		public void TriggerAllSubtitle()
		{
			if (this.Model.IsPaused.GetValueOrDefault())
			{
				return;
			}
			while (this.CacheDialogueQueue.Size > 0)
			{
				CacheDialogueData cacheDialogueData = this.CacheDialogueQueue.Pop();
				if (cacheDialogueData != null)
				{
					this.HandleSequenceDialog(cacheDialogueData.Show, cacheDialogueData.DialogueId, cacheDialogueData.GuardTime, cacheDialogueData.AudioDelay, cacheDialogueData.AudioTransitionDuration, cacheDialogueData.LanguageAudio, cacheDialogueData.AutoPlayDelay, cacheDialogueData.UnisonIdList);
				}
			}
		}

		// Token: 0x06036A0E RID: 223758 RVA: 0x00DD5D13 File Offset: 0x00DD3F13
		private void HandleSequenceDialog(bool isShow, string id, float guardTime, float audioDelay, float audioTransitionDuration, ELanguageAudio languageAudio, float autoPlayDelay, [Nullable(2)] TArray<int> unisonIdList)
		{
			if (languageAudio != ELanguageAudio.All && languageAudio != this.Model.CurLanguageAudio)
			{
				return;
			}
			if (isShow)
			{
				this.TriggerSubtitle(id, guardTime, audioDelay, audioTransitionDuration, autoPlayDelay, unisonIdList);
				return;
			}
			this.TriggerSubtitleEnd(id);
		}

		// Token: 0x06036A0F RID: 223759 RVA: 0x00DD5D44 File Offset: 0x00DD3F44
		private void TriggerSubtitle(string id, float guardTime, float audioDelay, float audioTransitionDuration, float autoPlayDelay, [Nullable(2)] TArray<int> unisonIdList)
		{
			if (id == "None")
			{
				return;
			}
			int talkId = int.Parse(id);
			ITalkItem talkItem = ControllerBase<FlowController>.Instance.FlowSequence.CreateSubtitleFromTalkItem(talkId);
			if (talkItem == null)
			{
				return;
			}
			if (this.PendingOptionResult.ContainsKey(talkItem.Id))
			{
				ControllerBase<FlowController>.Instance.FlowSequence.OnSubtitleStart(talkItem.Id);
				return;
			}
			ETalkItemType? type = talkItem.Type;
			if (type != null)
			{
				ETalkItemType valueOrDefault = type.GetValueOrDefault();
				if (valueOrDefault == ETalkItemType.QTE)
				{
					this.QteManger.HandlePlotQte(talkItem);
					return;
				}
				if (valueOrDefault == ETalkItemType.NoTextItem)
				{
					this.HandlePlotNoText(talkItem);
					return;
				}
			}
			this.HandlePlotSubtitle(talkItem, guardTime, audioDelay, audioTransitionDuration, autoPlayDelay, unisonIdList);
		}

		// Token: 0x06036A10 RID: 223760 RVA: 0x00DD5DEC File Offset: 0x00DD3FEC
		private void TriggerSubtitleEnd(string id)
		{
			if (id == "None")
			{
				return;
			}
			int num = int.Parse(id);
			ITalkItem talkItem = ControllerBase<FlowController>.Instance.FlowSequence.CreateSubtitleFromTalkItem(num);
			if (talkItem == null)
			{
				return;
			}
			if (this.PendingOptionResult.ContainsKey(talkItem.Id))
			{
				int index = this.PendingOptionResult[talkItem.Id];
				ControllerBase<FlowController>.Instance.FlowSequence.OnSubtitleEnd(new int?(talkItem.Id));
				ControllerBase<FlowController>.Instance.FlowSequence.OnSelectOption(index);
				return;
			}
			ETalkItemType? type = talkItem.Type;
			if (type != null)
			{
				ETalkItemType valueOrDefault = type.GetValueOrDefault();
				if (valueOrDefault == ETalkItemType.QTE)
				{
					this.QteManger.HandlePlotQteEnd(num);
					return;
				}
				if (valueOrDefault == ETalkItemType.NoTextItem)
				{
					this.HandlePlotNoTextEnd(num);
					return;
				}
			}
			this.HandlePlotSubtitleEnd(num, false).Forget();
		}

		// Token: 0x06036A11 RID: 223761 RVA: 0x00DD5EBC File Offset: 0x00DD40BC
		private void InitSubtitle()
		{
			this.Model.DefaultGuardTime = ModelBase<PlotModel>.Instance.PlotGlobalConfig.GuardTime;
			this.Model.DefaultAudioDelay = ModelBase<PlotModel>.Instance.PlotGlobalConfig.AudioDelay;
			this.Model.DefaultAudioTransitionDuration = ModelBase<PlotModel>.Instance.PlotGlobalConfig.AudioTransitionDuration;
			this.Model.IsSubtitleConfigInit = true;
		}

		// Token: 0x06036A12 RID: 223762 RVA: 0x00DD5F24 File Offset: 0x00DD4124
		public void HandlePlotSubtitle(ITalkItem inSubtitles, float guardTime, float audioDelay, float audioTransitionDuration, float autoPlayDelay, [Nullable(2)] TArray<int> unisonIdList)
		{
			if (!this.Model.IsSubtitleConfigInit)
			{
				this.InitSubtitle();
			}
			this.Model.CurSubtitle.Subtitles = inSubtitles;
			if (guardTime < 0f)
			{
				this.Model.CurSubtitle.GuardTime = 0f;
			}
			else if (guardTime == 0f)
			{
				this.Model.CurSubtitle.GuardTime = this.Model.DefaultGuardTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			}
			else
			{
				this.Model.CurSubtitle.GuardTime = Singleton<MathUtils>.Instance.Clamp(guardTime, 20f, 180000f);
			}
			if (audioDelay < 0f)
			{
				this.Model.CurSubtitle.AudioDelay = 0f;
			}
			else if (audioDelay == 0f)
			{
				this.Model.CurSubtitle.AudioDelay = this.Model.DefaultAudioDelay * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			}
			else
			{
				this.Model.CurSubtitle.AudioDelay = audioDelay;
			}
			if (audioTransitionDuration < 0f)
			{
				this.Model.CurSubtitle.AudioTransitionDuration = 0f;
			}
			else if (audioTransitionDuration == 0f)
			{
				this.Model.CurSubtitle.AudioTransitionDuration = this.Model.DefaultAudioTransitionDuration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			}
			else
			{
				this.Model.CurSubtitle.AudioTransitionDuration = audioTransitionDuration;
			}
			if (autoPlayDelay <= 0f)
			{
				this.Model.CurSubtitle.AutoPlayDelay = 0f;
			}
			else
			{
				this.Model.CurSubtitle.AutoPlayDelay = autoPlayDelay * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			}
			PlotSubtitleConfig curSubtitle = this.Model.CurSubtitle;
			ControllerBase<PlotController>.Instance.PlotViewManager.OnUpdateSubtitle(curSubtitle.Subtitles);
			ControllerBase<FlowController>.Instance.FlowSequence.OnSubtitleStart(curSubtitle.Subtitles.Id);
			ControllerBase<PlotController>.Instance.PlotViewManager.UpdateSeqSubtitle(curSubtitle);
			string sequenceMouthAnimKey = SequenceMouthAnimUtil.GetSequenceMouthAnimKey(curSubtitle.Subtitles);
			if (sequenceMouthAnimKey != null)
			{
				List<int> sequenceMouthAnimSpeakerIds = SequenceMouthAnimUtil.GetSequenceMouthAnimSpeakerIds(curSubtitle.Subtitles, unisonIdList);
				if (sequenceMouthAnimSpeakerIds.Count > 0)
				{
					ControllerBase<SequenceController>.Instance.TryApplyMouthAnim(sequenceMouthAnimKey, sequenceMouthAnimSpeakerIds);
				}
			}
		}

		// Token: 0x06036A13 RID: 223763 RVA: 0x00DD614C File Offset: 0x00DD434C
		public UniTask HandlePlotSubtitleEnd(int id, bool isSkip = false)
		{
			UiAssistant.<HandlePlotSubtitleEnd>d__26 <HandlePlotSubtitleEnd>d__;
			<HandlePlotSubtitleEnd>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandlePlotSubtitleEnd>d__.<>4__this = this;
			<HandlePlotSubtitleEnd>d__.id = id;
			<HandlePlotSubtitleEnd>d__.isSkip = isSkip;
			<HandlePlotSubtitleEnd>d__.<>1__state = -1;
			<HandlePlotSubtitleEnd>d__.<>t__builder.Start<UiAssistant.<HandlePlotSubtitleEnd>d__26>(ref <HandlePlotSubtitleEnd>d__);
			return <HandlePlotSubtitleEnd>d__.<>t__builder.Task;
		}

		// Token: 0x06036A14 RID: 223764 RVA: 0x00DD61A0 File Offset: 0x00DD43A0
		public UniTask HandleSelectedOption(int inOption, int talkItemId)
		{
			UiAssistant.<HandleSelectedOption>d__27 <HandleSelectedOption>d__;
			<HandleSelectedOption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleSelectedOption>d__.<>4__this = this;
			<HandleSelectedOption>d__.inOption = inOption;
			<HandleSelectedOption>d__.talkItemId = talkItemId;
			<HandleSelectedOption>d__.<>1__state = -1;
			<HandleSelectedOption>d__.<>t__builder.Start<UiAssistant.<HandleSelectedOption>d__27>(ref <HandleSelectedOption>d__);
			return <HandleSelectedOption>d__.<>t__builder.Task;
		}

		// Token: 0x06036A15 RID: 223765 RVA: 0x00DD61F3 File Offset: 0x00DD43F3
		private void HandlePlotNoText(ITalkItem subtitle)
		{
			ControllerBase<FlowController>.Instance.FlowSequence.OnSubtitleStart(subtitle.Id);
		}

		// Token: 0x06036A16 RID: 223766 RVA: 0x00DD620A File Offset: 0x00DD440A
		private void HandlePlotNoTextEnd(int id)
		{
			ControllerBase<FlowController>.Instance.FlowSequence.OnSubtitleEnd(new int?(id));
		}

		// Token: 0x06036A17 RID: 223767 RVA: 0x00DD6224 File Offset: 0x00DD4424
		private UniTask PreloadQte()
		{
			UiAssistant.<PreloadQte>d__30 <PreloadQte>d__;
			<PreloadQte>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadQte>d__.<>4__this = this;
			<PreloadQte>d__.<>1__state = -1;
			<PreloadQte>d__.<>t__builder.Start<UiAssistant.<PreloadQte>d__30>(ref <PreloadQte>d__);
			return <PreloadQte>d__.<>t__builder.Task;
		}

		// Token: 0x06036A18 RID: 223768 RVA: 0x00DD6268 File Offset: 0x00DD4468
		public void PreloadUi(CustomPromise<bool> promise)
		{
			UiAssistant.<>c__DisplayClass31_0 CS$<>8__locals1 = new UiAssistant.<>c__DisplayClass31_0();
			CS$<>8__locals1.promise = promise;
			CS$<>8__locals1.<>4__this = this;
			string formatId = ModelBase<PlotModel>.Instance.PlotResult.FormatId;
			if (ControllerBase<PlotController>.Instance.GetCurrentViewName() == null)
			{
				CS$<>8__locals1.<PreloadUi>g__SetResult|0();
				return;
			}
			BP_SequenceData_C sequenceData = this.Model.SequenceData;
			bool flag;
			if (sequenceData == null)
			{
				flag = (null != null);
			}
			else
			{
				BP_SequenceData_Generated_C generatedData = sequenceData.GeneratedData;
				flag = (((generatedData != null) ? generatedData.PreloadUiArray : null) != null);
			}
			if (flag)
			{
				BP_SequenceData_C sequenceData2 = this.Model.SequenceData;
				bool flag2;
				if (sequenceData2 == null)
				{
					flag2 = false;
				}
				else
				{
					BP_SequenceData_Generated_C generatedData2 = sequenceData2.GeneratedData;
					int? num = (generatedData2 != null) ? new int?(generatedData2.PreloadUiArray.Num()) : null;
					int num2 = 0;
					flag2 = (num.GetValueOrDefault() <= num2 & num != null);
				}
				if (!flag2)
				{
					List<UniTask> list = new List<UniTask>();
					if (ModelBase<PreloadModelNew>.Instance.PlotUiAssetManager.IsLoading(formatId))
					{
						list.Add(ModelBase<PreloadModelNew>.Instance.PlotUiAssetManager.WaitForPlotUiAsset(formatId));
					}
					else
					{
						list.Add(this.PreloadQte());
						list.Add(UniTask.Create(delegate()
						{
							UiAssistant.<>c__DisplayClass31_0.<<PreloadUi>b__1>d <<PreloadUi>b__1>d;
							<<PreloadUi>b__1>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
							<<PreloadUi>b__1>d.<>4__this = CS$<>8__locals1;
							<<PreloadUi>b__1>d.<>1__state = -1;
							<<PreloadUi>b__1>d.<>t__builder.Start<UiAssistant.<>c__DisplayClass31_0.<<PreloadUi>b__1>d>(ref <<PreloadUi>b__1>d);
							return <<PreloadUi>b__1>d.<>t__builder.Task;
						}));
					}
					if (ModelBase<SequenceModel>.Instance.SkipUiWaiting)
					{
						UniTask.WhenAll(list);
						CS$<>8__locals1.<PreloadUi>g__SetResult|0();
						return;
					}
					UniTask.WhenAll(list).ContinueWith(new Action(CS$<>8__locals1.<PreloadUi>g__SetResult|0));
					return;
				}
			}
			CS$<>8__locals1.<PreloadUi>g__SetResult|0();
		}

		// Token: 0x0401F761 RID: 128865
		private const string SUBTITLE_ACTION_PAUSE = "Action";

		// Token: 0x0401F762 RID: 128866
		private const string OPTION_ACTION_PAUSE = "Option";

		// Token: 0x0401F763 RID: 128867
		public Event<ESequenceEventName, Delegate> Event = new Event<ESequenceEventName, Delegate>();

		// Token: 0x0401F764 RID: 128868
		private readonly Queue<CacheDialogueData> CacheDialogueQueue = new Queue<CacheDialogueData>(4);

		// Token: 0x0401F765 RID: 128869
		private bool SubtitleEventRegistered;

		// Token: 0x0401F766 RID: 128870
		private readonly QteManger QteManger = new QteManger();

		// Token: 0x0401F767 RID: 128871
		private readonly SequenceQteManager SequenceQteManger = new SequenceQteManager();
	}
}
