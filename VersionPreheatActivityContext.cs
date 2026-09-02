using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001609 RID: 5641
[NullableContext(1)]
[Nullable(0)]
public class VersionPreheatActivityContext : ActivityBaseData
{
	// Token: 0x06009F5F RID: 40799 RVA: 0x0029A4B4 File Offset: 0x002986B4
	protected override void PhraseEx(ActivityData data)
	{
		PreheatSignActivityInfo preheatSignActivityInfo = data.PreheatSignActivityInfo;
		if (preheatSignActivityInfo == null)
		{
			return;
		}
		this.QuestCacheInternal.Clear();
		foreach (PreheatSignNodeInfo preheatSignNodeInfo in preheatSignActivityInfo.PreheatSignNodeInfos)
		{
			VersionPreheatQuestInfoCache value = new VersionPreheatQuestInfoCache
			{
				Meta = preheatSignNodeInfo,
				Id = preheatSignNodeInfo.PreheatNodeId,
				UnlockTimestamp = preheatSignNodeInfo.UnlockTime,
				Rewarded = preheatSignNodeInfo.Rewarded
			};
			this.QuestCacheInternal[preheatSignNodeInfo.PreheatNodeId] = value;
		}
	}

	// Token: 0x06009F60 RID: 40800 RVA: 0x0029A554 File Offset: 0x00298754
	public override bool GetExDataRedPointShowState()
	{
		return ModelBase<VersionPreheatModel>.Instance.HasNewQuest;
	}

	// Token: 0x06009F61 RID: 40801 RVA: 0x0029A560 File Offset: 0x00298760
	public void Dispose()
	{
	}

	// Token: 0x06009F62 RID: 40802 RVA: 0x0029A562 File Offset: 0x00298762
	public void SyncPreheatSignSurveyInfo(int id, PreheatSignSurveyInfo info)
	{
		this.SurveyInfoCache[id] = info;
	}

	// Token: 0x06009F63 RID: 40803 RVA: 0x0029A574 File Offset: 0x00298774
	public void SyncPreheatRewardedState(int id)
	{
		VersionPreheatQuestInfoCache versionPreheatQuestInfoCache;
		if (this.QuestCacheInternal.TryGetValue(id, out versionPreheatQuestInfoCache))
		{
			versionPreheatQuestInfoCache.Rewarded = true;
		}
	}

	// Token: 0x06009F64 RID: 40804 RVA: 0x0029A598 File Offset: 0x00298798
	public long GetVoteLeftCountById(int id)
	{
		PreheatSignSurveyInfo preheatSignSurveyInfo;
		if (this.SurveyInfoCache.TryGetValue(id, out preheatSignSurveyInfo))
		{
			return preheatSignSurveyInfo.SupportNum;
		}
		return 0L;
	}

	// Token: 0x06009F65 RID: 40805 RVA: 0x0029A5C0 File Offset: 0x002987C0
	public long GetVoteRightCountById(int id)
	{
		PreheatSignSurveyInfo preheatSignSurveyInfo;
		if (this.SurveyInfoCache.TryGetValue(id, out preheatSignSurveyInfo))
		{
			return preheatSignSurveyInfo.OpposeNum;
		}
		return 0L;
	}

	// Token: 0x06009F66 RID: 40806 RVA: 0x0029A5E8 File Offset: 0x002987E8
	public bool IsRewardedById(int id)
	{
		VersionPreheatQuestInfoCache versionPreheatQuestInfoCache;
		return this.QuestCacheInternal.TryGetValue(id, out versionPreheatQuestInfoCache) && versionPreheatQuestInfoCache.Rewarded;
	}

	// Token: 0x06009F67 RID: 40807 RVA: 0x0029A610 File Offset: 0x00298810
	public bool? IsLeftChosen(int id)
	{
		PreheatSignSurveyInfo preheatSignSurveyInfo;
		if (this.SurveyInfoCache.TryGetValue(id, out preheatSignSurveyInfo))
		{
			return new bool?(preheatSignSurveyInfo.AnswerStatus);
		}
		return null;
	}

	// Token: 0x17000D6F RID: 3439
	// (get) Token: 0x06009F68 RID: 40808 RVA: 0x0029A642 File Offset: 0x00298842
	public Dictionary<int, VersionPreheatQuestInfoCache> QuestCache
	{
		get
		{
			return this.QuestCacheInternal;
		}
	}

	// Token: 0x04004908 RID: 18696
	private readonly Dictionary<int, PreheatSignSurveyInfo> SurveyInfoCache = new Dictionary<int, PreheatSignSurveyInfo>();

	// Token: 0x04004909 RID: 18697
	private readonly Dictionary<int, VersionPreheatQuestInfoCache> QuestCacheInternal = new Dictionary<int, VersionPreheatQuestInfoCache>();
}
