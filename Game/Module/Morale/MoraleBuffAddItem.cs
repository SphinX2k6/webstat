using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x0200570C RID: 22284
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MoraleBuffAddItem : GridProxyAbstract<IMoraleBuffAddItemData>
	{
		// Token: 0x06038B80 RID: 232320 RVA: 0x00E5C8C8 File Offset: 0x00E5AAC8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x06038B81 RID: 232321 RVA: 0x00E5C922 File Offset: 0x00E5AB22
		public override void Refresh(IMoraleBuffAddItemData data, bool isSelected, int gridIndex)
		{
			this.Refresh(data);
		}

		// Token: 0x06038B82 RID: 232322 RVA: 0x00E5C92C File Offset: 0x00E5AB2C
		public void Refresh(IMoraleBuffAddItemData data)
		{
			this.ItemData = data;
			UUITexture texture = base.GetTexture(0);
			base.SetTextureByPath(data.IconPath, texture, null, null);
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.ShowTextNew(data.NameKey);
			}
			UUIText text2 = base.GetText(2);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(data.Value, true);
		}

		// Token: 0x04020537 RID: 132407
		public IMoraleBuffAddItemData ItemData;

		// Token: 0x0200B7A4 RID: 47012
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038CCD RID: 232653
			public const int TextureIcon = 0;

			// Token: 0x04038CCE RID: 232654
			public const int TxtName = 1;

			// Token: 0x04038CCF RID: 232655
			public const int TxtValue = 2;
		}
	}
}
