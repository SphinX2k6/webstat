using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E10 RID: 19984
	public class TrapDefenseBuildingDevelopNormalDragItem : UiPanelBase
	{
		// Token: 0x06033AD9 RID: 211673 RVA: 0x00CEA120 File Offset: 0x00CE8320
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIDraggableComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033ADA RID: 211674 RVA: 0x00CEA1AC File Offset: 0x00CE83AC
		[NullableContext(1)]
		public void UpdateItem(TrapDefenseBuildingDevelopItemData data)
		{
			base.SetTextureByPath(data.GetIconPath(), base.GetTexture(0), null, null);
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(false);
		}

		// Token: 0x06033ADB RID: 211675 RVA: 0x00CEA1E8 File Offset: 0x00CE83E8
		[NullableContext(1)]
		public UUIDraggableComponent GetDraggableComp()
		{
			return base.GetDraggable(1);
		}

		// Token: 0x0200AD85 RID: 44421
		private class ENormalDrag
		{
			// Token: 0x04035E39 RID: 220729
			public const int Icon = 0;

			// Token: 0x04035E3A RID: 220730
			public const int Draggable = 1;

			// Token: 0x04035E3B RID: 220731
			public const int Cost = 2;
		}
	}
}
