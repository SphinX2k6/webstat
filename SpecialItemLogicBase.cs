using System;

// Token: 0x0200207F RID: 8319
public class SpecialItemLogicBase
{
	// Token: 0x0600FD7C RID: 64892 RVA: 0x00458867 File Offset: 0x00456A67
	public SpecialItemLogicBase(int configId)
	{
		this.ConfigId = configId;
	}

	// Token: 0x0600FD7D RID: 64893 RVA: 0x00458876 File Offset: 0x00456A76
	public virtual void Init()
	{
	}

	// Token: 0x0600FD7E RID: 64894 RVA: 0x00458878 File Offset: 0x00456A78
	public virtual void Destroy()
	{
	}

	// Token: 0x0600FD7F RID: 64895 RVA: 0x0045887A File Offset: 0x00456A7A
	public virtual bool CheckUseCondition()
	{
		return true;
	}

	// Token: 0x0600FD80 RID: 64896 RVA: 0x0045887D File Offset: 0x00456A7D
	public virtual void OnUse()
	{
	}

	// Token: 0x040079A1 RID: 31137
	protected int ConfigId;
}
