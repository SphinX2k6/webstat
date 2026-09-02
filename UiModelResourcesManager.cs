using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02002C5A RID: 11354
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class UiModelResourcesManager : Singleton<UiModelResourcesManager>
{
	// Token: 0x17001DDB RID: 7643
	// (get) Token: 0x06016C4B RID: 93259 RVA: 0x00650A20 File Offset: 0x0064EC20
	private int UiModelHandleId
	{
		get
		{
			int uiModelHandleIdInternal = this.UiModelHandleIdInternal;
			this.UiModelHandleIdInternal = uiModelHandleIdInternal + 1;
			return uiModelHandleIdInternal;
		}
	}

	// Token: 0x06016C4C RID: 93260 RVA: 0x00650A3E File Offset: 0x0064EC3E
	public UiModelResourcesManager()
	{
		this.LoadUiModelHandleMap = new Dictionary<int, int[]>();
		this.UiModelHandleIdInternal = 0;
		this.InvalidValue = 0;
	}

	// Token: 0x06016C4D RID: 93261 RVA: 0x00650A60 File Offset: 0x0064EC60
	public int LoadUiModelResources(List<string> paths, [Nullable(new byte[]
	{
		2,
		2,
		1,
		1
	})] Action<EUiRoleLoadResult, Dictionary<string, UObject>> callback = null)
	{
		if (paths == null || paths.Count == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.UiModelResourcesManager, ELogAuthor.XXJ, "加载资源内容为空,检查一下传进来的数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			Action<EUiRoleLoadResult, Dictionary<string, UObject>> callback2 = callback;
			if (callback2 != null)
			{
				callback2(EUiRoleLoadResult.Fail, null);
			}
			return 0;
		}
		List<string> completeList = new List<string>();
		List<string> finishList = new List<string>();
		int modelHandleId = this.UiModelHandleId;
		Dictionary<string, UObject> loadedResources = new Dictionary<string, UObject>();
		Singleton<LoadModeManager>.Instance.SetLoadModeByReason(ELoadMode.Loading, ELoadModeReason.LoadUiModelResources);
		this.LoadUiModelHandleMap[modelHandleId] = Array.Empty<int>();
		List<int> list = new List<int>();
		Action<UObject, string> <>9__0;
		foreach (string text in paths)
		{
			ResourceSystem instance = Singleton<ResourceSystem>.Instance;
			string path = text;
			Action<UObject, string> callback3;
			if ((callback3 = <>9__0) == null)
			{
				callback3 = (<>9__0 = delegate([Nullable(2)] UObject result, string loadPath)
				{
					if (result != null)
					{
						completeList.Add(loadPath);
						loadedResources[loadPath] = result;
					}
					finishList.Add(loadPath);
					if (finishList.Count == paths.Count)
					{
						this.LoadUiModelHandleMap.Remove(modelHandleId);
						if (completeList.Count != finishList.Count)
						{
							Action<EUiRoleLoadResult, Dictionary<string, UObject>> callback4 = callback;
							if (callback4 != null)
							{
								callback4(EUiRoleLoadResult.LoadingMissing, null);
							}
							if (Singleton<LoadModeManager>.Instance.IsReasonTargetNotDefault(ELoadModeReason.LoadUiModelResources))
							{
								Singleton<LoadModeManager>.Instance.ResetLoadModeByReason(ELoadModeReason.LoadUiModelResources);
								return;
							}
						}
						else
						{
							Action<EUiRoleLoadResult, Dictionary<string, UObject>> callback5 = callback;
							if (callback5 != null)
							{
								callback5(EUiRoleLoadResult.Success, loadedResources);
							}
							if (Singleton<LoadModeManager>.Instance.IsReasonTargetNotDefault(ELoadModeReason.LoadUiModelResources))
							{
								Singleton<LoadModeManager>.Instance.ResetLoadModeByReason(ELoadModeReason.LoadUiModelResources);
							}
						}
					}
				});
			}
			int item = instance.LoadAsync<UObject>(path, callback3, 100, "js_undefined");
			if (this.LoadUiModelHandleMap.ContainsKey(modelHandleId))
			{
				list.Add(item);
			}
		}
		this.LoadUiModelHandleMap[modelHandleId] = list.ToArray();
		return modelHandleId;
	}

	// Token: 0x06016C4E RID: 93262 RVA: 0x00650BD4 File Offset: 0x0064EDD4
	public int LoadUiRoleAllResourceByRoleConfigId(int roleId, [Nullable(new byte[]
	{
		2,
		2,
		1,
		1
	})] Action<EUiRoleLoadResult, Dictionary<string, UObject>> callback = null)
	{
		List<string> list = new List<string>();
		list.AddRange(this.GetRoleResourcesPath(roleId));
		list.Add(EffectUtil.GetEffectPath("ChangeRoleMaterialController"));
		return this.LoadUiModelResources(list, callback);
	}

	// Token: 0x06016C4F RID: 93263 RVA: 0x00650C0C File Offset: 0x0064EE0C
	public void CancelUiModelResourceLoad(int handleId)
	{
		if (handleId == this.InvalidValue)
		{
			return;
		}
		int[] array;
		if (!this.LoadUiModelHandleMap.TryGetValue(handleId, out array))
		{
			return;
		}
		foreach (int id in array)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(id);
		}
		if (Singleton<LoadModeManager>.Instance.IsReasonTargetNotDefault(ELoadModeReason.LoadUiModelResources))
		{
			Singleton<LoadModeManager>.Instance.ResetLoadModeByReason(ELoadModeReason.LoadUiModelResources);
		}
	}

	// Token: 0x06016C50 RID: 93264 RVA: 0x00650C6C File Offset: 0x0064EE6C
	public List<string> GetRoleResourcesPath(int roleConfigId)
	{
		List<string> list = new List<string>();
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleConfigId);
		SModelConfig modelConfig = ModelUtil.GetModelConfig(roleConfig.Value.UiMeshId);
		list.Add(modelConfig.网格体.ToAssetPathName());
		list.Add(roleConfig.Value.UiScenePerformanceABP);
		TArray<TSoftObjectPtr<USkeletalMesh>> 子网格体 = modelConfig.子网格体;
		if (子网格体 != null)
		{
			for (int i = 0; i < 子网格体.Num(); i++)
			{
				list.Add(子网格体.Get(i).ToAssetPathName());
			}
		}
		return list;
	}

	// Token: 0x06016C51 RID: 93265 RVA: 0x00650CFC File Offset: 0x0064EEFC
	public unsafe List<string> GetWeaponResourcesPath(int weaponId)
	{
		List<string> list = new List<string>();
		Span<int> modelsBytes = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(weaponId).Value.GetModelsBytes();
		for (int i = 0; i < modelsBytes.Length; i++)
		{
			SModelConfig modelConfig = ModelUtil.GetModelConfig(*modelsBytes[i]);
			string text = modelConfig.网格体.ToAssetPathName();
			if (!string.IsNullOrEmpty(text))
			{
				list.Add(text);
			}
			string text2 = modelConfig.动画蓝图.ToAssetPathName();
			if (!string.IsNullOrEmpty(text2))
			{
				list.Add(text2);
			}
			FSoftObjectPath da = modelConfig.DA;
			string text3 = (da != null) ? da.GetAssetPathString() : null;
			if (!string.IsNullOrEmpty(text3))
			{
				list.Add(text3);
			}
		}
		return list;
	}

	// Token: 0x06016C52 RID: 93266 RVA: 0x00650DB4 File Offset: 0x0064EFB4
	public string[] GetHuluResourcesPath(int huluId)
	{
		List<string> list = new List<string>();
		SModelConfig modelConfig = ModelUtil.GetModelConfig(huluId);
		string text = modelConfig.网格体.ToAssetPathName();
		if (!string.IsNullOrEmpty(text))
		{
			list.Add(text);
		}
		string text2 = modelConfig.动画蓝图.ToAssetPathName();
		if (!string.IsNullOrEmpty(text2))
		{
			list.Add(text2);
		}
		return list.ToArray();
	}

	// Token: 0x0400AF7D RID: 44925
	private readonly Dictionary<int, int[]> LoadUiModelHandleMap;

	// Token: 0x0400AF7E RID: 44926
	private int UiModelHandleIdInternal;

	// Token: 0x0400AF7F RID: 44927
	public readonly int InvalidValue;
}
