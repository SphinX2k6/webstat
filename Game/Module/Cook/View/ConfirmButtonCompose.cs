using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E14 RID: 24084
	[NullableContext(1)]
	[Nullable(0)]
	public class ConfirmButtonCompose : UiPanelBase
	{
		// Token: 0x0603C99A RID: 248218 RVA: 0x00F636E7 File Offset: 0x00F618E7
		public ConfirmButtonCompose(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603C99B RID: 248219 RVA: 0x00F636FC File Offset: 0x00F618FC
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

		// Token: 0x0603C99C RID: 248220 RVA: 0x00F637A2 File Offset: 0x00F619A2
		public void UpdateText(string text)
		{
			base.GetText(1).SetText(text, true);
		}

		// Token: 0x0603C99D RID: 248221 RVA: 0x00F637B2 File Offset: 0x00F619B2
		public void RefreshButton(bool isEnable)
		{
			((base.GetButton(0).GetOwner() as AUIBaseActor).GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup).SetInteractable(isEnable);
		}

		// Token: 0x0603C99E RID: 248222 RVA: 0x00F637DF File Offset: 0x00F619DF
		public void BindClickFunction(Action onClickFunction)
		{
			this.OnClickFunction = onClickFunction;
		}

		// Token: 0x0603C99F RID: 248223 RVA: 0x00F637E8 File Offset: 0x00F619E8
		private void OnClick()
		{
			Action onClickFunction = this.OnClickFunction;
			if (onClickFunction == null)
			{
				return;
			}
			onClickFunction();
		}

		// Token: 0x040220EA RID: 139498
		[Nullable(2)]
		private Action OnClickFunction;

		// Token: 0x0200BE4B RID: 48715
		[NullableContext(0)]
		private enum EConfirmDefine
		{
			// Token: 0x0403A961 RID: 239969
			ConfirmButton,
			// Token: 0x0403A962 RID: 239970
			ConfirmText
		}
	}
}
