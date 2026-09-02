using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004755 RID: 18261
	[NullableContext(1)]
	[Nullable(0)]
	public class CharMaterialSlot
	{
		// Token: 0x0602F669 RID: 194153 RVA: 0x00B41170 File Offset: 0x00B3F370
		public void Init(int materialIndex, string slotName, [Nullable(2)] UMaterialInstanceDynamic dynamicMaterial)
		{
			this.SlotName = slotName;
			this.MaterialIndex = materialIndex;
			this.SectionIndex = 99999;
			this.FloatParamDirty = false;
			this.VectorParamDirty = false;
			this.TextureParamDirty = false;
			this.IsStarScar = (slotName == "MI_Star");
			this.SlotType = RenderConfig.GetMaterialSlotType(slotName);
			this.MaterialPartType = RenderConfig.GetMaterialPartType(slotName);
			this.SetDynamicMaterial(dynamicMaterial);
			this.ReplaceMaterialArray = new List<UMaterialInstanceDynamic>();
		}

		// Token: 0x0602F66A RID: 194154 RVA: 0x00B411E6 File Offset: 0x00B3F3E6
		[NullableContext(2)]
		public void SetDynamicMaterial(UMaterialInstanceDynamic dynamicMaterial)
		{
			this.DynamicMaterial = dynamicMaterial;
			if (dynamicMaterial != null)
			{
				this.FloatParamMap = new Dictionary<string, float[]>();
				this.VectorParamMap = new Dictionary<string, ColorTempContainer[]>();
				this.TextureParamMap = new Dictionary<string, UTexture[]>();
			}
			this.MaterialDirty = true;
		}

		// Token: 0x0602F66B RID: 194155 RVA: 0x00B4121C File Offset: 0x00B3F41C
		public void SetSkeletalMeshMaterial(USkeletalMeshComponent skeletalComp)
		{
			if (this.MaterialDirty)
			{
				this.MaterialDirty = false;
				int count = this.ReplaceMaterialArray.Count;
				if (count > 0)
				{
					skeletalComp.SetMaterial(this.MaterialIndex, this.ReplaceMaterialArray[count - 1]);
					return;
				}
				skeletalComp.SetMaterial(this.MaterialIndex, this.DynamicMaterial ?? Singleton<RenderDataManager>.Instance.GetEmptyMaterial());
			}
		}

		// Token: 0x0602F66C RID: 194156 RVA: 0x00B41284 File Offset: 0x00B3F484
		public int UpdateMaterialParam()
		{
			if (!this.IsDynamicMaterialValid())
			{
				return 0;
			}
			UMaterialInstanceDynamic dynamicMaterial = this.DynamicMaterial;
			int num = 0;
			if (this.FloatParamDirty)
			{
				this.FloatParamDirty = false;
				foreach (KeyValuePair<string, float[]> keyValuePair in this.FloatParamMap)
				{
					string key = keyValuePair.Key;
					float[] value = keyValuePair.Value;
					if (value[1] != value[2])
					{
						value[1] = value[2];
						dynamicMaterial.SetScalarParameterValue(FNameUtil.GetDynamicFName(key).Value, value[2]);
						num++;
					}
				}
			}
			if (this.VectorParamDirty)
			{
				this.VectorParamDirty = false;
				foreach (KeyValuePair<string, ColorTempContainer[]> keyValuePair2 in this.VectorParamMap)
				{
					string key2 = keyValuePair2.Key;
					ColorTempContainer[] value2 = keyValuePair2.Value;
					if (value2[1] != value2[2])
					{
						value2[1] = value2[2];
						ColorTempContainer colorTempContainer = value2[2];
						FLinearColor value3 = new FLinearColor(colorTempContainer.ColorR, colorTempContainer.ColorG, colorTempContainer.ColorB, colorTempContainer.ColorA);
						dynamicMaterial.SetVectorParameterValue(FNameUtil.GetDynamicFName(key2).Value, value3);
						num++;
					}
				}
			}
			if (this.TextureParamDirty)
			{
				this.TextureParamDirty = false;
				foreach (KeyValuePair<string, UTexture[]> keyValuePair3 in this.TextureParamMap)
				{
					string key3 = keyValuePair3.Key;
					UTexture[] value4 = keyValuePair3.Value;
					UTexture utexture = value4[2];
					if (utexture != null && value4[1] != utexture)
					{
						value4[1] = utexture;
						dynamicMaterial.SetTextureParameterValue(FNameUtil.GetDynamicFName(key3).Value, utexture);
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0602F66D RID: 194157 RVA: 0x00B41480 File Offset: 0x00B3F680
		public void SetReplaceMaterial(UMaterialInstanceDynamic replaceMaterial)
		{
			this.ReplaceMaterialArray.Add(replaceMaterial);
			this.MaterialDirty = true;
		}

		// Token: 0x0602F66E RID: 194158 RVA: 0x00B41498 File Offset: 0x00B3F698
		public bool RevertReplaceMaterial(UMaterialInstanceDynamic replaceMaterial)
		{
			List<UMaterialInstanceDynamic> list = new List<UMaterialInstanceDynamic>();
			bool result = false;
			for (int i = 0; i < this.ReplaceMaterialArray.Count; i++)
			{
				if (this.ReplaceMaterialArray[i] != replaceMaterial)
				{
					list.Add(this.ReplaceMaterialArray[i]);
				}
				else
				{
					result = true;
				}
			}
			this.ReplaceMaterialArray = list;
			this.MaterialDirty = true;
			return result;
		}

		// Token: 0x0602F66F RID: 194159 RVA: 0x00B414F8 File Offset: 0x00B3F6F8
		public void SetFloat(FName property, float value)
		{
			if (!this.IsDynamicMaterialValid())
			{
				return;
			}
			string key = property.ToString();
			this.FloatParamDirty = true;
			if (!this.FloatParamMap.ContainsKey(key))
			{
				this.FloatParamMap[key] = new float[]
				{
					this.DynamicMaterial.K2_GetScalarParameterValue(property),
					value + 1f,
					value
				};
				return;
			}
			this.FloatParamMap[key][2] = value;
		}

		// Token: 0x0602F670 RID: 194160 RVA: 0x00B41570 File Offset: 0x00B3F770
		public void RevertFloat(string propertyStr)
		{
			if (!this.IsDynamicMaterialValid())
			{
				return;
			}
			if (this.FloatParamMap.ContainsKey(propertyStr))
			{
				this.FloatParamDirty = true;
				float[] array = this.FloatParamMap[propertyStr];
				array[2] = array[0];
			}
		}

		// Token: 0x0602F671 RID: 194161 RVA: 0x00B415B0 File Offset: 0x00B3F7B0
		public void SetColor(FName property, FLinearColor value)
		{
			if (!this.IsDynamicMaterialValid())
			{
				return;
			}
			string key = property.ToString();
			this.VectorParamDirty = true;
			ColorTempContainer colorTempContainer = new ColorTempContainer
			{
				ColorR = value.R,
				ColorG = value.G,
				ColorB = value.B,
				ColorA = value.A
			};
			if (!this.VectorParamMap.ContainsKey(key))
			{
				FLinearColor flinearColor = this.DynamicMaterial.K2_GetVectorParameterValue(property);
				ColorTempContainer colorTempContainer2 = new ColorTempContainer
				{
					ColorR = flinearColor.R,
					ColorG = flinearColor.G,
					ColorB = flinearColor.B,
					ColorA = flinearColor.A
				};
				this.VectorParamMap[key] = new ColorTempContainer[]
				{
					colorTempContainer2,
					null,
					colorTempContainer
				};
				return;
			}
			this.VectorParamMap[key][2] = colorTempContainer;
		}

		// Token: 0x0602F672 RID: 194162 RVA: 0x00B4168C File Offset: 0x00B3F88C
		public void RevertColor(string propertyStr)
		{
			if (!this.IsDynamicMaterialValid())
			{
				return;
			}
			if (this.VectorParamMap.ContainsKey(propertyStr))
			{
				this.VectorParamDirty = true;
				ColorTempContainer[] array = this.VectorParamMap[propertyStr];
				array[2] = array[0];
			}
		}

		// Token: 0x0602F673 RID: 194163 RVA: 0x00B416CC File Offset: 0x00B3F8CC
		public void SetTexture(FName property, UTexture value)
		{
			if (!this.IsDynamicMaterialValid())
			{
				return;
			}
			string key = property.ToString();
			this.TextureParamDirty = true;
			if (!this.TextureParamMap.ContainsKey(key))
			{
				this.TextureParamMap[key] = new UTexture[]
				{
					this.DynamicMaterial.K2_GetTextureParameterValue(property),
					null,
					value
				};
				return;
			}
			this.TextureParamMap[key][2] = value;
		}

		// Token: 0x0602F674 RID: 194164 RVA: 0x00B4173C File Offset: 0x00B3F93C
		public void RevertTexture(string propertyStr)
		{
			if (!this.IsDynamicMaterialValid())
			{
				return;
			}
			if (this.TextureParamMap.ContainsKey(propertyStr))
			{
				this.TextureParamDirty = true;
				UTexture[] array = this.TextureParamMap[propertyStr];
				array[2] = array[0];
			}
		}

		// Token: 0x0602F675 RID: 194165 RVA: 0x00B4177C File Offset: 0x00B3F97C
		public void RevertProperty(FName property)
		{
			if (!this.IsDynamicMaterialValid())
			{
				return;
			}
			string propertyStr = property.ToString();
			this.RevertColor(propertyStr);
			this.RevertFloat(propertyStr);
			this.RevertTexture(propertyStr);
		}

		// Token: 0x0602F676 RID: 194166 RVA: 0x00B417B5 File Offset: 0x00B3F9B5
		public void SetStarScarEnergy(float energy)
		{
			if (!this.IsDynamicMaterialValid())
			{
				return;
			}
			if (this.IsStarScar)
			{
				this.SetFloat(RenderConfig.StarScarEnergyControl, energy);
			}
		}

		// Token: 0x0602F677 RID: 194167 RVA: 0x00B417D4 File Offset: 0x00B3F9D4
		public bool IsDynamicMaterialValid()
		{
			return this.DynamicMaterial != null && this.DynamicMaterial.IsValid();
		}

		// Token: 0x0401AFC7 RID: 110535
		[Nullable(2)]
		public UMaterialInstanceDynamic DynamicMaterial;

		// Token: 0x0401AFC8 RID: 110536
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, float[]> FloatParamMap;

		// Token: 0x0401AFC9 RID: 110537
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			2
		})]
		public Dictionary<string, ColorTempContainer[]> VectorParamMap;

		// Token: 0x0401AFCA RID: 110538
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			2
		})]
		public Dictionary<string, UTexture[]> TextureParamMap;

		// Token: 0x0401AFCB RID: 110539
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<UMaterialInstanceDynamic> ReplaceMaterialArray;

		// Token: 0x0401AFCC RID: 110540
		public string SlotName = string.Empty;

		// Token: 0x0401AFCD RID: 110541
		public int MaterialIndex;

		// Token: 0x0401AFCE RID: 110542
		public int SectionIndex;

		// Token: 0x0401AFCF RID: 110543
		public bool IsStarScar;

		// Token: 0x0401AFD0 RID: 110544
		public ECharacterMeshPart MaterialPartType;

		// Token: 0x0401AFD1 RID: 110545
		public ECharacterSlotType SlotType;

		// Token: 0x0401AFD2 RID: 110546
		public bool MaterialDirty;

		// Token: 0x0401AFD3 RID: 110547
		private bool FloatParamDirty;

		// Token: 0x0401AFD4 RID: 110548
		private bool VectorParamDirty;

		// Token: 0x0401AFD5 RID: 110549
		private bool TextureParamDirty;

		// Token: 0x0401AFD6 RID: 110550
		private const string STAR_SCAR_SLOT_NAME = "MI_Star";

		// Token: 0x0401AFD7 RID: 110551
		private const int ORIGINAL_INDEX = 0;

		// Token: 0x0401AFD8 RID: 110552
		private const int CACHE_INDEX = 1;

		// Token: 0x0401AFD9 RID: 110553
		private const int TARGET_INDEX = 2;
	}
}
