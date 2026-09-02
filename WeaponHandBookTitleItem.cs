using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001EAE RID: 7854
internal class WeaponHandBookTitleItem : UiPanelBase
{
	// Token: 0x0600E84C RID: 59468 RVA: 0x003ECC72 File Offset: 0x003EAE72
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x0600E84D RID: 59469 RVA: 0x003ECC95 File Offset: 0x003EAE95
	[NullableContext(1)]
	public void Update(string titleText)
	{
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		text.SetText(titleText, true);
	}

	// Token: 0x020081F0 RID: 33264
	private class EWeaponHandBookTitleItemDefine
	{
		// Token: 0x0402C14F RID: 180559
		public const int TitleText = 0;
	}
}
