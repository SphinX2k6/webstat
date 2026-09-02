using System;
using System.Runtime.CompilerServices;

// Token: 0x020031E4 RID: 12772
[NullableContext(1)]
[Nullable(0)]
public readonly struct EMoveState : IEquatable<EMoveState>
{
	// Token: 0x0601A79E RID: 108446 RVA: 0x007D229A File Offset: 0x007D049A
	private EMoveState(string value)
	{
		this.Value = value;
	}

	// Token: 0x0601A7A0 RID: 108448 RVA: 0x007D230B File Offset: 0x007D050B
	public override string ToString()
	{
		return this.Value;
	}

	// Token: 0x0601A7A1 RID: 108449 RVA: 0x007D2313 File Offset: 0x007D0513
	public bool Equals(EMoveState other)
	{
		return this.Value == other.Value;
	}

	// Token: 0x0601A7A2 RID: 108450 RVA: 0x007D2328 File Offset: 0x007D0528
	public override bool Equals(object obj)
	{
		if (obj is EMoveState)
		{
			EMoveState other = (EMoveState)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x0601A7A3 RID: 108451 RVA: 0x007D234D File Offset: 0x007D054D
	public override int GetHashCode()
	{
		string value = this.Value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x0601A7A4 RID: 108452 RVA: 0x007D2360 File Offset: 0x007D0560
	public static bool operator ==(EMoveState left, EMoveState right)
	{
		return left.Equals(right);
	}

	// Token: 0x0601A7A5 RID: 108453 RVA: 0x007D236A File Offset: 0x007D056A
	public static bool operator !=(EMoveState left, EMoveState right)
	{
		return !left.Equals(right);
	}

	// Token: 0x0400D606 RID: 54790
	public readonly string Value;

	// Token: 0x0400D607 RID: 54791
	public static readonly EMoveState None = new EMoveState("none");

	// Token: 0x0400D608 RID: 54792
	public static readonly EMoveState Fly = new EMoveState("fly");

	// Token: 0x0400D609 RID: 54793
	public static readonly EMoveState Fall = new EMoveState("fall");

	// Token: 0x0400D60A RID: 54794
	public static readonly EMoveState Slide = new EMoveState("slide");

	// Token: 0x0400D60B RID: 54795
	public static readonly EMoveState Ski = new EMoveState("ski");

	// Token: 0x0400D60C RID: 54796
	public static readonly EMoveState Hook = new EMoveState("hook");

	// Token: 0x0400D60D RID: 54797
	public const string None_Value = "none";

	// Token: 0x0400D60E RID: 54798
	public const string Fly_Value = "fly";

	// Token: 0x0400D60F RID: 54799
	public const string Fall_Value = "fall";

	// Token: 0x0400D610 RID: 54800
	public const string Slide_Value = "slide";

	// Token: 0x0400D611 RID: 54801
	public const string Ski_Value = "ski";

	// Token: 0x0400D612 RID: 54802
	public const string Hook_Value = "hook";
}
