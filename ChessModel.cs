using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001292 RID: 4754
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ChessModel : ModelBase<ChessModel>
{
	// Token: 0x06007F40 RID: 32576 RVA: 0x0021A38D File Offset: 0x0021858D
	protected override bool OnLeaveLevel()
	{
		this.ClearAll();
		return true;
	}

	// Token: 0x06007F41 RID: 32577 RVA: 0x0021A396 File Offset: 0x00218596
	protected override bool OnClear()
	{
		this.ClearAll();
		return true;
	}

	// Token: 0x06007F42 RID: 32578 RVA: 0x0021A3A0 File Offset: 0x002185A0
	public void ClearAll()
	{
		this.ChessManager = null;
		this.ChessboardPoints.Clear();
		foreach (KeyValuePair<int, ChessItem> keyValuePair in this.ChessItems)
		{
			keyValuePair.Value.OnClear();
		}
		this.ChessItems.Clear();
		this.TerminalPoint = null;
		this.CacheRankingItemIdList = null;
	}

	// Token: 0x06007F43 RID: 32579 RVA: 0x0021A424 File Offset: 0x00218624
	public IChessManager GetChessManager()
	{
		return this.ChessManager;
	}

	// Token: 0x06007F44 RID: 32580 RVA: 0x0021A42C File Offset: 0x0021862C
	public ChessItem GetChessItem(int id)
	{
		ChessItem result;
		if (this.ChessItems.TryGetValue(id, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06007F45 RID: 32581 RVA: 0x0021A44C File Offset: 0x0021864C
	[NullableContext(1)]
	public List<int> GetChessItemIdList([Nullable(new byte[]
	{
		2,
		1
	})] Comparison<ChessItem> compare = null)
	{
		List<int> list = new List<int>();
		if (compare == null)
		{
			foreach (KeyValuePair<int, ChessItem> keyValuePair in this.ChessItems)
			{
				list.Add(keyValuePair.Key);
			}
			return list;
		}
		List<ChessItem> list2 = new List<ChessItem>();
		foreach (KeyValuePair<int, ChessItem> keyValuePair2 in this.ChessItems)
		{
			list2.Add(keyValuePair2.Value);
		}
		list2.Sort(compare);
		foreach (ChessItem chessItem in list2)
		{
			list.Add(chessItem.GetId());
		}
		return list;
	}

	// Token: 0x06007F46 RID: 32582 RVA: 0x0021A54C File Offset: 0x0021874C
	public ChessboardPoint GetChessboardPoint(int id)
	{
		ChessboardPoint result;
		if (this.ChessboardPoints.TryGetValue(id, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06007F47 RID: 32583 RVA: 0x0021A56C File Offset: 0x0021876C
	public ChessboardPoint GetTerminalPoint()
	{
		return this.TerminalPoint;
	}

	// Token: 0x06007F48 RID: 32584 RVA: 0x0021A574 File Offset: 0x00218774
	public void UpdateChessMode(EChessMode mode, EChessAgentType agentType = EChessAgentType.EntityComponent)
	{
		this.ChessAgentType = agentType;
		this.ChessManager = ChessManagerCreator.CreateChessManager(mode);
	}

	// Token: 0x06007F49 RID: 32585 RVA: 0x0021A58C File Offset: 0x0021878C
	[NullableContext(1)]
	public void AddChessboardPoint(int id, Vector location, Rotator rotator, [Nullable(2)] Rotator backwardRotation, int sortIndex)
	{
		if (this.ChessManager == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Chess, ELogAuthor.LYY, "请先设置正确的棋局模式", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ChessboardPoint chessboardPoint = this.ChessManager.CreateChessboardPoint();
		chessboardPoint.Init(id, location, rotator, backwardRotation, sortIndex);
		this.ChessboardPoints.Add(id, chessboardPoint);
	}

	// Token: 0x06007F4A RID: 32586 RVA: 0x0021A5E8 File Offset: 0x002187E8
	[NullableContext(1)]
	public void AddChessItem(int id, EntityHandle entityHandle, bool rotationIsForward)
	{
		if (this.ChessManager == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Chess, ELogAuthor.LYY, "请设置正确的棋局模式", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		IChessAgent chessAgent = this.ChessManager.GetChessAgent(this.ChessAgentType, entityHandle);
		if (chessAgent == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Chess, ELogAuthor.LYY, "创建棋子代理失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ChessItem chessItem = this.ChessManager.CreateChessItem();
		chessItem.Init(id, chessAgent, rotationIsForward);
		this.ChessItems.Add(id, chessItem);
	}

	// Token: 0x06007F4B RID: 32587 RVA: 0x0021A678 File Offset: 0x00218878
	public void UpdateTerminalPoint(int pointId)
	{
		ChessboardPoint terminalPoint;
		if (this.ChessboardPoints.TryGetValue(pointId, out terminalPoint))
		{
			this.TerminalPoint = terminalPoint;
			return;
		}
		this.TerminalPoint = null;
	}

	// Token: 0x04003CF0 RID: 15600
	private IChessManager ChessManager;

	// Token: 0x04003CF1 RID: 15601
	private EChessAgentType ChessAgentType;

	// Token: 0x04003CF2 RID: 15602
	[Nullable(1)]
	private readonly Dictionary<int, ChessboardPoint> ChessboardPoints = new Dictionary<int, ChessboardPoint>();

	// Token: 0x04003CF3 RID: 15603
	[Nullable(1)]
	private readonly Dictionary<int, ChessItem> ChessItems = new Dictionary<int, ChessItem>();

	// Token: 0x04003CF4 RID: 15604
	private ChessboardPoint TerminalPoint;

	// Token: 0x04003CF5 RID: 15605
	public int[] CacheRankingItemIdList;
}
