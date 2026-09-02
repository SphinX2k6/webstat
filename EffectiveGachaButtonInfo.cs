using System;
using System.Runtime.CompilerServices;

// Token: 0x02001CFF RID: 7423
[NullableContext(2)]
[Nullable(0)]
public class EffectiveGachaButtonInfo
{
	// Token: 0x0600D9F5 RID: 55797 RVA: 0x003A7994 File Offset: 0x003A5B94
	public GachaTagInfo GetCustomTag()
	{
		if (!string.IsNullOrEmpty(this.TagCustomText))
		{
			return new GachaTagInfo(EGachaTagKind.Custom, this.TagCustomText, null);
		}
		return null;
	}

	// Token: 0x0600D9F6 RID: 55798 RVA: 0x003A79C8 File Offset: 0x003A5BC8
	public GachaTagInfo GetDiscountTag()
	{
		if (this.Consume == 0)
		{
			return new GachaTagInfo(EGachaTagKind.Free, null, null);
		}
		if (this.IsDiscount && this.OriginConsume != null && this.OriginConsume.Value > 0)
		{
			int value = (int)Math.Floor((double)((this.OriginConsume.Value - this.Consume) * 100) / (double)this.OriginConsume.Value);
			return new GachaTagInfo(EGachaTagKind.Discount, null, new int?(value));
		}
		return null;
	}

	// Token: 0x0600D9F7 RID: 55799 RVA: 0x003A7A4A File Offset: 0x003A5C4A
	[NullableContext(1)]
	public static EffectiveGachaButtonInfo MakeDiscount(int times, int consume, int originConsume, [Nullable(2)] string tagCustomText)
	{
		return new EffectiveGachaButtonInfo
		{
			Times = times,
			Consume = consume,
			IsDiscount = true,
			OriginConsume = new int?(originConsume),
			TagCustomText = tagCustomText
		};
	}

	// Token: 0x0600D9F8 RID: 55800 RVA: 0x003A7A79 File Offset: 0x003A5C79
	[NullableContext(1)]
	public static EffectiveGachaButtonInfo MakePlain(int times, int consume, [Nullable(2)] string tagCustomText)
	{
		return new EffectiveGachaButtonInfo
		{
			Times = times,
			Consume = consume,
			TagCustomText = tagCustomText
		};
	}

	// Token: 0x04006805 RID: 26629
	public int Times;

	// Token: 0x04006806 RID: 26630
	public int Consume;

	// Token: 0x04006807 RID: 26631
	public bool IsDiscount;

	// Token: 0x04006808 RID: 26632
	public int? OriginConsume;

	// Token: 0x04006809 RID: 26633
	public string TagCustomText;
}
