using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003113 RID: 12563
[NullableContext(2)]
public interface ISkillParam
{
	// Token: 0x17002330 RID: 9008
	// (get) Token: 0x06019F91 RID: 106385
	// (set) Token: 0x06019F92 RID: 106386
	Entity Target { get; set; }

	// Token: 0x17002331 RID: 9009
	// (get) Token: 0x06019F93 RID: 106387
	// (set) Token: 0x06019F94 RID: 106388
	AActor TargetActor { get; set; }

	// Token: 0x17002332 RID: 9010
	// (get) Token: 0x06019F95 RID: 106389
	// (set) Token: 0x06019F96 RID: 106390
	string SocketName { get; set; }

	// Token: 0x17002333 RID: 9011
	// (get) Token: 0x06019F97 RID: 106391
	// (set) Token: 0x06019F98 RID: 106392
	long? ContextId { get; set; }

	// Token: 0x17002334 RID: 9012
	// (get) Token: 0x06019F99 RID: 106393
	// (set) Token: 0x06019F9A RID: 106394
	string Reason { get; set; }

	// Token: 0x17002335 RID: 9013
	// (get) Token: 0x06019F9B RID: 106395
	// (set) Token: 0x06019F9C RID: 106396
	int? MontageIndex { get; set; }

	// Token: 0x17002336 RID: 9014
	// (get) Token: 0x06019F9D RID: 106397
	// (set) Token: 0x06019F9E RID: 106398
	bool? CheckMultiSkill { get; set; }

	// Token: 0x17002337 RID: 9015
	// (get) Token: 0x06019F9F RID: 106399
	// (set) Token: 0x06019FA0 RID: 106400
	int? NextSkillId { get; set; }

	// Token: 0x17002338 RID: 9016
	// (get) Token: 0x06019FA1 RID: 106401
	// (set) Token: 0x06019FA2 RID: 106402
	bool? IsAsync { get; set; }

	// Token: 0x17002339 RID: 9017
	// (get) Token: 0x06019FA3 RID: 106403
	// (set) Token: 0x06019FA4 RID: 106404
	FVectorDouble? ExtraTargetLocation { get; set; }
}
