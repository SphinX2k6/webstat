using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.MapMarkToggle
{
	// Token: 0x02004B9F RID: 19359
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MapMarkToggleItem : GridProxyAbstract<IMapMarkToggleItemData>
	{
		// Token: 0x060328C2 RID: 207042 RVA: 0x00CA7578 File Offset: 0x00CA5778
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060328C3 RID: 207043 RVA: 0x00CA7620 File Offset: 0x00CA5820
		[NullableContext(1)]
		public override void Refresh(IMapMarkToggleItemData data, bool isSelected, int gridIndex)
		{
			this.DataParam = data;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				UUIExtendToggle uuiextendToggle = extendToggle;
				Func<EToggleState> getToggleResultCallback = data.GetToggleResultCallback;
				uuiextendToggle.SetToggleState((getToggleResultCallback != null) ? getToggleResultCallback() : EToggleState.ETT_UnChecked, false, false, false);
			}
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(data.NameId);
		}

		// Token: 0x060328C4 RID: 207044 RVA: 0x00CA7672 File Offset: 0x00CA5872
		private void OnToggle(EToggleState state)
		{
			IMapMarkToggleItemData dataParam = this.DataParam;
			if (dataParam == null)
			{
				return;
			}
			Func<EToggleState, bool> setToggleStateCallback = dataParam.SetToggleStateCallback;
			if (setToggleStateCallback == null)
			{
				return;
			}
			setToggleStateCallback(state);
		}

		// Token: 0x0401D786 RID: 120710
		[Nullable(2)]
		private IMapMarkToggleItemData DataParam;

		// Token: 0x0200AC7B RID: 44155
		public static class EChildType
		{
			// Token: 0x040359DC RID: 219612
			public const int Toggle = 0;

			// Token: 0x040359DD RID: 219613
			public const int TxtName = 1;
		}
	}
}
