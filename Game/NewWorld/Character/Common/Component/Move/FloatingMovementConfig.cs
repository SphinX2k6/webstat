using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004919 RID: 18713
	[NullableContext(1)]
	[Nullable(0)]
	public class FloatingMovementConfig
	{
		// Token: 0x06030E98 RID: 200344 RVA: 0x00C22054 File Offset: 0x00C20254
		public void Init(BP_FloatingMovementConfig_C asset)
		{
			this.MoveSpeed = (float)asset.MoveSpeed;
			this.SprintSpeed = (float)asset.SprintSpeed;
			this.TurnSpeedDeg = (float)asset.TurnSpeedDeg;
			this.EnergyRecoverSpeed = (float)asset.EnergyRecoverSpeed;
			this.EnergyRecoverCoolDownTime = (float)asset.EnergyRecoverCoolDownTime;
			this.AirCriticalHeight = (float)asset.AirCriticalHeight;
			this.CloseToGroundHeight = (float)asset.CloseToGroundHeight;
			this.AirEnergyConsumption = (float)asset.AirEnergyConsumption;
			this.DodgeEnergyConsumption = (float)asset.DodgeEnergyConsumption;
			this.DropEnergyConsumption = (float)asset.DropEnergyConsumption;
			this.FastMoveEnergyConsumption = (float)asset.FastMoveEnergyConsumption;
			this.MoveEnergyConsumption = (float)asset.MoveEnergyConsumption;
			this.RiseEnergyConsumption = (float)asset.RiseEnergyConsumption;
			this.SprintEnergyConsumption = (float)asset.SprintEnergyConsumption;
			this.RiseSpeed = (float)asset.RiseSpeed;
			this.DropSpeed = (float)asset.DropSpeed;
			this.AnimLerpAlpha = asset.AnimLerpAlpha;
			this.SpeedAcceleration = asset.SpeedAcceleration;
			this.DirectionLerpAlpha = asset.DirectionLerpAlpha;
			for (int i = 0; i < asset.ForbidRotationTagList.GameplayTags.Num(); i++)
			{
				this.ForbidRotationTagList.Add(asset.ForbidRotationTagList.GameplayTags.Get(i).TagId());
			}
			for (int j = 0; j < asset.ForbidCloseToGrounTagList.GameplayTags.Num(); j++)
			{
				this.ForbidCloseToGroundTagList.Add(asset.ForbidCloseToGrounTagList.GameplayTags.Get(j).TagId());
			}
			this.DefaultMoveModeConfig.SetConfig(asset.DefaultMode);
			this.FloatingMoveModeConfig.SetConfig(asset.FloatingMode);
			this.RiseMoveModeConfig.SetConfig(asset.RiseMode);
			this.DropMoveModeConfig.SetConfig(asset.DropMode);
			this.WalkMoveModeConfig.SetConfig(asset.WalkMode);
		}

		// Token: 0x0401C224 RID: 115236
		public float MoveSpeed = 600f;

		// Token: 0x0401C225 RID: 115237
		public float SprintSpeed = 1200f;

		// Token: 0x0401C226 RID: 115238
		public float TurnSpeedDeg = 360f;

		// Token: 0x0401C227 RID: 115239
		public float AnimLerpAlpha = 0.1f;

		// Token: 0x0401C228 RID: 115240
		public float SpeedAcceleration = 0.5f;

		// Token: 0x0401C229 RID: 115241
		public float DirectionLerpAlpha = 0.1f;

		// Token: 0x0401C22A RID: 115242
		public float EnergyRecoverSpeed = 10f;

		// Token: 0x0401C22B RID: 115243
		public float EnergyRecoverCoolDownTime = 3f;

		// Token: 0x0401C22C RID: 115244
		public float AirCriticalHeight = 500f;

		// Token: 0x0401C22D RID: 115245
		public float CloseToGroundHeight = 550f;

		// Token: 0x0401C22E RID: 115246
		public float AirEnergyConsumption = 10f;

		// Token: 0x0401C22F RID: 115247
		public float DodgeEnergyConsumption = 10f;

		// Token: 0x0401C230 RID: 115248
		public float DropEnergyConsumption = 5f;

		// Token: 0x0401C231 RID: 115249
		public float FastMoveEnergyConsumption = 15f;

		// Token: 0x0401C232 RID: 115250
		public float MoveEnergyConsumption = 15f;

		// Token: 0x0401C233 RID: 115251
		public float RiseEnergyConsumption = 20f;

		// Token: 0x0401C234 RID: 115252
		public float SprintEnergyConsumption = 20f;

		// Token: 0x0401C235 RID: 115253
		public float RiseSpeed = 300f;

		// Token: 0x0401C236 RID: 115254
		public float DropSpeed = 200f;

		// Token: 0x0401C237 RID: 115255
		public List<int> ForbidRotationTagList = new List<int>();

		// Token: 0x0401C238 RID: 115256
		public List<int> ForbidCloseToGroundTagList = new List<int>();

		// Token: 0x0401C239 RID: 115257
		public MovementStateConfig DefaultMoveModeConfig = new MovementStateConfig();

		// Token: 0x0401C23A RID: 115258
		public MovementStateConfig FloatingMoveModeConfig = new MovementStateConfig();

		// Token: 0x0401C23B RID: 115259
		public MovementStateConfig RiseMoveModeConfig = new MovementStateConfig();

		// Token: 0x0401C23C RID: 115260
		public MovementStateConfig DropMoveModeConfig = new MovementStateConfig();

		// Token: 0x0401C23D RID: 115261
		public MovementStateConfig WalkMoveModeConfig = new MovementStateConfig();
	}
}
