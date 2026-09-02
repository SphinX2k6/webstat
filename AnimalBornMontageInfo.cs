using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02002E1A RID: 11802
[NullableContext(1)]
[Nullable(0)]
public class AnimalBornMontageInfo
{
	// Token: 0x06017E08 RID: 97800 RVA: 0x006B020C File Offset: 0x006AE40C
	public void Init(AnimalStandbyMontage config)
	{
		this.StartPath = (this.IsPathValid(config.MontageStart) ? config.MontageStart : "");
		this.LoopPath = (this.IsPathValid(config.MontageLoop) ? config.MontageLoop : "");
		this.EndPath = (this.IsPathValid(config.MontageEnd) ? config.MontageEnd : "");
		if (this.IsPathValid(config.MontageBranch1))
		{
			this.BranchPathList.Add(config.MontageBranch1);
		}
		if (this.IsPathValid(config.MontageBranch2))
		{
			this.BranchPathList.Add(config.MontageBranch2);
		}
		if (this.IsPathValid(config.MontageBranch3))
		{
			this.BranchPathList.Add(config.MontageBranch3);
		}
		if (this.IsPathValid(config.MontageBranch4))
		{
			this.BranchPathList.Add(config.MontageBranch4);
		}
	}

	// Token: 0x06017E09 RID: 97801 RVA: 0x006B0306 File Offset: 0x006AE506
	[NullableContext(2)]
	protected bool IsPathValid(string path)
	{
		return path != null && path != "" && path != "None";
	}

	// Token: 0x06017E0A RID: 97802 RVA: 0x006B0325 File Offset: 0x006AE525
	public bool IsAssetReady()
	{
		return this.StartReady && this.LoopReady && this.BranchReady && this.EndReady;
	}

	// Token: 0x06017E0B RID: 97803 RVA: 0x006B0348 File Offset: 0x006AE548
	public bool IsConfigValid()
	{
		bool flag = this.StartPath != "" && this.StartPath != "None";
		bool flag2 = this.LoopPath != "" && this.LoopPath != "None";
		return flag || flag2;
	}

	// Token: 0x06017E0C RID: 97804 RVA: 0x006B03A2 File Offset: 0x006AE5A2
	[NullableContext(2)]
	public UAnimMontage GetStartMontage()
	{
		UAnimMontage start = this.Start;
		if (start == null || !start.IsValid())
		{
			return this.Loop;
		}
		return this.Start;
	}

	// Token: 0x0400B945 RID: 47429
	[Nullable(2)]
	public UAnimMontage Start;

	// Token: 0x0400B946 RID: 47430
	[Nullable(2)]
	public UAnimMontage Loop;

	// Token: 0x0400B947 RID: 47431
	[Nullable(2)]
	public UAnimMontage Branch;

	// Token: 0x0400B948 RID: 47432
	[Nullable(2)]
	public UAnimMontage End;

	// Token: 0x0400B949 RID: 47433
	public List<UAnimMontage> BranchList = new List<UAnimMontage>();

	// Token: 0x0400B94A RID: 47434
	public string StartPath = "";

	// Token: 0x0400B94B RID: 47435
	public string LoopPath = "";

	// Token: 0x0400B94C RID: 47436
	public string EndPath = "";

	// Token: 0x0400B94D RID: 47437
	public string BranchPath = "";

	// Token: 0x0400B94E RID: 47438
	public int BranchLoadedCount;

	// Token: 0x0400B94F RID: 47439
	public List<string> BranchPathList = new List<string>();

	// Token: 0x0400B950 RID: 47440
	public bool StartReady;

	// Token: 0x0400B951 RID: 47441
	public bool LoopReady;

	// Token: 0x0400B952 RID: 47442
	public bool BranchReady;

	// Token: 0x0400B953 RID: 47443
	public bool EndReady;
}
