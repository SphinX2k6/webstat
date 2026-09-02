using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.Views
{
	// Token: 0x02005771 RID: 22385
	[NullableContext(1)]
	[Nullable(0)]
	public class MenuScrollSettingContainerItem : UiPanelBase, IDynamicScrollItem<MenuScrollItemData>
	{
		// Token: 0x06038F66 RID: 233318 RVA: 0x00E6EB94 File Offset: 0x00E6CD94
		public UniTask Init(UUIItem actor)
		{
			MenuScrollSettingContainerItem.<Init>d__8 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MenuScrollSettingContainerItem.<Init>d__8>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038F67 RID: 233319 RVA: 0x00E6EBE0 File Offset: 0x00E6CDE0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x06038F68 RID: 233320 RVA: 0x00E6ECF7 File Offset: 0x00E6CEF7
		protected override void OnStart()
		{
			if (this.LevelSequencePlayer == null)
			{
				this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			}
			this.AddEventListener();
		}

		// Token: 0x06038F69 RID: 233321 RVA: 0x00E6ED18 File Offset: 0x00E6CF18
		protected void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<EFunction>(EEventName.RefreshMenuSetting, new Action<EFunction>(this.OnRefreshMenuSetting));
			base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
			base.GetExtendToggle(0).OnUndeterminedClicked.Add(new Action(this.OnUndeterminedClicked));
		}

		// Token: 0x06038F6A RID: 233322 RVA: 0x00E6ED7B File Offset: 0x00E6CF7B
		protected void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshMenuSetting, new Action<EFunction>(this.OnRefreshMenuSetting));
			base.GetExtendToggle(0).OnUndeterminedClicked.Clear();
			base.GetExtendToggle(0).OnStateChange.Clear();
		}

		// Token: 0x06038F6B RID: 233323 RVA: 0x00E6EDBC File Offset: 0x00E6CFBC
		private void OnUndeterminedClicked()
		{
			if (this.Data == null || !this.Data.CanClickWhenDisable || this.Data.GetEnable())
			{
				return;
			}
			if (!this.Data.GetIsDetailTextVisible())
			{
				this.SetDetailVisible(true);
				return;
			}
			this.SetDetailVisible(false);
		}

		// Token: 0x06038F6C RID: 233324 RVA: 0x00E6EE08 File Offset: 0x00E6D008
		private void OnToggleStateChange(EToggleState state)
		{
			if (this.Data == null)
			{
				return;
			}
			if (this.Data.GetDetailPopId() > 0)
			{
				Action<MenuScrollSettingContainerItem> onDetailPopOpenCallback = this.OnDetailPopOpenCallback;
				if (onDetailPopOpenCallback != null)
				{
					onDetailPopOpenCallback(this);
				}
				base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				return;
			}
			if (state == EToggleState.ETT_Checked)
			{
				this.TryShowClickedTips();
			}
			if (this.OnToggleStateChangedCallback != null)
			{
				this.OnToggleStateChangedCallback(this, state);
			}
		}

		// Token: 0x06038F6D RID: 233325 RVA: 0x00E6EE6F File Offset: 0x00E6D06F
		public void BindOnToggleStateChangedCallback(Action<MenuScrollSettingContainerItem, EToggleState> onToggleReleasedCallback)
		{
			this.OnToggleStateChangedCallback = onToggleReleasedCallback;
		}

		// Token: 0x06038F6E RID: 233326 RVA: 0x00E6EE78 File Offset: 0x00E6D078
		public void BindOnDetailPopOpenCallback(Action<MenuScrollSettingContainerItem> onDetailPopOpenCallback)
		{
			this.OnDetailPopOpenCallback = onDetailPopOpenCallback;
		}

		// Token: 0x06038F6F RID: 233327 RVA: 0x00E6EE84 File Offset: 0x00E6D084
		private void TryShowClickedTips()
		{
			if (this.Data == null)
			{
				return;
			}
			string clickedTips = this.Data.ClickedTips;
			if (string.IsNullOrEmpty(clickedTips))
			{
				return;
			}
			MenuModel instance = ModelBase<MenuModel>.Instance;
			foreach (KeyValuePair<int, int> keyValuePair in this.Data.ClickedTipsMap)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (instance.IsInMenuDataByFunctionId((EFunction)key))
				{
					int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue((EFunction)key, true, true);
					int num = value;
					if (currentValue.GetValueOrDefault() == num & currentValue != null)
					{
						ControllerBase<GenericPromptController>.Instance.ShowPromptByCode(clickedTips, Array.Empty<object>());
						break;
					}
				}
			}
		}

		// Token: 0x06038F70 RID: 233328 RVA: 0x00E6EF50 File Offset: 0x00E6D150
		protected override void OnBeforeDestroy()
		{
			this.RemoveEventListener();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
			MenuScrollSettingBaseItem currentItem = this.CurrentItem;
			if (currentItem != null)
			{
				currentItem.ClearItem();
			}
			this.CurrentItem = null;
			this.OnToggleStateChangedCallback = null;
			this.OnDetailPopOpenCallback = null;
			this.ClearData();
		}

		// Token: 0x06038F71 RID: 233329 RVA: 0x00E6EFA7 File Offset: 0x00E6D1A7
		public void ClearItem()
		{
			this.ClearData();
		}

		// Token: 0x06038F72 RID: 233330 RVA: 0x00E6EFAF File Offset: 0x00E6D1AF
		private void ClearData()
		{
			if (this.VectorValue != null)
			{
				this.VectorValue = null;
			}
			if (this.Type != null)
			{
				this.Type = null;
			}
			if (this.Data != null)
			{
				this.Data = null;
			}
			this.MenuScrollItemData = null;
		}

		// Token: 0x06038F73 RID: 233331 RVA: 0x00E6EFF0 File Offset: 0x00E6D1F0
		[return: Nullable(2)]
		public AUIBaseActor GetUsingItem(MenuScrollItemData itemData)
		{
			UUIItem uuiitem = null;
			if (itemData.Type == EMenuScrollItemType.TitleItem)
			{
				uuiitem = base.GetItem(1);
				if (uuiitem == null)
				{
					return null;
				}
				return uuiitem.GetOwner() as AUIBaseActor;
			}
			else
			{
				switch (itemData.Data.SetType)
				{
				case ESetType.SLIDER:
				{
					MenuData data = itemData.Data;
					uuiitem = ((data != null && data.NeedScale) ? base.GetItem(9) : base.GetItem(4));
					break;
				}
				case ESetType.OPTIONS:
				{
					MenuData data2 = itemData.Data;
					uuiitem = ((data2 != null && data2.NeedScale) ? base.GetItem(8) : base.GetItem(3));
					break;
				}
				case ESetType.KEYMAP:
				{
					MenuData data3 = itemData.Data;
					uuiitem = ((data3 != null && data3.NeedScale) ? base.GetItem(7) : base.GetItem(2));
					break;
				}
				case ESetType.BUTTON:
				{
					MenuData data4 = itemData.Data;
					uuiitem = ((data4 != null && data4.NeedScale) ? base.GetItem(7) : base.GetItem(2));
					break;
				}
				case ESetType.DROPDOWN:
				{
					MenuData data5 = itemData.Data;
					uuiitem = ((data5 != null && data5.NeedScale) ? base.GetItem(10) : base.GetItem(5));
					break;
				}
				}
				if (uuiitem == null)
				{
					return null;
				}
				return uuiitem.GetOwner() as AUIBaseActor;
			}
		}

		// Token: 0x06038F74 RID: 233332 RVA: 0x00E6F123 File Offset: 0x00E6D323
		public void Update(MenuScrollItemData itemData, int index)
		{
			this.Type = new EMenuScrollItemType?(itemData.Type);
			this.Data = itemData.Data;
			this.MenuScrollItemData = itemData;
			this.ResetItemActive();
			this.HandleCurrentItem(itemData).Forget();
		}

		// Token: 0x06038F75 RID: 233333 RVA: 0x00E6F15C File Offset: 0x00E6D35C
		private UniTask HandleCurrentItem(MenuScrollItemData itemData)
		{
			MenuScrollSettingContainerItem.<HandleCurrentItem>d__23 <HandleCurrentItem>d__;
			<HandleCurrentItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleCurrentItem>d__.<>4__this = this;
			<HandleCurrentItem>d__.itemData = itemData;
			<HandleCurrentItem>d__.<>1__state = -1;
			<HandleCurrentItem>d__.<>t__builder.Start<MenuScrollSettingContainerItem.<HandleCurrentItem>d__23>(ref <HandleCurrentItem>d__);
			return <HandleCurrentItem>d__.<>t__builder.Task;
		}

		// Token: 0x06038F76 RID: 233334 RVA: 0x00E6F1A8 File Offset: 0x00E6D3A8
		private void RefreshItem(MenuScrollSettingBaseItem item, MenuScrollItemData itemData)
		{
			if (item == null)
			{
				return;
			}
			MenuData data = itemData.Data;
			item.SetActive(true);
			item.ExecuteUpdate(data, false);
			if (itemData.Type != EMenuScrollItemType.TitleItem)
			{
				this.SetItemInteractionActive(data.GetEnable());
			}
			else
			{
				this.SetItemInteractionActive(false);
			}
			if ((data.HasDetailText() || data.GetDetailPopId() > 0) && data.GetEnable())
			{
				UUIExtendToggle extendToggle = base.GetExtendToggle(0);
				if (extendToggle == null)
				{
					return;
				}
				extendToggle.SetToggleState((data != null && data.GetIsDetailTextVisible()) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
		}

		// Token: 0x06038F77 RID: 233335 RVA: 0x00E6F230 File Offset: 0x00E6D430
		[return: Nullable(2)]
		private MenuScrollSettingBaseItem GetCreateScrollItem(MenuScrollItemData itemData)
		{
			if (itemData.Type == EMenuScrollItemType.TitleItem)
			{
				return this.CreateScrollItem<MenuScrollSettingTitleItem>(1, () => new MenuScrollSettingTitleItem());
			}
			switch (itemData.Data.SetType)
			{
			case ESetType.SLIDER:
			{
				MenuData data = itemData.Data;
				return this.CreateScrollItem<MenuScrollSettingSliderItem>((data != null && data.NeedScale) ? 9 : 4, () => new MenuScrollSettingSliderItem());
			}
			case ESetType.OPTIONS:
			{
				MenuData data2 = itemData.Data;
				return this.CreateScrollItem<MenuScrollSettingSwitchItem>((data2 != null && data2.NeedScale) ? 8 : 3, () => new MenuScrollSettingSwitchItem());
			}
			case ESetType.BUTTON:
			{
				MenuData data3 = itemData.Data;
				return this.CreateScrollItem<MenuScrollSettingButtonItem>((data3 != null && data3.NeedScale) ? 7 : 2, () => new MenuScrollSettingButtonItem());
			}
			case ESetType.DROPDOWN:
			{
				MenuData data4 = itemData.Data;
				return this.CreateScrollItem<MenuScrollSettingDropDown>((data4 != null && data4.NeedScale) ? 10 : 5, () => new MenuScrollSettingDropDown());
			}
			}
			return null;
		}

		// Token: 0x06038F78 RID: 233336 RVA: 0x00E6F394 File Offset: 0x00E6D594
		private TItem CreateScrollItem<[Nullable(0)] TItem>(int name, Func<TItem> alloc) where TItem : MenuScrollSettingBaseItem
		{
			TItem titem = alloc();
			titem.Initialize(base.GetItem(name), new Action<int>(this.FireSaveMenuChange), new Action<string>(this.PlayLevelSequenceByName));
			return titem;
		}

		// Token: 0x06038F79 RID: 233337 RVA: 0x00E6F3C8 File Offset: 0x00E6D5C8
		private void RefreshData()
		{
			if (this.CurrentItem != null)
			{
				this.CurrentItem.ExecuteUpdate(this.Data, true);
				MenuScrollItemData menuScrollItemData = this.MenuScrollItemData;
				if (menuScrollItemData == null || menuScrollItemData.Type > EMenuScrollItemType.TitleItem)
				{
					this.SetItemInteractionActive(this.Data.GetEnable());
					return;
				}
				this.SetItemInteractionActive(false);
			}
		}

		// Token: 0x06038F7A RID: 233338 RVA: 0x00E6F420 File Offset: 0x00E6D620
		private void ResetItemActive()
		{
			base.GetItem(1).SetUIActive(false);
			base.GetItem(4).SetUIActive(false);
			base.GetItem(3).SetUIActive(false);
			base.GetItem(2).SetUIActive(false);
			base.GetItem(5).SetUIActive(false);
			base.GetItem(9).SetUIActive(false);
			base.GetItem(8).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			base.GetItem(10).SetUIActive(false);
		}

		// Token: 0x06038F7B RID: 233339 RVA: 0x00E6F4A4 File Offset: 0x00E6D6A4
		private void OnRefreshMenuSetting(EFunction functionId)
		{
			if (this.Data == null)
			{
				return;
			}
			if (this.Data.FunctionId == functionId)
			{
				this.RefreshData();
			}
		}

		// Token: 0x06038F7C RID: 233340 RVA: 0x00E6F4C4 File Offset: 0x00E6D6C4
		private void SetItemInteractionActive(bool isActive)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (isActive)
			{
				if (extendToggle.GetToggleState() == EToggleState.ETT_Checked)
				{
					extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				}
				else
				{
					extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				}
				extendToggle.SetSelfInteractive(true);
			}
			else
			{
				MenuScrollItemData menuScrollItemData = this.MenuScrollItemData;
				bool selfInteractive = menuScrollItemData == null || menuScrollItemData.Type > EMenuScrollItemType.TitleItem;
				extendToggle.SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
				extendToggle.SetSelfInteractive(selfInteractive);
			}
			EMenuScrollItemType? type = this.Type;
			EMenuScrollItemType emenuScrollItemType = EMenuScrollItemType.TitleItem;
			if (type.GetValueOrDefault() == emenuScrollItemType & type != null)
			{
				return;
			}
			if (this.CurrentItem != null)
			{
				this.CurrentItem.SetInteractionActive(isActive);
				if (!isActive)
				{
					MenuData data = this.Data;
					if (data != null && data.CanClickWhenDisable)
					{
						this.SetDetailVisible(this.Data.GetIsDetailTextVisible());
						return;
					}
				}
				if (!isActive)
				{
					this.CurrentItem.SetDetailVisible(false);
				}
			}
		}

		// Token: 0x06038F7D RID: 233341 RVA: 0x00E6F598 File Offset: 0x00E6D798
		private void PlayLevelSequenceByName(string val)
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName(val, false, null, false);
		}

		// Token: 0x06038F7E RID: 233342 RVA: 0x00E6F5BC File Offset: 0x00E6D7BC
		private void FireSaveMenuChange(int val)
		{
			if (this.Data.FunctionId == EFunction.RayTracing)
			{
				this.TryPlayConfirmBoxForRayTracing(val);
				return;
			}
			if (this.Data.FunctionId == EFunction.NVIDIADLSSFG)
			{
				this.TryPlayConfirmBoxForDlssFg(val);
				return;
			}
			if (this.Data.FunctionId == EFunction.Vulkan)
			{
				this.TryPlayConfirmBoxForVulkan(val);
				return;
			}
			if (this.Data.FunctionId == EFunction.HIGHESTFPS)
			{
				this.TryPlayConfirmBoxForHighestFps(val);
				return;
			}
			if (this.Data.FunctionId == EFunction.HDR)
			{
				this.TryPlayConfirmBoxForHdr(val);
				return;
			}
			if (this.Data.FunctionId == EFunction.AnisoLevel)
			{
				this.TryPlayConfirmBoxForAnisoLevel(val);
				return;
			}
			ControllerBase<MenuController>.Instance.HandleFireSaveMenuChange(this.Data, val);
		}

		// Token: 0x06038F7F RID: 233343 RVA: 0x00E6F670 File Offset: 0x00E6D870
		private void BuildThenShowConfirmBoxForRayTracing(EConfirmBoxConfigId confirmBoxId)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(confirmBoxId);
			confirmBoxDataNew.FunctionMap.Add(1, delegate
			{
				ControllerBase<MenuController>.Instance.HandleFireSaveMenuChange(this.Data, 0);
			});
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				ControllerBase<MenuController>.Instance.HandleFireSaveMenuChange(this.Data, 0);
			});
			confirmBoxDataNew.SetCloseFunction(delegate
			{
				ControllerBase<MenuController>.Instance.HandleFireSaveMenuChange(this.Data, 0);
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06038F80 RID: 233344 RVA: 0x00E6F6D4 File Offset: 0x00E6D8D4
		private void TryPlayConfirmBoxForRayTracing(int targetValue)
		{
			if (Singleton<GameSettingsDeviceRender>.Instance.IsDxr1_1NotSupported() && targetValue > 0)
			{
				this.BuildThenShowConfirmBoxForRayTracing(EConfirmBoxConfigId.Dxr1_1NotSupported);
				return;
			}
			if (Singleton<GameSettingsDeviceRender>.Instance.IsDriverNeedUpdateForRayTracing() && targetValue > 0)
			{
				this.BuildThenShowConfirmBoxForRayTracing(EConfirmBoxConfigId.GpuDriverVersionLowForRayTracing);
				return;
			}
			int? dataCacheOrCurValue = ModelBase<MenuModel>.Instance.GetDataCacheOrCurValue(this.Data.FunctionId);
			ModelBase<MenuModel>.Instance.NeedRayTracingSubChange = ((dataCacheOrCurValue + targetValue).GetValueOrDefault() == 1);
			int? num = dataCacheOrCurValue;
			int num2 = 0;
			if ((num.GetValueOrDefault() == num2 & num != null) && targetValue == 1 && !ModelBase<MenuModel>.Instance.IsRayTracingOpenChecked)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RayTracingOn);
				confirmBoxDataNew.FunctionMap.Add(2, delegate
				{
					ModelBase<MenuModel>.Instance.IsRayTracingOpenChecked = true;
					ControllerBase<MenuController>.Instance.HandleFireSaveMenuChange(this.Data, targetValue);
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			ControllerBase<MenuController>.Instance.HandleFireSaveMenuChange(this.Data, targetValue);
		}

		// Token: 0x06038F81 RID: 233345 RVA: 0x00E6F808 File Offset: 0x00E6DA08
		private void TryPlayConfirmBoxForDlssFg(int targetValue)
		{
			if (targetValue > 0 && Singleton<GameSettingsDeviceRender>.Instance.IsDlss3HardwareSchedulingDisabled())
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DlssFrameGenerateInvalid);
				confirmBoxDataNew.FunctionMap.Add(1, delegate
				{
					ControllerBase<MenuController>.Instance.HandleFireSaveMenuChange(this.Data, 0);
				});
				confirmBoxDataNew.FunctionMap.Add(2, delegate
				{
					ControllerBase<MenuController>.Instance.HandleFireSaveMenuChange(this.Data, 0);
				});
				confirmBoxDataNew.SetCloseFunction(delegate
				{
					ControllerBase<MenuController>.Instance.HandleFireSaveMenuChange(this.Data, 0);
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			ControllerBase<MenuController>.Instance.HandleFireSaveMenuChange(this.Data, targetValue);
		}

		// Token: 0x06038F82 RID: 233346 RVA: 0x00E6F890 File Offset: 0x00E6DA90
		private void TryPlayConfirmBoxForHdr(int targetValue)
		{
			ControllerBase<MenuController>.Instance.HandleFireSaveMenuChange(this.Data, targetValue);
		}

		// Token: 0x06038F83 RID: 233347 RVA: 0x00E6F8A4 File Offset: 0x00E6DAA4
		private void TryPlayConfirmBoxForAnisoLevel(int targetValue)
		{
			if (targetValue > 0 && !ModelBase<MenuModel>.Instance.IsAnisoLevelOpenChecked)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RayTracingOn);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				ModelBase<MenuModel>.Instance.IsAnisoLevelOpenChecked = true;
			}
			ControllerBase<MenuController>.Instance.HandleFireSaveMenuChange(this.Data, targetValue);
		}

		// Token: 0x06038F84 RID: 233348 RVA: 0x00E6F8F4 File Offset: 0x00E6DAF4
		private void TryPlayConfirmBoxForVulkan(int targetValue)
		{
			if (targetValue > 0 && !ModelBase<MenuModel>.Instance.IsVulkanOpenChecked)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.VulkanOn);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				ModelBase<MenuModel>.Instance.IsVulkanOpenChecked = true;
			}
			ControllerBase<MenuController>.Instance.HandleFireSaveMenuChange(this.Data, targetValue);
		}

		// Token: 0x06038F85 RID: 233349 RVA: 0x00E6F944 File Offset: 0x00E6DB44
		private void TryPlayConfirmBoxForHighestFps(int targetValue)
		{
			if (ControllerBase<MenuController>.Instance.NeedRedMagicFpsConfirmBox(targetValue))
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RedMagic90Fps);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			}
			ControllerBase<MenuController>.Instance.HandleFireSaveMenuChange(this.Data, targetValue);
		}

		// Token: 0x06038F86 RID: 233350 RVA: 0x00E6F986 File Offset: 0x00E6DB86
		public void SetDetailVisible(bool bVisible)
		{
			if (this.CurrentItem == null)
			{
				return;
			}
			this.CurrentItem.SetDetailVisible(bVisible);
		}

		// Token: 0x06038F87 RID: 233351 RVA: 0x00E6F99D File Offset: 0x00E6DB9D
		[NullableContext(2)]
		public MenuData GetMenuData()
		{
			return this.Data;
		}

		// Token: 0x06038F88 RID: 233352 RVA: 0x00E6F9A5 File Offset: 0x00E6DBA5
		public void SetSelected(bool bSelected)
		{
			if (bSelected)
			{
				UUIExtendToggle extendToggle = base.GetExtendToggle(0);
				if (extendToggle == null)
				{
					return;
				}
				extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				return;
			}
			else
			{
				UUIExtendToggle extendToggle2 = base.GetExtendToggle(0);
				if (extendToggle2 == null)
				{
					return;
				}
				extendToggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				return;
			}
		}

		// Token: 0x040206F6 RID: 132854
		public EMenuScrollItemType? Type;

		// Token: 0x040206F7 RID: 132855
		[Nullable(2)]
		private MenuData Data;

		// Token: 0x040206F8 RID: 132856
		[Nullable(2)]
		public MenuScrollItemData MenuScrollItemData;

		// Token: 0x040206F9 RID: 132857
		[Nullable(2)]
		private Vector2D VectorValue;

		// Token: 0x040206FA RID: 132858
		[Nullable(2)]
		private MenuScrollSettingBaseItem CurrentItem;

		// Token: 0x040206FB RID: 132859
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040206FC RID: 132860
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<MenuScrollSettingContainerItem, EToggleState> OnToggleStateChangedCallback;

		// Token: 0x040206FD RID: 132861
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<MenuScrollSettingContainerItem> OnDetailPopOpenCallback;
	}
}
