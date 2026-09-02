using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x020056AA RID: 22186
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueTaskTabItem : GridProxyAbstract<RogueTaskRewardTabData>
	{
		// Token: 0x0603878E RID: 231310 RVA: 0x00E4EE7C File Offset: 0x00E4D07C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnTabToggle))
			};
		}

		// Token: 0x0603878F RID: 231311 RVA: 0x00E4EEFC File Offset: 0x00E4D0FC
		public void SetToggleState(bool bSelect, bool bFire)
		{
			EToggleState state = bSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(1).SetToggleState(state, bFire, false, false);
		}

		// Token: 0x06038790 RID: 231312 RVA: 0x00E4EF22 File Offset: 0x00E4D122
		private void SetRedDotVisible(bool bVisible)
		{
			base.GetItem(2).SetUIActive(bVisible);
		}

		// Token: 0x06038791 RID: 231313 RVA: 0x00E4EF34 File Offset: 0x00E4D134
		public void RefreshRedDot()
		{
			RogueTaskRewardTabData tabData = this.TabData;
			bool? flag;
			if (tabData == null)
			{
				flag = null;
			}
			else
			{
				Func<int, bool> refreshRedDot = tabData.RefreshRedDot;
				flag = ((refreshRedDot != null) ? new bool?(refreshRedDot(this.TabIndex)) : null);
			}
			bool? flag2 = flag;
			bool valueOrDefault = flag2.GetValueOrDefault();
			this.SetRedDotVisible(valueOrDefault);
		}

		// Token: 0x06038792 RID: 231314 RVA: 0x00E4EF8A File Offset: 0x00E4D18A
		public override void Refresh(RogueTaskRewardTabData data, bool isSelected, int gridIndex)
		{
			this.TabData = data;
			this.TabIndex = data.Index;
			if (data.NameTextId != null)
			{
				UUIText text = base.GetText(0);
				if (text != null)
				{
					text.ShowTextNew(data.NameTextId);
				}
			}
			this.RefreshRedDot();
		}

		// Token: 0x06038793 RID: 231315 RVA: 0x00E4EFC5 File Offset: 0x00E4D1C5
		private void OnTabToggle(EToggleState state)
		{
			RogueTaskRewardTabData tabData = this.TabData;
			if (tabData == null)
			{
				return;
			}
			Action<int> clickedCallback = tabData.ClickedCallback;
			if (clickedCallback == null)
			{
				return;
			}
			clickedCallback(this.TabIndex);
		}

		// Token: 0x040203F6 RID: 132086
		[Nullable(2)]
		private RogueTaskRewardTabData TabData;

		// Token: 0x040203F7 RID: 132087
		private int TabIndex = -1;
	}
}
