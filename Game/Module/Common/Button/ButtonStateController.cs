using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiComponent.UiHomeButton;

namespace CSharpScript.Game.Module.Common.Button
{
	// Token: 0x02005E85 RID: 24197
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ButtonStateController : ControllerBase<ButtonStateController>
	{
		// Token: 0x0603CDA2 RID: 249250 RVA: 0x00F722E8 File Offset: 0x00F704E8
		protected override bool OnInit()
		{
			Dictionary<ButtonType, IModelBase> dictionary = new Dictionary<ButtonType, IModelBase>();
			dictionary[ButtonType.Home] = ModelBase<HomeBtnModel>.Instance;
			this.ButtonTypeMap = dictionary;
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			return true;
		}

		// Token: 0x0603CDA3 RID: 249251 RVA: 0x00F72320 File Offset: 0x00F70520
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			this.CancelTimer();
			Dictionary<ButtonType, IModelBase> buttonTypeMap = this.ButtonTypeMap;
			if (buttonTypeMap != null)
			{
				buttonTypeMap.Clear();
			}
			this.ButtonTypeMap = null;
			this.LastServerTime = 0.0;
			return true;
		}

		// Token: 0x0603CDA4 RID: 249252 RVA: 0x00F72377 File Offset: 0x00F70577
		private void OnWorldDone()
		{
			this.RequestBtnState();
			this.InitTimer();
		}

		// Token: 0x0603CDA5 RID: 249253 RVA: 0x00F72385 File Offset: 0x00F70585
		private void CancelTimer()
		{
			if (this.CheckStateTimer != null)
			{
				TimerSystem.RealTimeInstance.Remove(this.CheckStateTimer);
				this.CheckStateTimer = null;
			}
		}

		// Token: 0x0603CDA6 RID: 249254 RVA: 0x00F723A7 File Offset: 0x00F705A7
		private void InitTimer()
		{
			this.CancelTimer();
			this.CheckStateTimer = TimerSystem.RealTimeInstance.Forever(new TTimerAction(this.OnCheckStateTimer), 120000f, 1f, null, null, true);
		}

		// Token: 0x0603CDA7 RID: 249255 RVA: 0x00F723D8 File Offset: 0x00F705D8
		private void OnCheckStateTimer(float _)
		{
			this.RequestBtnState();
		}

		// Token: 0x0603CDA8 RID: 249256 RVA: 0x00F723E0 File Offset: 0x00F705E0
		public unsafe void RequestBtnState()
		{
			if (this.ButtonTypeMap == null)
			{
				return;
			}
			if (Singleton<Time>.Instance.ServerTimeStamp - this.LastServerTime <= 120000.0)
			{
				return;
			}
			this.LastServerTime = Singleton<Time>.Instance.ServerTimeStamp;
			Singleton<Log>.Instance.Info(ELogModule.HomeBtn, ELogAuthor.CB, "向服务器请求按钮状态", default(ReadOnlySpan<ValueTuple<string, object>>));
			ButtonIsEnableRequest buttonIsEnableRequest = ButtonIsEnableRequest.Create();
			foreach (ButtonType item in this.ButtonTypeMap.Keys)
			{
				buttonIsEnableRequest.Types_.Add(item);
			}
			Singleton<Net>.Instance.Call<ButtonIsEnableResponse>(ERequestMessageId.ButtonIsEnableRequest, buttonIsEnableRequest, delegate(ButtonIsEnableResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.ButtonIsEnableResponse, null, true, true);
					return;
				}
				foreach (ButtonEnableResult buttonEnableResult in response.Result)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.HomeBtn;
					ELogAuthor author = ELogAuthor.CB;
					string message = "服务器下发按钮状态";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", buttonEnableResult.Type);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Enable", buttonEnableResult.Enable);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					IModelBase target;
					if (this.ButtonTypeMap.TryGetValue(buttonEnableResult.Type, out target))
					{
						Singleton<EventSystem>.Instance.EmitWithTarget<bool>(target, EEventName.BtnStateUpdate, buttonEnableResult.Enable);
					}
				}
			}, 0);
		}

		// Token: 0x0402229C RID: 139932
		private const int CheckGap = 120000;

		// Token: 0x0402229D RID: 139933
		private TimerHandle CheckStateTimer;

		// Token: 0x0402229E RID: 139934
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<ButtonType, IModelBase> ButtonTypeMap;

		// Token: 0x0402229F RID: 139935
		private double LastServerTime;
	}
}
