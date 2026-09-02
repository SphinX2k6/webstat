using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide;

// Token: 0x0200173C RID: 5948
[NullableContext(1)]
[Nullable(0)]
public static class AdventureGuideControllerHelper
{
	// Token: 0x0600A6A2 RID: 42658 RVA: 0x002C2B88 File Offset: 0x002C0D88
	public static int silentAreasSortFunc(SilentAreaDetectionRecord a, SilentAreaDetectionRecord b)
	{
		if (a.Conf.DangerType != b.Conf.DangerType)
		{
			return b.Conf.DangerType - a.Conf.DangerType;
		}
		if (a.Conf.Secondary != b.Conf.Secondary)
		{
			return b.Conf.Secondary - a.Conf.Secondary;
		}
		return a.Conf.Id - b.Conf.Id;
	}

	// Token: 0x0600A6A3 RID: 42659 RVA: 0x002C2C2C File Offset: 0x002C0E2C
	public static int monsterSortFunc(MonsterDetectionRecord a, MonsterDetectionRecord b)
	{
		if (a.Conf.DangerType != b.Conf.DangerType)
		{
			return b.Conf.DangerType - a.Conf.DangerType;
		}
		if (a.Conf.TypeDescription2 != b.Conf.TypeDescription2)
		{
			return b.Conf.TypeDescription2 - a.Conf.TypeDescription2;
		}
		return b.Conf.Id - a.Conf.Id;
	}
}
