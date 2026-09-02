using System;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02002EA3 RID: 11939
[NullableContext(1)]
[Nullable(0)]
public static class SpecialIgnoreBullet
{
	// Token: 0x0601881E RID: 100382 RVA: 0x006DF7F3 File Offset: 0x006DD9F3
	public static bool CheckBulletInSpecialList(string checkBulletId)
	{
		return SpecialIgnoreBullet.Values.Contains(checkBulletId);
	}

	// Token: 0x0400BD1B RID: 48411
	[StaticVariableRuleIgnore]
	public static readonly string[] Values = new string[]
	{
		"4000000003",
		"210000004",
		"80004012001",
		"80012901001",
		"80012901003",
		"80012901004",
		"80012901005",
		"80012901006",
		"80012901008",
		"80012901009",
		"200300046",
		"200100013"
	};
}
