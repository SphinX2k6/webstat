using System;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Game.Input;

// Token: 0x02003049 RID: 12361
public interface IInputBase
{
	// Token: 0x1700221C RID: 8732
	// (get) Token: 0x0601954F RID: 103759
	// (set) Token: 0x06019550 RID: 103760
	CSharpScript.Game.Input.EInputAction Action { get; set; }

	// Token: 0x1700221D RID: 8733
	// (get) Token: 0x06019551 RID: 103761
	// (set) Token: 0x06019552 RID: 103762
	EInputState State { get; set; }

	// Token: 0x1700221E RID: 8734
	// (get) Token: 0x06019553 RID: 103763
	// (set) Token: 0x06019554 RID: 103764
	float Time { get; set; }

	// Token: 0x1700221F RID: 8735
	// (get) Token: 0x06019555 RID: 103765
	// (set) Token: 0x06019556 RID: 103766
	int Id { get; set; }

	// Token: 0x17002220 RID: 8736
	// (get) Token: 0x06019557 RID: 103767
	// (set) Token: 0x06019558 RID: 103768
	float Param { get; set; }
}
