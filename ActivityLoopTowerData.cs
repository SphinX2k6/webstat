using System;

// Token: 0x0200136A RID: 4970
public class ActivityLoopTowerData : ActivityBaseData
{
	// Token: 0x06008843 RID: 34883 RVA: 0x0023EFB4 File Offset: 0x0023D1B4
	public override bool GetExDataRedPointShowState()
	{
		return ModelBase<TowerModel>.Instance.CurrentSeason != -1 && (ModelBase<TowerModel>.Instance.GetLoopTowerIsClickSeason() < ModelBase<TowerModel>.Instance.CurrentSeason || ModelBase<TowerModel>.Instance.CanGetRewardByDifficulties(3) || !ModelBase<TowerModel>.Instance.GetLoopTowerIsClickShop());
	}

	// Token: 0x06008844 RID: 34884 RVA: 0x0023F002 File Offset: 0x0023D202
	protected override bool GetExDataFinishShowState()
	{
		return ModelBase<TowerModel>.Instance.CurrentSeason == ModelBase<TowerModel>.Instance.DataSeason && ModelBase<TowerModel>.Instance.IsRewardAllFinished(new int?(3));
	}
}
