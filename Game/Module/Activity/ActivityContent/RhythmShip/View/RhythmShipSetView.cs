using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.KeySetting;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x0200651B RID: 25883
	[NullableContext(1)]
	[Nullable(0)]
	public class RhythmShipSetView : UiViewBase
	{
		// Token: 0x06040BCA RID: 265162 RVA: 0x01099A4B File Offset: 0x01097C4B
		public RhythmShipSetView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040BCB RID: 265163 RVA: 0x01099A66 File Offset: 0x01097C66
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIMultiTemplateScrollViewComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06040BCC RID: 265164 RVA: 0x01099AA0 File Offset: 0x01097CA0
		protected override void OnStart()
		{
			CommonTabComponentData<CommonTabItem> data = new CommonTabComponentData<CommonTabItem>(new Func<UUIItem, int?, CommonTabItem>(this.TabItemProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
			this.TabComponent = new TabComponentWithCaptionItem<CommonTabItem>(base.GetItem(1), data, delegate()
			{
				base.CloseMe(null);
			}, false);
			this.TabComponent.SetHelpButtonShowState(false);
			this.SetMultiTemplateScrollView = new MultiTemplateScrollView(base.GetMultiTemplateScrollViewComponent(0));
			this.TabComponent.RefreshTabItemByLength(1, delegate
			{
				TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
				if (tabComponent == null)
				{
					return;
				}
				tabComponent.SelectToggleByIndex(0, false);
			});
		}

		// Token: 0x06040BCD RID: 265165 RVA: 0x01099B2D File Offset: 0x01097D2D
		protected override void OnBeforeShow()
		{
			if (this.HaveFirstShow)
			{
				this.HaveFirstShow = false;
				return;
			}
			this.RefreshSliderItem();
		}

		// Token: 0x06040BCE RID: 265166 RVA: 0x01099B48 File Offset: 0x01097D48
		private void RefreshScrollView()
		{
			this.InitScrollViewData();
			MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(this.ScrollDataList);
			multiTemplateScrollViewRefreshContext.ScrollToGridIndex = 0;
			MultiTemplateScrollView setMultiTemplateScrollView = this.SetMultiTemplateScrollView;
			if (setMultiTemplateScrollView == null)
			{
				return;
			}
			setMultiTemplateScrollView.RefreshByData(multiTemplateScrollViewRefreshContext);
		}

		// Token: 0x06040BCF RID: 265167 RVA: 0x01099B80 File Offset: 0x01097D80
		private void RefreshSliderItem()
		{
			int num = this.ScrollDataList.FindIndex((IMultiTemplateGridData data) => (data.Data as RhythmShipSetData).Type == ERhythmShipSetDataType.ItemBar);
			MultiTemplateScrollView setMultiTemplateScrollView = this.SetMultiTemplateScrollView;
			if (setMultiTemplateScrollView == null)
			{
				return;
			}
			ISyncGridProxy proxyByGridIndex = setMultiTemplateScrollView.GetProxyByGridIndex(num);
			if (proxyByGridIndex == null)
			{
				return;
			}
			proxyByGridIndex.Refresh(this.ScrollDataList[num].Data);
		}

		// Token: 0x06040BD0 RID: 265168 RVA: 0x01099BE4 File Offset: 0x01097DE4
		private void InitScrollViewData()
		{
			this.ScrollDataList = new List<IMultiTemplateGridData>();
			this.AddTitleData("RhythmShipSetTitle_1", ERhythmShipSetDataType.OnlyTitle);
			this.AddItemBtnData("RhythmShipSetItem_1", ERhythmShipSetDataType.ItemBtn, new Action(this.OnSetKeyItemBtnClickCallBack));
			this.AddTitleData("RhythmShipSetTitle_2", ERhythmShipSetDataType.OnlyTitle);
			this.AddItemBtnData("RhythmShipSetItem_2", ERhythmShipSetDataType.ItemBtn, new Action(this.OnSetCalibrationItemBtnClickCallBack));
			this.AddItemSliderData("RhythmShipSetItem_3", ERhythmShipSetDataType.ItemBar, new Action<int>(this.OnCalibrationValueChange));
		}

		// Token: 0x06040BD1 RID: 265169 RVA: 0x01099C5C File Offset: 0x01097E5C
		private void AddTitleData(string titleText, ERhythmShipSetDataType type)
		{
			RhythmShipSetTitleData item = new RhythmShipSetTitleData(new RhythmShipSetData
			{
				Text = titleText,
				Type = type
			});
			this.ScrollDataList.Add(item);
		}

		// Token: 0x06040BD2 RID: 265170 RVA: 0x01099C90 File Offset: 0x01097E90
		private void AddItemBtnData(string text, ERhythmShipSetDataType type, Action callBack)
		{
			RhythmShipSetItemBtnData item = new RhythmShipSetItemBtnData(new RhythmShipSetData
			{
				Text = text,
				Type = type,
				BtnCallBack = callBack
			});
			this.ScrollDataList.Add(item);
		}

		// Token: 0x06040BD3 RID: 265171 RVA: 0x01099CCC File Offset: 0x01097ECC
		private void AddItemSliderData(string text, ERhythmShipSetDataType type, Action<int> barValueChange)
		{
			RhythmShipSetItemSliderData rhythmShipSetItemSliderData = new RhythmShipSetItemSliderData(new RhythmShipSetData
			{
				Text = text,
				Type = type
			});
			rhythmShipSetItemSliderData.OnSliderValueChangeCallBack = barValueChange;
			this.ScrollDataList.Add(rhythmShipSetItemSliderData);
		}

		// Token: 0x06040BD4 RID: 265172 RVA: 0x01099D05 File Offset: 0x01097F05
		private CommonTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new CommonTabItem();
		}

		// Token: 0x06040BD5 RID: 265173 RVA: 0x01099D0C File Offset: 0x01097F0C
		private void ToggleCallBack(int index)
		{
			this.RefreshScrollView();
		}

		// Token: 0x06040BD6 RID: 265174 RVA: 0x01099D14 File Offset: 0x01097F14
		private CommonTabData GetCommonData(int index)
		{
			CommonTabTitleData titleData = new CommonTabTitleData("RhythmRole_SetView_Title", Array.Empty<object>());
			return new CommonTabData(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_SETanjian"), titleData, null);
		}

		// Token: 0x06040BD7 RID: 265175 RVA: 0x01099D47 File Offset: 0x01097F47
		private void OnCalibrationValueChange(int currentCalibrationValue)
		{
			this.CurrentCalibrationValue = currentCalibrationValue;
		}

		// Token: 0x06040BD8 RID: 265176 RVA: 0x01099D50 File Offset: 0x01097F50
		private void OnSetCalibrationItemBtnClickCallBack()
		{
			this.SaveCurrentCalibration();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipCalibrationView, null, null);
		}

		// Token: 0x06040BD9 RID: 265177 RVA: 0x01099D6C File Offset: 0x01097F6C
		private void OnSetKeyItemBtnClickCallBack()
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				ControllerBase<TouchUiEditController>.Instance.OpenCommonTouchUiEditView(4);
				return;
			}
			CommonKeySettingViewOpenData param = new CommonKeySettingViewOpenData
			{
				ViewType = EKeySettingExclusiveType.RhythmShip,
				BgSourceId = "T_RhythmShipLevelBg"
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonKeySettingView, param, null);
		}

		// Token: 0x06040BDA RID: 265178 RVA: 0x01099DBA File Offset: 0x01097FBA
		protected override void OnBeforeHide()
		{
			this.SaveCurrentCalibration();
		}

		// Token: 0x06040BDB RID: 265179 RVA: 0x01099DC2 File Offset: 0x01097FC2
		private void SaveCurrentCalibration()
		{
			ModelBase<RhythmShipModel>.Instance.SetLocalCalibrationValue(this.CurrentCalibrationValue);
		}

		// Token: 0x06040BDC RID: 265180 RVA: 0x01099DD4 File Offset: 0x01097FD4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			string text = configParams[0];
			if (text == "Tab")
			{
				int index = int.Parse(configParams[1]);
				TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
				UUIItem uuiitem;
				if (tabComponent == null)
				{
					uuiitem = null;
				}
				else
				{
					CommonTabItem tabItemByIndex = tabComponent.GetTabItemByIndex(index);
					uuiitem = ((tabItemByIndex != null) ? tabItemByIndex.GetRootItem() : null);
				}
				UUIItem uuiitem2 = uuiitem;
				if (uuiitem2 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem2,
					uuiitem2
				};
			}
			else
			{
				if (!text.Contains("Btn"))
				{
					return null;
				}
				int gridIndex = int.Parse(configParams[1]);
				RhythmShipSetItemBtn rhythmShipSetItemBtn = this.SetMultiTemplateScrollView.GetProxyByGridIndex(gridIndex) as RhythmShipSetItemBtn;
				if (rhythmShipSetItemBtn == null)
				{
					return null;
				}
				UUIItem btnItem = rhythmShipSetItemBtn.GetBtnItem();
				if (text == "Btn")
				{
					if (btnItem == null)
					{
						return null;
					}
					return new UUIItem[]
					{
						btnItem,
						btnItem
					};
				}
				else
				{
					UUIItem navigationItem = rhythmShipSetItemBtn.GetNavigationItem();
					if (btnItem == null || navigationItem == null)
					{
						return null;
					}
					return new UUIItem[]
					{
						btnItem,
						navigationItem
					};
				}
			}
		}

		// Token: 0x040244C8 RID: 148680
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected TabComponentWithCaptionItem<CommonTabItem> TabComponent;

		// Token: 0x040244C9 RID: 148681
		[Nullable(2)]
		private MultiTemplateScrollView SetMultiTemplateScrollView;

		// Token: 0x040244CA RID: 148682
		private List<IMultiTemplateGridData> ScrollDataList = new List<IMultiTemplateGridData>();

		// Token: 0x040244CB RID: 148683
		private int CurrentCalibrationValue;

		// Token: 0x040244CC RID: 148684
		private bool HaveFirstShow = true;
	}
}
