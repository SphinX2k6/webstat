using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity
{
	// Token: 0x020061C9 RID: 25033
	[NullableContext(1)]
	[Nullable(0)]
	public class GuQinActivityTabData
	{
		// Token: 0x0603F2CD RID: 258765 RVA: 0x010376AA File Offset: 0x010358AA
		public EGuQinActivityTabStatus GetStatus()
		{
			if (this.TaskList[0].GetStatus() == EGuQinActivityTaskStatus.Lock)
			{
				return EGuQinActivityTabStatus.Lock;
			}
			if (this.TaskList[this.TaskList.Count - 1].GetStatus() == EGuQinActivityTaskStatus.Completed)
			{
				return EGuQinActivityTabStatus.Completed;
			}
			return EGuQinActivityTabStatus.Progressing;
		}

		// Token: 0x0603F2CE RID: 258766 RVA: 0x010376E4 File Offset: 0x010358E4
		public string GetLockTip()
		{
			return this.TaskList[0].GetLockTip();
		}

		// Token: 0x0603F2CF RID: 258767 RVA: 0x010376F8 File Offset: 0x010358F8
		public bool GetIsRedDot()
		{
			using (List<GuQinActivityTaskData>.Enumerator enumerator = this.TaskList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GetIsRedDot())
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x040237B6 RID: 145334
		public List<GuQinActivityTaskData> TaskList = new List<GuQinActivityTaskData>();
	}
}
