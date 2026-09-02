using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F6C RID: 8044
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryWeaponPanelItem : UiPanelBase, IGridProxy<EHonamiStoryWeaponType>
{
	// Token: 0x0600F0EB RID: 61675 RVA: 0x0041D8BC File Offset: 0x0041BABC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F0EC RID: 61676 RVA: 0x0041D967 File Offset: 0x0041BB67
	protected override void OnStart()
	{
		this.WeaponHorizontalLayout = new GenericLayout<HonamiStoryWeaponToggleItem, IHonamiStoryWeaponToggleItemData>(base.GetHorizontalLayout(0), new Func<HonamiStoryWeaponToggleItem>(this.CreateWeaponToggleItem), null, false, true);
	}

	// Token: 0x1700125E RID: 4702
	// (get) Token: 0x0600F0ED RID: 61677 RVA: 0x0041D98A File Offset: 0x0041BB8A
	// (set) Token: 0x0600F0EE RID: 61678 RVA: 0x0041D992 File Offset: 0x0041BB92
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public IScrollViewDelegate<IGridProxy<EHonamiStoryWeaponType>, EHonamiStoryWeaponType> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x1700125F RID: 4703
	// (get) Token: 0x0600F0EF RID: 61679 RVA: 0x0041D99B File Offset: 0x0041BB9B
	// (set) Token: 0x0600F0F0 RID: 61680 RVA: 0x0041D9A3 File Offset: 0x0041BBA3
	public int GridIndex { get; set; }

	// Token: 0x17001260 RID: 4704
	// (get) Token: 0x0600F0F1 RID: 61681 RVA: 0x0041D9AC File Offset: 0x0041BBAC
	// (set) Token: 0x0600F0F2 RID: 61682 RVA: 0x0041D9B4 File Offset: 0x0041BBB4
	public int DisplayIndex { get; set; }

	// Token: 0x0600F0F3 RID: 61683 RVA: 0x0041D9C0 File Offset: 0x0041BBC0
	public UniTask RefreshAsync(EHonamiStoryWeaponType data, bool isSelected, int gridIndex)
	{
		HonamiStoryWeaponPanelItem.<RefreshAsync>d__19 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<HonamiStoryWeaponPanelItem.<RefreshAsync>d__19>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F0F4 RID: 61684 RVA: 0x0041DA0B File Offset: 0x0041BC0B
	public void BindWeaponToggleClick(Action<HonamiStoryWeaponToggleItem> callback)
	{
		this.WeaponToggleCallBack = callback;
	}

	// Token: 0x0600F0F5 RID: 61685 RVA: 0x0041DA14 File Offset: 0x0041BC14
	public IReadOnlyList<HonamiStoryWeaponToggleItem> GetWeaponToggleList()
	{
		return this.WeaponToggleList;
	}

	// Token: 0x0600F0F6 RID: 61686 RVA: 0x0041DA1C File Offset: 0x0041BC1C
	private HonamiStoryWeaponToggleItem CreateWeaponToggleItem()
	{
		HonamiStoryWeaponToggleItem honamiStoryWeaponToggleItem = new HonamiStoryWeaponToggleItem();
		if (this.WeaponToggleCallBack != null)
		{
			honamiStoryWeaponToggleItem.BindWeaponToggleClick(this.WeaponToggleCallBack);
		}
		this.WeaponToggleList.Add(honamiStoryWeaponToggleItem);
		return honamiStoryWeaponToggleItem;
	}

	// Token: 0x0600F0F7 RID: 61687 RVA: 0x0041DA50 File Offset: 0x0041BC50
	public void Clear()
	{
	}

	// Token: 0x0600F0F8 RID: 61688 RVA: 0x0041DA52 File Offset: 0x0041BC52
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x0600F0F9 RID: 61689 RVA: 0x0041DA54 File Offset: 0x0041BC54
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x0600F0FA RID: 61690 RVA: 0x0041DA56 File Offset: 0x0041BC56
	public object GetKey(EHonamiStoryWeaponType data, int gridIndex)
	{
		return this.GridIndex;
	}

	// Token: 0x040073BA RID: 29626
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<EHonamiStoryWeaponType, string> BARSPRITE_MAP = new Dictionary<EHonamiStoryWeaponType, string>
	{
		{
			EHonamiStoryWeaponType.Attack,
			"SP_Offensive"
		},
		{
			EHonamiStoryWeaponType.Explore,
			"SP_Exploration"
		},
		{
			EHonamiStoryWeaponType.Support,
			"SP_Survivability"
		}
	};

	// Token: 0x040073BB RID: 29627
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<HonamiStoryWeaponToggleItem> WeaponToggleCallBack;

	// Token: 0x040073BC RID: 29628
	private GenericLayout<HonamiStoryWeaponToggleItem, IHonamiStoryWeaponToggleItemData> WeaponHorizontalLayout;

	// Token: 0x040073BD RID: 29629
	public readonly List<HonamiStoryWeaponToggleItem> WeaponToggleList = new List<HonamiStoryWeaponToggleItem>();

	// Token: 0x02008305 RID: 33541
	[NullableContext(0)]
	private enum EHonamiStoryWeaponPanelItemComponent
	{
		// Token: 0x0402C6CA RID: 181962
		WeaponHorizontalLayout,
		// Token: 0x0402C6CB RID: 181963
		WeaponToggleItem,
		// Token: 0x0402C6CC RID: 181964
		TypeTitleText,
		// Token: 0x0402C6CD RID: 181965
		TypeBgSprite
	}
}
