using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x0200153E RID: 5438
[NullableContext(1)]
[Nullable(0)]
public static class ActivityRegressHelper
{
	// Token: 0x06009890 RID: 39056 RVA: 0x0027F680 File Offset: 0x0027D880
	[NullableContext(0)]
	public static void RefreshItemGrid([Nullable(1)] SmallItemGrid itemGrid, ItemInfo itemInfo, int itemCount, [TupleElementNames(new string[]
	{
		"lockVisible",
		"receivableVisible",
		"receivedVisible"
	})] ValueTuple<bool, bool, bool> state)
	{
		int id = itemInfo.Id;
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(id));
		bool item = state.Item1;
		bool item2 = state.Item2;
		bool item3 = state.Item3;
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.RoleItem)
		{
			RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(id).Value;
			CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
			{
				Data = itemInfo,
				ElementId = new int?(value.ElementId),
				ItemConfigId = new int?(id),
				BottomText = itemCount.ToString(),
				QualityId = new int?(value.QualityId),
				IsLockVisible = new bool?(item),
				IsReceivableVisible = new bool?(item2),
				IsReceivedVisible = new bool?(item3),
				IsRedDotVisible = new bool?(item2)
			};
			itemGrid.Apply<CharacterSmallItemGrid>(parameters);
			return;
		}
		if (itemDataTypeByConfigId != InventoryDefine.EItemDataType.PhantomItem)
		{
			PropSmallItemGrid parameters2 = new PropSmallItemGrid
			{
				Data = itemInfo,
				ItemConfigId = new int?(id),
				BottomText = itemCount.ToString(),
				IsLockVisible = new bool?(item),
				IsReceivableVisible = new bool?(item2),
				IsReceivedVisible = new bool?(item3),
				IsRedDotVisible = new bool?(item2)
			};
			itemGrid.Apply<PropSmallItemGrid>(parameters2);
			return;
		}
		PhantomSmallItemGrid parameters3 = new PhantomSmallItemGrid
		{
			Data = itemInfo,
			ItemConfigId = new int?(id),
			BottomText = itemCount.ToString(),
			IsLockVisible = new bool?(item),
			IsReceivableVisible = new bool?(item2),
			IsReceivedVisible = new bool?(item3),
			IsRedDotVisible = new bool?(item2)
		};
		itemGrid.Apply<PhantomSmallItemGrid>(parameters3);
	}

	// Token: 0x06009891 RID: 39057 RVA: 0x0027F838 File Offset: 0x0027DA38
	public static void RefreshItemGridByData(SmallItemGrid itemGrid, IRegressRewardItemInfo data)
	{
		ItemInfo? itemInfo = data.ItemInfo;
		int itemCount = data.ItemCount;
		bool item = data.RewardState == ERegressRewardState.UnReach;
		bool item2 = data.RewardState == ERegressRewardState.Reached;
		bool item3 = data.RewardState == ERegressRewardState.Claim;
		ActivityRegressHelper.RefreshItemGrid(itemGrid, itemInfo.Value, itemCount, new ValueTuple<bool, bool, bool>(item, item2, item3));
	}

	// Token: 0x06009892 RID: 39058 RVA: 0x0027F88E File Offset: 0x0027DA8E
	public static void ReportRecallLog1023(EReportLogEventType eventType)
	{
		ActivityRegressHelper.ReportLog("1023", eventType, 0);
	}

	// Token: 0x06009893 RID: 39059 RVA: 0x0027F89C File Offset: 0x0027DA9C
	public static void ReportRecallLog1024(EReportLogEventType eventType, int questId = 0)
	{
		ActivityRegressHelper.ReportLog("1024", eventType, questId);
	}

	// Token: 0x06009894 RID: 39060 RVA: 0x0027F8AC File Offset: 0x0027DAAC
	private static void ReportLog(string eventId, EReportLogEventType eventType, int questId = 0)
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		ActivityRecallLogData logData = new ActivityRecallLogData
		{
			event_id = eventId,
			i_activity_id = activityData.Id,
			i_activity_type = (int)activityData.Type,
			i_time_left = (int)activityData.GetActivityOpenTimeLeft(),
			i_type = (int)eventType,
			i_quest_id = questId,
			i_grade_id = (int)ModelBase<ActivityRegressModel>.Instance.Grade
		};
		ControllerBase<LogReportController>.Instance.LogReport(logData);
	}

	// Token: 0x06009895 RID: 39061 RVA: 0x0027F91F File Offset: 0x0027DB1F
	public static void ReportRecallLog1023New(EReportLogEventNewType eventType)
	{
		ActivityRegressHelper.ReportLogNew("1023", eventType, 0, 0);
	}

	// Token: 0x06009896 RID: 39062 RVA: 0x0027F92E File Offset: 0x0027DB2E
	public static void ReportRecallLog1024New(EReportLogEventNewType eventType, int questId = 0, int doubleDropType = 0)
	{
		ActivityRegressHelper.ReportLogNew("1024", eventType, questId, doubleDropType);
	}

	// Token: 0x06009897 RID: 39063 RVA: 0x0027F940 File Offset: 0x0027DB40
	private static void ReportLogNew(string eventId, EReportLogEventNewType eventType, int questId = 0, int doubleDropType = 0)
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		ActivityRecallLogData logData = new ActivityRecallLogData
		{
			event_id = eventId,
			i_activity_id = activityData.Id,
			i_activity_type = (int)activityData.Type,
			i_time_left = (int)activityData.GetActivityOpenTimeLeft(),
			i_type = (int)eventType,
			i_quest_id = questId,
			i_grade_id = (int)ModelBase<ActivityRegressModel>.Instance.Grade,
			i_id = doubleDropType
		};
		ControllerBase<LogReportController>.Instance.LogReport(logData);
	}

	// Token: 0x06009898 RID: 39064 RVA: 0x0027F9BA File Offset: 0x0027DBBA
	public static void ReportRegressLog1060()
	{
		ActivityRegressHelper.ReportRegressLog("1060", 0);
	}

	// Token: 0x06009899 RID: 39065 RVA: 0x0027F9C7 File Offset: 0x0027DBC7
	public static void ReportRegressLog1061(int questionnaireId)
	{
		ActivityRegressHelper.ReportRegressLog("1061", questionnaireId);
	}

	// Token: 0x0600989A RID: 39066 RVA: 0x0027F9D4 File Offset: 0x0027DBD4
	private static void ReportRegressLog(string eventId, int questionnaireId = 0)
	{
		ActivityRegressLogData logData = new ActivityRegressLogData
		{
			event_id = eventId,
			i_activity_id = ModelBase<ActivityRegressModel>.Instance.ActivityId,
			i_grade_id = (int)ModelBase<ActivityRegressModel>.Instance.Grade,
			i_question_id = questionnaireId
		};
		ControllerBase<LogReportController>.Instance.LogReport(logData);
	}

	// Token: 0x0600989B RID: 39067 RVA: 0x0027FA20 File Offset: 0x0027DC20
	public static Area? GetMinExploreAreaInfo()
	{
		Dictionary<int, bool> allUnlockedAreas = ModelBase<MapModel>.Instance.GetAllUnlockedAreas();
		if (allUnlockedAreas == null || allUnlockedAreas.Count <= 0)
		{
			return null;
		}
		List<ExploreAreaData> list = new List<ExploreAreaData>();
		foreach (KeyValuePair<int, bool> keyValuePair in allUnlockedAreas)
		{
			int key = keyValuePair.Key;
			ExploreAreaData exploreAreaData = ModelBase<ExploreProgressModel>.Instance.GetExploreAreaData(key);
			if (exploreAreaData != null)
			{
				list.Add(exploreAreaData);
			}
		}
		list.Sort((ExploreAreaData openAreaDataA, ExploreAreaData openAreaDataB) => openAreaDataA.GetProgress().CompareTo(openAreaDataB.GetProgress()));
		if (list.Count <= 0)
		{
			return null;
		}
		Area? result = null;
		foreach (ExploreAreaData exploreAreaData2 in list)
		{
			int areaId = exploreAreaData2.AreaId;
			Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaId);
			if (areaInfo != null && areaInfo.Value.DeliveryMarkId != 0)
			{
				int deliveryMarkId = areaInfo.Value.DeliveryMarkId;
				MapMark value = ConfigBase<MapConfig>.Instance.GetConfigMark(deliveryMarkId).Value;
				if (ModelBase<MapModel>.Instance.CheckFogUnlocked(value.FogHide, null))
				{
					result = areaInfo;
					break;
				}
			}
		}
		return result;
	}
}
