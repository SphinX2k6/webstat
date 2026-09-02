using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054F0 RID: 21744
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DeckBuilderCardInfoTabItem : GridProxyAbstract<DeckBuilderCardInfoTabItemData>
	{
		// Token: 0x06037685 RID: 226949 RVA: 0x00E0EE68 File Offset: 0x00E0D068
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnItemToggleStateChange))
			};
		}

		// Token: 0x06037686 RID: 226950 RVA: 0x00E0EECF File Offset: 0x00E0D0CF
		private void OnItemToggleStateChange(EToggleState toggleState)
		{
			if (base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_Checked)
			{
				Action<int> onSelect = this.Data.OnSelect;
				if (onSelect == null)
				{
					return;
				}
				onSelect(this.Data.TabIndex);
			}
		}

		// Token: 0x06037687 RID: 226951 RVA: 0x00E0EF00 File Offset: 0x00E0D100
		[NullableContext(1)]
		public override void Refresh(DeckBuilderCardInfoTabItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TabNameTextId, Array.Empty<object>());
		}

		// Token: 0x06037688 RID: 226952 RVA: 0x00E0EF25 File Offset: 0x00E0D125
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x06037689 RID: 226953 RVA: 0x00E0EF38 File Offset: 0x00E0D138
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x0401FCF2 RID: 130290
		[Nullable(2)]
		private DeckBuilderCardInfoTabItemData Data;

		// Token: 0x0200B46C RID: 46188
		private static class EComponents
		{
			// Token: 0x04037DA0 RID: 228768
			public const int ItemToggle = 0;

			// Token: 0x04037DA1 RID: 228769
			public const int NameText = 1;
		}
	}
}
