using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BB1 RID: 2993
[NullableContext(1)]
public interface IControllerBase
{
	// Token: 0x06003095 RID: 12437
	bool Init();

	// Token: 0x06003096 RID: 12438
	bool Clear();

	// Token: 0x06003097 RID: 12439
	void Tick(float delta);

	// Token: 0x06003098 RID: 12440
	bool CheckTick(bool isInFight, float delta);

	// Token: 0x06003099 RID: 12441
	void SetPerformanceStateObject(string name, string desc = "", string group = "");

	// Token: 0x17000095 RID: 149
	// (get) Token: 0x0600309A RID: 12442
	bool IsTickEvenPaused { get; }

	// Token: 0x0600309B RID: 12443
	Stat GetPerformanceStateObject();

	// Token: 0x0600309C RID: 12444
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	ValueTuple<string, CustomPromise<bool>>? Preload();

	// Token: 0x0600309D RID: 12445
	bool LeaveLevel();

	// Token: 0x0600309E RID: 12446
	bool ChangeMode();
}
