using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;

// Token: 0x020023A1 RID: 9121
[NullableContext(1)]
[Nullable(0)]
public class GameplayShopGridItem : GameplayShopItem, IGridProxy<IGameplayShopItemProxy>
{
	// Token: 0x1700165E RID: 5726
	// (get) Token: 0x06011928 RID: 71976 RVA: 0x004D1923 File Offset: 0x004CFB23
	// (set) Token: 0x06011929 RID: 71977 RVA: 0x004D192B File Offset: 0x004CFB2B
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<IGameplayShopItemProxy>, IGameplayShopItemProxy> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x1700165F RID: 5727
	// (get) Token: 0x0601192A RID: 71978 RVA: 0x004D1934 File Offset: 0x004CFB34
	// (set) Token: 0x0601192B RID: 71979 RVA: 0x004D193C File Offset: 0x004CFB3C
	public int GridIndex { get; set; }

	// Token: 0x17001660 RID: 5728
	// (get) Token: 0x0601192C RID: 71980 RVA: 0x004D1945 File Offset: 0x004CFB45
	// (set) Token: 0x0601192D RID: 71981 RVA: 0x004D194D File Offset: 0x004CFB4D
	public int DisplayIndex { get; set; }

	// Token: 0x0601192E RID: 71982 RVA: 0x004D1956 File Offset: 0x004CFB56
	public void Refresh(IGameplayShopItemProxy data, bool isSelected, int gridIndex)
	{
		base.RefreshByData(data);
	}

	// Token: 0x0601192F RID: 71983 RVA: 0x004D195F File Offset: 0x004CFB5F
	public void Clear()
	{
	}

	// Token: 0x06011930 RID: 71984 RVA: 0x004D1961 File Offset: 0x004CFB61
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x06011931 RID: 71985 RVA: 0x004D1963 File Offset: 0x004CFB63
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x06011932 RID: 71986 RVA: 0x004D1965 File Offset: 0x004CFB65
	public object GetKey(IGameplayShopItemProxy data, int gridIndex)
	{
		return gridIndex;
	}
}
