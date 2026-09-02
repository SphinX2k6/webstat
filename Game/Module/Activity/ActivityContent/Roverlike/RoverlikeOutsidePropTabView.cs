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
	// Token: 0x020063F5 RID: 25589
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeOutsidePropTabView : RoverlikeOutsideTabViewBase
	{
		// Token: 0x17009DCE RID: 40398
		// (get) Token: 0x060403F1 RID: 263153 RVA: 0x010777BB File Offset: 0x010759BB
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

		// Token: 0x060403F2 RID: 263154 RVA: 0x010777C4 File Offset: 0x010759C4
		protected override UniTask CreateDetailCardAsync()
		{
			RoverlikeOutsidePropTabView.<CreateDetailCardAsync>d__3 <CreateDetailCardAsync>d__;
			<CreateDetailCardAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateDetailCardAsync>d__.<>4__this = this;
			<CreateDetailCardAsync>d__.<>1__state = -1;
			<CreateDetailCardAsync>d__.<>t__builder.Start<RoverlikeOutsidePropTabView.<CreateDetailCardAsync>d__3>(ref <CreateDetailCardAsync>d__);
			return <CreateDetailCardAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060403F3 RID: 263155 RVA: 0x01077807 File Offset: 0x01075A07
		[NullableContext(2)]
		protected override UUIItem GetDetailItemComponent()
		{
			return base.GetSlotItem(EOutsideSlot.ItemPropDetail);
		}

		// Token: 0x060403F4 RID: 263156 RVA: 0x01077814 File Offset: 0x01075A14
		protected override void RefreshDetailCard(RoverlikeGainEntry entry)
		{
			RoverlikePropItemData data = new RoverlikePropItemData
			{
				ConfigId = entry.ConfigId,
				IsInGame = false
			};
			RoverlikePropCardItem detailCard = this.DetailCard;
			if (detailCard == null)
			{
				return;
			}
			detailCard.Refresh(data, false, 0);
		}

		// Token: 0x060403F5 RID: 263157 RVA: 0x0107784D File Offset: 0x01075A4D
		protected override bool ShouldShowCollectProgress()
		{
			return false;
		}

		// Token: 0x060403F6 RID: 263158 RVA: 0x01077850 File Offset: 0x01075A50
		protected override int BuildScrollDataList()
		{
			List<RoverRogueItem> list = (from cfg in ConfigBase<RoverlikeConfig>.Instance.GetItemConfigList()
			where cfg.Classify == 2
			orderby cfg.Quality descending, cfg.Id descending
			select cfg).ToList<RoverRogueItem>();
			int num = -1;
			if (list.Count > 0)
			{
				base.PushTitle("RoverRogue_SystemShow_Item");
				foreach (RoverRogueItem roverRogueItem in list)
				{
					RoverlikeGainEntry entry = RoverlikeGainEntry.Create(RoverRogueGainDataType.RoverRogueGainItem, roverRogueItem.Id);
					int num2 = base.PushGrid(entry);
					if (num < 0)
					{
						num = num2;
					}
				}
			}
			return num;
		}

		// Token: 0x060403F7 RID: 263159 RVA: 0x0107794C File Offset: 0x01075B4C
		protected override bool IsEntryLocked(RoverlikeGainEntry entry)
		{
			return false;
		}

		// Token: 0x0402405A RID: 147546
		[Nullable(2)]
		private RoverlikePropCardItem DetailCard;
	}
}
