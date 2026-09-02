using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.AttrSelect
{
	// Token: 0x02005ACF RID: 23247
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class AttrInfoItem : SyncGridProxyAbstract<IKurotatoAttrDisplay>
	{
		// Token: 0x0603AC83 RID: 240771 RVA: 0x00EE843C File Offset: 0x00EE663C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AC84 RID: 240772 RVA: 0x00EE84A8 File Offset: 0x00EE66A8
		[NullableContext(1)]
		public override void Refresh(IKurotatoAttrDisplay data)
		{
			base.GetText(0).SetText(data.Text, true);
			base.SetTextureByPath(data.Icon, base.GetTexture(1), null, null);
		}

		// Token: 0x0200BAF6 RID: 47862
		private class EAttrItemComp
		{
			// Token: 0x04039B61 RID: 236385
			public const int TextInfo = 0;

			// Token: 0x04039B62 RID: 236386
			public const int TextureIcon = 1;
		}
	}
}
