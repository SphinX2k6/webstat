using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C72 RID: 7282
internal class FloroRanchTechLine : UiPanelBase
{
	// Token: 0x0600D48C RID: 54412 RVA: 0x0038BC80 File Offset: 0x00389E80
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D48D RID: 54413 RVA: 0x0038BCC8 File Offset: 0x00389EC8
	public void Refresh(bool isUnlock)
	{
		UUISprite sprite = base.GetSprite(0);
		UUIItem uuiitem = sprite;
		bool bUseChangeColor = !isUnlock;
		FColor? fcolor = new FColor?(sprite.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x02007FA0 RID: 32672
	private class EFloroRanchTechLineDefine
	{
		// Token: 0x0402B72D RID: 177965
		public const int SpriteLine = 0;
	}
}
