using System;
using System.Runtime.CompilerServices;

// Token: 0x02001924 RID: 6436
[NullableContext(1)]
[Nullable(0)]
public class CalabashCollectSort : CommonSort<ECalabashCollectWayType>
{
	// Token: 0x0600B910 RID: 47376 RVA: 0x003137F8 File Offset: 0x003119F8
	private int SortQuality(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		CalabashDevelopRewardData calabashDevelopRewardData = a as CalabashDevelopRewardData;
		if (calabashDevelopRewardData == null)
		{
			return 0;
		}
		CalabashDevelopRewardData calabashDevelopRewardData2 = b as CalabashDevelopRewardData;
		if (calabashDevelopRewardData2 == null)
		{
			return 0;
		}
		int monsterId = calabashDevelopRewardData.DevelopRewardData.MonsterId;
		int monsterRarity = ModelBase<PhantomBattleModel>.Instance.GetMonsterRarity(monsterId);
		int monsterId2 = calabashDevelopRewardData2.DevelopRewardData.MonsterId;
		int monsterRarity2 = ModelBase<PhantomBattleModel>.Instance.GetMonsterRarity(monsterId2);
		if (monsterRarity != monsterRarity2)
		{
			return (monsterRarity - monsterRarity2) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B911 RID: 47377 RVA: 0x0031386C File Offset: 0x00311A6C
	private int SortSortId(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		CalabashDevelopRewardData calabashDevelopRewardData = a as CalabashDevelopRewardData;
		if (calabashDevelopRewardData == null)
		{
			return 0;
		}
		CalabashDevelopRewardData calabashDevelopRewardData2 = b as CalabashDevelopRewardData;
		if (calabashDevelopRewardData2 == null)
		{
			return 0;
		}
		int sortId = calabashDevelopRewardData.DevelopRewardData.SortId;
		int sortId2 = calabashDevelopRewardData2.DevelopRewardData.SortId;
		if (sortId != sortId2)
		{
			return (sortId - sortId2) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B912 RID: 47378 RVA: 0x003138C4 File Offset: 0x00311AC4
	private int SortMonsterId(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		CalabashDevelopRewardData calabashDevelopRewardData = a as CalabashDevelopRewardData;
		if (calabashDevelopRewardData == null)
		{
			return 0;
		}
		CalabashDevelopRewardData calabashDevelopRewardData2 = b as CalabashDevelopRewardData;
		if (calabashDevelopRewardData2 == null)
		{
			return 0;
		}
		int monsterId = calabashDevelopRewardData.DevelopRewardData.MonsterId;
		int monsterId2 = calabashDevelopRewardData2.DevelopRewardData.MonsterId;
		if (monsterId != monsterId2)
		{
			return (monsterId - monsterId2) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B913 RID: 47379 RVA: 0x0031391C File Offset: 0x00311B1C
	private int SortExperience(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		CalabashDevelopRewardData calabashDevelopRewardData = a as CalabashDevelopRewardData;
		if (calabashDevelopRewardData == null)
		{
			return 0;
		}
		CalabashDevelopRewardData calabashDevelopRewardData2 = b as CalabashDevelopRewardData;
		if (calabashDevelopRewardData2 == null)
		{
			return 0;
		}
		int monsterId = calabashDevelopRewardData.DevelopRewardData.MonsterId;
		int monsterId2 = calabashDevelopRewardData2.DevelopRewardData.MonsterId;
		int calabashDevelopRewardExpByMonsterId = ModelBase<CalabashModel>.Instance.GetCalabashDevelopRewardExpByMonsterId(monsterId);
		int calabashDevelopRewardExpByMonsterId2 = ModelBase<CalabashModel>.Instance.GetCalabashDevelopRewardExpByMonsterId(monsterId2);
		if (calabashDevelopRewardExpByMonsterId != calabashDevelopRewardExpByMonsterId2)
		{
			return (calabashDevelopRewardExpByMonsterId - calabashDevelopRewardExpByMonsterId2) * (isAscending ? 1 : -1);
		}
		return 0;
	}

	// Token: 0x0600B914 RID: 47380 RVA: 0x00313990 File Offset: 0x00311B90
	private int SortSkin(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		CalabashDevelopRewardData calabashDevelopRewardData = a as CalabashDevelopRewardData;
		if (calabashDevelopRewardData == null)
		{
			return 0;
		}
		CalabashDevelopRewardData calabashDevelopRewardData2 = b as CalabashDevelopRewardData;
		if (calabashDevelopRewardData2 == null)
		{
			return 0;
		}
		int monsterId = calabashDevelopRewardData.DevelopRewardData.MonsterId;
		int monsterId2 = calabashDevelopRewardData2.DevelopRewardData.MonsterId;
		int[] monsterSkinListByMonsterId = ModelBase<PhantomBattleModel>.Instance.GetMonsterSkinListByMonsterId(monsterId);
		int num = (monsterSkinListByMonsterId != null) ? monsterSkinListByMonsterId.Length : 0;
		int[] monsterSkinListByMonsterId2 = ModelBase<PhantomBattleModel>.Instance.GetMonsterSkinListByMonsterId(monsterId2);
		int num2 = (monsterSkinListByMonsterId2 != null) ? monsterSkinListByMonsterId2.Length : 0;
		if (num != num2)
		{
			return (num - num2) * (isAscending ? 1 : -1);
		}
		return 0;
	}

	// Token: 0x0600B915 RID: 47381 RVA: 0x00313A18 File Offset: 0x00311C18
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(ECalabashCollectWayType.Quality, new TSortResult(this.SortQuality));
		this.SortMap.Add(ECalabashCollectWayType.SortId, new TSortResult(this.SortSortId));
		this.SortMap.Add(ECalabashCollectWayType.MonsterId, new TSortResult(this.SortMonsterId));
		this.SortMap.Add(ECalabashCollectWayType.Experience, new TSortResult(this.SortExperience));
		this.SortMap.Add(ECalabashCollectWayType.Skin, new TSortResult(this.SortSkin));
	}
}
