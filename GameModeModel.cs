using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.DataLayerSwitch;
using UnrealEngine;

// Token: 0x020034B7 RID: 13495
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class GameModeModel : ModelBase<GameModeModel>
{
	// Token: 0x1700267A RID: 9850
	// (get) Token: 0x0601C7E7 RID: 116711 RVA: 0x0088BFC2 File Offset: 0x0088A1C2
	// (set) Token: 0x0601C7E8 RID: 116712 RVA: 0x0088BFCA File Offset: 0x0088A1CA
	public SceneInformation JoinSceneInfo
	{
		get
		{
			return this.JoinSceneInfoInternal;
		}
		set
		{
			this.JoinSceneInfoInternal = value;
		}
	}

	// Token: 0x1700267B RID: 9851
	// (get) Token: 0x0601C7E9 RID: 116713 RVA: 0x0088BFD3 File Offset: 0x0088A1D3
	// (set) Token: 0x0601C7EA RID: 116714 RVA: 0x0088BFDB File Offset: 0x0088A1DB
	public ELoadingPhase LoadingPhase
	{
		get
		{
			return this.LoadingPhaseInternal;
		}
		set
		{
			this.LoadingPhaseInternal = value;
		}
	}

	// Token: 0x1700267C RID: 9852
	// (get) Token: 0x0601C7EB RID: 116715 RVA: 0x0088BFE4 File Offset: 0x0088A1E4
	public bool Loading
	{
		get
		{
			return this.LoadingPhaseInternal > ELoadingPhase.Finished;
		}
	}

	// Token: 0x1700267D RID: 9853
	// (get) Token: 0x0601C7EC RID: 116716 RVA: 0x0088BFEF File Offset: 0x0088A1EF
	// (set) Token: 0x0601C7ED RID: 116717 RVA: 0x0088BFF7 File Offset: 0x0088A1F7
	public bool HasGameModeData
	{
		get
		{
			return this.HasGameModeDataInternal;
		}
		set
		{
			this.HasGameModeDataInternal = value;
		}
	}

	// Token: 0x1700267E RID: 9854
	// (get) Token: 0x0601C7EE RID: 116718 RVA: 0x0088C000 File Offset: 0x0088A200
	// (set) Token: 0x0601C7EF RID: 116719 RVA: 0x0088C008 File Offset: 0x0088A208
	public SceneMode? Mode
	{
		get
		{
			return this.ModeInternal;
		}
		set
		{
			this.ModeInternal = value;
		}
	}

	// Token: 0x1700267F RID: 9855
	// (get) Token: 0x0601C7F0 RID: 116720 RVA: 0x0088C011 File Offset: 0x0088A211
	// (set) Token: 0x0601C7F1 RID: 116721 RVA: 0x0088C019 File Offset: 0x0088A219
	[Nullable(1)]
	public string MapPath
	{
		[NullableContext(1)]
		get
		{
			return this.MapPathInternal;
		}
		[NullableContext(1)]
		set
		{
			this.MapPathInternal = value;
		}
	}

	// Token: 0x17002680 RID: 9856
	// (get) Token: 0x0601C7F2 RID: 116722 RVA: 0x0088C022 File Offset: 0x0088A222
	[Nullable(1)]
	public string LastMapPath
	{
		[NullableContext(1)]
		get
		{
			return this.LastMapPathInternal;
		}
	}

	// Token: 0x0601C7F3 RID: 116723 RVA: 0x0088C02C File Offset: 0x0088A22C
	[NullableContext(1)]
	public unsafe bool AddLoadMapHandle(string handle)
	{
		if (this.LoadMapHandleMap == null)
		{
			this.LoadMapHandleMap = new Dictionary<string, int>();
		}
		int valueOrDefault = this.LoadMapHandleMap.GetValueOrDefault(handle, 0);
		if (valueOrDefault == 0)
		{
			this.LoadMapHandleMap[handle] = 1;
		}
		else
		{
			this.LoadMapHandleMap[handle] = valueOrDefault + 1;
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.World;
		ELogAuthor author = ELogAuthor.LFJW;
		string message = "添加LoadMapHandle";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("添加的Handle", handle);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Size", this.LoadMapHandleMap.Count);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return true;
	}

	// Token: 0x0601C7F4 RID: 116724 RVA: 0x0088C0E0 File Offset: 0x0088A2E0
	[NullableContext(1)]
	public unsafe bool RemoveLoadMapHandle(string handle)
	{
		Dictionary<string, int> loadMapHandleMap = this.LoadMapHandleMap;
		if (loadMapHandleMap == null || !loadMapHandleMap.ContainsKey(handle))
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "删除LoadMapHandle失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Handle", handle);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "Size";
			Dictionary<string, int> loadMapHandleMap2 = this.LoadMapHandleMap;
			ptr = new ValueTuple<string, object>(item, (loadMapHandleMap2 != null) ? new int?(loadMapHandleMap2.Count) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		int num = this.LoadMapHandleMap[handle];
		num--;
		if (num == 0)
		{
			this.LoadMapHandleMap.Remove(handle);
		}
		else
		{
			this.LoadMapHandleMap[handle] = num;
		}
		global::Log instance2 = Singleton<global::Log>.Instance;
		ELogModule module2 = ELogModule.World;
		ELogAuthor author2 = ELogAuthor.LFJW;
		string message2 = "删除LoadMapHandle";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("删除的Handle", handle);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Size", this.LoadMapHandleMap.Count);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		return true;
	}

	// Token: 0x17002681 RID: 9857
	// (get) Token: 0x0601C7F5 RID: 116725 RVA: 0x0088C20E File Offset: 0x0088A40E
	public bool MapDone
	{
		get
		{
			return this.LoadMapHandleMap != null && this.LoadMapHandleMap.Count == 0;
		}
	}

	// Token: 0x17002682 RID: 9858
	// (get) Token: 0x0601C7F6 RID: 116726 RVA: 0x0088C228 File Offset: 0x0088A428
	// (set) Token: 0x0601C7F7 RID: 116727 RVA: 0x0088C230 File Offset: 0x0088A430
	public bool NavMeshDone
	{
		get
		{
			return this.NavMeshDoneInternal;
		}
		set
		{
			this.NavMeshDoneInternal = value;
		}
	}

	// Token: 0x17002683 RID: 9859
	// (get) Token: 0x0601C7F8 RID: 116728 RVA: 0x0088C239 File Offset: 0x0088A439
	// (set) Token: 0x0601C7F9 RID: 116729 RVA: 0x0088C241 File Offset: 0x0088A441
	public bool WorldDone
	{
		get
		{
			return this.WorldDoneInternal;
		}
		set
		{
			this.WorldDoneInternal = value;
		}
	}

	// Token: 0x17002684 RID: 9860
	// (get) Token: 0x0601C7FA RID: 116730 RVA: 0x0088C24A File Offset: 0x0088A44A
	// (set) Token: 0x0601C7FB RID: 116731 RVA: 0x0088C252 File Offset: 0x0088A452
	public bool WorldDoneAndLoadingClosed
	{
		get
		{
			return this.WorldDoneAndLoadingClosedInternal;
		}
		set
		{
			this.WorldDoneAndLoadingClosedInternal = value;
		}
	}

	// Token: 0x17002685 RID: 9861
	// (get) Token: 0x0601C7FC RID: 116732 RVA: 0x0088C25B File Offset: 0x0088A45B
	[Nullable(1)]
	public APlayerStart[] PlayerStarts
	{
		[NullableContext(1)]
		get
		{
			return this.PlayerStartsInternal.ToArray();
		}
	}

	// Token: 0x17002686 RID: 9862
	// (get) Token: 0x0601C7FD RID: 116733 RVA: 0x0088C268 File Offset: 0x0088A468
	// (set) Token: 0x0601C7FE RID: 116734 RVA: 0x0088C275 File Offset: 0x0088A475
	public AkiMapSource MapConfig
	{
		get
		{
			return this.MapConfigInternal.Value;
		}
		set
		{
			this.MapConfigInternal = new AkiMapSource?(value);
		}
	}

	// Token: 0x17002687 RID: 9863
	// (get) Token: 0x0601C7FF RID: 116735 RVA: 0x0088C283 File Offset: 0x0088A483
	public InstanceDungeon? InstanceDungeon
	{
		get
		{
			return this.InstanceDungeonInternal;
		}
	}

	// Token: 0x0601C800 RID: 116736 RVA: 0x0088C28B File Offset: 0x0088A48B
	public void SetInstanceDungeon(int value)
	{
		this.InstanceDungeonInternal = ConfigInstanceDungeonById.GetConfig(value, true);
	}

	// Token: 0x17002688 RID: 9864
	// (get) Token: 0x0601C801 RID: 116737 RVA: 0x0088C29A File Offset: 0x0088A49A
	// (set) Token: 0x0601C802 RID: 116738 RVA: 0x0088C2A2 File Offset: 0x0088A4A2
	public int MapId
	{
		get
		{
			return this.MapIdInternal;
		}
		set
		{
			this.MapIdInternal = value;
		}
	}

	// Token: 0x17002689 RID: 9865
	// (get) Token: 0x0601C803 RID: 116739 RVA: 0x0088C2AB File Offset: 0x0088A4AB
	// (set) Token: 0x0601C804 RID: 116740 RVA: 0x0088C2C7 File Offset: 0x0088A4C7
	public InstanceType InstanceType
	{
		get
		{
			if (this.InstanceTypeInternal == null)
			{
				return InstanceType.NoneInstance;
			}
			return this.InstanceTypeInternal.Value;
		}
		set
		{
			this.InstanceTypeInternal = new InstanceType?(value);
		}
	}

	// Token: 0x1700268A RID: 9866
	// (get) Token: 0x0601C805 RID: 116741 RVA: 0x0088C2D5 File Offset: 0x0088A4D5
	public InstanceType LastInstanceType
	{
		get
		{
			return this.LastInstanceTypeInternal;
		}
	}

	// Token: 0x1700268B RID: 9867
	// (get) Token: 0x0601C806 RID: 116742 RVA: 0x0088C2DD File Offset: 0x0088A4DD
	// (set) Token: 0x0601C807 RID: 116743 RVA: 0x0088C2E5 File Offset: 0x0088A4E5
	public bool IsMulti
	{
		get
		{
			return this.IsMultiInternal;
		}
		set
		{
			this.IsMultiInternal = value;
		}
	}

	// Token: 0x1700268C RID: 9868
	// (get) Token: 0x0601C808 RID: 116744 RVA: 0x0088C2EE File Offset: 0x0088A4EE
	// (set) Token: 0x0601C809 RID: 116745 RVA: 0x0088C2F6 File Offset: 0x0088A4F6
	public bool ChangeModeState
	{
		get
		{
			return this.ChangeModeStateInternal;
		}
		set
		{
			this.ChangeModeStateInternal = value;
		}
	}

	// Token: 0x1700268D RID: 9869
	// (get) Token: 0x0601C80A RID: 116746 RVA: 0x0088C2FF File Offset: 0x0088A4FF
	// (set) Token: 0x0601C80B RID: 116747 RVA: 0x0088C307 File Offset: 0x0088A507
	public bool PlayTravelMp4
	{
		get
		{
			return this.PlayTravelMp4Internal;
		}
		set
		{
			this.PlayTravelMp4Internal = value;
		}
	}

	// Token: 0x1700268E RID: 9870
	// (get) Token: 0x0601C80C RID: 116748 RVA: 0x0088C310 File Offset: 0x0088A510
	// (set) Token: 0x0601C80D RID: 116749 RVA: 0x0088C318 File Offset: 0x0088A518
	public string TravelMp4Path
	{
		get
		{
			return this.TravelMp4PathInternal;
		}
		set
		{
			this.TravelMp4PathInternal = value;
		}
	}

	// Token: 0x1700268F RID: 9871
	// (get) Token: 0x0601C80E RID: 116750 RVA: 0x0088C321 File Offset: 0x0088A521
	// (set) Token: 0x0601C80F RID: 116751 RVA: 0x0088C329 File Offset: 0x0088A529
	public bool UseShowCenterText
	{
		get
		{
			return this.UseShowCenterTextInternal;
		}
		set
		{
			this.UseShowCenterTextInternal = value;
		}
	}

	// Token: 0x17002690 RID: 9872
	// (get) Token: 0x0601C810 RID: 116752 RVA: 0x0088C332 File Offset: 0x0088A532
	// (set) Token: 0x0601C811 RID: 116753 RVA: 0x0088C33A File Offset: 0x0088A53A
	public bool UseAsBlackScreen
	{
		get
		{
			return this.UseAsBlackScreenInternal;
		}
		set
		{
			this.UseAsBlackScreenInternal = value;
		}
	}

	// Token: 0x17002691 RID: 9873
	// (get) Token: 0x0601C812 RID: 116754 RVA: 0x0088C343 File Offset: 0x0088A543
	// (set) Token: 0x0601C813 RID: 116755 RVA: 0x0088C34B File Offset: 0x0088A54B
	public EFadeInScreenShowType BlackScreenColor
	{
		get
		{
			return this.BlackScreenColorInternal;
		}
		set
		{
			this.BlackScreenColorInternal = value;
		}
	}

	// Token: 0x17002692 RID: 9874
	// (get) Token: 0x0601C814 RID: 116756 RVA: 0x0088C354 File Offset: 0x0088A554
	// (set) Token: 0x0601C815 RID: 116757 RVA: 0x0088C35C File Offset: 0x0088A55C
	public bool TravelMp4Playing
	{
		get
		{
			return this.TravelMp4PlayingInternal;
		}
		set
		{
			this.TravelMp4PlayingInternal = value;
		}
	}

	// Token: 0x17002693 RID: 9875
	// (get) Token: 0x0601C816 RID: 116758 RVA: 0x0088C365 File Offset: 0x0088A565
	[Nullable(1)]
	public DataLayerSwitchContext SwitchDataLayerContext
	{
		[NullableContext(1)]
		get
		{
			return this.switchDataLayerContext;
		}
	}

	// Token: 0x17002694 RID: 9876
	// (get) Token: 0x0601C817 RID: 116759 RVA: 0x0088C36D File Offset: 0x0088A56D
	public bool DataLayerSwitching
	{
		get
		{
			return this.switchDataLayerContext.DataLayerSwitching;
		}
	}

	// Token: 0x17002695 RID: 9877
	// (get) Token: 0x0601C818 RID: 116760 RVA: 0x0088C37A File Offset: 0x0088A57A
	// (set) Token: 0x0601C819 RID: 116761 RVA: 0x0088C382 File Offset: 0x0088A582
	public EMovieBackgroundType? Mp4FadeInScreenColor
	{
		get
		{
			return this.Mp4FadeInScreenColorInternal;
		}
		set
		{
			this.Mp4FadeInScreenColorInternal = value;
		}
	}

	// Token: 0x17002696 RID: 9878
	// (get) Token: 0x0601C81A RID: 116762 RVA: 0x0088C38B File Offset: 0x0088A58B
	// (set) Token: 0x0601C81B RID: 116763 RVA: 0x0088C393 File Offset: 0x0088A593
	public EMovieBackgroundType? Mp4FadeOutScreenColor
	{
		get
		{
			return this.Mp4FadeOutScreenColorInternal;
		}
		set
		{
			this.Mp4FadeOutScreenColorInternal = value;
		}
	}

	// Token: 0x17002697 RID: 9879
	// (get) Token: 0x0601C81C RID: 116764 RVA: 0x0088C39C File Offset: 0x0088A59C
	// (set) Token: 0x0601C81D RID: 116765 RVA: 0x0088C3A4 File Offset: 0x0088A5A4
	public bool NeedOpenBlackScreenWhenTeleportDungeon
	{
		get
		{
			return this.NeedOpenBlackScreenWhenTeleportDungeonInternal;
		}
		set
		{
			this.NeedOpenBlackScreenWhenTeleportDungeonInternal = value;
		}
	}

	// Token: 0x17002698 RID: 9880
	// (get) Token: 0x0601C81E RID: 116766 RVA: 0x0088C3AD File Offset: 0x0088A5AD
	public CustomPromise<bool> ChangeSceneModePromise
	{
		get
		{
			return this.ChangeSceneModePromiseInternal;
		}
	}

	// Token: 0x17002699 RID: 9881
	// (get) Token: 0x0601C81F RID: 116767 RVA: 0x0088C3B5 File Offset: 0x0088A5B5
	public CustomPromise<bool> ChangeSceneModeVoxelPromise
	{
		get
		{
			return this.ChangeSceneModeVoxelPromiseInternal;
		}
	}

	// Token: 0x1700269A RID: 9882
	// (get) Token: 0x0601C820 RID: 116768 RVA: 0x0088C3BD File Offset: 0x0088A5BD
	public CustomPromise<bool> ChangeSceneModeStreamingPromise
	{
		get
		{
			return this.ChangeSceneModeStreamingPromiseInternal;
		}
	}

	// Token: 0x0601C821 RID: 116769 RVA: 0x0088C3C8 File Offset: 0x0088A5C8
	public GameModeModel()
	{
		this.OpenLoadingProfiler = this.LoadWorldProfiler.CreateChild("打开Loading", false);
		this.OpenLevelProfiler = this.LoadWorldProfiler.CreateChild("加载主Level", false);
		this.PreloadProfiler = this.LoadWorldProfiler.CreateChild("Preload阶段", false);
		this.PreloadApplyMaterialParameterCollectionProfiler = this.PreloadProfiler.CreateChild("应用MPC", false);
		this.PreloadCommonAndEntityProfiler = this.PreloadProfiler.CreateChild("预加载公共资源、实体资源", false);
		this.PreloadControllerProfiler = this.PreloadProfiler.CreateChild("预加载Controller资源", false);
		this.PreloadCommonProfiler = this.PreloadCommonAndEntityProfiler.CreateChild("预加载公共资源", false);
		this.PreloadEntitiesProfiler = this.PreloadCommonAndEntityProfiler.CreateChild("预加载实体", false);
		this.LoadDataLayerAndSubLevelProfiler = this.LoadWorldProfiler.CreateChild("加载DataLayer、加载子关卡", false);
		this.LoadSubLevelProfiler = this.LoadDataLayerAndSubLevelProfiler.CreateChild("加载子Level", false);
		this.LoadDataLayerProfiler = this.LoadDataLayerAndSubLevelProfiler.CreateChild("加载DataLayer", false);
		this.CheckVoxelStreamingSourceProfiler = this.LoadWorldProfiler.CreateChild("等待体素流送", false);
		this.CheckStreamingSourceProfiler = this.LoadWorldProfiler.CreateChild("等待场景流送", false);
		this.CreateEntitiesProfiler = this.LoadWorldProfiler.CreateChild("创建实体", false);
		this.WaitRenderAssetsProfiler = this.LoadWorldProfiler.CreateChild("等待渲染资源", false);
		this.WorldDoneProfiler = this.LoadWorldProfiler.CreateChild("WorldDone", false);
		this.OpenBattleViewProfiler = this.WorldDoneProfiler.CreateChild("打开主界面(WorldDone阶段)", false);
		this.CloseLoadingProfiler = this.LoadWorldProfiler.CreateChild("关闭Loading界面", false);
		this.CloseLoadingPhaseOpenBattleViewProfiler = this.CloseLoadingProfiler.CreateChild("打开主界面(关闭Loading阶段)", false);
	}

	// Token: 0x0601C822 RID: 116770 RVA: 0x0088C640 File Offset: 0x0088A840
	[NullableContext(1)]
	public void AddPlayerStart(APlayerStart value)
	{
		this.PlayerStartsInternal.Add(value);
	}

	// Token: 0x0601C823 RID: 116771 RVA: 0x0088C64E File Offset: 0x0088A84E
	public void ClearPlayerStart()
	{
		this.PlayerStartsInternal.Clear();
	}

	// Token: 0x1700269B RID: 9883
	// (get) Token: 0x0601C824 RID: 116772 RVA: 0x0088C65B File Offset: 0x0088A85B
	public AActor VoxelStreamingSource
	{
		get
		{
			return this.VoxelStreamingSourceInternal;
		}
	}

	// Token: 0x1700269C RID: 9884
	// (get) Token: 0x0601C825 RID: 116773 RVA: 0x0088C663 File Offset: 0x0088A863
	public AActor StreamingSource
	{
		get
		{
			return this.StreamingSourceInternal;
		}
	}

	// Token: 0x1700269D RID: 9885
	// (get) Token: 0x0601C826 RID: 116774 RVA: 0x0088C66B File Offset: 0x0088A86B
	// (set) Token: 0x0601C827 RID: 116775 RVA: 0x0088C673 File Offset: 0x0088A873
	public bool UseWorldPartition
	{
		get
		{
			return this.UseWorldPartitionInternal;
		}
		set
		{
			this.UseWorldPartitionInternal = value;
		}
	}

	// Token: 0x1700269E RID: 9886
	// (get) Token: 0x0601C828 RID: 116776 RVA: 0x0088C67C File Offset: 0x0088A87C
	// (set) Token: 0x0601C829 RID: 116777 RVA: 0x0088C684 File Offset: 0x0088A884
	public bool IsTeleport
	{
		get
		{
			return this.IsTeleportInternal;
		}
		set
		{
			this.IsTeleportInternal = value;
		}
	}

	// Token: 0x1700269F RID: 9887
	// (get) Token: 0x0601C82A RID: 116778 RVA: 0x0088C68D File Offset: 0x0088A88D
	public FVectorDouble? BornLocation
	{
		get
		{
			return this.BornLocationInternal;
		}
	}

	// Token: 0x170026A0 RID: 9888
	// (get) Token: 0x0601C82B RID: 116779 RVA: 0x0088C695 File Offset: 0x0088A895
	public FRotator? BornRotator
	{
		get
		{
			return this.BornRotatorInternal;
		}
	}

	// Token: 0x170026A1 RID: 9889
	// (get) Token: 0x0601C82C RID: 116780 RVA: 0x0088C69D File Offset: 0x0088A89D
	public global::Vector RoleLocation
	{
		get
		{
			return this.RoleLocationInternal;
		}
	}

	// Token: 0x170026A2 RID: 9890
	// (get) Token: 0x0601C82D RID: 116781 RVA: 0x0088C6A5 File Offset: 0x0088A8A5
	// (set) Token: 0x0601C82E RID: 116782 RVA: 0x0088C6AD File Offset: 0x0088A8AD
	public TransitionWithSpineLoadingPb SpecialTransitionPb
	{
		get
		{
			return this.SpecialTransitionPbInternal;
		}
		set
		{
			this.SpecialTransitionPbInternal = value;
		}
	}

	// Token: 0x170026A3 RID: 9891
	// (get) Token: 0x0601C82F RID: 116783 RVA: 0x0088C6B6 File Offset: 0x0088A8B6
	// (set) Token: 0x0601C830 RID: 116784 RVA: 0x0088C6BE File Offset: 0x0088A8BE
	public TransitionPlayFlowPb PlayFlowPb
	{
		get
		{
			return this.PlayFlowPbInternal;
		}
		set
		{
			this.PlayFlowPbInternal = value;
		}
	}

	// Token: 0x0601C831 RID: 116785 RVA: 0x0088C6C8 File Offset: 0x0088A8C8
	[NullableContext(1)]
	public AActor CreateShapedStreamingSource(int sectorAngle = 100, float loadingRangeScale = 1f)
	{
		FStreamingSourceShape[] shapes = new FStreamingSourceShape[]
		{
			new FStreamingSourceShape(true, loadingRangeScale, 0f, true, (float)sectorAngle, global::Vector.ZeroVector, global::Rotator.ZeroRotator)
		};
		return GameModeModel.CreateStreamingSource(Singleton<MathUtils>.Instance.DefaultTransformDouble, EStreamingSourcePriority.Normal, EStreamingSourceTargetBehavior.Include, null, shapes);
	}

	// Token: 0x0601C832 RID: 116786 RVA: 0x0088C710 File Offset: 0x0088A910
	[NullableContext(1)]
	public static AActor CreateIndependentStreamingSource(FName[] targetGrids, float loadingRange, EStreamingSourcePriority priority)
	{
		FStreamingSourceShape[] shapes = new FStreamingSourceShape[]
		{
			new FStreamingSourceShape(false, 1f, loadingRange, false, 360f, global::Vector.ZeroVector, global::Rotator.ZeroRotator)
		};
		AActor aactor = GameModeModel.CreateStreamingSource(FTransformDouble.Identity, priority, EStreamingSourceTargetBehavior.Include, targetGrids, shapes);
		if (aactor.IsValid())
		{
			UWorldPartitionStreamingSourceComponent uworldPartitionStreamingSourceComponent = aactor.GetComponentByClass(UWorldPartitionStreamingSourceComponent.StaticClass()) as UWorldPartitionStreamingSourceComponent;
			if (uworldPartitionStreamingSourceComponent != null && uworldPartitionStreamingSourceComponent.IsValid())
			{
				uworldPartitionStreamingSourceComponent.EnableStreamingSource();
			}
		}
		return aactor;
	}

	// Token: 0x0601C833 RID: 116787 RVA: 0x0088C784 File Offset: 0x0088A984
	[NullableContext(1)]
	private static AActor CreateStreamingSource(FTransformDouble transform, EStreamingSourcePriority priority, EStreamingSourceTargetBehavior targetBehavior, [Nullable(2)] FName[] targetGrids = null, [Nullable(new byte[]
	{
		2,
		1
	})] FStreamingSourceShape[] shapes = null)
	{
		AActor aactor = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), transform, null, true);
		aactor.AddComponentByClass(USceneComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName));
		aactor.D_K2_SetActorLocation(transform.GetLocation(), false, ref WorldGlobal.SweepHitResult, false);
		UWorldPartitionStreamingSourceComponent uworldPartitionStreamingSourceComponent = aactor.AddComponentByClass(UWorldPartitionStreamingSourceComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UWorldPartitionStreamingSourceComponent;
		uworldPartitionStreamingSourceComponent.Priority = priority;
		uworldPartitionStreamingSourceComponent.TargetBehavior = targetBehavior;
		if (targetGrids != null)
		{
			foreach (FName value in targetGrids)
			{
				uworldPartitionStreamingSourceComponent.TargetGrids.Add(value);
			}
		}
		if (shapes != null)
		{
			foreach (FStreamingSourceShape value2 in shapes)
			{
				uworldPartitionStreamingSourceComponent.Shapes.Add(value2);
			}
		}
		uworldPartitionStreamingSourceComponent.bStreamingSourceShouldBlockOnSlowStreaming = true;
		uworldPartitionStreamingSourceComponent.DisableStreamingSource();
		return aactor;
	}

	// Token: 0x0601C834 RID: 116788 RVA: 0x0088C884 File Offset: 0x0088AA84
	public unsafe void ScaleStreamingSource(EStreamingSourceScaleType type, float scale)
	{
		float num;
		if ((UKuroStaticLibrary.IsLowMemoryDevice() || type != EStreamingSourceScaleType.Plot) && (!this.StreamingSourceScalingTypes.TryGetValue(type, out num) || num != scale))
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.GameMode;
			ELogAuthor author = ELogAuthor.XY;
			string message = "缩放流送源";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", type);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Scale", scale);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.StreamingSourceScalingTypes[type] = scale;
			this.UpdateStreamingSourceScale(false);
		}
	}

	// Token: 0x0601C835 RID: 116789 RVA: 0x0088C924 File Offset: 0x0088AB24
	public void CleanScaleStreamingSource(EStreamingSourceScaleType type)
	{
		if ((UKuroStaticLibrary.IsLowMemoryDevice() || type != EStreamingSourceScaleType.Plot) && this.StreamingSourceScalingTypes.Remove(type))
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.GameMode;
			ELogAuthor author = ELogAuthor.XY;
			string message = "清理缩放流送源";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", type);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.UpdateStreamingSourceScale(true);
		}
	}

	// Token: 0x0601C836 RID: 116790 RVA: 0x0088C980 File Offset: 0x0088AB80
	private float GetStreamingSourceScale()
	{
		float result = 1f;
		EStreamingSourceScaleType? estreamingSourceScaleType = null;
		foreach (KeyValuePair<EStreamingSourceScaleType, float> keyValuePair in this.StreamingSourceScalingTypes)
		{
			if (estreamingSourceScaleType == null || keyValuePair.Key <= estreamingSourceScaleType.Value)
			{
				result = keyValuePair.Value;
				estreamingSourceScaleType = new EStreamingSourceScaleType?(keyValuePair.Key);
			}
		}
		return result;
	}

	// Token: 0x0601C837 RID: 116791 RVA: 0x0088CA0C File Offset: 0x0088AC0C
	private void UpdateStreamingSourceScale(bool forceUpdate = false)
	{
		if (!forceUpdate && this.StreamingSourceScalingTypes.Count == 0)
		{
			return;
		}
		AActor streamingSourceInternal = this.StreamingSourceInternal;
		if (streamingSourceInternal != null && streamingSourceInternal.IsValid())
		{
			UWorldPartitionStreamingSourceComponent uworldPartitionStreamingSourceComponent = this.StreamingSourceInternal.GetComponentByClass(UWorldPartitionStreamingSourceComponent.StaticClass()) as UWorldPartitionStreamingSourceComponent;
			if (uworldPartitionStreamingSourceComponent != null && uworldPartitionStreamingSourceComponent.IsValid())
			{
				if (this.StreamingSourceScalingTypes.Count > 0)
				{
					float streamingSourceScale = this.GetStreamingSourceScale();
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.GameMode;
					ELogAuthor author = ELogAuthor.XY;
					string message = "更新流送源缩放";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Scale", streamingSourceScale);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					int num = uworldPartitionStreamingSourceComponent.Shapes.Num();
					FStreamingSourceShape fstreamingSourceShape = null;
					FStreamingSourceShape fstreamingSourceShape2 = null;
					if (num > 0)
					{
						fstreamingSourceShape = uworldPartitionStreamingSourceComponent.Shapes.Get(0);
					}
					if (num > 1)
					{
						fstreamingSourceShape2 = uworldPartitionStreamingSourceComponent.Shapes.Get(1);
					}
					if (fstreamingSourceShape == null)
					{
						fstreamingSourceShape = new FStreamingSourceShape(true, streamingSourceScale, 0f, false, 360f, global::Vector.ZeroVector, global::Rotator.ZeroRotator);
						uworldPartitionStreamingSourceComponent.Shapes.Add(fstreamingSourceShape);
					}
					else
					{
						fstreamingSourceShape.LoadingRangeScale = streamingSourceScale;
					}
					if (fstreamingSourceShape2 == null)
					{
						fstreamingSourceShape2 = new FStreamingSourceShape(false, 1f, 7000f, false, 360f, global::Vector.ZeroVector, global::Rotator.ZeroRotator);
						uworldPartitionStreamingSourceComponent.Shapes.Add(fstreamingSourceShape2);
						return;
					}
				}
				else
				{
					Singleton<global::Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.XY, "重置流送源缩放", default(ReadOnlySpan<ValueTuple<string, object>>));
					uworldPartitionStreamingSourceComponent.Shapes.Empty(true);
				}
			}
		}
	}

	// Token: 0x0601C838 RID: 116792 RVA: 0x0088CB84 File Offset: 0x0088AD84
	public unsafe void DisableHLODStreaming(EDisableHLODStreamingType type, int level = 0)
	{
		int num;
		if (!this.DisableHLODStreamingTypes.TryGetValue(type, out num) || num != level)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.GameMode;
			ELogAuthor author = ELogAuthor.XY;
			string message = "禁用流送HLOD";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", type);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Level", level);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.DisableHLODStreamingTypes[type] = level;
			this.UpdateHLODStreamingToggle(false);
		}
	}

	// Token: 0x0601C839 RID: 116793 RVA: 0x0088CC18 File Offset: 0x0088AE18
	public void EnableHLODStreaming(EDisableHLODStreamingType type)
	{
		if (this.DisableHLODStreamingTypes.Remove(type))
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.GameMode;
			ELogAuthor author = ELogAuthor.XY;
			string message = "开启流送HLOD";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", type);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.UpdateHLODStreamingToggle(true);
		}
	}

	// Token: 0x0601C83A RID: 116794 RVA: 0x0088CC68 File Offset: 0x0088AE68
	private int GetHLODStreamingToggleLevel()
	{
		int num = 2;
		foreach (KeyValuePair<EDisableHLODStreamingType, int> keyValuePair in this.DisableHLODStreamingTypes)
		{
			if (keyValuePair.Value < num)
			{
				num = keyValuePair.Value;
			}
		}
		return num;
	}

	// Token: 0x0601C83B RID: 116795 RVA: 0x0088CCCC File Offset: 0x0088AECC
	private void UpdateHLODStreamingToggle(bool forceUpdate = false)
	{
		if (!forceUpdate && this.DisableHLODStreamingTypes.Count == 0)
		{
			return;
		}
		AActor streamingSourceInternal = this.StreamingSourceInternal;
		if (streamingSourceInternal != null && streamingSourceInternal.IsValid())
		{
			UWorldPartitionStreamingSourceComponent uworldPartitionStreamingSourceComponent = this.StreamingSourceInternal.GetComponentByClass(UWorldPartitionStreamingSourceComponent.StaticClass()) as UWorldPartitionStreamingSourceComponent;
			if (uworldPartitionStreamingSourceComponent != null && uworldPartitionStreamingSourceComponent.IsValid())
			{
				HashSet<FName> hashSet = new HashSet<FName>();
				for (int i = 0; i < uworldPartitionStreamingSourceComponent.TargetGrids.Num(); i++)
				{
					hashSet.Add(FNameUtil.GetDynamicFName(uworldPartitionStreamingSourceComponent.TargetGrids.Get(i).ToString()).Value);
				}
				int hlodstreamingToggleLevel = this.GetHLODStreamingToggleLevel();
				if (hlodstreamingToggleLevel > 1)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.GameMode;
					ELogAuthor author = ELogAuthor.XY;
					string message = "重置HLOD流送";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Level", hlodstreamingToggleLevel);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					foreach (FName item in WorldDefine.firstHLODGridNames)
					{
						hashSet.Remove(item);
					}
					foreach (FName item2 in WorldDefine.secondHLODGridNames)
					{
						hashSet.Remove(item2);
					}
				}
				else
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.GameMode;
					ELogAuthor author2 = ELogAuthor.XY;
					string message2 = "更新HLOD流送";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Level", hlodstreamingToggleLevel);
					instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					foreach (FName item3 in WorldDefine.secondHLODGridNames)
					{
						hashSet.Add(item3);
					}
					if (hlodstreamingToggleLevel == 1)
					{
						foreach (FName item4 in WorldDefine.firstHLODGridNames)
						{
							hashSet.Remove(item4);
						}
					}
					else
					{
						foreach (FName item5 in WorldDefine.firstHLODGridNames)
						{
							hashSet.Add(item5);
						}
					}
				}
				uworldPartitionStreamingSourceComponent.TargetGrids.Empty(true);
				foreach (FName value in hashSet)
				{
					uworldPartitionStreamingSourceComponent.TargetGrids.Add(value);
				}
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.GameMode;
				ELogAuthor author3 = ELogAuthor.XY;
				string message3 = "更新HLOD流送";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Enabled", this.DisableHLODStreamingTypes.Count == 0);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			}
		}
	}

	// Token: 0x0601C83C RID: 116796 RVA: 0x0088CF70 File Offset: 0x0088B170
	public unsafe void InitStreamingSources()
	{
		FRotator value = this.BornRotator.Value;
		FVectorDouble value2 = this.BornLocation.Value;
		FVectorDouble fvectorDouble = new FVectorDouble(1.0, 1.0, 1.0);
		FVector fvector = fvectorDouble;
		FTransformDouble transform = new FTransformDouble(ref value, ref value2, ref fvector);
		FName[] array = new FName[]
		{
			WorldDefine.voxelGridName
		};
		AActor voxelStreamingSourceInternal = this.VoxelStreamingSourceInternal;
		if (voxelStreamingSourceInternal != null && voxelStreamingSourceInternal.IsValid())
		{
			AActor voxelStreamingSourceInternal2 = this.VoxelStreamingSourceInternal;
			if (voxelStreamingSourceInternal2 != null)
			{
				voxelStreamingSourceInternal2.D_K2_SetActorLocation(transform.GetLocation(), false, ref WorldGlobal.SweepHitResult, false);
			}
		}
		else
		{
			this.VoxelStreamingSourceInternal = GameModeModel.CreateStreamingSource(transform, EStreamingSourcePriority.High, EStreamingSourceTargetBehavior.Include, array, null);
		}
		if (UKuroStaticLibrary.IsLowMemoryDevice())
		{
			FName[] array2 = new FName[array.Length + WorldDefine.lowMemoryDeviceExcludeGridNames.Length];
			array.CopyTo(array2, 0);
			WorldDefine.lowMemoryDeviceExcludeGridNames.CopyTo(array2, array.Length);
			array = array2;
		}
		AActor streamingSourceInternal = this.StreamingSourceInternal;
		if (streamingSourceInternal != null && streamingSourceInternal.IsValid())
		{
			AActor streamingSourceInternal2 = this.StreamingSourceInternal;
			if (streamingSourceInternal2 != null)
			{
				streamingSourceInternal2.D_K2_SetActorLocation(transform.GetLocation(), false, ref WorldGlobal.SweepHitResult, false);
			}
		}
		else
		{
			this.StreamingSourceInternal = GameModeModel.CreateStreamingSource(transform, EStreamingSourcePriority.Normal, EStreamingSourceTargetBehavior.Exclude, array, null);
			this.UpdateStreamingSourceScale(false);
			this.UpdateHLODStreamingToggle(false);
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Level;
		ELogAuthor author = ELogAuthor.YZH;
		string message = "StreamingSource出生信息";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Location", this.BornLocation);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Rotation", this.BornRotator);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TargetGrids", string.Join<FName>(", ", array));
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x0601C83D RID: 116797 RVA: 0x0088D144 File Offset: 0x0088B344
	public void DisableStreamingSources()
	{
		AActor voxelStreamingSourceInternal = this.VoxelStreamingSourceInternal;
		if (voxelStreamingSourceInternal != null && voxelStreamingSourceInternal.IsValid())
		{
			UWorldPartitionStreamingSourceComponent uworldPartitionStreamingSourceComponent = this.VoxelStreamingSourceInternal.GetComponentByClass(UWorldPartitionStreamingSourceComponent.StaticClass()) as UWorldPartitionStreamingSourceComponent;
			if (uworldPartitionStreamingSourceComponent != null && uworldPartitionStreamingSourceComponent.IsValid())
			{
				uworldPartitionStreamingSourceComponent.DisableStreamingSource();
			}
		}
		AActor streamingSourceInternal = this.StreamingSourceInternal;
		if (streamingSourceInternal != null && streamingSourceInternal.IsValid())
		{
			UWorldPartitionStreamingSourceComponent uworldPartitionStreamingSourceComponent2 = this.StreamingSourceInternal.GetComponentByClass(UWorldPartitionStreamingSourceComponent.StaticClass()) as UWorldPartitionStreamingSourceComponent;
			if (uworldPartitionStreamingSourceComponent2 != null && uworldPartitionStreamingSourceComponent2.IsValid())
			{
				uworldPartitionStreamingSourceComponent2.DisableStreamingSource();
			}
		}
	}

	// Token: 0x0601C83E RID: 116798 RVA: 0x0088D1D4 File Offset: 0x0088B3D4
	public bool AttachStreamingSourcesToActor(AActor actor)
	{
		if (!this.IndependentStreaming && actor != null)
		{
			AActor streamingSourceInternal = this.StreamingSourceInternal;
			if (streamingSourceInternal != null && streamingSourceInternal.IsValid())
			{
				AActor voxelStreamingSourceInternal = this.VoxelStreamingSourceInternal;
				if (voxelStreamingSourceInternal != null && voxelStreamingSourceInternal.IsValid())
				{
					this.StreamingSourceInternal.K2_AttachToActor(actor, FName.NAME_None, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
					this.VoxelStreamingSourceInternal.K2_AttachToActor(actor, FName.NAME_None, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0601C83F RID: 116799 RVA: 0x0088D24C File Offset: 0x0088B44C
	public void StartIndependentStreaming(FVectorDouble? location = null)
	{
		AActor streamingSourceInternal = this.StreamingSourceInternal;
		if (streamingSourceInternal != null && streamingSourceInternal.IsValid())
		{
			AActor voxelStreamingSourceInternal = this.VoxelStreamingSourceInternal;
			if (voxelStreamingSourceInternal != null && voxelStreamingSourceInternal.IsValid())
			{
				this.IndependentStreaming = true;
				AActor streamingSourceInternal2 = this.StreamingSourceInternal;
				if (streamingSourceInternal2 != null)
				{
					streamingSourceInternal2.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
				}
				AActor voxelStreamingSourceInternal2 = this.VoxelStreamingSourceInternal;
				if (voxelStreamingSourceInternal2 != null)
				{
					voxelStreamingSourceInternal2.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
				}
				if (location != null)
				{
					AActor streamingSourceInternal3 = this.StreamingSourceInternal;
					if (streamingSourceInternal3 != null)
					{
						streamingSourceInternal3.D_K2_SetActorLocation(location.Value, false, ref WorldGlobal.SweepHitResult, false);
					}
					AActor voxelStreamingSourceInternal3 = this.VoxelStreamingSourceInternal;
					if (voxelStreamingSourceInternal3 == null)
					{
						return;
					}
					voxelStreamingSourceInternal3.D_K2_SetActorLocation(location.Value, false, ref WorldGlobal.SweepHitResult, false);
				}
				return;
			}
		}
	}

	// Token: 0x0601C840 RID: 116800 RVA: 0x0088D300 File Offset: 0x0088B500
	public void DetachStreamingSourceFromActor()
	{
		AActor streamingSourceInternal = this.StreamingSourceInternal;
		if (streamingSourceInternal != null && streamingSourceInternal.IsValid())
		{
			AActor voxelStreamingSourceInternal = this.VoxelStreamingSourceInternal;
			if (voxelStreamingSourceInternal != null && voxelStreamingSourceInternal.IsValid())
			{
				this.StreamingSourceInternal.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
				this.VoxelStreamingSourceInternal.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
				return;
			}
		}
	}

	// Token: 0x0601C841 RID: 116801 RVA: 0x0088D358 File Offset: 0x0088B558
	public void StopIndependentStreaming(AActor actor = null)
	{
		this.IndependentStreaming = false;
		this.AttachStreamingSourcesToActor(actor);
	}

	// Token: 0x0601C842 RID: 116802 RVA: 0x0088D36C File Offset: 0x0088B56C
	public void SetBornInfo(IVector bornLocation, IRotator bornRotator)
	{
		this.BornLocationInternal = ((bornLocation != null) ? new FVectorDouble?(new FVectorDouble(bornLocation.X, bornLocation.Y, bornLocation.Z)) : null);
		this.RoleLocationInternal = ((bornLocation != null) ? global::Vector.Create(bornLocation) : null);
		this.BornRotatorInternal = ((bornRotator != null) ? new FRotator?(new FRotator(bornRotator.Pitch, bornRotator.Yaw, bornRotator.Roll)) : null);
	}

	// Token: 0x0601C843 RID: 116803 RVA: 0x0088D3EB File Offset: 0x0088B5EB
	public void UpdateBornLocation(FVectorDouble location)
	{
		this.RoleLocationInternal.Set(location.X, location.Y, location.Z);
	}

	// Token: 0x0601C844 RID: 116804 RVA: 0x0088D40C File Offset: 0x0088B60C
	public void FlushTempDataLayers()
	{
		foreach (string item in this.TempDataLayer)
		{
			this.DataLayerSet.Add(item);
		}
	}

	// Token: 0x0601C845 RID: 116805 RVA: 0x0088D468 File Offset: 0x0088B668
	[NullableContext(1)]
	public bool AddDataLayer(string path)
	{
		if (this.DataLayerSet.Contains(path))
		{
			return false;
		}
		this.DataLayerSet.Add(path);
		return true;
	}

	// Token: 0x0601C846 RID: 116806 RVA: 0x0088D488 File Offset: 0x0088B688
	[NullableContext(1)]
	public bool RemoveDataLayer(string path)
	{
		if (!this.HasDataLayer(path))
		{
			return false;
		}
		this.DataLayerSet.Remove(path);
		return true;
	}

	// Token: 0x0601C847 RID: 116807 RVA: 0x0088D4A3 File Offset: 0x0088B6A3
	[NullableContext(1)]
	public bool HasDataLayer(string path)
	{
		return this.DataLayerSet.Contains(path);
	}

	// Token: 0x0601C848 RID: 116808 RVA: 0x0088D4B1 File Offset: 0x0088B6B1
	[NullableContext(1)]
	public HashSet<string> GetAllDataLayers()
	{
		return this.DataLayerSet;
	}

	// Token: 0x170026A4 RID: 9892
	// (get) Token: 0x0601C849 RID: 116809 RVA: 0x0088D4B9 File Offset: 0x0088B6B9
	public GameModePromise BeginLoadMapPromise
	{
		get
		{
			return this.BeginLoadMapPromiseInternal;
		}
	}

	// Token: 0x170026A5 RID: 9893
	// (get) Token: 0x0601C84A RID: 116810 RVA: 0x0088D4C1 File Offset: 0x0088B6C1
	public GameModePromise AfterJoinSceneNotifyPromise
	{
		get
		{
			return this.AfterJoinSceneNotifyPromiseInternal;
		}
	}

	// Token: 0x170026A6 RID: 9894
	// (get) Token: 0x0601C84B RID: 116811 RVA: 0x0088D4C9 File Offset: 0x0088B6C9
	public GameModePromise OpenLevelPromise
	{
		get
		{
			return this.OpenLevelPromiseInternal;
		}
	}

	// Token: 0x170026A7 RID: 9895
	// (get) Token: 0x0601C84C RID: 116812 RVA: 0x0088D4D1 File Offset: 0x0088B6D1
	public GameModePromise StreamingCompleted
	{
		get
		{
			return this.StreamingCompletedInternal;
		}
	}

	// Token: 0x170026A8 RID: 9896
	// (get) Token: 0x0601C84D RID: 116813 RVA: 0x0088D4D9 File Offset: 0x0088B6D9
	public GameModePromise VoxelStreamingCompleted
	{
		get
		{
			return this.VoxelStreamingCompletedInternal;
		}
	}

	// Token: 0x170026A9 RID: 9897
	// (get) Token: 0x0601C84E RID: 116814 RVA: 0x0088D4E1 File Offset: 0x0088B6E1
	// (set) Token: 0x0601C84F RID: 116815 RVA: 0x0088D4E9 File Offset: 0x0088B6E9
	public GameModePromise LoadMultiFormationPromise
	{
		get
		{
			return this.LoadMultiFormationPromiseInternal;
		}
		set
		{
			this.LoadMultiFormationPromiseInternal = value;
		}
	}

	// Token: 0x170026AA RID: 9898
	// (get) Token: 0x0601C850 RID: 116816 RVA: 0x0088D4F2 File Offset: 0x0088B6F2
	public GameModePromise PreloadPromise
	{
		get
		{
			return this.PreloadPromiseInternal;
		}
	}

	// Token: 0x170026AB RID: 9899
	// (get) Token: 0x0601C851 RID: 116817 RVA: 0x0088D4FA File Offset: 0x0088B6FA
	public GameModePromise ApplyMaterialParameterCollectionPromise
	{
		get
		{
			return this.ApplyMaterialParameterCollectionPromiseInternal;
		}
	}

	// Token: 0x170026AC RID: 9900
	// (get) Token: 0x0601C852 RID: 116818 RVA: 0x0088D502 File Offset: 0x0088B702
	public GameModePromise ChangeSceneModeEndNotifyPromise
	{
		get
		{
			return this.ChangeSceneModeEndNotifyPromiseInternal;
		}
	}

	// Token: 0x170026AD RID: 9901
	// (get) Token: 0x0601C853 RID: 116819 RVA: 0x0088D50A File Offset: 0x0088B70A
	// (set) Token: 0x0601C854 RID: 116820 RVA: 0x0088D512 File Offset: 0x0088B712
	public TimerHandle CheckStreamingCompletedTimerId
	{
		get
		{
			return this.CheckStreamingCompletedTimerIdInternal;
		}
		set
		{
			this.CheckStreamingCompletedTimerIdInternal = value;
		}
	}

	// Token: 0x170026AE RID: 9902
	// (get) Token: 0x0601C855 RID: 116821 RVA: 0x0088D51B File Offset: 0x0088B71B
	// (set) Token: 0x0601C856 RID: 116822 RVA: 0x0088D523 File Offset: 0x0088B723
	public TimerHandle CheckRenderAssetsStreamingCompletedTimerId
	{
		get
		{
			return this.CheckRenderAssetsStreamingCompletedTimerIdInternal;
		}
		set
		{
			this.CheckRenderAssetsStreamingCompletedTimerIdInternal = value;
		}
	}

	// Token: 0x170026AF RID: 9903
	// (get) Token: 0x0601C857 RID: 116823 RVA: 0x0088D52C File Offset: 0x0088B72C
	// (set) Token: 0x0601C858 RID: 116824 RVA: 0x0088D534 File Offset: 0x0088B734
	public TimerHandle CheckRenderAssetsTimeoutId
	{
		get
		{
			return this.CheckRenderAssetsTimeoutIdInternal;
		}
		set
		{
			this.CheckRenderAssetsTimeoutIdInternal = value;
		}
	}

	// Token: 0x170026B0 RID: 9904
	// (get) Token: 0x0601C859 RID: 116825 RVA: 0x0088D53D File Offset: 0x0088B73D
	public GameModePromise VideoStartPromise
	{
		get
		{
			return this.VideoStartPromiseInternal;
		}
	}

	// Token: 0x170026B1 RID: 9905
	// (get) Token: 0x0601C85A RID: 116826 RVA: 0x0088D545 File Offset: 0x0088B745
	public GameModePromise OpenLoadingEnd
	{
		get
		{
			return this.OpenLoadingEndPromiseInternal;
		}
	}

	// Token: 0x170026B2 RID: 9906
	// (get) Token: 0x0601C85B RID: 116827 RVA: 0x0088D54D File Offset: 0x0088B74D
	public GameModePromise PlayFlowEndPromise
	{
		get
		{
			return this.PlayFlowEndPromiseInternal;
		}
	}

	// Token: 0x170026B3 RID: 9907
	// (get) Token: 0x0601C85C RID: 116828 RVA: 0x0088D555 File Offset: 0x0088B755
	// (set) Token: 0x0601C85D RID: 116829 RVA: 0x0088D55D File Offset: 0x0088B75D
	public bool RenderAssetDone
	{
		get
		{
			return this.RenderAssetDoneInternal;
		}
		set
		{
			this.RenderAssetDoneInternal = value;
		}
	}

	// Token: 0x170026B4 RID: 9908
	// (get) Token: 0x0601C85E RID: 116830 RVA: 0x0088D566 File Offset: 0x0088B766
	// (set) Token: 0x0601C85F RID: 116831 RVA: 0x0088D570 File Offset: 0x0088B770
	public unsafe ELoadMapMode LoadMapMode
	{
		get
		{
			return this.LoadMapModeInternal;
		}
		set
		{
			if (value >= ELoadMapMode.Max || value < ELoadMapMode.ClientTravel)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "f.副本.xlsx表AkiMapSource Sheet 填错LoadMapMode值";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("loadMapMode", value);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MapPath", this.MapPath);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.LoadMapModeInternal = ELoadMapMode.ClientTravel;
				return;
			}
			this.LoadMapModeInternal = value;
		}
	}

	// Token: 0x170026B5 RID: 9909
	// (get) Token: 0x0601C860 RID: 116832 RVA: 0x0088D5F1 File Offset: 0x0088B7F1
	// (set) Token: 0x0601C861 RID: 116833 RVA: 0x0088D5FC File Offset: 0x0088B7FC
	public bool ForceClientTravel
	{
		get
		{
			return this.ForceClientTravelInternal;
		}
		set
		{
			bool forceClientTravelInternal = this.ForceClientTravelInternal;
			this.ForceClientTravelInternal = value;
			Singleton<EventSystem>.Instance.Emit<bool, bool>(EEventName.ForceClientTravelModify, forceClientTravelInternal, value);
		}
	}

	// Token: 0x170026B6 RID: 9910
	// (get) Token: 0x0601C862 RID: 116834 RVA: 0x0088D629 File Offset: 0x0088B829
	[Nullable(1)]
	public Dictionary<string, HashSet<ULevelStreamingDynamic>> LoadMapControllerDynamicStreamingLevels
	{
		[NullableContext(1)]
		get
		{
			if (this.LoadMapControllerDynamicStreamingLevelsInternal == null)
			{
				this.LoadMapControllerDynamicStreamingLevelsInternal = new Dictionary<string, HashSet<ULevelStreamingDynamic>>();
			}
			return this.LoadMapControllerDynamicStreamingLevelsInternal;
		}
	}

	// Token: 0x0601C863 RID: 116835 RVA: 0x0088D644 File Offset: 0x0088B844
	public void ClearLoadMapControllerData()
	{
		if (this.LoadMapControllerDynamicStreamingLevelsInternal != null)
		{
			this.LoadMapControllerDynamicStreamingLevelsInternal.Clear();
		}
		this.LoadMapControllerEnableWorldPartition = false;
	}

	// Token: 0x0601C864 RID: 116836 RVA: 0x0088D660 File Offset: 0x0088B860
	public void CreatePromise()
	{
		this.BeginLoadMapPromiseInternal = new GameModePromise();
		this.AfterJoinSceneNotifyPromiseInternal = new GameModePromise();
		this.OpenLevelPromiseInternal = new GameModePromise();
		this.StreamingCompletedInternal = new GameModePromise();
		this.VoxelStreamingCompletedInternal = new GameModePromise();
		this.PreloadPromiseInternal = new GameModePromise();
		this.VideoStartPromiseInternal = new GameModePromise();
		this.OpenLoadingEndPromiseInternal = new GameModePromise();
		this.ApplyMaterialParameterCollectionPromiseInternal = new GameModePromise();
		this.PlayFlowEndPromiseInternal = new GameModePromise();
	}

	// Token: 0x0601C865 RID: 116837 RVA: 0x0088D6DC File Offset: 0x0088B8DC
	public void ResetPromise()
	{
		this.BeginLoadMapPromiseInternal = null;
		this.AfterJoinSceneNotifyPromiseInternal = null;
		this.OpenLevelPromiseInternal = null;
		this.StreamingCompletedInternal = null;
		this.VoxelStreamingCompletedInternal = null;
		this.PreloadPromiseInternal = null;
		this.LoadMultiFormationPromiseInternal = null;
		this.VideoStartPromiseInternal = null;
		this.OpenLoadingEndPromiseInternal = null;
		this.ApplyMaterialParameterCollectionPromiseInternal = null;
		this.PlayFlowEndPromiseInternal = null;
	}

	// Token: 0x0601C866 RID: 116838 RVA: 0x0088D736 File Offset: 0x0088B936
	public void CreateChangeModePromise()
	{
		this.ChangeSceneModeEndNotifyPromiseInternal = new GameModePromise();
		this.ChangeSceneModePromiseInternal = new CustomPromise<bool>();
		this.ChangeSceneModeVoxelPromiseInternal = new CustomPromise<bool>();
		this.ChangeSceneModeStreamingPromiseInternal = new CustomPromise<bool>();
	}

	// Token: 0x0601C867 RID: 116839 RVA: 0x0088D764 File Offset: 0x0088B964
	public void ResetChangeModePromise()
	{
		this.ChangeSceneModeEndNotifyPromiseInternal = null;
		this.ChangeSceneModePromiseInternal = null;
		this.ChangeSceneModeVoxelPromiseInternal = null;
		this.ChangeSceneModeStreamingPromiseInternal = null;
	}

	// Token: 0x0601C868 RID: 116840 RVA: 0x0088D782 File Offset: 0x0088B982
	public void SkipChangeSceneModeWait()
	{
		CustomPromise<bool> changeSceneModePromiseInternal = this.ChangeSceneModePromiseInternal;
		if (changeSceneModePromiseInternal != null)
		{
			changeSceneModePromiseInternal.SetResult(true);
		}
		CustomPromise<bool> changeSceneModeVoxelPromiseInternal = this.ChangeSceneModeVoxelPromiseInternal;
		if (changeSceneModeVoxelPromiseInternal != null)
		{
			changeSceneModeVoxelPromiseInternal.SetResult(true);
		}
		CustomPromise<bool> changeSceneModeStreamingPromiseInternal = this.ChangeSceneModeStreamingPromiseInternal;
		if (changeSceneModeStreamingPromiseInternal == null)
		{
			return;
		}
		changeSceneModeStreamingPromiseInternal.SetResult(true);
	}

	// Token: 0x0601C869 RID: 116841 RVA: 0x0088D7BC File Offset: 0x0088B9BC
	protected override bool OnLeaveLevel()
	{
		this.TempDataLayer.Clear();
		foreach (string item in this.DataLayerSet)
		{
			this.TempDataLayer.Add(item);
		}
		this.DataLayerSet.Clear();
		this.MaterialParameterCollectionMap.Clear();
		if (this.CheckStreamingCompletedTimerId != null)
		{
			TimerSystem.Instance.Remove(this.CheckStreamingCompletedTimerId);
			this.CheckStreamingCompletedTimerId = null;
		}
		this.LoadMapHandleMap = null;
		this.NavMeshDoneInternal = false;
		this.WorldDoneInternal = false;
		this.WorldDoneAndLoadingClosedInternal = false;
		this.LastMapPathInternal = this.MapPathInternal;
		this.MapPathInternal = "";
		this.MapIdInternal = 0;
		this.IsMultiInternal = false;
		this.LastInstanceTypeInternal = this.InstanceTypeInternal.GetValueOrDefault();
		this.InstanceTypeInternal = new InstanceType?(InstanceType.NoneInstance);
		this.MapConfigInternal = null;
		this.InstanceDungeonInternal = null;
		this.UseWorldPartitionInternal = false;
		this.IsTeleportInternal = false;
		this.RenderAssetDone = false;
		this.ResetPromise();
		this.CheckStreamingCompletedTimerIdInternal = null;
		this.CheckRenderAssetsStreamingCompletedTimerIdInternal = null;
		this.CheckRenderAssetsTimeoutIdInternal = null;
		return true;
	}

	// Token: 0x0601C86A RID: 116842 RVA: 0x0088D8FC File Offset: 0x0088BAFC
	protected override bool OnChangeMode()
	{
		this.ResetPromise();
		return true;
	}

	// Token: 0x0601C86B RID: 116843 RVA: 0x0088D905 File Offset: 0x0088BB05
	public void SetCacheTimeDilationValue(float value)
	{
		this.CacheTimeDilationData = new TimeDilationDataImpl
		{
			TimeDilation = value
		};
	}

	// Token: 0x0601C86C RID: 116844 RVA: 0x0088D919 File Offset: 0x0088BB19
	public ITimeDilationData GetCacheTimeDilationValue()
	{
		return this.CacheTimeDilationData;
	}

	// Token: 0x0601C86D RID: 116845 RVA: 0x0088D921 File Offset: 0x0088BB21
	public void ClearCacheTimeDilationValue()
	{
		this.CacheTimeDilationData = null;
	}

	// Token: 0x0400E541 RID: 58689
	public const ETimeDilationType PAUSE_TYPE = ETimeDilationType.PhantomBattleArena;

	// Token: 0x0400E542 RID: 58690
	public bool IsSilentLogin;

	// Token: 0x0400E543 RID: 58691
	private bool HasGameModeDataInternal;

	// Token: 0x0400E544 RID: 58692
	private SceneMode? ModeInternal;

	// Token: 0x0400E545 RID: 58693
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<string, int> LoadMapHandleMap;

	// Token: 0x0400E546 RID: 58694
	private bool NavMeshDoneInternal;

	// Token: 0x0400E547 RID: 58695
	private bool WorldDoneInternal;

	// Token: 0x0400E548 RID: 58696
	private bool WorldDoneAndLoadingClosedInternal;

	// Token: 0x0400E549 RID: 58697
	private bool ChangeModeStateInternal;

	// Token: 0x0400E54A RID: 58698
	[Nullable(1)]
	private string MapPathInternal = "";

	// Token: 0x0400E54B RID: 58699
	[Nullable(1)]
	private string LastMapPathInternal = "";

	// Token: 0x0400E54C RID: 58700
	[Nullable(1)]
	private readonly List<APlayerStart> PlayerStartsInternal = new List<APlayerStart>();

	// Token: 0x0400E54D RID: 58701
	private AActor VoxelStreamingSourceInternal;

	// Token: 0x0400E54E RID: 58702
	private AActor StreamingSourceInternal;

	// Token: 0x0400E54F RID: 58703
	private AkiMapSource? MapConfigInternal;

	// Token: 0x0400E550 RID: 58704
	private InstanceDungeon? InstanceDungeonInternal;

	// Token: 0x0400E551 RID: 58705
	private int MapIdInternal;

	// Token: 0x0400E552 RID: 58706
	private InstanceType? InstanceTypeInternal;

	// Token: 0x0400E553 RID: 58707
	private InstanceType LastInstanceTypeInternal;

	// Token: 0x0400E554 RID: 58708
	private bool IsMultiInternal;

	// Token: 0x0400E555 RID: 58709
	private bool UseWorldPartitionInternal;

	// Token: 0x0400E556 RID: 58710
	private bool IsTeleportInternal;

	// Token: 0x0400E557 RID: 58711
	private bool PlayTravelMp4Internal;

	// Token: 0x0400E558 RID: 58712
	private string TravelMp4PathInternal;

	// Token: 0x0400E559 RID: 58713
	private bool TravelMp4PlayingInternal;

	// Token: 0x0400E55A RID: 58714
	private bool UseShowCenterTextInternal;

	// Token: 0x0400E55B RID: 58715
	private bool UseAsBlackScreenInternal;

	// Token: 0x0400E55C RID: 58716
	private EFadeInScreenShowType BlackScreenColorInternal = EFadeInScreenShowType.Black;

	// Token: 0x0400E55D RID: 58717
	public TransitionFlowPb ShowCenterTextFlow;

	// Token: 0x0400E55E RID: 58718
	[Nullable(1)]
	private readonly DataLayerSwitchContext switchDataLayerContext = new DataLayerSwitchContext();

	// Token: 0x0400E55F RID: 58719
	private EMovieBackgroundType? Mp4FadeInScreenColorInternal;

	// Token: 0x0400E560 RID: 58720
	private EMovieBackgroundType? Mp4FadeOutScreenColorInternal;

	// Token: 0x0400E561 RID: 58721
	private bool NeedOpenBlackScreenWhenTeleportDungeonInternal;

	// Token: 0x0400E562 RID: 58722
	private CustomPromise<bool> ChangeSceneModePromiseInternal;

	// Token: 0x0400E563 RID: 58723
	private CustomPromise<bool> ChangeSceneModeVoxelPromiseInternal;

	// Token: 0x0400E564 RID: 58724
	private CustomPromise<bool> ChangeSceneModeStreamingPromiseInternal;

	// Token: 0x0400E565 RID: 58725
	public bool ForceDisableGamePaused;

	// Token: 0x0400E566 RID: 58726
	public bool PreAwakeEntityDuringLoad = true;

	// Token: 0x0400E567 RID: 58727
	[Nullable(1)]
	public readonly HashSet<string> GamePausedReasons = new HashSet<string>();

	// Token: 0x0400E568 RID: 58728
	[Nullable(1)]
	public readonly HashSet<string> DataLayerSet = new HashSet<string>();

	// Token: 0x0400E569 RID: 58729
	[Nullable(1)]
	public readonly List<string> TempDataLayer = new List<string>();

	// Token: 0x0400E56A RID: 58730
	[Nullable(1)]
	public readonly Dictionary<string, bool> MaterialParameterCollectionMap = new Dictionary<string, bool>();

	// Token: 0x0400E56B RID: 58731
	[Nullable(1)]
	public readonly Dictionary<ETimeDilationType, float> TimeDilationMap = new Dictionary<ETimeDilationType, float>();

	// Token: 0x0400E56C RID: 58732
	private SceneInformation JoinSceneInfoInternal;

	// Token: 0x0400E56D RID: 58733
	private bool IndependentStreaming;

	// Token: 0x0400E56E RID: 58734
	[Nullable(1)]
	private readonly Dictionary<EStreamingSourceScaleType, float> StreamingSourceScalingTypes = new Dictionary<EStreamingSourceScaleType, float>();

	// Token: 0x0400E56F RID: 58735
	[Nullable(1)]
	private readonly Dictionary<EDisableHLODStreamingType, int> DisableHLODStreamingTypes = new Dictionary<EDisableHLODStreamingType, int>();

	// Token: 0x0400E570 RID: 58736
	private TransitionWithSpineLoadingPb SpecialTransitionPbInternal;

	// Token: 0x0400E571 RID: 58737
	private TransitionPlayFlowPb PlayFlowPbInternal;

	// Token: 0x0400E572 RID: 58738
	private ELoadingPhase LoadingPhaseInternal;

	// Token: 0x0400E573 RID: 58739
	public bool IsSameMapTraveling;

	// Token: 0x0400E574 RID: 58740
	[Nullable(1)]
	public readonly LogProfiler LoadWorldProfiler = new LogProfiler("加载世界", false);

	// Token: 0x0400E575 RID: 58741
	[Nullable(1)]
	public readonly LogProfiler OpenLoadingProfiler;

	// Token: 0x0400E576 RID: 58742
	[Nullable(1)]
	public readonly LogProfiler OpenLevelProfiler;

	// Token: 0x0400E577 RID: 58743
	[Nullable(1)]
	public readonly LogProfiler PreloadProfiler;

	// Token: 0x0400E578 RID: 58744
	[Nullable(1)]
	public readonly LogProfiler PreloadApplyMaterialParameterCollectionProfiler;

	// Token: 0x0400E579 RID: 58745
	[Nullable(1)]
	public readonly LogProfiler PreloadCommonAndEntityProfiler;

	// Token: 0x0400E57A RID: 58746
	[Nullable(1)]
	public readonly LogProfiler PreloadControllerProfiler;

	// Token: 0x0400E57B RID: 58747
	[Nullable(1)]
	public readonly LogProfiler PreloadCommonProfiler;

	// Token: 0x0400E57C RID: 58748
	[Nullable(1)]
	public readonly LogProfiler PreloadEntitiesProfiler;

	// Token: 0x0400E57D RID: 58749
	[Nullable(1)]
	public readonly LogProfiler PreloadDangoAbyssMonsterProfiler = new LogProfiler("子房间预加载团子深渊怪物实体", false);

	// Token: 0x0400E57E RID: 58750
	[Nullable(1)]
	public readonly LogProfiler LoadDataLayerAndSubLevelProfiler;

	// Token: 0x0400E57F RID: 58751
	[Nullable(1)]
	public readonly LogProfiler LoadSubLevelProfiler;

	// Token: 0x0400E580 RID: 58752
	[Nullable(1)]
	public readonly LogProfiler LoadDataLayerProfiler;

	// Token: 0x0400E581 RID: 58753
	[Nullable(1)]
	public readonly LogProfiler CheckVoxelStreamingSourceProfiler;

	// Token: 0x0400E582 RID: 58754
	[Nullable(1)]
	public readonly LogProfiler CheckStreamingSourceProfiler;

	// Token: 0x0400E583 RID: 58755
	[Nullable(1)]
	public readonly LogProfiler CreateEntitiesProfiler;

	// Token: 0x0400E584 RID: 58756
	[Nullable(1)]
	public readonly LogProfiler WaitRenderAssetsProfiler;

	// Token: 0x0400E585 RID: 58757
	[Nullable(1)]
	public readonly LogProfiler WorldDoneProfiler;

	// Token: 0x0400E586 RID: 58758
	[Nullable(1)]
	public readonly LogProfiler OpenBattleViewProfiler;

	// Token: 0x0400E587 RID: 58759
	[Nullable(1)]
	public readonly LogProfiler CloseLoadingProfiler;

	// Token: 0x0400E588 RID: 58760
	[Nullable(1)]
	public readonly LogProfiler CloseLoadingPhaseOpenBattleViewProfiler;

	// Token: 0x0400E589 RID: 58761
	private FVectorDouble? BornLocationInternal;

	// Token: 0x0400E58A RID: 58762
	private FRotator? BornRotatorInternal;

	// Token: 0x0400E58B RID: 58763
	private global::Vector RoleLocationInternal;

	// Token: 0x0400E58C RID: 58764
	private GameModePromise BeginLoadMapPromiseInternal;

	// Token: 0x0400E58D RID: 58765
	private GameModePromise AfterJoinSceneNotifyPromiseInternal;

	// Token: 0x0400E58E RID: 58766
	private GameModePromise OpenLevelPromiseInternal;

	// Token: 0x0400E58F RID: 58767
	private GameModePromise StreamingCompletedInternal;

	// Token: 0x0400E590 RID: 58768
	private GameModePromise VoxelStreamingCompletedInternal;

	// Token: 0x0400E591 RID: 58769
	private GameModePromise LoadMultiFormationPromiseInternal;

	// Token: 0x0400E592 RID: 58770
	private GameModePromise PreloadPromiseInternal;

	// Token: 0x0400E593 RID: 58771
	private GameModePromise ApplyMaterialParameterCollectionPromiseInternal;

	// Token: 0x0400E594 RID: 58772
	private GameModePromise ChangeSceneModeEndNotifyPromiseInternal;

	// Token: 0x0400E595 RID: 58773
	private TimerHandle CheckStreamingCompletedTimerIdInternal;

	// Token: 0x0400E596 RID: 58774
	private TimerHandle CheckRenderAssetsStreamingCompletedTimerIdInternal;

	// Token: 0x0400E597 RID: 58775
	private TimerHandle CheckRenderAssetsTimeoutIdInternal;

	// Token: 0x0400E598 RID: 58776
	private GameModePromise VideoStartPromiseInternal;

	// Token: 0x0400E599 RID: 58777
	private GameModePromise OpenLoadingEndPromiseInternal;

	// Token: 0x0400E59A RID: 58778
	private GameModePromise PlayFlowEndPromiseInternal;

	// Token: 0x0400E59B RID: 58779
	private bool RenderAssetDoneInternal;

	// Token: 0x0400E59C RID: 58780
	public bool EnableLoadMapMode = true;

	// Token: 0x0400E59D RID: 58781
	private ELoadMapMode LoadMapModeInternal;

	// Token: 0x0400E59E RID: 58782
	private bool ForceClientTravelInternal;

	// Token: 0x0400E59F RID: 58783
	public bool LoadMapControllerEnableWorldPartition;

	// Token: 0x0400E5A0 RID: 58784
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Dictionary<string, HashSet<ULevelStreamingDynamic>> LoadMapControllerDynamicStreamingLevelsInternal;

	// Token: 0x0400E5A1 RID: 58785
	private ITimeDilationData CacheTimeDilationData;
}
