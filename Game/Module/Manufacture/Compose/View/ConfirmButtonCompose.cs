using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Compose.View
{
	// Token: 0x020059CC RID: 22988
	[NullableContext(1)]
	[Nullable(0)]
	public class ConfirmButtonCompose : UiPanelBase
	{
		// Token: 0x0603A409 RID: 238601 RVA: 0x00EC3A03 File Offset: 0x00EC1C03
		public ConfirmButtonCompose(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603A40A RID: 238602 RVA: 0x00EC3A18 File Offset: 0x00EC1C18
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A40B RID: 238603 RVA: 0x00EC3ABE File Offset: 0x00EC1CBE
		public void UpdateText(string text)
		{
			base.GetText(1).SetText(text, true);
		}

		// Token: 0x0603A40C RID: 238604 RVA: 0x00EC3ACE File Offset: 0x00EC1CCE
		public void RefreshButton(bool isEnable)
		{
			((UUIInteractionGroup)((AUIBaseActor)base.GetButton(0).GetOwner()).GetComponentByClass(UUIInteractionGroup.StaticClass())).SetInteractable(isEnable);
		}

		// Token: 0x0603A40D RID: 238605 RVA: 0x00EC3AFB File Offset: 0x00EC1CFB
		public void BindClickFunction(Action onClickFunction)
		{
			this.OnClickFunction = onClickFunction;
		}

		// Token: 0x0603A40E RID: 238606 RVA: 0x00EC3B04 File Offset: 0x00EC1D04
		private void OnClick()
		{
			this.OnClickFunction();
		}

		// Token: 0x04021033 RID: 135219
		[Nullable(2)]
		private Action OnClickFunction;

		// Token: 0x0200B9A2 RID: 47522
		[NullableContext(0)]
		private class EConfirmDefine
		{
			// Token: 0x040395D1 RID: 234961
			public const int ConfirmButton = 0;

			// Token: 0x040395D2 RID: 234962
			public const int ConfirmText = 1;
		}
	}
}
