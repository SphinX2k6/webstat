using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A2B RID: 18987
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MobileSwitchInputController : Singleton<MobileSwitchInputController>
	{
		// Token: 0x060319E2 RID: 203234 RVA: 0x00C5C9ED File Offset: 0x00C5ABED
		private void ResetState()
		{
			this.IsInSwitching = false;
		}

		// Token: 0x060319E3 RID: 203235 RVA: 0x00C5C9F8 File Offset: 0x00C5ABF8
		private void ChooseSwitch()
		{
			if (Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.MobileGamepadMode, true, true).GetValueOrDefault() != 1)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Controler_Notconnect_tips", Array.Empty<object>());
				return;
			}
			this.NeedSwitch = true;
		}

		// Token: 0x060319E4 RID: 203236 RVA: 0x00C5CA40 File Offset: 0x00C5AC40
		private void ShowMobileSwitchInputView()
		{
			EInputControllerType? inputControllerType = this.CacheInputControllerType;
			this.CacheInputControllerType = null;
			this.IsInSwitching = false;
			if (!this.NeedSwitch)
			{
				return;
			}
			this.NeedSwitch = false;
			this.ClearAllView().ContinueWith(delegate()
			{
				this.OpenMobileSwitchInputView(true);
				Singleton<Info>.Instance.SwitchInputControllerType(inputControllerType.Value, "MobileSwitch");
			});
		}

		// Token: 0x060319E5 RID: 203237 RVA: 0x00C5CAA4 File Offset: 0x00C5ACA4
		private UniTask ClearAllView()
		{
			MobileSwitchInputController.<ClearAllView>d__9 <ClearAllView>d__;
			<ClearAllView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ClearAllView>d__.<>1__state = -1;
			<ClearAllView>d__.<>t__builder.Start<MobileSwitchInputController.<ClearAllView>d__9>(ref <ClearAllView>d__);
			return <ClearAllView>d__.<>t__builder.Task;
		}

		// Token: 0x060319E6 RID: 203238 RVA: 0x00C5CAE0 File Offset: 0x00C5ACE0
		private bool CheckOpenViewInMobileSwitch(EUiViewName viewName, object param)
		{
			if (viewName == EUiViewName.MobileSwitchInputView)
			{
				return true;
			}
			UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(viewName);
			if (uiViewInfo != null && (uiViewInfo.Type & (ELayerType.NetWork | ELayerType.CG)) > (ELayerType)0)
			{
				return true;
			}
			this.CacheOpenViewMap[viewName] = new MobileSwitchInputController.CacheData
			{
				UiViewName = viewName,
				Param = param
			};
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MobileInputSwitch;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "缓存切换期间打开的界面数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewName", viewName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}

		// Token: 0x060319E7 RID: 203239 RVA: 0x00C5CB6C File Offset: 0x00C5AD6C
		private void ReOpenCacheView()
		{
			foreach (MobileSwitchInputController.ICacheData cacheData in this.CacheOpenViewMap.Values)
			{
				Singleton<UiManager>.Instance.OpenView(cacheData.UiViewName, cacheData.Param, null);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MobileInputSwitch;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "重新打开切换期间打开的界面数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewName", cacheData.UiViewName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.CacheOpenViewMap.Clear();
		}

		// Token: 0x060319E8 RID: 203240 RVA: 0x00C5CC14 File Offset: 0x00C5AE14
		private void OpenMobileSwitchInputView(bool isSwitchToGamepad)
		{
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.All, new Func<EUiViewName, object, bool>(this.CheckOpenViewInMobileSwitch), "MobileSwitchInput");
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MobileSwitchInputView, isSwitchToGamepad, null);
		}

		// Token: 0x060319E9 RID: 203241 RVA: 0x00C5CC4C File Offset: 0x00C5AE4C
		private bool CanMobileSwitchInputCondition()
		{
			if (!Singleton<Info>.Instance.IsMobileInputModel())
			{
				return false;
			}
			if (!Singleton<UiModel>.Instance.IsInMainView)
			{
				return false;
			}
			BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
			return instance != null && instance.IsEnableChangeInputControllerOnMobile() && ModelBase<InputDistributeModel>.Instance.IsTagMatchAnyCurrentInputTag("FightInputRoot", false);
		}

		// Token: 0x060319EA RID: 203242 RVA: 0x00C5CCA4 File Offset: 0x00C5AEA4
		public void ReOpenBattleView(bool _)
		{
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.All, new Func<EUiViewName, object, bool>(this.CheckOpenViewInMobileSwitch));
			ControllerBase<BattleUiControl>.Instance.OpenMainView();
			if (!Singleton<CloudGameManager>.Instance.IsCloudGame)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PingView, null, null);
			}
			this.ReOpenCacheView();
		}

		// Token: 0x060319EB RID: 203243 RVA: 0x00C5CCFC File Offset: 0x00C5AEFC
		public void SwitchToGamepadByMenuSetting()
		{
			if (!Singleton<Info>.Instance.IsMobileInputModel())
			{
				return;
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.MobileInputSwitch, ELogAuthor.XXJ, "[MenuSetting]触屏切换手柄", default(ReadOnlySpan<ValueTuple<string, object>>));
			EInputControllerType inputControllerType = ModelBase<PlatformModel>.Instance.GetCurrentDeviceInputController();
			this.ClearAllView().ContinueWith(delegate()
			{
				this.OpenMobileSwitchInputView(true);
				Singleton<Info>.Instance.SwitchInputControllerType(inputControllerType, "MenuSetting");
			});
		}

		// Token: 0x060319EC RID: 203244 RVA: 0x00C5CD78 File Offset: 0x00C5AF78
		[NullableContext(1)]
		public void SwitchToGamepad(EInputControllerType? inputType, string reason)
		{
			if (inputType == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MobileInputSwitch;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "触屏切换手柄异常,传入无效的输入设备类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (!this.CanMobileSwitchInputCondition())
			{
				return;
			}
			this.CacheInputControllerType = inputType;
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			if (this.IsInSwitching)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.MobileInputSwitch, ELogAuthor.XXJ, "触屏切换手柄", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsInSwitching = true;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MobileInputSwitch);
			confirmBoxDataNew.FunctionMap[1] = new Action(this.ResetState);
			confirmBoxDataNew.FunctionMap[2] = new Action(this.ChooseSwitch);
			confirmBoxDataNew.SetCloseFunction(new Action(this.ShowMobileSwitchInputView));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x060319ED RID: 203245 RVA: 0x00C5CE60 File Offset: 0x00C5B060
		public void SwitchToTouch()
		{
			if (!Singleton<Info>.Instance.IsMobileInputModel())
			{
				return;
			}
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.MobileInputSwitch, ELogAuthor.XXJ, "手柄切换触屏", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.ClearAllView().ContinueWith(delegate()
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.MobileGamepadDisconnect);
				this.OpenMobileSwitchInputView(false);
				Singleton<Info>.Instance.SwitchInputControllerType(EInputControllerType.Touch, "MobileSwitch");
			});
		}

		// Token: 0x060319EE RID: 203246 RVA: 0x00C5CEC0 File Offset: 0x00C5B0C0
		public bool SwitchToTouchByDisconnectGamepad()
		{
			if (!this.CanMobileSwitchInputCondition())
			{
				return false;
			}
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return false;
			}
			Singleton<Log>.Instance.Info(ELogModule.MobileInputSwitch, ELogAuthor.XXJ, "手柄切换触屏DisconnectGamepad", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.ClearAllView().ContinueWith(delegate()
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.MobileGamepadDisconnect);
				this.OpenMobileSwitchInputView(false);
				Singleton<Info>.Instance.SwitchInputControllerType(EInputControllerType.Touch, "MobileSwitch");
			});
			return true;
		}

		// Token: 0x0401CE21 RID: 118305
		private bool NeedSwitch;

		// Token: 0x0401CE22 RID: 118306
		private bool IsInSwitching;

		// Token: 0x0401CE23 RID: 118307
		private EInputControllerType? CacheInputControllerType;

		// Token: 0x0401CE24 RID: 118308
		[Nullable(1)]
		private readonly Dictionary<EUiViewName, MobileSwitchInputController.ICacheData> CacheOpenViewMap = new Dictionary<EUiViewName, MobileSwitchInputController.ICacheData>();

		// Token: 0x0200AA8D RID: 43661
		private interface ICacheData
		{
			// Token: 0x1700A948 RID: 43336
			// (get) Token: 0x0604B3DF RID: 308191
			// (set) Token: 0x0604B3E0 RID: 308192
			EUiViewName UiViewName { get; set; }

			// Token: 0x1700A949 RID: 43337
			// (get) Token: 0x0604B3E1 RID: 308193
			// (set) Token: 0x0604B3E2 RID: 308194
			object Param { get; set; }
		}

		// Token: 0x0200AA8E RID: 43662
		[Nullable(0)]
		private class CacheData : MobileSwitchInputController.ICacheData
		{
			// Token: 0x1700A94A RID: 43338
			// (get) Token: 0x0604B3E3 RID: 308195 RVA: 0x01483185 File Offset: 0x01481385
			// (set) Token: 0x0604B3E4 RID: 308196 RVA: 0x0148318D File Offset: 0x0148138D
			public EUiViewName UiViewName { get; set; }

			// Token: 0x1700A94B RID: 43339
			// (get) Token: 0x0604B3E5 RID: 308197 RVA: 0x01483196 File Offset: 0x01481396
			// (set) Token: 0x0604B3E6 RID: 308198 RVA: 0x0148319E File Offset: 0x0148139E
			public object Param { get; set; }
		}
	}
}
