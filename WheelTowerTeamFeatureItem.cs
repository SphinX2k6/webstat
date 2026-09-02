using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200167B RID: 5755
public class WheelTowerTeamFeatureItem : GridProxyAbstract<int>
{
	// Token: 0x0600A0D9 RID: 41177 RVA: 0x002A2B04 File Offset: 0x002A0D04
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A0DA RID: 41178 RVA: 0x002A2B70 File Offset: 0x002A0D70
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		NewTowerTeamFeature? teamFeatureConfig = ConfigBase<WheelTowerConfig>.Instance.GetTeamFeatureConfig(data);
		if (teamFeatureConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), teamFeatureConfig.Value.Name, Array.Empty<object>());
		base.SetTextureByPath(teamFeatureConfig.Value.Icon, base.GetTexture(0), null, null);
	}
}
