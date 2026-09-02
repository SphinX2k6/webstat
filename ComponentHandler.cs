using System;
using System.Runtime.CompilerServices;

// Token: 0x0200186B RID: 6251
public class ComponentHandler : IHandler
{
	// Token: 0x17000E8E RID: 3726
	// (get) Token: 0x0600B313 RID: 45843 RVA: 0x002FCB30 File Offset: 0x002FAD30
	public EHandlerType Type
	{
		get
		{
			return EHandlerType.Component;
		}
	}

	// Token: 0x17000E8F RID: 3727
	// (get) Token: 0x0600B314 RID: 45844 RVA: 0x002FCB33 File Offset: 0x002FAD33
	// (set) Token: 0x0600B315 RID: 45845 RVA: 0x002FCB3B File Offset: 0x002FAD3B
	public bool? IsSync { get; set; }

	// Token: 0x17000E90 RID: 3728
	// (get) Token: 0x0600B316 RID: 45846 RVA: 0x002FCB44 File Offset: 0x002FAD44
	// (set) Token: 0x0600B317 RID: 45847 RVA: 0x002FCB4C File Offset: 0x002FAD4C
	public bool? IsCache { get; set; }

	// Token: 0x040054C2 RID: 21698
	[Nullable(2)]
	public Type Component;
}
