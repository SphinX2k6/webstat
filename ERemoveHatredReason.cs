using System;
using System.Runtime.CompilerServices;

// Token: 0x02000CFD RID: 3325
[NullableContext(1)]
[Nullable(0)]
public readonly struct ERemoveHatredReason : IEquatable<ERemoveHatredReason>
{
	// Token: 0x06004260 RID: 16992 RVA: 0x00074F58 File Offset: 0x00073158
	private ERemoveHatredReason(string value)
	{
		this._Value = value;
	}

	// Token: 0x06004261 RID: 16993 RVA: 0x00074F61 File Offset: 0x00073161
	public override string ToString()
	{
		return this._Value;
	}

	// Token: 0x06004262 RID: 16994 RVA: 0x00074F69 File Offset: 0x00073169
	public bool Equals(ERemoveHatredReason other)
	{
		return this._Value == other._Value;
	}

	// Token: 0x06004263 RID: 16995 RVA: 0x00074F7C File Offset: 0x0007317C
	[NullableContext(2)]
	public override bool Equals(object obj)
	{
		if (obj is ERemoveHatredReason)
		{
			ERemoveHatredReason other = (ERemoveHatredReason)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x06004264 RID: 16996 RVA: 0x00074FA1 File Offset: 0x000731A1
	public override int GetHashCode()
	{
		string value = this._Value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x06004265 RID: 16997 RVA: 0x00074FB4 File Offset: 0x000731B4
	public static bool operator ==(ERemoveHatredReason left, ERemoveHatredReason right)
	{
		return left.Equals(right);
	}

	// Token: 0x06004266 RID: 16998 RVA: 0x00074FBE File Offset: 0x000731BE
	public static bool operator !=(ERemoveHatredReason left, ERemoveHatredReason right)
	{
		return !left.Equals(right);
	}

	// Token: 0x040010AA RID: 4266
	private readonly string _Value;

	// Token: 0x040010AB RID: 4267
	public const string MinAreaTimer_Value = "MinAreaTimer";

	// Token: 0x040010AC RID: 4268
	public static readonly ERemoveHatredReason MinAreaTimer = new ERemoveHatredReason("MinAreaTimer");

	// Token: 0x040010AD RID: 4269
	public const string MaxArea_Value = "MaxArea";

	// Token: 0x040010AE RID: 4270
	public static readonly ERemoveHatredReason MaxArea = new ERemoveHatredReason("MaxArea");

	// Token: 0x040010AF RID: 4271
	public const string InActive_Value = "InActive";

	// Token: 0x040010B0 RID: 4272
	public static readonly ERemoveHatredReason InActive = new ERemoveHatredReason("InActive");

	// Token: 0x040010B1 RID: 4273
	public const string Clear_Value = "Clear";

	// Token: 0x040010B2 RID: 4274
	public static readonly ERemoveHatredReason Clear = new ERemoveHatredReason("Clear");

	// Token: 0x040010B3 RID: 4275
	public const string ForceChanged_Value = "ForceChanged";

	// Token: 0x040010B4 RID: 4276
	public static readonly ERemoveHatredReason ForceChanged = new ERemoveHatredReason("ForceChanged");

	// Token: 0x040010B5 RID: 4277
	public const string ChangeCamp_Value = "ChangeCamp";

	// Token: 0x040010B6 RID: 4278
	public static readonly ERemoveHatredReason ChangeCamp = new ERemoveHatredReason("ChangeCamp");

	// Token: 0x040010B7 RID: 4279
	public const string Dead_Value = "Dead";

	// Token: 0x040010B8 RID: 4280
	public static readonly ERemoveHatredReason Dead = new ERemoveHatredReason("Dead");
}
