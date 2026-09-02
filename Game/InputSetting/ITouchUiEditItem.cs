using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007014 RID: 28692
	[NullableContext(2)]
	public interface ITouchUiEditItem
	{
		// Token: 0x1700A4D9 RID: 42201
		// (get) Token: 0x06045771 RID: 284529
		ITouchUiEditData Data { get; }

		// Token: 0x1700A4DA RID: 42202
		// (get) Token: 0x06045772 RID: 284530
		[Nullable(1)]
		UUIItem RootItem { [NullableContext(1)] get; }

		// Token: 0x06045773 RID: 284531
		void SetData(ITouchUiEditData data);

		// Token: 0x06045774 RID: 284532
		void SetOffset(float offsetX, float offsetY);

		// Token: 0x06045775 RID: 284533
		void SetScale(float scale);

		// Token: 0x06045776 RID: 284534
		void SetAlpha(float alpha);

		// Token: 0x06045777 RID: 284535
		void SetHierarchyIndex(int index);

		// Token: 0x06045778 RID: 284536
		void OnViewDestroy();

		// Token: 0x06045779 RID: 284537
		void OnDrag(ULGUIPointerEventData eventData);

		// Token: 0x0604577A RID: 284538
		void OnDragBegin(ULGUIPointerEventData eventData);

		// Token: 0x0604577B RID: 284539
		void OnDragEnd(ULGUIPointerEventData eventData);

		// Token: 0x0604577C RID: 284540
		void OnButtonPress(ULGUIPointerEventData eventData);

		// Token: 0x0604577D RID: 284541
		void OnButtonRelease(ULGUIPointerEventData eventData);

		// Token: 0x0604577E RID: 284542
		void OnExtendToggleStateChanged(EToggleState state);

		// Token: 0x0604577F RID: 284543
		bool OnCheckCanExecuteChange();

		// Token: 0x06045780 RID: 284544
		bool IsEdited();
	}
}
