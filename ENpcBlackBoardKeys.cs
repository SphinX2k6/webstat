using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E4C RID: 3660
[NullableContext(1)]
[Nullable(0)]
public readonly struct ENpcBlackBoardKeys : IEquatable<ENpcBlackBoardKeys>
{
	// Token: 0x060057C2 RID: 22466 RVA: 0x0010565A File Offset: 0x0010385A
	private ENpcBlackBoardKeys(string value)
	{
		this.Value = value;
	}

	// Token: 0x060057C3 RID: 22467 RVA: 0x00105663 File Offset: 0x00103863
	public override string ToString()
	{
		return this.Value;
	}

	// Token: 0x060057C4 RID: 22468 RVA: 0x0010566B File Offset: 0x0010386B
	public bool Equals(ENpcBlackBoardKeys other)
	{
		return this.Value == other.Value;
	}

	// Token: 0x060057C5 RID: 22469 RVA: 0x00105680 File Offset: 0x00103880
	[NullableContext(2)]
	public override bool Equals(object obj)
	{
		if (obj is ENpcBlackBoardKeys)
		{
			ENpcBlackBoardKeys other = (ENpcBlackBoardKeys)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x060057C6 RID: 22470 RVA: 0x001056A5 File Offset: 0x001038A5
	public override int GetHashCode()
	{
		string value = this.Value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x060057C7 RID: 22471 RVA: 0x001056B8 File Offset: 0x001038B8
	public static bool operator ==(ENpcBlackBoardKeys left, ENpcBlackBoardKeys right)
	{
		return left.Equals(right);
	}

	// Token: 0x060057C8 RID: 22472 RVA: 0x001056C2 File Offset: 0x001038C2
	public static bool operator !=(ENpcBlackBoardKeys left, ENpcBlackBoardKeys right)
	{
		return !left.Equals(right);
	}

	// Token: 0x04001D9F RID: 7583
	public readonly string Value;

	// Token: 0x04001DA0 RID: 7584
	public const string ActiveAction_Value = "ActiveAction";

	// Token: 0x04001DA1 RID: 7585
	public static readonly ENpcBlackBoardKeys ActiveAction = new ENpcBlackBoardKeys("ActiveAction");

	// Token: 0x04001DA2 RID: 7586
	public const string TargetMontageName_Value = "TargetMontageName";

	// Token: 0x04001DA3 RID: 7587
	public static readonly ENpcBlackBoardKeys TargetMontageName = new ENpcBlackBoardKeys("TargetMontageName");

	// Token: 0x04001DA4 RID: 7588
	public const string MonsterCount_Value = "MonsterCount";

	// Token: 0x04001DA5 RID: 7589
	public static readonly ENpcBlackBoardKeys MonsterCount = new ENpcBlackBoardKeys("MonsterCount");

	// Token: 0x04001DA6 RID: 7590
	public const string NearerPlayerId_Value = "NearerPlayerId";

	// Token: 0x04001DA7 RID: 7591
	public static readonly ENpcBlackBoardKeys NearerPlayerId = new ENpcBlackBoardKeys("NearerPlayerId");

	// Token: 0x04001DA8 RID: 7592
	public const string NeutralCount_Value = "NeutralCount";

	// Token: 0x04001DA9 RID: 7593
	public static readonly ENpcBlackBoardKeys NeutralCount = new ENpcBlackBoardKeys("NeutralCount");
}
