using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005204 RID: 20996
	public class RogueBattleRoleAffixDetailToggle : GridProxyAbstract<int>
	{
		// Token: 0x06035DC6 RID: 220614 RVA: 0x00D8E101 File Offset: 0x00D8C301
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIExtendToggle))
			};
		}

		// Token: 0x06035DC7 RID: 220615 RVA: 0x00D8E13A File Offset: 0x00D8C33A
		private void OnClickExtendToggle(EToggleState _)
		{
			Action<int> onSelectCallback = this.OnSelectCallback;
			if (onSelectCallback == null)
			{
				return;
			}
			onSelectCallback(base.GridIndex);
		}

		// Token: 0x06035DC8 RID: 220616 RVA: 0x00D8E154 File Offset: 0x00D8C354
		public override void Refresh(int id, bool isSelected, int gridIndex)
		{
			this.Id = id;
			RogueResCharacterBuff? rogueResCharacterBuff = ConfigBase<RogueBattleConfig>.Instance.GetRogueResCharacterBuff(id);
			if (rogueResCharacterBuff == null)
			{
				return;
			}
			this.SetSpriteByPath(rogueResCharacterBuff.Value.AffixIcon, base.GetSprite(0), false, null, null);
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(1);
			extendToggle2.OnStateChange.Clear();
			extendToggle2.OnStateChange.Add(new Action<EToggleState>(this.OnClickExtendToggle));
		}

		// Token: 0x06035DC9 RID: 220617 RVA: 0x00D8E1EA File Offset: 0x00D8C3EA
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x06035DCA RID: 220618 RVA: 0x00D8E1FD File Offset: 0x00D8C3FD
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0401EEDA RID: 126682
		public int Id;

		// Token: 0x0401EEDB RID: 126683
		[Nullable(2)]
		public Action<int> OnSelectCallback;
	}
}
