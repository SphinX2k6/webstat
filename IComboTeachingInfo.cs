using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001870 RID: 6256
[NullableContext(1)]
public interface IComboTeachingInfo
{
	// Token: 0x17000E96 RID: 3734
	// (get) Token: 0x0600B33E RID: 45886
	// (set) Token: 0x0600B33F RID: 45887
	int Index { get; set; }

	// Token: 0x17000E97 RID: 3735
	// (get) Token: 0x0600B340 RID: 45888
	// (set) Token: 0x0600B341 RID: 45889
	ComboTeaching Config { get; set; }

	// Token: 0x17000E98 RID: 3736
	// (get) Token: 0x0600B342 RID: 45890
	// (set) Token: 0x0600B343 RID: 45891
	float HoldTotalTime { get; set; }

	// Token: 0x17000E99 RID: 3737
	// (get) Token: 0x0600B344 RID: 45892
	// (set) Token: 0x0600B345 RID: 45893
	float SuccessDelay { get; set; }

	// Token: 0x17000E9A RID: 3738
	// (get) Token: 0x0600B346 RID: 45894
	// (set) Token: 0x0600B347 RID: 45895
	[Nullable(2)]
	TimerHandle SuccessHandle { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17000E9B RID: 3739
	// (get) Token: 0x0600B348 RID: 45896
	// (set) Token: 0x0600B349 RID: 45897
	BaseCheckCondition SuccessCondition { get; set; }

	// Token: 0x17000E9C RID: 3740
	// (get) Token: 0x0600B34A RID: 45898
	// (set) Token: 0x0600B34B RID: 45899
	List<BaseCheckCondition> FailUpdateCondition { get; set; }

	// Token: 0x17000E9D RID: 3741
	// (get) Token: 0x0600B34C RID: 45900
	// (set) Token: 0x0600B34D RID: 45901
	float FailDelay { get; set; }

	// Token: 0x17000E9E RID: 3742
	// (get) Token: 0x0600B34E RID: 45902
	// (set) Token: 0x0600B34F RID: 45903
	[Nullable(2)]
	TimerHandle FailHandle { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17000E9F RID: 3743
	// (get) Token: 0x0600B350 RID: 45904
	// (set) Token: 0x0600B351 RID: 45905
	List<BaseCheckCondition> FailEventCondition { get; set; }

	// Token: 0x17000EA0 RID: 3744
	// (get) Token: 0x0600B352 RID: 45906
	// (set) Token: 0x0600B353 RID: 45907
	bool IsEmit { get; set; }

	// Token: 0x17000EA1 RID: 3745
	// (get) Token: 0x0600B354 RID: 45908
	// (set) Token: 0x0600B355 RID: 45909
	bool IsHoldAction { get; set; }

	// Token: 0x17000EA2 RID: 3746
	// (get) Token: 0x0600B356 RID: 45910
	// (set) Token: 0x0600B357 RID: 45911
	bool IsShowTag { get; set; }

	// Token: 0x17000EA3 RID: 3747
	// (get) Token: 0x0600B358 RID: 45912
	// (set) Token: 0x0600B359 RID: 45913
	string ActionInfo { get; set; }

	// Token: 0x17000EA4 RID: 3748
	// (get) Token: 0x0600B35A RID: 45914
	// (set) Token: 0x0600B35B RID: 45915
	bool NeedTickSummon { get; set; }
}
