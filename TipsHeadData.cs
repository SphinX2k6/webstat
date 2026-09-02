using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;

// Token: 0x0200198C RID: 6540
public class TipsHeadData : ItemTipsData
{
	// Token: 0x0600BBEF RID: 48111 RVA: 0x0031EB59 File Offset: 0x0031CD59
	[NullableContext(1)]
	public TipsHeadData(ItemTipsParam data) : base(data)
	{
		this.ItemType = EItemTipsType.Head;
	}
}
