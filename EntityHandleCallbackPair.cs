using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02003492 RID: 13458
[NullableContext(2)]
[Nullable(0)]
public class EntityHandleCallbackPair
{
	// Token: 0x17002668 RID: 9832
	// (get) Token: 0x0601C63E RID: 116286 RVA: 0x00881EB5 File Offset: 0x008800B5
	// (set) Token: 0x0601C63F RID: 116287 RVA: 0x00881EBD File Offset: 0x008800BD
	public EntityHandle Handle { get; set; }

	// Token: 0x17002669 RID: 9833
	// (get) Token: 0x0601C640 RID: 116288 RVA: 0x00881EC6 File Offset: 0x008800C6
	// (set) Token: 0x0601C641 RID: 116289 RVA: 0x00881ECE File Offset: 0x008800CE
	public long CreatureDataId { get; set; }

	// Token: 0x1700266A RID: 9834
	// (get) Token: 0x0601C642 RID: 116290 RVA: 0x00881ED7 File Offset: 0x008800D7
	// (set) Token: 0x0601C643 RID: 116291 RVA: 0x00881EDF File Offset: 0x008800DF
	public int PbDataId { get; set; }

	// Token: 0x1700266B RID: 9835
	// (get) Token: 0x0601C644 RID: 116292 RVA: 0x00881EE8 File Offset: 0x008800E8
	// (set) Token: 0x0601C645 RID: 116293 RVA: 0x00881EF0 File Offset: 0x008800F0
	public float AngleRatio { get; set; }

	// Token: 0x1700266C RID: 9836
	// (get) Token: 0x0601C646 RID: 116294 RVA: 0x00881EF9 File Offset: 0x008800F9
	// (set) Token: 0x0601C647 RID: 116295 RVA: 0x00881F01 File Offset: 0x00880101
	public float Priority { get; set; }

	// Token: 0x1700266D RID: 9837
	// (get) Token: 0x0601C648 RID: 116296 RVA: 0x00881F0A File Offset: 0x0088010A
	// (set) Token: 0x0601C649 RID: 116297 RVA: 0x00881F12 File Offset: 0x00880112
	public int Order { get; set; }

	// Token: 0x1700266E RID: 9838
	// (get) Token: 0x0601C64A RID: 116298 RVA: 0x00881F1B File Offset: 0x0088011B
	// (set) Token: 0x0601C64B RID: 116299 RVA: 0x00881F23 File Offset: 0x00880123
	public int Version { get; set; }

	// Token: 0x0601C64C RID: 116300 RVA: 0x00881F2C File Offset: 0x0088012C
	public void AddCallback(Action<ELoadResultType> callback)
	{
		if (callback != null)
		{
			this.Callbacks.Add(callback);
		}
	}

	// Token: 0x0601C64D RID: 116301 RVA: 0x00881F3D File Offset: 0x0088013D
	public void ClearCallbacks()
	{
		this.Callbacks.Clear();
	}

	// Token: 0x0601C64E RID: 116302 RVA: 0x00881F4C File Offset: 0x0088014C
	public void InvokeCallbacks(ELoadResultType result)
	{
		foreach (Action<ELoadResultType> action in this.Callbacks)
		{
			try
			{
				action(result);
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Preload;
				ELogAuthor author = ELogAuthor.XY;
				string message = "预加载实体:加载回调异常";
				Exception error = ex;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", result);
				instance.ErrorWithStack(module, author, message, error, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
	}

	// Token: 0x0400E480 RID: 58496
	[Nullable(1)]
	private readonly List<Action<ELoadResultType>> Callbacks = new List<Action<ELoadResultType>>();
}
