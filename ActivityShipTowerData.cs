using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

// Token: 0x020015B6 RID: 5558
public class ActivityShipTowerData : ActivityBaseData
{
	// Token: 0x06009C9A RID: 40090 RVA: 0x00290594 File Offset: 0x0028E794
	[NullableContext(1)]
	protected override void OnInit(ActivityData data)
	{
		ServerStorageUtil.OverrideLocalNumberToServerNumber(ELocalStoragePlayerKey.ShipTowerSeason, EClientStorageSystemIdType.ShipTowerSeason);
	}

	// Token: 0x06009C9B RID: 40091 RVA: 0x002905A0 File Offset: 0x0028E7A0
	public override bool GetExDataRedPointShowState()
	{
		return this.HasNewCycle() || ModelBase<ShipTowerModel>.Instance.IsCanReceiveAward();
	}

	// Token: 0x06009C9C RID: 40092 RVA: 0x002905B8 File Offset: 0x0028E7B8
	public bool HasNewCycle()
	{
		int curSeason = ModelBase<ShipTowerModel>.Instance.CurSeason;
		return curSeason > 0 && (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.ShipTowerSeason) as ServerStorageNumber).Get().GetValueOrDefault() < curSeason;
	}

	// Token: 0x06009C9D RID: 40093 RVA: 0x002905F7 File Offset: 0x0028E7F7
	protected override bool GetExDataFinishShowState()
	{
		return ModelBase<ShipTowerModel>.Instance.IsRewardAllReceived;
	}
}
