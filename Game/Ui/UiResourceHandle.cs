using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A53 RID: 19027
	[NullableContext(1)]
	[Nullable(0)]
	public class UiResourceHandle
	{
		// Token: 0x06031B6A RID: 203626 RVA: 0x00C63D1B File Offset: 0x00C61F1B
		public UiResourceHandle(UObject obj)
		{
			this.Object = obj;
		}

		// Token: 0x06031B6B RID: 203627 RVA: 0x00C63D31 File Offset: 0x00C61F31
		public void CancelResource()
		{
			if (this.ResourceId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.ResourceId);
			}
		}

		// Token: 0x0401CEB1 RID: 118449
		public UObject Object;

		// Token: 0x0401CEB2 RID: 118450
		public int ResourceId = -1;
	}
}
