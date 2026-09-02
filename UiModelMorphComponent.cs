using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002C8D RID: 11405
[NullableContext(2)]
[Nullable(0)]
public class UiModelMorphComponent : UiModelComponentBase
{
	// Token: 0x06016E2C RID: 93740 RVA: 0x00659059 File Offset: 0x00657259
	protected override void OnStart()
	{
		this.UiModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
		this.UiModelActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
	}

	// Token: 0x06016E2D RID: 93741 RVA: 0x0065907D File Offset: 0x0065727D
	protected override void OnEnd()
	{
		this.MorphType = EUiModelMorphType.默认形态;
		this.MorphDataMap = null;
		this.MorphIdMap = null;
		this.UiModelDataComponent = null;
		this.UiModelActorComponent = null;
		this.IsEnableMorphInternal = false;
	}

	// Token: 0x06016E2E RID: 93742 RVA: 0x006590A9 File Offset: 0x006572A9
	public EUiModelMorphType GetMorphType()
	{
		return this.MorphType;
	}

	// Token: 0x06016E2F RID: 93743 RVA: 0x006590B4 File Offset: 0x006572B4
	public unsafe bool SetMorphType(EUiModelMorphType morphType)
	{
		if (!this.IsEnableMorphInternal)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiModelMorph;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "该角色不支持多形态";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", this.UiModelDataComponent.ModelConfigId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (this.MorphType == morphType)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.UiModelMorph;
			ELogAuthor author2 = ELogAuthor.LRC;
			string message2 = "当前形态与目标形态相同";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("morphType", morphType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("this.MorphType", this.MorphType);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		this.MorphType = morphType;
		if (this.MorphDataMap == null)
		{
			return false;
		}
		IUiMorphData uiMorphData;
		if (!this.MorphDataMap.TryGetValue(morphType, out uiMorphData))
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.UiModelMorph;
			ELogAuthor author3 = ELogAuthor.LRC;
			string message3 = "[UiModelMorphComponent]初始化获取morphData有误";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("MorphType", morphType);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		UiModelActorComponent uiModelActorComponent = this.UiModelActorComponent;
		if (uiModelActorComponent != null)
		{
			uiModelActorComponent.ChangeMesh(uiMorphData.MainSkeletalMesh, uiMorphData.AnimClass, uiMorphData.ChildSkeletalMesh, uiMorphData.DecorationParamList, 0);
		}
		Singleton<EventSystem>.Instance.EmitWithTarget(base.Owner, EEventName.OnUiModelSetMorphTypeComplete);
		return true;
	}

	// Token: 0x06016E30 RID: 93744 RVA: 0x00659200 File Offset: 0x00657400
	public IUiMorphData GetCurrentMorphData()
	{
		if (this.MorphDataMap == null)
		{
			return null;
		}
		IUiMorphData result;
		if (this.MorphDataMap.TryGetValue(this.MorphType, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06016E31 RID: 93745 RVA: 0x0065922F File Offset: 0x0065742F
	protected virtual void PreloadMorphId()
	{
		this.MorphIdMap = null;
		this.IsEnableMorphInternal = false;
	}

	// Token: 0x06016E32 RID: 93746 RVA: 0x00659240 File Offset: 0x00657440
	public void PreloadMorphData()
	{
		this.PreloadMorphId();
		if (this.MorphIdMap == null)
		{
			return;
		}
		if (this.MorphDataMap != null)
		{
			this.MorphDataMap.Clear();
			this.MorphDataMap = null;
		}
		Dictionary<EUiModelMorphType, IUiMorphData> dictionary = new Dictionary<EUiModelMorphType, IUiMorphData>();
		foreach (KeyValuePair<EUiModelMorphType, IUiMorphId> keyValuePair in this.MorphIdMap)
		{
			EUiModelMorphType key = keyValuePair.Key;
			IUiMorphId value = keyValuePair.Value;
			if (!string.IsNullOrEmpty(value.MainMeshPath) && !string.IsNullOrEmpty(value.AnimPath))
			{
				string mainMeshPath = value.MainMeshPath;
				string animPath = value.AnimPath;
				List<string> childMeshPathList = value.ChildMeshPathList;
				TArray<SModelDecorationConfig> decorationMeshConfigArray = value.DecorationMeshConfigArray;
				USkeletalMesh loadedAsset = Singleton<ResourceSystem>.Instance.GetLoadedAsset<USkeletalMesh>(mainMeshPath);
				if (loadedAsset == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiModelMorph;
					ELogAuthor author = ELogAuthor.LRC;
					string message = "[UiRoleMorphComponent]获取mainMesh失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MainMeshPath", mainMeshPath);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				UClass loadedAsset2 = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UClass>(animPath);
				if (loadedAsset2 == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.UiModelMorph;
					ELogAuthor author2 = ELogAuthor.LRC;
					string message2 = "[UiRoleMorphComponent]获取animClass失败";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("AnimClassPath", animPath);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				List<USkeletalMesh> list = null;
				if (childMeshPathList != null)
				{
					list = new List<USkeletalMesh>();
					foreach (string text in childMeshPathList)
					{
						USkeletalMesh loadedAsset3 = Singleton<ResourceSystem>.Instance.GetLoadedAsset<USkeletalMesh>(text);
						if (loadedAsset3 == null)
						{
							Log instance3 = Singleton<Log>.Instance;
							ELogModule module3 = ELogModule.UiModelMorph;
							ELogAuthor author3 = ELogAuthor.LRC;
							string message3 = "[UiRoleMorphComponent]获取childMesh失败";
							ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("ChildMeshPath", text);
							instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
						}
						else
						{
							list.Add(loadedAsset3);
						}
					}
				}
				UiMorphData value2 = new UiMorphData
				{
					MainSkeletalMesh = loadedAsset,
					AnimClass = loadedAsset2,
					ChildSkeletalMesh = list,
					DecorationParamList = this.GetModelMeshDecorationList(decorationMeshConfigArray),
					RoleBody = value.RoleBody
				};
				dictionary[key] = value2;
			}
		}
		this.MorphDataMap = dictionary;
		this.MorphType = EUiModelMorphType.默认形态;
	}

	// Token: 0x06016E33 RID: 93747 RVA: 0x00659484 File Offset: 0x00657684
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public virtual List<string> GetAllMorphPathList()
	{
		return null;
	}

	// Token: 0x06016E34 RID: 93748 RVA: 0x00659487 File Offset: 0x00657687
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public virtual List<IUiMorphId> GetSpecialMorphIdList()
	{
		return null;
	}

	// Token: 0x06016E35 RID: 93749 RVA: 0x0065948A File Offset: 0x0065768A
	public void ClearData()
	{
		if (this.MorphDataMap != null)
		{
			this.MorphDataMap.Clear();
		}
		if (this.MorphIdMap != null)
		{
			this.MorphIdMap.Clear();
		}
		this.MorphDataMap = null;
		this.MorphIdMap = null;
	}

	// Token: 0x06016E36 RID: 93750 RVA: 0x006594C0 File Offset: 0x006576C0
	[NullableContext(1)]
	public List<UiModelDecorationParam> GetModelMeshDecorationList(TArray<SModelDecorationConfig> configArray)
	{
		int num = configArray.Num();
		List<UiModelDecorationParam> list = new List<UiModelDecorationParam>();
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				SModelDecorationConfig smodelDecorationConfig = configArray.Get(i);
				string text = smodelDecorationConfig.SkeletalMesh.ToAssetPathName();
				USkeletalMesh loadedAsset = Singleton<ResourceSystem>.Instance.GetLoadedAsset<USkeletalMesh>(text);
				if (loadedAsset == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiModelMorph;
					ELogAuthor author = ELogAuthor.BB;
					string message = "[UiRoleMorphComponent]获取decorationMesh失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DecorationMeshPath", text);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					UiModelDecorationParam item = new UiModelDecorationParam
					{
						SocketName = smodelDecorationConfig.SocketName,
						Transform = smodelDecorationConfig.Transform,
						SkeletalMesh = loadedAsset
					};
					list.Add(item);
				}
			}
		}
		return list;
	}

	// Token: 0x0400B08A RID: 45194
	protected EUiModelMorphType MorphType;

	// Token: 0x0400B08B RID: 45195
	protected bool IsEnableMorphInternal;

	// Token: 0x0400B08C RID: 45196
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Dictionary<EUiModelMorphType, IUiMorphData> MorphDataMap;

	// Token: 0x0400B08D RID: 45197
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Dictionary<EUiModelMorphType, IUiMorphId> MorphIdMap;

	// Token: 0x0400B08E RID: 45198
	protected UiModelDataComponent UiModelDataComponent;

	// Token: 0x0400B08F RID: 45199
	protected UiModelActorComponent UiModelActorComponent;
}
