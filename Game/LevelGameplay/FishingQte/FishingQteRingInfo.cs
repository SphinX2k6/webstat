using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E91 RID: 28305
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingQteRingInfo
	{
		// Token: 0x1700A3C4 RID: 41924
		// (get) Token: 0x06044A28 RID: 281128 RVA: 0x011D6EF6 File Offset: 0x011D50F6
		// (set) Token: 0x06044A29 RID: 281129 RVA: 0x011D6EFE File Offset: 0x011D50FE
		public EArrowDirection ArrowDirection { get; set; }

		// Token: 0x06044A2A RID: 281130 RVA: 0x011D6F07 File Offset: 0x011D5107
		public FishingQteRingInfo(EArrowDirection arrowDirection)
		{
			this.ArrowDirection = arrowDirection;
		}

		// Token: 0x06044A2B RID: 281131 RVA: 0x011D6F45 File Offset: 0x011D5145
		public void Clear()
		{
			this.ValidAreas.Clear();
			this.QteAreas.Clear();
		}

		// Token: 0x06044A2C RID: 281132 RVA: 0x011D6F5D File Offset: 0x011D515D
		public List<RingArea> GetValidAreas()
		{
			return this.ValidAreas;
		}

		// Token: 0x06044A2D RID: 281133 RVA: 0x011D6F65 File Offset: 0x011D5165
		public void AddValidArea(int startCellIndex, int endCellIndex)
		{
			this.ValidAreas.Add(new RingArea(startCellIndex, endCellIndex, this.ArrowDirection));
		}

		// Token: 0x06044A2E RID: 281134 RVA: 0x011D6F7F File Offset: 0x011D517F
		public void ClearValidAreas()
		{
			this.ValidAreas.Clear();
		}

		// Token: 0x06044A2F RID: 281135 RVA: 0x011D6F8C File Offset: 0x011D518C
		public Dictionary<int, ContinuousRingArea> GetQteAreas()
		{
			return this.QteAreas;
		}

		// Token: 0x06044A30 RID: 281136 RVA: 0x011D6F94 File Offset: 0x011D5194
		[NullableContext(2)]
		public ContinuousRingArea GetQteArea(int continuousIndex)
		{
			ContinuousRingArea result;
			if (this.QteAreas.TryGetValue(continuousIndex, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06044A31 RID: 281137 RVA: 0x011D6FB4 File Offset: 0x011D51B4
		public void AddQteArea(int continuousIndex, int startCellIndex, int endCellIndex)
		{
			this.QteAreas[continuousIndex] = new ContinuousRingArea(continuousIndex, startCellIndex, endCellIndex, this.ArrowDirection);
		}

		// Token: 0x06044A32 RID: 281138 RVA: 0x011D6FD0 File Offset: 0x011D51D0
		public void RemoveQteArea(int continuousIndex)
		{
			this.QteAreas.Remove(continuousIndex);
		}

		// Token: 0x06044A33 RID: 281139 RVA: 0x011D6FDF File Offset: 0x011D51DF
		public Dictionary<int, ContinuousRingArea> GetPerfectAreas()
		{
			return this.PerfectAreas;
		}

		// Token: 0x06044A34 RID: 281140 RVA: 0x011D6FE8 File Offset: 0x011D51E8
		[NullableContext(2)]
		public ContinuousRingArea GetPerfectArea(int continuousIndex)
		{
			ContinuousRingArea result;
			if (this.PerfectAreas.TryGetValue(continuousIndex, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06044A35 RID: 281141 RVA: 0x011D7008 File Offset: 0x011D5208
		public void AddPerfectArea(int continuousIndex, int startCellIndex, int endCellIndex)
		{
			this.PerfectAreas[continuousIndex] = new ContinuousRingArea(continuousIndex, startCellIndex, endCellIndex, this.ArrowDirection);
		}

		// Token: 0x06044A36 RID: 281142 RVA: 0x011D7024 File Offset: 0x011D5224
		public void RemovePerfectArea(int continuousIndex)
		{
			this.PerfectAreas.Remove(continuousIndex);
		}

		// Token: 0x06044A37 RID: 281143 RVA: 0x011D7034 File Offset: 0x011D5234
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

		// Token: 0x06044A38 RID: 281144 RVA: 0x011D70DC File Offset: 0x011D52DC
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
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFishingQteAreaChange, this.CurrentArrowStayRelativeValidAreaIndex);
		}

		// Token: 0x06044A39 RID: 281145 RVA: 0x011D7164 File Offset: 0x011D5364
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

		// Token: 0x0402635F RID: 156511
		public int CurrentArrowStayRelativeValidAreaIndex = -1;

		// Token: 0x04026360 RID: 156512
		public int CurrentArrowStayCellIndex;

		// Token: 0x04026362 RID: 156514
		public List<RingArea> ValidAreas = new List<RingArea>();

		// Token: 0x04026363 RID: 156515
		private Dictionary<int, ContinuousRingArea> QteAreas = new Dictionary<int, ContinuousRingArea>();

		// Token: 0x04026364 RID: 156516
		private Dictionary<int, ContinuousRingArea> PerfectAreas = new Dictionary<int, ContinuousRingArea>();

		// Token: 0x04026365 RID: 156517
		public bool IsWholeRing = true;
	}
}
