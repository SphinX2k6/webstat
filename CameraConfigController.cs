using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02000E08 RID: 3592
[NullableContext(1)]
[Nullable(0)]
[GeneratePropertyAccessMethod(true)]
public class CameraConfigController : CameraControllerBase<ENullEnum>
{
	// Token: 0x06005457 RID: 21591 RVA: 0x000CC0F4 File Offset: 0x000CA2F4
	public CameraConfig GetDefaultConfig()
	{
		return this.DefaultConfig;
	}

	// Token: 0x170005B1 RID: 1457
	// (get) Token: 0x06005458 RID: 21592 RVA: 0x000CC0FC File Offset: 0x000CA2FC
	// (set) Token: 0x06005459 RID: 21593 RVA: 0x000CC104 File Offset: 0x000CA304
	[Nullable(2)]
	protected EntityHandle SelfCharacterEntity
	{
		[NullableContext(2)]
		get
		{
			return this.SelfCharacterEntityInternal;
		}
		[NullableContext(2)]
		set
		{
			if (this.SelfCharacterEntityInternal == value)
			{
				return;
			}
			EntityHandle selfCharacterEntityInternal = this.SelfCharacterEntityInternal;
			if (selfCharacterEntityInternal != null && selfCharacterEntityInternal.Valid)
			{
				BaseTagComponent component = this.SelfCharacterEntityInternal.Entity.GetComponent<BaseTagComponent>();
				if (component != null && component.Valid)
				{
					foreach (CameraConfig cameraConfig in this.SubConfigs.Values)
					{
						component.RemoveTagAddOrRemoveListener(cameraConfig.Tag.Value.TagId(), new BaseTagComponent.TTagSwitchedCallback(this.OnSubTagChanged));
					}
				}
			}
			if (value != null && value.Valid)
			{
				BaseTagComponent component2 = value.Entity.GetComponent<BaseTagComponent>();
				if (component2 != null && component2.Valid)
				{
					foreach (CameraConfig cameraConfig2 in this.SubConfigs.Values)
					{
						component2.AddTagAddOrRemoveListener(cameraConfig2.Tag.Value.TagId(), new BaseTagComponent.TTagSwitchedCallback(this.OnSubTagChanged), null);
					}
				}
			}
			this.SelfCharacterEntityInternal = value;
			this.UpdateTargetConfig();
		}
	}

	// Token: 0x170005B2 RID: 1458
	// (get) Token: 0x0600545A RID: 21594 RVA: 0x000CC248 File Offset: 0x000CA448
	// (set) Token: 0x0600545B RID: 21595 RVA: 0x000CC250 File Offset: 0x000CA450
	[Nullable(2)]
	protected EntityHandle FloatCharacterEntity
	{
		[NullableContext(2)]
		get
		{
			return this.FloatCharacterEntityInternal;
		}
		[NullableContext(2)]
		set
		{
			if (this.FloatCharacterEntityInternal == value)
			{
				return;
			}
			EntityHandle floatCharacterEntityInternal = this.FloatCharacterEntityInternal;
			if (floatCharacterEntityInternal != null && floatCharacterEntityInternal.Valid)
			{
				BaseTagComponent component = this.FloatCharacterEntityInternal.Entity.GetComponent<BaseTagComponent>();
				if (component != null && component.Valid)
				{
					foreach (CameraConfig cameraConfig in this.AccompanyConfigs.Values)
					{
						component.RemoveTagAddOrRemoveListener(cameraConfig.Tag.Value.TagId(), new BaseTagComponent.TTagSwitchedCallback(this.OnAccompanyTagChanged));
					}
				}
			}
			if (value != null && value.Valid)
			{
				BaseTagComponent component2 = value.Entity.GetComponent<BaseTagComponent>();
				if (component2 != null && component2.Valid)
				{
					foreach (CameraConfig cameraConfig2 in this.AccompanyConfigs.Values)
					{
						component2.AddTagAddOrRemoveListener(cameraConfig2.Tag.Value.TagId(), new BaseTagComponent.TTagSwitchedCallback(this.OnAccompanyTagChanged), null);
					}
				}
			}
			this.FloatCharacterEntityInternal = value;
			this.UpdateAccompanyTargetConfig();
		}
	}

	// Token: 0x0600545C RID: 21596 RVA: 0x000CC394 File Offset: 0x000CA594
	private void OnSubTagChanged(int gameplayTagId, bool tagExist)
	{
		if (tagExist)
		{
			if (this.CurrentSubTagSet.Contains(gameplayTagId))
			{
				return;
			}
			CameraConfig cameraConfig;
			if (!this.SubConfigs.TryGetValue(gameplayTagId, out cameraConfig))
			{
				return;
			}
			this.CurrentConfigList.Insert(cameraConfig);
			this.CurrentSubTagSet.Add(gameplayTagId);
			this.UpdateFadeInConfig(cameraConfig);
			return;
		}
		else
		{
			CameraConfig cameraConfig2;
			if (!this.SubConfigs.TryGetValue(gameplayTagId, out cameraConfig2))
			{
				return;
			}
			if (!this.CurrentSubTagSet.Contains(gameplayTagId))
			{
				return;
			}
			if (this.Camera.ContainsTag(gameplayTagId, false))
			{
				return;
			}
			this.CurrentConfigList.Remove(cameraConfig2);
			this.CurrentSubTagSet.Remove(gameplayTagId);
			this.UpdateFadeOutConfig(cameraConfig2);
			return;
		}
	}

	// Token: 0x0600545D RID: 21597 RVA: 0x000CC438 File Offset: 0x000CA638
	private void OnAccompanyTagChanged(int gameplayTagId, bool tagExist)
	{
		if (tagExist)
		{
			if (this.CurrentAccompanyTagSet.Contains(gameplayTagId))
			{
				return;
			}
			CameraConfig cameraConfig;
			if (!this.AccompanyConfigs.TryGetValue(gameplayTagId, out cameraConfig))
			{
				return;
			}
			this.CurrentConfigList.Insert(cameraConfig);
			this.CurrentAccompanyTagSet.Add(gameplayTagId);
			this.UpdateFadeInConfig(cameraConfig);
			return;
		}
		else
		{
			CameraConfig cameraConfig2;
			if (!this.AccompanyConfigs.TryGetValue(gameplayTagId, out cameraConfig2))
			{
				return;
			}
			if (!this.CurrentAccompanyTagSet.Contains(gameplayTagId))
			{
				return;
			}
			if (this.Camera.AccompanyContainsTag(gameplayTagId))
			{
				return;
			}
			this.CurrentConfigList.Remove(cameraConfig2);
			this.CurrentAccompanyTagSet.Remove(gameplayTagId);
			this.UpdateFadeOutConfig(cameraConfig2);
			return;
		}
	}

	// Token: 0x0600545E RID: 21598 RVA: 0x000CC4D8 File Offset: 0x000CA6D8
	protected void UpdateFocusTargetAndSocket([Nullable(2)] Entity newTarget, string newSocket)
	{
		bool flag = false;
		if (this.FocusTarget == newTarget)
		{
			if (this.FocusTargetSocketName != newSocket)
			{
				flag = true;
			}
		}
		else
		{
			Entity focusTarget = this.FocusTarget;
			if (focusTarget != null && focusTarget.Valid)
			{
				BaseTagComponent component = this.FocusTarget.GetComponent<BaseTagComponent>();
				if (component != null && component.Valid)
				{
					foreach (CameraConfig cameraConfig in this.FocusConfigs.Values)
					{
						component.RemoveTagAddOrRemoveListener(cameraConfig.Tag.Value.TagId(), new BaseTagComponent.TTagSwitchedCallback(this.OnFocusTagChanged));
					}
				}
			}
			if (newTarget != null && newTarget.Valid)
			{
				BaseTagComponent component2 = newTarget.GetComponent<BaseTagComponent>();
				if (component2 != null && component2.Valid)
				{
					foreach (CameraConfig cameraConfig2 in this.FocusConfigs.Values)
					{
						component2.AddTagAddOrRemoveListener(cameraConfig2.Tag.Value.TagId(), new BaseTagComponent.TTagSwitchedCallback(this.OnFocusTagChanged), null);
					}
				}
			}
			flag = true;
		}
		this.FocusTarget = newTarget;
		this.FocusTargetSocketName = newSocket;
		if (flag)
		{
			this.UpdateFocusTargetConfig();
		}
	}

	// Token: 0x0600545F RID: 21599 RVA: 0x000CC638 File Offset: 0x000CA838
	private void OnFocusTagChanged(int gameplayTagId, bool tagExist)
	{
		if (tagExist)
		{
			if (this.CurrentFocusTagSet.Contains(gameplayTagId))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "Got config before Tag";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Tag", GameplayTagUtils.GetNameByTagId(gameplayTagId));
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			CameraConfig cameraConfig;
			if (!this.FocusConfigs.TryGetValue(gameplayTagId, out cameraConfig) || cameraConfig.LockOnParts.Length != 0)
			{
				return;
			}
			this.CurrentConfigList.Insert(cameraConfig);
			this.CurrentFocusTagSet.Add(gameplayTagId);
			this.UpdateFadeInConfig(cameraConfig);
			return;
		}
		else
		{
			if (!this.CurrentFocusTagSet.Contains(gameplayTagId))
			{
				return;
			}
			CameraConfig cameraConfig2;
			if (!this.FocusConfigs.TryGetValue(gameplayTagId, out cameraConfig2))
			{
				return;
			}
			this.CurrentConfigList.Remove(cameraConfig2);
			this.UpdateFadeOutConfig(cameraConfig2);
			this.CurrentFocusTagSet.Remove(gameplayTagId);
			return;
		}
	}

	// Token: 0x06005460 RID: 21600 RVA: 0x000CC700 File Offset: 0x000CA900
	protected override void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		if (this.AdjustCameraTagMap.Count <= 0)
		{
			return;
		}
		foreach (KeyValuePair<EAdjustPlayerCamera, int?> keyValuePair in this.AdjustCameraTagMap)
		{
			EAdjustPlayerCamera eadjustPlayerCamera;
			int? num;
			keyValuePair.Deconstruct(out eadjustPlayerCamera, out num);
			EAdjustPlayerCamera adjustPlayerCamera = eadjustPlayerCamera;
			int? extraTagId = num;
			this.EnableHookConfig(adjustPlayerCamera, extraTagId);
		}
	}

	// Token: 0x06005461 RID: 21601 RVA: 0x000CC774 File Offset: 0x000CA974
	private void OnCameraCharacterChanged([Nullable(2)] EntityHandle newEntity, string cameraName)
	{
		CameraModelInstance cameraModel = base.CameraModel;
		if (cameraName != ((cameraModel != null) ? cameraModel.CameraName : null))
		{
			return;
		}
		this.SelfCharacterEntity = newEntity;
	}

	// Token: 0x06005462 RID: 21602 RVA: 0x000CC798 File Offset: 0x000CA998
	private void OnFollowShooterPossessed(EntityHandle follower)
	{
		this.FloatCharacterEntity = follower;
	}

	// Token: 0x06005463 RID: 21603 RVA: 0x000CC7A1 File Offset: 0x000CA9A1
	private void OnFollowShooterUnPossessed()
	{
		this.FloatCharacterEntity = null;
	}

	// Token: 0x170005B3 RID: 1459
	// (get) Token: 0x06005464 RID: 21604 RVA: 0x000CC7AA File Offset: 0x000CA9AA
	[Nullable(2)]
	private string PlatformCheckKey { [NullableContext(2)] get; }

	// Token: 0x06005465 RID: 21605 RVA: 0x000CC7B4 File Offset: 0x000CA9B4
	public CameraConfigController(FightCameraLogicComponent camera) : base(camera)
	{
		this.CurrentConfigList = new RbTree<CameraConfig>(this.CameraConfigCompare);
		string text;
		if (Singleton<Info>.Instance.IsMobilePlatform())
		{
			text = "MobileValid";
		}
		else
		{
			text = "PcValid";
		}
		this.PlatformCheckKey = text;
		this.LoadConfig();
	}

	// Token: 0x06005466 RID: 21606 RVA: 0x000CC8DA File Offset: 0x000CAADA
	public override string Name()
	{
		return "ConfigController";
	}

	// Token: 0x06005467 RID: 21607 RVA: 0x000CC8E4 File Offset: 0x000CAAE4
	public override void OnStart()
	{
		base.OnStart();
		Singleton<EventSystem>.Instance.Add<EntityHandle, string>(EEventName.CameraCharacterChanged, new Action<EntityHandle, string>(this.OnCameraCharacterChanged));
		Singleton<EventSystem>.Instance.Add<EntityHandle>(EEventName.OnPlayerFollowerPossessed, new Action<EntityHandle>(this.OnFollowShooterPossessed));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPlayerFollowerUnPossessed, new Action(this.OnFollowShooterUnPossessed));
	}

	// Token: 0x06005468 RID: 21608 RVA: 0x000CC94B File Offset: 0x000CAB4B
	protected override void UpdateInternal(float deltaTime)
	{
		this.UpdateConfig();
	}

	// Token: 0x06005469 RID: 21609 RVA: 0x000CC954 File Offset: 0x000CAB54
	public void EnableHookConfig(EAdjustPlayerCamera adjustPlayerCamera, int? extraTagId = null)
	{
		int tagIdByName = GameplayTagUtils.GetTagIdByName(adjustPlayerCamera.ToEnumString());
		foreach (EntityHandle entityHandle in ModelBase<SceneTeamModel>.Instance.GetTeamEntities(true))
		{
			if (entityHandle.Valid)
			{
				BaseTagComponent component = entityHandle.Entity.GetComponent<BaseTagComponent>();
				if (component != null)
				{
					if (extraTagId != null && !component.HasTag(extraTagId.Value))
					{
						component.AddTag(new int?(extraTagId.Value));
					}
					if (component.HasTag(tagIdByName))
					{
						component.RemoveTag(new int?(tagIdByName));
					}
					component.AddTag(new int?(tagIdByName));
					this.AdjustCameraEntityHandleSet.Add(entityHandle);
				}
			}
		}
		this.AdjustCameraTagMap[adjustPlayerCamera] = extraTagId;
	}

	// Token: 0x0600546A RID: 21610 RVA: 0x000CCA34 File Offset: 0x000CAC34
	public void DisableHookConfig(float? fadeOutTime = null)
	{
		if (fadeOutTime != null)
		{
			foreach (EAdjustPlayerCamera adjustPlayerCamera in EAdjustPlayerCameraExtensions.GetValues())
			{
				this.SetHookConfigFadeOutTime(adjustPlayerCamera, fadeOutTime.Value);
			}
		}
		foreach (EntityHandle entityHandle in this.AdjustCameraEntityHandleSet)
		{
			WorldEntity entity = entityHandle.Entity;
			BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent != null)
			{
				foreach (EAdjustPlayerCamera value in EAdjustPlayerCameraExtensions.GetValues())
				{
					baseTagComponent.RemoveTag(new int?(GameplayTagUtils.GetTagIdByName(value.ToEnumString())));
				}
				baseTagComponent.RemoveTag(new int?(CameraConfigController.NoAimGameplayTag));
			}
		}
		this.AdjustCameraEntityHandleSet.Clear();
		this.AdjustCameraTagMap.Clear();
	}

	// Token: 0x0600546B RID: 21611 RVA: 0x000CCB20 File Offset: 0x000CAD20
	public void DisableHookConfigByType(EAdjustPlayerCamera adjustPlayerCamera)
	{
		foreach (EntityHandle entityHandle in this.AdjustCameraEntityHandleSet)
		{
			WorldEntity entity = entityHandle.Entity;
			BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent != null)
			{
				baseTagComponent.RemoveTag(new int?(GameplayTagUtils.GetTagIdByName(adjustPlayerCamera.ToEnumString())));
				baseTagComponent.RemoveTag(new int?(CameraConfigController.NoAimGameplayTag));
			}
		}
		this.AdjustCameraTagMap.Remove(adjustPlayerCamera);
	}

	// Token: 0x0600546C RID: 21612 RVA: 0x000CCBB8 File Offset: 0x000CADB8
	[NullableContext(2)]
	public CameraConfig GetCameraConfigByTag(int hookTagId)
	{
		return this.SubConfigs.GetValueOrDefault(hookTagId);
	}

	// Token: 0x0600546D RID: 21613 RVA: 0x000CCBC8 File Offset: 0x000CADC8
	public void LoadConfig()
	{
		this.ConfigsCache = ControllerBase<CameraController>.Instance.GetCameraConfigList(null);
		this.SubConfigs.Clear();
		this.FocusConfigs.Clear();
		this.AccompanyConfigs.Clear();
		this.CurrentSubTagSet.Clear();
		this.CurrentAccompanyTagSet.Clear();
		foreach (DtCameraConfig dtCameraConfig in this.CharacterCameraConfigs.Values)
		{
			dtCameraConfig.SubValidKeys.Clear();
			dtCameraConfig.FocusValidKeys.Clear();
			dtCameraConfig.AccompanyValidKeys.Clear();
		}
		int num = this.ConfigsCache.Num();
		Type typeFromHandle = typeof(CameraConfig);
		for (int i = 0; i < num; i++)
		{
			CameraConfig cameraConfig = new CameraConfig(this.ConfigsCache.Get(i));
			FieldInfo field = typeFromHandle.GetField(this.PlatformCheckKey);
			if (!(field == null) && (bool)field.GetValue(cameraConfig))
			{
				if (cameraConfig.Type == EFightCameraType.基础镜头)
				{
					this.DefaultConfig = cameraConfig;
				}
				else if (cameraConfig.Type == EFightCameraType.战斗镜头)
				{
					this.FightConfig = cameraConfig;
				}
				else if (cameraConfig.Type == EFightCameraType.子镜头)
				{
					if (cameraConfig.Tag == null || cameraConfig.Tag.Value.TagName == FName.NAME_None)
					{
						Singleton<global::Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "初始化镜头配置[DT_CameraConfigs]失败，子镜头没有正确配置Tag", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					else
					{
						this.SubConfigs[cameraConfig.Tag.Value.TagId()] = cameraConfig;
					}
				}
				else if (cameraConfig.Type == EFightCameraType.锁定目标镜头)
				{
					if (cameraConfig.Tag.Value.TagName == FName.NAME_None)
					{
						Singleton<global::Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "初始化镜头配置[DT_CameraConfigs]失败，锁定目标镜头没有正确配置Tag", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					else
					{
						this.FocusConfigs[cameraConfig.Tag.Value.TagId()] = cameraConfig;
					}
				}
				else if (cameraConfig.Type == EFightCameraType.伴随目标镜头)
				{
					if (cameraConfig.Tag.Value.TagName == FName.NAME_None)
					{
						Singleton<global::Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "初始化镜头配置[DT_CameraConfigs]失败，伴随目标镜头没有正确配置Tag", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					else
					{
						this.AccompanyConfigs[cameraConfig.Tag.Value.TagId()] = cameraConfig;
					}
				}
			}
		}
		if (this.DefaultConfig == null || this.FightConfig == null)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "初始化镜头配置[DT_CameraConfigs]失败，基础镜头/战斗镜头未配置", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		foreach (DtCameraConfig dtCameraConfig2 in this.CharacterCameraConfigs.Values)
		{
			dtCameraConfig2.SetToConfigs(this.SubConfigs, this.FocusConfigs, this.AccompanyConfigs, this.PlatformCheckKey);
		}
		this.IsFighting = false;
		this.CurrentConfigList.Clear();
		this.CurrentConfigList.Insert(this.DefaultConfig);
		this.HasChangedConfig = true;
		this.UpdateFadeInConfig(this.DefaultConfig);
		this.UpdateConfig();
	}

	// Token: 0x0600546E RID: 21614 RVA: 0x000CCF24 File Offset: 0x000CB124
	[NullableContext(2)]
	public void LoadCharacterConfig(UDataTable dataTable)
	{
		if (dataTable == null)
		{
			return;
		}
		DtCameraConfig dtCameraConfig;
		if (!this.CharacterCameraConfigs.TryGetValue(dataTable, out dtCameraConfig))
		{
			dtCameraConfig = new DtCameraConfig(dataTable);
			dtCameraConfig.SetToConfigs(this.SubConfigs, this.FocusConfigs, this.AccompanyConfigs, this.PlatformCheckKey);
			this.CharacterCameraConfigs[dataTable] = dtCameraConfig;
			EntityHandle selfCharacterEntityInternal = this.SelfCharacterEntityInternal;
			if (selfCharacterEntityInternal != null && selfCharacterEntityInternal.Valid)
			{
				BaseTagComponent component = this.SelfCharacterEntityInternal.Entity.GetComponent<BaseTagComponent>();
				if (component != null && component.Valid)
				{
					foreach (int tagId in dtCameraConfig.SubValidKeys)
					{
						component.AddTagAddOrRemoveListener(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnSubTagChanged), null);
					}
				}
			}
			Entity focusTarget = this.FocusTarget;
			if (focusTarget != null && focusTarget.Valid)
			{
				BaseTagComponent component2 = this.FocusTarget.GetComponent<BaseTagComponent>();
				if (component2 != null && component2.Valid)
				{
					foreach (int tagId2 in dtCameraConfig.FocusValidKeys)
					{
						component2.AddTagAddOrRemoveListener(tagId2, new BaseTagComponent.TTagSwitchedCallback(this.OnFocusTagChanged), null);
					}
				}
			}
			EntityHandle floatCharacterEntity = this.FloatCharacterEntity;
			if (floatCharacterEntity != null && floatCharacterEntity.Valid)
			{
				BaseTagComponent component3 = this.FloatCharacterEntityInternal.Entity.GetComponent<BaseTagComponent>();
				if (component3 != null && component3.Valid)
				{
					foreach (int tagId3 in dtCameraConfig.AccompanyValidKeys)
					{
						component3.AddTagAddOrRemoveListener(tagId3, new BaseTagComponent.TTagSwitchedCallback(this.OnAccompanyTagChanged), null);
					}
				}
			}
			if (this.SelfCharacterEntity != null)
			{
				foreach (int num in dtCameraConfig.SubValidKeys)
				{
					if (this.Camera.ContainsTag(num, false))
					{
						CameraConfig cameraConfig = this.SubConfigs[num];
						this.CurrentConfigList.Insert(cameraConfig);
						this.CurrentSubTagSet.Add(num);
						this.UpdateFadeInConfig(cameraConfig);
					}
				}
			}
			if (this.FocusTarget != null)
			{
				foreach (int num2 in dtCameraConfig.FocusValidKeys)
				{
					if (this.Camera.TargetContainsTag(num2))
					{
						CameraConfig cameraConfig2 = this.FocusConfigs[num2];
						this.CurrentConfigList.Insert(cameraConfig2);
						this.CurrentFocusTagSet.Add(num2);
						this.UpdateFadeInConfig(cameraConfig2);
					}
				}
			}
			if (this.FloatCharacterEntity != null)
			{
				foreach (int num3 in dtCameraConfig.AccompanyValidKeys)
				{
					if (this.Camera.AccompanyContainsTag(num3))
					{
						CameraConfig cameraConfig3 = this.AccompanyConfigs[num3];
						this.CurrentConfigList.Insert(cameraConfig3);
						this.CurrentAccompanyTagSet.Add(num3);
						this.UpdateFadeInConfig(cameraConfig3);
					}
				}
			}
		}
		dtCameraConfig.ReferenceCount++;
	}

	// Token: 0x0600546F RID: 21615 RVA: 0x000CD2A0 File Offset: 0x000CB4A0
	[NullableContext(2)]
	public void UnloadCharacterConfig(UDataTable dataTable)
	{
		if (dataTable == null)
		{
			return;
		}
		DtCameraConfig dtCameraConfig;
		if (!this.CharacterCameraConfigs.TryGetValue(dataTable, out dtCameraConfig))
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "没有加载Camera配置表格";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DT", dataTable.GetOuter());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		dtCameraConfig.ReferenceCount--;
		if (dtCameraConfig.ReferenceCount == 0)
		{
			EntityHandle selfCharacterEntityInternal = this.SelfCharacterEntityInternal;
			if (selfCharacterEntityInternal != null && selfCharacterEntityInternal.Valid)
			{
				BaseTagComponent component = this.SelfCharacterEntityInternal.Entity.GetComponent<BaseTagComponent>();
				if (component != null && component.Valid)
				{
					foreach (int tagId in dtCameraConfig.SubValidKeys)
					{
						component.RemoveTagAddOrRemoveListener(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnSubTagChanged));
					}
				}
			}
			Entity focusTarget = this.FocusTarget;
			if (focusTarget != null && focusTarget.Valid)
			{
				BaseTagComponent component2 = this.FocusTarget.GetComponent<BaseTagComponent>();
				if (component2 != null && component2.Valid)
				{
					foreach (int tagId2 in dtCameraConfig.FocusValidKeys)
					{
						component2.RemoveTagAddOrRemoveListener(tagId2, new BaseTagComponent.TTagSwitchedCallback(this.OnFocusTagChanged));
					}
				}
			}
			EntityHandle floatCharacterEntityInternal = this.FloatCharacterEntityInternal;
			if (floatCharacterEntityInternal != null && floatCharacterEntityInternal.Valid)
			{
				BaseTagComponent component3 = this.FloatCharacterEntityInternal.Entity.GetComponent<BaseTagComponent>();
				if (component3 != null && component3.Valid)
				{
					foreach (int tagId3 in dtCameraConfig.AccompanyValidKeys)
					{
						component3.RemoveTagAddOrRemoveListener(tagId3, new BaseTagComponent.TTagSwitchedCallback(this.OnAccompanyTagChanged));
					}
				}
			}
			if (this.SelfCharacterEntity != null)
			{
				foreach (int num in dtCameraConfig.SubValidKeys)
				{
					if (this.CurrentSubTagSet.Remove(num))
					{
						CameraConfig cameraConfig = this.SubConfigs[num];
						this.CurrentConfigList.Remove(cameraConfig);
						this.UpdateFadeOutConfig(cameraConfig);
					}
				}
			}
			if (this.FocusTarget != null)
			{
				foreach (int num2 in dtCameraConfig.FocusValidKeys)
				{
					if (this.CurrentFocusTagSet.Remove(num2))
					{
						CameraConfig cameraConfig2 = this.FocusConfigs[num2];
						this.CurrentConfigList.Remove(cameraConfig2);
						this.UpdateFadeOutConfig(cameraConfig2);
					}
				}
			}
			if (this.FloatCharacterEntity != null)
			{
				foreach (int num3 in dtCameraConfig.AccompanyValidKeys)
				{
					if (this.CurrentAccompanyTagSet.Remove(num3))
					{
						CameraConfig cameraConfig3 = this.AccompanyConfigs[num3];
						this.CurrentConfigList.Remove(cameraConfig3);
						this.UpdateFadeOutConfig(cameraConfig3);
					}
				}
			}
			dtCameraConfig.RemoveFromConfigs(this.SubConfigs, this.FocusConfigs, this.AccompanyConfigs);
			this.CharacterCameraConfigs.Remove(dataTable);
		}
	}

	// Token: 0x06005470 RID: 21616 RVA: 0x000CD618 File Offset: 0x000CB818
	public void UpdateConfig()
	{
		if (this.Camera.Character == null)
		{
			return;
		}
		bool flag = this.UpdateMainFightConfig();
		this.SelfCharacterEntity = this.Camera.CharacterEntityHandle;
		string text;
		if (this.Camera.TargetEntity == null)
		{
			text = "";
		}
		else
		{
			FightCameraLogicComponent camera = this.Camera;
			text = (((camera.TargetSocketName != null) ? camera.TargetSocketName.GetValueOrDefault().ToString() : null) ?? "");
		}
		string newSocket = text;
		EntityHandle targetEntity = this.Camera.TargetEntity;
		this.UpdateFocusTargetAndSocket((targetEntity != null) ? targetEntity.Entity : null, newSocket);
		if (flag | this.HasChangedConfig)
		{
			this.ApplyAllConfigs();
		}
		this.HasChangedConfig = false;
	}

	// Token: 0x06005471 RID: 21617 RVA: 0x000CD6C8 File Offset: 0x000CB8C8
	private bool UpdateMainFightConfig()
	{
		bool flag = this.Camera.ContainsTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"], false);
		if (flag == this.IsFighting)
		{
			return false;
		}
		CameraConfig cameraConfig = this.IsFighting ? this.FightConfig : this.DefaultConfig;
		CameraConfig cameraConfig2 = flag ? this.FightConfig : this.DefaultConfig;
		this.CurrentConfigList.Remove(cameraConfig);
		this.CurrentConfigList.Insert(cameraConfig2);
		this.UpdateFadeOutConfig(cameraConfig);
		this.UpdateFadeInConfig(cameraConfig2);
		this.IsFighting = flag;
		return true;
	}

	// Token: 0x06005472 RID: 21618 RVA: 0x000CD754 File Offset: 0x000CB954
	private void UpdateFocusTargetConfig()
	{
		foreach (int num in this.CurrentFocusTagSet.ToArray<int>())
		{
			CameraConfig cameraConfig = this.FocusConfigs[num];
			if (!this.Camera.TargetContainsTag(num) || !cameraConfig.LockOnParts.Contains(this.FocusTargetSocketName))
			{
				this.CurrentConfigList.Remove(cameraConfig);
				this.CurrentFocusTagSet.Remove(num);
				this.UpdateFadeOutConfig(cameraConfig);
			}
		}
		foreach (KeyValuePair<int, CameraConfig> keyValuePair in this.FocusConfigs)
		{
			int i;
			CameraConfig cameraConfig2;
			keyValuePair.Deconstruct(out i, out cameraConfig2);
			int num2 = i;
			CameraConfig cameraConfig3 = cameraConfig2;
			if (this.Camera.TargetContainsTag(num2) && (cameraConfig3.LockOnParts.Length == 0 || cameraConfig3.LockOnParts.Contains(this.FocusTargetSocketName)) && !this.CurrentFocusTagSet.Contains(num2))
			{
				this.CurrentConfigList.Insert(cameraConfig3);
				this.CurrentFocusTagSet.Add(num2);
				this.UpdateFadeInConfig(cameraConfig3);
			}
		}
	}

	// Token: 0x06005473 RID: 21619 RVA: 0x000CD884 File Offset: 0x000CBA84
	private void UpdateTargetConfig()
	{
		foreach (int num in this.CurrentSubTagSet.ToArray<int>())
		{
			CameraConfig cameraConfig = this.SubConfigs[num];
			if (!this.Camera.ContainsTag(num, false))
			{
				this.CurrentConfigList.Remove(cameraConfig);
				this.CurrentSubTagSet.Remove(num);
				this.UpdateFadeOutConfig(cameraConfig);
			}
		}
		foreach (KeyValuePair<int, CameraConfig> keyValuePair in this.SubConfigs)
		{
			int i;
			CameraConfig cameraConfig2;
			keyValuePair.Deconstruct(out i, out cameraConfig2);
			int num2 = i;
			CameraConfig cameraConfig3 = cameraConfig2;
			if (!this.CurrentSubTagSet.Contains(num2) && this.Camera.ContainsTag(num2, false))
			{
				this.CurrentConfigList.Insert(cameraConfig3);
				this.CurrentSubTagSet.Add(num2);
				this.UpdateFadeInConfig(cameraConfig3);
			}
		}
	}

	// Token: 0x06005474 RID: 21620 RVA: 0x000CD980 File Offset: 0x000CBB80
	private void UpdateAccompanyTargetConfig()
	{
		foreach (int num in this.CurrentAccompanyTagSet.ToArray<int>())
		{
			CameraConfig cameraConfig = this.AccompanyConfigs[num];
			if (!this.Camera.AccompanyContainsTag(num))
			{
				this.CurrentConfigList.Remove(cameraConfig);
				this.CurrentAccompanyTagSet.Remove(num);
				this.UpdateFadeOutConfig(cameraConfig);
			}
		}
		foreach (KeyValuePair<int, CameraConfig> keyValuePair in this.AccompanyConfigs)
		{
			int i;
			CameraConfig cameraConfig2;
			keyValuePair.Deconstruct(out i, out cameraConfig2);
			int num2 = i;
			CameraConfig cameraConfig3 = cameraConfig2;
			if (!this.CurrentAccompanyTagSet.Contains(num2) && this.Camera.AccompanyContainsTag(num2))
			{
				this.CurrentConfigList.Insert(cameraConfig3);
				this.CurrentAccompanyTagSet.Add(num2);
				this.UpdateFadeInConfig(cameraConfig3);
			}
		}
	}

	// Token: 0x06005475 RID: 21621 RVA: 0x000CDA7C File Offset: 0x000CBC7C
	private void UpdateFadeInConfig(CameraConfig cameraConfig)
	{
		float num = Math.Min(cameraConfig.FadeInTime, 10f);
		if (num > this.ConfigFadeInDuration)
		{
			return;
		}
		if (!this.IsUniqueFade)
		{
			FightCameraLogicComponent camera = this.Camera;
			if (camera == null || !camera.Fading || !camera.IsUniqueFade)
			{
				goto IL_46;
			}
		}
		if (!cameraConfig.IsUniqueFade)
		{
			return;
		}
		IL_46:
		this.FadeInTriggered = true;
		this.HasChangedConfig = true;
		this.IsUniqueFade = cameraConfig.IsUniqueFade;
		this.ConfigFadeInDuration = num;
		this.ConfigFadeInCurve = cameraConfig.FadeInCurve;
	}

	// Token: 0x06005476 RID: 21622 RVA: 0x000CDAFC File Offset: 0x000CBCFC
	private void UpdateFadeOutConfig(CameraConfig cameraConfig)
	{
		float num = Math.Min(cameraConfig.FadeOutTime, 10f);
		if (num > this.ConfigFadeOutDuration)
		{
			return;
		}
		if (!this.IsUniqueFade)
		{
			FightCameraLogicComponent camera = this.Camera;
			if (camera == null || !camera.Fading || !camera.IsUniqueFade)
			{
				goto IL_46;
			}
		}
		if (!cameraConfig.IsUniqueFade)
		{
			return;
		}
		IL_46:
		this.FadeOutTriggered = true;
		this.HasChangedConfig = true;
		this.IsUniqueFade = cameraConfig.IsUniqueFade;
		this.ConfigFadeOutDuration = num;
		this.ConfigFadeOutCurve = cameraConfig.FadeOutCurve;
	}

	// Token: 0x06005477 RID: 21623 RVA: 0x000CDB7C File Offset: 0x000CBD7C
	private bool IsFadeIn()
	{
		if (this.FadeInTriggered && this.FadeOutTriggered)
		{
			return this.ConfigFadeInDuration <= this.ConfigFadeOutDuration;
		}
		return this.FadeInTriggered;
	}

	// Token: 0x06005478 RID: 21624 RVA: 0x000CDBA8 File Offset: 0x000CBDA8
	[Conditional("DEBUG")]
	private void UpdateSubCameraModification()
	{
		CameraConfigController.<>c__DisplayClass73_0 CS$<>8__locals1 = new CameraConfigController.<>c__DisplayClass73_0();
		CS$<>8__locals1.subCameraModifications = new Dictionary<CameraConfig, Dictionary<string, ValueTuple<float, bool>>>();
		CS$<>8__locals1.tempConfigList = new List<CameraConfig>();
		this.CurrentConfigList.ForEach(delegate(CameraConfig config)
		{
			CS$<>8__locals1.tempConfigList.Add(config);
			return true;
		});
		CS$<>8__locals1.modifiedKeys = new HashSet<string>();
		for (int i = CS$<>8__locals1.tempConfigList.Count - 1; i >= 0; i--)
		{
			CameraConfig cameraConfig = CS$<>8__locals1.tempConfigList[i];
			CS$<>8__locals1.<UpdateSubCameraModification>g__UpdateConfigModification|1<EFightCameraDefault>("FightCameraLogicComponent", this.Camera, cameraConfig, cameraConfig.DefaultConfig);
			CS$<>8__locals1.<UpdateSubCameraModification>g__UpdateConfigModification|1<EFightCameraFocus>("CameraFocusController", this.Camera.CameraFocusController, cameraConfig, cameraConfig.FocusConfig);
			CS$<>8__locals1.<UpdateSubCameraModification>g__UpdateConfigModification|1<EFightCameraInput>("CameraInputController", this.Camera.CameraInputController, cameraConfig, cameraConfig.InputConfig);
			CS$<>8__locals1.<UpdateSubCameraModification>g__UpdateConfigModification|1<EFightCameraModify>("CameraModifyController", this.Camera.CameraModifyController, cameraConfig, cameraConfig.ModifyConfig);
			CS$<>8__locals1.<UpdateSubCameraModification>g__UpdateConfigModification|1<EFightCameraAdjust>("CameraAdjustController", this.Camera.CameraAdjustController, cameraConfig, cameraConfig.AdjustConfig);
			CS$<>8__locals1.<UpdateSubCameraModification>g__UpdateConfigModification|1<EFightCameraSidestep>("CameraSidestepController", this.Camera.CameraSidestepController, cameraConfig, cameraConfig.SidestepConfig);
			CS$<>8__locals1.<UpdateSubCameraModification>g__UpdateConfigModification|1<EFightCameraAuto>("CameraAutoController", this.Camera.CameraAutoController, cameraConfig, cameraConfig.AutoConfig);
			CS$<>8__locals1.<UpdateSubCameraModification>g__UpdateConfigModification|1<EFightCameraGuide>("CameraGuideController", this.Camera.CameraGuideController, cameraConfig, cameraConfig.GuideConfig);
			CS$<>8__locals1.<UpdateSubCameraModification>g__UpdateConfigModification|1<EFightCameraExplore>("CameraRunningController", this.Camera.CameraRunningController, cameraConfig, cameraConfig.ExploreConfig);
			CS$<>8__locals1.<UpdateSubCameraModification>g__UpdateConfigModification|1<EFightCameraDialogue>("CameraDialogueController", this.Camera.CameraDialogueController, cameraConfig, cameraConfig.DialogueConfig);
			CS$<>8__locals1.<UpdateSubCameraModification>g__UpdateConfigModification|1<EFightCameraClimb>("CameraClimbController", this.Camera.CameraClimbController, cameraConfig, cameraConfig.ClimbConfig);
		}
		this.DebugSubCameraModifications = CS$<>8__locals1.subCameraModifications;
	}

	// Token: 0x06005479 RID: 21625 RVA: 0x000CDD64 File Offset: 0x000CBF64
	private void ApplyAllConfigs()
	{
		this.ResetLockController();
		this.ResetAllControllersDefaultConfig();
		CameraConfig resetDefaultConfig = this.CurrentConfigList.ExtremelyLeft;
		bool hasResetDefaultConfig = false;
		CameraConfig resetDefaultLockConfig = this.CurrentConfigList.ExtremelyLeft;
		bool hasResetDefaultLockConfig = false;
		bool isLockConfigLeft = false;
		this.CurrentConfigList.ForEachReverse(delegate(CameraConfig config)
		{
			if (config.IsResetDefaultConfig && !hasResetDefaultConfig)
			{
				resetDefaultConfig = config;
				hasResetDefaultConfig = true;
			}
			if (config.IsResetCameraLock && !hasResetDefaultLockConfig)
			{
				resetDefaultLockConfig = config;
				hasResetDefaultLockConfig = true;
			}
			if (!hasResetDefaultLockConfig & hasResetDefaultConfig)
			{
				isLockConfigLeft = true;
			}
			return !(hasResetDefaultLockConfig & hasResetDefaultConfig);
		});
		CameraConfig from = isLockConfigLeft ? resetDefaultLockConfig : resetDefaultConfig;
		bool appliedDefaultConfig = false;
		bool appliedLockConfig = false;
		this.CurrentConfigList.ForEachFrom(from, delegate(CameraConfig config)
		{
			if (config == resetDefaultConfig && !appliedDefaultConfig)
			{
				appliedDefaultConfig = true;
			}
			if (config == resetDefaultLockConfig && !appliedLockConfig)
			{
				appliedLockConfig = true;
			}
			if (appliedDefaultConfig)
			{
				this.UpdateControllersConfig(config);
			}
			if (appliedLockConfig)
			{
				this.UpdateControllersLockStateByConfig(config);
			}
			return true;
		});
		this.Camera.ApplyConfig();
		if (this.Camera.Initialized)
		{
			bool flag = this.IsFadeIn();
			this.Camera.StartFade(flag ? this.ConfigFadeInDuration : this.ConfigFadeOutDuration, flag ? this.ConfigFadeInCurve : this.ConfigFadeOutCurve, true, true, true, true, this.IsUniqueFade);
		}
		this.IsUniqueFade = false;
		this.FadeInTriggered = false;
		this.FadeOutTriggered = false;
		this.ConfigFadeInDuration = 10f;
		this.ConfigFadeOutDuration = 10f;
	}

	// Token: 0x0600547A RID: 21626 RVA: 0x000CDE98 File Offset: 0x000CC098
	private void SetHookConfigFadeOutTime(EAdjustPlayerCamera adjustPlayerCamera, float fadeOutTime)
	{
		CameraConfig cameraConfigByTag = this.GetCameraConfigByTag(GameplayTagUtils.GetTagIdByName(adjustPlayerCamera.ToEnumString()));
		if (cameraConfigByTag == null)
		{
			return;
		}
		cameraConfigByTag.FadeOutTime = fadeOutTime;
	}

	// Token: 0x0600547B RID: 21627 RVA: 0x000CDEC4 File Offset: 0x000CC0C4
	public string GetCameraConfigTagsContent()
	{
		string content = "";
		this.CurrentConfigList.ForEach(delegate(CameraConfig config)
		{
			string content = content;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("|");
			defaultInterpolatedStringHandler.AppendFormatted<FName>((config.Tag != null) ? config.Tag.GetValueOrDefault().TagName : "None");
			content += defaultInterpolatedStringHandler.ToStringAndClear();
			return true;
		});
		return content;
	}

	// Token: 0x0600547C RID: 21628 RVA: 0x000CDF00 File Offset: 0x000CC100
	private void ResetLockController()
	{
		if (!this.AutoCamera)
		{
			this.Camera.CameraAutoController.Unlock(this);
		}
		if (!this.ModifyCamera)
		{
			this.Camera.CameraModifyController.Unlock(this);
		}
		if (!this.AdjustCamera)
		{
			this.Camera.CameraAdjustController.Unlock(this);
		}
		if (!this.FocusCamera)
		{
			this.Camera.CameraFocusController.Unlock(this);
		}
		if (!this.SidestepCamera)
		{
			this.Camera.CameraSidestepController.Unlock(this);
		}
		if (!this.ClimbCamera)
		{
			this.Camera.CameraClimbController.Unlock(this);
		}
		this.AutoCamera = true;
		this.ModifyCamera = true;
		this.AdjustCamera = true;
		this.FocusCamera = true;
		this.SidestepCamera = true;
		this.ClimbCamera = true;
		this.Camera.CameraCollision.IsOpenBlend = true;
	}

	// Token: 0x0600547D RID: 21629 RVA: 0x000CDFE0 File Offset: 0x000CC1E0
	private void UpdateControllersConfig(CameraConfig config)
	{
		this.Camera.SetConfigs(config.DefaultConfig, config.DefaultCurveConfig, config.VehicleConfig, config.VehicleCurveConfig, (config.Tag != null) ? config.Tag.GetValueOrDefault().TagName : FName.NAME_None, config.CameraArmLocationSocketName, config.CameraArmLocationSocketOverrideType, false);
		this.Camera.CameraFocusController.SetConfigs(config.FocusConfig, config.CurveFocusConfig);
		this.Camera.CameraInputController.SetConfigs(config.InputConfig, config.CurveInputConfig);
		this.Camera.CameraModifyController.SetConfigs(config.ModifyConfig, config.CurveModifyConfig);
		this.Camera.CameraAdjustController.SetConfigs(config.AdjustConfig, config.CurveAdjustConfig);
		this.Camera.CameraSidestepController.SetConfigs(config.SidestepConfig, config.CurveSidestepConfig);
		this.Camera.CameraAutoController.SetConfigs(config.AutoConfig, config.CurveAutoConfig);
		this.Camera.CameraGuideController.SetConfigs(config.GuideConfig, config.CurveGuideConfig);
		this.Camera.CameraRunningController.SetConfigs(config.ExploreConfig, config.CurveExploreConfig);
		this.Camera.CameraDialogueController.SetConfigs(config.DialogueConfig, config.CurveDialogueConfig);
		this.Camera.CameraClimbController.SetConfigs(config.ClimbConfig, config.CurveClimbConfig);
		this.Camera.CameraGravityController.SetConfigs(config.GravityConfig, config.GravityCurveConfig);
	}

	// Token: 0x0600547E RID: 21630 RVA: 0x000CE174 File Offset: 0x000CC374
	private void UpdateControllersLockStateByConfig(CameraConfig config)
	{
		if (!config.EnableAutoCamera)
		{
			this.Camera.CameraAutoController.Lock(this);
			this.AutoCamera = false;
		}
		if (!config.EnableModifyCamera)
		{
			this.Camera.CameraModifyController.Lock(this);
			this.ModifyCamera = false;
		}
		if (!config.EnableAdjustCamera)
		{
			this.Camera.CameraAdjustController.Lock(this);
			this.AdjustCamera = false;
		}
		if (!config.EnableFocusCamera)
		{
			this.Camera.CameraFocusController.Lock(this);
			this.FocusCamera = false;
		}
		if (!config.EnableSidestepCamera)
		{
			this.Camera.CameraSidestepController.Lock(this);
			this.SidestepCamera = false;
		}
		if (!config.EnableClimbCamera)
		{
			this.Camera.CameraClimbController.Lock(this);
			this.ClimbCamera = false;
		}
		this.Camera.CameraCollision.IsOpenBlend = config.IsOpenMainLoop;
	}

	// Token: 0x0600547F RID: 21631 RVA: 0x000CE258 File Offset: 0x000CC458
	private void ResetAllControllersDefaultConfig()
	{
		this.Camera.ResetDefaultConfig();
		this.Camera.CameraFocusController.ResetDefaultConfig();
		this.Camera.CameraInputController.ResetDefaultConfig();
		this.Camera.CameraModifyController.ResetDefaultConfig();
		this.Camera.CameraAdjustController.ResetDefaultConfig();
		this.Camera.CameraSidestepController.ResetDefaultConfig();
		this.Camera.CameraAutoController.ResetDefaultConfig();
		this.Camera.CameraGuideController.ResetDefaultConfig();
		this.Camera.CameraRunningController.ResetDefaultConfig();
		this.Camera.CameraDialogueController.ResetDefaultConfig();
		this.Camera.CameraClimbController.ResetDefaultConfig();
		this.Camera.CameraGravityController.ResetDefaultConfig();
	}

	// Token: 0x06005480 RID: 21632 RVA: 0x000CE320 File Offset: 0x000CC520
	public bool CheckIfInAdjustCamera()
	{
		return this.AdjustCameraTagMap.Count > 0 && this.AdjustCameraTagMap.ContainsKey(EAdjustPlayerCamera.Fixed);
	}

	// Token: 0x06005481 RID: 21633 RVA: 0x000CE340 File Offset: 0x000CC540
	public override void OnEnd()
	{
		base.OnEnd();
		Singleton<EventSystem>.Instance.Remove<EntityHandle, string>(EEventName.CameraCharacterChanged, new Action<EntityHandle, string>(this.OnCameraCharacterChanged));
		Singleton<EventSystem>.Instance.Remove<EntityHandle>(EEventName.OnPlayerFollowerPossessed, new Action<EntityHandle>(this.OnFollowShooterPossessed));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerFollowerUnPossessed, new Action(this.OnFollowShooterUnPossessed));
	}

	// Token: 0x06005482 RID: 21634 RVA: 0x000CE3A8 File Offset: 0x000CC5A8
	[NullableContext(0)]
	public override bool TryGetMember(string key, out object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 10:
			{
				char c = key[0];
				if (c != 'A')
				{
					if (c != 'I')
					{
						if (c == 'S')
						{
							if (key == "SubConfigs")
							{
								value = this.SubConfigs;
								return true;
							}
						}
					}
					else if (key == "IsFighting")
					{
						value = this.IsFighting;
						return true;
					}
				}
				else if (key == "AutoCamera")
				{
					value = this.AutoCamera;
					return true;
				}
				break;
			}
			case 11:
			{
				char c = key[1];
				if (c != 'i')
				{
					if (c != 'l')
					{
						if (c == 'o')
						{
							if (key == "FocusTarget")
							{
								value = this.FocusTarget;
								return true;
							}
							if (key == "FocusCamera")
							{
								value = this.FocusCamera;
								return true;
							}
						}
					}
					else if (key == "ClimbCamera")
					{
						value = this.ClimbCamera;
						return true;
					}
				}
				else if (key == "FightConfig")
				{
					value = this.FightConfig;
					return true;
				}
				break;
			}
			case 12:
			{
				char c = key[0];
				if (c <= 'C')
				{
					if (c != 'A')
					{
						if (c == 'C')
						{
							if (key == "ConfigsCache")
							{
								value = this.ConfigsCache;
								return true;
							}
						}
					}
					else if (key == "AdjustCamera")
					{
						value = this.AdjustCamera;
						return true;
					}
				}
				else if (c != 'F')
				{
					if (c != 'I')
					{
						if (c == 'M')
						{
							if (key == "ModifyCamera")
							{
								value = this.ModifyCamera;
								return true;
							}
						}
					}
					else if (key == "IsUniqueFade")
					{
						value = this.IsUniqueFade;
						return true;
					}
				}
				else if (key == "FocusConfigs")
				{
					value = this.FocusConfigs;
					return true;
				}
				break;
			}
			case 13:
				if (key == "DefaultConfig")
				{
					value = this.DefaultConfig;
					return true;
				}
				break;
			case 14:
				if (key == "SidestepCamera")
				{
					value = this.SidestepCamera;
					return true;
				}
				break;
			case 15:
				if (key == "FadeInTriggered")
				{
					value = this.FadeInTriggered;
					return true;
				}
				break;
			case 16:
			{
				char c = key[0];
				if (c <= 'C')
				{
					if (c != 'A')
					{
						if (c == 'C')
						{
							if (key == "CurrentSubTagSet")
							{
								value = this.CurrentSubTagSet;
								return true;
							}
						}
					}
					else if (key == "AccompanyConfigs")
					{
						value = this.AccompanyConfigs;
						return true;
					}
				}
				else if (c != 'F')
				{
					if (c != 'H')
					{
						if (c == 'P')
						{
							if (key == "PlatformCheckKey")
							{
								value = this.PlatformCheckKey;
								return true;
							}
						}
					}
					else if (key == "HasChangedConfig")
					{
						value = this.HasChangedConfig;
						return true;
					}
				}
				else if (key == "FadeOutTriggered")
				{
					value = this.FadeOutTriggered;
					return true;
				}
				break;
			}
			case 17:
			{
				char c = key[1];
				if (c != 'o')
				{
					if (c == 'u')
					{
						if (key == "CurrentConfigList")
						{
							value = this.CurrentConfigList;
							return true;
						}
					}
				}
				else if (key == "ConfigFadeInCurve")
				{
					value = this.ConfigFadeInCurve;
					return true;
				}
				break;
			}
			case 18:
			{
				char c = key[1];
				if (c != 'd')
				{
					if (c != 'o')
					{
						if (c == 'u')
						{
							if (key == "CurrentFocusTagSet")
							{
								value = this.CurrentFocusTagSet;
								return true;
							}
						}
					}
					else if (key == "ConfigFadeOutCurve")
					{
						value = this.ConfigFadeOutCurve;
						return true;
					}
				}
				else if (key == "AdjustCameraTagMap")
				{
					value = this.AdjustCameraTagMap;
					return true;
				}
				break;
			}
			case 19:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'S')
					{
						if (key == "SelfCharacterEntity")
						{
							value = this.SelfCharacterEntity;
							return true;
						}
					}
				}
				else if (key == "CameraConfigCompare")
				{
					value = this.CameraConfigCompare;
					return true;
				}
				break;
			}
			case 20:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'F')
					{
						if (key == "FloatCharacterEntity")
						{
							value = this.FloatCharacterEntity;
							return true;
						}
					}
				}
				else if (key == "ConfigFadeInDuration")
				{
					value = this.ConfigFadeInDuration;
					return true;
				}
				break;
			}
			case 21:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'F')
					{
						if (key == "FocusTargetSocketName")
						{
							value = this.FocusTargetSocketName;
							return true;
						}
					}
				}
				else if (key == "ConfigFadeOutDuration")
				{
					value = this.ConfigFadeOutDuration;
					return true;
				}
				break;
			}
			case 22:
			{
				char c = key[1];
				if (c != 'h')
				{
					if (c == 'u')
					{
						if (key == "CurrentAccompanyTagSet")
						{
							value = this.CurrentAccompanyTagSet;
							return true;
						}
					}
				}
				else if (key == "CharacterCameraConfigs")
				{
					value = this.CharacterCameraConfigs;
					return true;
				}
				break;
			}
			case 27:
			{
				char c = key[0];
				if (c != 'A')
				{
					if (c != 'D')
					{
						if (c == 'S')
						{
							if (key == "SelfCharacterEntityInternal")
							{
								value = this.SelfCharacterEntityInternal;
								return true;
							}
						}
					}
					else if (key == "DebugSubCameraModifications")
					{
						value = this.DebugSubCameraModifications;
						return true;
					}
				}
				else if (key == "AdjustCameraEntityHandleSet")
				{
					value = this.AdjustCameraEntityHandleSet;
					return true;
				}
				break;
			}
			case 28:
				if (key == "FloatCharacterEntityInternal")
				{
					value = this.FloatCharacterEntityInternal;
					return true;
				}
				break;
			}
		}
		return base.TryGetMember(key, out value);
	}

	// Token: 0x06005483 RID: 21635 RVA: 0x000CEA80 File Offset: 0x000CCC80
	[NullableContext(0)]
	public override void SetMember(string key, object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 10:
			{
				char c = key[0];
				if (c != 'A')
				{
					if (c == 'I')
					{
						if (key == "IsFighting")
						{
							this.IsFighting = (bool)value;
							return;
						}
					}
				}
				else if (key == "AutoCamera")
				{
					this.AutoCamera = (bool)value;
					return;
				}
				break;
			}
			case 11:
			{
				char c = key[1];
				if (c != 'i')
				{
					if (c != 'l')
					{
						if (c == 'o')
						{
							if (key == "FocusTarget")
							{
								this.FocusTarget = (Entity)value;
								return;
							}
							if (key == "FocusCamera")
							{
								this.FocusCamera = (bool)value;
								return;
							}
						}
					}
					else if (key == "ClimbCamera")
					{
						this.ClimbCamera = (bool)value;
						return;
					}
				}
				else if (key == "FightConfig")
				{
					this.FightConfig = (CameraConfig)value;
					return;
				}
				break;
			}
			case 12:
			{
				char c = key[0];
				if (c <= 'C')
				{
					if (c != 'A')
					{
						if (c == 'C')
						{
							if (key == "ConfigsCache")
							{
								this.ConfigsCache = (TArray<SCameraConfig>)value;
								return;
							}
						}
					}
					else if (key == "AdjustCamera")
					{
						this.AdjustCamera = (bool)value;
						return;
					}
				}
				else if (c != 'I')
				{
					if (c == 'M')
					{
						if (key == "ModifyCamera")
						{
							this.ModifyCamera = (bool)value;
							return;
						}
					}
				}
				else if (key == "IsUniqueFade")
				{
					this.IsUniqueFade = (bool)value;
					return;
				}
				break;
			}
			case 13:
				if (key == "DefaultConfig")
				{
					this.DefaultConfig = (CameraConfig)value;
					return;
				}
				break;
			case 14:
				if (key == "SidestepCamera")
				{
					this.SidestepCamera = (bool)value;
					return;
				}
				break;
			case 15:
				if (key == "FadeInTriggered")
				{
					this.FadeInTriggered = (bool)value;
					return;
				}
				break;
			case 16:
			{
				char c = key[0];
				if (c != 'F')
				{
					if (c == 'H')
					{
						if (key == "HasChangedConfig")
						{
							this.HasChangedConfig = (bool)value;
							return;
						}
					}
				}
				else if (key == "FadeOutTriggered")
				{
					this.FadeOutTriggered = (bool)value;
					return;
				}
				break;
			}
			case 17:
				if (key == "ConfigFadeInCurve")
				{
					this.ConfigFadeInCurve = (CurveBase)value;
					return;
				}
				break;
			case 18:
				if (key == "ConfigFadeOutCurve")
				{
					this.ConfigFadeOutCurve = (CurveBase)value;
					return;
				}
				break;
			case 19:
				if (key == "SelfCharacterEntity")
				{
					this.SelfCharacterEntity = (EntityHandle)value;
					return;
				}
				break;
			case 20:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'F')
					{
						if (key == "FloatCharacterEntity")
						{
							this.FloatCharacterEntity = (EntityHandle)value;
							return;
						}
					}
				}
				else if (key == "ConfigFadeInDuration")
				{
					float num2;
					if (value is double)
					{
						double num = (double)value;
						num2 = (float)num;
					}
					else if (value is float)
					{
						float num3 = (float)value;
						num2 = num3;
					}
					else if (value is int)
					{
						int num4 = (int)value;
						num2 = (float)num4;
					}
					else if (value is long)
					{
						long num5 = (long)value;
						num2 = (float)num5;
					}
					else
					{
						num2 = (float)value;
					}
					this.ConfigFadeInDuration = num2;
					return;
				}
				break;
			}
			case 21:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'F')
					{
						if (key == "FocusTargetSocketName")
						{
							this.FocusTargetSocketName = (string)value;
							return;
						}
					}
				}
				else if (key == "ConfigFadeOutDuration")
				{
					float num2;
					if (value is double)
					{
						double num6 = (double)value;
						num2 = (float)num6;
					}
					else if (value is float)
					{
						float num7 = (float)value;
						num2 = num7;
					}
					else if (value is int)
					{
						int num8 = (int)value;
						num2 = (float)num8;
					}
					else if (value is long)
					{
						long num9 = (long)value;
						num2 = (float)num9;
					}
					else
					{
						num2 = (float)value;
					}
					this.ConfigFadeOutDuration = num2;
					return;
				}
				break;
			}
			case 27:
			{
				char c = key[0];
				if (c != 'D')
				{
					if (c == 'S')
					{
						if (key == "SelfCharacterEntityInternal")
						{
							this.SelfCharacterEntityInternal = (EntityHandle)value;
							return;
						}
					}
				}
				else if (key == "DebugSubCameraModifications")
				{
					this.DebugSubCameraModifications = (Dictionary<CameraConfig, Dictionary<string, ValueTuple<float, bool>>>)value;
					return;
				}
				break;
			}
			case 28:
				if (key == "FloatCharacterEntityInternal")
				{
					this.FloatCharacterEntityInternal = (EntityHandle)value;
					return;
				}
				break;
			}
		}
		base.SetMember(key, value);
	}

	// Token: 0x06005484 RID: 21636 RVA: 0x000CF002 File Offset: 0x000CD202
	[NullableContext(0)]
	public override IEnumerable<ValueTuple<string, object>> MemberIter()
	{
		CameraConfigController.<MemberIter>d__85 <MemberIter>d__ = new CameraConfigController.<MemberIter>d__85(-2);
		<MemberIter>d__.<>4__this = this;
		return <MemberIter>d__;
	}

	// Token: 0x04001965 RID: 6501
	private const int DEFAULT_MAX_FADE_TIME = 10;

	// Token: 0x04001966 RID: 6502
	private static readonly int NoAimGameplayTag = GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.禁止瞄准模式"];

	// Token: 0x04001967 RID: 6503
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<SCameraConfig> ConfigsCache;

	// Token: 0x04001968 RID: 6504
	[Nullable(2)]
	private CameraConfig DefaultConfig;

	// Token: 0x04001969 RID: 6505
	[Nullable(2)]
	private CameraConfig FightConfig;

	// Token: 0x0400196A RID: 6506
	private readonly Dictionary<int, CameraConfig> SubConfigs = new Dictionary<int, CameraConfig>();

	// Token: 0x0400196B RID: 6507
	private readonly Dictionary<int, CameraConfig> FocusConfigs = new Dictionary<int, CameraConfig>();

	// Token: 0x0400196C RID: 6508
	private readonly Dictionary<int, CameraConfig> AccompanyConfigs = new Dictionary<int, CameraConfig>();

	// Token: 0x0400196D RID: 6509
	private readonly HashSet<int> CurrentSubTagSet = new HashSet<int>();

	// Token: 0x0400196E RID: 6510
	private readonly HashSet<int> CurrentFocusTagSet = new HashSet<int>();

	// Token: 0x0400196F RID: 6511
	private readonly HashSet<int> CurrentAccompanyTagSet = new HashSet<int>();

	// Token: 0x04001970 RID: 6512
	private readonly Comparison<CameraConfig> CameraConfigCompare = (CameraConfig a, CameraConfig b) => a.Priority - b.Priority;

	// Token: 0x04001971 RID: 6513
	private readonly RbTree<CameraConfig> CurrentConfigList;

	// Token: 0x04001972 RID: 6514
	private readonly Dictionary<UDataTable, DtCameraConfig> CharacterCameraConfigs = new Dictionary<UDataTable, DtCameraConfig>();

	// Token: 0x04001973 RID: 6515
	public readonly Dictionary<EAdjustPlayerCamera, int?> AdjustCameraTagMap = new Dictionary<EAdjustPlayerCamera, int?>();

	// Token: 0x04001974 RID: 6516
	public readonly HashSet<EntityHandle> AdjustCameraEntityHandleSet = new HashSet<EntityHandle>();

	// Token: 0x04001975 RID: 6517
	private bool IsFighting;

	// Token: 0x04001976 RID: 6518
	[Nullable(2)]
	private EntityHandle SelfCharacterEntityInternal;

	// Token: 0x04001977 RID: 6519
	[Nullable(2)]
	private EntityHandle FloatCharacterEntityInternal;

	// Token: 0x04001978 RID: 6520
	[Nullable(2)]
	private Entity FocusTarget;

	// Token: 0x04001979 RID: 6521
	private string FocusTargetSocketName = "";

	// Token: 0x0400197A RID: 6522
	private bool IsUniqueFade;

	// Token: 0x0400197B RID: 6523
	private bool FadeInTriggered;

	// Token: 0x0400197C RID: 6524
	private float ConfigFadeInDuration = 10f;

	// Token: 0x0400197D RID: 6525
	[Nullable(2)]
	private CurveBase ConfigFadeInCurve;

	// Token: 0x0400197E RID: 6526
	private bool FadeOutTriggered;

	// Token: 0x0400197F RID: 6527
	private float ConfigFadeOutDuration = 10f;

	// Token: 0x04001980 RID: 6528
	[Nullable(2)]
	private CurveBase ConfigFadeOutCurve;

	// Token: 0x04001981 RID: 6529
	public bool AutoCamera = true;

	// Token: 0x04001982 RID: 6530
	public bool AdjustCamera = true;

	// Token: 0x04001983 RID: 6531
	public bool ModifyCamera = true;

	// Token: 0x04001984 RID: 6532
	public bool FocusCamera = true;

	// Token: 0x04001985 RID: 6533
	public bool SidestepCamera = true;

	// Token: 0x04001986 RID: 6534
	public bool ClimbCamera = true;

	// Token: 0x04001987 RID: 6535
	private bool HasChangedConfig = true;

	// Token: 0x04001989 RID: 6537
	[TupleElementNames(new string[]
	{
		"Value",
		"IsEffect"
	})]
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1,
		0
	})]
	public Dictionary<CameraConfig, Dictionary<string, ValueTuple<float, bool>>> DebugSubCameraModifications;
}
