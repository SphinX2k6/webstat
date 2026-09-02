using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200271C RID: 10012
[NullableContext(2)]
[Nullable(0)]
public class RacingBetsDangoRankItem : UiPanelBase
{
	// Token: 0x06013BFD RID: 80893 RVA: 0x0057F01C File Offset: 0x0057D21C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06013BFE RID: 80894 RVA: 0x0057F0A2 File Offset: 0x0057D2A2
	protected override void OnBeforeCreateImplement()
	{
		this.UiLevelSequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.UiLevelSequence);
	}

	// Token: 0x06013BFF RID: 80895 RVA: 0x0057F0BC File Offset: 0x0057D2BC
	[NullableContext(1)]
	public void Init(RacingBetsDungeonDangoInfo data, UCurveFloat lerpCurve, int itemInterval)
	{
		this.DangoInfo = data;
		this.LerpCurve = lerpCurve;
		this.DangoRankInterval = itemInterval;
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(data.Rank.ToString(), true);
		}
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(data.DangoId);
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.ShowTextNew(dangoData.NameKey);
		}
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetAnchorOffsetY(this.GetDangoAnchorOffsetY(data.Rank));
		}
		base.SetTextureShowUntilLoaded(dangoData.DangoConfig.Value.IconSmall, base.GetTexture(1), null);
		Dice? diceConfig = data.GetDiceConfig();
		if (diceConfig != null)
		{
			base.SetTextureShowUntilLoaded(diceConfig.Value.RollDiceBackgroundIcon, base.GetTexture(3), null);
		}
		bool uiactive = ModelBase<RacingBetsModel>.Instance.IsDungeonBettingDango(data.DangoId);
		UUIItem item = base.GetItem(4);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x06013C00 RID: 80896 RVA: 0x0057F1B4 File Offset: 0x0057D3B4
	public UniTask RefreshAsync()
	{
		RacingBetsDangoRankItem.<RefreshAsync>d__14 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<RacingBetsDangoRankItem.<RefreshAsync>d__14>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013C01 RID: 80897 RVA: 0x0057F1F8 File Offset: 0x0057D3F8
	public UniTask LerpRankTargetPosition()
	{
		RacingBetsDangoRankItem.<LerpRankTargetPosition>d__15 <LerpRankTargetPosition>d__;
		<LerpRankTargetPosition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LerpRankTargetPosition>d__.<>4__this = this;
		<LerpRankTargetPosition>d__.<>1__state = -1;
		<LerpRankTargetPosition>d__.<>t__builder.Start<RacingBetsDangoRankItem.<LerpRankTargetPosition>d__15>(ref <LerpRankTargetPosition>d__);
		return <LerpRankTargetPosition>d__.<>t__builder.Task;
	}

	// Token: 0x06013C02 RID: 80898 RVA: 0x0057F23C File Offset: 0x0057D43C
	private void OnTick(float deltaTime)
	{
		this.CurLerpTime += deltaTime;
		float num = (float)this.LerpTime / Singleton<Time>.Instance.TimeDilation;
		if (this.CurLerpTime >= num)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetAnchorOffsetY(this.EndOffsetY);
			}
			this.ReleaseLerpPromise();
			this.ReleaseHandle();
			return;
		}
		if (this.LerpCurve != null)
		{
			float anchorOffsetY = this.LerpCurve.GetFloatValue(this.CurLerpTime / num) * (this.EndOffsetY - this.StartOffsetY) + this.StartOffsetY;
			UUIItem rootItem2 = this.RootItem;
			if (rootItem2 == null)
			{
				return;
			}
			rootItem2.SetAnchorOffsetY(anchorOffsetY);
		}
	}

	// Token: 0x06013C03 RID: 80899 RVA: 0x0057F2D9 File Offset: 0x0057D4D9
	protected override void OnBeforeDestroy()
	{
		this.ReleaseHandle();
		this.ReleaseLerpPromise();
	}

	// Token: 0x06013C04 RID: 80900 RVA: 0x0057F2E7 File Offset: 0x0057D4E7
	private float GetDangoAnchorOffsetY(int rank)
	{
		if (this.RootItem == null)
		{
			return 0f;
		}
		return (float)(-(float)(rank - 1)) * (this.RootItem.GetHeight() + (float)this.DangoRankInterval);
	}

	// Token: 0x06013C05 RID: 80901 RVA: 0x0057F310 File Offset: 0x0057D510
	public void ReleaseHandle()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06013C06 RID: 80902 RVA: 0x0057F332 File Offset: 0x0057D532
	private void ReleaseLerpPromise()
	{
		if (this.LerpPromise != null)
		{
			this.LerpPromise.SetResult();
			this.LerpPromise = null;
		}
	}

	// Token: 0x040099CE RID: 39374
	public UiBehaviorLevelSequence UiLevelSequence;

	// Token: 0x040099CF RID: 39375
	[Nullable(1)]
	private RacingBetsDungeonDangoInfo DangoInfo;

	// Token: 0x040099D0 RID: 39376
	private int DangoRankInterval;

	// Token: 0x040099D1 RID: 39377
	public int LerpTime = 1000;

	// Token: 0x040099D2 RID: 39378
	private float CurLerpTime;

	// Token: 0x040099D3 RID: 39379
	private float StartOffsetY;

	// Token: 0x040099D4 RID: 39380
	private float EndOffsetY;

	// Token: 0x040099D5 RID: 39381
	private CustomPromise LerpPromise;

	// Token: 0x040099D6 RID: 39382
	private TimerHandle TimerHandle;

	// Token: 0x040099D7 RID: 39383
	private UCurveFloat LerpCurve;

	// Token: 0x02008ABC RID: 35516
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402EC73 RID: 191603
		RankText,
		// Token: 0x0402EC74 RID: 191604
		HeadTexture,
		// Token: 0x0402EC75 RID: 191605
		NameText,
		// Token: 0x0402EC76 RID: 191606
		DiceTexture,
		// Token: 0x0402EC77 RID: 191607
		BetItem
	}
}
