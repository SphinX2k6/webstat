using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E90 RID: 3728
[NullableContext(2)]
public interface IGameSettings
{
	// Token: 0x17000682 RID: 1666
	// (get) Token: 0x06005AEC RID: 23276
	EFunction GameSettingId { get; }

	// Token: 0x17000683 RID: 1667
	// (get) Token: 0x06005AED RID: 23277
	[Nullable(1)]
	object GetCallbackOrGlobalKey { [NullableContext(1)] get; }

	// Token: 0x17000684 RID: 1668
	// (get) Token: 0x06005AEE RID: 23278
	Func<int, EGameSettingsApplyReason, bool> ApplyCallback { get; }

	// Token: 0x17000685 RID: 1669
	// (get) Token: 0x06005AEF RID: 23279
	Func<float, EGameSettingsApplyReason, bool> ApplyCallbackFloat { get; }

	// Token: 0x17000686 RID: 1670
	// (get) Token: 0x06005AF0 RID: 23280
	Action<int, EGameSettingsApplyReason> HandleDoneCallback { get; }

	// Token: 0x17000687 RID: 1671
	// (get) Token: 0x06005AF1 RID: 23281
	[Nullable(1)]
	Func<string> DumpCallback { [NullableContext(1)] get; }
}
