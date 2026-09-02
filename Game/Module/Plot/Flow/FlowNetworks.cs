using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Flow
{
	// Token: 0x02005404 RID: 21508
	[NullableContext(1)]
	[Nullable(0)]
	public class FlowNetworks
	{
		// Token: 0x06036EA7 RID: 224935 RVA: 0x00DEED44 File Offset: 0x00DECF44
		public static void Register()
		{
			Net instance = Singleton<Net>.Instance;
			ENotifyMessageId id = ENotifyMessageId.FlowStartNotify;
			Action<FlowStartNotify, Net.CallbackStatus> callback;
			if ((callback = FlowNetworks.<>O.<0>__HandleFlowStartNotify) == null)
			{
				callback = (FlowNetworks.<>O.<0>__HandleFlowStartNotify = new Action<FlowStartNotify, Net.CallbackStatus>(FlowNetworks.HandleFlowStartNotify));
			}
			instance.Register<FlowStartNotify>(id, callback);
			Net instance2 = Singleton<Net>.Instance;
			ENotifyMessageId id2 = ENotifyMessageId.FlowEndNotify;
			Action<FlowEndNotify, Net.CallbackStatus> callback2;
			if ((callback2 = FlowNetworks.<>O.<1>__HandleFlowEndNotify) == null)
			{
				callback2 = (FlowNetworks.<>O.<1>__HandleFlowEndNotify = new Action<FlowEndNotify, Net.CallbackStatus>(FlowNetworks.HandleFlowEndNotify));
			}
			instance2.Register<FlowEndNotify>(id2, callback2);
			Net instance3 = Singleton<Net>.Instance;
			ENotifyMessageId id3 = ENotifyMessageId.FlowServerSkipNotify;
			Action<FlowServerSkipNotify, Net.CallbackStatus> callback3;
			if ((callback3 = FlowNetworks.<>O.<2>__HandleFlowSkipBlackScreenNotify) == null)
			{
				callback3 = (FlowNetworks.<>O.<2>__HandleFlowSkipBlackScreenNotify = new Action<FlowServerSkipNotify, Net.CallbackStatus>(FlowNetworks.HandleFlowSkipBlackScreenNotify));
			}
			instance3.Register<FlowServerSkipNotify>(id3, callback3);
		}

		// Token: 0x06036EA8 RID: 224936 RVA: 0x00DEEDD2 File Offset: 0x00DECFD2
		public static void UnRegister()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FlowStartNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FlowEndNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FlowServerSkipNotify);
		}

		// Token: 0x06036EA9 RID: 224937 RVA: 0x00DEEE04 File Offset: 0x00DED004
		private static void HandleFlowStartNotify(FlowStartNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ControllerBase<FlowController>.Instance.StartNotify(notify);
		}

		// Token: 0x06036EAA RID: 224938 RVA: 0x00DEEE11 File Offset: 0x00DED011
		private static void HandleFlowEndNotify(FlowEndNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ControllerBase<FlowController>.Instance.EndNotify(notify);
		}

		// Token: 0x06036EAB RID: 224939 RVA: 0x00DEEE1E File Offset: 0x00DED01E
		private static void HandleFlowSkipBlackScreenNotify(FlowServerSkipNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ControllerBase<FlowController>.Instance.SkipBlackScreenNotify(notify);
		}

		// Token: 0x06036EAC RID: 224940 RVA: 0x00DEEE2C File Offset: 0x00DED02C
		public static void RequestGmFinish()
		{
			ChatRequest chatRequest = ChatRequest.Create();
			chatRequest.ChannelId = 0;
			chatRequest.Content = "@skipflow";
			Singleton<Net>.Instance.Call<ChatResponse>(ERequestMessageId.ChatRequest, chatRequest, delegate(ChatResponse response, Net.CallbackStatus _)
			{
			}, 0);
		}

		// Token: 0x06036EAD RID: 224941 RVA: 0x00DEEE84 File Offset: 0x00DED084
		[NullableContext(2)]
		public static void RequestAction(long flowIncId, int actionId, Action<ErrorCode> callback)
		{
			FlowActionRequest flowActionRequest = FlowActionRequest.Create();
			flowActionRequest.FlowIncId = flowIncId;
			flowActionRequest.ActionId = actionId;
			Singleton<Net>.Instance.Call<FlowActionResponse>(ERequestMessageId.FlowActionRequest, flowActionRequest, delegate(FlowActionResponse response, Net.CallbackStatus _)
			{
				if (callback != null)
				{
					callback(response.Code);
				}
				FlowNetworks.HandleErrorCode(response.Code, 21796);
			}, 0);
		}

		// Token: 0x06036EAE RID: 224942 RVA: 0x00DEEED0 File Offset: 0x00DED0D0
		[NullableContext(2)]
		public static void RequestFlowEnd(long flowIncId, bool isSkip, [Nullable(new byte[]
		{
			1,
			0,
			1,
			0
		})] List<ValueTuple<int, List<ValueTuple<int, int>>>> optionList, Action<long, ErrorCode?> callback = null)
		{
			FlowEndRequest flowEndRequest = FlowEndRequest.Create();
			flowEndRequest.FlowIncId = flowIncId;
			flowEndRequest.IsSkip = isSkip;
			new Dictionary<string, FlowOptionInfoList>();
			foreach (ValueTuple<int, List<ValueTuple<int, int>>> valueTuple in optionList)
			{
				int item = valueTuple.Item1;
				List<ValueTuple<int, int>> item2 = valueTuple.Item2;
				FlowOptionInfoList flowOptionInfoList = new FlowOptionInfoList();
				foreach (ValueTuple<int, int> valueTuple2 in item2)
				{
					FlowOptionInfo item3 = new FlowOptionInfo
					{
						TalkId = valueTuple2.Item1,
						OptionIndex = valueTuple2.Item2
					};
					flowOptionInfoList.OptionIndexList.Add(item3);
				}
				flowEndRequest.OptionInfos.Add(item, flowOptionInfoList);
			}
			Singleton<Net>.Instance.Call<FlowEndResponse>(ERequestMessageId.FlowEndRequest, flowEndRequest, delegate(FlowEndResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					ControllerBase<FlowController>.Instance.LogError("请求完成剧情时网络错误", default(ReadOnlySpan<ValueTuple<string, object>>));
					Action<long, ErrorCode?> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(flowIncId, null);
					return;
				}
				else
				{
					FlowNetworks.HandleErrorCode(response.Code, 21796);
					Action<long, ErrorCode?> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(flowIncId, new ErrorCode?(response.Code));
					return;
				}
			}, 0);
		}

		// Token: 0x06036EAF RID: 224943 RVA: 0x00DEEFF4 File Offset: 0x00DED1F4
		public static void RequestFlowRestart(long flowIncId)
		{
			FlowRestartRequest flowRestartRequest = FlowRestartRequest.Create();
			flowRestartRequest.FlowIncId = flowIncId;
			Singleton<Net>.Instance.Call<FlowRestartResponse>(ERequestMessageId.FlowRestartRequest, flowRestartRequest, delegate(FlowRestartResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					FlowController instance = ControllerBase<FlowController>.Instance;
					string text = "请求重启剧情时网络错误";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("flowIncId", flowIncId);
					instance.LogError(text, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				if (response.Code != ErrorCode.Success)
				{
					FlowController instance2 = ControllerBase<FlowController>.Instance;
					string text2 = "请求重启剧情失败";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("flowIncId", flowIncId);
					instance2.LogError(text2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
			}, 0);
		}

		// Token: 0x06036EB0 RID: 224944 RVA: 0x00DEF040 File Offset: 0x00DED240
		public static void RequestSeqEndPosition(FlowContext context, IVector location, IRotator rotation)
		{
			if (!context.IsServerNotify)
			{
				return;
			}
			FlowSeqSetPlayerPosRequest flowSeqSetPlayerPosRequest = FlowSeqSetPlayerPosRequest.Create();
			flowSeqSetPlayerPosRequest.FlowIncId = context.FlowIncId;
			flowSeqSetPlayerPosRequest.TalkActionId = context.CurShowTalkActionId;
			flowSeqSetPlayerPosRequest.TalkId = context.CurTalkId;
			flowSeqSetPlayerPosRequest.X = (float)location.X;
			flowSeqSetPlayerPosRequest.Y = (float)location.Y;
			flowSeqSetPlayerPosRequest.Z = (float)location.Z;
			flowSeqSetPlayerPosRequest.A = rotation.Yaw;
			long incId = context.FlowIncId;
			Singleton<Net>.Instance.Call<FlowSeqSetPlayerPosResponse>(ERequestMessageId.FlowSeqSetPlayerPosRequest, flowSeqSetPlayerPosRequest, delegate(FlowSeqSetPlayerPosResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					FlowController instance = ControllerBase<FlowController>.Instance;
					string text = "请求Seq最终位置时网络错误";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("flowIncId", incId);
					instance.LogError(text, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				if (response.Code != ErrorCode.Success)
				{
					FlowController instance2 = ControllerBase<FlowController>.Instance;
					string text2 = "请求Seq最终位置失败";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("flowIncId", incId);
					instance2.LogError(text2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
			}, 0);
		}

		// Token: 0x06036EB1 RID: 224945 RVA: 0x00DEF0E4 File Offset: 0x00DED2E4
		private static void HandleErrorCode(ErrorCode code, int messageId)
		{
			if (code == ErrorCode.ErrFinishFlowFail)
			{
				ControllerBase<FlowController>.Instance.LogError("请求服务器完成剧情失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (code == ErrorCode.ErrFlowActionFail)
			{
				ControllerBase<FlowController>.Instance.LogError("请求服务器剧情行为失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(code, messageId, null, true, true);
			}
		}

		// Token: 0x06036EB2 RID: 224946 RVA: 0x00DEF144 File Offset: 0x00DED344
		public static void RequestSafeTeleport(long flowIncId, Action<bool> callback)
		{
			FlowTeleportToPlotPosRequest flowTeleportToPlotPosRequest = FlowTeleportToPlotPosRequest.Create();
			flowTeleportToPlotPosRequest.FlowIncId = flowIncId;
			Singleton<Net>.Instance.Call<FlowTeleportToPlotPosResponse>(ERequestMessageId.FlowTeleportToPlotPosRequest, flowTeleportToPlotPosRequest, delegate(FlowTeleportToPlotPosResponse response, Net.CallbackStatus _)
			{
				if (response == null || response.Code != ErrorCode.Success)
				{
					ControllerBase<FlowController>.Instance.LogError("请求服务器传送到剧情起始点失败", default(ReadOnlySpan<ValueTuple<string, object>>));
					callback(false);
					return;
				}
				callback(true);
			}, 0);
		}

		// Token: 0x0200B395 RID: 45973
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04037A13 RID: 227859
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<FlowStartNotify, Net.CallbackStatus> <0>__HandleFlowStartNotify;

			// Token: 0x04037A14 RID: 227860
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<FlowEndNotify, Net.CallbackStatus> <1>__HandleFlowEndNotify;

			// Token: 0x04037A15 RID: 227861
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<FlowServerSkipNotify, Net.CallbackStatus> <2>__HandleFlowSkipBlackScreenNotify;
		}
	}
}
