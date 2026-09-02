using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002CF1 RID: 11505
public class WeaponResonanceItem : UiPanelBase
{
	// Token: 0x06017334 RID: 95028 RVA: 0x0066E2FE File Offset: 0x0066C4FE
	[NullableContext(1)]
	public WeaponResonanceItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x06017335 RID: 95029 RVA: 0x0066E314 File Offset: 0x0066C514
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06017336 RID: 95030 RVA: 0x0066E3E0 File Offset: 0x0066C5E0
	[NullableContext(1)]
	public void UpdateItem(WeaponDataBase data)
	{
		WeaponConf? weaponConfig = data.GetWeaponConfig();
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "WeaponResonanceItemLevelText", new <>z__ReadOnlySingleElementList<object>(data.GetResonanceLevel()));
		WeaponReson? weaponResonanceConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponResonanceConfig(weaponConfig.Value.ResonId, data.GetResonanceLevel());
		base.GetText(1).SetUIActive(weaponResonanceConfig != null);
		base.GetText(3).SetUIActive(weaponResonanceConfig != null);
		if (weaponResonanceConfig != null)
		{
			base.GetText(3).SetText(ConfigBase<WeaponConfig>.Instance.GetWeaponResonanceDesc(weaponResonanceConfig.Value.Name), true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.GetItemConfig().BgDescription, Array.Empty<object>());
		string[] weaponConfigDescParams = ModelBase<WeaponModel>.Instance.GetWeaponConfigDescParams(weaponConfig.Value, data.GetResonanceLevel());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), weaponConfig.Value.Desc, weaponConfigDescParams);
		int weaponType = weaponConfig.Value.WeaponType;
		foreach (Mapping mapping in ConfigBase<MappingConfig>.Instance.GetWeaponConfList())
		{
			if (weaponType == mapping.Value)
			{
				this.SetSpriteByPath(mapping.Icon, base.GetSprite(4), false, null, null);
				break;
			}
		}
	}

	// Token: 0x02008FBC RID: 36796
	private enum EWeaponResonanceItemDefine
	{
		// Token: 0x040303ED RID: 197613
		FromText,
		// Token: 0x040303EE RID: 197614
		DescribeText,
		// Token: 0x040303EF RID: 197615
		LevelText,
		// Token: 0x040303F0 RID: 197616
		SkillText,
		// Token: 0x040303F1 RID: 197617
		WeaponSprite
	}
}
