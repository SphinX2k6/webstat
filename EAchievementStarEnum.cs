using System;
using System.Runtime.CompilerServices;

// Token: 0x02000FD3 RID: 4051
[NullableContext(1)]
[Nullable(0)]
public readonly struct EAchievementStarEnum : IEquatable<EAchievementStarEnum>
{
	// Token: 0x06006834 RID: 26676 RVA: 0x001B2468 File Offset: 0x001B0668
	private EAchievementStarEnum(string value)
	{
		this._Value = value;
	}

	// Token: 0x06006835 RID: 26677 RVA: 0x001B2471 File Offset: 0x001B0671
	public override string ToString()
	{
		return this._Value;
	}

	// Token: 0x06006836 RID: 26678 RVA: 0x001B2479 File Offset: 0x001B0679
	public bool Equals(EAchievementStarEnum other)
	{
		return this._Value == other._Value;
	}

	// Token: 0x06006837 RID: 26679 RVA: 0x001B248C File Offset: 0x001B068C
	public override bool Equals(object obj)
	{
		if (obj is EAchievementStarEnum)
		{
			EAchievementStarEnum other = (EAchievementStarEnum)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x06006838 RID: 26680 RVA: 0x001B24B1 File Offset: 0x001B06B1
	public override int GetHashCode()
	{
		string value = this._Value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x06006839 RID: 26681 RVA: 0x001B24C4 File Offset: 0x001B06C4
	public static bool operator ==(EAchievementStarEnum left, EAchievementStarEnum right)
	{
		return left.Equals(right);
	}

	// Token: 0x0600683A RID: 26682 RVA: 0x001B24CE File Offset: 0x001B06CE
	public static bool operator !=(EAchievementStarEnum left, EAchievementStarEnum right)
	{
		return !left.Equals(right);
	}

	// Token: 0x040031A3 RID: 12707
	private readonly string _Value;

	// Token: 0x040031A4 RID: 12708
	public static readonly EAchievementStarEnum SingleStar = new EAchievementStarEnum("UiItem_AchvStarA");

	// Token: 0x040031A5 RID: 12709
	public static readonly EAchievementStarEnum DoubleStar = new EAchievementStarEnum("UiItem_AchvStarB");

	// Token: 0x040031A6 RID: 12710
	public static readonly EAchievementStarEnum TripleStar = new EAchievementStarEnum("UiItem_AchvStarC");
}
