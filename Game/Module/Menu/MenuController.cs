using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.GameSettings;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.Common.InputView.Controller;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Menu.SubViews.EyeProtect;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.PackageUpdate;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005746 RID: 22342
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class MenuController : UiControllerBase<MenuController>
	{
		// Token: 0x17009132 RID: 37170
		// (get) Token: 0x06038E1A RID: 232986 RVA: 0x00E69D98 File Offset: 0x00E67F98
		private HashSet<EFunction> MakeImageQualityCustomSet
		{
			get
			{
				return MenuDefine.makeImageQualityCustomSet;
			}
		}

		// Token: 0x06038E1B RID: 232987 RVA: 0x00E69D9F File Offset: 0x00E67F9F
		protected override bool OnInit()
		{
			this.RegisterOpenViewFunc();
			this.InitGamepadConnect();
			return true;
		}

		// Token: 0x06038E1C RID: 232988 RVA: 0x00E69DAE File Offset: 0x00E67FAE
		protected override bool OnClear()
		{
			return true;
		}

		// Token: 0x06038E1D RID: 232989 RVA: 0x00E69DB4 File Offset: 0x00E67FB4
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<bool, int, int>(EEventName.ControllerConnectChange, new Action<bool, int, int>(this.ControllerConnectChange));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.HandleInputControllerChange));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnSdkFocusStateChange, new Action<bool>(this.TrySwitchTouchInputByDisconnectGamepad));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.HandleWorldDone));
		}

		// Token: 0x06038E1E RID: 232990 RVA: 0x00E69E34 File Offset: 0x00E68034
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.ControllerConnectChange, new Action<bool, int, int>(this.ControllerConnectChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.HandleInputControllerChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSdkFocusStateChange, new Action<bool>(this.TrySwitchTouchInputByDisconnectGamepad));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.HandleWorldDone));
		}

		// Token: 0x06038E1F RID: 232991 RVA: 0x00E69EB4 File Offset: 0x00E680B4
		private unsafe void ControllerConnectChange(bool bIsConnected, int platformUserId, int controllerId)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MobileInputSwitch;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "刷新手柄连接状态";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("bIsConnected", bIsConnected);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("platformUserId", platformUserId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("controllerId", controllerId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.RefreshGamepadConnect();
		}

		// Token: 0x06038E20 RID: 232992 RVA: 0x00E69F44 File Offset: 0x00E68144
		private void HandleInputControllerChange(EInputControllerType eInputControllerType, EInputControllerType inputControllerType)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				LocalStorage.SetGlobal<EInputControllerType>(ELocalStorageGlobalKey.LastGamepadEnum, Singleton<Info>.Instance.InputControllerType);
			}
		}

		// Token: 0x06038E21 RID: 232993 RVA: 0x00E69F67 File Offset: 0x00E68167
		private void TrySwitchTouchInputByDisconnectGamepad(bool sdkGetFocusState)
		{
			if (sdkGetFocusState)
			{
				return;
			}
			this.RefreshGamepadConnect();
		}

		// Token: 0x06038E22 RID: 232994 RVA: 0x00E69F73 File Offset: 0x00E68173
		private void HandleWorldDone()
		{
			ControllerBase<EyeProtectController>.Instance.ApplyEyeProtectSetting();
			ControllerBase<FilterSettingController>.Instance.ApplyFilterSetting();
			GameSettingsUtils.ApplyImageDisplayMode(Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.ImageDisplayMode, 0, true));
		}

		// Token: 0x06038E23 RID: 232995 RVA: 0x00E69FA0 File Offset: 0x00E681A0
		public void CloseAllFilter()
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.KuroEnableScreenFilter 0", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Tonemapper.BrightnessAndTextureDisable 1", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.BlueLightFilter.Disable 1", null);
		}

		// Token: 0x06038E24 RID: 232996 RVA: 0x00E69FD2 File Offset: 0x00E681D2
		public void OpenAllFilter()
		{
			GameSettingsUtils.ApplyImageDisplayMode(Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.ImageDisplayMode, 0, true));
		}

		// Token: 0x06038E25 RID: 232997 RVA: 0x00E69FEC File Offset: 0x00E681EC
		public void HandleFireSaveMenuChange(MenuData menuData, int value)
		{
			EFunction functionId = menuData.FunctionId;
			bool flag = this.NeedRedMagicFpsConfirmBox(value);
			if (functionId == EFunction.IMAGEQUALITY)
			{
				ModelBase<MenuModel>.Instance.IsImageQualityCustom = false;
			}
			else if (this.MakeImageQualityCustomSet.Contains(functionId) && (!Singleton<Info>.Instance.IsMobilePlatform() || !MenuDefine.mobileQualityUnRelativeSet.Contains(functionId)))
			{
				ModelBase<MenuModel>.Instance.IsImageQualityCustom = true;
			}
			if (menuData.IsDataCache)
			{
				ModelBase<MenuModel>.Instance.AddDataToTempCache(functionId, value);
			}
			else
			{
				Singleton<GameSettingsManager>.Instance.HandleValueChange(functionId, value, EGameSettingsApplyReason.WhenUi);
			}
			this.HandleAffectedMenuData(menuData);
			this.RefreshAffectedMenuDataEnable(menuData);
			this.ShowMenuTips(menuData, value);
			if (MenuDefine.noticeConfigSet.Contains(functionId))
			{
				if (functionId == EFunction.HIGHESTFPS)
				{
					Singleton<EventSystem>.Instance.Emit<bool>(EEventName.ConfigLoadChange, !flag);
				}
				else
				{
					Singleton<EventSystem>.Instance.Emit<bool>(EEventName.ConfigLoadChange, true);
				}
			}
			ModelBase<MenuModel>.Instance.IsEdited = true;
		}

		// Token: 0x06038E26 RID: 232998 RVA: 0x00E6A0CC File Offset: 0x00E682CC
		private void HandleRaytracingMenuData(int rayTracingCurrentValue)
		{
			if (Singleton<GameSettingsManager>.Instance.IsValid(EFunction.RayTracedGI, true))
			{
				ModelBase<MenuModel>.Instance.AddDataToTempOrSetValue(EFunction.RayTracedGI, (rayTracingCurrentValue > 0) ? 1 : 0);
			}
			else
			{
				Singleton<GameSettingsManager>.Instance.ForceSaveValue(EFunction.RayTracedGI, (rayTracingCurrentValue > 0) ? 1 : 0);
			}
			if (Singleton<GameSettingsManager>.Instance.IsValid(EFunction.RayTracedReflection, true))
			{
				ModelBase<MenuModel>.Instance.AddDataToTempOrSetValue(EFunction.RayTracedReflection, (rayTracingCurrentValue > 0) ? 1 : 0);
			}
			else
			{
				Singleton<GameSettingsManager>.Instance.ForceSaveValue(EFunction.RayTracedReflection, (rayTracingCurrentValue > 0) ? 1 : 0);
			}
			if (Singleton<GameSettingsManager>.Instance.IsValid(EFunction.RayTracedShadow, true))
			{
				ModelBase<MenuModel>.Instance.AddDataToTempOrSetValue(EFunction.RayTracedShadow, (rayTracingCurrentValue > 0) ? 1 : 0);
				return;
			}
			Singleton<GameSettingsManager>.Instance.ForceSaveValue(EFunction.RayTracedShadow, (rayTracingCurrentValue > 0) ? 1 : 0);
		}

		// Token: 0x06038E27 RID: 232999 RVA: 0x00E6A18C File Offset: 0x00E6838C
		private void HandleAffectedMenuData(MenuData menuData)
		{
			MenuModel instance = ModelBase<MenuModel>.Instance;
			EFunction functionId = menuData.FunctionId;
			if (functionId == EFunction.IMAGEQUALITY)
			{
				int? dataCacheOrCurValue = instance.GetDataCacheOrCurValue(functionId);
				if (dataCacheOrCurValue == null)
				{
					return;
				}
				DeviceRenderFeature? deviceRenderFeature = Singleton<GameSettingsDeviceRender>.Instance.GetDeviceRenderFeature((EGameQualitySettingLevel)dataCacheOrCurValue.Value);
				if (deviceRenderFeature != null)
				{
					foreach (KeyValuePair<EFunction, int> keyValuePair in Singleton<GameSettingsDeviceRender>.Instance.GetOtherChangedValue(deviceRenderFeature.Value))
					{
						EFunction key = keyValuePair.Key;
						int value = keyValuePair.Value;
						if ((key != EFunction.MOBILERESOLUTION || Singleton<Info>.Instance.IsMobilePlatform()) && (key != EFunction.PCVSYNC || Singleton<Info>.Instance.IsPcOrGamepadPlatform()) && (key != EFunction.NPCDENSITY || !UKuroStaticLibrary.IsLowMemoryDevice()) && key != EFunction.RayTracing)
						{
							EFunction efunction = key;
							int num = value;
							if (key == EFunction.SUPERRESOLUTION && Singleton<Info>.Instance.IsPcPlatform())
							{
								EFunction efunction2 = key;
								ValueTuple<EFunction, EFunction, int> valueTuple = Singleton<GameSettingsDeviceRender>.Instance.MapSuperResolutionRecommendValue(efunction2, efunction, num);
								efunction2 = valueTuple.Item1;
								efunction = valueTuple.Item2;
								num = valueTuple.Item3;
								ModelBase<MenuModel>.Instance.AddDataToTempCache(efunction2, 1);
								MenuData menuDataByFunctionId = ModelBase<MenuModel>.Instance.GetMenuDataByFunctionId((int)efunction2);
								if (menuDataByFunctionId != null)
								{
									this.RefreshAffectedMenuDataEnable(menuDataByFunctionId);
								}
							}
							ModelBase<MenuModel>.Instance.AddDataToTempCache(efunction, num);
							MenuData menuDataByFunctionId2 = ModelBase<MenuModel>.Instance.GetMenuDataByFunctionId((int)efunction);
							if (menuDataByFunctionId2 != null)
							{
								this.RefreshAffectedMenuDataEnable(menuDataByFunctionId2);
							}
						}
					}
				}
			}
			if (this.MakeImageQualityCustomSet.Contains(functionId))
			{
				Singleton<EventSystem>.Instance.Emit<EFunction>(EEventName.RefreshMenuSetting, EFunction.IMAGEQUALITY);
			}
			if (functionId == EFunction.RayTracing)
			{
				int? dataCacheOrCurValue2 = instance.GetDataCacheOrCurValue(EFunction.RayTracing);
				if (dataCacheOrCurValue2 != null && ModelBase<MenuModel>.Instance.NeedRayTracingSubChange)
				{
					this.HandleRaytracingMenuData(dataCacheOrCurValue2.Value);
				}
			}
			if (functionId == EFunction.NVIDIADLSS)
			{
				int? dataCacheOrCurValue3 = instance.GetDataCacheOrCurValue(functionId);
				if (dataCacheOrCurValue3 != null && dataCacheOrCurValue3.Value == 0)
				{
					ModelBase<MenuModel>.Instance.AddDataToTempCache(EFunction.NVIDIADLSSFG, 0);
				}
			}
			if (functionId == EFunction.JoystickMode || functionId == EFunction.MotorMobileButtonLayout)
			{
				int? dataCacheOrCurValue4 = instance.GetDataCacheOrCurValue(EFunction.MotorMobileButtonLayout);
				int? dataCacheOrCurValue5 = instance.GetDataCacheOrCurValue(EFunction.JoystickMode);
				if (dataCacheOrCurValue4 != null && dataCacheOrCurValue4.Value == 0 && dataCacheOrCurValue5 != null)
				{
					Singleton<GameSettingsManager>.Instance.HandleValueChange(EFunction.MotorIsDynamicJoystick, dataCacheOrCurValue5.Value, EGameSettingsApplyReason.WhenUi);
				}
			}
			int? dataCacheOrCurValue6 = instance.GetDataCacheOrCurValue(functionId);
			if (dataCacheOrCurValue6 == null)
			{
				return;
			}
			if (!menuData.CanAffectedFunction(dataCacheOrCurValue6.Value))
			{
				return;
			}
			foreach (KeyValuePair<int, int> keyValuePair2 in menuData.AffectedFunction)
			{
				int key2 = keyValuePair2.Key;
				int value2 = keyValuePair2.Value;
				if (Singleton<GameSettingsManager>.Instance.ValidApplyConfigMap.ContainsKey((EFunction)key2))
				{
					ModelBase<MenuModel>.Instance.AddDataToTempCache((EFunction)key2, value2);
				}
			}
		}

		// Token: 0x06038E28 RID: 233000 RVA: 0x00E6A4A4 File Offset: 0x00E686A4
		private void RefreshAffectedMenuDataEnable(MenuData menuData)
		{
			EFunction functionId = menuData.FunctionId;
			if (functionId == EFunction.ImageDisplayMode)
			{
				Singleton<EventSystem>.Instance.Emit<EFunction>(EEventName.RefreshMenuSetting, EFunction.Filter);
				Singleton<EventSystem>.Instance.Emit<EFunction>(EEventName.RefreshMenuSetting, EFunction.EyeProtection);
			}
			if (!menuData.HasDisableFunction())
			{
				return;
			}
			if (Singleton<GameSettingsManager>.Instance.GetCurrentValue(functionId, true, true) == null)
			{
				return;
			}
			foreach (int p in menuData.DisableFunction)
			{
				Singleton<EventSystem>.Instance.Emit<EFunction>(EEventName.RefreshMenuSetting, (EFunction)p);
			}
		}

		// Token: 0x06038E29 RID: 233001 RVA: 0x00E6A538 File Offset: 0x00E68738
		private void ShowMenuTips(MenuData menuData, int value)
		{
			EFunction functionId = menuData.FunctionId;
			if (functionId == EFunction.NVIDIADLSSFG || functionId == EFunction.RESOLUTION || functionId == EFunction.DISPLAYMODE)
			{
				int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.DISPLAYMODE, true, true);
				int? currentValue2 = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.RESOLUTION, true, true);
				int? currentValue3 = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.NVIDIADLSSFG, true, true);
				if (currentValue == null || currentValue2 == null || currentValue3 == null)
				{
					return;
				}
				int index = (currentValue.Value == 0) ? 0 : currentValue2.Value;
				FIntPoint resolutionByList = Singleton<GameSettingsDeviceRender>.Instance.GetResolutionByList(index);
				if (currentValue3.Value > 0 && Singleton<GameSettingsDeviceRender>.Instance.IsNvidia4060() && resolutionByList.X >= 3840 && resolutionByList.Y >= 2160)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Change4KWarning_Text", Array.Empty<object>());
				}
				return;
			}
			else
			{
				if (functionId == EFunction.RayTracing)
				{
					if (value > 0 && Singleton<GameSettingsDeviceRender>.Instance.IsDriverNeedUpdateForRayTracing())
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("UpdateGraphicsCardDriver_Text", Array.Empty<object>());
					}
					return;
				}
				string promptId;
				if (!menuData.ValueTipsMap.TryGetValue(value, out promptId))
				{
					return;
				}
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode(promptId, Array.Empty<object>());
				return;
			}
		}

		// Token: 0x06038E2A RID: 233002 RVA: 0x00E6A65C File Offset: 0x00E6885C
		private unsafe void InitGamepadConnect()
		{
			if (Singleton<Info>.Instance.IsMobileInputModel())
			{
				bool flag = ModelBase<PlatformModel>.Instance.IsGamepadAttached();
				Singleton<GameSettingsManager>.Instance.HandleValueChange(EFunction.MobileGamepadMode, (flag > false) ? 1 : 0, EGameSettingsApplyReason.WhenUi);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MobileInputSwitch;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "初始化手柄连接状态";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isGamepadAttach", flag);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MobileGamepadMode", Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.MobileGamepadMode, true, true));
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				if (flag)
				{
					EInputControllerType currentDeviceInputController = ModelBase<PlatformModel>.Instance.GetCurrentDeviceInputController();
					Singleton<Info>.Instance.SwitchInputControllerType(currentDeviceInputController, "InitGamepadConnect");
					LocalStorage.SetGlobal<EInputControllerType>(ELocalStorageGlobalKey.LastGamepadEnum, Singleton<Info>.Instance.InputControllerType);
				}
				ModelBase<PlatformModel>.Instance.LastGamepadAttachedState = flag;
			}
		}

		// Token: 0x06038E2B RID: 233003 RVA: 0x00E6A748 File Offset: 0x00E68948
		public unsafe void RefreshGamepadConnect()
		{
			if (Singleton<Info>.Instance.IsMobileInputModel())
			{
				bool flag = ModelBase<PlatformModel>.Instance.IsGamepadAttached();
				bool lastGamepadAttachedState = ModelBase<PlatformModel>.Instance.LastGamepadAttachedState;
				Singleton<GameSettingsManager>.Instance.HandleValueChange(EFunction.MobileGamepadMode, (flag > false) ? 1 : 0, EGameSettingsApplyReason.WhenUi);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MobileInputSwitch;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "刷新手柄连接状态";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isGamepadAttach", flag);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("lastState", lastGamepadAttachedState);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("MobileGamepadMode", Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.MobileGamepadMode, true, true));
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				if (!flag && lastGamepadAttachedState)
				{
					Singleton<Log>.Instance.Info(ELogModule.MobileInputSwitch, ELogAuthor.XXJ, "手柄重置回触屏模式,手柄断联", default(ReadOnlySpan<ValueTuple<string, object>>));
					if (Singleton<MobileSwitchInputController>.Instance.SwitchToTouchByDisconnectGamepad())
					{
						ModelBase<PlatformModel>.Instance.LastGamepadAttachedState = flag;
						return;
					}
				}
				else
				{
					ModelBase<PlatformModel>.Instance.LastGamepadAttachedState = flag;
				}
			}
		}

		// Token: 0x06038E2C RID: 233004 RVA: 0x00E6A868 File Offset: 0x00E68A68
		public List<int> GetMainTypeList([Nullable(2)] TMenuItemFilter filter = null)
		{
			int[] mainTypeList = ModelBase<MenuModel>.Instance.GetMainTypeList(filter);
			List<int> list = new List<int>();
			for (int i = 0; i < mainTypeList.Length; i++)
			{
				list.Add(mainTypeList[i]);
			}
			return list;
		}

		// Token: 0x06038E2D RID: 233005 RVA: 0x00E6A8A0 File Offset: 0x00E68AA0
		public MainType GetTargetMainInfo(int typeId)
		{
			return ModelBase<MenuModel>.Instance.GetTargetMainInfo(typeId).Value;
		}

		// Token: 0x06038E2E RID: 233006 RVA: 0x00E6A8C0 File Offset: 0x00E68AC0
		public List<MenuData> GetTargetBaseConfigData(int mainType, [Nullable(2)] TMenuItemFilter filter = null)
		{
			return ModelBase<MenuModel>.Instance.GetTargetConfigData(mainType, filter) ?? new List<MenuData>();
		}

		// Token: 0x06038E2F RID: 233007 RVA: 0x00E6A8D8 File Offset: 0x00E68AD8
		public unsafe int GetTargetConfig(EFunction functionId)
		{
			int? dataCacheOrCurValue = ModelBase<MenuModel>.Instance.GetDataCacheOrCurValue(functionId);
			if (dataCacheOrCurValue == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Menu;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "Menu中获取选项值失败，返回缺省值0";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("functionId", functionId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Menu;
			ELogAuthor author2 = ELogAuthor.WZ;
			string message2 = "Menu中获取选项值";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("functionId", functionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("result", dataCacheOrCurValue);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return dataCacheOrCurValue.Value;
		}

		// Token: 0x06038E30 RID: 233008 RVA: 0x00E6A98C File Offset: 0x00E68B8C
		private string GetCurrentResolutionString()
		{
			if (Singleton<Info>.Instance.IsMobilePlatform())
			{
				return this.GetTargetConfig(EFunction.MOBILERESOLUTION).ToString();
			}
			int targetConfig = this.GetTargetConfig(EFunction.RESOLUTION);
			return Singleton<GameSettingsDeviceRender>.Instance.GetResolutionByList(targetConfig).ToString();
		}

		// Token: 0x06038E31 RID: 233009 RVA: 0x00E6A9D8 File Offset: 0x00E68BD8
		[NullableContext(2)]
		private float GetFilterSettingLogValue(float[] values, EFilterSettingValueIndex valueIndex)
		{
			if (values == null)
			{
				return -1f;
			}
			if (valueIndex >= (EFilterSettingValueIndex)values.Length)
			{
				return -1f;
			}
			return values[(int)valueIndex];
		}

		// Token: 0x06038E32 RID: 233010 RVA: 0x00E6AA00 File Offset: 0x00E68C00
		public void ReportSettingMenuLogEvent()
		{
			Singleton<Log>.Instance.Info(ELogModule.Menu, ELogAuthor.WZ, "上报设置系统埋点数据[Start]", default(ReadOnlySpan<ValueTuple<string, object>>));
			SettingMenuLogEvent settingMenuLogEvent = new SettingMenuLogEvent();
			settingMenuLogEvent.i_image_quality = (ModelBase<MenuModel>.Instance.IsImageQualityCustom ? 99 : this.GetTargetConfig(EFunction.IMAGEQUALITY));
			settingMenuLogEvent.i_display_mode = this.GetTargetConfig(EFunction.DISPLAYMODE);
			settingMenuLogEvent.s_resolution = this.GetCurrentResolutionString();
			settingMenuLogEvent.i_brightness = this.GetTargetConfig(EFunction.BRIGHTNESS);
			settingMenuLogEvent.i_highest_fps = this.GetTargetConfig(EFunction.HIGHESTFPS);
			settingMenuLogEvent.i_shadow_quality = this.GetTargetConfig(EFunction.SHADOWQUALITY);
			settingMenuLogEvent.i_niagara_quality = this.GetTargetConfig(EFunction.NIAGARAQUALITY);
			settingMenuLogEvent.i_fsr = this.GetTargetConfig(EFunction.FSR);
			settingMenuLogEvent.i_image_detail = this.GetTargetConfig(EFunction.IMAGEDETAIL);
			settingMenuLogEvent.i_scene_ao = this.GetTargetConfig(EFunction.SCENEAO);
			settingMenuLogEvent.i_volume_Fog = this.GetTargetConfig(EFunction.VOLUMEFOG);
			settingMenuLogEvent.i_volume_light = this.GetTargetConfig(EFunction.VOLUMELIGHT);
			settingMenuLogEvent.i_motion_blur = this.GetTargetConfig(EFunction.MOTIONBLUR);
			settingMenuLogEvent.i_anti_aliasing = this.GetTargetConfig(EFunction.ANTIALISING);
			settingMenuLogEvent.i_pcv_sync = this.GetTargetConfig(EFunction.PCVSYNC);
			settingMenuLogEvent.i_horizontal_view_sensitivity = this.GetTargetConfig(EFunction.HorizontalViewSensitivity);
			settingMenuLogEvent.i_vertical_view_sensitivity = this.GetTargetConfig(EFunction.VerticalViewSensitivity);
			settingMenuLogEvent.i_aim_horizontal_view_sensitivity = this.GetTargetConfig(EFunction.AimHorizontalViewSensitivity);
			settingMenuLogEvent.i_aim_vertical_view_sensitivity = this.GetTargetConfig(EFunction.AimVerticalViewSensitivity);
			settingMenuLogEvent.f_camera_shake_strength = (float)this.GetTargetConfig(EFunction.CameraShakeStrength);
			settingMenuLogEvent.i_common_spring_arm_length = this.GetTargetConfig(EFunction.CommonSpringArmLength);
			settingMenuLogEvent.i_fight_spring_arm_length = this.GetTargetConfig(EFunction.FightSpringArmLength);
			settingMenuLogEvent.i_reset_focus_enable = this.GetTargetConfig(EFunction.ResetFocusEnable);
			settingMenuLogEvent.i_side_step_camera_enable = this.GetTargetConfig(EFunction.IsSidestepCameraEnable);
			settingMenuLogEvent.i_soft_lock_camera_enable = this.GetTargetConfig(EFunction.IsSoftLockCameraEnable);
			settingMenuLogEvent.i_joystick_shake_strength = this.GetTargetConfig(EFunction.JoystickShakeStrength);
			settingMenuLogEvent.i_joystick_shake_type = this.GetTargetConfig(EFunction.JoystickShakeType);
			settingMenuLogEvent.f_walk_or_run_rate = Singleton<GameSettingsManager>.Instance.GetCurrentValueFloat(EFunction.WalkOrRunRate, true).GetValueOrDefault();
			settingMenuLogEvent.i_advice_setting = this.GetTargetConfig(EFunction.ADVICESETTING);
			settingMenuLogEvent.i_enemy_id = this.GetTargetConfig(EFunction.SkillLockEnemyMode);
			settingMenuLogEvent.i_crowd_density = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.NPCDENSITY, true, true).GetValueOrDefault();
			settingMenuLogEvent.i_hit_material_effects = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.EnemyHitDisplayMode, true, true).GetValueOrDefault();
			settingMenuLogEvent.i_auto_adjust = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.AutoAdjustImageQuality, true, true).GetValueOrDefault();
			settingMenuLogEvent.i_damage_numbers = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.ShowDamage, true, true).GetValueOrDefault();
			settingMenuLogEvent.i_fluttering_animation = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.DynamicBones, true, true).GetValueOrDefault();
			settingMenuLogEvent.i_cinematic_quality = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.FlowAdaptation, true, true).GetValueOrDefault();
			settingMenuLogEvent.i_teammate_effects = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.TeammateFx, true, true).GetValueOrDefault();
			settingMenuLogEvent.i_injury_effects = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.SkinDamageMode, true, true).GetValueOrDefault();
			settingMenuLogEvent.i_environment_interaction = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.WaterInteract, true, true).GetValueOrDefault();
			settingMenuLogEvent.i_foliage_blur = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.VegetationDither, true, true).GetValueOrDefault();
			settingMenuLogEvent.i_auto_exposure = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.AutoExposure, true, true).GetValueOrDefault();
			settingMenuLogEvent.i_hdr = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.HDR, true, true).GetValueOrDefault();
			settingMenuLogEvent.i_ui_Brightness = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.UiBrightness, true, true).GetValueOrDefault();
			settingMenuLogEvent.i_peak_Brightness = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.PeakBrightness, true, true).GetValueOrDefault();
			int global = LocalStorage.GetGlobal<int>(ELocalStorageGlobalKey.FilterSettingId, -1);
			Dictionary<int, float[]> global2 = LocalStorage.GetGlobal<Dictionary<int, float[]>>(ELocalStorageGlobalKey.FilterSettingValues, null);
			float[] values = null;
			if (global2 != null)
			{
				global2.TryGetValue(global, out values);
			}
			SettingMenuLogEvent settingMenuLogEvent2 = settingMenuLogEvent;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(145, 14);
			defaultInterpolatedStringHandler.AppendLiteral("id:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(global);
			defaultInterpolatedStringHandler.AppendLiteral("-intense:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.GetFilterSettingLogValue(values, EFilterSettingValueIndex.Intensity));
			defaultInterpolatedStringHandler.AppendLiteral("-x:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.GetFilterSettingLogValue(values, EFilterSettingValueIndex.Horizontal));
			defaultInterpolatedStringHandler.AppendLiteral("-y:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.GetFilterSettingLogValue(values, EFilterSettingValueIndex.Vertical));
			defaultInterpolatedStringHandler.AppendLiteral("-SharpenIntensity:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.GetFilterSettingLogValue(values, EFilterSettingValueIndex.SharpenIntensity));
			defaultInterpolatedStringHandler.AppendLiteral("-Brightness:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.GetFilterSettingLogValue(values, EFilterSettingValueIndex.Brightness));
			defaultInterpolatedStringHandler.AppendLiteral("-Contrast:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.GetFilterSettingLogValue(values, EFilterSettingValueIndex.Contrast));
			defaultInterpolatedStringHandler.AppendLiteral("-ColorTemperature:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.GetFilterSettingLogValue(values, EFilterSettingValueIndex.ColorTemperature));
			defaultInterpolatedStringHandler.AppendLiteral("-Saturation:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.GetFilterSettingLogValue(values, EFilterSettingValueIndex.Saturation));
			defaultInterpolatedStringHandler.AppendLiteral("-Bloom:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.GetFilterSettingLogValue(values, EFilterSettingValueIndex.Bloom));
			defaultInterpolatedStringHandler.AppendLiteral("-Gamma:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.GetFilterSettingLogValue(values, EFilterSettingValueIndex.Gamma));
			defaultInterpolatedStringHandler.AppendLiteral("-ShadowIntensity:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.GetFilterSettingLogValue(values, EFilterSettingValueIndex.ShadowIntensity));
			defaultInterpolatedStringHandler.AppendLiteral("-NoiseIntensity:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.GetFilterSettingLogValue(values, EFilterSettingValueIndex.NoiseIntensity));
			defaultInterpolatedStringHandler.AppendLiteral("-Halation:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.GetFilterSettingLogValue(values, EFilterSettingValueIndex.Halation));
			settingMenuLogEvent2.i_filter_list = defaultInterpolatedStringHandler.ToStringAndClear();
			settingMenuLogEvent.i_image_mode = Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.ImageDisplayMode, 0, true);
			settingMenuLogEvent.eyeprotect_mode = Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.EyeProtectionMode, 0, true);
			if (settingMenuLogEvent.eyeprotect_mode == 2)
			{
				SettingMenuLogEvent settingMenuLogEvent3 = settingMenuLogEvent;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 4);
				defaultInterpolatedStringHandler.AppendLiteral("temp:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(Singleton<GameSettingsManager>.Instance.GetCurrentValueSafelyFloat(EFunction.EyeProtectionTemp, 0f));
				defaultInterpolatedStringHandler.AppendLiteral("-strength:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(Singleton<GameSettingsManager>.Instance.GetCurrentValueSafelyFloat(EFunction.EyeProtectionStrength, 0f));
				defaultInterpolatedStringHandler.AppendLiteral("-brightness:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(Singleton<GameSettingsManager>.Instance.GetCurrentValueSafelyFloat(EFunction.EyeProtectionBrightness, 0f));
				defaultInterpolatedStringHandler.AppendLiteral("-texture:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(Singleton<GameSettingsManager>.Instance.GetCurrentValueSafelyFloat(EFunction.EyeProtectionTexture, 0f));
				settingMenuLogEvent3.eyeprotect_list = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			settingMenuLogEvent.i_recommend_config = ((ModelBase<MenuModel>.Instance != null && ModelBase<MenuModel>.Instance.HasApplyRecommendData) ? 1 : 0);
			settingMenuLogEvent.anisotropic_sampling = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.AnisoLevel, true, true).GetValueOrDefault(99999);
			settingMenuLogEvent.render_distance = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.LOADINGRANGESCALELEVEL, true, true).GetValueOrDefault(99999);
			if (Singleton<GameSettingsDeviceRender>.Instance.IsDlssGpuDevice())
			{
				settingMenuLogEvent.dlss = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.NVIDIADLSS, true, true).GetValueOrDefault(99999);
			}
			if (Singleton<GameSettingsDeviceRender>.Instance.IsFsrDevice())
			{
				settingMenuLogEvent.fsr = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.FSR3, true, true).GetValueOrDefault(99999);
			}
			if (Singleton<GameSettingsDeviceRender>.Instance.IsXess2Supported())
			{
				settingMenuLogEvent.xess = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.XESS2, true, true).GetValueOrDefault(99999);
			}
			if (Singleton<GameSettingsDeviceRender>.Instance.IsDlssGpuDevice())
			{
				settingMenuLogEvent.super_resolution = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.NVIDIADLSSQUALITY, true, true).GetValueOrDefault(99999);
			}
			else if (Singleton<GameSettingsDeviceRender>.Instance.IsFsrDevice())
			{
				settingMenuLogEvent.super_resolution = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.FSR3_QUALITY, true, true).GetValueOrDefault(99999);
			}
			else if (Singleton<GameSettingsDeviceRender>.Instance.IsXess2Supported())
			{
				settingMenuLogEvent.super_resolution = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.XESS2_QUALITY, true, true).GetValueOrDefault(99999);
			}
			if (UKuroRenderingRuntimeBPPluginBPLibrary.GetRayTracingSupportedType() == URayTracingSupport.Supported)
			{
				int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.RayTracing, true, true);
				int? currentValue2 = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.RayTracedReflection, true, true);
				int? currentValue3 = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.RayTracedGI, true, true);
				int? currentValue4 = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.RayTracedShadow, true, true);
				settingMenuLogEvent.ray_tracing = currentValue.GetValueOrDefault(99999);
				settingMenuLogEvent.rt_reflection = currentValue2.GetValueOrDefault(99999);
				settingMenuLogEvent.rt_global_illumination = currentValue3.GetValueOrDefault(99999);
				settingMenuLogEvent.rt_shadow = currentValue4.GetValueOrDefault(99999);
			}
			if (Singleton<Info>.Instance.IsPcPlatform())
			{
				settingMenuLogEvent.vulkan = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.Vulkan, true, true).GetValueOrDefault(99999);
			}
			if (Singleton<Info>.Instance.IsPcPlatform())
			{
				if (Singleton<GameSettingsDeviceRender>.Instance.IsDlss3GpuDevice())
				{
					settingMenuLogEvent.pc_frame_interpolation = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.NVIDIADLSSFG, true, true).GetValueOrDefault(99999);
				}
				else if (Singleton<GameSettingsDeviceRender>.Instance.IsFsrDevice())
				{
					settingMenuLogEvent.pc_frame_interpolation = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.FSR3_FG, true, true).GetValueOrDefault(99999);
				}
				else if (Singleton<GameSettingsDeviceRender>.Instance.IsXeFGSupported())
				{
					settingMenuLogEvent.pc_frame_interpolation = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.XESS2_FG, true, true).GetValueOrDefault(99999);
				}
			}
			if (Singleton<Info>.Instance.IsMobilePlatform())
			{
				settingMenuLogEvent.mob_frame_interpolation = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.AdrenoFME, true, true).GetValueOrDefault(99999);
			}
			settingMenuLogEvent.self_dev_interpolation = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.IRX, true, true).GetValueOrDefault(99999);
			settingMenuLogEvent.game_language = LocalStorage.GetGlobal<int>(ELocalStorageGlobalKey.TextLanguage, 0);
			settingMenuLogEvent.game_voice = LocalStorage.GetGlobal<int>(ELocalStorageGlobalKey.VoiceLanguage, 0);
			Singleton<Log>.Instance.Info(ELogModule.Menu, ELogAuthor.WZ, "上报设置系统埋点数据[Data Collect Done]", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<LogReportController>.Instance.LogReport(settingMenuLogEvent);
		}

		// Token: 0x06038E33 RID: 233011 RVA: 0x00E6B3EF File Offset: 0x00E695EF
		public void BeforeViewClose()
		{
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.NVIDIADLSSQUALITY, EGameSettingsApplyReason.WhenUi, true);
			GameSettingsManager.SetIsUsingQualityPreset(!ModelBase<MenuModel>.Instance.IsImageQualityCustom);
		}

		// Token: 0x06038E34 RID: 233012 RVA: 0x00E6B418 File Offset: 0x00E69618
		private void RegisterOpenViewFunc()
		{
			this.OpenViewFuncMap[EUiViewName.LogUploadView] = new Action(this.OpenLogUploadView);
			this.OpenViewFuncMap[EUiViewName.CdKeyInputView] = new Action(this.OpenCdKeyInputView);
			this.OpenViewFuncMap[EUiViewName.MobileSwitchInputView] = new Action(this.OpenMobileSwitchInputView);
			this.OpenViewFuncMap[EUiViewName.SubPackageDownLoadView] = new Action(this.OpenResDownLoadView);
			this.OpenViewFuncMap[EUiViewName.SubPackageDownLoadClearTipsView] = new Action(this.OpenSubPackageDownLoadClearTipsView);
			this.OpenViewFuncMap[EUiViewName.FilterSettingView] = new Action(this.OpenFilterSettingView);
			this.OpenViewFuncMap[EUiViewName.EyeProtectView] = new Action(this.OpenEyeProtectView);
			this.OpenViewFuncMap[EUiViewName.VersionCheckView] = new Action(this.OpenVersionCheckView);
		}

		// Token: 0x06038E35 RID: 233013 RVA: 0x00E6B505 File Offset: 0x00E69705
		private void OpenLogUploadView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.LogUploadView, EKuroSdkOpenCustomerServerType.Setting, null);
		}

		// Token: 0x06038E36 RID: 233014 RVA: 0x00E6B51D File Offset: 0x00E6971D
		private void OpenCdKeyInputView()
		{
			ControllerBase<CommonInputViewController>.Instance.OpenCdKeyInputView();
		}

		// Token: 0x06038E37 RID: 233015 RVA: 0x00E6B529 File Offset: 0x00E69729
		private void OpenVersionCheckView()
		{
			Singleton<PackageUpdateController>.Instance.TryOpenParallelPackageUpdateUrl();
		}

		// Token: 0x06038E38 RID: 233016 RVA: 0x00E6B535 File Offset: 0x00E69735
		private void OpenMobileSwitchInputView()
		{
			Singleton<MobileSwitchInputController>.Instance.SwitchToGamepadByMenuSetting();
		}

		// Token: 0x06038E39 RID: 233017 RVA: 0x00E6B541 File Offset: 0x00E69741
		private void OpenResDownLoadView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SubPackageDownLoadView, null, null);
		}

		// Token: 0x06038E3A RID: 233018 RVA: 0x00E6B554 File Offset: 0x00E69754
		private void OpenSubPackageDownLoadClearTipsView()
		{
			if (!Singleton<Info>.Instance.IsMobilePlatform())
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SubPackageDownLoadClearTipsView, null, null);
				return;
			}
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ConnectBanCleanResource", Array.Empty<object>());
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SubPackageDownLoadMobileClearPopView, null, null);
		}

		// Token: 0x06038E3B RID: 233019 RVA: 0x00E6B5B1 File Offset: 0x00E697B1
		public bool IsInputControllerTypeIncludeKey(EInputControllerType inputControllerType, string keyName)
		{
			switch (inputControllerType)
			{
			case EInputControllerType.Keyboard:
				return Singleton<InputSettings>.Instance.IsKeyboardKey(keyName) || Singleton<InputSettings>.Instance.IsMouseButton(keyName);
			case EInputControllerType.Gamepad:
				return Singleton<InputSettings>.Instance.IsGamepadKey(keyName);
			}
			return false;
		}

		// Token: 0x06038E3C RID: 233020 RVA: 0x00E6B5F0 File Offset: 0x00E697F0
		public void OpenChangeLockView()
		{
			InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding("锁定目标");
			if (actionBinding == null)
			{
				return;
			}
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			actionBinding.GetPcKeyNameList(list);
			actionBinding.GetGamepadKeyNameList(list2);
			string keyName = list[0];
			string keyName2 = list2[0];
			string keyIconPath = Singleton<InputSettings>.Instance.GetKeyIconPath(keyName);
			string keyIconPath2 = Singleton<InputSettings>.Instance.GetKeyIconPath(keyName2);
			ChangeKeyModeRow changeKeyModeRow = new ChangeKeyModeRow();
			changeKeyModeRow.RowSpriteResourceId = "SP_SwitchType1";
			changeKeyModeRow.DescriptionA = "LockEnemyModeText_1";
			ChangeKeyModeRow changeKeyModeRow2 = changeKeyModeRow;
			object[] array = new string[]
			{
				"<texture=" + keyIconPath + "/>"
			};
			changeKeyModeRow2.DescriptionParametersA = array;
			changeKeyModeRow.DescriptionB = "LockEnemyModeText_3";
			ChangeKeyModeRow changeKeyModeRow3 = changeKeyModeRow;
			array = new string[]
			{
				"<texture=" + keyIconPath + "/>"
			};
			changeKeyModeRow3.DescriptionParametersB = array;
			ChangeKeyModeRow changeKeyModeRow4 = changeKeyModeRow;
			changeKeyModeRow = new ChangeKeyModeRow();
			changeKeyModeRow.RowSpriteResourceId = "SP_SwitchType2";
			changeKeyModeRow.DescriptionA = "LockEnemyModeText_2";
			ChangeKeyModeRow changeKeyModeRow5 = changeKeyModeRow;
			array = new string[]
			{
				"<texture=" + keyIconPath + "/>"
			};
			changeKeyModeRow5.DescriptionParametersA = array;
			changeKeyModeRow.DescriptionB = "LockEnemyModeText_4";
			ChangeKeyModeRow changeKeyModeRow6 = changeKeyModeRow;
			changeKeyModeRow = new ChangeKeyModeRow();
			changeKeyModeRow.RowSpriteResourceId = "SP_SwitchType1";
			changeKeyModeRow.DescriptionA = "LockEnemyModeText_1";
			ChangeKeyModeRow changeKeyModeRow7 = changeKeyModeRow;
			array = new string[]
			{
				"<texture=" + keyIconPath2 + "/>"
			};
			changeKeyModeRow7.DescriptionParametersA = array;
			changeKeyModeRow.DescriptionB = "LockEnemyModeText_3";
			ChangeKeyModeRow changeKeyModeRow8 = changeKeyModeRow;
			array = new string[]
			{
				"<texture=" + keyIconPath2 + "/>"
			};
			changeKeyModeRow8.DescriptionParametersB = array;
			ChangeKeyModeRow changeKeyModeRow9 = changeKeyModeRow;
			changeKeyModeRow = new ChangeKeyModeRow();
			changeKeyModeRow.RowSpriteResourceId = "SP_SwitchType2";
			changeKeyModeRow.DescriptionA = "LockEnemyModeText_2";
			ChangeKeyModeRow changeKeyModeRow10 = changeKeyModeRow;
			array = new string[]
			{
				"<texture=" + keyIconPath2 + "/>"
			};
			changeKeyModeRow10.DescriptionParametersA = array;
			changeKeyModeRow.DescriptionB = "LockEnemyModeText_6";
			ChangeKeyModeRow changeKeyModeRow11 = changeKeyModeRow;
			int valueOrDefault = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.KeyboardLockEnemyMode, true, true).GetValueOrDefault();
			int valueOrDefault2 = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.GamepadLockEnemyMode, true, true).GetValueOrDefault();
			ChangeKeyModeGroup changeKeyModeGroup = new ChangeKeyModeGroup();
			changeKeyModeGroup.GroupName = "LockEnemyModeType_1";
			changeKeyModeGroup.DefaultKeyModeRowIndex = valueOrDefault;
			ChangeKeyModeGroup changeKeyModeGroup2 = changeKeyModeGroup;
			IChangeKeyModeRow[] changeKeyModeRowList = new ChangeKeyModeRow[]
			{
				changeKeyModeRow4,
				changeKeyModeRow6
			};
			changeKeyModeGroup2.ChangeKeyModeRowList = changeKeyModeRowList;
			ChangeKeyModeGroup changeKeyModeGroup3 = changeKeyModeGroup;
			changeKeyModeGroup = new ChangeKeyModeGroup();
			changeKeyModeGroup.GroupName = "LockEnemyModeType_2";
			changeKeyModeGroup.DefaultKeyModeRowIndex = valueOrDefault2;
			ChangeKeyModeGroup changeKeyModeGroup4 = changeKeyModeGroup;
			changeKeyModeRowList = new ChangeKeyModeRow[]
			{
				changeKeyModeRow9,
				changeKeyModeRow11
			};
			changeKeyModeGroup4.ChangeKeyModeRowList = changeKeyModeRowList;
			ChangeKeyModeGroup changeKeyModeGroup5 = changeKeyModeGroup;
			ChangeKeyMode changeKeyMode = new ChangeKeyMode();
			changeKeyMode.TitleName = "LockEnemyModeTitle";
			changeKeyMode.DefaultGroupIndex = ((ModelBase<MenuModel>.Instance.KeySettingInputControllerType == EInputControllerType.Gamepad) ? 1 : 0);
			ChangeKeyMode changeKeyMode2 = changeKeyMode;
			IChangeKeyModeGroup[] changeKeyModeGroupList = new ChangeKeyModeGroup[]
			{
				changeKeyModeGroup3,
				changeKeyModeGroup5
			};
			changeKeyMode2.ChangeKeyModeGroupList = changeKeyModeGroupList;
			changeKeyMode.OnConfirmCallback = new Action<Dictionary<int, int>>(this.OnChangeLockEnemyMode);
			ChangeKeyMode param = changeKeyMode;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ChangeModeTipsView, param, null);
		}

		// Token: 0x06038E3D RID: 233021 RVA: 0x00E6B90C File Offset: 0x00E69B0C
		private void OnChangeLockEnemyMode(Dictionary<int, int> editRowIndexMap)
		{
			foreach (KeyValuePair<int, int> keyValuePair in editRowIndexMap)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (key == 0)
				{
					Singleton<GameSettingsManager>.Instance.HandleValueChange(EFunction.KeyboardLockEnemyMode, value, EGameSettingsApplyReason.WhenUi);
				}
				else if (key == 1)
				{
					Singleton<GameSettingsManager>.Instance.HandleValueChange(EFunction.GamepadLockEnemyMode, value, EGameSettingsApplyReason.WhenUi);
				}
			}
		}

		// Token: 0x06038E3E RID: 233022 RVA: 0x00E6B990 File Offset: 0x00E69B90
		public void OpenImageOverloadConfirmBox()
		{
			int? dataCacheOrCurValue = ModelBase<MenuModel>.Instance.GetDataCacheOrCurValue(EFunction.AutoAdjustImageQuality);
			if (dataCacheOrCurValue == null)
			{
				return;
			}
			if (dataCacheOrCurValue.Value == 1)
			{
				this.OpenImageQualityOverloadConfirmBox();
				return;
			}
			this.OpenImageQualityAdjustConfirmBox();
		}

		// Token: 0x06038E3F RID: 233023 RVA: 0x00E6B9D0 File Offset: 0x00E69BD0
		private void OpenImageQualityAdjustConfirmBox()
		{
			bool imageQualityAdjustEnable = false;
			Action<bool> toggleFunction = delegate(bool isSelectOn)
			{
				imageQualityAdjustEnable = isSelectOn;
			};
			Action value = delegate()
			{
				Singleton<GameSettingsManager>.Instance.HandleValueChange(EFunction.AutoAdjustImageQuality, (imageQualityAdjustEnable > false) ? 1 : 0, EGameSettingsApplyReason.WhenUi);
			};
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ImageQualityAdjustConfirm);
			confirmBoxDataNew.HasToggle = true;
			confirmBoxDataNew.ToggleText = (ConfigMultiTextLang.GetLocalTextNew("MenuConfig_145_Set_Tips", null) ?? "");
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.SetToggleFunction(toggleFunction);
			confirmBoxDataNew.FunctionMap.Add(2, value);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06038E40 RID: 233024 RVA: 0x00E6BA58 File Offset: 0x00E69C58
		public void OpenImageQualityOverloadConfirmBox()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PictureConfigOverload);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06038E41 RID: 233025 RVA: 0x00E6BA7C File Offset: 0x00E69C7C
		public void OpenFilterSettingView()
		{
			ControllerBase<FilterSettingController>.Instance.TryOpenExternalPreparedAsync().Forget<bool>();
		}

		// Token: 0x06038E42 RID: 233026 RVA: 0x00E6BA8D File Offset: 0x00E69C8D
		public void OpenEyeProtectView()
		{
			ControllerBase<EyeProtectController>.Instance.OpenEyeProtectView().Forget<bool>();
		}

		// Token: 0x06038E43 RID: 233027 RVA: 0x00E6BAA0 File Offset: 0x00E69CA0
		public bool NeedRedMagicFpsConfirmBox(int targetValue)
		{
			if (Singleton<GameSettingsDeviceRender>.Instance.IsRedMagic() && targetValue == 2)
			{
				int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.Vulkan, true, true);
				int num = 0;
				return currentValue.GetValueOrDefault() == num & currentValue != null;
			}
			return false;
		}

		// Token: 0x0402062F RID: 132655
		private const int SettingLogDefaultValue = 99999;

		// Token: 0x04020630 RID: 132656
		private const int REPORT_IMAGE_QUALITY_VALUE_FOR_CUSTOM = 99;

		// Token: 0x04020631 RID: 132657
		public readonly Dictionary<EUiViewName, Action> OpenViewFuncMap = new Dictionary<EUiViewName, Action>();
	}
}
