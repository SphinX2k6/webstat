using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.AssistedWalk;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move.AttachMove;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move.AssistedWalk
{
	// Token: 0x02004942 RID: 18754
	[NullableContext(1)]
	[Nullable(0)]
	public class AssistedWalkParams : AttachMoveParams
	{
		// Token: 0x170083A7 RID: 33703
		// (get) Token: 0x06031088 RID: 200840 RVA: 0x00C3015B File Offset: 0x00C2E35B
		public static AssistedWalkParams Default { get; } = new AssistedWalkParams(null);

		// Token: 0x06031089 RID: 200841 RVA: 0x00C30164 File Offset: 0x00C2E364
		[NullableContext(2)]
		public AssistedWalkParams(BP_AssistedWalkConfig_C data = null) : base(data)
		{
			if (data == null)
			{
				return;
			}
			this.BaseMoveSpeed = (float)data.BaseMoveSpeed;
			this.LeaderTurnSpeed = (float)data.LeaderTurnSpeed;
			this.AnimSpeedRateRange.Set((double)data.AnimSpeedRateRange.X, (double)data.AnimSpeedRateRange.Y);
			Transform startTransform = this.StartTransform;
			FTransform startTransform2 = data.StartTransform;
			startTransform.FromUeTransform(startTransform2);
			for (int i = 0; i < data.LeaderGameplayTagList.GameplayTags.Num(); i++)
			{
				this.LeaderGameplayTagList.Add(data.LeaderGameplayTagList.GameplayTags.Get(i).TagId());
			}
		}

		// Token: 0x0401C3A5 RID: 115621
		public List<int> LeaderGameplayTagList = new List<int>();

		// Token: 0x0401C3A6 RID: 115622
		public float BaseMoveSpeed = 45f;

		// Token: 0x0401C3A7 RID: 115623
		public float LeaderTurnSpeed = 30f;

		// Token: 0x0401C3A8 RID: 115624
		public Vector2D AnimSpeedRateRange = new Vector2D(1.0, 1.0);

		// Token: 0x0401C3A9 RID: 115625
		public Transform StartTransform = Transform.Create();
	}
}
