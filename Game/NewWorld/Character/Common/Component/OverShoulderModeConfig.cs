using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.Structure;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x0200490A RID: 18698
	[NullableContext(1)]
	[Nullable(0)]
	public class OverShoulderModeConfig
	{
		// Token: 0x06030DE0 RID: 200160 RVA: 0x00C1B348 File Offset: 0x00C19548
		public void InitFromAsset(BP_OverShoulderModeConfig_C asset)
		{
			this.MaxTurnSpeed = asset.MaxTurnSpeed;
			this.MinTurnSpeed = asset.MinTurnSpeed;
			this.LerpBeginDeg = asset.LerpBeginDeg;
			this.LerpPow = asset.LerpPow;
			this.LerpCurve = asset.LerpCurve;
			this.SprintExitDegAbs = asset.SprintExitInputDegAbs;
			for (int i = 0; i < asset.TagList.GameplayTags.Num(); i++)
			{
				this.TagList.Add(asset.TagList.GameplayTags.Get(i).TagId());
			}
		}

		// Token: 0x06030DE1 RID: 200161 RVA: 0x00C1B3D9 File Offset: 0x00C195D9
		public bool IsValid()
		{
			return this.MinTurnSpeed <= this.MaxTurnSpeed && this.MinTurnSpeed > 0f && this.SprintExitDegAbs > 0f;
		}

		// Token: 0x06030DE2 RID: 200162 RVA: 0x00C1B408 File Offset: 0x00C19608
		public void TryAddOrRemoveTags(Entity entity, bool isAdd = true)
		{
			BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
			if (component == null)
			{
				return;
			}
			if (isAdd)
			{
				for (int i = 0; i < this.TagList.Count; i++)
				{
					component.AddTag(new int?(this.TagList[i]));
				}
				return;
			}
			for (int j = 0; j < this.TagList.Count; j++)
			{
				component.RemoveTag(new int?(this.TagList[j]));
			}
		}

		// Token: 0x06030DE3 RID: 200163 RVA: 0x00C1B480 File Offset: 0x00C19680
		public float GetLerpDegAlpha(float inAlpha)
		{
			float num = Singleton<MathUtils>.Instance.Clamp(inAlpha, 0f, 1f);
			UCurveFloat lerpCurve = this.LerpCurve;
			if (lerpCurve != null && lerpCurve.IsValid())
			{
				return Singleton<MathUtils>.Instance.Clamp(this.LerpCurve.GetFloatValue(num), 0f, 1f);
			}
			return MathF.Pow(num, this.LerpPow);
		}

		// Token: 0x0401C16A RID: 115050
		public float MaxTurnSpeed;

		// Token: 0x0401C16B RID: 115051
		public float MinTurnSpeed;

		// Token: 0x0401C16C RID: 115052
		public float LerpBeginDeg;

		// Token: 0x0401C16D RID: 115053
		public float SprintExitDegAbs;

		// Token: 0x0401C16E RID: 115054
		public float LerpPow = 1f;

		// Token: 0x0401C16F RID: 115055
		[Nullable(2)]
		public UCurveFloat LerpCurve;

		// Token: 0x0401C170 RID: 115056
		public List<int> TagList = new List<int>();
	}
}
