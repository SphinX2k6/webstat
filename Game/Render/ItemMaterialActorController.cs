using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004791 RID: 18321
	[NullableContext(2)]
	[Nullable(0)]
	public class ItemMaterialActorController : ItemMaterialControllerBase
	{
		// Token: 0x0602F8A4 RID: 194724 RVA: 0x00B52DE6 File Offset: 0x00B50FE6
		public bool IsValid()
		{
			return this.LifeTimeController != null && this.Actor.IsValid() && this.Data.IsValid();
		}

		// Token: 0x0602F8A5 RID: 194725 RVA: 0x00B52E0C File Offset: 0x00B5100C
		[NullableContext(1)]
		public ItemMaterialActorController(AActor actor, ItemMaterialControllerActorData data)
		{
			this.LifeTimeController = new EffectLifeTimeController(data.StartTime, data.LoopTime, data.EndTime, EEffectLifeTimeType.Auto, new Action(this.Destroy), null, 0f, 1f);
			this.Actor = actor;
			this.Data = data;
			this.ForEachComponent(this.Actor, delegate(UPrimitiveComponent component)
			{
				if (this.CheckMaterial(component))
				{
					this.CachedComponentMaterials(component);
				}
			});
			this.ForEachDecalComponent(this.Actor, delegate(UDecalComponent decalcomponent)
			{
				if (this.CheckDecalMaterial(decalcomponent))
				{
					this.CachedDecalComponentMaterials(decalcomponent);
				}
			});
			this.CollectParameter();
			this.Play();
		}

		// Token: 0x0602F8A6 RID: 194726 RVA: 0x00B52EB4 File Offset: 0x00B510B4
		public AActor GetActor()
		{
			if (!this.Actor.IsValid())
			{
				return null;
			}
			return this.Actor;
		}

		// Token: 0x0602F8A7 RID: 194727 RVA: 0x00B52ECB File Offset: 0x00B510CB
		public ItemMaterialControllerActorData GetData()
		{
			if (!this.Data.IsValid())
			{
				return null;
			}
			return this.Data;
		}

		// Token: 0x0602F8A8 RID: 194728 RVA: 0x00B52EE2 File Offset: 0x00B510E2
		public EffectLifeTimeController GetLifeTimeController()
		{
			return this.LifeTimeController;
		}

		// Token: 0x0602F8A9 RID: 194729 RVA: 0x00B52EEC File Offset: 0x00B510EC
		public void CollectParameter()
		{
			RenderStats.Init();
			this.ModelParameters = new EffectMaterialParameters(null, null);
			ItemMaterialControllerActorData data = this.Data;
			if (data != null && data.EnableBaseColorScale)
			{
				this.ModelParameters.CollectFloatConst(RenderConfig.E_Action_UseBaseColorScale, 1f);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_BaseColorScale, this.Data.BaseColorScale);
			}
			ItemMaterialControllerActorData data2 = this.Data;
			if (data2 != null && data2.EnableAddEmissionColor)
			{
				this.ModelParameters.CollectFloatConst(RenderConfig.E_Action_UseEmissionColor, 1f);
				this.ModelParameters.CollectLinearColorCurve(RenderConfig.E_Action_EmissionColor, this.Data.AddEmissionColor);
			}
			ItemMaterialControllerActorData data3 = this.Data;
			if (data3 != null && data3.EnableRimLight)
			{
				this.ModelParameters.CollectFloatConst(RenderConfig.E_Action_UseRimLight, 1f);
				this.ModelParameters.CollectLinearColorCurve(RenderConfig.E_Action_RimLightColor, this.Data.RimLightColor);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_RimPower, this.Data.RimPower);
			}
			ItemMaterialControllerActorData data4 = this.Data;
			if (data4 != null && data4.EnableEmissionChange)
			{
				this.ModelParameters.CollectFloatConst(RenderConfig.E_Action_UseEmissionChange, 1f);
				this.ModelParameters.CollectLinearColorCurve(RenderConfig.E_Action_EmissionLightColorChangeColor, this.Data.EmissionLightColorChangeColor);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_EmissionLightColorChangeStrength, this.Data.EmissionLightColorChangeStrength);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_EmissionLightColorChangeProgress, this.Data.EmissionLightColorChangeProgress);
			}
			ItemMaterialControllerActorData data5 = this.Data;
			if (data5 != null && data5.EnableDissolve)
			{
				this.ModelParameters.CollectFloatConst(RenderConfig.E_Action_UseDissolve, 1f);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_DissolveProgress, this.Data.DissolveProgress);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_DissolveAdjustment, this.Data.DissolveAdjustment);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_DissolveEdageWidth, this.Data.DissolveEdageWidth);
				this.ModelParameters.CollectLinearColorCurve(RenderConfig.E_Action_DissolveEdageColor, this.Data.DissolveEdageColor);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_DissolveEdageStrength, this.Data.DissolveEdageStrength);
				this.ModelParameters.CollectLinearColorCurve(RenderConfig.E_Action_DissolveTex_S_O, this.Data.DissolveTexScaleOffset);
				this.ModelParameters.CollectLinearColorCurve(RenderConfig.E_Action_DissolveTexSpeed, this.Data.DissolveTexSpeed);
				switch (this.Data.DissolveUv)
				{
				case ECharacterControllerUVSwitch.UV1:
					this.ModelParameters.CollectLinearColorConst(RenderConfig.E_Tex_DissolveTexUVSwitch, new FLinearColor(1f, 0f, 0f, 0f));
					break;
				case ECharacterControllerUVSwitch.UV2:
					this.ModelParameters.CollectLinearColorConst(RenderConfig.E_Tex_DissolveTexUVSwitch, new FLinearColor(0f, 1f, 0f, 0f));
					break;
				case ECharacterControllerUVSwitch.UV3:
					this.ModelParameters.CollectLinearColorConst(RenderConfig.E_Tex_DissolveTexUVSwitch, new FLinearColor(0f, 0f, 1f, 0f));
					break;
				case ECharacterControllerUVSwitch.UV4:
					this.ModelParameters.CollectLinearColorConst(RenderConfig.E_Tex_DissolveTexUVSwitch, new FLinearColor(0f, 0f, 0f, 1f));
					break;
				}
			}
			ItemMaterialControllerActorData data6 = this.Data;
			if (data6 != null && data6.EnableScanning)
			{
				this.ModelParameters.CollectFloatConst(RenderConfig.E_Action_UseScanning, 1f);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_ScanningOutlineMixNoiseStrength, this.Data.ScanningOutlineMixNoiseStrength);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_ScanningOutlineStrength, this.Data.ScanningOutlineStrength);
				this.ModelParameters.CollectLinearColorCurve(RenderConfig.E_Action_ScanningOutlineColor, this.Data.ScanningOutlineColor);
				this.ModelParameters.CollectLinearColorCurve(RenderConfig.E_Action_ScanningTex_S_O, this.Data.ScanningOutlineTexScaleOffset);
			}
			ItemMaterialControllerActorData data7 = this.Data;
			if (data7 != null && data7.EnablePivotPainterWorldPositionOffset)
			{
				this.ModelParameters.CollectFloatConst(RenderConfig.E_Action_UsePivotPainterWorldPositionOffset, 1f);
				this.ModelParameters.CollectLinearColorCurve(RenderConfig.E_Action_PivotPainterTransform, this.Data.PivotPainterTransform);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_PivotPainter_FloatingThreshold, this.Data.FloatingThreshold);
			}
			ItemMaterialControllerActorData data8 = this.Data;
			if (data8 != null && data8.EnableWorldPositionOffset)
			{
				this.ModelParameters.CollectFloatConst(RenderConfig.E_Action_UseWPO, 1f);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_VertexAnim_TimeDebug, this.Data.VertexAnimTimeDebug);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_VertexAnim_Frame, this.Data.VertexAnimFrame);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_SimpleWPO_Normal, this.Data.WorldPositionOffsetNormal);
				this.ModelParameters.CollectLinearColorCurve(RenderConfig.E_Action_SimpleWPO_Offset, this.Data.WorldPositionOffsetOffset);
			}
			ItemMaterialControllerActorData data9 = this.Data;
			if (data9 != null && data9.DisableFoliageEffect)
			{
				this.ModelParameters.CollectFloatConst(RenderConfig.E_Action_DisableFoliageEffect, 0f);
			}
			ItemMaterialControllerActorData data10 = this.Data;
			if (data10 != null && data10.EnableFoliageEffect)
			{
				this.ModelParameters.CollectFloatConst(RenderConfig.E_Action_DisableFoliageEffect, 1f);
			}
			ItemMaterialControllerActorData data11 = this.Data;
			if (data11 != null && data11.UseRimlightColorSpecil)
			{
				this.ModelParameters.CollectFloatConst(RenderConfig.E_Action_UseRimlightColorSpecil, 1f);
				this.ModelParameters.CollectLinearColorCurve(RenderConfig.E_Action_RimLightColorSpecil, this.Data.RimLightColorSpecil);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_RimlightColorStrength, this.Data.RimlightColorStrength);
			}
			ItemMaterialControllerActorData data12 = this.Data;
			if (data12 != null && data12.UseEmissionTex)
			{
				this.ModelParameters.CollectFloatConst(RenderConfig.E_Action_UseEmissionTex, 1f);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_EmissionTexStrength, this.Data.EmissionTexStrength);
			}
			ItemMaterialControllerActorData data13 = this.Data;
			if (((data13 != null) ? data13.SimpleUseFlow : null) != null)
			{
				this.ModelParameters.CollectFloatConst(RenderConfig.E_Action_Simple_UseFlow, 1f);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_Simple_Uspeed, this.Data.SimpleUspeed);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_Simple_Vspeed, this.Data.SimpleVspeed);
			}
			ItemMaterialControllerActorData data14 = this.Data;
			if (data14 != null && data14.EnableQuanXiPinTu)
			{
				this.ModelParameters.CollectFloatConst(RenderConfig.E_Action_UseQuanXiPinTu, 1f);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_TransparencyQuanXiPinTu, this.Data.TransparencyQuanXiPinTu);
				this.ModelParameters.CollectLinearColorCurve(RenderConfig.E_Action_TransparentColorQuanXiPinTu, this.Data.TransparentColorQuanXiPinTu);
				this.ModelParameters.CollectLinearColorCurve(RenderConfig.E_Action_OpaqueColorQuanXiPinTu, this.Data.OpaqueColorQuanXiPinTu);
			}
			ItemMaterialControllerActorData data15 = this.Data;
			if (data15 != null && data15.EnableQuanXiFengSuo)
			{
				this.ModelParameters.CollectFloatConst(RenderConfig.E_Action_UseQuanXiFengSuo, 1f);
				this.ModelParameters.CollectFloatCurve(RenderConfig.E_Action_TransparencyQuanXiFengSuo, this.Data.TransparencyQuanXiFengSuo);
				this.ModelParameters.CollectLinearColorCurve(RenderConfig.E_Action_TransparentColorQuanXiFengSuo, this.Data.TransparentColorQuanXiFengSuo);
			}
			this.UpdateCustomCurvePar();
		}

		// Token: 0x0602F8AA RID: 194730 RVA: 0x00B535F0 File Offset: 0x00B517F0
		public void UpdateCustomCurvePar()
		{
			ItemMaterialControllerActorData data = this.Data;
			if (((data != null) ? data.CustomScalarParMap : null) != null)
			{
				TMap<FName, FKuroCurveFloat> customScalarParMap = this.Data.CustomScalarParMap;
				for (int i = customScalarParMap.Num() - 1; i >= 0; i--)
				{
					FName key = customScalarParMap.GetKey(i);
					FKuroCurveFloat fkuroCurveFloat = customScalarParMap.Get(key);
					if (fkuroCurveFloat != null)
					{
						EffectMaterialParameters modelParameters = this.ModelParameters;
						if (modelParameters != null)
						{
							modelParameters.CollectFloatCurve(key, fkuroCurveFloat);
						}
					}
				}
			}
			ItemMaterialControllerActorData data2 = this.Data;
			if (((data2 != null) ? data2.CustomColorParMap : null) != null)
			{
				TMap<FName, FKuroCurveLinearColor> customColorParMap = this.Data.CustomColorParMap;
				for (int j = customColorParMap.Num() - 1; j >= 0; j--)
				{
					FName key2 = customColorParMap.GetKey(j);
					FKuroCurveLinearColor fkuroCurveLinearColor = customColorParMap.Get(key2);
					if (fkuroCurveLinearColor != null)
					{
						EffectMaterialParameters modelParameters2 = this.ModelParameters;
						if (modelParameters2 != null)
						{
							modelParameters2.CollectLinearColorCurve(key2, fkuroCurveLinearColor);
						}
					}
				}
			}
		}

		// Token: 0x0602F8AB RID: 194731 RVA: 0x00B536CC File Offset: 0x00B518CC
		public void UpdateParameters(bool forceUpdate)
		{
			if (this.LifeTimeController == null)
			{
				return;
			}
			foreach (Tuple<UPrimitiveComponent, List<UMaterialInterface>, List<UMaterialInstanceDynamic>> tuple in this.CachedMaterials)
			{
				if (tuple.Item3 != null)
				{
					foreach (UMaterialInstanceDynamic umaterialInstanceDynamic in tuple.Item3)
					{
						if (umaterialInstanceDynamic != null && umaterialInstanceDynamic.IsValid() && this.ModelParameters != null)
						{
							this.ModelParameters.Apply(umaterialInstanceDynamic, this.LifeTimeController.PassTime, forceUpdate);
						}
					}
				}
			}
			foreach (Tuple<UDecalComponent, UMaterialInterface, UMaterialInstanceDynamic> tuple2 in this.CachedDecalMaterials)
			{
				if (tuple2.Item3 != null && this.ModelParameters != null)
				{
					this.ModelParameters.Apply(tuple2.Item3, this.LifeTimeController.PassTime, forceUpdate);
				}
			}
		}

		// Token: 0x0602F8AC RID: 194732 RVA: 0x00B537FC File Offset: 0x00B519FC
		public void Play()
		{
			EffectLifeTimeController lifeTimeController = this.LifeTimeController;
			if (lifeTimeController != null)
			{
				lifeTimeController.Play();
			}
			this.UpdateParameters(true);
		}

		// Token: 0x0602F8AD RID: 194733 RVA: 0x00B53816 File Offset: 0x00B51A16
		public void Update(float deltaSecond)
		{
			if (!this.IsValid())
			{
				return;
			}
			EffectLifeTimeController lifeTimeController = this.LifeTimeController;
			if (lifeTimeController != null)
			{
				lifeTimeController.Update(deltaSecond);
			}
			this.UpdateParameters(false);
		}

		// Token: 0x0602F8AE RID: 194734 RVA: 0x00B5383A File Offset: 0x00B51A3A
		public void Destroy()
		{
			this.LifeTimeController = null;
		}

		// Token: 0x0602F8AF RID: 194735 RVA: 0x00B53843 File Offset: 0x00B51A43
		public void Stop(bool immediately = false)
		{
			EffectLifeTimeController lifeTimeController = this.LifeTimeController;
			if (lifeTimeController == null)
			{
				return;
			}
			lifeTimeController.Stop(immediately);
		}

		// Token: 0x0602F8B0 RID: 194736 RVA: 0x00B53858 File Offset: 0x00B51A58
		[NullableContext(1)]
		public void ForEachComponent([Nullable(2)] AActor actor, Action<UPrimitiveComponent> exec)
		{
			if (actor != null && actor.IsValid())
			{
				TArray<UActorComponent> tarray = actor.K2_GetComponentsByClass(UPrimitiveComponent.StaticClass());
				int num = tarray.Num();
				for (int i = 0; i < num; i++)
				{
					UPrimitiveComponent uprimitiveComponent = tarray.Get(i) as UPrimitiveComponent;
					if (uprimitiveComponent != null)
					{
						exec(uprimitiveComponent);
					}
				}
			}
		}

		// Token: 0x0602F8B1 RID: 194737 RVA: 0x00B538AC File Offset: 0x00B51AAC
		[NullableContext(1)]
		public void ForEachDecalComponent([Nullable(2)] AActor actor, Action<UDecalComponent> exec)
		{
			if (actor != null && actor.IsValid())
			{
				TArray<UActorComponent> tarray = actor.K2_GetComponentsByClass(UDecalComponent.StaticClass());
				int num = tarray.Num();
				for (int i = 0; i < num; i++)
				{
					UDecalComponent udecalComponent = tarray.Get(i) as UDecalComponent;
					if (udecalComponent != null)
					{
						exec(udecalComponent);
					}
				}
			}
		}

		// Token: 0x0602F8B2 RID: 194738 RVA: 0x00B53900 File Offset: 0x00B51B00
		public bool CheckMaterial(UPrimitiveComponent component)
		{
			if (component == null || !component.IsValid())
			{
				return false;
			}
			BP_EWorldType worldType = UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldType(component);
			if (worldType == BP_EWorldType.Editor || worldType == BP_EWorldType.EditorPreview)
			{
				int numMaterials = component.GetNumMaterials();
				for (int i = 0; i < numMaterials; i++)
				{
					UMaterialInterface material = component.GetMaterial(i);
					if (material != null && !UKuroRenderingRuntimeBPPluginBPLibrary.MaterialHasParameter_EditorOnly(material, RenderConfig.E_Action_UseScanning.ToString()))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0602F8B3 RID: 194739 RVA: 0x00B53964 File Offset: 0x00B51B64
		public bool CheckDecalMaterial(UDecalComponent component)
		{
			if (component == null || !component.IsValid())
			{
				return false;
			}
			BP_EWorldType worldType = UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldType(component);
			if (worldType == BP_EWorldType.Editor || worldType == BP_EWorldType.EditorPreview)
			{
				UMaterialInterface decalMaterial = component.GetDecalMaterial();
				if (decalMaterial != null && !UKuroRenderingRuntimeBPPluginBPLibrary.MaterialHasParameter_EditorOnly(decalMaterial, RenderConfig.E_Action_UseScanning.ToString()))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0602F8B4 RID: 194740 RVA: 0x00B539B4 File Offset: 0x00B51BB4
		public void CachedComponentMaterials(UPrimitiveComponent component)
		{
			if (component == null || !component.IsValid())
			{
				return;
			}
			int num = this.CachedMaterials.FindIndex(([Nullable(new byte[]
			{
				1,
				1,
				1,
				1,
				1,
				2
			})] Tuple<UPrimitiveComponent, List<UMaterialInterface>, List<UMaterialInstanceDynamic>> cached) => cached.Item1 == component);
			if (num < 0)
			{
				Tuple<UPrimitiveComponent, List<UMaterialInterface>, List<UMaterialInstanceDynamic>> item = Tuple.Create<UPrimitiveComponent, List<UMaterialInterface>, List<UMaterialInstanceDynamic>>(component, new List<UMaterialInterface>(), new List<UMaterialInstanceDynamic>());
				this.CachedMaterials.Add(item);
				num = this.CachedMaterials.Count - 1;
				int numMaterials = component.GetNumMaterials();
				for (int i = 0; i < numMaterials; i++)
				{
					UMaterialInterface material = component.GetMaterial(i);
					UMaterialInstanceDynamic umaterialInstanceDynamic = null;
					this.CachedMaterials[num].Item2.Add(material);
					if (material == null)
					{
						this.CachedMaterials[num].Item3.Add(null);
					}
					else
					{
						UMaterialInstanceDynamic umaterialInstanceDynamic2 = material as UMaterialInstanceDynamic;
						if (umaterialInstanceDynamic2 != null)
						{
							umaterialInstanceDynamic = umaterialInstanceDynamic2;
							this.CachedMaterials[num].Item3.Add(umaterialInstanceDynamic);
						}
						else
						{
							umaterialInstanceDynamic = component.CreateDynamicMaterialInstance(i, material, default(FName));
							this.CachedMaterials[num].Item3.Add(umaterialInstanceDynamic);
						}
					}
					if (umaterialInstanceDynamic == null)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Render;
						ELogAuthor author = ELogAuthor.LJY;
						string message = "材质控制器 - 使用了空材质";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", component.GetOwner());
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
				}
			}
		}

		// Token: 0x0602F8B5 RID: 194741 RVA: 0x00B53B34 File Offset: 0x00B51D34
		public void CachedDecalComponentMaterials(UDecalComponent component)
		{
			if (component == null || !component.IsValid())
			{
				return;
			}
			if (this.CachedDecalMaterials.FindIndex(([Nullable(new byte[]
			{
				1,
				1,
				2,
				2
			})] Tuple<UDecalComponent, UMaterialInterface, UMaterialInstanceDynamic> cached) => cached.Item1 == component) < 0)
			{
				UMaterialInterface decalMaterial = component.GetDecalMaterial();
				UMaterialInstanceDynamic umaterialInstanceDynamic;
				if (decalMaterial == null)
				{
					umaterialInstanceDynamic = null;
				}
				else
				{
					UMaterialInstanceDynamic umaterialInstanceDynamic2 = decalMaterial as UMaterialInstanceDynamic;
					if (umaterialInstanceDynamic2 != null)
					{
						umaterialInstanceDynamic = umaterialInstanceDynamic2;
					}
					else
					{
						umaterialInstanceDynamic = component.CreateDynamicMaterialInstance();
					}
				}
				this.CachedDecalMaterials.Add(Tuple.Create<UDecalComponent, UMaterialInterface, UMaterialInstanceDynamic>(component, decalMaterial, umaterialInstanceDynamic));
				if (umaterialInstanceDynamic == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Render;
					ELogAuthor author = ELogAuthor.LJY;
					string message = "材质控制器 - 使用了空材质";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", component.GetOwner());
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
		}

		// Token: 0x0602F8B6 RID: 194742 RVA: 0x00B53BFC File Offset: 0x00B51DFC
		public void ResetComponentMaterials(UPrimitiveComponent component)
		{
			if (component == null)
			{
				return;
			}
			int num = this.CachedMaterials.FindIndex(([Nullable(new byte[]
			{
				1,
				1,
				1,
				1,
				1,
				2
			})] Tuple<UPrimitiveComponent, List<UMaterialInterface>, List<UMaterialInstanceDynamic>> cached) => cached.Item1 == component);
			if (num >= 0)
			{
				int numMaterials = component.GetNumMaterials();
				for (int i = 0; i < numMaterials; i++)
				{
					component.SetMaterial(i, this.CachedMaterials[num].Item2[i]);
				}
			}
		}

		// Token: 0x0401B30C RID: 111372
		protected EffectLifeTimeController LifeTimeController;

		// Token: 0x0401B30D RID: 111373
		[Nullable(1)]
		protected AActor Actor;

		// Token: 0x0401B30E RID: 111374
		[Nullable(1)]
		protected ItemMaterialControllerActorData Data;

		// Token: 0x0401B30F RID: 111375
		protected EffectMaterialParameters ModelParameters;

		// Token: 0x0401B310 RID: 111376
		[Nullable(new byte[]
		{
			1,
			1,
			1,
			1,
			1,
			1,
			2
		})]
		protected List<Tuple<UPrimitiveComponent, List<UMaterialInterface>, List<UMaterialInstanceDynamic>>> CachedMaterials = new List<Tuple<UPrimitiveComponent, List<UMaterialInterface>, List<UMaterialInstanceDynamic>>>();

		// Token: 0x0401B311 RID: 111377
		[Nullable(new byte[]
		{
			1,
			1,
			1,
			2,
			2
		})]
		protected List<Tuple<UDecalComponent, UMaterialInterface, UMaterialInstanceDynamic>> CachedDecalMaterials = new List<Tuple<UDecalComponent, UMaterialInterface, UMaterialInstanceDynamic>>();
	}
}
