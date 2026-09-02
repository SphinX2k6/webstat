using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200182F RID: 6191
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ChannelController : UiControllerBase<ChannelController>
{
	// Token: 0x0600B0CA RID: 45258 RVA: 0x002F2F33 File Offset: 0x002F1133
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<ThirdPartySharedNotify>(ENotifyMessageId.ThirdPartySharedNotify, new Action<ThirdPartySharedNotify, Net.CallbackStatus>(this.OnGetThirdPartySharedNotify));
	}

	// Token: 0x0600B0CB RID: 45259 RVA: 0x002F2F51 File Offset: 0x002F1151
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ThirdPartySharedNotify);
	}

	// Token: 0x0600B0CC RID: 45260 RVA: 0x002F2F63 File Offset: 0x002F1163
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnShareResult, new Action<bool>(this.OnShareResultBack));
	}

	// Token: 0x0600B0CD RID: 45261 RVA: 0x002F2F81 File Offset: 0x002F1181
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnShareResult, new Action<bool>(this.OnShareResultBack));
	}

	// Token: 0x0600B0CE RID: 45262 RVA: 0x002F2FA0 File Offset: 0x002F11A0
	[NullableContext(2)]
	private void OnGetThirdPartySharedNotify(ThirdPartySharedNotify message, Net.CallbackStatus _)
	{
		if (message != null)
		{
			foreach (int id in message.SharedIds)
			{
				ModelBase<ChannelModel>.Instance.MarkActionShared((EShareActionId)id);
			}
		}
	}

	// Token: 0x0600B0CF RID: 45263 RVA: 0x002F2FF4 File Offset: 0x002F11F4
	public bool CheckShareChannelOpen(EChannelShare type)
	{
		return ModelBase<ChannelModel>.Instance.CheckShareChannelOpen(type);
	}

	// Token: 0x0600B0D0 RID: 45264 RVA: 0x002F3001 File Offset: 0x002F1201
	public bool CheckKuroStreetOpen()
	{
		return ModelBase<ChannelModel>.Instance.CheckKuroStreetOpen();
	}

	// Token: 0x0600B0D1 RID: 45265 RVA: 0x002F300D File Offset: 0x002F120D
	public bool CheckAccountSettingOpen(EChannelAccountSetting type)
	{
		return ModelBase<ChannelModel>.Instance.CheckAccountSettingOpen(type);
	}

	// Token: 0x0600B0D2 RID: 45266 RVA: 0x002F301A File Offset: 0x002F121A
	public bool CheckCustomerServiceOpen()
	{
		return ModelBase<ChannelModel>.Instance.CheckCustomerServiceOpen();
	}

	// Token: 0x0600B0D3 RID: 45267 RVA: 0x002F3026 File Offset: 0x002F1226
	public void OpenKuroStreet()
	{
		ModelBase<ChannelModel>.Instance.OpenKuroStreet();
	}

	// Token: 0x0600B0D4 RID: 45268 RVA: 0x002F3032 File Offset: 0x002F1232
	public void ProcessAccountSetting(EChannelAccountSetting type)
	{
		ModelBase<ChannelModel>.Instance.ProcessAccountSetting(type);
	}

	// Token: 0x0600B0D5 RID: 45269 RVA: 0x002F3040 File Offset: 0x002F1240
	public void OpenGameIntroduction()
	{
		string text = ModelBase<ChannelModel>.Instance.GameIntroductionUrl;
		if (string.IsNullOrEmpty(text))
		{
			if (ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk())
			{
				text = ConfigBase<CommonConfig>.Instance.GetGameIntroductionGlobalUrl();
			}
			else
			{
				text = ConfigBase<CommonConfig>.Instance.GetGameIntroductionUrl();
			}
		}
		string url = Singleton<PublicUtil>.Instance.GetExternalUrl(text, PublicUtil.EExternalUrlReason.GameIntroduction) ?? "";
		GameInformationClickLogEvent logData = new GameInformationClickLogEvent();
		ControllerBase<LogReportController>.Instance.LogReport(logData);
		ControllerBase<KuroSdkController>.Instance.OpenWebView("", url, true, true, true, "Default");
	}

	// Token: 0x0600B0D6 RID: 45270 RVA: 0x002F30C4 File Offset: 0x002F12C4
	public void OpenGameIntroductionByRoleId(int roleId)
	{
		string text = ModelBase<ChannelModel>.Instance.GameIntroductionUrl;
		if (string.IsNullOrEmpty(text))
		{
			if (ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk())
			{
				text = ConfigBase<CommonConfig>.Instance.GetGameIntroductionGlobalUrl();
			}
			else
			{
				text = ConfigBase<CommonConfig>.Instance.GetGameIntroductionUrl();
			}
		}
		string externalUrl = Singleton<PublicUtil>.Instance.GetExternalUrl(text, PublicUtil.EExternalUrlReason.GameIntroduction);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
		defaultInterpolatedStringHandler.AppendLiteral("&role_id=");
		defaultInterpolatedStringHandler.AppendFormatted<int>(roleId);
		string url = externalUrl + defaultInterpolatedStringHandler.ToStringAndClear();
		GameInformationClickLogEvent logData = new GameInformationClickLogEvent();
		ControllerBase<LogReportController>.Instance.LogReport(logData);
		ControllerBase<KuroSdkController>.Instance.OpenWebView("", url, true, true, true, "Default");
	}

	// Token: 0x0600B0D7 RID: 45271 RVA: 0x002F3168 File Offset: 0x002F1368
	public void RequestFirstShareReward(EShareActionId id)
	{
		ChannelController.<>c__DisplayClass13_0 CS$<>8__locals1 = new ChannelController.<>c__DisplayClass13_0();
		CS$<>8__locals1.id = id;
		ThirdPartyShareRequest thirdPartyShareRequest = ThirdPartyShareRequest.Create();
		thirdPartyShareRequest.SharedId = (int)CS$<>8__locals1.id;
		Singleton<Net>.Instance.Call<ThirdPartyShareResponse>(ERequestMessageId.ThirdPartyShareRequest, thirdPartyShareRequest, new Action<ThirdPartyShareResponse, Net.CallbackStatus>(CS$<>8__locals1.<RequestFirstShareReward>g__TempResponse|0), 0);
	}

	// Token: 0x0600B0D8 RID: 45272 RVA: 0x002F31B1 File Offset: 0x002F13B1
	public List<EChannelShare> GetOpenedShareIds()
	{
		return ModelBase<ChannelModel>.Instance.GetOpenedShareIds();
	}

	// Token: 0x0600B0D9 RID: 45273 RVA: 0x002F31BD File Offset: 0x002F13BD
	public bool CouldShare()
	{
		return ModelBase<ChannelModel>.Instance.GetOpenedShareIds().Count > 0;
	}

	// Token: 0x0600B0DA RID: 45274 RVA: 0x002F31D4 File Offset: 0x002F13D4
	[NullableContext(2)]
	public void ShareChannel(EChannelShare channel, TArray<byte> data, EShareActionId actionId, int shareConfigId, EShareReportExtraType reportExtraType)
	{
		if (data != null)
		{
			ModelBase<ChannelModel>.Instance.SharingActionId = actionId;
			ModelBase<ChannelModel>.Instance.SharingConfigId = shareConfigId;
			ModelBase<ChannelModel>.Instance.ShareReportExtraType = reportExtraType;
			ShareData shareData = new ShareData();
			ShareData shareData2 = shareData;
			int num = (int)channel;
			shareData2.platform = num.ToString();
			ControllerBase<KuroSdkController>.Instance.ShareByteData(shareData, data);
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.KuroSdk, ELogAuthor.JT, "分享图片数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600B0DB RID: 45275 RVA: 0x002F3248 File Offset: 0x002F1448
	private void OnShareResultBack(bool success)
	{
		EShareActionId sharingActionId = ModelBase<ChannelModel>.Instance.SharingActionId;
		int sharingConfigId = ModelBase<ChannelModel>.Instance.SharingConfigId;
		EShareReportExtraType shareReportExtraType = ModelBase<ChannelModel>.Instance.ShareReportExtraType;
		if (success && ModelBase<ChannelModel>.Instance.CouldGetShareReward(sharingActionId))
		{
			this.RequestFirstShareReward(sharingActionId);
		}
		this.RecordShare(sharingActionId, sharingConfigId, shareReportExtraType, success);
	}

	// Token: 0x0600B0DC RID: 45276 RVA: 0x002F3298 File Offset: 0x002F1498
	private void RecordShare(EShareActionId actionId, int shareConfigId, EShareReportExtraType reportExtraType, bool success)
	{
		ShareEvent shareEvent = new ShareEvent();
		shareEvent.i_share_channel = shareConfigId;
		shareEvent.i_share_result = ((success > false) ? 1 : 0);
		shareEvent.i_share_scene = (int)actionId;
		shareEvent.i_extra_choose = (int)reportExtraType;
		ControllerBase<LogReportController>.Instance.LogReport(shareEvent);
	}

	// Token: 0x0600B0DD RID: 45277 RVA: 0x002F32D8 File Offset: 0x002F14D8
	public void ShareGacha(IReadOnlyList<global::GachaResult> result)
	{
		EShareActionId shareId = EShareActionId.TenGacha;
		if (result.Count == 1)
		{
			shareId = ((ConfigBase<GachaConfig>.Instance.GetItemIdType(result[0].Proto_GachaReward.ItemId) == InventoryDefine.EItemDataType.WeaponItem) ? EShareActionId.Weapon : EShareActionId.Character);
		}
		PhotoSaveViewParam param = new PhotoSaveViewParam
		{
			ScreenShot = false,
			IsHiddenBattleView = false,
			HandBookPhotoData = null,
			GachaData = result,
			ShareId = (int)shareId
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhotoSaveView, param, null);
	}
}
