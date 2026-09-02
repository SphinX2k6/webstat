using System;
using System.Runtime.CompilerServices;

// Token: 0x02002B8F RID: 11151
[NullableContext(1)]
[Nullable(0)]
public readonly struct ESurvivorsSequenceName : IEquatable<ESurvivorsSequenceName>
{
	// Token: 0x0601636C RID: 90988 RVA: 0x006295CB File Offset: 0x006277CB
	private ESurvivorsSequenceName(string value)
	{
		this._Value = value;
	}

	// Token: 0x0601636D RID: 90989 RVA: 0x006295D4 File Offset: 0x006277D4
	public override string ToString()
	{
		return this._Value;
	}

	// Token: 0x0601636E RID: 90990 RVA: 0x006295DC File Offset: 0x006277DC
	public bool Equals(ESurvivorsSequenceName other)
	{
		return this._Value == other._Value;
	}

	// Token: 0x0601636F RID: 90991 RVA: 0x006295F0 File Offset: 0x006277F0
	[NullableContext(2)]
	public override bool Equals(object obj)
	{
		if (obj is ESurvivorsSequenceName)
		{
			ESurvivorsSequenceName other = (ESurvivorsSequenceName)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x06016370 RID: 90992 RVA: 0x00629615 File Offset: 0x00627815
	public override int GetHashCode()
	{
		string value = this._Value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x06016371 RID: 90993 RVA: 0x00629628 File Offset: 0x00627828
	public static bool operator ==(ESurvivorsSequenceName left, ESurvivorsSequenceName right)
	{
		return left.Equals(right);
	}

	// Token: 0x06016372 RID: 90994 RVA: 0x00629632 File Offset: 0x00627832
	public static bool operator !=(ESurvivorsSequenceName left, ESurvivorsSequenceName right)
	{
		return !left.Equals(right);
	}

	// Token: 0x0400ABE0 RID: 44000
	private readonly string _Value;

	// Token: 0x0400ABE1 RID: 44001
	public static readonly ESurvivorsSequenceName PreSelect = new ESurvivorsSequenceName("PreArm");

	// Token: 0x0400ABE2 RID: 44002
	public static readonly ESurvivorsSequenceName LevelUp = new ESurvivorsSequenceName("LevelUp");

	// Token: 0x0400ABE3 RID: 44003
	public static readonly ESurvivorsSequenceName Unlock = new ESurvivorsSequenceName("Unlock");

	// Token: 0x0400ABE4 RID: 44004
	public static readonly ESurvivorsSequenceName Connect = new ESurvivorsSequenceName("Connect");

	// Token: 0x0400ABE5 RID: 44005
	public static readonly ESurvivorsSequenceName Disconnect = new ESurvivorsSequenceName("Disconnect");
}
