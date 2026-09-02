using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020016A7 RID: 5799
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class StrItem : GridProxyAbstract<WheelTowerStrItemData>
{
	// Token: 0x0600A172 RID: 41330 RVA: 0x002A6D88 File Offset: 0x002A4F88
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A173 RID: 41331 RVA: 0x002A6DF4 File Offset: 0x002A4FF4
	public override void Refresh(WheelTowerStrItemData data, bool isSelected, int gridIndex)
	{
		string item = ConfigMultiTextLang.GetLocalTextNew(data.RoleName, null) ?? string.Empty;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "WheelBattleRoleInfo_StrTips", new <>z__ReadOnlySingleElementList<object>(item));
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(string.Join("\n", data.DescList), true);
	}
}
