using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x0200128C RID: 4748
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ChessController : ControllerBase<ChessController>
{
	// Token: 0x06007F2A RID: 32554 RVA: 0x0021A0C8 File Offset: 0x002182C8
	public UniTask InitChessGameAsync(List<IChessboardPointParams> chessboardPoints, List<IChessItemParams> chessItems, int terminalPointId, EChessMode gameMode = EChessMode.Stackable)
	{
		ChessController.<InitChessGameAsync>d__0 <InitChessGameAsync>d__;
		<InitChessGameAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitChessGameAsync>d__.chessboardPoints = chessboardPoints;
		<InitChessGameAsync>d__.chessItems = chessItems;
		<InitChessGameAsync>d__.terminalPointId = terminalPointId;
		<InitChessGameAsync>d__.gameMode = gameMode;
		<InitChessGameAsync>d__.<>1__state = -1;
		<InitChessGameAsync>d__.<>t__builder.Start<ChessController.<InitChessGameAsync>d__0>(ref <InitChessGameAsync>d__);
		return <InitChessGameAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007F2B RID: 32555 RVA: 0x0021A124 File Offset: 0x00218324
	public UniTask MoveItemToPointAsync(int itemId, int targetPointId, bool isForward = true)
	{
		ChessController.<MoveItemToPointAsync>d__1 <MoveItemToPointAsync>d__;
		<MoveItemToPointAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<MoveItemToPointAsync>d__.itemId = itemId;
		<MoveItemToPointAsync>d__.targetPointId = targetPointId;
		<MoveItemToPointAsync>d__.isForward = isForward;
		<MoveItemToPointAsync>d__.<>1__state = -1;
		<MoveItemToPointAsync>d__.<>t__builder.Start<ChessController.<MoveItemToPointAsync>d__1>(ref <MoveItemToPointAsync>d__);
		return <MoveItemToPointAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007F2C RID: 32556 RVA: 0x0021A178 File Offset: 0x00218378
	public UniTask ChessItemPerformAsync(int itemId, int type)
	{
		ChessController.<ChessItemPerformAsync>d__2 <ChessItemPerformAsync>d__;
		<ChessItemPerformAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ChessItemPerformAsync>d__.itemId = itemId;
		<ChessItemPerformAsync>d__.type = type;
		<ChessItemPerformAsync>d__.<>1__state = -1;
		<ChessItemPerformAsync>d__.<>t__builder.Start<ChessController.<ChessItemPerformAsync>d__2>(ref <ChessItemPerformAsync>d__);
		return <ChessItemPerformAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007F2D RID: 32557 RVA: 0x0021A1C4 File Offset: 0x002183C4
	public static void TeleportItemToPoint(int itemId, int targetPointId)
	{
		ChessItem chessItem = ModelBase<ChessModel>.Instance.GetChessItem(itemId);
		ChessboardPoint chessboardPoint = ModelBase<ChessModel>.Instance.GetChessboardPoint(targetPointId);
		if (chessItem != null && chessboardPoint != null)
		{
			ChessboardPoint currentPoint = chessItem.GetCurrentPoint();
			if (currentPoint != null)
			{
				currentPoint.ItemLeave(chessItem);
			}
			ValueTuple<Vector, Rotator> moveLocationAndRotator = chessboardPoint.GetMoveLocationAndRotator(chessItem.RotationIsForward());
			chessItem.Teleport(moveLocationAndRotator.Item1, moveLocationAndRotator.Item2);
			chessboardPoint.ItemEnter(chessItem);
			ChessController.AfterUpdateItem();
		}
	}

	// Token: 0x06007F2E RID: 32558 RVA: 0x0021A22C File Offset: 0x0021842C
	public void ChangeItemToMaxPriorityInPoint(int itemId)
	{
		ChessItem chessItem = ModelBase<ChessModel>.Instance.GetChessItem(itemId);
		if (chessItem != null)
		{
			ChessboardPoint currentPoint = chessItem.GetCurrentPoint();
			if (currentPoint != null)
			{
				currentPoint.ChangeItemToMaxPriority(chessItem);
			}
		}
		ChessController.AfterUpdateItem();
	}

	// Token: 0x06007F2F RID: 32559 RVA: 0x0021A260 File Offset: 0x00218460
	public void BatchTeleportItemsToPointSorted(List<IChessTransmitData> transmitDataList)
	{
		IChessManager chessManager = ModelBase<ChessModel>.Instance.GetChessManager();
		if (chessManager == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Chess, ELogAuthor.LYY, "ChessManager 不支持 BatchTeleportItemsToPointSorted 操作", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		chessManager.BatchTeleportItemsToPointSorted(transmitDataList);
		ChessController.AfterUpdateItem();
	}

	// Token: 0x06007F30 RID: 32560 RVA: 0x0021A2A7 File Offset: 0x002184A7
	private static void AfterUpdateItem()
	{
		ModelBase<ChessModel>.Instance.CacheRankingItemIdList = null;
	}

	// Token: 0x06007F31 RID: 32561 RVA: 0x0021A2B4 File Offset: 0x002184B4
	public static List<int> GetRankingItemIdList()
	{
		int[] cacheRankingItemIdList = ModelBase<ChessModel>.Instance.CacheRankingItemIdList;
		if (cacheRankingItemIdList != null)
		{
			return new List<int>(cacheRankingItemIdList);
		}
		ChessboardPoint terminalPoint = ModelBase<ChessModel>.Instance.GetTerminalPoint();
		if (terminalPoint == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Chess, ELogAuthor.LYY, "未设置终点，无法比较优先级", default(ReadOnlySpan<ValueTuple<string, object>>));
			return ModelBase<ChessModel>.Instance.GetChessItemIdList(null);
		}
		int terminalSortIndex = terminalPoint.GetSortIndex();
		List<int> chessItemIdList = ModelBase<ChessModel>.Instance.GetChessItemIdList(delegate(ChessItem a, ChessItem b)
		{
			int reachTerminalTimes = a.GetReachTerminalTimes();
			int reachTerminalTimes2 = b.GetReachTerminalTimes();
			if (reachTerminalTimes != reachTerminalTimes2)
			{
				return reachTerminalTimes2 - reachTerminalTimes;
			}
			ChessboardPoint currentPoint = a.GetCurrentPoint();
			ChessboardPoint currentPoint2 = b.GetCurrentPoint();
			if (currentPoint == null || currentPoint2 == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Chess, ELogAuthor.LYY, "棋子所在点位不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return 0;
			}
			if (currentPoint.GetId() == currentPoint2.GetId())
			{
				return currentPoint.ComparePriority(a, b);
			}
			int num = terminalSortIndex - currentPoint.GetSortIndex();
			int num2 = terminalSortIndex - currentPoint2.GetSortIndex();
			if (num == 0)
			{
				return 1;
			}
			if (num2 == 0)
			{
				return -1;
			}
			if (num * num2 <= 0)
			{
				return num2 - num;
			}
			return num - num2;
		});
		ModelBase<ChessModel>.Instance.CacheRankingItemIdList = chessItemIdList.ToArray();
		return chessItemIdList;
	}
}
