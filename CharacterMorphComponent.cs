using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Input.Blueprints;
using AkiClient.Game.Aki.Data.Entity.Struct;
using AkiClient.Game.Aki.Data.Fight.Struct;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using UnrealEngine;

// Token: 0x020030C5 RID: 12485
[NullableContext(1)]
[Nullable(0)]
public class CharacterMorphComponent : EntityComponent
{
	// Token: 0x06019BC1 RID: 105409 RVA: 0x0077CA05 File Offset: 0x0077AC05
	[NullableContext(2)]
	protected override bool OnInitData(IEntityArgs args = null)
	{
		return true;
	}

	// Token: 0x06019BC2 RID: 105410 RVA: 0x0077CA08 File Offset: 0x0077AC08
	protected override bool OnStart()
	{
		this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
		this.RolePreloadComp = base.Entity.GetComponent<RolePreloadComponent>();
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		this.MoveComp = base.Entity.GetComponent<CharacterMoveComponent>();
		this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
		this.CharacterAnimationComp = base.Entity.GetComponent<CharacterAnimationComponent>();
		this.CharacterFloatingComp = base.Entity.GetComponent<CharacterFloatingComponent>();
		this.InitMorphData();
		if (this.IsEnableMorphInternal)
		{
			if (this.TagComp != null)
			{
				this.MorphTagListenTask = this.TagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.角色形态.变装变身形态1"]), new BaseTagComponent.TTagSwitchedCallback(this.OnMorphTagChanged), null);
			}
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null && actorComp.IsRoleAndCtrlByMe)
			{
				this.LoadBpInputComp();
			}
			this.TempVector = Vector.Create();
		}
		return true;
	}

	// Token: 0x06019BC3 RID: 105411 RVA: 0x0077CAFC File Offset: 0x0077ACFC
	protected override bool OnEnd()
	{
		if (this.IsEnableMorphInternal)
		{
			if (this.MorphType != EMorphType.默认形态)
			{
				UDataTable morphCameraConfig = this.GetMorphCameraConfig(null);
				if (morphCameraConfig != null)
				{
					ControllerBase<CameraController>.Instance.UnloadCharacterCameraConfig(morphCameraConfig, "MainCamera");
				}
			}
			ITagTask morphTagListenTask = this.MorphTagListenTask;
			if (morphTagListenTask != null)
			{
				morphTagListenTask.EndTask();
			}
			this.MorphTagListenTask = null;
			this.MorphDataMap = null;
			this.MorphModelIdMap = null;
			this.MorphAssetMap = null;
			this.MorphMontageMapByName = null;
			this.MorphMontagePathMapByName = null;
			this.MorphMontagePathMap = null;
			this.BpInputComp = null;
			this.IsLoadingBpInputComp = false;
			this.TempVector = null;
			this.IsEnableMorphInternal = false;
		}
		return true;
	}

	// Token: 0x06019BC4 RID: 105412 RVA: 0x0077CB9E File Offset: 0x0077AD9E
	private void OnMorphTagChanged(int tagId, bool tagExist)
	{
		if (tagExist)
		{
			this.SetMorphType(EMorphType.变身形态);
			return;
		}
		this.SetMorphType(EMorphType.默认形态);
	}

	// Token: 0x06019BC5 RID: 105413 RVA: 0x0077CBB4 File Offset: 0x0077ADB4
	private unsafe void InitMorphData()
	{
		this.InitModelIdMap();
		if (this.MorphModelIdMap == null)
		{
			return;
		}
		RolePreloadComponent rolePreloadComp = this.RolePreloadComp;
		TMap<TEnumAsByte<EMorphType>, SCharacterMorphInfo> tmap;
		if (rolePreloadComp == null)
		{
			tmap = null;
		}
		else
		{
			SCharacterFightInfo fightInfo = rolePreloadComp.GetFightInfo();
			tmap = ((fightInfo != null) ? fightInfo.MorphModelInfoMap : null);
		}
		TMap<TEnumAsByte<EMorphType>, SCharacterMorphInfo> tmap2 = tmap;
		Dictionary<EMorphType, IMorphData> dictionary = new Dictionary<EMorphType, IMorphData>();
		foreach (KeyValuePair<EMorphType, int> keyValuePair in this.MorphModelIdMap)
		{
			EMorphType key = keyValuePair.Key;
			int value = keyValuePair.Value;
			if (value == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.WWJ;
				string message = "[CharacterMorphComponent]初始化获取ModelId有误";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ModelId", value);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MorphType", key);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				dictionary[key] = new MorphData
				{
					ModelId = 0
				};
			}
			else
			{
				SModelConfig modelConfig = ModelUtil.GetModelConfig(value);
				SCharacterMorphInfo scharacterMorphInfo = (tmap2 != null) ? tmap2.GetValueOrDefault(key) : null;
				MorphData morphData = new MorphData
				{
					ModelId = value,
					SkeletalMesh = Singleton<ResourceSystem>.Instance.GetLoadedAsset<USkeletalMesh>(modelConfig.网格体.ToAssetPathName()),
					AnimClass = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UClass>(modelConfig.动画蓝图.ToAssetPathName()),
					ComponentFloatParams = new Dictionary<string, Dictionary<string, float>>(),
					ComponentVectorParams = new Dictionary<string, Dictionary<string, Vector>>(),
					ComponentStringParams = new Dictionary<string, Dictionary<string, string>>()
				};
				if (key == EMorphType.变身形态)
				{
					morphData.DtBaseMovementSetting = ((scharacterMorphInfo != null) ? scharacterMorphInfo.DtBaseMovementSetting : null);
					morphData.DtCameraConfig = ((scharacterMorphInfo != null) ? scharacterMorphInfo.DtCameraConfig : null);
					morphData.InputComponentClass = ((scharacterMorphInfo != null) ? scharacterMorphInfo.InputComponentClass : null);
					this.InitComponentFloatParams(morphData, (scharacterMorphInfo != null) ? scharacterMorphInfo.ComponentFloatParams : null);
					this.InitComponentVectorParams(morphData, (scharacterMorphInfo != null) ? scharacterMorphInfo.ComponentVectorParams : null);
					this.InitComponentStringParams(morphData, (scharacterMorphInfo != null) ? scharacterMorphInfo.ComponentStringParams : null);
				}
				if (morphData.SkeletalMesh == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Battle;
					ELogAuthor author2 = ELogAuthor.WWJ;
					string message2 = "[CharacterMorphComponent]初始化资源有误";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("ModelId", value);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("MorphType", key);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("SkeletalMeshPath", modelConfig.网格体.ToAssetPathName());
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				}
				if (morphData.AnimClass == null)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Battle;
					ELogAuthor author3 = ELogAuthor.WWJ;
					string message3 = "[CharacterMorphComponent]初始化资源有误";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("ModelId", value);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("MorphType", key);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("AnimClassPath", modelConfig.动画蓝图.ToAssetPathName());
					instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
				}
				dictionary[key] = morphData;
			}
		}
		this.MorphDataMap = dictionary;
		this.IsEnableMorphInternal = (dictionary.Count != 0);
	}

	// Token: 0x06019BC6 RID: 105414 RVA: 0x0077CF24 File Offset: 0x0077B124
	private void InitModelIdMap()
	{
		if (this.MorphModelIdMap != null)
		{
			return;
		}
		RolePreloadComponent rolePreloadComp = this.RolePreloadComp;
		TMap<TEnumAsByte<EMorphType>, SCharacterMorphInfo> tmap;
		if (rolePreloadComp == null)
		{
			tmap = null;
		}
		else
		{
			SCharacterFightInfo fightInfo = rolePreloadComp.GetFightInfo();
			tmap = ((fightInfo != null) ? fightInfo.MorphModelInfoMap : null);
		}
		TMap<TEnumAsByte<EMorphType>, SCharacterMorphInfo> tmap2 = tmap;
		if (tmap2 != null && tmap2.Num() > 0)
		{
			Dictionary<EMorphType, int> dictionary = new Dictionary<EMorphType, int>();
			foreach (KeyValuePair<TEnumAsByte<EMorphType>, SCharacterMorphInfo> keyValuePair in tmap2)
			{
				TEnumAsByte<EMorphType> tenumAsByte;
				SCharacterMorphInfo scharacterMorphInfo;
				keyValuePair.Deconstruct(out tenumAsByte, out scharacterMorphInfo);
				TEnumAsByte<EMorphType> tenumAsByte2 = tenumAsByte;
				SCharacterMorphInfo scharacterMorphInfo2 = scharacterMorphInfo;
				if (!(tenumAsByte2 == EMorphType.默认形态) && scharacterMorphInfo2.ModelId != 0)
				{
					dictionary[tenumAsByte2] = scharacterMorphInfo2.ModelId;
				}
			}
			if (dictionary.Count > 0)
			{
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				int num = (creatureDataComp != null) ? creatureDataComp.GetModelId() : 0;
				if (num != 0)
				{
					dictionary[EMorphType.默认形态] = num;
					this.MorphModelIdMap = dictionary;
				}
			}
		}
	}

	// Token: 0x06019BC7 RID: 105415 RVA: 0x0077D014 File Offset: 0x0077B214
	private void InitComponentFloatParams(IMorphData morphData, [Nullable(new byte[]
	{
		2,
		1
	})] TMap<string, float> componentFloatParams)
	{
		if (componentFloatParams == null)
		{
			return;
		}
		Dictionary<string, Dictionary<string, float>> componentFloatParams2 = morphData.ComponentFloatParams;
		foreach (KeyValuePair<string, float> keyValuePair in componentFloatParams)
		{
			string text;
			float num;
			keyValuePair.Deconstruct(out text, out num);
			string text2 = text;
			float value = num;
			string[] array = text2.Split('.', StringSplitOptions.None);
			if (array.Length >= 2)
			{
				if (array.Length > 2 && array[1] == "可变胶囊体碰撞")
				{
					array = CharacterMorphComponent.ProcessAdjustableCapsuleParamName(array);
				}
				string key = array[0];
				string key2 = array[1];
				Dictionary<string, float> dictionary;
				if (!componentFloatParams2.TryGetValue(key, out dictionary))
				{
					dictionary = (componentFloatParams2[key] = new Dictionary<string, float>());
				}
				dictionary[key2] = value;
			}
		}
	}

	// Token: 0x06019BC8 RID: 105416 RVA: 0x0077D0D8 File Offset: 0x0077B2D8
	private void InitComponentVectorParams(IMorphData morphData, [Nullable(new byte[]
	{
		2,
		1
	})] TMap<string, FVector> componentVectorParams)
	{
		if (componentVectorParams == null)
		{
			return;
		}
		Dictionary<string, Dictionary<string, Vector>> componentVectorParams2 = morphData.ComponentVectorParams;
		foreach (KeyValuePair<string, FVector> keyValuePair in componentVectorParams)
		{
			string text;
			FVector fvector;
			keyValuePair.Deconstruct(out text, out fvector);
			string text2 = text;
			FVector fvector2 = fvector;
			string[] array = text2.Split('.', StringSplitOptions.None);
			if (array.Length >= 2)
			{
				string key = array[0];
				string key2 = array[1];
				Dictionary<string, Vector> dictionary;
				if (!componentVectorParams2.TryGetValue(key, out dictionary))
				{
					dictionary = (componentVectorParams2[key] = new Dictionary<string, Vector>());
				}
				Vector vector = Vector.Create();
				vector.FromUeVector(fvector2);
				dictionary[key2] = vector;
			}
		}
	}

	// Token: 0x06019BC9 RID: 105417 RVA: 0x0077D188 File Offset: 0x0077B388
	private void InitComponentStringParams(IMorphData morphData, [Nullable(new byte[]
	{
		2,
		1,
		1
	})] TMap<string, string> componentStringParams)
	{
		if (componentStringParams == null)
		{
			return;
		}
		Dictionary<string, Dictionary<string, string>> componentStringParams2 = morphData.ComponentStringParams;
		foreach (KeyValuePair<string, string> keyValuePair in componentStringParams)
		{
			string text;
			string text2;
			keyValuePair.Deconstruct(out text, out text2);
			string text3 = text;
			string text4 = text2;
			string[] array = text3.Split('.', StringSplitOptions.None);
			if (text4 != null && array.Length >= 2)
			{
				if (array.Length > 2 && array[1] == "可变胶囊体碰撞")
				{
					array = CharacterMorphComponent.ProcessAdjustableCapsuleParamName(array);
				}
				string key = array[0];
				string key2 = array[1];
				Dictionary<string, string> dictionary;
				if (!componentStringParams2.TryGetValue(key, out dictionary))
				{
					dictionary = (componentStringParams2[key] = new Dictionary<string, string>());
				}
				dictionary[key2] = text4;
			}
		}
	}

	// Token: 0x06019BCA RID: 105418 RVA: 0x0077D250 File Offset: 0x0077B450
	private static string[] ProcessAdjustableCapsuleParamName(string[] sp)
	{
		string text = sp[0] + "#" + sp[1];
		string text2 = "";
		for (int i = 2; i < sp.Length; i++)
		{
			if (i > 2)
			{
				text2 += "#";
			}
			text2 += sp[i];
		}
		return new string[]
		{
			text,
			text2
		};
	}

	// Token: 0x06019BCB RID: 105419 RVA: 0x0077D2AC File Offset: 0x0077B4AC
	[return: Nullable(2)]
	private static UKuroAdjustableCapsuleComponent FindAdjustableCapsuleByName(string capsuleName, USkeletalMeshComponent mesh)
	{
		AActor owner = mesh.GetOwner();
		if (owner == null)
		{
			return null;
		}
		TArray<UActorComponent> tarray = owner.K2_GetComponentsByClass(UKuroAdjustableCapsuleComponent.StaticClass());
		for (int i = 0; i < tarray.Num(); i++)
		{
			UKuroAdjustableCapsuleComponent ukuroAdjustableCapsuleComponent = tarray.Get(i) as UKuroAdjustableCapsuleComponent;
			string a = (ukuroAdjustableCapsuleComponent != null) ? ukuroAdjustableCapsuleComponent.GetName() : null;
			if (ukuroAdjustableCapsuleComponent != null && a == capsuleName)
			{
				return ukuroAdjustableCapsuleComponent;
			}
		}
		return null;
	}

	// Token: 0x06019BCC RID: 105420 RVA: 0x0077D312 File Offset: 0x0077B512
	public EMorphType GetMorphType()
	{
		return this.MorphType;
	}

	// Token: 0x06019BCD RID: 105421 RVA: 0x0077D31C File Offset: 0x0077B51C
	[NullableContext(2)]
	public IMorphData GetMorphData(EMorphType? morphType = null)
	{
		if (morphType == null)
		{
			return this.MorphData;
		}
		IMorphData result;
		if (this.MorphDataMap != null && this.MorphDataMap.TryGetValue(morphType.Value, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06019BCE RID: 105422 RVA: 0x0077D35C File Offset: 0x0077B55C
	[NullableContext(2)]
	public UDataTable GetMorphCameraConfig(EMorphType? morphType = null)
	{
		EMorphType value = morphType ?? this.MorphType;
		IMorphData morphData = this.GetMorphData(new EMorphType?(value));
		string text;
		if (morphData == null)
		{
			text = null;
		}
		else
		{
			TSoftObjectPtr<UDataTable> dtCameraConfig = morphData.DtCameraConfig;
			text = ((dtCameraConfig != null) ? dtCameraConfig.ToAssetPathName() : null);
		}
		string text2 = text ?? "";
		UDataTable udataTable = null;
		if (!string.IsNullOrEmpty(text2) && text2 != "None")
		{
			udataTable = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UDataTable>(text2);
			if (udataTable == null || !udataTable.IsValid())
			{
				return null;
			}
		}
		return udataTable;
	}

	// Token: 0x06019BCF RID: 105423 RVA: 0x0077D3E9 File Offset: 0x0077B5E9
	[NullableContext(2)]
	public BP_InputBase_C GetMorphBpInputComp()
	{
		return this.BpInputComp;
	}

	// Token: 0x06019BD0 RID: 105424 RVA: 0x0077D3F1 File Offset: 0x0077B5F1
	private bool IsValidMorphType(EMorphType morphType)
	{
		return morphType < EMorphType.EMorphType_MAX;
	}

	// Token: 0x06019BD1 RID: 105425 RVA: 0x0077D3F7 File Offset: 0x0077B5F7
	public bool IsEnableMorph()
	{
		return this.IsEnableMorphInternal;
	}

	// Token: 0x06019BD2 RID: 105426 RVA: 0x0077D3FF File Offset: 0x0077B5FF
	public bool IsMorphing()
	{
		return this.MorphType > EMorphType.默认形态;
	}

	// Token: 0x06019BD3 RID: 105427 RVA: 0x0077D40C File Offset: 0x0077B60C
	public bool HasComponentFloatParam(EMorphType morphType, string compName, string paramName)
	{
		IMorphData morphData = this.GetMorphData(new EMorphType?(morphType));
		Dictionary<string, float> dictionary;
		float num;
		return morphData != null && morphData.ComponentFloatParams != null && morphData.ComponentFloatParams.TryGetValue(compName, out dictionary) && dictionary != null && dictionary.TryGetValue(paramName, out num);
	}

	// Token: 0x06019BD4 RID: 105428 RVA: 0x0077D458 File Offset: 0x0077B658
	public void SetComponentFloatParam(EMorphType morphType, string compName, string paramName, float value)
	{
		IMorphData morphData = this.GetMorphData(new EMorphType?(morphType));
		if (morphData == null)
		{
			return;
		}
		Dictionary<string, Dictionary<string, float>> componentFloatParams = morphData.ComponentFloatParams;
		if (componentFloatParams == null)
		{
			return;
		}
		Dictionary<string, float> dictionary;
		if (!componentFloatParams.TryGetValue(compName, out dictionary) || dictionary == null)
		{
			dictionary = new Dictionary<string, float>();
			componentFloatParams[compName] = dictionary;
		}
		dictionary[paramName] = value;
	}

	// Token: 0x06019BD5 RID: 105429 RVA: 0x0077D4A8 File Offset: 0x0077B6A8
	public bool HasComponentVectorParam(EMorphType morphType, string compName, string paramName)
	{
		IMorphData morphData = this.GetMorphData(new EMorphType?(morphType));
		Dictionary<string, Vector> dictionary;
		Vector vector;
		return morphData != null && morphData.ComponentVectorParams != null && morphData.ComponentVectorParams.TryGetValue(compName, out dictionary) && dictionary != null && dictionary.TryGetValue(paramName, out vector);
	}

	// Token: 0x06019BD6 RID: 105430 RVA: 0x0077D4F4 File Offset: 0x0077B6F4
	public void SetComponentVectorParam(EMorphType morphType, string compName, string paramName, Vector value)
	{
		IMorphData morphData = this.GetMorphData(new EMorphType?(morphType));
		if (morphData == null)
		{
			return;
		}
		Dictionary<string, Dictionary<string, Vector>> componentVectorParams = morphData.ComponentVectorParams;
		if (componentVectorParams == null)
		{
			return;
		}
		Dictionary<string, Vector> dictionary;
		if (!componentVectorParams.TryGetValue(compName, out dictionary) || dictionary == null)
		{
			dictionary = new Dictionary<string, Vector>();
			componentVectorParams[compName] = dictionary;
		}
		dictionary[paramName] = value;
	}

	// Token: 0x06019BD7 RID: 105431 RVA: 0x0077D544 File Offset: 0x0077B744
	public bool HasComponentStringParam(EMorphType morphType, string compName, string paramName)
	{
		IMorphData morphData = this.GetMorphData(new EMorphType?(morphType));
		Dictionary<string, string> dictionary;
		string text;
		return morphData != null && morphData.ComponentStringParams != null && morphData.ComponentStringParams.TryGetValue(compName, out dictionary) && dictionary != null && dictionary.TryGetValue(paramName, out text);
	}

	// Token: 0x06019BD8 RID: 105432 RVA: 0x0077D590 File Offset: 0x0077B790
	public void SetComponentStringParam(EMorphType morphType, string compName, string paramName, string value)
	{
		IMorphData morphData = this.GetMorphData(new EMorphType?(morphType));
		if (morphData == null)
		{
			return;
		}
		Dictionary<string, Dictionary<string, string>> componentStringParams = morphData.ComponentStringParams;
		if (componentStringParams == null)
		{
			return;
		}
		Dictionary<string, string> dictionary;
		if (!componentStringParams.TryGetValue(compName, out dictionary) || dictionary == null)
		{
			dictionary = new Dictionary<string, string>();
			componentStringParams[compName] = dictionary;
		}
		dictionary[paramName] = value;
	}

	// Token: 0x06019BD9 RID: 105433 RVA: 0x0077D5DE File Offset: 0x0077B7DE
	public void SetAssetElement(EMorphType morphType, AssetElement assetElement)
	{
		if (this.MorphAssetMap == null)
		{
			this.MorphAssetMap = new Dictionary<EMorphType, AssetElement>();
		}
		this.MorphAssetMap[morphType] = assetElement;
	}

	// Token: 0x06019BDA RID: 105434 RVA: 0x0077D600 File Offset: 0x0077B800
	public void AddMontage(string name, UAnimMontage montage, string path)
	{
		Dictionary<string, EMorphType> morphMontagePathMap = this.MorphMontagePathMap;
		EMorphType? emorphType = (morphMontagePathMap != null) ? new EMorphType?(morphMontagePathMap.GetValueOrDefault(path)) : null;
		if (emorphType != null)
		{
			EMorphType? emorphType2 = emorphType;
			EMorphType emorphType3 = EMorphType.默认形态;
			if (!(emorphType2.GetValueOrDefault() == emorphType3 & emorphType2 != null))
			{
				if (this.MorphMontageMapByName == null)
				{
					this.MorphMontageMapByName = new Dictionary<EMorphType, Dictionary<string, UAnimMontage>>();
				}
				Dictionary<string, UAnimMontage> dictionary;
				if (!this.MorphMontageMapByName.TryGetValue(emorphType.Value, out dictionary) || dictionary == null)
				{
					dictionary = new Dictionary<string, UAnimMontage>();
					this.MorphMontageMapByName[emorphType.Value] = dictionary;
				}
				dictionary[name] = montage;
				if (this.MorphMontagePathMapByName == null)
				{
					this.MorphMontagePathMapByName = new Dictionary<EMorphType, Dictionary<string, string>>();
				}
				Dictionary<string, string> dictionary2;
				if (!this.MorphMontagePathMapByName.TryGetValue(emorphType.Value, out dictionary2) || dictionary2 == null)
				{
					dictionary2 = new Dictionary<string, string>();
					this.MorphMontagePathMapByName[emorphType.Value] = dictionary2;
				}
				dictionary2[name] = path;
				return;
			}
		}
	}

	// Token: 0x06019BDB RID: 105435 RVA: 0x0077D6EC File Offset: 0x0077B8EC
	public void AddMorphMontagePath(string path, EMorphType morphType)
	{
		if (this.MorphMontagePathMap == null)
		{
			this.MorphMontagePathMap = new Dictionary<string, EMorphType>();
		}
		this.MorphMontagePathMap[path] = morphType;
	}

	// Token: 0x06019BDC RID: 105436 RVA: 0x0077D70E File Offset: 0x0077B90E
	public void SetMontageSubPathMorphType(string name, EMorphType morphType)
	{
		if (this.SubPathNameMorphTypeMap == null)
		{
			this.SubPathNameMorphTypeMap = new Dictionary<string, EMorphType>();
		}
		this.SubPathNameMorphTypeMap[name] = morphType;
	}

	// Token: 0x06019BDD RID: 105437 RVA: 0x0077D730 File Offset: 0x0077B930
	public EMorphType GetMontagePathMorphType(string path)
	{
		if (this.SubPathNameMorphTypeMap != null)
		{
			foreach (KeyValuePair<string, EMorphType> keyValuePair in this.SubPathNameMorphTypeMap)
			{
				if (path.Contains(keyValuePair.Key))
				{
					return keyValuePair.Value;
				}
			}
			return EMorphType.默认形态;
		}
		return EMorphType.默认形态;
	}

	// Token: 0x06019BDE RID: 105438 RVA: 0x0077D7A0 File Offset: 0x0077B9A0
	[return: Nullable(2)]
	public UAnimMontage GetMontageByName(string name)
	{
		if (this.MorphMontageMapByName == null)
		{
			return null;
		}
		Dictionary<string, UAnimMontage> dictionary;
		if (!this.MorphMontageMapByName.TryGetValue(this.MorphType, out dictionary) || dictionary == null)
		{
			return null;
		}
		UAnimMontage result;
		if (!dictionary.TryGetValue(name, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06019BDF RID: 105439 RVA: 0x0077D7E0 File Offset: 0x0077B9E0
	[return: Nullable(2)]
	public string GetMontagePathByName(string name)
	{
		if (this.MorphMontagePathMapByName == null)
		{
			return null;
		}
		Dictionary<string, string> dictionary;
		if (!this.MorphMontagePathMapByName.TryGetValue(this.MorphType, out dictionary) || dictionary == null)
		{
			return null;
		}
		string result;
		if (!dictionary.TryGetValue(name, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06019BE0 RID: 105440 RVA: 0x0077D820 File Offset: 0x0077BA20
	public FVectorDouble? GetCenterActorLocationOffset()
	{
		if (this.IsMorphing() && this.CenterActorLocationOffset != null)
		{
			return new FVectorDouble?(this.CenterActorLocationOffset.ToUeVector(false));
		}
		return null;
	}

	// Token: 0x06019BE1 RID: 105441 RVA: 0x0077D858 File Offset: 0x0077BA58
	public unsafe void SetMorphType(EMorphType morphType)
	{
		if (morphType == this.MorphType)
		{
			return;
		}
		if (!this.IsValidMorphType(morphType))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.WWJ;
			string message = "[CharacterMorphComponent]设置了无效的形态类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MorphType", morphType);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Dictionary<EMorphType, IMorphData> morphDataMap = this.MorphDataMap;
		IMorphData morphData = (morphDataMap != null) ? morphDataMap.GetValueOrDefault(morphType) : null;
		if (morphData == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Battle;
			ELogAuthor author2 = ELogAuthor.WWJ;
			string message2 = "[CharacterMorphComponent]设置形态失败, 无对应形态数据";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("MorphType", morphType);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		if (morphData.SkeletalMesh == null || morphData.AnimClass == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Battle;
			ELogAuthor author3 = ELogAuthor.WWJ;
			string message3 = "[CharacterMorphComponent]设置形态失败, 对应形态数据有误";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MorphType", morphType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SkeletalMesh", morphData.SkeletalMesh);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("AnimClass", morphData.AnimClass);
			instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		this.SetBpCompParamsBackup();
		CombatLog instance4 = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
		Entity entity = base.Entity;
		string message4 = "设置形态成功, 开始切换";
		ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("MorphType", morphType);
		instance4.Info(flag, entity, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
		EMorphType morphType2 = this.MorphType;
		this.MorphType = morphType;
		this.MorphData = morphData;
		Singleton<EventSystem>.Instance.EmitWithTarget<Entity, EMorphType, EMorphType>(base.Entity, EEventName.OnBeforeCharacterMorphTypeChanged, base.Entity, morphType, morphType2);
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.ChangeMeshAnim(morphData.SkeletalMesh, morphData.AnimClass);
		}
		CreatureDataComponent creatureDataComp = this.CreatureDataComp;
		if (creatureDataComp != null)
		{
			creatureDataComp.SetModelConfig(morphData.ModelId);
		}
		CharacterActorComponent actorComp2 = this.ActorComp;
		if (actorComp2 != null)
		{
			actorComp2.UpdateModelResPath();
		}
		this.UpdateMovementData();
		this.UpdateMoveComp();
		this.UpdateCapsuleComp();
		this.UpdateCameraConfig();
		this.UpdateMeshComp();
		this.UpdateAdjustableCapsule();
		Singleton<EventSystem>.Instance.Emit<Entity, EMorphType, EMorphType>(EEventName.OnCharacterMorphTypeChanged, base.Entity, morphType, morphType2);
		Singleton<EventSystem>.Instance.EmitWithTarget<Entity, EMorphType, EMorphType>(base.Entity, EEventName.OnCharacterMorphTypeChanged, base.Entity, morphType, morphType2);
	}

	// Token: 0x06019BE2 RID: 105442 RVA: 0x0077DA80 File Offset: 0x0077BC80
	private void UpdateMovementData()
	{
		if (this.MoveComp == null)
		{
			return;
		}
		UDataTable udataTable;
		if (this.MorphType == EMorphType.默认形态)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			udataTable = ((actorComp != null) ? actorComp.Actor.DtBaseMovementSetting : null);
		}
		else
		{
			IMorphData morphData = this.MorphData;
			UDataTable udataTable2;
			if (morphData == null)
			{
				udataTable2 = null;
			}
			else
			{
				TSoftObjectPtr<UDataTable> dtBaseMovementSetting = morphData.DtBaseMovementSetting;
				udataTable2 = ((dtBaseMovementSetting != null) ? dtBaseMovementSetting.Get() : null);
			}
			udataTable = udataTable2;
		}
		if (udataTable != null)
		{
			SMovementSetting_State dataTableRow = DataTableUtil.GetDataTableRow<SMovementSetting_State>(udataTable, Singleton<CharacterNameDefines>.Instance.NORMAL.ToString());
			if (dataTableRow != null)
			{
				this.MoveComp.SetMovementData(dataTableRow, true);
			}
		}
	}

	// Token: 0x06019BE3 RID: 105443 RVA: 0x0077DB10 File Offset: 0x0077BD10
	private void UpdateMoveComp()
	{
		CharacterMoveComponent moveComp = this.MoveComp;
		if (moveComp == null)
		{
			return;
		}
		IMorphData morphData = this.MorphData;
		object obj;
		if (morphData == null)
		{
			obj = null;
		}
		else
		{
			Dictionary<string, Dictionary<string, float>> componentFloatParams = morphData.ComponentFloatParams;
			obj = ((componentFloatParams != null) ? componentFloatParams.GetValueOrDefault("角色移动") : null);
		}
		object obj2 = obj;
		float? num = (obj2 != null) ? new float?(obj2.GetValueOrDefault("最大步高")) : null;
		float? num2 = (obj2 != null) ? new float?(obj2.GetValueOrDefault("可行走地面角度")) : null;
		float? num3 = (obj2 != null) ? new float?(obj2.GetValueOrDefault("维持水平地面速度")) : null;
		float? num4 = (obj2 != null) ? new float?(obj2.GetValueOrDefault("默认水中运动模式")) : null;
		if (this.MorphType != EMorphType.默认形态)
		{
			if (num != null)
			{
				moveComp.SetStepHeight(num.Value);
			}
			if (num2 != null)
			{
				moveComp.SetWalkableFloorAngle(num2.Value);
			}
		}
		else
		{
			moveComp.ResetStepHeight();
			moveComp.ResetWalkableFloorAngle();
		}
		UCharacterMovementComponent characterMovement = moveComp.CharacterMovement;
		if (characterMovement != null)
		{
			if (num3 != null)
			{
				characterMovement.bMaintainHorizontalGroundVelocity = (num3.Value != 0f);
			}
			if (num4 != null)
			{
				characterMovement.DefaultWaterMovementMode = (EMovementMode)((byte)num4.Value);
			}
		}
	}

	// Token: 0x06019BE4 RID: 105444 RVA: 0x0077DC5C File Offset: 0x0077BE5C
	private void UpdateMeshComp()
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (((actorComp != null) ? actorComp.Actor.Mesh : null) == null)
		{
			return;
		}
		IMorphData morphData = this.MorphData;
		if (morphData == null)
		{
			return;
		}
		if (morphData.ComponentVectorParams == null)
		{
			return;
		}
		Dictionary<string, Vector> dictionary;
		if (!morphData.ComponentVectorParams.TryGetValue("网格体", out dictionary) || dictionary == null)
		{
			return;
		}
		Vector vector;
		if (dictionary.TryGetValue("位置", out vector) && vector != null)
		{
			CharacterAnimationComponent characterAnimationComp = this.CharacterAnimationComp;
			if (characterAnimationComp == null)
			{
				return;
			}
			characterAnimationComp.SetOriginLocation(vector);
		}
	}

	// Token: 0x06019BE5 RID: 105445 RVA: 0x0077DCD4 File Offset: 0x0077BED4
	[return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Dictionary<string, Dictionary<string, float>> ParseAdjustableCapsuleParams([Nullable(new byte[]
	{
		2,
		1
	})] Dictionary<string, float> capsuleParams)
	{
		if (capsuleParams == null)
		{
			return null;
		}
		Dictionary<string, Dictionary<string, float>> dictionary = new Dictionary<string, Dictionary<string, float>>();
		foreach (KeyValuePair<string, float> keyValuePair in capsuleParams)
		{
			string key = keyValuePair.Key;
			float value = keyValuePair.Value;
			string[] array = key.Split('#', StringSplitOptions.None);
			if (array.Length >= 2)
			{
				string key2 = array[0];
				string key3 = array[1];
				Dictionary<string, float> dictionary2;
				if (!dictionary.TryGetValue(key2, out dictionary2) || dictionary2 == null)
				{
					dictionary2 = new Dictionary<string, float>();
					dictionary[key2] = dictionary2;
				}
				dictionary2[key3] = value;
			}
		}
		return dictionary;
	}

	// Token: 0x06019BE6 RID: 105446 RVA: 0x0077DD80 File Offset: 0x0077BF80
	[return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1,
		1
	})]
	private Dictionary<string, Dictionary<string, string>> ParseAdjustableCapsuleStringParams([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> capsuleParams)
	{
		if (capsuleParams == null)
		{
			return null;
		}
		Dictionary<string, Dictionary<string, string>> dictionary = new Dictionary<string, Dictionary<string, string>>();
		foreach (KeyValuePair<string, string> keyValuePair in capsuleParams)
		{
			string key = keyValuePair.Key;
			string value = keyValuePair.Value;
			string[] array = key.Split('#', StringSplitOptions.None);
			if (array.Length >= 2)
			{
				string key2 = array[0];
				string key3 = array[1];
				Dictionary<string, string> dictionary2;
				if (!dictionary.TryGetValue(key2, out dictionary2) || dictionary2 == null)
				{
					dictionary2 = new Dictionary<string, string>();
					dictionary[key2] = dictionary2;
				}
				dictionary2[key3] = value;
			}
		}
		return dictionary;
	}

	// Token: 0x06019BE7 RID: 105447 RVA: 0x0077DE2C File Offset: 0x0077C02C
	private static string[] ParseSocketNamesString(string value)
	{
		string text = value.Trim();
		if (text.StartsWith("["))
		{
			text = text.Substring(1);
		}
		if (text.EndsWith("]"))
		{
			text = text.Substring(0, text.Length - 1);
		}
		if (text.Length == 0)
		{
			return Array.Empty<string>();
		}
		List<string> list = new List<string>();
		string[] array = text.Split(',', StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			string text2 = array[i].Trim();
			if (text2.Length > 0)
			{
				list.Add(text2);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06019BE8 RID: 105448 RVA: 0x0077DEC0 File Offset: 0x0077C0C0
	private static void SetAdjustableCapsuleBindSocketNames(UKuroAdjustableCapsuleComponent adjustableCapsule, string[] socketNames)
	{
		TArray<FName> tarray = new TArray<FName>();
		foreach (string name in socketNames)
		{
			tarray.Add(new FName(name));
		}
		adjustableCapsule.BindSocketNames = tarray;
	}

	// Token: 0x06019BE9 RID: 105449 RVA: 0x0077DEFC File Offset: 0x0077C0FC
	private static string GetAdjustableCapsuleBindSocketNames(UKuroAdjustableCapsuleComponent adjustableCapsule)
	{
		TArray<FName> bindSocketNames = adjustableCapsule.BindSocketNames;
		List<string> list = new List<string>();
		for (int i = 0; i < bindSocketNames.Num(); i++)
		{
			list.Add(bindSocketNames.Get(i).ToString());
		}
		return "[" + string.Join(",", list) + "]";
	}

	// Token: 0x06019BEA RID: 105450 RVA: 0x0077DF5C File Offset: 0x0077C15C
	private void UpdateAdjustableCapsule()
	{
		CharacterActorComponent actorComp = this.ActorComp;
		USkeletalMeshComponent uskeletalMeshComponent = (actorComp != null) ? actorComp.Actor.Mesh : null;
		if (uskeletalMeshComponent == null)
		{
			return;
		}
		if (this.MorphType == EMorphType.默认形态)
		{
			Dictionary<string, Dictionary<string, float>> defaultAdjustableCapsuleParams = this.DefaultAdjustableCapsuleParams;
			if (defaultAdjustableCapsuleParams != null && defaultAdjustableCapsuleParams.Count > 0)
			{
				foreach (KeyValuePair<string, Dictionary<string, float>> keyValuePair in defaultAdjustableCapsuleParams)
				{
					string key = keyValuePair.Key;
					Dictionary<string, float> value = keyValuePair.Value;
					UKuroAdjustableCapsuleComponent ukuroAdjustableCapsuleComponent = CharacterMorphComponent.FindAdjustableCapsuleByName(key, uskeletalMeshComponent);
					if (ukuroAdjustableCapsuleComponent != null)
					{
						foreach (KeyValuePair<string, float> keyValuePair2 in value)
						{
							string key2 = keyValuePair2.Key;
							if (!(key2 == "AddRadius"))
							{
								if (!(key2 == "MinRadius"))
								{
									if (key2 == "MaxRadius")
									{
										ukuroAdjustableCapsuleComponent.MaxRadius = keyValuePair2.Value;
									}
								}
								else
								{
									ukuroAdjustableCapsuleComponent.MinRadius = keyValuePair2.Value;
								}
							}
							else
							{
								ukuroAdjustableCapsuleComponent.AddRadius = keyValuePair2.Value;
							}
						}
					}
				}
			}
			Dictionary<string, Dictionary<string, string>> defaultAdjustableCapsuleStringParams = this.DefaultAdjustableCapsuleStringParams;
			if (defaultAdjustableCapsuleStringParams == null || defaultAdjustableCapsuleStringParams.Count <= 0)
			{
				return;
			}
			using (Dictionary<string, Dictionary<string, string>>.Enumerator enumerator3 = defaultAdjustableCapsuleStringParams.GetEnumerator())
			{
				while (enumerator3.MoveNext())
				{
					KeyValuePair<string, Dictionary<string, string>> keyValuePair3 = enumerator3.Current;
					string key3 = keyValuePair3.Key;
					Dictionary<string, string> value2 = keyValuePair3.Value;
					UKuroAdjustableCapsuleComponent ukuroAdjustableCapsuleComponent2 = CharacterMorphComponent.FindAdjustableCapsuleByName(key3, uskeletalMeshComponent);
					if (ukuroAdjustableCapsuleComponent2 != null)
					{
						foreach (KeyValuePair<string, string> keyValuePair4 in value2)
						{
							if (keyValuePair4.Key == "BindSocketNames")
							{
								CharacterMorphComponent.SetAdjustableCapsuleBindSocketNames(ukuroAdjustableCapsuleComponent2, CharacterMorphComponent.ParseSocketNamesString(keyValuePair4.Value));
							}
						}
					}
				}
				return;
			}
		}
		if (this.MorphData == null)
		{
			return;
		}
		Dictionary<string, Dictionary<string, float>> componentFloatParams = this.MorphData.ComponentFloatParams;
		Dictionary<string, float> capsuleParams = (componentFloatParams != null) ? componentFloatParams.GetValueOrDefault("网格体#可变胶囊体碰撞") : null;
		Dictionary<string, Dictionary<string, float>> dictionary = this.ParseAdjustableCapsuleParams(capsuleParams);
		if (dictionary != null)
		{
			foreach (KeyValuePair<string, Dictionary<string, float>> keyValuePair5 in dictionary)
			{
				string key4 = keyValuePair5.Key;
				Dictionary<string, float> value3 = keyValuePair5.Value;
				UKuroAdjustableCapsuleComponent ukuroAdjustableCapsuleComponent3 = CharacterMorphComponent.FindAdjustableCapsuleByName(key4, uskeletalMeshComponent);
				if (ukuroAdjustableCapsuleComponent3 != null)
				{
					foreach (KeyValuePair<string, float> keyValuePair6 in value3)
					{
						string key2 = keyValuePair6.Key;
						if (!(key2 == "AddRadius"))
						{
							if (!(key2 == "MinRadius"))
							{
								if (key2 == "MaxRadius")
								{
									ukuroAdjustableCapsuleComponent3.MaxRadius = keyValuePair6.Value;
								}
							}
							else
							{
								ukuroAdjustableCapsuleComponent3.MinRadius = keyValuePair6.Value;
							}
						}
						else
						{
							ukuroAdjustableCapsuleComponent3.AddRadius = keyValuePair6.Value;
						}
					}
				}
			}
		}
		Dictionary<string, Dictionary<string, string>> componentStringParams = this.MorphData.ComponentStringParams;
		Dictionary<string, string> capsuleParams2 = (componentStringParams != null) ? componentStringParams.GetValueOrDefault("网格体#可变胶囊体碰撞") : null;
		Dictionary<string, Dictionary<string, string>> dictionary2 = this.ParseAdjustableCapsuleStringParams(capsuleParams2);
		if (dictionary2 != null)
		{
			foreach (KeyValuePair<string, Dictionary<string, string>> keyValuePair7 in dictionary2)
			{
				string key5 = keyValuePair7.Key;
				Dictionary<string, string> value4 = keyValuePair7.Value;
				UKuroAdjustableCapsuleComponent ukuroAdjustableCapsuleComponent4 = CharacterMorphComponent.FindAdjustableCapsuleByName(key5, uskeletalMeshComponent);
				if (ukuroAdjustableCapsuleComponent4 != null)
				{
					foreach (KeyValuePair<string, string> keyValuePair8 in value4)
					{
						if (keyValuePair8.Key == "BindSocketNames")
						{
							CharacterMorphComponent.SetAdjustableCapsuleBindSocketNames(ukuroAdjustableCapsuleComponent4, CharacterMorphComponent.ParseSocketNamesString(keyValuePair8.Value));
						}
					}
				}
			}
		}
	}

	// Token: 0x06019BEB RID: 105451 RVA: 0x0077E390 File Offset: 0x0077C590
	private void UpdateCapsuleComp()
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp == null)
		{
			return;
		}
		float num = 0f;
		bool isRoleAndCtrlByMe = actorComp.IsRoleAndCtrlByMe;
		if (this.MorphType == EMorphType.默认形态)
		{
			num = this.DefaultHalfHeightInternal - actorComp.HalfHeight;
			actorComp.SetDefaultRadiusAndHalfHeight(this.DefaultRadiusInternal, this.DefaultHalfHeightInternal);
			actorComp.SetRadiusAndHalfHeight(this.DefaultRadiusInternal, this.DefaultHalfHeightInternal, false, false);
			if (isRoleAndCtrlByMe)
			{
				ControllerBase<GameBudgetController>.Instance.SetCenterOffset(Vector.ZeroVectorDouble);
			}
		}
		else
		{
			IMorphData morphData = this.MorphData;
			object obj;
			if (morphData == null)
			{
				obj = null;
			}
			else
			{
				Dictionary<string, Dictionary<string, float>> componentFloatParams = morphData.ComponentFloatParams;
				obj = ((componentFloatParams != null) ? componentFloatParams.GetValueOrDefault("胶囊体组件") : null);
			}
			object obj2 = obj;
			float? num2 = (obj2 != null) ? new float?(obj2.GetValueOrDefault("胶囊体半高")) : null;
			float? num3 = (obj2 != null) ? new float?(obj2.GetValueOrDefault("胶囊体半径")) : null;
			if (num2 != null || num3 != null)
			{
				num2 = new float?(num2 ?? actorComp.HalfHeight);
				num3 = new float?(num3 ?? actorComp.Radius);
				if (num2.Value > 0f && num3.Value > 0f)
				{
					actorComp.SetRadiusAndHalfHeight(num3.Value, num2.Value, false, false);
					num = num2.Value - actorComp.DefaultHalfHeight;
					if (isRoleAndCtrlByMe)
					{
						float defaultHalfHeight = actorComp.DefaultHalfHeight;
						float defaultRadius = actorComp.DefaultRadius;
						if (defaultHalfHeight > 0f && defaultRadius > 0f)
						{
							if (this.CenterActorLocationOffset == null)
							{
								this.CenterActorLocationOffset = Vector.Create(0.0, 0.0, (double)(-(double)(num2.Value + num3.Value - defaultHalfHeight - defaultRadius)));
							}
							ControllerBase<GameBudgetController>.Instance.SetCenterOffset(this.CenterActorLocationOffset.ToUeVector(false));
						}
					}
					this.DefaultHalfHeightInternal = actorComp.DefaultHalfHeight;
					this.DefaultRadiusInternal = actorComp.DefaultRadius;
					actorComp.SetDefaultRadiusAndHalfHeight(num3.Value, num2.Value);
				}
			}
		}
		if (isRoleAndCtrlByMe)
		{
			CharacterFloatingComponent characterFloatingComp = this.CharacterFloatingComp;
			float num4 = (characterFloatingComp != null && characterFloatingComp.IsNearGround) ? (num - this.CharacterFloatingComp.NearGroundDist) : num;
			if (num4 != 0f)
			{
				UCharacterMovementComponent characterMovement = actorComp.Actor.CharacterMovement;
				TEnumAsByte<EMovementMode>? tenumAsByte = (characterMovement != null) ? new TEnumAsByte<EMovementMode>?(characterMovement.MovementMode) : null;
				UCharacterMovementComponent characterMovement2 = actorComp.Actor.CharacterMovement;
				byte? b = (characterMovement2 != null) ? new byte?(characterMovement2.CustomMovementMode) : null;
				if (!(tenumAsByte == EMovementMode.MOVE_Walking) && !(tenumAsByte == EMovementMode.MOVE_NavWalking) && !(tenumAsByte == EMovementMode.MOVE_None))
				{
					byte? b2 = b;
					if (((b2 != null) ? new int?((int)b2.GetValueOrDefault()) : null).GetValueOrDefault() != 15)
					{
						return;
					}
					CharacterFloatingComponent characterFloatingComp2 = this.CharacterFloatingComp;
					if (characterFloatingComp2 == null || !characterFloatingComp2.IsNearGround)
					{
						return;
					}
				}
				if (this.TempVector == null)
				{
					this.TempVector = Vector.Create();
				}
				Vector tempVector = this.TempVector;
				FVectorDouble actorLocation = actorComp.ActorLocation;
				tempVector.FromUeVector(actorLocation);
				this.TempVector.Z += (double)num4;
				actorComp.SetActorLocation(this.TempVector.ToUeVector(false), "角色形态改变修改胶囊体的位置修正优化", true);
			}
		}
	}

	// Token: 0x06019BEC RID: 105452 RVA: 0x0077E754 File Offset: 0x0077C954
	private void UpdateCameraConfig()
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.IsRoleAndCtrlByMe)
		{
			return;
		}
		CharacterActorComponent actorComp2 = this.ActorComp;
		UDataTable udataTable = (actorComp2 != null) ? actorComp2.Actor.DtCameraConfig : null;
		if (udataTable == null)
		{
			return;
		}
		UDataTable morphCameraConfig = this.GetMorphCameraConfig(null);
		if (morphCameraConfig == null)
		{
			return;
		}
		if (this.MorphType == EMorphType.默认形态)
		{
			ControllerBase<CameraController>.Instance.UnloadCharacterCameraConfig(morphCameraConfig, "MainCamera");
			ControllerBase<CameraController>.Instance.LoadCharacterCameraConfig(udataTable);
			return;
		}
		ControllerBase<CameraController>.Instance.UnloadCharacterCameraConfig(udataTable, "MainCamera");
		ControllerBase<CameraController>.Instance.LoadCharacterCameraConfig(morphCameraConfig);
	}

	// Token: 0x06019BED RID: 105453 RVA: 0x0077E7E8 File Offset: 0x0077C9E8
	private void SetBpCompParamsBackup()
	{
		if (this.MorphType != EMorphType.默认形态 || this.IsBackupBpCompParams)
		{
			return;
		}
		this.IsBackupBpCompParams = true;
		CharacterMoveComponent moveComp = this.MoveComp;
		UCharacterMovementComponent ucharacterMovementComponent = (moveComp != null) ? moveComp.CharacterMovement : null;
		if (ucharacterMovementComponent != null)
		{
			if (this.HasComponentFloatParam(EMorphType.变身形态, "角色移动", "维持水平地面速度"))
			{
				this.SetComponentFloatParam(EMorphType.默认形态, "角色移动", "维持水平地面速度", ucharacterMovementComponent.bMaintainHorizontalGroundVelocity ? 1f : 0f);
			}
			if (this.HasComponentFloatParam(EMorphType.变身形态, "角色移动", "默认水中运动模式"))
			{
				this.SetComponentFloatParam(EMorphType.默认形态, "角色移动", "默认水中运动模式", (float)ucharacterMovementComponent.DefaultWaterMovementMode);
			}
		}
		CharacterActorComponent actorComp = this.ActorComp;
		USkeletalMeshComponent uskeletalMeshComponent = (actorComp != null) ? actorComp.Actor.Mesh : null;
		if (uskeletalMeshComponent != null)
		{
			if (this.HasComponentVectorParam(EMorphType.变身形态, "网格体", "位置"))
			{
				Vector vector = Vector.Create();
				Vector vector2 = vector;
				FVector relativeLocation = uskeletalMeshComponent.RelativeLocation;
				vector2.FromUeVector(relativeLocation);
				this.SetComponentVectorParam(EMorphType.默认形态, "网格体", "位置", vector);
			}
			IMorphData morphData = this.GetMorphData(new EMorphType?(EMorphType.变身形态));
			Dictionary<string, float> dictionary;
			if (morphData == null)
			{
				dictionary = null;
			}
			else
			{
				Dictionary<string, Dictionary<string, float>> componentFloatParams = morphData.ComponentFloatParams;
				dictionary = ((componentFloatParams != null) ? componentFloatParams.GetValueOrDefault("网格体#可变胶囊体碰撞") : null);
			}
			Dictionary<string, float> capsuleParams = dictionary;
			Dictionary<string, Dictionary<string, float>> dictionary2 = this.ParseAdjustableCapsuleParams(capsuleParams);
			if (dictionary2 != null && dictionary2.Count > 0)
			{
				this.DefaultAdjustableCapsuleParams = new Dictionary<string, Dictionary<string, float>>();
				foreach (KeyValuePair<string, Dictionary<string, float>> keyValuePair in dictionary2)
				{
					string key = keyValuePair.Key;
					Dictionary<string, float> value = keyValuePair.Value;
					UKuroAdjustableCapsuleComponent ukuroAdjustableCapsuleComponent = CharacterMorphComponent.FindAdjustableCapsuleByName(key, uskeletalMeshComponent);
					if (ukuroAdjustableCapsuleComponent != null)
					{
						Dictionary<string, float> dictionary3 = new Dictionary<string, float>();
						foreach (KeyValuePair<string, float> keyValuePair2 in value)
						{
							string key2 = keyValuePair2.Key;
							if (!(key2 == "AddRadius"))
							{
								if (!(key2 == "MinRadius"))
								{
									if (key2 == "MaxRadius")
									{
										dictionary3["MaxRadius"] = ukuroAdjustableCapsuleComponent.MaxRadius;
									}
								}
								else
								{
									dictionary3["MinRadius"] = ukuroAdjustableCapsuleComponent.MinRadius;
								}
							}
							else
							{
								dictionary3["AddRadius"] = ukuroAdjustableCapsuleComponent.AddRadius;
							}
						}
						this.DefaultAdjustableCapsuleParams[key] = dictionary3;
					}
				}
			}
			Dictionary<string, string> dictionary4;
			if (morphData == null)
			{
				dictionary4 = null;
			}
			else
			{
				Dictionary<string, Dictionary<string, string>> componentStringParams = morphData.ComponentStringParams;
				dictionary4 = ((componentStringParams != null) ? componentStringParams.GetValueOrDefault("网格体#可变胶囊体碰撞") : null);
			}
			Dictionary<string, string> capsuleParams2 = dictionary4;
			Dictionary<string, Dictionary<string, string>> dictionary5 = this.ParseAdjustableCapsuleStringParams(capsuleParams2);
			if (dictionary5 != null && dictionary5.Count > 0)
			{
				this.DefaultAdjustableCapsuleStringParams = new Dictionary<string, Dictionary<string, string>>();
				foreach (KeyValuePair<string, Dictionary<string, string>> keyValuePair3 in dictionary5)
				{
					string key3 = keyValuePair3.Key;
					Dictionary<string, string> value2 = keyValuePair3.Value;
					UKuroAdjustableCapsuleComponent ukuroAdjustableCapsuleComponent2 = CharacterMorphComponent.FindAdjustableCapsuleByName(key3, uskeletalMeshComponent);
					if (ukuroAdjustableCapsuleComponent2 != null)
					{
						Dictionary<string, string> dictionary6 = new Dictionary<string, string>();
						foreach (KeyValuePair<string, string> keyValuePair4 in value2)
						{
							if (keyValuePair4.Key == "BindSocketNames")
							{
								dictionary6["BindSocketNames"] = CharacterMorphComponent.GetAdjustableCapsuleBindSocketNames(ukuroAdjustableCapsuleComponent2);
							}
						}
						this.DefaultAdjustableCapsuleStringParams[key3] = dictionary6;
					}
				}
			}
		}
	}

	// Token: 0x06019BEE RID: 105454 RVA: 0x0077EB80 File Offset: 0x0077CD80
	private void LoadBpInputComp()
	{
		if (this.BpInputComp != null || this.IsLoadingBpInputComp)
		{
			return;
		}
		IMorphData morphData = this.GetMorphData(new EMorphType?(EMorphType.变身形态));
		string text;
		if (morphData == null)
		{
			text = null;
		}
		else
		{
			FSoftClassPath inputComponentClass2 = morphData.InputComponentClass;
			text = ((inputComponentClass2 != null) ? inputComponentClass2.AssetPathName.ToString() : null);
		}
		string text2 = text;
		if (!string.IsNullOrEmpty(text2))
		{
			this.IsLoadingBpInputComp = true;
			Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(text2, delegate([Nullable(2)] UClass inputComponentClass, string _)
			{
				CharacterActorComponent actorComp = this.ActorComp;
				TsBaseCharacter tsBaseCharacter = (actorComp != null) ? actorComp.Actor : null;
				if (tsBaseCharacter != null)
				{
					BP_InputBase_C bp_InputBase_C = tsBaseCharacter.AddComponentByClass(inputComponentClass, false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as BP_InputBase_C;
					bp_InputBase_C.OwnerActor = tsBaseCharacter;
					this.BpInputComp = bp_InputBase_C;
					if (this.MorphType == EMorphType.变身形态 && base.Entity.GetComponent<CharacterInputComponent>() != null)
					{
						CharacterInputLayer characterInputLayer = ControllerBase<InputController>.Instance.GetInputLayer(base.Entity.Id, EInputLayer.Character) as CharacterInputLayer;
						if (characterInputLayer != null)
						{
							characterInputLayer.SetBpInputComp(bp_InputBase_C);
						}
					}
				}
				this.IsLoadingBpInputComp = false;
			}, 100, "js_undefined");
		}
	}

	// Token: 0x06019BEF RID: 105455 RVA: 0x0077EC00 File Offset: 0x0077CE00
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterMorphComponent characterMorphComponent = (CharacterMorphComponent)componentTemplate;
		if (base.CanResetComponentProperty("MorphType"))
		{
			this.MorphType = characterMorphComponent.MorphType;
		}
		if (base.CanResetComponentProperty("MorphData"))
		{
			if (characterMorphComponent.MorphData == null)
			{
				this.MorphData = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<IMorphData>(this.MorphData), "MorphData"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsEnableMorphInternal"))
		{
			this.IsEnableMorphInternal = characterMorphComponent.IsEnableMorphInternal;
		}
		if (base.CanResetComponentProperty("MorphDataMap"))
		{
			if (characterMorphComponent.MorphDataMap == null)
			{
				this.MorphDataMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EMorphType, IMorphData>>(this.MorphDataMap), "MorphDataMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MorphModelIdMap"))
		{
			if (characterMorphComponent.MorphModelIdMap == null)
			{
				this.MorphModelIdMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EMorphType, int>>(this.MorphModelIdMap), "MorphModelIdMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MorphAssetMap"))
		{
			if (characterMorphComponent.MorphAssetMap == null)
			{
				this.MorphAssetMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EMorphType, AssetElement>>(this.MorphAssetMap), "MorphAssetMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MorphMontageMapByName"))
		{
			if (characterMorphComponent.MorphMontageMapByName == null)
			{
				this.MorphMontageMapByName = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EMorphType, Dictionary<string, UAnimMontage>>>(this.MorphMontageMapByName), "MorphMontageMapByName"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MorphMontagePathMapByName"))
		{
			if (characterMorphComponent.MorphMontagePathMapByName == null)
			{
				this.MorphMontagePathMapByName = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EMorphType, Dictionary<string, string>>>(this.MorphMontagePathMapByName), "MorphMontagePathMapByName"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MorphMontagePathMap"))
		{
			if (characterMorphComponent.MorphMontagePathMap == null)
			{
				this.MorphMontagePathMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, EMorphType>>(this.MorphMontagePathMap), "MorphMontagePathMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SubPathNameMorphTypeMap"))
		{
			if (characterMorphComponent.SubPathNameMorphTypeMap == null)
			{
				this.SubPathNameMorphTypeMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, EMorphType>>(this.SubPathNameMorphTypeMap), "SubPathNameMorphTypeMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CreatureDataComp"))
		{
			if (characterMorphComponent.CreatureDataComp == null)
			{
				this.CreatureDataComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("RolePreloadComp"))
		{
			if (characterMorphComponent.RolePreloadComp == null)
			{
				this.RolePreloadComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RolePreloadComponent>(this.RolePreloadComp), "RolePreloadComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterMorphComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (characterMorphComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (characterMorphComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CharacterAnimationComp"))
		{
			if (characterMorphComponent.CharacterAnimationComp == null)
			{
				this.CharacterAnimationComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.CharacterAnimationComp), "CharacterAnimationComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CharacterFloatingComp"))
		{
			if (characterMorphComponent.CharacterFloatingComp == null)
			{
				this.CharacterFloatingComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterFloatingComponent>(this.CharacterFloatingComp), "CharacterFloatingComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MorphTagListenTask"))
		{
			if (characterMorphComponent.MorphTagListenTask == null)
			{
				this.MorphTagListenTask = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.MorphTagListenTask), "MorphTagListenTask"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsBackupBpCompParams"))
		{
			this.IsBackupBpCompParams = characterMorphComponent.IsBackupBpCompParams;
		}
		if (base.CanResetComponentProperty("CenterActorLocationOffset"))
		{
			if (characterMorphComponent.CenterActorLocationOffset == null)
			{
				this.CenterActorLocationOffset = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.CenterActorLocationOffset), "CenterActorLocationOffset"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BpInputComp"))
		{
			if (characterMorphComponent.BpInputComp == null)
			{
				this.BpInputComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BP_InputBase_C>(this.BpInputComp), "BpInputComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsLoadingBpInputComp"))
		{
			this.IsLoadingBpInputComp = characterMorphComponent.IsLoadingBpInputComp;
		}
		if (base.CanResetComponentProperty("TempVector"))
		{
			if (characterMorphComponent.TempVector == null)
			{
				this.TempVector = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempVector), "TempVector"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DefaultRadiusInternal"))
		{
			this.DefaultRadiusInternal = characterMorphComponent.DefaultRadiusInternal;
		}
		if (base.CanResetComponentProperty("DefaultHalfHeightInternal"))
		{
			this.DefaultHalfHeightInternal = characterMorphComponent.DefaultHalfHeightInternal;
		}
		if (base.CanResetComponentProperty("DefaultAdjustableCapsuleParams"))
		{
			if (characterMorphComponent.DefaultAdjustableCapsuleParams == null)
			{
				this.DefaultAdjustableCapsuleParams = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, Dictionary<string, float>>>(this.DefaultAdjustableCapsuleParams), "DefaultAdjustableCapsuleParams"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DefaultAdjustableCapsuleStringParams"))
		{
			if (characterMorphComponent.DefaultAdjustableCapsuleStringParams == null)
			{
				this.DefaultAdjustableCapsuleStringParams = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, Dictionary<string, string>>>(this.DefaultAdjustableCapsuleStringParams), "DefaultAdjustableCapsuleStringParams"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400CCFC RID: 52476
	private const string CAPSULE_COMPONENT = "胶囊体组件";

	// Token: 0x0400CCFD RID: 52477
	private const string CAPSULE_HALF_HEIGHT = "胶囊体半高";

	// Token: 0x0400CCFE RID: 52478
	private const string CAPSULE_RADIUS = "胶囊体半径";

	// Token: 0x0400CCFF RID: 52479
	private const string MESH_COMPONENT = "网格体";

	// Token: 0x0400CD00 RID: 52480
	private const string MESH_LOCATION = "位置";

	// Token: 0x0400CD01 RID: 52481
	private const string MOVE_COMPONENT = "角色移动";

	// Token: 0x0400CD02 RID: 52482
	private const string MOVE_MAX_STEP_HEIGHT = "最大步高";

	// Token: 0x0400CD03 RID: 52483
	private const string MOVE_WALKABLE_FLOOR_ANGLE = "可行走地面角度";

	// Token: 0x0400CD04 RID: 52484
	private const string MOVE_MAINTAIN_HORIZONTAL_GROUND_VELOCITY = "维持水平地面速度";

	// Token: 0x0400CD05 RID: 52485
	private const string MOVE_DEFAULT_WATER_MOVEMENT_MODE = "默认水中运动模式";

	// Token: 0x0400CD06 RID: 52486
	private const string MESH_ADJUSTABLE_CAPSULE = "网格体#可变胶囊体碰撞";

	// Token: 0x0400CD07 RID: 52487
	private const string CAPSULE_ADD_RADIUS = "AddRadius";

	// Token: 0x0400CD08 RID: 52488
	private const string CAPSULE_MIN_RADIUS = "MinRadius";

	// Token: 0x0400CD09 RID: 52489
	private const string CAPSULE_MAX_RADIUS = "MaxRadius";

	// Token: 0x0400CD0A RID: 52490
	private const string CAPSULE_BIND_SOCKET_NAMES = "BindSocketNames";

	// Token: 0x0400CD0B RID: 52491
	private const bool IS_ENABLE_OPTIMIZE = true;

	// Token: 0x0400CD0C RID: 52492
	[StaticVariableRuleIgnore]
	private static readonly Stat StatOnSetMorphType = Stat.Create("[CharacterMorphComponent]SetMorphType", "", "");

	// Token: 0x0400CD0D RID: 52493
	[StaticVariableRuleIgnore]
	private static readonly Stat StatOnUpdateModel = Stat.Create("[CharacterMorphComponent]UpdateModel", "", "");

	// Token: 0x0400CD0E RID: 52494
	[StaticVariableRuleIgnore]
	private static readonly Stat StatOnUpdateMovement = Stat.Create("[CharacterMorphComponent]UpdateMovement", "", "");

	// Token: 0x0400CD0F RID: 52495
	[StaticVariableRuleIgnore]
	private static readonly Stat StatOnUpdateComponents = Stat.Create("[CharacterMorphComponent]UpdateComponents", "", "");

	// Token: 0x0400CD10 RID: 52496
	private EMorphType MorphType;

	// Token: 0x0400CD11 RID: 52497
	[Nullable(2)]
	private IMorphData MorphData;

	// Token: 0x0400CD12 RID: 52498
	private bool IsEnableMorphInternal;

	// Token: 0x0400CD13 RID: 52499
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<EMorphType, IMorphData> MorphDataMap;

	// Token: 0x0400CD14 RID: 52500
	[Nullable(2)]
	private Dictionary<EMorphType, int> MorphModelIdMap;

	// Token: 0x0400CD15 RID: 52501
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<EMorphType, AssetElement> MorphAssetMap;

	// Token: 0x0400CD16 RID: 52502
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Dictionary<EMorphType, Dictionary<string, UAnimMontage>> MorphMontageMapByName;

	// Token: 0x0400CD17 RID: 52503
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Dictionary<EMorphType, Dictionary<string, string>> MorphMontagePathMapByName;

	// Token: 0x0400CD18 RID: 52504
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<string, EMorphType> MorphMontagePathMap;

	// Token: 0x0400CD19 RID: 52505
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<string, EMorphType> SubPathNameMorphTypeMap;

	// Token: 0x0400CD1A RID: 52506
	[Nullable(2)]
	private CreatureDataComponent CreatureDataComp;

	// Token: 0x0400CD1B RID: 52507
	[Nullable(2)]
	private RolePreloadComponent RolePreloadComp;

	// Token: 0x0400CD1C RID: 52508
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400CD1D RID: 52509
	[Nullable(2)]
	private CharacterMoveComponent MoveComp;

	// Token: 0x0400CD1E RID: 52510
	[Nullable(2)]
	private BaseTagComponent TagComp;

	// Token: 0x0400CD1F RID: 52511
	[Nullable(2)]
	private CharacterAnimationComponent CharacterAnimationComp;

	// Token: 0x0400CD20 RID: 52512
	[Nullable(2)]
	private CharacterFloatingComponent CharacterFloatingComp;

	// Token: 0x0400CD21 RID: 52513
	[Nullable(2)]
	private ITagTask MorphTagListenTask;

	// Token: 0x0400CD22 RID: 52514
	private bool IsBackupBpCompParams;

	// Token: 0x0400CD23 RID: 52515
	[Nullable(2)]
	private Vector CenterActorLocationOffset;

	// Token: 0x0400CD24 RID: 52516
	[Nullable(2)]
	private BP_InputBase_C BpInputComp;

	// Token: 0x0400CD25 RID: 52517
	private bool IsLoadingBpInputComp;

	// Token: 0x0400CD26 RID: 52518
	[Nullable(2)]
	private Vector TempVector;

	// Token: 0x0400CD27 RID: 52519
	private float DefaultRadiusInternal;

	// Token: 0x0400CD28 RID: 52520
	private float DefaultHalfHeightInternal;

	// Token: 0x0400CD29 RID: 52521
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Dictionary<string, Dictionary<string, float>> DefaultAdjustableCapsuleParams;

	// Token: 0x0400CD2A RID: 52522
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1,
		1
	})]
	private Dictionary<string, Dictionary<string, string>> DefaultAdjustableCapsuleStringParams;
}
