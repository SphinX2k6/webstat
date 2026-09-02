using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll
{
	// Token: 0x02006F58 RID: 28504
	[NullableContext(1)]
	[Nullable(0)]
	public class BigStuffedGameInfo
	{
		// Token: 0x06044FE0 RID: 282592 RVA: 0x011F4FFC File Offset: 0x011F31FC
		public BigStuffedRingInfo AddRingInfo(int id, EArrowDirection arrowDirection)
		{
			BigStuffedRingInfo bigStuffedRingInfo = new BigStuffedRingInfo(id, arrowDirection);
			this.RingInfosMap[id] = bigStuffedRingInfo;
			this.RingInfosArr.Add(bigStuffedRingInfo);
			return bigStuffedRingInfo;
		}

		// Token: 0x06044FE1 RID: 282593 RVA: 0x011F502C File Offset: 0x011F322C
		public void Clear()
		{
			foreach (KeyValuePair<int, BigStuffedRingInfo> keyValuePair in this.RingInfosMap)
			{
				keyValuePair.Value.Clear();
			}
			this.RingInfosMap.Clear();
			this.RingInfosArr.Clear();
			this.CurrentArrowStayTotalIndex = -1;
			this.CurrentArrowStayRingId = -1;
			this.CurrentArrowStayRelativeValidAreaIndex = -1;
			this.CurrentArrowStayCellIndex = 0;
		}

		// Token: 0x06044FE2 RID: 282594 RVA: 0x011F50B8 File Offset: 0x011F32B8
		[NullableContext(2)]
		public BigStuffedRingInfo GetRingInfo(int id)
		{
			BigStuffedRingInfo result;
			if (this.RingInfosMap.TryGetValue(id, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06044FE3 RID: 282595 RVA: 0x011F50D8 File Offset: 0x011F32D8
		public void UpdateCurrentArrowStayInfo()
		{
			if (this.RingInfosArr.Count == 0)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			foreach (BigStuffedRingInfo bigStuffedRingInfo in this.RingInfosArr)
			{
				num += bigStuffedRingInfo.ValidAreas.Count;
				if (this.CurrentArrowStayTotalIndex < num)
				{
					this.CurrentArrowStayRingId = bigStuffedRingInfo.RingId;
					this.CurrentArrowStayRelativeValidAreaIndex = this.CurrentArrowStayTotalIndex - num2;
					break;
				}
				num2 = num;
			}
		}

		// Token: 0x06044FE4 RID: 282596 RVA: 0x011F516C File Offset: 0x011F336C
		public int GetValidAreaNum()
		{
			int num = 0;
			foreach (BigStuffedRingInfo bigStuffedRingInfo in this.RingInfosArr)
			{
				num += bigStuffedRingInfo.ValidAreas.Count;
			}
			return num;
		}

		// Token: 0x06044FE5 RID: 282597 RVA: 0x011F51CC File Offset: 0x011F33CC
		public void OnArrowDirectionReverse()
		{
			foreach (BigStuffedRingInfo bigStuffedRingInfo in this.RingInfosArr)
			{
				bigStuffedRingInfo.OnArrowDirectionReverse();
			}
		}

		// Token: 0x040267A3 RID: 157603
		private readonly Dictionary<int, BigStuffedRingInfo> RingInfosMap = new Dictionary<int, BigStuffedRingInfo>();

		// Token: 0x040267A4 RID: 157604
		private readonly List<BigStuffedRingInfo> RingInfosArr = new List<BigStuffedRingInfo>();

		// Token: 0x040267A5 RID: 157605
		public int CurrentArrowStayTotalIndex = -1;

		// Token: 0x040267A6 RID: 157606
		public int CurrentArrowStayRingId = -1;

		// Token: 0x040267A7 RID: 157607
		public int CurrentArrowStayRelativeValidAreaIndex = -1;

		// Token: 0x040267A8 RID: 157608
		public int CurrentArrowStayCellIndex;
	}
}
