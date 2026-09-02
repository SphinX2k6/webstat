using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02001A7F RID: 6783
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ConfirmBoxController : ControllerBase<ConfirmBoxController>
{
	// Token: 0x0600C220 RID: 49696 RVA: 0x003326DC File Offset: 0x003308DC
	public bool ShowConfirmBoxNew(ConfirmBoxDataNew confirmBoxDataNew)
	{
		ConfirmBox? confirmBoxConfig = ConfigBase<ConfirmBoxConfig>.Instance.GetConfirmBoxConfig((int)confirmBoxDataNew.ConfigId);
		if (confirmBoxConfig != null && confirmBoxConfig.GetValueOrDefault().ToggleType == 1)
		{
			ConfirmBoxModel instance = ModelBase<ConfirmBoxModel>.Instance;
			if (instance != null && instance.NotShowAgainSet.Contains(confirmBoxDataNew.ConfigId))
			{
				Action action;
				if (confirmBoxDataNew.FunctionMap.TryGetValue(2, out action) && action != null)
				{
					action();
				}
				return false;
			}
		}
		EUiViewName? uiViewName = this.GetUiViewName((int)confirmBoxDataNew.ConfigId);
		if (confirmBoxDataNew.FunctionMap.Count > 0)
		{
			confirmBoxDataNew.IsMultipleView = true;
		}
		if (uiViewName != null)
		{
			Singleton<UiManager>.Instance.OpenView(uiViewName.Value, confirmBoxDataNew, confirmBoxDataNew.FinishOpenFunction);
			return true;
		}
		return false;
	}

	// Token: 0x0600C221 RID: 49697 RVA: 0x00332794 File Offset: 0x00330994
	public bool CheckIsConfirmBoxOpen()
	{
		foreach (EUiViewName viewName in this.ConfirmBoxMapNameMap.Values)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600C222 RID: 49698 RVA: 0x003327FC File Offset: 0x003309FC
	public void CloseConfirmBoxView()
	{
		foreach (EUiViewName name in this.ConfirmBoxMapNameMap.Values)
		{
			Singleton<UiManager>.Instance.CloseView(name, null);
		}
	}

	// Token: 0x0600C223 RID: 49699 RVA: 0x0033285C File Offset: 0x00330A5C
	public void ShowNetWorkConfirmBoxView(ConfirmBoxDataNew confirmBoxDataNew, [Nullable(2)] TOpenViewCallBack finishCallback = null)
	{
		confirmBoxDataNew.NotAddChildToTopStackView = true;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.NetWorkConfirmBoxView, confirmBoxDataNew, finishCallback);
	}

	// Token: 0x0600C224 RID: 49700 RVA: 0x00332876 File Offset: 0x00330A76
	[NullableContext(2)]
	public void CloseNetWorkConfirmBoxView(int viewId, Action<bool> finishCallback = null)
	{
		Singleton<UiManager>.Instance.CloseViewById(viewId, finishCallback);
	}

	// Token: 0x0600C225 RID: 49701 RVA: 0x00332884 File Offset: 0x00330A84
	public void ShowFirstCurrencyConfirm()
	{
		int? num = ConfigBase<GachaConfig>.Instance.PrimaryCurrency();
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FirstCurrency);
		if (num == null)
		{
			return;
		}
		string itemName = ConfigBase<ItemConfig>.Instance.GetItemName(num.Value);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			itemName
		});
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<PayShopController>.Instance.OpenPayShopViewToRecharge();
		};
		this.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600C226 RID: 49702 RVA: 0x00332904 File Offset: 0x00330B04
	public void ShowExitGameConfirmBox()
	{
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			ControllerBase<KuroSdkController>.Instance.PostKuroSdkEvent(EKuroSdkEventKey.KUROSDKEXIT);
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ExitGame);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			if (GlobalData.IsPlayInEditor)
			{
				UKismetSystemLibrary.QuitGame(GlobalData.World, null, EQuitPreference.Quit, false);
				return;
			}
			KuroApplication.ExitWithReason(false, "ExitGameConfirmBox");
		};
		this.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600C227 RID: 49703 RVA: 0x00332964 File Offset: 0x00330B64
	public void ShowReturnLoginConfirmBox()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ExitGameOrReturnLogin);
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<ReConnectController>.Instance.Logout(ELogoutReason.ExitGameConfirmBox);
		};
		confirmBoxDataNew.FunctionMap[1] = delegate()
		{
			ControllerBase<KuroSdkController>.Instance.PostKuroSdkEvent(EKuroSdkEventKey.KUROSDKEXIT);
		};
		this.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600C228 RID: 49704 RVA: 0x003329E4 File Offset: 0x00330BE4
	public EUiViewName? GetUiViewName(int configId)
	{
		EConfirmBoxType valueOrDefault = (EConfirmBoxType)ConfigBase<ConfirmBoxConfig>.Instance.GetUiShowType(configId).GetValueOrDefault();
		EUiViewName value;
		if (!this.ConfirmBoxMapNameMap.TryGetValue(valueOrDefault, out value))
		{
			return null;
		}
		return new EUiViewName?(value);
	}

	// Token: 0x04005AF8 RID: 23288
	private readonly Dictionary<EConfirmBoxType, EUiViewName> ConfirmBoxMapNameMap = new Dictionary<EConfirmBoxType, EUiViewName>
	{
		{
			EConfirmBoxType.Small,
			EUiViewName.ConfirmBoxView
		},
		{
			EConfirmBoxType.Middle,
			EUiViewName.ConfirmBoxMiddleView
		},
		{
			EConfirmBoxType.MiddleWithoutItem,
			EUiViewName.ConfirmBoxMiddleWithoutItemView
		},
		{
			EConfirmBoxType.RacingBets,
			EUiViewName.RacingBetsConfirmBoxView
		},
		{
			EConfirmBoxType.FloroRanch,
			EUiViewName.FloroRanchConfirmBoxView
		},
		{
			EConfirmBoxType.Cyberpunk,
			EUiViewName.CyberpunkConfirmBoxView
		},
		{
			EConfirmBoxType.KurotatoSave,
			EUiViewName.KurotatoPopupSaveView
		}
	};
}
