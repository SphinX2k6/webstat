using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.ControlMonster;
using UnrealEngine;

// Token: 0x02003050 RID: 12368
public class AutomaticFlightData
{
	// Token: 0x06019599 RID: 103833 RVA: 0x0074D89C File Offset: 0x0074BA9C
	[NullableContext(1)]
	public AutomaticFlightData(ICM_AutomaticFlight_DataBase_C dataAsset)
	{
		this.MinFlySpeed = new float?(dataAsset.低飞行速度);
		this.NormalFlySpeed = new float?(dataAsset.标准飞行速度);
		this.MaxFlySpeed = new float?(dataAsset.高飞行速度);
		this.SpeedTransitionCurve = dataAsset.速度过渡曲线;
		this.ForwardAxisResponseValue = new float?(dataAsset.前向轴输入响应比例);
		this.BackwardAxisResponseValue = new float?((dataAsset.后向轴输入响应比例 > 0f) ? (-dataAsset.后向轴输入响应比例) : dataAsset.后向轴输入响应比例);
		this.ForwardSkill = new int?(dataAsset.前向轴输入响应技能);
		this.BackwardSkill = new int?(dataAsset.后向轴输入响应技能);
	}

	// Token: 0x0400C874 RID: 51316
	public float? MinFlySpeed;

	// Token: 0x0400C875 RID: 51317
	public float? NormalFlySpeed;

	// Token: 0x0400C876 RID: 51318
	public float? MaxFlySpeed;

	// Token: 0x0400C877 RID: 51319
	[Nullable(2)]
	public UCurveVector SpeedTransitionCurve;

	// Token: 0x0400C878 RID: 51320
	public float? ForwardAxisResponseValue;

	// Token: 0x0400C879 RID: 51321
	public float? BackwardAxisResponseValue;

	// Token: 0x0400C87A RID: 51322
	public int? ForwardSkill;

	// Token: 0x0400C87B RID: 51323
	public int? BackwardSkill;

	// Token: 0x0400C87C RID: 51324
	public int? CurrentSkill;

	// Token: 0x0400C87D RID: 51325
	public float? FlySpeed;

	// Token: 0x0400C87E RID: 51326
	public float? LastFlySpeed;

	// Token: 0x0400C87F RID: 51327
	public float? TargetFlySpeed;

	// Token: 0x0400C880 RID: 51328
	public EAutomaticFlightState LastState;

	// Token: 0x0400C881 RID: 51329
	public EAutomaticFlightState CurrentState;
}
