using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.InputView.Controller;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using FilterDefine;
using UnrealEngine;

namespace CSharpScript.Game.Module.Inventory.Views
{
	// Token: 0x02005B8C RID: 23436
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomManageConfigView : UiTabViewBase
	{
		// Token: 0x0603B41E RID: 242718 RVA: 0x00F003DC File Offset: 0x00EFE5DC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUITexture)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickedBtnRename)),
				new ValueTuple<int, Delegate>(9, new Action(this.OnClickedBtnDelete)),
				new ValueTuple<int, Delegate>(13, new Action(this.OnClickedBtnQuitEdit)),
				new ValueTuple<int, Delegate>(14, new Action(this.OnClickedBtnRecommend))
			};
		}

		// Token: 0x0603B41F RID: 242719 RVA: 0x00F005B4 File Offset: 0x00EFE7B4
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomManageConfigView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomManageConfigView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B420 RID: 242720 RVA: 0x00F005F8 File Offset: 0x00EFE7F8
		protected override void OnStart()
		{
			this.ViewModel = new PhantomManageConfigViewModel();
			this.ViewModel.Bind(new Action<EPhantomManageConfigViewData>(this.OnViewModelUpdate));
			this.LayoutType = new GenericLayout<PhantomManageConfigTypeItem, InventoryDefine.IManageConfigTypeItemData>(base.GetHorizontalLayout(0), new Func<PhantomManageConfigTypeItem>(this.CreateTypeItem), null, false, true);
			PhantomManageConfigTypeItem.ViewModel = this.ViewModel;
			this.ScrollConfig = new LoopScrollView<PhantomManageConfigItem, PhantomManageConfigData>(base.GetLoopScrollViewComponent(1), base.GetItem(2).GetOwner() as AUIBaseActor, new Func<PhantomManageConfigItem>(this.CreateConfigItem), false);
			PhantomManageConfigItem.CallbackBtnSelect = new Action<PhantomManageConfigData>(this.OnClickedBtnConfig);
			PhantomManageConfigItem.ViewModel = this.ViewModel;
			this.ScrollSetting = new GenericScrollViewNew<PhantomManageSettingTitleItem, InventoryDefine.IManageConfigTitleItemData>(base.GetScrollViewWithScrollbar(7), new Func<PhantomManageSettingTitleItem>(this.CreateSettingTitleItem), null, true, null);
			PhantomManageSettingTitleItem.ViewModel = this.ViewModel;
			this.InturnAniConfig = this.ScrollConfig.GetUiAnimController();
			this.InturnAniSetting = (base.GetScrollViewWithScrollbar(7).GetContent().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController);
			this.ViewModel.SetSelectType(PhantomSettingType.AutoLock, false);
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.AddSequenceFinishEvent("Start", new Action<string>(this.OnPlayingStartSequenceAsync), false);
			}
			UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
			if (uiViewSequence2 == null)
			{
				return;
			}
			uiViewSequence2.AddSequenceFinishEvent("UnSelect", delegate(string _)
			{
				if (!this.ViewModel.GetEditState())
				{
					base.GetItem(3).SetUIActive(false);
				}
			}, false);
		}

		// Token: 0x0603B421 RID: 242721 RVA: 0x00F00754 File Offset: 0x00EFE954
		protected void OnPlayingStartSequenceAsync(string _)
		{
			UUIInturnAnimController inturnAniConfig = this.InturnAniConfig;
			if (inturnAniConfig != null)
			{
				inturnAniConfig.Play("", -1, false);
			}
			UUIInturnAnimController inturnAniSetting = this.InturnAniSetting;
			if (inturnAniSetting == null)
			{
				return;
			}
			inturnAniSetting.Play("", -1, false);
		}

		// Token: 0x0603B422 RID: 242722 RVA: 0x00F00785 File Offset: 0x00EFE985
		protected override void OnBeforeDestroy()
		{
			this.ViewModel.UnBind(new Action<EPhantomManageConfigViewData>(this.OnViewModelUpdate));
		}

		// Token: 0x0603B423 RID: 242723 RVA: 0x00F007A0 File Offset: 0x00EFE9A0
		private void OnViewModelUpdate(EPhantomManageConfigViewData data)
		{
			if (data == EPhantomManageConfigViewData.SelectType)
			{
				this.RefreshType();
				PhantomSettingType selectType = this.ViewModel.GetSelectType();
				int selectIndex = this.ViewModel.GetSelectIndex(selectType);
				PhantomManageConfigData phantomManageConfigByTypeAndIndex = ModelBase<InventoryModel>.Instance.GetPhantomManageConfigByTypeAndIndex(selectType, selectIndex);
				this.SelectConfig(true, phantomManageConfigByTypeAndIndex);
				return;
			}
			if (data == EPhantomManageConfigViewData.SelectConfig)
			{
				this.RefreshConfig();
				this.RefreshTitle();
				this.RefreshSetting();
				return;
			}
			if (data == EPhantomManageConfigViewData.EditState)
			{
				this.RefreshMask();
				this.RefreshRecommendBtnState();
				this.RefreshButtons();
				this.RefreshEditData();
				this.RefreshSetting();
				this.RefreshConfig();
				if (!this.ViewModel.GetEditState())
				{
					this.RefreshTitle();
					return;
				}
			}
			else if (data == EPhantomManageConfigViewData.EditSwitch)
			{
				this.RefreshTitle();
			}
		}

		// Token: 0x0603B424 RID: 242724 RVA: 0x00F00844 File Offset: 0x00EFEA44
		private void RefreshType()
		{
			List<InventoryDefine.IManageConfigTypeItemData> list = new List<InventoryDefine.IManageConfigTypeItemData>();
			InventoryDefine.ManageConfigTypeItemData item = new InventoryDefine.ManageConfigTypeItemData
			{
				Type = PhantomSettingType.AutoLock,
				Name = "PhantomProject_LockProject"
			};
			InventoryDefine.ManageConfigTypeItemData item2 = new InventoryDefine.ManageConfigTypeItemData
			{
				Type = PhantomSettingType.AutoDisuse,
				Name = "PhantomProject_DiscardProject"
			};
			list.Add(item);
			list.Add(item2);
			this.LayoutType.RefreshByData(list.ToList<InventoryDefine.IManageConfigTypeItemData>(), null, false);
		}

		// Token: 0x0603B425 RID: 242725 RVA: 0x00F008A8 File Offset: 0x00EFEAA8
		private UniTask RefreshConfig()
		{
			PhantomManageConfigView.<RefreshConfig>d__19 <RefreshConfig>d__;
			<RefreshConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshConfig>d__.<>4__this = this;
			<RefreshConfig>d__.<>1__state = -1;
			<RefreshConfig>d__.<>t__builder.Start<PhantomManageConfigView.<RefreshConfig>d__19>(ref <RefreshConfig>d__);
			return <RefreshConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0603B426 RID: 242726 RVA: 0x00F008EC File Offset: 0x00EFEAEC
		private void RefreshTitle()
		{
			PhantomSettingType selectType = this.ViewModel.GetSelectType();
			PhantomManageConfigData selectConfig = this.ViewModel.GetSelectConfig();
			this.BtnSwitch.SetConfigType(selectType);
			bool flag = this.ViewModel.GetEditState() ? this.ViewModel.GetEditSwitch() : selectConfig.GetIsOn();
			this.BtnSwitch.SetConfigState(flag);
			UUITexture texture = base.GetTexture(12);
			UUIItem uuiitem = texture;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			base.GetText(4).SetText(selectConfig.GetName(), true);
		}

		// Token: 0x0603B427 RID: 242727 RVA: 0x00F0097C File Offset: 0x00EFEB7C
		private void RefreshSetting()
		{
			List<InventoryDefine.IManageConfigTitleItemData> settingTitleItemDataList = ModelBase<InventoryModel>.Instance.GetSettingTitleItemDataList();
			this.ScrollSetting.RefreshByDataAsync(settingTitleItemDataList.ToList<InventoryDefine.IManageConfigTitleItemData>(), false);
		}

		// Token: 0x0603B428 RID: 242728 RVA: 0x00F009A8 File Offset: 0x00EFEBA8
		private void RefreshButtons()
		{
			string textId = this.ViewModel.GetEditState() ? "PhantomProject_SaveButton02" : "PhantomProject_EditButton";
			this.BtnEdit.SetLocalTextNew(textId, Array.Empty<object>());
		}

		// Token: 0x0603B429 RID: 242729 RVA: 0x00F009E0 File Offset: 0x00EFEBE0
		private void RefreshMask()
		{
			bool editState = this.ViewModel.GetEditState();
			if (editState)
			{
				base.GetItem(3).SetUIActive(true);
			}
			base.SetButtonUiActive(13, editState);
			string sequenceName = editState ? "Select" : "UnSelect";
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlaySequence(sequenceName, false, null);
		}

		// Token: 0x0603B42A RID: 242730 RVA: 0x00F00A40 File Offset: 0x00EFEC40
		private void RefreshRecommendBtnState()
		{
			bool editState = this.ViewModel.GetEditState();
			base.SetButtonUiActive(14, !editState);
		}

		// Token: 0x0603B42B RID: 242731 RVA: 0x00F00A68 File Offset: 0x00EFEC68
		private void RefreshEditData()
		{
			PhantomManageConfigData selectConfig = this.ViewModel.GetSelectConfig();
			if (this.ViewModel.GetEditState())
			{
				this.ViewModel.InitEditDataSwitch(selectConfig, false);
			}
		}

		// Token: 0x0603B42C RID: 242732 RVA: 0x00F00A9C File Offset: 0x00EFEC9C
		[NullableContext(2)]
		private void SelectConfig(bool enableScroll, PhantomManageConfigData data = null)
		{
			PhantomSettingType selectType = this.ViewModel.GetSelectType();
			if (data != null)
			{
				this.ViewModel.SetSelectConfig(data, false);
				this.ViewModel.SetSelectIndex(selectType, data.GetIndex(), false);
			}
			else
			{
				List<PhantomManageConfigData> phantomManageConfigByType = ModelBase<InventoryModel>.Instance.GetPhantomManageConfigByType(selectType);
				this.ViewModel.SetSelectConfig(phantomManageConfigByType[0], false);
				this.ViewModel.SetSelectIndex(selectType, 0, false);
			}
			this.EnableConfigScroll = enableScroll;
		}

		// Token: 0x0603B42D RID: 242733 RVA: 0x00F00B10 File Offset: 0x00EFED10
		private void OnClickedBtnConfig(PhantomManageConfigData data)
		{
			PhantomManageConfigData selectConfig = this.ViewModel.GetSelectConfig();
			if (selectConfig.GetIndex() == data.GetIndex() && data.GetType() == selectConfig.GetType())
			{
				return;
			}
			this.IsChangeByClick = true;
			this.SelectConfig(false, data);
		}

		// Token: 0x0603B42E RID: 242734 RVA: 0x00F00B58 File Offset: 0x00EFED58
		private void OnClickedBtnRename()
		{
			PhantomManageConfigData selectConfig = this.ViewModel.GetSelectConfig();
			ControllerBase<CommonInputViewController>.Instance.OpenSetPhantomManageConfigName(selectConfig.GetName(), new Func<string, UniTask<Aki.Protocol.ErrorCode>>(this.OnConfirmRename), "");
		}

		// Token: 0x0603B42F RID: 242735 RVA: 0x00F00B92 File Offset: 0x00EFED92
		private void OnClickedBtnDelete()
		{
			if (this.ViewModel.GetEditState())
			{
				this.OnEditDelete();
				return;
			}
			this.OnDelete();
		}

		// Token: 0x0603B430 RID: 242736 RVA: 0x00F00BB0 File Offset: 0x00EFEDB0
		private void OnEditDelete()
		{
			PhantomManageConfigData config = this.ViewModel.GetSelectConfig();
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomManageConfigEditReset);
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				config.Reset(false, false);
				this.ViewModel.InitEditDataSwitch(config, false);
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603B431 RID: 242737 RVA: 0x00F00C0C File Offset: 0x00EFEE0C
		private void OnDelete()
		{
			PhantomSettingType type = this.ViewModel.GetSelectType();
			PhantomManageConfigData config = this.ViewModel.GetSelectConfig();
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomManageConfigReset);
			Action<bool> <>9__1;
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				PhantomManageConfigData config;
				config.Reset(false, true);
				PhantomManageConfigView <>4__this = this;
				PhantomSettingType type = type;
				config = config;
				bool? forceOn = new bool?(false);
				Action<bool> callback;
				if ((callback = <>9__1) == null)
				{
					callback = (<>9__1 = delegate(bool result)
					{
						this.OnSaveSuccess(result, null);
					});
				}
				<>4__this.RequestSaveDataAsync(type, config, forceOn, callback);
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603B432 RID: 242738 RVA: 0x00F00C78 File Offset: 0x00EFEE78
		private bool OnCheckToggleCanChange(EToggleState state)
		{
			bool editState = this.ViewModel.GetEditState();
			bool flag = this.ViewModel.GetSelectConfig().IsEmpty();
			if (editState)
			{
				Dictionary<int, int[]> editData = this.ViewModel.GetEditData();
				flag = this.CheckIsEmptyData(editData);
			}
			if (state == EToggleState.ETT_UnChecked && flag)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_Tips02", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x0603B433 RID: 242739 RVA: 0x00F00CD8 File Offset: 0x00EFEED8
		private void OnClickedToggleSwitch(EToggleState state)
		{
			if (this.ViewModel.GetEditState())
			{
				Dictionary<int, int[]> editData = this.ViewModel.GetEditData();
				if (state == EToggleState.ETT_Checked && this.CheckIsEmptyData(editData))
				{
					this.SetToggleSwitchEmpty();
					return;
				}
				bool isOn = state == EToggleState.ETT_Checked;
				this.ViewModel.SetEditSwitch(isOn, false);
				return;
			}
			else
			{
				PhantomManageConfigData selectConfig = this.ViewModel.GetSelectConfig();
				if (state == EToggleState.ETT_Checked && selectConfig.IsEmpty())
				{
					this.SetToggleSwitchEmpty();
					return;
				}
				this.OnConfirmSwitch(state);
				return;
			}
		}

		// Token: 0x0603B434 RID: 242740 RVA: 0x00F00D4C File Offset: 0x00EFEF4C
		private void SetToggleSwitchEmpty()
		{
			this.BtnSwitch.SetConfigState(false);
			UUITexture texture = base.GetTexture(12);
			UUIItem uuiitem = texture;
			bool bUseChangeColor = false;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_Tips02", Array.Empty<object>());
		}

		// Token: 0x0603B435 RID: 242741 RVA: 0x00F00D97 File Offset: 0x00EFEF97
		private void OnClickedBtnEdit(int _)
		{
			if (this.ViewModel.GetEditState())
			{
				this.TrySaveEditData();
				return;
			}
			this.ViewModel.SetEditState(true, false);
		}

		// Token: 0x0603B436 RID: 242742 RVA: 0x00F00DBC File Offset: 0x00EFEFBC
		private void TrySaveEditData()
		{
			bool editIsOn = this.ViewModel.GetEditSwitch();
			Dictionary<int, int[]> editData = this.ViewModel.GetEditData();
			PhantomSettingType type = this.ViewModel.GetSelectType();
			PhantomManageConfigData selectConfig = this.ViewModel.GetSelectConfig();
			bool flag = this.CheckIsEmptyData(editData);
			<>f__AnonymousDelegate6<bool, bool?> callbackSave = new <>f__AnonymousDelegate6<bool, bool?>(this.OnSaveSuccess);
			PhantomManageConfigData newConfig = selectConfig.Clone();
			newConfig.SetRuleIdMapValueList(editData);
			if (flag)
			{
				this.RequestSaveDataAsync(type, newConfig, new bool?(false), delegate(bool result)
				{
					callbackSave(result, null);
				});
				return;
			}
			if (!flag & editIsOn)
			{
				this.RequestSaveDataAsync(type, newConfig, new bool?(editIsOn), delegate(bool result)
				{
					callbackSave(result, null);
				});
			}
			if (!flag && !editIsOn)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomManageConfigSaveOn);
				Action<bool> <>9__4;
				confirmBoxDataNew.FunctionMap.Add(2, delegate
				{
					PhantomManageConfigView <>4__this = this;
					PhantomSettingType type = type;
					PhantomManageConfigData newConfig = newConfig;
					bool? forceOn = new bool?(true);
					Action<bool> callback;
					if ((callback = <>9__4) == null)
					{
						callback = (<>9__4 = delegate(bool result)
						{
							callbackSave(result, null);
						});
					}
					<>4__this.RequestSaveDataAsync(type, newConfig, forceOn, callback);
				});
				Action<bool> <>9__5;
				confirmBoxDataNew.FunctionMap.Add(1, delegate
				{
					PhantomManageConfigView <>4__this = this;
					PhantomSettingType type = type;
					PhantomManageConfigData newConfig = newConfig;
					bool? forceOn = new bool?(editIsOn);
					Action<bool> callback;
					if ((callback = <>9__5) == null)
					{
						callback = (<>9__5 = delegate(bool result)
						{
							callbackSave(result, null);
						});
					}
					<>4__this.RequestSaveDataAsync(type, newConfig, forceOn, callback);
				});
				confirmBoxDataNew.IsEscViewTriggerCallBack = false;
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			}
		}

		// Token: 0x0603B437 RID: 242743 RVA: 0x00F00F00 File Offset: 0x00EFF100
		private UniTask RequestSaveDataAsync(PhantomSettingType type, PhantomManageConfigData config, bool? forceOn = null, [Nullable(2)] Action<bool> callback = null)
		{
			PhantomManageConfigView.<RequestSaveDataAsync>d__37 <RequestSaveDataAsync>d__;
			<RequestSaveDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestSaveDataAsync>d__.type = type;
			<RequestSaveDataAsync>d__.config = config;
			<RequestSaveDataAsync>d__.forceOn = forceOn;
			<RequestSaveDataAsync>d__.callback = callback;
			<RequestSaveDataAsync>d__.<>1__state = -1;
			<RequestSaveDataAsync>d__.<>t__builder.Start<PhantomManageConfigView.<RequestSaveDataAsync>d__37>(ref <RequestSaveDataAsync>d__);
			return <RequestSaveDataAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B438 RID: 242744 RVA: 0x00F00F5C File Offset: 0x00EFF15C
		private void OnSaveSuccess(bool success, bool? goCheck = null)
		{
			if (success)
			{
				this.ViewModel.SetEditState(false, false);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_Warning11", Array.Empty<object>());
				if (goCheck.GetValueOrDefault())
				{
					this.OpenManageView();
				}
			}
		}

		// Token: 0x0603B439 RID: 242745 RVA: 0x00F00F94 File Offset: 0x00EFF194
		private bool CheckIsEmptyData(Dictionary<int, int[]> dataList)
		{
			using (Dictionary<int, int[]>.ValueCollection.Enumerator enumerator = dataList.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Length != 0)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0603B43A RID: 242746 RVA: 0x00F00FEC File Offset: 0x00EFF1EC
		private Dictionary<FilterDefine.EFilterType, List<int>> ConvertFilterConfigForSave()
		{
			bool editState = this.ViewModel.GetEditState();
			Dictionary<FilterDefine.EFilterType, List<int>> dictionary = new Dictionary<FilterDefine.EFilterType, List<int>>();
			Dictionary<int, int[]> dictionary2 = this.ViewModel.GetSelectConfig().GetRuleIdMapValueList();
			if (editState)
			{
				dictionary2 = this.ViewModel.GetEditData();
			}
			foreach (KeyValuePair<int, int[]> keyValuePair in dictionary2)
			{
				int filterType = ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(keyValuePair.Key).Value.FilterType;
				dictionary.Add((FilterDefine.EFilterType)filterType, keyValuePair.Value.ToList<int>());
			}
			return dictionary;
		}

		// Token: 0x0603B43B RID: 242747 RVA: 0x00F010A0 File Offset: 0x00EFF2A0
		private void OnClickedBtnPreview(int _)
		{
			if (this.ViewModel.GetEditState())
			{
				this.OnEditPreview();
				return;
			}
			this.OnPreview();
		}

		// Token: 0x0603B43C RID: 242748 RVA: 0x00F010BC File Offset: 0x00EFF2BC
		private void OnEditPreview()
		{
			Dictionary<int, int[]> editData = this.ViewModel.GetEditData();
			if (this.CheckIsEmptyData(editData))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_Tips02", Array.Empty<object>());
				return;
			}
			this.SaveFilterConfigData();
			this.OpenManageView();
		}

		// Token: 0x0603B43D RID: 242749 RVA: 0x00F01100 File Offset: 0x00EFF300
		private void OnPreview()
		{
			PhantomManageConfigData selectConfig = this.ViewModel.GetSelectConfig();
			if (this.CheckIsEmptyData(selectConfig.GetRuleIdMapValueList()))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_Tips02", Array.Empty<object>());
				return;
			}
			this.SaveFilterConfigData();
			this.OpenManageView();
		}

		// Token: 0x0603B43E RID: 242750 RVA: 0x00F01148 File Offset: 0x00EFF348
		private void SaveFilterConfigData()
		{
			int filterIdConst = ModelBase<InventoryModel>.Instance.GetFilterIdConst();
			FilterStorageData data = new FilterStorageData
			{
				ConfigId = filterIdConst,
				SelectRuleMap = this.ConvertFilterConfigForSave()
			};
			ModelBase<FilterModel>.Instance.SetFilterConfigData(EFilterSortConfigId.PhantomManage, 43, data, "");
		}

		// Token: 0x0603B43F RID: 242751 RVA: 0x00F0118C File Offset: 0x00EFF38C
		private void QuitEditState()
		{
			PhantomManageConfigData selectConfig = this.ViewModel.GetSelectConfig();
			this.ViewModel.InitEditDataSwitch(selectConfig, true);
			this.ViewModel.SetEditState(false, false);
		}

		// Token: 0x0603B440 RID: 242752 RVA: 0x00F011C0 File Offset: 0x00EFF3C0
		private void OpenManageView()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomManageView) || Singleton<UiManager>.Instance.IsViewHide(EUiViewName.PhantomManageView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.PhantomManageView, new Action<bool>(this.OnCloseManageView));
				return;
			}
			this.OnCloseManageView(true);
		}

		// Token: 0x0603B441 RID: 242753 RVA: 0x00F01212 File Offset: 0x00EFF412
		private void OnCloseManageView(bool success)
		{
			if (success)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomManageView, null, null);
			}
		}

		// Token: 0x0603B442 RID: 242754 RVA: 0x00F01228 File Offset: 0x00EFF428
		private void OnClickedBtnQuitEdit()
		{
			PhantomManageConfigData selectConfig = this.ViewModel.GetSelectConfig();
			Dictionary<int, int[]> editData = this.ViewModel.GetEditData();
			bool editSwitch = this.ViewModel.GetEditSwitch();
			if (selectConfig.IsEqual(editSwitch, editData))
			{
				this.QuitEditState();
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomManageConfigQuitEdit);
			confirmBoxDataNew.FunctionMap.Add(2, new Action(this.QuitEditState));
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603B443 RID: 242755 RVA: 0x00F012A0 File Offset: 0x00EFF4A0
		private void OnClickedBtnRecommend()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.UsePhantomManagePlanConfirm);
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				IEnumerable<PhantomManagePlanConfig> configList = ConfigPhantomManagePlanConfigAll.GetConfigList(true);
				List<PhantomSettingInfo> list = new List<PhantomSettingInfo>();
				foreach (PhantomManagePlanConfig phantomManagePlanConfig in configList)
				{
					PhantomSettingInfo phantomSettingInfo = PhantomSettingInfo.Create();
					phantomSettingInfo.SettingType = (PhantomSettingType)phantomManagePlanConfig.Type;
					List<OneItemFilterRule> list2 = new List<OneItemFilterRule>();
					foreach (KeyValuePair<int, IntArray> keyValuePair in phantomManagePlanConfig.RuleMap())
					{
						OneItemFilterRule oneItemFilterRule = OneItemFilterRule.Create();
						oneItemFilterRule.FilterRuleId = keyValuePair.Key;
						oneItemFilterRule.IdList.AddRange(keyValuePair.Value.GetArrayIntArray());
						list2.Add(oneItemFilterRule);
					}
					OnePhantomSetting onePhantomSetting = OnePhantomSetting.Create();
					onePhantomSetting.Index = phantomManagePlanConfig.SlotIndex;
					onePhantomSetting.On = phantomManagePlanConfig.IsEnable;
					onePhantomSetting.Name = ConfigMultiTextLang.GetLocalTextNew(phantomManagePlanConfig.Name, null);
					onePhantomSetting.RuleList.AddRange(list2);
					phantomSettingInfo.Setting = onePhantomSetting;
					list.Add(phantomSettingInfo);
				}
				ControllerBase<InventoryController>.Instance.PhantomSettingBatchUpdateRequestAsync(list.ToArray()).ContinueWith(delegate(bool result)
				{
					if (result)
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_Warning12", Array.Empty<object>());
						this.RefreshConfig();
						this.RefreshTitle();
						this.RefreshSetting();
						this.SelectConfig(true, null);
					}
				});
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603B444 RID: 242756 RVA: 0x00F012DC File Offset: 0x00EFF4DC
		[NullableContext(0)]
		private UniTask<Aki.Protocol.ErrorCode> OnConfirmRename([Nullable(1)] string input)
		{
			PhantomManageConfigView.<OnConfirmRename>d__50 <OnConfirmRename>d__;
			<OnConfirmRename>d__.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
			<OnConfirmRename>d__.<>4__this = this;
			<OnConfirmRename>d__.input = input;
			<OnConfirmRename>d__.<>1__state = -1;
			<OnConfirmRename>d__.<>t__builder.Start<PhantomManageConfigView.<OnConfirmRename>d__50>(ref <OnConfirmRename>d__);
			return <OnConfirmRename>d__.<>t__builder.Task;
		}

		// Token: 0x0603B445 RID: 242757 RVA: 0x00F01328 File Offset: 0x00EFF528
		private UniTask OnConfirmSwitch(EToggleState state)
		{
			PhantomManageConfigView.<OnConfirmSwitch>d__51 <OnConfirmSwitch>d__;
			<OnConfirmSwitch>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnConfirmSwitch>d__.<>4__this = this;
			<OnConfirmSwitch>d__.state = state;
			<OnConfirmSwitch>d__.<>1__state = -1;
			<OnConfirmSwitch>d__.<>t__builder.Start<PhantomManageConfigView.<OnConfirmSwitch>d__51>(ref <OnConfirmSwitch>d__);
			return <OnConfirmSwitch>d__.<>t__builder.Task;
		}

		// Token: 0x0603B446 RID: 242758 RVA: 0x00F01373 File Offset: 0x00EFF573
		private PhantomManageConfigTypeItem CreateTypeItem()
		{
			return new PhantomManageConfigTypeItem();
		}

		// Token: 0x0603B447 RID: 242759 RVA: 0x00F0137A File Offset: 0x00EFF57A
		private PhantomManageConfigItem CreateConfigItem()
		{
			return new PhantomManageConfigItem();
		}

		// Token: 0x0603B448 RID: 242760 RVA: 0x00F01381 File Offset: 0x00EFF581
		private PhantomManageSettingTitleItem CreateSettingTitleItem()
		{
			return new PhantomManageSettingTitleItem();
		}

		// Token: 0x0402167C RID: 136828
		[Nullable(2)]
		private PhantomManageConfigViewModel ViewModel;

		// Token: 0x0402167D RID: 136829
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<PhantomManageConfigTypeItem, InventoryDefine.IManageConfigTypeItemData> LayoutType;

		// Token: 0x0402167E RID: 136830
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<PhantomManageConfigItem, PhantomManageConfigData> ScrollConfig;

		// Token: 0x0402167F RID: 136831
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<PhantomManageSettingTitleItem, InventoryDefine.IManageConfigTitleItemData> ScrollSetting;

		// Token: 0x04021680 RID: 136832
		[Nullable(2)]
		private UUIInturnAnimController InturnAniConfig;

		// Token: 0x04021681 RID: 136833
		[Nullable(2)]
		private UUIInturnAnimController InturnAniSetting;

		// Token: 0x04021682 RID: 136834
		[Nullable(2)]
		private ButtonItem BtnEdit;

		// Token: 0x04021683 RID: 136835
		[Nullable(2)]
		private ButtonItem BtnPreview;

		// Token: 0x04021684 RID: 136836
		[Nullable(2)]
		private ToggleSwitch BtnSwitch;

		// Token: 0x04021685 RID: 136837
		private bool IsChangeByClick;

		// Token: 0x04021686 RID: 136838
		private bool EnableConfigScroll = true;

		// Token: 0x0200BBAD RID: 48045
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04039EAA RID: 237226
			public const int LayoutType = 0;

			// Token: 0x04039EAB RID: 237227
			public const int ScrollConfig = 1;

			// Token: 0x04039EAC RID: 237228
			public const int ItemConfig = 2;

			// Token: 0x04039EAD RID: 237229
			public const int PanelMask = 3;

			// Token: 0x04039EAE RID: 237230
			public const int TextName = 4;

			// Token: 0x04039EAF RID: 237231
			public const int BtnRename = 5;

			// Token: 0x04039EB0 RID: 237232
			public const int ItemSwitch = 6;

			// Token: 0x04039EB1 RID: 237233
			public const int ScrollSetting = 7;

			// Token: 0x04039EB2 RID: 237234
			public const int ItemSetting = 8;

			// Token: 0x04039EB3 RID: 237235
			public const int BtnDelete = 9;

			// Token: 0x04039EB4 RID: 237236
			public const int BtnPreview = 10;

			// Token: 0x04039EB5 RID: 237237
			public const int BtnEdit = 11;

			// Token: 0x04039EB6 RID: 237238
			public const int TextureSwitch = 12;

			// Token: 0x04039EB7 RID: 237239
			public const int BtnQuitEdit = 13;

			// Token: 0x04039EB8 RID: 237240
			public const int BtnRecommend = 14;
		}
	}
}
