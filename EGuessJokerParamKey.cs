using System;
using System.Runtime.CompilerServices;

// Token: 0x02001114 RID: 4372
[NullableContext(1)]
[Nullable(0)]
public readonly struct EGuessJokerParamKey : IEquatable<EGuessJokerParamKey>
{
	// Token: 0x06007193 RID: 29075 RVA: 0x001DAC0E File Offset: 0x001D8E0E
	private EGuessJokerParamKey(string value)
	{
		this._Value = value;
	}

	// Token: 0x06007194 RID: 29076 RVA: 0x001DAC17 File Offset: 0x001D8E17
	public override string ToString()
	{
		return this._Value;
	}

	// Token: 0x06007195 RID: 29077 RVA: 0x001DAC1F File Offset: 0x001D8E1F
	public bool Equals(EGuessJokerParamKey other)
	{
		return this._Value == other._Value;
	}

	// Token: 0x06007196 RID: 29078 RVA: 0x001DAC34 File Offset: 0x001D8E34
	[NullableContext(2)]
	public override bool Equals(object obj)
	{
		if (obj is EGuessJokerParamKey)
		{
			EGuessJokerParamKey other = (EGuessJokerParamKey)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x06007197 RID: 29079 RVA: 0x001DAC59 File Offset: 0x001D8E59
	public override int GetHashCode()
	{
		string value = this._Value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x06007198 RID: 29080 RVA: 0x001DAC6C File Offset: 0x001D8E6C
	public static bool operator ==(EGuessJokerParamKey left, EGuessJokerParamKey right)
	{
		return left.Equals(right);
	}

	// Token: 0x06007199 RID: 29081 RVA: 0x001DAC76 File Offset: 0x001D8E76
	public static bool operator !=(EGuessJokerParamKey left, EGuessJokerParamKey right)
	{
		return !left.Equals(right);
	}

	// Token: 0x040036E6 RID: 14054
	private readonly string _Value;

	// Token: 0x040036E7 RID: 14055
	public static readonly EGuessJokerParamKey GuessJokerCardMoveTime = new EGuessJokerParamKey("GuessJokerMoveCardTime");

	// Token: 0x040036E8 RID: 14056
	public static readonly EGuessJokerParamKey GuessJokerCardUpTime = new EGuessJokerParamKey("GuessJokerUpCardTime");

	// Token: 0x040036E9 RID: 14057
	public static readonly EGuessJokerParamKey GuessJokerCardRemoveTime = new EGuessJokerParamKey("GuessJokerRemoveCardTime");

	// Token: 0x040036EA RID: 14058
	public static readonly EGuessJokerParamKey GuessJokerAiSkillConsiderTime = new EGuessJokerParamKey("GuessJokerAiSkillConsiderTime");

	// Token: 0x040036EB RID: 14059
	public static readonly EGuessJokerParamKey GuessJokerPlayerSkillConsiderTime = new EGuessJokerParamKey("GuessJokerPlayerSkillConsiderTime");

	// Token: 0x040036EC RID: 14060
	public static readonly EGuessJokerParamKey GuessJokerNpcDrawCardWaitTime = new EGuessJokerParamKey("GuessJokerNpcDrawCardTime");

	// Token: 0x040036ED RID: 14061
	public static readonly EGuessJokerParamKey GuessJokerCheckCardTime = new EGuessJokerParamKey("GuessJokerCheckCardTime");

	// Token: 0x040036EE RID: 14062
	public static readonly EGuessJokerParamKey GuessJokerCheckItemMoveTime = new EGuessJokerParamKey("GuessJokerCheckItemMoveTime");

	// Token: 0x040036EF RID: 14063
	public static readonly EGuessJokerParamKey GuessJokerCheckItemStayTime = new EGuessJokerParamKey("GuessJokerCheckItemStayTime");

	// Token: 0x040036F0 RID: 14064
	public static readonly EGuessJokerParamKey GuessJokerMaxPerformTime = new EGuessJokerParamKey("GuessJokerMaxPerformTime");

	// Token: 0x040036F1 RID: 14065
	public static readonly EGuessJokerParamKey GuessJokerFloatTipTime = new EGuessJokerParamKey("GuessJokerFloatTipTime");

	// Token: 0x040036F2 RID: 14066
	public static readonly EGuessJokerParamKey GuessJokerLuhesiDrawCardWaitTime = new EGuessJokerParamKey("GuessJokerLuhesiDrawCardWaitTime");

	// Token: 0x040036F3 RID: 14067
	public static readonly EGuessJokerParamKey GuessJokerBeChooseAiCardCount = new EGuessJokerParamKey("GuessJokerBeChooseAiCardCount");

	// Token: 0x040036F4 RID: 14068
	public static readonly EGuessJokerParamKey GuessJokerBeDrawAiCardCount = new EGuessJokerParamKey("GuessJokerBeDrawAiCardCount");

	// Token: 0x040036F5 RID: 14069
	public static readonly EGuessJokerParamKey GuessJokerBeDrawPlayerCardCount = new EGuessJokerParamKey("GuessJokerBeDrawPlayerCardCount");

	// Token: 0x040036F6 RID: 14070
	public static readonly EGuessJokerParamKey GuessJokerDrawAiCardCount = new EGuessJokerParamKey("GuessJokerDrawAiCardCount");
}
