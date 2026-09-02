using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.HonamiStory.Data;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F6D RID: 8045
public class HonamiStoryWeaponSuitActiveItem : UiPanelBase
{
	// Token: 0x0600F0FD RID: 61693 RVA: 0x0041DAA8 File Offset: 0x0041BCA8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F0FE RID: 61694 RVA: 0x0041DAF0 File Offset: 0x0041BCF0
	protected override void OnBeforeCreateImplement()
	{
		this.LevelPlaySequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.LevelPlaySequence);
	}

	// Token: 0x0600F0FF RID: 61695 RVA: 0x0041DB0C File Offset: 0x0041BD0C
	[NullableContext(1)]
	public void Refresh(IHonamiStoryWeaponSuitData data)
	{
		int suitId = data.SuitId;
		HonamiStoryRoleEquipData equipData = data.EquipData;
		HonamiStoryWeaponSuitActiveData honamiStoryWeaponSuitActiveData = (equipData != null) ? equipData.IsSuitActivate(suitId, null) : null;
		CSharpScript.Game.Module.HonamiStory.Data.HonamiStoryWeaponSuitData weaponSuitData = ModelBase<HonamiStoryModel>.Instance.GetWeaponSuitData(suitId);
		HonamiStoryPluginSubType value = ConfigBase<HonamiStoryConfig>.Instance.GetPluginSubType(weaponSuitData.WeaponPluginType).Value;
		HonamiStoryWeaponSuitActiveItem.EHonamiStoryWeaponSuitActiveItemIndex ehonamiStoryWeaponSuitActiveItemIndex = HonamiStoryWeaponSuitActiveItem.EHonamiStoryWeaponSuitActiveItemIndex.InActive;
		if (honamiStoryWeaponSuitActiveData != null)
		{
			int num = honamiStoryWeaponSuitActiveData.NeedCount - 2;
			int num2 = honamiStoryWeaponSuitActiveData.CurCount - num;
			bool flag = honamiStoryWeaponSuitActiveData.CurCount >= honamiStoryWeaponSuitActiveData.NeedCount;
			if (flag && flag != this.LastActiveStatus)
			{
				UiBehaviorLevelSequence levelPlaySequence = this.LevelPlaySequence;
				if (levelPlaySequence != null)
				{
					levelPlaySequence.PlaySequence("Burst", false, null);
				}
			}
			this.LastActiveStatus = flag;
			if (num2 >= 2)
			{
				ehonamiStoryWeaponSuitActiveItemIndex = HonamiStoryWeaponSuitActiveItem.EHonamiStoryWeaponSuitActiveItemIndex.ActiveAll;
			}
			else if (num2 >= 1)
			{
				ehonamiStoryWeaponSuitActiveItemIndex = HonamiStoryWeaponSuitActiveItem.EHonamiStoryWeaponSuitActiveItemIndex.ActiveOne;
			}
			else
			{
				ehonamiStoryWeaponSuitActiveItemIndex = HonamiStoryWeaponSuitActiveItem.EHonamiStoryWeaponSuitActiveItemIndex.InActive;
			}
		}
		string text;
		switch (ehonamiStoryWeaponSuitActiveItemIndex)
		{
		case HonamiStoryWeaponSuitActiveItem.EHonamiStoryWeaponSuitActiveItemIndex.InActive:
			text = value.ActiveSpritePath;
			break;
		case HonamiStoryWeaponSuitActiveItem.EHonamiStoryWeaponSuitActiveItemIndex.ActiveOne:
			text = value.ActiveOneSpritePath;
			break;
		case HonamiStoryWeaponSuitActiveItem.EHonamiStoryWeaponSuitActiveItemIndex.ActiveAll:
			text = value.ActiveAllSpritePath;
			break;
		default:
			text = value.ActiveSpritePath;
			break;
		}
		if (!string.IsNullOrEmpty(text))
		{
			this.SetSpriteByPath(text, base.GetSprite(0), true, null, null);
		}
	}

	// Token: 0x040073C1 RID: 29633
	private const int START_SHOW_MIN_COUNT = 2;

	// Token: 0x040073C2 RID: 29634
	[Nullable(2)]
	private UiBehaviorLevelSequence LevelPlaySequence;

	// Token: 0x040073C3 RID: 29635
	private bool LastActiveStatus;

	// Token: 0x02008308 RID: 33544
	private enum EHonamiStoryWeaponSuitActiveItemComponent
	{
		// Token: 0x0402C6D6 RID: 181974
		Sprite
	}

	// Token: 0x02008309 RID: 33545
	private enum EHonamiStoryWeaponSuitActiveItemIndex
	{
		// Token: 0x0402C6D8 RID: 181976
		InActive,
		// Token: 0x0402C6D9 RID: 181977
		ActiveOne,
		// Token: 0x0402C6DA RID: 181978
		ActiveAll
	}
}
