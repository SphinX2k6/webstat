using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E91 RID: 3729
[NullableContext(2)]
[Nullable(0)]
public class GameSettings : IGameSettings
{
	// Token: 0x17000688 RID: 1672
	// (get) Token: 0x06005AF2 RID: 23282 RVA: 0x00169A54 File Offset: 0x00167C54
	// (set) Token: 0x06005AF3 RID: 23283 RVA: 0x00169A5C File Offset: 0x00167C5C
	public EFunction GameSettingId { get; set; }

	// Token: 0x17000689 RID: 1673
	// (get) Token: 0x06005AF4 RID: 23284 RVA: 0x00169A65 File Offset: 0x00167C65
	// (set) Token: 0x06005AF5 RID: 23285 RVA: 0x00169A6D File Offset: 0x00167C6D
	[Nullable(1)]
	public object GetCallbackOrGlobalKey { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x1700068A RID: 1674
	// (get) Token: 0x06005AF6 RID: 23286 RVA: 0x00169A76 File Offset: 0x00167C76
	// (set) Token: 0x06005AF7 RID: 23287 RVA: 0x00169A7E File Offset: 0x00167C7E
	public Func<int, EGameSettingsApplyReason, bool> ApplyCallback { get; set; }

	// Token: 0x1700068B RID: 1675
	// (get) Token: 0x06005AF8 RID: 23288 RVA: 0x00169A87 File Offset: 0x00167C87
	// (set) Token: 0x06005AF9 RID: 23289 RVA: 0x00169A8F File Offset: 0x00167C8F
	public Func<float, EGameSettingsApplyReason, bool> ApplyCallbackFloat { get; set; }

	// Token: 0x1700068C RID: 1676
	// (get) Token: 0x06005AFA RID: 23290 RVA: 0x00169A98 File Offset: 0x00167C98
	// (set) Token: 0x06005AFB RID: 23291 RVA: 0x00169AA0 File Offset: 0x00167CA0
	public Action<int, EGameSettingsApplyReason> HandleDoneCallback { get; set; }

	// Token: 0x1700068D RID: 1677
	// (get) Token: 0x06005AFC RID: 23292 RVA: 0x00169AA9 File Offset: 0x00167CA9
	// (set) Token: 0x06005AFD RID: 23293 RVA: 0x00169AB1 File Offset: 0x00167CB1
	[Nullable(1)]
	public Func<string> DumpCallback { [NullableContext(1)] get; [NullableContext(1)] set; }
}
