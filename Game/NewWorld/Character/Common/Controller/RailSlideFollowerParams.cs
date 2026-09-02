using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.RailSlideFollower;

namespace CSharpScript.Game.NewWorld.Character.Common.Controller
{
	// Token: 0x020048F4 RID: 18676
	public class RailSlideFollowerParams
	{
		// Token: 0x06030C3D RID: 199741 RVA: 0x00C0B8D0 File Offset: 0x00C09AD0
		[NullableContext(1)]
		public RailSlideFollowerParams(BP_RailSlideFollowerConfig_C asset = null)
		{
			if (asset != null)
			{
				this.AutoChangeSide = asset.AutoChangeSide;
				this.DelayStartFollow = (float)asset.DelayStartFollow;
				this.DynamicDistance = (float)asset.DynamicDistance;
				this.FollowOnRight = asset.FollowOnRight;
				this.FrontDistance = (float)asset.FrontDistance;
				this.SideDistance = new ValueTuple<float, float>(asset.SideDistance.X, asset.SideDistance.Y);
				this.ToleranceDistance = Math.Max(20f, (float)asset.ToleranceDistance);
				this.FollowerLerpSpeed = (float)asset.FollowerLerpSpeed;
				this.FollowSpeedStepRate = asset.FollowSpeedStepRate;
			}
		}

		// Token: 0x0401C049 RID: 114761
		public float DelayStartFollow;

		// Token: 0x0401C04A RID: 114762
		public bool FollowOnRight = true;

		// Token: 0x0401C04B RID: 114763
		public bool AutoChangeSide;

		// Token: 0x0401C04C RID: 114764
		public float DynamicDistance;

		// Token: 0x0401C04D RID: 114765
		public float FrontDistance;

		// Token: 0x0401C04E RID: 114766
		public float FollowerLerpSpeed;

		// Token: 0x0401C04F RID: 114767
		public float FollowSpeedStepRate;

		// Token: 0x0401C050 RID: 114768
		public ValueTuple<float, float> SideDistance = new ValueTuple<float, float>(0f, 0f);

		// Token: 0x0401C051 RID: 114769
		public float ToleranceDistance;

		// Token: 0x0401C052 RID: 114770
		private const float FOLLOWER_TOLERANCE_DIST = 20f;
	}
}
