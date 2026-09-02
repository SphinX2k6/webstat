using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001AB9 RID: 6841
[NullableContext(1)]
[Nullable(0)]
public class AbyssChallengeResultData
{
	// Token: 0x0600C47E RID: 50302 RVA: 0x0033DE13 File Offset: 0x0033C013
	public int GetPassTime()
	{
		return this.PassTime;
	}

	// Token: 0x0600C47F RID: 50303 RVA: 0x0033DE1B File Offset: 0x0033C01B
	public int GetMinPassTime()
	{
		return this.MinPassTime;
	}

	// Token: 0x0600C480 RID: 50304 RVA: 0x0033DE23 File Offset: 0x0033C023
	public bool GetIfSuccess()
	{
		return this.IfSuccess;
	}

	// Token: 0x0600C481 RID: 50305 RVA: 0x0033DE2B File Offset: 0x0033C02B
	public global::AbyssChallengeResultPlayerInfo[] GetPlayerInfoList()
	{
		return this.PlayerInfoList;
	}

	// Token: 0x0600C482 RID: 50306 RVA: 0x0033DE34 File Offset: 0x0033C034
	[NullableContext(2)]
	public global::AbyssChallengeResultPlayerInfo GetPlayerInfoByPlayerId(int playerId)
	{
		foreach (global::AbyssChallengeResultPlayerInfo abyssChallengeResultPlayerInfo in this.PlayerInfoList)
		{
			if (abyssChallengeResultPlayerInfo.GetPlayerId() == playerId)
			{
				return abyssChallengeResultPlayerInfo;
			}
		}
		return null;
	}

	// Token: 0x0600C483 RID: 50307 RVA: 0x0033DE68 File Offset: 0x0033C068
	[NullableContext(2)]
	public void Phrase(AbyssChallengeResultInfo data)
	{
		if (data == null)
		{
			return;
		}
		this.PassTime = data.PassTime;
		this.MinPassTime = data.MinPassTime;
		this.IfSuccess = data.Success;
		this.PlayerInfoList = Array.Empty<global::AbyssChallengeResultPlayerInfo>();
		List<global::AbyssChallengeResultPlayerInfo> list = new List<global::AbyssChallengeResultPlayerInfo>();
		int count = data.PlayerInfos.Count;
		for (int i = 0; i < count; i++)
		{
			global::AbyssChallengeResultPlayerInfo abyssChallengeResultPlayerInfo = new global::AbyssChallengeResultPlayerInfo();
			abyssChallengeResultPlayerInfo.Phrase(data.PlayerInfos[i]);
			list.Add(abyssChallengeResultPlayerInfo);
		}
		this.PlayerInfoList = list.ToArray();
	}

	// Token: 0x04005E3B RID: 24123
	private int PassTime;

	// Token: 0x04005E3C RID: 24124
	private int MinPassTime;

	// Token: 0x04005E3D RID: 24125
	private bool IfSuccess;

	// Token: 0x04005E3E RID: 24126
	private global::AbyssChallengeResultPlayerInfo[] PlayerInfoList = Array.Empty<global::AbyssChallengeResultPlayerInfo>();
}
