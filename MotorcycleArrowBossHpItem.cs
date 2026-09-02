using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D2C RID: 7468
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleArrowBossHpItem : UiPanelBase
{
	// Token: 0x0600DBEF RID: 56303 RVA: 0x003B1DA4 File Offset: 0x003AFFA4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIArtText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIArtText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
	}

	// Token: 0x0600DBF0 RID: 56304 RVA: 0x003B1E40 File Offset: 0x003B0040
	protected override void OnStart()
	{
		this.HpArtText = base.GetArtText(1);
		this.ShieldArtText = base.GetArtText(3);
		this.TimeText = base.GetText(5);
		this.HpSequencePlayer = new LevelSequencePlayer(base.GetItem(0));
		this.ShieldSequencePlayer = new LevelSequencePlayer(base.GetItem(2));
		this.HpDigitScroll.Init(0f, 0f, 500f);
		this.ShieldDigitScroll.Init(0f, 0f, 500f);
	}

	// Token: 0x0600DBF1 RID: 56305 RVA: 0x003B1ECC File Offset: 0x003B00CC
	[NullableContext(1)]
	public void UpdateHeadStateInfo(FKSC_HeadHpContext headInfo, bool isScroll = true)
	{
		if (isScroll)
		{
			float num = this.HpDigitScroll.SetTarget((float)headInfo.CurHp);
			float num2 = this.ShieldDigitScroll.SetTarget((float)headInfo.Shield);
			if (num < 0f)
			{
				LevelSequencePlayer hpSequencePlayer = this.HpSequencePlayer;
				if (hpSequencePlayer != null)
				{
					hpSequencePlayer.PlayOrReplaySequenceByName("Hit", false, null);
				}
			}
			if (num2 < 0f)
			{
				LevelSequencePlayer shieldSequencePlayer = this.ShieldSequencePlayer;
				if (shieldSequencePlayer != null)
				{
					shieldSequencePlayer.PlayOrReplaySequenceByName("Hit", false, null);
				}
			}
		}
		else
		{
			this.HpDigitScroll.Reset((float)headInfo.CurHp);
			this.ShieldDigitScroll.Reset((float)headInfo.Shield);
			base.GetItem(2).SetUIActive(headInfo.Shield > 0);
		}
		UUIArtText hpArtText = this.HpArtText;
		if (hpArtText != null)
		{
			hpArtText.SetText(MotorcycleUtil.CompactNumberFormat(this.HpDigitScroll.Current));
		}
		UUIArtText shieldArtText = this.ShieldArtText;
		if (shieldArtText == null)
		{
			return;
		}
		shieldArtText.SetText(MotorcycleUtil.CompactNumberFormat(this.ShieldDigitScroll.Current));
	}

	// Token: 0x0600DBF2 RID: 56306 RVA: 0x003B1FCC File Offset: 0x003B01CC
	public void OnTick(float delta)
	{
		MotorcycleArrowSubModel motorcycleArrowSubModel = (MotorcycleArrowSubModel)ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
		float num = (float)motorcycleArrowSubModel.BossFightTime - (float)Singleton<Time>.Instance.WorldTimeSeconds + (float)motorcycleArrowSubModel.BossFightStartTime;
		UUIText timeText = this.TimeText;
		if (timeText != null)
		{
			timeText.SetText(MotorcycleUtil.TimeFormat((num < 0f) ? 0f : num), true);
		}
		if (!this.HpDigitScroll.IsFinished())
		{
			float num2 = this.HpDigitScroll.Tick(delta);
			UUIArtText hpArtText = this.HpArtText;
			if (hpArtText != null)
			{
				hpArtText.SetText(MotorcycleUtil.CompactNumberFormat(num2));
			}
		}
		if (!this.ShieldDigitScroll.IsFinished())
		{
			float num3 = this.ShieldDigitScroll.Tick(delta);
			UUIArtText shieldArtText = this.ShieldArtText;
			if (shieldArtText == null)
			{
				return;
			}
			shieldArtText.SetText(MotorcycleUtil.CompactNumberFormat(num3));
		}
	}

	// Token: 0x0400692D RID: 26925
	private const int SCROLL_DURATION = 500;

	// Token: 0x0400692E RID: 26926
	protected UUIArtText HpArtText;

	// Token: 0x0400692F RID: 26927
	protected UUIArtText ShieldArtText;

	// Token: 0x04006930 RID: 26928
	protected UUIText TimeText;

	// Token: 0x04006931 RID: 26929
	[Nullable(1)]
	private readonly DigitScroll HpDigitScroll = new DigitScroll();

	// Token: 0x04006932 RID: 26930
	[Nullable(1)]
	private readonly DigitScroll ShieldDigitScroll = new DigitScroll();

	// Token: 0x04006933 RID: 26931
	private LevelSequencePlayer HpSequencePlayer;

	// Token: 0x04006934 RID: 26932
	private LevelSequencePlayer ShieldSequencePlayer;

	// Token: 0x020080BA RID: 32954
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BC76 RID: 179318
		public const int ItemHp = 0;

		// Token: 0x0402BC77 RID: 179319
		public const int ArtTextMonsterHp = 1;

		// Token: 0x0402BC78 RID: 179320
		public const int ItemShield = 2;

		// Token: 0x0402BC79 RID: 179321
		public const int ArtTextShield = 3;

		// Token: 0x0402BC7A RID: 179322
		public const int ItemTime = 4;

		// Token: 0x0402BC7B RID: 179323
		public const int TextTime = 5;
	}
}
