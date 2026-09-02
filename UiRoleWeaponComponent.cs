using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

// Token: 0x02002CB6 RID: 11446
[NullableContext(1)]
[Nullable(0)]
public class UiRoleWeaponComponent : UiModelComponentBase, IUiModelVisible, IUiModelSetDitherEffect
{
	// Token: 0x06016F83 RID: 94083 RVA: 0x0065E06C File Offset: 0x0065C26C
	protected override void OnInit()
	{
		this.RoleDataComponent = base.Owner.CheckGetComponent<UiRoleDataComponent>();
		this.ModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
		this.ActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
		this.AnsControllerComponent = base.Owner.CheckGetComponent<UiModelAnsControllerComponent>();
	}

	// Token: 0x06016F84 RID: 94084 RVA: 0x0065E0C0 File Offset: 0x0065C2C0
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnRoleMeshLoadComplete));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelSetMorphTypeComplete, new Action(this.OnRoleMeshLoadComplete));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelRoleDataIdChange, new Action(this.OnRoleIdChange));
		UiModelAnsControllerComponent ansControllerComponent = this.AnsControllerComponent;
		if (ansControllerComponent == null)
		{
			return;
		}
		ansControllerComponent.RegisterAnsTrigger("UiWeaponAnsContext", new Action<UiAnsContextBase>(this.OnAnsBegin), new Action<UiAnsContextBase>(this.OnAnsEnd));
	}

	// Token: 0x06016F85 RID: 94085 RVA: 0x0065E160 File Offset: 0x0065C360
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnRoleMeshLoadComplete));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelSetMorphTypeComplete, new Action(this.OnRoleMeshLoadComplete));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelRoleDataIdChange, new Action(this.OnRoleIdChange));
		foreach (SkeletalObserverHandle skeletalObserverHandle in this.WeaponHandleList)
		{
			SkeletalObserverManager.DestroySkeletalObserver(skeletalObserverHandle);
		}
	}

	// Token: 0x06016F86 RID: 94086 RVA: 0x0065E218 File Offset: 0x0065C418
	public void OnModelDitherEffectChange(float value)
	{
		this.SetDitherEffect(value);
	}

	// Token: 0x06016F87 RID: 94087 RVA: 0x0065E224 File Offset: 0x0065C424
	public void OnModelVisibleChange(bool visible)
	{
		for (int i = 0; i < this.WeaponStatesOnRole.Count; i++)
		{
			if (this.WeaponStatesOnRole[i] && visible)
			{
				this.ShowWeaponByIndex(i, false);
			}
			else
			{
				this.HideWeaponByIndex(i, false);
			}
		}
	}

	// Token: 0x06016F88 RID: 94088 RVA: 0x0065E26C File Offset: 0x0065C46C
	private void TrimWeaponHandles(int targetCount)
	{
		for (int i = this.WeaponHandleList.Count - 1; i >= targetCount; i--)
		{
			SkeletalObserverManager.DestroySkeletalObserver(this.WeaponHandleList[i]);
			this.WeaponHandleList.RemoveAt(i);
			this.WeaponStateList.RemoveAt(i);
			this.WeaponStatesOnRole.RemoveAt(i);
		}
	}

	// Token: 0x06016F89 RID: 94089 RVA: 0x0065E2C8 File Offset: 0x0065C4C8
	public void Refresh()
	{
		if (this.WeaponData == null)
		{
			return;
		}
		int[] models = this.WeaponData.GetModels(this.WeaponSkinId);
		this.WeaponCount = models.Length;
		this.TrimWeaponHandles(this.WeaponCount);
		for (int i = this.WeaponHandleList.Count; i < this.WeaponCount; i++)
		{
			SkeletalObserverHandle item = SkeletalObserverManager.NewSkeletalObserver(EUiModelUseWay.WeaponOnRole);
			this.WeaponHandleList.Add(item);
			this.WeaponStateList.Add(EWeaponState.None);
			this.WeaponStatesOnRole.Add(false);
			this.HideWeaponByIndex(i, false);
		}
		for (int j = 0; j < this.WeaponCount; j++)
		{
			UiModelBase model = this.WeaponHandleList[j].Model;
			UiWeaponDataComponent uiWeaponDataComponent = model.CheckGetComponent<UiWeaponDataComponent>();
			if (uiWeaponDataComponent != null)
			{
				uiWeaponDataComponent.SetWeaponData(this.WeaponData);
			}
			Singleton<UiModelUtil>.Instance.SetWeaponLevelMaterialBreachLevel(model, this.WeaponData.GetBreachLevel());
			UiModelLoadComponent uiModelLoadComponent = model.CheckGetComponent<UiModelLoadComponent>();
			int weaponIndex = j;
			if (uiModelLoadComponent != null)
			{
				uiModelLoadComponent.LoadModelByModelId(models[j], false, delegate
				{
					this.SyncWeaponVisibleWhenLoaded(weaponIndex);
				}, null);
			}
		}
	}

	// Token: 0x06016F8A RID: 94090 RVA: 0x0065E3E8 File Offset: 0x0065C5E8
	private void SyncWeaponVisibleWhenLoaded(int weaponIndex)
	{
		if (weaponIndex < 0 || weaponIndex >= this.WeaponHandleList.Count)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Weapon;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "显示武器索引错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("weaponIndex", weaponIndex);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		EWeaponState eweaponState = this.WeaponStateList[weaponIndex];
		UiModelBase model = this.WeaponHandleList[weaponIndex].Model;
		Singleton<UiModelUtil>.Instance.SetVisible(model, eweaponState == EWeaponState.Showing);
	}

	// Token: 0x06016F8B RID: 94091 RVA: 0x0065E464 File Offset: 0x0065C664
	public void OnRoleIdChange()
	{
		this.RefreshWeaponCase();
		this.HideAllWeapon(false);
		this.ResetWeaponStatesOnRole();
		int roleDataId = this.RoleDataComponent.RoleDataId;
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleDataId, true);
		int skinIdByRoleId = ModelBase<WeaponSkinModel>.Instance.GetSkinIdByRoleId(roleDataId);
		if (roleDataById != null)
		{
			if (roleDataById.IsTrialRole())
			{
				WeaponTrialData weaponData = ModelBase<RoleModel>.Instance.GetRoleRobotData(roleDataId).GetWeaponData();
				this.SetWeaponByWeaponData(weaponData, skinIdByRoleId);
				return;
			}
			WeaponDataBase weaponDataByRoleDataId = ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(roleDataId, true);
			this.SetWeaponByWeaponData(weaponDataByRoleDataId, skinIdByRoleId);
		}
	}

	// Token: 0x06016F8C RID: 94092 RVA: 0x0065E4E5 File Offset: 0x0065C6E5
	public void OnRoleMeshLoadComplete()
	{
		this.AttachWeaponToRole();
	}

	// Token: 0x06016F8D RID: 94093 RVA: 0x0065E4F0 File Offset: 0x0065C6F0
	public void ShowAllWeapon(bool addMaterialController = false)
	{
		for (int i = 0; i < this.WeaponHandleList.Count; i++)
		{
			this.ShowWeaponByIndex(i, addMaterialController);
		}
	}

	// Token: 0x06016F8E RID: 94094 RVA: 0x0065E51C File Offset: 0x0065C71C
	public void HideAllWeapon(bool playEffect = false)
	{
		for (int i = 0; i < this.WeaponHandleList.Count; i++)
		{
			this.HideWeaponByIndex(i, playEffect);
		}
	}

	// Token: 0x06016F8F RID: 94095 RVA: 0x0065E548 File Offset: 0x0065C748
	public void ResetWeaponStatesOnRole()
	{
		for (int i = 0; i < this.WeaponStatesOnRole.Count; i++)
		{
			this.WeaponStatesOnRole[i] = false;
		}
	}

	// Token: 0x06016F90 RID: 94096 RVA: 0x0065E578 File Offset: 0x0065C778
	public void ShowWeaponByIndex(int index, bool addMaterialController = false)
	{
		if (index < 0 || index >= this.WeaponHandleList.Count)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Weapon;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "显示武器索引错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", index);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		UiModelBase model = this.WeaponHandleList[index].Model;
		UiModelDataComponent uiModelDataComponent = model.CheckGetComponent<UiModelDataComponent>();
		this.WeaponStateList[index] = EWeaponState.Showing;
		if (((uiModelDataComponent != null) ? new bool?(uiModelDataComponent.GetVisible()) : null).GetValueOrDefault())
		{
			return;
		}
		if (uiModelDataComponent != null)
		{
			uiModelDataComponent.SetVisible(true);
		}
		if (addMaterialController)
		{
			Singleton<UiModelUtil>.Instance.SetRenderingMaterial(model, "ChangeWeaponMaterialController");
		}
	}

	// Token: 0x06016F91 RID: 94097 RVA: 0x0065E630 File Offset: 0x0065C830
	public void HideWeaponByIndex(int index, bool playEffect = false)
	{
		if (index < 0 || index >= this.WeaponHandleList.Count)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Weapon;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "隐藏武器索引错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", index);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		UiModelBase model = this.WeaponHandleList[index].Model;
		UiModelDataComponent uiModelDataComponent = model.CheckGetComponent<UiModelDataComponent>();
		this.WeaponStateList[index] = EWeaponState.Hidden;
		if (!((uiModelDataComponent != null) ? new bool?(uiModelDataComponent.GetVisible()) : null).GetValueOrDefault())
		{
			return;
		}
		if (uiModelDataComponent != null)
		{
			uiModelDataComponent.SetVisible(false);
		}
		if (playEffect)
		{
			Singleton<UiModelUtil>.Instance.PlayEffectOnRoot(model, "ShowHideWeaponEffect");
		}
	}

	// Token: 0x06016F92 RID: 94098 RVA: 0x0065E6E8 File Offset: 0x0065C8E8
	public void RefreshWeaponCase()
	{
		int roleConfigId = this.RoleDataComponent.RoleConfigId;
		SModelConfig modelConfig = ModelUtil.GetModelConfig(ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleConfigId).Value.UiMeshId);
		if (modelConfig == null)
		{
			return;
		}
		TArray<string> battleSockets = modelConfig.BattleSockets;
		this.WeaponSocketNames.Clear();
		for (int i = 0; i < battleSockets.Num(); i++)
		{
			string item = battleSockets.Get(i);
			this.WeaponSocketNames.Add(item);
		}
	}

	// Token: 0x06016F93 RID: 94099 RVA: 0x0065E76C File Offset: 0x0065C96C
	public void RefreshWeaponDa()
	{
		if (this.WeaponData == null)
		{
			return;
		}
		int breachLevel = this.WeaponData.GetBreachLevel();
		foreach (SkeletalObserverHandle skeletalObserverHandle in this.WeaponHandleList)
		{
			if (skeletalObserverHandle.Model != null)
			{
				Singleton<UiModelUtil>.Instance.SetWeaponLevelMaterialBreachLevel(skeletalObserverHandle.Model, breachLevel);
				Singleton<UiModelUtil>.Instance.TryApplyWeaponLevelMaterial(skeletalObserverHandle.Model);
			}
		}
	}

	// Token: 0x06016F94 RID: 94100 RVA: 0x0065E7F8 File Offset: 0x0065C9F8
	public void AttachWeaponToRole()
	{
		if (this.ModelDataComponent.GetModelLoadState() != EUiModelLoadState.LoadComplete)
		{
			return;
		}
		USkeletalMeshComponent mainMeshComponent = this.ActorComponent.MainMeshComponent;
		for (int i = 0; i < this.WeaponCount; i++)
		{
			SkeletalObserverHandle skeletalObserverHandle = this.WeaponHandleList[i];
			FName? dynamicFName = FNameUtil.GetDynamicFName(this.WeaponSocketNames[i]);
			UiModelBase model = skeletalObserverHandle.Model;
			UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
			if (uiModelActorComponent != null)
			{
				AActor actor = uiModelActorComponent.Actor;
				if (actor != null)
				{
					actor.K2_AttachToComponent(mainMeshComponent, dynamicFName.Value, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true);
				}
			}
			FHitResult fhitResult = new FHitResult();
			if (uiModelActorComponent != null)
			{
				AActor actor2 = uiModelActorComponent.Actor;
				if (actor2 != null)
				{
					actor2.D_K2_SetActorRelativeTransform(Singleton<MathUtils>.Instance.DefaultTransformDouble, false, ref fhitResult, false);
				}
			}
		}
	}

	// Token: 0x06016F95 RID: 94101 RVA: 0x0065E8B4 File Offset: 0x0065CAB4
	private void HangWeaponByIndex(int index, FName? socketName)
	{
		if (index < 0 || index >= this.WeaponHandleList.Count)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Weapon;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "挂载武器索引错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", index);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		UiModelBase model = this.WeaponHandleList[index].Model;
		UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
		if (uiModelActorComponent == null)
		{
			return;
		}
		AActor actor = uiModelActorComponent.Actor;
		if (actor == null)
		{
			return;
		}
		actor.K2_AttachToComponent(this.ActorComponent.MainMeshComponent, socketName ?? FNameUtil.GetDynamicFName(this.WeaponSocketNames[index]).Value, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true);
	}

	// Token: 0x06016F96 RID: 94102 RVA: 0x0065E96E File Offset: 0x0065CB6E
	[NullableContext(2)]
	public void SetWeaponByWeaponData(WeaponDataBase weaponData, int weaponSkinId)
	{
		if (weaponData == null)
		{
			return;
		}
		this.WeaponData = weaponData;
		this.WeaponSkinId = weaponSkinId;
		this.Refresh();
	}

	// Token: 0x06016F97 RID: 94103 RVA: 0x0065E988 File Offset: 0x0065CB88
	public void ReplaceWeaponModel(int[] modelIds, [Nullable(2)] Action loadFinishCallBack = null)
	{
		UiRoleWeaponComponent.<>c__DisplayClass31_0 CS$<>8__locals1 = new UiRoleWeaponComponent.<>c__DisplayClass31_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.loadFinishCallBack = loadFinishCallBack;
		this.WeaponCount = modelIds.Length;
		this.TrimWeaponHandles(this.WeaponCount);
		for (int i = this.WeaponHandleList.Count; i < this.WeaponCount; i++)
		{
			SkeletalObserverHandle item = SkeletalObserverManager.NewSkeletalObserver(EUiModelUseWay.WeaponOnRole);
			this.WeaponHandleList.Add(item);
			this.WeaponStateList.Add(EWeaponState.None);
			this.WeaponStatesOnRole.Add(false);
			this.HideWeaponByIndex(i, false);
		}
		CS$<>8__locals1.finishCount = 0;
		WeaponDataBase weaponData = this.WeaponData;
		int breachLevel = (weaponData != null) ? weaponData.GetBreachLevel() : 0;
		for (int j = 0; j < this.WeaponCount; j++)
		{
			UiModelBase model = this.WeaponHandleList[j].Model;
			UiModelDataComponent uiModelDataComponent = model.CheckGetComponent<UiModelDataComponent>();
			int? num = (uiModelDataComponent != null) ? new int?(uiModelDataComponent.ModelConfigId) : null;
			int num2 = modelIds[j];
			if (!(num.GetValueOrDefault() == num2 & num != null))
			{
				Singleton<UiModelUtil>.Instance.SetWeaponLevelMaterialBreachLevel(model, breachLevel);
				UiModelLoadComponent uiModelLoadComponent = model.CheckGetComponent<UiModelLoadComponent>();
				if (uiModelLoadComponent != null)
				{
					uiModelLoadComponent.LoadModelByModelId(modelIds[j], false, new Action(CS$<>8__locals1.<ReplaceWeaponModel>g__CallBackCache|0), null);
				}
			}
		}
	}

	// Token: 0x06016F98 RID: 94104 RVA: 0x0065EAC4 File Offset: 0x0065CCC4
	public bool HasWeapon()
	{
		return this.WeaponData != null;
	}

	// Token: 0x06016F99 RID: 94105 RVA: 0x0065EAD0 File Offset: 0x0065CCD0
	public void SetWeaponTransformByIndex(int index, FTransform transform)
	{
		if (index < 0 || index >= this.WeaponHandleList.Count)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Weapon;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "设置武器偏移索引错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", index);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		UiModelBase model = this.WeaponHandleList[index].Model;
		object obj = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
		FHitResult fhitResult = new FHitResult();
		object obj2 = obj;
		if (obj2 == null)
		{
			return;
		}
		USkeletalMeshComponent mainMeshComponent = obj2.MainMeshComponent;
		if (mainMeshComponent == null)
		{
			return;
		}
		mainMeshComponent.K2_SetRelativeTransform(transform, false, ref fhitResult, false);
	}

	// Token: 0x06016F9A RID: 94106 RVA: 0x0065EB5C File Offset: 0x0065CD5C
	public void SetDitherEffect(float ditherRate)
	{
		foreach (SkeletalObserverHandle skeletalObserverHandle in this.WeaponHandleList)
		{
			UiModelBase model = skeletalObserverHandle.Model;
			UiModelDataComponent uiModelDataComponent = (model != null) ? model.CheckGetComponent<UiModelDataComponent>() : null;
			if (uiModelDataComponent != null)
			{
				uiModelDataComponent.SetDitherEffect(ditherRate);
			}
		}
	}

	// Token: 0x06016F9B RID: 94107 RVA: 0x0065EBC4 File Offset: 0x0065CDC4
	public int GetWeaponCount()
	{
		return this.WeaponCount;
	}

	// Token: 0x06016F9C RID: 94108 RVA: 0x0065EBCC File Offset: 0x0065CDCC
	public void OnAnsBegin(UiAnsContextBase ansContext)
	{
		UiWeaponAnsContext uiWeaponAnsContext = ansContext as UiWeaponAnsContext;
		int index = uiWeaponAnsContext.Index;
		if (index < 0 || index >= this.WeaponStatesOnRole.Count)
		{
			return;
		}
		this.WeaponStatesOnRole[index] = true;
		this.ShowWeaponByIndex(index, uiWeaponAnsContext.ShowMaterialController);
		if (!FNameUtil.IsEmpty(new FName?(uiWeaponAnsContext.HangSocketName)))
		{
			this.HangWeaponByIndex(index, new FName?(uiWeaponAnsContext.HangSocketName));
		}
		if (uiWeaponAnsContext.Transform != null)
		{
			this.SetWeaponTransformByIndex(index, uiWeaponAnsContext.Transform.Value);
		}
	}

	// Token: 0x06016F9D RID: 94109 RVA: 0x0065EC60 File Offset: 0x0065CE60
	public void OnAnsEnd(UiAnsContextBase ansContext)
	{
		UiWeaponAnsContext uiWeaponAnsContext = ansContext as UiWeaponAnsContext;
		int index = uiWeaponAnsContext.Index;
		if (index < 0 || index >= this.WeaponStatesOnRole.Count)
		{
			return;
		}
		this.WeaponStatesOnRole[index] = false;
		this.HideWeaponByIndex(index, uiWeaponAnsContext.HideEffect);
		if (!FNameUtil.IsEmpty(new FName?(uiWeaponAnsContext.HangSocketName)))
		{
			this.HangWeaponByIndex(index, null);
		}
	}

	// Token: 0x0400B125 RID: 45349
	[Nullable(2)]
	private UiModelDataComponent ModelDataComponent;

	// Token: 0x0400B126 RID: 45350
	[Nullable(2)]
	private UiRoleDataComponent RoleDataComponent;

	// Token: 0x0400B127 RID: 45351
	[Nullable(2)]
	private UiModelActorComponent ActorComponent;

	// Token: 0x0400B128 RID: 45352
	[Nullable(2)]
	private UiModelAnsControllerComponent AnsControllerComponent;

	// Token: 0x0400B129 RID: 45353
	[Nullable(2)]
	private WeaponDataBase WeaponData;

	// Token: 0x0400B12A RID: 45354
	private int WeaponSkinId = -1;

	// Token: 0x0400B12B RID: 45355
	private readonly List<SkeletalObserverHandle> WeaponHandleList = new List<SkeletalObserverHandle>();

	// Token: 0x0400B12C RID: 45356
	private int WeaponCount;

	// Token: 0x0400B12D RID: 45357
	private readonly List<string> WeaponSocketNames = new List<string>();

	// Token: 0x0400B12E RID: 45358
	private readonly List<EWeaponState> WeaponStateList = new List<EWeaponState>();

	// Token: 0x0400B12F RID: 45359
	private readonly List<bool> WeaponStatesOnRole = new List<bool>();
}
