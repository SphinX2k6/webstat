using System;
using System.Runtime.CompilerServices;

// Token: 0x0200296C RID: 10604
public readonly struct ESdkPopUpViewType : IEquatable<ESdkPopUpViewType>
{
	// Token: 0x06015152 RID: 86354 RVA: 0x005D56A9 File Offset: 0x005D38A9
	private ESdkPopUpViewType(int value)
	{
		this._Value = value;
	}

	// Token: 0x06015153 RID: 86355 RVA: 0x005D56B2 File Offset: 0x005D38B2
	[NullableContext(1)]
	public override string ToString()
	{
		return this._Value.ToString();
	}

	// Token: 0x06015154 RID: 86356 RVA: 0x005D56BF File Offset: 0x005D38BF
	public bool Equals(ESdkPopUpViewType other)
	{
		return this._Value == other._Value;
	}

	// Token: 0x06015155 RID: 86357 RVA: 0x005D56D0 File Offset: 0x005D38D0
	[NullableContext(1)]
	public override bool Equals(object obj)
	{
		if (obj is ESdkPopUpViewType)
		{
			ESdkPopUpViewType other = (ESdkPopUpViewType)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x06015156 RID: 86358 RVA: 0x005D56F5 File Offset: 0x005D38F5
	public override int GetHashCode()
	{
		return this._Value.GetHashCode();
	}

	// Token: 0x06015157 RID: 86359 RVA: 0x005D5702 File Offset: 0x005D3902
	public static bool operator ==(ESdkPopUpViewType left, ESdkPopUpViewType right)
	{
		return left.Equals(right);
	}

	// Token: 0x06015158 RID: 86360 RVA: 0x005D570C File Offset: 0x005D390C
	public static bool operator !=(ESdkPopUpViewType left, ESdkPopUpViewType right)
	{
		return !left.Equals(right);
	}

	// Token: 0x0400A253 RID: 41555
	private readonly int _Value;

	// Token: 0x0400A254 RID: 41556
	public static readonly ESdkPopUpViewType Creating = new ESdkPopUpViewType(0);

	// Token: 0x0400A255 RID: 41557
	public static readonly ESdkPopUpViewType Login = new ESdkPopUpViewType(1);
}
