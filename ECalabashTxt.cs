using System;
using System.Runtime.CompilerServices;

// Token: 0x020017E1 RID: 6113
[NullableContext(1)]
[Nullable(0)]
public readonly struct ECalabashTxt : IEquatable<ECalabashTxt>
{
	// Token: 0x0600AD96 RID: 44438 RVA: 0x002E31AB File Offset: 0x002E13AB
	private ECalabashTxt(string value)
	{
		this._Value = value;
	}

	// Token: 0x0600AD97 RID: 44439 RVA: 0x002E31B4 File Offset: 0x002E13B4
	public override string ToString()
	{
		return this._Value;
	}

	// Token: 0x0600AD98 RID: 44440 RVA: 0x002E31BC File Offset: 0x002E13BC
	public bool Equals(ECalabashTxt other)
	{
		return this._Value == other._Value;
	}

	// Token: 0x0600AD99 RID: 44441 RVA: 0x002E31D0 File Offset: 0x002E13D0
	public override bool Equals(object obj)
	{
		if (obj is ECalabashTxt)
		{
			ECalabashTxt other = (ECalabashTxt)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x0600AD9A RID: 44442 RVA: 0x002E31F5 File Offset: 0x002E13F5
	public override int GetHashCode()
	{
		string value = this._Value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x0600AD9B RID: 44443 RVA: 0x002E3208 File Offset: 0x002E1408
	public static bool operator ==(ECalabashTxt left, ECalabashTxt right)
	{
		return left.Equals(right);
	}

	// Token: 0x0600AD9C RID: 44444 RVA: 0x002E3212 File Offset: 0x002E1412
	public static bool operator !=(ECalabashTxt left, ECalabashTxt right)
	{
		return !left.Equals(right);
	}

	// Token: 0x04005210 RID: 21008
	private readonly string _Value;

	// Token: 0x04005211 RID: 21009
	public static readonly ECalabashTxt UpAbsorptionTargetAdvanced = new ECalabashTxt("UpAbsorptionTarget_Advanced");

	// Token: 0x04005212 RID: 21010
	public static readonly ECalabashTxt UpAbsorptionTargetJunior = new ECalabashTxt("UpAbsorptionTarget_Junior");

	// Token: 0x04005213 RID: 21011
	public static readonly ECalabashTxt UpAbsorptionTargetNameJunior = new ECalabashTxt("UpAbsorptionTargetName_Junior");
}
