using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Shop
{
	// Token: 0x02004FDA RID: 20442
	public class SheriffShopMenuItem : GridProxyAbstract<int>
	{
		// Token: 0x06034B4D RID: 215885 RVA: 0x00D37F24 File Offset: 0x00D36124
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggleItemInner));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034B4E RID: 215886 RVA: 0x00D37FCC File Offset: 0x00D361CC
		public override void Refresh(int dataId, bool isSelected, int gridIndex)
		{
			this.Level = dataId;
			string text;
			SheriffShopDefine.SheriffShopTabMenuName.TryGetValue(this.Level, out text);
			base.GetText(1).ShowTextNew(text ?? "");
		}

		// Token: 0x06034B4F RID: 215887 RVA: 0x00D38009 File Offset: 0x00D36209
		[NullableContext(1)]
		public void SetOnClickToggleItem(Action<int> onClickToggleItem)
		{
			this.OnClickToggleItem = onClickToggleItem;
		}

		// Token: 0x06034B50 RID: 215888 RVA: 0x00D38012 File Offset: 0x00D36212
		public void SetDeselect()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06034B51 RID: 215889 RVA: 0x00D38025 File Offset: 0x00D36225
		public void SetSelect()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x06034B52 RID: 215890 RVA: 0x00D38038 File Offset: 0x00D36238
		private void OnClickToggleItemInner(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Action<int> onClickToggleItem = this.OnClickToggleItem;
				if (onClickToggleItem == null)
				{
					return;
				}
				onClickToggleItem(this.Level);
			}
		}

		// Token: 0x0401E60C RID: 124428
		public int Level;

		// Token: 0x0401E60D RID: 124429
		[Nullable(2)]
		private Action<int> OnClickToggleItem;

		// Token: 0x0200AFA7 RID: 44967
		private class EMenuComponents
		{
			// Token: 0x04036826 RID: 223270
			public const int ToggleItem = 0;

			// Token: 0x04036827 RID: 223271
			public const int TextTitle = 1;
		}
	}
}
