using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x020066A8 RID: 26280
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MowingRiskInstanceDetailAttributeGridItem : GridProxyAbstract<IMowingRiskInstanceDetailAttributeItemData>
	{
		// Token: 0x06041A13 RID: 268819 RVA: 0x010D3FBC File Offset: 0x010D21BC
		[NullableContext(1)]
		public override void Refresh(IMowingRiskInstanceDetailAttributeItemData data, bool isSelected, int gridIndex)
		{
			UUITexture texture = base.GetTexture(0);
			if (!string.IsNullOrEmpty(data.IconPath))
			{
				if (texture != null)
				{
					texture.SetUIActive(true);
				}
				base.SetTextureByPath(data.IconPath, texture, null, null);
			}
			else if (texture != null)
			{
				texture.SetUIActive(false);
			}
			UUIText text = base.GetText(1);
			if (!string.IsNullOrEmpty(data.AttributeTextId))
			{
				if (text != null)
				{
					text.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.AttributeTextId, Array.Empty<object>());
				return;
			}
			if (text != null)
			{
				text.SetUIActive(false);
			}
		}

		// Token: 0x06041A14 RID: 268820 RVA: 0x010D404B File Offset: 0x010D224B
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x0200C6CE RID: 50894
		private static class EItemComponent
		{
			// Token: 0x0403D369 RID: 250729
			public const int IconTexture = 0;

			// Token: 0x0403D36A RID: 250730
			public const int AttributeText = 1;
		}
	}
}
