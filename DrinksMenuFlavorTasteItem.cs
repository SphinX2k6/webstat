using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200101C RID: 4124
public class DrinksMenuFlavorTasteItem : UiPanelBase
{
	// Token: 0x06006B48 RID: 27464 RVA: 0x001C1099 File Offset: 0x001BF299
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06006B49 RID: 27465 RVA: 0x001C10D4 File Offset: 0x001BF2D4
	[NullableContext(2)]
	public void Refresh(ITasteInfo data)
	{
		if (data == null)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetUIActive(false);
			return;
		}
		else
		{
			UUIItem rootItem2 = this.RootItem;
			if (rootItem2 != null)
			{
				rootItem2.SetUIActive(true);
			}
			base.SetTextureByPath(ConfigBase<DrinksConfig>.Instance.GetFlavorType(data.Type).Value.Icon, base.GetTexture(0), null, null);
			string newText;
			if (data.Value.Length == 1)
			{
				newText = StringUtils.Format(data.Key, new string[]
				{
					data.Value[0]
				});
			}
			else if (data.Value.Length >= 2)
			{
				newText = StringUtils.Format(data.Key, new string[]
				{
					data.Value[0],
					data.Value[1]
				});
			}
			else
			{
				newText = data.Key;
			}
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(newText, true);
			return;
		}
	}

	// Token: 0x020073FE RID: 29694
	private static class EFlavor
	{
		// Token: 0x040281EA RID: 164330
		public const int Icon = 0;

		// Token: 0x040281EB RID: 164331
		public const int Txt = 1;
	}
}
