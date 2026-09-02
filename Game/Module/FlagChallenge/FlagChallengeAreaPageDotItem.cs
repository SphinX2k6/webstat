using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D4B RID: 23883
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FlagChallengeAreaPageDotItem : GridProxyAbstract<IFlagChallengeAreaPageDotItemData>
	{
		// Token: 0x0603C355 RID: 246613 RVA: 0x00F45669 File Offset: 0x00F43869
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle))
			};
		}

		// Token: 0x0603C356 RID: 246614 RVA: 0x00F4568C File Offset: 0x00F4388C
		protected override void OnStart()
		{
			base.GetExtendToggle(0).SetSelfInteractive(false);
		}

		// Token: 0x0603C357 RID: 246615 RVA: 0x00F4569C File Offset: 0x00F4389C
		public override void Refresh(IFlagChallengeAreaPageDotItemData data, bool isSelected, int gridIndex)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			EToggleState state = data.IsHighlight ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			extendToggle.SetToggleStateForce(state, false, false, false);
		}
	}
}
