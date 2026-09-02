using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Data.Sequence.Struct;
using AkiClient.Game.Aki.Sequence.Manager;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.Sequence.Assistant;
using CSharpScript.Game.Module.Plot.Sequence.NpcPerformState;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence
{
	// Token: 0x02005384 RID: 21380
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class SequenceController : ControllerWithAssistantBase<SequenceController>
	{
		// Token: 0x17008D8B RID: 36235
		// (get) Token: 0x06036865 RID: 223333 RVA: 0x00DC8166 File Offset: 0x00DC6366
		protected override bool IsTickEvenPausedInternal
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06036866 RID: 223334 RVA: 0x00DC8169 File Offset: 0x00DC6369
		protected override bool OnInit()
		{
			bool result = base.OnInit();
			this.Model = ModelBase<SequenceModel>.Instance;
			SequenceRenderSettings.SetupSequenceSetting();
			return result;
		}

		// Token: 0x06036867 RID: 223335 RVA: 0x00DC8181 File Offset: 0x00DC6381
		protected override bool OnClear()
		{
			this.Model = null;
			return base.OnClear();
		}

		// Token: 0x06036868 RID: 223336 RVA: 0x00DC8190 File Offset: 0x00DC6390
		protected override void OnTick(float delta)
		{
			if (this.Model.DisableMotionBlurFrame > 0f)
			{
				this.Model.DisableMotionBlurFrame -= 1f;
				if (this.Model.DisableMotionBlurFrame == 0f)
				{
					this.RenderAssistant.SetMotionBlurState(true);
				}
			}
			if (this.Model.BeginSwitchFrame > 0f)
			{
				this.Model.BeginSwitchFrame -= 1f;
				if (this.Model.BeginSwitchFrame == 0f)
				{
					if (this.ActorAssistant != null)
					{
						this.ActorAssistant.EndSwitchPose();
						PlotBlendController instance = ControllerBase<PlotBlendController>.Instance;
						PlaySequenceData config = this.Model.Config;
						instance.TryExecuteBlend((config != null) ? config.Path : null).Forget<bool>();
					}
					else
					{
						Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.ZWY, "SwitchPose 失败!", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
				}
			}
			this.FlushDialogueState();
			if (this.CheckRenderDataPromise != null)
			{
				this.CheckSeqStreamingData();
			}
		}

		// Token: 0x06036869 RID: 223337 RVA: 0x00DC8290 File Offset: 0x00DC6490
		protected override void RegisterAssistant()
		{
			base.AddAssistant(0, new SequenceAssistant());
			base.AddAssistant(1, new ActorAssistant());
			base.AddAssistant(2, new FunctionAssistant());
			base.AddAssistant(3, new CameraAssistant());
			base.AddAssistant(4, new RenderAssistant());
			base.AddAssistant(5, new FlowAssistant());
			base.AddAssistant(6, new UiAssistant());
		}

		// Token: 0x17008D8C RID: 36236
		// (get) Token: 0x0603686A RID: 223338 RVA: 0x00DC82F1 File Offset: 0x00DC64F1
		private SequenceAssistant SequenceAssistant
		{
			get
			{
				return this.Assistants[0] as SequenceAssistant;
			}
		}

		// Token: 0x17008D8D RID: 36237
		// (get) Token: 0x0603686B RID: 223339 RVA: 0x00DC8304 File Offset: 0x00DC6504
		private ActorAssistant ActorAssistant
		{
			get
			{
				return this.Assistants[1] as ActorAssistant;
			}
		}

		// Token: 0x17008D8E RID: 36238
		// (get) Token: 0x0603686C RID: 223340 RVA: 0x00DC8317 File Offset: 0x00DC6517
		private FunctionAssistant FunctionAssistant
		{
			get
			{
				return this.Assistants[2] as FunctionAssistant;
			}
		}

		// Token: 0x17008D8F RID: 36239
		// (get) Token: 0x0603686D RID: 223341 RVA: 0x00DC832A File Offset: 0x00DC652A
		private CameraAssistant CameraAssistant
		{
			get
			{
				return this.Assistants[3] as CameraAssistant;
			}
		}

		// Token: 0x17008D90 RID: 36240
		// (get) Token: 0x0603686E RID: 223342 RVA: 0x00DC833D File Offset: 0x00DC653D
		private RenderAssistant RenderAssistant
		{
			get
			{
				return this.Assistants[4] as RenderAssistant;
			}
		}

		// Token: 0x17008D91 RID: 36241
		// (get) Token: 0x0603686F RID: 223343 RVA: 0x00DC8350 File Offset: 0x00DC6550
		private FlowAssistant FlowAssistant
		{
			get
			{
				return this.Assistants[5] as FlowAssistant;
			}
		}

		// Token: 0x17008D92 RID: 36242
		// (get) Token: 0x06036870 RID: 223344 RVA: 0x00DC8363 File Offset: 0x00DC6563
		private UiAssistant UiAssistant
		{
			get
			{
				return this.Assistants[6] as UiAssistant;
			}
		}

		// Token: 0x06036871 RID: 223345 RVA: 0x00DC8378 File Offset: 0x00DC6578
		public void Play(PlaySequenceData config, List<string> preLoadMouthKeys, [Nullable(2)] Action<bool> callback = null, bool isViewTargetControl = true, bool isSubtitleUiUse = true, bool isWaitRenderData = false, float playRate = 1f, bool bSeamless = false, bool isControlEntity = false)
		{
			if (this.Model != null && this.Model.IsPlaying)
			{
				ControllerBase<FlowController>.Instance.LogError("重复播放剧情Sequence，当前一次只能播放一段", default(ReadOnlySpan<ValueTuple<string, object>>));
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			if (config == null)
			{
				ControllerBase<FlowController>.Instance.LogError("播放剧情Sequence配置为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			if (preLoadMouthKeys != null && preLoadMouthKeys.Count > 0)
			{
				this.ActorAssistant.PreLoadMouthAssetName = preLoadMouthKeys;
			}
			else
			{
				this.ActorAssistant.PreLoadMouthAssetName.Clear();
			}
			this.Model.Config = config;
			this.Model.IsViewTargetControl = new bool?(isViewTargetControl);
			this.Model.IsSubtitleUiUse = new bool?(isSubtitleUiUse);
			this.Model.IsWaitRenderData = new bool?(isWaitRenderData);
			this.Model.PlayRate = playRate;
			this.Model.IsSeamless = bSeamless;
			this.Model.IsControlEntity = isControlEntity;
			this.Model.FinishCallback = callback;
			if (config.SeqBlendAnim != null)
			{
				ControllerBase<PlotBlendController>.Instance.SetupInfo(config.SeqBlendAnim, config.Path);
			}
			this.Load(delegate(bool result)
			{
				if (this.Model.IsEnding)
				{
					return;
				}
				if (!result)
				{
					ControllerBase<FlowController>.Instance.LogError("资源加载失败，不播放Sequence", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.EndPlay();
					this.DoCallback(false);
					return;
				}
				this.Setup(delegate(bool result)
				{
					if (this.Model.IsEnding)
					{
						return;
					}
					if (!result)
					{
						this.EndPlay();
						this.DoCallback(false);
						return;
					}
					this.StartPlay(delegate(bool result)
					{
						if (this.Model.IsEnding)
						{
							return;
						}
						if (!result)
						{
							this.EndPlay();
							this.DoCallback(false);
							return;
						}
						this.StopPlay(delegate(bool result)
						{
							if (this.Model.IsEnding)
							{
								return;
							}
							if (!result)
							{
								this.EndPlay();
							}
							this.Model.Reset();
							this.DoCallback(result);
						});
					});
				});
			});
		}

		// Token: 0x06036872 RID: 223346 RVA: 0x00DC84B2 File Offset: 0x00DC66B2
		public void LoadData(PlaySequenceData config, Action callback)
		{
			this.Model.State = ESequenceState.Loading;
			this.Model.Config = config;
			this.SequenceAssistant.LoadNecessaryData(callback);
		}

		// Token: 0x06036873 RID: 223347 RVA: 0x00DC84D8 File Offset: 0x00DC66D8
		public void ManualFinish()
		{
			if (this.Model.State == ESequenceState.Null || this.Model.State == ESequenceState.Stopping || this.Model.State == ESequenceState.Ending)
			{
				this.Model.FinishCallback = null;
				return;
			}
			ModelBase<SequenceModel>.Instance.IsSeamless = false;
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "剧情Sequence强制停止", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.EndPlay();
			this.Model.Reset();
		}

		// Token: 0x06036874 RID: 223348 RVA: 0x00DC8554 File Offset: 0x00DC6754
		private void Load(Action<bool> callback)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "[剧情加载等待] Sequence加载-开始", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (StringUtils.IsEmpty(this.Model.Config.Path))
			{
				return;
			}
			this.Model.State = ESequenceState.Loading;
			UniTask<bool> task = this.UiAssistant.LoadPromise();
			UniTask<bool> task2 = this.ActorAssistant.BeginLoadMouthAssetPromise();
			CustomPromise<bool> promise = new CustomPromise<bool>();
			CustomPromise<bool> preloadUiPromise = new CustomPromise<bool>();
			CustomPromise<bool> forceStreamPromise = new CustomPromise<bool>();
			this.ForceStreamPromise = forceStreamPromise;
			Action<bool> <>9__3;
			Action<bool> <>9__2;
			this.SequenceAssistant.Load(delegate(bool result)
			{
				if (!result)
				{
					ControllerBase<FlowController>.Instance.LogError("Sequence加载失败", default(ReadOnlySpan<ValueTuple<string, object>>));
					promise.SetResult(false);
					preloadUiPromise.SetResult(false);
					forceStreamPromise.SetResult(false);
					return;
				}
				this.UiAssistant.PreloadUi(preloadUiPromise);
				this.RequestForceStreamSceneActors(forceStreamPromise);
				SeqBaseAssistant actorAssistant = this.ActorAssistant;
				Action<bool> callback2;
				if ((callback2 = <>9__2) == null)
				{
					callback2 = (<>9__2 = delegate(bool result)
					{
						if (!result)
						{
							promise.SetResult(false);
							return;
						}
						SeqBaseAssistant functionAssistant = this.FunctionAssistant;
						Action<bool> callback3;
						if ((callback3 = <>9__3) == null)
						{
							callback3 = (<>9__3 = delegate(bool result)
							{
								if (!result)
								{
									promise.SetResult(false);
									return;
								}
								if (this.Model.IsWaitRenderData.GetValueOrDefault())
								{
									this.CheckRenderDataPromise = promise;
									this.CheckSeqStreamingData();
									return;
								}
								this.CheckSeqStreamingData();
								promise.SetResult(true);
							});
						}
						functionAssistant.Load(callback3);
					});
				}
				actorAssistant.Load(callback2);
			});
			UniTask.WhenAll<bool, bool, bool, bool, bool>(task, task2, promise.Promise, preloadUiPromise.Promise, forceStreamPromise.Promise).ContinueWith(delegate(ValueTuple<bool, bool, bool, bool, bool> promiseResult)
			{
				bool flag = promiseResult.Item1 && promiseResult.Item2 && promiseResult.Item3 && promiseResult.Item4 && promiseResult.Item5;
				if (this.ForceStreamPromise == forceStreamPromise)
				{
					this.ForceStreamPromise = null;
				}
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[剧情加载等待] Sequence加载-完成";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", flag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				callback(flag);
			}).Forget();
		}

		// Token: 0x06036875 RID: 223349 RVA: 0x00DC8650 File Offset: 0x00DC6850
		private unsafe void RequestForceStreamSceneActors(CustomPromise<bool> forceStreamPromise)
		{
			BP_SequenceData_C sequenceData = this.Model.SequenceData;
			if (sequenceData == null || !sequenceData.IsForceStreamSceneActor)
			{
				forceStreamPromise.SetResult(true);
				return;
			}
			BP_SequenceData_Generated_C generatedData = sequenceData.GeneratedData;
			TArray<FSoftObjectPath> tarray = (generatedData != null) ? generatedData.ActorRefs : null;
			if (tarray == null || tarray.Num() == 0)
			{
				forceStreamPromise.SetResult(true);
				return;
			}
			UKuroActorStreamingHandle handle = UKuroSequenceRuntimeFunctionLibrary.RequestActorExternalStreaming(GlobalData.World, tarray);
			if (handle == null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.YZH, "[剧情加载等待] 强制流送Actor跳过：非PartitionedWorld或子系统不可用", default(ReadOnlySpan<ValueTuple<string, object>>));
				forceStreamPromise.SetResult(true);
				return;
			}
			this.Model.ForceStreamHandle = handle;
			int num = tarray.Num();
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.YZH;
			string message = "[剧情加载等待] 强制流送Actor-开始";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("count", num);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			TimerHandle timeoutHandle = null;
			Action onCompleted = null;
			onCompleted = delegate()
			{
				handle.OnCompleted.Remove(onCompleted);
				if (timeoutHandle != null && TimerSystem.Instance.Has(timeoutHandle))
				{
					TimerSystem.Instance.Remove(timeoutHandle);
				}
				if (forceStreamPromise.IsPending)
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.Plot;
					ELogAuthor author2 = ELogAuthor.YZH;
					string message2 = "[剧情加载等待] 强制流送Actor-完成";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("loaded", handle.GetLoadedCount());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("requested", handle.GetRequestedCount());
					instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					forceStreamPromise.SetResult(true);
				}
			};
			handle.OnCompleted.Add(onCompleted);
			if (this.ForceStreamTimeoutMs > 0)
			{
				timeoutHandle = TimerSystem.Instance.Delay(delegate(float _)
				{
					timeoutHandle = null;
					if (forceStreamPromise.IsPending)
					{
						global::Log instance2 = Singleton<global::Log>.Instance;
						ELogModule module2 = ELogModule.Plot;
						ELogAuthor author2 = ELogAuthor.YZH;
						string message2 = "[剧情加载等待] 强制流送Actor-超时";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("timeoutMs", this.ForceStreamTimeoutMs);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("loaded", handle.GetLoadedCount());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("requested", handle.GetRequestedCount());
						instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
						forceStreamPromise.SetResult(true);
					}
				}, (float)this.ForceStreamTimeoutMs, null, null, true, 1f);
			}
		}

		// Token: 0x06036876 RID: 223350 RVA: 0x00DC87B8 File Offset: 0x00DC69B8
		private void Setup(Action<bool> callback)
		{
			SequenceController.<>c__DisplayClass31_0 CS$<>8__locals1 = new SequenceController.<>c__DisplayClass31_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			this.Model.State = ESequenceState.PrePlay;
			this.FlowAssistant.PreAllPlay(null);
			this.SequenceAssistant.PreAllPlay(null);
			this.UiAssistant.PreAllPlay(null);
			BP_SequenceData_C sequenceData = this.Model.SequenceData;
			if (sequenceData != null && sequenceData.EnableStartTransformBlend)
			{
				this.ActorAssistant.StartTransformBlend(delegate
				{
					base.<Setup>g__DoPlay|0();
				});
				return;
			}
			CS$<>8__locals1.<Setup>g__DoPlay|0();
		}

		// Token: 0x06036877 RID: 223351 RVA: 0x00DC8840 File Offset: 0x00DC6A40
		private void StartPlay(Action<bool> callback)
		{
			Singleton<EventSystem>.Instance.Emit<float>(EEventName.PlotSequencePlay, this.Model.SequenceData.相机过渡时间);
			this.ActorAssistant.CheckHideBattleCharacter();
			Singleton<SeqNpcPerformStateManager>.Instance.OnBattleCharacterHidden("演出隐藏实机角色后");
			this.Model.State = ESequenceState.Playing;
			this.ForEachPlaySequence(callback);
			Singleton<EventSystem>.Instance.Emit(EEventName.PlotSequenceStarted);
			ModelBase<PlotModel>.Instance.SeamlessLockState = false;
		}

		// Token: 0x06036878 RID: 223352 RVA: 0x00DC88B8 File Offset: 0x00DC6AB8
		private void ForEachPlaySequence(Action<bool> callback)
		{
			this.FlowAssistant.PreEachPlay();
			this.SequenceAssistant.PreEachPlay();
			this.ActorAssistant.PreEachPlay();
			this.RenderAssistant.PreEachPlay();
			this.CameraAssistant.PreEachPlay();
			this.SequenceAssistant.Play(delegate
			{
				this.RenderAssistant.EachStop();
				this.SequenceAssistant.EachStop();
				this.UiAssistant.EachStop();
				this.FlowAssistant.EachStop();
				this.CameraAssistant.EachStop();
				if (this.Model.IsFinish())
				{
					Singleton<EventSystem>.Instance.Emit(EEventName.PlotSequenceEnd);
					callback(true);
					return;
				}
				this.WaitSubLevelThenContinue(callback).Forget();
			});
		}

		// Token: 0x06036879 RID: 223353 RVA: 0x00DC8928 File Offset: 0x00DC6B28
		private UniTask WaitSubLevelThenContinue(Action<bool> callback)
		{
			SequenceController.<WaitSubLevelThenContinue>d__34 <WaitSubLevelThenContinue>d__;
			<WaitSubLevelThenContinue>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitSubLevelThenContinue>d__.<>4__this = this;
			<WaitSubLevelThenContinue>d__.callback = callback;
			<WaitSubLevelThenContinue>d__.<>1__state = -1;
			<WaitSubLevelThenContinue>d__.<>t__builder.Start<SequenceController.<WaitSubLevelThenContinue>d__34>(ref <WaitSubLevelThenContinue>d__);
			return <WaitSubLevelThenContinue>d__.<>t__builder.Task;
		}

		// Token: 0x0603687A RID: 223354 RVA: 0x00DC8974 File Offset: 0x00DC6B74
		private UniTask CheckSwitchSubLevelWithTimeout()
		{
			SequenceController.<CheckSwitchSubLevelWithTimeout>d__35 <CheckSwitchSubLevelWithTimeout>d__;
			<CheckSwitchSubLevelWithTimeout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckSwitchSubLevelWithTimeout>d__.<>1__state = -1;
			<CheckSwitchSubLevelWithTimeout>d__.<>t__builder.Start<SequenceController.<CheckSwitchSubLevelWithTimeout>d__35>(ref <CheckSwitchSubLevelWithTimeout>d__);
			return <CheckSwitchSubLevelWithTimeout>d__.<>t__builder.Task;
		}

		// Token: 0x0603687B RID: 223355 RVA: 0x00DC89B0 File Offset: 0x00DC6BB0
		private void StopPlay(Action<bool> callback)
		{
			this.Model.State = ESequenceState.Stopping;
			this.FunctionAssistant.AllStop(null);
			this.RenderAssistant.AllStop(null);
			this.FlowAssistant.AllStop(null);
			this.UiAssistant.AllStop(null);
			UniTask<bool> task = this.ActorAssistant.AllStopPromise();
			UniTask<bool> task2 = this.CameraAssistant.AllStopPromise();
			this.CameraAssistant.AllStop(null);
			UniTask.WhenAll<bool, bool>(task, task2).ContinueWith(delegate(ValueTuple<bool, bool> result)
			{
				if (!result.Item1)
				{
					callback(false);
					return;
				}
				this.SequenceAssistant.AllStop(null);
				this.EndPlay();
				callback(true);
			});
		}

		// Token: 0x0603687C RID: 223356 RVA: 0x00DC8A48 File Offset: 0x00DC6C48
		private void EndPlay()
		{
			if (this.Model.IsEnding)
			{
				return;
			}
			if (this.ForceStreamPromise != null)
			{
				this.ForceStreamPromise.SetResult(false);
				this.ForceStreamPromise = null;
			}
			if (this.Model.ForceStreamHandle != null)
			{
				this.Model.ForceStreamHandle.Cancel();
				this.Model.ForceStreamHandle = null;
			}
			this.Model.State = ESequenceState.Ending;
			this.RenderAssistant.End();
			this.SequenceAssistant.End();
			this.ActorAssistant.End();
			this.UiAssistant.End();
			this.FunctionAssistant.End();
			this.FlowAssistant.End();
			this.CameraAssistant.End();
			TArray<AActor> tarray = new TArray<AActor>();
			UGameplayStatics.GetAllActorsOfClass(GlobalData.World, AKuroPostProcessVolume.StaticClass(), ref tarray);
			int num = tarray.Num();
			FName tag = new FName("SequencePostProcess");
			for (int i = 0; i < num; i++)
			{
				AKuroPostProcessVolume akuroPostProcessVolume = tarray.Get(i) as AKuroPostProcessVolume;
				if (akuroPostProcessVolume.ActorHasTag(tag))
				{
					akuroPostProcessVolume.Settings = new FPostProcessSettings();
				}
			}
			this.Model.State = ESequenceState.Null;
		}

		// Token: 0x0603687D RID: 223357 RVA: 0x00DC8B6B File Offset: 0x00DC6D6B
		private void DoCallback(bool result)
		{
			if (this.Model.FinishCallback == null)
			{
				return;
			}
			Action<bool> finishCallback = this.Model.FinishCallback;
			this.Model.FinishCallback = null;
			finishCallback(result);
		}

		// Token: 0x17008D93 RID: 36243
		// (get) Token: 0x0603687E RID: 223358 RVA: 0x00DC8B98 File Offset: 0x00DC6D98
		public Event<ESequenceEventName, Delegate> Event
		{
			get
			{
				return this.UiAssistant.Event;
			}
		}

		// Token: 0x0603687F RID: 223359 RVA: 0x00DC8BA5 File Offset: 0x00DC6DA5
		public void SelectOption(int index, int talkItemId)
		{
			this.UiAssistant.HandleSelectedOption(index, talkItemId).Forget();
		}

		// Token: 0x06036880 RID: 223360 RVA: 0x00DC8BB9 File Offset: 0x00DC6DB9
		public void FinishSubtitle(int id)
		{
			this.UiAssistant.HandlePlotSubtitleEnd(id, true).Forget();
		}

		// Token: 0x06036881 RID: 223361 RVA: 0x00DC8BCD File Offset: 0x00DC6DCD
		public void JumpToNextSubtitleOrChildSeq()
		{
			this.SequenceAssistant.JumpToNextSubtitleOrChildSeq();
		}

		// Token: 0x06036882 RID: 223362 RVA: 0x00DC8BDA File Offset: 0x00DC6DDA
		public void AccelerateToNextSubtitleOrChildSeq(Action finishCallback)
		{
			this.SequenceAssistant.AccelerateToNextSubtitleOrChildSeq(finishCallback);
		}

		// Token: 0x06036883 RID: 223363 RVA: 0x00DC8BE8 File Offset: 0x00DC6DE8
		public void ClearAccelerateCallback()
		{
			this.SequenceAssistant.ClearAccelerateCallback();
		}

		// Token: 0x06036884 RID: 223364 RVA: 0x00DC8BF5 File Offset: 0x00DC6DF5
		[NullableContext(2)]
		public void PauseSequence(string reason = null)
		{
			this.SequenceAssistant.PauseSequence(reason);
		}

		// Token: 0x06036885 RID: 223365 RVA: 0x00DC8C03 File Offset: 0x00DC6E03
		[NullableContext(2)]
		public void ResumeSequence(string reason = null, bool? goToNextFrame = null)
		{
			this.SequenceAssistant.ResumeSequence(reason, goToNextFrame);
		}

		// Token: 0x06036886 RID: 223366 RVA: 0x00DC8C12 File Offset: 0x00DC6E12
		public void SetNextSequenceIndex(int index)
		{
			this.FlowAssistant.SetNextSequenceIndex(index);
		}

		// Token: 0x06036887 RID: 223367 RVA: 0x00DC8C20 File Offset: 0x00DC6E20
		public void CheckSeqStreamingData()
		{
			if (this.RenderAssistant.CheckSeqStreamingData() && this.CheckRenderDataPromise != null)
			{
				this.CheckRenderDataPromise.SetResult(true);
				this.CheckRenderDataPromise = null;
			}
		}

		// Token: 0x06036888 RID: 223368 RVA: 0x00DC8C4A File Offset: 0x00DC6E4A
		public void FlushDialogueState()
		{
			this.UiAssistant.TriggerAllSubtitle();
		}

		// Token: 0x06036889 RID: 223369 RVA: 0x00DC8C57 File Offset: 0x00DC6E57
		public void TryApplyMouthAnim(string textKey, List<int> characterIdList)
		{
			this.ActorAssistant.TryApplyMouthAnim(textKey, characterIdList);
		}

		// Token: 0x0603688A RID: 223370 RVA: 0x00DC8C68 File Offset: 0x00DC6E68
		public void StopMouthAnim()
		{
			if (this.ActorAssistant == null)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.JYS, "StopMouthAnim失败,this.ActorAssistant为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.ActorAssistant.StopMouthAnim();
		}

		// Token: 0x0603688B RID: 223371 RVA: 0x00DC8CA5 File Offset: 0x00DC6EA5
		public void RunSequenceFrameEvents(string key)
		{
			this.FunctionAssistant.RunSequenceFrameEvents(key);
		}

		// Token: 0x0603688C RID: 223372 RVA: 0x00DC8CB4 File Offset: 0x00DC6EB4
		public void TriggerCutChange()
		{
			this.Model.DisableMotionBlurFrame = 2f;
			this.RenderAssistant.SetMotionBlurState(false);
			EPlotSequenceType? type = this.Model.Type;
			EPlotSequenceType eplotSequenceType = EPlotSequenceType.过场;
			if ((type.GetValueOrDefault() == eplotSequenceType & type != null) && this.SequenceAssistant.ReadNeedHidePlayer())
			{
				this.ActorAssistant.PlayerHide();
			}
			this.CameraAssistant.CalcPreloadLocation();
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.InvalidSeveralFrameOcculusion 5", null);
			if (GlobalData.IsSm5 && UKuroSequencePerformanceManager.GetPerformanceMode() == EKuroPerformanceMode.EPM_InPerformanceMode && UKuroSequencePerformanceManager.GetShadowUpdateCVar())
			{
				this.RenderAssistant.CmdShadowUpdate();
			}
		}

		// Token: 0x0603688D RID: 223373 RVA: 0x00DC8D5D File Offset: 0x00DC6F5D
		public void ShowLogo(float time)
		{
			this.FunctionAssistant.ShowLogo(time);
		}

		// Token: 0x0603688E RID: 223374 RVA: 0x00DC8D6B File Offset: 0x00DC6F6B
		public void OpenUiView(string assetPath, string spineName, bool needLoop = true, bool useFullscreenAdaptAnchor = false)
		{
			this.FunctionAssistant.OpenBackgroundImage(assetPath, spineName, needLoop, useFullscreenAdaptAnchor).Forget();
		}

		// Token: 0x0603688F RID: 223375 RVA: 0x00DC8D82 File Offset: 0x00DC6F82
		public void OpenUiViewForArray(string assetPath, TArray<SpineThingsInfo> spineArray, bool useFullscreenAdaptAnchor = false)
		{
			this.FunctionAssistant.OpenBackgroundImageInArray(assetPath, spineArray, useFullscreenAdaptAnchor).Forget();
		}

		// Token: 0x06036890 RID: 223376 RVA: 0x00DC8D97 File Offset: 0x00DC6F97
		public void PlayUiLevelSequence(string seqName)
		{
			this.FunctionAssistant.PlayUiLevelSequence(seqName).Forget();
		}

		// Token: 0x06036891 RID: 223377 RVA: 0x00DC8DAA File Offset: 0x00DC6FAA
		public void CloseUiView()
		{
			this.FunctionAssistant.CloseBackgroundImage().Forget();
		}

		// Token: 0x06036892 RID: 223378 RVA: 0x00DC8DBC File Offset: 0x00DC6FBC
		public void PlaySpineAnim(string spineName, bool needLoop = true)
		{
			this.FunctionAssistant.PlaySpineAnim(spineName, needLoop);
		}

		// Token: 0x06036893 RID: 223379 RVA: 0x00DC8DCB File Offset: 0x00DC6FCB
		public void PlaySpineAnimInArray(TArray<SpineThingsInfo> spineArray)
		{
			this.FunctionAssistant.PlaySpineAnimInArray(spineArray);
		}

		// Token: 0x06036894 RID: 223380 RVA: 0x00DC8DD9 File Offset: 0x00DC6FD9
		public void CloseSpineAnim(string spineName)
		{
			this.FunctionAssistant.CloseSpineAnimation(spineName);
		}

		// Token: 0x06036895 RID: 223381 RVA: 0x00DC8DE7 File Offset: 0x00DC6FE7
		public void CloseSpineAnimInArray(TArray<string> spineArray)
		{
			this.FunctionAssistant.CloseSpineAnimationInArray(spineArray);
		}

		// Token: 0x06036896 RID: 223382 RVA: 0x00DC8DF5 File Offset: 0x00DC6FF5
		public void DisableMotionBlurAwhile()
		{
			this.Model.DisableMotionBlurFrame = 2f;
			this.RenderAssistant.SetMotionBlurState(false);
		}

		// Token: 0x06036897 RID: 223383 RVA: 0x00DC8E13 File Offset: 0x00DC7013
		public void AdditionSeqPlay(ULevelSequence levelSequence, FName componentName, FName boneName, int frame)
		{
			this.FunctionAssistant.AdditionSeqPlay(levelSequence, componentName, boneName, frame);
		}

		// Token: 0x06036898 RID: 223384 RVA: 0x00DC8E25 File Offset: 0x00DC7025
		public void AdditionSeqEnd()
		{
			this.FunctionAssistant.AdditionSeqEnd();
		}

		// Token: 0x06036899 RID: 223385 RVA: 0x00DC8E32 File Offset: 0x00DC7032
		public void EnableCameraShake(bool bEnable, TSoftClassPtr<UMatineeCameraShake> cameraShakePtr)
		{
			if (bEnable)
			{
				this.CameraAssistant.StartCameraShake(cameraShakePtr);
				return;
			}
			this.CameraAssistant.StopCameraShake(cameraShakePtr);
		}

		// Token: 0x0603689A RID: 223386 RVA: 0x00DC8E50 File Offset: 0x00DC7050
		public string GetCurrentSequenceDebugInfo()
		{
			ULevelSequence currentSequence = this.Model.GetCurrentSequence();
			if (currentSequence == null)
			{
				return "";
			}
			ALevelSequenceActor curLevelSeqActor = this.Model.CurLevelSeqActor;
			int? num;
			if (curLevelSeqActor == null)
			{
				num = null;
			}
			else
			{
				ULevelSequencePlayer sequencePlayer = curLevelSeqActor.SequencePlayer;
				num = ((sequencePlayer != null) ? new int?(sequencePlayer.GetCurrentTime().Time.FrameNumber.Value) : null);
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 2);
			defaultInterpolatedStringHandler.AppendFormatted(currentSequence.GetName());
			defaultInterpolatedStringHandler.AppendLiteral("  Frame: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(valueOrDefault);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0401F64E RID: 128590
		[Nullable(2)]
		private CustomPromise<bool> CheckRenderDataPromise;

		// Token: 0x0401F64F RID: 128591
		[Nullable(2)]
		private CustomPromise<bool> ForceStreamPromise;

		// Token: 0x0401F650 RID: 128592
		[Nullable(2)]
		private SequenceModel Model;

		// Token: 0x0401F651 RID: 128593
		private const int DEFAULT_WAIT_SUB_LEVEL_TIMEOUT_S = 10;

		// Token: 0x0401F652 RID: 128594
		private readonly int ForceStreamTimeoutMs = 10000;

		// Token: 0x0401F653 RID: 128595
		public bool GmForceCollectExtraTexture;

		// Token: 0x0200B2D8 RID: 45784
		[NullableContext(0)]
		private enum EAssistantType
		{
			// Token: 0x040376E7 RID: 227047
			SequenceAssistant,
			// Token: 0x040376E8 RID: 227048
			ActorAssistant,
			// Token: 0x040376E9 RID: 227049
			FunctionAssistant,
			// Token: 0x040376EA RID: 227050
			CameraAssistant,
			// Token: 0x040376EB RID: 227051
			RenderAssistant,
			// Token: 0x040376EC RID: 227052
			FlowAssistant,
			// Token: 0x040376ED RID: 227053
			UiAssistant
		}
	}
}
