using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004D9B RID: 19867
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseTalentTreeNodeData
	{
		// Token: 0x17008805 RID: 34821
		// (get) Token: 0x0603373A RID: 210746 RVA: 0x00CDE9D0 File Offset: 0x00CDCBD0
		public int Row
		{
			get
			{
				return this.Config.Row;
			}
		}

		// Token: 0x17008806 RID: 34822
		// (get) Token: 0x0603373B RID: 210747 RVA: 0x00CDE9DD File Offset: 0x00CDCBDD
		public int Col
		{
			get
			{
				return this.Config.Col;
			}
		}

		// Token: 0x17008807 RID: 34823
		// (get) Token: 0x0603373C RID: 210748 RVA: 0x00CDE9EA File Offset: 0x00CDCBEA
		public ETrapDefenseTalentTreeType Type
		{
			get
			{
				return (ETrapDefenseTalentTreeType)this.Config.Type;
			}
		}

		// Token: 0x17008808 RID: 34824
		// (get) Token: 0x0603373D RID: 210749 RVA: 0x00CDE9F7 File Offset: 0x00CDCBF7
		public int Index
		{
			get
			{
				return (this.Type - ETrapDefenseTalentTreeType.Economy) * 2 + this.Col - 1;
			}
		}

		// Token: 0x17008809 RID: 34825
		// (get) Token: 0x0603373E RID: 210750 RVA: 0x00CDEA0C File Offset: 0x00CDCC0C
		public string Icon
		{
			get
			{
				return this.Config.IconPath;
			}
		}

		// Token: 0x1700880A RID: 34826
		// (get) Token: 0x0603373F RID: 210751 RVA: 0x00CDEA19 File Offset: 0x00CDCC19
		public string IconBig
		{
			get
			{
				return this.Config.IconPathBig;
			}
		}

		// Token: 0x1700880B RID: 34827
		// (get) Token: 0x06033740 RID: 210752 RVA: 0x00CDEA26 File Offset: 0x00CDCC26
		public string Desc
		{
			get
			{
				return this.Config.Desc;
			}
		}

		// Token: 0x1700880C RID: 34828
		// (get) Token: 0x06033741 RID: 210753 RVA: 0x00CDEA33 File Offset: 0x00CDCC33
		public string Name
		{
			get
			{
				return this.Config.Name;
			}
		}

		// Token: 0x06033742 RID: 210754 RVA: 0x00CDEA40 File Offset: 0x00CDCC40
		public static TrapDefenseTalentTreeNodeData Create(TrapDefenseTech config)
		{
			return new TrapDefenseTalentTreeNodeData
			{
				Config = config,
				Id = config.Id
			};
		}

		// Token: 0x06033743 RID: 210755 RVA: 0x00CDEA5B File Offset: 0x00CDCC5B
		public void SetUnlock()
		{
			this.IsUnlock = true;
		}

		// Token: 0x06033744 RID: 210756 RVA: 0x00CDEA64 File Offset: 0x00CDCC64
		public List<ICostData> GetCostData()
		{
			if (this.IsUnlock)
			{
				return new List<ICostData>();
			}
			CostData item = new CostData
			{
				ItemId = ConfigBase<TrapDefenseConfig>.Instance.GetTalentTreeCurrencyItemId(),
				Count = ModelBase<TrapDefenseModel>.Instance.TalentTreeData.RemainPoints,
				Cost = this.Config.UnlockCost
			};
			return new List<ICostData>
			{
				item
			};
		}

		// Token: 0x0401DCEF RID: 122095
		public int Id;

		// Token: 0x0401DCF0 RID: 122096
		public TrapDefenseTech Config;

		// Token: 0x0401DCF1 RID: 122097
		public bool IsUnlock;
	}
}
