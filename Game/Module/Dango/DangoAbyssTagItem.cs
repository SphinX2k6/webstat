using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Dango
{
	// Token: 0x02005DE6 RID: 24038
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class DangoAbyssTagItem : GridProxyAbstract<DangoAbyssDefine.DangoAbyssTagData>
	{
		// Token: 0x0603C7F2 RID: 247794 RVA: 0x00F5D448 File Offset: 0x00F5B648
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x0603C7F3 RID: 247795 RVA: 0x00F5D4B8 File Offset: 0x00F5B6B8
		public override void Refresh(DangoAbyssDefine.DangoAbyssTagData data, bool isSelected, int gridIndex)
		{
			AbyssPluginPropDesc value = ConfigBase<DangoAbyssConfig>.Instance.GetDangoPluginPropDescById(data.TagId).Value;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.Name, Array.Empty<object>());
			this.RefreshBgColor(value.BgColor);
			this.RefreshDescText(data);
			this.RefreshValueBg(data);
		}

		// Token: 0x0603C7F4 RID: 247796 RVA: 0x00F5D518 File Offset: 0x00F5B718
		private void RefreshDescText(DangoAbyssDefine.DangoAbyssTagData data)
		{
			string formatAttributeValueByTagId = ModelBase<DangoAbyssModel>.Instance.GetFormatAttributeValueByTagId(data.Value, data.TagId, new bool?(true));
			base.GetText(2).SetText(formatAttributeValueByTagId, true);
			base.GetText(2).SetUIActive(true);
		}

		// Token: 0x0603C7F5 RID: 247797 RVA: 0x00F5D560 File Offset: 0x00F5B760
		private void RefreshBgColor(string color)
		{
			FColor color2 = FColor.FromHex(color);
			base.GetSprite(0).SetColor(color2);
		}

		// Token: 0x0603C7F6 RID: 247798 RVA: 0x00F5D581 File Offset: 0x00F5B781
		private void RefreshValueBg(DangoAbyssDefine.DangoAbyssTagData data)
		{
			base.GetItem(3).SetUIActive(true);
		}

		// Token: 0x0200BE3A RID: 48698
		[NullableContext(0)]
		private enum ETagComponent
		{
			// Token: 0x0403A906 RID: 239878
			SpriteBg,
			// Token: 0x0403A907 RID: 239879
			NameText,
			// Token: 0x0403A908 RID: 239880
			DescText,
			// Token: 0x0403A909 RID: 239881
			ValueBg
		}
	}
}
