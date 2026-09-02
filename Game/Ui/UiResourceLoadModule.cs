using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A54 RID: 19028
	[NullableContext(1)]
	[Nullable(0)]
	public class UiResourceLoadModule
	{
		// Token: 0x06031B6C RID: 203628 RVA: 0x00C63D4C File Offset: 0x00C61F4C
		protected void CancelResource(UObject obj)
		{
			UiResourceHandle uiResourceHandle;
			if (!this.ResourceHandleMap.TryGetValue(obj, out uiResourceHandle))
			{
				uiResourceHandle = new UiResourceHandle(obj);
				this.ResourceHandleMap[obj] = uiResourceHandle;
				return;
			}
			uiResourceHandle.CancelResource();
		}

		// Token: 0x06031B6D RID: 203629 RVA: 0x00C63D84 File Offset: 0x00C61F84
		protected void SetResourceId(UObject obj, int resourceId)
		{
			UiResourceHandle uiResourceHandle;
			if (this.ResourceHandleMap.TryGetValue(obj, out uiResourceHandle))
			{
				uiResourceHandle.ResourceId = resourceId;
			}
		}

		// Token: 0x06031B6E RID: 203630 RVA: 0x00C63DA8 File Offset: 0x00C61FA8
		protected void DeleteResourceHandle(UObject obj)
		{
			this.ResourceHandleMap.Remove(obj);
		}

		// Token: 0x06031B6F RID: 203631 RVA: 0x00C63DB8 File Offset: 0x00C61FB8
		public virtual void Clear()
		{
			foreach (UiResourceHandle uiResourceHandle in this.ResourceHandleMap.Values)
			{
				uiResourceHandle.CancelResource();
			}
			this.ResourceHandleMap.Clear();
		}

		// Token: 0x0401CEB3 RID: 118451
		private readonly Dictionary<UObject, UiResourceHandle> ResourceHandleMap = new Dictionary<UObject, UiResourceHandle>();
	}
}
