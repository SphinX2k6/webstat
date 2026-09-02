using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020011C3 RID: 4547
[NullableContext(1)]
[Nullable(0)]
public class ArtemisQteView : UiTickViewBase
{
	// Token: 0x060077BA RID: 30650 RVA: 0x001F589A File Offset: 0x001F3A9A
	public ArtemisQteView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060077BB RID: 30651 RVA: 0x001F58A4 File Offset: 0x001F3AA4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickFishButton))
		};
	}

	// Token: 0x060077BC RID: 30652 RVA: 0x001F5924 File Offset: 0x001F3B24
	protected override UniTask OnBeforeStartAsync()
	{
		ArtemisQteView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ArtemisQteView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060077BD RID: 30653 RVA: 0x001F5967 File Offset: 0x001F3B67
	protected override void OnBeforeShow()
	{
		this.PlayAnim(this.ViewSequencePlayer, "Start");
		ArtemisQteProgressItem progressItem = this.ProgressItem;
		if (progressItem == null)
		{
			return;
		}
		progressItem.PlayAnim("Start");
	}

	// Token: 0x060077BE RID: 30654 RVA: 0x001F5990 File Offset: 0x001F3B90
	protected override UniTask OnPlayingCloseSequenceAsync()
	{
		ArtemisQteView.<OnPlayingCloseSequenceAsync>d__14 <OnPlayingCloseSequenceAsync>d__;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
		<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<ArtemisQteView.<OnPlayingCloseSequenceAsync>d__14>(ref <OnPlayingCloseSequenceAsync>d__);
		return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060077BF RID: 30655 RVA: 0x001F59D3 File Offset: 0x001F3BD3
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnArtemisQteAreaChange, new Action<int>(this.OnFishingQteAreaChange));
	}

	// Token: 0x060077C0 RID: 30656 RVA: 0x001F59F1 File Offset: 0x001F3BF1
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnArtemisQteAreaChange, new Action<int>(this.OnFishingQteAreaChange));
	}

	// Token: 0x060077C1 RID: 30657 RVA: 0x001F5A0F File Offset: 0x001F3C0F
	protected override void OnStart()
	{
		this.Init();
		ArtemisQteProgressItem progressItem = this.ProgressItem;
		if (progressItem != null)
		{
			progressItem.InitRing();
		}
		ArtemisQteClickTipsItem tipsItem = this.TipsItem;
		if (tipsItem == null)
		{
			return;
		}
		tipsItem.SetActive(false);
	}

	// Token: 0x060077C2 RID: 30658 RVA: 0x001F5A39 File Offset: 0x001F3C39
	private void Init()
	{
		this.GameInfo.SetGameStage(EArtemisQteStage.Ready);
		this.GameInfo.GetRingInfo().EnterNextValidArea();
		this.SetGameStart();
	}

	// Token: 0x060077C3 RID: 30659 RVA: 0x001F5A5D File Offset: 0x001F3C5D
	protected override void OnBeforeDestroy()
	{
		Action finishCallback = this.FinishCallback;
		if (finishCallback != null)
		{
			finishCallback();
		}
		LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
		if (viewSequencePlayer != null)
		{
			viewSequencePlayer.Clear();
		}
		this.ViewSequencePlayer = null;
	}

	// Token: 0x060077C4 RID: 30660 RVA: 0x001F5A88 File Offset: 0x001F3C88
	protected override void OnTick(float delta)
	{
		ArtemisQteProgressItem progressItem = this.ProgressItem;
		if (progressItem != null)
		{
			progressItem.OnTick(delta);
		}
		if (this.GameInfo.IsGamePause())
		{
			return;
		}
		float num = delta / 1000f;
		this.GameInfo.CurrentScore += (int)((float)this.ScoreUp * num);
		ArtemisQte? currentPlayConfig = this.GetCurrentPlayConfig();
		int num2 = (currentPlayConfig != null) ? currentPlayConfig.GetValueOrDefault().MaxScore : 0;
		if (this.GameInfo.CurrentScore >= num2)
		{
			this.EnterNextRound();
		}
	}

	// Token: 0x060077C5 RID: 30661 RVA: 0x001F5B10 File Offset: 0x001F3D10
	private void EnterNextRound()
	{
		this.GameInfo.CurrentRound = Math.Min(this.GameInfo.CurrentRound + 1, this.GameInfo.MaxRound);
		ArtemisQte? currentPlayConfig = this.GetCurrentPlayConfig();
		if (this.GameInfo.CurrentRound != this.GameInfo.MaxRound)
		{
			this.GameInfo.CurrentScore -= currentPlayConfig.Value.MaxScore;
		}
		else
		{
			this.GameInfo.SetGameStage(EArtemisQteStage.End);
		}
		this.ProgressItem.EnterNextRound();
		if (this.GameInfo.CurrentRound == this.GameInfo.MaxRound)
		{
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.SetGameEnd();
			}, 800f, null, null, true, 1f);
		}
	}

	// Token: 0x060077C6 RID: 30662 RVA: 0x001F5BDA File Offset: 0x001F3DDA
	private void OnFishingQteAreaChange(int areaRelativeIndex)
	{
		this.ProgressItem.OnArrowStayAreaUpdate(areaRelativeIndex);
	}

	// Token: 0x060077C7 RID: 30663 RVA: 0x001F5BE8 File Offset: 0x001F3DE8
	private void OnClickFishButton()
	{
		if (this.GameInfo.IsGamePause())
		{
			return;
		}
		ArtemisQteRingInfo ringInfo = this.GameInfo.GetRingInfo();
		int currentArrowStayCellIndex = ringInfo.CurrentArrowStayCellIndex;
		ContinuousRingArea continuousRingArea = ringInfo.CheckInArea(ringInfo.GetPerfectAreas(), currentArrowStayCellIndex);
		if (continuousRingArea != null)
		{
			this.OnAreaClick(EArtemisAreaType.PerfectArea, continuousRingArea);
			return;
		}
		ContinuousRingArea continuousRingArea2 = ringInfo.CheckInArea(ringInfo.GetQteAreas(), currentArrowStayCellIndex);
		if (continuousRingArea2 != null)
		{
			this.OnAreaClick(EArtemisAreaType.QteArea, continuousRingArea2);
			return;
		}
		this.OnAreaClick(EArtemisAreaType.BlankArea, null);
	}

	// Token: 0x060077C8 RID: 30664 RVA: 0x001F5C52 File Offset: 0x001F3E52
	private void SetGameStart()
	{
		this.GameInfo.SetGameStage(EArtemisQteStage.OnGoing);
	}

	// Token: 0x060077C9 RID: 30665 RVA: 0x001F5C60 File Offset: 0x001F3E60
	private void SetGameEnd()
	{
		base.CloseMe(null);
		ArtemisQteViewParams artemisQteViewParams = this.OpenParam as ArtemisQteViewParams;
		if (artemisQteViewParams == null)
		{
			return;
		}
		artemisQteViewParams.CallBack();
	}

	// Token: 0x060077CA RID: 30666 RVA: 0x001F5C84 File Offset: 0x001F3E84
	[NullableContext(2)]
	private void OnAreaClick(EArtemisAreaType areaType, ContinuousRingArea area)
	{
		this.ProgressItem.OnAreaClick(areaType, area);
		ArtemisQte? currentPlayConfig = this.GetCurrentPlayConfig();
		int num = (currentPlayConfig != null) ? currentPlayConfig.GetValueOrDefault().MaxScore : 0;
		switch (areaType)
		{
		case EArtemisAreaType.BlankArea:
		{
			this.PlayAnim(this.ViewSequencePlayer, "Miss");
			this.OnMissOn();
			ArtemisQteClickTipsItem tipsItem = this.TipsItem;
			if (tipsItem == null)
			{
				return;
			}
			tipsItem.ShowTip(EArtemisTipsType.Miss);
			return;
		}
		case EArtemisAreaType.QteArea:
		{
			this.ProgressItem.StartAnimProgress();
			this.PlayAnim(this.ViewSequencePlayer, "Success");
			this.OnQteOn();
			ArtemisQteRingInfo ringInfo = this.GameInfo.GetRingInfo();
			if (!ringInfo.IsWholeRing)
			{
				ringInfo.EnterNextValidArea();
			}
			if (this.GameInfo.CurrentScore < num && area != null)
			{
				this.ProgressItem.SpawnContinuousArea(area.ContinuousIndex, EArtemisAreaType.QteArea);
			}
			ArtemisQteClickTipsItem tipsItem2 = this.TipsItem;
			if (tipsItem2 == null)
			{
				return;
			}
			tipsItem2.ShowTip(EArtemisTipsType.None);
			return;
		}
		case EArtemisAreaType.PerfectArea:
		{
			this.ProgressItem.StartAnimProgress();
			this.PlayAnim(this.ViewSequencePlayer, "Perfect");
			this.OnPerfectOn();
			ArtemisQteRingInfo ringInfo2 = this.GameInfo.GetRingInfo();
			if (!ringInfo2.IsWholeRing)
			{
				ringInfo2.EnterNextValidArea();
			}
			if (this.GameInfo.CurrentScore < num && area != null)
			{
				this.ProgressItem.SpawnContinuousArea(area.ContinuousIndex, EArtemisAreaType.PerfectArea);
			}
			ArtemisQteClickTipsItem tipsItem3 = this.TipsItem;
			if (tipsItem3 == null)
			{
				return;
			}
			tipsItem3.ShowTip(EArtemisTipsType.Perfect);
			return;
		}
		default:
			return;
		}
	}

	// Token: 0x060077CB RID: 30667 RVA: 0x001F5DE4 File Offset: 0x001F3FE4
	private void PlayAnim([Nullable(2)] LevelSequencePlayer player, string sequenceName)
	{
		if (player == null)
		{
			return;
		}
		if (player.GetCurrentSequence() == sequenceName)
		{
			player.ReplaySequenceByKey(sequenceName);
			return;
		}
		player.StopPlayingSequence(false, true);
		player.PlayLevelSequenceByName(sequenceName, false, null, false);
	}

	// Token: 0x17000A0F RID: 2575
	// (get) Token: 0x060077CC RID: 30668 RVA: 0x001F5E25 File Offset: 0x001F4025
	public int GetCurrentGameplayId
	{
		get
		{
			return this.CurrentGameplayId;
		}
	}

	// Token: 0x060077CD RID: 30669 RVA: 0x001F5E2D File Offset: 0x001F402D
	public bool GameplayStart(int configId, int maxRound)
	{
		this.CurrentGameplayId = configId;
		return this.InitialGameInfo(maxRound);
	}

	// Token: 0x060077CE RID: 30670 RVA: 0x001F5E3D File Offset: 0x001F403D
	public ArtemisQte? GetCurrentPlayConfig()
	{
		return ConfigBase<ArtemisActivityConfig>.Instance.GetArtemisQteConfigById(this.CurrentGameplayId);
	}

	// Token: 0x060077CF RID: 30671 RVA: 0x001F5E50 File Offset: 0x001F4050
	private bool InitialGameInfo(int maxRound)
	{
		if (this.GameInfo == null)
		{
			this.GameInfo = new ArtemisQteGameInfo();
		}
		this.GameInfo.Clear();
		ArtemisQte? currentPlayConfig = this.GetCurrentPlayConfig();
		EArrowDirection arrowDirection = (currentPlayConfig != null && currentPlayConfig.GetValueOrDefault().IsAnticlockwise) ? EArrowDirection.Anticlockwise : EArrowDirection.Clockwise;
		this.GameInfo.CreateRingInfo(arrowDirection);
		this.GameInfo.MaxRound = maxRound;
		int num = (currentPlayConfig != null) ? currentPlayConfig.GetValueOrDefault().InvalidAreaLength : 0;
		this.GameInfo.GetRingInfo().IsWholeRing = (num == 0);
		this.AccumulatePerfectCombo = 0;
		return true;
	}

	// Token: 0x17000A10 RID: 2576
	// (get) Token: 0x060077D0 RID: 30672 RVA: 0x001F5EF4 File Offset: 0x001F40F4
	public int ScoreUp
	{
		get
		{
			ArtemisQte? currentPlayConfig = this.GetCurrentPlayConfig();
			if (currentPlayConfig != null)
			{
				return currentPlayConfig.Value.ScoreUp;
			}
			return 0;
		}
	}

	// Token: 0x17000A11 RID: 2577
	// (get) Token: 0x060077D1 RID: 30673 RVA: 0x001F5F24 File Offset: 0x001F4124
	public int HitAreaScore
	{
		get
		{
			ArtemisQte? currentPlayConfig = this.GetCurrentPlayConfig();
			if (currentPlayConfig != null)
			{
				return currentPlayConfig.Value.HitAreaScore;
			}
			return 0;
		}
	}

	// Token: 0x17000A12 RID: 2578
	// (get) Token: 0x060077D2 RID: 30674 RVA: 0x001F5F54 File Offset: 0x001F4154
	public int PerfectScore
	{
		get
		{
			ArtemisQte? currentPlayConfig = this.GetCurrentPlayConfig();
			if (currentPlayConfig != null)
			{
				return currentPlayConfig.Value.PerfectScore;
			}
			return 0;
		}
	}

	// Token: 0x17000A13 RID: 2579
	// (get) Token: 0x060077D3 RID: 30675 RVA: 0x001F5F82 File Offset: 0x001F4182
	// (set) Token: 0x060077D4 RID: 30676 RVA: 0x001F5F8A File Offset: 0x001F418A
	protected int AccumulatePerfectCombo
	{
		get
		{
			return this.AccumulatePerfectComboInternal;
		}
		set
		{
			this.AccumulatePerfectComboInternal = value;
			this.RefreshAccumulatePerfectCombo();
		}
	}

	// Token: 0x060077D5 RID: 30677 RVA: 0x001F5F9C File Offset: 0x001F419C
	public void OnQteOn()
	{
		this.GameInfo.CurrentScore += this.HitAreaScore;
		int accumulatePerfectCombo = this.AccumulatePerfectCombo;
		this.AccumulatePerfectCombo = accumulatePerfectCombo + 1;
	}

	// Token: 0x060077D6 RID: 30678 RVA: 0x001F5FD4 File Offset: 0x001F41D4
	public void OnPerfectOn()
	{
		this.GameInfo.CurrentScore += this.PerfectScore;
		int accumulatePerfectCombo = this.AccumulatePerfectCombo;
		this.AccumulatePerfectCombo = accumulatePerfectCombo + 1;
	}

	// Token: 0x060077D7 RID: 30679 RVA: 0x001F600C File Offset: 0x001F420C
	public void OnMissOn()
	{
		ArtemisQte? currentPlayConfig = this.GetCurrentPlayConfig();
		this.GameInfo.CurrentScore = Math.Max(0, this.GameInfo.CurrentScore - currentPlayConfig.Value.MistakeScore);
		this.AccumulatePerfectCombo = 0;
	}

	// Token: 0x060077D8 RID: 30680 RVA: 0x001F6054 File Offset: 0x001F4254
	private void RefreshAccumulatePerfectCombo()
	{
		int accumulatePerfectCombo = this.AccumulatePerfectCombo;
		ArtemisQte? currentPlayConfig = this.GetCurrentPlayConfig();
		if (currentPlayConfig == null)
		{
			return;
		}
		ArtemisQte config = currentPlayConfig.Value;
		Dictionary<int, int> keyValueMap = ArtemisQteView.BuildDictFromConfigArray(config.CursorSpeedLength, (int j) => config.CursorSpeed(j));
		Dictionary<int, int> keyValueMap2 = ArtemisQteView.BuildDictFromConfigArray(config.RouletteRotateSpeedLength, (int j) => config.RouletteRotateSpeed(j));
		Dictionary<int, int> keyValueMap3 = ArtemisQteView.BuildDictFromConfigArray(config.PerfectAppearRateLength, (int j) => config.PerfectAppearRate(j));
		this.GameInfo.CursorSpeed = (float)ArtemisQteView.RefreshInfoByKey(accumulatePerfectCombo, keyValueMap);
		this.GameInfo.RingSpeed = (float)ArtemisQteView.RefreshInfoByKey(accumulatePerfectCombo, keyValueMap2);
		this.GameInfo.PerfectAppearRate = (float)ArtemisQteView.RefreshInfoByKey(accumulatePerfectCombo, keyValueMap3);
	}

	// Token: 0x060077D9 RID: 30681 RVA: 0x001F6120 File Offset: 0x001F4320
	private static Dictionary<int, int> BuildDictFromConfigArray(int length, Func<int, DicIntInt?> getItem)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = 0; i < length; i++)
		{
			DicIntInt? dicIntInt = getItem(i);
			if (dicIntInt != null)
			{
				DicIntInt value = dicIntInt.Value;
				dictionary[value.Key] = value.Value;
			}
		}
		return dictionary;
	}

	// Token: 0x060077DA RID: 30682 RVA: 0x001F6170 File Offset: 0x001F4370
	private static int RefreshInfoByKey(int currentKey, Dictionary<int, int> keyValueMap)
	{
		List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
		foreach (KeyValuePair<int, int> keyValuePair in keyValueMap)
		{
			list.Add(new ValueTuple<int, int>(keyValuePair.Key, keyValuePair.Value));
		}
		for (int i = 0; i < list.Count; i++)
		{
			int item = list[i].Item1;
			int item2 = list[i].Item2;
			if (i >= list.Count - 1)
			{
				return item2;
			}
			int item3 = list[i + 1].Item1;
			if (item <= currentKey && currentKey < item3)
			{
				return item2;
			}
		}
		return 0;
	}

	// Token: 0x040039F9 RID: 14841
	private const int MAX_QTE_ROUNG = 1;

	// Token: 0x040039FA RID: 14842
	private const int GAME_END_TIME = 800;

	// Token: 0x040039FB RID: 14843
	protected ArtemisQteGameInfo GameInfo;

	// Token: 0x040039FC RID: 14844
	[Nullable(2)]
	private ArtemisQteProgressItem ProgressItem;

	// Token: 0x040039FD RID: 14845
	[Nullable(2)]
	private readonly Action FinishCallback;

	// Token: 0x040039FE RID: 14846
	[Nullable(2)]
	private ArtemisQteClickTipsItem TipsItem;

	// Token: 0x040039FF RID: 14847
	[Nullable(2)]
	private LevelSequencePlayer ViewSequencePlayer;

	// Token: 0x04003A00 RID: 14848
	public int CurrentGameplayId;

	// Token: 0x04003A01 RID: 14849
	private int AccumulatePerfectComboInternal;

	// Token: 0x0200751A RID: 29978
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040286D8 RID: 165592
		public const int CenterPanel = 0;

		// Token: 0x040286D9 RID: 165593
		public const int BtnControl = 1;

		// Token: 0x040286DA RID: 165594
		public const int QteTipUiItem = 2;
	}
}
