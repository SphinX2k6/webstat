using System;
using System.Runtime.CompilerServices;

// Token: 0x02000CFC RID: 3324
[NullableContext(1)]
[Nullable(0)]
public readonly struct EAddHatredReason : IEquatable<EAddHatredReason>
{
	// Token: 0x06004258 RID: 16984 RVA: 0x00074E4D File Offset: 0x0007304D
	private EAddHatredReason(string value)
	{
		this._Value = value;
	}

	// Token: 0x06004259 RID: 16985 RVA: 0x00074E56 File Offset: 0x00073056
	public override string ToString()
	{
		return this._Value;
	}

	// Token: 0x0600425A RID: 16986 RVA: 0x00074E5E File Offset: 0x0007305E
	public bool Equals(EAddHatredReason other)
	{
		return this._Value == other._Value;
	}

	// Token: 0x0600425B RID: 16987 RVA: 0x00074E74 File Offset: 0x00073074
	[NullableContext(2)]
	public override bool Equals(object obj)
	{
		if (obj is EAddHatredReason)
		{
			EAddHatredReason other = (EAddHatredReason)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x0600425C RID: 16988 RVA: 0x00074E99 File Offset: 0x00073099
	public override int GetHashCode()
	{
		string value = this._Value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x0600425D RID: 16989 RVA: 0x00074EAC File Offset: 0x000730AC
	public static bool operator ==(EAddHatredReason left, EAddHatredReason right)
	{
		return left.Equals(right);
	}

	// Token: 0x0600425E RID: 16990 RVA: 0x00074EB6 File Offset: 0x000730B6
	public static bool operator !=(EAddHatredReason left, EAddHatredReason right)
	{
		return !left.Equals(right);
	}

	// Token: 0x04001097 RID: 4247
	private readonly string _Value;

	// Token: 0x04001098 RID: 4248
	public const string None_Value = "None";

	// Token: 0x04001099 RID: 4249
	public static readonly EAddHatredReason None = new EAddHatredReason("None");

	// Token: 0x0400109A RID: 4250
	public const string Damage_Value = "Damage";

	// Token: 0x0400109B RID: 4251
	public static readonly EAddHatredReason Damage = new EAddHatredReason("Damage");

	// Token: 0x0400109C RID: 4252
	public const string Taunt_Value = "Taunt";

	// Token: 0x0400109D RID: 4253
	public static readonly EAddHatredReason Taunt = new EAddHatredReason("Taunt");

	// Token: 0x0400109E RID: 4254
	public const string Area_Value = "Area";

	// Token: 0x0400109F RID: 4255
	public static readonly EAddHatredReason Area = new EAddHatredReason("Area");

	// Token: 0x040010A0 RID: 4256
	public const string ChangeRole_Value = "ChangeRole";

	// Token: 0x040010A1 RID: 4257
	public static readonly EAddHatredReason ChangeRole = new EAddHatredReason("ChangeRole");

	// Token: 0x040010A2 RID: 4258
	public const string VisionMorphBegin_Value = "VisionMorphBegin";

	// Token: 0x040010A3 RID: 4259
	public static readonly EAddHatredReason VisionMorphBegin = new EAddHatredReason("VisionMorphBegin");

	// Token: 0x040010A4 RID: 4260
	public const string VisionMorphEnd_Value = "VisionMorphEnd";

	// Token: 0x040010A5 RID: 4261
	public static readonly EAddHatredReason VisionMorphEnd = new EAddHatredReason("VisionMorphEnd");

	// Token: 0x040010A6 RID: 4262
	public const string Blueprint_Value = "Blueprint";

	// Token: 0x040010A7 RID: 4263
	public static readonly EAddHatredReason Blueprint = new EAddHatredReason("Blueprint");

	// Token: 0x040010A8 RID: 4264
	public const string Shared_Value = "Shared";

	// Token: 0x040010A9 RID: 4265
	public static readonly EAddHatredReason Shared = new EAddHatredReason("Shared");
}
