using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057BE RID: 22462
	[NullableContext(1)]
	[Nullable(0)]
	public class ChangeKeyModeGroupData
	{
		// Token: 0x06039190 RID: 233872 RVA: 0x00E788D8 File Offset: 0x00E76AD8
		public ChangeKeyModeGroupData(IChangeKeyModeGroup changeKeyModeGroup)
		{
			this.GroupName = changeKeyModeGroup.GroupName;
			this.DefaultKeyModeRowIndex = changeKeyModeGroup.DefaultKeyModeRowIndex;
			int num = 0;
			foreach (IChangeKeyModeRow changeKeyModeRow in changeKeyModeGroup.ChangeKeyModeRowList)
			{
				ChangeKeyModeRowData item = new ChangeKeyModeRowData(num, changeKeyModeRow);
				this.ChangeKeyModeRowDataList.Add(item);
				num++;
			}
		}

		// Token: 0x06039191 RID: 233873 RVA: 0x00E78943 File Offset: 0x00E76B43
		public IReadOnlyList<ChangeKeyModeRowData> GetChangeKeyModeRowDataList()
		{
			return this.ChangeKeyModeRowDataList;
		}

		// Token: 0x04020810 RID: 133136
		[Nullable(2)]
		public readonly string GroupName;

		// Token: 0x04020811 RID: 133137
		public readonly int DefaultKeyModeRowIndex;

		// Token: 0x04020812 RID: 133138
		private readonly List<ChangeKeyModeRowData> ChangeKeyModeRowDataList = new List<ChangeKeyModeRowData>();
	}
}
