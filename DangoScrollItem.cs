using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001AE9 RID: 6889
internal class DangoScrollItem : GridProxyAbstract<int>
{
	// Token: 0x0600C64D RID: 50765 RVA: 0x00346890 File Offset: 0x00344A90
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600C64E RID: 50766 RVA: 0x003468C9 File Offset: 0x00344AC9
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.RefreshTexture(data);
		this.RefreshGetItem(data);
	}

	// Token: 0x0600C64F RID: 50767 RVA: 0x003468DC File Offset: 0x00344ADC
	private void RefreshTexture(int id)
	{
		string icon = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(id).GetConfig().Value.Icon;
		base.SetTextureByPath(icon, base.GetTexture(0), null, null);
	}

	// Token: 0x0600C650 RID: 50768 RVA: 0x00346924 File Offset: 0x00344B24
	private void RefreshGetItem(int id)
	{
		AbyssDangoRoleData dangoAbyssRoleData = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(id);
		if (dangoAbyssRoleData != null)
		{
			base.GetItem(1).SetUIActive(!dangoAbyssRoleData.GetIfLock());
			return;
		}
		base.GetItem(1).SetUIActive(false);
	}
}
