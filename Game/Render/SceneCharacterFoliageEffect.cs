using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using AkiClient.Game.Aki.UI.Manager;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004781 RID: 18305
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneCharacterFoliageEffect : IStaticVariableResetter
	{
		// Token: 0x0602F7CB RID: 194507 RVA: 0x00B4A0D8 File Offset: 0x00B482D8
		static SceneCharacterFoliageEffect()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SceneCharacterFoliageEffect.CreateStaticDefaultValue), new Action(SceneCharacterFoliageEffect.ResetStaticDefaultValue));
		}

		// Token: 0x0602F7CC RID: 194508 RVA: 0x00B4A254 File Offset: 0x00B48454
		public void Start(TsBaseCharacter owner)
		{
			if (!owner.IsValid())
			{
				return;
			}
			if (UKismetSystemLibrary.GetConsoleVariableFloatValue("r.Kuro.InteractionEffect.EnableFoliageEffect") <= 0f)
			{
				return;
			}
			this.Owner = owner;
			this.IsReady = true;
			this.TempColor = new FLinearColor();
			Singleton<ResourceSystem>.Instance.LoadAsync<UNiagaraDataChannelAsset>("/Game/Aki/Effect/NiagaraDataChannel/NDCAsset/Scene/NDC_Leaves.NDC_Leaves", delegate([Nullable(2)] UNiagaraDataChannelAsset result, string _)
			{
				if (result == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RenderEffect;
					ELogAuthor author = ELogAuthor.LLX;
					string message = "[FoliageEffect] NDC加载失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", "/Game/Aki/Effect/NiagaraDataChannel/NDCAsset/Scene/NDC_Leaves.NDC_Leaves");
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				this.NDCAssetDefault = result;
			}, 100, "js_undefined");
			Singleton<ResourceSystem>.Instance.LoadAsync<UNiagaraDataChannelAsset>("/Game/Aki/Effect/NiagaraDataChannel/NDCAsset/Scene/NDC_Leaves_SF.NDC_Leaves_SF", delegate([Nullable(2)] UNiagaraDataChannelAsset result, string _)
			{
				if (result == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RenderEffect;
					ELogAuthor author = ELogAuthor.LLX;
					string message = "[FoliageEffect] NDC加载失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", "/Game/Aki/Effect/NiagaraDataChannel/NDCAsset/Scene/NDC_Leaves_SF.NDC_Leaves_SF");
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				this.NDCAssetSeqFrame = result;
			}, 100, "js_undefined");
			Singleton<ResourceSystem>.Instance.LoadAsync<UMaterialParameterCollection>("/Game/Aki/Render/Shaders/Scene/Interaction/MPC_NDCParameter.MPC_NDCParameter", delegate([Nullable(2)] UMaterialParameterCollection result, string _)
			{
				if (result == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RenderEffect;
					ELogAuthor author = ELogAuthor.LLX;
					string message = "[FoliageEffect] MPC加载失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", "/Game/Aki/Render/Shaders/Scene/Interaction/MPC_NDCParameter.MPC_NDCParameter");
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				this.MPCAsset = result;
			}, 100, "js_undefined");
			UDataTable table = Singleton<ResourceSystem>.Instance.Load<UDataTable>("/Game/Aki/Data/Effect/DT_FoliageNDCEffect.DT_FoliageNDCEffect", "js_undefined");
			this.ConfigMap.Clear();
			this.foliageNameArray = new TArray<string>();
			List<Tuple<string, FKuroInteractionEffectTraceFoliage>> allDataTableRowFromTableWithRowName = DataTableUtil.GetAllDataTableRowFromTableWithRowName<FKuroInteractionEffectTraceFoliage>(table);
			if (allDataTableRowFromTableWithRowName.Count > 0)
			{
				foreach (Tuple<string, FKuroInteractionEffectTraceFoliage> tuple in allDataTableRowFromTableWithRowName)
				{
					TSoftObjectPtr<UObject> tsoftObjectPtr = new TSoftObjectPtr<UObject>(tuple.Item2.FoliageMesh);
					if (UKismetSystemLibrary.IsValidSoftObjectReference(tsoftObjectPtr))
					{
						string text = tuple.Item2.FoliageMesh.ToAssetPathName();
						this.ConfigMap[text] = tuple.Item2;
						this.foliageNameArray.Add(text);
					}
				}
			}
		}

		// Token: 0x0602F7CD RID: 194509 RVA: 0x00B4A3C0 File Offset: 0x00B485C0
		[NullableContext(2)]
		private void WeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			this.WeaponPosition = new FVectorDouble?(OriginPoint);
		}

		// Token: 0x0602F7CE RID: 194510 RVA: 0x00B4A3D0 File Offset: 0x00B485D0
		public void Enable()
		{
			if (!this.IsReady)
			{
				return;
			}
			this.IsEnabled = true;
			this.ScalarParameterCache.Clear();
			this.VectorParameterCache.Clear();
			BP_EventManager_C bpEventManager = GlobalData.BpEventManager;
			if (bpEventManager != null)
			{
				bpEventManager.武器交互场景时.Remove(new Action<FVectorDouble, BP_SceneBattleInteract_C, int>(this.WeaponInteraction));
			}
			if (bpEventManager != null)
			{
				bpEventManager.武器交互场景时.Add(new Action<FVectorDouble, BP_SceneBattleInteract_C, int>(this.WeaponInteraction));
			}
			CharacterActorComponent characterActorComponent = this.Owner.CharacterActorComponent;
			CharacterActorComponent actorComponent;
			if (characterActorComponent == null)
			{
				actorComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				actorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
			}
			this.ActorComponent = actorComponent;
			this.EnviInteractionComponent = (this.Owner.GetComponentByClass(UKuroEnviInteractionComponent.StaticClass()) as UKuroEnviInteractionComponent);
			this.kuroEnviInteractionSystem = UKuroInteractionEffectSystem.GetKuroInteractionEffectSystem(this.Owner.GetWorld());
		}

		// Token: 0x0602F7CF RID: 194511 RVA: 0x00B4A4A0 File Offset: 0x00B486A0
		public void Disable()
		{
			if (!this.IsEnabled)
			{
				return;
			}
			this.IsEnabled = false;
			this.kuroEnviInteractionSystem = null;
			BP_EventManager_C bpEventManager = GlobalData.BpEventManager;
			if (bpEventManager == null)
			{
				return;
			}
			bpEventManager.武器交互场景时.Remove(new Action<FVectorDouble, BP_SceneBattleInteract_C, int>(this.WeaponInteraction));
		}

		// Token: 0x0602F7D0 RID: 194512 RVA: 0x00B4A4DC File Offset: 0x00B486DC
		private bool RefreshKuroEnviInteractionSystem()
		{
			if (this.Owner == null || !UKismetSystemLibrary.IsValid(this.Owner))
			{
				this.kuroEnviInteractionSystem = null;
				return false;
			}
			if (this.kuroEnviInteractionSystem == null || !UKismetSystemLibrary.IsValid(this.kuroEnviInteractionSystem))
			{
				this.kuroEnviInteractionSystem = UKuroInteractionEffectSystem.GetKuroInteractionEffectSystem(this.Owner.GetWorld());
			}
			return this.kuroEnviInteractionSystem != null && UKismetSystemLibrary.IsValid(this.kuroEnviInteractionSystem);
		}

		// Token: 0x0602F7D1 RID: 194513 RVA: 0x00B4A548 File Offset: 0x00B48748
		public void Tick(float deltaSeconds)
		{
			if (!this.IsEnabled || this.Owner == null)
			{
				return;
			}
			CharacterActorComponent actorComponent = this.ActorComponent;
			if (actorComponent != null && actorComponent.IsAutonomousProxy)
			{
				this.Timer++;
				if (this.Timer >= 3)
				{
					if (this.RefreshKuroEnviInteractionSystem())
					{
						this.UpdatePlayerState();
						this.CalcSpeed();
						this.CalcSpawnMessage();
						this.SetFoliageMPC();
						this.SpawnNDC();
					}
					this.Timer = 0;
				}
			}
		}

		// Token: 0x0602F7D2 RID: 194514 RVA: 0x00B4A5C0 File Offset: 0x00B487C0
		private void SpawnNDC()
		{
			if (!this.IsReady || this.Owner == null || this.NDCAssetDefault == null || this.NDCAssetSeqFrame == null)
			{
				return;
			}
			CharacterActorComponent characterActorComponent = this.Owner.CharacterActorComponent;
			BaseTagComponent baseTagComponent;
			if (characterActorComponent == null)
			{
				baseTagComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
			}
			BaseTagComponent baseTagComponent2 = baseTagComponent;
			if ((baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.状态.空中状态"])) || (baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"])))
			{
				return;
			}
			if (this.DefaultSpawnCount > 0)
			{
				UNiagaraDataChannelLibrary.WriteToNiagaraDataChannel(this.Owner.GetWorld(), this.NDCAssetDefault, SceneCharacterFoliageEffect.NDCSearchParam, this.DefaultSpawnCount, true, true, false, "TS FoliageEffect WriteToNDC Default");
			}
			if (this.SeqFrameSpawnCount > 0)
			{
				UNiagaraDataChannelLibrary.WriteToNiagaraDataChannel(this.Owner.GetWorld(), this.NDCAssetSeqFrame, SceneCharacterFoliageEffect.NDCSearchParam, this.SeqFrameSpawnCount, true, true, false, "TS FoliageEffect WriteToNDC SeqFrame");
			}
		}

		// Token: 0x0602F7D3 RID: 194515 RVA: 0x00B4A6B0 File Offset: 0x00B488B0
		private void CalcSpeed()
		{
			if (!this.IsReady)
			{
				return;
			}
			this.WeaponSpeed = 0.0;
			if (this.WeaponPosition != null)
			{
				if (this.PreWeaponPosition != null)
				{
					this.WeaponSpeed = Singleton<MathUtils>.Instance.VectorDistance(this.WeaponPosition.Value, this.PreWeaponPosition.Value);
					FVectorDouble fvectorDouble = this.WeaponPosition.Value;
					FVectorDouble value = this.PreWeaponPosition.Value;
					this.WeaponVelocity = new FVector?((fvectorDouble - value).ToVector());
				}
				else
				{
					this.WeaponVelocity = null;
				}
			}
			this.PreWeaponPosition = this.WeaponPosition;
			this.PlayerSpeed = ((this.PrePlayerPosition != null) ? Singleton<MathUtils>.Instance.VectorDistance(this.Owner.D_K2_GetActorLocation(), this.PrePlayerPosition.Value) : 0.0);
			if (this.PrePlayerPosition != null)
			{
				FVectorDouble fvectorDouble = this.Owner.D_K2_GetActorLocation();
				FVectorDouble value = this.PrePlayerPosition.Value;
				this.PlayerVelocity = new FVector?((fvectorDouble - value).ToVector());
			}
			else
			{
				this.PlayerVelocity = null;
			}
			this.PrePlayerPosition = new FVectorDouble?(this.Owner.D_K2_GetActorLocation());
			this.WeaponSpawn = this.CalcWeaponSpawn();
			this.PlayerSpawn = this.CalcPlayerSpawn();
		}

		// Token: 0x0602F7D4 RID: 194516 RVA: 0x00B4A834 File Offset: 0x00B48A34
		private void CalcSpawnMessage()
		{
			if (this.Owner == null || this.foliageNameArray == null || !this.RefreshKuroEnviInteractionSystem())
			{
				return;
			}
			UKuroInteractionEffectSystem ukuroInteractionEffectSystem = this.kuroEnviInteractionSystem;
			if (ukuroInteractionEffectSystem == null)
			{
				return;
			}
			if (this.EnviInteractionComponent == null)
			{
				this.EnviInteractionComponent = (this.Owner.GetComponentByClass(UKuroEnviInteractionComponent.StaticClass()) as UKuroEnviInteractionComponent);
			}
			this.WeightSpawnArrayDefault.Clear();
			this.WeightSpawnArraySeqFrame.Clear();
			TArray<int> tarray = ukuroInteractionEffectSystem.SearchInteractionFoliageArray(this.foliageNameArray);
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				string key = this.foliageNameArray.Get(i);
				FKuroInteractionEffectNDCConfigBase fkuroInteractionEffectNDCConfigBase;
				if (this.ConfigMap.TryGetValue(key, out fkuroInteractionEffectNDCConfigBase))
				{
					double num2 = (double)((float)tarray.Get(i) * fkuroInteractionEffectNDCConfigBase.SpawnNum);
					if (num2 > 0.0)
					{
						int effectIndex = fkuroInteractionEffectNDCConfigBase.EffectIndex;
						if (effectIndex != 0)
						{
							if (effectIndex == 1)
							{
								this.TryInsertTopWeightedSpawn(this.WeightSpawnArraySeqFrame, num2, fkuroInteractionEffectNDCConfigBase);
							}
						}
						else
						{
							this.TryInsertTopWeightedSpawn(this.WeightSpawnArrayDefault, num2, fkuroInteractionEffectNDCConfigBase);
						}
					}
				}
			}
			UKuroEnviInteractionComponent enviInteractionComponent = this.EnviInteractionComponent;
			if (enviInteractionComponent != null)
			{
				TWeakObjectPtr<AActor> hitBushActor = enviInteractionComponent.GetEnviInteractionData().HitBushActor;
				if (hitBushActor.IsValid(false, false))
				{
					UStaticMeshComponent ustaticMeshComponent = hitBushActor.Get().GetComponentByClass(UStaticMeshComponent.StaticClass()) as UStaticMeshComponent;
					if (ustaticMeshComponent != null && ustaticMeshComponent.StaticMesh != null)
					{
						FKuroInteractionEffectTraceStaticMesh fkuroInteractionEffectTraceStaticMesh = ukuroInteractionEffectSystem.SearchInteractionStaticMeshConfig(ustaticMeshComponent.StaticMesh);
						if (fkuroInteractionEffectTraceStaticMesh.SpawnNum > 0f)
						{
							int effectIndex = fkuroInteractionEffectTraceStaticMesh.EffectIndex;
							if (effectIndex == 0)
							{
								this.TryInsertTopWeightedSpawn(this.WeightSpawnArrayDefault, (double)fkuroInteractionEffectTraceStaticMesh.SpawnNum, fkuroInteractionEffectTraceStaticMesh);
								return;
							}
							if (effectIndex != 1)
							{
								return;
							}
							this.TryInsertTopWeightedSpawn(this.WeightSpawnArraySeqFrame, (double)fkuroInteractionEffectTraceStaticMesh.SpawnNum, fkuroInteractionEffectTraceStaticMesh);
						}
					}
				}
			}
		}

		// Token: 0x0602F7D5 RID: 194517 RVA: 0x00B4A9F0 File Offset: 0x00B48BF0
		private bool ClampHeight(double Height)
		{
			return this.IsReady && (this.Owner != null && this.WeaponPosition != null && this.WeaponPosition.Value.Z - this.Owner.D_K2_GetActorLocation().Z <= Height);
		}

		// Token: 0x0602F7D6 RID: 194518 RVA: 0x00B4AA44 File Offset: 0x00B48C44
		private void SetFoliageMPC()
		{
			if (this.MPCAsset == null)
			{
				return;
			}
			if (this.WeaponPosition != null)
			{
				this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_LeaveSpawnPosition, this.WeaponPosition.Value.X, this.WeaponPosition.Value.Y, this.WeaponPosition.Value.Z, 0.0);
			}
			if (this.Owner != null)
			{
				this.SetScalarParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_OnMotorcycle, this.OnMotorcycle > false);
				this.SetScalarParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_PlayerSpeed, this.PlayerSpeed);
				if (this.PrePlayerPosition != null)
				{
					double num = this.PrePlayerPosition.Value.X;
					double num2 = this.PrePlayerPosition.Value.Y;
					double num3 = this.PrePlayerPosition.Value.Z;
					if (this.OnMotorcycle && this.Owner.CharacterActorComponent != null && this.PlayerMotorcycleSpawnOffset != null)
					{
						num += (double)this.PlayerMotorcycleSpawnOffset.Value.X;
						num2 += (double)this.PlayerMotorcycleSpawnOffset.Value.Y;
						num3 += (double)this.PlayerMotorcycleSpawnOffset.Value.Z;
					}
					this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_PlayerSpawnPosition, num, num2, num3, 0.0);
				}
				if (this.WeaponVelocity != null)
				{
					this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_WeaponVelocity, (double)this.WeaponVelocity.Value.X, (double)this.WeaponVelocity.Value.Y, (double)this.WeaponVelocity.Value.Z, 0.0);
				}
				if (this.PlayerVelocity != null)
				{
					this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_PlayerVelocity, (double)this.PlayerVelocity.Value.X, (double)this.PlayerVelocity.Value.Y, (double)this.PlayerVelocity.Value.Z, 0.0);
				}
			}
			this.DefaultSpawnCount = this.SetDefaultFoliageMPC();
			this.SeqFrameSpawnCount = this.SetSeqFrameFoliageMPC();
		}

		// Token: 0x0602F7D7 RID: 194519 RVA: 0x00B4AC54 File Offset: 0x00B48E54
		private int SetDefaultFoliageMPC()
		{
			if (this.MPCAsset == null)
			{
				return 0;
			}
			int num = Math.Min(4, this.WeightSpawnArrayDefault.Count);
			double num2 = 0.0;
			for (int i = 0; i < num; i++)
			{
				num2 += this.WeightSpawnArrayDefault[i].Item1;
			}
			if (num2 <= 0.0)
			{
				return 0;
			}
			double item = this.WeightSpawnArrayDefault[0].Item1;
			double num3 = this.WeightSpawnArrayDefault[Math.Min(1, num - 1)].Item1 + item;
			double w = this.WeightSpawnArrayDefault[Math.Min(2, num - 1)].Item1 + num3;
			double x = (double)this.WeightSpawnArrayDefault[0].Item2.TypeIndex;
			double z = (double)this.WeightSpawnArrayDefault[Math.Min(1, num - 1)].Item2.TypeIndex;
			double x2 = (double)this.WeightSpawnArrayDefault[Math.Min(2, num - 1)].Item2.TypeIndex;
			double z2 = (double)this.WeightSpawnArrayDefault[Math.Min(3, num - 1)].Item2.TypeIndex;
			this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_SpawnParam0, x, 0.0, z, item);
			this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_SpawnParam1, x2, num3, z2, w);
			double playerSpawnPercent = this.GetPlayerSpawnPercent(this.WeightSpawnArrayDefault[0].Item2);
			double x3 = this.ClampHeight((double)this.WeightSpawnArrayDefault[0].Item2.HeightClamp) ? playerSpawnPercent : 10.0;
			double playerSpawnPercent2 = this.GetPlayerSpawnPercent(this.WeightSpawnArrayDefault[Math.Min(1, num - 1)].Item2);
			double y = this.ClampHeight((double)this.WeightSpawnArrayDefault[Math.Min(1, num - 1)].Item2.HeightClamp) ? playerSpawnPercent2 : 10.0;
			double playerSpawnPercent3 = this.GetPlayerSpawnPercent(this.WeightSpawnArrayDefault[Math.Min(2, num - 1)].Item2);
			double z3 = this.ClampHeight((double)this.WeightSpawnArrayDefault[Math.Min(2, num - 1)].Item2.HeightClamp) ? playerSpawnPercent3 : 10.0;
			double playerSpawnPercent4 = this.GetPlayerSpawnPercent(this.WeightSpawnArrayDefault[Math.Min(3, num - 1)].Item2);
			double w2 = this.ClampHeight((double)this.WeightSpawnArrayDefault[Math.Min(3, num - 1)].Item2.HeightClamp) ? playerSpawnPercent4 : 10.0;
			this.SetScalarParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_SpawnNum, num2);
			if (this.Owner != null)
			{
				this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_PlayerSpawnOffset0, (double)this.WeightSpawnArrayDefault[0].Item2.PlayerSpawnOffset.X, (double)this.WeightSpawnArrayDefault[0].Item2.PlayerSpawnOffset.Y, (double)this.WeightSpawnArrayDefault[0].Item2.PlayerSpawnOffset.Z, 0.0);
				this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_PlayerSpawnOffset1, (double)this.WeightSpawnArrayDefault[Math.Min(1, num - 1)].Item2.PlayerSpawnOffset.X, (double)this.WeightSpawnArrayDefault[Math.Min(1, num - 1)].Item2.PlayerSpawnOffset.Y, (double)this.WeightSpawnArrayDefault[Math.Min(1, num - 1)].Item2.PlayerSpawnOffset.Z, 0.0);
				this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_PlayerSpawnOffset2, (double)this.WeightSpawnArrayDefault[Math.Min(2, num - 1)].Item2.PlayerSpawnOffset.X, (double)this.WeightSpawnArrayDefault[Math.Min(2, num - 1)].Item2.PlayerSpawnOffset.Y, (double)this.WeightSpawnArrayDefault[Math.Min(2, num - 1)].Item2.PlayerSpawnOffset.Z, 0.0);
				this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_PlayerSpawnOffset3, (double)this.WeightSpawnArrayDefault[Math.Min(3, num - 1)].Item2.PlayerSpawnOffset.X, (double)this.WeightSpawnArrayDefault[Math.Min(3, num - 1)].Item2.PlayerSpawnOffset.Y, (double)this.WeightSpawnArrayDefault[Math.Min(3, num - 1)].Item2.PlayerSpawnOffset.Z, 0.0);
				this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_PlayerPercent0123, x3, y, z3, w2);
			}
			return (int)Singleton<MathUtils>.Instance.GetFloatPointCeil(this.GetTotalSpawnCount(this.WeightSpawnArrayDefault, num), 0);
		}

		// Token: 0x0602F7D8 RID: 194520 RVA: 0x00B4B124 File Offset: 0x00B49324
		private int SetSeqFrameFoliageMPC()
		{
			if (this.MPCAsset == null)
			{
				return 0;
			}
			int num = Math.Min(4, this.WeightSpawnArraySeqFrame.Count);
			double num2 = 0.0;
			for (int i = 0; i < num; i++)
			{
				num2 += this.WeightSpawnArraySeqFrame[i].Item1;
			}
			if (num2 <= 0.0)
			{
				return 0;
			}
			double item = this.WeightSpawnArraySeqFrame[0].Item1;
			double num3 = this.WeightSpawnArraySeqFrame[Math.Min(1, num - 1)].Item1 + item;
			double w = this.WeightSpawnArraySeqFrame[Math.Min(2, num - 1)].Item1 + num3;
			double x = (double)this.WeightSpawnArraySeqFrame[0].Item2.TypeIndex;
			double z = (double)this.WeightSpawnArraySeqFrame[Math.Min(1, num - 1)].Item2.TypeIndex;
			double x2 = (double)this.WeightSpawnArraySeqFrame[Math.Min(2, num - 1)].Item2.TypeIndex;
			double z2 = (double)this.WeightSpawnArraySeqFrame[Math.Min(3, num - 1)].Item2.TypeIndex;
			this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_SpawnParam0_SF, x, 0.0, z, item);
			this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_SpawnParam1_SF, x2, num3, z2, w);
			double playerSpawnPercent = this.GetPlayerSpawnPercent(this.WeightSpawnArraySeqFrame[0].Item2);
			double x3 = this.ClampHeight((double)this.WeightSpawnArraySeqFrame[0].Item2.HeightClamp) ? playerSpawnPercent : 10.0;
			double playerSpawnPercent2 = this.GetPlayerSpawnPercent(this.WeightSpawnArraySeqFrame[Math.Min(1, num - 1)].Item2);
			double y = this.ClampHeight((double)this.WeightSpawnArraySeqFrame[Math.Min(1, num - 1)].Item2.HeightClamp) ? playerSpawnPercent2 : 10.0;
			double playerSpawnPercent3 = this.GetPlayerSpawnPercent(this.WeightSpawnArraySeqFrame[Math.Min(2, num - 1)].Item2);
			double z3 = this.ClampHeight((double)this.WeightSpawnArraySeqFrame[Math.Min(2, num - 1)].Item2.HeightClamp) ? playerSpawnPercent3 : 10.0;
			double playerSpawnPercent4 = this.GetPlayerSpawnPercent(this.WeightSpawnArraySeqFrame[Math.Min(3, num - 1)].Item2);
			double w2 = this.ClampHeight((double)this.WeightSpawnArraySeqFrame[Math.Min(3, num - 1)].Item2.HeightClamp) ? playerSpawnPercent4 : 10.0;
			this.SetScalarParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_SpawnNum_SF, num2);
			if (this.Owner != null)
			{
				this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_PlayerSpawnOffset0_SF, (double)this.WeightSpawnArraySeqFrame[0].Item2.PlayerSpawnOffset.X, (double)this.WeightSpawnArraySeqFrame[0].Item2.PlayerSpawnOffset.Y, (double)this.WeightSpawnArraySeqFrame[0].Item2.PlayerSpawnOffset.Z, 0.0);
				this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_PlayerSpawnOffset1_SF, (double)this.WeightSpawnArraySeqFrame[Math.Min(1, num - 1)].Item2.PlayerSpawnOffset.X, (double)this.WeightSpawnArraySeqFrame[Math.Min(1, num - 1)].Item2.PlayerSpawnOffset.Y, (double)this.WeightSpawnArraySeqFrame[Math.Min(1, num - 1)].Item2.PlayerSpawnOffset.Z, 0.0);
				this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_PlayerSpawnOffset2_SF, (double)this.WeightSpawnArraySeqFrame[Math.Min(2, num - 1)].Item2.PlayerSpawnOffset.X, (double)this.WeightSpawnArraySeqFrame[Math.Min(2, num - 1)].Item2.PlayerSpawnOffset.Y, (double)this.WeightSpawnArraySeqFrame[Math.Min(2, num - 1)].Item2.PlayerSpawnOffset.Z, 0.0);
				this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_PlayerSpawnOffset3_SF, (double)this.WeightSpawnArraySeqFrame[Math.Min(3, num - 1)].Item2.PlayerSpawnOffset.X, (double)this.WeightSpawnArraySeqFrame[Math.Min(3, num - 1)].Item2.PlayerSpawnOffset.Y, (double)this.WeightSpawnArraySeqFrame[Math.Min(3, num - 1)].Item2.PlayerSpawnOffset.Z, 0.0);
				this.SetVectorParameterValueIfChanged(SceneCharacterFoliageEffect.MPC_PlayerPercent0123_SF, x3, y, z3, w2);
			}
			return (int)Singleton<MathUtils>.Instance.GetFloatPointCeil(this.GetTotalSpawnCount(this.WeightSpawnArraySeqFrame, num), 0);
		}

		// Token: 0x0602F7D9 RID: 194521 RVA: 0x00B4B5F3 File Offset: 0x00B497F3
		private double CalcWeaponSpawn()
		{
			double num = Singleton<MathUtils>.Instance.Clamp(this.WeaponSpeed, 0.0, 300.0) / 300.0;
			return num * num * 0.5;
		}

		// Token: 0x0602F7DA RID: 194522 RVA: 0x00B4B630 File Offset: 0x00B49830
		private double CalcPlayerSpawn()
		{
			double num = this.OnMotorcycle ? 100.0 : 100.0;
			return Singleton<MathUtils>.Instance.Clamp(this.PlayerSpeed, 0.0, num) / num * this.PlayerMoveTypeParam;
		}

		// Token: 0x0602F7DB RID: 194523 RVA: 0x00B4B680 File Offset: 0x00B49880
		private void UpdatePlayerState()
		{
			if (!this.IsReady)
			{
				return;
			}
			CharacterActorComponent characterActorComponent = this.Owner.CharacterActorComponent;
			FVectorDouble? fvectorDouble = (characterActorComponent != null) ? new FVectorDouble?(characterActorComponent.ActorForward) : null;
			CharacterActorComponent characterActorComponent2 = this.Owner.CharacterActorComponent;
			BaseTagComponent baseTagComponent;
			if (characterActorComponent2 == null)
			{
				baseTagComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent2.Entity;
				baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
			}
			BaseTagComponent baseTagComponent2 = baseTagComponent;
			if (baseTagComponent2 == null || !baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.驾驶期间"]))
			{
				if ((baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.行走"])) || (baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.行走停止"])) || (baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.站立"])))
				{
					this.PlayerMoveTypeParam = 0.0;
				}
				else
				{
					this.PlayerMoveTypeParam = 0.1;
				}
				this.OnMotorcycle = false;
				return;
			}
			this.PlayerMoveTypeParam = 1.0;
			this.OnMotorcycle = true;
			FVectorDouble value;
			if (baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.冲刺"]))
			{
				value = fvectorDouble.Value;
				this.PlayerMotorcycleSpawnOffset = new FVector?((value * (this.PlayerSpeed * 1.5)).ToVector());
				return;
			}
			if (baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.烧胎"]))
			{
				value = fvectorDouble.Value;
				this.PlayerMotorcycleSpawnOffset = new FVector?((value * -100.0).ToVector());
				return;
			}
			value = fvectorDouble.Value;
			this.PlayerMotorcycleSpawnOffset = new FVector?((value * (this.PlayerSpeed * 1.2)).ToVector());
		}

		// Token: 0x0602F7DC RID: 194524 RVA: 0x00B4B853 File Offset: 0x00B49A53
		private void SetTempColor(double R, double G, double B, double A)
		{
			this.TempColor.R = (float)R;
			this.TempColor.G = (float)G;
			this.TempColor.B = (float)B;
			this.TempColor.A = (float)A;
		}

		// Token: 0x0602F7DD RID: 194525 RVA: 0x00B4B88C File Offset: 0x00B49A8C
		private double GetPlayerSpawnPercent(FKuroInteractionEffectNDCConfigBase config)
		{
			double num = this.PlayerSpawn * (double)config.MoveSpawn;
			double num2 = this.WeaponSpawn * (double)config.WeaponSpawn;
			return Math.Round(Singleton<MathUtils>.Instance.Clamp((num + 0.001) / (num2 + num + 0.001), 0.0, 1.0) * 10.0);
		}

		// Token: 0x0602F7DE RID: 194526 RVA: 0x00B4B8FC File Offset: 0x00B49AFC
		private double GetTotalSpawnCount([Nullable(new byte[]
		{
			1,
			0,
			1
		})] List<ValueTuple<double, FKuroInteractionEffectNDCConfigBase>> weightSpawnArray, int typeNum)
		{
			double num = 0.0;
			for (int i = 0; i < typeNum; i++)
			{
				ValueTuple<double, FKuroInteractionEffectNDCConfigBase> valueTuple = weightSpawnArray[i];
				double num2 = Math.Max(this.WeaponSpawn * (double)valueTuple.Item2.WeaponSpawn + this.PlayerSpawn * (double)valueTuple.Item2.MoveSpawn - 0.0001, 0.0);
				num += valueTuple.Item1 * num2;
			}
			return num;
		}

		// Token: 0x0602F7DF RID: 194527 RVA: 0x00B4B974 File Offset: 0x00B49B74
		private void TryInsertTopWeightedSpawn([Nullable(new byte[]
		{
			1,
			0,
			1
		})] List<ValueTuple<double, FKuroInteractionEffectNDCConfigBase>> targetArray, double foliageNum, FKuroInteractionEffectNDCConfigBase message)
		{
			double num = foliageNum * (double)message.Weight;
			int num2 = targetArray.Count;
			for (int i = 0; i < targetArray.Count; i++)
			{
				ValueTuple<double, FKuroInteractionEffectNDCConfigBase> valueTuple = targetArray[i];
				if (num > valueTuple.Item1 * (double)valueTuple.Item2.Weight)
				{
					num2 = i;
					break;
				}
			}
			if (num2 >= 4 && targetArray.Count >= 4)
			{
				return;
			}
			targetArray.Insert(num2, new ValueTuple<double, FKuroInteractionEffectNDCConfigBase>(foliageNum, message));
			if (targetArray.Count > 4)
			{
				targetArray.RemoveRange(4, targetArray.Count - 4);
			}
		}

		// Token: 0x0602F7E0 RID: 194528 RVA: 0x00B4B9FC File Offset: 0x00B49BFC
		private void SetScalarParameterValueIfChanged(FName paramName, double value)
		{
			if (this.MPCAsset == null || this.Owner == null)
			{
				return;
			}
			string key = paramName.ToString();
			double num;
			if (this.ScalarParameterCache.TryGetValue(key, out num) && num == value)
			{
				return;
			}
			this.ScalarParameterCache[key] = value;
			UKismetMaterialLibrary.SetScalarParameterValue(this.Owner.GetWorld(), this.MPCAsset, paramName, (float)value);
		}

		// Token: 0x0602F7E1 RID: 194529 RVA: 0x00B4BA64 File Offset: 0x00B49C64
		private void SetVectorParameterValueIfChanged(FName paramName, double X, double Y, double Z, double W)
		{
			if (this.MPCAsset == null)
			{
				return;
			}
			string key = paramName.ToString();
			ValueTuple<double, double, double, double> valueTuple;
			if (this.VectorParameterCache.TryGetValue(key, out valueTuple) && valueTuple.Item1 == X && valueTuple.Item2 == Y && valueTuple.Item3 == Z && valueTuple.Item4 == W)
			{
				return;
			}
			this.VectorParameterCache[key] = new ValueTuple<double, double, double, double>(X, Y, Z, W);
			this.SetTempColor(X, Y, Z, W);
			UKismetMaterialLibrary.SetVectorParameterValue(GlobalData.World, this.MPCAsset, paramName, this.TempColor);
		}

		// Token: 0x0602F7E2 RID: 194530 RVA: 0x00B4BAF9 File Offset: 0x00B49CF9
		public static void CreateStaticDefaultValue()
		{
			SceneCharacterFoliageEffect.NDCSearchParam = new FNiagaraDataChannelSearchParameters();
		}

		// Token: 0x0602F7E3 RID: 194531 RVA: 0x00B4BB05 File Offset: 0x00B49D05
		public static void ResetStaticDefaultValue()
		{
			SceneCharacterFoliageEffect.NDCSearchParam = null;
		}

		// Token: 0x0401B201 RID: 111105
		private const string NDCAssetPathDefault = "/Game/Aki/Effect/NiagaraDataChannel/NDCAsset/Scene/NDC_Leaves.NDC_Leaves";

		// Token: 0x0401B202 RID: 111106
		private const string NDCAssetPathSeqFrame = "/Game/Aki/Effect/NiagaraDataChannel/NDCAsset/Scene/NDC_Leaves_SF.NDC_Leaves_SF";

		// Token: 0x0401B203 RID: 111107
		private const string ConfigPath = "/Game/Aki/Data/Effect/DT_FoliageNDCEffect.DT_FoliageNDCEffect";

		// Token: 0x0401B204 RID: 111108
		private const string MPCPath = "/Game/Aki/Render/Shaders/Scene/Interaction/MPC_NDCParameter.MPC_NDCParameter";

		// Token: 0x0401B205 RID: 111109
		private const double WEAPON_SPAWN_PARAM = 300.0;

		// Token: 0x0401B206 RID: 111110
		private const double PLAYER_SPAWN_PARAM = 100.0;

		// Token: 0x0401B207 RID: 111111
		private const double PLAYER_MOTORCYCLE_SPAWN_PARAM = 100.0;

		// Token: 0x0401B208 RID: 111112
		private const int MAX_SPAWN_TYPE_COUNT = 4;

		// Token: 0x0401B209 RID: 111113
		private const double PLAYER_PERCENT_SCALE = 10.0;

		// Token: 0x0401B20A RID: 111114
		[Nullable(2)]
		public TsBaseCharacter Owner;

		// Token: 0x0401B20B RID: 111115
		[Nullable(2)]
		public CharacterActorComponent ActorComponent;

		// Token: 0x0401B20C RID: 111116
		public bool IsReady;

		// Token: 0x0401B20D RID: 111117
		protected int Timer;

		// Token: 0x0401B20E RID: 111118
		protected double WeaponSpeed;

		// Token: 0x0401B20F RID: 111119
		public FVector? WeaponVelocity;

		// Token: 0x0401B210 RID: 111120
		public FVector? PlayerVelocity;

		// Token: 0x0401B211 RID: 111121
		protected double PlayerSpeed;

		// Token: 0x0401B212 RID: 111122
		protected double WeaponSpawn;

		// Token: 0x0401B213 RID: 111123
		protected double PlayerSpawn;

		// Token: 0x0401B214 RID: 111124
		protected double PlayerMoveTypeParam = 0.1;

		// Token: 0x0401B215 RID: 111125
		protected FVector? PlayerMotorcycleSpawnOffset;

		// Token: 0x0401B216 RID: 111126
		protected bool OnMotorcycle;

		// Token: 0x0401B217 RID: 111127
		protected FVectorDouble? WeaponPosition;

		// Token: 0x0401B218 RID: 111128
		protected int DefaultSpawnCount;

		// Token: 0x0401B219 RID: 111129
		protected int SeqFrameSpawnCount;

		// Token: 0x0401B21A RID: 111130
		protected FVectorDouble? PreWeaponPosition;

		// Token: 0x0401B21B RID: 111131
		protected FVectorDouble? PrePlayerPosition;

		// Token: 0x0401B21C RID: 111132
		[Nullable(2)]
		protected UNiagaraDataChannelAsset NDCAssetDefault;

		// Token: 0x0401B21D RID: 111133
		[Nullable(2)]
		protected UNiagaraDataChannelAsset NDCAssetSeqFrame;

		// Token: 0x0401B21E RID: 111134
		[Nullable(2)]
		protected UMaterialParameterCollection MPCAsset;

		// Token: 0x0401B21F RID: 111135
		protected Dictionary<string, FKuroInteractionEffectNDCConfigBase> ConfigMap = new Dictionary<string, FKuroInteractionEffectNDCConfigBase>();

		// Token: 0x0401B220 RID: 111136
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		protected List<ValueTuple<double, FKuroInteractionEffectNDCConfigBase>> WeightSpawnArrayDefault = new List<ValueTuple<double, FKuroInteractionEffectNDCConfigBase>>();

		// Token: 0x0401B221 RID: 111137
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		protected List<ValueTuple<double, FKuroInteractionEffectNDCConfigBase>> WeightSpawnArraySeqFrame = new List<ValueTuple<double, FKuroInteractionEffectNDCConfigBase>>();

		// Token: 0x0401B222 RID: 111138
		[Nullable(2)]
		protected UKuroInteractionEffectSystem kuroEnviInteractionSystem;

		// Token: 0x0401B223 RID: 111139
		[Nullable(2)]
		protected UKuroEnviInteractionComponent EnviInteractionComponent;

		// Token: 0x0401B224 RID: 111140
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected TArray<string> foliageNameArray;

		// Token: 0x0401B225 RID: 111141
		protected readonly Dictionary<string, double> ScalarParameterCache = new Dictionary<string, double>();

		// Token: 0x0401B226 RID: 111142
		[Nullable(new byte[]
		{
			1,
			1,
			0
		})]
		protected readonly Dictionary<string, ValueTuple<double, double, double, double>> VectorParameterCache = new Dictionary<string, ValueTuple<double, double, double, double>>();

		// Token: 0x0401B227 RID: 111143
		public static readonly FName MPC_LeaveSpawnPosition = new FName("NDC_LeaveSpawnPosition");

		// Token: 0x0401B228 RID: 111144
		public static readonly FName MPC_SpawnParam0 = new FName("SpawnParam0");

		// Token: 0x0401B229 RID: 111145
		public static readonly FName MPC_SpawnParam1 = new FName("SpawnParam1");

		// Token: 0x0401B22A RID: 111146
		public static readonly FName MPC_SpawnNum = new FName("SpawnNum");

		// Token: 0x0401B22B RID: 111147
		public static readonly FName MPC_SpawnParam0_SF = new FName("SpawnParam0_SF");

		// Token: 0x0401B22C RID: 111148
		public static readonly FName MPC_SpawnParam1_SF = new FName("SpawnParam1_SF");

		// Token: 0x0401B22D RID: 111149
		public static readonly FName MPC_SpawnNum_SF = new FName("SpawnNum_SF");

		// Token: 0x0401B22E RID: 111150
		public static readonly FName MPC_OnMotorcycle = new FName("OnMotorcycle");

		// Token: 0x0401B22F RID: 111151
		public static readonly FName MPC_PlayerSpeed = new FName("PlayerSpeed");

		// Token: 0x0401B230 RID: 111152
		public static readonly FName MPC_PlayerSpawnPosition = new FName("NDC_PlayerSpawnPosition");

		// Token: 0x0401B231 RID: 111153
		public static readonly FName MPC_PlayerSpawnOffset0 = new FName("PlayerSpawnOffset0");

		// Token: 0x0401B232 RID: 111154
		public static readonly FName MPC_PlayerSpawnOffset1 = new FName("PlayerSpawnOffset1");

		// Token: 0x0401B233 RID: 111155
		public static readonly FName MPC_PlayerSpawnOffset2 = new FName("PlayerSpawnOffset2");

		// Token: 0x0401B234 RID: 111156
		public static readonly FName MPC_PlayerSpawnOffset3 = new FName("PlayerSpawnOffset3");

		// Token: 0x0401B235 RID: 111157
		public static readonly FName MPC_PlayerPercent0123 = new FName("PlayerPercent0123");

		// Token: 0x0401B236 RID: 111158
		public static readonly FName MPC_PlayerSpawnOffset0_SF = new FName("PlayerSpawnOffset0_SF");

		// Token: 0x0401B237 RID: 111159
		public static readonly FName MPC_PlayerSpawnOffset1_SF = new FName("PlayerSpawnOffset1_SF");

		// Token: 0x0401B238 RID: 111160
		public static readonly FName MPC_PlayerSpawnOffset2_SF = new FName("PlayerSpawnOffset2_SF");

		// Token: 0x0401B239 RID: 111161
		public static readonly FName MPC_PlayerSpawnOffset3_SF = new FName("PlayerSpawnOffset3_SF");

		// Token: 0x0401B23A RID: 111162
		public static readonly FName MPC_PlayerPercent0123_SF = new FName("PlayerPercent0123_SF");

		// Token: 0x0401B23B RID: 111163
		public static readonly FName MPC_WeaponVelocity = new FName("WeaponVelocity");

		// Token: 0x0401B23C RID: 111164
		public static readonly FName MPC_PlayerVelocity = new FName("PlayerVelocity");

		// Token: 0x0401B23D RID: 111165
		protected FLinearColor TempColor;

		// Token: 0x0401B23E RID: 111166
		[Nullable(2)]
		protected static FNiagaraDataChannelSearchParameters NDCSearchParam = null;

		// Token: 0x0401B23F RID: 111167
		public bool IsEnabled;
	}
}
