using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Capability;

namespace CSharpScript.Game.NewWorld.SceneItem.SplineConstrainedDrag.Capability
{
	// Token: 0x02004828 RID: 18472
	[NullableContext(2)]
	[Nullable(0)]
	public class SnapInterpolationData : CapabilityData
	{
		// Token: 0x0603011C RID: 196892 RVA: 0x00BA6BC1 File Offset: 0x00BA4DC1
		public SnapInterpolationData(ICapabilityGameObject ownerGameObject = null) : base(ownerGameObject)
		{
		}

		// Token: 0x0603011D RID: 196893 RVA: 0x00BA6BD5 File Offset: 0x00BA4DD5
		public override void OnAdded()
		{
		}

		// Token: 0x0603011E RID: 196894 RVA: 0x00BA6BD7 File Offset: 0x00BA4DD7
		public override void OnRemoved()
		{
			this.Active = false;
			this.Elapsed = 0f;
			this.SetDistanceFunc = null;
		}

		// Token: 0x0603011F RID: 196895 RVA: 0x00BA6BF4 File Offset: 0x00BA4DF4
		[NullableContext(1)]
		public void SetDistance(float startDistance, float targetDistance, Func<float, bool, float> setDistanceFunc, float? duration = null)
		{
			this.StartDistance = startDistance;
			this.TargetDistance = targetDistance;
			this.SetDistanceFunc = setDistanceFunc;
			float duration2;
			if (duration != null)
			{
				float? num = duration;
				float num2 = 0f;
				if (num.GetValueOrDefault() > num2 & num != null)
				{
					duration2 = duration.Value;
					goto IL_4A;
				}
			}
			duration2 = SnapInterpolationData.DefaultSnapInterpDuration;
			IL_4A:
			this.Duration = duration2;
			this.Elapsed = 0f;
			this.Active = true;
		}

		// Token: 0x06030120 RID: 196896 RVA: 0x00BA6C62 File Offset: 0x00BA4E62
		public void Clear()
		{
			this.Active = false;
			this.Elapsed = 0f;
		}

		// Token: 0x0401B98D RID: 113037
		public static readonly float DefaultSnapInterpDuration = 0.5f;

		// Token: 0x0401B98E RID: 113038
		public Func<float, bool, float> SetDistanceFunc;

		// Token: 0x0401B98F RID: 113039
		public float Duration = SnapInterpolationData.DefaultSnapInterpDuration;

		// Token: 0x0401B990 RID: 113040
		public bool Active;

		// Token: 0x0401B991 RID: 113041
		public float StartDistance;

		// Token: 0x0401B992 RID: 113042
		public float TargetDistance;

		// Token: 0x0401B993 RID: 113043
		public float Elapsed;
	}
}
