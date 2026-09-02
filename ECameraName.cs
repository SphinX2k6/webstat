using System;
using System.Runtime.CompilerServices;

// Token: 0x0200245E RID: 9310
[NullableContext(1)]
[Nullable(0)]
public readonly struct ECameraName : IEquatable<ECameraName>
{
	// Token: 0x060120E1 RID: 73953 RVA: 0x004F7D14 File Offset: 0x004F5F14
	private ECameraName(string value)
	{
		this._Value = value;
	}

	// Token: 0x060120E2 RID: 73954 RVA: 0x004F7D1D File Offset: 0x004F5F1D
	public override string ToString()
	{
		return this._Value;
	}

	// Token: 0x060120E3 RID: 73955 RVA: 0x004F7D25 File Offset: 0x004F5F25
	public bool Equals(ECameraName other)
	{
		return this._Value == other._Value;
	}

	// Token: 0x060120E4 RID: 73956 RVA: 0x004F7D38 File Offset: 0x004F5F38
	public override bool Equals(object obj)
	{
		if (obj is ECameraName)
		{
			ECameraName other = (ECameraName)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x060120E5 RID: 73957 RVA: 0x004F7D5D File Offset: 0x004F5F5D
	public override int GetHashCode()
	{
		string value = this._Value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x060120E6 RID: 73958 RVA: 0x004F7D70 File Offset: 0x004F5F70
	public static bool operator ==(ECameraName left, ECameraName right)
	{
		return left.Equals(right);
	}

	// Token: 0x060120E7 RID: 73959 RVA: 0x004F7D7A File Offset: 0x004F5F7A
	public static bool operator !=(ECameraName left, ECameraName right)
	{
		return !left.Equals(right);
	}

	// Token: 0x04008D07 RID: 36103
	private readonly string _Value;

	// Token: 0x04008D08 RID: 36104
	public static readonly ECameraName BlendCamera = new ECameraName("1001");

	// Token: 0x04008D09 RID: 36105
	public static readonly ECameraName PhantomBaseCamera = new ECameraName("1025");
}
