using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;

// Token: 0x02002243 RID: 8771
public abstract class MarkItemViewPoolBase
{
	// Token: 0x060108E8 RID: 67816 RVA: 0x00487280 File Offset: 0x00485480
	[return: Nullable(2)]
	public T Get<T>() where T : MarkPanelBase
	{
		if (this.Handles.Count > 0)
		{
			IMarkPoolHandle markPoolHandle = this.Handles[0];
			this.Handles.RemoveAt(0);
			return markPoolHandle.Obj as T;
		}
		return default(T);
	}

	// Token: 0x060108E9 RID: 67817 RVA: 0x004872CC File Offset: 0x004854CC
	[NullableContext(1)]
	public void Recycle(MarkPanelBase poolObj)
	{
		MarkPoolHandle item = new MarkPoolHandle
		{
			RecycleTimeStamp = Singleton<Time>.Instance.ServerTimeStamp,
			Obj = poolObj
		};
		this.Handles.Add(item);
	}

	// Token: 0x060108EA RID: 67818 RVA: 0x00487302 File Offset: 0x00485502
	public void Tick()
	{
		this.OnTick();
	}

	// Token: 0x060108EB RID: 67819 RVA: 0x0048730A File Offset: 0x0048550A
	protected virtual void OnTick()
	{
	}

	// Token: 0x060108EC RID: 67820 RVA: 0x0048730C File Offset: 0x0048550C
	public void Dispose()
	{
		this.OnDispose();
	}

	// Token: 0x060108ED RID: 67821 RVA: 0x00487314 File Offset: 0x00485514
	protected virtual void OnDispose()
	{
	}

	// Token: 0x04008251 RID: 33361
	[Nullable(1)]
	protected readonly List<IMarkPoolHandle> Handles = new List<IMarkPoolHandle>();
}
