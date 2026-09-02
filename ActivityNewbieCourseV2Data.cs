using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Google.Protobuf.Collections;

// Token: 0x0200144B RID: 5195
[NullableContext(1)]
[Nullable(0)]
public class ActivityNewbieCourseV2Data : ActivityBaseData
{
	// Token: 0x060090A5 RID: 37029 RVA: 0x0026069F File Offset: 0x0025E89F
	protected override void OnInit(ActivityData data)
	{
		this.UpdateProtocolBeginOpenTime(data);
	}

	// Token: 0x060090A6 RID: 37030 RVA: 0x002606A8 File Offset: 0x0025E8A8
	protected override void PhraseEx(ActivityData data)
	{
		this.UpdateProtocolBeginOpenTime(data);
		this.ReceivedSet.Clear();
		NewbieCourseV2ActivityPb newbieCourseV2ActivityPb = data.NewbieCourseV2ActivityPb;
		int[] array;
		if (newbieCourseV2ActivityPb == null)
		{
			array = null;
		}
		else
		{
			RepeatedField<int> hadTakeReward = newbieCourseV2ActivityPb.HadTakeReward;
			array = ((hadTakeReward != null) ? hadTakeReward.ToArray<int>() : null);
		}
		this.SetReceiveData(array ?? Array.Empty<int>());
	}

	// Token: 0x060090A7 RID: 37031 RVA: 0x002606F8 File Offset: 0x0025E8F8
	private void UpdateProtocolBeginOpenTime(ActivityData data)
	{
		NewbieCourseV2ActivityPb newbieCourseV2ActivityPb = data.NewbieCourseV2ActivityPb;
		if (newbieCourseV2ActivityPb != null)
		{
			this.ProtocolBeginOpenTime = Singleton<MathUtils>.Instance.LongToBigInt(newbieCourseV2ActivityPb.BeginOpenTime);
			return;
		}
		if (data.BeginOpenTime != 0L)
		{
			this.ProtocolBeginOpenTime = Singleton<MathUtils>.Instance.LongToBigInt(data.BeginOpenTime);
			return;
		}
		this.ProtocolBeginOpenTime = 0L;
	}

	// Token: 0x060090A8 RID: 37032 RVA: 0x0026074D File Offset: 0x0025E94D
	public override long GetProtocolBeginOpenTime()
	{
		return this.ProtocolBeginOpenTime;
	}

	// Token: 0x060090A9 RID: 37033 RVA: 0x00260755 File Offset: 0x0025E955
	public override bool GetExDataRedPointShowState()
	{
		return this.CheckHasCanReceive();
	}

	// Token: 0x060090AA RID: 37034 RVA: 0x00260760 File Offset: 0x0025E960
	protected override bool GetExDataFinishShowState()
	{
		IReadOnlyList<NewbieCourseV2> configList = ConfigBase<ActivityNewbieCourseV2Config>.Instance.GetConfigList(base.Id);
		if (configList.Count <= 0)
		{
			return false;
		}
		foreach (NewbieCourseV2 newbieCourseV in configList)
		{
			if (this.GetRewardState(newbieCourseV.TargetLevel) != ENewbieCourseV2ItemState.HasReceived)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060090AB RID: 37035 RVA: 0x002607D4 File Offset: 0x0025E9D4
	public void SetReceiveData(int[] receivedList)
	{
		this.ReceivedSet.Clear();
		foreach (int item in receivedList)
		{
			this.ReceivedSet.Add(item);
		}
	}

	// Token: 0x060090AC RID: 37036 RVA: 0x0026080D File Offset: 0x0025EA0D
	public void AddReceivedData(int level)
	{
		this.ReceivedSet.Add(level);
	}

	// Token: 0x060090AD RID: 37037 RVA: 0x0026081C File Offset: 0x0025EA1C
	public ENewbieCourseV2ItemState GetRewardState(int targetLevel)
	{
		int? playerLevel = ModelBase<PlayerInfoModel>.Instance.GetPlayerLevel();
		if (playerLevel.GetValueOrDefault() < targetLevel & playerLevel != null)
		{
			return ENewbieCourseV2ItemState.Unaccomplished;
		}
		if (this.ReceivedSet.Contains(targetLevel))
		{
			return ENewbieCourseV2ItemState.HasReceived;
		}
		return ENewbieCourseV2ItemState.CanReceive;
	}

	// Token: 0x060090AE RID: 37038 RVA: 0x00260860 File Offset: 0x0025EA60
	private bool CheckHasCanReceive()
	{
		foreach (NewbieCourseV2 newbieCourseV in ConfigBase<ActivityNewbieCourseV2Config>.Instance.GetConfigList(base.Id))
		{
			if (this.GetRewardState(newbieCourseV.TargetLevel) == ENewbieCourseV2ItemState.CanReceive)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0400431C RID: 17180
	private readonly HashSet<int> ReceivedSet = new HashSet<int>();

	// Token: 0x0400431D RID: 17181
	private long ProtocolBeginOpenTime;
}
