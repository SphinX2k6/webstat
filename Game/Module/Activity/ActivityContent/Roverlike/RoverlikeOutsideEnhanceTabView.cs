using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063F4 RID: 25588
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeOutsideEnhanceTabView : RoverlikeOutsideTabViewBase
	{
		// Token: 0x17009DCD RID: 40397
		// (get) Token: 0x060403EA RID: 263146 RVA: 0x01077618 File Offset: 0x01075818
		[TupleElementNames(new string[]
		{
			"Slot",
			"Type"
		})]
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		protected override IReadOnlyList<ValueTuple<EOutsideSlot, Type>> Layout
		{
			[return: TupleElementNames(new string[]
			{
				"Slot",
				"Type"
			})]
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				return RoverlikeOutsideLayout.Compact;
			}
		}

		// Token: 0x060403EB RID: 263147 RVA: 0x01077620 File Offset: 0x01075820
		protected override UniTask CreateDetailCardAsync()
		{
			RoverlikeOutsideEnhanceTabView.<CreateDetailCardAsync>d__3 <CreateDetailCardAsync>d__;
			<CreateDetailCardAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateDetailCardAsync>d__.<>4__this = this;
			<CreateDetailCardAsync>d__.<>1__state = -1;
			<CreateDetailCardAsync>d__.<>t__builder.Start<RoverlikeOutsideEnhanceTabView.<CreateDetailCardAsync>d__3>(ref <CreateDetailCardAsync>d__);
			return <CreateDetailCardAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060403EC RID: 263148 RVA: 0x01077663 File Offset: 0x01075863
		[NullableContext(2)]
		protected override UUIItem GetDetailItemComponent()
		{
			return base.GetSlotItem(EOutsideSlot.ItemReinforceDetail);
		}

		// Token: 0x060403ED RID: 263149 RVA: 0x01077670 File Offset: 0x01075870
		protected override void RefreshDetailCard(RoverlikeGainEntry entry)
		{
			RoverlikeReinforcementItemData data = new RoverlikeReinforcementItemData
			{
				ConfigId = entry.ConfigId,
				AllowToggleInteract = new bool?(false)
			};
			RoverlikeReinforcementCardItem detailCard = this.DetailCard;
			if (detailCard == null)
			{
				return;
			}
			detailCard.Refresh(data, false, 0);
		}

		// Token: 0x060403EE RID: 263150 RVA: 0x010776B0 File Offset: 0x010758B0
		protected override int BuildScrollDataList()
		{
			IReadOnlyList<RoverRogueRoleEnhance> roleEnhanceConfigList = ConfigBase<RoverlikeConfig>.Instance.GetRoleEnhanceConfigList();
			IEnumerable<RoverRogueRoleType> roleTypeConfigList = ConfigBase<RoverlikeConfig>.Instance.GetRoleTypeConfigList();
			int num = -1;
			using (IEnumerator<RoverRogueRoleType> enumerator = roleTypeConfigList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					RoverRogueRoleType roleTypeCfg = enumerator.Current;
					List<RoverRogueRoleEnhance> list = roleEnhanceConfigList.Where(delegate(RoverRogueRoleEnhance cfg)
					{
						int[] roleTypeArray = cfg.GetRoleTypeArray();
						return roleTypeArray != null && roleTypeArray.Contains(roleTypeCfg.Id);
					}).ToList<RoverRogueRoleEnhance>();
					if (list.Count != 0)
					{
						base.PushTitleIconWithText(roleTypeCfg.ElementIcon, roleTypeCfg.Element);
						foreach (RoverRogueRoleEnhance roverRogueRoleEnhance in list)
						{
							RoverlikeGainEntry entry = RoverlikeGainEntry.Create(RoverRogueGainDataType.RoverRogueGainRoleEnhance, roverRogueRoleEnhance.Id);
							int num2 = base.PushGrid(entry);
							if (num < 0)
							{
								num = num2;
							}
						}
					}
				}
			}
			return num;
		}

		// Token: 0x060403EF RID: 263151 RVA: 0x010777B0 File Offset: 0x010759B0
		protected override bool IsEntryLocked(RoverlikeGainEntry entry)
		{
			return false;
		}

		// Token: 0x04024059 RID: 147545
		[Nullable(2)]
		private RoverlikeReinforcementCardItem DetailCard;
	}
}
