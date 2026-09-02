using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C51 RID: 23633
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InfrArchiveMenuItem : GridProxyAbstract<IInfrArchiveMenuItemData>
	{
		// Token: 0x170097E4 RID: 38884
		// (get) Token: 0x0603BB57 RID: 244567 RVA: 0x00F1FFCE File Offset: 0x00F1E1CE
		public InfrastructureDefine.EInfrArchiveTabType CardType
		{
			get
			{
				return this.Data.CardType;
			}
		}

		// Token: 0x0603BB58 RID: 244568 RVA: 0x00F1FFDC File Offset: 0x00F1E1DC
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BB59 RID: 244569 RVA: 0x00F20082 File Offset: 0x00F1E282
		public override void Refresh(IInfrArchiveMenuItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			base.GetText(1).ShowTextNew(data.DesText);
		}

		// Token: 0x0603BB5A RID: 244570 RVA: 0x00F2009D File Offset: 0x00F1E29D
		public void SetToggleClickCb(Action<int> callback)
		{
			this.SelectedCallBack = callback;
		}

		// Token: 0x0603BB5B RID: 244571 RVA: 0x00F200A6 File Offset: 0x00F1E2A6
		public void SetToggleSelected(EToggleState state)
		{
			base.GetExtendToggle(0).SetToggleState(state, false, false, false);
		}

		// Token: 0x0603BB5C RID: 244572 RVA: 0x00F200B9 File Offset: 0x00F1E2B9
		private void ToggleClick(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.SelectedCallBack((int)this.Data.CardType);
				return;
			}
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x0603BB5D RID: 244573 RVA: 0x00F200EC File Offset: 0x00F1E2EC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			UUIItem uuiitem = (extendToggle != null) ? extendToggle.GetRootComponent() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x04021920 RID: 137504
		private IInfrArchiveMenuItemData Data;

		// Token: 0x04021921 RID: 137505
		public Action<int> SelectedCallBack;

		// Token: 0x0200BCC7 RID: 48327
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403A291 RID: 238225
			public const int ToggleItem = 0;

			// Token: 0x0403A292 RID: 238226
			public const int TextTitle = 1;
		}
	}
}
