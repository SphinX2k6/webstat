using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057BD RID: 22461
	[NullableContext(1)]
	[Nullable(0)]
	public class ChangeKeyModeData
	{
		// Token: 0x0603918D RID: 233869 RVA: 0x00E78860 File Offset: 0x00E76A60
		public ChangeKeyModeData(IChangeKeyMode changeKeyMode)
		{
			this.TitleName = changeKeyMode.TitleName;
			this.DefaultGroupIndex = changeKeyMode.DefaultGroupIndex;
			IChangeKeyModeGroup[] changeKeyModeGroupList = changeKeyMode.ChangeKeyModeGroupList;
			for (int i = 0; i < changeKeyModeGroupList.Length; i++)
			{
				ChangeKeyModeGroupData item = new ChangeKeyModeGroupData(changeKeyModeGroupList[i]);
				this.ChangeKeyModeGroupDataList.Add(item);
			}
		}

		// Token: 0x0603918E RID: 233870 RVA: 0x00E788C0 File Offset: 0x00E76AC0
		public IReadOnlyList<ChangeKeyModeGroupData> GetChangeKeyModeGroupDataList()
		{
			return this.ChangeKeyModeGroupDataList;
		}

		// Token: 0x0603918F RID: 233871 RVA: 0x00E788C8 File Offset: 0x00E76AC8
		public int GetMaxGroupIndex()
		{
			return this.GetChangeKeyModeGroupDataList().Count - 1;
		}

		// Token: 0x0402080D RID: 133133
		[Nullable(2)]
		public readonly string TitleName;

		// Token: 0x0402080E RID: 133134
		public int DefaultGroupIndex;

		// Token: 0x0402080F RID: 133135
		private readonly List<ChangeKeyModeGroupData> ChangeKeyModeGroupDataList = new List<ChangeKeyModeGroupData>();
	}
}
