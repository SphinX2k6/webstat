using System;
using System.Runtime.CompilerServices;

// Token: 0x02001168 RID: 4456
[NullableContext(1)]
[Nullable(0)]
public readonly struct EActivityRewardSource : IEquatable<EActivityRewardSource>
{
	// Token: 0x06007556 RID: 30038 RVA: 0x001ECDC3 File Offset: 0x001EAFC3
	private EActivityRewardSource(string value)
	{
		this._Value = value;
	}

	// Token: 0x06007557 RID: 30039 RVA: 0x001ECDCC File Offset: 0x001EAFCC
	public override string ToString()
	{
		return this._Value;
	}

	// Token: 0x06007558 RID: 30040 RVA: 0x001ECDD4 File Offset: 0x001EAFD4
	public bool Equals(EActivityRewardSource other)
	{
		return this._Value == other._Value;
	}

	// Token: 0x06007559 RID: 30041 RVA: 0x001ECDE8 File Offset: 0x001EAFE8
	public override bool Equals(object obj)
	{
		if (obj is EActivityRewardSource)
		{
			EActivityRewardSource other = (EActivityRewardSource)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x0600755A RID: 30042 RVA: 0x001ECE0D File Offset: 0x001EB00D
	public override int GetHashCode()
	{
		string value = this._Value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x0600755B RID: 30043 RVA: 0x001ECE20 File Offset: 0x001EB020
	public static bool operator ==(EActivityRewardSource left, EActivityRewardSource right)
	{
		return left.Equals(right);
	}

	// Token: 0x0600755C RID: 30044 RVA: 0x001ECE2A File Offset: 0x001EB02A
	public static bool operator !=(EActivityRewardSource left, EActivityRewardSource right)
	{
		return !left.Equals(right);
	}

	// Token: 0x040038E0 RID: 14560
	private readonly string _Value;

	// Token: 0x040038E1 RID: 14561
	public static readonly EActivityRewardSource BossRush = new EActivityRewardSource("BossRush");

	// Token: 0x040038E2 RID: 14562
	public static readonly EActivityRewardSource Collection = new EActivityRewardSource("Collection");

	// Token: 0x040038E3 RID: 14563
	public static readonly EActivityRewardSource MoonChasing = new EActivityRewardSource("MoonChasing");

	// Token: 0x040038E4 RID: 14564
	public static readonly EActivityRewardSource Mowing = new EActivityRewardSource("Mowing");

	// Token: 0x040038E5 RID: 14565
	public static readonly EActivityRewardSource MowingRisk = new EActivityRewardSource("MowingRisk");

	// Token: 0x040038E6 RID: 14566
	public static readonly EActivityRewardSource DreamLink = new EActivityRewardSource("DreamLink");

	// Token: 0x040038E7 RID: 14567
	public static readonly EActivityRewardSource DarkCoastDelivery = new EActivityRewardSource("DarkCoastDelivery");

	// Token: 0x040038E8 RID: 14568
	public static readonly EActivityRewardSource TowerDefence = new EActivityRewardSource("TowerDefence");

	// Token: 0x040038E9 RID: 14569
	public static readonly EActivityRewardSource FarmGold = new EActivityRewardSource("FarmGold");

	// Token: 0x040038EA RID: 14570
	public static readonly EActivityRewardSource WeeklyRogue = new EActivityRewardSource("WeeklyRogue");

	// Token: 0x040038EB RID: 14571
	public static readonly EActivityRewardSource RogueRes = new EActivityRewardSource("RogueRes");

	// Token: 0x040038EC RID: 14572
	public static readonly EActivityRewardSource Infrastructure = new EActivityRewardSource("Infrastructure");
}
