using System;
using System.Reflection;
using System.Runtime.CompilerServices;

// Token: 0x0200323A RID: 12858
[NullableContext(1)]
[Nullable(0)]
public class BaseOptimizationStrategy
{
	// Token: 0x0601AC42 RID: 109634 RVA: 0x007FA684 File Offset: 0x007F8884
	public BaseOptimizationStrategy()
	{
		this.NeedEnableInternal = (base.GetType().GetMethod("OnEnable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).DeclaringType != typeof(BaseOptimizationStrategy));
		this.NeedTriggerMyPlayerInOut = (base.GetType().GetMethod("OnMyPlayerInOutRangeLocal", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).DeclaringType != typeof(BaseOptimizationStrategy));
		this.NeedTriggerEntityInOut = (base.GetType().GetMethod("OnEntityInOutRangeLocal", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).DeclaringType != typeof(BaseOptimizationStrategy));
		this.NeedDisableInternal = (base.GetType().GetMethod("OnDisable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).DeclaringType != typeof(BaseOptimizationStrategy));
	}

	// Token: 0x1700245C RID: 9308
	// (get) Token: 0x0601AC43 RID: 109635 RVA: 0x007FA747 File Offset: 0x007F8947
	public bool NeedEnable
	{
		get
		{
			return this.NeedEnableInternal;
		}
	}

	// Token: 0x1700245D RID: 9309
	// (get) Token: 0x0601AC44 RID: 109636 RVA: 0x007FA74F File Offset: 0x007F894F
	public bool NeedTriggerMyPlayerInOutRange
	{
		get
		{
			return this.NeedTriggerMyPlayerInOut;
		}
	}

	// Token: 0x1700245E RID: 9310
	// (get) Token: 0x0601AC45 RID: 109637 RVA: 0x007FA757 File Offset: 0x007F8957
	public bool NeedTriggerEntityInOutRange
	{
		get
		{
			return this.NeedTriggerEntityInOut;
		}
	}

	// Token: 0x1700245F RID: 9311
	// (get) Token: 0x0601AC46 RID: 109638 RVA: 0x007FA75F File Offset: 0x007F895F
	public bool NeedDisable
	{
		get
		{
			return this.NeedDisableInternal;
		}
	}

	// Token: 0x0601AC47 RID: 109639 RVA: 0x007FA767 File Offset: 0x007F8967
	public void Enable()
	{
		if (!this.NeedEnableInternal)
		{
			return;
		}
		this.OnEnable();
	}

	// Token: 0x0601AC48 RID: 109640 RVA: 0x007FA778 File Offset: 0x007F8978
	public void MyPlayerEntityInOutRange(bool isEnter)
	{
		if (!this.NeedTriggerMyPlayerInOut)
		{
			return;
		}
		this.OnMyPlayerInOutRangeLocal(isEnter);
	}

	// Token: 0x0601AC49 RID: 109641 RVA: 0x007FA78A File Offset: 0x007F898A
	public void EntityInOutRange(bool isEnter, EntityHandle handle)
	{
		if (!this.NeedTriggerEntityInOut)
		{
			return;
		}
		this.OnEntityInOutRangeLocal(isEnter, handle);
	}

	// Token: 0x0601AC4A RID: 109642 RVA: 0x007FA79D File Offset: 0x007F899D
	public void Disable()
	{
		if (!this.NeedDisableInternal)
		{
			return;
		}
		this.OnDisable();
	}

	// Token: 0x0601AC4B RID: 109643 RVA: 0x007FA7AE File Offset: 0x007F89AE
	protected virtual void OnEnable()
	{
	}

	// Token: 0x0601AC4C RID: 109644 RVA: 0x007FA7B0 File Offset: 0x007F89B0
	protected virtual void OnMyPlayerInOutRangeLocal(bool isEnter)
	{
	}

	// Token: 0x0601AC4D RID: 109645 RVA: 0x007FA7B2 File Offset: 0x007F89B2
	protected virtual void OnEntityInOutRangeLocal(bool isEnter, EntityHandle handle)
	{
	}

	// Token: 0x0601AC4E RID: 109646 RVA: 0x007FA7B4 File Offset: 0x007F89B4
	protected virtual void OnDisable()
	{
	}

	// Token: 0x0400D926 RID: 55590
	private readonly bool NeedEnableInternal;

	// Token: 0x0400D927 RID: 55591
	private readonly bool NeedTriggerMyPlayerInOut;

	// Token: 0x0400D928 RID: 55592
	private readonly bool NeedTriggerEntityInOut;

	// Token: 0x0400D929 RID: 55593
	private readonly bool NeedDisableInternal;

	// Token: 0x0400D92A RID: 55594
	private const BindingFlags MethodBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
}
