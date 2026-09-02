using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D2B RID: 7467
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleBossHeadItem : UiPanelBase
{
	// Token: 0x0600DBE8 RID: 56296 RVA: 0x003B1A70 File Offset: 0x003AFC70
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x0600DBE9 RID: 56297 RVA: 0x003B1B0C File Offset: 0x003AFD0C
	protected override void OnStart()
	{
		this.Attack = base.GetItem(0);
		this.BossHead = base.GetTexture(1);
		this.HeadBase = base.GetSprite(2);
		this.BossIcon = base.GetSprite(3);
		this.FinishIcon = base.GetSprite(4);
		this.StateAttack = base.GetItem(5);
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600DBEA RID: 56298 RVA: 0x003B1B78 File Offset: 0x003AFD78
	protected override void OnBeforeDestroy()
	{
		this.SequencePlayer.Clear();
		this.SequencePlayer = null;
	}

	// Token: 0x0600DBEB RID: 56299 RVA: 0x003B1B8C File Offset: 0x003AFD8C
	[NullableContext(1)]
	public void SetBossIconPath(string path)
	{
		base.SetTextureByPath(path, this.BossHead, null, null);
	}

	// Token: 0x0600DBEC RID: 56300 RVA: 0x003B1BB0 File Offset: 0x003AFDB0
	public void SetBossState(EBossState state, bool bForceRefresh = false)
	{
		if (this.BossState == state && !bForceRefresh)
		{
			return;
		}
		this.BossState = state;
		this.Refresh();
	}

	// Token: 0x0600DBED RID: 56301 RVA: 0x003B1BCC File Offset: 0x003AFDCC
	protected void Refresh()
	{
		this.SequencePlayer.StopPlayingSequence(false, true);
		if (this.BossState == EBossState.WaitStart)
		{
			this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_HeadBgNor"), this.HeadBase, true, null, null);
			UUISprite finishIcon = this.FinishIcon;
			if (finishIcon != null)
			{
				finishIcon.SetUIActive(false);
			}
			UUIItem stateAttack = this.StateAttack;
			if (stateAttack != null)
			{
				stateAttack.SetUIActive(true);
			}
			this.SequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
			UUITexture bossHead = this.BossHead;
			if (bossHead == null)
			{
				return;
			}
			bool bUseChangeColor = false;
			FColor? fcolor = null;
			bossHead.SetChangeColor(bUseChangeColor, fcolor);
			return;
		}
		else
		{
			FColor? fcolor;
			if (this.BossState != EBossState.Battle)
			{
				if (this.BossState == EBossState.Finish)
				{
					UUISprite finishIcon2 = this.FinishIcon;
					if (finishIcon2 != null)
					{
						finishIcon2.SetUIActive(true);
					}
					UUIItem stateAttack2 = this.StateAttack;
					if (stateAttack2 != null)
					{
						stateAttack2.SetUIActive(false);
					}
					this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_HeadBgSuccess"), this.HeadBase, true, null, null);
					this.SequencePlayer.PlaySequencePurely("Defeat", false, false, null, null, false);
					FColor value = FColor.FromHex("375454");
					UUITexture bossHead2 = this.BossHead;
					if (bossHead2 == null)
					{
						return;
					}
					bool bUseChangeColor2 = true;
					fcolor = new FColor?(value);
					bossHead2.SetChangeColor(bUseChangeColor2, fcolor);
				}
				return;
			}
			this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_HeadBgNor"), this.HeadBase, true, null, null);
			UUISprite finishIcon3 = this.FinishIcon;
			if (finishIcon3 != null)
			{
				finishIcon3.SetUIActive(false);
			}
			UUIItem stateAttack3 = this.StateAttack;
			if (stateAttack3 != null)
			{
				stateAttack3.SetUIActive(true);
			}
			this.SequencePlayer.PlaySequencePurely("Trigger", false, false, null, null, false);
			UUITexture bossHead3 = this.BossHead;
			if (bossHead3 == null)
			{
				return;
			}
			bool bUseChangeColor3 = false;
			fcolor = null;
			bossHead3.SetChangeColor(bUseChangeColor3, fcolor);
			return;
		}
	}

	// Token: 0x04006925 RID: 26917
	protected EBossState BossState;

	// Token: 0x04006926 RID: 26918
	protected UUIItem Attack;

	// Token: 0x04006927 RID: 26919
	protected UUITexture BossHead;

	// Token: 0x04006928 RID: 26920
	protected UUISprite HeadBase;

	// Token: 0x04006929 RID: 26921
	protected UUISprite BossIcon;

	// Token: 0x0400692A RID: 26922
	protected UUISprite FinishIcon;

	// Token: 0x0400692B RID: 26923
	protected UUIItem StateAttack;

	// Token: 0x0400692C RID: 26924
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x020080B9 RID: 32953
	[NullableContext(0)]
	private static class EComponentBossHeadItem
	{
		// Token: 0x0402BC70 RID: 179312
		public const int Attack = 0;

		// Token: 0x0402BC71 RID: 179313
		public const int BossHead = 1;

		// Token: 0x0402BC72 RID: 179314
		public const int HeadBase = 2;

		// Token: 0x0402BC73 RID: 179315
		public const int BossIcon = 3;

		// Token: 0x0402BC74 RID: 179316
		public const int FinishIcon = 4;

		// Token: 0x0402BC75 RID: 179317
		public const int StateAttack = 5;
	}
}
