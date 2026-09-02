using System;
using System.Runtime.CompilerServices;

// Token: 0x02001283 RID: 4739
[NullableContext(1)]
[Nullable(0)]
public abstract class ChessboardPoint
{
	// Token: 0x06007EE4 RID: 32484 RVA: 0x00219DC4 File Offset: 0x00217FC4
	public void Init(int id, Vector location, Rotator rotator, [Nullable(2)] Rotator backwardRotator, int sortIndex)
	{
		this.Id = id;
		this.SortIndex = sortIndex;
		this.Location.DeepCopy(location);
		this.Rotator.DeepCopy(rotator);
		if (backwardRotator != null)
		{
			this.BackwardRotator = Rotator.Create();
			this.BackwardRotator.DeepCopy(backwardRotator);
		}
	}

	// Token: 0x06007EE5 RID: 32485 RVA: 0x00219E14 File Offset: 0x00218014
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x06007EE6 RID: 32486 RVA: 0x00219E1C File Offset: 0x0021801C
	public int GetSortIndex()
	{
		return this.SortIndex;
	}

	// Token: 0x06007EE7 RID: 32487 RVA: 0x00219E24 File Offset: 0x00218024
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public virtual ValueTuple<Vector, Rotator> GetMoveLocationAndRotator(bool rotationIsForward = true)
	{
		return new ValueTuple<Vector, Rotator>(this.Location, this.GetPointRotator(rotationIsForward));
	}

	// Token: 0x06007EE8 RID: 32488 RVA: 0x00219E38 File Offset: 0x00218038
	public Vector GetPointLocation()
	{
		return this.Location;
	}

	// Token: 0x06007EE9 RID: 32489 RVA: 0x00219E40 File Offset: 0x00218040
	public Rotator GetPointRotator(bool rotationIsForward = true)
	{
		if (rotationIsForward || this.BackwardRotator == null)
		{
			return this.Rotator;
		}
		return this.BackwardRotator;
	}

	// Token: 0x06007EEA RID: 32490
	public abstract void ItemEnter(ChessItem chessItem);

	// Token: 0x06007EEB RID: 32491
	public abstract void ItemLeave(ChessItem chessItem);

	// Token: 0x06007EEC RID: 32492
	public abstract void ChangeItemToMaxPriority(ChessItem chessItem);

	// Token: 0x06007EED RID: 32493
	public abstract int ComparePriority(ChessItem a, ChessItem b);

	// Token: 0x04003CD1 RID: 15569
	private int Id;

	// Token: 0x04003CD2 RID: 15570
	private int SortIndex;

	// Token: 0x04003CD3 RID: 15571
	private readonly Vector Location = Vector.Create();

	// Token: 0x04003CD4 RID: 15572
	private readonly Rotator Rotator = Rotator.Create();

	// Token: 0x04003CD5 RID: 15573
	[Nullable(2)]
	private Rotator BackwardRotator;
}
