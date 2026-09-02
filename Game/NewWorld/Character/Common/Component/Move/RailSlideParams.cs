using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Data.Level.RailSlide;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004934 RID: 18740
	[NullableContext(2)]
	[Nullable(0)]
	public class RailSlideParams
	{
		// Token: 0x06030FFE RID: 200702 RVA: 0x00C2BF30 File Offset: 0x00C2A130
		public RailSlideParams(BP_RailSlideConfig_C asset = null, bool? isKatixiya = null, int pbDataId = 0)
		{
			if (asset != null)
			{
				this.PbDataId = pbDataId;
				this.InitSpeed = asset.初始速度;
				this.BaseTargetSpeed = asset.基础目标速度;
				this.BaseAcceleration = asset.基础加速度;
				this.AccelerationForUp = asset.上坡加速度;
				this.AccelerationForDown = asset.下坡加速度;
				this.TargetSpeedForUp = asset.上坡目标速度;
				this.TargetSpeedForDown = asset.下坡目标速度;
				this.AccelerationAngle = asset.最大加速度角度;
				this.MaxLandSpeed = asset.落地最大速度;
				this.MinLandSpeed = asset.落地最小速度;
				this.SideJumpParams = new RailSlideJumpParams();
				this.SideJumpParams.InitSideJump(asset, isKatixiya);
				this.StartJumpSpeed = asset.初始进入轨道速度;
				this.LeaningBlendAlpha = asset.倾斜输入插值;
				this.MaxLeaningAngle = asset.最大倾斜角度;
				this.LimitInputAngle = asset.限制输入角度;
				this.DisableGravityLean = asset.禁止重力方向倾斜;
				this.DisablePitchLean = asset.禁止前后俯仰倾斜;
				this.ChangeRailCooldownTime = asset.切换轨道CD;
				this.ChangeRailDistance = asset.切换轨道水平距离;
				this.ChangeRailHeight = asset.切换轨道垂直距离;
				this.ChangeRailSpeed = asset.切换轨道基速度;
				this.MoveCurve = (isKatixiya.GetValueOrDefault() ? asset.位移曲线_卡提西亚.FloatCurve : asset.位移曲线.FloatCurve);
				this.DebugDraw = asset.DebugDraw;
				this.AnimationType = (asset.是否启用定制动作_DEPRECATED ? ERailSlideAnimType.SlopeSlide : asset.滑轨动画类型);
				this.LandAnimation = (asset.是否有落地动画 || (isKatixiya.GetValueOrDefault() && this.AnimationType == ERailSlideAnimType.Normal));
				this.FreeJumpParams = new RailSlideJumpParams();
				this.FreeJumpParams.InitFreeJump(asset);
				this.ControlData = new RailControlData(asset, pbDataId);
				for (int i = 0; i < asset.打断技能列表.Num(); i++)
				{
					this.InterruptSkillList.Add((long)asset.打断技能列表.Get(i));
				}
				for (int j = 0; j < asset.期间Tag.GameplayTags.Num(); j++)
				{
					this.TagList.Add(asset.期间Tag.GameplayTags.Get(j).TagId());
				}
			}
		}

		// Token: 0x06030FFF RID: 200703 RVA: 0x00C2C228 File Offset: 0x00C2A428
		[NullableContext(1)]
		public void SetControlState(bool innerArc, List<ISwordRiderRailSplinePoint> points, float halfHeight)
		{
			this.IsControlState = true;
			this.ControlData.InitSplinePoints(innerArc, points, halfHeight);
		}

		// Token: 0x06031000 RID: 200704 RVA: 0x00C2C23F File Offset: 0x00C2A43F
		public bool IsCurrentFreeJump()
		{
			return this.CurrentFreeJump;
		}

		// Token: 0x06031001 RID: 200705 RVA: 0x00C2C247 File Offset: 0x00C2A447
		public void SetCurrentFreeJump(bool value)
		{
			this.CurrentFreeJump = value;
		}

		// Token: 0x1700838C RID: 33676
		// (get) Token: 0x06031002 RID: 200706 RVA: 0x00C2C250 File Offset: 0x00C2A450
		public int BaseJumpHeight
		{
			get
			{
				if (this.CurrentFreeJump && this.FreeJumpParams != null)
				{
					return this.FreeJumpParams.BaseJumpHeight;
				}
				return this.SideJumpParams.BaseJumpHeight;
			}
		}

		// Token: 0x1700838D RID: 33677
		// (get) Token: 0x06031003 RID: 200707 RVA: 0x00C2C279 File Offset: 0x00C2A479
		public float BaseJumpDistanceRate
		{
			get
			{
				if (this.CurrentFreeJump && this.FreeJumpParams != null)
				{
					return this.FreeJumpParams.BaseJumpDistanceRate;
				}
				return this.SideJumpParams.BaseJumpDistanceRate;
			}
		}

		// Token: 0x1700838E RID: 33678
		// (get) Token: 0x06031004 RID: 200708 RVA: 0x00C2C2A2 File Offset: 0x00C2A4A2
		public int MaxJumpDistance
		{
			get
			{
				if (this.CurrentFreeJump && this.FreeJumpParams != null)
				{
					return this.FreeJumpParams.MaxJumpDistance;
				}
				return this.SideJumpParams.MaxJumpDistance;
			}
		}

		// Token: 0x1700838F RID: 33679
		// (get) Token: 0x06031005 RID: 200709 RVA: 0x00C2C2CB File Offset: 0x00C2A4CB
		public int MaxJumpHeight
		{
			get
			{
				if (this.CurrentFreeJump && this.FreeJumpParams != null)
				{
					return this.FreeJumpParams.MaxJumpHeight;
				}
				return this.SideJumpParams.MaxJumpHeight;
			}
		}

		// Token: 0x17008390 RID: 33680
		// (get) Token: 0x06031006 RID: 200710 RVA: 0x00C2C2F4 File Offset: 0x00C2A4F4
		public int JumpAcceleration
		{
			get
			{
				if (this.CurrentFreeJump && this.FreeJumpParams != null)
				{
					return this.FreeJumpParams.JumpAcceleration;
				}
				return this.SideJumpParams.JumpAcceleration;
			}
		}

		// Token: 0x17008391 RID: 33681
		// (get) Token: 0x06031007 RID: 200711 RVA: 0x00C2C31D File Offset: 0x00C2A51D
		public int TargetSpeedForJump
		{
			get
			{
				if (this.CurrentFreeJump && this.FreeJumpParams != null)
				{
					return this.FreeJumpParams.TargetSpeedForJump;
				}
				return this.SideJumpParams.TargetSpeedForJump;
			}
		}

		// Token: 0x17008392 RID: 33682
		// (get) Token: 0x06031008 RID: 200712 RVA: 0x00C2C346 File Offset: 0x00C2A546
		public int AllTimeForJump
		{
			get
			{
				if (this.CurrentFreeJump && this.FreeJumpParams != null)
				{
					return this.FreeJumpParams.AllTimeForJump;
				}
				return this.SideJumpParams.AllTimeForJump;
			}
		}

		// Token: 0x17008393 RID: 33683
		// (get) Token: 0x06031009 RID: 200713 RVA: 0x00C2C36F File Offset: 0x00C2A56F
		public int JumpBlendTime
		{
			get
			{
				if (this.CurrentFreeJump && this.FreeJumpParams != null)
				{
					return this.FreeJumpParams.JumpBlendTime;
				}
				return this.SideJumpParams.JumpBlendTime;
			}
		}

		// Token: 0x17008394 RID: 33684
		// (get) Token: 0x0603100A RID: 200714 RVA: 0x00C2C398 File Offset: 0x00C2A598
		public int LandBlendTime
		{
			get
			{
				if (this.CurrentFreeJump && this.FreeJumpParams != null)
				{
					return this.FreeJumpParams.LandBlendTime;
				}
				return this.SideJumpParams.LandBlendTime;
			}
		}

		// Token: 0x0401C30F RID: 115471
		public int InitSpeed = 700;

		// Token: 0x0401C310 RID: 115472
		public int BaseTargetSpeed = 1000;

		// Token: 0x0401C311 RID: 115473
		public int BaseAcceleration = 300;

		// Token: 0x0401C312 RID: 115474
		public int AccelerationForUp = -300;

		// Token: 0x0401C313 RID: 115475
		public int TargetSpeedForUp = 700;

		// Token: 0x0401C314 RID: 115476
		public int AccelerationForDown = 300;

		// Token: 0x0401C315 RID: 115477
		public int TargetSpeedForDown = 1000;

		// Token: 0x0401C316 RID: 115478
		public int AccelerationAngle = 20;

		// Token: 0x0401C317 RID: 115479
		public int MaxLandSpeed = 2000;

		// Token: 0x0401C318 RID: 115480
		public int MinLandSpeed = 500;

		// Token: 0x0401C319 RID: 115481
		public RailSlideJumpParams SideJumpParams;

		// Token: 0x0401C31A RID: 115482
		public RailSlideJumpParams FreeJumpParams;

		// Token: 0x0401C31B RID: 115483
		public RailControlData ControlData;

		// Token: 0x0401C31C RID: 115484
		public float LeaningBlendAlpha = 0.1f;

		// Token: 0x0401C31D RID: 115485
		public int MaxLeaningAngle = 45;

		// Token: 0x0401C31E RID: 115486
		public int LimitInputAngle = 5;

		// Token: 0x0401C31F RID: 115487
		public bool DisableGravityLean;

		// Token: 0x0401C320 RID: 115488
		public bool DisablePitchLean;

		// Token: 0x0401C321 RID: 115489
		public int ChangeRailCooldownTime = 1000;

		// Token: 0x0401C322 RID: 115490
		public int ChangeRailDistance = 1000;

		// Token: 0x0401C323 RID: 115491
		public int ChangeRailHeight = 400;

		// Token: 0x0401C324 RID: 115492
		public int ChangeRailSpeed = 1000;

		// Token: 0x0401C325 RID: 115493
		public int StartJumpSpeed = 1000;

		// Token: 0x0401C326 RID: 115494
		[Nullable(1)]
		public List<long> InterruptSkillList = new List<long>();

		// Token: 0x0401C327 RID: 115495
		public UCurveFloat MoveCurve;

		// Token: 0x0401C328 RID: 115496
		[Nullable(1)]
		public List<int> TagList = new List<int>();

		// Token: 0x0401C329 RID: 115497
		public bool DebugDraw;

		// Token: 0x0401C32A RID: 115498
		public bool LandAnimation;

		// Token: 0x0401C32B RID: 115499
		public ERailSlideAnimType AnimationType;

		// Token: 0x0401C32C RID: 115500
		private readonly int PbDataId;

		// Token: 0x0401C32D RID: 115501
		public bool IsControlState;

		// Token: 0x0401C32E RID: 115502
		private bool CurrentFreeJump;
	}
}
