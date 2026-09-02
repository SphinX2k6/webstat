using System;
using System.Runtime.CompilerServices;

// Token: 0x02002551 RID: 9553
[NullableContext(1)]
[Nullable(0)]
public readonly struct ETextKey : IEquatable<ETextKey>
{
	// Token: 0x0601294E RID: 76110 RVA: 0x0051E4EA File Offset: 0x0051C6EA
	private ETextKey(string value)
	{
		this._Value = value;
	}

	// Token: 0x0601294F RID: 76111 RVA: 0x0051E4F3 File Offset: 0x0051C6F3
	public override string ToString()
	{
		return this._Value;
	}

	// Token: 0x06012950 RID: 76112 RVA: 0x0051E4FB File Offset: 0x0051C6FB
	public bool Equals(ETextKey other)
	{
		return this._Value == other._Value;
	}

	// Token: 0x06012951 RID: 76113 RVA: 0x0051E510 File Offset: 0x0051C710
	public override bool Equals(object obj)
	{
		if (obj is ETextKey)
		{
			ETextKey other = (ETextKey)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x06012952 RID: 76114 RVA: 0x0051E535 File Offset: 0x0051C735
	public override int GetHashCode()
	{
		string value = this._Value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x06012953 RID: 76115 RVA: 0x0051E548 File Offset: 0x0051C748
	public static bool operator ==(ETextKey left, ETextKey right)
	{
		return left.Equals(right);
	}

	// Token: 0x06012954 RID: 76116 RVA: 0x0051E552 File Offset: 0x0051C752
	public static bool operator !=(ETextKey left, ETextKey right)
	{
		return !left.Equals(right);
	}

	// Token: 0x040090E3 RID: 37091
	private readonly string _Value;

	// Token: 0x040090E4 RID: 37092
	public static readonly ETextKey VisionIdentifyLock = new ETextKey("VisionIdentifyLock");

	// Token: 0x040090E5 RID: 37093
	public static readonly ETextKey VisionRefineNotOpen = new ETextKey("Text_PhantomRefineNotOpen_Text");

	// Token: 0x040090E6 RID: 37094
	public static readonly ETextKey VisionRefineConditionUnfit = new ETextKey("Text_PhantomRefineConditionUnfit_Text");
}
