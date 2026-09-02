using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001388 RID: 5000
[NullableContext(1)]
[Nullable(0)]
public class SoarChallengePlayData
{
	// Token: 0x17000BA9 RID: 2985
	// (get) Token: 0x06008964 RID: 35172 RVA: 0x00242E4C File Offset: 0x0024104C
	// (set) Token: 0x06008965 RID: 35173 RVA: 0x00242E54 File Offset: 0x00241054
	public int TabIndex { get; set; }

	// Token: 0x17000BAA RID: 2986
	// (get) Token: 0x06008966 RID: 35174 RVA: 0x00242E5D File Offset: 0x0024105D
	// (set) Token: 0x06008967 RID: 35175 RVA: 0x00242E65 File Offset: 0x00241065
	public int PlayId { get; set; }

	// Token: 0x17000BAB RID: 2987
	// (get) Token: 0x06008968 RID: 35176 RVA: 0x00242E6E File Offset: 0x0024106E
	// (set) Token: 0x06008969 RID: 35177 RVA: 0x00242E76 File Offset: 0x00241076
	public int JumpId { get; set; }

	// Token: 0x17000BAC RID: 2988
	// (get) Token: 0x0600896A RID: 35178 RVA: 0x00242E7F File Offset: 0x0024107F
	// (set) Token: 0x0600896B RID: 35179 RVA: 0x00242E87 File Offset: 0x00241087
	public string NameTextId { get; set; } = "";

	// Token: 0x17000BAD RID: 2989
	// (get) Token: 0x0600896C RID: 35180 RVA: 0x00242E90 File Offset: 0x00241090
	public List<int> RewardIds { get; } = new List<int>();

	// Token: 0x17000BAE RID: 2990
	// (get) Token: 0x0600896D RID: 35181 RVA: 0x00242E98 File Offset: 0x00241098
	// (set) Token: 0x0600896E RID: 35182 RVA: 0x00242EA0 File Offset: 0x002410A0
	public bool IsUnlock { get; set; }

	// Token: 0x17000BAF RID: 2991
	// (get) Token: 0x0600896F RID: 35183 RVA: 0x00242EA9 File Offset: 0x002410A9
	// (set) Token: 0x06008970 RID: 35184 RVA: 0x00242EB1 File Offset: 0x002410B1
	public bool IsNew { get; set; }

	// Token: 0x17000BB0 RID: 2992
	// (get) Token: 0x06008971 RID: 35185 RVA: 0x00242EBA File Offset: 0x002410BA
	// (set) Token: 0x06008972 RID: 35186 RVA: 0x00242EC2 File Offset: 0x002410C2
	public int HighestPoint { get; set; }

	// Token: 0x17000BB1 RID: 2993
	// (get) Token: 0x06008973 RID: 35187 RVA: 0x00242ECB File Offset: 0x002410CB
	// (set) Token: 0x06008974 RID: 35188 RVA: 0x00242ED3 File Offset: 0x002410D3
	public Func<List<int>, bool> CheckRedDot { get; set; }

	// Token: 0x17000BB2 RID: 2994
	// (get) Token: 0x06008975 RID: 35189 RVA: 0x00242EDC File Offset: 0x002410DC
	// (set) Token: 0x06008976 RID: 35190 RVA: 0x00242EE4 File Offset: 0x002410E4
	public Func<List<int>, bool> CheckFinished { get; set; }

	// Token: 0x17000BB3 RID: 2995
	// (get) Token: 0x06008977 RID: 35191 RVA: 0x00242EED File Offset: 0x002410ED
	public bool HasRedDot
	{
		get
		{
			return this.CheckRedDot(this.RewardIds);
		}
	}

	// Token: 0x17000BB4 RID: 2996
	// (get) Token: 0x06008978 RID: 35192 RVA: 0x00242F00 File Offset: 0x00241100
	public bool IsFinished
	{
		get
		{
			return this.CheckFinished(this.RewardIds);
		}
	}
}
