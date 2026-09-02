using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049B0 RID: 18864
	[NullableContext(1)]
	[Nullable(0)]
	public class UiSequencePlayer
	{
		// Token: 0x060314C4 RID: 201924 RVA: 0x00C45780 File Offset: 0x00C43980
		public UiSequencePlayer(UUIItem item)
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(item);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.FinishSequenceEvent), false);
			this.LevelSequencePlayer.BindSequenceStartEvent(new TSequenceStartEvent(this.PlaySequenceStartEvent));
		}

		// Token: 0x060314C5 RID: 201925 RVA: 0x00C457D9 File Offset: 0x00C439D9
		[NullableContext(2)]
		private void ClearSequenceMapValue(string key)
		{
			if (key != null)
			{
				this.CurrentSequenceStateMap.Remove(key);
			}
		}

		// Token: 0x060314C6 RID: 201926 RVA: 0x00C457EB File Offset: 0x00C439EB
		private void AddItemToSequenceMap(string key)
		{
			this.CurrentSequenceStateMap[key] = ESequenceState.Start;
		}

		// Token: 0x060314C7 RID: 201927 RVA: 0x00C457FA File Offset: 0x00C439FA
		public void BindOnEndSequenceEvent(Action<string> sequencePlayCloseEvent)
		{
			if (this.OnSequenceEndEvent == null)
			{
				this.OnSequenceEndEvent = new List<Action<string>>();
			}
			this.OnSequenceEndEvent.Add(sequencePlayCloseEvent);
		}

		// Token: 0x060314C8 RID: 201928 RVA: 0x00C4581B File Offset: 0x00C43A1B
		public void BindOnStartSequenceEvent(Action<string> sequenceStartEvent)
		{
			if (this.OnSequenceStartEvent == null)
			{
				this.OnSequenceStartEvent = new List<Action<string>>();
			}
			this.OnSequenceStartEvent.Add(sequenceStartEvent);
		}

		// Token: 0x060314C9 RID: 201929 RVA: 0x00C4583C File Offset: 0x00C43A3C
		public bool IsInSequence()
		{
			bool result = false;
			string[] array = new string[this.CurrentSequenceStateMap.Count];
			this.CurrentSequenceStateMap.Keys.CopyTo(array, 0);
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				if (this.CurrentSequenceStateMap[array[i]] != ESequenceState.End)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x060314CA RID: 201930 RVA: 0x00C45894 File Offset: 0x00C43A94
		public bool IsSequenceInPlaying(string sequenceName)
		{
			return this.CurrentSequenceStateMap.ContainsKey(sequenceName) && this.CurrentSequenceStateMap[sequenceName] == ESequenceState.Playing;
		}

		// Token: 0x060314CB RID: 201931 RVA: 0x00C458B5 File Offset: 0x00C43AB5
		public bool IsSequenceFinish(string sequenceName)
		{
			return !this.CurrentSequenceStateMap.ContainsKey(sequenceName) || this.CurrentSequenceStateMap[sequenceName] == ESequenceState.End;
		}

		// Token: 0x060314CC RID: 201932 RVA: 0x00C458D8 File Offset: 0x00C43AD8
		public bool IsStartSequenceFinish(string sequenceName)
		{
			ESequenceState esequenceState;
			return !this.CurrentSequenceStateMap.TryGetValue(sequenceName, out esequenceState) || esequenceState > ESequenceState.Start;
		}

		// Token: 0x060314CD RID: 201933 RVA: 0x00C458FB File Offset: 0x00C43AFB
		[NullableContext(2)]
		public string GetCurrentSequence()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return null;
			}
			return levelSequencePlayer.GetCurrentSequence();
		}

		// Token: 0x060314CE RID: 201934 RVA: 0x00C45910 File Offset: 0x00C43B10
		private void FinishSequenceEvent(string sequenceName)
		{
			this.CurrentSequenceStateMap[sequenceName] = ESequenceState.End;
			if (this.OnSequenceEndEvent != null)
			{
				foreach (Action<string> action in this.OnSequenceEndEvent)
				{
					action(sequenceName);
				}
			}
		}

		// Token: 0x060314CF RID: 201935 RVA: 0x00C45978 File Offset: 0x00C43B78
		private void PlaySequenceStartEvent(string sequenceName)
		{
			this.CurrentSequenceStateMap[sequenceName] = ESequenceState.Playing;
			if (this.OnSequenceStartEvent != null)
			{
				foreach (Action<string> action in this.OnSequenceStartEvent)
				{
					action(sequenceName);
				}
			}
		}

		// Token: 0x060314D0 RID: 201936 RVA: 0x00C459E0 File Offset: 0x00C43BE0
		public void PlaySequencePurely(string sequenceName, bool blockClick = false, bool isReverse = false)
		{
			this.LevelSequencePlayer.PlaySequencePurely(sequenceName, blockClick, isReverse, null, null, false);
		}

		// Token: 0x060314D1 RID: 201937 RVA: 0x00C45A08 File Offset: 0x00C43C08
		public void StopPrevSequence(bool needEvent, bool toLastFrame = false)
		{
			string currentSequence = this.LevelSequencePlayer.GetCurrentSequence();
			this.LevelSequencePlayer.StopCurrentSequence(needEvent, toLastFrame);
			this.ClearSequenceMapValue(currentSequence);
		}

		// Token: 0x060314D2 RID: 201938 RVA: 0x00C45A38 File Offset: 0x00C43C38
		public void StopCurrentSequenceByName(string sequenceName, bool needEvent, bool toLastFrame = false)
		{
			string currentSequence = this.LevelSequencePlayer.GetCurrentSequence();
			if (currentSequence == sequenceName)
			{
				this.LevelSequencePlayer.StopCurrentSequence(needEvent, toLastFrame);
				this.ClearSequenceMapValue(currentSequence);
			}
		}

		// Token: 0x060314D3 RID: 201939 RVA: 0x00C45A6E File Offset: 0x00C43C6E
		public void PlaySequence(string sequenceName, bool blockClick = false, float? playRate = null)
		{
			this.RemoveCurrentRunningSequence();
			this.AddItemToSequenceMap(sequenceName.ToString());
			this.LevelSequencePlayer.PlayLevelSequenceByName(sequenceName.ToString(), blockClick, playRate, false);
		}

		// Token: 0x060314D4 RID: 201940 RVA: 0x00C45A98 File Offset: 0x00C43C98
		public UniTask PlaySequenceAsync(string sequenceName, CustomPromise<bool> stopPromise, bool blockClick = false, bool playReverse = false, float? playRate = null)
		{
			UiSequencePlayer.<PlaySequenceAsync>d__20 <PlaySequenceAsync>d__;
			<PlaySequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySequenceAsync>d__.<>4__this = this;
			<PlaySequenceAsync>d__.sequenceName = sequenceName;
			<PlaySequenceAsync>d__.stopPromise = stopPromise;
			<PlaySequenceAsync>d__.blockClick = blockClick;
			<PlaySequenceAsync>d__.playReverse = playReverse;
			<PlaySequenceAsync>d__.playRate = playRate;
			<PlaySequenceAsync>d__.<>1__state = -1;
			<PlaySequenceAsync>d__.<>t__builder.Start<UiSequencePlayer.<PlaySequenceAsync>d__20>(ref <PlaySequenceAsync>d__);
			return <PlaySequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060314D5 RID: 201941 RVA: 0x00C45B08 File Offset: 0x00C43D08
		public UniTask PlaySequenceAsyncNoStopRunning(string sequenceName, CustomPromise<bool> stopPromise, bool blockClick = false, bool playReverse = false, float? playRate = null)
		{
			UiSequencePlayer.<PlaySequenceAsyncNoStopRunning>d__21 <PlaySequenceAsyncNoStopRunning>d__;
			<PlaySequenceAsyncNoStopRunning>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySequenceAsyncNoStopRunning>d__.<>4__this = this;
			<PlaySequenceAsyncNoStopRunning>d__.sequenceName = sequenceName;
			<PlaySequenceAsyncNoStopRunning>d__.stopPromise = stopPromise;
			<PlaySequenceAsyncNoStopRunning>d__.blockClick = blockClick;
			<PlaySequenceAsyncNoStopRunning>d__.playReverse = playReverse;
			<PlaySequenceAsyncNoStopRunning>d__.playRate = playRate;
			<PlaySequenceAsyncNoStopRunning>d__.<>1__state = -1;
			<PlaySequenceAsyncNoStopRunning>d__.<>t__builder.Start<UiSequencePlayer.<PlaySequenceAsyncNoStopRunning>d__21>(ref <PlaySequenceAsyncNoStopRunning>d__);
			return <PlaySequenceAsyncNoStopRunning>d__.<>t__builder.Task;
		}

		// Token: 0x060314D6 RID: 201942 RVA: 0x00C45B75 File Offset: 0x00C43D75
		public void ReplaySequence(string sequenceName)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.ReplaySequenceByKey(sequenceName);
		}

		// Token: 0x060314D7 RID: 201943 RVA: 0x00C45B88 File Offset: 0x00C43D88
		public void PlayOrReplaySequenceByName(string sequenceName, bool blockClick = false, float? playRate = null)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayOrReplaySequenceByName(sequenceName, blockClick, playRate);
		}

		// Token: 0x060314D8 RID: 201944 RVA: 0x00C45BA0 File Offset: 0x00C43DA0
		private void RemoveCurrentRunningSequence()
		{
			if (this.IsInSequence())
			{
				string[] array = new string[this.CurrentSequenceStateMap.Count];
				this.CurrentSequenceStateMap.Keys.CopyTo(array, 0);
				string key = array[0];
				this.ClearSequenceMapValue(key);
			}
		}

		// Token: 0x060314D9 RID: 201945 RVA: 0x00C45BE3 File Offset: 0x00C43DE3
		public void StopSequenceByKey(string sequenceName, bool needEvent = false, bool toLastFrame = false)
		{
			this.LevelSequencePlayer.StopSequenceByKey(sequenceName, needEvent, toLastFrame);
		}

		// Token: 0x060314DA RID: 201946 RVA: 0x00C45BF4 File Offset: 0x00C43DF4
		public void SequencePlayReverseByKey(string sequenceName, bool block)
		{
			this.LevelSequencePlayer.PlaySequencePurely(sequenceName, block, true, null, null, false);
		}

		// Token: 0x060314DB RID: 201947 RVA: 0x00C45C1A File Offset: 0x00C43E1A
		public void PauseSequence()
		{
			this.LevelSequencePlayer.PauseSequence();
		}

		// Token: 0x060314DC RID: 201948 RVA: 0x00C45C27 File Offset: 0x00C43E27
		public void ResumeSequence()
		{
			this.LevelSequencePlayer.ResumeSequence();
		}

		// Token: 0x060314DD RID: 201949 RVA: 0x00C45C34 File Offset: 0x00C43E34
		public void ChangePlaybackDirection(string sequenceName)
		{
			this.LevelSequencePlayer.ChangePlaybackDirection(sequenceName);
		}

		// Token: 0x060314DE RID: 201950 RVA: 0x00C45C42 File Offset: 0x00C43E42
		public void SetActorTag(string sequenceName, FName tag, AActor actor)
		{
			this.LevelSequencePlayer.SetActorTag(sequenceName, tag, actor);
		}

		// Token: 0x060314DF RID: 201951 RVA: 0x00C45C52 File Offset: 0x00C43E52
		public void SetRelativeTransform(string sequenceName, FTransformDouble transform)
		{
			this.LevelSequencePlayer.SetRelativeTransform(sequenceName, transform);
		}

		// Token: 0x060314E0 RID: 201952 RVA: 0x00C45C61 File Offset: 0x00C43E61
		public void Clear()
		{
			this.LevelSequencePlayer.Clear();
			this.LevelSequencePlayer = null;
		}

		// Token: 0x060314E1 RID: 201953 RVA: 0x00C45C78 File Offset: 0x00C43E78
		[NullableContext(0)]
		public UniTask<bool> LitePlayAsync([Nullable(1)] string sequenceName, bool blockClick = false, bool playReverse = false)
		{
			UiSequencePlayer.<LitePlayAsync>d__35 <LitePlayAsync>d__;
			<LitePlayAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LitePlayAsync>d__.<>4__this = this;
			<LitePlayAsync>d__.sequenceName = sequenceName;
			<LitePlayAsync>d__.blockClick = blockClick;
			<LitePlayAsync>d__.playReverse = playReverse;
			<LitePlayAsync>d__.<>1__state = -1;
			<LitePlayAsync>d__.<>t__builder.Start<UiSequencePlayer.<LitePlayAsync>d__35>(ref <LitePlayAsync>d__);
			return <LitePlayAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060314E2 RID: 201954 RVA: 0x00C45CD4 File Offset: 0x00C43ED4
		[NullableContext(0)]
		public UniTask<bool> LiteReplayAsync([Nullable(1)] string sequenceName, bool blockClick = false, bool playReverse = false)
		{
			UiSequencePlayer.<LiteReplayAsync>d__36 <LiteReplayAsync>d__;
			<LiteReplayAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LiteReplayAsync>d__.<>4__this = this;
			<LiteReplayAsync>d__.sequenceName = sequenceName;
			<LiteReplayAsync>d__.blockClick = blockClick;
			<LiteReplayAsync>d__.playReverse = playReverse;
			<LiteReplayAsync>d__.<>1__state = -1;
			<LiteReplayAsync>d__.<>t__builder.Start<UiSequencePlayer.<LiteReplayAsync>d__36>(ref <LiteReplayAsync>d__);
			return <LiteReplayAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060314E3 RID: 201955 RVA: 0x00C45D2F File Offset: 0x00C43F2F
		public void LiteStop()
		{
			if (this.LevelSequencePlayer != null && this.LitePlayingSequenceName != null && this.LitePlayingPromise != null)
			{
				this.LevelSequencePlayer.StopSequenceByKey(this.LitePlayingSequenceName.ToString(), false, false);
			}
			this.LitePlayingSequenceName = null;
			this.LitePlayingPromise = null;
		}

		// Token: 0x060314E4 RID: 201956 RVA: 0x00C45D6F File Offset: 0x00C43F6F
		public void LiteExit()
		{
			this.LiteStop();
			this.Clear();
		}

		// Token: 0x060314E5 RID: 201957 RVA: 0x00C45D7D File Offset: 0x00C43F7D
		public void LiteJumpToEnd(string sequenceName)
		{
			if (this.LevelSequencePlayer != null)
			{
				this.LitePlayAsync(sequenceName, true, false);
				this.LevelSequencePlayer.EndSequenceLastFrame(sequenceName.ToString());
				this.LiteStop();
			}
		}

		// Token: 0x060314E6 RID: 201958 RVA: 0x00C45DA8 File Offset: 0x00C43FA8
		[NullableContext(0)]
		public UniTask<bool> LiteWaitFor([Nullable(1)] string sequenceName)
		{
			UiSequencePlayer.<LiteWaitFor>d__40 <LiteWaitFor>d__;
			<LiteWaitFor>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LiteWaitFor>d__.<>4__this = this;
			<LiteWaitFor>d__.sequenceName = sequenceName;
			<LiteWaitFor>d__.<>1__state = -1;
			<LiteWaitFor>d__.<>t__builder.Start<UiSequencePlayer.<LiteWaitFor>d__40>(ref <LiteWaitFor>d__);
			return <LiteWaitFor>d__.<>t__builder.Task;
		}

		// Token: 0x0401C561 RID: 116065
		private readonly Dictionary<string, ESequenceState> CurrentSequenceStateMap = new Dictionary<string, ESequenceState>();

		// Token: 0x0401C562 RID: 116066
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401C563 RID: 116067
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private List<Action<string>> OnSequenceEndEvent;

		// Token: 0x0401C564 RID: 116068
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private List<Action<string>> OnSequenceStartEvent;

		// Token: 0x0401C565 RID: 116069
		[Nullable(2)]
		private string LitePlayingSequenceName;

		// Token: 0x0401C566 RID: 116070
		[Nullable(2)]
		private CustomPromise<bool> LitePlayingPromise;
	}
}
