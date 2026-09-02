using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A85 RID: 23173
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class AttributeItem : GridProxyAbstract<IKurotatoRoleSkillInfo>
	{
		// Token: 0x0603AA28 RID: 240168 RVA: 0x00EDACC4 File Offset: 0x00ED8EC4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AA29 RID: 240169 RVA: 0x00EDAD50 File Offset: 0x00ED8F50
		[NullableContext(1)]
		public override void Refresh(IKurotatoRoleSkillInfo data, bool isSelected, int gridIndex)
		{
			KurotatoProperty value = ConfigBase<KurotatoConfig>.Instance.GetPropertyById(data.AttrId).Value;
			base.SetTextureByPath(value.Icon, base.GetTexture(0), null, null);
			base.GetText(1).ShowTextNew(value.ShowName);
			base.GetText(2).SetText(KurotatoUtil.GetPropertyShowValue(data.AttrId, (float)data.Value), true);
		}

		// Token: 0x0200BA62 RID: 47714
		private class EAttributeComps
		{
			// Token: 0x040398C9 RID: 235721
			public const int TextureIcon = 0;

			// Token: 0x040398CA RID: 235722
			public const int TextName = 1;

			// Token: 0x040398CB RID: 235723
			public const int TextValue = 2;
		}
	}
}
