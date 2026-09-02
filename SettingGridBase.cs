using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;

// Token: 0x0200201D RID: 8221
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SettingGridBase : GridProxyAbstract<InventoryDefine.IManageConfigSettingGridData>
{
	// Token: 0x0600F9DD RID: 63965 RVA: 0x004468C2 File Offset: 0x00444AC2
	public override void Refresh(InventoryDefine.IManageConfigSettingGridData data, bool isSelected, int gridIndex)
	{
	}

	// Token: 0x0600F9DE RID: 63966 RVA: 0x004468C4 File Offset: 0x00444AC4
	public override object GetKey(InventoryDefine.IManageConfigSettingGridData data, int displayIndex)
	{
		return base.GridIndex;
	}

	// Token: 0x04007814 RID: 30740
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<InventoryDefine.IManageConfigSettingGridData, bool> CallbackOnClicked;
}
