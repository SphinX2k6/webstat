using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.WorldMap;

// Token: 0x02001B67 RID: 7015
[NullableContext(1)]
[Nullable(0)]
public class ExploreAreaItemData
{
	// Token: 0x17001046 RID: 4166
	// (get) Token: 0x0600CB7A RID: 52090 RVA: 0x00364ACA File Offset: 0x00362CCA
	public bool IsShowProgressBar
	{
		get
		{
			return this.IsShowProgress && this.PlayPointTotalCount > 0 && !this.IsCompleted();
		}
	}

	// Token: 0x17001047 RID: 4167
	// (get) Token: 0x0600CB7B RID: 52091 RVA: 0x00364AE8 File Offset: 0x00362CE8
	public bool IsFinishedPlayPoint
	{
		get
		{
			return this.PlayPointCompletedCount >= this.PlayPointTotalCount;
		}
	}

	// Token: 0x17001048 RID: 4168
	// (get) Token: 0x0600CB7C RID: 52092 RVA: 0x00364AFB File Offset: 0x00362CFB
	public bool IsShowRecommendPlayPoint
	{
		get
		{
			return this.IsRecommend && !this.IsFinishedPlayPoint && this.IsUnlocked() && this.IsNearestPlayPointUnlock();
		}
	}

	// Token: 0x0600CB7D RID: 52093 RVA: 0x00364B20 File Offset: 0x00362D20
	public void Initialize(ExploreProgress config)
	{
		this.AreaId = config.Area;
		this.ExploreType = (EExploreType)config.ExploreType;
		this.PhantomSkillId = config.PhantomSkillId;
		this.UnlockTextId = config.UnlockTextId;
		this.LockTextId = config.LockTextId;
		this.UnlockConditionId = config.UnlockCondition;
		this.SpecialPlayPointIndexMap = config.SpecialPlayerMap();
		this.IsRecommend = config.IsRecommend;
		this.IsShowProgress = config.IsShowProgress;
		this.SubTypes = new int[config.SubTypeScore().Count];
		int num = 0;
		foreach (int num2 in config.SubTypeScore().Keys)
		{
			this.SubTypes[num] = num2;
			num++;
		}
		this.SpecialPlayerDesc = config.SpecialPlayerDesc;
		this.ConfigId = config.Id;
		this.IsShowTrackBtn = config.IsShowTrack;
		this.UnlockTrackType = (EExploreTrackType)config.UnlockTrackType;
		this.LockTrackType = (EExploreTrackType)config.LockTrackType;
		this.AccessPathId = config.AccessPathId;
		this.IsPhantomSkillUnlock = false;
		if (this.PhantomSkillId != 0)
		{
			this.IsPhantomSkillUnlock = ModelBase<RouletteModel>.Instance.UnlockExploreSkillDataMap.ContainsKey(this.PhantomSkillId);
		}
		ExploreType value = ConfigBase<ExploreProgressConfig>.Instance.GetExploreTypeByType((int)this.ExploreType).Value;
		this.TypeNameId = value.Name;
		this.CountMode = value.CountMode;
		this.Icon = value.Icon;
		this.DescBg = value.DescBg;
		this.SortIndex = value.SortIndex;
		this.LockDescId = value.LockDescId;
		this.DescId = value.DescId;
	}

	// Token: 0x0600CB7E RID: 52094 RVA: 0x00364CFC File Offset: 0x00362EFC
	public void Refresh(OneExploreItem info)
	{
		this.ExploreProgress = info.ExplorePercent;
		this.ExploreProgressId = info.ExploreProgressId;
		this.CurrentCount = info.CurCount;
		this.TotalCount = info.TotalCount;
		this.IsUnlock = info.UnLock;
		this.UpdateDefaultPlayPointData();
	}

	// Token: 0x0600CB7F RID: 52095 RVA: 0x00364D4B File Offset: 0x00362F4B
	public int GetProgress()
	{
		return this.ExploreProgress;
	}

	// Token: 0x0600CB80 RID: 52096 RVA: 0x00364D53 File Offset: 0x00362F53
	public int GetCurrentCount()
	{
		return this.CurrentCount;
	}

	// Token: 0x0600CB81 RID: 52097 RVA: 0x00364D5B File Offset: 0x00362F5B
	public int GetTotalCount()
	{
		return this.TotalCount;
	}

	// Token: 0x0600CB82 RID: 52098 RVA: 0x00364D63 File Offset: 0x00362F63
	public string GetNameId()
	{
		return this.TypeNameId;
	}

	// Token: 0x0600CB83 RID: 52099 RVA: 0x00364D6C File Offset: 0x00362F6C
	public string GetPlayDetailTitle()
	{
		string text = "PrefabTextItem_1918495092_Text";
		string nameId = this.GetNameId();
		string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text, text);
		string multiTextByKey2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(nameId, nameId);
		return StringUtils.Format(multiTextByKey, new string[]
		{
			multiTextByKey2
		});
	}

	// Token: 0x0600CB84 RID: 52100 RVA: 0x00364DAE File Offset: 0x00362FAE
	public bool IsPercent()
	{
		return this.CountMode == 0;
	}

	// Token: 0x0600CB85 RID: 52101 RVA: 0x00364DB9 File Offset: 0x00362FB9
	public bool IsCompleted()
	{
		return this.ExploreProgress >= 100 || (this.CurrentCount > 0 && this.TotalCount > 0 && this.CurrentCount >= this.TotalCount);
	}

	// Token: 0x0600CB86 RID: 52102 RVA: 0x00364DEC File Offset: 0x00362FEC
	public bool HasPhantomSkill()
	{
		return this.PhantomSkillId != 0;
	}

	// Token: 0x0600CB87 RID: 52103 RVA: 0x00364DF7 File Offset: 0x00362FF7
	[NullableContext(2)]
	public string GetUnlockTextId()
	{
		return this.UnlockTextId;
	}

	// Token: 0x0600CB88 RID: 52104 RVA: 0x00364DFF File Offset: 0x00362FFF
	[NullableContext(2)]
	public string GetLockTextId()
	{
		return this.LockTextId;
	}

	// Token: 0x0600CB89 RID: 52105 RVA: 0x00364E07 File Offset: 0x00363007
	public bool GetIsPhantomSkillUnlock()
	{
		return this.IsPhantomSkillUnlock;
	}

	// Token: 0x0600CB8A RID: 52106 RVA: 0x00364E10 File Offset: 0x00363010
	public int? GetPhantomSkillHelpId()
	{
		ExploreTools? exploreConfigById = ConfigBase<RouletteConfig>.Instance.GetExploreConfigById(this.PhantomSkillId);
		if (exploreConfigById == null)
		{
			return null;
		}
		return new int?(exploreConfigById.GetValueOrDefault().HelpId);
	}

	// Token: 0x0600CB8B RID: 52107 RVA: 0x00364E55 File Offset: 0x00363055
	public bool IsUnlocked()
	{
		return this.IsUnlock;
	}

	// Token: 0x0600CB8C RID: 52108 RVA: 0x00364E60 File Offset: 0x00363060
	public string GetLockDetailId()
	{
		if (this.UnlockConditionId == 0)
		{
			return "";
		}
		ConditionGroup? conditionGroupConfig = ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(this.UnlockConditionId);
		if (conditionGroupConfig != null)
		{
			return conditionGroupConfig.Value.HintText;
		}
		return "";
	}

	// Token: 0x0600CB8D RID: 52109 RVA: 0x00364EAC File Offset: 0x003630AC
	private void UpdateDefaultPlayPointData()
	{
		if (this.PlayProgressDataList.Count > 0)
		{
			return;
		}
		if (!this.IsShowProgress)
		{
			return;
		}
		this.PlayPointCompletedCount = this.CurrentCount;
		this.PlayPointToBeCompletedCount = 0;
		this.PlayPointLockedCount = this.TotalCount - this.CurrentCount;
		this.PlayPointTotalCount = this.TotalCount;
		for (int i = 0; i < this.TotalCount; i++)
		{
			this.PlayProgressDataList.Add(new ExplorePlayProgressItemData
			{
				ExploreType = this.ExploreType,
				PlayPointType = EPlayPointType.Normal,
				PlayPointState = ((i < this.CurrentCount) ? EPlayPointState.Completed : EPlayPointState.Locked)
			});
		}
	}

	// Token: 0x0600CB8E RID: 52110 RVA: 0x00364F4A File Offset: 0x0036314A
	public bool IsSubType(int subType)
	{
		return this.SubTypes.Contains(subType);
	}

	// Token: 0x0600CB8F RID: 52111 RVA: 0x00364F58 File Offset: 0x00363158
	public void AddPlayPointData(IPlayPointInfo info)
	{
		this.PlayIdMap.Add(info.PlayId, info);
		this.PlayPointTotalCount++;
		if (info.PlayState == EPlayPointState.Completed)
		{
			this.PlayPointCompletedCount++;
		}
		else if (info.PlayState == EPlayPointState.ToBeCompleted)
		{
			this.PlayPointToBeCompletedCount++;
		}
		else
		{
			this.PlayPointLockedCount++;
		}
		this.PlayProgressDataList.Add(new ExplorePlayProgressItemData
		{
			ExploreType = this.ExploreType,
			PlayPointType = EPlayPointType.Normal,
			PlayPointState = info.PlayState,
			PlayPointId = new int?(info.PlayId),
			EntityId = new int?(info.EntityId),
			IsClear = info.IsClear,
			ClearInfo = info.ClearInfo,
			IsUnlock = new bool?(info.IsUnlock)
		});
	}

	// Token: 0x0600CB90 RID: 52112 RVA: 0x0036503F File Offset: 0x0036323F
	public void ClearPlayPointData()
	{
		this.PlayIdMap.Clear();
		this.PlayPointTotalCount = 0;
		this.PlayPointCompletedCount = 0;
		this.PlayPointToBeCompletedCount = 0;
		this.PlayPointLockedCount = 0;
		this.PlayProgressDataList.Clear();
	}

	// Token: 0x0600CB91 RID: 52113 RVA: 0x00365074 File Offset: 0x00363274
	public void PlayPointDataAddFinish()
	{
		if (this.PlayProgressDataList.Count == 0)
		{
			return;
		}
		this.PlayProgressDataList.Sort((IExplorePlayProgressItemData a, IExplorePlayProgressItemData b) => b.PlayPointState - a.PlayPointState);
		foreach (KeyValuePair<int, int> keyValuePair in this.SpecialPlayPointIndexMap)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			if (key < this.PlayProgressDataList.Count)
			{
				this.PlayProgressDataList[key].PlayPointType = (EPlayPointType)value;
			}
		}
	}

	// Token: 0x0600CB92 RID: 52114 RVA: 0x00365128 File Offset: 0x00363328
	public bool HasSpecialPlayPoint()
	{
		using (List<IExplorePlayProgressItemData>.Enumerator enumerator = this.PlayProgressDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.PlayPointType == EPlayPointType.Hidden)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600CB93 RID: 52115 RVA: 0x00365184 File Offset: 0x00363384
	public bool IsNearestPlayPointUnlock()
	{
		MapMark? nearTrackMapMark = this.GetNearTrackMapMark();
		bool result = true;
		if (nearTrackMapMark == null || nearTrackMapMark.Value.GameplayLockJumpId == 0 || nearTrackMapMark.Value.GameplayLockText == "")
		{
			return result;
		}
		if (!this.GetPlayIdIsUnlock(nearTrackMapMark.Value.RelativeId))
		{
			result = false;
		}
		return result;
	}

	// Token: 0x0600CB94 RID: 52116 RVA: 0x003651EB File Offset: 0x003633EB
	public void TrackPoint()
	{
		if (this.PlayIdMap.Count > 0)
		{
			this.TrackPlayPoint();
			return;
		}
		this.TrackEntityPoint();
	}

	// Token: 0x0600CB95 RID: 52117 RVA: 0x0036520C File Offset: 0x0036340C
	private void TrackEntityPoint()
	{
		int exploratoryDegree = this.SubTypes[0];
		ControllerBase<ExploreProgressController>.Instance.ExploreEntityTraceRequest(exploratoryDegree, this.AreaId);
	}

	// Token: 0x0600CB96 RID: 52118 RVA: 0x00365234 File Offset: 0x00363434
	public bool TrackPlayPoint()
	{
		if (this.TrackExploreType())
		{
			return true;
		}
		if (this.IsFinishedPlayPoint)
		{
			return false;
		}
		EPlayPointState trackPlayState = this.GetTrackPlayState();
		List<IPlayPointInfo> playPointIdsByState = this.GetPlayPointIdsByState(trackPlayState);
		if (playPointIdsByState.Count == 0)
		{
			return false;
		}
		MapMark? markByPointState = this.GetMarkByPointState(trackPlayState, playPointIdsByState);
		if (markByPointState == null)
		{
			return false;
		}
		if (trackPlayState == EPlayPointState.ToBeCompleted)
		{
			if (!ModelBase<MapModel>.Instance.IsMarkFogUnlock(markByPointState.Value.MarkId))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("MapAreaIsLock", Array.Empty<object>());
				return false;
			}
			if (!ModelBase<MapModel>.Instance.IsConfigMarkIdUnlock(markByPointState.Value.MarkId))
			{
				ModelBase<MapModel>.Instance.CreateTempMapMark(markByPointState.Value.MarkId);
			}
			Singleton<EventSystem>.Instance.Emit<NavigateMark>(EEventName.WorldMapNavigate, new NavigateMark
			{
				MarkId = markByPointState.Value.MarkId,
				MarkType = (EMarkType)markByPointState.Value.ObjectType,
				Focal = new bool?(true),
				NeedTempShow = new bool?(true)
			});
		}
		else if (trackPlayState == EPlayPointState.Locked)
		{
			this.TrackLockedPlayPointMark(markByPointState.Value);
		}
		return true;
	}

	// Token: 0x0600CB97 RID: 52119 RVA: 0x00365358 File Offset: 0x00363558
	public MapMark? GetNearTrackMapMark()
	{
		if (this.PlayIdMap.Count <= 0)
		{
			return null;
		}
		if (this.IsFinishedPlayPoint)
		{
			return null;
		}
		EPlayPointState trackPlayState = this.GetTrackPlayState();
		List<IPlayPointInfo> playPointIdsByState = this.GetPlayPointIdsByState(trackPlayState);
		if (playPointIdsByState.Count == 0)
		{
			return null;
		}
		return this.GetMarkByPointState(trackPlayState, playPointIdsByState);
	}

	// Token: 0x0600CB98 RID: 52120 RVA: 0x003653B8 File Offset: 0x003635B8
	public MapMark? GetMarkByPointState(EPlayPointState state, List<IPlayPointInfo> playIds)
	{
		EExploreTrackType eexploreTrackType = (state == EPlayPointState.Locked) ? this.LockTrackType : this.UnlockTrackType;
		if (eexploreTrackType == EExploreTrackType.Nearest)
		{
			return this.GetNearMapMarkByPlayIds(playIds);
		}
		if (eexploreTrackType != EExploreTrackType.MinId)
		{
			return null;
		}
		return this.GetMinMarkIdPlayPoint(playIds);
	}

	// Token: 0x0600CB99 RID: 52121 RVA: 0x003653FC File Offset: 0x003635FC
	public bool GetPlayIdIsUnlock(int playId)
	{
		IPlayPointInfo playPointInfo;
		return !this.PlayIdMap.TryGetValue(playId, out playPointInfo) || playPointInfo.IsUnlock;
	}

	// Token: 0x0600CB9A RID: 52122 RVA: 0x00365424 File Offset: 0x00363624
	private void TrackLockedPlayPointMark(MapMark nearMark)
	{
		IPlayPointInfo findPlayIdInfo = this.FindPlayIdInfo;
		if (findPlayIdInfo != null && findPlayIdInfo.IsClear.GetValueOrDefault())
		{
			this.FindClearPlayPointMark();
			return;
		}
		NavigateMarkShowRange navigateMarkShowRange = new NavigateMarkShowRange
		{
			MarkId = nearMark.MarkId,
			MarkType = (EMarkType)nearMark.ObjectType,
			Tips = "NoPlayPoint_Text",
			GamePlayId = new int?(nearMark.RelativeId),
			ExploreTypeName = this.GetNameId()
		};
		ModelBase<WorldMapModel>.Instance.NavigateMarkShowRangeInfo = navigateMarkShowRange;
		Singleton<EventSystem>.Instance.Emit<NavigateMarkShowRange>(EEventName.NavigateMarkAndShowRange, navigateMarkShowRange);
	}

	// Token: 0x0600CB9B RID: 52123 RVA: 0x003654BC File Offset: 0x003636BC
	private void FindClearPlayPointMark()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ExploreClearPlayPointMark);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			IPlayPointInfo findPlayIdInfo = this.FindPlayIdInfo;
			string text = (findPlayIdInfo != null) ? findPlayIdInfo.ClearInfo : null;
			if (text == null)
			{
				return;
			}
			string[] array = text.Split('_', StringSplitOptions.None);
			string a = array[0].ToLower();
			string clearId = array[1];
			if (a == "q")
			{
				this.FindQuestMark(clearId);
				return;
			}
			if (a == "l")
			{
				this.FindPlayPointMark(clearId);
			}
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600CB9C RID: 52124 RVA: 0x003654F8 File Offset: 0x003636F8
	private void FindQuestMark(string clearId)
	{
		int questId = int.Parse(clearId);
		global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(questId);
		int? num;
		if (quest == null)
		{
			num = null;
		}
		else
		{
			BehaviorNodeBase currentActiveChildQuestNode = quest.GetCurrentActiveChildQuestNode();
			num = ((currentActiveChildQuestNode != null) ? new int?(currentActiveChildQuestNode.NodeId) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault();
		int valueOrDefault2 = ((quest != null) ? quest.GetDefaultMark(valueOrDefault) : null).GetValueOrDefault();
		if (valueOrDefault2 == 0 || (quest != null && quest.IsSuspend()))
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<NavigateMark>(EEventName.WorldMapNavigate, new NavigateMark
		{
			MarkId = valueOrDefault2,
			MarkType = EMarkType.Quest,
			Focal = new bool?(true),
			NeedTempShow = new bool?(true)
		});
		this.CheckClearFindMarkIsHideRange(valueOrDefault2, EMarkType.Quest);
	}

	// Token: 0x0600CB9D RID: 52125 RVA: 0x003655C8 File Offset: 0x003637C8
	private void FindPlayPointMark(string clearId)
	{
		int playId = int.Parse(clearId);
		MapMark? mapMarkByPlayId = this.GetMapMarkByPlayId(playId);
		if (mapMarkByPlayId == null)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<NavigateMark>(EEventName.WorldMapNavigate, new NavigateMark
		{
			MarkId = mapMarkByPlayId.Value.MarkId,
			MarkType = (EMarkType)mapMarkByPlayId.Value.ObjectType,
			Focal = new bool?(true),
			NeedTempShow = new bool?(true)
		});
		this.CheckClearFindMarkIsHideRange(mapMarkByPlayId.Value.MarkId, (EMarkType)mapMarkByPlayId.Value.ObjectType);
	}

	// Token: 0x0600CB9E RID: 52126 RVA: 0x0036566C File Offset: 0x0036386C
	private void CheckClearFindMarkIsHideRange(int markId, EMarkType markType)
	{
		NavigateMarkShowRange navigateMarkShowRangeInfo = ModelBase<WorldMapModel>.Instance.NavigateMarkShowRangeInfo;
		if (navigateMarkShowRangeInfo != null && navigateMarkShowRangeInfo.MarkId == markId && navigateMarkShowRangeInfo != null && navigateMarkShowRangeInfo.MarkType == markType)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.HideNavigateMarkRange);
		}
	}

	// Token: 0x0600CB9F RID: 52127 RVA: 0x003656AC File Offset: 0x003638AC
	private bool TrackExploreType()
	{
		if (this.PlayIdMap.Count > 0)
		{
			return false;
		}
		ScrollingTipsController instance = ControllerBase<ScrollingTipsController>.Instance;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 2);
		defaultInterpolatedStringHandler.AppendLiteral("Track ExploreType: ");
		defaultInterpolatedStringHandler.AppendFormatted<EExploreType>(this.ExploreType);
		defaultInterpolatedStringHandler.AppendLiteral(", AreaId: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.AreaId);
		instance.ShowTipsByText(defaultInterpolatedStringHandler.ToStringAndClear());
		return true;
	}

	// Token: 0x0600CBA0 RID: 52128 RVA: 0x00365718 File Offset: 0x00363918
	private EPlayPointState GetTrackPlayState()
	{
		EPlayPointState result = EPlayPointState.Locked;
		if (this.PlayPointToBeCompletedCount > 0)
		{
			result = EPlayPointState.ToBeCompleted;
		}
		return result;
	}

	// Token: 0x0600CBA1 RID: 52129 RVA: 0x00365734 File Offset: 0x00363934
	private List<IPlayPointInfo> GetPlayPointIdsByState(EPlayPointState findState)
	{
		List<IPlayPointInfo> list = new List<IPlayPointInfo>();
		foreach (IPlayPointInfo playPointInfo in this.PlayIdMap.Values)
		{
			if (playPointInfo.PlayState == findState)
			{
				list.Add(playPointInfo);
			}
		}
		int count = list.Count;
		return list;
	}

	// Token: 0x0600CBA2 RID: 52130 RVA: 0x003657A4 File Offset: 0x003639A4
	private MapMark? GetNearMapMarkByPlayIds(List<IPlayPointInfo> infoList)
	{
		if (infoList.Count == 0)
		{
			return null;
		}
		int scale = 1000;
		global::Vector myPos = ModelBase<WorldMapModel>.Instance.GetPlayerPosition();
		myPos.DivisionEqual((double)scale);
		List<ValueTuple<IPlayPointInfo, MapMark?>> list = new List<ValueTuple<IPlayPointInfo, MapMark?>>();
		foreach (IPlayPointInfo playPointInfo in infoList)
		{
			MapMark? mapMarkByPlayInfo = this.GetMapMarkByPlayInfo(playPointInfo);
			if (mapMarkByPlayInfo != null)
			{
				list.Add(new ValueTuple<IPlayPointInfo, MapMark?>(playPointInfo, mapMarkByPlayInfo));
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		list.Sort(delegate([TupleElementNames(new string[]
		{
			"Info",
			"Mark"
		})] [Nullable(new byte[]
		{
			0,
			1
		})] ValueTuple<IPlayPointInfo, MapMark?> a, [TupleElementNames(new string[]
		{
			"Info",
			"Mark"
		})] [Nullable(new byte[]
		{
			0,
			1
		})] ValueTuple<IPlayPointInfo, MapMark?> b)
		{
			if (a.Item1.IsUnlock == b.Item1.IsUnlock)
			{
				global::Vector entityPosition = ModelBase<WorldMapModel>.Instance.GetEntityPosition(a.Item2.Value.EntityConfigId, a.Item2.Value.MapId);
				global::Vector entityPosition2 = ModelBase<WorldMapModel>.Instance.GetEntityPosition(b.Item2.Value.EntityConfigId, b.Item2.Value.MapId);
				entityPosition.DivisionEqual((double)(scale * 100));
				entityPosition2.DivisionEqual((double)(scale * 100));
				double num = global::Vector.DistSquared(myPos, entityPosition);
				double value = global::Vector.DistSquared(myPos, entityPosition2);
				return num.CompareTo(value);
			}
			if (!a.Item1.IsUnlock)
			{
				return 1;
			}
			return -1;
		});
		ValueTuple<IPlayPointInfo, MapMark?> valueTuple = list[0];
		this.FindPlayIdInfo = valueTuple.Item1;
		return valueTuple.Item2;
	}

	// Token: 0x0600CBA3 RID: 52131 RVA: 0x0036589C File Offset: 0x00363A9C
	private MapMark? GetMinMarkIdPlayPoint(List<IPlayPointInfo> infoList)
	{
		if (infoList.Count == 0)
		{
			return null;
		}
		List<ValueTuple<IPlayPointInfo, MapMark?>> list = new List<ValueTuple<IPlayPointInfo, MapMark?>>();
		foreach (IPlayPointInfo playPointInfo in infoList)
		{
			MapMark? mapMarkByPlayInfo = this.GetMapMarkByPlayInfo(playPointInfo);
			if (mapMarkByPlayInfo != null)
			{
				list.Add(new ValueTuple<IPlayPointInfo, MapMark?>(playPointInfo, mapMarkByPlayInfo));
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		list.Sort(delegate([TupleElementNames(new string[]
		{
			"Info",
			"Mark"
		})] [Nullable(new byte[]
		{
			0,
			1
		})] ValueTuple<IPlayPointInfo, MapMark?> a, [TupleElementNames(new string[]
		{
			"Info",
			"Mark"
		})] [Nullable(new byte[]
		{
			0,
			1
		})] ValueTuple<IPlayPointInfo, MapMark?> b)
		{
			if (a.Item1.IsUnlock == b.Item1.IsUnlock)
			{
				return a.Item2.Value.MarkId - b.Item2.Value.MarkId;
			}
			if (!a.Item1.IsUnlock)
			{
				return 1;
			}
			return -1;
		});
		ValueTuple<IPlayPointInfo, MapMark?> valueTuple = list[0];
		this.FindPlayIdInfo = valueTuple.Item1;
		return valueTuple.Item2;
	}

	// Token: 0x0600CBA4 RID: 52132 RVA: 0x00365970 File Offset: 0x00363B70
	private MapMark? GetMapMarkByPlayInfo(IPlayPointInfo info)
	{
		return this.GetMapMarkByPlayId(info.PlayId);
	}

	// Token: 0x0600CBA5 RID: 52133 RVA: 0x00365980 File Offset: 0x00363B80
	public MapMark? GetMapMarkByPlayId(int playId)
	{
		ExploreAreaData exploreAreaData = ModelBase<ExploreProgressModel>.Instance.GetExploreAreaData(this.AreaId);
		if (exploreAreaData == null)
		{
			return null;
		}
		return ConfigBase<MapConfig>.Instance.GetMapMarkByRelativeId(playId, exploreAreaData.GetSceneId());
	}

	// Token: 0x0600CBA6 RID: 52134 RVA: 0x003659BC File Offset: 0x00363BBC
	public EPlayPointState[] GetPlayPointStateList()
	{
		EPlayPointState[] array = new EPlayPointState[this.PlayProgressDataList.Count];
		for (int i = 0; i < this.PlayProgressDataList.Count; i++)
		{
			array[i] = this.PlayProgressDataList[i].PlayPointState;
		}
		return array;
	}

	// Token: 0x0600CBA7 RID: 52135 RVA: 0x00365A05 File Offset: 0x00363C05
	public void LogInfo()
	{
	}

	// Token: 0x0600CBA8 RID: 52136 RVA: 0x00365A07 File Offset: 0x00363C07
	public void FinishNewRecommendPlay()
	{
		this.IsNewRecommendPlay = false;
	}

	// Token: 0x0600CBA9 RID: 52137 RVA: 0x00365A10 File Offset: 0x00363C10
	[NullableContext(2)]
	public void SetSequenceData(ExploreAreaItemData data = null)
	{
		this.SequenceData = data;
	}

	// Token: 0x0600CBAA RID: 52138 RVA: 0x00365A19 File Offset: 0x00363C19
	public void SetFlagSequenceData(bool flag)
	{
		this.FlagSequenceData = flag;
	}

	// Token: 0x0600CBAB RID: 52139 RVA: 0x00365A22 File Offset: 0x00363C22
	public bool GetFlagSequenceDataAndClean()
	{
		bool flagSequenceData = this.FlagSequenceData;
		this.FlagSequenceData = false;
		return flagSequenceData;
	}

	// Token: 0x0600CBAC RID: 52140 RVA: 0x00365A34 File Offset: 0x00363C34
	public List<IExplorePlayProgressItemData> GetPlayProgressDataIgnoreHiddenList()
	{
		List<IExplorePlayProgressItemData> list = new List<IExplorePlayProgressItemData>();
		foreach (IExplorePlayProgressItemData explorePlayProgressItemData in this.PlayProgressDataList)
		{
			ExplorePlayProgressItemData item = new ExplorePlayProgressItemData
			{
				ExploreType = explorePlayProgressItemData.ExploreType,
				PlayPointType = explorePlayProgressItemData.PlayPointType,
				PlayPointState = explorePlayProgressItemData.PlayPointState,
				PlayPointId = explorePlayProgressItemData.PlayPointId,
				LastPlayPointState = explorePlayProgressItemData.LastPlayPointState,
				EntityId = explorePlayProgressItemData.EntityId,
				IgnoreHiddenType = new bool?(true),
				IsClear = explorePlayProgressItemData.IsClear,
				ClearInfo = explorePlayProgressItemData.ClearInfo,
				IsUnlock = explorePlayProgressItemData.IsUnlock
			};
			list.Add(item);
		}
		return list;
	}

	// Token: 0x0600CBAD RID: 52141 RVA: 0x00365B14 File Offset: 0x00363D14
	public void SetEntityList(int[] entityList)
	{
		this.EntityList = entityList;
		this.CalcEntityDistance();
		this.CreateEntityMark();
	}

	// Token: 0x0600CBAE RID: 52142 RVA: 0x00365B2C File Offset: 0x00363D2C
	public void CalcEntityDistance()
	{
		if (this.EntityList == null || this.EntityList.Length < 2)
		{
			return;
		}
		int num = 1000;
		Aki.Config.Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(this.AreaId);
		if (areaInfo == null)
		{
			return;
		}
		int mapConfigId = areaInfo.Value.MapConfigId;
		global::Vector playerPosition = ModelBase<WorldMapModel>.Instance.GetPlayerPosition();
		double num2 = 2147483647.0;
		int num3 = 0;
		playerPosition.DivisionEqual((double)num);
		for (int i = 0; i < this.EntityList.Length; i++)
		{
			int pbDataId = this.EntityList[i];
			global::Vector entityPosition = ModelBase<WorldMapModel>.Instance.GetEntityPosition(pbDataId, mapConfigId);
			entityPosition.DivisionEqual((double)num);
			double num4 = global::Vector.DistSquared(playerPosition, entityPosition);
			if (num4 < num2)
			{
				num2 = num4;
				num3 = i;
			}
		}
		if (num3 > 0)
		{
			int item = this.EntityList[num3];
			List<int> list = new List<int>(this.EntityList);
			list.RemoveAt(num3);
			list.Insert(0, item);
			this.EntityList = list.ToArray();
		}
	}

	// Token: 0x0600CBAF RID: 52143 RVA: 0x00365C34 File Offset: 0x00363E34
	public void CreateEntityMark()
	{
		if (this.EntityList.Length == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.ExploreProgress, ELogAuthor.CB, "实体Id列表为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		EMarkType markType;
		if (!ExploreProgressDefine.exploreType2MarkType.TryGetValue((int)this.ExploreType, out markType))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ExploreProgress;
			ELogAuthor author = ELogAuthor.CB;
			string message = "找不到探索项对应的标记类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ExploreType", this.ExploreType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		int configId;
		if (!ExploreProgressDefine.exploreType2Config.TryGetValue((int)this.ExploreType, out configId))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.ExploreProgress;
			ELogAuthor author2 = ELogAuthor.CB;
			string message2 = "找不到探索项对应的标记id配置";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ExploreType", this.ExploreType);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		Aki.Config.Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(this.AreaId);
		if (areaInfo == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.ExploreProgress;
			ELogAuthor author3 = ELogAuthor.CB;
			string message3 = "找不到探索项对应的区域id配置";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("ExploreType", this.ExploreType);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return;
		}
		int entityId = this.EntityList[0];
		int num = ModelBase<MapModel>.Instance.CreateDyMarkByEntity(entityId, markType, configId, areaInfo.Value.MapConfigId);
		ModelBase<MapModel>.Instance.AddPendingTempMapMarkList(num);
		Singleton<EventSystem>.Instance.Emit<NavigateMark>(EEventName.WorldMapNavigate, new NavigateMark
		{
			MarkId = num,
			MarkType = markType,
			Focal = new bool?(true)
		});
	}

	// Token: 0x04006141 RID: 24897
	public int AreaId;

	// Token: 0x04006142 RID: 24898
	public EExploreType ExploreType;

	// Token: 0x04006143 RID: 24899
	public int ExploreProgressId;

	// Token: 0x04006144 RID: 24900
	public int ConfigId;

	// Token: 0x04006145 RID: 24901
	private int ExploreProgress;

	// Token: 0x04006146 RID: 24902
	private int CurrentCount;

	// Token: 0x04006147 RID: 24903
	private int TotalCount;

	// Token: 0x04006148 RID: 24904
	[Nullable(2)]
	private string TypeNameId;

	// Token: 0x04006149 RID: 24905
	private int PhantomSkillId;

	// Token: 0x0400614A RID: 24906
	[Nullable(2)]
	private string UnlockTextId;

	// Token: 0x0400614B RID: 24907
	[Nullable(2)]
	private string LockTextId;

	// Token: 0x0400614C RID: 24908
	private bool IsPhantomSkillUnlock;

	// Token: 0x0400614D RID: 24909
	private int CountMode;

	// Token: 0x0400614E RID: 24910
	public string Icon;

	// Token: 0x0400614F RID: 24911
	public string DescBg;

	// Token: 0x04006150 RID: 24912
	public int SortIndex;

	// Token: 0x04006151 RID: 24913
	public string LockDescId;

	// Token: 0x04006152 RID: 24914
	public string DescId;

	// Token: 0x04006153 RID: 24915
	public int[] SubTypes;

	// Token: 0x04006154 RID: 24916
	public int UnlockConditionId;

	// Token: 0x04006155 RID: 24917
	public int AccessPathId;

	// Token: 0x04006156 RID: 24918
	public Dictionary<int, int> SpecialPlayPointIndexMap = new Dictionary<int, int>();

	// Token: 0x04006157 RID: 24919
	public bool IsRecommend;

	// Token: 0x04006158 RID: 24920
	private bool IsShowProgress;

	// Token: 0x04006159 RID: 24921
	public bool IsShowTrackBtn;

	// Token: 0x0400615A RID: 24922
	public bool IsNewRecommendPlay;

	// Token: 0x0400615B RID: 24923
	[Nullable(2)]
	public ExploreAreaItemData SequenceData;

	// Token: 0x0400615C RID: 24924
	public bool FlagSequenceData;

	// Token: 0x0400615D RID: 24925
	public readonly List<IExplorePlayProgressItemData> PlayProgressDataList = new List<IExplorePlayProgressItemData>();

	// Token: 0x0400615E RID: 24926
	public int PlayPointTotalCount;

	// Token: 0x0400615F RID: 24927
	public int PlayPointCompletedCount;

	// Token: 0x04006160 RID: 24928
	public int PlayPointToBeCompletedCount;

	// Token: 0x04006161 RID: 24929
	public int PlayPointLockedCount;

	// Token: 0x04006162 RID: 24930
	public EExploreTrackType UnlockTrackType;

	// Token: 0x04006163 RID: 24931
	public EExploreTrackType LockTrackType;

	// Token: 0x04006164 RID: 24932
	public readonly Dictionary<int, IPlayPointInfo> PlayIdMap = new Dictionary<int, IPlayPointInfo>();

	// Token: 0x04006165 RID: 24933
	[Nullable(2)]
	private IPlayPointInfo FindPlayIdInfo;

	// Token: 0x04006166 RID: 24934
	public string SpecialPlayerDesc;

	// Token: 0x04006167 RID: 24935
	private bool IsUnlock;

	// Token: 0x04006168 RID: 24936
	private int[] EntityList;
}
