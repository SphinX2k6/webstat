using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.MapRogue;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051F3 RID: 20979
	public class MediumItemGridRogueRoleLevelComponent : MediumItemGridComponent
	{
		// Token: 0x06035D86 RID: 220550 RVA: 0x00D8C9E8 File Offset: 0x00D8ABE8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText))
			};
		}

		// Token: 0x06035D87 RID: 220551 RVA: 0x00D8CA58 File Offset: 0x00D8AC58
		[NullableContext(1)]
		protected override string GetResourceId()
		{
			return "UiItem_ItemRoleInfo";
		}

		// Token: 0x06035D88 RID: 220552 RVA: 0x00D8CA60 File Offset: 0x00D8AC60
		[NullableContext(2)]
		protected override void OnRefresh(object data = null)
		{
			IRogueBattleMapRoleGridInfo rogueBattleMapRoleGridInfo = (IRogueBattleMapRoleGridInfo)data;
			int configId = rogueBattleMapRoleGridInfo.ConfigId;
			bool flag = ModelBase<RogueBattleModel>.Instance.IsRoleGot(configId);
			this.SetActive(flag);
			if (!flag)
			{
				return;
			}
			int incIdByRoleId = ModelBase<RogueBattleModel>.Instance.GetIncIdByRoleId(configId);
			RogueResRole roleInfoById = ModelBase<RogueBattleModel>.Instance.GetRoleInfoById(incIdByRoleId);
			if (rogueBattleMapRoleGridInfo.NeedLevel)
			{
				UUIText text = base.GetText(0);
				if (text != null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Lv.");
					defaultInterpolatedStringHandler.AppendFormatted<int>(ModelBase<MapRogueModel>.Instance.GetRogueRoleLevel());
					text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				}
			}
			else
			{
				UUIText text2 = base.GetText(0);
				if (text2 != null)
				{
					text2.SetText(string.Empty, true);
				}
			}
			UUIText text3 = base.GetText(3);
			if (text3 == null)
			{
				return;
			}
			text3.SetText(roleInfoById.Level.ToString(), true);
		}
	}
}
