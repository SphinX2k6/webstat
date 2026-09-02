using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x020026DC RID: 9948
public class RacingBetsDangoRoundStartCommand : RacingBetsCommandBase
{
	// Token: 0x170018D3 RID: 6355
	// (get) Token: 0x06013A1A RID: 80410 RVA: 0x00579109 File Offset: 0x00577309
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.DangoRoundStart;
		}
	}

	// Token: 0x06013A1B RID: 80411 RVA: 0x0057910C File Offset: 0x0057730C
	public void Init(int dangoId)
	{
		this.DangoId = dangoId;
	}

	// Token: 0x06013A1C RID: 80412 RVA: 0x00579115 File Offset: 0x00577315
	public override void OnActive()
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRacingBetsDangoRoundStart, this.DangoId);
	}

	// Token: 0x06013A1D RID: 80413 RVA: 0x0057912D File Offset: 0x0057732D
	[NullableContext(1)]
	public override string LogInfo()
	{
		return "RacingBetsDangoRoundStartCommand";
	}

	// Token: 0x040098B5 RID: 39093
	private int DangoId;
}
