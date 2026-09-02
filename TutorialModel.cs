using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02002C2C RID: 11308
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class TutorialModel : ModelBase<TutorialModel>
{
	// Token: 0x06016A03 RID: 92675 RVA: 0x00646EE8 File Offset: 0x006450E8
	protected override bool OnInit()
	{
		foreach (object obj in Enum.GetValues(typeof(ETutorialType)))
		{
			int key = (int)obj;
			this.TutorialTotalData.Add((ETutorialType)key, new Dictionary<int, TutorialSaveData>());
		}
		return true;
	}

	// Token: 0x06016A04 RID: 92676 RVA: 0x00646F58 File Offset: 0x00645158
	public void InitTutorialTotalData()
	{
		foreach (TutorialSaveData tutorialSaveData in this.TutorialSaveDataMap.Values.ToList<TutorialSaveData>())
		{
			TutorialSaveData tutorialSaveData2 = new TutorialSaveData();
			tutorialSaveData2.TimeStamp = tutorialSaveData.TimeStamp;
			tutorialSaveData2.TutorialId = tutorialSaveData.TutorialId;
			tutorialSaveData2.HasRedDot = tutorialSaveData.HasRedDot;
			int tutorialType = tutorialSaveData2.TutorialData.Value.TutorialType;
			int id = tutorialSaveData2.TutorialData.Value.Id;
			this.TutorialTotalData[(ETutorialType)tutorialType][id] = tutorialSaveData2;
			this.TutorialTotalData[ETutorialType.All][id] = tutorialSaveData2;
			this.TutorialSaveDataMap[id] = tutorialSaveData2;
		}
	}

	// Token: 0x06016A05 RID: 92677 RVA: 0x00647048 File Offset: 0x00645248
	protected override bool OnClear()
	{
		foreach (Dictionary<int, TutorialSaveData> dictionary in this.TutorialTotalData.Values)
		{
			dictionary.Clear();
		}
		this.TutorialTotalData.Clear();
		return true;
	}

	// Token: 0x06016A06 RID: 92678 RVA: 0x006470AC File Offset: 0x006452AC
	public void InitUnlockTutorials(IReadOnlyList<TutorialInfo> tutorialInfos)
	{
		foreach (TutorialInfo tutorialInfo in tutorialInfos)
		{
			TutorialSaveData tutorialSaveData = new TutorialSaveData();
			tutorialSaveData.TimeStamp = (int)tutorialInfo.CreateTime;
			tutorialSaveData.TutorialId = tutorialInfo.Id;
			tutorialSaveData.HasRedDot = !tutorialInfo.GetAward;
			int tutorialType = tutorialSaveData.TutorialData.Value.TutorialType;
			if (Enum.IsDefined(typeof(ETutorialType), tutorialType))
			{
				if (!this.TutorialTotalData[(ETutorialType)tutorialType].ContainsKey(tutorialSaveData.TutorialId))
				{
					this.TutorialTotalData[(ETutorialType)tutorialType].Add(tutorialSaveData.TutorialId, tutorialSaveData);
					this.TutorialSaveDataMap.Add(tutorialSaveData.TutorialId, tutorialSaveData);
				}
				this.InvokeTutorialRedDot(tutorialSaveData);
			}
		}
	}

	// Token: 0x06016A07 RID: 92679 RVA: 0x0064719C File Offset: 0x0064539C
	public void InitDefaultUnlockTutorials()
	{
		foreach (GuideTutorial guideTutorial in ConfigBase<GuideConfig>.Instance.GetAllTutorial())
		{
			if (guideTutorial.DefaultUnlock)
			{
				TutorialSaveData tutorialSaveData = new TutorialSaveData();
				tutorialSaveData.TimeStamp = 0;
				tutorialSaveData.TutorialId = guideTutorial.Id;
				tutorialSaveData.HasRedDot = false;
				int tutorialType = guideTutorial.TutorialType;
				if (Enum.IsDefined(typeof(ETutorialType), tutorialType))
				{
					this.TutorialTotalData[(ETutorialType)tutorialType].Add(tutorialSaveData.TutorialId, tutorialSaveData);
					this.TutorialSaveDataMap.Add(tutorialSaveData.TutorialId, tutorialSaveData);
				}
			}
		}
	}

	// Token: 0x06016A08 RID: 92680 RVA: 0x0064725C File Offset: 0x0064545C
	public void UpdateUnlockTutorials(TutorialInfo tutorialInfo)
	{
		TutorialSaveData tutorialSaveData = new TutorialSaveData();
		tutorialSaveData.TimeStamp = (int)tutorialInfo.CreateTime;
		tutorialSaveData.TutorialId = tutorialInfo.Id;
		tutorialSaveData.HasRedDot = !tutorialInfo.GetAward;
		int tutorialType = tutorialSaveData.TutorialData.Value.TutorialType;
		if (!Enum.IsDefined(typeof(ETutorialType), tutorialType))
		{
			return;
		}
		if (this.TutorialTotalData[(ETutorialType)tutorialType].ContainsKey(tutorialSaveData.TutorialId))
		{
			return;
		}
		this.TutorialTotalData[(ETutorialType)tutorialType].Add(tutorialSaveData.TutorialId, tutorialSaveData);
		this.TutorialTotalData[ETutorialType.All].Add(tutorialSaveData.TutorialId, tutorialSaveData);
		this.TutorialSaveDataMap.Add(tutorialSaveData.TutorialId, tutorialSaveData);
		this.InvokeUpdateTutorials();
		this.InvokeTutorialRedDot(tutorialSaveData);
	}

	// Token: 0x06016A09 RID: 92681 RVA: 0x00647330 File Offset: 0x00645530
	public List<TutorialItemData> GetUnlockedTutorialDataByType(ETutorialType tType, EExclusiveTutorialType exclusiveType = EExclusiveTutorialType.None)
	{
		Dictionary<int, TutorialSaveData> dictionary = this.TutorialTotalData[tType];
		List<TutorialItemData> list = new List<TutorialItemData>();
		foreach (TutorialSaveData tutorialSaveData in dictionary.Values)
		{
			if (!tutorialSaveData.IsExcludedFromWiki)
			{
				GuideTutorial? tutorialData = tutorialSaveData.TutorialData;
				int? num = (tutorialData != null) ? new int?(tutorialData.GetValueOrDefault().ExclusiveType) : null;
				if (num.GetValueOrDefault() == (int)exclusiveType & num != null)
				{
					TutorialItemData tutorialItemData = new TutorialItemData();
					tutorialItemData.IsTypeTitle = false;
					tutorialData = tutorialSaveData.TutorialData;
					tutorialItemData.TextId = tutorialData.Value.GroupName;
					tutorialItemData.SavedData = tutorialSaveData;
					tutorialItemData.OwnerType = new ETutorialType?(tType);
					TutorialItemData item = tutorialItemData;
					if (tutorialSaveData.HasRedDot)
					{
						this.InvokeTutorialRedDot(tutorialSaveData);
					}
					list.Add(item);
				}
			}
		}
		list.Sort(delegate(TutorialItemData d1, TutorialItemData d2)
		{
			if (d1.SavedData.HasRedDot && !d2.SavedData.HasRedDot)
			{
				return -1;
			}
			if (!d1.SavedData.HasRedDot && d2.SavedData.HasRedDot)
			{
				return 1;
			}
			if (d1.SavedData.HasRedDot && d2.SavedData.HasRedDot)
			{
				return d2.SavedData.TimeStamp - d1.SavedData.TimeStamp;
			}
			if (tType == ETutorialType.All)
			{
				return d2.SavedData.TimeStamp - d1.SavedData.TimeStamp;
			}
			GuideTutorial value = d1.SavedData.TutorialData.Value;
			GuideTutorial value2 = d2.SavedData.TutorialData.Value;
			if (d1.SavedData.TimeStamp != d2.SavedData.TimeStamp)
			{
				return d1.SavedData.TimeStamp - d2.SavedData.TimeStamp;
			}
			if (value.TutorialOrder != value2.TutorialOrder)
			{
				return value.TutorialOrder - value2.TutorialOrder;
			}
			return value.Id - value2.Id;
		});
		bool flag = tType > ETutorialType.All;
		bool flag2 = exclusiveType > EExclusiveTutorialType.None;
		if (flag || flag2)
		{
			return list;
		}
		int val = list.Count;
		for (int i = 0; i < list.Count; i++)
		{
			if (!list[i].SavedData.HasRedDot)
			{
				val = i + TutorialUtils.MaxLatestTutorial.Value;
				break;
			}
		}
		return list.GetRange(0, Math.Min(val, list.Count));
	}

	// Token: 0x06016A0A RID: 92682 RVA: 0x006474DC File Offset: 0x006456DC
	public void RemoveRedDotTutorialId(int tutorialId)
	{
		if (!this.TutorialSaveDataMap.ContainsKey(tutorialId))
		{
			return;
		}
		TutorialSaveData tutorialSaveData = this.TutorialSaveDataMap[tutorialId];
		tutorialSaveData.HasRedDot = false;
		this.InvokeTutorialRedDot(tutorialSaveData);
	}

	// Token: 0x06016A0B RID: 92683 RVA: 0x00647514 File Offset: 0x00645714
	public bool RedDotCheckIsNewTutorial(int tutorialId)
	{
		TutorialSaveData tutorialSaveData;
		return this.TutorialSaveDataMap.TryGetValue(tutorialId, out tutorialSaveData) && tutorialSaveData.HasRedDot;
	}

	// Token: 0x06016A0C RID: 92684 RVA: 0x00647539 File Offset: 0x00645739
	public void InvokeUpdateTutorials()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnTutorialUpdate);
	}

	// Token: 0x06016A0D RID: 92685 RVA: 0x0064754C File Offset: 0x0064574C
	[NullableContext(2)]
	public void InvokeTutorialRedDot(TutorialSaveData saveData = null)
	{
		int p = (saveData != null) ? saveData.TutorialId : 0;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RedDotNewTutorial, p);
		if (saveData != null)
		{
			Singleton<EventSystem>.Instance.Emit<ETutorialType>(EEventName.RedDotNewTutorialType, ETutorialType.All);
		}
	}

	// Token: 0x06016A0E RID: 92686 RVA: 0x0064758C File Offset: 0x0064578C
	public bool RedDotCheckIsNewTutorialType(ETutorialType tType)
	{
		if (!this.TutorialTotalData.ContainsKey(tType))
		{
			return false;
		}
		foreach (TutorialSaveData tutorialSaveData in this.TutorialTotalData[tType].Values)
		{
			GuideTutorial? guideTutorial;
			int? num = (tutorialSaveData.TutorialData != null) ? new int?(guideTutorial.GetValueOrDefault().ExclusiveType) : null;
			int currentExclusiveType = (int)this.CurrentExclusiveType;
			if ((num.GetValueOrDefault() == currentExclusiveType & num != null) && tutorialSaveData.HasRedDot && !tutorialSaveData.IsExcludedFromWiki)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06016A0F RID: 92687 RVA: 0x0064765C File Offset: 0x0064585C
	[return: TupleElementNames(new string[]
	{
		"ItemData",
		"HasTutorial"
	})]
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public ValueTuple<List<TutorialItemData>, bool> MakeSearchList(string searchText, ETutorialType? currentType, EExclusiveTutorialType exclusiveType = EExclusiveTutorialType.None)
	{
		Regex regex = null;
		List<TutorialItemData> list = new List<TutorialItemData>();
		try
		{
			regex = new Regex(searchText, RegexOptions.IgnoreCase);
		}
		catch
		{
			return new ValueTuple<List<TutorialItemData>, bool>(list, false);
		}
		bool item = false;
		foreach (ETutorialType etutorialType in this.TutorialTotalData.Keys.OrderBy(delegate(ETutorialType t)
		{
			ETutorialType? currentType3 = currentType;
			if (!(t == currentType3.GetValueOrDefault() & currentType3 != null))
			{
				return 1;
			}
			return -1;
		}).ToList<ETutorialType>())
		{
			if (etutorialType != ETutorialType.All)
			{
				List<TutorialItemData> list2 = new List<TutorialItemData>();
				foreach (TutorialSaveData tutorialSaveData in this.TutorialTotalData[etutorialType].Values)
				{
					if (!tutorialSaveData.IsExcludedFromWiki)
					{
						GuideTutorial? tutorialData = tutorialSaveData.TutorialData;
						int? num = (tutorialData != null) ? new int?(tutorialData.GetValueOrDefault().ExclusiveType) : null;
						if (num.GetValueOrDefault() == (int)exclusiveType & num != null)
						{
							string tutorialTitle = tutorialSaveData.GetTutorialTitle();
							if (regex.Match(tutorialTitle).Success)
							{
								TutorialItemData tutorialItemData = new TutorialItemData();
								tutorialItemData.IsTypeTitle = false;
								tutorialData = tutorialSaveData.TutorialData;
								tutorialItemData.TextId = tutorialData.Value.GroupName;
								tutorialItemData.SavedData = tutorialSaveData;
								tutorialItemData.Text = tutorialTitle.Replace(searchText, TutorialUtils.AddSearchHighlight(searchText));
								TutorialItemData item2 = tutorialItemData;
								item = true;
								list2.Add(item2);
							}
						}
					}
				}
				ETutorialType? currentType2 = currentType;
				ETutorialType etutorialType2 = ETutorialType.All;
				if (currentType2.GetValueOrDefault() == etutorialType2 & currentType2 != null)
				{
					list.AddRange(list2);
				}
				else if (list2.Count > 0)
				{
					list.Add(new TutorialItemData
					{
						IsTypeTitle = true,
						TextId = TutorialUtils.GetTutorialTypeTxt(etutorialType)
					});
					list.AddRange(list2);
				}
			}
		}
		return new ValueTuple<List<TutorialItemData>, bool>(list, item);
	}

	// Token: 0x06016A10 RID: 92688 RVA: 0x006478B4 File Offset: 0x00645AB4
	[NullableContext(2)]
	public TutorialSaveData GetSavedDataById(int tId)
	{
		TutorialSaveData result;
		if (this.TutorialSaveDataMap.TryGetValue(tId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0400AE9E RID: 44702
	[Nullable(2)]
	public ItemRewardNotify RewardInfo;

	// Token: 0x0400AE9F RID: 44703
	[Nullable(new byte[]
	{
		1,
		0
	})]
	public List<ValueTuple<int, int>> RewardList = new List<ValueTuple<int, int>>();

	// Token: 0x0400AEA0 RID: 44704
	public EExclusiveTutorialType CurrentExclusiveType;

	// Token: 0x0400AEA1 RID: 44705
	private readonly Dictionary<ETutorialType, Dictionary<int, TutorialSaveData>> TutorialTotalData = new Dictionary<ETutorialType, Dictionary<int, TutorialSaveData>>();

	// Token: 0x0400AEA2 RID: 44706
	private readonly Dictionary<int, TutorialSaveData> TutorialSaveDataMap = new Dictionary<int, TutorialSaveData>();
}
