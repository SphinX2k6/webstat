using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020015A0 RID: 5536
[NullableContext(1)]
[Nullable(0)]
public class ScratchTicketData : ActivityBaseData
{
	// Token: 0x06009BB5 RID: 39861 RVA: 0x0028BDF4 File Offset: 0x00289FF4
	protected override void PhraseEx(ActivityData data)
	{
		ScratchCardActivityInfo scratchCardActivityInfo = data.ScratchCardActivityInfo;
		if (scratchCardActivityInfo == null)
		{
			return;
		}
		this.InitData(scratchCardActivityInfo);
	}

	// Token: 0x06009BB6 RID: 39862 RVA: 0x0028BE13 File Offset: 0x0028A013
	public override bool NeedSelfControlFirstRedPoint()
	{
		return false;
	}

	// Token: 0x06009BB7 RID: 39863 RVA: 0x0028BE18 File Offset: 0x0028A018
	public void InitData(ScratchCardActivityInfo activityInfo)
	{
		this.Config = ConfigBase<ActivityScratchTicketConfig>.Instance.GetScratchTicketConfig(base.Id);
		if (this.Config == null)
		{
			return;
		}
		this.InitRoundData(activityInfo.RoundInfos.ToList<ScratchCardRoundInfo>());
		this.InitConditionData(activityInfo.ScratchTimeInfos.ToList<ScratchCardTimeInfo>());
	}

	// Token: 0x06009BB8 RID: 39864 RVA: 0x0028BE6C File Offset: 0x0028A06C
	private void InitRoundData(List<ScratchCardRoundInfo> roundInfos)
	{
		if (this.RoundDataList.Count > 0)
		{
			return;
		}
		this.RoundDataList = new List<ScratchTicketRoundData>();
		foreach (ScratchCardRoundInfo roundInfo in roundInfos)
		{
			ScratchTicketRoundData scratchTicketRoundData = new ScratchTicketRoundData();
			scratchTicketRoundData.Init(roundInfo);
			this.RoundDataList.Add(scratchTicketRoundData);
		}
		this.RoundDataList.Sort((ScratchTicketRoundData a, ScratchTicketRoundData b) => a.Config.Value.PreRoundId - b.Config.Value.PreRoundId);
		this.UpdateAllRoundState();
	}

	// Token: 0x06009BB9 RID: 39865 RVA: 0x0028BF18 File Offset: 0x0028A118
	public void UpdateAllRoundState()
	{
		for (int i = 0; i < this.RoundDataList.Count; i++)
		{
			ScratchTicketRoundData scratchTicketRoundData = this.RoundDataList[i];
			if (i == 0)
			{
				scratchTicketRoundData.UpdateRoundState(EScratchTicketRoundState.Finish);
			}
			else
			{
				ScratchTicketRoundData scratchTicketRoundData2 = this.RoundDataList[i - 1];
				scratchTicketRoundData.UpdateRoundState(scratchTicketRoundData2.GetRoundState());
			}
		}
	}

	// Token: 0x06009BBA RID: 39866 RVA: 0x0028BF70 File Offset: 0x0028A170
	public void UpdateCellReward(int roundId, ScratchCardRewardResponse message)
	{
		ScratchTicketRoundData roundDataById = this.GetRoundDataById(roundId);
		if (roundDataById == null)
		{
			return;
		}
		roundDataById.UpdateCellDataReward(message.OpenIndex.ToDictionary<int, ScratchCardRewardData>());
		roundDataById.UpdateRemainReward(message.LeftRewardItem.ToDictionary<int, int>());
		this.UpdateAllRoundState();
	}

	// Token: 0x06009BBB RID: 39867 RVA: 0x0028BFB4 File Offset: 0x0028A1B4
	private void InitConditionData(List<ScratchCardTimeInfo> conditionInfos)
	{
		if (this.ConditionDataList.Count > 0)
		{
			return;
		}
		this.ConditionDataList = new List<ScratchTicketConditionData>();
		foreach (ScratchCardTimeInfo condition in conditionInfos)
		{
			ScratchTicketConditionData scratchTicketConditionData = new ScratchTicketConditionData();
			scratchTicketConditionData.Init(condition);
			this.ConditionDataList.Add(scratchTicketConditionData);
		}
	}

	// Token: 0x06009BBC RID: 39868 RVA: 0x0028C030 File Offset: 0x0028A230
	public void RefreshConditionData(List<ScratchCardTimeInfo> conditionInfos)
	{
		foreach (ScratchCardTimeInfo scratchCardTimeInfo in conditionInfos)
		{
			ScratchTicketConditionData conditionData = this.GetConditionData(scratchCardTimeInfo.Id);
			if (conditionData != null)
			{
				conditionData.RefreshCondition(scratchCardTimeInfo);
			}
		}
	}

	// Token: 0x06009BBD RID: 39869 RVA: 0x0028C090 File Offset: 0x0028A290
	public override bool GetExDataRedPointShowState()
	{
		if (!this.ActivityHasClick())
		{
			return true;
		}
		int remainCount = this.GetRemainCount();
		return this.HasRoundInProgress() && remainCount > 0;
	}

	// Token: 0x06009BBE RID: 39870 RVA: 0x0028C0BC File Offset: 0x0028A2BC
	protected override bool GetExDataFinishShowState()
	{
		return base.GetPreGuideQuestFinishState() && this.IsAllRoundFinish();
	}

	// Token: 0x06009BBF RID: 39871 RVA: 0x0028C0CE File Offset: 0x0028A2CE
	public bool IsInit()
	{
		return this.RoundDataList.Count > 0;
	}

	// Token: 0x06009BC0 RID: 39872 RVA: 0x0028C0DE File Offset: 0x0028A2DE
	public bool ActivityHasClick()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 100, 0, 0) == 1;
	}

	// Token: 0x06009BC1 RID: 39873 RVA: 0x0028C0F8 File Offset: 0x0028A2F8
	public void ClickRedDot()
	{
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 100, 0, 0, 1);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06009BC2 RID: 39874 RVA: 0x0028C128 File Offset: 0x0028A328
	[NullableContext(2)]
	private ScratchTicketConditionData GetConditionData(int id)
	{
		foreach (ScratchTicketConditionData scratchTicketConditionData in this.ConditionDataList)
		{
			if (scratchTicketConditionData.Id == id)
			{
				return scratchTicketConditionData;
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.ScratchTicket;
		ELogAuthor author = ELogAuthor.BB;
		string message = "ScratchTicketData无法获取条件id";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x06009BC3 RID: 39875 RVA: 0x0028C1B4 File Offset: 0x0028A3B4
	public ScratchCardActivityRe? GetScratchCardActivityConfig()
	{
		return this.Config;
	}

	// Token: 0x06009BC4 RID: 39876 RVA: 0x0028C1BC File Offset: 0x0028A3BC
	[NullableContext(2)]
	public ScratchTicketRoundData GetRoundDataById(int id)
	{
		foreach (ScratchTicketRoundData scratchTicketRoundData in this.RoundDataList)
		{
			if (scratchTicketRoundData.Id == id)
			{
				return scratchTicketRoundData;
			}
		}
		return null;
	}

	// Token: 0x06009BC5 RID: 39877 RVA: 0x0028C218 File Offset: 0x0028A418
	public int GetFirstProgressRoundDataIndex()
	{
		int count = this.RoundDataList.Count;
		if (count <= 0)
		{
			return -1;
		}
		for (int i = 0; i < count; i++)
		{
			if (this.RoundDataList[i].GetRoundState() != EScratchTicketRoundState.Finish)
			{
				return i;
			}
		}
		return count - 1;
	}

	// Token: 0x06009BC6 RID: 39878 RVA: 0x0028C25C File Offset: 0x0028A45C
	public int GetRoundDataIndex(ScratchTicketRoundData roundData)
	{
		for (int i = 0; i < this.RoundDataList.Count; i++)
		{
			if (this.RoundDataList[i] == roundData)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x06009BC7 RID: 39879 RVA: 0x0028C294 File Offset: 0x0028A494
	[NullableContext(2)]
	public ScratchTicketRoundData GetFirstProgressRoundData()
	{
		int firstProgressRoundDataIndex = this.GetFirstProgressRoundDataIndex();
		if (firstProgressRoundDataIndex < 0)
		{
			return null;
		}
		return this.RoundDataList[firstProgressRoundDataIndex];
	}

	// Token: 0x06009BC8 RID: 39880 RVA: 0x0028C2BA File Offset: 0x0028A4BA
	public List<ScratchTicketRoundData> GetRoundDataList()
	{
		return this.RoundDataList;
	}

	// Token: 0x06009BC9 RID: 39881 RVA: 0x0028C2C2 File Offset: 0x0028A4C2
	public List<ScratchTicketConditionData> GetConditionDataList()
	{
		return this.ConditionDataList;
	}

	// Token: 0x06009BCA RID: 39882 RVA: 0x0028C2CC File Offset: 0x0028A4CC
	public bool IsAllRoundFinish()
	{
		using (List<ScratchTicketRoundData>.Enumerator enumerator = this.RoundDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetRoundState() != EScratchTicketRoundState.Finish)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06009BCB RID: 39883 RVA: 0x0028C328 File Offset: 0x0028A528
	public bool HasRoundInProgress()
	{
		using (List<ScratchTicketRoundData>.Enumerator enumerator = this.RoundDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetRoundState() == EScratchTicketRoundState.InProgress)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06009BCC RID: 39884 RVA: 0x0028C384 File Offset: 0x0028A584
	public int GetRemainCount()
	{
		int itemId = this.Config.Value.ItemId;
		return ModelBase<InventoryModel>.Instance.GetCommonItemCount(itemId, 0);
	}

	// Token: 0x06009BCD RID: 39885 RVA: 0x0028C3B4 File Offset: 0x0028A5B4
	public int GetCostItemId()
	{
		return this.Config.Value.ItemId;
	}

	// Token: 0x040047BF RID: 18367
	private const int SCRATCH_TICKET_RED_DOT_CACHE_KEY = 100;

	// Token: 0x040047C0 RID: 18368
	private List<ScratchTicketRoundData> RoundDataList = new List<ScratchTicketRoundData>();

	// Token: 0x040047C1 RID: 18369
	private List<ScratchTicketConditionData> ConditionDataList = new List<ScratchTicketConditionData>();

	// Token: 0x040047C2 RID: 18370
	private ScratchCardActivityRe? Config;
}
