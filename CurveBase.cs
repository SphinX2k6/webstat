using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BF8 RID: 3064
public abstract class CurveBase
{
	// Token: 0x060032AB RID: 12971 RVA: 0x00024144 File Offset: 0x00022344
	[NullableContext(1)]
	public CurveBase(params float[] @params)
	{
	}

	// Token: 0x060032AC RID: 12972 RVA: 0x0002414C File Offset: 0x0002234C
	public float GetCurrentValue(float key)
	{
		return this.GetCurrentValueInternal(Singleton<MathUtils>.Instance.Clamp(key, 0f, 1f));
	}

	// Token: 0x060032AD RID: 12973 RVA: 0x00024169 File Offset: 0x00022369
	public virtual float GetCurrentValueInternal(float key)
	{
		return 0f;
	}

	// Token: 0x060032AE RID: 12974 RVA: 0x00024170 File Offset: 0x00022370
	public float GetOffsetValue(float key, float delta)
	{
		return this.GetCurrentValue(key + delta) - this.GetCurrentValue(key);
	}

	// Token: 0x060032AF RID: 12975 RVA: 0x00024184 File Offset: 0x00022384
	public float GetOffsetRate(float key, float delta)
	{
		if (key >= 1f)
		{
			return 1f;
		}
		float currentValue = this.GetCurrentValue(key);
		return (this.GetCurrentValue(key + delta) - currentValue) / (1f - currentValue);
	}
}
