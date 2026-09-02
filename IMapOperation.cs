using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x0200223E RID: 8766
[NullableContext(1)]
public interface IMapOperation
{
	// Token: 0x17001461 RID: 5217
	// (get) Token: 0x060108C5 RID: 67781
	// (set) Token: 0x060108C6 RID: 67782
	[Nullable(2)]
	string OpName { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17001462 RID: 5218
	// (get) Token: 0x060108C7 RID: 67783
	EMapOperationType Type { get; }

	// Token: 0x17001463 RID: 5219
	// (get) Token: 0x060108C8 RID: 67784
	Func<bool> IsValidate { get; }

	// Token: 0x17001464 RID: 5220
	// (get) Token: 0x060108C9 RID: 67785
	Func<UniTask> Execute { get; }
}
