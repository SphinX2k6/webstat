using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Dango.DangoLogic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002718 RID: 10008
public class RacingBetsDangoBroadcastItem : UiPanelBase
{
	// Token: 0x06013BDB RID: 80859 RVA: 0x0057E7DC File Offset: 0x0057C9DC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06013BDC RID: 80860 RVA: 0x0057E84C File Offset: 0x0057CA4C
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.SequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceFinish), false);
	}

	// Token: 0x06013BDD RID: 80861 RVA: 0x0057E877 File Offset: 0x0057CA77
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.Clear();
		}
		this.SequencePlayer = null;
	}

	// Token: 0x06013BDE RID: 80862 RVA: 0x0057E891 File Offset: 0x0057CA91
	[NullableContext(1)]
	private void OnSequenceFinish(string sequenceName)
	{
		if (sequenceName == "TipsHide" && this.IsPlayingHide)
		{
			base.GetItem(0).SetUIActive(false);
			this.IsPlayingHide = false;
		}
	}

	// Token: 0x06013BDF RID: 80863 RVA: 0x0057E8BC File Offset: 0x0057CABC
	[NullableContext(1)]
	public void Init(RacingBetsLegMatchData legMatchData)
	{
		this.LegMatchData = legMatchData;
	}

	// Token: 0x06013BE0 RID: 80864 RVA: 0x0057E8C8 File Offset: 0x0057CAC8
	public void OnTick(float deltaTime)
	{
		if (this.IsShowBroadcast)
		{
			this.MoveLeft(deltaTime);
			this.CurBroadcastTime += deltaTime;
			if (this.CurBroadcastTime > this.ScrollDuration && !this.HasTriggeredHideThisRound)
			{
				this.HasTriggeredHideThisRound = true;
				this.IsPlayingHide = true;
				LevelSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer != null)
				{
					sequencePlayer.PlaySequencePurely("TipsHide", false, false, null, null, false);
				}
			}
			if (this.CurBroadcastTime > this.BroadcastInterval)
			{
				this.CurBroadcastTime = 0f;
				this.IsShowBroadcast = false;
				return;
			}
		}
		else
		{
			this.InitBroadcast();
		}
	}

	// Token: 0x06013BE1 RID: 80865 RVA: 0x0057E960 File Offset: 0x0057CB60
	private void MoveLeft(float delta)
	{
		UUIItem item = base.GetItem(3);
		item.SetAnchorOffsetX(item.GetAnchorOffsetX() - delta * 0.2f);
	}

	// Token: 0x06013BE2 RID: 80866 RVA: 0x0057E97C File Offset: 0x0057CB7C
	private void InitBroadcast()
	{
		this.IsShowBroadcast = true;
		this.IsPlayingHide = false;
		this.HasTriggeredHideThisRound = false;
		UUIText text = base.GetText(1);
		UUIItem item = base.GetItem(3);
		UUITexture texture = base.GetTexture(2);
		float ruleRate = ConfigBase<RacingBetsConfig>.Instance.GetRuleRate();
		if (Random.Shared.NextDouble() < (double)ruleRate)
		{
			string randomRuleText = this.LegMatchData.GetRandomRuleText();
			text.ShowTextNew(randomRuleText);
			texture.SetUIActive(false);
		}
		else
		{
			ValueTuple<string, int> dangoBroadcastText = this.LegMatchData.GetDangoBroadcastText();
			text.ShowTextNew(dangoBroadcastText.Item1);
			base.SetTextureShowUntilLoaded(ConfigBase<DangoConfig>.Instance.GetDangoById(dangoBroadcastText.Item2).Value.Icon, texture, null);
			texture.SetUIActive(true);
		}
		base.GetItem(0).SetUIActive(true);
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.PlaySequencePurely("TipsShow", false, false, null, null, false);
		}
		float width = base.GetItem(0).Width;
		item.SetAnchorOffsetX(width);
		float num = text.GetTextRenderSize().X;
		num += texture.Width;
		this.ScrollDuration = (width + num) / 0.2f;
		this.BroadcastInterval = this.ScrollDuration + 5000f;
	}

	// Token: 0x040099C2 RID: 39362
	private float BroadcastInterval;

	// Token: 0x040099C3 RID: 39363
	private float ScrollDuration;

	// Token: 0x040099C4 RID: 39364
	private float CurBroadcastTime;

	// Token: 0x040099C5 RID: 39365
	private bool IsShowBroadcast;

	// Token: 0x040099C6 RID: 39366
	[Nullable(2)]
	private RacingBetsLegMatchData LegMatchData;

	// Token: 0x040099C7 RID: 39367
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x040099C8 RID: 39368
	private bool IsPlayingHide;

	// Token: 0x040099C9 RID: 39369
	private bool HasTriggeredHideThisRound;

	// Token: 0x02008AB8 RID: 35512
	private class EComponent
	{
		// Token: 0x0402EC60 RID: 191584
		public const int RootItem = 0;

		// Token: 0x0402EC61 RID: 191585
		public const int Text = 1;

		// Token: 0x0402EC62 RID: 191586
		public const int DangoIconTexture = 2;

		// Token: 0x0402EC63 RID: 191587
		public const int PosItem = 3;
	}
}
