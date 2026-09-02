using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.GaCha.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.WeaponLevelMaterial;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Weapon.Data;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002CFD RID: 11517
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class WeaponController : UiControllerBase<WeaponController>
{
	// Token: 0x0601740C RID: 95244 RVA: 0x006726D8 File Offset: 0x006708D8
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<WeaponItem, bool, bool>(EEventName.OnAddWeaponItem, new Action<WeaponItem, bool, bool>(this.OnAddWeaponItem));
		Singleton<EventSystem>.Instance.Add<WeaponItem>(EEventName.OnResponseWeaponItem, new Action<WeaponItem>(this.OnResponseWeaponItem));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.OnRemoveWeaponItem, new Action<IReadOnlyList<int>>(this.OnRemoveWeaponItem));
	}

	// Token: 0x0601740D RID: 95245 RVA: 0x0067273C File Offset: 0x0067093C
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<WeaponItem, bool, bool>(EEventName.OnAddWeaponItem, new Action<WeaponItem, bool, bool>(this.OnAddWeaponItem));
		Singleton<EventSystem>.Instance.Remove<WeaponItem>(EEventName.OnResponseWeaponItem, new Action<WeaponItem>(this.OnResponseWeaponItem));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<int>>(EEventName.OnRemoveWeaponItem, new Action<IReadOnlyList<int>>(this.OnRemoveWeaponItem));
	}

	// Token: 0x0601740E RID: 95246 RVA: 0x006727A0 File Offset: 0x006709A0
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<EquipTakeOnNotify>(ENotifyMessageId.EquipTakeOnNotify, delegate(EquipTakeOnNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			ModelBase<WeaponModel>.Instance.WeaponRoleLoadEquip(response.DataList);
		});
		Singleton<Net>.Instance.Register<EntityEquipChangeNotify>(ENotifyMessageId.EntityEquipChangeNotify, delegate(EntityEquipChangeNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			long creatureDataId = Singleton<MathUtils>.Instance.LongToNumber(notify.EntityId);
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
			CharacterWeaponComponent characterWeaponComponent;
			if (entity == null)
			{
				characterWeaponComponent = null;
			}
			else
			{
				WorldEntity entity2 = entity.Entity;
				characterWeaponComponent = ((entity2 != null) ? entity2.GetComponent<CharacterWeaponComponent>() : null);
			}
			CharacterWeaponComponent characterWeaponComponent2 = characterWeaponComponent;
			if (characterWeaponComponent2 == null)
			{
				return;
			}
			characterWeaponComponent2.OnEquipWeaponForRoleNotify(notify);
		});
	}

	// Token: 0x0601740F RID: 95247 RVA: 0x0067280B File Offset: 0x00670A0B
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EquipTakeOnNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EntityEquipChangeNotify);
	}

	// Token: 0x06017410 RID: 95248 RVA: 0x0067282D File Offset: 0x00670A2D
	private void OnAddWeaponItem(WeaponItem weaponItem, bool b, bool arg3)
	{
		ModelBase<WeaponModel>.Instance.AddWeaponData(weaponItem);
	}

	// Token: 0x06017411 RID: 95249 RVA: 0x0067283A File Offset: 0x00670A3A
	private void OnResponseWeaponItem(WeaponItem weaponItem)
	{
		ModelBase<WeaponModel>.Instance.AddWeaponData(weaponItem);
	}

	// Token: 0x06017412 RID: 95250 RVA: 0x00672848 File Offset: 0x00670A48
	private void OnRemoveWeaponItem(IReadOnlyList<int> uniqueIdList)
	{
		foreach (int incId in uniqueIdList)
		{
			ModelBase<WeaponModel>.Instance.RemoveWeaponData(incId);
		}
	}

	// Token: 0x06017413 RID: 95251 RVA: 0x00672894 File Offset: 0x00670A94
	public void SendPbWeaponLevelUpRequest(int incId, ISelectedData[] consumeList)
	{
		WeaponLevelUpRequest weaponLevelUpRequest = WeaponLevelUpRequest.Create();
		weaponLevelUpRequest.IncId = incId;
		foreach (ISelectedData selectedData in consumeList)
		{
			WeaponConsumeItem weaponConsumeItem = WeaponConsumeItem.Create();
			weaponConsumeItem.Count = selectedData.SelectedCount;
			weaponConsumeItem.IncId = selectedData.IncId;
			weaponConsumeItem.ItemId = selectedData.ItemId;
			weaponLevelUpRequest.ConsumeList.Add(weaponConsumeItem);
		}
		Singleton<Net>.Instance.Call<WeaponLevelUpResponse>(ERequestMessageId.WeaponLevelUpRequest, weaponLevelUpRequest, delegate(WeaponLevelUpResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				ModelBase<WeaponModel>.Instance.WeaponLevelUpResponse(response);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 21421, null, true, true);
		}, 0);
	}

	// Token: 0x06017414 RID: 95252 RVA: 0x00672930 File Offset: 0x00670B30
	public void SendPbWeaponBreachRequest(int incId, Action<int> callback)
	{
		WeaponBreachRequest weaponBreachRequest = WeaponBreachRequest.Create();
		weaponBreachRequest.IncId = incId;
		Singleton<Net>.Instance.Call<WeaponBreachResponse>(ERequestMessageId.WeaponBreachRequest, weaponBreachRequest, delegate(WeaponBreachResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				int weaponBreach = response.WeaponBreach;
				ModelBase<WeaponModel>.Instance.SetWeaponBreachData(incId, weaponBreach);
				callback(weaponBreach);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponBreachSuccessView, incId, null);
				Singleton<EventSystem>.Instance.Emit(EEventName.WeaponBreakUp);
				WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId);
				if (weaponDataByIncId != null && weaponDataByIncId.HasRole())
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.WeaponRoleBreakUp, weaponDataByIncId.GetRoleId());
					return;
				}
			}
			else
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27219, null, true, true);
			}
		}, 0);
	}

	// Token: 0x06017415 RID: 95253 RVA: 0x00672980 File Offset: 0x00670B80
	public void SendPbResonUpRequest(int incId, WeaponConsumeItem[] consumeList)
	{
		if (ControllerBase<RoleController>.Instance.CheckCharacterInBattleTagAndShowTips(false))
		{
			return;
		}
		WeaponResonUpRequest weaponResonUpRequest = WeaponResonUpRequest.Create();
		weaponResonUpRequest.IncId = incId;
		weaponResonUpRequest.ConsumeItemList.AddRange(consumeList);
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId);
		int lastLevel = weaponDataByIncId.GetResonanceLevel();
		Singleton<Net>.Instance.Call<WeaponResonUpResponse>(ERequestMessageId.WeaponResonUpRequest, weaponResonUpRequest, delegate(WeaponResonUpResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				ModelBase<WeaponModel>.Instance.SetWeaponResonanceData(response.IncId, response.ReaonLevel);
				Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.WeaponResonanceSuccess, incId, lastLevel);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20680, null, true, true);
		}, 0);
	}

	// Token: 0x06017416 RID: 95254 RVA: 0x00672A00 File Offset: 0x00670C00
	public void SendPbEquipTakeOnRequest(int roleId, EquipPos pos, int equipIncId)
	{
		if (ControllerBase<RoleController>.Instance.CheckCharacterInBattleTagAndShowTips(true))
		{
			return;
		}
		if (roleId <= 0)
		{
			return;
		}
		EquipTakeOnRequest equipTakeOnRequest = EquipTakeOnRequest.Create();
		equipTakeOnRequest.Data = RoleLoadEquipData.Create();
		equipTakeOnRequest.Data.RoleID = roleId;
		equipTakeOnRequest.Data.Pos = pos;
		equipTakeOnRequest.Data.EquipIncID = equipIncId;
		Singleton<Net>.Instance.Call<EquipTakeOnResponse>(ERequestMessageId.EquipTakeOnRequest, equipTakeOnRequest, delegate(EquipTakeOnResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				ModelBase<WeaponModel>.Instance.WeaponRoleLoadEquip(response.DataList);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26033, null, true, true);
		}, 0);
	}

	// Token: 0x06017417 RID: 95255 RVA: 0x00672A88 File Offset: 0x00670C88
	private static void LoadWeaponModelInCurrentObserver(int[] models, int[] modelsIndex, int transformId, string weaponCase, string scabbardCase, UiModelBase weaponModel, UiModelBase scabbardModel, bool needMeshStreaming = false, int? skinId = null)
	{
		WeaponController.<>c__DisplayClass11_0 CS$<>8__locals1 = new WeaponController.<>c__DisplayClass11_0();
		CS$<>8__locals1.weaponModel = weaponModel;
		CS$<>8__locals1.scabbardModel = scabbardModel;
		CS$<>8__locals1.weaponCase = weaponCase;
		if (CS$<>8__locals1.weaponModel == null)
		{
			return;
		}
		if (models.Length == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.Weapon, ELogAuthor.LRC, "武器模型未配置 请检查", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (models.Length != modelsIndex.Length)
		{
			Singleton<Log>.Instance.Error(ELogModule.Weapon, ELogAuthor.LRC, "武器模型与索引配置长度不一致 请检查", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		CS$<>8__locals1.weaponPromise = new CustomPromise();
		CS$<>8__locals1.scabbardPromise = new CustomPromise();
		UiModelEffectComponent component = CS$<>8__locals1.weaponModel.GetComponent<UiModelEffectComponent>();
		if (component != null)
		{
			component.NeedSetUiScale = true;
		}
		UiWeaponDataComponent uiWeaponDataComponent = CS$<>8__locals1.weaponModel.CheckGetComponent<UiWeaponDataComponent>();
		SGachaWeaponTransform? sgachaWeaponTransform;
		if (!DataTableUtil.TryGetDataTableRowStruct<SGachaWeaponTransform>(EDataTable.GachaWeaponTransform, (skinId ?? uiWeaponDataComponent.WeaponConfigId).ToString(), out sgachaWeaponTransform))
		{
			WeaponController.<>c__DisplayClass11_0 CS$<>8__locals2 = CS$<>8__locals1;
			WeaponModelTransform? weaponModelTransformData = ConfigBase<WeaponConfig>.Instance.GetWeaponModelTransformData(transformId);
			CS$<>8__locals2.transformData = ((weaponModelTransformData != null) ? weaponModelTransformData.GetValueOrDefault() : null);
		}
		else
		{
			CS$<>8__locals1.transformData = sgachaWeaponTransform.Value;
		}
		CS$<>8__locals1.weaponActorComponent = CS$<>8__locals1.weaponModel.CheckGetComponent<UiModelActorComponent>();
		UiModelActorComponent weaponActorComponent = CS$<>8__locals1.weaponActorComponent;
		if (weaponActorComponent != null)
		{
			weaponActorComponent.SetTransformByTag(CS$<>8__locals1.weaponCase);
		}
		UiModelLoadComponent uiModelLoadComponent = CS$<>8__locals1.weaponModel.CheckGetComponent<UiModelLoadComponent>();
		int num = (modelsIndex.Length == models.Length) ? modelsIndex[0] : 0;
		WeaponDataBase weaponDataBase = (uiWeaponDataComponent != null) ? uiWeaponDataComponent.WeaponData : null;
		int breachLevel = (weaponDataBase != null) ? weaponDataBase.GetBreachLevel() : 0;
		Singleton<UiModelUtil>.Instance.SetWeaponLevelMaterialBreachLevel(CS$<>8__locals1.weaponModel, breachLevel);
		if (uiModelLoadComponent != null)
		{
			uiModelLoadComponent.LoadModelByModelId(models[num], needMeshStreaming, delegate
			{
				WeaponController.WeaponLoadCallBack(CS$<>8__locals1.weaponModel, CS$<>8__locals1.transformData, CS$<>8__locals1.weaponActorComponent);
				CS$<>8__locals1.weaponPromise.SetResult();
			}, null);
		}
		WeaponController.StartRotate(CS$<>8__locals1.weaponPromise, CS$<>8__locals1.scabbardPromise, CS$<>8__locals1.weaponModel, CS$<>8__locals1.transformData);
		if (CS$<>8__locals1.scabbardModel == null)
		{
			CS$<>8__locals1.scabbardPromise.SetResult();
			return;
		}
		if (CS$<>8__locals1.transformData.ShowScabbard())
		{
			if (models.Length > 1)
			{
				UiModelEffectComponent component2 = CS$<>8__locals1.scabbardModel.GetComponent<UiModelEffectComponent>();
				if (component2 != null)
				{
					component2.NeedSetUiScale = true;
				}
				UiModelLoadComponent uiModelLoadComponent2 = CS$<>8__locals1.scabbardModel.CheckGetComponent<UiModelLoadComponent>();
				int num2 = (modelsIndex.Length == models.Length) ? modelsIndex[1] : 1;
				Singleton<UiModelUtil>.Instance.SetWeaponLevelMaterialBreachLevel(CS$<>8__locals1.scabbardModel, breachLevel);
				uiModelLoadComponent2.LoadModelByModelId(models[num2], false, delegate
				{
					WeaponController.ScabbardLoadCallBack(CS$<>8__locals1.scabbardModel, CS$<>8__locals1.transformData, CS$<>8__locals1.weaponCase);
					CS$<>8__locals1.scabbardPromise.SetResult();
				}, null);
				return;
			}
		}
		else
		{
			Singleton<UiModelUtil>.Instance.SetVisible(CS$<>8__locals1.scabbardModel, false);
		}
		CS$<>8__locals1.scabbardPromise.SetResult();
	}

	// Token: 0x06017418 RID: 95256 RVA: 0x00672CF8 File Offset: 0x00670EF8
	private static void WeaponLoadCallBack(UiModelBase weaponModel, TWeaponModelTransform transformData, UiModelActorComponent weaponActorComponent)
	{
		Singleton<UiModelUtil>.Instance.SetVisible(weaponModel, true);
		global::Vector vector = transformData.Location();
		global::Vector vector2 = transformData.Rotation();
		global::Vector vector3 = transformData.AxisRotate();
		float num = transformData.Size();
		global::Vector inT = global::Vector.Create(vector.X, vector.Y, vector.Z);
		global::Rotator rotator = global::Rotator.Create((float)vector2.Y, (float)vector2.Z, (float)vector2.X);
		global::Vector inS = global::Vector.Create((double)num, (double)num, (double)num);
		global::Transform transform = global::Transform.Create(rotator.Quaternion(null), inT, inS);
		FHitResult fhitResult = new FHitResult();
		if (weaponActorComponent != null)
		{
			USkeletalMeshComponent mainMeshComponent = weaponActorComponent.MainMeshComponent;
			if (mainMeshComponent != null)
			{
				FTransformDouble ftransformDouble = transform.ToUeTransform();
				mainMeshComponent.D_K2_SetRelativeTransform(ftransformDouble, false, ref fhitResult, false);
			}
		}
		Singleton<UiModelUtil>.Instance.SetRenderingMaterial(weaponModel, "WeaponRootWeaponMaterialController");
		Singleton<UiModelUtil>.Instance.PlayEffectOnRoot(weaponModel, "WeaponRootWeaponShowHideEffect");
		rotator.Set((float)vector3.Y, (float)vector3.Z, (float)vector3.X);
		if (weaponActorComponent != null)
		{
			AActor actor = weaponActorComponent.Actor;
			if (actor == null)
			{
				return;
			}
			actor.K2_SetActorRotation(rotator.ToUeRotator(), false);
		}
	}

	// Token: 0x06017419 RID: 95257 RVA: 0x00672E08 File Offset: 0x00671008
	private static void ScabbardLoadCallBack(UiModelBase scabbardModel, TWeaponModelTransform transformData, string weaponCase)
	{
		Singleton<UiModelUtil>.Instance.SetVisible(scabbardModel, true);
		UiModelActorComponent uiModelActorComponent = scabbardModel.CheckGetComponent<UiModelActorComponent>();
		uiModelActorComponent.SetTransformByTag(weaponCase);
		global::Vector vector = transformData.ScabbardOffset();
		global::Vector inT = global::Vector.Create(vector.X, vector.Y, vector.Z);
		global::Vector vector2 = transformData.HasScabbardValue() ? transformData.ScabbardRotationOffset() : transformData.Rotation();
		global::Rotator rotator = new global::Rotator((float)vector2.Y, (float)vector2.Z, (float)vector2.X);
		float num = transformData.Size();
		global::Vector inS = global::Vector.Create((double)num, (double)num, (double)num);
		global::Transform transform = global::Transform.Create(rotator.Quaternion(null), inT, inS);
		FHitResult fhitResult = new FHitResult();
		USkeletalMeshComponent mainMeshComponent = uiModelActorComponent.MainMeshComponent;
		if (mainMeshComponent != null)
		{
			FTransformDouble ftransformDouble = transform.ToUeTransform();
			mainMeshComponent.D_K2_SetRelativeTransform(ftransformDouble, false, ref fhitResult, false);
		}
		Singleton<UiModelUtil>.Instance.SetRenderingMaterial(scabbardModel, "WeaponRootWeaponMaterialController");
		UiModelRotateComponent uiModelRotateComponent = scabbardModel.CheckGetComponent<UiModelRotateComponent>();
		float aroundTime = transformData.RotateTime();
		uiModelRotateComponent.SetRotateParam(aroundTime, ERotateAxis.Yaw, true);
		uiModelRotateComponent.StartRotate();
		global::Vector vector3 = transformData.AxisRotate();
		rotator.Set((float)vector3.Y, (float)vector3.Z, (float)vector3.X);
		if (uiModelActorComponent == null)
		{
			return;
		}
		AActor actor = uiModelActorComponent.Actor;
		if (actor == null)
		{
			return;
		}
		actor.K2_SetActorRotation(rotator.ToUeRotator(), false);
	}

	// Token: 0x0601741A RID: 95258 RVA: 0x00672F40 File Offset: 0x00671140
	private static UniTask StartRotate(CustomPromise weaponPromise, CustomPromise scabbardPromise, UiModelBase weaponModel, TWeaponModelTransform transformData)
	{
		WeaponController.<StartRotate>d__14 <StartRotate>d__;
		<StartRotate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<StartRotate>d__.weaponPromise = weaponPromise;
		<StartRotate>d__.scabbardPromise = scabbardPromise;
		<StartRotate>d__.weaponModel = weaponModel;
		<StartRotate>d__.transformData = transformData;
		<StartRotate>d__.<>1__state = -1;
		<StartRotate>d__.<>t__builder.Start<WeaponController.<StartRotate>d__14>(ref <StartRotate>d__);
		return <StartRotate>d__.<>t__builder.Task;
	}

	// Token: 0x0601741B RID: 95259 RVA: 0x00672F9C File Offset: 0x0067119C
	public void SelectedWeaponSkinChange(int incId, int skinId, SkeletalObserverHandle weaponObserver, SkeletalObserverHandle weaponScabbardObserver, bool needMeshStreaming = false)
	{
		if (skinId == -1)
		{
			WeaponConf? weaponConfig = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId).GetWeaponConfig();
			WeaponController.LoadWeaponModelInCurrentObserver(weaponConfig.Value.Models(), weaponConfig.Value.ModelsIndex(), weaponConfig.Value.TransformId, "WeaponSkinCase", "WeaponSkinCase", weaponObserver.Model, weaponScabbardObserver.Model, needMeshStreaming, null);
			return;
		}
		WeaponSkin weaponSkinConfig = ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(skinId);
		WeaponController.LoadWeaponModelInCurrentObserver(weaponSkinConfig.Models(), weaponSkinConfig.ModelsIndex(), weaponSkinConfig.TransformId, "WeaponSkinCase", "WeaponSkinCase", weaponObserver.Model, weaponScabbardObserver.Model, needMeshStreaming, new int?(skinId));
	}

	// Token: 0x0601741C RID: 95260 RVA: 0x00673058 File Offset: 0x00671258
	public void OnSelectedWeaponChange(WeaponDataBase weaponInstance, SkeletalObserverHandle weaponObserver, SkeletalObserverHandle weaponScabbardObserver, int skinId = -1, bool needMeshStreaming = false)
	{
		if (skinId == -1)
		{
			skinId = -1;
		}
		if (weaponObserver.Model != null)
		{
			UiModelBase model = weaponObserver.Model;
			UiWeaponDataComponent uiWeaponDataComponent = model.CheckGetComponent<UiWeaponDataComponent>();
			if (uiWeaponDataComponent != null)
			{
				uiWeaponDataComponent.SetWeaponData(weaponInstance);
			}
			UiModelDataComponent uiModelDataComponent = model.CheckGetComponent<UiModelDataComponent>();
			if (uiModelDataComponent != null)
			{
				uiModelDataComponent.SetLoadingIconFollowState(needMeshStreaming);
			}
		}
		if (weaponScabbardObserver.Model != null)
		{
			weaponScabbardObserver.Model.CheckGetComponent<UiWeaponDataComponent>().SetWeaponData(weaponInstance);
		}
		WeaponController.LoadWeaponModelInCurrentObserver(weaponInstance.GetModels(skinId), weaponInstance.GetModelsIndex(skinId), weaponInstance.GetTransformId(skinId), "WeaponCase", "WeaponScabbardCase", weaponObserver.Model, weaponScabbardObserver.Model, needMeshStreaming, (skinId != -1) ? new int?(skinId) : null);
	}

	// Token: 0x0601741D RID: 95261 RVA: 0x00673104 File Offset: 0x00671304
	public void PlayWeaponRenderingMaterial(string materialId, SkeletalObserverHandle weaponObserver, SkeletalObserverHandle weaponScabbardObserver = null)
	{
		Singleton<UiModelUtil>.Instance.SetRenderingMaterial(weaponObserver.Model, materialId);
		if (weaponScabbardObserver != null)
		{
			Singleton<UiModelUtil>.Instance.SetRenderingMaterial(weaponScabbardObserver.Model, materialId);
		}
	}

	// Token: 0x0601741E RID: 95262 RVA: 0x0067312D File Offset: 0x0067132D
	public void ApplyWeaponLevelMaterial(USkinnedMeshComponent mesh, PD_WeaponLevelMaterialDatas_C data, int level = 0)
	{
		BP_CharacterRenderingFunctionLibrary_C.ApplyWeaponLevelMaterial(mesh, data, level, mesh);
	}

	// Token: 0x0601741F RID: 95263 RVA: 0x0067313C File Offset: 0x0067133C
	public UniTask LoadCharacterRenderingFunctionLibraryAsync()
	{
		WeaponController.<LoadCharacterRenderingFunctionLibraryAsync>d__19 <LoadCharacterRenderingFunctionLibraryAsync>d__;
		<LoadCharacterRenderingFunctionLibraryAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadCharacterRenderingFunctionLibraryAsync>d__.<>1__state = -1;
		<LoadCharacterRenderingFunctionLibraryAsync>d__.<>t__builder.Start<WeaponController.<LoadCharacterRenderingFunctionLibraryAsync>d__19>(ref <LoadCharacterRenderingFunctionLibraryAsync>d__);
		return <LoadCharacterRenderingFunctionLibraryAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06017420 RID: 95264 RVA: 0x00673178 File Offset: 0x00671378
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<PD_WeaponLevelMaterialDatas_C> LoadWeaponLevelMaterialDataAsync(string daPath)
	{
		WeaponController.<LoadWeaponLevelMaterialDataAsync>d__20 <LoadWeaponLevelMaterialDataAsync>d__;
		<LoadWeaponLevelMaterialDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<PD_WeaponLevelMaterialDatas_C>.Create();
		<LoadWeaponLevelMaterialDataAsync>d__.daPath = daPath;
		<LoadWeaponLevelMaterialDataAsync>d__.<>1__state = -1;
		<LoadWeaponLevelMaterialDataAsync>d__.<>t__builder.Start<WeaponController.<LoadWeaponLevelMaterialDataAsync>d__20>(ref <LoadWeaponLevelMaterialDataAsync>d__);
		return <LoadWeaponLevelMaterialDataAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06017421 RID: 95265 RVA: 0x006731BC File Offset: 0x006713BC
	public void RoleFadeIn(TsUiSceneRoleActor roleActor, string curveId = "RoleFadeInCurve")
	{
		UiModelFadeComponent uiModelFadeComponent = roleActor.Model.CheckGetComponent<UiModelFadeComponent>();
		int? intConfig = ConfigCommonParamById.GetIntConfig("RoleFadeInDuration");
		if (uiModelFadeComponent == null)
		{
			return;
		}
		uiModelFadeComponent.Fade(1f, 0f, (float)intConfig.Value, curveId, null);
	}

	// Token: 0x06017422 RID: 95266 RVA: 0x00673200 File Offset: 0x00671400
	public void RoleFadeOut(TsUiSceneRoleActor roleActor, string curveId = "RoleFadeOutCurve")
	{
		UiModelFadeComponent uiModelFadeComponent = roleActor.Model.CheckGetComponent<UiModelFadeComponent>();
		int? intConfig = ConfigCommonParamById.GetIntConfig("RoleFadeOutDuration");
		if (uiModelFadeComponent == null)
		{
			return;
		}
		uiModelFadeComponent.Fade(0f, 1f, (float)intConfig.Value, curveId, null);
	}
}
