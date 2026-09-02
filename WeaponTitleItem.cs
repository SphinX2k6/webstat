using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02001758 RID: 5976
public class WeaponTitleItem : TitleItemBase<int>
{
	// Token: 0x0600A800 RID: 43008 RVA: 0x002CBDCF File Offset: 0x002C9FCF
	[NullableContext(1)]
	public WeaponTitleItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x0600A801 RID: 43009 RVA: 0x002CBDD8 File Offset: 0x002C9FD8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITextureTransitionComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A802 RID: 43010 RVA: 0x002CBE44 File Offset: 0x002CA044
	[NullableContext(1)]
	public override void ShowTemp(int data, DropDownItemBase<int> selectedItemObj)
	{
		UUITextureTransitionComponent uiTextureTransitionComponent = base.GetUiTextureTransitionComponent(1);
		string newText = "";
		if (data > 0)
		{
			IReadOnlyList<Mapping> weaponConfList = ConfigBase<MappingConfig>.Instance.GetWeaponConfList();
			if (weaponConfList == null)
			{
				goto IL_A7;
			}
			using (IEnumerator<Mapping> enumerator = weaponConfList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Mapping mapping = enumerator.Current;
					if (mapping.Value == data)
					{
						base.SetTextureTransitionByPath(mapping.DetectionDropDownIcon, uiTextureTransitionComponent, EUISelectableSelectionState.EUISelectableSelectionState_MAX);
						newText = ConfigBase<MappingConfig>.Instance.GetWeaponConfComment(mapping.Comment);
						break;
					}
				}
				goto IL_A7;
			}
		}
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("UiItem_DevelopmentGuide_AllTypeIcon");
		base.SetTextureTransitionByPath(resourcePath, uiTextureTransitionComponent, EUISelectableSelectionState.EUISelectableSelectionState_MAX);
		newText = (ConfigMultiTextLang.GetLocalTextNew("Text_FilterTextAllWeaponFetter_Text", null) ?? "");
		IL_A7:
		base.GetText(0).SetText(newText, true);
	}

	// Token: 0x02007ABE RID: 31422
	private enum EComponent
	{
		// Token: 0x0402A0B7 RID: 172215
		TxtOption,
		// Token: 0x0402A0B8 RID: 172216
		WeaponTexture
	}
}
