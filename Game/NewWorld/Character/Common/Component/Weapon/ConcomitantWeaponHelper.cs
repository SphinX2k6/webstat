using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game.Module.Skin;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Weapon
{
	// Token: 0x02004914 RID: 18708
	[NullableContext(1)]
	[Nullable(0)]
	public class ConcomitantWeaponHelper
	{
		// Token: 0x06030E3F RID: 200255 RVA: 0x00C1D464 File Offset: 0x00C1B664
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public static string[] GetConcomitantWeaponSubMeshNames(Entity entity)
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component == null || !component.IsConcomitantEntity)
			{
				return null;
			}
			int summonCfgId = component.SummonCfgId;
			if (summonCfgId == 0)
			{
				return null;
			}
			SummonCfg? config = ConfigSummonCfgById.GetConfig(summonCfgId, true);
			if (config == null)
			{
				return null;
			}
			string[] array = config.Value.ShowWeaponSubMesh();
			if (array.Length == 0)
			{
				return null;
			}
			return array;
		}

		// Token: 0x06030E40 RID: 200256 RVA: 0x00C1D4C4 File Offset: 0x00C1B6C4
		public static void SyncWeaponToConcomitants(Entity ownerEntity)
		{
			CreatureDataComponent component = ownerEntity.GetComponent<CreatureDataComponent>();
			if (component == null)
			{
				return;
			}
			IList<long> customServerEntityIds = component.CustomServerEntityIds;
			if (customServerEntityIds.Count == 0)
			{
				return;
			}
			CharacterWeaponComponent component2 = ownerEntity.GetComponent<CharacterWeaponComponent>();
			if (component2 == null)
			{
				return;
			}
			foreach (long concomitantServerId in customServerEntityIds)
			{
				ConcomitantWeaponHelper.SyncWeaponToSingleConcomitant(concomitantServerId, component2);
			}
		}

		// Token: 0x06030E41 RID: 200257 RVA: 0x00C1D530 File Offset: 0x00C1B730
		private static void SyncWeaponToSingleConcomitant(long concomitantServerId, CharacterWeaponComponent ownerWeaponComp)
		{
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(concomitantServerId);
			if (entity == null || !entity.Valid || entity.Entity == null)
			{
				return;
			}
			CharacterActorComponent component = entity.Entity.GetComponent<CharacterActorComponent>();
			if (component == null)
			{
				return;
			}
			string[] concomitantWeaponSubMeshNames = ConcomitantWeaponHelper.GetConcomitantWeaponSubMeshNames(entity.Entity);
			if (concomitantWeaponSubMeshNames == null)
			{
				return;
			}
			ConcomitantWeaponHelper.SyncWeaponByNames(component, ownerWeaponComp, concomitantWeaponSubMeshNames);
		}

		// Token: 0x06030E42 RID: 200258 RVA: 0x00C1D58C File Offset: 0x00C1B78C
		private static void SyncWeaponByNames(CharacterActorComponent concomitantActorComp, CharacterWeaponComponent ownerWeaponComp, string[] weaponNames)
		{
			TArray<UActorComponent> tarray = concomitantActorComp.Actor.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
			int[] ownerWeaponModelIds = ConcomitantWeaponHelper.GetOwnerWeaponModelIds(ownerWeaponComp);
			CharacterWeaponMesh weaponMesh = ownerWeaponComp.GetWeaponMesh();
			foreach (string text in weaponNames)
			{
				if (!(text == ""))
				{
					USkeletalMeshComponent uskeletalMeshComponent = null;
					for (int j = 0; j < tarray.Num(); j++)
					{
						USkeletalMeshComponent uskeletalMeshComponent2 = tarray.Get(j) as USkeletalMeshComponent;
						if (uskeletalMeshComponent2.GetName() == text)
						{
							uskeletalMeshComponent = uskeletalMeshComponent2;
							break;
						}
					}
					if (uskeletalMeshComponent != null)
					{
						int? num = null;
						int k = 0;
						while (k < weaponMesh.CharacterWeapons.Length)
						{
							if (weaponMesh.CharacterWeapons[k].Mesh.GetName() == text)
							{
								if (k < ownerWeaponModelIds.Length)
								{
									num = new int?(ownerWeaponModelIds[k]);
									break;
								}
								break;
							}
							else
							{
								k++;
							}
						}
						if (num != null)
						{
							int? num2 = num;
							int num3 = 0;
							if (!(num2.GetValueOrDefault() == num3 & num2 != null))
							{
								ConcomitantWeaponHelper.SetWeaponModel(uskeletalMeshComponent, num.Value);
							}
						}
					}
				}
			}
		}

		// Token: 0x06030E43 RID: 200259 RVA: 0x00C1D6B4 File Offset: 0x00C1B8B4
		private static void SetWeaponModel(USkeletalMeshComponent targetMesh, int modelId)
		{
			SModelConfig modelConfig = ModelUtil.GetModelConfig(modelId);
			if (modelConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.HXY;
				string message = "武器模型配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("modelId", modelId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Action<UClass, string> <>9__1;
			Singleton<ResourceSystem>.Instance.LoadAsync<USkeletalMesh>(modelConfig.网格体.ToAssetPathName(), delegate([Nullable(2)] USkeletalMesh skeletalMesh, string _)
			{
				if (skeletalMesh == null || targetMesh == null)
				{
					return;
				}
				int numMaterials = targetMesh.GetNumMaterials();
				for (int i = 0; i < numMaterials; i++)
				{
					targetMesh.SetMaterial(i, null);
				}
				TArray<FSkeletalMaterial> materials = skeletalMesh.Materials;
				int num = materials.Num();
				targetMesh.SetAnimClass(default(UClassStackOnlyPtr));
				targetMesh.SetSkeletalMesh(skeletalMesh, false);
				for (int j = 0; j < num; j++)
				{
					targetMesh.SetMaterial(j, materials.Get(j).MaterialInterface);
				}
				string text = modelConfig.动画蓝图.ToAssetPathName();
				if (text != "")
				{
					ResourceSystem instance2 = Singleton<ResourceSystem>.Instance;
					string path = text;
					Action<UClass, string> callback;
					if ((callback = <>9__1) == null)
					{
						callback = (<>9__1 = delegate([Nullable(2)] UClass animInstanceClass, string _)
						{
							if (animInstanceClass != null && targetMesh != null)
							{
								targetMesh.SetAnimClass(animInstanceClass.ClassStackOnlyPtr);
							}
						});
					}
					instance2.LoadAsync<UClass>(path, callback, 100, "js_undefined");
				}
			}, 100, "js_undefined");
		}

		// Token: 0x06030E44 RID: 200260 RVA: 0x00C1D744 File Offset: 0x00C1B944
		private static int[] GetOwnerWeaponModelIds(CharacterWeaponComponent ownerWeaponComp)
		{
			CharacterActorComponent actorComp = ownerWeaponComp.ActorComp;
			int num = (actorComp != null) ? actorComp.CreatureData.GetWeaponSkinId() : 0;
			if (num > 0)
			{
				return ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(num).Models();
			}
			WeaponEquipInfo weaponEquipInfo = ownerWeaponComp.WeaponEquipInfo;
			return ((weaponEquipInfo != null) ? ((weaponEquipInfo._WeaponConfig != null) ? weaponEquipInfo._WeaponConfig.GetValueOrDefault().Models() : null) : null) ?? Array.Empty<int>();
		}
	}
}
