using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049BC RID: 18876
	[NullableContext(1)]
	[Nullable(0)]
	public class UiBehaviorLevelSequence : IUiBehavior
	{
		// Token: 0x1700841B RID: 33819
		// (get) Token: 0x060315BD RID: 202173 RVA: 0x00C48DA4 File Offset: 0x00C46FA4
		// (set) Token: 0x060315BE RID: 202174 RVA: 0x00C48DAC File Offset: 0x00C46FAC
		public string StartSequenceName
		{
			get
			{
				return this.StartSequenceNameInternal;
			}
			set
			{
				this.StartSequenceNameInternal = value;
			}
		}

		// Token: 0x1700841C RID: 33820
		// (get) Token: 0x060315BF RID: 202175 RVA: 0x00C48DB5 File Offset: 0x00C46FB5
		// (set) Token: 0x060315C0 RID: 202176 RVA: 0x00C48DBD File Offset: 0x00C46FBD
		public string CloseSequenceName
		{
			get
			{
				return this.CloseSequenceNameInternal;
			}
			set
			{
				this.CloseSequenceNameInternal = value;
			}
		}

		// Token: 0x1700841D RID: 33821
		// (get) Token: 0x060315C1 RID: 202177 RVA: 0x00C48DC6 File Offset: 0x00C46FC6
		// (set) Token: 0x060315C2 RID: 202178 RVA: 0x00C48DCE File Offset: 0x00C46FCE
		public string ShowSequenceName
		{
			get
			{
				return this.ShowSequenceNameInternal;
			}
			set
			{
				this.ShowSequenceNameInternal = value;
			}
		}

		// Token: 0x1700841E RID: 33822
		// (get) Token: 0x060315C3 RID: 202179 RVA: 0x00C48DD7 File Offset: 0x00C46FD7
		// (set) Token: 0x060315C4 RID: 202180 RVA: 0x00C48DDF File Offset: 0x00C46FDF
		public string HideSequenceName
		{
			get
			{
				return this.HideSequenceNameInternal;
			}
			set
			{
				this.HideSequenceNameInternal = value;
			}
		}

		// Token: 0x060315C5 RID: 202181 RVA: 0x00C48DE8 File Offset: 0x00C46FE8
		public UiBehaviorLevelSequence(UiPanelBase owner)
		{
			this.Owner = owner;
		}

		// Token: 0x060315C6 RID: 202182 RVA: 0x00C48E4F File Offset: 0x00C4704F
		public UniTask OnUiCreateAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x060315C7 RID: 202183 RVA: 0x00C48E58 File Offset: 0x00C47058
		public void OnAfterUiStart()
		{
			this.UiSequencePlayer = new UiSequencePlayer(this.Owner.GetRootItem());
			this.UiSequencePlayer.BindOnStartSequenceEvent(new Action<string>(this.OnSequenceStart));
			this.UiSequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.OnSequenceEnd));
		}

		// Token: 0x060315C8 RID: 202184 RVA: 0x00C48EAC File Offset: 0x00C470AC
		private void OnSequenceStart(string sequenceName)
		{
			HashSet<Action<string>> hashSet;
			if (this.StartEventMap.TryGetValue(sequenceName, out hashSet))
			{
				foreach (Action<string> action in hashSet)
				{
					if (action != null)
					{
						action(sequenceName);
					}
				}
			}
		}

		// Token: 0x060315C9 RID: 202185 RVA: 0x00C48F10 File Offset: 0x00C47110
		private void OnSequenceEnd(string sequenceName)
		{
			HashSet<Action<string>> hashSet;
			if (this.EndEventMap.TryGetValue(sequenceName, out hashSet))
			{
				foreach (Action<string> action in hashSet)
				{
					if (action != null)
					{
						action(sequenceName);
					}
				}
			}
		}

		// Token: 0x060315CA RID: 202186 RVA: 0x00C48F74 File Offset: 0x00C47174
		public bool IsInSequence()
		{
			return this.UiSequencePlayer.IsInSequence();
		}

		// Token: 0x060315CB RID: 202187 RVA: 0x00C48F81 File Offset: 0x00C47181
		public bool HasSequenceNameInPlaying(string sequenceName)
		{
			UiSequencePlayer uiSequencePlayer = this.UiSequencePlayer;
			return uiSequencePlayer != null && uiSequencePlayer.IsSequenceInPlaying(sequenceName);
		}

		// Token: 0x060315CC RID: 202188 RVA: 0x00C48F95 File Offset: 0x00C47195
		public void SetSequenceName(UiViewData viewData)
		{
			if (viewData != null)
			{
				this.StartSequenceNameInternal = (viewData.StartSequenceName ?? "Start");
				this.CloseSequenceNameInternal = (viewData.CloseSequenceName ?? "Close");
			}
		}

		// Token: 0x060315CD RID: 202189 RVA: 0x00C48FC4 File Offset: 0x00C471C4
		public void AddSequenceFinishEvent(string sequenceName, Action<string> finishEvent, bool clear = false)
		{
			HashSet<Action<string>> hashSet;
			if (!this.EndEventMap.TryGetValue(sequenceName, out hashSet))
			{
				hashSet = new HashSet<Action<string>>();
				this.EndEventMap[sequenceName] = hashSet;
			}
			else if (clear)
			{
				hashSet.Clear();
			}
			if (hashSet.Contains(finishEvent))
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCore, ELogAuthor.LFJW, "SequenceFinishEvent重复添加。", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			hashSet.Add(finishEvent);
		}

		// Token: 0x060315CE RID: 202190 RVA: 0x00C4902C File Offset: 0x00C4722C
		public void RemoveSequenceFinishEvent(string sequenceName, Action<string> finishEvent)
		{
			if (this.EndEventMap == null || finishEvent == null)
			{
				return;
			}
			HashSet<Action<string>> hashSet;
			if (!this.EndEventMap.TryGetValue(sequenceName, out hashSet))
			{
				return;
			}
			if (!hashSet.Contains(finishEvent))
			{
				return;
			}
			hashSet.Remove(finishEvent);
		}

		// Token: 0x060315CF RID: 202191 RVA: 0x00C49068 File Offset: 0x00C47268
		public void AddSequenceStartEvent(string name, Action<string> eventAction)
		{
			HashSet<Action<string>> hashSet;
			if (!this.StartEventMap.TryGetValue(name, out hashSet))
			{
				hashSet = new HashSet<Action<string>>();
				this.StartEventMap[name] = hashSet;
			}
			if (hashSet.Contains(eventAction))
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCore, ELogAuthor.YZY, "AddSequenceStartEvent重复添加。", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			hashSet.Add(eventAction);
		}

		// Token: 0x060315D0 RID: 202192 RVA: 0x00C490C6 File Offset: 0x00C472C6
		public void StopSequenceByKey(string sequenceName, bool needEvent = false, bool toLastFrame = false)
		{
			UiSequencePlayer uiSequencePlayer = this.UiSequencePlayer;
			if (uiSequencePlayer == null)
			{
				return;
			}
			uiSequencePlayer.StopSequenceByKey(sequenceName, needEvent, toLastFrame);
		}

		// Token: 0x060315D1 RID: 202193 RVA: 0x00C490DB File Offset: 0x00C472DB
		public void SequencePlayReverseByKey(string sequenceName, bool block)
		{
			UiSequencePlayer uiSequencePlayer = this.UiSequencePlayer;
			if (uiSequencePlayer == null)
			{
				return;
			}
			uiSequencePlayer.PlaySequencePurely(sequenceName, block, true);
		}

		// Token: 0x060315D2 RID: 202194 RVA: 0x00C490F0 File Offset: 0x00C472F0
		public void PlaySequence(string sequenceName, bool blockClick = false, float? playRate = null)
		{
			this.CurrentPlayingSequenceName = sequenceName.ToString();
			this.UiSequencePlayer.PlaySequence(sequenceName, blockClick, playRate);
		}

		// Token: 0x1700841F RID: 33823
		// (get) Token: 0x060315D3 RID: 202195 RVA: 0x00C4910C File Offset: 0x00C4730C
		public string CurrentSequenceName
		{
			get
			{
				return this.CurrentPlayingSequenceName;
			}
		}

		// Token: 0x060315D4 RID: 202196 RVA: 0x00C49114 File Offset: 0x00C47314
		public UniTask PlaySequenceAsync(string sequenceName, CustomPromise<bool> stopPromise, bool blockClick = false, bool playReverse = false, float? playRate = null)
		{
			UiBehaviorLevelSequence.<PlaySequenceAsync>d__37 <PlaySequenceAsync>d__;
			<PlaySequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySequenceAsync>d__.<>4__this = this;
			<PlaySequenceAsync>d__.sequenceName = sequenceName;
			<PlaySequenceAsync>d__.stopPromise = stopPromise;
			<PlaySequenceAsync>d__.blockClick = blockClick;
			<PlaySequenceAsync>d__.playReverse = playReverse;
			<PlaySequenceAsync>d__.playRate = playRate;
			<PlaySequenceAsync>d__.<>1__state = -1;
			<PlaySequenceAsync>d__.<>t__builder.Start<UiBehaviorLevelSequence.<PlaySequenceAsync>d__37>(ref <PlaySequenceAsync>d__);
			return <PlaySequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060315D5 RID: 202197 RVA: 0x00C49184 File Offset: 0x00C47384
		public UniTask PlaySequenceAsyncNoStopRunning(string sequenceName, CustomPromise<bool> stopPromise, bool blockClick = false, bool playReverse = false, float? playRate = null)
		{
			UiBehaviorLevelSequence.<PlaySequenceAsyncNoStopRunning>d__38 <PlaySequenceAsyncNoStopRunning>d__;
			<PlaySequenceAsyncNoStopRunning>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySequenceAsyncNoStopRunning>d__.<>4__this = this;
			<PlaySequenceAsyncNoStopRunning>d__.sequenceName = sequenceName;
			<PlaySequenceAsyncNoStopRunning>d__.stopPromise = stopPromise;
			<PlaySequenceAsyncNoStopRunning>d__.blockClick = blockClick;
			<PlaySequenceAsyncNoStopRunning>d__.playReverse = playReverse;
			<PlaySequenceAsyncNoStopRunning>d__.playRate = playRate;
			<PlaySequenceAsyncNoStopRunning>d__.<>1__state = -1;
			<PlaySequenceAsyncNoStopRunning>d__.<>t__builder.Start<UiBehaviorLevelSequence.<PlaySequenceAsyncNoStopRunning>d__38>(ref <PlaySequenceAsyncNoStopRunning>d__);
			return <PlaySequenceAsyncNoStopRunning>d__.<>t__builder.Task;
		}

		// Token: 0x060315D6 RID: 202198 RVA: 0x00C491F1 File Offset: 0x00C473F1
		public void PlaySequencePurely(string sequenceName, bool blockClick = false, bool isReverse = false)
		{
			this.CurrentPlayingSequenceName = sequenceName.ToString();
			UiSequencePlayer uiSequencePlayer = this.UiSequencePlayer;
			if (uiSequencePlayer == null)
			{
				return;
			}
			uiSequencePlayer.PlaySequencePurely(sequenceName.ToString(), blockClick, isReverse);
		}

		// Token: 0x060315D7 RID: 202199 RVA: 0x00C49217 File Offset: 0x00C47417
		public void PlayOrReplaySequenceByName(string sequenceName, bool blockClick = false, float? playRate = null)
		{
			UiSequencePlayer uiSequencePlayer = this.UiSequencePlayer;
			if (uiSequencePlayer == null)
			{
				return;
			}
			uiSequencePlayer.PlayOrReplaySequenceByName(sequenceName, blockClick, playRate);
		}

		// Token: 0x060315D8 RID: 202200 RVA: 0x00C4922C File Offset: 0x00C4742C
		public void PauseSequence()
		{
			this.UiSequencePlayer.PauseSequence();
		}

		// Token: 0x060315D9 RID: 202201 RVA: 0x00C49239 File Offset: 0x00C47439
		public void ResumeSequence()
		{
			this.UiSequencePlayer.ResumeSequence();
		}

		// Token: 0x060315DA RID: 202202 RVA: 0x00C49246 File Offset: 0x00C47446
		public void StopPrevSequence(bool needEvent, bool toLastFrame = false)
		{
			if (this.IsInSequence())
			{
				this.UiSequencePlayer.StopCurrentSequenceByName(this.CurrentPlayingSequenceName, needEvent, toLastFrame);
			}
		}

		// Token: 0x060315DB RID: 202203 RVA: 0x00C49263 File Offset: 0x00C47463
		public void ReplaySequence(string sequenceName)
		{
			if (this.IsInSequence())
			{
				this.UiSequencePlayer.ReplaySequence(sequenceName);
			}
		}

		// Token: 0x060315DC RID: 202204 RVA: 0x00C49279 File Offset: 0x00C47479
		public void ChangePlaybackDirection(string sequenceName)
		{
			if (!this.HasSequenceNameInPlaying(sequenceName))
			{
				return;
			}
			this.UiSequencePlayer.ChangePlaybackDirection(sequenceName);
		}

		// Token: 0x060315DD RID: 202205 RVA: 0x00C49291 File Offset: 0x00C47491
		public void SetActorTag(string sequenceName, FName tag, AActor actor)
		{
			this.UiSequencePlayer.SetActorTag(sequenceName, tag, actor);
		}

		// Token: 0x060315DE RID: 202206 RVA: 0x00C492A1 File Offset: 0x00C474A1
		public void SetRelativeTransform(string sequenceName, FTransformDouble transform)
		{
			this.UiSequencePlayer.SetRelativeTransform(sequenceName, transform);
		}

		// Token: 0x060315DF RID: 202207 RVA: 0x00C492B0 File Offset: 0x00C474B0
		public void OnBeforeDestroy()
		{
			if (this.UiSequencePlayer != null)
			{
				this.UiSequencePlayer.Clear();
				this.UiSequencePlayer = null;
			}
			this.EndEventMap.Clear();
			this.StartEventMap.Clear();
		}

		// Token: 0x060315E0 RID: 202208 RVA: 0x00C492E2 File Offset: 0x00C474E2
		public void OnAfterUiShow()
		{
		}

		// Token: 0x060315E1 RID: 202209 RVA: 0x00C492E4 File Offset: 0x00C474E4
		public void OnBeforeUiHide()
		{
		}

		// Token: 0x0401C5AC RID: 116140
		[Nullable(2)]
		private UiSequencePlayer UiSequencePlayer;

		// Token: 0x0401C5AD RID: 116141
		private string StartSequenceNameInternal = "Start";

		// Token: 0x0401C5AE RID: 116142
		private string CloseSequenceNameInternal = "Close";

		// Token: 0x0401C5AF RID: 116143
		private string ShowSequenceNameInternal = "ShowView";

		// Token: 0x0401C5B0 RID: 116144
		private string HideSequenceNameInternal = "HideView";

		// Token: 0x0401C5B1 RID: 116145
		private readonly Dictionary<string, HashSet<Action<string>>> EndEventMap = new Dictionary<string, HashSet<Action<string>>>();

		// Token: 0x0401C5B2 RID: 116146
		private readonly Dictionary<string, HashSet<Action<string>>> StartEventMap = new Dictionary<string, HashSet<Action<string>>>();

		// Token: 0x0401C5B3 RID: 116147
		private string CurrentPlayingSequenceName = "";

		// Token: 0x0401C5B4 RID: 116148
		private readonly UiPanelBase Owner;
	}
}
