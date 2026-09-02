using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020023EB RID: 9195
[NullableContext(2)]
public interface IGiftDisplayItem
{
	// Token: 0x06011CC4 RID: 72900
	[NullableContext(1)]
	UniTask CreateByActorAsync(AActor actor);

	// Token: 0x06011CC5 RID: 72901
	UUIItem GetOriginalItem();

	// Token: 0x06011CC6 RID: 72902
	void SetActive(bool active);

	// Token: 0x06011CC7 RID: 72903
	void Refresh(PayShopGoods data, bool isSelected, int gridIndex);
}
