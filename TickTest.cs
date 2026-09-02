using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020034F1 RID: 13553
[UnitTest]
public sealed class TickTest : UnitTestBase
{
	// Token: 0x170026F1 RID: 9969
	// (get) Token: 0x0601CA40 RID: 117312 RVA: 0x00898613 File Offset: 0x00896813
	[Nullable(1)]
	public override string Name
	{
		[NullableContext(1)]
		get
		{
			return "TickTest";
		}
	}

	// Token: 0x0601CA41 RID: 117313 RVA: 0x0089861C File Offset: 0x0089681C
	public override UniTask<bool> Run([Nullable(1)] params object[] args)
	{
		TickTest.<Run>d__5 <Run>d__;
		<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<Run>d__.<>4__this = this;
		<Run>d__.args = args;
		<Run>d__.<>1__state = -1;
		<Run>d__.<>t__builder.Start<TickTest.<Run>d__5>(ref <Run>d__);
		return <Run>d__.<>t__builder.Task;
	}

	// Token: 0x0601CA42 RID: 117314 RVA: 0x00898667 File Offset: 0x00896867
	private void Tick(float delta)
	{
		this._CurrentTime += delta;
		if (this._CurrentTime > 5000f)
		{
			this._Tcs.TrySetResult(true);
		}
	}

	// Token: 0x0400E68D RID: 59021
	private const float TotalTime = 5000f;

	// Token: 0x0400E68E RID: 59022
	private float _CurrentTime;

	// Token: 0x0400E68F RID: 59023
	[Nullable(2)]
	private UniTaskCompletionSource<bool> _Tcs;
}
