using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LongShan
{
	// Token: 0x02006751 RID: 26449
	[NullableContext(1)]
	[Nullable(0)]
	public class LongShanStageInfo
	{
		// Token: 0x06041F1A RID: 270106 RVA: 0x010EAB68 File Offset: 0x010E8D68
		public LongShanStageInfo(LongShanStageInfo stateInfo)
		{
			this.ProtoStageInfo = stateInfo;
			RepeatedField<LongShanTaskInfo> tasks = this.ProtoStageInfo.Tasks;
			if (tasks != null)
			{
				foreach (LongShanTaskInfo longShanTaskInfo in tasks)
				{
					this.TaskInfoMap[longShanTaskInfo.Id] = longShanTaskInfo;
				}
			}
		}

		// Token: 0x04024CAE RID: 150702
		[Nullable(2)]
		public LongShanStageInfo ProtoStageInfo;

		// Token: 0x04024CAF RID: 150703
		public Dictionary<int, LongShanTaskInfo> TaskInfoMap = new Dictionary<int, LongShanTaskInfo>();
	}
}
