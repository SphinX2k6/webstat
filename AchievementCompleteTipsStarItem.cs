using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02000FD8 RID: 4056
public class AchievementCompleteTipsStarItem : GridProxyAbstract<bool>
{
	// Token: 0x0600687C RID: 26748 RVA: 0x001B398D File Offset: 0x001B1B8D
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x0600687D RID: 26749 RVA: 0x001B39B0 File Offset: 0x001B1BB0
	public override void Refresh(bool data, bool isSelected, int gridIndex)
	{
		UUIItem item = base.GetItem(0);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(data);
	}

	// Token: 0x020073B3 RID: 29619
	private enum EComponent
	{
		// Token: 0x0402808D RID: 163981
		StarObj
	}
}
