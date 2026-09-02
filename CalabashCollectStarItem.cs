using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020017F0 RID: 6128
public class CalabashCollectStarItem : GridProxyAbstract<bool>
{
	// Token: 0x0600AE2A RID: 44586 RVA: 0x002E4FE5 File Offset: 0x002E31E5
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x0600AE2B RID: 44587 RVA: 0x002E5008 File Offset: 0x002E3208
	public override void Refresh(bool isUnlock, bool isSelected, int gridIndex)
	{
		UUIItem item = base.GetItem(0);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(isUnlock);
	}

	// Token: 0x02007B69 RID: 31593
	private enum EComponent
	{
		// Token: 0x0402A303 RID: 172803
		UnlockItem
	}
}
