using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.RailSlide;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004933 RID: 18739
	[NullableContext(1)]
	[Nullable(0)]
	public class RailSlideJumpParams
	{
		// Token: 0x06030FFB RID: 200699 RVA: 0x00C2BDA0 File Offset: 0x00C29FA0
		public void InitSideJump(BP_RailSlideConfig_C asset, bool? isKatixiya = null)
		{
			this.BaseJumpDistanceRate = asset.基础跳远倍率;
			this.BaseJumpHeight = asset.基础跳跃高度;
			this.MaxJumpDistance = asset.最大跳跃距离;
			this.MaxJumpHeight = asset.最大跳跃高度;
			this.JumpAcceleration = (isKatixiya.GetValueOrDefault() ? asset.起跳加速度_卡提西亚 : asset.起跳加速度);
			this.TargetSpeedForJump = asset.起跳目标速度;
			this.AllTimeForJump = asset.跳跃空中总时长;
			this.JumpBlendTime = (isKatixiya.GetValueOrDefault() ? asset.起跳时长_卡提西亚 : asset.起跳时长);
			this.LandBlendTime = (isKatixiya.GetValueOrDefault() ? asset.落地时长_卡提西亚 : asset.落地时长);
		}

		// Token: 0x06030FFC RID: 200700 RVA: 0x00C2BE4C File Offset: 0x00C2A04C
		public void InitFreeJump(BP_RailSlideConfig_C asset)
		{
			this.BaseJumpDistanceRate = asset.前向基础跳远倍率;
			this.BaseJumpHeight = asset.前向基础跳跃高度;
			this.MaxJumpDistance = asset.前向最大跳跃距离;
			this.MaxJumpHeight = asset.前向最大跳跃高度;
			this.JumpAcceleration = asset.前向起跳加速度;
			this.TargetSpeedForJump = asset.前向起跳目标速度;
			this.AllTimeForJump = asset.前向跳跃空中总时长;
			this.JumpBlendTime = asset.前向起跳时长;
			this.LandBlendTime = asset.前向落地时长;
		}

		// Token: 0x0401C306 RID: 115462
		public int BaseJumpHeight = 50;

		// Token: 0x0401C307 RID: 115463
		public float BaseJumpDistanceRate = 0.5f;

		// Token: 0x0401C308 RID: 115464
		public int MaxJumpDistance = 1000;

		// Token: 0x0401C309 RID: 115465
		public int MaxJumpHeight = 300;

		// Token: 0x0401C30A RID: 115466
		public int JumpAcceleration = -1000;

		// Token: 0x0401C30B RID: 115467
		public int TargetSpeedForJump = 300;

		// Token: 0x0401C30C RID: 115468
		public int AllTimeForJump = 800;

		// Token: 0x0401C30D RID: 115469
		public int JumpBlendTime = 200;

		// Token: 0x0401C30E RID: 115470
		public int LandBlendTime;
	}
}
