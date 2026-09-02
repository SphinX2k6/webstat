using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051D9 RID: 20953
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleFilterDropDownItem : DropDownItemBase<RoleBondInfo>
	{
		// Token: 0x06035D42 RID: 220482 RVA: 0x00D8AEF5 File Offset: 0x00D890F5
		public RogueBattleFilterDropDownItem(UUIItem uiItem) : base(uiItem)
		{
		}

		// Token: 0x06035D43 RID: 220483 RVA: 0x00D8AF00 File Offset: 0x00D89100
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
		}

		// Token: 0x06035D44 RID: 220484 RVA: 0x00D8AF86 File Offset: 0x00D89186
		[NullableContext(2)]
		protected override UUIExtendToggle GetDropDownToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x06035D45 RID: 220485 RVA: 0x00D8AF90 File Offset: 0x00D89190
		protected override void OnShowDropDownItemBase(RoleBondInfo fetterInfo)
		{
			if (fetterInfo.ConfigId == 0)
			{
				this.SetFetterAllSelect();
				return;
			}
			RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(fetterInfo.ConfigId);
			if (rogueResBond == null)
			{
				return;
			}
			bool uiactive = ModelBase<RogueBattleModel>.Instance.IsBondLinkCanActivate(fetterInfo.ConfigId);
			UUITexture texture = base.GetTexture(2);
			base.SetTextureShowUntilLoaded(rogueResBond.Value.Icon, texture, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rogueResBond.Value.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "RogueResSynergyLV", new <>z__ReadOnlySingleElementList<object>(fetterInfo.Level));
			base.GetText(3).SetUIActive(true);
			base.GetItem(4).SetUIActive(uiactive);
		}

		// Token: 0x06035D46 RID: 220486 RVA: 0x00D8B05C File Offset: 0x00D8925C
		private void SetFetterAllSelect()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_RogueSelectAll");
			base.SetTextureShowUntilLoaded(resourcePath, base.GetTexture(2), null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "RogueRes_BondSelect_Desc", Array.Empty<object>());
			base.GetText(3).SetUIActive(false);
			base.GetItem(4).SetUIActive(false);
		}
	}
}
