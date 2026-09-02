using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Calabash.New.VisionRefine
{
	// Token: 0x02005EDD RID: 24285
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class VisionRefineMainAttributeItem : GridProxyAbstract<VisionRefineAttributeItemData>
	{
		// Token: 0x0603D053 RID: 249939 RVA: 0x00F7FAD8 File Offset: 0x00F7DCD8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUITexture))
			};
		}

		// Token: 0x0603D054 RID: 249940 RVA: 0x00F7FB34 File Offset: 0x00F7DD34
		[NullableContext(1)]
		public override void Refresh(VisionRefineAttributeItemData data, bool isSelected, int gridIndex)
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.ShowTextNew(data.NameTextId);
			}
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.SetText(data.NumberText ?? "", true);
			}
			base.SetTextureByPath(data.IconPath ?? "", base.GetTexture(2), null, null);
		}

		// Token: 0x0200BEDE RID: 48862
		private enum EComp
		{
			// Token: 0x0403ABEA RID: 240618
			Name,
			// Token: 0x0403ABEB RID: 240619
			Num,
			// Token: 0x0403ABEC RID: 240620
			Icon
		}
	}
}
