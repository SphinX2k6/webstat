using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BCB RID: 23499
	public class InstanceDungeonTrialRoleItem : UiPanelBase
	{
		// Token: 0x0603B800 RID: 243712 RVA: 0x00F158C3 File Offset: 0x00F13AC3
		[NullableContext(1)]
		public InstanceDungeonTrialRoleItem(UUIItem baseUiItem, int roleId)
		{
			this.RoleId = roleId;
		}

		// Token: 0x0603B801 RID: 243713 RVA: 0x00F158D4 File Offset: 0x00F13AD4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B802 RID: 243714 RVA: 0x00F15960 File Offset: 0x00F13B60
		protected override void OnStart()
		{
			base.GetExtendToggle(7).CanExecuteChange.Bind(() => false);
			base.GetExtendToggle(7).IsSelfInteractive = false;
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.ShowRoleTexture();
		}

		// Token: 0x0603B803 RID: 243715 RVA: 0x00F159C3 File Offset: 0x00F13BC3
		protected override void OnBeforeDestroy()
		{
			this.RoleId = 0;
		}

		// Token: 0x0603B804 RID: 243716 RVA: 0x00F159CC File Offset: 0x00F13BCC
		public void SetRoleId(int id)
		{
			this.RoleId = id;
			this.ShowRoleTexture();
		}

		// Token: 0x0603B805 RID: 243717 RVA: 0x00F159DC File Offset: 0x00F13BDC
		private void ShowRoleTexture()
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId);
			base.SetRoleIcon(((roleConfig != null) ? roleConfig.GetValueOrDefault().RoleHeadIcon : null) ?? "", base.GetTexture(1), this.RoleId, null, null);
		}

		// Token: 0x04021835 RID: 137269
		private int RoleId;

		// Token: 0x0200BC36 RID: 48182
		private static class EInstanceDungeonTrialRoleItem
		{
			// Token: 0x0403A0D7 RID: 237783
			public const int RoleTexture = 1;

			// Token: 0x0403A0D8 RID: 237784
			public const int NameItem = 2;

			// Token: 0x0403A0D9 RID: 237785
			public const int Toggle = 7;
		}
	}
}
