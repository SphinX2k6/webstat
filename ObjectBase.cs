using System;

// Token: 0x02000BCC RID: 3020
public abstract class ObjectBase
{
	// Token: 0x060031A4 RID: 12708 RVA: 0x0001E418 File Offset: 0x0001C618
	protected ObjectBase(int Id, int Index)
	{
	}

	// Token: 0x170000BE RID: 190
	// (get) Token: 0x060031A5 RID: 12709 RVA: 0x0001E42E File Offset: 0x0001C62E
	public bool Valid
	{
		get
		{
			return Singleton<ObjectSystem>.Instance.IsValid(this);
		}
	}

	// Token: 0x04000491 RID: 1169
	public int Id = Id;

	// Token: 0x04000492 RID: 1170
	public int Index = Index;
}
