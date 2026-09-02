using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.Ski;
using UnrealEngine;

// Token: 0x020030D2 RID: 12498
[NullableContext(1)]
[Nullable(0)]
public class SkiParams
{
	// Token: 0x06019C9A RID: 105626 RVA: 0x007848C8 File Offset: 0x00782AC8
	public SkiParams(BP_SkiConfig_C asset)
	{
		this.InitSpeed = asset.初始速度;
		this.BaseAccForSpeedUp = asset.基础加速度;
		this.BaseAccForSpeedDown = asset.基础减速度;
		this.BaseTargetSpeed = asset.基础目标速度;
		this.SlopExtraTargetSpeed = asset.斜坡额外目标速度;
		this.SlopExtraAccel = asset.斜坡额外加速度;
		this.TurnSpeed = asset.转向速度;
		this.IgnoreStepHeight = asset.忽视阶梯高度;
		this.JumpTurnRate = asset.跳跃转向速度系数;
		this.JumpHeightRate = asset.跳跃高度缩放系数;
		this.JumpTimeScale = asset.跳跃滞空缩放系数;
		this.JumpMaxHorizontalSpeed = asset.跳跃下落最大平面速度;
		TArray<FGameplayTag> gameplayTags = asset.期间Tag.GameplayTags;
		int num = gameplayTags.Num();
		for (int i = 0; i < num; i++)
		{
			this.TagList.Add(gameplayTags.Get(i).TagId());
		}
	}

	// Token: 0x0400CDBE RID: 52670
	public float InitSpeed = 700f;

	// Token: 0x0400CDBF RID: 52671
	public float BaseAccForSpeedUp = 300f;

	// Token: 0x0400CDC0 RID: 52672
	public float BaseAccForSpeedDown = 300f;

	// Token: 0x0400CDC1 RID: 52673
	public float BaseTargetSpeed = 1000f;

	// Token: 0x0400CDC2 RID: 52674
	public float SlopExtraTargetSpeed = 200f;

	// Token: 0x0400CDC3 RID: 52675
	public float SlopExtraAccel = 150f;

	// Token: 0x0400CDC4 RID: 52676
	public float TurnSpeed = 50f;

	// Token: 0x0400CDC5 RID: 52677
	public float IgnoreStepHeight = 20f;

	// Token: 0x0400CDC6 RID: 52678
	public float JumpMaxHorizontalSpeed = 3500f;

	// Token: 0x0400CDC7 RID: 52679
	public float JumpTurnRate = 0.4f;

	// Token: 0x0400CDC8 RID: 52680
	public float JumpHeightRate = 1f;

	// Token: 0x0400CDC9 RID: 52681
	public float JumpTimeScale = 1f;

	// Token: 0x0400CDCA RID: 52682
	public List<int> TagList = new List<int>();

	// Token: 0x0400CDCB RID: 52683
	private const int DEFAULT_SKI_MAX_SPEED = 3500;
}
