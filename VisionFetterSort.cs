using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001947 RID: 6471
[NullableContext(1)]
[Nullable(0)]
public class VisionFetterSort : CommonSort<EVisionFetterSortWayType>
{
	// Token: 0x0600B9BF RID: 47551 RVA: 0x00317AFC File Offset: 0x00315CFC
	private int SortEquipState(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		if (!(a is PhantomFetterGroup))
		{
			return 0;
		}
		PhantomFetterGroup phantomFetterGroup = (PhantomFetterGroup)a;
		if (b is PhantomFetterGroup)
		{
			PhantomFetterGroup phantomFetterGroup2 = (PhantomFetterGroup)b;
			int num = 0;
			if (param != null && param.Length != 0)
			{
				object obj = param[0];
				if (obj is int)
				{
					int num2 = (int)obj;
					num = num2;
				}
			}
			int num3 = num;
			if (num3 > 0)
			{
				foreach (int uniqueId in ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(num3).GetIncrIdList())
				{
					PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
					int value = (phantomBattleData != null) ? phantomBattleData.GetMonsterId(false) : 0;
					int num4 = ModelBase<PhantomBattleModel>.Instance.GetFetterGroupMonsterIdArray(phantomFetterGroup.Id).Contains(value) ? 1 : -1;
					int num5 = ModelBase<PhantomBattleModel>.Instance.GetFetterGroupMonsterIdArray(phantomFetterGroup2.Id).Contains(value) ? 1 : -1;
					if (num4 != num5)
					{
						return (num4 > num5) ? (isAscending ? 1 : -1) : (isAscending ? -1 : 1);
					}
				}
				return 0;
			}
			return 0;
		}
		return 0;
	}

	// Token: 0x0600B9C0 RID: 47552 RVA: 0x00317C34 File Offset: 0x00315E34
	private int SortHaveState(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		return 0;
	}

	// Token: 0x0600B9C1 RID: 47553 RVA: 0x00317C38 File Offset: 0x00315E38
	private int SortId(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		if (!(a is PhantomFetterGroup))
		{
			return 0;
		}
		PhantomFetterGroup phantomFetterGroup = (PhantomFetterGroup)a;
		if (!(b is PhantomFetterGroup))
		{
			return 0;
		}
		PhantomFetterGroup phantomFetterGroup2 = (PhantomFetterGroup)b;
		if (phantomFetterGroup.Id != phantomFetterGroup2.Id)
		{
			return (phantomFetterGroup.Id - phantomFetterGroup2.Id) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B9C2 RID: 47554 RVA: 0x00317C94 File Offset: 0x00315E94
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(EVisionFetterSortWayType.EquipState, new TSortResult(this.SortEquipState));
		this.SortMap.Add(EVisionFetterSortWayType.HaveState, new TSortResult(this.SortHaveState));
		this.SortMap.Add(EVisionFetterSortWayType.Id, new TSortResult(this.SortId));
	}
}
