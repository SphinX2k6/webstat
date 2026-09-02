using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020050FE RID: 20734
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeEntriesGroupData
	{
		// Token: 0x17008C3F RID: 35903
		// (get) Token: 0x06035731 RID: 218929 RVA: 0x00D6A8D4 File Offset: 0x00D68AD4
		// (set) Token: 0x06035730 RID: 218928 RVA: 0x00D6A8B0 File Offset: 0x00D68AB0
		public bool IsActive
		{
			get
			{
				return this.IsActiveInternal;
			}
			set
			{
				if (this.IsActiveInternal == value)
				{
					return;
				}
				this.IsActiveInternal = value;
				Action<bool> activeStateChange = this.ActiveStateChange;
				if (activeStateChange == null)
				{
					return;
				}
				activeStateChange(value);
			}
		}

		// Token: 0x17008C40 RID: 35904
		// (get) Token: 0x06035733 RID: 218931 RVA: 0x00D6A900 File Offset: 0x00D68B00
		// (set) Token: 0x06035732 RID: 218930 RVA: 0x00D6A8DC File Offset: 0x00D68ADC
		public bool IsFocus
		{
			get
			{
				return this.IsFocusInternal;
			}
			set
			{
				if (this.IsFocus == value)
				{
					return;
				}
				this.IsFocusInternal = value;
				Action<bool> focusStateChange = this.FocusStateChange;
				if (focusStateChange == null)
				{
					return;
				}
				focusStateChange(value);
			}
		}

		// Token: 0x06035734 RID: 218932 RVA: 0x00D6A908 File Offset: 0x00D68B08
		public List<RoguelikeEntryData> GetAllEntryDataList()
		{
			List<RoguelikeEntryData> list = new List<RoguelikeEntryData>();
			list.AddRange(this.GroupDataListRow1);
			list.AddRange(this.GroupDataListRow2);
			list.AddRange(this.GroupDataListRow3);
			return list;
		}

		// Token: 0x06035735 RID: 218933 RVA: 0x00D6A934 File Offset: 0x00D68B34
		public RogueHotEntryGroup GetConfig()
		{
			return ConfigBase<RoguelikeConfig>.Instance.GetRogueHotEntryGroupConfig(this.Id).Value;
		}

		// Token: 0x0401EB2F RID: 125743
		public int Id;

		// Token: 0x0401EB30 RID: 125744
		public int Index;

		// Token: 0x0401EB31 RID: 125745
		public bool IsUnlock;

		// Token: 0x0401EB32 RID: 125746
		private bool IsActiveInternal;

		// Token: 0x0401EB33 RID: 125747
		private bool IsFocusInternal;

		// Token: 0x0401EB34 RID: 125748
		public List<RoguelikeEntryData> GroupDataListRow1 = new List<RoguelikeEntryData>();

		// Token: 0x0401EB35 RID: 125749
		public List<RoguelikeEntryData> GroupDataListRow2 = new List<RoguelikeEntryData>();

		// Token: 0x0401EB36 RID: 125750
		public List<RoguelikeEntryData> GroupDataListRow3 = new List<RoguelikeEntryData>();

		// Token: 0x0401EB37 RID: 125751
		[Nullable(2)]
		public Action<bool> ActiveStateChange;

		// Token: 0x0401EB38 RID: 125752
		[Nullable(2)]
		public Action<bool> FocusStateChange;
	}
}
