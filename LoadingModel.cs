using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Ui;

// Token: 0x020020D9 RID: 8409
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class LoadingModel : ModelBase<LoadingModel>
{
	// Token: 0x17001355 RID: 4949
	// (get) Token: 0x060100FD RID: 65789 RVA: 0x00468E68 File Offset: 0x00467068
	public int TipTime
	{
		get
		{
			if (this.TipsTimeInternal == 0)
			{
				this.TipsTimeInternal = ConfigBase<LoadingConfig>.Instance.GetLoadingTipsTime();
			}
			return this.TipsTimeInternal;
		}
	}

	// Token: 0x17001356 RID: 4950
	// (get) Token: 0x060100FE RID: 65790 RVA: 0x00468E88 File Offset: 0x00467088
	// (set) Token: 0x060100FF RID: 65791 RVA: 0x00468E90 File Offset: 0x00467090
	public bool IsShowUidView
	{
		get
		{
			return this.IsShowUidViewInternal;
		}
		set
		{
			if (value == this.IsShowUidViewInternal)
			{
				return;
			}
			this.IsShowUidViewInternal = value;
			ControllerBase<LoadingController>.Instance.UpdateUidViewShow();
		}
	}

	// Token: 0x17001357 RID: 4951
	// (get) Token: 0x06010101 RID: 65793 RVA: 0x00468EB6 File Offset: 0x004670B6
	// (set) Token: 0x06010100 RID: 65792 RVA: 0x00468EAD File Offset: 0x004670AD
	public int LastInstanceId
	{
		get
		{
			return this.LastInstanceIdInternal;
		}
		set
		{
			this.LastInstanceIdInternal = value;
		}
	}

	// Token: 0x17001358 RID: 4952
	// (get) Token: 0x06010102 RID: 65794 RVA: 0x00468EBE File Offset: 0x004670BE
	public bool IsLoading
	{
		get
		{
			return this.IsLoadingInternal;
		}
	}

	// Token: 0x06010103 RID: 65795 RVA: 0x00468EC6 File Offset: 0x004670C6
	public void SetIsLoading(bool isLoading)
	{
		if (this.IsLoadingInternal == isLoading)
		{
			return;
		}
		this.IsLoadingInternal = isLoading;
		if (isLoading)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnStartLoadingState);
			return;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnFinishLoadingState);
	}

	// Token: 0x17001359 RID: 4953
	// (get) Token: 0x06010104 RID: 65796 RVA: 0x00468EFD File Offset: 0x004670FD
	public bool IsLoadingView
	{
		get
		{
			return this.IsLoadingViewInternal;
		}
	}

	// Token: 0x06010105 RID: 65797 RVA: 0x00468F05 File Offset: 0x00467105
	public void SetIsLoadingView(bool isLoadingView)
	{
		if (this.IsLoadingViewInternal == isLoadingView)
		{
			return;
		}
		this.IsLoadingViewInternal = isLoadingView;
		if (isLoadingView)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnOpenLoadingView);
			return;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnCloseLoadingView);
	}

	// Token: 0x06010106 RID: 65798 RVA: 0x00468F3C File Offset: 0x0046713C
	public void SetIsLoginToWorld(bool isLoginToWorld)
	{
		this.IsLoginToWorld = isLoginToWorld;
	}

	// Token: 0x06010107 RID: 65799 RVA: 0x00468F45 File Offset: 0x00467145
	public bool GetIsLoginToWorld()
	{
		bool isLoginToWorld = this.IsLoginToWorld;
		this.IsLoginToWorld = false;
		return isLoginToWorld;
	}

	// Token: 0x06010108 RID: 65800 RVA: 0x00468F54 File Offset: 0x00467154
	[NullableContext(1)]
	public void SetLoadingTexturePath(string loadingPath)
	{
		this.LoadingTexturePathInternal = loadingPath;
	}

	// Token: 0x06010109 RID: 65801 RVA: 0x00468F5D File Offset: 0x0046715D
	public string GetLoadingTexturePath()
	{
		return this.LoadingTexturePathInternal;
	}

	// Token: 0x0601010A RID: 65802 RVA: 0x00468F65 File Offset: 0x00467165
	[NullableContext(1)]
	public void SetLoadingTitle(string loadingTitle)
	{
		this.LoadingTitleInternal = loadingTitle;
	}

	// Token: 0x0601010B RID: 65803 RVA: 0x00468F6E File Offset: 0x0046716E
	public string GetLoadingTitle()
	{
		return this.LoadingTitleInternal;
	}

	// Token: 0x0601010C RID: 65804 RVA: 0x00468F76 File Offset: 0x00467176
	[NullableContext(1)]
	public void SetLoadingTips(string loadingTips)
	{
		this.LoadingTipsInternal = loadingTips;
	}

	// Token: 0x0601010D RID: 65805 RVA: 0x00468F7F File Offset: 0x0046717F
	public string GetLoadingTips()
	{
		return this.LoadingTipsInternal;
	}

	// Token: 0x0601010E RID: 65806 RVA: 0x00468F88 File Offset: 0x00467188
	public EUiViewName GetOpenLoadingViewName()
	{
		if (this.CustomLoadingViewType != null && this.CustomLoadingViewType.Value == ECustomScreenLoading.Cyberpunk)
		{
			return EUiViewName.CyberpunkLoadingView;
		}
		if (this.RoleLoadingConfig != null)
		{
			return EUiViewName.RoleLoadingView;
		}
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		EUiViewName? loadingViewNameByInstanceId = this.GetLoadingViewNameByInstanceId(instanceId, true);
		if (loadingViewNameByInstanceId != null)
		{
			return loadingViewNameByInstanceId.Value;
		}
		EUiViewName? loadingViewNameByInstanceId2 = this.GetLoadingViewNameByInstanceId(this.LastInstanceId, false);
		if (loadingViewNameByInstanceId2 != null)
		{
			return loadingViewNameByInstanceId2.Value;
		}
		return EUiViewName.LoadingView;
	}

	// Token: 0x0601010F RID: 65807 RVA: 0x00469014 File Offset: 0x00467214
	private EUiViewName? GetLoadingViewNameByInstanceId(int instanceId, bool isEnter)
	{
		if (instanceId <= 0)
		{
			return null;
		}
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		if (config == null)
		{
			return null;
		}
		EUiViewName? loadingViewNameBySpecialCustomType = this.GetLoadingViewNameBySpecialCustomType(instanceId);
		if (loadingViewNameBySpecialCustomType != null)
		{
			return loadingViewNameBySpecialCustomType;
		}
		int instSubType = config.Value.InstSubType;
		LoadingDefine.IDungeonLoadingData valueOrDefault = LoadingDefine.dungeonToLoadingViewMap.GetValueOrDefault((EDungeonSubType)instSubType);
		if (valueOrDefault == null)
		{
			return null;
		}
		if (!isEnter && valueOrDefault.IgnoreExitLoading != null && valueOrDefault.IgnoreExitLoading.Value)
		{
			return null;
		}
		if (valueOrDefault.Filter != null && !valueOrDefault.Filter(instanceId))
		{
			return null;
		}
		if (valueOrDefault.WorldSubType == null)
		{
			return new EUiViewName?(valueOrDefault.View);
		}
		if (valueOrDefault.WorldSubType.Value == (EWorldDungeonSubType)config.Value.WorldDungeonSubType)
		{
			return new EUiViewName?(valueOrDefault.View);
		}
		return null;
	}

	// Token: 0x06010110 RID: 65808 RVA: 0x00469134 File Offset: 0x00467334
	private EUiViewName? GetLoadingViewNameBySpecialCustomType(int instanceId)
	{
		foreach (ISpecialCustomLoadingTypeChecker specialCustomLoadingTypeChecker in this.SpecialCustomLoadingCheckers)
		{
			if (specialCustomLoadingTypeChecker.CanHandle(instanceId))
			{
				return specialCustomLoadingTypeChecker.GetLoadingViewName(instanceId);
			}
		}
		return null;
	}

	// Token: 0x06010111 RID: 65809 RVA: 0x00469174 File Offset: 0x00467374
	[NullableContext(1)]
	public void SetLoadingConfig(IList<LoadingAreaConfig> loadingConfig)
	{
		this.LoadingAreaConfig = loadingConfig;
	}

	// Token: 0x06010112 RID: 65810 RVA: 0x00469180 File Offset: 0x00467380
	public List<int> GetLoadingConfigId()
	{
		if (this.LoadingAreaConfig == null)
		{
			return null;
		}
		if (this.LoadingAreaConfig.Count <= 0)
		{
			this.LoadingAreaConfig = null;
			return null;
		}
		List<int> list = new List<int>();
		foreach (LoadingAreaConfig other in this.LoadingAreaConfig)
		{
			LoadingAreaConfig loadingAreaConfig = new LoadingAreaConfig(other);
			double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
			long beginTime = loadingAreaConfig.BeginTime;
			long endTime = loadingAreaConfig.EndTime;
			if (serverTimeStamp >= (double)beginTime && serverTimeStamp <= (double)endTime)
			{
				list.Add(loadingAreaConfig.Id);
			}
		}
		this.LoadingAreaConfig = null;
		return list;
	}

	// Token: 0x06010113 RID: 65811 RVA: 0x00469230 File Offset: 0x00467430
	public void SetRoleLoadingConfig(int? id)
	{
		if (id == null)
		{
			return;
		}
		this.RoleLoadingConfig = ConfigCharacterDisplayStyleById.GetConfig(id.Value, true);
	}

	// Token: 0x1700135A RID: 4954
	// (get) Token: 0x06010114 RID: 65812 RVA: 0x0046924F File Offset: 0x0046744F
	public CharacterDisplayStyle? RoleLoading
	{
		get
		{
			return this.RoleLoadingConfig;
		}
	}

	// Token: 0x06010115 RID: 65813 RVA: 0x00469257 File Offset: 0x00467457
	public void ClearRoleLoadingInfo()
	{
		this.RoleLoadingConfig = null;
	}

	// Token: 0x06010116 RID: 65814 RVA: 0x00469268 File Offset: 0x00467468
	public void SetSpecifiedLoadingConfigId(int? id)
	{
		if (id == null)
		{
			return;
		}
		LoadingLevelArea? levelAreaById = ConfigBase<LoadingConfig>.Instance.GetLevelAreaById(id.Value);
		if (levelAreaById != null && levelAreaById.Value.Type == 2)
		{
			this.SpecifiedLoadingConfig = levelAreaById;
		}
	}

	// Token: 0x06010117 RID: 65815 RVA: 0x004692B3 File Offset: 0x004674B3
	public LoadingLevelArea? GetSpecifiedLoadingConfig()
	{
		return this.SpecifiedLoadingConfig;
	}

	// Token: 0x06010118 RID: 65816 RVA: 0x004692BB File Offset: 0x004674BB
	public void ClearSpecifiedLoadingConfig()
	{
		this.SpecifiedLoadingConfig = null;
	}

	// Token: 0x06010119 RID: 65817 RVA: 0x004692C9 File Offset: 0x004674C9
	public void SetCustomLoadingViewType(ECustomScreenLoading? type)
	{
		this.CustomLoadingViewType = type;
	}

	// Token: 0x0601011A RID: 65818 RVA: 0x004692D2 File Offset: 0x004674D2
	public ECustomScreenLoading? GetCustomLoadingViewType()
	{
		return this.CustomLoadingViewType;
	}

	// Token: 0x0601011B RID: 65819 RVA: 0x004692DC File Offset: 0x004674DC
	[NullableContext(1)]
	public void SetSpecialCustomLoadingInfo(TransitionWithSpecialCustomLoadingPb loadingPb)
	{
		HonamiStoryCustomLoadingPb honamiStoryCustomLoadingPb = loadingPb.HonamiStoryCustomLoadingPb;
		if (honamiStoryCustomLoadingPb != null)
		{
			HonamiStoryLoadingDataImpl mainTaskLoadingData = new HonamiStoryLoadingDataImpl
			{
				LoadingId = new int?(honamiStoryCustomLoadingPb.LoadingId)
			};
			ModelBase<HonamiStoryModel>.Instance.SetMainTaskLoadingData(mainTaskLoadingData);
		}
	}

	// Token: 0x0601011C RID: 65820 RVA: 0x00469318 File Offset: 0x00467518
	[NullableContext(1)]
	public void SetSpecialCustomLoadingInfoByConfig(ITeleportTransitionWithSpecialCustomLoading option)
	{
		IHonamiStoryCustomLoading loadingType = option.LoadingType;
		if (loadingType != null)
		{
			HonamiStoryLoadingDataImpl mainTaskLoadingData = new HonamiStoryLoadingDataImpl
			{
				LoadingId = new int?(loadingType.LoadingId)
			};
			ModelBase<HonamiStoryModel>.Instance.SetMainTaskLoadingData(mainTaskLoadingData);
		}
	}

	// Token: 0x0601011D RID: 65821 RVA: 0x00469351 File Offset: 0x00467551
	protected override bool OnClear()
	{
		this.IsLoadingInternal = false;
		this.IsLoadingViewInternal = false;
		this.CustomLoadingViewType = null;
		this.ReachHandleQueue.Clear();
		return true;
	}

	// Token: 0x04007B1E RID: 31518
	public EScreenEffectType? ScreenEffect;

	// Token: 0x04007B1F RID: 31519
	public int TargetTeleportId;

	// Token: 0x04007B20 RID: 31520
	private int TipsTimeInternal;

	// Token: 0x04007B21 RID: 31521
	private int LastInstanceIdInternal;

	// Token: 0x04007B22 RID: 31522
	private bool IsShowUidViewInternal = true;

	// Token: 0x04007B23 RID: 31523
	private bool IsLoadingInternal;

	// Token: 0x04007B24 RID: 31524
	public int Speed;

	// Token: 0x04007B25 RID: 31525
	public int SpeedRate = 1;

	// Token: 0x04007B26 RID: 31526
	[TupleElementNames(new string[]
	{
		"Progress",
		"reachHandle"
	})]
	[Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	public Queue<ValueTuple<int, Action>> ReachHandleQueue = new Queue<ValueTuple<int, Action>>(4);

	// Token: 0x04007B27 RID: 31527
	public float CurrentProgress;

	// Token: 0x04007B28 RID: 31528
	public int NextProgress;

	// Token: 0x04007B29 RID: 31529
	private bool IsLoadingViewInternal;

	// Token: 0x04007B2A RID: 31530
	private bool IsLoginToWorld;

	// Token: 0x04007B2B RID: 31531
	private string LoadingTexturePathInternal;

	// Token: 0x04007B2C RID: 31532
	public string LoadingTexturePathOverride;

	// Token: 0x04007B2D RID: 31533
	private string LoadingTitleInternal;

	// Token: 0x04007B2E RID: 31534
	private string LoadingTipsInternal;

	// Token: 0x04007B2F RID: 31535
	[Nullable(1)]
	private readonly ISpecialCustomLoadingTypeChecker[] SpecialCustomLoadingCheckers = new ISpecialCustomLoadingTypeChecker[]
	{
		new HonamiStoryLoadingChecker(),
		new LordGymLoadingChecker()
	};

	// Token: 0x04007B30 RID: 31536
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private IList<LoadingAreaConfig> LoadingAreaConfig;

	// Token: 0x04007B31 RID: 31537
	private CharacterDisplayStyle? RoleLoadingConfig;

	// Token: 0x04007B32 RID: 31538
	private LoadingLevelArea? SpecifiedLoadingConfig;

	// Token: 0x04007B33 RID: 31539
	private ECustomScreenLoading? CustomLoadingViewType;

	// Token: 0x04007B34 RID: 31540
	private global::ESpecialCustomLoadingType CurSpecialCustomLoadingType = global::ESpecialCustomLoadingType.HonamiStory;

	// Token: 0x04007B35 RID: 31541
	private ISpecialCustomLoadingData CurSpecialCustomLoadingData;
}
