using System;

// Token: 0x020011BC RID: 4540
public class RingArea
{
	// Token: 0x06007776 RID: 30582 RVA: 0x001F3F64 File Offset: 0x001F2164
	public RingArea(int startCellIndex, int endCellIndex, EArrowDirection arrowDirection)
	{
		this.StartCellIndex = startCellIndex;
		this.EndCellIndex = endCellIndex;
		this.ArrowDirection = arrowDirection;
	}

	// Token: 0x06007777 RID: 30583 RVA: 0x001F3F84 File Offset: 0x001F2184
	public void OnArrowDirectionReverse()
	{
		EArrowDirection arrowDirection = this.ArrowDirection;
		if (arrowDirection == EArrowDirection.Clockwise)
		{
			this.ArrowDirection = EArrowDirection.Anticlockwise;
			return;
		}
		if (arrowDirection != EArrowDirection.Anticlockwise)
		{
			return;
		}
		this.ArrowDirection = EArrowDirection.Clockwise;
	}

	// Token: 0x040039CD RID: 14797
	public int StartCellIndex;

	// Token: 0x040039CE RID: 14798
	public int EndCellIndex;

	// Token: 0x040039CF RID: 14799
	public EArrowDirection ArrowDirection;
}
