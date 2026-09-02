using System;
using System.Runtime.CompilerServices;

// Token: 0x020027E3 RID: 10211
[NullableContext(1)]
[Nullable(0)]
public readonly struct EResourceId : IEquatable<EResourceId>
{
	// Token: 0x060142B4 RID: 82612 RVA: 0x005A09BD File Offset: 0x0059EBBD
	private EResourceId(string value)
	{
		this._value = value;
	}

	// Token: 0x060142B5 RID: 82613 RVA: 0x005A09C6 File Offset: 0x0059EBC6
	public override string ToString()
	{
		return this._value;
	}

	// Token: 0x060142B6 RID: 82614 RVA: 0x005A09CE File Offset: 0x0059EBCE
	public bool Equals(EResourceId other)
	{
		return this._value == other._value;
	}

	// Token: 0x060142B7 RID: 82615 RVA: 0x005A09E4 File Offset: 0x0059EBE4
	[NullableContext(2)]
	public override bool Equals(object obj)
	{
		if (obj is EResourceId)
		{
			EResourceId other = (EResourceId)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x060142B8 RID: 82616 RVA: 0x005A0A09 File Offset: 0x0059EC09
	public override int GetHashCode()
	{
		string value = this._value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x060142B9 RID: 82617 RVA: 0x005A0A1C File Offset: 0x0059EC1C
	public static bool operator ==(EResourceId? left, EResourceId? right)
	{
		return left.Equals(right);
	}

	// Token: 0x060142BA RID: 82618 RVA: 0x005A0A31 File Offset: 0x0059EC31
	public static bool operator !=(EResourceId? left, EResourceId? right)
	{
		return !left.Equals(right);
	}

	// Token: 0x060142BB RID: 82619 RVA: 0x005A0A49 File Offset: 0x0059EC49
	public static implicit operator string(EResourceId id)
	{
		return id.ToString();
	}

	// Token: 0x04009D1F RID: 40223
	private readonly string _value;

	// Token: 0x04009D20 RID: 40224
	public static readonly EResourceId PlanRole = new EResourceId("UiItem_PlanRole");

	// Token: 0x04009D21 RID: 40225
	public static readonly EResourceId PlanWeapon = new EResourceId("UiItem_PlanWeapon");

	// Token: 0x04009D22 RID: 40226
	public static readonly EResourceId PlanVision = new EResourceId("UiItem_PlanVision");

	// Token: 0x04009D23 RID: 40227
	public static readonly EResourceId PlanSkill = new EResourceId("UiItem_PlanRoleSkill");
}
