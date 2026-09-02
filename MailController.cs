using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Functional;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;

// Token: 0x02002222 RID: 8738
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class MailController : UiControllerBase<MailController>
{
	// Token: 0x06010798 RID: 67480 RVA: 0x0047FCC8 File Offset: 0x0047DEC8
	public static void ShowMailFloatTipsByTextKey(string textKey)
	{
		string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(textKey, "");
		if (StringUtils.IsEmpty(multiTextByKey))
		{
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(multiTextByKey);
	}

	// Token: 0x06010799 RID: 67481 RVA: 0x0047FCFA File Offset: 0x0047DEFA
	public static bool CanOpenView(EUiViewName viewName, object param)
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10020);
	}

	// Token: 0x0601079A RID: 67482 RVA: 0x0047FD0B File Offset: 0x0047DF0B
	protected override void OnAddOpenViewCheckFunction()
	{
		UiManager instance = Singleton<UiManager>.Instance;
		EUiViewName mailBoxView = EUiViewName.MailBoxView;
		Func<EUiViewName, object, bool> func;
		if ((func = MailController.<>O.<0>__CanOpenView) == null)
		{
			func = (MailController.<>O.<0>__CanOpenView = new Func<EUiViewName, object, bool>(MailController.CanOpenView));
		}
		instance.AddOpenViewCheckFunction(mailBoxView, func, "MailController.CanOpenView");
	}

	// Token: 0x0601079B RID: 67483 RVA: 0x0047FD3C File Offset: 0x0047DF3C
	protected override void OnRemoveOpenViewCheckFunction()
	{
		UiManager instance = Singleton<UiManager>.Instance;
		EUiViewName editFormationView = EUiViewName.EditFormationView;
		Func<EUiViewName, object, bool> func;
		if ((func = MailController.<>O.<0>__CanOpenView) == null)
		{
			func = (MailController.<>O.<0>__CanOpenView = new Func<EUiViewName, object, bool>(MailController.CanOpenView));
		}
		instance.RemoveOpenViewCheckFunction(editFormationView, func);
	}

	// Token: 0x0601079C RID: 67484 RVA: 0x0047FD68 File Offset: 0x0047DF68
	protected override void OnAddEvents()
	{
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.WorldDoneAndCloseLoading;
		Action handle;
		if ((handle = MailController.<>O.<1>__OnWorldDoneAndCloseLoading) == null)
		{
			handle = (MailController.<>O.<1>__OnWorldDoneAndCloseLoading = new Action(MailController.OnWorldDoneAndCloseLoading));
		}
		instance.Add(name, handle);
	}

	// Token: 0x0601079D RID: 67485 RVA: 0x0047FD95 File Offset: 0x0047DF95
	protected override void OnRemoveEvents()
	{
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.WorldDoneAndCloseLoading;
		Action handle;
		if ((handle = MailController.<>O.<1>__OnWorldDoneAndCloseLoading) == null)
		{
			handle = (MailController.<>O.<1>__OnWorldDoneAndCloseLoading = new Action(MailController.OnWorldDoneAndCloseLoading));
		}
		instance.Remove(name, handle);
	}

	// Token: 0x0601079E RID: 67486 RVA: 0x0047FDC4 File Offset: 0x0047DFC4
	protected override void OnRegisterNetEvent()
	{
		Net instance = Singleton<Net>.Instance;
		ENotifyMessageId id = ENotifyMessageId.MailInfosNotify;
		Action<MailInfosNotify, Net.CallbackStatus> callback;
		if ((callback = MailController.<>O.<2>__OnMailInfosNotify) == null)
		{
			callback = (MailController.<>O.<2>__OnMailInfosNotify = new Action<MailInfosNotify, Net.CallbackStatus>(MailController.OnMailInfosNotify));
		}
		instance.Register<MailInfosNotify>(id, callback);
		Net instance2 = Singleton<Net>.Instance;
		ENotifyMessageId id2 = ENotifyMessageId.MailDeleteNotify;
		Action<MailDeleteNotify, Net.CallbackStatus> callback2;
		if ((callback2 = MailController.<>O.<3>__OnMailDeleteNotify) == null)
		{
			callback2 = (MailController.<>O.<3>__OnMailDeleteNotify = new Action<MailDeleteNotify, Net.CallbackStatus>(MailController.OnMailDeleteNotify));
		}
		instance2.Register<MailDeleteNotify>(id2, callback2);
		Net instance3 = Singleton<Net>.Instance;
		ENotifyMessageId id3 = ENotifyMessageId.MailAddNotify;
		Action<MailAddNotify, Net.CallbackStatus> callback3;
		if ((callback3 = MailController.<>O.<4>__OnMailAddNotify) == null)
		{
			callback3 = (MailController.<>O.<4>__OnMailAddNotify = new Action<MailAddNotify, Net.CallbackStatus>(MailController.OnMailAddNotify));
		}
		instance3.Register<MailAddNotify>(id3, callback3);
	}

	// Token: 0x0601079F RID: 67487 RVA: 0x0047FE52 File Offset: 0x0047E052
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MailInfosNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MailDeleteNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MailAddNotify);
	}

	// Token: 0x060107A0 RID: 67488 RVA: 0x0047FE84 File Offset: 0x0047E084
	private static void OnMailInfosNotify(MailInfosNotify response, [Nullable(2)] Net.CallbackStatus status)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件控制器：OnMailInfosNotify [Mail]6100 Mails response, length: ";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("response.MailInfos.length", response.MailInfos.Count);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		foreach (PbMailInfo mailInfo in response.MailInfos)
		{
			if (ModelBase<MailModel>.Instance.GetMailListLength() >= ModelBase<MailModel>.Instance.GetMailCapacity())
			{
				Singleton<Log>.Instance.Error(ELogModule.Mail, ELogAuthor.YZY, "[MailError]MailBox is fulfilled", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			ModelBase<MailModel>.Instance.AddMail(mailInfo, false);
		}
		ModelBase<MailModel>.Instance.ReloadMailList();
		ModelBase<MailModel>.Instance.RefreshLocalNewMailMap();
		MailController.TryShowNewMailTips("NewMail");
	}

	// Token: 0x060107A1 RID: 67489 RVA: 0x0047FF5C File Offset: 0x0047E15C
	private static void OnMailDeleteNotify(MailDeleteNotify response, [Nullable(2)] Net.CallbackStatus status)
	{
		string id = response.Id;
		ModelBase<MailModel>.Instance.DeleteMail(id);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件控制器：OnMailDeleteNotify A mail was deleted, id: ";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("deletingMailId", id);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.MailContentView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.MailContentView, null);
		}
		if (response.Reason == MailDeleteReason.PublicCancelled)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("MailRecall", Array.Empty<object>());
		}
		else
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("MailDelete", Array.Empty<object>());
		}
		ModelBase<MailModel>.Instance.RefreshLocalNewMailMap();
		Singleton<EventSystem>.Instance.Emit(EEventName.DeletingMailPassively);
	}

	// Token: 0x060107A2 RID: 67490 RVA: 0x00480010 File Offset: 0x0047E210
	private static void OnMailAddNotify(MailAddNotify response, [Nullable(2)] Net.CallbackStatus status)
	{
		if (response.NewMail == null)
		{
			return;
		}
		if (ModelBase<MailModel>.Instance.GetMailListLength() >= ModelBase<MailModel>.Instance.GetMailCapacity())
		{
			Singleton<Log>.Instance.Error(ELogModule.Mail, ELogAuthor.YZY, "邮件控制器：MailBox is fulfilled!", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		PbMailInfo newMail = response.NewMail;
		if (ModelBase<MailModel>.Instance.GetMailInstanceById(newMail.Id) != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Mail;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "邮件控制器：This mail exist! id: ";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("newMailInfo.Id", newMail.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Mail;
		ELogAuthor author2 = ELogAuthor.YZY;
		string message2 = "邮件控制器：OnMailAddNotify New mail added, id: ";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("newMailInfo.Id", newMail.Id);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		ModelBase<MailModel>.Instance.AddMail(newMail, true);
		MailData mailInstanceById = ModelBase<MailModel>.Instance.GetMailInstanceById(newMail.Id);
		if (mailInstanceById != null)
		{
			mailInstanceById.SetAddReason((int)response.Reason);
		}
		ModelBase<MailModel>.Instance.RefreshLocalNewMailMap();
		if (response.Reason == MailAddReason.BagFull)
		{
			MailController.TryShowNewMailTips("BagOverLimit");
		}
		else
		{
			MailController.TryShowNewMailTips("NewMail");
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.AddingNewMail);
	}

	// Token: 0x060107A3 RID: 67491 RVA: 0x00480130 File Offset: 0x0047E330
	private static void OnWorldDoneAndCloseLoading()
	{
		MailController.TryShowNewMailTips("NewMail");
	}

	// Token: 0x060107A4 RID: 67492 RVA: 0x0048013C File Offset: 0x0047E33C
	private static void TryShowNewMailTips(string promptId = "NewMail")
	{
		if (!ModelBase<GameModeModel>.Instance.WorldDoneAndLoadingClosed)
		{
			return;
		}
		double num = Singleton<Time>.Instance.NowSeconds - ModelBase<MailModel>.Instance.LastTimeShowNewMailTipsTime;
		int? newMailGap = ConfigBase<CommonConfig>.Instance.GetNewMailGap();
		double? num2 = (newMailGap != null) ? new double?((double)newMailGap.GetValueOrDefault()) : null;
		bool flag = num > num2.GetValueOrDefault() & num2 != null;
		if (flag && ModelBase<MailModel>.Instance.IfNeedShowNewMail())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode(promptId, Array.Empty<object>());
			ModelBase<MailModel>.Instance.SaveShowNewMailMap();
			ModelBase<MailModel>.Instance.LastTimeShowNewMailTipsTime = Singleton<Time>.Instance.NowSeconds;
			return;
		}
		if (!flag && ModelBase<MailModel>.Instance.IfNeedShowNewMail())
		{
			ModelBase<MailModel>.Instance.SaveShowNewMailMap();
		}
	}

	// Token: 0x060107A5 RID: 67493 RVA: 0x00480204 File Offset: 0x0047E404
	public static void SelectedMail(MailData selectedMail)
	{
		if (selectedMail != null)
		{
			if (selectedMail.GetWasScanned())
			{
				Singleton<EventSystem>.Instance.Emit<string, int>(EEventName.SelectedMail, selectedMail.Id, selectedMail.ConfigId);
				Singleton<EventSystem>.Instance.Emit(EEventName.SwitchUnfinishedFlag);
				return;
			}
			MailController.RequestReadMail(selectedMail.Id, selectedMail.ConfigId);
		}
	}

	// Token: 0x060107A6 RID: 67494 RVA: 0x0048025C File Offset: 0x0047E45C
	public static void RequestReadMail(string mailId, int configId)
	{
		MailReadRequest mailReadRequest = MailReadRequest.Create();
		mailReadRequest.Id = mailId;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件控制器：RequestReadMail 未阅读邮件，申请阅读";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("mailId", mailId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<Net>.Instance.Call<MailReadResponse>(ERequestMessageId.MailReadRequest, mailReadRequest, delegate(MailReadResponse response, Net.CallbackStatus _)
		{
			MailController.OnReadMailResponse(response, configId);
		}, 0);
	}

	// Token: 0x060107A7 RID: 67495 RVA: 0x004802C8 File Offset: 0x0047E4C8
	private static void OnReadMailResponse(MailReadResponse response, int configId)
	{
		if (response == null)
		{
			return;
		}
		if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
		{
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23264, null, true, true);
			return;
		}
		MailData mailInstanceById = ModelBase<MailModel>.Instance.GetMailInstanceById(response.Id);
		if (mailInstanceById != null)
		{
			mailInstanceById.ReadTime = Singleton<MathUtils>.Instance.LongToNumber(response.ReadTime);
			mailInstanceById.ExpiryTime = Singleton<MathUtils>.Instance.LongToNumber(response.ExpiryTime);
			if (mailInstanceById.IsIntervalMail)
			{
				mailInstanceById.IntervalExpiryTime = mailInstanceById.ExpiryTime;
			}
			ModelBase<MailModel>.Instance.SetMailStatusByStatusCode(response.State, mailInstanceById);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Mail;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "邮件控制器：OnReadMailResponse 阅读选中，状态码";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("response.State", response.State);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Emit<string, int>(EEventName.SelectedMail, response.Id, configId);
			Singleton<EventSystem>.Instance.Emit(EEventName.SwitchUnfinishedFlag);
		}
	}

	// Token: 0x060107A8 RID: 67496 RVA: 0x004803BC File Offset: 0x0047E5BC
	public static void RequestPickAttachment(List<string> attachmentIds, EMailAttachmentPickType pickType)
	{
		MailGetAttachmentRequest mailGetAttachmentRequest = MailGetAttachmentRequest.Create();
		int value = ConfigCommonParamById.GetIntConfig("mail_take_limit").Value;
		int num = Math.Min(attachmentIds.Count, value);
		for (int i = 0; i < num; i++)
		{
			mailGetAttachmentRequest.MailIds.Add(attachmentIds[i]);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件控制器：RequestPickAttachment 申请领取附件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("attachmentIds", mailGetAttachmentRequest.MailIds);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<Net>.Instance.Call<MailGetAttachmentResponse>(ERequestMessageId.MailGetAttachmentRequest, mailGetAttachmentRequest, delegate(MailGetAttachmentResponse response, Net.CallbackStatus _)
		{
			MailController.OnPickMailAttachmentResponse(response, pickType);
		}, 0);
	}

	// Token: 0x060107A9 RID: 67497 RVA: 0x0048046C File Offset: 0x0047E66C
	private static void OnPickMailAttachmentResponse(MailGetAttachmentResponse response, EMailAttachmentPickType pickType)
	{
		if (response == null)
		{
			return;
		}
		if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
		{
			Dictionary<string, int> successIdMap = response.SuccessIdMap.ToDictionary((KeyValuePair<string, int> pair) => pair.Key, (KeyValuePair<string, int> pair) => pair.Value);
			ModelBase<MailModel>.Instance.SetLastPickedAttachments(successIdMap, pickType);
			return;
		}
		int id = ConfigErrorCodeById.GetConfig((int)response.ErrorCode, true).Value.Id;
		string text = "";
		if (id != 10000)
		{
			if (id != 10008)
			{
				if (id == 400012)
				{
					text = "MailOverLimit";
				}
			}
			else
			{
				text = "MailOverLimit";
			}
		}
		else
		{
			text = "MailOutOfDate";
		}
		if (text != "")
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode(text, Array.Empty<object>());
			return;
		}
		ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17764, null, true, true);
	}

	// Token: 0x060107AA RID: 67498 RVA: 0x0048056C File Offset: 0x0047E76C
	public static void RequestMailFavorite(string mailId, bool isFavorite, Action onFailed = null, Action onSuccess = null)
	{
		if (ModelBase<MailModel>.Instance.CanRequestMailFavorite(mailId, isFavorite))
		{
			MailFavoriteRequest mailFavoriteRequest = MailFavoriteRequest.Create();
			mailFavoriteRequest.Id = mailId;
			mailFavoriteRequest.IsFavorite = isFavorite;
			Singleton<Net>.Instance.Call<MailFavoriteResponse>(ERequestMessageId.MailFavoriteRequest, mailFavoriteRequest, delegate(MailFavoriteResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					Action onFailed3 = onFailed;
					if (onFailed3 == null)
					{
						return;
					}
					onFailed3();
					return;
				}
				else
				{
					long expiryTime = Singleton<MathUtils>.Instance.LongToNumber(response.ExpiryTime);
					if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
					{
						ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17539, null, true, true);
						Action onFailed4 = onFailed;
						if (onFailed4 == null)
						{
							return;
						}
						onFailed4();
						return;
					}
					else
					{
						ModelBase<MailModel>.Instance.ApplyMailFavoriteResponse(response.Id, isFavorite, response.State, expiryTime);
						Action onSuccess2 = onSuccess;
						if (onSuccess2 == null)
						{
							return;
						}
						onSuccess2();
						return;
					}
				}
			}, 0);
			return;
		}
		Action onFailed2 = onFailed;
		if (onFailed2 == null)
		{
			return;
		}
		onFailed2();
	}

	// Token: 0x060107AB RID: 67499 RVA: 0x004805F0 File Offset: 0x0047E7F0
	public static void RequestDeleteFavoriteMail(string mailId)
	{
		MailData mailInstanceById = ModelBase<MailModel>.Instance.GetMailInstanceById(mailId);
		if (mailInstanceById == null)
		{
			return;
		}
		if (!mailInstanceById.IsFavorite)
		{
			MailController.RequestDeleteMail(new List<string>
			{
				mailId
			});
			return;
		}
		MailController.RequestMailFavorite(mailId, false, null, delegate
		{
			MailController.RequestDeleteMail(new List<string>
			{
				mailId
			});
		});
	}

	// Token: 0x060107AC RID: 67500 RVA: 0x00480658 File Offset: 0x0047E858
	public static void RequestDeleteMail(List<string> mailIds)
	{
		MailDeleteRequest mailDeleteRequest = MailDeleteRequest.Create();
		mailDeleteRequest.MailIds.AddRange(mailIds);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件控制器：RequestDeleteMail请求删除邮件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("mailId", mailIds);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<Net>.Instance.Call<MailDeleteResponse>(ERequestMessageId.MailDeleteRequest, mailDeleteRequest, delegate(MailDeleteResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			MailController.OnDeleteMailResponse(response);
		}, 0);
	}

	// Token: 0x060107AD RID: 67501 RVA: 0x004806D0 File Offset: 0x0047E8D0
	private static void OnDeleteMailResponse(MailDeleteResponse response)
	{
		if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
		{
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19962, null, true, true);
			return;
		}
		if (response.SuccessIds.Count > 0)
		{
			foreach (string mailId in response.SuccessIds)
			{
				ModelBase<MailModel>.Instance.DeleteMail(mailId);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Mail;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "邮件控制器：删除邮件";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("邮件id", response.SuccessIds);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("MailDelete", Array.Empty<object>());
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<string>>(EEventName.DeletingMail, response.SuccessIds);
		}
	}

	// Token: 0x060107AE RID: 67502 RVA: 0x004807AC File Offset: 0x0047E9AC
	public static void OpenMailJumpView(MailData mailData)
	{
		int subContentJumpId = mailData.GetSubContentJumpId();
		int subContentJumpParam = mailData.GetSubContentJumpParam();
		int subContentJumpParam2 = mailData.GetSubContentJumpParam2();
		MailTo? mailToConfigById = ConfigBase<MailConfig>.Instance.GetMailToConfigById(subContentJumpId);
		if (mailToConfigById != null)
		{
			if (MailController.TryOpenMailToInventoryJump(mailToConfigById.Value.JumpId, subContentJumpParam, subContentJumpParam2))
			{
				return;
			}
			SkipTaskManager.RunByConfigId(mailToConfigById.Value.JumpId, null);
			return;
		}
		else
		{
			if (MailController.TryMailJump((EFunctionType)subContentJumpId, subContentJumpParam, subContentJumpParam2))
			{
				return;
			}
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView((EFunctionType)subContentJumpId);
			return;
		}
	}

	// Token: 0x060107AF RID: 67503 RVA: 0x0048082C File Offset: 0x0047EA2C
	private static bool TryOpenMailToInventoryJump(int accessPathId, int jumpParam, int jumpParam2)
	{
		AccessPath? accessPathConfig = ConfigBase<SkipInterfaceConfig>.Instance.GetAccessPathConfig(accessPathId);
		if (accessPathConfig == null)
		{
			return false;
		}
		if (accessPathConfig.Value.SkipName != 38)
		{
			return false;
		}
		if (accessPathConfig.Value.Val1 != EUiViewName.InventoryView)
		{
			return false;
		}
		FunctionModel instance = ModelBase<FunctionModel>.Instance;
		foreach (KeyValuePair<int, string> keyValuePair in accessPathConfig.Value.FunctionOpenCheckMap())
		{
			if (!instance.IsOpen(keyValuePair.Key))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode(keyValuePair.Value, Array.Empty<object>());
				return true;
			}
		}
		int num2;
		int num = int.TryParse(accessPathConfig.Value.Val2, out num2) ? num2 : 0;
		int num3 = (jumpParam > 0) ? jumpParam : num;
		int num4 = (jumpParam2 > 0) ? jumpParam2 : 0;
		if (num3 <= 0 && num4 <= 0)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InventoryView, null, null);
			return true;
		}
		return MailController.OpenMailBagJump(num3, num4);
	}

	// Token: 0x060107B0 RID: 67504 RVA: 0x00480960 File Offset: 0x0047EB60
	private static bool TryMailJump(EFunctionType jumpId, int jumpParam, int jumpParam2)
	{
		if (jumpParam <= 0 && jumpParam2 <= 0)
		{
			return false;
		}
		if (jumpId <= EFunctionType.Shop)
		{
			switch (jumpId)
			{
			case EFunctionType.Role:
			case EFunctionType.Calabash:
				break;
			case EFunctionType.Bag:
				return MailController.OpenMailBagJump(jumpParam, jumpParam2);
			default:
				if (jumpId != EFunctionType.Gacha)
				{
					if (jumpId != EFunctionType.Shop)
					{
						return false;
					}
					if (jumpParam > 0)
					{
						MailController.OpenMailShopJump(jumpParam, jumpParam2);
						return true;
					}
					return false;
				}
				else
				{
					if (jumpParam > 0)
					{
						ControllerBase<GachaController>.Instance.OpenGachaView(jumpParam);
						return true;
					}
					return false;
				}
				break;
			}
		}
		else if (jumpId <= EFunctionType.AdventureGuide)
		{
			if (jumpId != EFunctionType.Tutorial)
			{
				if (jumpId != EFunctionType.AdventureGuide)
				{
					return false;
				}
			}
			else
			{
				if (jumpParam > 0)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.TutorialView, new TutorialViewParam
					{
						TutorialId = new int?(jumpParam)
					}, null);
					return true;
				}
				return false;
			}
		}
		else if (jumpId != EFunctionType.HandBookSystem)
		{
			if (jumpId != EFunctionType.Activity)
			{
				return false;
			}
			if (jumpParam > 0)
			{
				ControllerBase<ActivityController>.Instance.OpenActivityById(jumpParam, EActivityViewOpenType.Other, null, null);
				return true;
			}
			return false;
		}
		else
		{
			if (jumpParam > 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.HandBookEntranceView, new HandBookEntranceViewParam
				{
					SelectedTabType = (EHandBookTabType)jumpParam
				}, null);
				return true;
			}
			return false;
		}
		return MailController.OpenMailJumpSubTab(jumpId, jumpParam, jumpParam2);
	}

	// Token: 0x060107B1 RID: 67505 RVA: 0x00480A7C File Offset: 0x0047EC7C
	private static bool OpenMailJumpSubTab(EFunctionType jumpId, int jumpParam, int jumpParam2)
	{
		if (jumpParam <= 0)
		{
			return false;
		}
		EUiViewName? euiViewName = null;
		if (jumpId != EFunctionType.Role)
		{
			if (jumpId != EFunctionType.Calabash)
			{
				if (jumpId != EFunctionType.AdventureGuide)
				{
					return false;
				}
				euiViewName = new EUiViewName?(EUiViewName.AdventureGuideView);
			}
			else
			{
				euiViewName = new EUiViewName?(EUiViewName.CalabashRootView);
			}
		}
		else
		{
			euiViewName = new EUiViewName?(EUiViewName.RoleRootView);
		}
		List<UiDynamicTab> tabList;
		if (jumpId == EFunctionType.AdventureGuide)
		{
			tabList = new List<UiDynamicTab>(ModelBase<AdventureGuideModel>.Instance.GetAdventureGuideTabList());
		}
		else
		{
			tabList = ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(euiViewName.Value);
		}
		UiDynamicTab? uiDynamicTab = MailController.FindMailJumpTab(tabList, jumpParam);
		if (uiDynamicTab == null)
		{
			return false;
		}
		EUiTabViewName euiTabViewName = (EUiTabViewName)uiDynamicTab.Value.ChildViewName;
		int? num = (jumpParam2 > 0) ? new int?(jumpParam2) : null;
		if (euiViewName == EUiViewName.AdventureGuideView)
		{
			ControllerBase<AdventureGuideController>.Instance.OpenGuideView(new EUiTabViewName?(euiTabViewName), num, null);
			return true;
		}
		if (euiViewName == EUiViewName.CalabashRootView)
		{
			ControllerBase<CalabashController>.Instance.JumpToCalabashRootView(euiTabViewName, num);
			return true;
		}
		if (euiViewName == EUiViewName.RoleRootView)
		{
			ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Normal, 0, null, new EUiTabViewName?(euiTabViewName), null);
			return true;
		}
		return false;
	}

	// Token: 0x060107B2 RID: 67506 RVA: 0x00480C00 File Offset: 0x0047EE00
	private static UiDynamicTab? FindMailJumpTab(List<UiDynamicTab> tabList, int jumpParam)
	{
		foreach (UiDynamicTab value in tabList)
		{
			if (value.Id == jumpParam)
			{
				return new UiDynamicTab?(value);
			}
		}
		foreach (UiDynamicTab value2 in tabList)
		{
			if (value2.TabIndex == jumpParam)
			{
				return new UiDynamicTab?(value2);
			}
		}
		if (jumpParam >= 0 && jumpParam < tabList.Count)
		{
			return new UiDynamicTab?(tabList[jumpParam]);
		}
		return null;
	}

	// Token: 0x060107B3 RID: 67507 RVA: 0x00480CCC File Offset: 0x0047EECC
	private static void OpenMailShopJump(int shopId, int subTabId)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10010))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FunctionDisable", Array.Empty<object>());
			return;
		}
		if (shopId == 1 && subTabId > 0)
		{
			PayShopViewData data = new PayShopViewData
			{
				PayShopId = PayShopDefine.EPayShopTabType.Recommend,
				RecommendId = new int?(subTabId)
			};
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PayShopRootView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.PayShopRootView, null);
			}
			ControllerBase<PayShopController>.Instance.OpenPayShopView(data, null);
			return;
		}
		ControllerBase<PayShopController>.Instance.OpenPayShopViewWithTab((PayShopDefine.EPayShopTabType)shopId, subTabId);
	}

	// Token: 0x060107B4 RID: 67508 RVA: 0x00480D5C File Offset: 0x0047EF5C
	private static bool OpenMailBagJump(int mainTypeId, int uniqueId)
	{
		if (mainTypeId <= 0 && uniqueId <= 0)
		{
			return false;
		}
		if (mainTypeId > 0)
		{
			int num = ModelBase<InventoryModel>.Instance.GetOpenIdMainTypeConfig().FindIndex((ItemMainType item) => item.Id == mainTypeId);
			if (num >= 0)
			{
				ModelBase<InventoryModel>.Instance.SetSelectedTypeIndex(num);
			}
		}
		if (uniqueId > 0)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InventoryView, uniqueId, null);
		}
		else
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InventoryView, null, null);
		}
		return true;
	}

	// Token: 0x060107B5 RID: 67509 RVA: 0x00480DE8 File Offset: 0x0047EFE8
	public static void RecordMailJumpLog(MailData mailData)
	{
		MailJumpLogEvent logData = new MailJumpLogEvent
		{
			s_mail_id = mailData.Id,
			i_level = mailData.GetMailLevel(),
			l_received_time = (long)mailData.GetReceiveTime(),
			i_reason = mailData.GetAddReason(),
			l_take_time = (long)Singleton<TimeUtil>.Instance.GetServerTimeStamp()
		};
		ControllerBase<LogReportController>.Instance.LogReport(logData);
	}

	// Token: 0x020084F7 RID: 34039
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402D082 RID: 184450
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<EUiViewName, object, bool> <0>__CanOpenView;

		// Token: 0x0402D083 RID: 184451
		[Nullable(0)]
		public static Action <1>__OnWorldDoneAndCloseLoading;

		// Token: 0x0402D084 RID: 184452
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<MailInfosNotify, Net.CallbackStatus> <2>__OnMailInfosNotify;

		// Token: 0x0402D085 RID: 184453
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<MailDeleteNotify, Net.CallbackStatus> <3>__OnMailDeleteNotify;

		// Token: 0x0402D086 RID: 184454
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<MailAddNotify, Net.CallbackStatus> <4>__OnMailAddNotify;
	}
}
