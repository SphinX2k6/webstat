using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001681 RID: 5761
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WheelTowerRoleItem : GridProxyAbstract<RoleDataWithBranch>
{
	// Token: 0x17000D86 RID: 3462
	// (get) Token: 0x0600A0ED RID: 41197 RVA: 0x002A314A File Offset: 0x002A134A
	// (set) Token: 0x0600A0EE RID: 41198 RVA: 0x002A3152 File Offset: 0x002A1352
	public bool IsOnlyShowIcon { get; set; }

	// Token: 0x17000D87 RID: 3463
	// (get) Token: 0x0600A0EF RID: 41199 RVA: 0x002A315B File Offset: 0x002A135B
	// (set) Token: 0x0600A0F0 RID: 41200 RVA: 0x002A3163 File Offset: 0x002A1363
	public bool CanClick { get; set; } = true;

	// Token: 0x0600A0F1 RID: 41201 RVA: 0x002A316C File Offset: 0x002A136C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A0F2 RID: 41202 RVA: 0x002A32E0 File Offset: 0x002A14E0
	public override void Refresh(RoleDataWithBranch data, bool isSelected, int gridIndex)
	{
		int roleId = data.RoleId;
		bool flag = roleId > 0;
		UUITexture texture = base.GetTexture(1);
		if (texture != null)
		{
			texture.SetUIActive(flag);
		}
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(flag && !this.IsOnlyShowIcon);
		}
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetUIActive(flag);
		}
		UUIItem item2 = base.GetItem(4);
		if (item2 != null)
		{
			item2.SetUIActive(flag && !this.IsOnlyShowIcon);
		}
		UUIItem item3 = base.GetItem(5);
		if (item3 != null)
		{
			item3.SetUIActive(flag);
		}
		UUIItem item4 = base.GetItem(6);
		if (item4 != null)
		{
			item4.SetUIActive(!flag && this.CanClick);
		}
		UUIItem item5 = base.GetItem(7);
		if (item5 != null)
		{
			item5.SetUIActive(flag && !this.IsOnlyShowIcon);
		}
		UUIItem item6 = base.GetItem(8);
		if (item6 != null)
		{
			item6.SetUIActive(!flag && !this.CanClick);
		}
		if (!flag)
		{
			UUIItem item7 = base.GetItem(9);
			if (item7 == null)
			{
				return;
			}
			item7.SetUIActive(false);
			return;
		}
		else
		{
			WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
			int roleId2 = instance.TryGetRealRoleId(roleId);
			int itemId = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value.SkinId;
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
			if (roleDataById != null)
			{
				itemId = roleDataById.GetRoleSkinId();
			}
			RoleSkin? roleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(itemId);
			if (roleSkinConfig != null)
			{
				base.SetTextureShowUntilLoaded(roleSkinConfig.Value.Card, base.GetTexture(1), null);
			}
			UUIItem item8 = base.GetItem(9);
			int skillBranchIndex = data.SkillBranchIndex;
			bool uiactive = data.RoleId > 0 && skillBranchIndex > -1;
			if (item8 != null)
			{
				item8.SetUIActive(uiactive);
			}
			this.SetSkillBranchIconToLeft(skillBranchIndex == 0);
			if (this.IsOnlyShowIcon)
			{
				return;
			}
			int roleEnergy = instance.SelectedEnergyInfo.GetRoleEnergy(roleId2);
			UUIText text2 = base.GetText(3);
			if (text2 != null)
			{
				text2.SetText(roleEnergy.ToString(), true);
			}
			if (text2 != null)
			{
				text2.SetChangeColor(roleEnergy <= 0, TowerData.redColor);
			}
			bool uiactive2 = instance.IsEnhanceRole(roleId2);
			UUIItem item9 = base.GetItem(4);
			if (item9 != null)
			{
				item9.SetUIActive(uiactive2);
			}
			bool uiactive3 = instance.CheckConflict(roleId) != null;
			UUIItem item10 = base.GetItem(7);
			if (item10 == null)
			{
				return;
			}
			item10.SetUIActive(uiactive3);
			return;
		}
	}

	// Token: 0x0600A0F3 RID: 41203 RVA: 0x002A352C File Offset: 0x002A172C
	private void SetSkillBranchIconToLeft(bool isLeft)
	{
		UUIItem item = base.GetItem(9);
		FVector fvector = new FVector(0f, (float)(isLeft ? 0 : 180), 0f);
		FRotator frotator = FRotator.MakeFromEuler(fvector);
		item.SetUIRelativeRotation(frotator);
	}
}
