using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.Structure;
using UnrealEngine;

// Token: 0x02003052 RID: 12370
[NullableContext(1)]
[Nullable(0)]
public class CameraFollowInputConfig
{
	// Token: 0x0601959B RID: 103835 RVA: 0x0074D950 File Offset: 0x0074BB50
	public void Init(BP_FirstPersonConfig_C asset, int triggerTagId)
	{
		this.TriggerTagId = triggerTagId;
		this.ForwardAngle = (float)asset.ForwardAngle;
		this.DashInForwardAngle = asset.DashInForwardAngle;
		int num = 0;
		for (;;)
		{
			int num2 = num;
			int? num3 = (asset != null) ? new int?(asset.FirstPersonTagList.GameplayTags.Num()) : null;
			if (!(num2 < num3.GetValueOrDefault() & num3 != null))
			{
				break;
			}
			this.FirstPersonTagList.Add(asset.FirstPersonTagList.GameplayTags.Get(num).TagId());
			num++;
		}
		int num4 = 0;
		for (;;)
		{
			int num5 = num4;
			int? num3 = (asset != null) ? new int?(asset.ForbidRotationTagList.GameplayTags.Num()) : null;
			if (!(num5 < num3.GetValueOrDefault() & num3 != null))
			{
				break;
			}
			this.ForbidRotationTagList.Add(asset.ForbidRotationTagList.GameplayTags.Get(num4).TagId());
			num4++;
		}
	}

	// Token: 0x0400C889 RID: 51337
	public int TriggerTagId;

	// Token: 0x0400C88A RID: 51338
	public float ForwardAngle = 50f;

	// Token: 0x0400C88B RID: 51339
	public bool DashInForwardAngle = true;

	// Token: 0x0400C88C RID: 51340
	public List<int> FirstPersonTagList = new List<int>();

	// Token: 0x0400C88D RID: 51341
	public List<int> ForbidRotationTagList = new List<int>();
}
