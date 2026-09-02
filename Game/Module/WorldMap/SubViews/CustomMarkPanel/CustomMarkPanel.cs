using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Controller;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark.Misc;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.CustomMarkPanel
{
	// Token: 0x02004BC5 RID: 19397
	[NullableContext(1)]
	[Nullable(0)]
	public class CustomMarkPanel : WorldMapSecondaryUiLayoutB
	{
		// Token: 0x06032A06 RID: 207366 RVA: 0x00CAE6E9 File Offset: 0x00CAC8E9
		public override string GetResourceId()
		{
			return "UiItem_CustomMarkPanel_Prefab";
		}

		// Token: 0x06032A07 RID: 207367 RVA: 0x00CAE6F0 File Offset: 0x00CAC8F0
		protected override void OnStart()
		{
			base.OnStart();
			this.MarkIconOptions = new List<MarkIconOption>();
			this.CreateMarkIconOptions();
		}

		// Token: 0x06032A08 RID: 207368 RVA: 0x00CAE70C File Offset: 0x00CAC90C
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length >= 2)
			{
				CustomMarkItem customMarkItem = param[0] as CustomMarkItem;
				if (customMarkItem != null)
				{
					object obj = param[1];
					ECustomMarkPanelMode ecustomMarkPanelMode2;
					if (obj is ECustomMarkPanelMode)
					{
						ECustomMarkPanelMode ecustomMarkPanelMode = (ECustomMarkPanelMode)obj;
						ecustomMarkPanelMode2 = ecustomMarkPanelMode;
					}
					else if (obj is int)
					{
						int num = (int)obj;
						ecustomMarkPanelMode2 = (ECustomMarkPanelMode)num;
					}
					else
					{
						ecustomMarkPanelMode2 = ECustomMarkPanelMode.Create;
					}
					ECustomMarkPanelMode ecustomMarkPanelMode3 = ecustomMarkPanelMode2;
					if (this.LayoutContext != null)
					{
						this.LayoutContext.MarkItem = customMarkItem;
					}
					this.CustomMarkMode = ecustomMarkPanelMode3;
					customMarkItem.IsCreated = (ecustomMarkPanelMode3 == ECustomMarkPanelMode.Modify);
					this.SelectedMarkItem = customMarkItem;
					this.LayoutContext.TakeAction = false;
					this.UpdatePanel();
					this.SetSpriteByPath(this.SelectedMarkItem.IconPath, base.GetSprite(0), false, null, null);
					int markCountByType = ModelBase<MapModel>.Instance.GetMarkCountByType(EMarkType.Custom);
					UUIText text = base.GetText(3);
					if (text != null)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
						defaultInterpolatedStringHandler.AppendFormatted<int>(markCountByType);
						defaultInterpolatedStringHandler.AppendLiteral("/");
						defaultInterpolatedStringHandler.AppendFormatted<int>(ModelBase<WorldMapModel>.Instance.CustomMarkSize);
						text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
					}
					UUIItem rootItem = this.RootItem;
					if (rootItem != null)
					{
						rootItem.SetUIActive(true);
					}
					ButtonItem rightConfirmBtn = this.RightConfirmBtn;
					if (rightConfirmBtn != null)
					{
						rightConfirmBtn.SetUiActive(true);
					}
					ButtonItem leftConfirmBtn = this.LeftConfirmBtn;
					if (leftConfirmBtn != null)
					{
						leftConfirmBtn.SetUiActive(true);
					}
					ButtonItem middleCenterBtn = this.MiddleCenterBtn;
					if (middleCenterBtn != null)
					{
						middleCenterBtn.SetUiActive(false);
					}
					this.SelectOptionChecked(customMarkItem);
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "CustomeMark", Array.Empty<object>());
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "CustomeMarkTip", Array.Empty<object>());
					return;
				}
			}
		}

		// Token: 0x06032A09 RID: 207369 RVA: 0x00CAE8A8 File Offset: 0x00CACAA8
		public void SelectOptionChecked(CustomMarkItem selectedMarkItem)
		{
			if (this.MarkIconOptions == null || this.MarkIconOptions.Count == 0)
			{
				return;
			}
			if (this.CustomMarkMode == ECustomMarkPanelMode.Modify)
			{
				foreach (MarkIconOption markIconOption in this.MarkIconOptions)
				{
					CustomMark? customMark;
					if (((markIconOption.Config != null) ? customMark.GetValueOrDefault().MarkPic : null) == selectedMarkItem.IconPath)
					{
						markIconOption.SetToggleChecked();
						return;
					}
				}
			}
			this.MarkIconOptions[0].SetToggleChecked();
		}

		// Token: 0x06032A0A RID: 207370 RVA: 0x00CAE95C File Offset: 0x00CACB5C
		private void UpdatePanel()
		{
			ECustomMarkPanelMode customMarkMode = this.CustomMarkMode;
			if (customMarkMode != ECustomMarkPanelMode.Create)
			{
				if (customMarkMode == ECustomMarkPanelMode.Modify)
				{
					MarkItem markItem = MarkUiUtils.FindNearbyValidGotoMark(this.Map, this.SelectedMarkItem);
					ButtonItem rightConfirmBtn = this.RightConfirmBtn;
					if (rightConfirmBtn != null)
					{
						rightConfirmBtn.SetEnableClick(ModelBase<TeleportModel>.Instance.AllowTeleportByUi && markItem != null);
					}
					ButtonItem rightConfirmBtn2 = this.RightConfirmBtn;
					if (rightConfirmBtn2 != null)
					{
						rightConfirmBtn2.TrySetLocalTextNew("MapMarkQuickTransfer_Text", Array.Empty<object>());
					}
				}
			}
			else
			{
				string text = ConfigMultiTextLang.GetLocalTextNew("Text_Add_Text", null) ?? "";
				ButtonItem rightConfirmBtn3 = this.RightConfirmBtn;
				if (rightConfirmBtn3 != null)
				{
					rightConfirmBtn3.SetText(text);
				}
				ButtonItem rightConfirmBtn4 = this.RightConfirmBtn;
				if (rightConfirmBtn4 != null)
				{
					rightConfirmBtn4.SetEnableClick(true);
				}
			}
			bool flag = this.CustomMarkMode == ECustomMarkPanelMode.Create;
			base.SetDelBtnActive(!flag);
			ButtonItem leftConfirmBtn = this.LeftConfirmBtn;
			if (leftConfirmBtn != null)
			{
				leftConfirmBtn.SetEnableClick(!flag);
			}
			CustomMarkItem selectedMarkItem = this.SelectedMarkItem;
			this.UpdateTrackButton(selectedMarkItem != null && selectedMarkItem.IsTracked);
		}

		// Token: 0x06032A0B RID: 207371 RVA: 0x00CAEA4C File Offset: 0x00CACC4C
		protected override void OnRightConfirmBtnClick(int index)
		{
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext != null && layoutContext.TakeAction)
			{
				return;
			}
			ECustomMarkPanelMode customMarkMode = this.CustomMarkMode;
			if (customMarkMode == ECustomMarkPanelMode.Create)
			{
				ControllerBase<MapController>.Instance.RequestCreateCustomMark(this.SelectedMarkItem.TrackPosition, this.SelectedMarkItem.ConfigId, null);
				this.LayoutContext.TakeAction = true;
				base.Close();
				return;
			}
			if (customMarkMode != ECustomMarkPanelMode.Modify)
			{
				return;
			}
			MarkItem markItem = MarkUiUtils.FindNearbyValidGotoMark(this.Map, this.SelectedMarkItem);
			if (markItem != null)
			{
				MarkUiUtils.QuickGotoTeleport(this.SelectedMarkItem, markItem, new TOnTelSuccessCallBack(base.Close));
			}
		}

		// Token: 0x06032A0C RID: 207372 RVA: 0x00CAEAE0 File Offset: 0x00CACCE0
		protected override void OnLeftConfirmBtnClick(int index)
		{
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext != null && layoutContext.TakeAction)
			{
				return;
			}
			base.CheckAndShowCrossMapTips(this.SelectedMarkItem);
			ControllerBase<MapController>.Instance.RequestTrackMapMark(new TrackMapMarkParams
			{
				MarkType = this.SelectedMarkItem.MarkType,
				MarkId = this.SelectedMarkItem.MarkId,
				Track = !this.TrackState,
				TrackMode = new ETrackMapMarkMode?(ETrackMapMarkMode.Remote)
			}, null);
			this.LayoutContext.TakeAction = true;
			this.TrackState = !this.TrackState;
			base.Close();
		}

		// Token: 0x06032A0D RID: 207373 RVA: 0x00CAEB7C File Offset: 0x00CACD7C
		protected override void OnDelBtnClick()
		{
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext != null && layoutContext.TakeAction)
			{
				return;
			}
			if (this.CustomMarkMode == ECustomMarkPanelMode.Modify)
			{
				ControllerBase<MapController>.Instance.RequestRemoveMapMarks(EMarkType.Custom, new List<int>
				{
					this.SelectedMarkItem.MarkId
				});
			}
			this.LayoutContext.TakeAction = true;
			base.Close();
		}

		// Token: 0x06032A0E RID: 207374 RVA: 0x00CAEBDC File Offset: 0x00CACDDC
		private void UpdateTrackButton(bool isTracked)
		{
			this.TrackState = isTracked;
			string text = ConfigMultiTextLang.GetLocalTextNew(this.TrackState ? "Text_InstanceDungeonEntranceCancelTrack_Text" : "Text_InstanceDungeonEntranceTrack_Text", null) ?? "";
			ButtonItem leftConfirmBtn = this.LeftConfirmBtn;
			if (leftConfirmBtn == null)
			{
				return;
			}
			leftConfirmBtn.SetText(text);
		}

		// Token: 0x06032A0F RID: 207375 RVA: 0x00CAEC28 File Offset: 0x00CACE28
		private void SetConfigId(int configId, EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			if (!this.SelectedMarkItem.IsNewCustomMarkItem)
			{
				ControllerBase<MapController>.Instance.RequestMapMarkReplace(this.SelectedMarkItem.MarkId, configId);
			}
			this.SelectedMarkItem.SetConfigId(configId);
			this.SetSpriteByPath(this.SelectedMarkItem.IconPath, base.GetSprite(0), false, null, null);
		}

		// Token: 0x06032A10 RID: 207376 RVA: 0x00CAEC8C File Offset: 0x00CACE8C
		private void CreateMarkIconOptions()
		{
			WorldMapConfig instance = ConfigBase<WorldMapConfig>.Instance;
			IReadOnlyList<CustomMark> readOnlyList = (instance != null) ? instance.GetCustomMarks() : null;
			if (readOnlyList == null)
			{
				return;
			}
			using (IEnumerator<CustomMark> enumerator = readOnlyList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CustomMark configMark = enumerator.Current;
					UUIItem item = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(6), base.GetItem(4));
					MarkIconOption markIconOption = new MarkIconOption();
					markIconOption.Initialize(item, base.GetItem(4), configMark);
					if (this.CustomMarkMode == ECustomMarkPanelMode.Create && this.MarkIconOptions.Count == 0)
					{
						markIconOption.SetToggleChecked();
					}
					if (this.CustomMarkMode == ECustomMarkPanelMode.Modify)
					{
						CustomMarkItem selectedMarkItem = this.SelectedMarkItem;
						if (((selectedMarkItem != null) ? selectedMarkItem.IconPath : null) == configMark.MarkPic)
						{
							markIconOption.SetToggleChecked();
						}
					}
					markIconOption.SetOnclick(delegate(EToggleState state)
					{
						this.SetConfigId(configMark.MarkId, state);
					});
					this.MarkIconOptions.Add(markIconOption);
				}
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x06032A11 RID: 207377 RVA: 0x00CAEDB4 File Offset: 0x00CACFB4
		protected override void OnAfterShowWorldMapSecondaryUi()
		{
			base.OnAfterShowWorldMapSecondaryUi();
			Singleton<EventSystem>.Instance.Emit(EEventName.OnMapCustomMarkPanelShow);
		}

		// Token: 0x06032A12 RID: 207378 RVA: 0x00CAEDCC File Offset: 0x00CACFCC
		[NullableContext(2)]
		protected override void OnRefreshPanel(MarkItem param)
		{
			CustomMarkItem customMarkItem = param as CustomMarkItem;
			if (customMarkItem != null)
			{
				this.SelectedMarkItem = customMarkItem;
				if (this.SelectedMarkItem != null)
				{
					this.LayoutContext.MarkItem = this.SelectedMarkItem;
				}
				CustomMarkItem selectedMarkItem = this.SelectedMarkItem;
				this.CustomMarkMode = ((selectedMarkItem != null && selectedMarkItem.IsCreated) ? ECustomMarkPanelMode.Modify : ECustomMarkPanelMode.Create);
				this.UpdatePanel();
			}
		}

		// Token: 0x0401D7F6 RID: 120822
		private const int CUSTOM_MARK_PANEL_WIDTH = 778;

		// Token: 0x0401D7F7 RID: 120823
		private const int CUSTOM_MARK_PANEL_HEIGHT = 592;

		// Token: 0x0401D7F8 RID: 120824
		public static readonly FVector2D PanelSize = new FVector2D(778f, 592f);

		// Token: 0x0401D7F9 RID: 120825
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<MarkIconOption> MarkIconOptions;

		// Token: 0x0401D7FA RID: 120826
		[Nullable(2)]
		private CustomMarkItem SelectedMarkItem;

		// Token: 0x0401D7FB RID: 120827
		private bool TrackState;

		// Token: 0x0401D7FC RID: 120828
		private ECustomMarkPanelMode CustomMarkMode;

		// Token: 0x0200ACAA RID: 44202
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035A4F RID: 219727
			public const int CustomMarkPanel = 0;
		}
	}
}
