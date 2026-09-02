using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020014FC RID: 5372
public class ActivityRegressRoleItem : UiPanelBase
{
	// Token: 0x0600965D RID: 38493 RVA: 0x002751B4 File Offset: 0x002733B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600965E RID: 38494 RVA: 0x00275260 File Offset: 0x00273460
	public void RefreshItem(int roleId)
	{
		if (roleId == 0)
		{
			base.GetItem(1).SetUIActive(true);
			base.GetItem(3).SetUIActive(false);
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath((playerGender == EPlayerGender.Male) ? "T_RoleTrialBoy" : "T_RoleTrialGirl");
			base.SetTextureByPath(resourcePath, base.GetTexture(2), null, null);
			return;
		}
		base.GetItem(1).SetUIActive(false);
		base.GetItem(3).SetUIActive(true);
		base.SetRoleIcon(ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value.FormationRoleCard, base.GetTexture(4), roleId, null, null);
	}

	// Token: 0x020078C0 RID: 30912
	private class EActivityRegressRoleItemComponents
	{
		// Token: 0x04029832 RID: 170034
		public const int Button = 0;

		// Token: 0x04029833 RID: 170035
		public const int LockItem = 1;

		// Token: 0x04029834 RID: 170036
		public const int LocKTexture = 2;

		// Token: 0x04029835 RID: 170037
		public const int UnLockItem = 3;

		// Token: 0x04029836 RID: 170038
		public const int UnLockTexture = 4;

		// Token: 0x04029837 RID: 170039
		public const int TitleText = 5;
	}
}
