using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Controller;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Mark.Misc;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Misc;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Module.WorldMap.SubViews.Common;
using CSharpScript.Game.Module.WorldMap.ViewComponent;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout
{
	// Token: 0x02004B61 RID: 19297
	[NullableContext(2)]
	[Nullable(0)]
	public class WorldMapSecondaryUiLayoutA : WorldMapSecondaryUi
	{
		// Token: 0x060326A9 RID: 206505 RVA: 0x00C9CD50 File Offset: 0x00C9AF50
		protected unsafe override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = WorldMapDefine.SecondaryUiPanelComponentsRegisterInfoA;
			int num = 3;
			List<ValueTuple<int, Delegate>> list = new List<ValueTuple<int, Delegate>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list, num);
			Span<ValueTuple<int, Delegate>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Delegate>(15, new Action(this.OnDetailBtnClick));
			num2++;
			*span[num2] = new ValueTuple<int, Delegate>(18, new Action(this.OnStripBtnClick));
			num2++;
			*span[num2] = new ValueTuple<int, Delegate>(39, new Action(this.OnDelBtnClick));
			this.BtnBindInfo = list;
		}

		// Token: 0x060326AA RID: 206506 RVA: 0x00C9CDF4 File Offset: 0x00C9AFF4
		protected override UniTask OnBeforeStartAsync()
		{
			WorldMapSecondaryUiLayoutA.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WorldMapSecondaryUiLayoutA.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060326AB RID: 206507 RVA: 0x00C9CE37 File Offset: 0x00C9B037
		protected override void OnStart()
		{
			this.RootItem.SetRaycastTarget(false);
			this.UpdateTopRightIconHandle = new Action(this.UpdateTopRightIconActive);
			Singleton<EventSystem>.Instance.Add(EEventName.OnMarkTopRightIconUpdate, this.UpdateTopRightIconHandle);
		}

		// Token: 0x060326AC RID: 206508 RVA: 0x00C9CE70 File Offset: 0x00C9B070
		private void InitContext()
		{
			this.LayoutContext = new WorldMapSecondaryUiContext();
			this.LayoutContext.SetSpriteByPathAction = new TSetSpriteByPathAction(this.SetSpriteByPath);
			this.LayoutContext.Icon = base.GetSprite(0);
			this.LayoutContext.Title = base.GetText(1);
			this.LayoutContext.AreaText = base.GetText(3);
			this.LayoutContext.AreaIconItem = base.GetItem(22);
			this.LayoutContext.DescriptionText = base.GetText(4);
			if (this.ConfirmButton != null)
			{
				this.LayoutContext.SetConfirmBtnItem(this.ConfirmButton);
			}
			this.LayoutContext.TrackButtonItem = this.TrackBtn;
			this.LayoutContext.DownStateIcon = base.GetSprite(23);
			this.LayoutContext.PanelProgressItem = base.GetItem(14);
			this.LayoutContext.PanelListLayout = base.GetVerticalLayout(5);
			this.LayoutContext.DelButton = base.GetButton(39);
			this.LayoutContext.MapTipsActivateTipPanel = this.MapTipsActivateTipPanel;
			this.AutoPilotContext = new WorldMapSecondaryUiAutoPilotContext(this.LayoutContext);
			this.AutoPilotContext.SetCloseSecondaryUiFunction(new Action(base.Close));
			this.AutoPilotContext.SetDownStateBtnRoot(base.GetItem(27));
			this.AutoPilotContext.SetUiParent(base.GetItem(47));
			this.AutoPilotContext.RefreshPanelCallback = new Action<MarkItem>(this.RefreshPanel);
		}

		// Token: 0x060326AD RID: 206509 RVA: 0x00C9CFE8 File Offset: 0x00C9B1E8
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMarkTopRightIconUpdate, this.UpdateTopRightIconHandle);
			ButtonItem confirmButton = this.ConfirmButton;
			if (confirmButton != null)
			{
				confirmButton.Destroy(null);
			}
			ButtonItem trackBtn = this.TrackBtn;
			if (trackBtn != null)
			{
				trackBtn.Destroy(null);
			}
			ButtonItem gotoBtn = this.GotoBtn;
			if (gotoBtn != null)
			{
				gotoBtn.Destroy(null);
			}
			MapTipsActivateTipPanel mapTipsActivateTipPanel = this.MapTipsActivateTipPanel;
			if (mapTipsActivateTipPanel != null)
			{
				mapTipsActivateTipPanel.Destroy(null);
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x060326AE RID: 206510 RVA: 0x00C9D05C File Offset: 0x00C9B25C
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.GetItem(14).SetUIActive(true);
			base.GetItem(26).SetUIActive(false);
			base.GetVerticalLayout(5).RootUIComp.Get().SetUIActive(true);
			base.GetItem(25).SetUIActive(false);
			base.GetItem(9).SetUIActive(false);
			base.GetItem(12).SetUIActive(false);
			base.GetItem(8).SetUIActive(false);
			base.GetVerticalLayout(16).RootUIComp.Get().SetUIActive(false);
			base.GetSprite(24).SetUIActive(false);
			MapTipsActivateTipPanel mapTipsActivateTipPanel = this.MapTipsActivateTipPanel;
			if (mapTipsActivateTipPanel != null)
			{
				mapTipsActivateTipPanel.SetUiActive(false);
			}
			base.GetButton(39).RootUIComp.Get().SetUIActive(false);
			base.GetVerticalLayout(40).RootUIComp.Get().SetUIActive(false);
			WorldMapSecondaryUiAutoPilotContext autoPilotContext = this.AutoPilotContext;
			if (autoPilotContext != null)
			{
				autoPilotContext.SetMap(this.Map);
			}
			WorldMapSecondaryUiAutoPilotContext autoPilotContext2 = this.AutoPilotContext;
			if (autoPilotContext2 != null)
			{
				autoPilotContext2.SetDownStateBtnRootActive(true);
			}
			WorldMapSecondaryUiAutoPilotContext autoPilotContext3 = this.AutoPilotContext;
			if (autoPilotContext3 != null)
			{
				autoPilotContext3.SetAutoPilotNavBtnActive(false);
			}
			WorldMapSecondaryUiAutoPilotContext autoPilotContext4 = this.AutoPilotContext;
			if (autoPilotContext4 == null)
			{
				return;
			}
			autoPilotContext4.RefreshAutoPilotTrackBtnGroup(false);
		}

		// Token: 0x060326AF RID: 206511 RVA: 0x00C9D194 File Offset: 0x00C9B394
		protected bool UpdateQuickGoto()
		{
			bool flag = MarkUiUtils.IsShowGoto(this.LayoutContext.MarkItem);
			this.UpdateQuickGotoActive(flag);
			return flag;
		}

		// Token: 0x060326B0 RID: 206512 RVA: 0x00C9D1BC File Offset: 0x00C9B3BC
		protected void UpdateQuickGotoActive(bool showGoto)
		{
			MarkItem markItem = this.LayoutContext.MarkItem;
			base.GetItem(32).SetUIActive(showGoto);
			if (!showGoto)
			{
				this.UpdateHidePlayMapTipPanel();
				return;
			}
			UUISelectableComponent button = base.GetButton(29);
			bool allowTeleportByUi = ModelBase<TeleportModel>.Instance.AllowTeleportByUi;
			bool flag = MarkUiUtils.FindNearbyValidGotoMark(this.Map, markItem) != null || this.IsFastReturnAvailable();
			button.SetSelfInteractive(allowTeleportByUi && flag);
			bool isHide = markItem.MarkItemEntity.GamePlay.IsHide;
			MapTipsActivateTipPanel mapTipsActivateTipPanel = this.MapTipsActivateTipPanel;
			if (mapTipsActivateTipPanel != null)
			{
				mapTipsActivateTipPanel.SetUiActive((!allowTeleportByUi || !flag || isHide) && !HonamiStoryUtil.CheckInHonamiStoryDungeon());
			}
			if (isHide)
			{
				this.UpdateHidePlayMapTipPanel();
				return;
			}
			MapTipsActivateTipPanel mapTipsActivateTipPanel2 = this.MapTipsActivateTipPanel;
			if (mapTipsActivateTipPanel2 == null)
			{
				return;
			}
			mapTipsActivateTipPanel2.SetDistanceTips();
		}

		// Token: 0x060326B1 RID: 206513 RVA: 0x00C9D278 File Offset: 0x00C9B478
		protected virtual bool IsFastReturnAvailable()
		{
			return false;
		}

		// Token: 0x060326B2 RID: 206514 RVA: 0x00C9D27C File Offset: 0x00C9B47C
		protected void UpdateHidePlayMapTipPanel()
		{
			MarkItem markItem = this.LayoutContext.MarkItem;
			bool isHide = markItem.MarkItemEntity.GamePlay.IsHide;
			MapTipsActivateTipPanel mapTipsActivateTipPanel = this.MapTipsActivateTipPanel;
			if (mapTipsActivateTipPanel != null)
			{
				mapTipsActivateTipPanel.SetUiActive(isHide);
			}
			if (isHide)
			{
				MarkCommonGamePlayStateComponent component = markItem.MarkItemEntity.GetComponent<MarkCommonGamePlayStateComponent>(EMapComponent.MarkCommonGamePlayState);
				int? num = (component != null) ? component.GetRelativeDungeonId() : null;
				int? num2 = (component != null) ? component.GetRelativeId() : null;
				if (component != null && num != null && num2 != null)
				{
					string hideTip = ModelBase<LevelPlayReportModel>.Instance.GetLevelPlayHideReason(num.Value, num2.Value);
					MapTipsActivateTipPanel mapTipsActivateTipPanel2 = this.MapTipsActivateTipPanel;
					if (mapTipsActivateTipPanel2 == null)
					{
						return;
					}
					mapTipsActivateTipPanel2.SetHideTip(hideTip);
					return;
				}
				else
				{
					int valueOrDefault = markItem.MarkItemEntity.GetComponent<MarkEntityComponent>(EMapComponent.MarkEntity).EntityId.GetValueOrDefault();
					string hideTip = ModelBase<MapModel>.Instance.GetMarkHideReason(markItem.MapId, valueOrDefault);
					MapTipsActivateTipPanel mapTipsActivateTipPanel3 = this.MapTipsActivateTipPanel;
					if (mapTipsActivateTipPanel3 == null)
					{
						return;
					}
					mapTipsActivateTipPanel3.SetHideTip(hideTip);
				}
			}
		}

		// Token: 0x060326B3 RID: 206515 RVA: 0x00C9D37C File Offset: 0x00C9B57C
		protected virtual void UpdateEnableFastMoveLayout()
		{
			MarkItem markItem = this.LayoutContext.MarkItem;
			ConfigMarkItem configMarkItem = this.LayoutContext.MarkItem as ConfigMarkItem;
			IMarkShowState markExtraShowState = ModelBase<MapModel>.Instance.GetMarkExtraShowState(markItem.MarkId);
			bool flag = markExtraShowState == null || markExtraShowState.ShowFlag != MapMarkShowFlag.ShowDisable;
			bool flag2 = configMarkItem == null || !configMarkItem.IsLocked;
			bool flag3;
			if (configMarkItem == null)
			{
				flag3 = false;
			}
			else
			{
				ConfigMarkItem configMarkItem2 = configMarkItem;
				flag3 = (((configMarkItem2.MarkConfig != null) ? new int?(configMarkItem2.MarkConfig.GetValueOrDefault().EnableQuickTransfer) : null).GetValueOrDefault() == 1);
			}
			bool flag4 = flag3;
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext != null)
			{
				layoutContext.SetConfirmBtnActive(flag4 && flag2);
			}
			ButtonItem confirmButton = this.ConfirmButton;
			if (confirmButton != null)
			{
				confirmButton.SetEnableClick(flag2);
			}
			this.UpdateQuickGotoActive(!flag4 || !flag2);
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markItem.MarkId);
			if (configMark != null && configMark.Value.IsDisableBtnGoto)
			{
				base.GetItem(27).SetUIActive(false);
			}
			if (!flag)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MarkBlock");
				this.UpdateTopRightIcon(true, resourcePath);
				return;
			}
			this.UpdateTopRightIconActive();
		}

		// Token: 0x060326B4 RID: 206516 RVA: 0x00C9D4B4 File Offset: 0x00C9B6B4
		protected void UpdateMarkItemRelativeLayout()
		{
			this.UpdateMultiMap();
			this.UpdateTopRightIconActive();
		}

		// Token: 0x060326B5 RID: 206517 RVA: 0x00C9D4C4 File Offset: 0x00C9B6C4
		protected void UpdateMultiMap()
		{
			bool flag = this.LayoutContext.MarkItem.ShowSecondaryUiMultiMapIcon();
			base.GetSprite(23).SetUIActive(flag);
			if (flag)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MarkMultiMapSelect");
				this.SetSpriteByPath(resourcePath, base.GetSprite(23), false, null, null);
			}
		}

		// Token: 0x060326B6 RID: 206518 RVA: 0x00C9D520 File Offset: 0x00C9B720
		protected void UpdateTopRightIconActive()
		{
			MarkItem markItem = this.LayoutContext.MarkItem;
			if (markItem == null)
			{
				return;
			}
			bool active = markItem.MarkItemEntity.ViewLifeCircle.IsChildViewVisible(EMarkViewComponentType.TopRightIcon, false);
			string topRightIconPath = markItem.MarkItemEntity.Resource.TopRightIconPath;
			this.UpdateTopRightIcon(active, topRightIconPath);
		}

		// Token: 0x060326B7 RID: 206519 RVA: 0x00C9D56C File Offset: 0x00C9B76C
		protected void UpdateTopRightIconByTeleportState()
		{
			if (!this.LayoutContext.MarkItem.MarkItemEntity.GamePlay.IsDisable)
			{
				this.UpdateTopRightIcon(false, null);
				return;
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MarkBlock");
			this.UpdateTopRightIcon(true, resourcePath);
		}

		// Token: 0x060326B8 RID: 206520 RVA: 0x00C9D5BC File Offset: 0x00C9B7BC
		protected void UpdateTopRightIcon(bool active, string iconPath = null)
		{
			base.GetSprite(24).SetUIActive(active);
			if (active && !StringUtils.IsEmpty(iconPath))
			{
				this.SetSpriteByPath(iconPath, base.GetSprite(24), false, null, null);
			}
		}

		// Token: 0x060326B9 RID: 206521 RVA: 0x00C9D5FC File Offset: 0x00C9B7FC
		protected void UpdateRightDownIconActive()
		{
			this.UpdateMultiMapIconActive();
		}

		// Token: 0x060326BA RID: 206522 RVA: 0x00C9D604 File Offset: 0x00C9B804
		protected void UpdateMultiMapIconActive()
		{
			bool flag = this.LayoutContext.MarkItem.ShowSecondaryUiMultiMapIcon();
			if (flag)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MarkMultiMapSelect");
				this.UpdateDownStateIcon(flag, resourcePath);
				return;
			}
			this.UpdateDownStateIcon(flag, null);
		}

		// Token: 0x060326BB RID: 206523 RVA: 0x00C9D648 File Offset: 0x00C9B848
		protected void UpdateDownStateIcon(bool active, string iconPath = null)
		{
			base.GetSprite(23).SetUIActive(active);
			if (active && !StringUtils.IsEmpty(iconPath))
			{
				this.SetSpriteByPath(iconPath, base.GetSprite(23), false, null, null);
			}
		}

		// Token: 0x060326BC RID: 206524 RVA: 0x00C9D688 File Offset: 0x00C9B888
		protected bool UpdateDeliveryPropLayout()
		{
			MapMark? markConfig = (this.LayoutContext.MarkItem as ConfigMarkItem).MarkConfig;
			List<TItem> list = null;
			if (markConfig.Value.DeliveryPropLength > 0)
			{
				list = new List<TItem>();
				for (int i = 0; i < markConfig.Value.DeliveryPropLength; i++)
				{
					DicIntInt? dicIntInt = markConfig.Value.DeliveryProp(i);
					TItem item = new TItem
					{
						ItemData = new InventoryDefine.GetItemData(dicIntInt.Value.Key, 0),
						Count = dicIntInt.Value.Value
					};
					list.Add(item);
				}
			}
			if (((list != null) ? list.Count : 0) > 0)
			{
				this.UpdateRewardLayoutByList(list, "Mark_Submit_Material_Text");
				return true;
			}
			base.GetVerticalLayout(40).RootUIComp.Get().SetUIActive(false);
			return false;
		}

		// Token: 0x060326BD RID: 206525 RVA: 0x00C9D774 File Offset: 0x00C9B974
		[NullableContext(1)]
		public void UpdateRewardLayout(int dropId, string titleKey)
		{
			List<TItem> itemListByDropId = this.GetItemListByDropId(dropId);
			this.UpdateRewardLayoutByList(itemListByDropId, titleKey);
		}

		// Token: 0x060326BE RID: 206526 RVA: 0x00C9D794 File Offset: 0x00C9B994
		[NullableContext(1)]
		public List<TItem> GetItemListByDropId(int dropId)
		{
			List<TItem> list = new List<TItem>();
			DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(dropId);
			if (dropPackage != null && dropPackage.GetValueOrDefault().DropPreviewLength > 0)
			{
				for (int i = 0; i < dropPackage.Value.DropPreviewLength; i++)
				{
					DicIntInt? dicIntInt = dropPackage.Value.DropPreview(i);
					list.Add(new TItem
					{
						ItemData = new InventoryDefine.GetItemData(dicIntInt.Value.Key, 0),
						Count = dicIntInt.Value.Value
					});
				}
			}
			return list;
		}

		// Token: 0x060326BF RID: 206527 RVA: 0x00C9D844 File Offset: 0x00C9BA44
		[NullableContext(1)]
		public void UpdateRewardLayoutByList(List<TItem> list, string titleKey)
		{
			if (list.Count == 0)
			{
				return;
			}
			base.GetVerticalLayout(40).RootUIComp.Get().SetUIActive(true);
			this.DeliveryPropView.SetTitleNewTxt(titleKey);
			this.DeliveryPropView.Refresh(list);
		}

		// Token: 0x060326C0 RID: 206528 RVA: 0x00C9D88D File Offset: 0x00C9BA8D
		protected virtual void OnConfirmBtnClick(int index)
		{
			this.HandleTeleportAndTrack();
		}

		// Token: 0x060326C1 RID: 206529 RVA: 0x00C9D895 File Offset: 0x00C9BA95
		protected virtual void OnTrackBtnClick(int index)
		{
			this.HandleTrack();
		}

		// Token: 0x060326C2 RID: 206530 RVA: 0x00C9D89D File Offset: 0x00C9BA9D
		protected virtual void OnGotoBtnClick(int index)
		{
			this.HandleQuickGoto();
		}

		// Token: 0x060326C3 RID: 206531 RVA: 0x00C9D8A5 File Offset: 0x00C9BAA5
		protected virtual void OnDetailBtnClick()
		{
		}

		// Token: 0x060326C4 RID: 206532 RVA: 0x00C9D8A7 File Offset: 0x00C9BAA7
		protected virtual void OnStripBtnClick()
		{
		}

		// Token: 0x060326C5 RID: 206533 RVA: 0x00C9D8A9 File Offset: 0x00C9BAA9
		protected virtual void OnDelBtnClick()
		{
		}

		// Token: 0x060326C6 RID: 206534 RVA: 0x00C9D8AB File Offset: 0x00C9BAAB
		protected virtual void HandleTeleportAndTrack()
		{
			if (this.HandleTeleport())
			{
				return;
			}
			this.HandleTrack();
		}

		// Token: 0x060326C7 RID: 206535 RVA: 0x00C9D8BC File Offset: 0x00C9BABC
		protected virtual void HandleFastMoveAndTrack()
		{
			ConfigMarkItem configMarkItem = this.LayoutContext.MarkItem as ConfigMarkItem;
			bool flag = configMarkItem == null || !configMarkItem.IsLocked;
			bool flag2;
			if (configMarkItem == null)
			{
				flag2 = false;
			}
			else
			{
				ConfigMarkItem configMarkItem2 = configMarkItem;
				flag2 = (((configMarkItem2.MarkConfig != null) ? new int?(configMarkItem2.MarkConfig.GetValueOrDefault().EnableQuickTransfer) : null).GetValueOrDefault() == 1);
			}
			bool flag3 = flag2;
			if (flag && flag3)
			{
				this.HandleTeleportAndTrack();
				return;
			}
			this.HandleTrack();
		}

		// Token: 0x060326C8 RID: 206536 RVA: 0x00C9D938 File Offset: 0x00C9BB38
		protected unsafe virtual bool HandleTeleport()
		{
			ConfigMarkItem configMarkItem = this.LayoutContext.MarkItem as ConfigMarkItem;
			if (configMarkItem == null)
			{
				return false;
			}
			if (configMarkItem.IsLocked)
			{
				return false;
			}
			ELogAuthor author = ELogAuthor.LYX;
			string message = "[地图系统]->传送";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("markId", configMarkItem.MarkId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsTracked", configMarkItem.IsTracked);
			MapLogger.Debug(author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			ConfigMarkItem configMarkItem2 = configMarkItem;
			if (configMarkItem2.MarkConfig != null && configMarkItem2.MarkConfig.GetValueOrDefault().InstanceDungeonId != 0)
			{
				ControllerBase<WorldMapController>.Instance.TryEntityTeleport(configMarkItem.MarkConfigId, null);
			}
			else
			{
				ControllerBase<WorldMapController>.Instance.TryTeleport(configMarkItem.MarkConfigId, null);
			}
			return true;
		}

		// Token: 0x060326C9 RID: 206537 RVA: 0x00C9DA0C File Offset: 0x00C9BC0C
		protected unsafe virtual void HandleTrack()
		{
			MarkItem markItem = this.LayoutContext.MarkItem;
			if (markItem == null)
			{
				return;
			}
			base.CheckAndShowCrossMapTips(markItem);
			ELogAuthor author = ELogAuthor.LRX;
			string message = "[地图系统]->追踪";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("markId", markItem.MarkId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsTracked", markItem.IsTracked);
			MapLogger.Debug(author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			ControllerBase<MapController>.Instance.RequestTrackMapMark(new TrackMapMarkParams
			{
				MarkType = markItem.MarkType,
				MarkId = markItem.MarkId,
				Track = !markItem.IsTracked
			}, null);
			base.Close();
		}

		// Token: 0x060326CA RID: 206538 RVA: 0x00C9DAD0 File Offset: 0x00C9BCD0
		protected virtual void HandleQuickGoto()
		{
			MarkItem markItem = this.LayoutContext.MarkItem;
			MarkItem markItem2 = MarkUiUtils.FindNearbyValidGotoMark(this.Map, markItem);
			if (markItem2 != null)
			{
				MarkUiUtils.QuickGotoTeleport(markItem, markItem2, new TOnTelSuccessCallBack(base.Close));
			}
		}

		// Token: 0x060326CB RID: 206539 RVA: 0x00C9DB0C File Offset: 0x00C9BD0C
		protected override void OnAfterShowWorldMapSecondaryUi()
		{
			WorldMapSecondaryUiAutoPilotContext autoPilotContext = this.AutoPilotContext;
			if (autoPilotContext == null)
			{
				return;
			}
			autoPilotContext.UpdateAutoPilotState();
		}

		// Token: 0x060326CC RID: 206540 RVA: 0x00C9DB1E File Offset: 0x00C9BD1E
		private void RefreshPanel(MarkItem markItem)
		{
			this.OnRefreshPanel();
		}

		// Token: 0x060326CD RID: 206541 RVA: 0x00C9DB26 File Offset: 0x00C9BD26
		protected virtual void OnRefreshPanel()
		{
			WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
		}

		// Token: 0x0401D6CB RID: 120523
		private ButtonItem ConfirmButton;

		// Token: 0x0401D6CC RID: 120524
		protected ButtonItem TrackBtn;

		// Token: 0x0401D6CD RID: 120525
		protected ButtonItem GotoBtn;

		// Token: 0x0401D6CE RID: 120526
		protected MapTipsActivateTipPanel MapTipsActivateTipPanel;

		// Token: 0x0401D6CF RID: 120527
		protected MediumItemListPanel DeliveryPropView;

		// Token: 0x0401D6D0 RID: 120528
		protected WorldMapSecondaryUiAutoPilotContext AutoPilotContext;

		// Token: 0x0401D6D1 RID: 120529
		protected WorldMapSecondaryUiContext LayoutContext;

		// Token: 0x0401D6D2 RID: 120530
		private Action UpdateTopRightIconHandle;
	}
}
