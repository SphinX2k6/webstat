using System;
using System.Runtime.CompilerServices;

// Token: 0x02002C63 RID: 11363
[NullableContext(1)]
[Nullable(0)]
public readonly struct ERoleFadeCurveDefine : IEquatable<ERoleFadeCurveDefine>
{
	// Token: 0x06016CE0 RID: 93408 RVA: 0x006531EF File Offset: 0x006513EF
	private ERoleFadeCurveDefine(string value)
	{
		this._value = value;
	}

	// Token: 0x06016CE1 RID: 93409 RVA: 0x006531F8 File Offset: 0x006513F8
	public override string ToString()
	{
		return this._value;
	}

	// Token: 0x06016CE2 RID: 93410 RVA: 0x00653200 File Offset: 0x00651400
	public bool Equals(ERoleFadeCurveDefine other)
	{
		return this._value == other._value;
	}

	// Token: 0x06016CE3 RID: 93411 RVA: 0x00653214 File Offset: 0x00651414
	[NullableContext(2)]
	public override bool Equals(object obj)
	{
		if (obj is ERoleFadeCurveDefine)
		{
			ERoleFadeCurveDefine other = (ERoleFadeCurveDefine)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x06016CE4 RID: 93412 RVA: 0x00653239 File Offset: 0x00651439
	public override int GetHashCode()
	{
		string value = this._value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x06016CE5 RID: 93413 RVA: 0x0065324C File Offset: 0x0065144C
	public static bool operator ==(ERoleFadeCurveDefine? left, ERoleFadeCurveDefine? right)
	{
		return left.Equals(right);
	}

	// Token: 0x06016CE6 RID: 93414 RVA: 0x00653261 File Offset: 0x00651461
	public static bool operator !=(ERoleFadeCurveDefine? left, ERoleFadeCurveDefine? right)
	{
		return !left.Equals(right);
	}

	// Token: 0x06016CE7 RID: 93415 RVA: 0x00653279 File Offset: 0x00651479
	public static implicit operator string(ERoleFadeCurveDefine def)
	{
		return def.ToString();
	}

	// Token: 0x0400AFA8 RID: 44968
	private readonly string _value;

	// Token: 0x0400AFA9 RID: 44969
	public static readonly ERoleFadeCurveDefine None = new ERoleFadeCurveDefine("None");

	// Token: 0x0400AFAA RID: 44970
	public static readonly ERoleFadeCurveDefine RoleFadeInCurve = new ERoleFadeCurveDefine("RoleFadeInCurve");

	// Token: 0x0400AFAB RID: 44971
	public static readonly ERoleFadeCurveDefine RoleFadeOutCurve = new ERoleFadeCurveDefine("RoleFadeOutCurve");

	// Token: 0x0400AFAC RID: 44972
	public static readonly ERoleFadeCurveDefine WeaponSkinRoleFadeInCurve = new ERoleFadeCurveDefine("WeaponSkinRoleFadeInCurve");

	// Token: 0x0400AFAD RID: 44973
	public static readonly ERoleFadeCurveDefine WeaponSkinRoleFadeOutCurve = new ERoleFadeCurveDefine("WeaponSkinRoleFadeOutCurve");

	// Token: 0x0400AFAE RID: 44974
	public static readonly ERoleFadeCurveDefine FlySkinRoleFadeInCurve = new ERoleFadeCurveDefine("FlySkinRoleFadeInCurve");

	// Token: 0x0400AFAF RID: 44975
	public static readonly ERoleFadeCurveDefine FlySkinRoleFadeOutCurve = new ERoleFadeCurveDefine("FlySkinRoleFadeOutCurve");

	// Token: 0x0400AFB0 RID: 44976
	public static readonly ERoleFadeCurveDefine TerminalSkinRoleFadeInCurve = new ERoleFadeCurveDefine("TerminalSkinRoleFadeInCurve");

	// Token: 0x0400AFB1 RID: 44977
	public static readonly ERoleFadeCurveDefine TerminalSkinRoleFadeOutCurve = new ERoleFadeCurveDefine("TerminalSkinRoleFadeOutCurve");
}
