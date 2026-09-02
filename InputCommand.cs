using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Input.Structures;
using CSharpScript.Game.Input;

// Token: 0x0200304B RID: 12363
[NullableContext(1)]
[Nullable(0)]
public class InputCommand : IInputBase
{
	// Token: 0x17002226 RID: 8742
	// (get) Token: 0x06019564 RID: 103780 RVA: 0x0074D01A File Offset: 0x0074B21A
	// (set) Token: 0x06019565 RID: 103781 RVA: 0x0074D022 File Offset: 0x0074B222
	public CSharpScript.Game.Input.EInputAction Action { get; set; }

	// Token: 0x17002227 RID: 8743
	// (get) Token: 0x06019566 RID: 103782 RVA: 0x0074D02B File Offset: 0x0074B22B
	// (set) Token: 0x06019567 RID: 103783 RVA: 0x0074D033 File Offset: 0x0074B233
	public EInputState State { get; set; }

	// Token: 0x17002228 RID: 8744
	// (get) Token: 0x06019568 RID: 103784 RVA: 0x0074D03C File Offset: 0x0074B23C
	// (set) Token: 0x06019569 RID: 103785 RVA: 0x0074D044 File Offset: 0x0074B244
	public float Time { get; set; }

	// Token: 0x17002229 RID: 8745
	// (get) Token: 0x0601956A RID: 103786 RVA: 0x0074D04D File Offset: 0x0074B24D
	// (set) Token: 0x0601956B RID: 103787 RVA: 0x0074D055 File Offset: 0x0074B255
	public SInputCommand Command { get; set; }

	// Token: 0x1700222A RID: 8746
	// (get) Token: 0x0601956C RID: 103788 RVA: 0x0074D05E File Offset: 0x0074B25E
	// (set) Token: 0x0601956D RID: 103789 RVA: 0x0074D066 File Offset: 0x0074B266
	public int Index { get; set; }

	// Token: 0x1700222B RID: 8747
	// (get) Token: 0x0601956E RID: 103790 RVA: 0x0074D06F File Offset: 0x0074B26F
	// (set) Token: 0x0601956F RID: 103791 RVA: 0x0074D077 File Offset: 0x0074B277
	public int Id { get; set; }

	// Token: 0x1700222C RID: 8748
	// (get) Token: 0x06019570 RID: 103792 RVA: 0x0074D080 File Offset: 0x0074B280
	// (set) Token: 0x06019571 RID: 103793 RVA: 0x0074D088 File Offset: 0x0074B288
	public float Param { get; set; }

	// Token: 0x06019572 RID: 103794 RVA: 0x0074D091 File Offset: 0x0074B291
	public InputCommand(CSharpScript.Game.Input.EInputAction action, EInputState state, float time, SInputCommand command, int index)
	{
		this.Action = action;
		this.State = state;
		this.Time = time;
		this.Command = command;
		this.Index = index;
		this.Id = -1;
		this.Param = 0f;
	}
}
