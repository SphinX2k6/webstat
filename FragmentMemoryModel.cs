using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;

// Token: 0x02001C85 RID: 7301
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class FragmentMemoryModel : ModelBase<FragmentMemoryModel>
{
	// Token: 0x0600D577 RID: 54647 RVA: 0x0038EE8F File Offset: 0x0038D08F
	public void OnPhotoMemoryResponse(PhotoMemoryResponse response)
	{
		this.RebuildTopicData(response.Topics);
	}

	// Token: 0x0600D578 RID: 54648 RVA: 0x0038EE9D File Offset: 0x0038D09D
	public void OnPhotoMemoryUpdate(PhotoMemoryUpdateNotify notify)
	{
		this.UpdateTopicData(notify.Topics);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnFragmentMemoryDataUpdate);
	}

	// Token: 0x0600D579 RID: 54649 RVA: 0x0038EEBB File Offset: 0x0038D0BB
	public void TryRemoveCurrentTrackEntity()
	{
		if (this.CurrentTrackMapMarkId != 0)
		{
			ModelBase<MapModel>.Instance.RemoveMapMark(new EMarkType?(EMarkType.Entity), new int?(this.CurrentTrackMapMarkId));
			this.CurrentTrackMapMarkId = 0;
		}
	}

	// Token: 0x0600D57A RID: 54650 RVA: 0x0038EEE8 File Offset: 0x0038D0E8
	private void UpdateTopicData(IEnumerable<PhotoMemoryTopicInfo> data)
	{
		foreach (PhotoMemoryTopicInfo photoMemoryTopicInfo in data)
		{
			int id = photoMemoryTopicInfo.Id;
			FragmentMemoryTopicData fragmentMemoryTopicData;
			if (this.TopicDataMap.TryGetValue(id, out fragmentMemoryTopicData))
			{
				fragmentMemoryTopicData.Phrase(photoMemoryTopicInfo);
			}
			else
			{
				FragmentMemoryTopicData value = this.CreateTopicData(photoMemoryTopicInfo);
				this.TopicDataMap.Add(id, value);
			}
			foreach (FragmentMemoryCollectData fragmentMemoryCollectData in this.TopicDataMap[id].GetCollectDataList())
			{
				if (this.MemoryCollectMap.ContainsKey(fragmentMemoryCollectData.GetId()))
				{
					this.MemoryCollectMap[fragmentMemoryCollectData.GetId()] = fragmentMemoryCollectData;
				}
				else
				{
					this.MemoryCollectMap.Add(fragmentMemoryCollectData.GetId(), fragmentMemoryCollectData);
				}
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.FragmentRewardEntranceRedDot);
	}

	// Token: 0x0600D57B RID: 54651 RVA: 0x0038EFFC File Offset: 0x0038D1FC
	private void RebuildTopicData(IEnumerable<PhotoMemoryTopicInfo> topicInfo)
	{
		this.TopicDataMap.Clear();
		this.MemoryCollectMap.Clear();
		foreach (PhotoMemoryTopicInfo photoMemoryTopicInfo in topicInfo)
		{
			FragmentMemoryTopicData fragmentMemoryTopicData = this.CreateTopicData(photoMemoryTopicInfo);
			this.TopicDataMap.Add(photoMemoryTopicInfo.Id, fragmentMemoryTopicData);
			foreach (FragmentMemoryCollectData fragmentMemoryCollectData in fragmentMemoryTopicData.GetCollectDataList())
			{
				this.MemoryCollectMap.Add(fragmentMemoryCollectData.GetId(), fragmentMemoryCollectData);
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.FragmentRewardEntranceRedDot);
	}

	// Token: 0x0600D57C RID: 54652 RVA: 0x0038F0D0 File Offset: 0x0038D2D0
	public List<int> GetCollectedIds()
	{
		List<int> list = new List<int>();
		foreach (FragmentMemoryTopicData fragmentMemoryTopicData in this.TopicDataMap.Values)
		{
			foreach (FragmentMemoryCollectData fragmentMemoryCollectData in fragmentMemoryTopicData.GetCollectDataList())
			{
				if (fragmentMemoryCollectData.GetIfUnlock())
				{
					list.Add(fragmentMemoryCollectData.GetId());
				}
			}
		}
		return list;
	}

	// Token: 0x0600D57D RID: 54653 RVA: 0x0038F178 File Offset: 0x0038D378
	public IReadOnlyList<PhotoMemoryTopic> GetAllFragmentTopic()
	{
		return ConfigBase<FragmentMemoryConfig>.Instance.GetAllPhotoMemoryTopic();
	}

	// Token: 0x0600D57E RID: 54654 RVA: 0x0038F184 File Offset: 0x0038D384
	public bool GetTopicUnlockState(int id)
	{
		return this.GetTopicDataById(id) != null;
	}

	// Token: 0x0600D57F RID: 54655 RVA: 0x0038F190 File Offset: 0x0038D390
	public string GetUnlockConditionText(int id)
	{
		return LevelGeneralCommons.GetConditionGroupHintText(ConfigBase<FragmentMemoryConfig>.Instance.GetPhotoMemoryTopicById(id).Value.ConditionGroupId) ?? "";
	}

	// Token: 0x0600D580 RID: 54656 RVA: 0x0038F1C8 File Offset: 0x0038D3C8
	public void OnPhotoMemoryCollectUpdate(PhotoMemoryCollectNotify notify)
	{
		int id = notify.CollectInfo.Id;
		FragmentMemoryCollectData fragmentMemoryCollectData;
		if (!this.MemoryCollectMap.TryGetValue(id, out fragmentMemoryCollectData))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FragmentMemory;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "记忆历程数据刷新时找不到数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			fragmentMemoryCollectData = new FragmentMemoryCollectData();
		}
		fragmentMemoryCollectData.Phrase(notify.CollectInfo);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnFragmentMemoryCollectUpdate);
	}

	// Token: 0x0600D581 RID: 54657 RVA: 0x0038F242 File Offset: 0x0038D442
	private FragmentMemoryTopicData CreateTopicData(PhotoMemoryTopicInfo data)
	{
		FragmentMemoryTopicData fragmentMemoryTopicData = new FragmentMemoryTopicData();
		fragmentMemoryTopicData.Phrase(data);
		return fragmentMemoryTopicData;
	}

	// Token: 0x0600D582 RID: 54658 RVA: 0x0038F250 File Offset: 0x0038D450
	[NullableContext(2)]
	public FragmentMemoryCollectData GetCollectDataById(int id)
	{
		FragmentMemoryCollectData result;
		if (this.MemoryCollectMap.TryGetValue(id, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600D583 RID: 54659 RVA: 0x0038F270 File Offset: 0x0038D470
	[NullableContext(2)]
	public FragmentMemoryTopicData GetTopicDataById(int id)
	{
		FragmentMemoryTopicData fragmentMemoryTopicData;
		if (!this.TopicDataMap.TryGetValue(id, out fragmentMemoryTopicData))
		{
			return null;
		}
		if (fragmentMemoryTopicData != null && !fragmentMemoryTopicData.GetUnlockState())
		{
			return null;
		}
		return fragmentMemoryTopicData;
	}

	// Token: 0x0600D584 RID: 54660 RVA: 0x0038F2A0 File Offset: 0x0038D4A0
	public bool GetRedDotState()
	{
		IReadOnlyList<PhotoMemoryTopic> allFragmentTopic = this.GetAllFragmentTopic();
		if (allFragmentTopic.Count == 0)
		{
			return false;
		}
		int id = allFragmentTopic[allFragmentTopic.Count - 1].Id;
		FragmentMemoryTopicData fragmentMemoryTopicData;
		return this.TopicDataMap.TryGetValue(id, out fragmentMemoryTopicData) && fragmentMemoryTopicData != null && fragmentMemoryTopicData.GetRedDotState();
	}

	// Token: 0x0600D585 RID: 54661 RVA: 0x0038F2F4 File Offset: 0x0038D4F4
	public bool GetTopicFirstOpenRedDotState(int topicId)
	{
		List<int> player = LocalStorage.GetPlayer<List<int>>(ELocalStoragePlayerKey.FragmentMemoryOpened, null);
		return player == null || !player.Contains(topicId);
	}

	// Token: 0x0600D586 RID: 54662 RVA: 0x0038F31C File Offset: 0x0038D51C
	public bool GetCurrentActivityFragmentMemoryRedDotState()
	{
		List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(16);
		if (currentActivitiesByType != null && currentActivitiesByType.Count > 0)
		{
			using (List<ActivityBaseData>.Enumerator enumerator = currentActivitiesByType.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if ((enumerator.Current as FragmentMemoryActivityData).EntranceRedDot())
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x0600D587 RID: 54663 RVA: 0x0038F390 File Offset: 0x0038D590
	public void SaveTopicOpened(int topicId)
	{
		FragmentMemoryTopicData fragmentMemoryTopicData;
		if (!this.TopicDataMap.TryGetValue(topicId, out fragmentMemoryTopicData))
		{
			return;
		}
		if (!fragmentMemoryTopicData.GetUnlockState())
		{
			return;
		}
		List<int> list = LocalStorage.GetPlayer<List<int>>(ELocalStoragePlayerKey.FragmentMemoryOpened, null);
		if (list == null)
		{
			list = new List<int>();
		}
		if (list.Contains(topicId))
		{
			return;
		}
		list.Add(topicId);
		LocalStorage.SetPlayer<List<int>>(ELocalStoragePlayerKey.FragmentMemoryOpened, list);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.FragmentRewardTopicRedDot, topicId);
		Singleton<EventSystem>.Instance.Emit(EEventName.FragmentRewardEntranceRedDot);
	}

	// Token: 0x0400654D RID: 25933
	public string ActivitySubViewTryPlayAnimation = "";

	// Token: 0x0400654E RID: 25934
	public string MemoryFragmentMainViewTryPlayAnimation = "";

	// Token: 0x0400654F RID: 25935
	private readonly Dictionary<int, FragmentMemoryCollectData> MemoryCollectMap = new Dictionary<int, FragmentMemoryCollectData>();

	// Token: 0x04006550 RID: 25936
	public int CurrentTrackMapMarkId;

	// Token: 0x04006551 RID: 25937
	public int CurrentTrackFragmentId;

	// Token: 0x04006552 RID: 25938
	private readonly Dictionary<int, FragmentMemoryTopicData> TopicDataMap = new Dictionary<int, FragmentMemoryTopicData>();

	// Token: 0x04006553 RID: 25939
	public int CurrentUnlockCollectId;
}
