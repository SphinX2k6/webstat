using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002529 RID: 9513
[NullableContext(1)]
[Nullable(0)]
public class VisionNameText
{
	// Token: 0x06012832 RID: 75826 RVA: 0x005199B3 File Offset: 0x00517BB3
	public VisionNameText(UUIText textComponent)
	{
		this.TextComponent = textComponent;
	}

	// Token: 0x06012833 RID: 75827 RVA: 0x005199C4 File Offset: 0x00517BC4
	public void Update(PhantomDataBase data)
	{
		string monsterName = data.GetMonsterName();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(this.TextComponent, monsterName, Array.Empty<object>());
		this.TextComponent.SetColor(FColor.FromHex(data.GetNameColor()));
	}

	// Token: 0x04009051 RID: 36945
	[Nullable(2)]
	private readonly UUIText TextComponent;
}
