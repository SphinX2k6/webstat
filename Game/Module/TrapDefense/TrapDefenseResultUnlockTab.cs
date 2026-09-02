using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E26 RID: 20006
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseResultUnlockTab : GridProxyAbstract<ITrapDefenseResultUnlockTab>
	{
		// Token: 0x06033B85 RID: 211845 RVA: 0x00CED68C File Offset: 0x00CEB88C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033B86 RID: 211846 RVA: 0x00CED758 File Offset: 0x00CEB958
		protected override void OnStart()
		{
			this.OrganLayout = new GenericLayout<TrapDefenseResultOrganUnlockItem, ITrapDefenseResultUnlockInfo>(base.GetGridLayout(1), new Func<TrapDefenseResultOrganUnlockItem>(this.CreateOrganItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
			this.BdLayout = new GenericLayout<TrapDefenseResultBdUnlockItem, ITrapDefenseResultUnlockInfo>(base.GetGridLayout(3), new Func<TrapDefenseResultBdUnlockItem>(this.CreateBdItem), base.GetItem(4).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x06033B87 RID: 211847 RVA: 0x00CED7C8 File Offset: 0x00CEB9C8
		public override void Refresh(ITrapDefenseResultUnlockTab data, bool isSelected, int gridIndex)
		{
			ETrapDefenseResultUnlockType type = data.Type;
			string textStringId = TrapDefenseResultUnlockTab.tabTypeTxtMap[type];
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textStringId, Array.Empty<object>());
			bool flag = type == ETrapDefenseResultUnlockType.Organ || type == ETrapDefenseResultUnlockType.OrganShare;
			this.IsUnlockAnim = (type == ETrapDefenseResultUnlockType.Organ || type == ETrapDefenseResultUnlockType.Bd);
			base.GetGridLayout(1).RootUIComp.Get().SetUIActive(flag);
			base.GetGridLayout(3).RootUIComp.Get().SetUIActive(!flag);
			this.IsShared = (type == ETrapDefenseResultUnlockType.OrganShare || type == ETrapDefenseResultUnlockType.BdShare);
			if (flag)
			{
				this.OrganLayout.RefreshByData(data.DataList, null, true);
				return;
			}
			this.BdLayout.RefreshByData(data.DataList, null, true);
		}

		// Token: 0x06033B88 RID: 211848 RVA: 0x00CED88C File Offset: 0x00CEBA8C
		public void PlayUnlockAnim()
		{
			if (!this.IsUnlockAnim)
			{
				return;
			}
			foreach (TrapDefenseResultOrganUnlockItem trapDefenseResultOrganUnlockItem in this.OrganLayout.GetLayoutItemList())
			{
				trapDefenseResultOrganUnlockItem.PlayUnlockAnim();
			}
			foreach (TrapDefenseResultBdUnlockItem trapDefenseResultBdUnlockItem in this.BdLayout.GetLayoutItemList())
			{
				trapDefenseResultBdUnlockItem.PlayUnlockAnim();
			}
		}

		// Token: 0x06033B89 RID: 211849 RVA: 0x00CED930 File Offset: 0x00CEBB30
		private TrapDefenseResultOrganUnlockItem CreateOrganItem()
		{
			return new TrapDefenseResultOrganUnlockItem();
		}

		// Token: 0x06033B8A RID: 211850 RVA: 0x00CED937 File Offset: 0x00CEBB37
		private TrapDefenseResultBdUnlockItem CreateBdItem()
		{
			return new TrapDefenseResultBdUnlockItem();
		}

		// Token: 0x0401DF1A RID: 122650
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<ETrapDefenseResultUnlockType, string> tabTypeTxtMap = new Dictionary<ETrapDefenseResultUnlockType, string>
		{
			{
				ETrapDefenseResultUnlockType.Organ,
				"TowerDefense_Ending_GainBuilding_Text"
			},
			{
				ETrapDefenseResultUnlockType.OrganShare,
				"TowerDefense_Ending_GainBuildingShare_Text"
			},
			{
				ETrapDefenseResultUnlockType.Bd,
				"TowerDefense_Ending_GainSchool_Text"
			},
			{
				ETrapDefenseResultUnlockType.BdShare,
				"TowerDefense_Ending_GainSchoolShare_Text"
			}
		};

		// Token: 0x0401DF1B RID: 122651
		protected GenericLayout<TrapDefenseResultOrganUnlockItem, ITrapDefenseResultUnlockInfo> OrganLayout;

		// Token: 0x0401DF1C RID: 122652
		protected GenericLayout<TrapDefenseResultBdUnlockItem, ITrapDefenseResultUnlockInfo> BdLayout;

		// Token: 0x0401DF1D RID: 122653
		public bool IsShared;

		// Token: 0x0401DF1E RID: 122654
		private bool IsUnlockAnim;

		// Token: 0x0200AD9E RID: 44446
		[NullableContext(0)]
		internal class EUnlockTab
		{
			// Token: 0x04035EA0 RID: 220832
			public const int Title = 0;

			// Token: 0x04035EA1 RID: 220833
			public const int OrganLayout = 1;

			// Token: 0x04035EA2 RID: 220834
			public const int OrganItem = 2;

			// Token: 0x04035EA3 RID: 220835
			public const int BdLayout = 3;

			// Token: 0x04035EA4 RID: 220836
			public const int BdItem = 4;
		}
	}
}
