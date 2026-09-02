using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D36 RID: 7478
[NullableContext(1)]
[Nullable(0)]
public class SimpleBossStateItem : UiPanelBase
{
	// Token: 0x0600DC33 RID: 56371 RVA: 0x003B30E4 File Offset: 0x003B12E4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUISprite)),
			new ValueTuple<int, Type>(10, typeof(UUISprite)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUISprite))
		};
	}

	// Token: 0x0600DC34 RID: 56372 RVA: 0x003B31B0 File Offset: 0x003B13B0
	protected override void OnStart()
	{
		this.BossNameText = base.GetText(1);
		this.HpBarSprite = base.GetSprite(7);
		this.ShieldBarSprite = base.GetSprite(10);
		this.HpBufferSprite = base.GetSprite(9);
		base.GetSprite(14).SetUIActive(false);
	}

	// Token: 0x0600DC35 RID: 56373 RVA: 0x003B3201 File Offset: 0x003B1401
	protected override void OnBeforeShow()
	{
		base.GetItem(11).SetUIActive(false);
		base.GetText(0).SetUIActive(false);
	}

	// Token: 0x0600DC36 RID: 56374 RVA: 0x003B321E File Offset: 0x003B141E
	protected override void OnBeforeHide()
	{
		this.StopBarLerpAnimation();
	}

	// Token: 0x0600DC37 RID: 56375 RVA: 0x003B3228 File Offset: 0x003B1428
	private float GetSafeHpPercent(FKSC_HeadHpContext headInfo)
	{
		float num = (float)headInfo.CurHp / (float)headInfo.MaxHp;
		if (num <= 1f)
		{
			return num;
		}
		return 1f;
	}

	// Token: 0x0600DC38 RID: 56376 RVA: 0x003B3254 File Offset: 0x003B1454
	public void RefreshBossInfo(FKSC_HeadHpContext headInfo)
	{
		this.ShieldMax = (float)headInfo.Shield;
		float safeHpPercent = this.GetSafeHpPercent(headInfo);
		this.HpStateMachine.TargetPercent = safeHpPercent;
		this.HpStateMachine.CurrentPercent = safeHpPercent;
	}

	// Token: 0x0600DC39 RID: 56377 RVA: 0x003B328E File Offset: 0x003B148E
	public void SetBossName(string bossName)
	{
		this.BossNameText.ShowTextNew(bossName);
	}

	// Token: 0x0600DC3A RID: 56378 RVA: 0x003B329C File Offset: 0x003B149C
	public void UpdateHeadStateInfo(FKSC_HeadHpContext headInfo)
	{
		float safeHpPercent = this.GetSafeHpPercent(headInfo);
		this.HpBarSprite.SetFillAmount(safeHpPercent);
		this.PlayBarAnimation(safeHpPercent);
		float num = (this.ShieldMax == 0f) ? 0f : ((float)headInfo.Shield / this.ShieldMax);
		this.SetShieldBarPercent((num > 1f) ? 1f : num);
	}

	// Token: 0x0600DC3B RID: 56379 RVA: 0x003B3300 File Offset: 0x003B1500
	private void PlayBarAnimation(float hpPercent)
	{
		if (hpPercent < this.HpStateMachine.TargetPercent)
		{
			bool flag = this.HpStateMachine.IsOriginState();
			this.HpStateMachine.GetHit(hpPercent, this.HpStateMachine.CurrentPercent);
			if (flag && !this.HpStateMachine.IsOriginState())
			{
				this.SetBarBufferPercent(this.HpStateMachine.CurrentPercent);
			}
			base.GetItem(8).SetUIActive(true);
		}
	}

	// Token: 0x0600DC3C RID: 56380 RVA: 0x003B336A File Offset: 0x003B156A
	private void StopBarLerpAnimation()
	{
		base.GetItem(8).SetUIActive(false);
		this.HpStateMachine.Reset();
	}

	// Token: 0x0600DC3D RID: 56381 RVA: 0x003B3384 File Offset: 0x003B1584
	private void SetBarBufferPercent(float percent)
	{
		UUISprite hpBufferSprite = this.HpBufferSprite;
		if (hpBufferSprite == null)
		{
			return;
		}
		hpBufferSprite.SetFillAmount(percent);
	}

	// Token: 0x0600DC3E RID: 56382 RVA: 0x003B3397 File Offset: 0x003B1597
	private void SetShieldBarPercent(float percent)
	{
		if (percent > 0f)
		{
			this.ShieldBarSprite.SetFillAmount(percent);
			this.ShieldBarSprite.SetUIActive(true);
			return;
		}
		this.ShieldBarSprite.SetUIActive(false);
	}

	// Token: 0x0600DC3F RID: 56383 RVA: 0x003B33C8 File Offset: 0x003B15C8
	public void OnTick(float delta)
	{
		if (!this.HpStateMachine.IsOriginState())
		{
			float num = this.HpStateMachine.UpdatePercent(delta);
			if (num < 0f)
			{
				this.StopBarLerpAnimation();
				return;
			}
			if (num <= 1f)
			{
				this.SetBarBufferPercent(num);
			}
		}
	}

	// Token: 0x0400695C RID: 26972
	[Nullable(2)]
	private UUIText BossNameText;

	// Token: 0x0400695D RID: 26973
	[Nullable(2)]
	private UUISprite HpBarSprite;

	// Token: 0x0400695E RID: 26974
	[Nullable(2)]
	private UUISprite ShieldBarSprite;

	// Token: 0x0400695F RID: 26975
	[Nullable(2)]
	private UUISprite HpBufferSprite;

	// Token: 0x04006960 RID: 26976
	private float ShieldMax;

	// Token: 0x04006961 RID: 26977
	private readonly HpBufferStateMachine HpStateMachine = new HpBufferStateMachine();

	// Token: 0x020080C8 RID: 32968
	[NullableContext(0)]
	private static class EChildComponentType
	{
		// Token: 0x0402BCB4 RID: 179380
		public const int BossLevelText = 0;

		// Token: 0x0402BCB5 RID: 179381
		public const int BossNameText = 1;

		// Token: 0x0402BCB6 RID: 179382
		public const int RageItem = 2;

		// Token: 0x0402BCB7 RID: 179383
		public const int ToughBg = 3;

		// Token: 0x0402BCB8 RID: 179384
		public const int RageBar = 4;

		// Token: 0x0402BCB9 RID: 179385
		public const int HpShieldBarItem = 5;

		// Token: 0x0402BCBA RID: 179386
		public const int HpBarItem = 6;

		// Token: 0x0402BCBB RID: 179387
		public const int NormalHpBarSprite = 7;

		// Token: 0x0402BCBC RID: 179388
		public const int BarBufferCanvas = 8;

		// Token: 0x0402BCBD RID: 179389
		public const int BarBufferSprite = 9;

		// Token: 0x0402BCBE RID: 179390
		public const int ShieldBarSprite = 10;

		// Token: 0x0402BCBF RID: 179391
		public const int ToughItem = 11;

		// Token: 0x0402BCC0 RID: 179392
		public const int MaxHardnessEffect = 12;

		// Token: 0x0402BCC1 RID: 179393
		public const int BuffHorizontalItem = 13;

		// Token: 0x0402BCC2 RID: 179394
		public const int HpLight = 14;

		// Token: 0x0402BCC3 RID: 179395
		public const int HardnessNormal = 15;

		// Token: 0x0402BCC4 RID: 179396
		public const int HardnessBreak = 16;

		// Token: 0x0402BCC5 RID: 179397
		public const int FallDownItem = 17;

		// Token: 0x0402BCC6 RID: 179398
		public const int FallDownBar = 18;

		// Token: 0x0402BCC7 RID: 179399
		public const int FallDownBarSign = 19;

		// Token: 0x0402BCC8 RID: 179400
		public const int RageReduceLittle = 20;

		// Token: 0x0402BCC9 RID: 179401
		public const int HpFlicker = 21;

		// Token: 0x0402BCCA RID: 179402
		public const int RageReduceLargeCanvas = 22;

		// Token: 0x0402BCCB RID: 179403
		public const int RageReduceLarge = 23;

		// Token: 0x0402BCCC RID: 179404
		public const int RageEmpty = 24;

		// Token: 0x0402BCCD RID: 179405
		public const int AnimSmallHit = 25;

		// Token: 0x0402BCCE RID: 179406
		public const int AnimBigHit = 26;

		// Token: 0x0402BCCF RID: 179407
		public const int AnimToughStart = 27;

		// Token: 0x0402BCD0 RID: 179408
		public const int AnimToughHit = 28;

		// Token: 0x0402BCD1 RID: 179409
		public const int AnimToughFlick = 29;

		// Token: 0x0402BCD2 RID: 179410
		public const int AnimToughClose = 30;

		// Token: 0x0402BCD3 RID: 179411
		public const int AnimBreak = 31;

		// Token: 0x0402BCD4 RID: 179412
		public const int ExtraItem = 32;

		// Token: 0x0402BCD5 RID: 179413
		public const int BloodModeIcon = 33;

		// Token: 0x0402BCD6 RID: 179414
		public const int WeaknessContainer = 34;

		// Token: 0x0402BCD7 RID: 179415
		public const int HpWeaknessNode = 35;

		// Token: 0x0402BCD8 RID: 179416
		public const int HpWeaknessSprite1 = 36;

		// Token: 0x0402BCD9 RID: 179417
		public const int HpWeaknessEffect = 37;

		// Token: 0x0402BCDA RID: 179418
		public const int AniHpWeaknessFull = 38;

		// Token: 0x0402BCDB RID: 179419
		public const int AniHpWeaknessBreak = 39;
	}
}
