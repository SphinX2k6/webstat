using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.AutoPilot;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.Common;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout
{
	// Token: 0x02004B63 RID: 19299
	[NullableContext(1)]
	[Nullable(0)]
	public static class WorldMapSecondaryUiLayoutHelper
	{
		// Token: 0x060326E3 RID: 206563 RVA: 0x00C9DE0C File Offset: 0x00C9C00C
		public static void UpdateAreaTxtByConfigMarkItem(WorldMapSecondaryUiContext context)
		{
			ConfigMarkItem configMarkItem = (ConfigMarkItem)context.MarkItem;
			string text = (configMarkItem != null) ? configMarkItem.GetAreaText() : null;
			if (!string.IsNullOrEmpty(text))
			{
				UUIText areaText = context.AreaText;
				if (areaText == null)
				{
					return;
				}
				areaText.SetText(text, true);
			}
		}

		// Token: 0x060326E4 RID: 206564 RVA: 0x00C9DE4C File Offset: 0x00C9C04C
		public static void UpdateAreaAndIconByConfigOrDynamicConfigMarkItem(WorldMapSecondaryUiContext context)
		{
			string text = null;
			ConfigMarkItem configMarkItem = context.MarkItem as ConfigMarkItem;
			if (configMarkItem != null)
			{
				text = configMarkItem.GetAreaText();
			}
			else
			{
				DynamicConfigMarkItem dynamicConfigMarkItem = context.MarkItem as DynamicConfigMarkItem;
				if (dynamicConfigMarkItem != null)
				{
					text = dynamicConfigMarkItem.GetAreaText();
				}
			}
			bool flag = text != null;
			UUIText areaText = context.AreaText;
			if (areaText != null)
			{
				areaText.SetUIActive(flag);
			}
			UUIItem areaIconItem = context.AreaIconItem;
			if (areaIconItem != null)
			{
				areaIconItem.SetUIActive(flag);
			}
			if (flag)
			{
				UUIText areaText2 = context.AreaText;
				if (areaText2 == null)
				{
					return;
				}
				areaText2.SetText(text, true);
			}
		}

		// Token: 0x060326E5 RID: 206565 RVA: 0x00C9DEC8 File Offset: 0x00C9C0C8
		public static void UpdateAreaTxtByServerMarkItem(WorldMapSecondaryUiContext context)
		{
			ServerMarkItem serverMarkItem = context.MarkItem as ServerMarkItem;
			string text = (serverMarkItem != null) ? serverMarkItem.GetAreaText() : null;
			if (!string.IsNullOrEmpty(text))
			{
				UUIText areaText = context.AreaText;
				if (areaText == null)
				{
					return;
				}
				areaText.SetText(text, true);
			}
		}

		// Token: 0x060326E6 RID: 206566 RVA: 0x00C9DF08 File Offset: 0x00C9C108
		public static void UpdateIconAndTitleByServerMarkItem(WorldMapSecondaryUiContext context)
		{
			ServerMarkItem serverMarkItem = (ServerMarkItem)context.MarkItem;
			WorldMapSecondaryUiLayoutHelper.UpdateIconByServerMarkItem(context);
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark((serverMarkItem != null) ? serverMarkItem.ConfigId : 0);
			UUIText title = context.Title;
			if (title == null)
			{
				return;
			}
			title.ShowTextNew(((configMark != null) ? configMark.GetValueOrDefault().MarkTitle : null) ?? "");
		}

		// Token: 0x060326E7 RID: 206567 RVA: 0x00C9DF74 File Offset: 0x00C9C174
		public static void UpdateIconAndTitle(WorldMapSecondaryUiContext context)
		{
			WorldMapSecondaryUiLayoutHelper.UpdateIcon(context);
			string key = "";
			ConfigMarkItem configMarkItem = context.MarkItem as ConfigMarkItem;
			if (configMarkItem != null)
			{
				key = configMarkItem.MarkConfig.Value.MarkTitle;
			}
			else
			{
				DynamicConfigMarkItem dynamicConfigMarkItem = context.MarkItem as DynamicConfigMarkItem;
				if (dynamicConfigMarkItem != null)
				{
					key = dynamicConfigMarkItem.MarkConfig.Value.MarkTitle;
				}
				else
				{
					TraceExploreEntityMarkItem traceExploreEntityMarkItem = context.MarkItem as TraceExploreEntityMarkItem;
					if (traceExploreEntityMarkItem != null)
					{
						key = traceExploreEntityMarkItem.MarkConfig.MarkTitle;
					}
				}
			}
			UUIText title = context.Title;
			if (title == null)
			{
				return;
			}
			title.ShowTextNew(key);
		}

		// Token: 0x060326E8 RID: 206568 RVA: 0x00C9E00C File Offset: 0x00C9C20C
		public static void SetTitleUseChangeColor(WorldMapSecondaryUiContext context, bool useChangeColor)
		{
			UUIText title = context.Title;
			if (title == null)
			{
				return;
			}
			UUIText title2 = context.Title;
			FColor? fcolor;
			FColor? fcolor2;
			if (title2 == null)
			{
				fcolor = null;
				fcolor2 = fcolor;
			}
			else
			{
				fcolor2 = new FColor?(title2.changeColor);
			}
			fcolor = fcolor2;
			title.SetChangeColor(useChangeColor, fcolor);
		}

		// Token: 0x060326E9 RID: 206569 RVA: 0x00C9E04C File Offset: 0x00C9C24C
		public static void UpdateIcon(WorldMapSecondaryUiContext context)
		{
			if (context.MarkItem != null && context.SetSpriteByPathAction != null)
			{
				context.SetSpriteByPathAction(context.MarkItem.IconPath, context.Icon, false, null, null);
			}
		}

		// Token: 0x060326EA RID: 206570 RVA: 0x00C9E090 File Offset: 0x00C9C290
		public static void UpdateIconByServerMarkItem(WorldMapSecondaryUiContext context)
		{
			ServerMarkItem serverMarkItem = context.MarkItem as ServerMarkItem;
			if (serverMarkItem != null && context.SetSpriteByPathAction != null)
			{
				context.SetSpriteByPathAction(serverMarkItem.IconPath, context.Icon, false, null, null);
			}
		}

		// Token: 0x060326EB RID: 206571 RVA: 0x00C9E0D8 File Offset: 0x00C9C2D8
		public static void UpdateDesc(WorldMapSecondaryUiContext context)
		{
			string key = "";
			ConfigMarkItem configMarkItem = context.MarkItem as ConfigMarkItem;
			if (configMarkItem != null)
			{
				ConfigMarkItem configMarkItem2 = configMarkItem;
				key = (((configMarkItem2.MarkConfig != null) ? configMarkItem2.MarkConfig.GetValueOrDefault().MarkDesc : null) ?? "");
			}
			else
			{
				DynamicConfigMarkItem dynamicConfigMarkItem = context.MarkItem as DynamicConfigMarkItem;
				if (dynamicConfigMarkItem != null)
				{
					DynamicConfigMarkItem dynamicConfigMarkItem2 = dynamicConfigMarkItem;
					key = (((dynamicConfigMarkItem2.MarkConfig != null) ? dynamicConfigMarkItem2.MarkConfig.GetValueOrDefault().MarkDesc : null) ?? "");
				}
				else
				{
					TraceExploreEntityMarkItem traceExploreEntityMarkItem = context.MarkItem as TraceExploreEntityMarkItem;
					if (traceExploreEntityMarkItem != null)
					{
						key = traceExploreEntityMarkItem.MarkConfig.MarkDesc;
					}
				}
			}
			UUIText descriptionText = context.DescriptionText;
			if (descriptionText == null)
			{
				return;
			}
			descriptionText.ShowTextNew(key);
		}

		// Token: 0x060326EC RID: 206572 RVA: 0x00C9E194 File Offset: 0x00C9C394
		public static void UpdateBoxDesc(WorldMapSecondaryUiContext context)
		{
			IBoxMark boxMark = context.MarkItem as IBoxMark;
			UUIText descriptionText = context.DescriptionText;
			if (descriptionText == null)
			{
				return;
			}
			descriptionText.ShowTextNew(((boxMark != null) ? boxMark.GetDescText() : null) ?? "");
		}

		// Token: 0x060326ED RID: 206573 RVA: 0x00C9E1D4 File Offset: 0x00C9C3D4
		public static void UpdateServerMarkDesc(WorldMapSecondaryUiContext context)
		{
			ServerMarkItem serverMarkItem = (ServerMarkItem)context.MarkItem;
			int markId = (serverMarkItem != null) ? serverMarkItem.ConfigId : 0;
			OneOf<MapMark, DynamicMapMark>? oneOf = ConfigBase<MapConfig>.Instance.SearchMarkConfig(markId);
			string key = "";
			if (oneOf.Value.IsT1)
			{
				key = oneOf.Value.AsT1.MarkDesc;
			}
			else if (oneOf.Value.IsT2)
			{
				key = oneOf.Value.AsT2.MarkDesc;
			}
			UUIText descriptionText = context.DescriptionText;
			if (descriptionText == null)
			{
				return;
			}
			descriptionText.ShowTextNew(key);
		}

		// Token: 0x060326EE RID: 206574 RVA: 0x00C9E274 File Offset: 0x00C9C474
		public static void UpdateConfirmButtonTextWithFastMoveStyle(WorldMapSecondaryUiContext context)
		{
			string textContentIdById = ConfigBase<TextConfig>.Instance.GetTextContentIdById("TeleportFastMove");
			context.SetConfirmBtnText(textContentIdById, Array.Empty<object>());
		}

		// Token: 0x060326EF RID: 206575 RVA: 0x00C9E29D File Offset: 0x00C9C49D
		public static void UpdateConfirmButtonTextWithStopDetectionStyle(WorldMapSecondaryUiContext context)
		{
			context.SetConfirmBtnText("Text_TeleportStop_Text", Array.Empty<object>());
		}

		// Token: 0x060326F0 RID: 206576 RVA: 0x00C9E2B0 File Offset: 0x00C9C4B0
		public static void UpdateConfirmButtonTextWithTrackStyle(WorldMapSecondaryUiContext context)
		{
			MarkItem markItem = context.MarkItem;
			string id;
			if (markItem != null && markItem.IsTracked)
			{
				id = "InstanceDungeonEntranceCancelTrack";
			}
			else
			{
				id = "InstanceDungeonEntranceTrack";
			}
			string textContentIdById = ConfigBase<TextConfig>.Instance.GetTextContentIdById(id);
			context.SetConfirmBtnText(textContentIdById, Array.Empty<object>());
		}

		// Token: 0x060326F1 RID: 206577 RVA: 0x00C9E300 File Offset: 0x00C9C500
		public static void UpdateConfirmButtonEnableClickByTeleportState(WorldMapSecondaryUiContext context)
		{
			MarkItem markItem = context.MarkItem;
			IMarkShowState markExtraShowState = ModelBase<MapModel>.Instance.GetMarkExtraShowState((markItem != null) ? markItem.MarkId : 0);
			bool flag = markExtraShowState != null && markExtraShowState.ShowFlag == MapMarkShowFlag.ShowDisable;
			context.SetConfirmBtnEnableClick(!flag);
		}

		// Token: 0x060326F2 RID: 206578 RVA: 0x00C9E344 File Offset: 0x00C9C544
		public static void UpdateTrackButtonTextWithTrackStyle(WorldMapSecondaryUiContext context)
		{
			MarkItem markItem = context.MarkItem;
			string textId;
			if (markItem != null && markItem.IsTracked)
			{
				textId = "InstanceDungeonEntranceCancelTrack";
			}
			else
			{
				textId = "InstanceDungeonEntranceTrack";
			}
			ButtonItem trackButtonItem = context.TrackButtonItem;
			if (trackButtonItem == null)
			{
				return;
			}
			trackButtonItem.SetLocalText(textId, Array.Empty<object>());
		}

		// Token: 0x060326F3 RID: 206579 RVA: 0x00C9E390 File Offset: 0x00C9C590
		public static void UpdateDownStateIcon(WorldMapSecondaryUiContext context)
		{
			MarkItem markItem = context.MarkItem;
			if (markItem == null)
			{
				return;
			}
			bool flag = markItem.MarkItemEntity.ViewLifeCircle.IsChildViewVisible(EMarkViewComponentType.ChildIcon, false);
			string childIconPath = markItem.MarkItemEntity.Resource.ChildIconPath;
			UUISprite downStateIcon = context.DownStateIcon;
			if (downStateIcon != null)
			{
				downStateIcon.SetUIActive(flag);
			}
			if (flag && context.SetSpriteByPathAction != null)
			{
				context.SetSpriteByPathAction(childIconPath, context.DownStateIcon, false, null, null);
			}
		}

		// Token: 0x060326F4 RID: 206580 RVA: 0x00C9E408 File Offset: 0x00C9C608
		public static void UpdateAutoPilotState(WorldMapSecondaryUiAutoPilotContext context)
		{
			MarkItem markItem = context.LayoutContext.MarkItem;
			if (markItem == null)
			{
				return;
			}
			int autoPilotAreaId = ControllerBase<AutoPilotController>.Instance.GetAutoPilotAreaId(markItem.WorldPosition, markItem.MapId);
			if (!WorldMapSecondaryUiLayoutHelper.UpdateAutoPilotTrackToggleActive(context, autoPilotAreaId))
			{
				return;
			}
			int autoPilotAreaId2 = ModelBase<AutoPilotModel>.Instance.AutoPilotAreaId;
			bool item = autoPilotAreaId2 != 0 && autoPilotAreaId2 == autoPilotAreaId;
			bool exploreSkillFlagEnable = ModelBase<ExploreSkillFlagModel>.Instance.GetExploreSkillFlagEnable(EExploreSkillType.MotorcycleCruise);
			bool item2 = ModelBase<AutoPilotModel>.Instance.CheckPlayerToTargetDistanceValid(markItem.WorldPosition);
			ValueTuple<bool, string>[] array = new ValueTuple<bool, string>[]
			{
				new ValueTuple<bool, string>(item, (autoPilotAreaId2 == 0) ? AutoPilotDefine.EAutoPilotTextId.TextAutoPilotActivated : AutoPilotDefine.EAutoPilotTextId.TextAutoPilotAreaIsolatedTips),
				new ValueTuple<bool, string>(exploreSkillFlagEnable, AutoPilotDefine.EAutoPilotTextId.TextAutoPilotForbidden),
				new ValueTuple<bool, string>(item2, AutoPilotDefine.EAutoPilotTextId.TextAutoPilotUnValidTooNearTips)
			};
			ValueTuple<bool, string>? valueTuple = null;
			foreach (ValueTuple<bool, string> valueTuple2 in array)
			{
				if (!valueTuple2.Item1)
				{
					valueTuple = new ValueTuple<bool, string>?(valueTuple2);
					break;
				}
			}
			bool isInteractive = valueTuple == null;
			if (valueTuple != null)
			{
				MapTipsActivateTipPanel mapTipsActivateTipPanel = context.LayoutContext.MapTipsActivateTipPanel;
				if (mapTipsActivateTipPanel != null)
				{
					mapTipsActivateTipPanel.SetUiActive(true);
				}
				MapTipsActivateTipPanel mapTipsActivateTipPanel2 = context.LayoutContext.MapTipsActivateTipPanel;
				if (mapTipsActivateTipPanel2 != null)
				{
					mapTipsActivateTipPanel2.SetActivatedTip(valueTuple.Value.Item2, new bool?(false));
				}
			}
			context.UpdateAutoPilotNavBtn(markItem.IsAutoPilotTracked, isInteractive);
			context.SetDownStateBtnRootActive(!markItem.IsAutoPilotTracked);
			context.RefreshAutoPilotTrackBtnGroup(markItem.IsAutoPilotTracked);
		}

		// Token: 0x060326F5 RID: 206581 RVA: 0x00C9E580 File Offset: 0x00C9C780
		private static bool UpdateAutoPilotTrackToggleActive(WorldMapSecondaryUiAutoPilotContext context, int autoPilotAreaId)
		{
			bool flag = WorldMapSecondaryUiLayoutHelper.CheckAutoPilotTrackToggleCanShow(context, autoPilotAreaId);
			context.SetAutoPilotNavBtnActive(flag);
			return flag;
		}

		// Token: 0x060326F6 RID: 206582 RVA: 0x00C9E5A0 File Offset: 0x00C9C7A0
		private static bool CheckAutoPilotTrackToggleCanShow(WorldMapSecondaryUiAutoPilotContext context, int autoPilotAreaId)
		{
			if (!ModelBase<WorldMapModel>.Instance.IsCanAutoPilotTrack)
			{
				return false;
			}
			if (context.LayoutContext.GetIsConfirmBtnActive() || !context.LayoutContext.TrackButtonItem.IsUiActiveInHierarchy())
			{
				return false;
			}
			if (autoPilotAreaId == 0)
			{
				return false;
			}
			MarkItem markItem = context.LayoutContext.MarkItem;
			int instanceId = markItem.InstanceDungeonId.GetValueOrDefault();
			return instanceId == 0 || (ConfigBase<MapConfig>.Instance.GetMapRoadWaysByMapId(markItem.MapId) ?? Array.Empty<MapRoadWays>()).Any((MapRoadWays item) => (item.GetShowDungeonListArray() ?? Array.Empty<int>()).Contains(instanceId));
		}
	}
}
