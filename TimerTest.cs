using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020034F2 RID: 13554
[NullableContext(1)]
[Nullable(0)]
[UnitTest]
public sealed class TimerTest : UnitTestBase
{
	// Token: 0x170026F2 RID: 9970
	// (get) Token: 0x0601CA44 RID: 117316 RVA: 0x00898699 File Offset: 0x00896899
	public override string Name
	{
		get
		{
			return "TimerTest";
		}
	}

	// Token: 0x0601CA45 RID: 117317 RVA: 0x008986A0 File Offset: 0x008968A0
	[NullableContext(0)]
	public override UniTask<bool> Run([Nullable(1)] params object[] args)
	{
		TimerTest.<Run>d__6 <Run>d__;
		<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<Run>d__.<>4__this = this;
		<Run>d__.args = args;
		<Run>d__.<>1__state = -1;
		<Run>d__.<>t__builder.Start<TimerTest.<Run>d__6>(ref <Run>d__);
		return <Run>d__.<>t__builder.Task;
	}

	// Token: 0x0601CA46 RID: 117318 RVA: 0x008986EB File Offset: 0x008968EB
	private void Tick(float delta)
	{
		this._TimerSystem.Tick(delta);
	}

	// Token: 0x0400E690 RID: 59024
	private const float TotalTime = 10000f;

	// Token: 0x0400E691 RID: 59025
	private float _CurrentTime;

	// Token: 0x0400E692 RID: 59026
	[Nullable(2)]
	private UniTaskCompletionSource<bool> _Tcs;

	// Token: 0x0400E693 RID: 59027
	private TimerSystemInstance _TimerSystem = new TimerSystemInstance();
}
