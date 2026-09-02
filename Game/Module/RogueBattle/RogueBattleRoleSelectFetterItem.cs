using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005208 RID: 21000
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleRoleSelectFetterItem : GridProxyAbstract<RoleBondInfo>
	{
		// Token: 0x06035DD8 RID: 220632 RVA: 0x00D8E534 File Offset: 0x00D8C734
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleSelect))
			};
		}

		// Token: 0x06035DD9 RID: 220633 RVA: 0x00D8E5E0 File Offset: 0x00D8C7E0
		public override void Refresh(RoleBondInfo bondInfo, bool isSelected, int gridIndex)
		{
			int configId = bondInfo.ConfigId;
			RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(configId);
			this.BondInfo = bondInfo;
			int level = bondInfo.Level;
			RogueResBondLv? bondLvConfigByLv = ConfigBase<RogueBattleConfig>.Instance.GetBondLvConfigByLv(level);
			if (rogueResBond == null || bondLvConfigByLv == null)
			{
				return;
			}
			UUITexture texture = base.GetTexture(2);
			UUIText text = base.GetText(3);
			UUIText text2 = base.GetText(4);
			UUIItem uuiitem = texture;
			bool bUseChangeColor = level == 0 && !isSelected;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			base.SetTextureShowUntilLoaded(rogueResBond.Value.Icon, texture, null);
			UUISprite sprite = base.GetSprite(1);
			FColor color = FColor.FromHex(bondLvConfigByLv.Value.LvColor);
			sprite.SetColor(color);
			sprite.SetUIActive(level > 0 && !isSelected);
			text.SetColor(color);
			text2.SetColor(color);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RogueResSynergyLV", new <>z__ReadOnlySingleElementList<object>(level));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, rogueResBond.Value.Name, Array.Empty<object>());
		}

		// Token: 0x06035DDA RID: 220634 RVA: 0x00D8E707 File Offset: 0x00D8C907
		private void OnToggleSelect(EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			Action<RoleBondInfo> onToggleClick = this.OnToggleClick;
			if (onToggleClick == null)
			{
				return;
			}
			onToggleClick(this.BondInfo);
		}

		// Token: 0x06035DDB RID: 220635 RVA: 0x00D8E724 File Offset: 0x00D8C924
		public override void OnSelected(bool fireEvent)
		{
			UUIItem sprite = base.GetSprite(1);
			UUITexture texture = base.GetTexture(2);
			UUIItem uuiitem = texture;
			bool bUseChangeColor = false;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			sprite.SetUIActive(false);
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x06035DDC RID: 220636 RVA: 0x00D8E76C File Offset: 0x00D8C96C
		public override void OnDeselected(bool fireEvent)
		{
			int level = this.BondInfo.Level;
			UUIItem sprite = base.GetSprite(1);
			UUITexture texture = base.GetTexture(2);
			sprite.SetUIActive(level > 0);
			UUIItem uuiitem = texture;
			bool bUseChangeColor = level == 0;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x06035DDD RID: 220637 RVA: 0x00D8E7C6 File Offset: 0x00D8C9C6
		public override object GetKey(RoleBondInfo data, int displayIndex)
		{
			return data.ConfigId;
		}

		// Token: 0x0401EEEC RID: 126700
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<RoleBondInfo> OnToggleClick;

		// Token: 0x0401EEED RID: 126701
		private RoleBondInfo BondInfo;
	}
}
