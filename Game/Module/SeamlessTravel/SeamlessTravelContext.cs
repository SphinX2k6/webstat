using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.SeamlessTravel
{
	// Token: 0x02005000 RID: 20480
	[NullableContext(2)]
	[Nullable(0)]
	public class SeamlessTravelContext
	{
		// Token: 0x06034CB9 RID: 216249 RVA: 0x00D3F7B8 File Offset: 0x00D3D9B8
		[NullableContext(1)]
		public void ParseParamsByProto(TransitionInSeamlessPb config)
		{
			this.EffectPath = config.EffectDaPath;
			this.EffectExpandTime = config.EffectExpandTime;
			this.EffectCollapseTime = Math.Max(config.EffectCollapseTime, 0.5f);
			this.LeastTime = config.LeastTime;
			this.IsTeleportInPlace = config.IsTeleportInPlace;
			this.TransitionWeatherDaPath = config.TransitionWeatherDaPath;
			this.SceneEffectDaPath = config.SceneEffectDaPath;
			if (config.KeepStates.Count > 0)
			{
				this.KeepMovementStateFeatures = new KeepMovementStateFeatures();
				foreach (KeepMovementState keepMovementState in config.KeepStates)
				{
					if (keepMovementState != KeepMovementState.Kite)
					{
						if (keepMovementState == KeepMovementState.Soar)
						{
							this.KeepMovementStateFeatures.KeepSoar = true;
						}
					}
					else
					{
						this.KeepMovementStateFeatures.KeepKite = true;
					}
				}
			}
			if (config.HasFloorSettings)
			{
				this.FloorParams = new SeamlessTravelFloorParams();
				this.FloorParams.ParseFloorParamsByProto(config.FloorSettings);
			}
			if (config.SeamlessTeleportFinishConfig != null)
			{
				this.FinishParams = new SeamlessTravelFinishParams();
				this.FinishParams.ParseFinishParamsByProto(config.SeamlessTeleportFinishConfig);
			}
		}

		// Token: 0x06034CBA RID: 216250 RVA: 0x00D3F8E4 File Offset: 0x00D3DAE4
		[NullableContext(1)]
		public void ParseParamsByConfig(ITeleportTransitionInSeamlessType config)
		{
			this.EffectPath = config.EffectDaPath;
			this.EffectExpandTime = config.EffectExpandTime;
			this.EffectCollapseTime = Math.Max(config.EffectCollapseTime, 0.5f);
			this.LeastTime = config.LeastTime;
			this.IsTeleportInPlace = config.IsTeleportInPlace.GetValueOrDefault();
			this.TransitionWeatherDaPath = config.TransitionWeatherDaPath;
			this.SceneEffectDaPath = config.SceneEffectDaPath;
			if (config.KeepMovementStates != null && config.KeepMovementStates.Count > 0)
			{
				this.KeepMovementStateFeatures = new KeepMovementStateFeatures();
				foreach (EKeepMovementState ekeepMovementState in config.KeepMovementStates)
				{
					if (ekeepMovementState != EKeepMovementState.Kite)
					{
						if (ekeepMovementState == EKeepMovementState.Soar)
						{
							this.KeepMovementStateFeatures.KeepSoar = true;
						}
					}
					else
					{
						this.KeepMovementStateFeatures.KeepKite = true;
					}
				}
			}
			if (config.FloorSettings != null)
			{
				this.FloorParams = new SeamlessTravelFloorParams();
				this.FloorParams.ParseFloorParamsByConfig(config.FloorSettings);
			}
			if (config.SeamlessTeleportFinishConfig != null)
			{
				this.FinishParams = new SeamlessTravelFinishParams();
				this.FinishParams.ParseFinishParamsByConfig(config.SeamlessTeleportFinishConfig);
			}
		}

		// Token: 0x0401E689 RID: 124553
		public string EffectPath;

		// Token: 0x0401E68A RID: 124554
		public float EffectExpandTime;

		// Token: 0x0401E68B RID: 124555
		public float EffectCollapseTime;

		// Token: 0x0401E68C RID: 124556
		public float LeastTime;

		// Token: 0x0401E68D RID: 124557
		public SeamlessTravelFloorParams FloorParams;

		// Token: 0x0401E68E RID: 124558
		public bool IsTeleportInPlace;

		// Token: 0x0401E68F RID: 124559
		public string TransitionWeatherDaPath;

		// Token: 0x0401E690 RID: 124560
		public string SceneEffectDaPath;

		// Token: 0x0401E691 RID: 124561
		public KeepMovementStateFeatures KeepMovementStateFeatures;

		// Token: 0x0401E692 RID: 124562
		public SeamlessTravelFinishParams FinishParams;
	}
}
