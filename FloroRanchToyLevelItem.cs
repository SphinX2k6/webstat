using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C75 RID: 7285
public class FloroRanchToyLevelItem : UiPanelBase
{
	// Token: 0x0600D4A0 RID: 54432 RVA: 0x0038C40C File Offset: 0x0038A60C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D4A1 RID: 54433 RVA: 0x0038C4B7 File Offset: 0x0038A6B7
	protected override void OnStart()
	{
		base.GetItem(0).SetUIActive(false);
		base.GetItem(1).SetUIActive(false);
		base.GetText(2).SetUIActive(false);
	}

	// Token: 0x0600D4A2 RID: 54434 RVA: 0x0038C4E0 File Offset: 0x0038A6E0
	public void Refresh(int level)
	{
		if (this.Level == level)
		{
			return;
		}
		this.Level = level;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Farm_ToyLevelText", new <>z__ReadOnlySingleElementList<object>(this.Level));
	}

	// Token: 0x04006522 RID: 25890
	public int Level;

	// Token: 0x02007FA5 RID: 32677
	private class EComponentDefine
	{
		// Token: 0x0402B747 RID: 177991
		public const int ArrowItem = 0;

		// Token: 0x0402B748 RID: 177992
		public const int UpItem = 1;

		// Token: 0x0402B749 RID: 177993
		public const int UpText = 2;

		// Token: 0x0402B74A RID: 177994
		public const int LevelText = 3;
	}
}
