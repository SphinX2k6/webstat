using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020024FF RID: 9471
public class FetterGroupIcon : GridProxyAbstract<int>
{
	// Token: 0x0601263D RID: 75325 RVA: 0x0050E884 File Offset: 0x0050CA84
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0601263E RID: 75326 RVA: 0x0050E8E0 File Offset: 0x0050CAE0
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		base.TrySetTextureByPath(ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data).FetterElementPath, base.GetTexture(2), null, null);
		UUIItem item = base.GetItem(0);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(gridIndex != 0);
	}
}
