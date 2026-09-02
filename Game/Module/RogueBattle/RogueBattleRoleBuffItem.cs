using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005206 RID: 20998
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleRoleBuffItem : GridProxyAbstract<RogueResGainData>
	{
		// Token: 0x06035DCC RID: 220620 RVA: 0x00D8E218 File Offset: 0x00D8C418
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickExtendToggle)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickBtnDetail))
			};
		}

		// Token: 0x06035DCD RID: 220621 RVA: 0x00D8E2EF File Offset: 0x00D8C4EF
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RogueBattleDescModeChange, new Action(this.RefreshDescText));
		}

		// Token: 0x06035DCE RID: 220622 RVA: 0x00D8E30D File Offset: 0x00D8C50D
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueBattleDescModeChange, new Action(this.RefreshDescText));
		}

		// Token: 0x06035DCF RID: 220623 RVA: 0x00D8E32B File Offset: 0x00D8C52B
		private void OnClickExtendToggle(EToggleState state)
		{
			Action<int> onSelectCallback = this.OnSelectCallback;
			if (onSelectCallback == null)
			{
				return;
			}
			onSelectCallback(base.GridIndex);
		}

		// Token: 0x06035DD0 RID: 220624 RVA: 0x00D8E343 File Offset: 0x00D8C543
		private void OnClickBtnDetail()
		{
			Action<int> onClickBtnDetailCallback = this.OnClickBtnDetailCallback;
			if (onClickBtnDetailCallback == null)
			{
				return;
			}
			onClickBtnDetailCallback(base.GridIndex);
		}

		// Token: 0x06035DD1 RID: 220625 RVA: 0x00D8E35C File Offset: 0x00D8C55C
		[NullableContext(1)]
		public override void Refresh(RogueResGainData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			RogueResCharacterBuff? rogueResCharacterBuff = ConfigBase<RogueBattleConfig>.Instance.GetRogueResCharacterBuff(data.RogueResRoleBuff.ConfigId);
			if (rogueResCharacterBuff == null)
			{
				return;
			}
			this.RefreshDescText();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rogueResCharacterBuff.Value.AffixTitle, Array.Empty<object>());
			base.GetSprite(2).SetUIActive(false);
			this.SetSpriteByPath(rogueResCharacterBuff.Value.AffixIcon, base.GetSprite(2), false, null, delegate(bool result)
			{
				if (result)
				{
					base.GetSprite(2).SetUIActive(true);
				}
			});
			base.GetItem(4).SetUIActive(data.RogueResRoleBuff.IsNew);
		}

		// Token: 0x06035DD2 RID: 220626 RVA: 0x00D8E414 File Offset: 0x00D8C614
		private void RefreshDescText()
		{
			if (this.Data == null)
			{
				return;
			}
			RogueResCharacterBuff? rogueResCharacterBuff = ConfigBase<RogueBattleConfig>.Instance.GetRogueResCharacterBuff(this.Data.RogueResRoleBuff.ConfigId);
			if (rogueResCharacterBuff == null)
			{
				return;
			}
			if (ModelBase<RogueBattleModel>.Instance.DescMode == EDescModel.SIMPLE)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rogueResCharacterBuff.Value.AffixDescSimple, Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rogueResCharacterBuff.Value.AffixDesc, rogueResCharacterBuff.Value.AffixDescParam());
		}

		// Token: 0x06035DD3 RID: 220627 RVA: 0x00D8E4B0 File Offset: 0x00D8C6B0
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x06035DD4 RID: 220628 RVA: 0x00D8E4C3 File Offset: 0x00D8C6C3
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06035DD5 RID: 220629 RVA: 0x00D8E4D8 File Offset: 0x00D8C6D8
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "FirstBuffDetail"))
			{
				return null;
			}
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				item,
				item
			};
		}

		// Token: 0x0401EEE3 RID: 126691
		private RogueResGainData Data;

		// Token: 0x0401EEE4 RID: 126692
		public Action<int> OnSelectCallback;

		// Token: 0x0401EEE5 RID: 126693
		public Action<int> OnClickBtnDetailCallback;
	}
}
