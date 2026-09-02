using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x020026D1 RID: 9937
[NullableContext(1)]
public interface IDangoDungeonCommand
{
	// Token: 0x170018C2 RID: 6338
	// (get) Token: 0x060139CF RID: 80335
	// (set) Token: 0x060139D0 RID: 80336
	int CommandIndex { get; set; }

	// Token: 0x170018C3 RID: 6339
	// (get) Token: 0x060139D1 RID: 80337
	ERacingBetsCommandType CommandType { get; }

	// Token: 0x170018C4 RID: 6340
	// (get) Token: 0x060139D2 RID: 80338
	// (set) Token: 0x060139D3 RID: 80339
	int ActionIndex { get; set; }

	// Token: 0x170018C5 RID: 6341
	// (get) Token: 0x060139D4 RID: 80340
	// (set) Token: 0x060139D5 RID: 80341
	bool IsAborted { get; set; }

	// Token: 0x060139D6 RID: 80342
	UniTask Execute();

	// Token: 0x060139D7 RID: 80343
	string LogInfo();
}
