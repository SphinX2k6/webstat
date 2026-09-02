using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005202 RID: 20994
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleRandomEventItem : GridProxyAbstract<RogueResGainData>
	{
		// Token: 0x06035DC0 RID: 220608 RVA: 0x00D8E004 File Offset: 0x00D8C204
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnBtnExtendToggle))
			};
		}

		// Token: 0x06035DC1 RID: 220609 RVA: 0x00D8E081 File Offset: 0x00D8C281
		private void OnBtnExtendToggle(EToggleState state)
		{
			if (base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_Checked)
			{
				IScrollViewDelegate<IGridProxy<RogueResGainData>, RogueResGainData> scrollViewDelegate = base.ScrollViewDelegate;
				if (scrollViewDelegate == null)
				{
					return;
				}
				scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, true);
			}
		}

		// Token: 0x06035DC2 RID: 220610 RVA: 0x00D8E0AF File Offset: 0x00D8C2AF
		public override void Refresh(RogueResGainData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
		}

		// Token: 0x06035DC3 RID: 220611 RVA: 0x00D8E0B8 File Offset: 0x00D8C2B8
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
			ModelBase<RogueBattleModel>.Instance.SelectGainData = this.Data;
		}

		// Token: 0x06035DC4 RID: 220612 RVA: 0x00D8E0DB File Offset: 0x00D8C2DB
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			ModelBase<RogueBattleModel>.Instance.SelectGainData = null;
		}

		// Token: 0x0401EED6 RID: 126678
		[Nullable(2)]
		public RogueResGainData Data;
	}
}
