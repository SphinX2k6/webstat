using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.WorldMap.RegionalTerminal
{
	// Token: 0x02004BED RID: 19437
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RegionalTerminalController : ControllerBase<RegionalTerminalController>
	{
		// Token: 0x06032B61 RID: 207713 RVA: 0x00CB3C2B File Offset: 0x00CB1E2B
		protected override bool OnInit()
		{
			this.OnRegisterNetEvent();
			return true;
		}

		// Token: 0x06032B62 RID: 207714 RVA: 0x00CB3C34 File Offset: 0x00CB1E34
		protected override bool OnClear()
		{
			this.OnUnRegisterNetEvent();
			return true;
		}

		// Token: 0x06032B63 RID: 207715 RVA: 0x00CB3C3D File Offset: 0x00CB1E3D
		protected void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<AreaTerminalInfoNotify>(ENotifyMessageId.AreaTerminalInfoNotify, new Action<AreaTerminalInfoNotify, Net.CallbackStatus>(this.OnAreaTerminalInfoNotify));
		}

		// Token: 0x06032B64 RID: 207716 RVA: 0x00CB3C5B File Offset: 0x00CB1E5B
		protected void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AreaTerminalInfoNotify);
		}

		// Token: 0x06032B65 RID: 207717 RVA: 0x00CB3C70 File Offset: 0x00CB1E70
		private void OnAreaTerminalInfoNotify(AreaTerminalInfoNotify message, Net.CallbackStatus callbackStatus)
		{
			ModelBase<RegionalTerminalModel>.Instance.InitGameplayPin(message.PinIds);
			foreach (AreaTerminalFuncConditionInfo areaTerminalFuncConditionInfo in message.AreaTerminalFuncConditionInfos)
			{
				ModelBase<RegionalTerminalModel>.Instance.UpdateFuncIdConditionFinishedState(areaTerminalFuncConditionInfo.FuncId, areaTerminalFuncConditionInfo.FinishConditionIds);
			}
			if (message.AreaMapGroup.Count > 0)
			{
				foreach (int unlockAreaMapGroupId in message.AreaMapGroup)
				{
					ModelBase<RegionalTerminalModel>.Instance.SetUnlockAreaMapGroupId(unlockAreaMapGroupId);
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Map;
				ELogAuthor author = ELogAuthor.YYZ;
				string message2 = "[RegionalTerminal] UnlockAreaMapGroup";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Ids", message.AreaMapGroup);
				instance.Info(module, author, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x06032B66 RID: 207718 RVA: 0x00CB3D58 File Offset: 0x00CB1F58
		public void RequestTerminalPinOperation(int gameplayId, bool isPin, Action<bool> callback = null)
		{
			AreaTerminalPinOperationRequest areaTerminalPinOperationRequest = new AreaTerminalPinOperationRequest();
			areaTerminalPinOperationRequest.Id = gameplayId;
			areaTerminalPinOperationRequest.OpType = isPin;
			Singleton<Net>.Instance.Call<AreaTerminalPinOperationResponse>(ERequestMessageId.AreaTerminalPinOperationRequest, areaTerminalPinOperationRequest, delegate(AreaTerminalPinOperationResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else if (response.Code != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, EResponseMessageId.AreaTerminalPinOperationResponse, null, true, true);
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(false);
					return;
				}
				else
				{
					ModelBase<RegionalTerminalModel>.Instance.UpdateGameplayPin(gameplayId, isPin);
					Action<bool> callback4 = callback;
					if (callback4 == null)
					{
						return;
					}
					callback4(true);
					return;
				}
			}, 0);
		}

		// Token: 0x06032B67 RID: 207719 RVA: 0x00CB3DBC File Offset: 0x00CB1FBC
		public void OpenTerminalOverviewView(int id = 0)
		{
			RegionalTerminalViewParams regionalTerminalViewParams = new RegionalTerminalViewParams();
			regionalTerminalViewParams.GameplayId = id;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RegionalTerminalOverviewView, regionalTerminalViewParams, null);
		}
	}
}
