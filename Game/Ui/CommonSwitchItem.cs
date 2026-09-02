using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049C4 RID: 18884
	public class CommonSwitchItem : UiPanelBase
	{
		// Token: 0x0603165A RID: 202330 RVA: 0x00C4A980 File Offset: 0x00C48B80
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleStateChange));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603165B RID: 202331 RVA: 0x00C4AA26 File Offset: 0x00C48C26
		protected override void OnStart()
		{
			base.GetExtendToggle(0).SetToggleGroup(null);
		}

		// Token: 0x0603165C RID: 202332 RVA: 0x00C4AA38 File Offset: 0x00C48C38
		public void SetToggleState(bool bOpen)
		{
			EToggleState state = bOpen ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x0603165D RID: 202333 RVA: 0x00C4AA5D File Offset: 0x00C48C5D
		[NullableContext(2)]
		public void SetOnStateChangedCallback(Action<EToggleState> callback)
		{
			this.OnStateChangedInternal = callback;
		}

		// Token: 0x0603165E RID: 202334 RVA: 0x00C4AA66 File Offset: 0x00C48C66
		private void OnToggleStateChange(EToggleState state)
		{
			Action<EToggleState> onStateChangedInternal = this.OnStateChangedInternal;
			if (onStateChangedInternal == null)
			{
				return;
			}
			onStateChangedInternal(state);
		}

		// Token: 0x0603165F RID: 202335 RVA: 0x00C4AA7C File Offset: 0x00C48C7C
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			if (configParams[0] == "SwitchItem")
			{
				UUIItem rootComponent = base.GetExtendToggle(0).GetRootComponent();
				UUIItem rootItem = base.GetRootItem();
				if (rootComponent != null && rootItem != null)
				{
					return new UUIItem[]
					{
						rootComponent,
						rootItem
					};
				}
			}
			return null;
		}

		// Token: 0x0401C5F4 RID: 116212
		[Nullable(2)]
		private Action<EToggleState> OnStateChangedInternal;

		// Token: 0x0200AA44 RID: 43588
		private class EChildType
		{
			// Token: 0x04034AF8 RID: 215800
			public const int SwitchToggle = 0;

			// Token: 0x04034AF9 RID: 215801
			public const int TitleText = 1;
		}
	}
}
