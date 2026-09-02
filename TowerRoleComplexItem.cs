using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002C03 RID: 11267
public class TowerRoleComplexItem : UiPanelBase
{
	// Token: 0x060167B8 RID: 92088 RVA: 0x0063FCB8 File Offset: 0x0063DEB8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060167B9 RID: 92089 RVA: 0x0063FD84 File Offset: 0x0063DF84
	protected override void OnStart()
	{
		base.GetItem(2).SetUIActive(true);
		base.GetText(3).SetUIActive(false);
		base.GetSprite(4).SetUIActive(false);
	}

	// Token: 0x060167BA RID: 92090 RVA: 0x0063FDB0 File Offset: 0x0063DFB0
	public void RefreshRoleId(int roleId)
	{
		UUITexture texture = base.GetTexture(1);
		UUISprite sprite = base.GetSprite(0);
		if (roleId == 0)
		{
			texture.SetUIActive(false);
			sprite.SetUIActive(false);
			return;
		}
		texture.SetUIActive(true);
		sprite.SetUIActive(true);
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		base.SetRoleIcon(roleConfig.Value.RoleHeadIconBig, texture, roleId, null, null);
		this.SetSpriteByPath(ConfigBase<RoleConfig>.Instance.GetRoleQualityInfo(roleConfig.Value.QualityId).Value.Image, sprite, false, null, null);
	}

	// Token: 0x02008F01 RID: 36609
	private enum EChildType
	{
		// Token: 0x0403009E RID: 196766
		BgQualitySprite,
		// Token: 0x0403009F RID: 196767
		RoleIcon,
		// Token: 0x040300A0 RID: 196768
		RoleLevelItem,
		// Token: 0x040300A1 RID: 196769
		RoleLevelText,
		// Token: 0x040300A2 RID: 196770
		BgRoleLevelText
	}
}
