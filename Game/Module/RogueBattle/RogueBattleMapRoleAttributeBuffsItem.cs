using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051E7 RID: 20967
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleMapRoleAttributeBuffsItem : UiPanelBase
	{
		// Token: 0x06035D63 RID: 220515 RVA: 0x00D8BE88 File Offset: 0x00D8A088
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIGridLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06035D64 RID: 220516 RVA: 0x00D8BEF8 File Offset: 0x00D8A0F8
		protected override void OnStart()
		{
			this.BuffsLayout = new GenericLayout<RougeBattleAttributeBuffItem, int>(base.GetGridLayout(1), new Func<RougeBattleAttributeBuffItem>(this.CreateElement), null, false, true);
		}

		// Token: 0x06035D65 RID: 220517 RVA: 0x00D8BF1B File Offset: 0x00D8A11B
		private RougeBattleAttributeBuffItem CreateElement()
		{
			return new RougeBattleAttributeBuffItem
			{
				OnClickCall = new Action<int>(this.OnClickBuff)
			};
		}

		// Token: 0x06035D66 RID: 220518 RVA: 0x00D8BF34 File Offset: 0x00D8A134
		protected override void OnBeforeDestroy()
		{
			this.BuffsLayout = null;
		}

		// Token: 0x06035D67 RID: 220519 RVA: 0x00D8BF40 File Offset: 0x00D8A140
		public void Refresh(int roleId)
		{
			this.RoleId = roleId;
			int incIdByRoleId = ModelBase<RogueBattleModel>.Instance.GetIncIdByRoleId(roleId);
			RepeatedField<int> roleAffixs = ModelBase<RogueBattleModel>.Instance.GetRoleInfoById(incIdByRoleId).RoleAffixs;
			if (roleAffixs.Count == 0)
			{
				UUIItem item = base.GetItem(3);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				this.BuffsLayout.GetRootUiItem().SetUIActive(false);
				return;
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			this.BuffsLayout.GetRootUiItem().SetUIActive(true);
			GenericLayout<RougeBattleAttributeBuffItem, int> buffsLayout = this.BuffsLayout;
			if (buffsLayout != null)
			{
				buffsLayout.RefreshByData(roleAffixs.ToList<int>(), null, false);
			}
			this.BuffList = new List<int>(roleAffixs);
		}

		// Token: 0x06035D68 RID: 220520 RVA: 0x00D8BFE8 File Offset: 0x00D8A1E8
		private void OnClickBuff(int buffId)
		{
			RogueBattleRoleAffixDetailOpenParam param = new RogueBattleRoleAffixDetailOpenParam
			{
				Index = this.BuffList.IndexOf(buffId),
				AffixIds = this.BuffList,
				RoleId = this.RoleId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleRoleAffixDetailView, param, null);
		}

		// Token: 0x0401EE6C RID: 126572
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RougeBattleAttributeBuffItem, int> BuffsLayout;

		// Token: 0x0401EE6D RID: 126573
		private List<int> BuffList = new List<int>();

		// Token: 0x0401EE6E RID: 126574
		private int RoleId;
	}
}
