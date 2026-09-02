using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Menu.KeySettingsView;
using CSharpScript.Game.Module.Menu.Views;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x0200576C RID: 22380
	[NullableContext(1)]
	[Nullable(0)]
	public class MenuView : UiViewBase
	{
		// Token: 0x17009195 RID: 37269
		// (get) Token: 0x06038F0A RID: 233226 RVA: 0x00E6CB03 File Offset: 0x00E6AD03
		public MenuViewData MenuViewDataExternal
		{
			get
			{
				return this.MenuViewData;
			}
		}

		// Token: 0x06038F0B RID: 233227 RVA: 0x00E6CB0B File Offset: 0x00E6AD0B
		public MenuView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038F0C RID: 233228 RVA: 0x00E6CB38 File Offset: 0x00E6AD38
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIDynScrollViewComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(6, new Action(this.MobileSwitchTouch))
			};
		}

		// Token: 0x06038F0D RID: 233229 RVA: 0x00E6CC50 File Offset: 0x00E6AE50
		protected override void OnStart()
		{
			if (Singleton<CloudGameManager>.Instance.IsCloudGame || Singleton<Info>.Instance.IsHomeConsolePlatform())
			{
				UUIItem item = base.GetItem(9);
				if (item != null)
				{
					item.SetUIActive(false);
				}
			}
			else
			{
				this.ApplyBtnItem = new ButtonItem(base.GetItem(9));
				this.ApplyBtnItem.SetFunction(new Action<int>(this.OnClickApplyBtn));
				this.RefreshApplyBtn();
			}
			this.TabComponent.SelectToggleByIndex(0, true);
			UUIButtonComponent button = base.GetButton(6);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(Singleton<Info>.Instance.IsMobileInputModel() && Singleton<Info>.Instance.IsInGamepad() && Singleton<GameSettingsManager>.Instance.IsGameSettingsAppliedOnOpenLoading);
			}
			ModelBase<MenuModel>.Instance.HasApplyRecommendData = false;
		}

		// Token: 0x06038F0E RID: 233230 RVA: 0x00E6CD18 File Offset: 0x00E6AF18
		protected override void OnBeforeDestroy()
		{
			if (this.TabComponent != null)
			{
				this.TabComponent.Destroy(null);
				this.TabComponent = null;
			}
			if (this.ScrollItemPool != null)
			{
				this.ScrollItemPool.Clear();
			}
			if (this.MenuInfoDataArray != null)
			{
				this.MenuInfoDataArray.Clear();
			}
			if (this.ScrollView != null)
			{
				this.ScrollView.ClearChildren();
				this.ScrollView = null;
			}
			if (this.MenuScrollSettingContainerDynItem != null)
			{
				this.MenuScrollSettingContainerDynItem = null;
			}
			MenuModel instance = ModelBase<MenuModel>.Instance;
			if (instance.IsEdited)
			{
				ControllerBase<MenuController>.Instance.ReportSettingMenuLogEvent();
				instance.IsEdited = false;
			}
			instance.IsImageQualityCustomNullable = null;
			this.RemoveNextScrollToButtonTimerHandle();
			instance.ClearMenuDataMap();
			instance.HasApplyRecommendData = false;
		}

		// Token: 0x06038F0F RID: 233231 RVA: 0x00E6CDD0 File Offset: 0x00E6AFD0
		protected override UniTask OnBeforeStartAsync()
		{
			MenuView.<OnBeforeStartAsync>d__24 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MenuView.<OnBeforeStartAsync>d__24>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038F10 RID: 233232 RVA: 0x00E6CE14 File Offset: 0x00E6B014
		[NullableContext(2)]
		private TMenuItemFilter GetItemFilterByOpenScene(EMenuViewOpenScene? openScene)
		{
			EMenuViewOpenScene valueOrDefault = openScene.GetValueOrDefault();
			if (valueOrDefault != EMenuViewOpenScene.Default && valueOrDefault == EMenuViewOpenScene.Login)
			{
				return (MenuData data) => data.CanShowInLogin;
			}
			return null;
		}

		// Token: 0x06038F11 RID: 233233 RVA: 0x00E6CE51 File Offset: 0x00E6B051
		private MenuScrollItemData Creator()
		{
			return new MenuScrollItemData();
		}

		// Token: 0x06038F12 RID: 233234 RVA: 0x00E6CE58 File Offset: 0x00E6B058
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnDropDownListVisibleChanged, new Action<bool>(this.OnDropDownListVisibleChanged));
			Singleton<EventSystem>.Instance.Add<string, string>(EEventName.TextLanguageChange, new Action<string, string>(this.RefreshTextLanguage));
			Singleton<EventSystem>.Instance.Add<EFunction>(EEventName.RefreshMenuSetting, new Action<EFunction>(this.OnRefreshMenuSetting));
			if (Singleton<Platform>.Instance.IsMobilePlatform() || Singleton<Platform>.Instance.IsPcPlatform())
			{
				Singleton<EventSystem>.Instance.Add<bool>(EEventName.ConfigLoadChange, new Action<bool>(this.RefreshGameQualityLoad));
			}
			UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
			if (gameUserSettings == null)
			{
				return;
			}
			gameUserSettings.OnGameUserSettingsUINeedsUpdate.Add(new Action(ControllerBase<GameSettingsController>.Instance.OnGameUserSettingsUINeedsUpdate));
		}

		// Token: 0x06038F13 RID: 233235 RVA: 0x00E6CF14 File Offset: 0x00E6B114
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnDropDownListVisibleChanged, new Action<bool>(this.OnDropDownListVisibleChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.TextLanguageChange, new Action<string, string>(this.RefreshTextLanguage));
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshMenuSetting, new Action<EFunction>(this.OnRefreshMenuSetting));
			if (Singleton<Platform>.Instance.IsMobilePlatform() || Singleton<Platform>.Instance.IsPcPlatform())
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.ConfigLoadChange, new <>f__AnonymousDelegate8<bool>(this.RefreshGameQualityLoad));
			}
			UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
			if (gameUserSettings == null)
			{
				return;
			}
			gameUserSettings.OnGameUserSettingsUINeedsUpdate.Remove(new Action(ControllerBase<GameSettingsController>.Instance.OnGameUserSettingsUINeedsUpdate));
		}

		// Token: 0x06038F14 RID: 233236 RVA: 0x00E6CFCD File Offset: 0x00E6B1CD
		private void RefreshTextLanguage(string s, string s1)
		{
			this.RefreshConfig();
		}

		// Token: 0x06038F15 RID: 233237 RVA: 0x00E6CFD5 File Offset: 0x00E6B1D5
		private void OnRefreshMenuSetting(EFunction functionId)
		{
			if (functionId == EFunction.IMAGEQUALITY)
			{
				this.RefreshApplyBtn();
			}
		}

		// Token: 0x06038F16 RID: 233238 RVA: 0x00E6CFE2 File Offset: 0x00E6B1E2
		private void OnDropDownListVisibleChanged(bool bVisible)
		{
			if (!bVisible)
			{
				return;
			}
			base.GetUIDynScrollViewComponent(0).StopMovement();
		}

		// Token: 0x06038F17 RID: 233239 RVA: 0x00E6CFF4 File Offset: 0x00E6B1F4
		private void RefreshGameQualityLoad(bool needLoadConfirmBox = true)
		{
			if (!Singleton<Platform>.Instance.IsMobilePlatform() && !Singleton<Platform>.Instance.IsPcPlatform())
			{
				return;
			}
			MenuModel instance = ModelBase<MenuModel>.Instance;
			GameQualityLoadInfo gameQualityLoadInfo = instance.GetGameQualityLoadInfo();
			int percentage = gameQualityLoadInfo.Percentage;
			if (percentage > 80 && needLoadConfirmBox && (!instance.IsOpenedImageOverloadConfirmBox || instance.QualityInfoPercentage < 80f))
			{
				if (Singleton<Platform>.Instance.IsIOSPlatform())
				{
					ControllerBase<MenuController>.Instance.OpenImageQualityOverloadConfirmBox();
				}
				else
				{
					ControllerBase<MenuController>.Instance.OpenImageOverloadConfirmBox();
				}
				instance.IsOpenedImageOverloadConfirmBox = true;
			}
			instance.QualityInfoPercentage = (float)percentage;
			this.SetLoadPercentage((float)gameQualityLoadInfo.Percentage, gameQualityLoadInfo.BarColor);
			this.SetLoadDesc(gameQualityLoadInfo.Desc);
		}

		// Token: 0x06038F18 RID: 233240 RVA: 0x00E6D09C File Offset: 0x00E6B29C
		private void MobileSwitchTouch()
		{
			if (Singleton<Info>.Instance.IsMobileInputModel() && Singleton<Info>.Instance.IsInGamepad())
			{
				Singleton<MobileSwitchInputController>.Instance.SwitchToTouch();
			}
		}

		// Token: 0x06038F19 RID: 233241 RVA: 0x00E6D0C0 File Offset: 0x00E6B2C0
		private void OnClickApplyBtn(int _)
		{
			EGameQualitySettingLevel? recommendLevel = Singleton<GameSettingsDeviceRender>.Instance.GetRecommendQualityLv();
			if (recommendLevel == null)
			{
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ApplyImageQualityConfirm);
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				ModelBase<MenuModel>.Instance.HasApplyRecommendData = true;
				ControllerBase<MenuController>.Instance.HandleFireSaveMenuChange(ModelBase<MenuModel>.Instance.GetMenuDataByFunctionId(10), (int)recommendLevel.Value);
				this.RefreshApplyBtn();
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06038F1A RID: 233242 RVA: 0x00E6D128 File Offset: 0x00E6B328
		private void RefreshApplyBtn()
		{
			EGameQualitySettingLevel? recommendQualityLv = Singleton<GameSettingsDeviceRender>.Instance.GetRecommendQualityLv();
			if (recommendQualityLv != null)
			{
				int? dataCacheOrCurValue = ModelBase<MenuModel>.Instance.GetDataCacheOrCurValue(EFunction.IMAGEQUALITY);
				int value = (int)recommendQualityLv.Value;
				if ((dataCacheOrCurValue.GetValueOrDefault() == value & dataCacheOrCurValue != null) && !ModelBase<MenuModel>.Instance.IsImageQualityCustom)
				{
					this.SetEnableApplyButton(false);
					return;
				}
			}
			this.SetEnableApplyButton(true);
		}

		// Token: 0x06038F1B RID: 233243 RVA: 0x00E6D18D File Offset: 0x00E6B38D
		private void SetEnableApplyButton(bool enable)
		{
			if (this.ApplyBtnItem == null)
			{
				return;
			}
			this.ApplyBtnItem.SetEnableClick(enable);
			this.ApplyBtnItem.SetLocalTextNew(enable ? "ImageSetting_ApplyRec" : "ImageSetting_AppledRec", Array.Empty<object>());
		}

		// Token: 0x06038F1C RID: 233244 RVA: 0x00E6D1C4 File Offset: 0x00E6B3C4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForTabType(string[] configParams)
		{
			if (configParams.Length < 2)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "引导配置MenuView时参数不足";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ForTabType应有2个参数，但是实际只有", configParams.Length);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			int num = int.Parse(configParams[1]);
			int num2 = 0;
			for (int i = 0; i < this.MainTypeList.Count; i++)
			{
				if (this.MainTypeList[i] == num)
				{
					num2 = i;
					break;
				}
			}
			CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(num2);
			if (tabItemByIndex == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Guide;
				ELogAuthor author2 = ELogAuthor.WZ;
				string message2 = "引导配置MenuView时，未找到指定页签";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("targetIndex", num2);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return null;
			}
			this.TabComponent.ScrollToToggleByIndex(num2);
			UUIItem rootItem = tabItemByIndex.GetRootItem();
			return new UUIItem[]
			{
				rootItem,
				rootItem
			};
		}

		// Token: 0x06038F1D RID: 233245 RVA: 0x00E6D2A0 File Offset: 0x00E6B4A0
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForKeySetting(string[] configParams)
		{
			if (configParams.Length < 2)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "引导配置MenuView时参数不足";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ForKeySetting应有2个参数，但是实际只有", configParams.Length);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			int num = int.Parse(configParams[1]);
			KeySetting? config = ConfigKeySettingById.GetConfig(num, true);
			UUIItem guideItemByKeySettingId = this.KeySettingPanel.GetGuideItemByKeySettingId(num, new bool?(false));
			if (config == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Guide;
				ELogAuthor author2 = ELogAuthor.WZ;
				string message2 = "引导配置MenuView时找不到key setting";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("key setting id", num);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return null;
			}
			if (guideItemByKeySettingId == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				guideItemByKeySettingId,
				guideItemByKeySettingId
			};
		}

		// Token: 0x06038F1E RID: 233246 RVA: 0x00E6D354 File Offset: 0x00E6B554
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForMenuConfig(string[] configParams)
		{
			if (configParams.Length < 2)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "引导配置MenuView时参数不足";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ForMenuConfig应有2个参数，但是实际只有", configParams.Length);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			int num = int.Parse(configParams[1]);
			int num2 = -1;
			for (int i = 0; i < this.MenuInfoDataArray.Count; i++)
			{
				MenuScrollItemData menuScrollItemData = this.MenuInfoDataArray[i];
				MenuData data = menuScrollItemData.Data;
				if (((data != null) ? new EFunction?(data.FunctionId) : null).Value == (EFunction)num && menuScrollItemData.Type == EMenuScrollItemType.SubItem)
				{
					num2 = i;
					break;
				}
			}
			if (num2 < 0)
			{
				return null;
			}
			if (!this.IsLateUpdateDone)
			{
				return null;
			}
			if (this.IsScrolling == null)
			{
				this.IsScrolling = new bool?(true);
				this.ScrollView.ScrollToItemIndex(num2, false, false).ContinueWith(delegate()
				{
					this.IsScrolling = new bool?(false);
				}).Forget();
			}
			if (this.IsScrolling.GetValueOrDefault())
			{
				return null;
			}
			int displayGridStartIndex = this.ScrollView.GetDisplayGridStartIndex();
			int displayGridEndIndex = this.ScrollView.GetDisplayGridEndIndex();
			if (num2 < displayGridStartIndex || num2 > displayGridEndIndex)
			{
				return null;
			}
			UUIItem grid = this.ScrollView.GetGrid(num2);
			if (grid != null)
			{
				this.ScrollView.AddListenerOnItemClear(num2, delegate
				{
					Singleton<EventSystem>.Instance.Emit<string>(EEventName.FinishGuideStepByEvent, "MenuView");
				});
				return new UUIItem[]
				{
					grid,
					grid
				};
			}
			return null;
		}

		// Token: 0x17009196 RID: 37270
		// (get) Token: 0x06038F1F RID: 233247 RVA: 0x00E6D4D4 File Offset: 0x00E6B6D4
		private Dictionary<string, TGuideItemBuilder> GuideUiItemBuilders
		{
			get
			{
				if (this.GuideUiItemBuildersInternal == null || this.GuideUiItemBuildersInternal.Count == 0)
				{
					this.GuideUiItemBuildersInternal = new Dictionary<string, TGuideItemBuilder>
					{
						{
							"TabType",
							new TGuideItemBuilder(this.BuilderForTabType)
						},
						{
							"KeySetting",
							new TGuideItemBuilder(this.BuilderForKeySetting)
						},
						{
							"MenuConfig",
							new TGuideItemBuilder(this.BuilderForMenuConfig)
						}
					};
				}
				return this.GuideUiItemBuildersInternal;
			}
		}

		// Token: 0x06038F20 RID: 233248 RVA: 0x00E6D54C File Offset: 0x00E6B74C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length < 1)
			{
				Singleton<Log>.Instance.Error(ELogModule.Guide, ELogAuthor.WZ, "引导配置MenuView时，必须要有Extra参数", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			TGuideItemBuilder tguideItemBuilder;
			if (this.GuideUiItemBuilders.TryGetValue(configParams[0], out tguideItemBuilder))
			{
				return tguideItemBuilder(configParams);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "引导配置MenuView，Extra键值与代码不匹配";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("配置中的值", configParams[0]);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x06038F21 RID: 233249 RVA: 0x00E6D5C1 File Offset: 0x00E6B7C1
		private MenuScrollSettingContainerItem OnSettingItemCreate(MenuScrollItemData data, UUIItem uiItem, int index)
		{
			MenuScrollSettingContainerItem menuScrollSettingContainerItem = new MenuScrollSettingContainerItem();
			menuScrollSettingContainerItem.BindOnToggleStateChangedCallback(new Action<MenuScrollSettingContainerItem, EToggleState>(this.OnMenuScrollSettingContainerItemToggleReleased));
			menuScrollSettingContainerItem.BindOnDetailPopOpenCallback(new Action<MenuScrollSettingContainerItem>(this.OnDetailPopOpenCallback));
			return menuScrollSettingContainerItem;
		}

		// Token: 0x06038F22 RID: 233250 RVA: 0x00E6D5EC File Offset: 0x00E6B7EC
		private void OnMenuScrollSettingContainerItemToggleReleased(MenuScrollSettingContainerItem item, EToggleState state)
		{
			EMenuScrollItemType? type = item.Type;
			EMenuScrollItemType emenuScrollItemType = EMenuScrollItemType.TitleItem;
			if (type.GetValueOrDefault() == emenuScrollItemType & type != null)
			{
				return;
			}
			MenuData menuData = item.GetMenuData();
			if (menuData == null)
			{
				return;
			}
			if (state == EToggleState.ETT_UnChecked)
			{
				this.ClearSelectedDisplay(item);
				return;
			}
			this.RemoveNextScrollToButtonTimerHandle();
			MenuScrollSettingContainerItem selectedItem = this.SelectedItem;
			bool flag;
			if (selectedItem == null)
			{
				flag = false;
			}
			else
			{
				MenuData menuData2 = selectedItem.GetMenuData();
				flag = ((menuData2 != null) ? new bool?(menuData2.GetEnable()) : null).GetValueOrDefault();
			}
			if (flag)
			{
				MenuScrollSettingContainerItem selectedItem2 = this.SelectedItem;
				if (selectedItem2 != null)
				{
					selectedItem2.SetSelected(false);
				}
			}
			MenuScrollSettingContainerItem selectedItem3 = this.SelectedItem;
			if (selectedItem3 != null)
			{
				selectedItem3.SetDetailVisible(false);
			}
			item.SetDetailVisible(!menuData.GetIsDetailTextVisible());
			item.SetSelected(true);
			this.SelectedItem = item;
			this.SelectedDetailMenuData = menuData;
			MenuScrollItemData menuScrollItemData = item.MenuScrollItemData;
			if (menuData.HasDetailText() && menuScrollItemData != null && this.MenuInfoDataArray.IndexOf(menuScrollItemData) >= this.MenuInfoDataArray.Count - 1)
			{
				this.NextScrollToButtonTimerHandle = TimerSystem.GameplayTimeInstance.Next(delegate(float _)
				{
					this.ScrollView.ScrollToBottom(item.GetRootItem());
				}, null, null);
			}
		}

		// Token: 0x06038F23 RID: 233251 RVA: 0x00E6D738 File Offset: 0x00E6B938
		private void OnDetailPopOpenCallback(MenuScrollSettingContainerItem item)
		{
			MenuData menuData = item.GetMenuData();
			if (menuData == null)
			{
				return;
			}
			int detailPopId = menuData.GetDetailPopId();
			if (detailPopId > 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MenuDetailPopView, detailPopId, null);
			}
		}

		// Token: 0x06038F24 RID: 233252 RVA: 0x00E6D771 File Offset: 0x00E6B971
		private void RemoveNextScrollToButtonTimerHandle()
		{
			if (this.NextScrollToButtonTimerHandle != null && TimerSystem.GameplayTimeInstance.Has(this.NextScrollToButtonTimerHandle))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.NextScrollToButtonTimerHandle);
			}
			this.NextScrollToButtonTimerHandle = null;
		}

		// Token: 0x06038F25 RID: 233253 RVA: 0x00E6D7A8 File Offset: 0x00E6B9A8
		[NullableContext(2)]
		private void ClearSelectedDisplay(MenuScrollSettingContainerItem selectedItem)
		{
			if (selectedItem != this.SelectedItem)
			{
				if (selectedItem != null)
				{
					selectedItem.SetDetailVisible(false);
				}
				if (selectedItem != null)
				{
					selectedItem.SetSelected(false);
				}
			}
			else
			{
				MenuScrollSettingContainerItem selectedItem2 = this.SelectedItem;
				if (selectedItem2 != null)
				{
					selectedItem2.SetDetailVisible(false);
				}
				MenuScrollSettingContainerItem selectedItem3 = this.SelectedItem;
				if (selectedItem3 != null)
				{
					selectedItem3.SetSelected(false);
				}
			}
			MenuData selectedDetailMenuData = this.SelectedDetailMenuData;
			if (selectedDetailMenuData != null)
			{
				selectedDetailMenuData.SetDetailTextVisible(false);
			}
			this.SelectedItem = null;
			this.SelectedDetailMenuData = null;
		}

		// Token: 0x06038F26 RID: 233254 RVA: 0x00E6D818 File Offset: 0x00E6BA18
		private UniTask InitTabScroll()
		{
			MenuView.<InitTabScroll>d__50 <InitTabScroll>d__;
			<InitTabScroll>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTabScroll>d__.<>4__this = this;
			<InitTabScroll>d__.<>1__state = -1;
			<InitTabScroll>d__.<>t__builder.Start<MenuView.<InitTabScroll>d__50>(ref <InitTabScroll>d__);
			return <InitTabScroll>d__.<>t__builder.Task;
		}

		// Token: 0x06038F27 RID: 233255 RVA: 0x00E6D85B File Offset: 0x00E6BA5B
		private CommonTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new CommonTabItem();
		}

		// Token: 0x06038F28 RID: 233256 RVA: 0x00E6D864 File Offset: 0x00E6BA64
		private List<CommonTabItemData> CreateTabItemData()
		{
			List<CommonTabItemData> list = new List<CommonTabItemData>();
			for (int i = 0; i < this.MainTypeList.Count; i++)
			{
				CommonTabItemData commonTabItemData = new CommonTabItemData();
				commonTabItemData.Index = i;
				commonTabItemData.Data = this.GetCommonData(i);
				if (this.MainTypeList[i] == 5)
				{
					commonTabItemData.RedDotName = new ERedDotName?(ERedDotName.RedDotVersionCheck);
				}
				list.Add(commonTabItemData);
			}
			return list;
		}

		// Token: 0x06038F29 RID: 233257 RVA: 0x00E6D8D0 File Offset: 0x00E6BAD0
		private void OnClickedItem(int index)
		{
			int num = this.MainTypeList[index];
			this.MenuViewData.MenuViewDataCurMainType = num;
			MainType? mainTypeConfigById = ConfigBase<MenuBaseConfig>.Instance.GetMainTypeConfigById(num);
			UUIItem item = base.GetItem(5);
			UUIItem item2 = base.GetItem(4);
			if (mainTypeConfigById == null)
			{
				item.SetUIActive(false);
				item2.SetUIActive(false);
				return;
			}
			int num2 = mainTypeConfigById.Value.TabPanelType;
			if (Singleton<Info>.Instance.IsPcPlatform() && !Singleton<Info>.Instance.IsWinGDKPlatform())
			{
				if (Singleton<CloudGameManager>.Instance.IsCloudGame)
				{
					if (Singleton<Info>.Instance.IsInGamepad())
					{
						num2 = mainTypeConfigById.Value.PsTabPanelType;
					}
					else if (Singleton<Info>.Instance.IsMobileInputModel())
					{
						num2 = mainTypeConfigById.Value.TabPanelType;
					}
					else if (Singleton<Info>.Instance.IsPcInputModel())
					{
						num2 = mainTypeConfigById.Value.PcTabPanelType;
					}
				}
				else
				{
					num2 = mainTypeConfigById.Value.PcTabPanelType;
				}
			}
			else if (Singleton<Info>.Instance.IsPs5Platform())
			{
				num2 = mainTypeConfigById.Value.PsTabPanelType;
			}
			else if (Singleton<Info>.Instance.IsXboxPlatform())
			{
				num2 = mainTypeConfigById.Value.XboxTabPanelType;
			}
			else if (Singleton<Info>.Instance.IsMobilePlatform() && Singleton<Info>.Instance.IsInGamepad())
			{
				num2 = mainTypeConfigById.Value.PsTabPanelType;
			}
			if (num == 2)
			{
				ButtonItem applyBtnItem = this.ApplyBtnItem;
				if (applyBtnItem != null)
				{
					applyBtnItem.SetUiActive(true);
				}
			}
			else
			{
				ButtonItem applyBtnItem2 = this.ApplyBtnItem;
				if (applyBtnItem2 != null)
				{
					applyBtnItem2.SetUiActive(false);
				}
			}
			ESettingTabPanelType esettingTabPanelType = (ESettingTabPanelType)num2;
			if (esettingTabPanelType != ESettingTabPanelType.CommonSetting)
			{
				if (esettingTabPanelType != ESettingTabPanelType.KeySetting)
				{
					item.SetUIActive(false);
					item2.SetUIActive(false);
				}
				else
				{
					this.RefreshKeySetting();
					item.SetUIActive(false);
					item2.SetUIActive(true);
				}
			}
			else
			{
				this.RefreshCommonSetting();
				item.SetUIActive(true);
				item2.SetUIActive(false);
			}
			this.ClearSelectedDisplay(this.SelectedItem);
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.FinishGuideStepByEvent, "MenuView");
		}

		// Token: 0x06038F2A RID: 233258 RVA: 0x00E6DAE4 File Offset: 0x00E6BCE4
		private CommonTabData GetCommonData(int index)
		{
			int typeId = this.MainTypeList[index];
			MainType targetMainInfo = ControllerBase<MenuController>.Instance.GetTargetMainInfo(typeId);
			return new CommonTabData(targetMainInfo.MainIcon, new CommonTabTitleData(targetMainInfo.MainName, Array.Empty<object>()), null);
		}

		// Token: 0x06038F2B RID: 233259 RVA: 0x00E6DB28 File Offset: 0x00E6BD28
		private void RefreshCommonSetting()
		{
			this.RefreshConfig();
		}

		// Token: 0x06038F2C RID: 233260 RVA: 0x00E6DB30 File Offset: 0x00E6BD30
		private void RefreshKeySetting()
		{
			EInputControllerType inputControllerType = EInputControllerType.None;
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				inputControllerType = EInputControllerType.Keyboard;
			}
			else if (Singleton<Info>.Instance.IsInGamepad())
			{
				inputControllerType = EInputControllerType.Gamepad;
			}
			if (this.KeySettingPanel == null)
			{
				this.KeySettingPanel = new PcAndGamepadKeySettingPanel();
				this.KeySettingPanel.CreateThenShowByResourceIdAsync("UiItem_HandleSet", base.GetItem(4), false).ContinueWith(delegate()
				{
					this.KeySettingPanel.Refresh(inputControllerType);
				}).Forget();
				return;
			}
			this.KeySettingPanel.Refresh(inputControllerType);
		}

		// Token: 0x06038F2D RID: 233261 RVA: 0x00E6DBCC File Offset: 0x00E6BDCC
		private void RefreshConfig()
		{
			List<MenuData> targetBaseConfigData = ControllerBase<MenuController>.Instance.GetTargetBaseConfigData(this.MenuViewData.MenuViewDataCurMainType, this.ItemFilter);
			if (this.MenuViewData.MenuViewDataCurMainType == 2 && (Singleton<Platform>.Instance.IsMobilePlatform() || Singleton<Platform>.Instance.IsPcPlatform()))
			{
				UUIItem item = base.GetItem(3);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				this.RefreshGameQualityLoad(true);
			}
			else
			{
				UUIItem item2 = base.GetItem(3);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
			}
			this.MenuViewData.MenuViewDataLastSubType = 0;
			this.RecycleInfoDataArray();
			this.RefreshMenuInfoDataArray(targetBaseConfigData);
		}

		// Token: 0x06038F2E RID: 233262 RVA: 0x00E6DC64 File Offset: 0x00E6BE64
		private void SetLoadDesc(string desc)
		{
			UUIItem item = base.GetItem(3);
			UUIText uiText = ((item != null) ? item.GetAttachUIChildren().Get(1) : null) as UUIText;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(uiText, desc, Array.Empty<object>());
		}

		// Token: 0x06038F2F RID: 233263 RVA: 0x00E6DCA4 File Offset: 0x00E6BEA4
		private void SetLoadPercentage(float val, string color)
		{
			UUIItem item = base.GetItem(3);
			UUIItem uuiitem = (item != null) ? item.GetAttachUIChildren().Get(3) : null;
			if (uuiitem == null)
			{
				return;
			}
			TArray<UUIItem> attachUIChildren = uuiitem.GetAttachUIChildren();
			UUIItem uuiitem2 = (item != null) ? item.GetAttachUIChildren().Get(4) : null;
			if (uuiitem2 == null)
			{
				return;
			}
			float width = uuiitem2.Width;
			float[] array = new float[5];
			if (val >= 100f)
			{
				for (int i = 0; i < attachUIChildren.Num(); i++)
				{
					array[i] = width;
				}
			}
			else if (val >= 80f)
			{
				for (int j = 0; j < attachUIChildren.Num() - 1; j++)
				{
					array[j] = width;
				}
				float num = (val - 80f) * 5f;
				array[4] = width * (num / 100f);
			}
			else if (val >= 60f)
			{
				for (int k = 0; k < attachUIChildren.Num() - 2; k++)
				{
					array[k] = width;
				}
				float num2 = (val - 60f) * 5f;
				array[3] = width * (num2 / 100f);
			}
			else if (val >= 40f)
			{
				for (int l = 0; l < attachUIChildren.Num() - 3; l++)
				{
					array[l] = width;
				}
				float num3 = (val - 40f) * 5f;
				array[2] = width * (num3 / 100f);
			}
			else if (val >= 20f)
			{
				for (int m = 0; m < attachUIChildren.Num() - 4; m++)
				{
					array[m] = width;
				}
				float num4 = (val - 20f) * 5f;
				array[1] = width * (num4 / 100f);
			}
			else
			{
				float num5 = val * 5f;
				array[0] = width * (num5 / 100f);
			}
			for (int n = 0; n < attachUIChildren.Num(); n++)
			{
				UUISprite uuisprite = attachUIChildren.Get(n) as UUISprite;
				uuisprite.SetWidth(array[n]);
				this.SetSpriteByPath(color, uuisprite, false, null, null);
			}
		}

		// Token: 0x06038F30 RID: 233264 RVA: 0x00E6DEA4 File Offset: 0x00E6C0A4
		private void RecycleInfoDataArray()
		{
			foreach (MenuScrollItemData value in this.MenuInfoDataArray)
			{
				this.ScrollItemPool.Put(value);
			}
			this.MenuInfoDataArray.Clear();
		}

		// Token: 0x06038F31 RID: 233265 RVA: 0x00E6DF08 File Offset: 0x00E6C108
		private void GetMenuScrollItemData(MenuData data, EMenuScrollItemType itemType)
		{
			MenuScrollItemData menuScrollItemData = this.ScrollItemPool.Get();
			if (menuScrollItemData == null)
			{
				menuScrollItemData = this.ScrollItemPool.Create();
			}
			menuScrollItemData.Type = itemType;
			menuScrollItemData.Data = data;
			this.MenuInfoDataArray.Add(menuScrollItemData);
		}

		// Token: 0x06038F32 RID: 233266 RVA: 0x00E6DF4C File Offset: 0x00E6C14C
		private void RefreshMenuInfoDataArray(List<MenuData> menuDataArray)
		{
			foreach (MenuData menuData in menuDataArray)
			{
				if (menuData.SubType != this.MenuViewData.MenuViewDataLastSubType)
				{
					this.MenuViewData.MenuViewDataLastSubType = menuData.SubType;
					this.GetMenuScrollItemData(menuData, EMenuScrollItemType.TitleItem);
				}
				this.GetMenuScrollItemData(menuData, EMenuScrollItemType.SubItem);
			}
			this.IsLateUpdateDone = false;
			this.ScrollView.RefreshByData(this.MenuInfoDataArray.ToArray(), false, true);
			this.ScrollView.BindLateUpdate(new Action<float>(this.OnLateUpdate));
		}

		// Token: 0x06038F33 RID: 233267 RVA: 0x00E6E000 File Offset: 0x00E6C200
		private void OnLateUpdate(float _)
		{
			this.ScrollView.ScrollToItemIndex(0, true, true).Forget();
			this.ScrollView.UnBindLateUpdate();
			this.IsLateUpdateDone = true;
		}

		// Token: 0x06038F34 RID: 233268 RVA: 0x00E6E028 File Offset: 0x00E6C228
		private void OnCloseView()
		{
			MenuModel instance = ModelBase<MenuModel>.Instance;
			GameQualityLoadInfo gameQualityLoadInfo = (instance != null) ? instance.GetGameQualityLoadInfo() : null;
			if (((gameQualityLoadInfo != null) ? gameQualityLoadInfo.Desc : null) == "Text_SettingLoadOver_text")
			{
				MenuModel instance2 = ModelBase<MenuModel>.Instance;
				if (instance2 != null && instance2.HasDataCache())
				{
					this.OpenConfirmBox();
					return;
				}
			}
			this.CloseMySelf().Forget();
		}

		// Token: 0x06038F35 RID: 233269 RVA: 0x00E6E084 File Offset: 0x00E6C284
		public void OpenConfirmBox()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.GameQualityLoadOver);
			confirmBoxDataNew.FunctionMap.Add(1, delegate
			{
				this.CloseMySelf().Forget();
			});
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				this.TabComponent.SelectToggleByIndex(1, false);
			});
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06038F36 RID: 233270 RVA: 0x00E6E0E0 File Offset: 0x00E6C2E0
		private UniTask CloseMySelf()
		{
			MenuView.<CloseMySelf>d__66 <CloseMySelf>d__;
			<CloseMySelf>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseMySelf>d__.<>4__this = this;
			<CloseMySelf>d__.<>1__state = -1;
			<CloseMySelf>d__.<>t__builder.Start<MenuView.<CloseMySelf>d__66>(ref <CloseMySelf>d__);
			return <CloseMySelf>d__.<>t__builder.Task;
		}

		// Token: 0x06038F37 RID: 233271 RVA: 0x00E6E123 File Offset: 0x00E6C323
		private void RefreshLoginCacheIfNeed()
		{
			if (!Singleton<GameSettingsManager>.Instance.IsGameSettingsAppliedOnOpenLoading)
			{
				Singleton<GameSettingsManager>.Instance.RefreshLoginOverrideCache();
			}
		}

		// Token: 0x040206CF RID: 132815
		private const int CAPACITY = 20;

		// Token: 0x040206D0 RID: 132816
		private List<int> MainTypeList = new List<int>();

		// Token: 0x040206D1 RID: 132817
		private List<MenuScrollItemData> MenuInfoDataArray = new List<MenuScrollItemData>();

		// Token: 0x040206D2 RID: 132818
		[Nullable(2)]
		private MenuScrollSettingContainerDynItem MenuScrollSettingContainerDynItem;

		// Token: 0x040206D3 RID: 132819
		private readonly MenuViewData MenuViewData = new MenuViewData();

		// Token: 0x040206D4 RID: 132820
		[Nullable(2)]
		private MenuScrollSettingContainerItem SelectedItem;

		// Token: 0x040206D5 RID: 132821
		[Nullable(2)]
		private MenuData SelectedDetailMenuData;

		// Token: 0x040206D6 RID: 132822
		[Nullable(2)]
		private TimerHandle NextScrollToButtonTimerHandle;

		// Token: 0x040206D7 RID: 132823
		[Nullable(2)]
		private UiSequencePlayer ProgressSequencePlayer;

		// Token: 0x040206D8 RID: 132824
		private bool IsClosing;

		// Token: 0x040206D9 RID: 132825
		[Nullable(2)]
		private ButtonItem ApplyBtnItem;

		// Token: 0x040206DA RID: 132826
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TabComponentWithCaptionItem<CommonTabItem> TabComponent;

		// Token: 0x040206DB RID: 132827
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private DynamicScrollView<MenuScrollSettingContainerItem, MenuScrollSettingContainerDynItem, MenuScrollItemData> ScrollView;

		// Token: 0x040206DC RID: 132828
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Pool<MenuScrollItemData> ScrollItemPool;

		// Token: 0x040206DD RID: 132829
		[Nullable(2)]
		private PcAndGamepadKeySettingPanel KeySettingPanel;

		// Token: 0x040206DE RID: 132830
		[Nullable(2)]
		private TMenuItemFilter ItemFilter;

		// Token: 0x040206DF RID: 132831
		private bool IsLateUpdateDone;

		// Token: 0x040206E0 RID: 132832
		private bool? IsScrolling;

		// Token: 0x040206E1 RID: 132833
		private Dictionary<string, TGuideItemBuilder> GuideUiItemBuildersInternal;

		// Token: 0x0200B7FB RID: 47099
		[NullableContext(0)]
		private enum EMenuViewComponent
		{
			// Token: 0x04038E98 RID: 233112
			ScrollView,
			// Token: 0x04038E99 RID: 233113
			TabComponent,
			// Token: 0x04038E9A RID: 233114
			SettingItem,
			// Token: 0x04038E9B RID: 233115
			PnlLoad,
			// Token: 0x04038E9C RID: 233116
			KeySettingPanelItem,
			// Token: 0x04038E9D RID: 233117
			CommonSettingPanelItem,
			// Token: 0x04038E9E RID: 233118
			MobileSwitchTouchBtn,
			// Token: 0x04038E9F RID: 233119
			ProgressBar,
			// Token: 0x04038EA0 RID: 233120
			ProgressText,
			// Token: 0x04038EA1 RID: 233121
			ApplyBtn
		}
	}
}
