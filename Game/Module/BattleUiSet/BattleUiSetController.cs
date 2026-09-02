using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using Google.Protobuf;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.BattleUiSet
{
	// Token: 0x02006134 RID: 24884
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class BattleUiSetController : UiControllerBase<BattleUiSetController>
	{
		// Token: 0x0603ED9C RID: 257436 RVA: 0x0101A68F File Offset: 0x0101888F
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603ED9D RID: 257437 RVA: 0x0101A692 File Offset: 0x01018892
		protected override bool OnClear()
		{
			return true;
		}

		// Token: 0x0603ED9E RID: 257438 RVA: 0x0101A695 File Offset: 0x01018895
		protected override void OnRegisterNetEvent()
		{
			Net instance = Singleton<Net>.Instance;
			ENotifyMessageId id = ENotifyMessageId.SettingNotify;
			Action<SettingNotify, Net.CallbackStatus> callback;
			if ((callback = BattleUiSetController.<>O.<0>__SettingNotify) == null)
			{
				callback = (BattleUiSetController.<>O.<0>__SettingNotify = new Action<SettingNotify, Net.CallbackStatus>(BattleUiSetController.SettingNotify));
			}
			instance.Register<SettingNotify>(id, callback);
		}

		// Token: 0x0603ED9F RID: 257439 RVA: 0x0101A6C2 File Offset: 0x010188C2
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SettingNotify);
		}

		// Token: 0x0603EDA0 RID: 257440 RVA: 0x0101A6D4 File Offset: 0x010188D4
		private static void SettingNotify(SettingNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BattleUiSet;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "SettingNotify 通知移动端按键设置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("notify", notify);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			RepeatedField<MobileButtonSetting> mobileButtonSettings = notify.MobileButtonSettings;
			if (mobileButtonSettings == null)
			{
				return;
			}
			BattleUiSetModel instance2 = ModelBase<BattleUiSetModel>.Instance;
			foreach (MobileButtonSetting mobileButtonSetting in mobileButtonSettings)
			{
				int id = mobileButtonSetting.Id;
				BattleUiSetPanelItemData panelItemDataByConfigId = instance2.GetPanelItemDataByConfigId(id);
				if (panelItemDataByConfigId == null)
				{
					break;
				}
				panelItemDataByConfigId.Size = mobileButtonSetting.Size;
				panelItemDataByConfigId.EditSize = mobileButtonSetting.Size;
				panelItemDataByConfigId.Alpha = mobileButtonSetting.Transparency;
				panelItemDataByConfigId.EditAlpha = mobileButtonSetting.Transparency;
				panelItemDataByConfigId.OffsetX = mobileButtonSetting.ScreenX;
				panelItemDataByConfigId.EditOffsetX = mobileButtonSetting.ScreenX;
				panelItemDataByConfigId.OffsetY = mobileButtonSetting.ScreenY;
				panelItemDataByConfigId.EditOffsetY = mobileButtonSetting.ScreenY;
				panelItemDataByConfigId.HierarchyIndex = mobileButtonSetting.ButtonLevel;
				panelItemDataByConfigId.EditorHierarchyIndex = mobileButtonSetting.ButtonLevel;
			}
		}

		// Token: 0x0603EDA1 RID: 257441 RVA: 0x0101A800 File Offset: 0x01018A00
		public static void MobileButtonSettingUpdateRequest(IReadOnlyList<MobileButtonSetting> settings)
		{
			MobileButtonSettingUpdateRequest mobileButtonSettingUpdateRequest = Aki.Protocol.MobileButtonSettingUpdateRequest.Create();
			mobileButtonSettingUpdateRequest.MobileButtonSettings.AddRange(settings);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BattleUiSet;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "MobileButtonSettingUpdateRequest 客户端请求移动端键位设置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("request", mobileButtonSettingUpdateRequest);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Net instance2 = Singleton<Net>.Instance;
			ERequestMessageId requestMessageId = ERequestMessageId.MobileButtonSettingUpdateRequest;
			IMessage message2 = mobileButtonSettingUpdateRequest;
			Action<MobileButtonSettingUpdateResponse, Net.CallbackStatus> handle;
			if ((handle = BattleUiSetController.<>O.<1>__MobileButtonSettingUpdateResponse) == null)
			{
				handle = (BattleUiSetController.<>O.<1>__MobileButtonSettingUpdateResponse = new Action<MobileButtonSettingUpdateResponse, Net.CallbackStatus>(BattleUiSetController.MobileButtonSettingUpdateResponse));
			}
			instance2.Call<MobileButtonSettingUpdateResponse>(requestMessageId, message2, handle, 0);
		}

		// Token: 0x0603EDA2 RID: 257442 RVA: 0x0101A878 File Offset: 0x01018A78
		[NullableContext(2)]
		private static void MobileButtonSettingUpdateResponse(MobileButtonSettingUpdateResponse response, Net.CallbackStatus status)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BattleUiSet;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "MobileButtonSettingUpdateResponse 服务端返回移动端键位设置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("response", response);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29928, null, true, true);
				return;
			}
			GenericPromptController instance2 = ControllerBase<GenericPromptController>.Instance;
			BattleUiPureModeData pureModeData = ModelBase<BattleUiModel>.Instance.PureModeData;
			instance2.ShowPromptByCode((pureModeData != null && pureModeData.IsOpen) ? "SaveButtonPureMode" : "SaveButton", Array.Empty<object>());
		}

		// Token: 0x0200C2B7 RID: 49847
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403C08C RID: 245900
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<SettingNotify, Net.CallbackStatus> <0>__SettingNotify;

			// Token: 0x0403C08D RID: 245901
			[Nullable(new byte[]
			{
				0,
				2,
				2
			})]
			public static Action<MobileButtonSettingUpdateResponse, Net.CallbackStatus> <1>__MobileButtonSettingUpdateResponse;
		}
	}
}
