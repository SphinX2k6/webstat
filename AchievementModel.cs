using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02000FD4 RID: 4052
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class AchievementModel : ModelBase<AchievementModel>
{
	// Token: 0x0600683C RID: 26684 RVA: 0x001B250C File Offset: 0x001B070C
	private void InitAchievementGroupMapData(int group)
	{
		List<AchievementData> list = new List<AchievementData>();
		foreach (Achievement achievement in ConfigBase<AchievementConfig>.Instance.GetAchievementGroupAchievementList(group))
		{
			AchievementData achievementData = this.GetAchievementData(achievement.Id);
			list.Add(achievementData);
		}
		this.AchievementGroupMap[group] = list;
	}

	// Token: 0x0600683D RID: 26685 RVA: 0x001B2580 File Offset: 0x001B0780
	private void InitAchievementCategoryGroupData(int categoryId)
	{
		IEnumerable<AchievementGroup> achievementCategoryGroups = ConfigBase<AchievementConfig>.Instance.GetAchievementCategoryGroups(categoryId);
		List<AchievementGroupData> list = new List<AchievementGroupData>();
		foreach (AchievementGroup achievementGroup in achievementCategoryGroups)
		{
			AchievementGroupData achievementGroupData = this.GetAchievementGroupData(new int?(achievementGroup.Id));
			list.Add(achievementGroupData);
		}
		this.AchievementCategoryGroupMap[categoryId] = list;
	}

	// Token: 0x0600683E RID: 26686 RVA: 0x001B25F8 File Offset: 0x001B07F8
	private void InitAchievementCategoryData()
	{
		this.AchievementCategoryArray = new List<AchievementCategoryData>();
		foreach (AchievementCategory achievementCategory in ConfigBase<AchievementConfig>.Instance.GetAllAchievementCategory())
		{
			AchievementCategoryData item = new AchievementCategoryData(achievementCategory.Id);
			if (this.showFunctionList.Contains(achievementCategory.FunctionType))
			{
				this.AchievementCategoryArray.Add(item);
			}
		}
	}

	// Token: 0x0600683F RID: 26687 RVA: 0x001B267C File Offset: 0x001B087C
	private void AddDataToCanGetArray(AchievementData data)
	{
		if (!this.CanGetRewardAchievements.Contains(data))
		{
			this.CanGetRewardAchievements.Add(data);
		}
	}

	// Token: 0x06006840 RID: 26688 RVA: 0x001B2698 File Offset: 0x001B0898
	private void AddDataToHasGetArray(AchievementData data)
	{
		if (!this.HasGetRewardAchievements.Contains(data))
		{
			this.HasGetRewardAchievements.Add(data);
		}
	}

	// Token: 0x06006841 RID: 26689 RVA: 0x001B26B4 File Offset: 0x001B08B4
	private void ClearCacheIds(AchievementData data)
	{
		int num = this.CanGetRewardAchievements.IndexOf(data);
		if (num >= 0)
		{
			this.CanGetRewardAchievements.RemoveAt(num);
		}
		int num2 = this.HasGetRewardAchievements.IndexOf(data);
		if (num2 >= 0)
		{
			this.HasGetRewardAchievements.RemoveAt(num2);
		}
	}

	// Token: 0x06006842 RID: 26690 RVA: 0x001B26FB File Offset: 0x001B08FB
	private void SortCanGetRewardAchievements()
	{
		this.CanGetRewardAchievements.Sort(this.SortFunc);
	}

	// Token: 0x06006843 RID: 26691 RVA: 0x001B270E File Offset: 0x001B090E
	private void SortHasGetRewardAchievements()
	{
		this.HasGetRewardAchievements.Sort(this.SortFunc);
	}

	// Token: 0x06006844 RID: 26692 RVA: 0x001B2724 File Offset: 0x001B0924
	private void InitAchievementData(int id)
	{
		AchievementData achievementData = new AchievementData(id);
		if (!achievementData.IfSingleAchievement())
		{
			int nextLink = achievementData.GetNextLink();
			if (nextLink > 0)
			{
				this.GetAchievementData(nextLink).SetLastLink(id);
			}
		}
		this.AchievementMap[id] = achievementData;
	}

	// Token: 0x06006845 RID: 26693 RVA: 0x001B2768 File Offset: 0x001B0968
	private void InitAchievementGroupData(int groupId)
	{
		AchievementGroupData value = new AchievementGroupData(groupId);
		this.AllAchievementGroupMap[groupId] = value;
	}

	// Token: 0x06006846 RID: 26694 RVA: 0x001B278C File Offset: 0x001B098C
	public void PhraseBaseData(AchievementInfoResponse response)
	{
		Singleton<Log>.Instance.Info(ELogModule.Achievement, ELogAuthor.YZY, "Achievement PhraseBaseData response", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.CanGetRewardAchievements = new List<AchievementData>();
		this.HasGetRewardAchievements = new List<AchievementData>();
		this.AchievementMap.Clear();
		this.AchievementGroupMap.Clear();
		foreach (AchievementGroupInfo achievementGroupInfo in response.AchievementGroupInfoList)
		{
			this.GetAchievementGroupData(new int?(achievementGroupInfo.AchievementGroupEntry.Id)).Phrase(achievementGroupInfo.AchievementGroupEntry);
			foreach (AchievementEntry achievementEntry in achievementGroupInfo.AchievementEntryList)
			{
				AchievementData achievementData = this.GetAchievementData(achievementEntry.Id);
				achievementData.Phrase(achievementEntry);
				if (achievementData.GetFinishState() == EAchievementStateEnum.CanGetReward)
				{
					this.AddDataToCanGetArray(achievementData);
				}
				else if (achievementData.GetFinishState() == EAchievementStateEnum.HaveGetReward)
				{
					this.AddDataToHasGetArray(achievementData);
				}
			}
		}
		this.AchieveStarCount = response.StarCount;
		this.AchieveFinishCount = response.FinishCount;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAchievementDataNotify);
		Singleton<EventSystem>.Instance.Emit(EEventName.RefreshAchievementRedPoint);
	}

	// Token: 0x06006847 RID: 26695 RVA: 0x001B28F0 File Offset: 0x001B0AF0
	public void OnTsDataReady(IReadOnlyList<int> categoryIds, IReadOnlyList<int> groupIds, IReadOnlyList<int> achievementIds, int startCount, int finishCount)
	{
		this.CanGetRewardAchievements = new List<AchievementData>();
		this.HasGetRewardAchievements = new List<AchievementData>();
		this.AchievementMap.Clear();
		this.AchievementGroupMap.Clear();
		this.InitAchievementCategoryData();
		foreach (int groupId in groupIds)
		{
			this.InitAchievementGroupData(groupId);
		}
		foreach (int id in achievementIds)
		{
			this.InitAchievementData(id);
		}
		foreach (int id2 in achievementIds)
		{
			AchievementData achievementData = this.GetAchievementData(id2);
			if (achievementData != null)
			{
				if (achievementData.GetFinishState() == EAchievementStateEnum.CanGetReward)
				{
					this.AddDataToCanGetArray(achievementData);
				}
				else if (achievementData.GetFinishState() == EAchievementStateEnum.HaveGetReward)
				{
					this.AddDataToHasGetArray(achievementData);
				}
			}
		}
		this.AchieveStarCount = startCount;
		this.AchieveFinishCount = finishCount;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAchievementDataNotify);
		Singleton<EventSystem>.Instance.Emit(EEventName.RefreshAchievementRedPoint);
	}

	// Token: 0x06006848 RID: 26696 RVA: 0x001B2A34 File Offset: 0x001B0C34
	public void PhraseUpdateData(AchievementUpdateResponse response)
	{
		foreach (AchievementEntry achievementEntry in response.AchievementEntryList)
		{
			this.GetAchievementData(achievementEntry.Id).Phrase(achievementEntry);
		}
	}

	// Token: 0x06006849 RID: 26697 RVA: 0x001B2A8C File Offset: 0x001B0C8C
	public unsafe void OnAchievementProgressNotify(AchievementEntry message)
	{
		AchievementData achievementData = this.GetAchievementData(message.Id);
		EAchievementStateEnum finishState = achievementData.GetFinishState();
		achievementData.Phrase(message);
		EAchievementStateEnum finishState2 = achievementData.GetFinishState();
		if (finishState2 != finishState)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Achievement;
			ELogAuthor author = ELogAuthor.YZY;
			string message2 = "OnAchievementGroupProgressNotify";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", achievementData.GetId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("currentState", finishState2);
			instance.Info(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshAchievementRedPoint);
		}
		this.ClearCacheIds(achievementData);
		if (achievementData.GetFinishState() == EAchievementStateEnum.CanGetReward)
		{
			this.AddDataToCanGetArray(achievementData);
		}
		else if (achievementData.GetFinishState() == EAchievementStateEnum.HaveGetReward)
		{
			this.AddDataToHasGetArray(achievementData);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAchievementDataNotify);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnAchievementDataWithIdNotify, achievementData.GetId());
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnAchievementGroupDataNotify, achievementData.GetGroupId());
	}

	// Token: 0x0600684A RID: 26698 RVA: 0x001B2B9C File Offset: 0x001B0D9C
	public unsafe void OnAchievementGroupProgressNotify(AchievementGroupProgressNotify message)
	{
		AchievementGroupData achievementGroupData = this.GetAchievementGroupData(new int?(message.AchievementGroupEntry.Id));
		EAchievementStateEnum finishState = achievementGroupData.GetFinishState();
		achievementGroupData.Phrase(message.AchievementGroupEntry);
		EAchievementStateEnum finishState2 = achievementGroupData.GetFinishState();
		if (finishState2 != finishState)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshAchievementRedPoint);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Achievement;
			ELogAuthor author = ELogAuthor.YZY;
			string message2 = "OnAchievementGroupProgressNotify";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", achievementGroupData.GetId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("currentState", finishState2);
			instance.Info(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnAchievementGroupDataNotify, achievementGroupData.GetId());
	}

	// Token: 0x0600684B RID: 26699 RVA: 0x001B2C69 File Offset: 0x001B0E69
	public void OnAchievementCountChangeNotify(AchievementCountChangeNotify message)
	{
		this.AchieveFinishCount = message.FinishCount;
		this.AchieveStarCount = message.StarCount;
	}

	// Token: 0x0600684C RID: 26700 RVA: 0x001B2C84 File Offset: 0x001B0E84
	public List<AchievementData> GetGroupAchievements(int group, bool filterShowState = true)
	{
		List<AchievementData> list;
		if (!this.AchievementGroupMap.TryGetValue(group, out list))
		{
			this.InitAchievementGroupMapData(group);
			list = this.AchievementGroupMap[group];
		}
		if (!filterShowState)
		{
			return list;
		}
		List<AchievementData> list2 = new List<AchievementData>();
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].GetShowState())
			{
				list2.Add(list[i]);
			}
		}
		return list2;
	}

	// Token: 0x0600684D RID: 26701 RVA: 0x001B2CED File Offset: 0x001B0EED
	public bool GetGroupAchievementsIsRedDot(int group)
	{
		return this.GetGroupAchievements(group, false).Any((AchievementData data) => data.RedPoint());
	}

	// Token: 0x0600684E RID: 26702 RVA: 0x001B2D1C File Offset: 0x001B0F1C
	public int GetAchievementCategoryIndex(AchievementCategoryData categoryData)
	{
		return this.GetAchievementCategoryArray().FindIndex((AchievementCategoryData data) => data.GetId() == categoryData.GetId());
	}

	// Token: 0x0600684F RID: 26703 RVA: 0x001B2D50 File Offset: 0x001B0F50
	public List<AchievementGroupData> GetAchievementCategoryGroups(int categoryId, bool filterShowState = true)
	{
		List<AchievementGroupData> list;
		if (!this.AchievementCategoryGroupMap.TryGetValue(categoryId, out list))
		{
			this.InitAchievementCategoryGroupData(categoryId);
			list = this.AchievementCategoryGroupMap[categoryId];
		}
		if (!filterShowState)
		{
			return list ?? new List<AchievementGroupData>();
		}
		List<AchievementGroupData> list2 = new List<AchievementGroupData>();
		foreach (AchievementGroupData achievementGroupData in list)
		{
			if (achievementGroupData.GetShowState())
			{
				list2.Add(achievementGroupData);
			}
		}
		list2.Sort((AchievementGroupData a, AchievementGroupData b) => a.GetSort() - b.GetSort());
		return list2;
	}

	// Token: 0x06006850 RID: 26704 RVA: 0x001B2E04 File Offset: 0x001B1004
	[NullableContext(2)]
	public AchievementData GetAchievementData(int id)
	{
		AchievementData achievementData;
		if (!this.AchievementMap.TryGetValue(id, out achievementData))
		{
			try
			{
				this.InitAchievementData(id);
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Achievement;
				ELogAuthor author = ELogAuthor.BB;
				string message = "成就初始化异常";
				Exception error = ex;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.ErrorWithStack(module, author, message, error, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		return this.AchievementMap[id];
	}

	// Token: 0x06006851 RID: 26705 RVA: 0x001B2E7C File Offset: 0x001B107C
	public Dictionary<int, AchievementData> GetAllAchievementData()
	{
		return this.AchievementMap;
	}

	// Token: 0x06006852 RID: 26706 RVA: 0x001B2E84 File Offset: 0x001B1084
	public List<AchievementCategoryData> GetAchievementCategoryArray()
	{
		if (this.AchievementCategoryArray.Count == 0)
		{
			this.InitAchievementCategoryData();
		}
		return this.AchievementCategoryArray;
	}

	// Token: 0x06006853 RID: 26707 RVA: 0x001B2EA0 File Offset: 0x001B10A0
	[NullableContext(2)]
	public AchievementCategoryData GetCategory(int categoryId)
	{
		List<AchievementCategoryData> achievementCategoryArray = this.GetAchievementCategoryArray();
		AchievementCategoryData result = null;
		for (int i = 0; i < achievementCategoryArray.Count; i++)
		{
			if (achievementCategoryArray[i].GetId() == categoryId)
			{
				result = achievementCategoryArray[i];
			}
		}
		return result;
	}

	// Token: 0x06006854 RID: 26708 RVA: 0x001B2EDF File Offset: 0x001B10DF
	[NullableContext(2)]
	public AchievementGroupData GetAchievementGroupData(int? groupId)
	{
		if (groupId == null)
		{
			return null;
		}
		if (!this.AllAchievementGroupMap.ContainsKey(groupId.Value))
		{
			this.InitAchievementGroupData(groupId.Value);
		}
		return this.AllAchievementGroupMap[groupId.Value];
	}

	// Token: 0x06006855 RID: 26709 RVA: 0x001B2F1F File Offset: 0x001B111F
	public Dictionary<int, AchievementGroupData> GetAllAchievementGroupData()
	{
		return this.AllAchievementGroupMap;
	}

	// Token: 0x06006856 RID: 26710 RVA: 0x001B2F28 File Offset: 0x001B1128
	public List<int> GetRecentFinishedAchievementList()
	{
		List<int> list = new List<int>();
		this.SortCanGetRewardAchievements();
		int num = 0;
		while (num < this.CanGetRewardAchievements.Count && list.Count < 5)
		{
			if (!list.Contains(this.CanGetRewardAchievements[num].GetId()) && this.CanGetRewardAchievements[num].GetShowState())
			{
				AchievementGroupData achievementGroupData = this.GetAchievementGroupData(new int?(this.CanGetRewardAchievements[num].GetGroupId()));
				int categoryFunctionType = ConfigBase<AchievementConfig>.Instance.GetCategoryFunctionType(achievementGroupData.GetCategory());
				if (this.showFunctionList.Contains(categoryFunctionType))
				{
					list.Add(this.CanGetRewardAchievements[num].GetId());
				}
			}
			num++;
		}
		if (list.Count < 5)
		{
			this.SortHasGetRewardAchievements();
			int num2 = 0;
			while (num2 < this.HasGetRewardAchievements.Count && list.Count < 5)
			{
				if (!list.Contains(this.HasGetRewardAchievements[num2].GetId()) && this.HasGetRewardAchievements[num2].GetShowState())
				{
					AchievementGroupData achievementGroupData2 = this.GetAchievementGroupData(new int?(this.HasGetRewardAchievements[num2].GetGroupId()));
					int categoryFunctionType2 = ConfigBase<AchievementConfig>.Instance.GetCategoryFunctionType(achievementGroupData2.GetCategory());
					if (this.showFunctionList.Contains(categoryFunctionType2))
					{
						list.Add(this.HasGetRewardAchievements[num2].GetId());
					}
				}
				num2++;
			}
		}
		return list;
	}

	// Token: 0x06006857 RID: 26711 RVA: 0x001B30AE File Offset: 0x001B12AE
	public bool GetAchievementRedPointState()
	{
		return this.GetAchievementCategoryArray().Any((AchievementCategoryData category) => this.GetCategoryRedPointState(category.GetId()));
	}

	// Token: 0x06006858 RID: 26712 RVA: 0x001B30C7 File Offset: 0x001B12C7
	public bool GetCategoryRedPointState(int categoryId)
	{
		return this.GetAchievementCategoryGroups(categoryId, false).Any((AchievementGroupData group) => group.SmallItemRedPoint());
	}

	// Token: 0x06006859 RID: 26713 RVA: 0x001B30F8 File Offset: 0x001B12F8
	public int GetCategoryStarNum(int category)
	{
		List<AchievementGroupData> achievementCategoryGroups = this.GetAchievementCategoryGroups(category, true);
		int num = 0;
		foreach (AchievementGroupData achievementGroupData in achievementCategoryGroups)
		{
			foreach (AchievementData achievementData in this.GetGroupAchievements(achievementGroupData.GetId(), true))
			{
				num += achievementData.GetMaxStar();
			}
		}
		return num;
	}

	// Token: 0x0600685A RID: 26714 RVA: 0x001B3198 File Offset: 0x001B1398
	public int GetFinishedAchievementNum()
	{
		return this.AchieveFinishCount;
	}

	// Token: 0x0600685B RID: 26715 RVA: 0x001B31A0 File Offset: 0x001B13A0
	public int GetAchievementFinishedStar()
	{
		return this.AchieveStarCount;
	}

	// Token: 0x0600685C RID: 26716 RVA: 0x001B31A8 File Offset: 0x001B13A8
	public void RefreshSearchResult()
	{
		List<AchievementCategoryData> achievementCategoryArray = this.GetAchievementCategoryArray();
		this.SearchResult = new Dictionary<AchievementCategoryData, Dictionary<AchievementGroupData, AchievementData[]>>();
		foreach (AchievementCategoryData achievementCategoryData in achievementCategoryArray)
		{
			Dictionary<AchievementGroupData, AchievementData[]> categorySearchResult = this.GetCategorySearchResult(achievementCategoryData.GetId(), this.CurrentSearchText);
			if (categorySearchResult.Keys.Count > 0)
			{
				this.SearchResult[achievementCategoryData] = categorySearchResult;
			}
		}
	}

	// Token: 0x0600685D RID: 26717 RVA: 0x001B3230 File Offset: 0x001B1430
	public Dictionary<AchievementCategoryData, Dictionary<AchievementGroupData, AchievementData[]>> GetSearchResult()
	{
		return this.SearchResult;
	}

	// Token: 0x0600685E RID: 26718 RVA: 0x001B3238 File Offset: 0x001B1438
	public bool GetSearchResultIfNull()
	{
		Dictionary<AchievementCategoryData, Dictionary<AchievementGroupData, AchievementData[]>> searchResult = this.SearchResult;
		bool flag = true;
		foreach (Dictionary<AchievementGroupData, AchievementData[]> dictionary in searchResult.Values)
		{
			using (Dictionary<AchievementGroupData, AchievementData[]>.ValueCollection.Enumerator enumerator2 = dictionary.Values.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.Length != 0)
					{
						flag = false;
						break;
					}
				}
			}
			if (!flag)
			{
				break;
			}
		}
		return flag;
	}

	// Token: 0x0600685F RID: 26719 RVA: 0x001B32D0 File Offset: 0x001B14D0
	private Dictionary<AchievementGroupData, AchievementData[]> GetCategorySearchResult(int category, string searchText)
	{
		Dictionary<AchievementGroupData, AchievementData[]> dictionary = new Dictionary<AchievementGroupData, AchievementData[]>();
		List<AchievementGroupData> achievementCategoryGroups = this.GetAchievementCategoryGroups(category, true);
		for (int i = 0; i < achievementCategoryGroups.Count; i++)
		{
			List<AchievementData> groupAchievements = this.GetGroupAchievements(achievementCategoryGroups[i].GetId(), true);
			List<AchievementData> list = new List<AchievementData>();
			foreach (AchievementData achievementData in groupAchievements)
			{
				if (!string.IsNullOrEmpty(achievementData.GetTitle()))
				{
					string.IsNullOrEmpty(achievementData.GetDesc());
				}
				string title = achievementData.GetTitle();
				if (title == null || !title.Contains(searchText))
				{
					string desc = achievementData.GetDesc();
					if (desc == null || !desc.Contains(searchText))
					{
						continue;
					}
				}
				list.Add(achievementData);
			}
			if (list.Count > 0)
			{
				dictionary[achievementCategoryGroups[i]] = list.ToArray();
			}
		}
		return dictionary;
	}

	// Token: 0x06006860 RID: 26720 RVA: 0x001B33C4 File Offset: 0x001B15C4
	public List<AchievementSearchData> GetSearchResultData(Dictionary<AchievementCategoryData, Dictionary<AchievementGroupData, AchievementData[]>> input)
	{
		List<AchievementSearchData> list = new List<AchievementSearchData>();
		foreach (AchievementCategoryData key in input.Keys)
		{
			foreach (KeyValuePair<AchievementGroupData, AchievementData[]> keyValuePair in input[key])
			{
				list.Add(new AchievementSearchData
				{
					AchievementSearchGroupData = new AchievementSearchGroupData(),
					AchievementSearchGroupData = 
					{
						AchievementGroupData = keyValuePair.Key,
						AchievementDataLength = keyValuePair.Value.Length
					}
				});
				foreach (AchievementData achievementData in keyValuePair.Value)
				{
					list.Add(new AchievementSearchData
					{
						AchievementData = achievementData
					});
				}
			}
		}
		return list;
	}

	// Token: 0x06006861 RID: 26721 RVA: 0x001B34E0 File Offset: 0x001B16E0
	public bool IsHideAchievementGroup(int groupId)
	{
		AchievementGroupData achievementGroupData = this.GetAchievementGroupData(new int?(groupId));
		int? num = (achievementGroupData != null) ? new int?(achievementGroupData.GetCategory()) : null;
		int categoryFunctionType = ConfigBase<AchievementConfig>.Instance.GetCategoryFunctionType(num.Value);
		return !this.showFunctionList.Contains(categoryFunctionType);
	}

	// Token: 0x06006862 RID: 26722 RVA: 0x001B3534 File Offset: 0x001B1734
	public void GmClearData()
	{
		this.CurrentFinishAchievementArray.Clear();
	}

	// Token: 0x040031A7 RID: 12711
	private const int RECENT_FINISHED_LIST_LENGTH = 5;

	// Token: 0x040031A8 RID: 12712
	private readonly int[] showFunctionList = new int[]
	{
		1
	};

	// Token: 0x040031A9 RID: 12713
	[Nullable(2)]
	public AchievementCategoryData CurrentSelectCategory;

	// Token: 0x040031AA RID: 12714
	[Nullable(2)]
	public AchievementGroupData CurrentSelectGroup;

	// Token: 0x040031AB RID: 12715
	public int CurrentSelectAchievementId;

	// Token: 0x040031AC RID: 12716
	public bool AchievementSearchState;

	// Token: 0x040031AD RID: 12717
	public string CurrentSearchText = "";

	// Token: 0x040031AE RID: 12718
	public List<int> CurrentFinishAchievementArray = new List<int>();

	// Token: 0x040031AF RID: 12719
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<AchievementSearchData> CurrentCacheSearchData;

	// Token: 0x040031B0 RID: 12720
	private Dictionary<AchievementCategoryData, Dictionary<AchievementGroupData, AchievementData[]>> SearchResult = new Dictionary<AchievementCategoryData, Dictionary<AchievementGroupData, AchievementData[]>>();

	// Token: 0x040031B1 RID: 12721
	private readonly Dictionary<int, List<AchievementData>> AchievementGroupMap = new Dictionary<int, List<AchievementData>>();

	// Token: 0x040031B2 RID: 12722
	private List<AchievementCategoryData> AchievementCategoryArray = new List<AchievementCategoryData>();

	// Token: 0x040031B3 RID: 12723
	private readonly Dictionary<int, List<AchievementGroupData>> AchievementCategoryGroupMap = new Dictionary<int, List<AchievementGroupData>>();

	// Token: 0x040031B4 RID: 12724
	private readonly Dictionary<int, AchievementData> AchievementMap = new Dictionary<int, AchievementData>();

	// Token: 0x040031B5 RID: 12725
	private readonly Dictionary<int, AchievementGroupData> AllAchievementGroupMap = new Dictionary<int, AchievementGroupData>();

	// Token: 0x040031B6 RID: 12726
	private List<AchievementData> CanGetRewardAchievements = new List<AchievementData>();

	// Token: 0x040031B7 RID: 12727
	private List<AchievementData> HasGetRewardAchievements = new List<AchievementData>();

	// Token: 0x040031B8 RID: 12728
	private int AchieveStarCount;

	// Token: 0x040031B9 RID: 12729
	private int AchieveFinishCount;

	// Token: 0x040031BA RID: 12730
	private readonly Comparison<AchievementData> SortFunc = (AchievementData a, AchievementData b) => (int)(b.GetFinishTime() - a.GetFinishTime()).Value;

	// Token: 0x040031BB RID: 12731
	public readonly Comparison<AchievementData> SortByTabIndex = (AchievementData a, AchievementData b) => b.GetFinishSort() - a.GetFinishSort();
}
