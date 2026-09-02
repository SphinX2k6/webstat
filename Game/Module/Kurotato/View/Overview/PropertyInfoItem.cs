using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005A9A RID: 23194
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PropertyInfoItem : GridProxyAbstract<IKurotatoAttrDisplay>
	{
		// Token: 0x0603AAFA RID: 240378 RVA: 0x00EDF92C File Offset: 0x00EDDB2C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AAFB RID: 240379 RVA: 0x00EDF9D8 File Offset: 0x00EDDBD8
		[NullableContext(1)]
		public override void Refresh(IKurotatoAttrDisplay data, bool isSelected, int gridIndex)
		{
			base.SetTextureByPath(data.Icon, base.GetTexture(0), null, null);
			KurotatoProperty? propertyById = ConfigBase<KurotatoConfig>.Instance.GetPropertyById(data.PropertyId);
			string text;
			if (propertyById != null)
			{
				KurotatoProperty valueOrDefault = propertyById.GetValueOrDefault();
				text = (ConfigMultiTextLang.GetLocalTextNew(valueOrDefault.ShowName, null) ?? valueOrDefault.ShowName);
			}
			else
			{
				text = "";
			}
			string newText = text;
			base.GetText(1).SetText(newText, true);
			base.GetText(2).SetText(data.Text, true);
			base.GetTexture(3).SetUIActive(gridIndex % 2 == 0);
		}

		// Token: 0x0200BA94 RID: 47764
		private enum EAttrChildComp
		{
			// Token: 0x040399C8 RID: 235976
			TextureIcon,
			// Token: 0x040399C9 RID: 235977
			TextAttr,
			// Token: 0x040399CA RID: 235978
			TextNum,
			// Token: 0x040399CB RID: 235979
			TextureBg
		}
	}
}
