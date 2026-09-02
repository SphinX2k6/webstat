using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.Manipulate;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x0200484A RID: 18506
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ManipulateConfig : ConfigBase<ManipulateConfig>
	{
		// Token: 0x06030242 RID: 197186 RVA: 0x00BACEF4 File Offset: 0x00BAB0F4
		protected override bool OnInit()
		{
			this.ManipulatePrecastLinesValue = new string[]
			{
				"Manipulate_Precast_Line_L",
				"Manipulate_Precast_Line_R",
				"Manipulate_Precast_Line_F",
				"Manipulate_Precast_Line_B"
			};
			this.DisconnectDistanceValue = (float)ConfigCommonParamById.GetIntConfig("ManipulatableItemDisconnectDistance").GetValueOrDefault();
			this.SearchRangeValue = (float)ConfigCommonParamById.GetIntConfig("ManipulatableItemSearchRange").GetValueOrDefault();
			this.PushEffectPathValue = ConfigCommonParamById.GetStringConfig("ManipulatableItemPushFXAsset");
			this.SearchAngleCosValue = new List<float>();
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("ManipulatebleItemSearchAngle");
			if (intArrayConfig != null)
			{
				foreach (int num in intArrayConfig)
				{
					this.SearchAngleCosValue.Add((float)num);
				}
			}
			this.SearchAngleWeightValue = new List<float>();
			IReadOnlyList<int> intArrayConfig2 = ConfigCommonParamById.GetIntArrayConfig("ManipulatebleItemSearchAngleWeight");
			if (intArrayConfig2 != null)
			{
				foreach (int num2 in intArrayConfig2)
				{
					this.SearchAngleWeightValue.Add((float)num2);
				}
			}
			this.PrecastTimeValue = ConfigCommonParamById.GetFloatConfig("ManipulatePrecastTime").GetValueOrDefault() * 1000f;
			this.DontUseLineDistanceValue = (float)ConfigCommonParamById.GetIntConfig("ManipulateDontUseLineDistance").GetValueOrDefault();
			this.CommonItemLineValue = (ConfigCommonParamById.GetStringConfig("ManipulateItemLine_Common") ?? "");
			this.LineFxNsPathValue = (ConfigCommonParamById.GetStringConfig("ManipulatableItemLineNiagaraSystemAssetPath") ?? "");
			this.HandFxPathValue = (ConfigCommonParamById.GetStringConfig("ManipulatableItemHandFXAssetPath") ?? "");
			this.MatControllerDaPathValue = (ConfigCommonParamById.GetStringConfig("MatControllerDAPath") ?? "");
			this.ItemMassValue = ConfigCommonParamById.GetFloatConfig("ManipulatableItemMass").GetValueOrDefault();
			this.ItemLinearDampingValue = ConfigCommonParamById.GetFloatConfig("ManipulatableItemLinearDamping").GetValueOrDefault();
			this.ItemAngularDampingValue = ConfigCommonParamById.GetFloatConfig("ManipulatableItemAngularDamping").GetValueOrDefault();
			return true;
		}

		// Token: 0x17008269 RID: 33385
		// (get) Token: 0x06030243 RID: 197187 RVA: 0x00BAD10C File Offset: 0x00BAB30C
		public string[] ManipulatePrecastLines
		{
			get
			{
				return this.ManipulatePrecastLinesValue;
			}
		}

		// Token: 0x1700826A RID: 33386
		// (get) Token: 0x06030244 RID: 197188 RVA: 0x00BAD114 File Offset: 0x00BAB314
		public float DisconnectDistance
		{
			get
			{
				return this.DisconnectDistanceValue;
			}
		}

		// Token: 0x1700826B RID: 33387
		// (get) Token: 0x06030245 RID: 197189 RVA: 0x00BAD11C File Offset: 0x00BAB31C
		public float SearchRange
		{
			get
			{
				return this.SearchRangeValue;
			}
		}

		// Token: 0x1700826C RID: 33388
		// (get) Token: 0x06030246 RID: 197190 RVA: 0x00BAD124 File Offset: 0x00BAB324
		public string PushEffectPath
		{
			get
			{
				return this.PushEffectPathValue;
			}
		}

		// Token: 0x1700826D RID: 33389
		// (get) Token: 0x06030247 RID: 197191 RVA: 0x00BAD12C File Offset: 0x00BAB32C
		public List<float> SearchAnglesCos
		{
			get
			{
				return this.SearchAngleCosValue;
			}
		}

		// Token: 0x1700826E RID: 33390
		// (get) Token: 0x06030248 RID: 197192 RVA: 0x00BAD134 File Offset: 0x00BAB334
		public List<float> SearchAnglesWeight
		{
			get
			{
				return this.SearchAngleWeightValue;
			}
		}

		// Token: 0x1700826F RID: 33391
		// (get) Token: 0x06030249 RID: 197193 RVA: 0x00BAD13C File Offset: 0x00BAB33C
		public float PrecastTime
		{
			get
			{
				return this.PrecastTimeValue;
			}
		}

		// Token: 0x17008270 RID: 33392
		// (get) Token: 0x0603024A RID: 197194 RVA: 0x00BAD144 File Offset: 0x00BAB344
		public float DontUseLineDistance
		{
			get
			{
				return this.DontUseLineDistanceValue;
			}
		}

		// Token: 0x17008271 RID: 33393
		// (get) Token: 0x0603024B RID: 197195 RVA: 0x00BAD14C File Offset: 0x00BAB34C
		public string CommonItemLine
		{
			get
			{
				return this.CommonItemLineValue;
			}
		}

		// Token: 0x17008272 RID: 33394
		// (get) Token: 0x0603024C RID: 197196 RVA: 0x00BAD154 File Offset: 0x00BAB354
		public string LineFxNsPath
		{
			get
			{
				return this.LineFxNsPathValue;
			}
		}

		// Token: 0x17008273 RID: 33395
		// (get) Token: 0x0603024D RID: 197197 RVA: 0x00BAD15C File Offset: 0x00BAB35C
		public string MatControllerDaPath
		{
			get
			{
				return this.MatControllerDaPathValue;
			}
		}

		// Token: 0x17008274 RID: 33396
		// (get) Token: 0x0603024E RID: 197198 RVA: 0x00BAD164 File Offset: 0x00BAB364
		public string HandFxPath
		{
			get
			{
				return this.HandFxPathValue;
			}
		}

		// Token: 0x17008275 RID: 33397
		// (get) Token: 0x0603024F RID: 197199 RVA: 0x00BAD16C File Offset: 0x00BAB36C
		public float ItemMass
		{
			get
			{
				return this.ItemMassValue;
			}
		}

		// Token: 0x17008276 RID: 33398
		// (get) Token: 0x06030250 RID: 197200 RVA: 0x00BAD174 File Offset: 0x00BAB374
		public float ItemLinearDamping
		{
			get
			{
				return this.ItemLinearDampingValue;
			}
		}

		// Token: 0x17008277 RID: 33399
		// (get) Token: 0x06030251 RID: 197201 RVA: 0x00BAD17C File Offset: 0x00BAB37C
		public float ItemAngularDampling
		{
			get
			{
				return this.ItemAngularDampingValue;
			}
		}

		// Token: 0x06030252 RID: 197202 RVA: 0x00BAD184 File Offset: 0x00BAB384
		public FVector? GetPrecastLineValue(string rowName, float time)
		{
			SManipulateConfig dataTableRowFromName = DataTableUtil.GetDataTableRowFromName<SManipulateConfig>(EDataTable.ManipulatePrecast, rowName);
			if (dataTableRowFromName == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.CH;
				string message = "加载失败，Manipulate Precast表中没有该项";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Row Name", rowName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return new FVector?(this.GetLocationByTime(dataTableRowFromName.ManipulatePoints, dataTableRowFromName.Duration, time));
		}

		// Token: 0x06030253 RID: 197203 RVA: 0x00BAD1EC File Offset: 0x00BAB3EC
		public FVector? GetItemLineValue(string rowName, float time)
		{
			SManipulateConfig dataTableRowFromName = DataTableUtil.GetDataTableRowFromName<SManipulateConfig>(EDataTable.ManipulateItem, rowName);
			if (dataTableRowFromName == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.CH;
				string message = "加载失败，Manipulate Item表中没有该项";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Row Name", rowName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return new FVector?(this.GetLocationByTime(dataTableRowFromName.ManipulatePoints, dataTableRowFromName.Duration, time));
		}

		// Token: 0x06030254 RID: 197204 RVA: 0x00BAD254 File Offset: 0x00BAB454
		private FVector GetLocationByTime(TArray<SManipulatePointInfo> points, float duration, float time)
		{
			int num = points.Num();
			float num2 = (float)(num - 1) / duration;
			if (time <= 0f)
			{
				return points[0].Location;
			}
			if (time >= 1f)
			{
				return points[num - 1].Location;
			}
			float num3 = time * num2;
			int num4 = (int)Math.Floor((double)num3);
			SManipulatePointInfo smanipulatePointInfo = points[num4];
			int index = num4 + 1;
			SManipulatePointInfo smanipulatePointInfo2 = points[index];
			if (!(smanipulatePointInfo.PointType != ESplinePointType.Constant))
			{
				return smanipulatePointInfo.Location;
			}
			float num5 = num3 - (float)num4;
			if (smanipulatePointInfo.PointType == ESplinePointType.Linear)
			{
				FVector result = new FVector();
				Singleton<MathUtils>.Instance.LerpVectorOld(smanipulatePointInfo.Location, smanipulatePointInfo2.Location, num5, ref result);
				return result;
			}
			return this.CubicInterp(smanipulatePointInfo.Location, smanipulatePointInfo.LeaveTangent, smanipulatePointInfo2.Location, smanipulatePointInfo2.ArriveTangent, num5);
		}

		// Token: 0x06030255 RID: 197205 RVA: 0x00BAD340 File Offset: 0x00BAB540
		protected override bool OnClear()
		{
			this.ManipulatePrecastLinesValue = null;
			this.PushEffectPathValue = null;
			return true;
		}

		// Token: 0x06030256 RID: 197206 RVA: 0x00BAD354 File Offset: 0x00BAB554
		private FVector CubicInterp(FVector p0, FVector t0, FVector p1, FVector t1, float a)
		{
			float num = a * a;
			float num2 = num * a;
			float num3 = 2f * num2 - 3f * num + 1f;
			float num4 = num2 - 2f * num + a;
			float num5 = num2 - num;
			float num6 = -2f * num2 + 3f * num;
			global::Vector vector = global::Vector.Create(p0).MultiplyEqual((double)num3);
			global::Vector inB = global::Vector.Create(t0).MultiplyEqual((double)num4);
			global::Vector inB2 = global::Vector.Create(t1).MultiplyEqual((double)num5);
			global::Vector inB3 = global::Vector.Create(p1).MultiplyEqual((double)num6);
			vector.AdditionEqual(inB).AdditionEqual(inB2).AdditionEqual(inB3);
			return vector.ToUeVectorOld();
		}

		// Token: 0x0401BA1E RID: 113182
		private const int SECOND_TO_MICROSECOND = 1000;

		// Token: 0x0401BA1F RID: 113183
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private string[] ManipulatePrecastLinesValue;

		// Token: 0x0401BA20 RID: 113184
		private float DisconnectDistanceValue;

		// Token: 0x0401BA21 RID: 113185
		private float SearchRangeValue;

		// Token: 0x0401BA22 RID: 113186
		[Nullable(2)]
		private string PushEffectPathValue;

		// Token: 0x0401BA23 RID: 113187
		private List<float> SearchAngleCosValue = new List<float>();

		// Token: 0x0401BA24 RID: 113188
		private List<float> SearchAngleWeightValue = new List<float>();

		// Token: 0x0401BA25 RID: 113189
		private float PrecastTimeValue;

		// Token: 0x0401BA26 RID: 113190
		private float DontUseLineDistanceValue;

		// Token: 0x0401BA27 RID: 113191
		private string CommonItemLineValue = "";

		// Token: 0x0401BA28 RID: 113192
		private string LineFxNsPathValue = "";

		// Token: 0x0401BA29 RID: 113193
		private string HandFxPathValue = "";

		// Token: 0x0401BA2A RID: 113194
		private string MatControllerDaPathValue = "";

		// Token: 0x0401BA2B RID: 113195
		private float ItemMassValue;

		// Token: 0x0401BA2C RID: 113196
		private float ItemLinearDampingValue;

		// Token: 0x0401BA2D RID: 113197
		private float ItemAngularDampingValue;
	}
}
