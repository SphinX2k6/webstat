using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006EF9 RID: 28409
	[NullableContext(1)]
	[Nullable(0)]
	internal class TabItem : GridProxyAbstract<int>
	{
		// Token: 0x06044D85 RID: 281989 RVA: 0x011EA074 File Offset: 0x011E8274
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06044D86 RID: 281990 RVA: 0x011EA13B File Offset: 0x011E833B
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.TabIndex = data;
		}

		// Token: 0x06044D87 RID: 281991 RVA: 0x011EA144 File Offset: 0x011E8344
		private void OnClickToggle(EToggleState _)
		{
			Action<int> onTabClickCallBack = this.OnTabClickCallBack;
			if (onTabClickCallBack == null)
			{
				return;
			}
			onTabClickCallBack(this.TabIndex);
		}

		// Token: 0x06044D88 RID: 281992 RVA: 0x011EA15C File Offset: 0x011E835C
		public void SetTabClickCallback(Action<int> callback)
		{
			this.OnTabClickCallBack = callback;
		}

		// Token: 0x06044D89 RID: 281993 RVA: 0x011EA165 File Offset: 0x011E8365
		public void SetTabNameKey(string key)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), key, Array.Empty<object>());
		}

		// Token: 0x06044D8A RID: 281994 RVA: 0x011EA17E File Offset: 0x011E837E
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleSelect(false, false);
		}

		// Token: 0x06044D8B RID: 281995 RVA: 0x011EA188 File Offset: 0x011E8388
		public void SetToggleSelect(bool isSelected, bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x040265A8 RID: 157096
		private int TabIndex = -1;

		// Token: 0x040265A9 RID: 157097
		[Nullable(2)]
		private Action<int> OnTabClickCallBack;
	}
}
