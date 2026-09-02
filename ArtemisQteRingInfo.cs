using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x020011BB RID: 4539
[NullableContext(1)]
[Nullable(0)]
public class ArtemisQteRingInfo
{
	// Token: 0x06007766 RID: 30566 RVA: 0x001F3C4E File Offset: 0x001F1E4E
	public ArtemisQteRingInfo(EArrowDirection arrowDirection)
	{
		this.ArrowDirection = arrowDirection;
	}

	// Token: 0x06007767 RID: 30567 RVA: 0x001F3C8C File Offset: 0x001F1E8C
	public void Clear()
	{
		this.ValidAreas.Clear();
		this.QteAreas.Clear();
	}

	// Token: 0x06007768 RID: 30568 RVA: 0x001F3CA4 File Offset: 0x001F1EA4
	public List<RingArea> GetValidAreas()
	{
		return this.ValidAreas;
	}

	// Token: 0x06007769 RID: 30569 RVA: 0x001F3CAC File Offset: 0x001F1EAC
	public void AddValidArea(int startCellIndex, int endCellIndex)
	{
		this.ValidAreas.Add(new RingArea(startCellIndex, endCellIndex, this.ArrowDirection));
	}

	// Token: 0x0600776A RID: 30570 RVA: 0x001F3CC6 File Offset: 0x001F1EC6
	public void ClearValidAreas()
	{
		this.ValidAreas.Clear();
	}

	// Token: 0x0600776B RID: 30571 RVA: 0x001F3CD3 File Offset: 0x001F1ED3
	public Dictionary<int, ContinuousRingArea> GetQteAreas()
	{
		return this.QteAreas;
	}

	// Token: 0x0600776C RID: 30572 RVA: 0x001F3CDC File Offset: 0x001F1EDC
	[NullableContext(2)]
	public ContinuousRingArea GetQteArea(int continuousIndex)
	{
		ContinuousRingArea result;
		if (!this.QteAreas.TryGetValue(continuousIndex, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600776D RID: 30573 RVA: 0x001F3CFC File Offset: 0x001F1EFC
	public void AddQteArea(int continuousIndex, int startCellIndex, int endCellIndex)
	{
		this.QteAreas[continuousIndex] = new ContinuousRingArea(continuousIndex, startCellIndex, endCellIndex, this.ArrowDirection);
	}

	// Token: 0x0600776E RID: 30574 RVA: 0x001F3D18 File Offset: 0x001F1F18
	public void RemoveQteArea(int continuousIndex)
	{
		this.QteAreas.Remove(continuousIndex);
	}

	// Token: 0x0600776F RID: 30575 RVA: 0x001F3D27 File Offset: 0x001F1F27
	public Dictionary<int, ContinuousRingArea> GetPerfectAreas()
	{
		return this.PerfectAreas;
	}

	// Token: 0x06007770 RID: 30576 RVA: 0x001F3D30 File Offset: 0x001F1F30
	[NullableContext(2)]
	public ContinuousRingArea GetPerfectArea(int continuousIndex)
	{
		ContinuousRingArea result;
		if (!this.PerfectAreas.TryGetValue(continuousIndex, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06007771 RID: 30577 RVA: 0x001F3D50 File Offset: 0x001F1F50
	public void AddPerfectArea(int continuousIndex, int startCellIndex, int endCellIndex)
	{
		this.PerfectAreas[continuousIndex] = new ContinuousRingArea(continuousIndex, startCellIndex, endCellIndex, this.ArrowDirection);
	}

	// Token: 0x06007772 RID: 30578 RVA: 0x001F3D6C File Offset: 0x001F1F6C
	public void RemovePerfectArea(int continuousIndex)
	{
		this.PerfectAreas.Remove(continuousIndex);
	}

	// Token: 0x06007773 RID: 30579 RVA: 0x001F3D7C File Offset: 0x001F1F7C
	[return: Nullable(2)]
	public ContinuousRingArea CheckInArea(Dictionary<int, ContinuousRingArea> areas, int currentArrowStayCellIndex)
	{
		foreach (KeyValuePair<int, ContinuousRingArea> keyValuePair in areas)
		{
			ContinuousRingArea value = keyValuePair.Value;
			int startCellIndex = value.StartCellIndex;
			int endCellIndex = value.EndCellIndex;
			if (endCellIndex >= startCellIndex)
			{
				if (currentArrowStayCellIndex >= startCellIndex && currentArrowStayCellIndex <= endCellIndex)
				{
					return value;
				}
			}
			else
			{
				bool flag = currentArrowStayCellIndex >= startCellIndex && currentArrowStayCellIndex <= 36;
				bool flag2 = currentArrowStayCellIndex >= 1 && currentArrowStayCellIndex <= endCellIndex;
				if (flag || flag2)
				{
					return value;
				}
			}
		}
		return null;
	}

	// Token: 0x06007774 RID: 30580 RVA: 0x001F3E24 File Offset: 0x001F2024
	public void EnterNextValidArea()
	{
		int count = this.ValidAreas.Count;
		if (count == 0)
		{
			return;
		}
		EArrowDirection arrowDirection = this.ArrowDirection;
		if (arrowDirection != EArrowDirection.Clockwise)
		{
			if (arrowDirection == EArrowDirection.Anticlockwise)
			{
				this.CurrentArrowStayRelativeValidAreaIndex--;
			}
		}
		else
		{
			this.CurrentArrowStayRelativeValidAreaIndex++;
		}
		if (this.CurrentArrowStayRelativeValidAreaIndex >= count)
		{
			this.CurrentArrowStayRelativeValidAreaIndex = 0;
		}
		else if (this.CurrentArrowStayRelativeValidAreaIndex < 0)
		{
			this.CurrentArrowStayRelativeValidAreaIndex = count - 1;
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnArtemisQteAreaChange, this.CurrentArrowStayRelativeValidAreaIndex);
	}

	// Token: 0x06007775 RID: 30581 RVA: 0x001F3EAC File Offset: 0x001F20AC
	public void OnArrowDirectionReverse()
	{
		EArrowDirection arrowDirection = this.ArrowDirection;
		if (arrowDirection != EArrowDirection.Clockwise)
		{
			if (arrowDirection == EArrowDirection.Anticlockwise)
			{
				this.ArrowDirection = EArrowDirection.Clockwise;
			}
		}
		else
		{
			this.ArrowDirection = EArrowDirection.Anticlockwise;
		}
		foreach (RingArea ringArea in this.ValidAreas)
		{
			ringArea.OnArrowDirectionReverse();
		}
		foreach (KeyValuePair<int, ContinuousRingArea> keyValuePair in this.QteAreas)
		{
			keyValuePair.Value.OnArrowDirectionReverse();
		}
	}

	// Token: 0x040039C6 RID: 14790
	public int CurrentArrowStayRelativeValidAreaIndex = -1;

	// Token: 0x040039C7 RID: 14791
	public int CurrentArrowStayCellIndex;

	// Token: 0x040039C8 RID: 14792
	public EArrowDirection ArrowDirection;

	// Token: 0x040039C9 RID: 14793
	public readonly List<RingArea> ValidAreas = new List<RingArea>();

	// Token: 0x040039CA RID: 14794
	private readonly Dictionary<int, ContinuousRingArea> QteAreas = new Dictionary<int, ContinuousRingArea>();

	// Token: 0x040039CB RID: 14795
	private readonly Dictionary<int, ContinuousRingArea> PerfectAreas = new Dictionary<int, ContinuousRingArea>();

	// Token: 0x040039CC RID: 14796
	public bool IsWholeRing = true;
}
