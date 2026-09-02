using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x020025B2 RID: 9650
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class PhotographModel : ModelBase<PhotographModel>
{
	// Token: 0x06012D43 RID: 77123 RVA: 0x00534A03 File Offset: 0x00532C03
	protected override bool OnInit()
	{
		this.SavePath = ConfigCommonParamById.GetStringConfig("ScreenShotSavePath");
		return true;
	}

	// Token: 0x06012D44 RID: 77124 RVA: 0x00534A16 File Offset: 0x00532C16
	protected override bool OnClear()
	{
		this.DestroyUiCamera();
		return true;
	}

	// Token: 0x06012D45 RID: 77125 RVA: 0x00534A1F File Offset: 0x00532C1F
	protected override bool OnLeaveLevel()
	{
		this.DestroyUiCamera();
		return true;
	}

	// Token: 0x06012D46 RID: 77126 RVA: 0x00534A28 File Offset: 0x00532C28
	public UiCameraPhotographerStructure SpawnPhotographerStructure(FVectorDouble playerLocation, FQuat rotation, FVectorDouble scale, FVectorDouble cameraLocation)
	{
		this.SpawnTransformCache.SetLocation(playerLocation);
		this.SpawnTransformCache.SetRotation(rotation);
		this.SpawnTransformCache.SetScale3D(scale);
		UiCamera uiCamera = UiCameraManager.Get();
		this.UiCameraPhotographerStructure = uiCamera.PushStructure<UiCameraPhotographerStructure>();
		this.UiCameraPhotographerStructure.SetActorTransform(this.SpawnTransformCache);
		if (ControllerBase<PhotographController>.Instance.CheckIfInFightPhotographCamera())
		{
			this.UiCameraPhotographerStructure.SetCameraArmTargetOffset(cameraLocation, true);
		}
		uiCamera.GetUiCameraComponent<UiCameraPostEffectComponent>().SetCameraFocalDistance(300f);
		return this.UiCameraPhotographerStructure;
	}

	// Token: 0x06012D47 RID: 77127 RVA: 0x00534AAF File Offset: 0x00532CAF
	public void DestroyUiCamera()
	{
		UiCameraManager.Destroy(0.5f, EViewTargetBlendFunction.VTBlend_Linear, 0f);
		this.UiCameraPhotographerStructure = null;
	}

	// Token: 0x06012D48 RID: 77128 RVA: 0x00534AC8 File Offset: 0x00532CC8
	[NullableContext(2)]
	public UiCameraPhotographerStructure GetPhotographerStructure()
	{
		return this.UiCameraPhotographerStructure;
	}

	// Token: 0x06012D49 RID: 77129 RVA: 0x00534AD0 File Offset: 0x00532CD0
	public void SetPhotographOption(EPhotoSetupValueType valueType, float value)
	{
		if (this.PhotographOptionMap.ContainsKey(valueType))
		{
			this.PhotographOptionMap[valueType] = value;
			return;
		}
		this.PhotographOptionMap.Add(valueType, value);
	}

	// Token: 0x06012D4A RID: 77130 RVA: 0x00534AFB File Offset: 0x00532CFB
	public void ClearPhotographOption()
	{
		this.PhotographOptionMap.Clear();
	}

	// Token: 0x06012D4B RID: 77131 RVA: 0x00534B08 File Offset: 0x00532D08
	public float? GetPhotographOption(EPhotoSetupValueType valueType)
	{
		float value;
		if (this.PhotographOptionMap.TryGetValue(valueType, out value))
		{
			return new float?(value);
		}
		return null;
	}

	// Token: 0x06012D4C RID: 77132 RVA: 0x00534B35 File Offset: 0x00532D35
	public IReadOnlyDictionary<EPhotoSetupValueType, float> GetAllPhotographOption()
	{
		return this.PhotographOptionMap;
	}

	// Token: 0x06012D4D RID: 77133 RVA: 0x00534B40 File Offset: 0x00532D40
	public void SetEntityEnable(EntityHandle handle, bool bEnable)
	{
		if (handle == null || !handle.Valid || handle.Entity == null || !handle.Entity.Valid)
		{
			return;
		}
		if (handle.Entity.Active == bEnable)
		{
			return;
		}
		if (!bEnable)
		{
			if (this.SetDisableEntity != null)
			{
				this.ResetEntityEnable();
			}
			this.MontageId = 0;
			this.SetDisableEntity = handle;
			this.EntityDisableId = new int?(handle.Entity.Disable("[PhotographModel.SetEntityEnable] bEnable为false"));
			return;
		}
		if (this.SetDisableEntity != null && handle.Id == this.SetDisableEntity.Id)
		{
			handle.Entity.Enable(this.EntityDisableId.Value, "PhotographModel.SetEntityEnable");
			this.EntityDisableId = null;
			this.SetDisableEntity = null;
			return;
		}
		this.ResetEntityEnable();
	}

	// Token: 0x06012D4E RID: 77134 RVA: 0x00534C0C File Offset: 0x00532E0C
	public void ResetEntityEnable()
	{
		if (this.SetDisableEntity != null)
		{
			WorldEntity entity = this.SetDisableEntity.Entity;
			if (entity != null)
			{
				entity.Enable(this.EntityDisableId.Value, "PhotographModel.ResetEntityEnable");
			}
		}
		this.EntityDisableId = null;
		this.SetDisableEntity = null;
	}

	// Token: 0x06012D4F RID: 77135 RVA: 0x00534C5B File Offset: 0x00532E5B
	public void SetPhotographFilter(int filterId)
	{
		this.FilterId = filterId;
	}

	// Token: 0x06012D50 RID: 77136 RVA: 0x00534C64 File Offset: 0x00532E64
	public void ClearPhotographFilter()
	{
		this.ClearSelectedPhotographFilter();
		this.FilterStrengthMap.Clear();
		this.IsFilterToggleOpen = true;
	}

	// Token: 0x06012D51 RID: 77137 RVA: 0x00534C7E File Offset: 0x00532E7E
	public void ClearSelectedPhotographFilter()
	{
		this.FilterId = 0;
		ControllerBase<PhotographController>.Instance.InitPostProcessVolBlendWeight(1);
	}

	// Token: 0x06012D52 RID: 77138 RVA: 0x00534C92 File Offset: 0x00532E92
	public int GetPhotographFilter()
	{
		return this.FilterId;
	}

	// Token: 0x06012D53 RID: 77139 RVA: 0x00534C9C File Offset: 0x00532E9C
	public void InitFilterPostProcessVolume()
	{
		string key = "Filter";
		TArray<AActor> tarray = new TArray<AActor>();
		UGameplayStatics.GetAllActorsOfClassWithTag(GlobalData.World, APostProcessVolume.StaticClass(), FNameUtil.GetDynamicFName(key).Value, ref tarray);
		if (tarray == null || tarray.Num() <= 0)
		{
			return;
		}
		int num = tarray.Num();
		for (int i = 0; i < num; i++)
		{
			APostProcessVolume apostProcessVolume = tarray.Get(i) as APostProcessVolume;
			if (apostProcessVolume != null)
			{
				apostProcessVolume.BlendWeight = 0f;
				if (apostProcessVolume.Tags.Num() >= 2)
				{
					string key2 = apostProcessVolume.Tags.Get(1).ToString();
					if (this.PostProcessVolumeMap.ContainsKey(key2))
					{
						this.PostProcessVolumeMap[key2] = apostProcessVolume;
					}
					else
					{
						this.PostProcessVolumeMap.Add(key2, apostProcessVolume);
					}
				}
			}
		}
	}

	// Token: 0x06012D54 RID: 77140 RVA: 0x00534D7E File Offset: 0x00532F7E
	public Dictionary<string, APostProcessVolume> GetFilterPostProcessVolumeMap()
	{
		return this.PostProcessVolumeMap;
	}

	// Token: 0x06012D55 RID: 77141 RVA: 0x00534D88 File Offset: 0x00532F88
	public float GetFilterStrengthByFilterId(int filterId)
	{
		float result;
		if (!this.FilterStrengthMap.TryGetValue(filterId, out result))
		{
			return 1f;
		}
		return result;
	}

	// Token: 0x06012D56 RID: 77142 RVA: 0x00534DAC File Offset: 0x00532FAC
	public void SetFilterStrength(int filterId, float filterStrength)
	{
		if (this.FilterStrengthMap.ContainsKey(filterId))
		{
			this.FilterStrengthMap[filterId] = filterStrength;
			return;
		}
		this.FilterStrengthMap.Add(filterId, filterStrength);
	}

	// Token: 0x06012D57 RID: 77143 RVA: 0x00534DD7 File Offset: 0x00532FD7
	public void SetFilterToggleState(bool isOpen)
	{
		this.IsFilterToggleOpen = isOpen;
	}

	// Token: 0x06012D58 RID: 77144 RVA: 0x00534DE0 File Offset: 0x00532FE0
	public bool GetFilterToggleState()
	{
		return this.IsFilterToggleOpen;
	}

	// Token: 0x06012D59 RID: 77145 RVA: 0x00534DE8 File Offset: 0x00532FE8
	public void SetPhotographTimeDilation(float timeDilation)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Photograph;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "SetPhotographTimeDilation";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("timeDilation", timeDilation);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (timeDilation != 1f)
		{
			Singleton<AudioSystem>.Instance.SetState("game_sys_fightphoto", "slow", true);
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_battlephoto_timestop");
		}
		ControllerBase<GameModeController>.Instance.SetTimeDilation(timeDilation, ETimeDilationType.Photograph);
	}

	// Token: 0x0400932C RID: 37676
	[Nullable(2)]
	private UiCameraPhotographerStructure UiCameraPhotographerStructure;

	// Token: 0x0400932D RID: 37677
	[Nullable(2)]
	public EntityHandle PlayMontageEntity;

	// Token: 0x0400932E RID: 37678
	public int MontageId;

	// Token: 0x0400932F RID: 37679
	public int FilterId;

	// Token: 0x04009330 RID: 37680
	private readonly Dictionary<EPhotoSetupValueType, float> PhotographOptionMap = new Dictionary<EPhotoSetupValueType, float>();

	// Token: 0x04009331 RID: 37681
	private readonly Dictionary<string, APostProcessVolume> PostProcessVolumeMap = new Dictionary<string, APostProcessVolume>();

	// Token: 0x04009332 RID: 37682
	private readonly Dictionary<int, float> FilterStrengthMap = new Dictionary<int, float>();

	// Token: 0x04009333 RID: 37683
	private FTransformDouble SpawnTransformCache = new FTransformDouble();

	// Token: 0x04009334 RID: 37684
	public float RightValue;

	// Token: 0x04009335 RID: 37685
	public float UpValue;

	// Token: 0x04009336 RID: 37686
	public float ForwardValue;

	// Token: 0x04009337 RID: 37687
	private int? EntityDisableId = new int?(0);

	// Token: 0x04009338 RID: 37688
	[Nullable(2)]
	private EntityHandle SetDisableEntity;

	// Token: 0x04009339 RID: 37689
	public bool IsOpenPhotograph;

	// Token: 0x0400933A RID: 37690
	public string SavePath = "";

	// Token: 0x0400933B RID: 37691
	public bool IsSaveButtonVisible;

	// Token: 0x0400933C RID: 37692
	public bool IsFilterToggleOpen = true;

	// Token: 0x0400933D RID: 37693
	public int? PlayerActionSortId;

	// Token: 0x0400933E RID: 37694
	public Transform CameraTransformProxy = Transform.Create();

	// Token: 0x0400933F RID: 37695
	public HashSet<string> SequenceInValidSectionSet = new HashSet<string>();

	// Token: 0x04009340 RID: 37696
	public Dictionary<int, HashSet<string>> MontageTagSet = new Dictionary<int, HashSet<string>>();

	// Token: 0x04009341 RID: 37697
	public HashSet<int> NpcFaceSet = new HashSet<int>();

	// Token: 0x04009342 RID: 37698
	public double ChangeNpcFaceRangeSquared = 9000000.0;
}
