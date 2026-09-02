using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.KurotatoLevelSelect
{
	// Token: 0x02005AB3 RID: 23219
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KurotatoLevelTitleItem : SyncGridProxyAbstract<KurotatoLevelTitleItemData>
	{
		// Token: 0x0603AB7E RID: 240510 RVA: 0x00EE2B80 File Offset: 0x00EE0D80
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

		// Token: 0x0603AB7F RID: 240511 RVA: 0x00EE2BEC File Offset: 0x00EE0DEC
		[NullableContext(1)]
		public override void Refresh(KurotatoLevelTitleItemData data)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.TextId, Array.Empty<object>());
			base.SetTextureByPath(data.BgPath, base.GetTexture(1), null, null);
		}

		// Token: 0x0200BAB9 RID: 47801
		private enum EComponents
		{
			// Token: 0x04039A49 RID: 236105
			TextName,
			// Token: 0x04039A4A RID: 236106
			TextureBg
		}
	}
}
