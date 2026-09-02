using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D35 RID: 7477
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleArrowScore : UiPanelBase
{
	// Token: 0x0600DC24 RID: 56356 RVA: 0x003B2BC8 File Offset: 0x003B0DC8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIArtText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x0600DC25 RID: 56357 RVA: 0x003B2C38 File Offset: 0x003B0E38
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.SequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnCloseEvent), false);
		this.SpriteExpress = base.GetSprite(0);
		this.ArtTextScore = base.GetArtText(1);
		this.TextTime = base.GetText(2);
		this.EffectDouble = base.GetItem(3);
		int id = ModelBase<GameModeModel>.Instance.InstanceDungeon.Value.Id;
		MotorFightMainLevel? levelByInstId = ConfigBase<MotorcycleArrowConfig>.Instance.GetLevelByInstId(id);
		this.BigScoreThreshold = ((levelByInstId != null) ? levelByInstId.GetValueOrDefault().BigScore : 10);
		UUIArtText artTextScore = this.ArtTextScore;
		if (artTextScore != null)
		{
			artTextScore.SetText("0");
		}
		this.DigitScroll.Init(0f, 0f, 500f);
		this.SetExpressState("SP_ScoreExpress1");
	}

	// Token: 0x0600DC26 RID: 56358 RVA: 0x003B2D27 File Offset: 0x003B0F27
	protected override void OnBeforeDestroy()
	{
		this.SequencePlayer.Clear();
		this.SequencePlayer = null;
	}

	// Token: 0x0600DC27 RID: 56359 RVA: 0x003B2D3C File Offset: 0x003B0F3C
	protected override void OnBeforeShow()
	{
		this.OnAddEventListener();
		MotorcycleArrowSubModel motorcycleArrowSubModel = (MotorcycleArrowSubModel)ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
		this.OnMotorArrowScoreUpdate(motorcycleArrowSubModel.Score);
		this.PlayLevelSequence("Start", false);
	}

	// Token: 0x0600DC28 RID: 56360 RVA: 0x003B2D77 File Offset: 0x003B0F77
	protected override void OnBeforeHide()
	{
		this.OnRemoveEventListener();
	}

	// Token: 0x0600DC29 RID: 56361 RVA: 0x003B2D7F File Offset: 0x003B0F7F
	protected void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorArrowScoreUpdate, new Action<int>(this.OnMotorArrowScoreUpdate));
	}

	// Token: 0x0600DC2A RID: 56362 RVA: 0x003B2D9D File Offset: 0x003B0F9D
	protected void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorArrowScoreUpdate, new Action<int>(this.OnMotorArrowScoreUpdate));
	}

	// Token: 0x0600DC2B RID: 56363 RVA: 0x003B2DBC File Offset: 0x003B0FBC
	protected void OnMotorArrowScoreUpdate(int score)
	{
		float num = this.DigitScroll.SetTarget((float)score);
		if (num <= 0f)
		{
			return;
		}
		if (num > (float)this.BigScoreThreshold)
		{
			this.NeedDoubleEffect = true;
			this.PlayLevelSequence("Double", true);
			return;
		}
		if (this.CurSeqState == "Double")
		{
			return;
		}
		if (this.CurSeqState == "Score")
		{
			this.PlayLevelSequence("Scoring", false);
			return;
		}
		if (this.CurSeqState == "Loop")
		{
			this.PlayLevelSequence("Score", false);
		}
	}

	// Token: 0x0600DC2C RID: 56364 RVA: 0x003B2E50 File Offset: 0x003B1050
	public void OnTick(float delta)
	{
		MotorcycleArrowSubModel motorcycleArrowSubModel = (MotorcycleArrowSubModel)ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
		if (motorcycleArrowSubModel == null)
		{
			return;
		}
		this.TextTime.SetText(MotorcycleUtil.TimeFormat((float)(Singleton<Time>.Instance.WorldTimeSeconds - (double)motorcycleArrowSubModel.LevelStartTime)), true);
		if (!this.DigitScroll.IsFinished())
		{
			float num = this.DigitScroll.Tick(delta);
			UUIArtText artTextScore = this.ArtTextScore;
			if (artTextScore != null)
			{
				artTextScore.SetText(MotorcycleUtil.CompactNumberFormat((float)Math.Floor((double)num)));
			}
		}
		else if (this.NeedDoubleEffect)
		{
			this.PlayerEffectDouble();
			this.NeedDoubleEffect = false;
		}
		if (this.EndSeqTime > 0f && (float)Singleton<Time>.Instance.WorldTimeSeconds >= this.EndSeqTime)
		{
			this.EndSeqTime = 0f;
			this.PlayLevelSequence("Loop", false);
		}
	}

	// Token: 0x0600DC2D RID: 56365 RVA: 0x003B2F1B File Offset: 0x003B111B
	private void OnCloseEvent(string sequenceName)
	{
		if (sequenceName == "Start" || sequenceName == "Double")
		{
			this.PlayLevelSequence("Loop", false);
		}
	}

	// Token: 0x0600DC2E RID: 56366 RVA: 0x003B2F44 File Offset: 0x003B1144
	private void PlayLevelSequence(string state, bool bRestart)
	{
		if (this.CurSeqState == state && !bRestart)
		{
			this.UpdateEndSeqTime(state);
			return;
		}
		this.CurSeqState = state;
		if (state == "Double" || state == "Scoring" || state == "Score")
		{
			this.SetExpressState("SP_ScoreExpress2");
		}
		else if (state == "Start" || state == "Close")
		{
			this.SetExpressState("SP_ScoreExpress1");
		}
		else if (this.DigitScroll.Target > 0f)
		{
			this.SetExpressState("SP_ScoreExpress3");
		}
		this.UpdateEndSeqTime(state);
		this.SequencePlayer.StopPlayingSequence(false, true);
		this.SequencePlayer.PlayOrReplaySequenceByName(state, false, null);
	}

	// Token: 0x0600DC2F RID: 56367 RVA: 0x003B3013 File Offset: 0x003B1213
	private void UpdateEndSeqTime(string state)
	{
		if (state == "Scoring" || state == "Score")
		{
			this.EndSeqTime = (float)Singleton<Time>.Instance.WorldTimeSeconds + 5000f;
			return;
		}
		this.EndSeqTime = 0f;
	}

	// Token: 0x0600DC30 RID: 56368 RVA: 0x003B3054 File Offset: 0x003B1254
	private void SetExpressState(string state)
	{
		if (this.ExpressState == state)
		{
			return;
		}
		this.ExpressState = state;
		this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(state), this.SpriteExpress, false, null, null);
	}

	// Token: 0x0600DC31 RID: 56369 RVA: 0x003B3099 File Offset: 0x003B1299
	private void PlayerEffectDouble()
	{
		this.EffectDouble.SetUIActive(false);
		this.EffectDouble.SetUIActive(true);
	}

	// Token: 0x0400694F RID: 26959
	private const int CONSECUTIVE_SCORE_DURATION = 5000;

	// Token: 0x04006950 RID: 26960
	private const int SCORE_ANIM_DURATION = 500;

	// Token: 0x04006951 RID: 26961
	[Nullable(2)]
	protected UUISprite SpriteExpress;

	// Token: 0x04006952 RID: 26962
	[Nullable(2)]
	protected UUIArtText ArtTextScore;

	// Token: 0x04006953 RID: 26963
	[Nullable(2)]
	protected UUIText TextTime;

	// Token: 0x04006954 RID: 26964
	[Nullable(2)]
	protected UUIItem EffectDouble;

	// Token: 0x04006955 RID: 26965
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x04006956 RID: 26966
	private int BigScoreThreshold = 10;

	// Token: 0x04006957 RID: 26967
	private string CurSeqState = "None";

	// Token: 0x04006958 RID: 26968
	private float EndSeqTime;

	// Token: 0x04006959 RID: 26969
	private string ExpressState = "None";

	// Token: 0x0400695A RID: 26970
	private bool NeedDoubleEffect;

	// Token: 0x0400695B RID: 26971
	private readonly DigitScroll DigitScroll = new DigitScroll();

	// Token: 0x020080C5 RID: 32965
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BCA5 RID: 179365
		public const int SpriteExpress = 0;

		// Token: 0x0402BCA6 RID: 179366
		public const int ArtTextScore = 1;

		// Token: 0x0402BCA7 RID: 179367
		public const int TextTime = 2;

		// Token: 0x0402BCA8 RID: 179368
		public const int EffectDouble = 3;
	}

	// Token: 0x020080C6 RID: 32966
	[Nullable(0)]
	private static class ELevelSequence
	{
		// Token: 0x0402BCA9 RID: 179369
		public const string None = "None";

		// Token: 0x0402BCAA RID: 179370
		public const string Start = "Start";

		// Token: 0x0402BCAB RID: 179371
		public const string Score = "Score";

		// Token: 0x0402BCAC RID: 179372
		public const string Scoring = "Scoring";

		// Token: 0x0402BCAD RID: 179373
		public const string Double = "Double";

		// Token: 0x0402BCAE RID: 179374
		public const string Close = "Close";

		// Token: 0x0402BCAF RID: 179375
		public const string Loop = "Loop";
	}

	// Token: 0x020080C7 RID: 32967
	[Nullable(0)]
	private static class EExpressDefine
	{
		// Token: 0x0402BCB0 RID: 179376
		public const string None = "None";

		// Token: 0x0402BCB1 RID: 179377
		public const string Close = "SP_ScoreExpress1";

		// Token: 0x0402BCB2 RID: 179378
		public const string Double = "SP_ScoreExpress2";

		// Token: 0x0402BCB3 RID: 179379
		public const string Open = "SP_ScoreExpress3";
	}
}
