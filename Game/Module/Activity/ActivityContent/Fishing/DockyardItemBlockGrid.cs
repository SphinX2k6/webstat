using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067B5 RID: 26549
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DockyardItemBlockGrid : GridProxyAbstract<IPanelPos>
	{
		// Token: 0x060423A1 RID: 271265 RVA: 0x010FD73C File Offset: 0x010FB93C
		protected unsafe override void OnRegisterComponent()
		{
			this.ParentItem = (this.OpenParam as DockyardItemBlock);
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIDraggableComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060423A2 RID: 271266 RVA: 0x010FD7B8 File Offset: 0x010FB9B8
		private void InitDrag()
		{
			this.DraggableComponent = base.GetDraggable(1);
			this.DraggableComponent.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.ParentItem.OnPointerDown));
			this.DraggableComponent.OnPointerCancelCallBack.Bind(new Action<ULGUIPointerEventData>(this.ParentItem.OnPointerUp));
			this.DraggableComponent.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.ParentItem.OnPointerUp));
			this.DraggableComponent.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.ParentItem.OnDragBegin));
			this.DraggableComponent.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.ParentItem.OnDrag));
			this.DraggableComponent.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.ParentItem.OnDragEnd));
		}

		// Token: 0x060423A3 RID: 271267 RVA: 0x010FD898 File Offset: 0x010FBA98
		protected override void OnStart()
		{
			this.InitDrag();
			base.GetSprite(0).SetUIActive(false);
		}

		// Token: 0x060423A4 RID: 271268 RVA: 0x010FD8AD File Offset: 0x010FBAAD
		public override void Refresh(IPanelPos data, bool isSelected, int gridIndex)
		{
			this.Value = this.ParentItem.GetValueByPanelPos(data);
			this.RefreshDragItemActive(false);
		}

		// Token: 0x060423A5 RID: 271269 RVA: 0x010FD8C8 File Offset: 0x010FBAC8
		public void RefreshDragItemActive(bool isInSelectState)
		{
			this.DraggableComponent.RootUIComp.Get().SetUIActive(this.Value != 0 || isInSelectState);
		}

		// Token: 0x04024E34 RID: 151092
		private UUIDraggableComponent DraggableComponent;

		// Token: 0x04024E35 RID: 151093
		private DockyardItemBlock ParentItem;

		// Token: 0x04024E36 RID: 151094
		private int Value;

		// Token: 0x0200C7E2 RID: 51170
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D866 RID: 252006
			public const int BgSprite = 0;

			// Token: 0x0403D867 RID: 252007
			public const int DraggableItem = 1;
		}
	}
}
