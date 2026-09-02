using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200515E RID: 20830
	public class RoguelikeActivityNormalInstButton : UiPanelBase
	{
		// Token: 0x060359C8 RID: 219592 RVA: 0x00D774C4 File Offset: 0x00D756C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonCallback));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060359C9 RID: 219593 RVA: 0x00D775AC File Offset: 0x00D757AC
		private void ButtonCallback()
		{
			Action buttonCallbackInternal = this.ButtonCallbackInternal;
			if (buttonCallbackInternal == null)
			{
				return;
			}
			buttonCallbackInternal();
		}

		// Token: 0x060359CA RID: 219594 RVA: 0x00D775BE File Offset: 0x00D757BE
		[NullableContext(1)]
		public void SetButtonCallback(Action callback)
		{
			this.ButtonCallbackInternal = callback;
		}

		// Token: 0x060359CB RID: 219595 RVA: 0x00D775C7 File Offset: 0x00D757C7
		public void SetProcessingState(bool bVisible)
		{
			base.GetItem(3).SetUIActive(bVisible);
		}

		// Token: 0x0401ECAC RID: 126124
		[Nullable(2)]
		private Action ButtonCallbackInternal;

		// Token: 0x0200B10D RID: 45325
		private class EComponents
		{
			// Token: 0x04036EB2 RID: 224946
			public const int BtnConfirm = 0;

			// Token: 0x04036EB3 RID: 224947
			public const int TxtConfirm = 1;

			// Token: 0x04036EB4 RID: 224948
			public const int ItemRedDot = 2;

			// Token: 0x04036EB5 RID: 224949
			public const int PanelProcessing = 3;
		}
	}
}
