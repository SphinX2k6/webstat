using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026DB RID: 9947
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsDangoRankChangeCommand : RacingBetsCommandBase
{
	// Token: 0x170018D2 RID: 6354
	// (get) Token: 0x06013A15 RID: 80405 RVA: 0x0057909E File Offset: 0x0057729E
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.RankChange;
		}
	}

	// Token: 0x06013A16 RID: 80406 RVA: 0x005790A2 File Offset: 0x005772A2
	public void Init(List<int> rankList)
	{
		this.RankList = rankList;
	}

	// Token: 0x06013A17 RID: 80407 RVA: 0x005790AC File Offset: 0x005772AC
	public override UniTask OnExecute()
	{
		RacingBetsDangoRankChangeCommand.<OnExecute>d__4 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<RacingBetsDangoRankChangeCommand.<OnExecute>d__4>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x06013A18 RID: 80408 RVA: 0x005790EF File Offset: 0x005772EF
	public override string LogInfo()
	{
		return "RacingBetsDangoRankChangeCommand";
	}

	// Token: 0x040098B4 RID: 39092
	private List<int> RankList = new List<int>();
}
