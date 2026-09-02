using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide;

// Token: 0x02001920 RID: 6432
public class AdventureGuideSort : CommonSort<EAdventureGuideSortType>
{
	// Token: 0x0600B906 RID: 47366 RVA: 0x00313580 File Offset: 0x00311780
	[NullableContext(1)]
	private int SortDanger(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		MonsterDetectionRecord monsterDetectionRecord = a as MonsterDetectionRecord;
		if (monsterDetectionRecord == null)
		{
			return 0;
		}
		MonsterDetectionRecord monsterDetectionRecord2 = b as MonsterDetectionRecord;
		if (monsterDetectionRecord2 == null)
		{
			return 0;
		}
		if (monsterDetectionRecord != monsterDetectionRecord2)
		{
			return (monsterDetectionRecord.Conf.DangerType - monsterDetectionRecord2.Conf.DangerType) * (isAscending ? 1 : -1);
		}
		return 0;
	}

	// Token: 0x0600B907 RID: 47367 RVA: 0x003135D0 File Offset: 0x003117D0
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(EAdventureGuideSortType.Danger, new TSortResult(this.SortDanger));
	}
}
