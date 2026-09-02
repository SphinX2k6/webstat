using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x0200550A RID: 21770
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DeckBuilderSortFilterItem : GridProxyAbstract<IDeckBuilderSortFilterItemData>
	{
		// Token: 0x060377DC RID: 227292 RVA: 0x00E120F4 File Offset: 0x00E102F4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIExtendToggle))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.ToggleEvent))
			};
		}

		// Token: 0x060377DD RID: 227293 RVA: 0x00E1215B File Offset: 0x00E1035B
		private void ToggleEvent(EToggleState toggleState)
		{
			if (base.GetExtendToggle(1).GetToggleState() == EToggleState.ETT_Checked)
			{
				Action<int> onToggleSelect = this.OnToggleSelect;
				if (onToggleSelect == null)
				{
					return;
				}
				onToggleSelect(base.GridIndex);
			}
		}

		// Token: 0x060377DE RID: 227294 RVA: 0x00E12182 File Offset: 0x00E10382
		[NullableContext(1)]
		public override void Refresh(IDeckBuilderSortFilterItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Name, Array.Empty<object>());
			if (isSelected)
			{
				this.OnSelected(false);
				return;
			}
			this.OnDeselected(false);
		}

		// Token: 0x060377DF RID: 227295 RVA: 0x00E121B9 File Offset: 0x00E103B9
		public override void OnSelected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x060377E0 RID: 227296 RVA: 0x00E121D1 File Offset: 0x00E103D1
		public override void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x0401FD69 RID: 130409
		protected IDeckBuilderSortFilterItemData Data;

		// Token: 0x0401FD6A RID: 130410
		public Action<int> OnToggleSelect;

		// Token: 0x0200B481 RID: 46209
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037E0C RID: 228876
			public const int Name = 0;

			// Token: 0x04037E0D RID: 228877
			public const int Toggle = 1;
		}
	}
}
