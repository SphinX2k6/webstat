using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020034CF RID: 13519
[NullableContext(1)]
[Nullable(0)]
public class LoadGroup
{
	// Token: 0x170026D0 RID: 9936
	// (get) Token: 0x0601C905 RID: 116997 RVA: 0x0088FCAF File Offset: 0x0088DEAF
	public string Name { get; }

	// Token: 0x0601C906 RID: 116998 RVA: 0x0088FCB7 File Offset: 0x0088DEB7
	public LoadGroup(string name)
	{
		this.Name = name;
	}

	// Token: 0x0601C907 RID: 116999 RVA: 0x0088FCDC File Offset: 0x0088DEDC
	[NullableContext(0)]
	public UniTask<bool> Run()
	{
		LoadGroup.<Run>d__6 <Run>d__;
		<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<Run>d__.<>4__this = this;
		<Run>d__.<>1__state = -1;
		<Run>d__.<>t__builder.Start<LoadGroup.<Run>d__6>(ref <Run>d__);
		return <Run>d__.<>t__builder.Task;
	}

	// Token: 0x0601C908 RID: 117000 RVA: 0x0088FD1F File Offset: 0x0088DF1F
	[NullableContext(2)]
	public bool Add([Nullable(1)] string name, Func<bool> beforeHandle, [Nullable(new byte[]
	{
		1,
		0
	})] Func<UniTask<bool>> handle, Action<bool> afterHandle)
	{
		this.Handles.Add(new ValueTuple<string, Func<bool>, Func<UniTask<bool>>, Action<bool>>(name, beforeHandle, handle, afterHandle));
		return true;
	}

	// Token: 0x0400E60E RID: 58894
	[Nullable(new byte[]
	{
		1,
		0
	})]
	private readonly List<UniTask<bool>> Promises = new List<UniTask<bool>>();

	// Token: 0x0400E60F RID: 58895
	[Nullable(new byte[]
	{
		1,
		0,
		1,
		2,
		1,
		0,
		2
	})]
	private readonly List<ValueTuple<string, Func<bool>, Func<UniTask<bool>>, Action<bool>>> Handles = new List<ValueTuple<string, Func<bool>, Func<UniTask<bool>>, Action<bool>>>();
}
