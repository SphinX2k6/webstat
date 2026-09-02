using System;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Game.Input;

// Token: 0x0200304A RID: 12362
public class InputEvent : IInputBase
{
	// Token: 0x17002221 RID: 8737
	// (get) Token: 0x06019559 RID: 103769 RVA: 0x0074CF99 File Offset: 0x0074B199
	// (set) Token: 0x0601955A RID: 103770 RVA: 0x0074CFA1 File Offset: 0x0074B1A1
	public CSharpScript.Game.Input.EInputAction Action { get; set; }

	// Token: 0x17002222 RID: 8738
	// (get) Token: 0x0601955B RID: 103771 RVA: 0x0074CFAA File Offset: 0x0074B1AA
	// (set) Token: 0x0601955C RID: 103772 RVA: 0x0074CFB2 File Offset: 0x0074B1B2
	public EInputState State { get; set; }

	// Token: 0x17002223 RID: 8739
	// (get) Token: 0x0601955D RID: 103773 RVA: 0x0074CFBB File Offset: 0x0074B1BB
	// (set) Token: 0x0601955E RID: 103774 RVA: 0x0074CFC3 File Offset: 0x0074B1C3
	public float Time { get; set; }

	// Token: 0x17002224 RID: 8740
	// (get) Token: 0x0601955F RID: 103775 RVA: 0x0074CFCC File Offset: 0x0074B1CC
	// (set) Token: 0x06019560 RID: 103776 RVA: 0x0074CFD4 File Offset: 0x0074B1D4
	public int Id { get; set; }

	// Token: 0x17002225 RID: 8741
	// (get) Token: 0x06019561 RID: 103777 RVA: 0x0074CFDD File Offset: 0x0074B1DD
	// (set) Token: 0x06019562 RID: 103778 RVA: 0x0074CFE5 File Offset: 0x0074B1E5
	public float Param { get; set; }

	// Token: 0x06019563 RID: 103779 RVA: 0x0074CFEE File Offset: 0x0074B1EE
	public InputEvent(CSharpScript.Game.Input.EInputAction action, EInputState state, float time, float param = 0f)
	{
		this.Action = action;
		this.State = state;
		this.Time = time;
		this.Id = -1;
		this.Param = param;
	}
}
