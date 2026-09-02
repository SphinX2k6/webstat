using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029C2 RID: 10690
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerMonsterListItem : UiPanelBase
{
	// Token: 0x0601551B RID: 87323 RVA: 0x005E88F8 File Offset: 0x005E6AF8
	public UniTask Init(UUIItem item)
	{
		ShipTowerMonsterListItem.<Init>d__2 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ShipTowerMonsterListItem.<Init>d__2>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0601551C RID: 87324 RVA: 0x005E8943 File Offset: 0x005E6B43
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIGridLayout))
		};
	}

	// Token: 0x0601551D RID: 87325 RVA: 0x005E897C File Offset: 0x005E6B7C
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerMonsterListItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerMonsterListItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601551E RID: 87326 RVA: 0x005E89BF File Offset: 0x005E6BBF
	public void UpdateData(ShipTowerMonsterListItemData data)
	{
		base.GetText(0).SetText(data.Title, true);
		GenericLayout<ShipTowerMonsterInfoItem, ShipTowerMonsterInfoItemData> layoutInfo = this.LayoutInfo;
		if (layoutInfo == null)
		{
			return;
		}
		layoutInfo.RefreshByData(data.MonsterInfoList, null, false);
	}

	// Token: 0x0601551F RID: 87327 RVA: 0x005E89EC File Offset: 0x005E6BEC
	private ShipTowerMonsterInfoItem CreateItem()
	{
		return new ShipTowerMonsterInfoItem();
	}

	// Token: 0x0400A44B RID: 42059
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ShipTowerMonsterInfoItem, ShipTowerMonsterInfoItemData> LayoutInfo;

	// Token: 0x02008D1B RID: 36123
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F76D RID: 194413
		public const int TxtTitle = 0;

		// Token: 0x0402F76E RID: 194414
		public const int GLayoutContainer = 1;
	}
}
