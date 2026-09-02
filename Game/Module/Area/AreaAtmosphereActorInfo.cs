using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Area
{
	// Token: 0x02006173 RID: 24947
	[NullableContext(2)]
	[Nullable(0)]
	public class AreaAtmosphereActorInfo
	{
		// Token: 0x0603F0BA RID: 258234 RVA: 0x0102A3D8 File Offset: 0x010285D8
		public void Clear()
		{
			this.AreaAtmosphereInfo = null;
			if (this.Actor != null)
			{
				Singleton<ActorSystem>.Instance.Put("AreaAtmosphereActorInfo.Clear", this.Actor, null);
			}
			this.Actor = null;
			this.KuroPostProcessComponent = null;
		}

		// Token: 0x040235E7 RID: 144871
		public AreaAtmosphereInfo? AreaAtmosphereInfo;

		// Token: 0x040235E8 RID: 144872
		public AActor Actor;

		// Token: 0x040235E9 RID: 144873
		public UKuroPostProcessComponent KuroPostProcessComponent;

		// Token: 0x040235EA RID: 144874
		public float TargetBlendWeight;

		// Token: 0x040235EB RID: 144875
		public float CurBlendWeight;

		// Token: 0x040235EC RID: 144876
		public float ChangeSpeed;

		// Token: 0x040235ED RID: 144877
		public bool IsLoadCompleted;
	}
}
