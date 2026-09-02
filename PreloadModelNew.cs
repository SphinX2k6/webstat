using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x020034BB RID: 13499
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PreloadModelNew : ModelBase<PreloadModelNew>
{
	// Token: 0x170026B7 RID: 9911
	// (get) Token: 0x0601C871 RID: 116849 RVA: 0x0088D958 File Offset: 0x0088BB58
	[Nullable(2)]
	public UHoldPreloadObject HoldPreloadObject
	{
		[NullableContext(2)]
		get
		{
			return this.HoldPreloadObjectInternal;
		}
	}

	// Token: 0x0601C872 RID: 116850 RVA: 0x0088D960 File Offset: 0x0088BB60
	protected override bool OnInit()
	{
		this.ProjectPath = UKismetSystemLibrary.ConvertToAbsolutePath(UBlueprintPathsLibrary.ProjectDir());
		this.JsonExportRootPath = UKismetSystemLibrary.ConvertToAbsolutePath(this.ProjectPath + "../Config/Client/Preload/");
		this.ModelConfigJsonExportPath = this.JsonExportRootPath + "ModelConfig/";
		this.SkillJsonExportPath = this.JsonExportRootPath + "SkillInfo/";
		this.CommonSkillJsonExportPath = this.JsonExportRootPath + "CommonSkillInfo/";
		this.BulletJsonExportPath = this.JsonExportRootPath + "BulletInfo/";
		this.StateMachineJsonExportPath = this.JsonExportRootPath + "EntityFsm/";
		this.HoldPreloadObjectInternal = new UHoldPreloadObject(GlobalData.GameInstance, null, EObjectFlags.RF_NoFlags);
		this.PreCreateEffect.RegisterTick();
		this.PreCreateEffect.Init();
		if (Singleton<Info>.Instance.IsPs5Platform() || Singleton<CloudGameManager>.Instance.IsCloudGame)
		{
			PreloadSetting.LoadAllPreloadData = true;
		}
		this.InitPbDataPreload();
		this.InitCommonSkillDataPreload();
		if (PreloadSetting.LoadAllPreloadData)
		{
			this.InitBulletDataPreload();
			this.InitModelConfigDataPreload();
			this.InitStateMachineDataPreload();
			this.InitTemplateDataPreload();
			this.InitSkillDataPreload();
		}
		this.PlotAssetManager.Init();
		this.PlotUiAssetManager.Init();
		return true;
	}

	// Token: 0x0601C873 RID: 116851 RVA: 0x0088DA94 File Offset: 0x0088BC94
	private void InitPbDataPreload()
	{
		IReadOnlyList<PbDataPreload> configList = ConfigPbDataPreloadAll.GetConfigList(true);
		if (configList != null)
		{
			foreach (PbDataPreload value in configList)
			{
				if (!this.PbDataPreloadDataMap.ContainsKey(value.MapId))
				{
					this.PbDataPreloadDataMap[value.MapId] = new Dictionary<int, PbDataPreload>();
				}
				this.PbDataPreloadDataMap[value.MapId][value.PbDataId] = value;
			}
		}
	}

	// Token: 0x0601C874 RID: 116852 RVA: 0x0088DB2C File Offset: 0x0088BD2C
	private void InitBulletDataPreload()
	{
		foreach (BulletPreload src in ConfigBulletPreloadByAll.GetConfigList(true))
		{
			if (!this.BulletPreloadDataMap.ContainsKey(src.ActorBlueprint))
			{
				this.BulletPreloadDataMap[src.ActorBlueprint] = new Dictionary<long, PreloadSaveData>();
			}
			this.BulletPreloadDataMap[src.ActorBlueprint][src.BulletId] = this.BuildPreloadSaveData(src);
		}
	}

	// Token: 0x0601C875 RID: 116853 RVA: 0x0088DBC4 File Offset: 0x0088BDC4
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public OneOf<PreloadSaveData, BulletPreload>? GetBulletPreloadData(string bpPath, long bulletId)
	{
		if (PreloadSetting.LoadAllPreloadData)
		{
			Dictionary<long, PreloadSaveData> dictionary;
			PreloadSaveData value;
			if (this.BulletPreloadDataMap.TryGetValue(bpPath, out dictionary) && dictionary.TryGetValue(bulletId, out value))
			{
				return new OneOf<PreloadSaveData, BulletPreload>?(value);
			}
			return null;
		}
		else
		{
			BulletPreload? config = ConfigBulletPreloadByActorBlueprintAndBulletId.GetConfig(bpPath, bulletId, true);
			if (config != null)
			{
				return new OneOf<PreloadSaveData, BulletPreload>?(config.Value);
			}
			return null;
		}
	}

	// Token: 0x0601C876 RID: 116854 RVA: 0x0088DC38 File Offset: 0x0088BE38
	private void InitCommonSkillDataPreload()
	{
		IReadOnlyList<CommonSkillPreload> configList = ConfigCommonSkillPreloadAll.GetConfigList(true);
		if (configList != null)
		{
			foreach (CommonSkillPreload item in configList)
			{
				this.CommonSkillPreloadDataMap = new List<CommonSkillPreload>(this.CommonSkillPreloadDataMap)
				{
					item
				}.ToArray();
			}
		}
	}

	// Token: 0x0601C877 RID: 116855 RVA: 0x0088DCA4 File Offset: 0x0088BEA4
	[NullableContext(2)]
	public CommonSkillPreload[] GetCommonSkillPreloadData()
	{
		return this.CommonSkillPreloadDataMap;
	}

	// Token: 0x0601C878 RID: 116856 RVA: 0x0088DCAC File Offset: 0x0088BEAC
	private void InitModelConfigDataPreload()
	{
		foreach (ModelConfigPreload src in ConfigModelConfigPreloadByAll.GetConfigList(true))
		{
			if (!this.ModelConfigPreloadDataMap.ContainsKey(src.Id))
			{
				PreloadModelConfigSaveData preloadModelConfigSaveData = this.BuildPreloadSaveData(src) as PreloadModelConfigSaveData;
				preloadModelConfigSaveData.ActorClassPath = src.ActorClassPath;
				this.ModelConfigPreloadDataMap[src.Id] = preloadModelConfigSaveData;
			}
		}
	}

	// Token: 0x0601C879 RID: 116857 RVA: 0x0088DD34 File Offset: 0x0088BF34
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public OneOf<PreloadModelConfigSaveData, ModelConfigPreload>? GetModelConfigPreloadData(int modelConfigId)
	{
		if (PreloadSetting.LoadAllPreloadData)
		{
			PreloadModelConfigSaveData value;
			if (this.ModelConfigPreloadDataMap.TryGetValue(modelConfigId, out value))
			{
				return new OneOf<PreloadModelConfigSaveData, ModelConfigPreload>?(value);
			}
			return null;
		}
		else
		{
			ModelConfigPreload? config = ConfigModelConfigPreloadById.GetConfig(modelConfigId, true);
			if (config != null)
			{
				return new OneOf<PreloadModelConfigSaveData, ModelConfigPreload>?(config.Value);
			}
			return null;
		}
	}

	// Token: 0x0601C87A RID: 116858 RVA: 0x0088DD9C File Offset: 0x0088BF9C
	private void InitStateMachineDataPreload()
	{
		foreach (StateMachinePreload src in ConfigStateMachinePreloadByAll.GetConfigList(true))
		{
			if (!this.StateMachinePreloadDataMap.ContainsKey(src.FsmKey))
			{
				this.StateMachinePreloadDataMap[src.FsmKey] = this.BuildPreloadSaveData(src);
			}
		}
	}

	// Token: 0x0601C87B RID: 116859 RVA: 0x0088DE10 File Offset: 0x0088C010
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public OneOf<PreloadSaveData, StateMachinePreload>? GetStateMachinePreloadData(string fsmKey)
	{
		if (PreloadSetting.LoadAllPreloadData)
		{
			PreloadSaveData value;
			if (this.StateMachinePreloadDataMap.TryGetValue(fsmKey, out value))
			{
				return new OneOf<PreloadSaveData, StateMachinePreload>?(value);
			}
			return null;
		}
		else
		{
			StateMachinePreload? config = ConfigStateMachinePreloadByFsmKey.GetConfig(fsmKey, true);
			if (config != null)
			{
				return new OneOf<PreloadSaveData, StateMachinePreload>?(config.Value);
			}
			return null;
		}
	}

	// Token: 0x0601C87C RID: 116860 RVA: 0x0088DE78 File Offset: 0x0088C078
	private void InitTemplateDataPreload()
	{
		foreach (TemplateDataPreload src in ConfigTemplateDataPreloadByAll.GetConfigList(true))
		{
			if (!this.TemplatePreloadDataMap.ContainsKey(src.Id))
			{
				this.TemplatePreloadDataMap[src.Id] = this.BuildPreloadSaveData(src);
			}
		}
	}

	// Token: 0x0601C87D RID: 116861 RVA: 0x0088DEEC File Offset: 0x0088C0EC
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public OneOf<PreloadSaveData, TemplateDataPreload>? GetTemplatePreloadData(int templateId)
	{
		if (PreloadSetting.LoadAllPreloadData)
		{
			PreloadSaveData value;
			if (this.TemplatePreloadDataMap.TryGetValue(templateId, out value))
			{
				return new OneOf<PreloadSaveData, TemplateDataPreload>?(value);
			}
			return null;
		}
		else
		{
			TemplateDataPreload? config = ConfigTemplateDataPreloadById.GetConfig(templateId, true);
			if (config != null)
			{
				return new OneOf<PreloadSaveData, TemplateDataPreload>?(config.Value);
			}
			return null;
		}
	}

	// Token: 0x0601C87E RID: 116862 RVA: 0x0088DF54 File Offset: 0x0088C154
	private void InitSkillDataPreload()
	{
		foreach (EntitySkillPreload src in ConfigEntitySkillPreloadByAll.GetConfigList(true))
		{
			PreloadSkillSaveData preloadSkillSaveData = this.BuildPreloadSaveData(src) as PreloadSkillSaveData;
			preloadSkillSaveData.SkillId = src.SkillId;
			preloadSkillSaveData.ActorBlueprint = src.ActorBlueprint;
			preloadSkillSaveData.LoadType = src.LoadType;
			preloadSkillSaveData.IsCommon = src.IsCommon;
			preloadSkillSaveData.HasMontagePath = src.HasMontagePath;
			List<PreloadSkillSaveData> list;
			if (this.SkillPreloadDataMap.TryGetValue(src.ActorBlueprint, out list))
			{
				list.Add(preloadSkillSaveData);
			}
			else
			{
				list = new List<PreloadSkillSaveData>();
				list.Add(preloadSkillSaveData);
				this.SkillPreloadDataMap[src.ActorBlueprint] = list;
			}
		}
	}

	// Token: 0x0601C87F RID: 116863 RVA: 0x0088E030 File Offset: 0x0088C230
	[return: Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})]
	public OneOf<List<PreloadSkillSaveData>, IReadOnlyList<EntitySkillPreload>>? GetSkillPreloadData(string bpPath)
	{
		if (PreloadSetting.LoadAllPreloadData)
		{
			List<PreloadSkillSaveData> value;
			if (this.SkillPreloadDataMap.TryGetValue(bpPath, out value))
			{
				return new OneOf<List<PreloadSkillSaveData>, IReadOnlyList<EntitySkillPreload>>?(value);
			}
			return null;
		}
		else
		{
			IReadOnlyList<EntitySkillPreload> configList = ConfigEntitySkillPreloadByActorBlueprint.GetConfigList(bpPath, true);
			if (configList != null)
			{
				return new OneOf<List<PreloadSkillSaveData>, IReadOnlyList<EntitySkillPreload>>?(new OneOf<List<PreloadSkillSaveData>, IReadOnlyList<EntitySkillPreload>>(configList));
			}
			return null;
		}
	}

	// Token: 0x0601C880 RID: 116864 RVA: 0x0088E08C File Offset: 0x0088C28C
	private PreloadSaveData BuildPreloadSaveData(BulletPreload src)
	{
		PreloadSaveData preloadSaveData = new PreloadSaveData();
		if (src.ActorClassLength > 0)
		{
			for (int i = 0; i < src.ActorClassLength; i++)
			{
				preloadSaveData.Others.Add(src.ActorClass(i));
			}
		}
		if (src.AnimationsLength > 0)
		{
			if (preloadSaveData.Animations == null)
			{
				preloadSaveData.Animations = new List<string>();
			}
			preloadSaveData.Animations.Clear();
			for (int j = 0; j < src.AnimationsLength; j++)
			{
				preloadSaveData.Animations.Add(src.Animations(j));
			}
		}
		if (src.EffectsLength > 0)
		{
			for (int k = 0; k < src.EffectsLength; k++)
			{
				preloadSaveData.Others.Add(src.Effects(k));
			}
		}
		if (src.AudiosLength > 0)
		{
			for (int l = 0; l < src.AudiosLength; l++)
			{
				preloadSaveData.Others.Add(src.Audios(l));
			}
		}
		if (src.MaterialsLength > 0)
		{
			for (int m = 0; m < src.MaterialsLength; m++)
			{
				preloadSaveData.Others.Add(src.Materials(m));
			}
		}
		if (src.MeshesLength > 0)
		{
			for (int n = 0; n < src.MeshesLength; n++)
			{
				preloadSaveData.Others.Add(src.Meshes(n));
			}
		}
		if (src.AnimationBlueprintsLength > 0)
		{
			for (int num = 0; num < src.AnimationBlueprintsLength; num++)
			{
				preloadSaveData.Others.Add(src.AnimationBlueprints(num));
			}
		}
		if (src.OthersLength > 0)
		{
			for (int num2 = 0; num2 < src.OthersLength; num2++)
			{
				preloadSaveData.Others.Add(src.Others(num2));
			}
		}
		return preloadSaveData;
	}

	// Token: 0x0601C881 RID: 116865 RVA: 0x0088E250 File Offset: 0x0088C450
	private PreloadSaveData BuildPreloadSaveData(EntitySkillPreload src)
	{
		PreloadSkillSaveData preloadSkillSaveData = new PreloadSkillSaveData();
		if (src.ActorClassLength > 0)
		{
			for (int i = 0; i < src.ActorClassLength; i++)
			{
				preloadSkillSaveData.Others.Add(src.ActorClass(i));
			}
		}
		if (src.AnimationsLength > 0)
		{
			if (preloadSkillSaveData.Animations == null)
			{
				preloadSkillSaveData.Animations = new List<string>();
			}
			preloadSkillSaveData.Animations.Clear();
			for (int j = 0; j < src.AnimationsLength; j++)
			{
				preloadSkillSaveData.Animations.Add(src.Animations(j));
			}
		}
		if (src.EffectsLength > 0)
		{
			for (int k = 0; k < src.EffectsLength; k++)
			{
				preloadSkillSaveData.Others.Add(src.Effects(k));
			}
		}
		if (src.AudiosLength > 0)
		{
			for (int l = 0; l < src.AudiosLength; l++)
			{
				preloadSkillSaveData.Others.Add(src.Audios(l));
			}
		}
		if (src.MaterialsLength > 0)
		{
			for (int m = 0; m < src.MaterialsLength; m++)
			{
				preloadSkillSaveData.Others.Add(src.Materials(m));
			}
		}
		if (src.MeshesLength > 0)
		{
			for (int n = 0; n < src.MeshesLength; n++)
			{
				preloadSkillSaveData.Others.Add(src.Meshes(n));
			}
		}
		if (src.AnimationBlueprintsLength > 0)
		{
			for (int num = 0; num < src.AnimationBlueprintsLength; num++)
			{
				preloadSkillSaveData.Others.Add(src.AnimationBlueprints(num));
			}
		}
		if (src.OthersLength > 0)
		{
			for (int num2 = 0; num2 < src.OthersLength; num2++)
			{
				preloadSkillSaveData.Others.Add(src.Others(num2));
			}
		}
		return preloadSkillSaveData;
	}

	// Token: 0x0601C882 RID: 116866 RVA: 0x0088E414 File Offset: 0x0088C614
	private PreloadSaveData BuildPreloadSaveData(TemplateDataPreload src)
	{
		PreloadSaveData preloadSaveData = new PreloadSaveData();
		if (src.ActorClassLength > 0)
		{
			for (int i = 0; i < src.ActorClassLength; i++)
			{
				preloadSaveData.Others.Add(src.ActorClass(i));
			}
		}
		if (src.AnimationsLength > 0)
		{
			if (preloadSaveData.Animations == null)
			{
				preloadSaveData.Animations = new List<string>();
			}
			preloadSaveData.Animations.Clear();
			for (int j = 0; j < src.AnimationsLength; j++)
			{
				preloadSaveData.Animations.Add(src.Animations(j));
			}
		}
		if (src.EffectsLength > 0)
		{
			for (int k = 0; k < src.EffectsLength; k++)
			{
				preloadSaveData.Others.Add(src.Effects(k));
			}
		}
		if (src.AudiosLength > 0)
		{
			for (int l = 0; l < src.AudiosLength; l++)
			{
				preloadSaveData.Others.Add(src.Audios(l));
			}
		}
		if (src.MaterialsLength > 0)
		{
			for (int m = 0; m < src.MaterialsLength; m++)
			{
				preloadSaveData.Others.Add(src.Materials(m));
			}
		}
		if (src.MeshesLength > 0)
		{
			for (int n = 0; n < src.MeshesLength; n++)
			{
				preloadSaveData.Others.Add(src.Meshes(n));
			}
		}
		if (src.AnimationBlueprintsLength > 0)
		{
			for (int num = 0; num < src.AnimationBlueprintsLength; num++)
			{
				preloadSaveData.Others.Add(src.AnimationBlueprints(num));
			}
		}
		if (src.OthersLength > 0)
		{
			for (int num2 = 0; num2 < src.OthersLength; num2++)
			{
				preloadSaveData.Others.Add(src.Others(num2));
			}
		}
		return preloadSaveData;
	}

	// Token: 0x0601C883 RID: 116867 RVA: 0x0088E5D8 File Offset: 0x0088C7D8
	private PreloadSaveData BuildPreloadSaveData(StateMachinePreload src)
	{
		PreloadSaveData preloadSaveData = new PreloadSaveData();
		if (src.ActorClassLength > 0)
		{
			for (int i = 0; i < src.ActorClassLength; i++)
			{
				preloadSaveData.Others.Add(src.ActorClass(i));
			}
		}
		if (src.AnimationsLength > 0)
		{
			if (preloadSaveData.Animations == null)
			{
				preloadSaveData.Animations = new List<string>();
			}
			preloadSaveData.Animations.Clear();
			for (int j = 0; j < src.AnimationsLength; j++)
			{
				preloadSaveData.Animations.Add(src.Animations(j));
			}
		}
		if (src.EffectsLength > 0)
		{
			for (int k = 0; k < src.EffectsLength; k++)
			{
				preloadSaveData.Others.Add(src.Effects(k));
			}
		}
		if (src.AudiosLength > 0)
		{
			for (int l = 0; l < src.AudiosLength; l++)
			{
				preloadSaveData.Others.Add(src.Audios(l));
			}
		}
		if (src.MaterialsLength > 0)
		{
			for (int m = 0; m < src.MaterialsLength; m++)
			{
				preloadSaveData.Others.Add(src.Materials(m));
			}
		}
		if (src.MeshesLength > 0)
		{
			for (int n = 0; n < src.MeshesLength; n++)
			{
				preloadSaveData.Others.Add(src.Meshes(n));
			}
		}
		if (src.AnimationBlueprintsLength > 0)
		{
			for (int num = 0; num < src.AnimationBlueprintsLength; num++)
			{
				preloadSaveData.Others.Add(src.AnimationBlueprints(num));
			}
		}
		if (src.OthersLength > 0)
		{
			for (int num2 = 0; num2 < src.OthersLength; num2++)
			{
				preloadSaveData.Others.Add(src.Others(num2));
			}
		}
		return preloadSaveData;
	}

	// Token: 0x0601C884 RID: 116868 RVA: 0x0088E79C File Offset: 0x0088C99C
	private PreloadSaveData BuildPreloadSaveData(ModelConfigPreload src)
	{
		PreloadModelConfigSaveData preloadModelConfigSaveData = new PreloadModelConfigSaveData();
		if (src.ActorClassLength > 0)
		{
			for (int i = 0; i < src.ActorClassLength; i++)
			{
				preloadModelConfigSaveData.Others.Add(src.ActorClass(i));
			}
		}
		if (src.AnimationsLength > 0)
		{
			if (preloadModelConfigSaveData.Animations == null)
			{
				preloadModelConfigSaveData.Animations = new List<string>();
			}
			preloadModelConfigSaveData.Animations.Clear();
			for (int j = 0; j < src.AnimationsLength; j++)
			{
				preloadModelConfigSaveData.Animations.Add(src.Animations(j));
			}
		}
		if (src.EffectsLength > 0)
		{
			for (int k = 0; k < src.EffectsLength; k++)
			{
				preloadModelConfigSaveData.Others.Add(src.Effects(k));
			}
		}
		if (src.AudiosLength > 0)
		{
			for (int l = 0; l < src.AudiosLength; l++)
			{
				preloadModelConfigSaveData.Others.Add(src.Audios(l));
			}
		}
		if (src.MaterialsLength > 0)
		{
			for (int m = 0; m < src.MaterialsLength; m++)
			{
				preloadModelConfigSaveData.Others.Add(src.Materials(m));
			}
		}
		if (src.MeshesLength > 0)
		{
			for (int n = 0; n < src.MeshesLength; n++)
			{
				preloadModelConfigSaveData.Others.Add(src.Meshes(n));
			}
		}
		if (src.AnimationBlueprintsLength > 0)
		{
			for (int num = 0; num < src.AnimationBlueprintsLength; num++)
			{
				preloadModelConfigSaveData.Others.Add(src.AnimationBlueprints(num));
			}
		}
		if (src.OthersLength > 0)
		{
			for (int num2 = 0; num2 < src.OthersLength; num2++)
			{
				preloadModelConfigSaveData.Others.Add(src.Others(num2));
			}
		}
		return preloadModelConfigSaveData;
	}

	// Token: 0x0601C885 RID: 116869 RVA: 0x0088E960 File Offset: 0x0088CB60
	private PreloadSaveData BuildPreloadSaveData(IDbAssetElement src)
	{
		PreloadSaveData preloadSaveData = new PreloadSaveData();
		if (src.ActorClass.Count > 0)
		{
			preloadSaveData.Others.AddRange(src.ActorClass);
		}
		if (src.Animations.Count > 0)
		{
			preloadSaveData.Animations = new List<string>(src.Animations);
		}
		if (src.Effects.Count > 0)
		{
			preloadSaveData.Others.AddRange(src.Effects);
		}
		if (src.Audios.Count > 0)
		{
			preloadSaveData.Others.AddRange(src.Audios);
		}
		if (src.Materials.Count > 0)
		{
			preloadSaveData.Others.AddRange(src.Materials);
		}
		if (src.Meshes.Count > 0)
		{
			preloadSaveData.Others.AddRange(src.Meshes);
		}
		if (src.AnimationBlueprints.Count > 0)
		{
			preloadSaveData.Others.AddRange(src.AnimationBlueprints);
		}
		if (src.Others.Count > 0)
		{
			preloadSaveData.Others.AddRange(src.Others);
		}
		return preloadSaveData;
	}

	// Token: 0x0601C886 RID: 116870 RVA: 0x0088EA6C File Offset: 0x0088CC6C
	protected override bool OnClear()
	{
		UHoldPreloadObject holdPreloadObjectInternal = this.HoldPreloadObjectInternal;
		if (holdPreloadObjectInternal != null)
		{
			holdPreloadObjectInternal.Clear();
		}
		UHoldPreloadObject holdPreloadObjectInternal2 = this.HoldPreloadObjectInternal;
		if (holdPreloadObjectInternal2 != null && holdPreloadObjectInternal2.IsValid())
		{
			this.HoldPreloadObjectInternal.Clear();
		}
		this.HoldPreloadObjectInternal = null;
		this.PreCreateEffect.UnregisterTick();
		this.PreCreateEffect.Clear();
		this.CommonSkillMap.Clear();
		this.PlotAssetManager.Clear();
		this.PlotUiAssetManager.Clear();
		return true;
	}

	// Token: 0x0601C887 RID: 116871 RVA: 0x0088EAE8 File Offset: 0x0088CCE8
	public void AddPreloadResource(string path)
	{
		if (this.PreloadAssetMap.ContainsKey(path))
		{
			int num = this.PreloadAssetMap[path];
			this.PreloadAssetMap[path] = num + 1;
			return;
		}
		this.PreloadAssetMap[path] = 1;
	}

	// Token: 0x0601C888 RID: 116872 RVA: 0x0088EB30 File Offset: 0x0088CD30
	public bool RemovePreloadResource(string path)
	{
		if (!this.PreloadAssetMap.ContainsKey(path))
		{
			return false;
		}
		int num = this.PreloadAssetMap[path];
		if (num > 0)
		{
			num--;
			this.PreloadAssetMap[path] = num;
		}
		if (num == 0)
		{
			this.PreloadAssetMap.Remove(path);
		}
		return true;
	}

	// Token: 0x0601C889 RID: 116873 RVA: 0x0088EB80 File Offset: 0x0088CD80
	public void ClearPreloadResource()
	{
		this.PreloadAssetMap.Clear();
		this.HoldPreloadObjectInternal.Clear();
		this.LoadingNeedWaitEntitySet.Clear();
	}

	// Token: 0x0601C88A RID: 116874 RVA: 0x0088EBA3 File Offset: 0x0088CDA3
	public bool AddEntityAsset(long creatureDataId, EntityAssetElement entityAsset)
	{
		if (this.AllEntityAssetMap.ContainsKey(creatureDataId))
		{
			return false;
		}
		this.AllEntityAssetMap[creatureDataId] = entityAsset;
		return true;
	}

	// Token: 0x0601C88B RID: 116875 RVA: 0x0088EBC3 File Offset: 0x0088CDC3
	public bool HasEntityAsset(long creatureDataId)
	{
		return this.AllEntityAssetMap.ContainsKey(creatureDataId);
	}

	// Token: 0x0601C88C RID: 116876 RVA: 0x0088EBD1 File Offset: 0x0088CDD1
	[NullableContext(2)]
	public EntityAssetElement GetEntityAssetElement(long creatureDataId)
	{
		return this.AllEntityAssetMap.GetValueOrDefault(creatureDataId);
	}

	// Token: 0x0601C88D RID: 116877 RVA: 0x0088EBDF File Offset: 0x0088CDDF
	public bool RemoveEntityAsset(long creatureDataId)
	{
		return this.AllEntityAssetMap.Remove(creatureDataId);
	}

	// Token: 0x0601C88E RID: 116878 RVA: 0x0088EBED File Offset: 0x0088CDED
	public void ClearEntityAsset()
	{
		this.AllEntityAssetMap.Clear();
	}

	// Token: 0x0601C88F RID: 116879 RVA: 0x0088EBFA File Offset: 0x0088CDFA
	public bool AddPbEntityAsset(int pbDataId, PbEntityAssetElement entityAsset)
	{
		if (this.AllPbEntityAssetMap.ContainsKey(pbDataId))
		{
			return false;
		}
		this.AllPbEntityAssetMap[pbDataId] = entityAsset;
		return true;
	}

	// Token: 0x0601C890 RID: 116880 RVA: 0x0088EC1A File Offset: 0x0088CE1A
	public bool HasPbEntityAsset(int pbDataId)
	{
		return this.AllPbEntityAssetMap.ContainsKey(pbDataId);
	}

	// Token: 0x0601C891 RID: 116881 RVA: 0x0088EC28 File Offset: 0x0088CE28
	[NullableContext(2)]
	public PbEntityAssetElement GetPbEntityAssetElement(int pbDataId)
	{
		return this.AllPbEntityAssetMap.GetValueOrDefault(pbDataId);
	}

	// Token: 0x0601C892 RID: 116882 RVA: 0x0088EC36 File Offset: 0x0088CE36
	public bool RemovePbEntityAsset(int pbDataId)
	{
		return this.AllPbEntityAssetMap.Remove(pbDataId);
	}

	// Token: 0x0601C893 RID: 116883 RVA: 0x0088EC44 File Offset: 0x0088CE44
	public void ClearPbEntityAsset()
	{
		foreach (KeyValuePair<int, PbEntityAssetElement> keyValuePair in this.AllPbEntityAssetMap)
		{
			keyValuePair.Value.Clear();
		}
		this.AllPbEntityAssetMap.Clear();
	}

	// Token: 0x0601C894 RID: 116884 RVA: 0x0088ECA8 File Offset: 0x0088CEA8
	public void CleanPlotAsset()
	{
		this.PlotAssetManager.RemoveAllPreload();
	}

	// Token: 0x0601C895 RID: 116885 RVA: 0x0088ECB5 File Offset: 0x0088CEB5
	public void AddNeedWaitEntity(int entityId)
	{
		this.LoadingNeedWaitEntitySet.Add(entityId);
	}

	// Token: 0x0601C896 RID: 116886 RVA: 0x0088ECC4 File Offset: 0x0088CEC4
	public void RemoveNeedWaitEntity(int entityId)
	{
		this.LoadingNeedWaitEntitySet.Remove(entityId);
	}

	// Token: 0x0601C897 RID: 116887 RVA: 0x0088ECD4 File Offset: 0x0088CED4
	public bool AddCommonSkill(int skillId, bool hasMontage, AssetElement assetElement)
	{
		if (this.CommonSkillMap.ContainsKey((long)skillId))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Preload;
			ELogAuthor author = ELogAuthor.YZ;
			string message = "[预加载] 重复添加技能";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SkillId", skillId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.CommonSkillMap[(long)skillId] = new ValueTuple<bool, AssetElement>(hasMontage, assetElement);
		return true;
	}

	// Token: 0x0601C898 RID: 116888 RVA: 0x0088ED32 File Offset: 0x0088CF32
	public bool IsCommonSkill(int skillId)
	{
		return this.CommonSkillMap.ContainsKey((long)skillId);
	}

	// Token: 0x0601C899 RID: 116889 RVA: 0x0088ED44 File Offset: 0x0088CF44
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<bool, AssetElement>? GetCommonSkill(int skillId)
	{
		ValueTuple<bool, AssetElement> value;
		if (this.CommonSkillMap.TryGetValue((long)skillId, out value))
		{
			return new ValueTuple<bool, AssetElement>?(value);
		}
		return null;
	}

	// Token: 0x0601C89A RID: 116890 RVA: 0x0088ED72 File Offset: 0x0088CF72
	public void AddResourcesLoadTime([Nullable(new byte[]
	{
		0,
		1
	})] ValueTuple<string, int> loadTime)
	{
		this.ResourcesLoadTime.Add(loadTime);
	}

	// Token: 0x0601C89B RID: 116891 RVA: 0x0088ED80 File Offset: 0x0088CF80
	public void ClearResourcesLoadTime()
	{
		this.ResourcesLoadTime.Clear();
	}

	// Token: 0x0400E5AA RID: 58794
	public bool EnablePreloadLog;

	// Token: 0x0400E5AB RID: 58795
	[Nullable(2)]
	public string ProjectPath;

	// Token: 0x0400E5AC RID: 58796
	[Nullable(2)]
	public string JsonExportRootPath;

	// Token: 0x0400E5AD RID: 58797
	[Nullable(2)]
	public string ModelConfigJsonExportPath;

	// Token: 0x0400E5AE RID: 58798
	[Nullable(2)]
	public string SkillJsonExportPath;

	// Token: 0x0400E5AF RID: 58799
	[Nullable(2)]
	public string CommonSkillJsonExportPath;

	// Token: 0x0400E5B0 RID: 58800
	[Nullable(2)]
	public string BulletJsonExportPath;

	// Token: 0x0400E5B1 RID: 58801
	[Nullable(2)]
	public string StateMachineJsonExportPath;

	// Token: 0x0400E5B2 RID: 58802
	public readonly PreCreateEffect PreCreateEffect = new PreCreateEffect();

	// Token: 0x0400E5B3 RID: 58803
	public readonly CommonAssetElement CommonAssetElement = new CommonAssetElement(null);

	// Token: 0x0400E5B4 RID: 58804
	public readonly Dictionary<string, int> PreloadAssetMap = new Dictionary<string, int>();

	// Token: 0x0400E5B5 RID: 58805
	public readonly Dictionary<int, Dictionary<int, PbDataPreload>> PbDataPreloadDataMap = new Dictionary<int, Dictionary<int, PbDataPreload>>();

	// Token: 0x0400E5B6 RID: 58806
	public readonly Dictionary<long, EntityAssetElement> AllEntityAssetMap = new Dictionary<long, EntityAssetElement>();

	// Token: 0x0400E5B7 RID: 58807
	public readonly Dictionary<int, PbEntityAssetElement> AllPbEntityAssetMap = new Dictionary<int, PbEntityAssetElement>();

	// Token: 0x0400E5B8 RID: 58808
	public readonly PlotAssetManager PlotAssetManager = new PlotAssetManager();

	// Token: 0x0400E5B9 RID: 58809
	public readonly PlotUiAssetManager PlotUiAssetManager = new PlotUiAssetManager();

	// Token: 0x0400E5BA RID: 58810
	[TupleElementNames(new string[]
	{
		"hasMontage",
		"assetElement"
	})]
	[Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	private readonly Dictionary<long, ValueTuple<bool, AssetElement>> CommonSkillMap = new Dictionary<long, ValueTuple<bool, AssetElement>>();

	// Token: 0x0400E5BB RID: 58811
	[Nullable(2)]
	private UHoldPreloadObject HoldPreloadObjectInternal;

	// Token: 0x0400E5BC RID: 58812
	public readonly Dictionary<string, Dictionary<long, PreloadSaveData>> BulletPreloadDataMap = new Dictionary<string, Dictionary<long, PreloadSaveData>>();

	// Token: 0x0400E5BD RID: 58813
	public CommonSkillPreload[] CommonSkillPreloadDataMap = Array.Empty<CommonSkillPreload>();

	// Token: 0x0400E5BE RID: 58814
	public readonly Dictionary<int, PreloadModelConfigSaveData> ModelConfigPreloadDataMap = new Dictionary<int, PreloadModelConfigSaveData>();

	// Token: 0x0400E5BF RID: 58815
	public readonly Dictionary<string, PreloadSaveData> StateMachinePreloadDataMap = new Dictionary<string, PreloadSaveData>();

	// Token: 0x0400E5C0 RID: 58816
	public readonly Dictionary<int, PreloadSaveData> TemplatePreloadDataMap = new Dictionary<int, PreloadSaveData>();

	// Token: 0x0400E5C1 RID: 58817
	public readonly Dictionary<string, List<PreloadSkillSaveData>> SkillPreloadDataMap = new Dictionary<string, List<PreloadSkillSaveData>>();

	// Token: 0x0400E5C2 RID: 58818
	public readonly HashSet<int> LoadingNeedWaitEntitySet = new HashSet<int>();

	// Token: 0x0400E5C3 RID: 58819
	public bool UseEntityProfilerInternal = true;

	// Token: 0x0400E5C4 RID: 58820
	public bool LoadAssetOneByOneState;

	// Token: 0x0400E5C5 RID: 58821
	[Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	public List<ValueTuple<string, int>> ResourcesLoadTime = new List<ValueTuple<string, int>>();
}
