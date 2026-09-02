using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026D3 RID: 9939
public class OpenRacingBetsGamePlayPreviewViewCommand : RacingBetsCommandBase
{
	// Token: 0x170018C7 RID: 6343
	// (get) Token: 0x060139DD RID: 80349 RVA: 0x00578B16 File Offset: 0x00576D16
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.GamePlayPreviewView;
		}
	}

	// Token: 0x060139DE RID: 80350 RVA: 0x00578B1A File Offset: 0x00576D1A
	public void Init(bool canCameraInput = false)
	{
		this.CanCameraInput = canCameraInput;
	}

	// Token: 0x060139DF RID: 80351 RVA: 0x00578B24 File Offset: 0x00576D24
	public override UniTask OnExecute()
	{
		OpenRacingBetsGamePlayPreviewViewCommand.<OnExecute>d__4 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<OpenRacingBetsGamePlayPreviewViewCommand.<OnExecute>d__4>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x060139E0 RID: 80352 RVA: 0x00578B67 File Offset: 0x00576D67
	[NullableContext(1)]
	public override string LogInfo()
	{
		return "RacingBetsGamePlayPreviewView";
	}

	// Token: 0x040098A8 RID: 39080
	private bool CanCameraInput;
}
