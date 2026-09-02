using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.ClusteredStuff;
using CSharpScript.Game.Render.DebugDraw;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004769 RID: 18281
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FoliageClusteredEffectManager : Singleton<FoliageClusteredEffectManager>
	{
		// Token: 0x0602F712 RID: 194322 RVA: 0x00B46BA4 File Offset: 0x00B44DA4
		protected override bool OnInit()
		{
			this.Ready = false;
			this.UpdateCounter = 0;
			this.UpdateIndex = 0;
			Singleton<ResourceSystem>.Instance.LoadAsync<PDA_FoliageClusteredEffectConfig_C>(this.ConfigPath, delegate([Nullable(2)] PDA_FoliageClusteredEffectConfig_C result, string _)
			{
				if (result == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RenderEffect;
					ELogAuthor author = ELogAuthor.LSY;
					string message = "植被特效找不到配置";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("配置路径", this.ConfigPath);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				this.Config = result;
				this.CacheFromConfig();
				this.Ready = true;
			}, 100, "js_undefined");
			return true;
		}

		// Token: 0x0602F713 RID: 194323 RVA: 0x00B46BE0 File Offset: 0x00B44DE0
		public void CacheFromConfig()
		{
			this.FoliageTypes = new List<UFoliageType>();
			this.ClusteredEffects = new List<EffectClusteredStuffSettings>();
			this.NumMin = new List<int>();
			this.NumMax = new List<int>();
			this.Densities = new List<double>();
			this.BoxExtend = Vector.Create(this.Config.BoxExtend);
			for (int i = 0; i < this.Config.SettingsData.Num(); i++)
			{
				SFoliageClusteredEffectEntry sfoliageClusteredEffectEntry = this.Config.SettingsData.Get(i);
				this.FoliageTypes.Add(sfoliageClusteredEffectEntry.FoliageType);
				this.ClusteredEffects.Add(sfoliageClusteredEffectEntry.EffectSetting);
				this.NumMin.Add(sfoliageClusteredEffectEntry.NumMin);
				this.NumMax.Add(sfoliageClusteredEffectEntry.NumMax);
				this.Densities.Add(0.0);
			}
			this.DetectBox = new FBox();
			this.TempVector = Vector.Create();
		}

		// Token: 0x0602F714 RID: 194324 RVA: 0x00B46CE0 File Offset: 0x00B44EE0
		public void Tick(double deltaSeconds)
		{
			if (!this.Ready || this.FoliageTypes.Count == 0)
			{
				return;
			}
			this.UpdateCounter--;
			if (this.UpdateCounter > 0)
			{
				return;
			}
			this.UpdateCounter = this.UpdateInterval;
			Singleton<RenderDataManager>.Instance.GetCurrentCharacterPosition().Subtraction(this.BoxExtend, this.TempVector);
			this.DetectBox.Min = this.TempVector.ToUeVectorOld();
			Singleton<RenderDataManager>.Instance.GetCurrentCharacterPosition().Addition(this.BoxExtend, this.TempVector);
			this.DetectBox.Max = this.TempVector.ToUeVectorOld();
			int overlappingBoxCountForAllFoliageActors = UKuroRenderingRuntimeBPPluginBPLibrary.GetOverlappingBoxCountForAllFoliageActors(GlobalData.World, this.FoliageTypes[this.UpdateIndex], this.DetectBox, this.NumMax[this.UpdateIndex]);
			this.Densities[this.UpdateIndex] = (double)Singleton<MathUtils>.Instance.Clamp((overlappingBoxCountForAllFoliageActors - this.NumMin[this.UpdateIndex]) / (this.NumMax[this.UpdateIndex] - this.NumMin[this.UpdateIndex]), 0, 1);
			this.UpdateIndex = (this.UpdateIndex + 1) % this.FoliageTypes.Count;
		}

		// Token: 0x0602F715 RID: 194325 RVA: 0x00B46E2D File Offset: 0x00B4502D
		public void BeginDebugDraw(FLinearColor color, float width)
		{
			this.DebugDrawHandle = DebugDrawManager.AddDebugBox(this.DetectBox, color, width);
		}

		// Token: 0x0602F716 RID: 194326 RVA: 0x00B46E42 File Offset: 0x00B45042
		public void EndDebugDraw()
		{
			DebugDrawManager.RemoveDebugDraw(this.DebugDrawHandle);
		}

		// Token: 0x0401B175 RID: 110965
		protected PDA_FoliageClusteredEffectConfig_C Config;

		// Token: 0x0401B176 RID: 110966
		[Nullable(1)]
		protected string ConfigPath = "/Game/Aki/Effect/Setting/DA_FoliageClusteredEffectConfig.DA_FoliageClusteredEffectConfig";

		// Token: 0x0401B177 RID: 110967
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected List<UFoliageType> FoliageTypes;

		// Token: 0x0401B178 RID: 110968
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected List<EffectClusteredStuffSettings> ClusteredEffects;

		// Token: 0x0401B179 RID: 110969
		protected List<int> NumMin;

		// Token: 0x0401B17A RID: 110970
		protected List<int> NumMax;

		// Token: 0x0401B17B RID: 110971
		protected Vector BoxExtend;

		// Token: 0x0401B17C RID: 110972
		protected bool Ready;

		// Token: 0x0401B17D RID: 110973
		protected List<double> Densities;

		// Token: 0x0401B17E RID: 110974
		protected int UpdateInterval = 5;

		// Token: 0x0401B17F RID: 110975
		protected int UpdateCounter;

		// Token: 0x0401B180 RID: 110976
		protected int UpdateIndex;

		// Token: 0x0401B181 RID: 110977
		protected FBox DetectBox;

		// Token: 0x0401B182 RID: 110978
		protected Vector TempVector;

		// Token: 0x0401B183 RID: 110979
		public int DebugDrawHandle = -1;
	}
}
