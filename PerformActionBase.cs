using System;
using System.Runtime.CompilerServices;

// Token: 0x020030EE RID: 12526
[NullableContext(2)]
[Nullable(0)]
public class PerformActionBase : IPerformActionBase
{
	// Token: 0x06019E92 RID: 106130 RVA: 0x0079430C File Offset: 0x0079250C
	public PerformActionBase(EPerformAction name)
	{
		this.Name = name;
	}

	// Token: 0x17002317 RID: 8983
	// (get) Token: 0x06019E93 RID: 106131 RVA: 0x0079431B File Offset: 0x0079251B
	// (set) Token: 0x06019E94 RID: 106132 RVA: 0x00794323 File Offset: 0x00792523
	public EPerformAction Name { get; private set; }

	// Token: 0x17002318 RID: 8984
	// (get) Token: 0x06019E95 RID: 106133 RVA: 0x0079432C File Offset: 0x0079252C
	// (set) Token: 0x06019E96 RID: 106134 RVA: 0x00794334 File Offset: 0x00792534
	public int Id { get; set; }

	// Token: 0x17002319 RID: 8985
	// (get) Token: 0x06019E97 RID: 106135 RVA: 0x0079433D File Offset: 0x0079253D
	// (set) Token: 0x06019E98 RID: 106136 RVA: 0x00794345 File Offset: 0x00792545
	public EPerformMode Mode { get; set; }

	// Token: 0x1700231A RID: 8986
	// (get) Token: 0x06019E99 RID: 106137 RVA: 0x0079434E File Offset: 0x0079254E
	// (set) Token: 0x06019E9A RID: 106138 RVA: 0x00794356 File Offset: 0x00792556
	public EPerformGroup Group { get; set; }

	// Token: 0x1700231B RID: 8987
	// (get) Token: 0x06019E9B RID: 106139 RVA: 0x0079435F File Offset: 0x0079255F
	// (set) Token: 0x06019E9C RID: 106140 RVA: 0x00794367 File Offset: 0x00792567
	public bool Executed { get; set; }

	// Token: 0x1700231C RID: 8988
	// (get) Token: 0x06019E9D RID: 106141 RVA: 0x00794370 File Offset: 0x00792570
	public virtual bool IsAtomic { get; }

	// Token: 0x1700231D RID: 8989
	// (get) Token: 0x06019E9E RID: 106142 RVA: 0x00794378 File Offset: 0x00792578
	// (set) Token: 0x06019E9F RID: 106143 RVA: 0x00794380 File Offset: 0x00792580
	public bool IsValid { get; set; }

	// Token: 0x1700231E RID: 8990
	// (get) Token: 0x06019EA0 RID: 106144 RVA: 0x00794389 File Offset: 0x00792589
	// (set) Token: 0x06019EA1 RID: 106145 RVA: 0x00794391 File Offset: 0x00792591
	public bool IsPersistent { get; set; }

	// Token: 0x06019EA2 RID: 106146 RVA: 0x0079439C File Offset: 0x0079259C
	public void Execute()
	{
		if (this.IsValid)
		{
			if (this.Executed)
			{
				this.OnRestore();
				return;
			}
			this.Executed = true;
			Action<int> onBeforeExecute = this.OnBeforeExecute;
			if (onBeforeExecute != null)
			{
				onBeforeExecute(this.Id);
			}
			this.OnExecute();
			return;
		}
		else
		{
			Action onFinish = this.OnFinish;
			if (onFinish == null)
			{
				return;
			}
			onFinish();
			return;
		}
	}

	// Token: 0x06019EA3 RID: 106147 RVA: 0x007943F5 File Offset: 0x007925F5
	protected void FinishExecute()
	{
		Action<int> onAfterExecute = this.OnAfterExecute;
		if (onAfterExecute != null)
		{
			onAfterExecute(this.Id);
		}
		Action onFinish = this.OnFinish;
		if (onFinish == null)
		{
			return;
		}
		onFinish();
	}

	// Token: 0x06019EA4 RID: 106148 RVA: 0x0079441E File Offset: 0x0079261E
	public void Interrupt()
	{
		this.OnInterrupt();
	}

	// Token: 0x06019EA5 RID: 106149 RVA: 0x00794428 File Offset: 0x00792628
	public void Reset()
	{
		this.IsValid = false;
		this.Id = 0;
		this.Executed = false;
		this.Param = null;
		this.PerformComp = null;
		this.Mode = EPerformMode.Undetermined;
		this.Group = EPerformGroup.DefaultGroup;
		this.IsPersistent = false;
		this.OnFinish = null;
		this.OnBeforeExecute = null;
		this.OnReset();
	}

	// Token: 0x06019EA6 RID: 106150 RVA: 0x00794481 File Offset: 0x00792681
	protected virtual void OnExecute()
	{
	}

	// Token: 0x06019EA7 RID: 106151 RVA: 0x00794483 File Offset: 0x00792683
	protected virtual void OnInterrupt()
	{
	}

	// Token: 0x06019EA8 RID: 106152 RVA: 0x00794485 File Offset: 0x00792685
	protected virtual void OnRestore()
	{
		this.OnExecute();
	}

	// Token: 0x06019EA9 RID: 106153 RVA: 0x0079448D File Offset: 0x0079268D
	protected virtual void OnReset()
	{
	}

	// Token: 0x0400CFBA RID: 53178
	public IActionParamMap Param;

	// Token: 0x0400CFBB RID: 53179
	public BasePerformComponent PerformComp;

	// Token: 0x0400CFBC RID: 53180
	public Action OnFinish;

	// Token: 0x0400CFBD RID: 53181
	public Action<int> OnBeforeExecute;

	// Token: 0x0400CFBE RID: 53182
	public Action<int> OnAfterExecute;
}
