using System;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Mark.Misc;
using CSharpScript.Game.Module.Map.Marks;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Misc;
using CSharpScript.Game.Module.Map.View.BaseMap;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.Map.Mark.Debug
{
	// Token: 0x02005826 RID: 22566
	[NullableContext(1)]
	[Nullable(0)]
	public static class MapDebugger
	{
		// Token: 0x060395D3 RID: 234963 RVA: 0x00E8EF88 File Offset: 0x00E8D188
		private static string DumpMarkItem(BaseMap map, MarkItem markItem)
		{
			MarkEntityComponent component = markItem.MarkItemEntity.GetComponent<MarkEntityComponent>(EMapComponent.MarkEntity);
			int valueOrDefault = ((component != null) ? component.EntityId : null).GetValueOrDefault();
			MarkItem markItem2 = MarkUiUtils.FindNearbyValidGotoMark(map, markItem);
			MarkItemEntity markItemEntity = markItem.MarkItemEntity;
			MarkConfigComponent markConfigComponent = (markItemEntity != null) ? markItemEntity.GetComponent<MarkConfigComponent>(EMapComponent.MarkConfig) : null;
			MarkItemEntity markItemEntity2 = markItem.MarkItemEntity;
			bool? flag;
			if (markItemEntity2 == null)
			{
				flag = null;
			}
			else
			{
				MarkGamePlayComponent gamePlay = markItemEntity2.GamePlay;
				flag = ((gamePlay != null) ? new bool?(gamePlay.IsHide) : null);
			}
			bool? flag2 = flag;
			bool valueOrDefault2 = flag2.GetValueOrDefault();
			string text = string.Empty;
			if (valueOrDefault2)
			{
				MarkItemEntity markItemEntity3 = markItem.MarkItemEntity;
				MarkCommonGamePlayStateComponent markCommonGamePlayStateComponent = (markItemEntity3 != null) ? markItemEntity3.GetComponent<MarkCommonGamePlayStateComponent>(EMapComponent.MarkCommonGamePlayState) : null;
				int? num = (markCommonGamePlayStateComponent != null) ? markCommonGamePlayStateComponent.GetRelativeDungeonId() : null;
				int? num2 = (markCommonGamePlayStateComponent != null) ? markCommonGamePlayStateComponent.GetRelativeId() : null;
				if (markCommonGamePlayStateComponent != null && num != null && num2 != null)
				{
					text = ModelBase<LevelPlayReportModel>.Instance.GetLevelPlayHideReason(num.Value, num2.Value);
				}
				else
				{
					MarkItemEntity markItemEntity4 = markItem.MarkItemEntity;
					int? num3;
					if (markItemEntity4 == null)
					{
						num3 = null;
					}
					else
					{
						MarkEntityComponent component2 = markItemEntity4.GetComponent<MarkEntityComponent>(EMapComponent.MarkEntity);
						num3 = ((component2 != null) ? component2.EntityId : null);
					}
					int? num4 = num3;
					int valueOrDefault3 = num4.GetValueOrDefault();
					text = ModelBase<MapModel>.Instance.GetMarkHideReason(markItem.MapId, valueOrDefault3);
				}
				if (string.IsNullOrEmpty(text))
				{
					text = "PlayPointClearDesc_Text";
				}
			}
			LevelEntityConfig? levelEntityConfig;
			int value = (valueOrDefault != 0) ? ((ConfigBase<MapConfig>.Instance.GetEntityConfigByMapIdAndEntityId(markItem.MapId, valueOrDefault) != null) ? levelEntityConfig.GetValueOrDefault().AreaId : 0) : 0;
			string value2 = (valueOrDefault != 0) ? ModelBase<MapModel>.Instance.GetMarkAreaText(markItem.MapId, valueOrDefault) : string.Empty;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("------------------------标记信息Start--------------------");
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("标记Id:");
			appendInterpolatedStringHandler.AppendFormatted<int>(markItem.MarkId);
			stringBuilder3.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder4 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("标记类型Type:");
			appendInterpolatedStringHandler.AppendFormatted<EMarkType>(markItem.MarkType);
			stringBuilder4.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder5 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("地图类型Type:");
			appendInterpolatedStringHandler.AppendFormatted<EMapType>(markItem.MapType);
			stringBuilder5.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder6 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("地图Id:");
			appendInterpolatedStringHandler.AppendFormatted<int>(markItem.MapId);
			stringBuilder6.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder7 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("副本Id:");
			appendInterpolatedStringHandler.AppendFormatted<int?>(markItem.InstanceDungeonId);
			stringBuilder7.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder8 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(14, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("追踪区域Id(不一定有值):");
			appendInterpolatedStringHandler.AppendFormatted<int?>(markItem.TrackAreaId);
			stringBuilder8.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder9 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(12, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("归属迷雾FogHide:");
			appendInterpolatedStringHandler.AppendFormatted<int?>((markConfigComponent != null) ? markConfigComponent.FogHide : null);
			stringBuilder9.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder10 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("区域Id:");
			appendInterpolatedStringHandler.AppendFormatted<int>(value);
			stringBuilder10.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder11 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("区域名字:");
			appendInterpolatedStringHandler.AppendFormatted(value2);
			stringBuilder11.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder12 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("分层地图Id:");
			appendInterpolatedStringHandler.AppendFormatted<int>(markItem.GetMultiMapId());
			stringBuilder12.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder13 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("是否分层标记:");
			appendInterpolatedStringHandler.AppendFormatted<bool>(markItem.IsMultiMap());
			stringBuilder13.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder14 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("世界坐标X:");
			appendInterpolatedStringHandler.AppendFormatted<double>(markItem.WorldPosition.X);
			appendInterpolatedStringHandler.AppendLiteral(",");
			stringBuilder14.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder15 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("世界坐标Y:");
			appendInterpolatedStringHandler.AppendFormatted<double>(markItem.WorldPosition.Y);
			appendInterpolatedStringHandler.AppendLiteral(",");
			stringBuilder15.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder16 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(6, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("世界坐标Z:");
			appendInterpolatedStringHandler.AppendFormatted<double>(markItem.WorldPosition.Z);
			stringBuilder16.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder17 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("Ui坐标X:");
			appendInterpolatedStringHandler.AppendFormatted<double>(markItem.UiPosition.X);
			appendInterpolatedStringHandler.AppendLiteral(",");
			stringBuilder17.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder18 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("Ui坐标Y:");
			appendInterpolatedStringHandler.AppendFormatted<double>(markItem.UiPosition.Y);
			appendInterpolatedStringHandler.AppendLiteral(",");
			stringBuilder18.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder19 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(6, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("Ui坐标Z:");
			appendInterpolatedStringHandler.AppendFormatted<double>(markItem.UiPosition.Z);
			stringBuilder19.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder20 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("重力方向:");
			MarkItemEntity markItemEntity5 = markItem.MarkItemEntity;
			EMapGravityDirection? value3;
			if (markItemEntity5 == null)
			{
				value3 = null;
			}
			else
			{
				MarkGamePlayComponent gamePlay2 = markItemEntity5.GamePlay;
				value3 = ((gamePlay2 != null) ? new EMapGravityDirection?(gamePlay2.Gravity) : null);
			}
			appendInterpolatedStringHandler.AppendFormatted<EMapGravityDirection?>(value3);
			stringBuilder20.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder21 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("是否在对应的重力面:");
			MarkItemEntity markItemEntity6 = markItem.MarkItemEntity;
			bool? value4;
			if (markItemEntity6 == null)
			{
				value4 = null;
			}
			else
			{
				MarkGamePlayComponent gamePlay3 = markItemEntity6.GamePlay;
				value4 = ((gamePlay3 != null) ? new bool?(gamePlay3.InGravityLayer) : null);
			}
			appendInterpolatedStringHandler.AppendFormatted<bool?>(value4);
			stringBuilder21.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder22 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("配置Id:");
			appendInterpolatedStringHandler.AppendFormatted<int?>((markConfigComponent != null) ? markConfigComponent.MarkId : null);
			stringBuilder22.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder23 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("玩法Id:");
			appendInterpolatedStringHandler.AppendFormatted<int?>((markConfigComponent != null) ? markConfigComponent.RelativeId : null);
			stringBuilder23.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder24 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("玩法绑定的副本Id:");
			appendInterpolatedStringHandler.AppendFormatted<int?>((markConfigComponent != null) ? markConfigComponent.RelativeDungeonId : null);
			stringBuilder24.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder25 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("绑定的实体Id:");
			appendInterpolatedStringHandler.AppendFormatted<int>(valueOrDefault);
			stringBuilder25.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder26 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("绑定的二级弹窗类型:");
			appendInterpolatedStringHandler.AppendFormatted(Enum.GetName(typeof(ESecondaryPanel), markItem.GetSecondaryUiType()));
			stringBuilder26.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder27 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("玩法是否被清场:");
			appendInterpolatedStringHandler.AppendFormatted<bool>(valueOrDefault2);
			stringBuilder27.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder28 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("清场原因:");
			appendInterpolatedStringHandler.AppendFormatted(valueOrDefault2 ? ConfigBase<TextConfig>.Instance.GetMultiText(text, Array.Empty<string>()) : string.Empty);
			stringBuilder28.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder29 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("传送点被锁或被禁用:");
			MarkItemEntity markItemEntity7 = markItem.MarkItemEntity;
			bool? value5;
			if (markItemEntity7 == null)
			{
				value5 = null;
			}
			else
			{
				MarkGamePlayComponent gamePlay4 = markItemEntity7.GamePlay;
				value5 = ((gamePlay4 != null) ? new bool?(gamePlay4.IsTeleportLocked) : null);
			}
			appendInterpolatedStringHandler.AppendFormatted<bool?>(value5);
			stringBuilder29.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder30 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("玩法状态:");
			MarkItemEntity markItemEntity8 = markItem.MarkItemEntity;
			EMarkGamePlayState? value6;
			if (markItemEntity8 == null)
			{
				value6 = null;
			}
			else
			{
				MarkGamePlayComponent gamePlay5 = markItemEntity8.GamePlay;
				value6 = ((gamePlay5 != null) ? new EMarkGamePlayState?(gamePlay5.GamePlayState) : null);
			}
			appendInterpolatedStringHandler.AppendFormatted<EMarkGamePlayState?>(value6);
			stringBuilder30.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder31 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(18, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("附近可前往的标记信息-MarkId:");
			appendInterpolatedStringHandler.AppendFormatted<int?>((markItem2 != null) ? new int?(markItem2.MarkId) : null);
			stringBuilder31.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder.AppendLine("------------------------标记信息End------------------");
			return stringBuilder.ToString();
		}

		// Token: 0x060395D4 RID: 234964 RVA: 0x00E8F87C File Offset: 0x00E8DA7C
		public static string DumpMarkItemForUi(BaseMap map, MarkItem markItem)
		{
			MarkItemEntity markItemEntity = markItem.MarkItemEntity;
			int? num;
			if (markItemEntity == null)
			{
				num = null;
			}
			else
			{
				MarkEntityComponent component = markItemEntity.GetComponent<MarkEntityComponent>(EMapComponent.MarkEntity);
				num = ((component != null) ? component.EntityId : null);
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault();
			MarkItem markItem2 = MarkUiUtils.FindNearbyValidGotoMark(map, markItem);
			MarkItemEntity markItemEntity2 = markItem.MarkItemEntity;
			MarkConfigComponent markConfigComponent = (markItemEntity2 != null) ? markItemEntity2.GetComponent<MarkConfigComponent>(EMapComponent.MarkConfig) : null;
			LevelEntityConfig? levelEntityConfig;
			int value = (valueOrDefault != 0) ? ((ConfigBase<MapConfig>.Instance.GetEntityConfigByMapIdAndEntityId(markItem.MapId, valueOrDefault) != null) ? levelEntityConfig.GetValueOrDefault().AreaId : 0) : 0;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("---简单标记信息Start---");
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(20, 4, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("\n标记Id:");
			appendInterpolatedStringHandler.AppendFormatted<int>(markItem.MarkId);
			appendInterpolatedStringHandler.AppendLiteral("类型:");
			appendInterpolatedStringHandler.AppendFormatted<EMarkType>(markItem.MarkType);
			appendInterpolatedStringHandler.AppendLiteral("地图Id:");
			appendInterpolatedStringHandler.AppendFormatted<int>(markItem.MapId);
			appendInterpolatedStringHandler.AppendLiteral(" 副本Id:");
			appendInterpolatedStringHandler.AppendFormatted<int?>(markItem.InstanceDungeonId);
			stringBuilder3.Append(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder4 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(26, 4, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("\n追踪区域:");
			appendInterpolatedStringHandler.AppendFormatted<int?>(markItem.TrackAreaId);
			appendInterpolatedStringHandler.AppendLiteral("迷雾FogHide:");
			appendInterpolatedStringHandler.AppendFormatted<int?>((markConfigComponent != null) ? markConfigComponent.FogHide : null);
			appendInterpolatedStringHandler.AppendLiteral("区域:");
			appendInterpolatedStringHandler.AppendFormatted<int>(value);
			appendInterpolatedStringHandler.AppendLiteral("分层地图Id:");
			appendInterpolatedStringHandler.AppendFormatted<int>(markItem.GetMultiMapId());
			stringBuilder4.Append(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder5 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(21, 3, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("\n世界坐标X:");
			appendInterpolatedStringHandler.AppendFormatted<double>(markItem.WorldPosition.X, "F2");
			appendInterpolatedStringHandler.AppendLiteral(",世界坐标Y:");
			appendInterpolatedStringHandler.AppendFormatted<double>(markItem.WorldPosition.Y, "F2");
			appendInterpolatedStringHandler.AppendLiteral(",世界坐标Z:");
			appendInterpolatedStringHandler.AppendFormatted<double>(markItem.WorldPosition.Z, "F2");
			stringBuilder5.Append(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder6 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(21, 3, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("\nUi坐标X:");
			appendInterpolatedStringHandler.AppendFormatted<double>(markItem.UiPosition.X, "F2");
			appendInterpolatedStringHandler.AppendLiteral(",Ui坐标Y:");
			appendInterpolatedStringHandler.AppendFormatted<double>(markItem.UiPosition.Y, "F2");
			appendInterpolatedStringHandler.AppendLiteral(",Ui坐标Z:");
			appendInterpolatedStringHandler.AppendFormatted<double>(markItem.UiPosition.Z, "F2");
			stringBuilder6.Append(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder7 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(29, 4, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("\n重力方向:");
			MarkItemEntity markItemEntity3 = markItem.MarkItemEntity;
			EMapGravityDirection? value2;
			if (markItemEntity3 == null)
			{
				value2 = null;
			}
			else
			{
				MarkGamePlayComponent gamePlay = markItemEntity3.GamePlay;
				value2 = ((gamePlay != null) ? new EMapGravityDirection?(gamePlay.Gravity) : null);
			}
			appendInterpolatedStringHandler.AppendFormatted<EMapGravityDirection?>(value2);
			appendInterpolatedStringHandler.AppendLiteral(" 配置Id:");
			appendInterpolatedStringHandler.AppendFormatted<int?>((markConfigComponent != null) ? markConfigComponent.MarkId : null);
			appendInterpolatedStringHandler.AppendLiteral(" 玩法Id:");
			appendInterpolatedStringHandler.AppendFormatted<int?>((markConfigComponent != null) ? markConfigComponent.RelativeId : null);
			appendInterpolatedStringHandler.AppendLiteral(" 玩法绑定的副本Id:");
			appendInterpolatedStringHandler.AppendFormatted<int?>((markConfigComponent != null) ? markConfigComponent.RelativeDungeonId : null);
			stringBuilder7.Append(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder8 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(20, 2, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("\n绑定的实体Id:");
			appendInterpolatedStringHandler.AppendFormatted<int>(valueOrDefault);
			appendInterpolatedStringHandler.AppendLiteral(" 绑定的二级弹窗类型:");
			appendInterpolatedStringHandler.AppendFormatted<ESecondaryPanel>(markItem.GetSecondaryUiType());
			stringBuilder8.Append(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder9 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(18, 2, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("\n玩法被清场:");
			MarkItemEntity markItemEntity4 = markItem.MarkItemEntity;
			bool? value3;
			if (markItemEntity4 == null)
			{
				value3 = null;
			}
			else
			{
				MarkGamePlayComponent gamePlay2 = markItemEntity4.GamePlay;
				value3 = ((gamePlay2 != null) ? new bool?(gamePlay2.IsHide) : null);
			}
			appendInterpolatedStringHandler.AppendFormatted<bool?>(value3);
			appendInterpolatedStringHandler.AppendLiteral(" 传送点被锁或被禁用:");
			MarkItemEntity markItemEntity5 = markItem.MarkItemEntity;
			bool? value4;
			if (markItemEntity5 == null)
			{
				value4 = null;
			}
			else
			{
				MarkGamePlayComponent gamePlay3 = markItemEntity5.GamePlay;
				value4 = ((gamePlay3 != null) ? new bool?(gamePlay3.IsTeleportLocked) : null);
			}
			appendInterpolatedStringHandler.AppendFormatted<bool?>(value4);
			stringBuilder9.Append(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder10 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(25, 2, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("\n玩法状态:");
			MarkItemEntity markItemEntity6 = markItem.MarkItemEntity;
			EMarkGamePlayState? value5;
			if (markItemEntity6 == null)
			{
				value5 = null;
			}
			else
			{
				MarkGamePlayComponent gamePlay4 = markItemEntity6.GamePlay;
				value5 = ((gamePlay4 != null) ? new EMarkGamePlayState?(gamePlay4.GamePlayState) : null);
			}
			appendInterpolatedStringHandler.AppendFormatted<EMarkGamePlayState?>(value5);
			appendInterpolatedStringHandler.AppendLiteral(" 附近可前往的标记信息-MarkId:");
			appendInterpolatedStringHandler.AppendFormatted<int?>((markItem2 != null) ? new int?(markItem2.MarkId) : null);
			stringBuilder10.Append(ref appendInterpolatedStringHandler);
			stringBuilder.Append("\n---标记信息End---");
			return stringBuilder.ToString();
		}

		// Token: 0x060395D5 RID: 234965 RVA: 0x00E8FD98 File Offset: 0x00E8DF98
		public static void PrintMarkItemDumpInfo(BaseMap map, MarkItem markItem)
		{
			ELogAuthor author = ELogAuthor.LRX;
			string message = "地图调试信息->当前标记ItemDump信息";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标记信息", MapDebugger.DumpMarkItem(map, markItem));
			MapLogger.Debug(author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x060395D6 RID: 234966 RVA: 0x00E8FDCC File Offset: 0x00E8DFCC
		public static void PrintTrackDataInfo(string title, ITrackData data)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("------------------------追踪信息Start--------------------");
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(12, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("TrackSource:");
			appendInterpolatedStringHandler.AppendFormatted<ETrackSource>(data.TrackSource);
			stringBuilder3.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder4 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("MarkType:");
			appendInterpolatedStringHandler.AppendFormatted<EMarkType?>(data.MarkType);
			stringBuilder4.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder5 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("TrackId:");
			appendInterpolatedStringHandler.AppendFormatted<int>(data.Id);
			stringBuilder5.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder6 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("IconPath:");
			appendInterpolatedStringHandler.AppendFormatted(data.IconPath);
			stringBuilder6.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder7 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(12, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("TrackTarget:");
			appendInterpolatedStringHandler.AppendFormatted<TTrackTarget>(data.TrackTarget);
			stringBuilder7.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder8 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(16, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("TrackInstanceId:");
			appendInterpolatedStringHandler.AppendFormatted<int?>(data.TrackInstanceId);
			stringBuilder8.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder9 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(24, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("TrackAutoCancelDistance:");
			appendInterpolatedStringHandler.AppendFormatted<float?>(data.TrackAutoCancelDistance);
			stringBuilder9.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder10 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("IsSubTrack:");
			appendInterpolatedStringHandler.AppendFormatted<bool?>(data.IsSubTrack);
			stringBuilder10.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder11 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("TrackHideDis:");
			appendInterpolatedStringHandler.AppendFormatted<float?>(data.TrackHideDis);
			stringBuilder11.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder12 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(12, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("ShowGroupId:");
			appendInterpolatedStringHandler.AppendFormatted<int?>(data.ShowGroupId);
			stringBuilder12.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder13 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("TrackType:");
			appendInterpolatedStringHandler.AppendFormatted<ETrackType?>(data.TrackType);
			stringBuilder13.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder14 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(14, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("AutoHideTrack:");
			appendInterpolatedStringHandler.AppendFormatted<bool?>(data.AutoHideTrack);
			stringBuilder14.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder15 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("PrefabPath:");
			appendInterpolatedStringHandler.AppendFormatted(data.PrefabPath);
			stringBuilder15.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder16 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("Offset:");
			appendInterpolatedStringHandler.AppendFormatted<global::Vector>(data.Offset);
			stringBuilder16.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder17 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(15, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("IsInTrackRange:");
			appendInterpolatedStringHandler.AppendFormatted<bool?>(data.IsInTrackRange);
			stringBuilder17.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder18 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("AreaId:");
			appendInterpolatedStringHandler.AppendFormatted<int?>(data.AreaId);
			stringBuilder18.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder19 = stringBuilder2;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("MultiMapId:");
			appendInterpolatedStringHandler.AppendFormatted<int?>(data.MultiMapId);
			stringBuilder19.AppendLine(ref appendInterpolatedStringHandler);
			stringBuilder.AppendLine("------------------------追踪信息End------------------");
			string item = stringBuilder.ToString();
			ELogAuthor author = ELogAuthor.LRX;
			string message = "地图调试信息->" + title;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("追踪信息", item);
			MapLogger.Warn(author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}
}
