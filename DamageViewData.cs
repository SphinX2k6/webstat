using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02001AB2 RID: 6834
[NullableContext(1)]
[Nullable(0)]
public class DamageViewData
{
	// Token: 0x0600C3F2 RID: 50162 RVA: 0x0033B01C File Offset: 0x0033921C
	public void Initialize(DamageText damageTextConfig)
	{
		this.ConfigId = damageTextConfig.Id;
		this.DamageTextConfig = new DamageText?(damageTextConfig);
		this.CriticalNiagaraPath = damageTextConfig.CritNiagaraPath;
		this.MinRandomOffsetX = (float)damageTextConfig.MinDeviationX;
		this.MinRandomOffsetY = (float)damageTextConfig.MinDeviationY;
		this.MaxRandomOffsetX = (float)damageTextConfig.MaxDeviationX;
		this.MaxRandomOffsetY = (float)damageTextConfig.MaxDeviationX;
		this.TextColor = new FColor?(FColor.FromHex(damageTextConfig.TextColor));
		this.CriticalTextColor = new FColor?(FColor.FromHex(damageTextConfig.CritTextColor));
		this.StrokeColor = new FColor?(FColor.FromHex(damageTextConfig.StrokeColor));
		this.CriticalStrokeColor = new FColor?(FColor.FromHex(damageTextConfig.CritStrokeColor));
	}

	// Token: 0x0600C3F3 RID: 50163 RVA: 0x0033B0E3 File Offset: 0x003392E3
	public int GetConfigId()
	{
		return this.ConfigId;
	}

	// Token: 0x0600C3F4 RID: 50164 RVA: 0x0033B0EB File Offset: 0x003392EB
	public float GetRandomOffsetX()
	{
		return Singleton<MathUtils>.Instance.GetRandomFloatNumber(this.MinRandomOffsetX, this.MaxRandomOffsetX);
	}

	// Token: 0x0600C3F5 RID: 50165 RVA: 0x0033B103 File Offset: 0x00339303
	public float GetRandomOffsetY()
	{
		return Singleton<MathUtils>.Instance.GetRandomFloatNumber(this.MinRandomOffsetY, this.MaxRandomOffsetY);
	}

	// Token: 0x0600C3F6 RID: 50166 RVA: 0x0033B11B File Offset: 0x0033931B
	public FColor? GetTextColor()
	{
		return this.TextColor;
	}

	// Token: 0x0600C3F7 RID: 50167 RVA: 0x0033B123 File Offset: 0x00339323
	public FColor? GetCriticalTextColor()
	{
		return this.CriticalTextColor;
	}

	// Token: 0x0600C3F8 RID: 50168 RVA: 0x0033B12B File Offset: 0x0033932B
	public FColor? GetStrokeColor()
	{
		return this.StrokeColor;
	}

	// Token: 0x0600C3F9 RID: 50169 RVA: 0x0033B133 File Offset: 0x00339333
	public FColor? GetCriticalStrokeColor()
	{
		return this.CriticalStrokeColor;
	}

	// Token: 0x0600C3FA RID: 50170 RVA: 0x0033B13B File Offset: 0x0033933B
	public string GetCriticalNiagaraPath()
	{
		return this.CriticalNiagaraPath;
	}

	// Token: 0x0600C3FB RID: 50171 RVA: 0x0033B144 File Offset: 0x00339344
	public string GetSequencePath(bool bOwnPlayerDamage, bool bCritical, bool bCustomText)
	{
		if (bCustomText)
		{
			return this.DamageTextConfig.Value.DamageTextSequence;
		}
		if (bOwnPlayerDamage)
		{
			if (bCritical)
			{
				return this.DamageTextConfig.Value.OwnCriticalDamageSequence;
			}
			return this.DamageTextConfig.Value.OwnDamageSequence;
		}
		else
		{
			if (bCritical)
			{
				return this.DamageTextConfig.Value.MonsterCriticalDamageSequence;
			}
			return this.DamageTextConfig.Value.MonsterDamageSequence;
		}
	}

	// Token: 0x04005E08 RID: 24072
	public int ConfigId;

	// Token: 0x04005E09 RID: 24073
	public DamageText? DamageTextConfig;

	// Token: 0x04005E0A RID: 24074
	public float MinRandomOffsetX;

	// Token: 0x04005E0B RID: 24075
	public float MinRandomOffsetY;

	// Token: 0x04005E0C RID: 24076
	public float MaxRandomOffsetX;

	// Token: 0x04005E0D RID: 24077
	public float MaxRandomOffsetY;

	// Token: 0x04005E0E RID: 24078
	public FColor? TextColor;

	// Token: 0x04005E0F RID: 24079
	public FColor? CriticalTextColor;

	// Token: 0x04005E10 RID: 24080
	public FColor? StrokeColor;

	// Token: 0x04005E11 RID: 24081
	public FColor? CriticalStrokeColor;

	// Token: 0x04005E12 RID: 24082
	public string CriticalNiagaraPath = "";

	// Token: 0x04005E13 RID: 24083
	public int CriticalNiagaraId = -1;
}
