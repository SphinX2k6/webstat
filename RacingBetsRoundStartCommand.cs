using System;
using System.Runtime.CompilerServices;

// Token: 0x020026E3 RID: 9955
public class RacingBetsRoundStartCommand : RacingBetsCommandBase
{
	// Token: 0x170018DA RID: 6362
	// (get) Token: 0x06013A48 RID: 80456 RVA: 0x00579F3A File Offset: 0x0057813A
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.RoundStart;
		}
	}

	// Token: 0x06013A49 RID: 80457 RVA: 0x00579F3D File Offset: 0x0057813D
	[NullableContext(1)]
	public override string LogInfo()
	{
		return "RacingBetsRoundStartCommand";
	}
}
