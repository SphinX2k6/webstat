using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x020056FC RID: 22268
	public class MoraleAreaInfoFlagDescPanel : UiPanelBase
	{
		// Token: 0x06038AAB RID: 232107 RVA: 0x00E59674 File Offset: 0x00E57874
		[NullableContext(1)]
		public UniTask Init(UUIItem item)
		{
			MoraleAreaInfoFlagDescPanel.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleAreaInfoFlagDescPanel.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038AAC RID: 232108 RVA: 0x00E596C0 File Offset: 0x00E578C0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnMask));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06038AAD RID: 232109 RVA: 0x00E59787 File Offset: 0x00E57987
		[NullableContext(1)]
		public void UpdateDesc(string descKey)
		{
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(descKey);
		}

		// Token: 0x06038AAE RID: 232110 RVA: 0x00E5979B File Offset: 0x00E5799B
		private void OnBtnMask()
		{
			this.SetActive(false);
		}

		// Token: 0x0200B76E RID: 46958
		private enum EChildType
		{
			// Token: 0x04038BB9 RID: 232377
			BtnMask,
			// Token: 0x04038BBA RID: 232378
			ItemRoot,
			// Token: 0x04038BBB RID: 232379
			TextDesc
		}
	}
}
