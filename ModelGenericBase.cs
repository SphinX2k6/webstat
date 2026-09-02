using System;

// Token: 0x02000BB6 RID: 2998
public abstract class ModelGenericBase : IModelBase
{
	// Token: 0x060030C8 RID: 12488 RVA: 0x0001AEC5 File Offset: 0x000190C5
	public bool Init()
	{
		return this.OnInit();
	}

	// Token: 0x060030C9 RID: 12489 RVA: 0x0001AECD File Offset: 0x000190CD
	public bool Clear()
	{
		return this.OnClear();
	}

	// Token: 0x060030CA RID: 12490 RVA: 0x0001AED5 File Offset: 0x000190D5
	public bool LeaveLevel()
	{
		return this.OnLeaveLevel();
	}

	// Token: 0x060030CB RID: 12491 RVA: 0x0001AEDD File Offset: 0x000190DD
	public bool ChangeMode()
	{
		return this.OnChangeMode();
	}

	// Token: 0x060030CC RID: 12492 RVA: 0x0001AEE5 File Offset: 0x000190E5
	protected virtual bool OnInit()
	{
		return true;
	}

	// Token: 0x060030CD RID: 12493 RVA: 0x0001AEE8 File Offset: 0x000190E8
	protected virtual bool OnClear()
	{
		return true;
	}

	// Token: 0x060030CE RID: 12494 RVA: 0x0001AEEB File Offset: 0x000190EB
	protected virtual bool OnLeaveLevel()
	{
		return true;
	}

	// Token: 0x060030CF RID: 12495 RVA: 0x0001AEEE File Offset: 0x000190EE
	protected virtual bool OnChangeMode()
	{
		return true;
	}
}
