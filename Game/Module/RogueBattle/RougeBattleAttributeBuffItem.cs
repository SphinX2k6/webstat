using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051E5 RID: 20965
	public class RougeBattleAttributeBuffItem : GridProxyAbstract<int>
	{
		// Token: 0x06035D5F RID: 220511 RVA: 0x00D8BC8C File Offset: 0x00D89E8C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUISprite)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(12, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(11, new Action<EToggleState>(this.OnClick))
			};
		}

		// Token: 0x06035D60 RID: 220512 RVA: 0x00D8BDEC File Offset: 0x00D89FEC
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.BuffId = data;
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.SetSpriteByPath(ConfigBase<RogueBattleConfig>.Instance.GetRogueResCharacterBuff(this.BuffId).Value.AffixIcon, base.GetSprite(9), false, null, null);
		}

		// Token: 0x06035D61 RID: 220513 RVA: 0x00D8BE4D File Offset: 0x00D8A04D
		private void OnClick(EToggleState state)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(11);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			Action<int> onClickCall = this.OnClickCall;
			if (onClickCall == null)
			{
				return;
			}
			onClickCall(this.BuffId);
		}

		// Token: 0x0401EE65 RID: 126565
		private int BuffId;

		// Token: 0x0401EE66 RID: 126566
		[Nullable(2)]
		public Action<int> OnClickCall;
	}
}
