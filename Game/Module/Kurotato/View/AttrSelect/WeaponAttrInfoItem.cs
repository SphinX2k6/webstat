using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.AttrSelect
{
	// Token: 0x02005ACD RID: 23245
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class WeaponAttrInfoItem : SyncGridProxyAbstract<IKurotatoAttrDisplay>
	{
		// Token: 0x0603AC7A RID: 240762 RVA: 0x00EE832C File Offset: 0x00EE652C
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

		// Token: 0x0603AC7B RID: 240763 RVA: 0x00EE8398 File Offset: 0x00EE6598
		[NullableContext(1)]
		public override void Refresh(IKurotatoAttrDisplay data)
		{
			KurotatoProperty? propertyById = ConfigBase<KurotatoConfig>.Instance.GetPropertyById(data.PropertyId);
			if (propertyById != null)
			{
				base.GetText(0).ShowTextNew(propertyById.Value.ShowName);
			}
			else
			{
				base.GetText(0).SetText("", true);
			}
			base.GetText(1).SetText(data.Text, true);
		}

		// Token: 0x0200BAF5 RID: 47861
		private class EWeaponAttrInfoComp
		{
			// Token: 0x04039B5F RID: 236383
			public const int TextTitle = 0;

			// Token: 0x04039B60 RID: 236384
			public const int ItemAttrInfo = 1;
		}
	}
}
