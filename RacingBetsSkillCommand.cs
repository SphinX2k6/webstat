using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026E4 RID: 9956
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsSkillCommand : RacingBetsCommandBase
{
	// Token: 0x170018DB RID: 6363
	// (get) Token: 0x06013A4B RID: 80459 RVA: 0x00579F4C File Offset: 0x0057814C
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.DangoSkill;
		}
	}

	// Token: 0x06013A4C RID: 80460 RVA: 0x00579F4F File Offset: 0x0057814F
	public void Init(RacingBetsDangoActionSkill skillAction)
	{
		this.SkillAction = skillAction;
	}

	// Token: 0x06013A4D RID: 80461 RVA: 0x00579F58 File Offset: 0x00578158
	public override UniTask OnExecute()
	{
		RacingBetsSkillCommand.<OnExecute>d__4 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<RacingBetsSkillCommand.<OnExecute>d__4>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x06013A4E RID: 80462 RVA: 0x00579F9B File Offset: 0x0057819B
	public override string LogInfo()
	{
		return "RacingBetsSkillCommand";
	}

	// Token: 0x040098CA RID: 39114
	private RacingBetsDangoActionSkill SkillAction;
}
