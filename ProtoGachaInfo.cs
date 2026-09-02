using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Google.Protobuf.Collections;

// Token: 0x02001D0F RID: 7439
[NullableContext(1)]
[Nullable(0)]
public class ProtoGachaInfo
{
	// Token: 0x0600DA78 RID: 55928 RVA: 0x003AB418 File Offset: 0x003A9618
	public ProtoGachaInfo(GachaInfo gachaInfo)
	{
		this.Id = gachaInfo.Id;
		this.TodayTimes = gachaInfo.TodayTimes;
		this.TotalTimes = gachaInfo.TotalTimes;
		this.ItemId = gachaInfo.ItemId;
		this.GachaConsumes = gachaInfo.GachaConsumes.ToArray<GachaConsume>();
		this.UsePoolId = gachaInfo.UsePoolId;
		this.GachaAccumulateId = gachaInfo.GachaAccumulateId;
		this.GachaDiscountInfos = gachaInfo.GachaDiscountInfos.ToArray<GachaDiscountInfo>();
		this.OnlyViewDiscount = gachaInfo.OnlyViewDiscount;
		this.IsShowProgress = gachaInfo.IsShowProgress;
		foreach (KeyValuePair<int, string> keyValuePair in gachaInfo.DiscountTagDetails)
		{
			this.DiscountTagDetails[keyValuePair.Key] = keyValuePair.Value;
		}
		RepeatedField<GachaPoolInfo> pools = gachaInfo.Pools;
		if (pools != null)
		{
			List<ProtoGachaPoolInfo> list = new List<ProtoGachaPoolInfo>();
			foreach (GachaPoolInfo poolInfo in pools)
			{
				list.Add(new ProtoGachaPoolInfo(poolInfo));
			}
			this.Pools = list.ToArray();
		}
		this.BeginTime = (double)Singleton<MathUtils>.Instance.LongToNumber(gachaInfo.BeginTime);
		this.EndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(gachaInfo.EndTime);
		this.DailyLimitTimes = gachaInfo.DailyLimitTimes;
		this.TotalLimitTimes = gachaInfo.TotalLimitTimes;
		this.ResourcesId = gachaInfo.ResourcesId;
		Gacha? gachaConfig = ConfigBase<GachaConfig>.Instance.GetGachaConfig(this.Id);
		if (gachaConfig != null)
		{
			this.Sort = gachaConfig.Value.Sort;
			this.GroupId = gachaConfig.Value.RuleGroupId;
		}
	}

	// Token: 0x0600DA79 RID: 55929 RVA: 0x003AB628 File Offset: 0x003A9828
	[NullableContext(2)]
	public ProtoGachaPoolInfo GetFirstValidPool()
	{
		ProtoGachaPoolInfo[] validPoolList = this.GetValidPoolList();
		if (validPoolList != null && validPoolList.Length != 0)
		{
			return validPoolList[0];
		}
		return null;
	}

	// Token: 0x0600DA7A RID: 55930 RVA: 0x003AB648 File Offset: 0x003A9848
	[NullableContext(2)]
	public ProtoGachaPoolInfo GetPoolInfo(int poolId)
	{
		ProtoGachaPoolInfo result = null;
		foreach (ProtoGachaPoolInfo protoGachaPoolInfo in this.Pools)
		{
			if (protoGachaPoolInfo.Id == poolId)
			{
				result = protoGachaPoolInfo;
			}
		}
		return result;
	}

	// Token: 0x0600DA7B RID: 55931 RVA: 0x003AB67C File Offset: 0x003A987C
	[NullableContext(2)]
	public ProtoGachaPoolInfo GetCurrentPoolInfo()
	{
		if (this.UsePoolId == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.Gacha, ELogAuthor.LPH, "ProtoGachaInfo.GetCurrentPoolInfo UsePoolId is 0!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return this.GetPoolInfo(this.UsePoolId);
	}

	// Token: 0x0600DA7C RID: 55932 RVA: 0x003AB6C0 File Offset: 0x003A98C0
	public double GetPoolEndTimeByPoolId(int poolId)
	{
		ProtoGachaPoolInfo poolInfo = this.GetPoolInfo(poolId);
		return this.GetPoolEndTimeByPoolInfo(poolInfo);
	}

	// Token: 0x0600DA7D RID: 55933 RVA: 0x003AB6DC File Offset: 0x003A98DC
	[NullableContext(2)]
	public double GetPoolEndTimeByPoolInfo(ProtoGachaPoolInfo poolInfo)
	{
		double endTime = this.EndTime;
		if (poolInfo == null)
		{
			return endTime;
		}
		double endTime2 = poolInfo.EndTime;
		if (endTime2 == 0.0)
		{
			return endTime;
		}
		if (endTime == 0.0)
		{
			return endTime2;
		}
		if (endTime >= endTime2)
		{
			return endTime2;
		}
		return endTime;
	}

	// Token: 0x0600DA7E RID: 55934 RVA: 0x003AB720 File Offset: 0x003A9920
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public ProtoGachaPoolInfo[] GetValidPoolList()
	{
		ProtoGachaPoolInfo[] pools = this.Pools;
		if (pools == null)
		{
			return null;
		}
		List<ProtoGachaPoolInfo> list = new List<ProtoGachaPoolInfo>();
		foreach (ProtoGachaPoolInfo protoGachaPoolInfo in pools)
		{
			if (this.IsPoolValid(protoGachaPoolInfo))
			{
				list.Add(protoGachaPoolInfo);
			}
		}
		list.Sort((ProtoGachaPoolInfo a, ProtoGachaPoolInfo b) => a.Sort - b.Sort);
		return list.ToArray();
	}

	// Token: 0x0600DA7F RID: 55935 RVA: 0x003AB794 File Offset: 0x003A9994
	public bool IsPoolValid(ProtoGachaPoolInfo poolInfo)
	{
		double poolEndTimeByPoolInfo = this.GetPoolEndTimeByPoolInfo(poolInfo);
		return poolEndTimeByPoolInfo == 0.0 || poolEndTimeByPoolInfo >= Singleton<TimeUtil>.Instance.GetServerTime();
	}

	// Token: 0x04006855 RID: 26709
	public readonly int Id;

	// Token: 0x04006856 RID: 26710
	public int TodayTimes;

	// Token: 0x04006857 RID: 26711
	public int TotalTimes;

	// Token: 0x04006858 RID: 26712
	public readonly int ItemId;

	// Token: 0x04006859 RID: 26713
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public readonly GachaConsume[] GachaConsumes;

	// Token: 0x0400685A RID: 26714
	public int UsePoolId;

	// Token: 0x0400685B RID: 26715
	private readonly ProtoGachaPoolInfo[] Pools = Array.Empty<ProtoGachaPoolInfo>();

	// Token: 0x0400685C RID: 26716
	public readonly double BeginTime;

	// Token: 0x0400685D RID: 26717
	public readonly double EndTime;

	// Token: 0x0400685E RID: 26718
	public readonly int DailyLimitTimes;

	// Token: 0x0400685F RID: 26719
	public readonly int TotalLimitTimes;

	// Token: 0x04006860 RID: 26720
	public readonly string ResourcesId = "";

	// Token: 0x04006861 RID: 26721
	public int GroupId;

	// Token: 0x04006862 RID: 26722
	public int Sort;

	// Token: 0x04006863 RID: 26723
	public int GachaAccumulateId;

	// Token: 0x04006864 RID: 26724
	public GachaDiscountInfo[] GachaDiscountInfos = Array.Empty<GachaDiscountInfo>();

	// Token: 0x04006865 RID: 26725
	public bool OnlyViewDiscount;

	// Token: 0x04006866 RID: 26726
	public bool IsShowProgress;

	// Token: 0x04006867 RID: 26727
	public Dictionary<int, string> DiscountTagDetails = new Dictionary<int, string>();
}
