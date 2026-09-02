using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;

// Token: 0x0200159D RID: 5533
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ActivityScratchTicketModel : ModelBase<ActivityScratchTicketModel>
{
	// Token: 0x06009BA5 RID: 39845 RVA: 0x0028BB01 File Offset: 0x00289D01
	[NullableContext(2)]
	public ScratchTicketData GetScratchTicketData()
	{
		return this.ScratchTicketData;
	}

	// Token: 0x06009BA6 RID: 39846 RVA: 0x0028BB09 File Offset: 0x00289D09
	public void SetScratchTicketData(ScratchTicketData data)
	{
		this.ScratchTicketData = data;
	}

	// Token: 0x06009BA7 RID: 39847 RVA: 0x0028BB12 File Offset: 0x00289D12
	[NullableContext(2)]
	public ScratchTicketRoundData GetScratchRoundData(int roundId)
	{
		if (this.ScratchTicketData == null)
		{
			return null;
		}
		return this.ScratchTicketData.GetRoundDataById(roundId);
	}

	// Token: 0x06009BA8 RID: 39848 RVA: 0x0028BB2A File Offset: 0x00289D2A
	public void OnScratchCardCountInfoNotify(ScratchCardCountInfoNotify message)
	{
		if (this.ScratchTicketData == null)
		{
			return;
		}
		this.ScratchTicketData.UpdateAllRoundState();
		this.ScratchTicketData.RefreshConditionData(new List<ScratchCardTimeInfo>(message.ScratchTimeInfos));
		Singleton<EventSystem>.Instance.Emit(EEventName.OnScratchTicketConditionRefresh);
	}

	// Token: 0x06009BA9 RID: 39849 RVA: 0x0028BB68 File Offset: 0x00289D68
	public void OnScratchCardRewardResponse(int index, int roundId, ScratchCardRewardResponse message, Action<EScratchTicketRewardType, int, List<ScratchTicketRoundResult>, List<RewardItemData>> callback)
	{
		if (this.ScratchTicketData == null)
		{
			return;
		}
		ScratchTicketRoundData roundDataById = this.ScratchTicketData.GetRoundDataById(roundId);
		if (roundDataById == null)
		{
			return;
		}
		List<ScratchTicketRoundResult> rewardResultList = roundDataById.GetRewardResultList(index, (EScratchTicketRewardType)message.OpenType);
		this.ScratchTicketData.UpdateCellReward(roundId, message);
		List<RewardItemData> rewardDataList = roundDataById.GetRewardDataList(message.ItemMap.ToDictionary<int, int>());
		callback((EScratchTicketRewardType)message.OpenType, roundId, rewardResultList, rewardDataList);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ScratchTicketData.Id);
	}

	// Token: 0x040047B7 RID: 18359
	[Nullable(2)]
	private ScratchTicketData ScratchTicketData;
}
