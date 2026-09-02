using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050D0 RID: 20688
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class RoleDevelopTabItemData : MultiTemplateGridDataBase<RoleDevelopTabItemCellData, RoleDevelopTabItem>
	{
		// Token: 0x060354FC RID: 218364 RVA: 0x00D6029E File Offset: 0x00D5E49E
		public RoleDevelopTabItemData(RoleDevelopTabItemCellData data, Action<int, UUIExtendToggle> toggleFunc, Func<int, bool> canToggleChange)
		{
			base.Data = data;
			this.ToggleFunc = toggleFunc;
			this.CanToggleChange = canToggleChange;
		}

		// Token: 0x060354FD RID: 218365 RVA: 0x00D602BB File Offset: 0x00D5E4BB
		public override int GetTemplateIndex()
		{
			return 1;
		}

		// Token: 0x060354FE RID: 218366 RVA: 0x00D602BE File Offset: 0x00D5E4BE
		public override RoleDevelopTabItem CreateProxy()
		{
			RoleDevelopTabItem roleDevelopTabItem = new RoleDevelopTabItem();
			roleDevelopTabItem.BindOnToggleFunc(this.ToggleFunc);
			roleDevelopTabItem.BindCanToggleExecuteChange(this.CanToggleChange);
			return roleDevelopTabItem;
		}

		// Token: 0x0401EA96 RID: 125590
		private Action<int, UUIExtendToggle> ToggleFunc;

		// Token: 0x0401EA97 RID: 125591
		private Func<int, bool> CanToggleChange;
	}
}
