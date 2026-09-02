using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029C1 RID: 10689
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerMonsterInfoItem : GridProxyAbstract<ShipTowerMonsterInfoItemData>
{
	// Token: 0x06015514 RID: 87316 RVA: 0x005E87A8 File Offset: 0x005E69A8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout))
		};
	}

	// Token: 0x06015515 RID: 87317 RVA: 0x005E8818 File Offset: 0x005E6A18
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerMonsterInfoItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerMonsterInfoItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015516 RID: 87318 RVA: 0x005E885B File Offset: 0x005E6A5B
	public override void Refresh(ShipTowerMonsterInfoItemData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data);
	}

	// Token: 0x06015517 RID: 87319 RVA: 0x005E8864 File Offset: 0x005E6A64
	public void Refresh(ShipTowerMonsterInfoItemData data)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "LevelText", new <>z__ReadOnlySingleElementList<object>(data.Level));
		base.GetText(0).ShowTextNew(data.Title);
		base.SetTextureByPath(data.MonsterIcon, base.GetTexture(2), null, null);
		GenericLayout<TowerElementItem, int> layoutElement = this.LayoutElement;
		if (layoutElement == null)
		{
			return;
		}
		layoutElement.RefreshByData(data.ElementList, null, false);
	}

	// Token: 0x06015518 RID: 87320 RVA: 0x005E88DE File Offset: 0x005E6ADE
	private TowerElementItem CreateItem()
	{
		return new TowerElementItem();
	}

	// Token: 0x0400A44A RID: 42058
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerElementItem, int> LayoutElement;

	// Token: 0x02008D19 RID: 36121
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F765 RID: 194405
		public const int TxtTitle = 0;

		// Token: 0x0402F766 RID: 194406
		public const int TxtLevel = 1;

		// Token: 0x0402F767 RID: 194407
		public const int TextureMonsterIcon = 2;

		// Token: 0x0402F768 RID: 194408
		public const int HLayoutContainer = 3;
	}
}
