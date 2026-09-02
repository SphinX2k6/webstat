using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.SplineClimb;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004939 RID: 18745
	[NullableContext(1)]
	[Nullable(0)]
	public class SplineClimbParams
	{
		// Token: 0x06031042 RID: 200770 RVA: 0x00C2D654 File Offset: 0x00C2B854
		[NullableContext(2)]
		public SplineClimbParams(BP_SplineClimbConfig_C asset = null)
		{
			if (asset == null)
			{
				return;
			}
			this.Tags = GameplayTagUtils.ConvertFromUeContainer(asset.期间Tag);
			for (int i = 0; i < asset.打断技能.Num(); i++)
			{
				this.InterruptSkills.Add((long)asset.打断技能.Get(i));
			}
			this.SampleLength = asset.采样长度;
			this.SampleInterval = (double)asset.采样间隔;
			this.TraceLength = (double)asset.检测距离;
			this.TraceStartOffset = (double)asset.检测起始偏移;
			this.ExtraWallRadius = (double)asset.离墙额外距离;
			this.DebugDraw = asset.DebugDraw;
		}

		// Token: 0x0401C360 RID: 115552
		public IList<int> Tags = new List<int>();

		// Token: 0x0401C361 RID: 115553
		public List<long> InterruptSkills = new List<long>();

		// Token: 0x0401C362 RID: 115554
		public float SampleLength = 200f;

		// Token: 0x0401C363 RID: 115555
		public double SampleInterval = 50.0;

		// Token: 0x0401C364 RID: 115556
		public double TraceLength = 1500.0;

		// Token: 0x0401C365 RID: 115557
		public double TraceStartOffset = -200.0;

		// Token: 0x0401C366 RID: 115558
		public double ExtraWallRadius = 2.5;

		// Token: 0x0401C367 RID: 115559
		public bool DebugDraw;
	}
}
