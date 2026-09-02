using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.WaterInteraction;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004787 RID: 18311
	[NullableContext(1)]
	[Nullable(0)]
	public class WaterEffectSubConfig
	{
		// Token: 0x0602F821 RID: 194593 RVA: 0x00B4E7D0 File Offset: 0x00B4C9D0
		public bool ShouldUseShallowFootSplashes(double depth)
		{
			return this.ShallowMoveEffects.Count > 0 && depth < (double)this.ShallowMoveDepthThreshold;
		}

		// Token: 0x0602F822 RID: 194594 RVA: 0x00B4E7EC File Offset: 0x00B4C9EC
		[NullableContext(2)]
		public WaterEffectItem FindShallowMoveEffect(double depth, double speed)
		{
			if (!this.ShouldUseShallowFootSplashes(depth))
			{
				return null;
			}
			return this.FindMoveEffectInGroups(this.ShallowMoveEffects, depth, speed);
		}

		// Token: 0x0602F823 RID: 194595 RVA: 0x00B4E807 File Offset: 0x00B4CA07
		[NullableContext(2)]
		public WaterEffectItem FindWadeMoveEffect(double depth, double speed)
		{
			if (this.ShouldUseShallowFootSplashes(depth))
			{
				return null;
			}
			return this.FindMoveEffectInGroups(this.MoveEffects, depth, speed);
		}

		// Token: 0x0602F824 RID: 194596 RVA: 0x00B4E822 File Offset: 0x00B4CA22
		[NullableContext(2)]
		public WaterEffectItem FindMoveEffect(double depth, double speed)
		{
			return this.FindMoveEffectInGroups(this.MoveEffects, depth, speed);
		}

		// Token: 0x0602F825 RID: 194597 RVA: 0x00B4E834 File Offset: 0x00B4CA34
		[return: Nullable(2)]
		private WaterEffectItem FindMoveEffectInGroups(List<WaterEffectGroup> groups, double depth, double speed)
		{
			int num = 0;
			while (num < groups.Count && depth >= groups[num].WaterDepthThreshold)
			{
				num++;
			}
			if (num == 0)
			{
				return null;
			}
			return groups[num - 1].FindEffectAtSpeed(speed);
		}

		// Token: 0x0602F826 RID: 194598 RVA: 0x00B4E878 File Offset: 0x00B4CA78
		[NullableContext(2)]
		public WaterEffectItem FindFallEffectAtSpeed(float speed)
		{
			int num = 0;
			while (num < this.FallEffects.Count && (double)speed >= this.FallEffects[num].SpeedThreshold)
			{
				num++;
			}
			if (num == 0)
			{
				return null;
			}
			return this.FallEffects[num - 1];
		}

		// Token: 0x0602F827 RID: 194599 RVA: 0x00B4E8C4 File Offset: 0x00B4CAC4
		[NullableContext(2)]
		public WaterEffectItem FindJumpEffectAtSpeed(float speed)
		{
			int num = 0;
			while (num < this.JumpEffects.Count && (double)speed >= this.JumpEffects[num].SpeedThreshold)
			{
				num++;
			}
			if (num == 0)
			{
				return null;
			}
			return this.JumpEffects[num - 1];
		}

		// Token: 0x0602F828 RID: 194600 RVA: 0x00B4E910 File Offset: 0x00B4CB10
		[NullableContext(2)]
		public WaterEffectItem FindFlyEffectAtSpeed(float speed)
		{
			int num = 0;
			while (num < this.FlyEffects.Count && (double)speed >= this.FlyEffects[num].SpeedThreshold)
			{
				num++;
			}
			if (num == 0)
			{
				return null;
			}
			return this.FlyEffects[num - 1];
		}

		// Token: 0x0602F829 RID: 194601 RVA: 0x00B4E95C File Offset: 0x00B4CB5C
		public void Init(SWaterEffectSubConfig configData)
		{
			this.MoveEffects.Clear();
			this.ShallowMoveEffects.Clear();
			this.FallEffects.Clear();
			this.JumpEffects.Clear();
			this.FlyEffects.Clear();
			int num = configData.MoveEffects.Num();
			for (int i = 0; i < num; i++)
			{
				WaterEffectGroup waterEffectGroup = new WaterEffectGroup();
				waterEffectGroup.Init(configData.MoveEffects.Get(i));
				this.MoveEffects.Add(waterEffectGroup);
			}
			int num2 = configData.ShallowMoveEffects.Num();
			for (int j = 0; j < num2; j++)
			{
				WaterEffectGroup waterEffectGroup2 = new WaterEffectGroup();
				waterEffectGroup2.Init(configData.ShallowMoveEffects.Get(j));
				this.ShallowMoveEffects.Add(waterEffectGroup2);
			}
			this.ShallowMoveDepthThreshold = configData.ShallowMoveDepthThreshold;
			int num3 = configData.FallEffects.Num();
			for (int k = 0; k < num3; k++)
			{
				WaterEffectItem waterEffectItem = new WaterEffectItem();
				waterEffectItem.Init(configData.FallEffects.Get(k));
				this.FallEffects.Add(waterEffectItem);
			}
			int num4 = configData.JumpEffects.Num();
			for (int l = 0; l < num4; l++)
			{
				WaterEffectItem waterEffectItem2 = new WaterEffectItem();
				waterEffectItem2.Init(configData.JumpEffects.Get(l));
				this.JumpEffects.Add(waterEffectItem2);
			}
			int num5 = configData.FlyEffects.Num();
			for (int m = 0; m < num5; m++)
			{
				WaterEffectItem waterEffectItem3 = new WaterEffectItem();
				waterEffectItem3.Init(configData.FlyEffects.Get(m));
				this.FlyEffects.Add(waterEffectItem3);
			}
			this.FallJumpDepthThreshold = configData.FallJumpDepthThreshold;
			this.TriggerInGrass = configData.TriggerInGrass;
			this.FlyEffectHeightThreshold = configData.FlyEffectTriggerHeight;
		}

		// Token: 0x0401B297 RID: 111255
		public List<WaterEffectGroup> MoveEffects = new List<WaterEffectGroup>();

		// Token: 0x0401B298 RID: 111256
		public List<WaterEffectGroup> ShallowMoveEffects = new List<WaterEffectGroup>();

		// Token: 0x0401B299 RID: 111257
		public float ShallowMoveDepthThreshold;

		// Token: 0x0401B29A RID: 111258
		public List<WaterEffectItem> FallEffects = new List<WaterEffectItem>();

		// Token: 0x0401B29B RID: 111259
		public List<WaterEffectItem> JumpEffects = new List<WaterEffectItem>();

		// Token: 0x0401B29C RID: 111260
		public List<WaterEffectItem> FlyEffects = new List<WaterEffectItem>();

		// Token: 0x0401B29D RID: 111261
		public float FallJumpDepthThreshold;

		// Token: 0x0401B29E RID: 111262
		public bool TriggerInGrass;

		// Token: 0x0401B29F RID: 111263
		public float FlyEffectHeightThreshold;
	}
}
