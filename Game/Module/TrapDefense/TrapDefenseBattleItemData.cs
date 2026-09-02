using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004D95 RID: 19861
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBattleItemData
	{
		// Token: 0x060336F6 RID: 210678 RVA: 0x00CDD0A7 File Offset: 0x00CDB2A7
		public static TrapDefenseBattleItemData Create(TrapDefenseItem config)
		{
			return new TrapDefenseBattleItemData
			{
				Config = config
			};
		}

		// Token: 0x170087FC RID: 34812
		// (get) Token: 0x060336F7 RID: 210679 RVA: 0x00CDD0B5 File Offset: 0x00CDB2B5
		public string Name
		{
			get
			{
				return this.Config.Name;
			}
		}

		// Token: 0x170087FD RID: 34813
		// (get) Token: 0x060336F8 RID: 210680 RVA: 0x00CDD0C2 File Offset: 0x00CDB2C2
		public string Desc
		{
			get
			{
				return this.Config.Desc;
			}
		}

		// Token: 0x170087FE RID: 34814
		// (get) Token: 0x060336F9 RID: 210681 RVA: 0x00CDD0CF File Offset: 0x00CDB2CF
		public string Icon
		{
			get
			{
				return this.Config.Icon;
			}
		}

		// Token: 0x170087FF RID: 34815
		// (get) Token: 0x060336FA RID: 210682 RVA: 0x00CDD0DC File Offset: 0x00CDB2DC
		public int Type
		{
			get
			{
				return this.Config.ItemType;
			}
		}

		// Token: 0x17008800 RID: 34816
		// (get) Token: 0x060336FB RID: 210683 RVA: 0x00CDD0E9 File Offset: 0x00CDB2E9
		public int ExploreToolId
		{
			get
			{
				return this.Config.ExploreToolId;
			}
		}

		// Token: 0x17008801 RID: 34817
		// (get) Token: 0x060336FC RID: 210684 RVA: 0x00CDD0F6 File Offset: 0x00CDB2F6
		public bool IsUseSkill
		{
			get
			{
				return this.Config.SkillIndex >= 0;
			}
		}

		// Token: 0x17008802 RID: 34818
		// (get) Token: 0x060336FD RID: 210685 RVA: 0x00CDD109 File Offset: 0x00CDB309
		public int SkillIndex
		{
			get
			{
				return this.Config.SkillIndex;
			}
		}

		// Token: 0x060336FE RID: 210686 RVA: 0x00CDD116 File Offset: 0x00CDB316
		public void UpdateByServerData(int count, int limitCount)
		{
			this.InventoryCount = count;
			this.LimitCount = limitCount;
			Singleton<EventSystem>.Instance.Emit(EEventName.TrapDefenseInventoryDataUpdate);
		}

		// Token: 0x0401DCC7 RID: 122055
		public TrapDefenseItem Config;

		// Token: 0x0401DCC8 RID: 122056
		public int InventoryCount;

		// Token: 0x0401DCC9 RID: 122057
		public int LimitCount = 1;
	}
}
