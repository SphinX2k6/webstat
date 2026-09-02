using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.StaticScene;
using CSharpScript.Game.Render;
using CSharpScript.Game.World.StepSequence;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;

namespace CSharpScript.Game.Module.DataLayerSwitch
{
	// Token: 0x02005DD3 RID: 24019
	[NullableContext(2)]
	[Nullable(0)]
	public class DataLayersTransitionTask : IStaticVariableResetter
	{
		// Token: 0x0603C76B RID: 247659 RVA: 0x00F5B0E4 File Offset: 0x00F592E4
		static DataLayersTransitionTask()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(DataLayersTransitionTask.CreateStaticDefaultValue), new Action(DataLayersTransitionTask.ResetStaticDefaultValue));
		}

		// Token: 0x0603C76C RID: 247660 RVA: 0x00F5B103 File Offset: 0x00F59303
		public static void CreateStaticDefaultValue()
		{
			DataLayersTransitionTask.MaxTaskId = 0;
		}

		// Token: 0x0603C76D RID: 247661 RVA: 0x00F5B10B File Offset: 0x00F5930B
		public static void ResetStaticDefaultValue()
		{
			DataLayersTransitionTask.MaxTaskId = 0;
		}

		// Token: 0x0603C76E RID: 247662 RVA: 0x00F5B114 File Offset: 0x00F59314
		public DataLayersTransitionTask()
		{
			this.TaskId = ++DataLayersTransitionTask.MaxTaskId;
		}

		// Token: 0x0603C76F RID: 247663 RVA: 0x00F5B1A4 File Offset: 0x00F593A4
		private UKuroSceneModifierSubsystem GetKuroSceneModifierSubsystem()
		{
			UKuroSceneModifierSubsystem kuroSceneModifierSubsystemCache = this.KuroSceneModifierSubsystemCache;
			if (kuroSceneModifierSubsystemCache == null || !kuroSceneModifierSubsystemCache.IsValid())
			{
				this.KuroSceneModifierSubsystemCache = (UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UKuroSceneModifierSubsystem.StaticClass()) as UKuroSceneModifierSubsystem);
				UKuroSceneModifierSubsystem kuroSceneModifierSubsystemCache2 = this.KuroSceneModifierSubsystemCache;
				if (kuroSceneModifierSubsystemCache2 == null || !kuroSceneModifierSubsystemCache2.IsValid())
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Level;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "[DataLayersTransitionTask] 获取KuroSceneModifierSubsystem失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TaskId", this.TaskId);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					this.KuroSceneModifierSubsystemCache = null;
				}
			}
			return this.KuroSceneModifierSubsystemCache;
		}

		// Token: 0x0603C770 RID: 247664 RVA: 0x00F5B23C File Offset: 0x00F5943C
		public unsafe void StartTask()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Level;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[DataLayersTransitionTask] DataLayer过渡开始";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TaskId", this.TaskId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ToActivateDataLayerNames", this.ToActivateDataLayerNames);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ToDeactivateDataLayerNames", this.ToDeactivateDataLayerNames);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (this.ToActivateDataLayerNames == null && this.ToDeactivateDataLayerNames == null)
			{
				this.StopTask(true);
				return;
			}
			this.Transition();
		}

		// Token: 0x0603C771 RID: 247665 RVA: 0x00F5B2E8 File Offset: 0x00F594E8
		[NullableContext(1)]
		private void InitUeContainerFromSet(HashSet<FName> inSet, TArray<FName> outUeSet)
		{
			outUeSet.Empty(true);
			foreach (FName value in inSet)
			{
				outUeSet.Add(value);
			}
		}

		// Token: 0x0603C772 RID: 247666 RVA: 0x00F5B340 File Offset: 0x00F59540
		[NullableContext(1)]
		private void InitUeContainerFromSet(HashSet<FName> inSet, TSet<FName> outUeSet)
		{
			outUeSet.Empty(0);
			foreach (FName value in inSet)
			{
				outUeSet.Add(value);
			}
		}

		// Token: 0x0603C773 RID: 247667 RVA: 0x00F5B398 File Offset: 0x00F59598
		[NullableContext(1)]
		private void ChangeDataLayerState(HashSet<FName> dataLayerNames, bool targetState)
		{
			if (this.IsServerControlledDataLayer && dataLayerNames.Count > 0)
			{
				Singleton<EventSystem>.Instance.Emit<ELevelEnvChangeType, FVectorDouble?, float?>(EEventName.OnLevelEnvChange, ELevelEnvChangeType.DataLayer, null, null);
			}
			foreach (FName fname in dataLayerNames)
			{
				string text = fname.ToString();
				if (this.IsServerControlledDataLayer)
				{
					if (targetState)
					{
						ModelBase<GameModeModel>.Instance.AddDataLayer(text);
					}
					else
					{
						ModelBase<GameModeModel>.Instance.RemoveDataLayer(text);
					}
				}
				if (ControllerBase<RenderModuleController>.Instance.IsWorldPartitionDataLayerEnable(text) != targetState)
				{
					ControllerBase<RenderModuleController>.Instance.SetWorldPartitionDataLayerState(text, targetState, false);
				}
			}
		}

		// Token: 0x0603C774 RID: 247668 RVA: 0x00F5B468 File Offset: 0x00F59668
		private void Transition()
		{
			if (this.ToActivateDataLayerNames != null)
			{
				this.ToActivateDataLayerNamesUeSet = new TSet<FName>();
				this.InitUeContainerFromSet(this.ToActivateDataLayerNames, this.ToActivateDataLayerNamesUeSet);
			}
			if (this.ToDeactivateDataLayerNames != null)
			{
				this.ToDeactivateDataLayerNamesUeSet = new TSet<FName>();
				this.InitUeContainerFromSet(this.ToDeactivateDataLayerNames, this.ToDeactivateDataLayerNamesUeSet);
			}
			new StepSequence().AddStep((SequenceContext _) => this.TransitionPartLoadResources()).AddStep(delegate(SequenceContext ctx)
			{
				this.TransitionPartCheckBeforeTransition(ctx);
				return UniTask.CompletedTask;
			}).AddStep((SequenceContext _) => this.TransitionPartPlaySeqToBeforeModifyMatMark()).AddStep(delegate(SequenceContext _)
			{
				this.TransitionPartModifyMat();
				return UniTask.CompletedTask;
			}).AddStep((SequenceContext _) => this.TransitionPartLoadDataLayer()).AddStep((SequenceContext _) => this.TransitionPartPlaySeqToEnd()).AddStep((SequenceContext _) => this.TransitionPartUnloadDataLayer()).AddStep(delegate(SequenceContext _)
			{
				this.TransitionPartResetMat();
				return UniTask.CompletedTask;
			}).AddStep(delegate(SequenceContext _)
			{
				this.TransitionPartClearCustomCullFlag();
				return UniTask.CompletedTask;
			}).AddStep((SequenceContext _) => this.TransitionPartRenderAssetsCheck()).AddStep(delegate(SequenceContext _)
			{
				this.TransitionPartFixBornLocation();
				return UniTask.CompletedTask;
			}).SetOnAbort(delegate
			{
				this.OnTransitionAborted();
			}).SetFinally(delegate
			{
				this.StopTask(true);
			}).Run(this.AbortSignal);
		}

		// Token: 0x0603C775 RID: 247669 RVA: 0x00F5B5B0 File Offset: 0x00F597B0
		private UniTask TransitionPartLoadResources()
		{
			DataLayersTransitionTask.<TransitionPartLoadResources>d__51 <TransitionPartLoadResources>d__;
			<TransitionPartLoadResources>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TransitionPartLoadResources>d__.<>4__this = this;
			<TransitionPartLoadResources>d__.<>1__state = -1;
			<TransitionPartLoadResources>d__.<>t__builder.Start<DataLayersTransitionTask.<TransitionPartLoadResources>d__51>(ref <TransitionPartLoadResources>d__);
			return <TransitionPartLoadResources>d__.<>t__builder.Task;
		}

		// Token: 0x0603C776 RID: 247670 RVA: 0x00F5B5F4 File Offset: 0x00F597F4
		[NullableContext(1)]
		private void StartTrackedResourceLoad<[Nullable(0)] T>(string path, [Nullable(new byte[]
		{
			1,
			2
		})] Action<T> onLoaded) where T : UObject, IUnrealUObject
		{
			int id = -1;
			bool done = false;
			id = Singleton<ResourceSystem>.Instance.LoadAsync<T>(path, delegate([Nullable(2)] T asset, string _)
			{
				done = true;
				this.ActiveLoadIds.Remove(id);
				onLoaded(asset);
			}, 100, "js_undefined");
			if (id != -1 && !done)
			{
				this.ActiveLoadIds.Add(id);
			}
		}

		// Token: 0x0603C777 RID: 247671 RVA: 0x00F5B66A File Offset: 0x00F5986A
		[NullableContext(1)]
		private void TransitionPartCheckBeforeTransition(SequenceContext ctx)
		{
			HashSet<FName> toActivateDataLayerNames = this.ToActivateDataLayerNames;
			if (toActivateDataLayerNames == null || toActivateDataLayerNames.Count <= 0)
			{
				HashSet<FName> toDeactivateDataLayerNames = this.ToDeactivateDataLayerNames;
				if (toDeactivateDataLayerNames == null || toDeactivateDataLayerNames.Count <= 0)
				{
					ctx.Stop();
					return;
				}
			}
			this.CheckLogBeforeTransition();
		}

		// Token: 0x0603C778 RID: 247672 RVA: 0x00F5B6A8 File Offset: 0x00F598A8
		private void OnTransitionAborted()
		{
			foreach (int id in this.ActiveLoadIds)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(id);
			}
			this.ActiveLoadIds.Clear();
			foreach (Action action in new List<Action>(this.ActivePollFinishers))
			{
				action();
			}
			HashSet<FName> toActivateDataLayerNames = this.ToActivateDataLayerNames;
			if (toActivateDataLayerNames != null && toActivateDataLayerNames.Count > 0)
			{
				this.ChangeDataLayerState(this.ToActivateDataLayerNames, true);
			}
			HashSet<FName> toDeactivateDataLayerNames = this.ToDeactivateDataLayerNames;
			if (toDeactivateDataLayerNames != null && toDeactivateDataLayerNames.Count > 0)
			{
				this.ChangeDataLayerState(this.ToDeactivateDataLayerNames, false);
			}
			UKuroSceneModifierSubsystem kuroSceneModifierSubsystem = this.GetKuroSceneModifierSubsystem();
			if (kuroSceneModifierSubsystem != null)
			{
				kuroSceneModifierSubsystem.ResetMaterialsByDataLayer(this.ToActivateDataLayerNamesUeSet);
			}
			UKuroSceneModifierSubsystem kuroSceneModifierSubsystem2 = this.GetKuroSceneModifierSubsystem();
			if (kuroSceneModifierSubsystem2 == null)
			{
				return;
			}
			kuroSceneModifierSubsystem2.ResetMaterialsByDataLayer(this.ToDeactivateDataLayerNamesUeSet);
		}

		// Token: 0x0603C779 RID: 247673 RVA: 0x00F5B7C4 File Offset: 0x00F599C4
		private unsafe void CheckLogBeforeTransition()
		{
			HashSet<FName> toActivateDataLayerNames = this.ToActivateDataLayerNames;
			if (toActivateDataLayerNames != null && toActivateDataLayerNames.Count > 0)
			{
				HashSet<FName> toDeactivateDataLayerNames = this.ToDeactivateDataLayerNames;
				if (toDeactivateDataLayerNames != null && toDeactivateDataLayerNames.Count > 0 && this.MatDataForActivating != null && this.MatDataForDeactivating != null && this.SeqData != null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Level;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "[DataLayersTransitionTask] 同时控制DataLayer显示的过渡和DataLayer隐藏的过渡，可能导致表现问题";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TaskId", this.TaskId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ToActivateDataLayerNames", this.ToActivateDataLayerNames);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ToDeactivateDataLayerNames", this.ToDeactivateDataLayerNames);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
			}
			HashSet<FName> toActivateDataLayerNames2 = this.ToActivateDataLayerNames;
			if (toActivateDataLayerNames2 == null || toActivateDataLayerNames2.Count <= 0 || this.MatDataForActivating == null)
			{
				HashSet<FName> toDeactivateDataLayerNames2 = this.ToDeactivateDataLayerNames;
				if (toDeactivateDataLayerNames2 == null || toDeactivateDataLayerNames2.Count <= 0 || this.MatDataForDeactivating == null)
				{
					return;
				}
			}
			if (this.SeqData == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Level;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[DataLayersTransitionTask] 要处理的DataLayer和过渡材质DA, 但是没有过渡Seq, 可能导致表现问题";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("TaskId", this.TaskId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ToActivateDataLayerNames", this.ToActivateDataLayerNames);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("ToDeactivateDataLayerNames", this.ToDeactivateDataLayerNames);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			}
		}

		// Token: 0x0603C77A RID: 247674 RVA: 0x00F5B970 File Offset: 0x00F59B70
		private UniTask TransitionPartPlaySeqToBeforeModifyMatMark()
		{
			DataLayersTransitionTask.<TransitionPartPlaySeqToBeforeModifyMatMark>d__56 <TransitionPartPlaySeqToBeforeModifyMatMark>d__;
			<TransitionPartPlaySeqToBeforeModifyMatMark>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TransitionPartPlaySeqToBeforeModifyMatMark>d__.<>4__this = this;
			<TransitionPartPlaySeqToBeforeModifyMatMark>d__.<>1__state = -1;
			<TransitionPartPlaySeqToBeforeModifyMatMark>d__.<>t__builder.Start<DataLayersTransitionTask.<TransitionPartPlaySeqToBeforeModifyMatMark>d__56>(ref <TransitionPartPlaySeqToBeforeModifyMatMark>d__);
			return <TransitionPartPlaySeqToBeforeModifyMatMark>d__.<>t__builder.Task;
		}

		// Token: 0x0603C77B RID: 247675 RVA: 0x00F5B9B4 File Offset: 0x00F59BB4
		private void TransitionPartModifyMat()
		{
			UKuroSceneMatModifyDataAsset matDataForActivating = this.MatDataForActivating;
			if (matDataForActivating != null && matDataForActivating.IsValid())
			{
				UKuroSceneModifierSubsystem kuroSceneModifierSubsystem = this.GetKuroSceneModifierSubsystem();
				if (kuroSceneModifierSubsystem != null)
				{
					kuroSceneModifierSubsystem.ModifyMaterialsByDataLayer(this.ToActivateDataLayerNamesUeSet, this.MatDataForActivating, false);
				}
			}
			UKuroSceneMatModifyDataAsset matDataForDeactivating = this.MatDataForDeactivating;
			if (matDataForDeactivating != null && matDataForDeactivating.IsValid())
			{
				UKuroSceneModifierSubsystem kuroSceneModifierSubsystem2 = this.GetKuroSceneModifierSubsystem();
				if (kuroSceneModifierSubsystem2 == null)
				{
					return;
				}
				kuroSceneModifierSubsystem2.ModifyMaterialsByDataLayer(this.ToDeactivateDataLayerNamesUeSet, this.MatDataForDeactivating, true);
			}
		}

		// Token: 0x0603C77C RID: 247676 RVA: 0x00F5BA24 File Offset: 0x00F59C24
		[NullableContext(1)]
		private unsafe UniTask PollWithTimeout(string logTag, Func<bool> check, int intervalMs, float maxWaitTime)
		{
			UniTaskCompletionSource tcs = new UniTaskCompletionSource();
			TimerHandle pollTimer = null;
			TimerHandle maxTimer = null;
			bool finished = false;
			Action finish = null;
			finish = delegate()
			{
				if (finished)
				{
					return;
				}
				finished = true;
				this.ActivePollFinishers.Remove(finish);
				if (pollTimer != null && TimerSystem.Instance.Has(pollTimer))
				{
					TimerSystem.Instance.Remove(pollTimer);
				}
				if (maxTimer != null && TimerSystem.Instance.Has(maxTimer))
				{
					TimerSystem.Instance.Remove(maxTimer);
				}
				tcs.TrySetResult();
			};
			this.ActivePollFinishers.Add(finish);
			pollTimer = TimerSystem.Instance.Forever(delegate(float _)
			{
				if (check())
				{
					finish();
				}
			}, (float)intervalMs, 1f, null, null, true);
			if (pollTimer == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Level;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[DataLayersTransitionTask] " + logTag + ":设置轮询计时器时出错,强行结束";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TaskId", this.TaskId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				finish();
				return tcs.Task;
			}
			float num = maxWaitTime * 1000f;
			if (num <= 0f)
			{
				return tcs.Task;
			}
			if (num < 20f)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Level;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[DataLayersTransitionTask] " + logTag + ":超时时间不≤0但又过短,强行结束";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TaskId", this.TaskId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("WaitMaxTime", maxWaitTime);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				finish();
				return tcs.Task;
			}
			maxTimer = TimerSystem.Instance.Delay(delegate(float _)
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.Level;
				ELogAuthor author4 = ELogAuthor.ZYL;
				string message4 = "[DataLayersTransitionTask] " + logTag + ":等待超时,强行结束";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("TaskId", this.TaskId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("WaitMaxTime", maxWaitTime);
				instance4.Warn(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				finish();
			}, num, null, null, true, 1f);
			if (maxTimer == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Level;
				ELogAuthor author3 = ELogAuthor.ZYL;
				string message3 = "[DataLayersTransitionTask] " + logTag + ":设置超时计时器时出错,强行结束";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("TaskId", this.TaskId);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				finish();
			}
			return tcs.Task;
		}

		// Token: 0x0603C77D RID: 247677 RVA: 0x00F5BC64 File Offset: 0x00F59E64
		[NullableContext(1)]
		private Func<bool> CreatePlayerDriftChecker()
		{
			DataLayersTransitionTask.<>c__DisplayClass60_0 CS$<>8__locals1 = new DataLayersTransitionTask.<>c__DisplayClass60_0();
			CS$<>8__locals1.<>4__this = this;
			DataLayersTransitionTask.<>c__DisplayClass60_0 CS$<>8__locals2 = CS$<>8__locals1;
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CS$<>8__locals2.actorComponent = ((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null);
			DataLayersTransitionTask.<>c__DisplayClass60_0 CS$<>8__locals3 = CS$<>8__locals1;
			CharacterActorComponent actorComponent = CS$<>8__locals1.actorComponent;
			CS$<>8__locals3.startLocation = ((actorComponent != null) ? actorComponent.ActorLocationProxy : null);
			if (!this.ShouldAbortOnPlayerDrift || CS$<>8__locals1.actorComponent == null || CS$<>8__locals1.startLocation == null)
			{
				return () => false;
			}
			CS$<>8__locals1.driftTmp = Vector.Create();
			return delegate()
			{
				CS$<>8__locals1.actorComponent.ActorLocationProxy.Subtraction(CS$<>8__locals1.startLocation, CS$<>8__locals1.driftTmp);
				return CS$<>8__locals1.driftTmp.SizeSquared() > (double)CS$<>8__locals1.<>4__this.DriftAbortDistanceSquare;
			};
		}

		// Token: 0x0603C77E RID: 247678 RVA: 0x00F5BCFC File Offset: 0x00F59EFC
		private UniTask TransitionPartLoadDataLayer()
		{
			DataLayersTransitionTask.<TransitionPartLoadDataLayer>d__61 <TransitionPartLoadDataLayer>d__;
			<TransitionPartLoadDataLayer>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TransitionPartLoadDataLayer>d__.<>4__this = this;
			<TransitionPartLoadDataLayer>d__.<>1__state = -1;
			<TransitionPartLoadDataLayer>d__.<>t__builder.Start<DataLayersTransitionTask.<TransitionPartLoadDataLayer>d__61>(ref <TransitionPartLoadDataLayer>d__);
			return <TransitionPartLoadDataLayer>d__.<>t__builder.Task;
		}

		// Token: 0x0603C77F RID: 247679 RVA: 0x00F5BD40 File Offset: 0x00F59F40
		private UniTask TryWaitDataLayerStreaming(HashSet<FName> dataLayerNames, bool considerVoxel, bool modifyBudget, ELoadMode loadMode, float maxWaitTime)
		{
			DataLayersTransitionTask.<TryWaitDataLayerStreaming>d__62 <TryWaitDataLayerStreaming>d__;
			<TryWaitDataLayerStreaming>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TryWaitDataLayerStreaming>d__.<>4__this = this;
			<TryWaitDataLayerStreaming>d__.dataLayerNames = dataLayerNames;
			<TryWaitDataLayerStreaming>d__.considerVoxel = considerVoxel;
			<TryWaitDataLayerStreaming>d__.modifyBudget = modifyBudget;
			<TryWaitDataLayerStreaming>d__.loadMode = loadMode;
			<TryWaitDataLayerStreaming>d__.maxWaitTime = maxWaitTime;
			<TryWaitDataLayerStreaming>d__.<>1__state = -1;
			<TryWaitDataLayerStreaming>d__.<>t__builder.Start<DataLayersTransitionTask.<TryWaitDataLayerStreaming>d__62>(ref <TryWaitDataLayerStreaming>d__);
			return <TryWaitDataLayerStreaming>d__.<>t__builder.Task;
		}

		// Token: 0x0603C780 RID: 247680 RVA: 0x00F5BDB0 File Offset: 0x00F59FB0
		private UniTask TransitionPartUnloadDataLayer()
		{
			DataLayersTransitionTask.<TransitionPartUnloadDataLayer>d__63 <TransitionPartUnloadDataLayer>d__;
			<TransitionPartUnloadDataLayer>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TransitionPartUnloadDataLayer>d__.<>4__this = this;
			<TransitionPartUnloadDataLayer>d__.<>1__state = -1;
			<TransitionPartUnloadDataLayer>d__.<>t__builder.Start<DataLayersTransitionTask.<TransitionPartUnloadDataLayer>d__63>(ref <TransitionPartUnloadDataLayer>d__);
			return <TransitionPartUnloadDataLayer>d__.<>t__builder.Task;
		}

		// Token: 0x0603C781 RID: 247681 RVA: 0x00F5BDF3 File Offset: 0x00F59FF3
		private void TransitionPartResetMat()
		{
			UKuroSceneModifierSubsystem kuroSceneModifierSubsystem = this.GetKuroSceneModifierSubsystem();
			if (kuroSceneModifierSubsystem != null)
			{
				kuroSceneModifierSubsystem.ResetMaterialsByDataLayer(this.ToActivateDataLayerNamesUeSet);
			}
			UKuroSceneModifierSubsystem kuroSceneModifierSubsystem2 = this.GetKuroSceneModifierSubsystem();
			if (kuroSceneModifierSubsystem2 == null)
			{
				return;
			}
			kuroSceneModifierSubsystem2.ResetMaterialsByDataLayer(this.ToDeactivateDataLayerNamesUeSet);
		}

		// Token: 0x0603C782 RID: 247682 RVA: 0x00F5BE24 File Offset: 0x00F5A024
		private void TransitionPartClearCustomCullFlag()
		{
			if (this.ShouldClearCustomCullFlag)
			{
				TimerSystem.Instance.Delay(delegate(float _)
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.kuro.CustomCullFlag 0", null);
				}, 1000f, null, null, true, 1f);
			}
		}

		// Token: 0x0603C783 RID: 247683 RVA: 0x00F5BE70 File Offset: 0x00F5A070
		private UniTask TransitionPartRenderAssetsCheck()
		{
			DataLayersTransitionTask.<TransitionPartRenderAssetsCheck>d__66 <TransitionPartRenderAssetsCheck>d__;
			<TransitionPartRenderAssetsCheck>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TransitionPartRenderAssetsCheck>d__.<>4__this = this;
			<TransitionPartRenderAssetsCheck>d__.<>1__state = -1;
			<TransitionPartRenderAssetsCheck>d__.<>t__builder.Start<DataLayersTransitionTask.<TransitionPartRenderAssetsCheck>d__66>(ref <TransitionPartRenderAssetsCheck>d__);
			return <TransitionPartRenderAssetsCheck>d__.<>t__builder.Task;
		}

		// Token: 0x0603C784 RID: 247684 RVA: 0x00F5BEB3 File Offset: 0x00F5A0B3
		private void TransitionPartFixBornLocation()
		{
			if (this.ShouldEmitFixBornLocation)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.FixBornLocation);
			}
		}

		// Token: 0x0603C785 RID: 247685 RVA: 0x00F5BED0 File Offset: 0x00F5A0D0
		private UniTask TransitionPartPlaySeqToEnd()
		{
			DataLayersTransitionTask.<TransitionPartPlaySeqToEnd>d__68 <TransitionPartPlaySeqToEnd>d__;
			<TransitionPartPlaySeqToEnd>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TransitionPartPlaySeqToEnd>d__.<>4__this = this;
			<TransitionPartPlaySeqToEnd>d__.<>1__state = -1;
			<TransitionPartPlaySeqToEnd>d__.<>t__builder.Start<DataLayersTransitionTask.<TransitionPartPlaySeqToEnd>d__68>(ref <TransitionPartPlaySeqToEnd>d__);
			return <TransitionPartPlaySeqToEnd>d__.<>t__builder.Task;
		}

		// Token: 0x0603C786 RID: 247686 RVA: 0x00F5BF14 File Offset: 0x00F5A114
		public unsafe void StopTask(bool success)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Level;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[DataLayersTransitionTask] DataLayer过渡结束";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TaskId", this.TaskId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ToActivateDataLayerNames", this.ToActivateDataLayerNames);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ToDeactivateDataLayerNames", this.ToDeactivateDataLayerNames);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			SimpleLevelSequenceActor simpleLevelSequenceActor = this.SimpleLevelSequenceActor;
			if (simpleLevelSequenceActor != null)
			{
				simpleLevelSequenceActor.Clear();
			}
			this.SimpleLevelSequenceActor = null;
			Action<DataLayersTransitionTask, bool> taskFinishCallback = this.TaskFinishCallback;
			if (taskFinishCallback == null)
			{
				return;
			}
			taskFinishCallback(this, success);
		}

		// Token: 0x0603C787 RID: 247687 RVA: 0x00F5BFCC File Offset: 0x00F5A1CC
		public unsafe void AbortTask()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Level;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[DataLayersTransitionTask] DataLayer过渡被中止，强制收到终态";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TaskId", this.TaskId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ToActivateDataLayerNames", this.ToActivateDataLayerNames);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ToDeactivateDataLayerNames", this.ToDeactivateDataLayerNames);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.AbortSignal.Abort();
		}

		// Token: 0x04021FE3 RID: 139235
		private const float DEFAULT_WAIT_DATALAYER_STREAMING_RADIUS = 3500f;

		// Token: 0x04021FE4 RID: 139236
		private static int MaxTaskId;

		// Token: 0x04021FE5 RID: 139237
		private readonly int TaskId;

		// Token: 0x04021FE6 RID: 139238
		public UKuroSceneMatModifyDataAsset MatDataForActivating;

		// Token: 0x04021FE7 RID: 139239
		public string MatPathForActivating;

		// Token: 0x04021FE8 RID: 139240
		public bool MatDataForActivatingLoaded;

		// Token: 0x04021FE9 RID: 139241
		public UKuroSceneMatModifyDataAsset MatDataForDeactivating;

		// Token: 0x04021FEA RID: 139242
		public string MatPathForDeactivating;

		// Token: 0x04021FEB RID: 139243
		public bool MatDataForDeactivatingLoaded;

		// Token: 0x04021FEC RID: 139244
		public ULevelSequence SeqData;

		// Token: 0x04021FED RID: 139245
		public string SeqPath;

		// Token: 0x04021FEE RID: 139246
		public bool SeqDataLoaded;

		// Token: 0x04021FEF RID: 139247
		public string SeqMarkBeforeModifyMat;

		// Token: 0x04021FF0 RID: 139248
		public HashSet<FName> ToActivateDataLayerNames;

		// Token: 0x04021FF1 RID: 139249
		public HashSet<FName> ToDeactivateDataLayerNames;

		// Token: 0x04021FF2 RID: 139250
		public bool ShouldWaitDataLayersActivateFinish;

		// Token: 0x04021FF3 RID: 139251
		public bool ShouldConsiderVoxelDuringWaitDataLayersActivateFinish;

		// Token: 0x04021FF4 RID: 139252
		public float MaxTimeForWaitDataLayerActivateFinish;

		// Token: 0x04021FF5 RID: 139253
		public bool ShouldModifyBudgetDuringWaitDataLayerActivateFinish = true;

		// Token: 0x04021FF6 RID: 139254
		public ELoadMode TargetLoadModeDuringWaitDataLayerActivateFinish = ELoadMode.InGameLoading;

		// Token: 0x04021FF7 RID: 139255
		public bool ShouldWaitDataLayersDeactivateFinish;

		// Token: 0x04021FF8 RID: 139256
		public bool ShouldConsiderVoxelDuringWaitDataLayersDeactivateFinish;

		// Token: 0x04021FF9 RID: 139257
		public float MaxTimeForWaitDataLayerDeactivateFinish;

		// Token: 0x04021FFA RID: 139258
		public bool ShouldModifyBudgetDuringWaitDataLayerDeactivateFinish = true;

		// Token: 0x04021FFB RID: 139259
		public ELoadMode TargetLoadModeDuringWaitDataLayerDeactivateFinish = ELoadMode.InGameLoading;

		// Token: 0x04021FFC RID: 139260
		public float WaitDataLayerStreamingRadius = 3500f;

		// Token: 0x04021FFD RID: 139261
		public bool IsServerControlledDataLayer;

		// Token: 0x04021FFE RID: 139262
		public bool ShouldClearCustomCullFlag;

		// Token: 0x04021FFF RID: 139263
		public bool ShouldCheckRenderAssets;

		// Token: 0x04022000 RID: 139264
		public float RenderAssetsCheckRadius = 7000f;

		// Token: 0x04022001 RID: 139265
		public float WaitRenderAssetsTimeout = 40f;

		// Token: 0x04022002 RID: 139266
		public bool ShouldEmitFixBornLocation;

		// Token: 0x04022003 RID: 139267
		public bool ShouldAbortOnPlayerDrift;

		// Token: 0x04022004 RID: 139268
		public float DriftAbortDistanceSquare = 10000f;

		// Token: 0x04022005 RID: 139269
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<DataLayersTransitionTask, bool> TaskFinishCallback;

		// Token: 0x04022006 RID: 139270
		[Nullable(1)]
		public ISequenceAbortSignal AbortSignal = new DataLayerTransitionAbortSignal();

		// Token: 0x04022007 RID: 139271
		private SimpleLevelSequenceActor SimpleLevelSequenceActor;

		// Token: 0x04022008 RID: 139272
		private TSet<FName> ToActivateDataLayerNamesUeSet;

		// Token: 0x04022009 RID: 139273
		private TSet<FName> ToDeactivateDataLayerNamesUeSet;

		// Token: 0x0402200A RID: 139274
		private UKuroSceneModifierSubsystem KuroSceneModifierSubsystemCache;

		// Token: 0x0402200B RID: 139275
		[Nullable(1)]
		private readonly HashSet<int> ActiveLoadIds = new HashSet<int>();

		// Token: 0x0402200C RID: 139276
		[Nullable(1)]
		private readonly HashSet<Action> ActivePollFinishers = new HashSet<Action>();
	}
}
