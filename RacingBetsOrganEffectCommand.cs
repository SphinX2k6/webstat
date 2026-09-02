using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026E2 RID: 9954
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsOrganEffectCommand : RacingBetsCommandBase
{
	// Token: 0x170018D9 RID: 6361
	// (get) Token: 0x06013A43 RID: 80451 RVA: 0x00579EDA File Offset: 0x005780DA
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.OrganEffect;
		}
	}

	// Token: 0x06013A44 RID: 80452 RVA: 0x00579EDE File Offset: 0x005780DE
	public void Init(RacingBetsOrganEffect organEffectAction)
	{
		this.OrganEffectAction = organEffectAction;
	}

	// Token: 0x06013A45 RID: 80453 RVA: 0x00579EE8 File Offset: 0x005780E8
	public override UniTask OnExecute()
	{
		RacingBetsOrganEffectCommand.<OnExecute>d__4 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<RacingBetsOrganEffectCommand.<OnExecute>d__4>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x06013A46 RID: 80454 RVA: 0x00579F2B File Offset: 0x0057812B
	public override string LogInfo()
	{
		return "RacingBetsOrganEffectCommand";
	}

	// Token: 0x040098C9 RID: 39113
	private RacingBetsOrganEffect OrganEffectAction;
}
