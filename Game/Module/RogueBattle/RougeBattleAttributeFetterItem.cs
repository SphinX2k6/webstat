using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051E9 RID: 20969
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RougeBattleAttributeFetterItem : GridProxyAbstract<IRogueBattleMapAttrFettersInfo>
	{
		// Token: 0x06035D6A RID: 220522 RVA: 0x00D8C04C File Offset: 0x00D8A24C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIExtendToggle))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickToggle))
			};
		}

		// Token: 0x06035D6B RID: 220523 RVA: 0x00D8C0CC File Offset: 0x00D8A2CC
		public override void Refresh(IRogueBattleMapAttrFettersInfo data, bool isSelected, int gridIndex)
		{
			this.BondId = data.ConfigId;
			UUIText text = base.GetText(1);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Lv.");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.Level);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			base.SetTextureByPath(ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(data.ConfigId).Value.Icon, base.GetTexture(0), null, null);
		}

		// Token: 0x06035D6C RID: 220524 RVA: 0x00D8C158 File Offset: 0x00D8A358
		private void OnClickToggle(EToggleState state)
		{
			ModelBase<RogueBattleModel>.Instance.CurrentMapSummaryBond = this.BondId;
			ModelBase<RogueBattleModel>.Instance.IsMapSummaryBondJumping = true;
			Singleton<EventSystem>.Instance.Emit(EEventName.RogueResMapSummaryTeamToBondUpdate);
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0401EE73 RID: 126579
		private int BondId;
	}
}
