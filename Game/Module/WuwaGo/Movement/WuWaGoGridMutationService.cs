using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.WuWaGo;
using CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity;
using CSharpScript.Game.Module.WuwaGo.Model;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Movement
{
	// Token: 0x02004ACC RID: 19148
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoGridMutationService : IWuWaGoGridMutationService
	{
		// Token: 0x06031EA6 RID: 204454 RVA: 0x00C7DC3E File Offset: 0x00C7BE3E
		public WuWaGoGridMutationService(WuWaGoGameData data)
		{
		}

		// Token: 0x06031EA7 RID: 204455 RVA: 0x00C7DC50 File Offset: 0x00C7BE50
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<IWuWaGoMovableFloorBatchResult> ExecuteMovableFloorBatch(IReadOnlyList<MovableFloorController> controllers, string batchSource)
		{
			WuWaGoGridMutationService.<ExecuteMovableFloorBatch>d__3 <ExecuteMovableFloorBatch>d__;
			<ExecuteMovableFloorBatch>d__.<>t__builder = AsyncUniTaskMethodBuilder<IWuWaGoMovableFloorBatchResult>.Create();
			<ExecuteMovableFloorBatch>d__.<>4__this = this;
			<ExecuteMovableFloorBatch>d__.controllers = controllers;
			<ExecuteMovableFloorBatch>d__.batchSource = batchSource;
			<ExecuteMovableFloorBatch>d__.<>1__state = -1;
			<ExecuteMovableFloorBatch>d__.<>t__builder.Start<WuWaGoGridMutationService.<ExecuteMovableFloorBatch>d__3>(ref <ExecuteMovableFloorBatch>d__);
			return <ExecuteMovableFloorBatch>d__.<>t__builder.Task;
		}

		// Token: 0x06031EA8 RID: 204456 RVA: 0x00C7DCA4 File Offset: 0x00C7BEA4
		private unsafe bool ValidateMovableFloorBatchRequests(IReadOnlyList<IMovableFloorMoveRequest> requests, string batchSource)
		{
			HashSet<string> hashSet = new HashSet<string>(from request in requests
			select request.RelocationRequest.OldKey);
			HashSet<string> hashSet2 = new HashSet<string>();
			WuWaGoGameData wuWaGoGameData = this.<data>P;
			foreach (IMovableFloorMoveRequest movableFloorMoveRequest in requests)
			{
				IWuWaGoGridRelocationRequest relocationRequest = movableFloorMoveRequest.RelocationRequest;
				if (!hashSet2.Add(relocationRequest.TargetKey))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.WuWaGo;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "移动板批量提交失败：目标坐标重复";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("batchSource", batchSource);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entityId", movableFloorMoveRequest.Controller.Entity.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("pbDataId", movableFloorMoveRequest.Controller.Entity.EntityPbDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("targetKey", relocationRequest.TargetKey);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
					return false;
				}
				WuWaGoGrid gridByKey = wuWaGoGameData.GetGridByKey(relocationRequest.TargetKey);
				if (gridByKey != null && !hashSet.Contains(relocationRequest.TargetKey))
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.WuWaGo;
					ELogAuthor author2 = ELogAuthor.YSQ;
					string message2 = "移动板批量提交失败：目标坐标被非本批次Grid占用";
					<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray5<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("batchSource", batchSource);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("entityId", movableFloorMoveRequest.Controller.Entity.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("pbDataId", movableFloorMoveRequest.Controller.Entity.EntityPbDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("targetKey", relocationRequest.TargetKey);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("occupiedGridId", gridByKey.Id);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 5));
					return false;
				}
			}
			return true;
		}

		// Token: 0x06031EA9 RID: 204457 RVA: 0x00C7DF18 File Offset: 0x00C7C118
		private unsafe void RollbackMovableFloorBatchRequests(IReadOnlyList<IMovableFloorMoveRequest> requests, string batchSource)
		{
			foreach (IMovableFloorMoveRequest movableFloorMoveRequest in requests)
			{
				movableFloorMoveRequest.Controller.CancelPendingMove();
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.WuWaGo;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "移动板批量提交已回滚";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("batchSource", batchSource);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("count", requests.Count);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06031EAA RID: 204458 RVA: 0x00C7DFC4 File Offset: 0x00C7C1C4
		private IReadOnlyList<IGridMoveParticipantExecution> CollectParticipantExecutions(IReadOnlyList<IMovableFloorMoveRequest> requests)
		{
			Dictionary<string, IGridMoveParticipantExecution> dictionary = new Dictionary<string, IGridMoveParticipantExecution>();
			foreach (IMovableFloorMoveRequest movableFloorMoveRequest in requests)
			{
				foreach (IWuWaGoGridMoveParticipant wuWaGoGridMoveParticipant in movableFloorMoveRequest.RelocationRequest.Participants)
				{
					if (!dictionary.ContainsKey(wuWaGoGridMoveParticipant.ParticipantKey))
					{
						dictionary.Add(wuWaGoGridMoveParticipant.ParticipantKey, new GridMoveParticipantExecution
						{
							Participant = wuWaGoGridMoveParticipant,
							Context = movableFloorMoveRequest.RelocationRequest
						});
					}
				}
			}
			return dictionary.Values.ToList<IGridMoveParticipantExecution>();
		}

		// Token: 0x06031EAB RID: 204459 RVA: 0x00C7E088 File Offset: 0x00C7C288
		private void RunBeforeGridMoveParticipants(IReadOnlyList<IGridMoveParticipantExecution> executions)
		{
			foreach (IGridMoveParticipantExecution gridMoveParticipantExecution in executions)
			{
				Action<IWuWaGoGridRelocationContext> beforeGridMove = gridMoveParticipantExecution.Participant.BeforeGridMove;
				if (beforeGridMove != null)
				{
					beforeGridMove(gridMoveParticipantExecution.Context);
				}
			}
		}

		// Token: 0x06031EAC RID: 204460 RVA: 0x00C7E0E8 File Offset: 0x00C7C2E8
		private UniTask RunAfterGridMoveParticipants(IReadOnlyList<IGridMoveParticipantExecution> executions)
		{
			WuWaGoGridMutationService.<RunAfterGridMoveParticipants>d__8 <RunAfterGridMoveParticipants>d__;
			<RunAfterGridMoveParticipants>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunAfterGridMoveParticipants>d__.executions = executions;
			<RunAfterGridMoveParticipants>d__.<>1__state = -1;
			<RunAfterGridMoveParticipants>d__.<>t__builder.Start<WuWaGoGridMutationService.<RunAfterGridMoveParticipants>d__8>(ref <RunAfterGridMoveParticipants>d__);
			return <RunAfterGridMoveParticipants>d__.<>t__builder.Task;
		}

		// Token: 0x06031EAD RID: 204461 RVA: 0x00C7E12C File Offset: 0x00C7C32C
		private IReadOnlyList<int> CollectMovedRoleIds(IReadOnlyList<IGridMoveParticipantExecution> executions)
		{
			HashSet<int> hashSet = new HashSet<int>();
			foreach (IGridMoveParticipantExecution gridMoveParticipantExecution in executions)
			{
				int? movedRoleId = gridMoveParticipantExecution.Participant.MovedRoleId;
				if (movedRoleId != null)
				{
					hashSet.Add(movedRoleId.Value);
				}
			}
			return hashSet.ToList<int>();
		}

		// Token: 0x06031EAE RID: 204462 RVA: 0x00C7E19C File Offset: 0x00C7C39C
		private IWuWaGoMovableFloorBatchResult CreateMovableFloorBatchResult(bool committed, [Nullable(2)] IReadOnlyList<int> movedRoleIds = null)
		{
			return new WuWaGoMovableFloorBatchResult
			{
				Committed = committed,
				MovedRoleIds = (movedRoleIds ?? new List<int>())
			};
		}

		// Token: 0x06031EAF RID: 204463 RVA: 0x00C7E1BC File Offset: 0x00C7C3BC
		[NullableContext(0)]
		private UniTask<bool> PlayRelocationPresentation([Nullable(1)] IMovableFloorMoveRequest request)
		{
			WuWaGoGridMutationService.<PlayRelocationPresentation>d__11 <PlayRelocationPresentation>d__;
			<PlayRelocationPresentation>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PlayRelocationPresentation>d__.<>4__this = this;
			<PlayRelocationPresentation>d__.request = request;
			<PlayRelocationPresentation>d__.<>1__state = -1;
			<PlayRelocationPresentation>d__.<>t__builder.Start<WuWaGoGridMutationService.<PlayRelocationPresentation>d__11>(ref <PlayRelocationPresentation>d__);
			return <PlayRelocationPresentation>d__.<>t__builder.Task;
		}

		// Token: 0x06031EB0 RID: 204464 RVA: 0x00C7E208 File Offset: 0x00C7C408
		private float? ResolveMoveSpeed()
		{
			BP_WuWaGo_C setting = WuWaGoGlobal.Setting;
			int? num = (setting != null) ? new int?(setting.MovableFloorMoveSpeed) : null;
			if (num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (num2.GetValueOrDefault() > num3 & num2 != null)
				{
					num2 = num;
					if (num2 == null)
					{
						return null;
					}
					return new float?((float)num2.GetValueOrDefault());
				}
			}
			BP_WuWaGo_C setting2 = WuWaGoGlobal.Setting;
			int? num4 = (setting2 != null) ? new int?(setting2.SingleGridSize) : null;
			if ((num4 ?? 0) != 0)
			{
				int? num2 = num4;
				int num3 = 0;
				if (!(num2.GetValueOrDefault() <= num3 & num2 != null))
				{
					num2 = num4;
					float? num5 = (num2 != null) ? new float?((float)num2.GetValueOrDefault()) : null;
					float num6 = (float)WuWaGoGridMutationService.LegacyMoveDurationPerGridMs / 1000f;
					if (num5 == null)
					{
						return null;
					}
					return new float?(num5.GetValueOrDefault() / num6);
				}
			}
			return null;
		}

		// Token: 0x0401D35A RID: 119642
		[CompilerGenerated]
		private WuWaGoGameData <data>P = data;

		// Token: 0x0401D35B RID: 119643
		private static readonly int LegacyMoveDurationPerGridMs = 150;
	}
}
