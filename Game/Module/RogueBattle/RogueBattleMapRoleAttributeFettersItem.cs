using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051EB RID: 20971
	public class RogueBattleMapRoleAttributeFettersItem : UiPanelBase
	{
		// Token: 0x06035D6E RID: 220526 RVA: 0x00D8C1B0 File Offset: 0x00D8A3B0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06035D6F RID: 220527 RVA: 0x00D8C20A File Offset: 0x00D8A40A
		protected override void OnStart()
		{
			this.FettersLayout = new GenericLayout<RougeBattleAttributeFetterItem, IRogueBattleMapAttrFettersInfo>(base.GetHorizontalLayout(1), new Func<RougeBattleAttributeFetterItem>(this.CreateElement), null, false, true);
		}

		// Token: 0x06035D70 RID: 220528 RVA: 0x00D8C22D File Offset: 0x00D8A42D
		[NullableContext(1)]
		private RougeBattleAttributeFetterItem CreateElement()
		{
			return new RougeBattleAttributeFetterItem();
		}

		// Token: 0x06035D71 RID: 220529 RVA: 0x00D8C234 File Offset: 0x00D8A434
		protected override void OnBeforeDestroy()
		{
			this.FettersLayout = null;
		}

		// Token: 0x06035D72 RID: 220530 RVA: 0x00D8C240 File Offset: 0x00D8A440
		public void Refresh(int roleId)
		{
			bool flag = ModelBase<RogueBattleModel>.Instance.IsRoleGot(roleId);
			int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(roleId);
			RogueResBondRole? rogueResBondRole = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBondRole(baseRoleId);
			List<IRogueBattleMapAttrFettersInfo> list = new List<IRogueBattleMapAttrFettersInfo>();
			foreach (int num in rogueResBondRole.Value.BondIdsIter())
			{
				RoleBondInfo roleBondDataById = ModelBase<RogueBattleModel>.Instance.GetRoleBondDataById(num);
				RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(num);
				int num2 = (roleBondDataById != null) ? roleBondDataById.Level : 0;
				RogueBattleMapAttrFettersInfo item = new RogueBattleMapAttrFettersInfo
				{
					ConfigId = num,
					Level = num2,
					IsUnlock = (flag && roleBondDataById != null),
					IsMaxLevel = new bool?(roleBondDataById != null && num2 == rogueResBond.Value.StarMapLength)
				};
				list.Add(item);
			}
			GenericLayout<RougeBattleAttributeFetterItem, IRogueBattleMapAttrFettersInfo> fettersLayout = this.FettersLayout;
			if (fettersLayout == null)
			{
				return;
			}
			fettersLayout.RefreshByData(list, null, false);
		}

		// Token: 0x0401EE78 RID: 126584
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RougeBattleAttributeFetterItem, IRogueBattleMapAttrFettersInfo> FettersLayout;
	}
}
