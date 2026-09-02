using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001F5E RID: 8030
[Nullable(new byte[]
{
	0,
	1
})]
public class HonamiStoryEquipItemInfoItem : GridProxyAbstract<IHonamiStoryTipsBuffInfo>
{
	// Token: 0x0600F066 RID: 61542 RVA: 0x0041B3F0 File Offset: 0x004195F0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText))
		};
	}

	// Token: 0x0600F067 RID: 61543 RVA: 0x0041B4A4 File Offset: 0x004196A4
	[NullableContext(1)]
	public override void Refresh(IHonamiStoryTipsBuffInfo buffInfo, bool isSelected, int gridIndex)
	{
		bool flag = true;
		HonamiStoryBuffTemp? honamiStoryBuffTemp = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryBuffTemp(buffInfo.BuffId);
		if (honamiStoryBuffTemp == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "HonamiStory_EquipEffect", new <>z__ReadOnlySingleElementList<object>(new TableTextArgNew(honamiStoryBuffTemp.Value.Name, Array.Empty<object>())));
		UUIText text = base.GetText(0);
		if (text != null)
		{
			UUIItem uuiitem = text;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}
		bool flag2;
		if (buffInfo.FromTeamView)
		{
			flag2 = ModelBase<RoleModel>.Instance.IsShowSkillResume;
		}
		else
		{
			flag2 = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.HonamiStorySkillDescMode, false);
		}
		string textStringId = (!flag2) ? honamiStoryBuffTemp.Value.Desc : honamiStoryBuffTemp.Value.DescSimple;
		string[] array = (!flag2) ? honamiStoryBuffTemp.Value.DescArgs() : honamiStoryBuffTemp.Value.DescSimpleArgs();
		if (array != null && array.Length != 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, array);
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
		}
		UUIText text2 = base.GetText(1);
		if (text2 != null)
		{
			UUIItem uuiitem2 = text2;
			bool bUseChangeColor2 = flag;
			FColor? fcolor = new FColor?(text2.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
		}
		base.GetSprite(2).SetUIActive(flag);
		base.GetSprite(3).SetUIActive(!flag);
		base.GetItem(5).SetUIActive(false);
		base.GetText(6).SetUIActive(false);
	}

	// Token: 0x020082EB RID: 33515
	internal enum EHonamiStoryEquipItemInfoItemComponent
	{
		// Token: 0x0402C637 RID: 181815
		TitleText,
		// Token: 0x0402C638 RID: 181816
		DescText,
		// Token: 0x0402C639 RID: 181817
		ActiveSprite,
		// Token: 0x0402C63A RID: 181818
		NonActiveSprite,
		// Token: 0x0402C63B RID: 181819
		TipSprite,
		// Token: 0x0402C63C RID: 181820
		SuitActiveItem,
		// Token: 0x0402C63D RID: 181821
		SuitNumText
	}
}
