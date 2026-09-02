using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.ResManager;

namespace CSharpScript.Game.Module.Teleport
{
	// Token: 0x02004EEA RID: 20202
	[NullableContext(2)]
	[Nullable(0)]
	public class TeleportMisc
	{
		// Token: 0x060342F6 RID: 213750 RVA: 0x00D0DBFC File Offset: 0x00D0BDFC
		public static void SendTeleportTransferRequest(int markConfigId)
		{
			if (TeleportMisc.ShowTeleportConfirmBox(delegate
			{
				TeleportMisc.SendTeleportTransferRequestPurely(markConfigId, delegate
				{
					ModelBase<InstanceDungeonModel>.Instance.ClearInstanceDungeonInfo();
				});
			}))
			{
				return;
			}
			TeleportMisc.SendTeleportTransferRequestPurely(markConfigId, null);
		}

		// Token: 0x060342F7 RID: 213751 RVA: 0x00D0DC38 File Offset: 0x00D0BE38
		private static void SendTeleportTransferRequestPurely(int markConfigId, Action onSuccess = null)
		{
			ModelBase<LoadingModel>.Instance.TargetTeleportId = markConfigId;
			TeleportTransferRequest teleportTransferRequest = TeleportTransferRequest.Create();
			teleportTransferRequest.Id = markConfigId;
			Singleton<Net>.Instance.Call<TeleportTransferResponse>(ERequestMessageId.TeleportTransferRequest, teleportTransferRequest, delegate(TeleportTransferResponse response, Net.CallbackStatus _)
			{
				if (GlobalData.World == null)
				{
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrPlayerIsTeleportCanNotDoTeleport)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					if (response.ErrorCode != Aki.Protocol.ErrorCode.ErrSceneBlockSplitNotBlock)
					{
						ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.TeleportTransferResponse, null, true, true);
					}
					return;
				}
				Action onSuccess2 = onSuccess;
				if (onSuccess2 == null)
				{
					return;
				}
				onSuccess2();
			}, 0);
		}

		// Token: 0x060342F8 RID: 213752 RVA: 0x00D0DC88 File Offset: 0x00D0BE88
		public static bool ShowTeleportConfirmBox(Action confirmCallBack = null)
		{
			if (confirmCallBack == null)
			{
				confirmCallBack = delegate()
				{
				};
			}
			int? currentDungeonTelExitConfirmId = ModelBase<InstanceDungeonModel>.Instance.GetCurrentDungeonTelExitConfirmId();
			if (currentDungeonTelExitConfirmId != null)
			{
				int? num = currentDungeonTelExitConfirmId;
				int num2 = 0;
				if (num.GetValueOrDefault() > num2 & num != null)
				{
					ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew((EConfirmBoxConfigId)currentDungeonTelExitConfirmId.Value);
					confirmBoxDataNew.FunctionMap[2] = delegate()
					{
						confirmCallBack();
					};
					ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
					return true;
				}
			}
			return false;
		}

		// Token: 0x060342F9 RID: 213753 RVA: 0x00D0DD34 File Offset: 0x00D0BF34
		public static void SendTeleportTransferRequestByEntityId(int instEntityTeleportId)
		{
			InstEntityTeleporter value = ConfigBase<MapConfig>.Instance.GetInstEntityTeleportConfigById(instEntityTeleportId).Value;
			InstEntityTeleportRequest instEntityTeleportRequest = InstEntityTeleportRequest.Create();
			instEntityTeleportRequest.InstId = value.InstId;
			instEntityTeleportRequest.EntityConfigId = value.EntityConfigId;
			Singleton<Net>.Instance.Call<InstEntityTeleportResponse>(ERequestMessageId.InstEntityTeleportRequest, instEntityTeleportRequest, delegate(InstEntityTeleportResponse response, Net.CallbackStatus _)
			{
				if (GlobalData.World == null)
				{
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrPlayerIsTeleportCanNotDoTeleport)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.InstEntityTeleportResponse, null, true, true);
				}
			}, 0);
		}

		// Token: 0x060342FA RID: 213754 RVA: 0x00D0DDA8 File Offset: 0x00D0BFA8
		[NullableContext(1)]
		public unsafe static bool BackToGameIfTargetPositionInvalid(global::Vector position, string reason)
		{
			int mapId = ModelBase<GameModeModel>.Instance.MapId;
			ValueTuple<bool, bool> valueTuple = ControllerBase<ResourceManagerController>.Instance.IsBlockResourceDownloaded(mapId, position);
			bool item = valueTuple.Item1;
			bool item2 = valueTuple.Item2;
			if (item && !item2)
			{
				return false;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SubPackageTeleportToUnFinishAreaConfirm);
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
				ControllerBase<ReConnectController>.Instance.Logout(ELogoutReason.InvalidTeleportPosition);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
			int mapBlockFromPosition = ControllerBase<ResourceManagerController>.Instance.GetMapBlockFromPosition(mapId, position);
			if (mapBlockFromPosition >= 0)
			{
				ControllerBase<ResourceManagerController>.Instance.PushCurBlock(new <>z__ReadOnlySingleElementList<int>(mapBlockFromPosition), "传送保底,回到登陆界面");
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Teleport;
			ELogAuthor author = ELogAuthor.XY;
			string message = "传送: 目标位置所在区块资源未下载, 回到登录界面";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("mapId", mapId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("position", position);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("reason", reason);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return true;
		}
	}
}
