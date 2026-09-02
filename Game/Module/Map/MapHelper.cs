using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.Map
{
	// Token: 0x020057E5 RID: 22501
	[NullableContext(1)]
	[Nullable(0)]
	public static class MapHelper
	{
		// Token: 0x060392EF RID: 234223 RVA: 0x00E7F418 File Offset: 0x00E7D618
		public static void CheckAndShowCrossMapTips(int markId, EMarkType markType, int? areaId, global::Vector worldPosition)
		{
			int markMapConfigId = ModelBase<MapModel>.Instance.GetMarkMapConfigId(markId, markType);
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			if (MapUtil.IsDungeonDiffWorld(markMapConfigId, instanceId).GetValueOrDefault())
			{
				if (areaId != null && areaId.Value > 0)
				{
					string levelOneAreaNameLocalTextId = MapHelper.GetLevelOneAreaNameLocalTextId(areaId.Value);
					if (!string.IsNullOrEmpty(levelOneAreaNameLocalTextId))
					{
						string areaLocalName = ConfigBase<AreaConfig>.Instance.GetAreaLocalName(levelOneAreaNameLocalTextId);
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("CrossMapMainTips", new object[]
						{
							areaLocalName
						});
						return;
					}
				}
				string mapNameByInstanceId = MapUtil.GetMapNameByInstanceId(markMapConfigId, worldPosition);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("CrossMapMainTips", new object[]
				{
					mapNameByInstanceId
				});
			}
		}

		// Token: 0x060392F0 RID: 234224 RVA: 0x00E7F4C4 File Offset: 0x00E7D6C4
		public static string GetLevelOneAreaNameLocalTextId(int areaId)
		{
			int levelOneAreaId = ConfigBase<AreaConfig>.Instance.GetLevelOneAreaId(areaId);
			int areaId2 = (levelOneAreaId != 0) ? levelOneAreaId : areaId;
			Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaId2);
			return ((areaInfo != null) ? areaInfo.GetValueOrDefault().Title : null) ?? "";
		}

		// Token: 0x060392F1 RID: 234225 RVA: 0x00E7F518 File Offset: 0x00E7D718
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public unsafe static ValueTuple<bool, int, int, string, string> GetDoubleRestAndMaxTimes(ConfigMarkItem markItem)
		{
			if (markItem.MarkConfig.Value.RelativeSubType == 1)
			{
				ActivityDoubleRewardController instance = ControllerBase<ActivityDoubleRewardController>.Instance;
				int num = 1;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount<int>(list, num);
				Span<int> span = CollectionsMarshal.AsSpan<int>(list);
				int index = 0;
				*span[index] = 3;
				ActivityDoubleRewardData dungeonUpActivity = instance.GetDungeonUpActivity(list, false);
				bool flag = dungeonUpActivity != null;
				int num2 = 0;
				int item = 0;
				if (dungeonUpActivity != null)
				{
					ValueTuple<string, int, int> numTxtAndParam = dungeonUpActivity.GetNumTxtAndParam();
					num2 = numTxtAndParam.Item2;
					item = numTxtAndParam.Item3;
				}
				if (flag)
				{
					return new ValueTuple<bool, int, int, string, string>(flag, num2, item, (num2 > 0) ? "Reward_doubling_time" : "Reward_doubling_end", "Double_reward_tips_02");
				}
			}
			int num3 = markItem.MarkConfig.Value.RelativeId;
			num3 = ((num3 != 0) ? num3 : ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetEntranceIdByMarkId(markItem.MarkConfigId));
			if (ModelBase<ActivityRegressModel>.Instance.DungeonHasDoubleDropTimes(num3, EDungeonType.Boss) || ModelBase<ActivityRegressModel>.Instance.LevelPlayHasDoubleDropTimes(num3, EDungeonType.Boss))
			{
				return ModelBase<ActivityRegressModel>.Instance.GetDetectionDoubleDropTuple(EDungeonType.Boss);
			}
			if (ModelBase<ActivityRegressModel>.Instance.DungeonHasDoubleDropTimes(num3, EDungeonType.Weekly) || ModelBase<ActivityRegressModel>.Instance.LevelPlayHasDoubleDropTimes(num3, EDungeonType.Weekly))
			{
				return ModelBase<ActivityRegressModel>.Instance.GetDetectionDoubleDropTuple(EDungeonType.Weekly);
			}
			return new ValueTuple<bool, int, int, string, string>(false, 0, 0, "", "");
		}
	}
}
