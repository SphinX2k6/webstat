using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002064 RID: 8292
public class ItemPriorHintItem : ItemHintItem
{
	// Token: 0x0600FCDB RID: 64731 RVA: 0x004567A0 File Offset: 0x004549A0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUISprite))
		};
	}

	// Token: 0x0600FCDC RID: 64732 RVA: 0x0045683C File Offset: 0x00454A3C
	public override UniTask AsyncLoadUiResource()
	{
		ItemPriorHintItem.<AsyncLoadUiResource>d__2 <AsyncLoadUiResource>d__;
		<AsyncLoadUiResource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AsyncLoadUiResource>d__.<>4__this = this;
		<AsyncLoadUiResource>d__.<>1__state = -1;
		<AsyncLoadUiResource>d__.<>t__builder.Start<ItemPriorHintItem.<AsyncLoadUiResource>d__2>(ref <AsyncLoadUiResource>d__);
		return <AsyncLoadUiResource>d__.<>t__builder.Task;
	}

	// Token: 0x020083FE RID: 33790
	private enum EItemPriorHintItemCom
	{
		// Token: 0x0402CBD9 RID: 183257
		ItemIcon,
		// Token: 0x0402CBDA RID: 183258
		ItemNameText,
		// Token: 0x0402CBDB RID: 183259
		ItemCountText,
		// Token: 0x0402CBDC RID: 183260
		ItemXText,
		// Token: 0x0402CBDD RID: 183261
		QualityTexture,
		// Token: 0x0402CBDE RID: 183262
		QualitySprite
	}
}
