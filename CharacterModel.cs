using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Render;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002E25 RID: 11813
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CharacterModel : ModelBase<CharacterModel>
{
	// Token: 0x1700205E RID: 8286
	// (get) Token: 0x06017E67 RID: 97895 RVA: 0x006B23A1 File Offset: 0x006B05A1
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public HashSet<EntityHandle> ExtraEntitiesToEnterSelfCenteredState
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return this.ExtraEntitiesToEnterSelfCenteredStateInternal;
		}
	}

	// Token: 0x06017E68 RID: 97896 RVA: 0x006B23A9 File Offset: 0x006B05A9
	[NullableContext(2)]
	public void AddExtraEntityToEnterSelfCenteredState(EntityHandle entityHandle)
	{
		if (entityHandle == null || !entityHandle.Valid)
		{
			return;
		}
		if (this.ExtraEntitiesToEnterSelfCenteredStateInternal == null)
		{
			this.ExtraEntitiesToEnterSelfCenteredStateInternal = new HashSet<EntityHandle>();
		}
		this.ExtraEntitiesToEnterSelfCenteredStateInternal.Add(entityHandle);
	}

	// Token: 0x06017E69 RID: 97897 RVA: 0x006B23D7 File Offset: 0x006B05D7
	public void ClearExtraEntitiesToEnterSelfCenteredState()
	{
		HashSet<EntityHandle> extraEntitiesToEnterSelfCenteredStateInternal = this.ExtraEntitiesToEnterSelfCenteredStateInternal;
		if (extraEntitiesToEnterSelfCenteredStateInternal == null)
		{
			return;
		}
		extraEntitiesToEnterSelfCenteredStateInternal.Clear();
	}

	// Token: 0x1700205F RID: 8287
	// (get) Token: 0x06017E6A RID: 97898 RVA: 0x006B23E9 File Offset: 0x006B05E9
	public bool EnabledSelfCentered
	{
		get
		{
			return this.SelfCenteredModeInternal != ESelfCenteredMode.None || this.SelfCenteredTimeDilationInternal != 1f;
		}
	}

	// Token: 0x17002060 RID: 8288
	// (get) Token: 0x06017E6B RID: 97899 RVA: 0x006B2405 File Offset: 0x006B0605
	public ESelfCenteredMode SelfCenteredMode
	{
		get
		{
			return this.SelfCenteredModeInternal;
		}
	}

	// Token: 0x17002061 RID: 8289
	// (get) Token: 0x06017E6C RID: 97900 RVA: 0x006B240D File Offset: 0x006B060D
	public float SelfCenteredTimeDilation
	{
		get
		{
			return this.SelfCenteredTimeDilationInternal;
		}
	}

	// Token: 0x17002062 RID: 8290
	// (get) Token: 0x06017E6D RID: 97901 RVA: 0x006B2415 File Offset: 0x006B0615
	public float InverseSelfCenteredTimeDilation
	{
		get
		{
			return this.InverseSelfCenteredTimeDilationInternal;
		}
	}

	// Token: 0x06017E6E RID: 97902 RVA: 0x006B241D File Offset: 0x006B061D
	private void OnInitRole(EntityHandle entity)
	{
		if (this.SelfCenteredTimeDilationInternal == 1f)
		{
			return;
		}
		this.UpdateTeamSelfCenteredState();
	}

	// Token: 0x06017E6F RID: 97903 RVA: 0x006B2433 File Offset: 0x006B0633
	private void OnUpdateSceneTeam()
	{
		if (this.SelfCenteredTimeDilationInternal == 1f)
		{
			return;
		}
		this.UpdateTeamSelfCenteredState();
	}

	// Token: 0x06017E70 RID: 97904 RVA: 0x006B244C File Offset: 0x006B064C
	private void OnPlotNetworkStart(PlotInfo plotInfo)
	{
		EPlotLevel plotLevel = plotInfo.PlotLevel;
		bool flag = plotLevel - EPlotLevel.LevelD <= 1;
		if (flag)
		{
			return;
		}
		this.ExitAllSelfCenteredMode();
	}

	// Token: 0x06017E71 RID: 97905 RVA: 0x006B2476 File Offset: 0x006B0676
	private void OnLeaveLevelEvent()
	{
		this.ExitAllSelfCenteredMode();
	}

	// Token: 0x06017E72 RID: 97906 RVA: 0x006B247E File Offset: 0x006B067E
	private void OnBackLoginEvent()
	{
		this.ExitAllSelfCenteredMode();
	}

	// Token: 0x06017E73 RID: 97907 RVA: 0x006B2486 File Offset: 0x006B0686
	private void OnSetGamePaused(bool paused)
	{
		if (!paused)
		{
			return;
		}
		if (!this.EnabledSelfCentered)
		{
			return;
		}
		this.ExitAllSelfCenteredMode();
	}

	// Token: 0x06017E74 RID: 97908 RVA: 0x006B249B File Offset: 0x006B069B
	private void OnOpenView(EUiViewName viewName, int viewId)
	{
		if (viewName != EUiViewName.PhantomExploreView && viewName != EUiViewName.ChatView && viewName != EUiViewName.ShopView)
		{
			return;
		}
		this.ExitAllSelfCenteredMode();
	}

	// Token: 0x06017E75 RID: 97909 RVA: 0x006B24CC File Offset: 0x006B06CC
	protected override bool OnInit()
	{
		this.Handles.Clear();
		this.SelfCenteredSequence.Add(5);
		this.SelfCenteredSequence.Add(3);
		this.SelfCenteredSequence.Add(2);
		this.SelfCenteredSequence.Add(1);
		this.SelfCenteredSequence.Add(4);
		Singleton<EventSystem>.Instance.Add<EntityHandle>(EEventName.OnInitRole, new Action<EntityHandle>(this.OnInitRole));
		Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
		Singleton<EventSystem>.Instance.Add<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnPlotNetworkStart));
		Singleton<EventSystem>.Instance.Add(EEventName.DoLeaveLevel, new Action(this.OnLeaveLevelEvent));
		Singleton<EventSystem>.Instance.Add(EEventName.BackLoginView, new Action(this.OnBackLoginEvent));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnSetGamePaused, new Action<bool>(this.OnSetGamePaused));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		return true;
	}

	// Token: 0x06017E76 RID: 97910 RVA: 0x006B25E4 File Offset: 0x006B07E4
	protected override bool OnClear()
	{
		this.ClearData();
		Singleton<EventSystem>.Instance.Remove<EntityHandle>(EEventName.OnInitRole, new Action<EntityHandle>(this.OnInitRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
		Singleton<EventSystem>.Instance.Remove<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnPlotNetworkStart));
		Singleton<EventSystem>.Instance.Remove(EEventName.DoLeaveLevel, new Action(this.OnLeaveLevelEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.BackLoginView, new Action(this.OnBackLoginEvent));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnSetGamePaused, new Action<bool>(this.OnSetGamePaused));
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		return true;
	}

	// Token: 0x06017E77 RID: 97911 RVA: 0x006B26B8 File Offset: 0x006B08B8
	protected override bool OnLeaveLevel()
	{
		this.ClearData();
		return true;
	}

	// Token: 0x06017E78 RID: 97912 RVA: 0x006B26C1 File Offset: 0x006B08C1
	protected override bool OnChangeMode()
	{
		this.ExitAllSelfCenteredMode();
		return true;
	}

	// Token: 0x06017E79 RID: 97913 RVA: 0x006B26CC File Offset: 0x006B08CC
	public EntityHandle CreateHandle(WorldEntity entity)
	{
		int index = entity.Index;
		while (this.Handles.Count <= index)
		{
			this.Handles.Add(null);
		}
		EntityHandle entityHandle = new EntityHandle(entity);
		this.Handles[index] = entityHandle;
		return entityHandle;
	}

	// Token: 0x06017E7A RID: 97914 RVA: 0x006B2714 File Offset: 0x006B0914
	public void ClearHandle(EntityHandle handle)
	{
		int index = handle.Index;
		if (index >= this.Handles.Count)
		{
			return;
		}
		this.Handles[index] = null;
	}

	// Token: 0x06017E7B RID: 97915 RVA: 0x006B2744 File Offset: 0x006B0944
	public void PushAwakeHandler(EntityHandle handle, Func<bool> onAwake, Func<bool> onSleep)
	{
		ValueTuple<EntityHandle, Func<bool>, Func<bool>> valueTuple = new ValueTuple<EntityHandle, Func<bool>, Func<bool>>(handle, onAwake, onSleep);
		this.AwakeQueue.Push(valueTuple);
		this.AwakeMap[handle] = valueTuple;
	}

	// Token: 0x06017E7C RID: 97916 RVA: 0x006B2774 File Offset: 0x006B0974
	[return: Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})]
	public ValueTuple<EntityHandle, Func<bool>, Func<bool>>? PopAwakeHandler()
	{
		if (this.AwakeQueue.Empty)
		{
			return null;
		}
		ValueTuple<EntityHandle, Func<bool>, Func<bool>> valueTuple = this.AwakeQueue.Pop();
		this.AwakeMap.Remove(valueTuple.Item1);
		return new ValueTuple<EntityHandle, Func<bool>, Func<bool>>?(valueTuple);
	}

	// Token: 0x06017E7D RID: 97917 RVA: 0x006B27BC File Offset: 0x006B09BC
	public void ClearData()
	{
		this.AwakeQueue.Clear();
		this.AwakeMap.Clear();
	}

	// Token: 0x06017E7E RID: 97918 RVA: 0x006B27D4 File Offset: 0x006B09D4
	[NullableContext(2)]
	public EntityHandle GetHandle(int id)
	{
		if (id == 0)
		{
			return null;
		}
		int num = (int)((uint)id >> 16);
		if (num >= this.Handles.Count)
		{
			return null;
		}
		EntityHandle entityHandle = this.Handles[num];
		if (entityHandle != null && entityHandle.Id == id)
		{
			return entityHandle;
		}
		return null;
	}

	// Token: 0x06017E7F RID: 97919 RVA: 0x006B2818 File Offset: 0x006B0A18
	[NullableContext(2)]
	public EntityHandle GetHandleByEntity(Entity entity)
	{
		if (entity == null)
		{
			return null;
		}
		int index = entity.Index;
		if (index >= this.Handles.Count)
		{
			return null;
		}
		EntityHandle entityHandle = this.Handles[index];
		int? num = (entityHandle != null) ? new int?(entityHandle.Id) : null;
		int id = entity.Id;
		if (num.GetValueOrDefault() == id & num != null)
		{
			return entityHandle;
		}
		return null;
	}

	// Token: 0x06017E80 RID: 97920 RVA: 0x006B2888 File Offset: 0x006B0A88
	public bool IsValid(int id)
	{
		int num = (int)((uint)id >> 16);
		if (num >= this.Handles.Count)
		{
			return false;
		}
		EntityHandle entityHandle = this.Handles[num];
		return entityHandle != null && entityHandle.Id == id;
	}

	// Token: 0x06017E81 RID: 97921 RVA: 0x006B28C4 File Offset: 0x006B0AC4
	public void SortItem(EntityHandle handle)
	{
		ValueTuple<EntityHandle, Func<bool>, Func<bool>> item;
		if (!this.AwakeMap.TryGetValue(handle, out item))
		{
			return;
		}
		this.AwakeQueue.Update(item);
	}

	// Token: 0x06017E82 RID: 97922 RVA: 0x006B28EF File Offset: 0x006B0AEF
	public void EnterSelfCenteredMode(ESelfCenteredMode mode, float timeDilation, float duration = -1f)
	{
		this.EnableSelfCenteredMode(mode, timeDilation, duration);
		this.SwitchSelfCenteredMode(this.GetNextSelfCenteredMode());
	}

	// Token: 0x06017E83 RID: 97923 RVA: 0x006B2908 File Offset: 0x006B0B08
	public void ExitSkillSelfCenteredMode()
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		BaseSkillComponent baseSkillComponent;
		if (baseCharacter == null)
		{
			baseSkillComponent = null;
		}
		else
		{
			Entity entityNoBlueprint = baseCharacter.GetEntityNoBlueprint();
			baseSkillComponent = ((entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<BaseSkillComponent>() : null);
		}
		BaseSkillComponent baseSkillComponent2 = baseSkillComponent;
		if (baseSkillComponent2 != null && baseSkillComponent2.Valid)
		{
			baseSkillComponent2.BeginSkillAsync(210027, null);
		}
		ControllerBase<CharacterController>.Instance.ExitSelfCenteredMode(ESelfCenteredMode.Skill);
	}

	// Token: 0x06017E84 RID: 97924 RVA: 0x006B2956 File Offset: 0x006B0B56
	public void ExitSelfCenteredMode(ESelfCenteredMode mode)
	{
		this.DisableSelfCenteredMode(mode);
		this.SwitchSelfCenteredMode(this.GetNextSelfCenteredMode());
	}

	// Token: 0x06017E85 RID: 97925 RVA: 0x006B296C File Offset: 0x006B0B6C
	public void ExitAllSelfCenteredMode()
	{
		if (this.IsSelfCenteredModeEnabled(ESelfCenteredMode.Skill))
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			BaseSkillComponent baseSkillComponent;
			if (baseCharacter == null)
			{
				baseSkillComponent = null;
			}
			else
			{
				Entity entityNoBlueprint = baseCharacter.GetEntityNoBlueprint();
				baseSkillComponent = ((entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<BaseSkillComponent>() : null);
			}
			BaseSkillComponent baseSkillComponent2 = baseSkillComponent;
			if (baseSkillComponent2 != null && baseSkillComponent2.Valid)
			{
				baseSkillComponent2.BeginSkillAsync(210027, null);
			}
		}
		foreach (int num in this.SelfCenteredSequence)
		{
			this.SelfCenteredEnableModeArray[num] = false;
			this.SelfCenteredTimeDilationArray[num] = 1f;
			this.SelfCenteredTimeDurationArray[num] = 0f;
		}
		this.SwitchSelfCenteredMode(this.GetNextSelfCenteredMode());
	}

	// Token: 0x06017E86 RID: 97926 RVA: 0x006B2A28 File Offset: 0x006B0C28
	public bool IsSelfCenteredModeEnabled(ESelfCenteredMode mode)
	{
		return (int)mode < this.SelfCenteredEnableModeArray.Length && this.SelfCenteredEnableModeArray[(int)mode];
	}

	// Token: 0x06017E87 RID: 97927 RVA: 0x006B2A4C File Offset: 0x006B0C4C
	public unsafe void EnableSelfCenteredMode(ESelfCenteredMode mode, float timeDilation, float duration = -1f)
	{
		if ((double)timeDilation <= 1E-08)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "Error SelfCentered TimeDilation.";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("mode", mode);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TimeDilation", timeDilation);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		this.SelfCenteredEnableModeArray[(int)mode] = true;
		this.SelfCenteredTimeDilationArray[(int)mode] = timeDilation;
		this.SelfCenteredTimeDurationArray[(int)mode] = duration;
	}

	// Token: 0x06017E88 RID: 97928 RVA: 0x006B2ADF File Offset: 0x006B0CDF
	public void DisableSelfCenteredMode(ESelfCenteredMode mode)
	{
		this.SelfCenteredEnableModeArray[(int)mode] = false;
		this.SelfCenteredTimeDilationArray[(int)mode] = 1f;
		this.SelfCenteredTimeDurationArray[(int)mode] = 0f;
	}

	// Token: 0x06017E89 RID: 97929 RVA: 0x006B2B04 File Offset: 0x006B0D04
	public ESelfCenteredMode GetNextSelfCenteredMode()
	{
		foreach (int num in this.SelfCenteredSequence)
		{
			if (this.SelfCenteredEnableModeArray[num])
			{
				return (ESelfCenteredMode)num;
			}
		}
		return ESelfCenteredMode.None;
	}

	// Token: 0x06017E8A RID: 97930 RVA: 0x006B2B64 File Offset: 0x006B0D64
	private float GetSelfCenteredTimeDilationByMode(ESelfCenteredMode mode)
	{
		if (this.SelfCenteredEnableModeArray[(int)mode])
		{
			return this.SelfCenteredTimeDilationArray[(int)mode];
		}
		return 1f;
	}

	// Token: 0x06017E8B RID: 97931 RVA: 0x006B2B7E File Offset: 0x006B0D7E
	private float GetSelfCenteredTimeDurationByMode(ESelfCenteredMode mode)
	{
		if (this.SelfCenteredEnableModeArray[(int)mode])
		{
			return this.SelfCenteredTimeDurationArray[(int)mode];
		}
		return 0f;
	}

	// Token: 0x06017E8C RID: 97932 RVA: 0x006B2B98 File Offset: 0x006B0D98
	public unsafe bool SwitchSelfCenteredMode(ESelfCenteredMode mode)
	{
		float selfCenteredTimeDilationByMode = this.GetSelfCenteredTimeDilationByMode(mode);
		if (this.SelfCenteredModeInternal == mode && Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.SelfCenteredTimeDilationInternal, (double)selfCenteredTimeDilationByMode, null))
		{
			return false;
		}
		ESelfCenteredMode selfCenteredModeInternal = this.SelfCenteredModeInternal;
		this.SelfCenteredModeInternal = mode;
		this.SelfCenteredTimeDilationInternal = selfCenteredTimeDilationByMode;
		this.InverseSelfCenteredTimeDilationInternal = 1f / selfCenteredTimeDilationByMode;
		UGameplayStatics.SetGlobalTimeDilation(GlobalData.GameInstance, selfCenteredTimeDilationByMode);
		Singleton<Time>.Instance.SetInverseSelfCenteredTimeDilation(this.InverseSelfCenteredTimeDilationInternal);
		Singleton<Time>.Instance.SetFlowTimeDilation(this.InverseSelfCenteredTimeDilationInternal);
		ControllerBase<FormationDataController>.Instance.SetTimeDilation(this.InverseSelfCenteredTimeDilation);
		USequencerManager sequencerManager = ALGUIManagerActor.GetSequencerManager(GlobalData.World);
		if (sequencerManager != null)
		{
			sequencerManager.SetGlobalPlayRate(this.InverseSelfCenteredTimeDilation);
		}
		ALTweenActor ltweenInstance = ALTweenActor.GetLTweenInstance(GlobalData.World);
		if (ltweenInstance != null)
		{
			ltweenInstance.SetGlobalPlayRate(this.InverseSelfCenteredTimeDilation);
		}
		if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.SelfCenteredTimeDilationInternal, 1.0, null))
		{
			Singleton<AudioSystem>.Instance.SetState("level_2_5_time_slow", "none", true);
			Singleton<AudioSystem>.Instance.PostEvent("disable_monster_effect_2_5_time_slow");
			this.SetEffectSystemScaleEnable(false);
			TimerSystem.Instance.Next(delegate(float _)
			{
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				BaseTagComponent baseTagComponent;
				if (baseCharacter == null)
				{
					baseTagComponent = null;
				}
				else
				{
					CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
					baseTagComponent = ((characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<BaseTagComponent>() : null);
				}
				BaseTagComponent baseTagComponent2 = baseTagComponent;
				bool flag = baseTagComponent2 != null && baseTagComponent2.Valid && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.状态.空中状态.翱翔"]);
				if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.SelfCenteredTimeDilationInternal, 1.0, null) && !flag)
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.MotionBlur.TargetFPS -1", null);
					return;
				}
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.MotionBlur.TargetFPS 1200", null);
			}, null, null);
			Singleton<EffectSystem>.Instance.EnableNiagaraDownSampling();
			RenderUtil.UnsetNeedRenderKuroToonDepth();
		}
		else
		{
			Singleton<AudioSystem>.Instance.SetState("level_2_5_time_slow", "enable", true);
			Singleton<AudioSystem>.Instance.PostEvent("enable_monster_effect_2_5_time_slow");
			this.SetEffectSystemScaleEnable(true);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.MotionBlur.TargetFPS 1200", null);
			Singleton<EffectSystem>.Instance.DisableNiagaraDownSampling();
			RenderUtil.SetNeedRenderKuroToonDepth();
		}
		this.UpdateTeamSelfCenteredState();
		this.UpdateExtraEntitySelfCenteredState();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Character;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "SelfCentered Change.";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("timeDilation", selfCenteredTimeDilationByMode);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SelfCenteredMode", this.SelfCenteredModeInternal);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (selfCenteredModeInternal != ESelfCenteredMode.Skill && this.SelfCenteredModeInternal == ESelfCenteredMode.Skill)
		{
			this.OnEnterSkillSelfCenteredMode();
		}
		else if (selfCenteredModeInternal == ESelfCenteredMode.Skill)
		{
			this.OnExitSkillSelfCenteredMode();
		}
		Singleton<EventSystem>.Instance.Emit<ESelfCenteredMode, float>(EEventName.OnSwitchSelfCenteredMode, this.SelfCenteredModeInternal, selfCenteredTimeDilationByMode);
		SlowTimePush slowTimePush = SlowTimePush.Create();
		slowTimePush.Dilation = selfCenteredTimeDilationByMode;
		slowTimePush.Flag = (selfCenteredTimeDilationByMode != 1f);
		slowTimePush.Duration = (int)(this.GetSelfCenteredTimeDurationByMode(mode) * (float)Singleton<TimeUtil>.Instance.InverseMillisecond);
		Singleton<Net>.Instance.Send(EPushMessageId.SlowTimePush, slowTimePush);
		return true;
	}

	// Token: 0x06017E8D RID: 97933 RVA: 0x006B2E20 File Offset: 0x006B1020
	private void OnEnterSkillSelfCenteredMode()
	{
		ControllerBase<FormationAttributeController>.Instance.AddThresholdListener(EFormationAttributeId.TimeScaleStrength, new TThresholdListener(this.StrengthEmptyCallback), 0f, 0f, "Strength.RoleStrengthComponent");
		ControllerBase<FormationDataController>.Instance.AddPlayerTag(ModelBase<CreatureModel>.Instance.GetPlayerId(), new int?(GameplayTagDefine.EGameplayTagId["角色.Common.时间缩放.技能"]));
	}

	// Token: 0x06017E8E RID: 97934 RVA: 0x006B2E7C File Offset: 0x006B107C
	private void OnExitSkillSelfCenteredMode()
	{
		ControllerBase<FormationAttributeController>.Instance.RemoveThresholdListener(EFormationAttributeId.TimeScaleStrength, new TThresholdListener(this.StrengthEmptyCallback));
		ControllerBase<FormationDataController>.Instance.RemovePlayerTag(ModelBase<CreatureModel>.Instance.GetPlayerId(), new int?(GameplayTagDefine.EGameplayTagId["角色.Common.时间缩放.技能"]));
	}

	// Token: 0x06017E8F RID: 97935 RVA: 0x006B2EC9 File Offset: 0x006B10C9
	private void StrengthEmptyCallback(EFormationAttributeId attrId, bool inInterval, float currentRatio)
	{
		if (this.SelfCenteredModeInternal == ESelfCenteredMode.Skill)
		{
			this.ExitSkillSelfCenteredMode();
		}
	}

	// Token: 0x06017E90 RID: 97936 RVA: 0x006B2EDC File Offset: 0x006B10DC
	private void SetEffectSystemScaleEnable(bool enable)
	{
		for (int i = 0; i < 18; i++)
		{
			Singleton<EffectSystem>.Instance.SetAdditionTimeScaleEnable((ETimeScaleSourceType)i, enable);
		}
	}

	// Token: 0x06017E91 RID: 97937 RVA: 0x006B2F04 File Offset: 0x006B1104
	private void SetEntitySelfCenterTimeDilation(float timeDilation, EntityHandle entityHandle)
	{
		if (!entityHandle.Valid)
		{
			return;
		}
		CharacterSelfCenterComponent component = entityHandle.Entity.GetComponent<CharacterSelfCenterComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		component.SetSelfCenterTimeDilation(timeDilation, true);
	}

	// Token: 0x06017E92 RID: 97938 RVA: 0x006B2F3C File Offset: 0x006B113C
	private void UpdateTeamSelfCenteredState()
	{
		foreach (EntityHandle entityHandle in ModelBase<SceneTeamModel>.Instance.GetTeamEntities(true))
		{
			this.SetEntitySelfCenterTimeDilation(this.InverseSelfCenteredTimeDilation, entityHandle);
		}
	}

	// Token: 0x06017E93 RID: 97939 RVA: 0x006B2F9C File Offset: 0x006B119C
	private void UpdateExtraEntitySelfCenteredState()
	{
		if (this.ExtraEntitiesToEnterSelfCenteredStateInternal != null)
		{
			foreach (EntityHandle entityHandle in this.ExtraEntitiesToEnterSelfCenteredStateInternal)
			{
				this.SetEntitySelfCenterTimeDilation(this.InverseSelfCenteredTimeDilation, entityHandle);
			}
		}
	}

	// Token: 0x0400B96E RID: 47470
	private const int ENTITY_LRU_CAPACITY = 300;

	// Token: 0x0400B96F RID: 47471
	[StaticVariableRuleIgnore]
	private static readonly global::Vector AEntityLocation = global::Vector.Create();

	// Token: 0x0400B970 RID: 47472
	[StaticVariableRuleIgnore]
	private static readonly global::Vector BEntityLocation = global::Vector.Create();

	// Token: 0x0400B971 RID: 47473
	private const int SELF_CENTERED_SKILL_ID = 210027;

	// Token: 0x0400B972 RID: 47474
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly List<EntityHandle> Handles = new List<EntityHandle>();

	// Token: 0x0400B973 RID: 47475
	private readonly bool[] SelfCenteredEnableModeArray = new bool[6];

	// Token: 0x0400B974 RID: 47476
	private readonly float[] SelfCenteredTimeDilationArray = new float[6];

	// Token: 0x0400B975 RID: 47477
	private readonly float[] SelfCenteredTimeDurationArray = new float[6];

	// Token: 0x0400B976 RID: 47478
	private readonly List<int> SelfCenteredSequence = new List<int>();

	// Token: 0x0400B977 RID: 47479
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private HashSet<EntityHandle> ExtraEntitiesToEnterSelfCenteredStateInternal;

	// Token: 0x0400B978 RID: 47480
	[Nullable(new byte[]
	{
		1,
		0,
		1,
		1,
		1
	})]
	public readonly PriorityQueue<ValueTuple<EntityHandle, Func<bool>, Func<bool>>> AwakeQueue = new PriorityQueue<ValueTuple<EntityHandle, Func<bool>, Func<bool>>>(delegate([Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})] ValueTuple<EntityHandle, Func<bool>, Func<bool>> a, [Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})] ValueTuple<EntityHandle, Func<bool>, Func<bool>> b)
	{
		EntityHandle item = a.Item1;
		EntityHandle item2 = b.Item1;
		int priority = (int)item2.Priority;
		int priority2 = (int)item.Priority;
		if (priority != priority2)
		{
			return priority - priority2;
		}
		CreatureDataComponent creatureDataComponent;
		if (!item.Valid)
		{
			creatureDataComponent = null;
		}
		else
		{
			WorldEntity entity = item.Entity;
			creatureDataComponent = ((entity != null) ? entity.GetComponent<CreatureDataComponent>() : null);
		}
		CreatureDataComponent creatureDataComponent2 = creatureDataComponent;
		CreatureDataComponent creatureDataComponent3;
		if (!item2.Valid)
		{
			creatureDataComponent3 = null;
		}
		else
		{
			WorldEntity entity2 = item2.Entity;
			creatureDataComponent3 = ((entity2 != null) ? entity2.GetComponent<CreatureDataComponent>() : null);
		}
		CreatureDataComponent creatureDataComponent4 = creatureDataComponent3;
		if (creatureDataComponent2 == null || creatureDataComponent4 == null)
		{
			return 0;
		}
		FVectorDouble location = creatureDataComponent2.GetLocation();
		CharacterModel.AEntityLocation.X = location.X;
		CharacterModel.AEntityLocation.Y = location.Y;
		CharacterModel.AEntityLocation.Z = location.Z;
		FVectorDouble location2 = creatureDataComponent4.GetLocation();
		CharacterModel.BEntityLocation.X = location2.X;
		CharacterModel.BEntityLocation.Y = location2.Y;
		CharacterModel.BEntityLocation.Z = location2.Z;
		global::Vector roleLocation = ModelBase<GameModeModel>.Instance.RoleLocation;
		double num = global::Vector.DistSquared(roleLocation, CharacterModel.AEntityLocation);
		double value = global::Vector.DistSquared(roleLocation, CharacterModel.BEntityLocation);
		return num.CompareTo(value);
	});

	// Token: 0x0400B979 RID: 47481
	[Nullable(new byte[]
	{
		1,
		1,
		0,
		1,
		1,
		1
	})]
	private readonly Dictionary<EntityHandle, ValueTuple<EntityHandle, Func<bool>, Func<bool>>> AwakeMap = new Dictionary<EntityHandle, ValueTuple<EntityHandle, Func<bool>, Func<bool>>>();

	// Token: 0x0400B97A RID: 47482
	public bool TestSoarOn;

	// Token: 0x0400B97B RID: 47483
	public readonly Lru<BigInteger, WorldEntity> EntityPool = new Lru<BigInteger, WorldEntity>(300, (BigInteger key) => new WorldEntity(0, 0), null);

	// Token: 0x0400B97C RID: 47484
	private ESelfCenteredMode SelfCenteredModeInternal;

	// Token: 0x0400B97D RID: 47485
	private float SelfCenteredTimeDilationInternal = 1f;

	// Token: 0x0400B97E RID: 47486
	private float InverseSelfCenteredTimeDilationInternal = 1f;
}
