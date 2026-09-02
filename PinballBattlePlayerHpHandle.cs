using System;
using System.Runtime.CompilerServices;

// Token: 0x02000F68 RID: 3944
public class PinballBattlePlayerHpHandle
{
	// Token: 0x060063AA RID: 25514 RVA: 0x0018FC32 File Offset: 0x0018DE32
	public void Init()
	{
		this.IsInit = true;
	}

	// Token: 0x060063AB RID: 25515 RVA: 0x0018FC3B File Offset: 0x0018DE3B
	[NullableContext(1)]
	public void OnPlayerHpChange(KscHeadStateData kscPlayerHeadStateData)
	{
		bool isInit = this.IsInit;
	}

	// Token: 0x060063AC RID: 25516 RVA: 0x0018FC44 File Offset: 0x0018DE44
	public void Clear()
	{
		this.IsInit = false;
	}

	// Token: 0x04002FAE RID: 12206
	private bool IsInit;
}
