using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02001488 RID: 5256
[NullableContext(1)]
[Nullable(0)]
public class ActivityNoviceJourneyData : ActivityBaseData
{
	// Token: 0x06009316 RID: 37654 RVA: 0x0026D0DC File Offset: 0x0026B2DC
	public override bool GetExDataRedPointShowState()
	{
		return this.CheckHasCanReceive();
	}

	// Token: 0x06009317 RID: 37655 RVA: 0x0026D0E4 File Offset: 0x0026B2E4
	protected override void PhraseEx(ActivityData data)
	{
		NewBieCourseActivity newBieCourseActivity = data.NewBieCourseActivity;
		this.SetReceiveData(newBieCourseActivity.HadTakeReward.ToArray<int>());
	}

	// Token: 0x06009318 RID: 37656 RVA: 0x0026D10C File Offset: 0x0026B30C
	protected override bool GetExDataFinishShowState()
	{
		foreach (NewbieCourse newbieCourse in ConfigBase<ActivityNoviceJourneyConfig>.Instance.GetNoticeJourneyConfigList())
		{
			if (this.GetRewardStateByLevel(newbieCourse.Id) != NoviceJourneyDefine.EItemState.HasReceived)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06009319 RID: 37657 RVA: 0x0026D150 File Offset: 0x0026B350
	private bool CheckHasCanReceive()
	{
		foreach (NewbieCourse newbieCourse in ConfigBase<ActivityNoviceJourneyConfig>.Instance.GetNoticeJourneyConfigList())
		{
			if (this.GetRewardStateByLevel(newbieCourse.Id) == NoviceJourneyDefine.EItemState.CanReceive)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600931A RID: 37658 RVA: 0x0026D194 File Offset: 0x0026B394
	public void SetReceiveData(int[] receivedList)
	{
		foreach (int item in receivedList)
		{
			this.ReceivedSet.Add(item);
		}
	}

	// Token: 0x0600931B RID: 37659 RVA: 0x0026D1C2 File Offset: 0x0026B3C2
	public void AddReceivedData(int level)
	{
		this.ReceivedSet.Add(level);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.NoticeJourneyReceive, level);
	}

	// Token: 0x0600931C RID: 37660 RVA: 0x0026D1E2 File Offset: 0x0026B3E2
	public bool CheckRewardReceived(int level)
	{
		return this.ReceivedSet.Contains(level);
	}

	// Token: 0x0600931D RID: 37661 RVA: 0x0026D1F0 File Offset: 0x0026B3F0
	public NoviceJourneyDefine.EItemState GetRewardStateByLevel(int level)
	{
		int? playerLevel = ModelBase<PlayerInfoModel>.Instance.GetPlayerLevel();
		if (playerLevel.GetValueOrDefault() < level & playerLevel != null)
		{
			return NoviceJourneyDefine.EItemState.Unaccomplished;
		}
		if (!this.CheckRewardReceived(level))
		{
			return NoviceJourneyDefine.EItemState.CanReceive;
		}
		return NoviceJourneyDefine.EItemState.HasReceived;
	}

	// Token: 0x04004418 RID: 17432
	private readonly HashSet<int> ReceivedSet = new HashSet<int>();
}
