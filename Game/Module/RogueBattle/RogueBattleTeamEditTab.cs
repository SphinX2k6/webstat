using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200522B RID: 21035
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleTeamEditTab : CommonTabItemBase
	{
		// Token: 0x06035E47 RID: 220743 RVA: 0x00D90C54 File Offset: 0x00D8EE54
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIExtendToggleSpriteTransition)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.ToggleClick))
			};
		}

		// Token: 0x06035E48 RID: 220744 RVA: 0x00D90CFD File Offset: 0x00D8EEFD
		protected override void OnStart()
		{
			base.OnStart();
			this.GetTabToggle().SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			base.GetItem(2).SetUIActive(false);
		}

		// Token: 0x06035E49 RID: 220745 RVA: 0x00D90D22 File Offset: 0x00D8EF22
		private void ToggleClick(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.SelectedCallBack(base.GridIndex);
			}
		}

		// Token: 0x06035E4A RID: 220746 RVA: 0x00D90D3B File Offset: 0x00D8EF3B
		protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
		{
			base.UpdateTabIcon(data.Data.GetIcon());
		}

		// Token: 0x06035E4B RID: 220747 RVA: 0x00D90D50 File Offset: 0x00D8EF50
		protected override void OnUpdateTabIcon(string iconPath)
		{
			this.SetSpriteByPath(iconPath, base.GetSprite(0), false, null, new Action<bool>(this.RefreshTransition));
		}

		// Token: 0x06035E4C RID: 220748 RVA: 0x00D90D84 File Offset: 0x00D8EF84
		protected void RefreshTransition(bool _)
		{
			UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition = base.GetUiExtendToggleSpriteTransition(3);
			if (uiExtendToggleSpriteTransition != null)
			{
				uiExtendToggleSpriteTransition.SetAllStateSprite(base.GetSprite(0).GetSprite());
			}
		}

		// Token: 0x06035E4D RID: 220749 RVA: 0x00D90DAE File Offset: 0x00D8EFAE
		protected override void OnSetToggleState(EToggleState state, bool bFire)
		{
			this.GetTabToggle().SetToggleState(state, bFire, false, false);
		}

		// Token: 0x06035E4E RID: 220750 RVA: 0x00D90DC0 File Offset: 0x00D8EFC0
		protected override UUIExtendToggle GetTabToggle()
		{
			return base.GetExtendToggle(1);
		}
	}
}
