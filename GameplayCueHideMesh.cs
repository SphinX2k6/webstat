using System;
using UnrealEngine;

// Token: 0x02002FA9 RID: 12201
public class GameplayCueHideMesh : GameplayCueBase
{
	// Token: 0x06018E1B RID: 101915 RVA: 0x0070C410 File Offset: 0x0070A610
	protected override void OnCreate()
	{
		this.HideMesh(true);
	}

	// Token: 0x06018E1C RID: 101916 RVA: 0x0070C419 File Offset: 0x0070A619
	protected override void OnDestroy()
	{
		this.HideMesh(false);
	}

	// Token: 0x06018E1D RID: 101917 RVA: 0x0070C424 File Offset: 0x0070A624
	private void HideMesh(bool bStart)
	{
		if (this.CueConfig.ParametersLength == 0)
		{
			return;
		}
		foreach (UActorComponent uactorComponent in this.ActorInternal.K2_GetComponentsByClass(UMeshComponent.StaticClass()))
		{
			if (uactorComponent.GetName() == this.CueConfig.Parameters(0))
			{
				bool flag = ((this.CueConfig.ParametersLength > 1) ? this.CueConfig.Parameters(1) : "1") == "1";
				if (!bStart)
				{
					flag = !flag;
				}
				bool bPropagateToChildren = ((this.CueConfig.ParametersLength > 2) ? this.CueConfig.Parameters(2) : "1") == "1";
				((UMeshComponent)uactorComponent).SetHiddenInGame(flag, bPropagateToChildren);
			}
		}
	}
}
