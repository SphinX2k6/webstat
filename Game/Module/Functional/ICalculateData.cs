using System;

namespace CSharpScript.Game.Module.Functional
{
	// Token: 0x02005D20 RID: 23840
	public interface ICalculateData
	{
		// Token: 0x1700987C RID: 39036
		// (get) Token: 0x0603C1CF RID: 246223
		// (set) Token: 0x0603C1D0 RID: 246224
		int TotalGridNumber { get; set; }

		// Token: 0x1700987D RID: 39037
		// (get) Token: 0x0603C1D1 RID: 246225
		// (set) Token: 0x0603C1D2 RID: 246226
		float OffsetWidth { get; set; }

		// Token: 0x1700987E RID: 39038
		// (get) Token: 0x0603C1D3 RID: 246227
		// (set) Token: 0x0603C1D4 RID: 246228
		int HorizontalGridNum { get; set; }

		// Token: 0x1700987F RID: 39039
		// (get) Token: 0x0603C1D5 RID: 246229
		// (set) Token: 0x0603C1D6 RID: 246230
		int VerticalGridNum { get; set; }
	}
}
