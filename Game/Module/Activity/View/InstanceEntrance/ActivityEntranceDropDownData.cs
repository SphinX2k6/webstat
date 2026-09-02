using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061E3 RID: 25059
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityEntranceDropDownData
	{
		// Token: 0x0603F3C1 RID: 259009 RVA: 0x0103AD01 File Offset: 0x01038F01
		public ActivityEntranceDropDownContentData[] GetDropDownContentDataList()
		{
			return this.DropDownContentDataList;
		}

		// Token: 0x0603F3C2 RID: 259010 RVA: 0x0103AD09 File Offset: 0x01038F09
		public int GetDefaultIndex()
		{
			return this.DefaultIndex;
		}

		// Token: 0x0603F3C3 RID: 259011 RVA: 0x0103AD11 File Offset: 0x01038F11
		public void SetDefaultIndex(int index)
		{
			this.DefaultIndex = index;
		}

		// Token: 0x0603F3C4 RID: 259012 RVA: 0x0103AD1A File Offset: 0x01038F1A
		public static ActivityEntranceDropDownData Create(ActivityEntranceDropDownContentData[] dropDownContentDataList, int defaultIndex)
		{
			return new ActivityEntranceDropDownData
			{
				DropDownContentDataList = dropDownContentDataList,
				DefaultIndex = defaultIndex
			};
		}

		// Token: 0x04023816 RID: 145430
		private int DefaultIndex;

		// Token: 0x04023817 RID: 145431
		private ActivityEntranceDropDownContentData[] DropDownContentDataList = Array.Empty<ActivityEntranceDropDownContentData>();
	}
}
