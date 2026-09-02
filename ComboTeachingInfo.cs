using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001877 RID: 6263
[NullableContext(1)]
[Nullable(0)]
public class ComboTeachingInfo : IComboTeachingInfo
{
	// Token: 0x17000EB2 RID: 3762
	// (get) Token: 0x0600B38B RID: 45963 RVA: 0x002FE82B File Offset: 0x002FCA2B
	// (set) Token: 0x0600B38C RID: 45964 RVA: 0x002FE833 File Offset: 0x002FCA33
	public int Index { get; set; }

	// Token: 0x17000EB3 RID: 3763
	// (get) Token: 0x0600B38D RID: 45965 RVA: 0x002FE83C File Offset: 0x002FCA3C
	// (set) Token: 0x0600B38E RID: 45966 RVA: 0x002FE844 File Offset: 0x002FCA44
	public ComboTeaching Config { get; set; }

	// Token: 0x17000EB4 RID: 3764
	// (get) Token: 0x0600B38F RID: 45967 RVA: 0x002FE84D File Offset: 0x002FCA4D
	// (set) Token: 0x0600B390 RID: 45968 RVA: 0x002FE855 File Offset: 0x002FCA55
	public float HoldTotalTime { get; set; }

	// Token: 0x17000EB5 RID: 3765
	// (get) Token: 0x0600B391 RID: 45969 RVA: 0x002FE85E File Offset: 0x002FCA5E
	// (set) Token: 0x0600B392 RID: 45970 RVA: 0x002FE866 File Offset: 0x002FCA66
	public float SuccessDelay { get; set; }

	// Token: 0x17000EB6 RID: 3766
	// (get) Token: 0x0600B393 RID: 45971 RVA: 0x002FE86F File Offset: 0x002FCA6F
	// (set) Token: 0x0600B394 RID: 45972 RVA: 0x002FE877 File Offset: 0x002FCA77
	[Nullable(2)]
	public TimerHandle SuccessHandle { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17000EB7 RID: 3767
	// (get) Token: 0x0600B395 RID: 45973 RVA: 0x002FE880 File Offset: 0x002FCA80
	// (set) Token: 0x0600B396 RID: 45974 RVA: 0x002FE888 File Offset: 0x002FCA88
	public BaseCheckCondition SuccessCondition { get; set; }

	// Token: 0x17000EB8 RID: 3768
	// (get) Token: 0x0600B397 RID: 45975 RVA: 0x002FE891 File Offset: 0x002FCA91
	// (set) Token: 0x0600B398 RID: 45976 RVA: 0x002FE899 File Offset: 0x002FCA99
	public List<BaseCheckCondition> FailUpdateCondition { get; set; } = new List<BaseCheckCondition>();

	// Token: 0x17000EB9 RID: 3769
	// (get) Token: 0x0600B399 RID: 45977 RVA: 0x002FE8A2 File Offset: 0x002FCAA2
	// (set) Token: 0x0600B39A RID: 45978 RVA: 0x002FE8AA File Offset: 0x002FCAAA
	public float FailDelay { get; set; }

	// Token: 0x17000EBA RID: 3770
	// (get) Token: 0x0600B39B RID: 45979 RVA: 0x002FE8B3 File Offset: 0x002FCAB3
	// (set) Token: 0x0600B39C RID: 45980 RVA: 0x002FE8BB File Offset: 0x002FCABB
	[Nullable(2)]
	public TimerHandle FailHandle { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17000EBB RID: 3771
	// (get) Token: 0x0600B39D RID: 45981 RVA: 0x002FE8C4 File Offset: 0x002FCAC4
	// (set) Token: 0x0600B39E RID: 45982 RVA: 0x002FE8CC File Offset: 0x002FCACC
	public List<BaseCheckCondition> FailEventCondition { get; set; } = new List<BaseCheckCondition>();

	// Token: 0x17000EBC RID: 3772
	// (get) Token: 0x0600B39F RID: 45983 RVA: 0x002FE8D5 File Offset: 0x002FCAD5
	// (set) Token: 0x0600B3A0 RID: 45984 RVA: 0x002FE8DD File Offset: 0x002FCADD
	public bool IsEmit { get; set; }

	// Token: 0x17000EBD RID: 3773
	// (get) Token: 0x0600B3A1 RID: 45985 RVA: 0x002FE8E6 File Offset: 0x002FCAE6
	// (set) Token: 0x0600B3A2 RID: 45986 RVA: 0x002FE8EE File Offset: 0x002FCAEE
	public bool IsHoldAction { get; set; }

	// Token: 0x17000EBE RID: 3774
	// (get) Token: 0x0600B3A3 RID: 45987 RVA: 0x002FE8F7 File Offset: 0x002FCAF7
	// (set) Token: 0x0600B3A4 RID: 45988 RVA: 0x002FE8FF File Offset: 0x002FCAFF
	public bool IsShowTag { get; set; }

	// Token: 0x17000EBF RID: 3775
	// (get) Token: 0x0600B3A5 RID: 45989 RVA: 0x002FE908 File Offset: 0x002FCB08
	// (set) Token: 0x0600B3A6 RID: 45990 RVA: 0x002FE910 File Offset: 0x002FCB10
	public string ActionInfo { get; set; } = "";

	// Token: 0x17000EC0 RID: 3776
	// (get) Token: 0x0600B3A7 RID: 45991 RVA: 0x002FE919 File Offset: 0x002FCB19
	// (set) Token: 0x0600B3A8 RID: 45992 RVA: 0x002FE921 File Offset: 0x002FCB21
	public bool NeedTickSummon { get; set; }
}
