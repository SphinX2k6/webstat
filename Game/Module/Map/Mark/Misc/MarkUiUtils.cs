using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.View.BaseMap;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.Map.Mark.Misc
{
	// Token: 0x02005823 RID: 22563
	[NullableContext(1)]
	[Nullable(0)]
	public static class MarkUiUtils
	{
		// Token: 0x060395CC RID: 234956 RVA: 0x00E8E814 File Offset: 0x00E8CA14
		public static bool IsShowGoto(MarkItem markItem)
		{
			TeleportMarkItem teleportMarkItem = markItem as TeleportMarkItem;
			if (teleportMarkItem != null && !teleportMarkItem.IsActivity)
			{
				return teleportMarkItem.IsLocked;
			}
			HonamiScanMarkItem honamiScanMarkItem = markItem as HonamiScanMarkItem;
			if (honamiScanMarkItem != null)
			{
				return honamiScanMarkItem.IsLocked;
			}
			if (markItem.MarkType != EMarkType.CorniceMeeting)
			{
				SceneGameplayMarkItem sceneGameplayMarkItem = markItem as SceneGameplayMarkItem;
				if (sceneGameplayMarkItem != null)
				{
					if (sceneGameplayMarkItem.IsLocked)
					{
						return true;
					}
					LevelPlayModel instance = ModelBase<LevelPlayModel>.Instance;
					SceneGameplayMarkItem sceneGameplayMarkItem2 = sceneGameplayMarkItem;
					LevelPlayInfo levelPlayInfo = instance.GetLevelPlayInfo((sceneGameplayMarkItem2.MarkConfig != null) ? sceneGameplayMarkItem2.MarkConfig.GetValueOrDefault().RelativeId : 0);
					return levelPlayInfo == null || levelPlayInfo.IsClose;
				}
				else
				{
					FixedSceneGameplayMarkItem fixedSceneGameplayMarkItem = markItem as FixedSceneGameplayMarkItem;
					if (fixedSceneGameplayMarkItem != null)
					{
						return fixedSceneGameplayMarkItem.IsLocked;
					}
				}
			}
			if (markItem is TaskMarkItem)
			{
				return true;
			}
			if (markItem.MarkType == EMarkType.PunishReport || markItem.MarkType == EMarkType.LevelPlayReport)
			{
				ConfigMarkItem configMarkItem = markItem as ConfigMarkItem;
				return configMarkItem != null && configMarkItem.IsLocked;
			}
			if (MarkUiUtils.ShowGotoMarkTypeSet.Contains(markItem.MarkType))
			{
				return true;
			}
			DynamicEntityMarkItem dynamicEntityMarkItem = markItem as DynamicEntityMarkItem;
			if (dynamicEntityMarkItem != null)
			{
				MonsterDetection? monsterDetectionConfig = ConfigBase<MapConfig>.Instance.GetMonsterDetectionConfig(dynamicEntityMarkItem.MarkConfigId);
				if (monsterDetectionConfig != null)
				{
					EDangerType dangerType = (EDangerType)monsterDetectionConfig.Value.DangerType;
					if (MarkUiUtils.DangerFullOpenGoToMap.GetValueOrDefault(dangerType, false))
					{
						return true;
					}
				}
				TTrackTarget_Int ttrackTarget_Int = dynamicEntityMarkItem.TrackTarget as TTrackTarget_Int;
				return ttrackTarget_Int == null || !ModelBase<CreatureModel>.Instance.CheckEntityVisible(ttrackTarget_Int);
			}
			return WorldMapSecondaryUiDefine.MarkPanelTypeMap.GetValueOrDefault(markItem.MarkType, ESecondaryPanel.GeneralPanel) == ESecondaryPanel.GeneralPanel;
		}

		// Token: 0x060395CD RID: 234957 RVA: 0x00E8E984 File Offset: 0x00E8CB84
		[return: Nullable(2)]
		public static MarkItem FindNearbyValidGotoMark(BaseMap map, MarkItem markItem)
		{
			float searchRadius = (float)(ConfigCommonParamById.GetIntConfig("QuickTransferRange").GetValueOrDefault() * 100);
			int targetMultiMapId = markItem.GetMultiMapId();
			bool flag = targetMultiMapId != 0;
			List<ValueTuple<MarkItem, double>> list = map.FindNearbyMarkItems(markItem, searchRadius, delegate(MarkItem result)
			{
				MarkItemEntity markItemEntity2 = result.MarkItemEntity;
				if (markItemEntity2 == null || !markItemEntity2.GamePlay.InGravityLayer)
				{
					return false;
				}
				MarkItemEntity markItemEntity3 = result.MarkItemEntity;
				EMapGravityDirection? emapGravityDirection = (markItemEntity3 != null) ? new EMapGravityDirection?(markItemEntity3.GamePlay.Gravity) : null;
				MarkItemEntity markItemEntity4 = markItem.MarkItemEntity;
				EMapGravityDirection? emapGravityDirection2 = (markItemEntity4 != null) ? new EMapGravityDirection?(markItemEntity4.GamePlay.Gravity) : null;
				EMapGravityDirection? emapGravityDirection3 = emapGravityDirection2;
				EMapGravityDirection emapGravityDirection4 = EMapGravityDirection.All;
				if (emapGravityDirection3.GetValueOrDefault() == emapGravityDirection4 & emapGravityDirection3 != null)
				{
					return result != markItem;
				}
				if (result != markItem)
				{
					emapGravityDirection3 = emapGravityDirection;
					EMapGravityDirection? emapGravityDirection5 = emapGravityDirection2;
					return emapGravityDirection3.GetValueOrDefault() == emapGravityDirection5.GetValueOrDefault() & emapGravityDirection3 != null == (emapGravityDirection5 != null);
				}
				return false;
			});
			if (flag)
			{
				float num = (float)(ConfigCommonParamById.GetIntConfig("SameLayerQuickTransferRange").GetValueOrDefault() * 100);
				double sameLayerRangeSquared = (double)(num * num);
				list.Sort(delegate([Nullable(new byte[]
				{
					0,
					1
				})] ValueTuple<MarkItem, double> a, [Nullable(new byte[]
				{
					0,
					1
				})] ValueTuple<MarkItem, double> b)
				{
					int num2 = (a.Item2 <= sameLayerRangeSquared && a.Item1.GetMultiMapId() == targetMultiMapId) ? 0 : 1;
					int num3 = (b.Item2 <= sameLayerRangeSquared && b.Item1.GetMultiMapId() == targetMultiMapId) ? 0 : 1;
					if (num2 != num3)
					{
						return num2 - num3;
					}
					return a.Item2.CompareTo(b.Item2);
				});
			}
			foreach (ValueTuple<MarkItem, double> valueTuple in list)
			{
				MarkItem item = new ValueTuple<MarkItem, float>(valueTuple.Item1, (float)valueTuple.Item2).Item1;
				TeleportMarkItem teleportMarkItem = item as TeleportMarkItem;
				if (teleportMarkItem != null && !teleportMarkItem.IsLocked && teleportMarkItem.CanConditionShowView())
				{
					return teleportMarkItem;
				}
				TemporaryTeleportMarkItem temporaryTeleportMarkItem = item as TemporaryTeleportMarkItem;
				if (temporaryTeleportMarkItem != null)
				{
					return temporaryTeleportMarkItem;
				}
				if (item is FixedSceneGameplayMarkItem || item is SceneGameplayMarkItem)
				{
					ConfigMarkItem configMarkItem = (ConfigMarkItem)item;
					if (!configMarkItem.IsLocked && !configMarkItem.IsLordGym())
					{
						LevelPlayModel instance = ModelBase<LevelPlayModel>.Instance;
						ConfigMarkItem configMarkItem2 = configMarkItem;
						LevelPlayInfo levelPlayInfo = instance.GetLevelPlayInfo((configMarkItem2.MarkConfig != null) ? configMarkItem2.MarkConfig.GetValueOrDefault().RelativeId : 0);
						if (levelPlayInfo != null && !levelPlayInfo.IsClose && !ModelBase<MapModel>.Instance.IsLevelPlayOccupied(levelPlayInfo.Id).IsOccupied)
						{
							return item;
						}
					}
				}
				MarkItemEntity markItemEntity = item.MarkItemEntity;
				if (markItemEntity != null && markItemEntity.IsConfigMark)
				{
					ConfigMarkItem configMarkItem3 = item as ConfigMarkItem;
					bool flag2;
					if (configMarkItem3 == null)
					{
						flag2 = false;
					}
					else
					{
						ConfigMarkItem configMarkItem4 = configMarkItem3;
						flag2 = (((configMarkItem4.MarkConfig != null) ? new int?(configMarkItem4.MarkConfig.GetValueOrDefault().EnableQuickTransfer) : null).GetValueOrDefault() == 1);
					}
					if (flag2 && configMarkItem3 != null && !configMarkItem3.IsLocked && configMarkItem3.CanConditionShowView())
					{
						return configMarkItem3;
					}
				}
			}
			return null;
		}

		// Token: 0x060395CE RID: 234958 RVA: 0x00E8EBE4 File Offset: 0x00E8CDE4
		public static int? FindNearbyValidGotoMarkByPosition(BaseMap map, global::Vector position)
		{
			int? result = ConfigCommonParamById.GetIntConfig("QuickTransferRange");
			float searchRadius = (float)(result.GetValueOrDefault() * 100);
			List<ValueTuple<MarkItem, double>> list = map.FindNearbyMarkItemsByPosition(position, searchRadius, null);
			if (list == null)
			{
				result = null;
				return result;
			}
			foreach (ValueTuple<MarkItem, double> valueTuple in list)
			{
				MarkItem item = valueTuple.Item1;
				TeleportMarkItem teleportMarkItem = item as TeleportMarkItem;
				if (teleportMarkItem != null && !teleportMarkItem.IsLocked && teleportMarkItem.CanConditionShowView())
				{
					return new int?(teleportMarkItem.MarkConfigId);
				}
				if (item is FixedSceneGameplayMarkItem || item is SceneGameplayMarkItem)
				{
					ConfigMarkItem configMarkItem = (ConfigMarkItem)item;
					if (!configMarkItem.IsLocked && !configMarkItem.IsLordGym())
					{
						LevelPlayModel instance = ModelBase<LevelPlayModel>.Instance;
						ConfigMarkItem configMarkItem2 = configMarkItem;
						LevelPlayInfo levelPlayInfo = instance.GetLevelPlayInfo((configMarkItem2.MarkConfig != null) ? configMarkItem2.MarkConfig.GetValueOrDefault().RelativeId : 0);
						if (levelPlayInfo != null && !levelPlayInfo.IsClose && !ModelBase<MapModel>.Instance.IsLevelPlayOccupied(levelPlayInfo.Id).IsOccupied)
						{
							return new int?(item.MarkId);
						}
					}
				}
				MarkItemEntity markItemEntity = item.MarkItemEntity;
				if (markItemEntity != null && markItemEntity.IsConfigMark)
				{
					ConfigMarkItem configMarkItem3 = item as ConfigMarkItem;
					ConfigMarkItem configMarkItem4 = configMarkItem3;
					if (configMarkItem4.MarkConfig != null && configMarkItem4.MarkConfig.GetValueOrDefault().EnableQuickTransfer == 1 && !configMarkItem3.IsLocked && configMarkItem3.CanConditionShowView())
					{
						return new int?(configMarkItem3.MarkConfigId);
					}
				}
			}
			return null;
		}

		// Token: 0x060395CF RID: 234959 RVA: 0x00E8EDA4 File Offset: 0x00E8CFA4
		public static void QuickGotoTeleport(MarkItem markItem, MarkItem teleportMarkItem, [Nullable(2)] TOnTelSuccessCallBack successTelAction = null)
		{
			MarkUiUtils.<>c__DisplayClass5_0 CS$<>8__locals1 = new MarkUiUtils.<>c__DisplayClass5_0();
			CS$<>8__locals1.markItem = markItem;
			CS$<>8__locals1.teleportMarkItem = teleportMarkItem;
			CS$<>8__locals1.successTelAction = successTelAction;
			CS$<>8__locals1.playerLocation = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation();
			if (CS$<>8__locals1.playerLocation == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Map;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "[地图系统]MarkUiUtils->没有玩家坐标，快速前往失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("markId", CS$<>8__locals1.teleportMarkItem.MarkId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			bool flag = true;
			TeleportMarkItem teleportMarkItem2 = CS$<>8__locals1.teleportMarkItem as TeleportMarkItem;
			if (teleportMarkItem2 != null)
			{
				flag = !teleportMarkItem2.IsLocked;
			}
			if (flag)
			{
				if (ModelBase<WorldMapModel>.Instance.HideQuickTransferConfirmBox)
				{
					CS$<>8__locals1.<QuickGotoTeleport>g__DistanceCheckConfirmBoxFunc|3();
					return;
				}
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.QuickTranser);
				confirmBoxDataNew.HasToggle = true;
				confirmBoxDataNew.ToggleTextKey = "Text_FastTravelConfirmToggle_text";
				confirmBoxDataNew.SetToggleFunction(delegate(bool isSelectOn)
				{
					ModelBase<WorldMapModel>.Instance.HideQuickTransferConfirmBox = isSelectOn;
				});
				confirmBoxDataNew.FunctionMap[1] = new Action(MarkUiUtils.<QuickGotoTeleport>g__CloseFunction|5_5);
				confirmBoxDataNew.FunctionMap[2] = new Action(CS$<>8__locals1.<QuickGotoTeleport>g__DistanceCheckConfirmBoxFunc|3);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			}
		}

		// Token: 0x060395D0 RID: 234960 RVA: 0x00E8EED8 File Offset: 0x00E8D0D8
		public static bool IsDungeonBelongDiffMap(int srcDungeonId, int dstDungeonId)
		{
			InstanceDungeon? dungeonConfig = ConfigBase<WorldMapConfig>.Instance.GetDungeonConfig(srcDungeonId);
			InstanceDungeon? dungeonConfig2 = ConfigBase<WorldMapConfig>.Instance.GetDungeonConfig(dstDungeonId);
			int num = (dungeonConfig != null) ? dungeonConfig.GetValueOrDefault().MapConfigId : srcDungeonId;
			int num2 = (dungeonConfig2 != null) ? dungeonConfig2.GetValueOrDefault().MapConfigId : dstDungeonId;
			return num != num2;
		}

		// Token: 0x060395D1 RID: 234961 RVA: 0x00E8EF3A File Offset: 0x00E8D13A
		// Note: this type is marked as 'beforefieldinit'.
		static MarkUiUtils()
		{
			Dictionary<EDangerType, bool> dictionary = new Dictionary<EDangerType, bool>();
			dictionary[EDangerType.VeryLow] = true;
			dictionary[EDangerType.Low] = true;
			dictionary[EDangerType.Middle] = false;
			dictionary[EDangerType.High] = false;
			MarkUiUtils.DangerFullOpenGoToMap = dictionary;
			MarkUiUtils.ShowGotoMarkTypeSet = new HashSet<EMarkType>
			{
				EMarkType.CaveHole
			};
		}

		// Token: 0x060395D2 RID: 234962 RVA: 0x00E8EF79 File Offset: 0x00E8D179
		[CompilerGenerated]
		internal static void <QuickGotoTeleport>g__CloseFunction|5_5()
		{
			ModelBase<WorldMapModel>.Instance.HideQuickTransferConfirmBox = false;
		}

		// Token: 0x040209F2 RID: 133618
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EDangerType, bool> DangerFullOpenGoToMap;

		// Token: 0x040209F3 RID: 133619
		[StaticVariableRuleIgnore]
		private static readonly HashSet<EMarkType> ShowGotoMarkTypeSet;
	}
}
