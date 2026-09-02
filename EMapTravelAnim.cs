using System;
using System.Runtime.CompilerServices;

// Token: 0x02001382 RID: 4994
[NullableContext(1)]
[Nullable(0)]
public readonly struct EMapTravelAnim : IEquatable<EMapTravelAnim>
{
	// Token: 0x06008938 RID: 35128 RVA: 0x00242CE1 File Offset: 0x00240EE1
	private EMapTravelAnim(string value)
	{
		this._Value = value;
	}

	// Token: 0x06008939 RID: 35129 RVA: 0x00242CEA File Offset: 0x00240EEA
	public override string ToString()
	{
		return this._Value;
	}

	// Token: 0x0600893A RID: 35130 RVA: 0x00242CF2 File Offset: 0x00240EF2
	public bool Equals(EMapTravelAnim other)
	{
		return this._Value == other._Value;
	}

	// Token: 0x0600893B RID: 35131 RVA: 0x00242D08 File Offset: 0x00240F08
	public override bool Equals(object obj)
	{
		if (obj is EMapTravelAnim)
		{
			EMapTravelAnim other = (EMapTravelAnim)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x0600893C RID: 35132 RVA: 0x00242D2D File Offset: 0x00240F2D
	public override int GetHashCode()
	{
		string value = this._Value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x0600893D RID: 35133 RVA: 0x00242D40 File Offset: 0x00240F40
	public static bool operator ==(EMapTravelAnim left, EMapTravelAnim right)
	{
		return left.Equals(right);
	}

	// Token: 0x0600893E RID: 35134 RVA: 0x00242D4A File Offset: 0x00240F4A
	public static bool operator !=(EMapTravelAnim left, EMapTravelAnim right)
	{
		return !left.Equals(right);
	}

	// Token: 0x0400405B RID: 16475
	private readonly string _Value;

	// Token: 0x0400405C RID: 16476
	public static readonly EMapTravelAnim AniOpen = new EMapTravelAnim("AniOpen");

	// Token: 0x0400405D RID: 16477
	public static readonly EMapTravelAnim AniClose = new EMapTravelAnim("AniClose");
}
