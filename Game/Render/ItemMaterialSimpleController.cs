using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004790 RID: 18320
	[NullableContext(2)]
	[Nullable(0)]
	public class ItemMaterialSimpleController : ItemMaterialControllerBase
	{
		// Token: 0x0602F89D RID: 194717 RVA: 0x00B52957 File Offset: 0x00B50B57
		[NullableContext(1)]
		public ItemMaterialSimpleController(AActor actor)
		{
			this.Actor = actor;
			this.ForEachComponent(this.Actor, delegate(UPrimitiveComponent component)
			{
				if (this.CheckMaterial(component))
				{
					this.CachedComponentMaterials(component);
				}
			});
		}

		// Token: 0x0602F89E RID: 194718 RVA: 0x00B52989 File Offset: 0x00B50B89
		public AActor GetActor()
		{
			if (!this.Actor.IsValid())
			{
				return null;
			}
			return this.Actor;
		}

		// Token: 0x0602F89F RID: 194719 RVA: 0x00B529A0 File Offset: 0x00B50BA0
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

		// Token: 0x0602F8A0 RID: 194720 RVA: 0x00B529F4 File Offset: 0x00B50BF4
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

		// Token: 0x0602F8A1 RID: 194721 RVA: 0x00B52A58 File Offset: 0x00B50C58
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

		// Token: 0x0602F8A2 RID: 194722 RVA: 0x00B52BD8 File Offset: 0x00B50DD8
		public void UpdateParameters()
		{
			foreach (Tuple<UPrimitiveComponent, List<UMaterialInterface>, List<UMaterialInstanceDynamic>> tuple in this.CachedMaterials)
			{
				if (tuple.Item3 != null)
				{
					foreach (UMaterialInstanceDynamic umaterialInstanceDynamic in tuple.Item3)
					{
						if (umaterialInstanceDynamic != null && umaterialInstanceDynamic.IsValid() && this.ScalarParameterValue != null)
						{
							foreach (FName fname in this.ScalarParameterValue.Keys)
							{
								umaterialInstanceDynamic.SetScalarParameterValue(fname, this.ScalarParameterValue[fname]);
							}
						}
					}
				}
			}
			foreach (Tuple<UPrimitiveComponent, List<UMaterialInterface>, List<UMaterialInstanceDynamic>> tuple2 in this.CachedMaterials)
			{
				if (tuple2.Item3 != null)
				{
					foreach (UMaterialInstanceDynamic umaterialInstanceDynamic2 in tuple2.Item3)
					{
						if (umaterialInstanceDynamic2 != null && umaterialInstanceDynamic2.IsValid() && this.VectorParameterValue != null)
						{
							foreach (FName fname2 in this.VectorParameterValue.Keys)
							{
								umaterialInstanceDynamic2.SetVectorParameterValue(fname2, this.VectorParameterValue[fname2]);
							}
						}
					}
				}
			}
		}

		// Token: 0x0401B308 RID: 111368
		[Nullable(1)]
		protected AActor Actor;

		// Token: 0x0401B309 RID: 111369
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

		// Token: 0x0401B30A RID: 111370
		public Dictionary<FName, float> ScalarParameterValue;

		// Token: 0x0401B30B RID: 111371
		public Dictionary<FName, FLinearColor> VectorParameterValue;
	}
}
