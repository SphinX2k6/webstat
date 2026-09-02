using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029C4 RID: 10692
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerMonsterWordItem : UiPanelBase
{
	// Token: 0x06015526 RID: 87334 RVA: 0x005E8AD0 File Offset: 0x005E6CD0
	public UniTask Init(UUIItem item)
	{
		ShipTowerMonsterWordItem.<Init>d__2 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ShipTowerMonsterWordItem.<Init>d__2>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06015527 RID: 87335 RVA: 0x005E8B1C File Offset: 0x005E6D1C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06015528 RID: 87336 RVA: 0x005E8B78 File Offset: 0x005E6D78
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerMonsterWordItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerMonsterWordItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015529 RID: 87337 RVA: 0x005E8BBB File Offset: 0x005E6DBB
	public void UpdateData(ShipTowerMonsterWordItemData data)
	{
		base.GetText(0).SetText(data.Title, true);
		GenericLayout<ShipTowerMonsterWordInfoItem, ShipTowerMonsterWordInfoItemData> layoutInfo = this.LayoutInfo;
		if (layoutInfo == null)
		{
			return;
		}
		layoutInfo.RefreshByData(data.InfoList, null, false);
	}

	// Token: 0x0601552A RID: 87338 RVA: 0x005E8BE8 File Offset: 0x005E6DE8
	private ShipTowerMonsterWordInfoItem CreateItem()
	{
		return new ShipTowerMonsterWordInfoItem();
	}

	// Token: 0x0400A44C RID: 42060
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ShipTowerMonsterWordInfoItem, ShipTowerMonsterWordInfoItemData> LayoutInfo;

	// Token: 0x02008D1F RID: 36127
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F77B RID: 194427
		public const int TxtTitle = 0;

		// Token: 0x0402F77C RID: 194428
		public const int VLayoutContainer = 1;

		// Token: 0x0402F77D RID: 194429
		public const int ItemWordInfo = 2;
	}
}
