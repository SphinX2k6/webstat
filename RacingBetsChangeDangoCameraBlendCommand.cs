using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026D6 RID: 9942
public class RacingBetsChangeDangoCameraBlendCommand : RacingBetsCommandBase
{
	// Token: 0x170018CA RID: 6346
	// (get) Token: 0x060139EE RID: 80366 RVA: 0x00578D19 File Offset: 0x00576F19
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.CameraBlend;
		}
	}

	// Token: 0x060139EF RID: 80367 RVA: 0x00578D20 File Offset: 0x00576F20
	public override UniTask OnExecute()
	{
		RacingBetsChangeDangoCameraBlendCommand.<OnExecute>d__3 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<RacingBetsChangeDangoCameraBlendCommand.<OnExecute>d__3>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x060139F0 RID: 80368 RVA: 0x00578D63 File Offset: 0x00576F63
	public void SetDangoId(int dangoId)
	{
		this.DangoId = dangoId;
	}

	// Token: 0x060139F1 RID: 80369 RVA: 0x00578D6C File Offset: 0x00576F6C
	[NullableContext(1)]
	public override string LogInfo()
	{
		return "RacingBetsChangeDangoCameraBlendCommand";
	}

	// Token: 0x040098AA RID: 39082
	private int DangoId;
}
