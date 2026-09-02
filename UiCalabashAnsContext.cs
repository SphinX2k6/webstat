using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002C78 RID: 11384
public class UiCalabashAnsContext : UiAnsContextBase
{
	// Token: 0x17001DF2 RID: 7666
	// (get) Token: 0x06016D67 RID: 93543 RVA: 0x00656425 File Offset: 0x00654625
	public FName Socket { get; }

	// Token: 0x17001DF3 RID: 7667
	// (get) Token: 0x06016D68 RID: 93544 RVA: 0x0065642D File Offset: 0x0065462D
	public bool IsRotate { get; }

	// Token: 0x06016D69 RID: 93545 RVA: 0x00656435 File Offset: 0x00654635
	public UiCalabashAnsContext(FName socket, bool isRotate)
	{
		this.Socket = socket;
		this.IsRotate = isRotate;
	}

	// Token: 0x06016D6A RID: 93546 RVA: 0x0065644C File Offset: 0x0065464C
	[NullableContext(1)]
	public override bool IsEqual(UiAnsContextBase inAnsContext)
	{
		UiCalabashAnsContext uiCalabashAnsContext = inAnsContext as UiCalabashAnsContext;
		return uiCalabashAnsContext != null && this.Socket == uiCalabashAnsContext.Socket;
	}
}
