using System;
using System.Runtime.CompilerServices;

// Token: 0x0200209E RID: 8350
[NullableContext(1)]
[Nullable(0)]
public readonly struct EReignsCardType : IEquatable<EReignsCardType>
{
	// Token: 0x0600FED5 RID: 65237 RVA: 0x0045E854 File Offset: 0x0045CA54
	private EReignsCardType(string value)
	{
		this._Value = value;
	}

	// Token: 0x0600FED6 RID: 65238 RVA: 0x0045E85D File Offset: 0x0045CA5D
	public override string ToString()
	{
		return this._Value;
	}

	// Token: 0x0600FED7 RID: 65239 RVA: 0x0045E865 File Offset: 0x0045CA65
	public bool Equals(EReignsCardType other)
	{
		return this._Value == other._Value;
	}

	// Token: 0x0600FED8 RID: 65240 RVA: 0x0045E878 File Offset: 0x0045CA78
	public override bool Equals(object obj)
	{
		if (obj is EReignsCardType)
		{
			EReignsCardType other = (EReignsCardType)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x0600FED9 RID: 65241 RVA: 0x0045E89D File Offset: 0x0045CA9D
	public override int GetHashCode()
	{
		string value = this._Value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x0600FEDA RID: 65242 RVA: 0x0045E8B0 File Offset: 0x0045CAB0
	public static bool operator ==(EReignsCardType left, EReignsCardType right)
	{
		return left.Equals(right);
	}

	// Token: 0x0600FEDB RID: 65243 RVA: 0x0045E8BA File Offset: 0x0045CABA
	public static bool operator !=(EReignsCardType left, EReignsCardType right)
	{
		return !left.Equals(right);
	}

	// Token: 0x04007A37 RID: 31287
	private readonly string _Value;

	// Token: 0x04007A38 RID: 31288
	public static readonly EReignsCardType OptionResultCard = new EReignsCardType("OptionCard");

	// Token: 0x04007A39 RID: 31289
	public static readonly EReignsCardType AchievementResultCard = new EReignsCardType("AchievementCard");

	// Token: 0x04007A3A RID: 31290
	public static readonly EReignsCardType Settlement = new EReignsCardType("Settlement");

	// Token: 0x04007A3B RID: 31291
	public static readonly EReignsCardType StaticImage = new EReignsCardType("StaticImage");

	// Token: 0x04007A3C RID: 31292
	public static readonly EReignsCardType BuffCard = new EReignsCardType("BuffCard");
}
