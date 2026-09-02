using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02001756 RID: 5974
public class NewSoundWeaponDropDownItem : DropDownItemBase<int>
{
	// Token: 0x0600A7F8 RID: 43000 RVA: 0x002CBADA File Offset: 0x002C9CDA
	[NullableContext(1)]
	public NewSoundWeaponDropDownItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x0600A7F9 RID: 43001 RVA: 0x002CBAE4 File Offset: 0x002C9CE4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITextureTransitionComponent));
		this.ComponentRegisterInfos = list;
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x0600A7FA RID: 43002 RVA: 0x002CBB79 File Offset: 0x002C9D79
	[NullableContext(2)]
	protected override UUIExtendToggle GetDropDownToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x0600A7FB RID: 43003 RVA: 0x002CBB84 File Offset: 0x002C9D84
	protected override void OnShowDropDownItemBase(int data)
	{
		UUITextureTransitionComponent uiTextureTransitionComponent = base.GetUiTextureTransitionComponent(2);
		string newText = "";
		if (data > 0)
		{
			IReadOnlyList<Mapping> weaponConfList = ConfigBase<MappingConfig>.Instance.GetWeaponConfList();
			if (weaponConfList == null)
			{
				goto IL_B0;
			}
			using (IEnumerator<Mapping> enumerator = weaponConfList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Mapping mapping = enumerator.Current;
					if (mapping.Value == data)
					{
						base.SetTextureTransitionByPath(mapping.DetectionDropDownIcon, uiTextureTransitionComponent, EUISelectableSelectionState.EUISelectableSelectionState_MAX);
						newText = (ConfigBase<MappingConfig>.Instance.GetWeaponConfComment(mapping.Comment) ?? "");
						break;
					}
				}
				goto IL_B0;
			}
		}
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("UiItem_DevelopmentGuide_AllTypeIcon");
		base.SetTextureTransitionByPath(resourcePath, uiTextureTransitionComponent, EUISelectableSelectionState.EUISelectableSelectionState_MAX);
		newText = (ConfigMultiTextLang.GetLocalTextNew("Text_FilterTextAllWeaponFetter_Text", null) ?? "");
		IL_B0:
		base.GetText(1).SetText(newText, true);
	}

	// Token: 0x02007ABB RID: 31419
	private enum EComponent
	{
		// Token: 0x0402A0AE RID: 172206
		TogOption,
		// Token: 0x0402A0AF RID: 172207
		TxtOption,
		// Token: 0x0402A0B0 RID: 172208
		WeaponTexture
	}
}
