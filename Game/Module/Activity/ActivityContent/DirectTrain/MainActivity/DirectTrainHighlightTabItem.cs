using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity
{
	// Token: 0x02006953 RID: 26963
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DirectTrainHighlightTabItem : GridProxyAbstract<IHighlightTabData>
	{
		// Token: 0x06042E90 RID: 274064 RVA: 0x0112CD20 File Offset: 0x0112AF20
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06042E91 RID: 274065 RVA: 0x0112CDC6 File Offset: 0x0112AFC6
		public void SetOnSelectCallback(Action<IHighlightTabData> callback)
		{
			this.OnSelectCallback = callback;
		}

		// Token: 0x06042E92 RID: 274066 RVA: 0x0112CDCF File Offset: 0x0112AFCF
		public override void Refresh(IHighlightTabData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TabTitle, Array.Empty<object>());
			this.RefreshToggleState(isSelected);
		}

		// Token: 0x06042E93 RID: 274067 RVA: 0x0112CDFB File Offset: 0x0112AFFB
		public override object GetKey(IHighlightTabData data, int displayIndex)
		{
			return data.Id;
		}

		// Token: 0x06042E94 RID: 274068 RVA: 0x0112CE08 File Offset: 0x0112B008
		public override void OnSelected(bool fireEvent)
		{
			this.RefreshToggleState(true);
			if (fireEvent && this.Data != null)
			{
				Action<IHighlightTabData> onSelectCallback = this.OnSelectCallback;
				if (onSelectCallback == null)
				{
					return;
				}
				onSelectCallback(this.Data);
			}
		}

		// Token: 0x06042E95 RID: 274069 RVA: 0x0112CE32 File Offset: 0x0112B032
		public override void OnDeselected(bool fireEvent)
		{
			this.RefreshToggleState(false);
		}

		// Token: 0x06042E96 RID: 274070 RVA: 0x0112CE3C File Offset: 0x0112B03C
		public void RefreshToggleState(bool isSelected)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
		}

		// Token: 0x06042E97 RID: 274071 RVA: 0x0112CE65 File Offset: 0x0112B065
		private void OnToggleClick(EToggleState _)
		{
			if (this.Data != null)
			{
				Action<IHighlightTabData> onSelectCallback = this.OnSelectCallback;
				if (onSelectCallback == null)
				{
					return;
				}
				onSelectCallback(this.Data);
			}
		}

		// Token: 0x04025467 RID: 152679
		[Nullable(2)]
		private IHighlightTabData Data;

		// Token: 0x04025468 RID: 152680
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IHighlightTabData> OnSelectCallback;

		// Token: 0x0200C8F2 RID: 51442
		[NullableContext(0)]
		private enum EHighlightTabComponents
		{
			// Token: 0x0403DD0A RID: 253194
			Toggle,
			// Token: 0x0403DD0B RID: 253195
			Text
		}
	}
}
