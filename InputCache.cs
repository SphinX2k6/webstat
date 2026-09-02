using System;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Game.Input;

// Token: 0x0200304C RID: 12364
public class InputCache : IInputBase
{
	// Token: 0x1700222D RID: 8749
	// (get) Token: 0x06019573 RID: 103795 RVA: 0x0074D0D0 File Offset: 0x0074B2D0
	// (set) Token: 0x06019574 RID: 103796 RVA: 0x0074D0D8 File Offset: 0x0074B2D8
	public CSharpScript.Game.Input.EInputAction Action { get; set; }

	// Token: 0x1700222E RID: 8750
	// (get) Token: 0x06019575 RID: 103797 RVA: 0x0074D0E1 File Offset: 0x0074B2E1
	// (set) Token: 0x06019576 RID: 103798 RVA: 0x0074D0E9 File Offset: 0x0074B2E9
	public EInputState State { get; set; }

	// Token: 0x1700222F RID: 8751
	// (get) Token: 0x06019577 RID: 103799 RVA: 0x0074D0F2 File Offset: 0x0074B2F2
	// (set) Token: 0x06019578 RID: 103800 RVA: 0x0074D0FA File Offset: 0x0074B2FA
	public float Time { get; set; }

	// Token: 0x17002230 RID: 8752
	// (get) Token: 0x06019579 RID: 103801 RVA: 0x0074D103 File Offset: 0x0074B303
	// (set) Token: 0x0601957A RID: 103802 RVA: 0x0074D10B File Offset: 0x0074B30B
	public float WorldTime { get; set; }

	// Token: 0x17002231 RID: 8753
	// (get) Token: 0x0601957B RID: 103803 RVA: 0x0074D114 File Offset: 0x0074B314
	// (set) Token: 0x0601957C RID: 103804 RVA: 0x0074D11C File Offset: 0x0074B31C
	public int Id { get; set; }

	// Token: 0x17002232 RID: 8754
	// (get) Token: 0x0601957D RID: 103805 RVA: 0x0074D125 File Offset: 0x0074B325
	// (set) Token: 0x0601957E RID: 103806 RVA: 0x0074D12D File Offset: 0x0074B32D
	public float Param { get; set; }

	// Token: 0x17002233 RID: 8755
	// (get) Token: 0x0601957F RID: 103807 RVA: 0x0074D136 File Offset: 0x0074B336
	// (set) Token: 0x06019580 RID: 103808 RVA: 0x0074D13E File Offset: 0x0074B33E
	public double AccumulateTime { get; set; }

	// Token: 0x06019581 RID: 103809 RVA: 0x0074D147 File Offset: 0x0074B347
	public InputCache(CSharpScript.Game.Input.EInputAction action, EInputState state, float time, float worldTime, float accumulateTime, int id = -1, float param = 0f)
	{
		this.Action = action;
		this.State = state;
		this.Time = time;
		this.WorldTime = worldTime;
		this.AccumulateTime = (double)accumulateTime;
		this.Id = id;
		this.Param = param;
	}
}
