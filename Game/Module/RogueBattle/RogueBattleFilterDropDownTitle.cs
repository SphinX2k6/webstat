using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051DB RID: 20955
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleFilterDropDownTitle : TitleItemBase<RoleBondInfo>
	{
		// Token: 0x06035D47 RID: 220487 RVA: 0x00D8B0BD File Offset: 0x00D892BD
		public RogueBattleFilterDropDownTitle(UUIItem uiItem) : base(uiItem)
		{
		}

		// Token: 0x06035D48 RID: 220488 RVA: 0x00D8B0C8 File Offset: 0x00D892C8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06035D49 RID: 220489 RVA: 0x00D8B124 File Offset: 0x00D89324
		public override void ShowTemp(RoleBondInfo fetterInfo, DropDownItemBase<RoleBondInfo> selectedItemObj)
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
			UUITexture texture = base.GetTexture(1);
			base.SetTextureShowUntilLoaded(rogueResBond.Value.Icon, texture, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), rogueResBond.Value.Name, Array.Empty<object>());
			base.GetItem(2).SetUIActive(uiactive);
		}

		// Token: 0x06035D4A RID: 220490 RVA: 0x00D8B1C0 File Offset: 0x00D893C0
		private void SetFetterAllSelect()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_RogueSelectAll");
			base.SetTextureShowUntilLoaded(resourcePath, base.GetTexture(1), null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "RogueRes_BondSelect_Desc", Array.Empty<object>());
			base.GetItem(2).SetUIActive(false);
		}
	}
}
