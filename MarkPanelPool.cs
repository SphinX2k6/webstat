using System;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;

// Token: 0x02002244 RID: 8772
public class MarkPanelPool : MarkItemViewPoolBase
{
	// Token: 0x060108EF RID: 67823 RVA: 0x0048732C File Offset: 0x0048552C
	protected override void OnTick()
	{
		for (int i = this.Handles.Count - 1; i >= 0; i--)
		{
			IMarkPoolHandle markPoolHandle = this.Handles[i];
			if (Singleton<Time>.Instance.ServerTimeStamp - markPoolHandle.RecycleTimeStamp > 10000.0)
			{
				MarkPanelBase obj = markPoolHandle.Obj;
				if (obj != null)
				{
					obj.RecycleToPool();
				}
				this.Handles.RemoveAt(i);
			}
		}
	}

	// Token: 0x060108F0 RID: 67824 RVA: 0x00487398 File Offset: 0x00485598
	protected override void OnDispose()
	{
		foreach (IMarkPoolHandle markPoolHandle in this.Handles)
		{
			MarkPanelBase obj = markPoolHandle.Obj;
			if (obj != null)
			{
				obj.RecycleToPool();
			}
		}
		this.Handles.Clear();
	}

	// Token: 0x04008252 RID: 33362
	public const int MAX_PANEL_HANDLE_CACHE_TIME = 10000;
}
