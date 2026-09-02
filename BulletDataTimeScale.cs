using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;

// Token: 0x02002DA8 RID: 11688
[NullableContext(1)]
[Nullable(0)]
public class BulletDataTimeScale
{
	// Token: 0x17001F8E RID: 8078
	// (get) Token: 0x06017985 RID: 96645 RVA: 0x0069003D File Offset: 0x0068E23D
	public bool AreaTimeScale
	{
		get
		{
			if (this.AreaTimeScaleInternal == null)
			{
				this.AreaTimeScaleInternal = new bool?(this.Data.区域受击者时间膨胀);
			}
			return this.AreaTimeScaleInternal.Value;
		}
	}

	// Token: 0x17001F8F RID: 8079
	// (get) Token: 0x06017986 RID: 96646 RVA: 0x0069006D File Offset: 0x0068E26D
	public STimeScale TimeScaleOnHit
	{
		get
		{
			if (this.TimeScaleOnHitInternal == null)
			{
				this.TimeScaleOnHitInternal = this.Data.受击顿帧;
			}
			return this.TimeScaleOnHitInternal;
		}
	}

	// Token: 0x17001F90 RID: 8080
	// (get) Token: 0x06017987 RID: 96647 RVA: 0x00690094 File Offset: 0x0068E294
	public bool ForceBulletTimeScaleInArea
	{
		get
		{
			if (this.ForceBulletTimeScaleInAreaInternal == null)
			{
				this.ForceBulletTimeScaleInAreaInternal = new bool?(this.Data.强制影响区域内子弹);
			}
			return this.ForceBulletTimeScaleInAreaInternal.Value;
		}
	}

	// Token: 0x17001F91 RID: 8081
	// (get) Token: 0x06017988 RID: 96648 RVA: 0x006900C4 File Offset: 0x0068E2C4
	public STimeScale TimeScaleOnAttack
	{
		get
		{
			if (this.TimeScaleOnAttackInternal == null)
			{
				this.TimeScaleOnAttackInternal = this.Data.攻击顿帧;
			}
			return this.TimeScaleOnAttackInternal;
		}
	}

	// Token: 0x17001F92 RID: 8082
	// (get) Token: 0x06017989 RID: 96649 RVA: 0x006900EB File Offset: 0x0068E2EB
	public bool TimeScaleOnAttackIgnoreAttacker
	{
		get
		{
			if (this.TimeScaleOnAttackIgnoreAttackerInternal == null)
			{
				this.TimeScaleOnAttackIgnoreAttackerInternal = new bool?(this.Data.攻击顿帧忽略攻击者);
			}
			return this.TimeScaleOnAttackIgnoreAttackerInternal.Value;
		}
	}

	// Token: 0x17001F93 RID: 8083
	// (get) Token: 0x0601798A RID: 96650 RVA: 0x0069011B File Offset: 0x0068E31B
	public float TimeScaleEffectImmune
	{
		get
		{
			if (this.TimeScaleEffectImmuneInternal == null)
			{
				this.TimeScaleEffectImmuneInternal = new float?(this.Data.时间膨胀失效);
			}
			return this.TimeScaleEffectImmuneInternal.Value;
		}
	}

	// Token: 0x17001F94 RID: 8084
	// (get) Token: 0x0601798B RID: 96651 RVA: 0x0069014B File Offset: 0x0068E34B
	public bool TimeScaleWithAttacker
	{
		get
		{
			if (this.TimeScaleWithAttackerInternal == null)
			{
				this.TimeScaleWithAttackerInternal = new bool?(this.Data.是否跟随攻击者顿帧);
			}
			return this.TimeScaleWithAttackerInternal.Value;
		}
	}

	// Token: 0x17001F95 RID: 8085
	// (get) Token: 0x0601798C RID: 96652 RVA: 0x0069017C File Offset: 0x0068E37C
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] CharacterCustomKeyTimeScale
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			if (!this.CharacterCustomKeyTimeScaleInit)
			{
				this.CharacterCustomKeyTimeScaleInit = true;
				string 自定义连携顿帧单位key = this.Data.自定义连携顿帧单位key;
				if (!string.IsNullOrEmpty(自定义连携顿帧单位key))
				{
					string[] array = 自定义连携顿帧单位key.Split(',', StringSplitOptions.None);
					if (array.Length != 0)
					{
						this.CharacterCustomKeyTimeScaleInternal = array;
					}
				}
			}
			return this.CharacterCustomKeyTimeScaleInternal;
		}
	}

	// Token: 0x17001F96 RID: 8086
	// (get) Token: 0x0601798D RID: 96653 RVA: 0x006901C7 File Offset: 0x0068E3C7
	public STimeScale AttackerTimeScaleOnHitWeakPoint
	{
		get
		{
			if (this.AttackerTimeScaleOnHitWeakPointInternal == null)
			{
				this.AttackerTimeScaleOnHitWeakPointInternal = this.Data.命中弱点攻击者顿帧;
			}
			return this.AttackerTimeScaleOnHitWeakPointInternal;
		}
	}

	// Token: 0x17001F97 RID: 8087
	// (get) Token: 0x0601798E RID: 96654 RVA: 0x006901EE File Offset: 0x0068E3EE
	public STimeScale VictimTimeScaleOnHitWeakPoint
	{
		get
		{
			if (this.VictimTimeScaleOnHitWeakPointInternal == null)
			{
				this.VictimTimeScaleOnHitWeakPointInternal = this.Data.命中弱点受击者顿帧;
			}
			return this.VictimTimeScaleOnHitWeakPointInternal;
		}
	}

	// Token: 0x17001F98 RID: 8088
	// (get) Token: 0x0601798F RID: 96655 RVA: 0x00690215 File Offset: 0x0068E415
	public bool RemoveHitTimeScaleOnDestroy
	{
		get
		{
			if (this.RemoveTimeScaleOnDestroyInternal == null)
			{
				this.RemoveTimeScaleOnDestroyInternal = new bool?(this.Data.子弹销毁时移除受击顿帧);
			}
			return this.RemoveTimeScaleOnDestroyInternal.Value;
		}
	}

	// Token: 0x06017990 RID: 96656 RVA: 0x00690245 File Offset: 0x0068E445
	public BulletDataTimeScale(SReBulletDataTime data)
	{
		this.Data = data;
	}

	// Token: 0x0400B560 RID: 46432
	private readonly SReBulletDataTime Data;

	// Token: 0x0400B561 RID: 46433
	private bool? AreaTimeScaleInternal;

	// Token: 0x0400B562 RID: 46434
	[Nullable(2)]
	private STimeScale TimeScaleOnHitInternal;

	// Token: 0x0400B563 RID: 46435
	private bool? ForceBulletTimeScaleInAreaInternal;

	// Token: 0x0400B564 RID: 46436
	[Nullable(2)]
	private STimeScale TimeScaleOnAttackInternal;

	// Token: 0x0400B565 RID: 46437
	private bool? TimeScaleOnAttackIgnoreAttackerInternal;

	// Token: 0x0400B566 RID: 46438
	private float? TimeScaleEffectImmuneInternal;

	// Token: 0x0400B567 RID: 46439
	private bool? TimeScaleWithAttackerInternal;

	// Token: 0x0400B568 RID: 46440
	private bool CharacterCustomKeyTimeScaleInit;

	// Token: 0x0400B569 RID: 46441
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private string[] CharacterCustomKeyTimeScaleInternal;

	// Token: 0x0400B56A RID: 46442
	[Nullable(2)]
	private STimeScale AttackerTimeScaleOnHitWeakPointInternal;

	// Token: 0x0400B56B RID: 46443
	[Nullable(2)]
	private STimeScale VictimTimeScaleOnHitWeakPointInternal;

	// Token: 0x0400B56C RID: 46444
	private bool? RemoveTimeScaleOnDestroyInternal;
}
