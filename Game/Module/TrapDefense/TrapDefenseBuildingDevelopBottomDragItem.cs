using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E0F RID: 19983
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBuildingDevelopBottomDragItem : UiPanelBase
	{
		// Token: 0x06033AD3 RID: 211667 RVA: 0x00CE9FC8 File Offset: 0x00CE81C8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIDraggableComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033AD4 RID: 211668 RVA: 0x00CEA074 File Offset: 0x00CE8274
		public void Refresh(TrapDefenseBuildingDevelopItemData data)
		{
			this.Data = data;
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			UUITexture texture = base.GetTexture(2);
			if (texture != null)
			{
				texture.SetUIActive(data != null);
			}
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			if (data == null)
			{
				return;
			}
			base.SetTextureByPath(data.GetIconPath(), base.GetTexture(2), null, null);
		}

		// Token: 0x06033AD5 RID: 211669 RVA: 0x00CEA0E5 File Offset: 0x00CE82E5
		public UUIDraggableComponent GetDraggableComp()
		{
			return base.GetDraggable(0);
		}

		// Token: 0x06033AD6 RID: 211670 RVA: 0x00CEA0EE File Offset: 0x00CE82EE
		public void OnStartDrag()
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(true);
		}

		// Token: 0x06033AD7 RID: 211671 RVA: 0x00CEA102 File Offset: 0x00CE8302
		public void OnEndDrag()
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(false);
		}

		// Token: 0x0401DEDB RID: 122587
		protected TrapDefenseBuildingDevelopItemData Data;

		// Token: 0x0200AD84 RID: 44420
		[NullableContext(0)]
		private class EDefine
		{
			// Token: 0x04035E35 RID: 220725
			public const int Item = 0;

			// Token: 0x04035E36 RID: 220726
			public const int SpriteBg = 1;

			// Token: 0x04035E37 RID: 220727
			public const int TextureIcon = 2;

			// Token: 0x04035E38 RID: 220728
			public const int Txt = 3;
		}
	}
}
