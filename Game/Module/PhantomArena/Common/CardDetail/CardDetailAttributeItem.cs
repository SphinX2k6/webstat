using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x0200556A RID: 21866
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CardDetailAttributeItem : GridProxyAbstract<CardDetailAttributeItemData>
	{
		// Token: 0x06037BBE RID: 228286 RVA: 0x00E2173C File Offset: 0x00E1F93C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x06037BBF RID: 228287 RVA: 0x00E21798 File Offset: 0x00E1F998
		public override void Refresh(CardDetailAttributeItemData data, bool isSelected, int gridIndex)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.AttributeName, Array.Empty<object>());
			base.GetText(2).SetText(data.AttributeValue.ToString(), true);
			this.RefreshHighLightState(data.IsHighLight);
		}

		// Token: 0x06037BC0 RID: 228288 RVA: 0x00E217E8 File Offset: 0x00E1F9E8
		public void RefreshHighLightState(bool isHighLight)
		{
			if (this.IsHighLight == isHighLight)
			{
				return;
			}
			this.IsHighLight = isHighLight;
			UUISprite sprite = base.GetSprite(0);
			UUIText text = base.GetText(1);
			UUIText text2 = base.GetText(2);
			string path = isHighLight ? "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity24/SoundRemnantArena/Outside/SP_CardAttrBg1.SP_CardAttrBg1" : "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity24/SoundRemnantArena/Outside/SP_CardAttrBg2.SP_CardAttrBg2";
			this.SetSpriteByPath(path, sprite, false, null, null);
			bool flag = !isHighLight;
			UUIItem uuiitem = sprite;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(sprite.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			UUIItem uuiitem2 = text;
			bool bUseChangeColor2 = flag;
			fcolor = new FColor?(text.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
			UUIItem uuiitem3 = text2;
			bool bUseChangeColor3 = flag;
			fcolor = new FColor?(text2.changeColor);
			uuiitem3.SetChangeColor(bUseChangeColor3, fcolor);
		}

		// Token: 0x0401FE9F RID: 130719
		private const string HIGH_LIGHT_BG_PATH = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity24/SoundRemnantArena/Outside/SP_CardAttrBg1.SP_CardAttrBg1";

		// Token: 0x0401FEA0 RID: 130720
		private const string BG_PATH = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity24/SoundRemnantArena/Outside/SP_CardAttrBg2.SP_CardAttrBg2";

		// Token: 0x0401FEA1 RID: 130721
		private bool IsHighLight = true;

		// Token: 0x0200B518 RID: 46360
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x040380EE RID: 229614
			public const int BgSprite = 0;

			// Token: 0x040380EF RID: 229615
			public const int AttributeNameText = 1;

			// Token: 0x040380F0 RID: 229616
			public const int AttributeValueText = 2;
		}
	}
}
