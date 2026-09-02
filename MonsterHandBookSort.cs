using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001939 RID: 6457
public class MonsterHandBookSort : CommonSort<MonsterHandBookSort.EAdventureGuideSortType>
{
	// Token: 0x0600B95A RID: 47450 RVA: 0x00314C38 File Offset: 0x00312E38
	[NullableContext(2)]
	private int SortDanger(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] parameters = null)
	{
		int num2;
		if (a is int)
		{
			int num = (int)a;
			num2 = num;
		}
		else
		{
			num2 = 0;
		}
		int id = num2;
		int num4;
		if (b is int)
		{
			int num3 = (int)b;
			num4 = num3;
		}
		else
		{
			num4 = 0;
		}
		int id2 = num4;
		HandBookConfig instance = ConfigBase<HandBookConfig>.Instance;
		MonsterHandBook? monsterHandBook = (instance != null) ? instance.GetMonsterHandBookConfigById(id) : null;
		HandBookConfig instance2 = ConfigBase<HandBookConfig>.Instance;
		MonsterHandBook? monsterHandBook2 = (instance2 != null) ? instance2.GetMonsterHandBookConfigById(id2) : null;
		int num5 = (monsterHandBook != null) ? monsterHandBook.GetValueOrDefault().Type : 0;
		int num6 = (monsterHandBook2 != null) ? monsterHandBook2.GetValueOrDefault().Type : 0;
		if (num5 != num6)
		{
			return (num5 - num6) * (isAscending ? 1 : -1);
		}
		int num7 = (monsterHandBook != null) ? monsterHandBook.GetValueOrDefault().SortId : 0;
		int num8 = (monsterHandBook2 != null) ? monsterHandBook2.GetValueOrDefault().SortId : 0;
		if (num7 != num8)
		{
			return (num8 - num7) * (isAscending ? 1 : -1);
		}
		return 0;
	}

	// Token: 0x0600B95B RID: 47451 RVA: 0x00314D4C File Offset: 0x00312F4C
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(MonsterHandBookSort.EAdventureGuideSortType.Danger, new TSortResult(this.SortDanger));
	}

	// Token: 0x02007C73 RID: 31859
	public enum EAdventureGuideSortType
	{
		// Token: 0x0402A80F RID: 174095
		Danger = 1
	}
}
