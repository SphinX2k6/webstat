using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Google.Protobuf.Collections;

// Token: 0x020024A5 RID: 9381
[NullableContext(1)]
[Nullable(0)]
public class VisionFetterRecommendInfo
{
	// Token: 0x0601232F RID: 74543 RVA: 0x0050170B File Offset: 0x004FF90B
	public VisionFetterRecommendInfo()
	{
		this.CountList = new List<IVisionFetterCount>();
		this.CostCombinations = new List<ICostCombinationData>();
	}

	// Token: 0x06012330 RID: 74544 RVA: 0x00501734 File Offset: 0x004FF934
	public int GetRecommendFetterGroupId()
	{
		return this.FetterGroupId;
	}

	// Token: 0x06012331 RID: 74545 RVA: 0x0050173C File Offset: 0x004FF93C
	public int GetSpecialFetterSubGroupId()
	{
		return this.FetterGroupSubId;
	}

	// Token: 0x06012332 RID: 74546 RVA: 0x00501744 File Offset: 0x004FF944
	public int GetPlanId()
	{
		return VisionFetterRecommendInfo.EncodePlanId(this.FetterGroupId, this.FetterGroupSubId);
	}

	// Token: 0x06012333 RID: 74547 RVA: 0x00501757 File Offset: 0x004FF957
	public int GetUsage()
	{
		return this.Usage;
	}

	// Token: 0x06012334 RID: 74548 RVA: 0x00501760 File Offset: 0x004FF960
	public string GetUsageText()
	{
		double num = (double)(this.Usage - this.Usage % 10) / 100.0;
		if (this.Usage != 0)
		{
			return num.ToString("F1") + "%";
		}
		return "";
	}

	// Token: 0x06012335 RID: 74549 RVA: 0x005017AD File Offset: 0x004FF9AD
	public List<IVisionFetterCount> GetFetterCountList()
	{
		return this.CountList;
	}

	// Token: 0x06012336 RID: 74550 RVA: 0x005017B5 File Offset: 0x004FF9B5
	public EFetterGroupType GetFetterType()
	{
		return this.FetterGroupType;
	}

	// Token: 0x06012337 RID: 74551 RVA: 0x005017BD File Offset: 0x004FF9BD
	public List<ICostCombinationData> GetCostCombinations()
	{
		return this.CostCombinations;
	}

	// Token: 0x06012338 RID: 74552 RVA: 0x005017C5 File Offset: 0x004FF9C5
	public List<global::MainPhantomRecommendInfo> GetMainPhantomList()
	{
		return this.MainPhantomList;
	}

	// Token: 0x06012339 RID: 74553 RVA: 0x005017D0 File Offset: 0x004FF9D0
	public void Phrase(PhantomFetterRecommendInfo data)
	{
		this.PhraseIdAndCount(data);
		this.Usage = data.Usage;
		this.FetterGroupType = (EFetterGroupType)ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(this.FetterGroupId).FetterType;
		this.PhraseCostCombinations(data);
		this.PhraseMainPhantoms(data);
	}

	// Token: 0x0601233A RID: 74554 RVA: 0x0050181C File Offset: 0x004FFA1C
	private void PhraseMainPhantoms(PhantomFetterRecommendInfo data)
	{
		this.MainPhantomList.Clear();
		RepeatedField<Aki.Protocol.MainPhantomRecommendInfo> mainPhantomRecommendInfos = data.MainPhantomRecommendInfos;
		if (mainPhantomRecommendInfos == null || mainPhantomRecommendInfos.Count == 0)
		{
			return;
		}
		foreach (Aki.Protocol.MainPhantomRecommendInfo data2 in mainPhantomRecommendInfos)
		{
			global::MainPhantomRecommendInfo mainPhantomRecommendInfo = new global::MainPhantomRecommendInfo();
			mainPhantomRecommendInfo.Phrase(data2);
			this.MainPhantomList.Add(mainPhantomRecommendInfo);
		}
		this.MainPhantomList.Sort((global::MainPhantomRecommendInfo a, global::MainPhantomRecommendInfo b) => b.GetUsage() - a.GetUsage());
		if (this.Usage != 0)
		{
			List<global::MainPhantomRecommendInfo> list = new List<global::MainPhantomRecommendInfo>();
			foreach (global::MainPhantomRecommendInfo mainPhantomRecommendInfo2 in this.MainPhantomList)
			{
				if (mainPhantomRecommendInfo2.GetUsage() >= 1000)
				{
					list.Add(mainPhantomRecommendInfo2);
				}
			}
			if (list.Count > 3)
			{
				list = list.GetRange(0, 3);
			}
			this.MainPhantomList.Clear();
			this.MainPhantomList.AddRange(list);
		}
	}

	// Token: 0x0601233B RID: 74555 RVA: 0x00501950 File Offset: 0x004FFB50
	private void PhraseCostCombinations(PhantomFetterRecommendInfo data)
	{
		this.CostCombinations = new List<ICostCombinationData>();
		RepeatedField<CostCombinationInfo> costCombinationInfos = data.CostCombinationInfos;
		if (costCombinationInfos == null || costCombinationInfos.Count == 0)
		{
			return;
		}
		foreach (CostCombinationInfo costCombinationInfo in costCombinationInfos)
		{
			int costId = costCombinationInfo.CostId;
			this.CostCombinations.Add(new CostCombinationData
			{
				CostId = costId,
				Costs = VisionFetterRecommendInfo.DecodeCostId(costId),
				Usage = costCombinationInfo.Usage
			});
		}
	}

	// Token: 0x0601233C RID: 74556 RVA: 0x005019E8 File Offset: 0x004FFBE8
	public static List<int> DecodeCostId(int costId)
	{
		List<int> list = new List<int>();
		for (int i = 28; i >= 0; i -= 4)
		{
			int num = (int)((uint)costId >> i & 15U);
			if (num > 0)
			{
				list.Add(num);
			}
		}
		return list;
	}

	// Token: 0x0601233D RID: 74557 RVA: 0x00501A1E File Offset: 0x004FFC1E
	public static int EncodePlanId(int fetterGroupId, int fetterGroupSubId)
	{
		if (fetterGroupSubId <= 0)
		{
			return fetterGroupId;
		}
		return fetterGroupId << 16 | (fetterGroupSubId & 65535);
	}

	// Token: 0x0601233E RID: 74558 RVA: 0x00501A34 File Offset: 0x004FFC34
	private unsafe void PhraseIdAndCount(PhantomFetterRecommendInfo data)
	{
		this.CountList = new List<IVisionFetterCount>();
		RepeatedField<PhantomFetterGroupInfo> phantomFetterGroupInfos = data.PhantomFetterGroupInfos;
		if (phantomFetterGroupInfos.Count < 2 || phantomFetterGroupInfos.Count > 3)
		{
			Singleton<Log>.Instance.Error(ELogModule.Phantom, ELogAuthor.WDX, "推荐的套装羁绊数量异常，请确认配置与统计", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		int? num = null;
		int? num2 = null;
		foreach (PhantomFetterGroupInfo phantomFetterGroupInfo in phantomFetterGroupInfos)
		{
			int phantomFetterGroupId = phantomFetterGroupInfo.PhantomFetterGroupId;
			int countNeed = phantomFetterGroupInfo.CountNeed;
			PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(phantomFetterGroupId);
			if (fetterGroupById.FetterType == 1)
			{
				num = new int?(phantomFetterGroupId);
			}
			else
			{
				num2 = new int?(phantomFetterGroupId);
			}
			int fetterId;
			if (!fetterGroupById.FetterMap().TryGetValue(countNeed, out fetterId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Phantom;
				ELogAuthor author = ELogAuthor.WDX;
				string message = "推荐的套装没有对应的羁绊效果";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Group", phantomFetterGroupId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Count", countNeed);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			else
			{
				VisionFetterCount item = new VisionFetterCount
				{
					GroupId = phantomFetterGroupId,
					Count = countNeed,
					FetterId = fetterId
				};
				this.CountList.Add(item);
			}
		}
		this.FetterGroupId = (num ?? ((phantomFetterGroupInfos.Count > 0) ? phantomFetterGroupInfos[0].PhantomFetterGroupId : 0));
		this.FetterGroupSubId = ((num != null) ? num2.GetValueOrDefault() : 0);
	}

	// Token: 0x0601233F RID: 74559 RVA: 0x00501BF4 File Offset: 0x004FFDF4
	public List<int> BuildFetterList()
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (IVisionFetterCount visionFetterCount in this.GetFetterCountList())
		{
			hashSet.Add(visionFetterCount.GroupId);
		}
		List<int> list = new List<int>(hashSet);
		list.Sort(delegate(int a, int b)
		{
			PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(a);
			PhantomFetterGroup fetterGroupById2 = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(b);
			if (fetterGroupById.FetterType != fetterGroupById2.FetterType)
			{
				return fetterGroupById2.FetterType - fetterGroupById.FetterType;
			}
			return b - a;
		});
		return list;
	}

	// Token: 0x06012340 RID: 74560 RVA: 0x00501C80 File Offset: 0x004FFE80
	public List<IVisionNewRecommendFetterItemData> BuildFetterItemDataList()
	{
		Dictionary<int, IVisionNewRecommendFetterItemData> dictionary = new Dictionary<int, IVisionNewRecommendFetterItemData>();
		foreach (IVisionFetterCount visionFetterCount in this.GetFetterCountList())
		{
			IVisionNewRecommendFetterItemData visionNewRecommendFetterItemData;
			if (dictionary.TryGetValue(visionFetterCount.GroupId, out visionNewRecommendFetterItemData))
			{
				visionNewRecommendFetterItemData.Count = Math.Max(visionNewRecommendFetterItemData.Count, visionFetterCount.Count);
			}
			else
			{
				visionNewRecommendFetterItemData = new VisionNewRecommendFetterItemData
				{
					GroupId = visionFetterCount.GroupId,
					Count = visionFetterCount.Count
				};
				dictionary[visionFetterCount.GroupId] = visionNewRecommendFetterItemData;
			}
		}
		List<IVisionNewRecommendFetterItemData> list = new List<IVisionNewRecommendFetterItemData>(dictionary.Values);
		list.Sort(delegate(IVisionNewRecommendFetterItemData a, IVisionNewRecommendFetterItemData b)
		{
			PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(a.GroupId);
			PhantomFetterGroup fetterGroupById2 = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(b.GroupId);
			if (fetterGroupById.FetterType != fetterGroupById2.FetterType)
			{
				return fetterGroupById2.FetterType - fetterGroupById.FetterType;
			}
			return b.GroupId - a.GroupId;
		});
		return list;
	}

	// Token: 0x04008DFC RID: 36348
	private const int COST_BITS = 4;

	// Token: 0x04008DFD RID: 36349
	private const int COST_MASK = 15;

	// Token: 0x04008DFE RID: 36350
	private const int PLAN_ID_GROUP_SHIFT = 16;

	// Token: 0x04008DFF RID: 36351
	private const int PLAN_ID_SUB_MASK = 65535;

	// Token: 0x04008E00 RID: 36352
	private const int MAIN_PHANTOM_RECOMMEND_USAGE_THRESHOLD = 1000;

	// Token: 0x04008E01 RID: 36353
	private const int MAIN_PHANTOM_USAGE_DISPLAY_LIMIT = 3;

	// Token: 0x04008E02 RID: 36354
	private int FetterGroupId;

	// Token: 0x04008E03 RID: 36355
	private int FetterGroupSubId;

	// Token: 0x04008E04 RID: 36356
	private int Usage;

	// Token: 0x04008E05 RID: 36357
	private EFetterGroupType FetterGroupType;

	// Token: 0x04008E06 RID: 36358
	private List<IVisionFetterCount> CountList;

	// Token: 0x04008E07 RID: 36359
	private List<ICostCombinationData> CostCombinations;

	// Token: 0x04008E08 RID: 36360
	private readonly List<global::MainPhantomRecommendInfo> MainPhantomList = new List<global::MainPhantomRecommendInfo>();
}
