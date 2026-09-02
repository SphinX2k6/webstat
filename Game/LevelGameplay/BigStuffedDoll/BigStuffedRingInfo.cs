using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll
{
	// Token: 0x02006F59 RID: 28505
	[NullableContext(1)]
	[Nullable(0)]
	public class BigStuffedRingInfo
	{
		// Token: 0x06044FE7 RID: 282599 RVA: 0x011F5250 File Offset: 0x011F3450
		public BigStuffedRingInfo(int RingId, EArrowDirection ArrowDirection)
		{
			this.RingId = RingId;
			this.ArrowDirection = ArrowDirection;
		}

		// Token: 0x06044FE8 RID: 282600 RVA: 0x011F529D File Offset: 0x011F349D
		public void Clear()
		{
			this.ValidAreas.Clear();
			this.GoodAreas.Clear();
			this.PerfectAreas.Clear();
			this.BonusAreas.Clear();
		}

		// Token: 0x06044FE9 RID: 282601 RVA: 0x011F52CB File Offset: 0x011F34CB
		public List<Area> GetValidAreas()
		{
			return this.ValidAreas;
		}

		// Token: 0x06044FEA RID: 282602 RVA: 0x011F52D3 File Offset: 0x011F34D3
		public void AddValidArea(int startCellIndex, int endCellIndex)
		{
			this.ValidAreas.Add(new Area(startCellIndex, endCellIndex, this.ArrowDirection));
		}

		// Token: 0x06044FEB RID: 282603 RVA: 0x011F52ED File Offset: 0x011F34ED
		public void ClearValidAreas()
		{
			this.ValidAreas.Clear();
		}

		// Token: 0x06044FEC RID: 282604 RVA: 0x011F52FA File Offset: 0x011F34FA
		public Dictionary<int, ContinuousArea> GetGoodAreas()
		{
			return this.GoodAreas;
		}

		// Token: 0x06044FED RID: 282605 RVA: 0x011F5304 File Offset: 0x011F3504
		[NullableContext(2)]
		public ContinuousArea GetGoodArea(int continuousIndex)
		{
			ContinuousArea result;
			if (this.GoodAreas.TryGetValue(continuousIndex, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06044FEE RID: 282606 RVA: 0x011F5324 File Offset: 0x011F3524
		public void AddGoodArea(int continuousIndex, int startCellIndex, int endCellIndex)
		{
			this.GoodAreas[continuousIndex] = new ContinuousArea(continuousIndex, startCellIndex, endCellIndex, this.ArrowDirection);
		}

		// Token: 0x06044FEF RID: 282607 RVA: 0x011F5340 File Offset: 0x011F3540
		public void RemoveGoodArea(int continuousIndex)
		{
			this.GoodAreas.Remove(continuousIndex);
		}

		// Token: 0x06044FF0 RID: 282608 RVA: 0x011F534F File Offset: 0x011F354F
		public Dictionary<int, ContinuousArea> GetPerfectAreas()
		{
			return this.PerfectAreas;
		}

		// Token: 0x06044FF1 RID: 282609 RVA: 0x011F5357 File Offset: 0x011F3557
		public void AddPerfectArea(int continuousIndex, int startCellIndex, int endCellIndex)
		{
			this.PerfectAreas[continuousIndex] = new ContinuousArea(continuousIndex, startCellIndex, endCellIndex, this.ArrowDirection);
		}

		// Token: 0x06044FF2 RID: 282610 RVA: 0x011F5373 File Offset: 0x011F3573
		public void RemovePerfectArea(int continuousIndex)
		{
			this.PerfectAreas.Remove(continuousIndex);
		}

		// Token: 0x06044FF3 RID: 282611 RVA: 0x011F5382 File Offset: 0x011F3582
		public Dictionary<int, ContinuousArea> GetBonusAreas()
		{
			return this.BonusAreas;
		}

		// Token: 0x06044FF4 RID: 282612 RVA: 0x011F538A File Offset: 0x011F358A
		public void AddBonusArea(int continuousIndex, int startCellIndex, int endCellIndex)
		{
			this.BonusAreas[continuousIndex] = new ContinuousArea(continuousIndex, startCellIndex, endCellIndex, this.ArrowDirection);
		}

		// Token: 0x06044FF5 RID: 282613 RVA: 0x011F53A8 File Offset: 0x011F35A8
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
			foreach (Area area in this.ValidAreas)
			{
				area.OnArrowDirectionReverse();
			}
			foreach (KeyValuePair<int, ContinuousArea> keyValuePair in this.GoodAreas)
			{
				keyValuePair.Value.OnArrowDirectionReverse();
			}
			foreach (KeyValuePair<int, ContinuousArea> keyValuePair2 in this.PerfectAreas)
			{
				keyValuePair2.Value.OnArrowDirectionReverse();
			}
			foreach (KeyValuePair<int, ContinuousArea> keyValuePair3 in this.BonusAreas)
			{
				keyValuePair3.Value.OnArrowDirectionReverse();
			}
		}

		// Token: 0x040267A9 RID: 157609
		public readonly int RingId;

		// Token: 0x040267AA RID: 157610
		public EArrowDirection ArrowDirection;

		// Token: 0x040267AB RID: 157611
		public readonly List<Area> ValidAreas = new List<Area>();

		// Token: 0x040267AC RID: 157612
		private readonly Dictionary<int, ContinuousArea> GoodAreas = new Dictionary<int, ContinuousArea>();

		// Token: 0x040267AD RID: 157613
		private readonly Dictionary<int, ContinuousArea> PerfectAreas = new Dictionary<int, ContinuousArea>();

		// Token: 0x040267AE RID: 157614
		private readonly Dictionary<int, ContinuousArea> BonusAreas = new Dictionary<int, ContinuousArea>();
	}
}
