using System;
using System.Runtime.CompilerServices;

// Token: 0x020014D8 RID: 5336
[NullableContext(2)]
[Nullable(0)]
internal class PinballBattleLevelStartTipsControllerParam : IPinballBattleLevelStartTipsParam, IPinballBattleTipsBaseParam
{
	// Token: 0x17000CBE RID: 3262
	// (get) Token: 0x0600952A RID: 38186 RVA: 0x00270765 File Offset: 0x0026E965
	// (set) Token: 0x0600952B RID: 38187 RVA: 0x0027076D File Offset: 0x0026E96D
	public int CurWave { get; set; }

	// Token: 0x17000CBF RID: 3263
	// (get) Token: 0x0600952C RID: 38188 RVA: 0x00270776 File Offset: 0x0026E976
	// (set) Token: 0x0600952D RID: 38189 RVA: 0x0027077E File Offset: 0x0026E97E
	public int MaxWave { get; set; }

	// Token: 0x17000CC0 RID: 3264
	// (get) Token: 0x0600952E RID: 38190 RVA: 0x00270787 File Offset: 0x0026E987
	// (set) Token: 0x0600952F RID: 38191 RVA: 0x0027078F File Offset: 0x0026E98F
	public Action CloseCallback { get; set; }

	// Token: 0x17000CC1 RID: 3265
	// (get) Token: 0x06009530 RID: 38192 RVA: 0x00270798 File Offset: 0x0026E998
	// (set) Token: 0x06009531 RID: 38193 RVA: 0x002707A0 File Offset: 0x0026E9A0
	public bool? AddMask { get; set; }

	// Token: 0x17000CC2 RID: 3266
	// (get) Token: 0x06009532 RID: 38194 RVA: 0x002707A9 File Offset: 0x0026E9A9
	// (set) Token: 0x06009533 RID: 38195 RVA: 0x002707B1 File Offset: 0x0026E9B1
	public int? CloseTime { get; set; }

	// Token: 0x17000CC3 RID: 3267
	// (get) Token: 0x06009534 RID: 38196 RVA: 0x002707BA File Offset: 0x0026E9BA
	// (set) Token: 0x06009535 RID: 38197 RVA: 0x002707C2 File Offset: 0x0026E9C2
	public bool? MoveToBehind { get; set; }
}
