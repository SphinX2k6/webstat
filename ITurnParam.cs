using System;
using System.Runtime.CompilerServices;

// Token: 0x0200301B RID: 12315
[NullableContext(2)]
public interface ITurnParam : IActionParamMap
{
	// Token: 0x170021D8 RID: 8664
	// (get) Token: 0x060191FC RID: 102908
	// (set) Token: 0x060191FD RID: 102909
	Vector TargetLocation { get; set; }

	// Token: 0x170021D9 RID: 8665
	// (get) Token: 0x060191FE RID: 102910
	// (set) Token: 0x060191FF RID: 102911
	Vector Direction { get; set; }

	// Token: 0x170021DA RID: 8666
	// (get) Token: 0x06019200 RID: 102912
	// (set) Token: 0x06019201 RID: 102913
	float? TurnSpeed { get; set; }

	// Token: 0x170021DB RID: 8667
	// (get) Token: 0x06019202 RID: 102914
	// (set) Token: 0x06019203 RID: 102915
	bool? ContainZ { get; set; }

	// Token: 0x170021DC RID: 8668
	// (get) Token: 0x06019204 RID: 102916
	// (set) Token: 0x06019205 RID: 102917
	float? MinTurnTimeSeconds { get; set; }
}
