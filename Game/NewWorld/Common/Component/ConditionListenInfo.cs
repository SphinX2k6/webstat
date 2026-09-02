using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.Common.Component
{
	// Token: 0x020048BC RID: 18620
	[NullableContext(1)]
	[Nullable(0)]
	internal class ConditionListenInfo
	{
		// Token: 0x060308BE RID: 198846 RVA: 0x00BECAAB File Offset: 0x00BEACAB
		public ConditionListenInfo(IClientConditionListener conditionListener, bool checkResult)
		{
		}

		// Token: 0x0401BE65 RID: 114277
		public IClientConditionListener ConditionListener = conditionListener;

		// Token: 0x0401BE66 RID: 114278
		public bool CheckResult = checkResult;

		// Token: 0x0401BE67 RID: 114279
		public List<int> LevelListenerIds = new List<int>();
	}
}
