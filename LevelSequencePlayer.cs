using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020019AA RID: 6570
[NullableContext(1)]
[Nullable(0)]
public class LevelSequencePlayer : IStaticVariableResetter
{
	// Token: 0x0600BCB5 RID: 48309 RVA: 0x00321CF9 File Offset: 0x0031FEF9
	static LevelSequencePlayer()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(LevelSequencePlayer.CreateStaticDefaultValue), new Action(LevelSequencePlayer.ResetStaticDefaultValue));
	}

	// Token: 0x17000F64 RID: 3940
	// (get) Token: 0x0600BCB6 RID: 48310 RVA: 0x00321D18 File Offset: 0x0031FF18
	private static HashSet<LevelSequencePlayer> PlayingInstances
	{
		get
		{
			return LevelSequencePlayer._playingInstances;
		}
	}

	// Token: 0x0600BCB7 RID: 48311 RVA: 0x00321D20 File Offset: 0x0031FF20
	[NullableContext(2)]
	public LevelSequencePlayer(UUIItem uiItem = null)
	{
		this.UiItem = uiItem;
		this.UiBaseActor = (((uiItem != null) ? uiItem.GetOwner() : null) as AUIBaseActor);
		this.UiBaseActor.OnPreDestroyed.Add(new Action<AActor>(this.AutoDestroy));
	}

	// Token: 0x0600BCB8 RID: 48312 RVA: 0x00321D83 File Offset: 0x0031FF83
	[NullableContext(2)]
	private void AutoDestroy(AActor _)
	{
		this.Clear();
	}

	// Token: 0x0600BCB9 RID: 48313 RVA: 0x00321D8C File Offset: 0x0031FF8C
	public void BindSequenceCloseEvent(TSequenceEndEvent sequencePlayCloseEvent, bool clear = false)
	{
		if (clear && this.OnSequenceEndEvent != null)
		{
			this.OnSequenceEndEvent = Array.Empty<TSequenceEndEvent>();
		}
		if (this.OnSequenceEndEvent == null)
		{
			this.OnSequenceEndEvent = Array.Empty<TSequenceEndEvent>();
		}
		TSequenceEndEvent[] array = new TSequenceEndEvent[this.OnSequenceEndEvent.Length + 1];
		this.OnSequenceEndEvent.CopyTo(array, 0);
		array[this.OnSequenceEndEvent.Length] = sequencePlayCloseEvent;
		this.OnSequenceEndEvent = array;
	}

	// Token: 0x0600BCBA RID: 48314 RVA: 0x00321DF4 File Offset: 0x0031FFF4
	public void BindSequenceStartEvent(TSequenceStartEvent sequenceStartEvent)
	{
		if (this.OnSequenceStartEvent == null)
		{
			this.OnSequenceStartEvent = new TSequenceStartEvent[0];
		}
		TSequenceStartEvent[] array = new TSequenceStartEvent[this.OnSequenceStartEvent.Length + 1];
		this.OnSequenceStartEvent.CopyTo(array, 0);
		array[this.OnSequenceStartEvent.Length] = sequenceStartEvent;
		this.OnSequenceStartEvent = array;
	}

	// Token: 0x0600BCBB RID: 48315 RVA: 0x00321E44 File Offset: 0x00320044
	public void StopCurrentSequence(bool needEvent = false, bool toLastFrame = false)
	{
		if (this.CurrentSequenceName == null)
		{
			return;
		}
		this.StopSequenceByKey(this.CurrentSequenceName, needEvent, toLastFrame);
		this.CurrentSequenceName = null;
	}

	// Token: 0x0600BCBC RID: 48316 RVA: 0x00321E64 File Offset: 0x00320064
	public void StopSequenceByKey(string sequenceName, bool needEvent = false, bool toLastFrame = false)
	{
		if (!this.IsValid())
		{
			return;
		}
		if (toLastFrame)
		{
			this.EndSequenceLastFrame(sequenceName);
		}
		SequenceData sequenceData;
		if (this.PlayingSequenceNameMap.TryGetValue(sequenceName, out sequenceData))
		{
			sequenceData.NeedFinishEvent = needEvent;
		}
		USequencePlayContext usequencePlayContext;
		if (this.PlayContextMap.TryGetValue(sequenceName, out usequencePlayContext) && usequencePlayContext.IsValid())
		{
			usequencePlayContext.TryStop();
			return;
		}
		this.OnSequenceStop(sequenceName);
	}

	// Token: 0x0600BCBD RID: 48317 RVA: 0x00321EC4 File Offset: 0x003200C4
	public void ReplaySequenceByKey(string sequenceName)
	{
		if (!this.IsValid())
		{
			return;
		}
		SequenceData sequenceData;
		if (!this.PlayingSequenceNameMap.TryGetValue(sequenceName, out sequenceData))
		{
			return;
		}
		USequencePlayContext usequencePlayContext;
		if (!this.PlayContextMap.TryGetValue(sequenceName, out usequencePlayContext))
		{
			return;
		}
		ALevelSequenceActor sequencePlayerByKey = this.UiBaseActor.GetSequencePlayerByKey(sequenceName);
		if (sequencePlayerByKey != null && sequencePlayerByKey.IsValid())
		{
			ULevelSequencePlayer sequencePlayer = sequencePlayerByKey.SequencePlayer;
			if (sequencePlayer != null && sequencePlayer.IsValid())
			{
				if (sequencePlayer.IsStopped())
				{
					this.PlayLevelSequenceByName(sequenceName, sequenceData.IsBlock, null, false);
					return;
				}
				AUIBaseActor uiBaseActor = this.UiBaseActor;
				FFrameTime fframeTime = new FFrameTime();
				uiBaseActor.SequenceJumpToSecondByKey(sequenceName, fframeTime);
			}
		}
	}

	// Token: 0x0600BCBE RID: 48318 RVA: 0x00321F5C File Offset: 0x0032015C
	public void SequenceJumpToStartWhenPlaying(string sequenceName)
	{
		if (!this.IsValid())
		{
			return;
		}
		ALevelSequenceActor sequencePlayerByKey = this.UiBaseActor.GetSequencePlayerByKey(sequenceName);
		if (sequencePlayerByKey != null && sequencePlayerByKey.IsValid())
		{
			ULevelSequencePlayer sequencePlayer = sequencePlayerByKey.SequencePlayer;
			if (sequencePlayer != null && sequencePlayer.IsValid() && !sequencePlayer.IsStopped())
			{
				AUIBaseActor uiBaseActor = this.UiBaseActor;
				FFrameTime fframeTime = new FFrameTime();
				uiBaseActor.SequenceJumpToSecondByKey(sequenceName, fframeTime);
			}
		}
	}

	// Token: 0x0600BCBF RID: 48319 RVA: 0x00321FB8 File Offset: 0x003201B8
	public void ChangePlaybackDirection(string sequenceName)
	{
		SequenceData sequenceData;
		if (!this.PlayingSequenceNameMap.TryGetValue(sequenceName, out sequenceData))
		{
			return;
		}
		USequencePlayContext usequencePlayContext;
		if (!this.PlayContextMap.TryGetValue(sequenceName, out usequencePlayContext))
		{
			return;
		}
		ALevelSequenceActor sequencePlayerByKey = this.UiBaseActor.GetSequencePlayerByKey(sequenceName);
		if (sequencePlayerByKey == null || !sequencePlayerByKey.IsValid())
		{
			return;
		}
		ULevelSequencePlayer sequencePlayer = sequencePlayerByKey.GetSequencePlayer();
		if (sequencePlayer == null || !sequencePlayer.IsValid())
		{
			return;
		}
		sequencePlayer.ChangePlaybackDirection();
	}

	// Token: 0x0600BCC0 RID: 48320 RVA: 0x00322019 File Offset: 0x00320219
	[NullableContext(2)]
	public string GetCurrentSequence()
	{
		return this.CurrentSequenceName;
	}

	// Token: 0x0600BCC1 RID: 48321 RVA: 0x00322024 File Offset: 0x00320224
	public unsafe void PauseSequence()
	{
		if (!this.IsValid())
		{
			return;
		}
		if (this.CurrentSequenceName == null)
		{
			return;
		}
		ALevelSequenceActor levelSequenceActor = this.GetLevelSequenceActor(this.CurrentSequenceName);
		if (levelSequenceActor != null)
		{
			levelSequenceActor.SequencePlayer.Pause();
			return;
		}
		USequencePlayContext usequencePlayContext;
		if (!this.PlayContextMap.TryGetValue(this.CurrentSequenceName, out usequencePlayContext))
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.LevelSequencePlayer;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "异步加载暂停关卡序列";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("停止节点", this.UiItem.GetDisplayName());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("关卡序列", this.CurrentSequenceName);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		usequencePlayContext.TryStop();
	}

	// Token: 0x0600BCC2 RID: 48322 RVA: 0x003220E0 File Offset: 0x003202E0
	public unsafe void ResumeSequence()
	{
		if (!this.IsValid())
		{
			return;
		}
		if (this.CurrentSequenceName == null)
		{
			return;
		}
		ALevelSequenceActor levelSequenceActor = this.GetLevelSequenceActor(this.CurrentSequenceName);
		if (levelSequenceActor == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelSequencePlayer;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "异步恢复关卡序列动画";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "停止节点";
			UUIItem uiItem = this.UiItem;
			ptr = new ValueTuple<string, object>(item, (uiItem != null) ? uiItem.GetDisplayName() : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("关卡序列", this.CurrentSequenceName);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			USequencePlayContext usequencePlayContext;
			if (this.PlayContextMap.TryGetValue(this.CurrentSequenceName, out usequencePlayContext))
			{
				usequencePlayContext.ExecutePlay();
			}
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.LevelSequencePlayer;
		ELogAuthor author2 = ELogAuthor.XXJ;
		string message2 = "恢复关卡序列动画";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
		string item2 = "停止节点";
		UUIItem uiItem2 = this.UiItem;
		ptr2 = new ValueTuple<string, object>(item2, (uiItem2 != null) ? uiItem2.GetDisplayName() : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("关卡序列", this.CurrentSequenceName);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		ULevelSequencePlayer sequencePlayer = levelSequenceActor.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.Play();
	}

	// Token: 0x0600BCC3 RID: 48323 RVA: 0x00322210 File Offset: 0x00320410
	public void Clear()
	{
		UUIItem uiItem = this.UiItem;
		foreach (USequencePlayContext usequencePlayContext in this.PlayContextMap.Values)
		{
			usequencePlayContext.OnStop.Unbind();
		}
		foreach (string sequenceName in new List<string>(this.PlayingSequenceNameMap.Keys))
		{
			this.OnSequenceStop(sequenceName);
		}
		this.PlayContextMap.Clear();
		this.PlayingSequenceNameMap.Clear();
		LevelSequencePlayer.PlayingInstances.Remove(this);
		AUIBaseActor uiBaseActor = this.UiBaseActor;
		if (uiBaseActor != null)
		{
			uiBaseActor.ClearAllSequence();
		}
		AUIBaseActor uiBaseActor2 = this.UiBaseActor;
		if (uiBaseActor2 != null)
		{
			uiBaseActor2.OnPreDestroyed.Remove(new Action<AActor>(this.AutoDestroy));
		}
		this.UiBaseActor = null;
		this.UiItem = null;
	}

	// Token: 0x0600BCC4 RID: 48324 RVA: 0x00322320 File Offset: 0x00320520
	public void StopPlayingSequence(bool needEvent = false, bool toLastFrame = true)
	{
		foreach (string sequenceName in new List<string>(this.PlayingSequenceNameMap.Keys))
		{
			this.StopSequenceByKey(sequenceName, needEvent, toLastFrame);
		}
	}

	// Token: 0x0600BCC5 RID: 48325 RVA: 0x00322380 File Offset: 0x00320580
	public bool IsPlayingSequence(string sequenceName)
	{
		return this.PlayingSequenceNameMap.ContainsKey(sequenceName);
	}

	// Token: 0x0600BCC6 RID: 48326 RVA: 0x00322390 File Offset: 0x00320590
	public void EndSequenceLastFrame(string sequenceName)
	{
		if (!this.IsValid())
		{
			return;
		}
		AUIBaseActor uiBaseActor = this.UiBaseActor;
		UUIItem uuiitem = (uiBaseActor != null) ? uiBaseActor.GetUIItem() : null;
		if (uuiitem != null && uuiitem.LevelSequences.Contains(sequenceName))
		{
			ALevelSequenceActor levelSequenceActor = this.GetLevelSequenceActor(sequenceName);
			if (levelSequenceActor != null)
			{
				AUIBaseActor uiBaseActor2 = this.UiBaseActor;
				FFrameTime time = levelSequenceActor.SequencePlayer.GetDuration().Time;
				uiBaseActor2.SequenceJumpToSecondByKey(sequenceName, time);
			}
		}
	}

	// Token: 0x0600BCC7 RID: 48327 RVA: 0x003223F4 File Offset: 0x003205F4
	public bool CheckSeqActorIsSeqPlaying(string sequenceName)
	{
		ALevelSequenceActor levelSequenceActor = this.GetLevelSequenceActor(sequenceName);
		if (levelSequenceActor != null && levelSequenceActor.IsValid())
		{
			ULevelSequencePlayer sequencePlayer = levelSequenceActor.SequencePlayer;
			if (sequencePlayer != null && sequencePlayer.IsValid() && sequencePlayer.IsPlaying())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600BCC8 RID: 48328 RVA: 0x00322434 File Offset: 0x00320634
	public bool CheckSeqActorIsUnStopped(string sequenceName)
	{
		ALevelSequenceActor levelSequenceActor = this.GetLevelSequenceActor(sequenceName);
		if (levelSequenceActor != null && levelSequenceActor.IsValid())
		{
			ULevelSequencePlayer sequencePlayer = levelSequenceActor.SequencePlayer;
			if (sequencePlayer != null && sequencePlayer.IsValid() && !sequencePlayer.IsStopped())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600BCC9 RID: 48329 RVA: 0x00322471 File Offset: 0x00320671
	public void PlayOrReplaySequenceByName(string sequenceName, bool blockClick = false, float? playRate = null)
	{
		if (this.CheckSeqActorIsSeqPlaying(sequenceName))
		{
			this.ReplaySequenceByKey(sequenceName);
			return;
		}
		this.PlaySequencePurely(sequenceName, blockClick, false, null, playRate, false);
	}

	// Token: 0x0600BCCA RID: 48330 RVA: 0x00322490 File Offset: 0x00320690
	public void PlayLevelSequenceByName(string sequenceName, bool blockClick = false, float? playRate = null, bool bJumpToLastFrame = false)
	{
		this.PlaySequencePurely(sequenceName, blockClick, false, null, playRate, bJumpToLastFrame);
	}

	// Token: 0x0600BCCB RID: 48331 RVA: 0x003224A0 File Offset: 0x003206A0
	public UniTask PlaySequenceAsync(string sequenceName, [Nullable(2)] CustomPromise<bool> stopPromise, bool blockClick = false, bool playReverse = false, float? playRate = null, bool bJumpToLastFrame = false)
	{
		LevelSequencePlayer.<PlaySequenceAsync>d__32 <PlaySequenceAsync>d__;
		<PlaySequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaySequenceAsync>d__.<>4__this = this;
		<PlaySequenceAsync>d__.sequenceName = sequenceName;
		<PlaySequenceAsync>d__.stopPromise = stopPromise;
		<PlaySequenceAsync>d__.blockClick = blockClick;
		<PlaySequenceAsync>d__.playReverse = playReverse;
		<PlaySequenceAsync>d__.playRate = playRate;
		<PlaySequenceAsync>d__.bJumpToLastFrame = bJumpToLastFrame;
		<PlaySequenceAsync>d__.<>1__state = -1;
		<PlaySequenceAsync>d__.<>t__builder.Start<LevelSequencePlayer.<PlaySequenceAsync>d__32>(ref <PlaySequenceAsync>d__);
		return <PlaySequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600BCCC RID: 48332 RVA: 0x00322518 File Offset: 0x00320718
	public void PlaySequencePurely(string sequenceName, bool blockClick = false, bool playReverse = false, [Nullable(2)] CustomPromise<bool> stopPromise = null, float? playRate = null, bool bJumpToLastFrame = false)
	{
		if (!this.IsValid())
		{
			if (stopPromise != null)
			{
				stopPromise.SetResult(false);
			}
			return;
		}
		USequencePlayContext sequencePlayContext = this.GetSequencePlayContext(sequenceName);
		string displayName = this.UiItem.GetDisplayName();
		this.CurrentSequenceName = sequenceName;
		SequenceData value = new SequenceData(sequenceName, blockClick, displayName, stopPromise);
		this.PlayingSequenceNameMap[sequenceName] = value;
		LevelSequencePlayer.PlayingInstances.Add(this);
		if (LevelSequencePlayer.Banned)
		{
			this.OnSequenceStart(sequenceName);
			this.OnSequenceStop(sequenceName);
			return;
		}
		if (sequencePlayContext != null)
		{
			sequencePlayContext.bReverse = playReverse;
			if (playRate != null)
			{
				sequencePlayContext.PlayInfo.PlaySetting.PlayRate = playRate.Value;
			}
			sequencePlayContext.bJumpToLastFrame = bJumpToLastFrame;
			sequencePlayContext.ExecutePlay();
			this.OnSequenceStart(sequenceName);
			return;
		}
		this.OnSequenceStop(sequenceName);
	}

	// Token: 0x0600BCCD RID: 48333 RVA: 0x003225D8 File Offset: 0x003207D8
	[return: Nullable(2)]
	public USequencePlayContext GetSequencePlayContext(string sequenceName)
	{
		if (!this.IsValid())
		{
			return null;
		}
		USequencePlayContext sequencePlayContextOfKey;
		if (!this.PlayContextMap.TryGetValue(sequenceName, out sequencePlayContextOfKey))
		{
			sequencePlayContextOfKey = this.UiBaseActor.GetSequencePlayContextOfKey(sequenceName);
			if (sequencePlayContextOfKey == null)
			{
				return null;
			}
			sequencePlayContextOfKey.bIsAsync = false;
			sequencePlayContextOfKey.OnStop.Bind(delegate()
			{
				this.OnSequenceStop(sequenceName);
			});
			this.PlayContextMap[sequenceName] = sequencePlayContextOfKey;
		}
		return sequencePlayContextOfKey;
	}

	// Token: 0x0600BCCE RID: 48334 RVA: 0x00322660 File Offset: 0x00320860
	[return: Nullable(2)]
	public CustomPromise<bool> GetCurrentStopPromise(string sequenceName)
	{
		SequenceData sequenceData;
		if (this.PlayingSequenceNameMap.TryGetValue(sequenceName, out sequenceData))
		{
			return sequenceData.StopPromise;
		}
		return null;
	}

	// Token: 0x0600BCCF RID: 48335 RVA: 0x00322688 File Offset: 0x00320888
	private void OnSequenceStart(string sequenceName)
	{
		SequenceData sequenceData;
		this.PlayingSequenceNameMap.TryGetValue(sequenceName, out sequenceData);
		if (sequenceData != null && sequenceData.IsBlock)
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer(sequenceData.Tag, true);
		}
		if (this.OnSequenceStartEvent != null)
		{
			TSequenceStartEvent[] onSequenceStartEvent = this.OnSequenceStartEvent;
			for (int i = 0; i < onSequenceStartEvent.Length; i++)
			{
				onSequenceStartEvent[i](sequenceName);
			}
		}
	}

	// Token: 0x0600BCD0 RID: 48336 RVA: 0x003226E8 File Offset: 0x003208E8
	private void OnSequenceStop(string sequenceName)
	{
		SequenceData sequenceData;
		this.PlayingSequenceNameMap.TryGetValue(sequenceName, out sequenceData);
		bool flag = true;
		if (sequenceData != null)
		{
			if (sequenceData.IsBlock)
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer(sequenceData.Tag, false);
			}
			flag = sequenceData.NeedFinishEvent;
			sequenceData.NeedFinishEvent = true;
			this.PlayingSequenceNameMap.Remove(sequenceName);
		}
		if (this.CurrentSequenceName == sequenceName)
		{
			this.CurrentSequenceName = null;
		}
		if (flag && this.OnSequenceEndEvent != null)
		{
			TSequenceEndEvent[] onSequenceEndEvent = this.OnSequenceEndEvent;
			for (int i = 0; i < onSequenceEndEvent.Length; i++)
			{
				onSequenceEndEvent[i](sequenceName);
			}
		}
		if (this.PlayingSequenceNameMap.Count == 0)
		{
			LevelSequencePlayer.PlayingInstances.Remove(this);
		}
		if (((sequenceData != null) ? sequenceData.StopPromise : null) != null)
		{
			sequenceData.StopPromise.SetResult(true);
			sequenceData.StopPromise = null;
		}
	}

	// Token: 0x0600BCD1 RID: 48337 RVA: 0x003227B5 File Offset: 0x003209B5
	[return: Nullable(2)]
	private ALevelSequenceActor GetLevelSequenceActor(string sequenceName)
	{
		if (this.UiBaseActor != null)
		{
			return this.UiBaseActor.GetSequencePlayerByKey(sequenceName);
		}
		return null;
	}

	// Token: 0x0600BCD2 RID: 48338 RVA: 0x003227D0 File Offset: 0x003209D0
	public void SetActorTag(string sequenceName, FName tag, AActor actor)
	{
		ALevelSequenceActor levelSequenceActor = this.GetLevelSequenceActor(sequenceName);
		if (levelSequenceActor != null)
		{
			levelSequenceActor.AddBindingByTag(tag, actor, false, false);
		}
	}

	// Token: 0x0600BCD3 RID: 48339 RVA: 0x003227F4 File Offset: 0x003209F4
	public void SetRelativeTransform(string sequenceName, FTransformDouble transform)
	{
		ALevelSequenceActor levelSequenceActor = this.GetLevelSequenceActor(sequenceName);
		if (levelSequenceActor != null)
		{
			levelSequenceActor.bOverrideInstanceData = true;
			UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData = levelSequenceActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
			FTransform transformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(transform);
			udefaultLevelSequenceInstanceData.TransformOrigin = transformOrigin;
		}
	}

	// Token: 0x0600BCD4 RID: 48340 RVA: 0x0032282B File Offset: 0x00320A2B
	public bool IsValid()
	{
		AUIBaseActor uiBaseActor = this.UiBaseActor;
		return uiBaseActor != null && uiBaseActor.IsValid();
	}

	// Token: 0x0600BCD5 RID: 48341 RVA: 0x00322840 File Offset: 0x00320A40
	public static void SetBanned(bool value)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.LevelSequencePlayer;
		ELogAuthor author = ELogAuthor.TL;
		string message = "[LevelSequencePlayer.SetBanned] 设置禁用动画";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("value", value.ToString());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (value)
		{
			LevelSequencePlayer.Banned = true;
			using (HashSet<LevelSequencePlayer>.Enumerator enumerator = LevelSequencePlayer.PlayingInstances.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					LevelSequencePlayer levelSequencePlayer = enumerator.Current;
					if (!levelSequencePlayer.IsValid())
					{
						LevelSequencePlayer.PlayingInstances.Remove(levelSequencePlayer);
					}
					else
					{
						levelSequencePlayer.StopCurrentSequence(true, false);
					}
				}
				goto IL_88;
			}
		}
		LevelSequencePlayer.Banned = false;
		IL_88:
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.LevelSequencePlayerBandStateChange, value);
	}

	// Token: 0x0600BCD6 RID: 48342 RVA: 0x003228F4 File Offset: 0x00320AF4
	public static void CreateStaticDefaultValue()
	{
		LevelSequencePlayer._playingInstances = new HashSet<LevelSequencePlayer>();
	}

	// Token: 0x0600BCD7 RID: 48343 RVA: 0x00322900 File Offset: 0x00320B00
	public static void ResetStaticDefaultValue()
	{
		LevelSequencePlayer.Banned = false;
		LevelSequencePlayer.PlayingInstances.Clear();
		LevelSequencePlayer._playingInstances = null;
	}

	// Token: 0x0600BCD8 RID: 48344 RVA: 0x00322918 File Offset: 0x00320B18
	public static bool GetBanned()
	{
		return LevelSequencePlayer.Banned;
	}

	// Token: 0x04005942 RID: 22850
	private readonly Dictionary<string, USequencePlayContext> PlayContextMap = new Dictionary<string, USequencePlayContext>();

	// Token: 0x04005943 RID: 22851
	[Nullable(2)]
	private AUIBaseActor UiBaseActor;

	// Token: 0x04005944 RID: 22852
	[Nullable(2)]
	private UUIItem UiItem;

	// Token: 0x04005945 RID: 22853
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSequenceEndEvent[] OnSequenceEndEvent;

	// Token: 0x04005946 RID: 22854
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSequenceStartEvent[] OnSequenceStartEvent;

	// Token: 0x04005947 RID: 22855
	[Nullable(2)]
	private string CurrentSequenceName;

	// Token: 0x04005948 RID: 22856
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static HashSet<LevelSequencePlayer> _playingInstances;

	// Token: 0x04005949 RID: 22857
	private static bool Banned;

	// Token: 0x0400594A RID: 22858
	private readonly Dictionary<string, SequenceData> PlayingSequenceNameMap = new Dictionary<string, SequenceData>();
}
