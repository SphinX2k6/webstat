using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002DD4 RID: 11732
[NullableContext(1)]
[Nullable(0)]
public static class BulletHitCountUtil
{
	// Token: 0x06017A51 RID: 96849 RVA: 0x00698250 File Offset: 0x00696450
	public static bool HitCountCondition(BulletInfo bulletInfo, Entity victimEntity)
	{
		if (bulletInfo.CountByParent && bulletInfo.ParentBulletInfo != null)
		{
			return BulletHitCountUtil.HitCountCondition(bulletInfo.ParentBulletInfo, victimEntity);
		}
		bool openHitActorLog = Singleton<BulletConstant>.Instance.OpenHitActorLog;
		if (victimEntity == null)
		{
			return false;
		}
		CharacterFollowComponent component = victimEntity.GetComponent<CharacterFollowComponent>();
		Entity entity = ((component != null) ? component.GetAttributeHolderExceptVisionSummon() : null) ?? victimEntity;
		BulletDataMain bulletDataMain = bulletInfo.BulletDataMain;
		if (bulletDataMain.Base.VictimCount >= 0 && bulletInfo.EntityHitSet.Count >= bulletDataMain.Base.VictimCount && !bulletInfo.EntityHitSet.Contains(entity.Id))
		{
			return false;
		}
		if (bulletDataMain.Base.HitCountMax >= 0 && bulletInfo.HitNumberAll >= bulletDataMain.Base.HitCountMax)
		{
			return false;
		}
		int num;
		if (!bulletInfo.EntityHitCount.TryGetValue(entity.Id, out num))
		{
			bulletInfo.EntityHitCount[entity.Id] = 1;
			bulletInfo.EntityHitSet.Add(entity.Id);
			bulletInfo.HitNumberAll++;
			return true;
		}
		if (bulletDataMain.Base.HitCountPerVictim > 0 && num >= bulletDataMain.Base.HitCountPerVictim)
		{
			return false;
		}
		bulletInfo.EntityHitCount[entity.Id] = num + 1;
		bulletInfo.EntityHitSet.Add(entity.Id);
		bulletInfo.HitNumberAll++;
		return true;
	}

	// Token: 0x06017A52 RID: 96850 RVA: 0x006983A8 File Offset: 0x006965A8
	public static void AddHitCount(BulletInfo bulletInfo, Entity victim)
	{
		if (bulletInfo.CountByParent && bulletInfo.ParentBulletInfo != null)
		{
			BulletHitCountUtil.AddHitCount(bulletInfo.ParentBulletInfo, victim);
			return;
		}
		int valueOrDefault = bulletInfo.EntityHitCount.GetValueOrDefault(victim.Id, 0);
		bulletInfo.EntityHitCount[victim.Id] = valueOrDefault + 1;
		bulletInfo.EntityHitSet.Add(victim.Id);
		bulletInfo.HitNumberAll++;
	}

	// Token: 0x06017A53 RID: 96851 RVA: 0x0069841C File Offset: 0x0069661C
	public static bool CheckHitCountPerVictim(BulletInfo bulletInfo, Entity victim)
	{
		if (bulletInfo.CountByParent && bulletInfo.ParentBulletInfo != null)
		{
			return BulletHitCountUtil.CheckHitCountPerVictim(bulletInfo.ParentBulletInfo, victim);
		}
		int count = bulletInfo.EntityHitSet.Count;
		bool openHitActorLog = Singleton<BulletConstant>.Instance.OpenHitActorLog;
		BulletDataMain bulletDataMain = bulletInfo.BulletDataMain;
		if (bulletDataMain.Base.VictimCount >= 0 && count >= bulletDataMain.Base.VictimCount && !bulletInfo.EntityHitSet.Contains(victim.Id))
		{
			return false;
		}
		int valueOrDefault = bulletInfo.EntityHitCount.GetValueOrDefault(victim.Id, 0);
		return (bulletDataMain.Base.HitCountPerVictim < 0 || valueOrDefault < bulletDataMain.Base.HitCountPerVictim) && (bulletDataMain.Base.HitCountMax <= 0 || bulletInfo.HitNumberAll < bulletDataMain.Base.HitCountMax);
	}

	// Token: 0x06017A54 RID: 96852 RVA: 0x006984EC File Offset: 0x006966EC
	public static bool CheckHitCountTotal(BulletInfo bulletInfo)
	{
		if (bulletInfo.CountByParent && bulletInfo.ParentBulletInfo != null)
		{
			return BulletHitCountUtil.CheckHitCountTotal(bulletInfo.ParentBulletInfo);
		}
		BulletDataMain bulletDataMain = bulletInfo.BulletDataMain;
		return bulletDataMain.Logic.DestroyOnCountZero && bulletDataMain.Base.HitCountMax > 0 && bulletInfo.HitNumberAll >= bulletDataMain.Base.HitCountMax;
	}

	// Token: 0x06017A55 RID: 96853 RVA: 0x0069854F File Offset: 0x0069674F
	public static int GetHitCountByVictim(BulletInfo bulletInfo, int victimId)
	{
		if (bulletInfo.CountByParent && bulletInfo.ParentBulletInfo != null)
		{
			return BulletHitCountUtil.GetHitCountByVictim(bulletInfo.ParentBulletInfo, victimId);
		}
		return bulletInfo.EntityHitCount.GetValueOrDefault(victimId, 0);
	}
}
