using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.SummonGongduola;

namespace CSharpScript.Game.LevelGamePlay.GongduolaSummon
{
	// Token: 0x02006E83 RID: 28291
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class GongduolaSummonModel : ModelBase<GongduolaSummonModel>
	{
		// Token: 0x060449CA RID: 281034 RVA: 0x011D6879 File Offset: 0x011D4A79
		protected override bool OnInit()
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<BP_SummonGongduolaConfig_C>(this.ConfigDaPath, delegate([Nullable(2)] BP_SummonGongduolaConfig_C result, string _)
			{
				if (result == null || !result.IsValid())
				{
					Singleton<Log>.Instance.Error(ELogModule.SummonGongduola, ELogAuthor.CH, "[GongduolaSummonModel] Load Config DA Failed", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				this.SummonConfig = result;
				this.IsLoaded = true;
			}, 100, "js_undefined");
			return true;
		}

		// Token: 0x04026315 RID: 156437
		[Nullable(1)]
		public readonly string CancelSummonAmPath = "/Game/Aki/Character/NPC/AlienNPC/Level_B/SB1Gongduola3/BaseAnim/AM_CancelSummon.AM_CancelSummon";

		// Token: 0x04026316 RID: 156438
		[Nullable(1)]
		public readonly string SummonAmPath = "/Game/Aki/Character/NPC/AlienNPC/Level_B/SB1Gongduola3/BaseAnim/AM_Summon.AM_Summon";

		// Token: 0x04026317 RID: 156439
		[Nullable(1)]
		private readonly string ConfigDaPath = "/Game/Aki/Data/Level/SummonGongduola/DA_SummonGongduolaConfig.DA_SummonGongduolaConfig";

		// Token: 0x04026318 RID: 156440
		public BaseActorComponent SummonedActorComp;

		// Token: 0x04026319 RID: 156441
		public Vector SummonLocation;

		// Token: 0x0402631A RID: 156442
		public Rotator SummonRotation;

		// Token: 0x0402631B RID: 156443
		public Vector SummonGravityDir;

		// Token: 0x0402631C RID: 156444
		public BP_SummonGongduolaConfig_C SummonConfig;

		// Token: 0x0402631D RID: 156445
		[Nullable(1)]
		public readonly string BanInputReason = "SummonGongduola Ban Input";

		// Token: 0x0402631E RID: 156446
		public bool IsLoaded;
	}
}
