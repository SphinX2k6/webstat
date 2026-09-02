using System;
using System.Runtime.CompilerServices;

// Token: 0x02002933 RID: 10547
public class RouletteData
{
	// Token: 0x06014F16 RID: 85782 RVA: 0x005CBB04 File Offset: 0x005C9D04
	[NullableContext(1)]
	public RouletteData DeepCopy()
	{
		return new RouletteData
		{
			DataIndex = this.DataIndex,
			GridIndex = this.GridIndex,
			GridType = this.GridType,
			Id = this.Id,
			Name = this.Name,
			State = this.State,
			ShowIndex = this.ShowIndex,
			ShowRedDot = this.ShowRedDot,
			UseType = this.UseType
		};
	}

	// Token: 0x0400A15B RID: 41307
	public int Id;

	// Token: 0x0400A15C RID: 41308
	public bool ShowIndex;

	// Token: 0x0400A15D RID: 41309
	public int GridIndex;

	// Token: 0x0400A15E RID: 41310
	public ERouletteGridType GridType;

	// Token: 0x0400A15F RID: 41311
	public bool ShowNum;

	// Token: 0x0400A160 RID: 41312
	public int DataNum;

	// Token: 0x0400A161 RID: 41313
	public int DataIndex;

	// Token: 0x0400A162 RID: 41314
	[Nullable(2)]
	public string Name;

	// Token: 0x0400A163 RID: 41315
	public EGridBehavior State = EGridBehavior.Normal;

	// Token: 0x0400A164 RID: 41316
	public bool ShowRedDot = true;

	// Token: 0x0400A165 RID: 41317
	public EGridUseType UseType;
}
