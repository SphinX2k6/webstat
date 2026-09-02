using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.Map.Marks;
using CSharpScript.Game.Ui;
using CSharpScript.Game.World.Define;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200232C RID: 9004
[NullableContext(2)]
[Nullable(0)]
public class NpcIconComponent : IGameBudgetManagedObject
{
	// Token: 0x17001532 RID: 5426
	// (get) Token: 0x0601120B RID: 70155 RVA: 0x004B46F1 File Offset: 0x004B28F1
	// (set) Token: 0x0601120C RID: 70156 RVA: 0x004B46F9 File Offset: 0x004B28F9
	private bool IsSelfVisible
	{
		get
		{
			return this.IsSelfVisibleInner;
		}
		set
		{
			this.IsSelfVisibleInner = value;
		}
	}

	// Token: 0x17001533 RID: 5427
	// (get) Token: 0x0601120D RID: 70157 RVA: 0x004B4702 File Offset: 0x004B2902
	// (set) Token: 0x0601120E RID: 70158 RVA: 0x004B470A File Offset: 0x004B290A
	private bool IsNpcVisible
	{
		get
		{
			return this.IsNpcVisibleInner;
		}
		set
		{
			this.IsNpcVisibleInner = value;
		}
	}

	// Token: 0x17001534 RID: 5428
	// (get) Token: 0x0601120F RID: 70159 RVA: 0x004B4713 File Offset: 0x004B2913
	private bool IsVisible
	{
		get
		{
			return this.IsSelfVisible || this.IsNpcVisible;
		}
	}

	// Token: 0x06011210 RID: 70160 RVA: 0x004B4728 File Offset: 0x004B2928
	[NullableContext(1)]
	public NpcIconComponent(INpcIconFunction data)
	{
		this.Data = data;
		this.MaxShowRangeDisSquared = (double)ConfigBase<NpcIconConfig>.Instance.NpcIconHeadInfoLimitMaxDistanceSquared;
	}

	// Token: 0x06011211 RID: 70161 RVA: 0x004B477C File Offset: 0x004B297C
	public unsafe void RegisterTick()
	{
		if (this.GameBudgetManagedTokenInternal != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HudUnit;
			ELogAuthor author = ELogAuthor.WLJ;
			string message = "NpcIconComponent RegisterTick: 重复注册Tick";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcIconComponent", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Path", this.Path);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.UnregisterTick();
		}
		if (!this.GameBudgetGCHandle.IsAllocated)
		{
			this.GameBudgetGCHandle = GCHandle.Alloc(this, GCHandleType.Normal);
		}
		TsGameBudgetGroupConfigCache tsHUDTickConfig = Singleton<GameBudgetAllocatorConfigCreator>.Instance.TsHUDTickConfig;
		GameBudgetInterfaceController instance2 = Singleton<GameBudgetInterfaceController>.Instance;
		FName groupName = tsHUDTickConfig.GroupName;
		ESignificanceGroup significanceGroup = tsHUDTickConfig.SignificanceGroup;
		UiPoolActor uiPoolActor = this.UiPoolActor;
		this.GameBudgetManagedTokenInternal = new uint?(instance2.RegisterTick(groupName, significanceGroup, this, (uiPoolActor != null) ? uiPoolActor.Actor : null, true, true, true, true));
	}

	// Token: 0x06011212 RID: 70162 RVA: 0x004B485E File Offset: 0x004B2A5E
	public void UnregisterTick()
	{
		if (this.GameBudgetManagedTokenInternal != null)
		{
			Singleton<GameBudgetInterfaceController>.Instance.UnregisterTick(this);
			this.GameBudgetManagedTokenInternal = null;
		}
		if (this.GameBudgetGCHandle.IsAllocated)
		{
			this.GameBudgetGCHandle.Free();
		}
	}

	// Token: 0x06011213 RID: 70163 RVA: 0x004B489C File Offset: 0x004B2A9C
	public void ScheduledTick(float deltaSeconds, int deltaFrames, float distance)
	{
	}

	// Token: 0x17001535 RID: 5429
	// (get) Token: 0x06011214 RID: 70164 RVA: 0x004B489E File Offset: 0x004B2A9E
	public bool HasScheduledAfterTick
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06011215 RID: 70165 RVA: 0x004B48A1 File Offset: 0x004B2AA1
	public void ScheduledAfterTick(float deltaSeconds, int deltaFrames, float distance)
	{
		this.Tick(deltaSeconds * 1000f, false);
	}

	// Token: 0x17001536 RID: 5430
	// (get) Token: 0x06011216 RID: 70166 RVA: 0x004B48B1 File Offset: 0x004B2AB1
	public bool HasOnEnabledChange
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06011217 RID: 70167 RVA: 0x004B48B4 File Offset: 0x004B2AB4
	public void OnEnabledChange(bool enable, float distance)
	{
		this.SetRootItemState(enable);
	}

	// Token: 0x06011218 RID: 70168 RVA: 0x004B48BD File Offset: 0x004B2ABD
	public void SetInteractionSpotVisible(bool isVisible)
	{
		this.IsInteractionSpotVisible = isVisible;
	}

	// Token: 0x17001537 RID: 5431
	// (get) Token: 0x06011219 RID: 70169 RVA: 0x004B48C6 File Offset: 0x004B2AC6
	public bool HasOnWasRecentlyRenderedOnScreenChange
	{
		get
		{
			return true;
		}
	}

	// Token: 0x0601121A RID: 70170 RVA: 0x004B48C9 File Offset: 0x004B2AC9
	public void OnWasRecentlyRenderedOnScreenChange(bool wasRecentlyRenderedOnScreen)
	{
		this.IsSelfVisible = wasRecentlyRenderedOnScreen;
	}

	// Token: 0x0601121B RID: 70171 RVA: 0x004B48D2 File Offset: 0x004B2AD2
	public GCHandle GetGCHandle()
	{
		return this.GameBudgetGCHandle;
	}

	// Token: 0x0601121C RID: 70172 RVA: 0x004B48DA File Offset: 0x004B2ADA
	public void OnNpcWasRecentlyRenderedOnScreenChange(bool wasRecentlyRenderedOnScreen)
	{
		this.IsNpcVisible = wasRecentlyRenderedOnScreen;
	}

	// Token: 0x0601121D RID: 70173 RVA: 0x004B48E3 File Offset: 0x004B2AE3
	public void SetupCheckRange(double maxDisSquared)
	{
		this.MaxShowRangeDisSquared = maxDisSquared;
	}

	// Token: 0x0601121E RID: 70174 RVA: 0x004B48EC File Offset: 0x004B2AEC
	[NullableContext(0)]
	public UniTask<bool> AddNpcIconAsync()
	{
		NpcIconComponent.<AddNpcIconAsync>d__48 <AddNpcIconAsync>d__;
		<AddNpcIconAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<AddNpcIconAsync>d__.<>4__this = this;
		<AddNpcIconAsync>d__.<>1__state = -1;
		<AddNpcIconAsync>d__.<>t__builder.Start<NpcIconComponent.<AddNpcIconAsync>d__48>(ref <AddNpcIconAsync>d__);
		return <AddNpcIconAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601121F RID: 70175 RVA: 0x004B4930 File Offset: 0x004B2B30
	[NullableContext(0)]
	protected UniTask<bool> CreateNpcIcon()
	{
		NpcIconComponent.<CreateNpcIcon>d__49 <CreateNpcIcon>d__;
		<CreateNpcIcon>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<CreateNpcIcon>d__.<>4__this = this;
		<CreateNpcIcon>d__.<>1__state = -1;
		<CreateNpcIcon>d__.<>t__builder.Start<NpcIconComponent.<CreateNpcIcon>d__49>(ref <CreateNpcIcon>d__);
		return <CreateNpcIcon>d__.<>t__builder.Task;
	}

	// Token: 0x06011220 RID: 70176 RVA: 0x004B4973 File Offset: 0x004B2B73
	[NullableContext(1)]
	public void RegisterNpcIconCreateCallback(Action callback)
	{
		this.NpcIconCreateCallback = callback;
	}

	// Token: 0x06011221 RID: 70177 RVA: 0x004B497C File Offset: 0x004B2B7C
	public void SetCharacterIconLocation()
	{
		UPrimitiveComponent attachToMeshComponent = this.Data.GetAttachToMeshComponent();
		if (attachToMeshComponent is UStaticMeshComponent)
		{
			Vector tmpVector = this.TmpVector;
			FVectorDouble fvectorDouble = attachToMeshComponent.D_K2_GetComponentLocation();
			tmpVector.FromUeVector(fvectorDouble);
		}
		else
		{
			this.Data.GetAttachToLocation(this.TmpVector);
		}
		double addOffsetZ = this.Data.GetAddOffsetZ();
		double offsetZ = (double)(this.Data.IsShowPlayerInfo() ? ConfigBase<NpcIconConfig>.Instance.GetPlayerInfoIconLocationOffsetZ() : ConfigBase<NpcIconConfig>.Instance.GetNpcIconLocationOffsetZ()) + addOffsetZ;
		this.HeadView.InitItemLocation(this.TmpVector.ToUeVector(false), offsetZ);
	}

	// Token: 0x06011222 RID: 70178 RVA: 0x004B4A0F File Offset: 0x004B2C0F
	public void SetCharacterName(string headName)
	{
		NpcIconComponentView headView = this.HeadView;
		if (headView == null)
		{
			return;
		}
		headView.SetNpcName(headName);
	}

	// Token: 0x06011223 RID: 70179 RVA: 0x004B4A22 File Offset: 0x004B2C22
	public void SetCharacterSecondName(string name)
	{
		NpcIconComponentView headView = this.HeadView;
		if (headView == null)
		{
			return;
		}
		headView.SetNpcSecondName(name);
	}

	// Token: 0x06011224 RID: 70180 RVA: 0x004B4A35 File Offset: 0x004B2C35
	public void SetCharacterFunctionIcon(string path)
	{
		NpcIconComponentView headView = this.HeadView;
		if (headView == null)
		{
			return;
		}
		headView.SetFunctionIcon(path, null);
	}

	// Token: 0x06011225 RID: 70181 RVA: 0x004B4A49 File Offset: 0x004B2C49
	public void SetNpcQuest(string path)
	{
		NpcIconComponentView headView = this.HeadView;
		if (headView == null)
		{
			return;
		}
		headView.SetNpcQuestIcon(path);
	}

	// Token: 0x06011226 RID: 70182 RVA: 0x004B4A5C File Offset: 0x004B2C5C
	public void SetHeadItemState(bool bState)
	{
		NpcIconComponentView headView = this.HeadView;
		if (headView == null)
		{
			return;
		}
		headView.SetHeadItemState(bState);
	}

	// Token: 0x06011227 RID: 70183 RVA: 0x004B4A6F File Offset: 0x004B2C6F
	public void SetQuestTrackCellState(bool bState)
	{
		NpcIconComponentView headView = this.HeadView;
		if (headView == null)
		{
			return;
		}
		headView.SetQuestTrackCellState(bState);
	}

	// Token: 0x06011228 RID: 70184 RVA: 0x004B4A82 File Offset: 0x004B2C82
	public void SetRootItemState(bool bState)
	{
		NpcIconComponentView headView = this.HeadView;
		if (headView == null)
		{
			return;
		}
		headView.SetRootItemState(bState, false);
	}

	// Token: 0x06011229 RID: 70185 RVA: 0x004B4A96 File Offset: 0x004B2C96
	public bool GetRootItemState()
	{
		NpcIconComponentView headView = this.HeadView;
		return headView != null && headView.GetRootItemState();
	}

	// Token: 0x0601122A RID: 70186 RVA: 0x004B4AA9 File Offset: 0x004B2CA9
	public void SetHeadInfoNameState(bool bState)
	{
		NpcIconComponentView headView = this.HeadView;
		if (headView == null)
		{
			return;
		}
		headView.SetHeadInfoNameState(bState);
	}

	// Token: 0x0601122B RID: 70187 RVA: 0x004B4ABC File Offset: 0x004B2CBC
	public bool GetHeadInfoNameState()
	{
		NpcIconComponentView headView = this.HeadView;
		return headView != null && headView.GetHeadInfoNameState();
	}

	// Token: 0x0601122C RID: 70188 RVA: 0x004B4ACF File Offset: 0x004B2CCF
	public void SetQuestInfoState(bool bState)
	{
		NpcIconComponentView headView = this.HeadView;
		if (headView == null)
		{
			return;
		}
		headView.SetNpcQuestIconState(bState);
	}

	// Token: 0x0601122D RID: 70189 RVA: 0x004B4AE2 File Offset: 0x004B2CE2
	public void SetQuestTrackEffectState(bool bState)
	{
		NpcIconComponentView headView = this.HeadView;
		if (headView == null)
		{
			return;
		}
		headView.SetTrackEffectState(bState);
	}

	// Token: 0x0601122E RID: 70190 RVA: 0x004B4AF5 File Offset: 0x004B2CF5
	public void SetEntityPbDataId(int id)
	{
		this.EntityPbDataId = id;
	}

	// Token: 0x0601122F RID: 70191 RVA: 0x004B4AFE File Offset: 0x004B2CFE
	[NullableContext(1)]
	public void SetDialogueText(string text, float removeSeconds = -1f, bool redDot = false)
	{
		this.RemoveMillSeconds = removeSeconds * 1000f;
		NpcIconComponentView headView = this.HeadView;
		if (headView != null)
		{
			headView.SetDialogueActive(true, redDot, false);
		}
		NpcIconComponentView headView2 = this.HeadView;
		if (headView2 != null)
		{
			headView2.SetDialogueText(text);
		}
		if (redDot)
		{
			this.SetTargetTracking(true);
		}
	}

	// Token: 0x06011230 RID: 70192 RVA: 0x004B4B3D File Offset: 0x004B2D3D
	public void HideDialogueText()
	{
		this.RemoveMillSeconds = -1f;
		NpcIconComponentView headView = this.HeadView;
		if (headView != null)
		{
			headView.SetDialogueActive(false, false, false);
		}
		this.SetTargetTracking(false);
	}

	// Token: 0x06011231 RID: 70193 RVA: 0x004B4B65 File Offset: 0x004B2D65
	public void UpdateDialogWorldScale()
	{
		NpcIconComponentView headView = this.HeadView;
		if (headView == null)
		{
			return;
		}
		headView.SetDialogWorldScale3D(this.Data.GetDialogWorldScale3D());
	}

	// Token: 0x06011232 RID: 70194 RVA: 0x004B4B82 File Offset: 0x004B2D82
	public bool IsDialogueTextActive()
	{
		NpcIconComponentView headView = this.HeadView;
		return headView != null && headView.GetDialogueActive();
	}

	// Token: 0x06011233 RID: 70195 RVA: 0x004B4B95 File Offset: 0x004B2D95
	public bool IsHeadIconActive()
	{
		NpcIconComponentView headView = this.HeadView;
		return headView != null && headView.GetHeadIconActive();
	}

	// Token: 0x06011234 RID: 70196 RVA: 0x004B4BA8 File Offset: 0x004B2DA8
	public bool IsHeadItemActive()
	{
		NpcIconComponentView headView = this.HeadView;
		return headView != null && headView.GetHeadItemState();
	}

	// Token: 0x06011235 RID: 70197 RVA: 0x004B4BBC File Offset: 0x004B2DBC
	private void SetTargetTracking(bool active)
	{
		ITrackData trackData = ModelBase<TrackModel>.Instance.IsTargetTracking(this.EntityPbDataId);
		if (trackData != null && this.QuestMarkOccupied)
		{
			ControllerBase<TrackController>.Instance.SetTrackMarkOccupied(ETrackSource.Quest, trackData.Id, active);
			this.QuestMarkOccupied = active;
		}
	}

	// Token: 0x06011236 RID: 70198 RVA: 0x004B4C03 File Offset: 0x004B2E03
	protected void TickDialogueText(float deltaTime)
	{
		if (this.RemoveMillSeconds < 0f)
		{
			return;
		}
		this.RemoveMillSeconds -= deltaTime;
		if (this.RemoveMillSeconds <= 0f)
		{
			this.HideDialogueText();
		}
	}

	// Token: 0x06011237 RID: 70199 RVA: 0x004B4C34 File Offset: 0x004B2E34
	public void Tick(float deltaTime, bool isForce = false)
	{
		if (!this.Data.CanTick(deltaTime))
		{
			return;
		}
		if (!isForce && !this.IsVisible)
		{
			return;
		}
		this.UpdateHeadInfoRotationAndScale();
		this.TickDialogueText(deltaTime);
	}

	// Token: 0x06011238 RID: 70200 RVA: 0x004B4C60 File Offset: 0x004B2E60
	private void UpdateHeadInfoRotationAndScale()
	{
		double num = Vector.DistSquared(ModelBase<CameraModel>.Instance.MainModel.CameraLocation, this.Data.GetSelfLocation());
		this.TickHeadInfo((float)num);
		this.UpdateCharacterIconRotation();
	}

	// Token: 0x06011239 RID: 70201 RVA: 0x004B4C9C File Offset: 0x004B2E9C
	private void UpdateCharacterIconRotation()
	{
		if (this.HeadView != null)
		{
			Rotator cameraRotator = ControllerBase<CameraController>.Instance.MainModel.CameraRotator;
			this.HeadView.UpdateRotation(cameraRotator.Yaw, cameraRotator.Pitch);
		}
	}

	// Token: 0x0601123A RID: 70202 RVA: 0x004B4CD8 File Offset: 0x004B2ED8
	private void TickHeadItem(float cameraDistanceSquare)
	{
		bool flag = this.Data.IsInHeadItemShowRange((double)cameraDistanceSquare, this.MaxShowRangeDisSquared, (double)ConfigBase<NpcIconConfig>.Instance.NpcIconHeadInfoLimitMinDistanceSquared);
		flag = (flag && !this.IsInteractionSpotVisible);
		this.SetHeadItemState(flag);
		this.TickQuestTrackCellState();
		if (this.RemoveMillSeconds > 0f && (this.DistanceSquare < (float)ConfigBase<NpcIconConfig>.Instance.NpcIconHeadInfoLimitMinDistanceSquared || (double)this.DistanceSquare > this.MaxShowRangeDisSquared))
		{
			this.HideDialogueText();
		}
		if (flag)
		{
			this.SetHeadWorldScale3D(cameraDistanceSquare);
		}
	}

	// Token: 0x0601123B RID: 70203 RVA: 0x004B4D60 File Offset: 0x004B2F60
	private void TickQuestTrackCellState()
	{
		if (this.IsInteractionSpotVisible)
		{
			this.SetQuestTrackCellState(true);
			return;
		}
		ITrackData trackData = ModelBase<TrackModel>.Instance.IsTargetTracking(this.EntityPbDataId);
		bool flag = MarkItemUtil.CanShowTrackMark(trackData);
		bool flag2 = trackData != null && trackData.TrackSource == ETrackSource.Quest;
		this.SetQuestTrackCellState(flag2);
		if (!flag2 && this.HeadView != null)
		{
			this.HeadView.ForceHideDialog = flag;
			this.HeadView.ForceHideRootItem = flag;
		}
	}

	// Token: 0x0601123C RID: 70204 RVA: 0x004B4DD4 File Offset: 0x004B2FD4
	private bool IsInHeadItemNameShowRange(float distance)
	{
		int npcIconHeadInfoNameLimitDistance = ConfigBase<NpcIconConfig>.Instance.GetNpcIconHeadInfoNameLimitDistance();
		return distance <= (float)(npcIconHeadInfoNameLimitDistance * npcIconHeadInfoNameLimitDistance);
	}

	// Token: 0x0601123D RID: 70205 RVA: 0x004B4DF8 File Offset: 0x004B2FF8
	private bool IsInPlayerInfoNameShowRange(float distance)
	{
		int playerInfoNameLimitDistance = ConfigBase<NpcIconConfig>.Instance.GetPlayerInfoNameLimitDistance();
		return distance <= (float)(playerInfoNameLimitDistance * playerInfoNameLimitDistance);
	}

	// Token: 0x0601123E RID: 70206 RVA: 0x004B4E1C File Offset: 0x004B301C
	private bool IsInPlayerInfoIconShowRange(float distance)
	{
		int playerInfoIconLimitDistance = ConfigBase<NpcIconConfig>.Instance.GetPlayerInfoIconLimitDistance();
		return distance < (float)(playerInfoIconLimitDistance * playerInfoIconLimitDistance);
	}

	// Token: 0x0601123F RID: 70207 RVA: 0x004B4E3C File Offset: 0x004B303C
	private void TickHeadItemName(float cameraDistanceSquare)
	{
		if (this.Data.IsShowPlayerInfo())
		{
			bool nameTextState = this.IsInPlayerInfoNameShowRange(cameraDistanceSquare);
			bool playerInfoIconState = this.IsInPlayerInfoIconShowRange(cameraDistanceSquare);
			this.SetNameTextState(nameTextState);
			this.SetPlayerInfoIconState(playerInfoIconState);
			this.SetHeadInfoNameState(true);
			return;
		}
		if (this.Data.IsShowNameInfo())
		{
			bool flag = this.IsInHeadItemNameShowRange(cameraDistanceSquare);
			bool headInfoNameState = this.GetHeadInfoNameState();
			if (flag != headInfoNameState)
			{
				if (flag)
				{
					if (!this.PendingShowHeadInfoName)
					{
						this.PendingShowHeadInfoName = true;
						Singleton<TickProcessSystem>.Instance.RegisterOnceTickProcess(ETickingGroup.TG_PrePhysics, false, delegate(float deltaTime)
						{
							if (this.PendingShowHeadInfoName)
							{
								this.PendingShowHeadInfoName = false;
								this.SetHeadInfoNameState(true);
							}
						});
						return;
					}
				}
				else
				{
					this.SetHeadInfoNameState(flag);
				}
			}
		}
	}

	// Token: 0x06011240 RID: 70208 RVA: 0x004B4ECF File Offset: 0x004B30CF
	private bool IsInHeadQuestShowRange(float distance)
	{
		return this.MaxShowQuestDisSquared == 0f || distance <= this.MaxShowQuestDisSquared * this.MaxShowQuestDisSquared;
	}

	// Token: 0x06011241 RID: 70209 RVA: 0x004B4EF3 File Offset: 0x004B30F3
	private bool IsInTrackEffectShowRange(float distance)
	{
		return this.MaxShowTrackEffectDisSquared == 0f || distance <= this.MaxShowTrackEffectDisSquared * this.MaxShowTrackEffectDisSquared;
	}

	// Token: 0x06011242 RID: 70210 RVA: 0x004B4F18 File Offset: 0x004B3118
	private void TickHeadQuestInfo(float cameraDistanceSquare)
	{
		if (this.Data.IsShowQuestInfo())
		{
			bool questInfoState = this.IsInHeadQuestShowRange(cameraDistanceSquare);
			this.SetQuestInfoState(questInfoState);
			bool questTrackEffectState = this.IsInTrackEffectShowRange(cameraDistanceSquare);
			this.SetQuestTrackEffectState(questTrackEffectState);
		}
	}

	// Token: 0x06011243 RID: 70211 RVA: 0x004B4F50 File Offset: 0x004B3150
	private void TickHeadInfo(float cameraDistanceSquare)
	{
		if (this.DistanceSquare == cameraDistanceSquare)
		{
			return;
		}
		this.DistanceSquare = cameraDistanceSquare;
		this.TickHeadItem(cameraDistanceSquare);
		this.TickHeadItemName(cameraDistanceSquare);
		this.TickHeadQuestInfo(cameraDistanceSquare);
	}

	// Token: 0x06011244 RID: 70212 RVA: 0x004B4F78 File Offset: 0x004B3178
	private void SetHeadWorldScale3D(float cameraDistance)
	{
		float headStateScaleValue = ConfigBase<NpcIconConfig>.Instance.GetHeadStateScaleValue(cameraDistance);
		NpcIconComponentView headView = this.HeadView;
		if (headView == null)
		{
			return;
		}
		headView.SetHeadWorldScale3D(headStateScaleValue);
	}

	// Token: 0x06011245 RID: 70213 RVA: 0x004B4FA2 File Offset: 0x004B31A2
	public void SetPlayerInfoIcon(string path)
	{
		this.IsPlayerInfoIconReady = false;
		NpcIconComponentView headView = this.HeadView;
		if (headView == null)
		{
			return;
		}
		headView.SetPlayerInfoIcon(path, delegate(bool result)
		{
			this.IsPlayerInfoIconReady = result;
		});
	}

	// Token: 0x06011246 RID: 70214 RVA: 0x004B4FC8 File Offset: 0x004B31C8
	public void SetPlayerInfoIconState(bool bState)
	{
		if (!this.IsPlayerInfoIconReady)
		{
			return;
		}
		NpcIconComponentView headView = this.HeadView;
		if (headView == null)
		{
			return;
		}
		headView.SetPlayerInfoItemState(bState);
	}

	// Token: 0x06011247 RID: 70215 RVA: 0x004B4FE4 File Offset: 0x004B31E4
	public void SetNameTextState(bool bState)
	{
		NpcIconComponentView headView = this.HeadView;
		if (headView == null)
		{
			return;
		}
		headView.SetNameTextItemState(bState);
	}

	// Token: 0x06011248 RID: 70216 RVA: 0x004B4FF8 File Offset: 0x004B31F8
	public void Destroy()
	{
		this.IsDestroy = true;
		bool flag = false;
		if (this.HeadView != null)
		{
			flag = true;
			Singleton<UiModel>.Instance.RemoveNpcIconViewUnit(this.HeadView);
			this.HeadView.Destroy(null);
			this.HeadView = null;
		}
		if (this.UiPoolActor != null)
		{
			AActor actor = this.UiPoolActor.Actor;
			if (actor != null)
			{
				actor.DetachRootComponentFromParent(true);
			}
			if (!flag)
			{
				Singleton<UiActorPool>.Instance.RecycleAsync(this.UiPoolActor, this.Path);
			}
			this.UiPoolActor = null;
			this.Data = null;
		}
		this.UnregisterTick();
	}

	// Token: 0x040086A0 RID: 34464
	private UiPoolActor UiPoolActor;

	// Token: 0x040086A1 RID: 34465
	[Nullable(1)]
	private string Path = "";

	// Token: 0x040086A2 RID: 34466
	protected NpcIconComponentView HeadView;

	// Token: 0x040086A3 RID: 34467
	private INpcIconFunction Data;

	// Token: 0x040086A4 RID: 34468
	private float RemoveMillSeconds = -1f;

	// Token: 0x040086A5 RID: 34469
	private double MaxShowRangeDisSquared;

	// Token: 0x040086A6 RID: 34470
	public float MaxShowQuestDisSquared;

	// Token: 0x040086A7 RID: 34471
	private readonly float MaxShowTrackEffectDisSquared;

	// Token: 0x040086A8 RID: 34472
	private UniTaskCompletionSource<bool> CustomPromise;

	// Token: 0x040086A9 RID: 34473
	private Action ReCreateHeadView;

	// Token: 0x040086AA RID: 34474
	private float DistanceSquare;

	// Token: 0x040086AB RID: 34475
	private bool PendingShowHeadInfoName;

	// Token: 0x040086AC RID: 34476
	private bool IsDestroy;

	// Token: 0x040086AD RID: 34477
	private uint? GameBudgetManagedTokenInternal;

	// Token: 0x040086AE RID: 34478
	private int EntityPbDataId;

	// Token: 0x040086AF RID: 34479
	private bool QuestMarkOccupied;

	// Token: 0x040086B0 RID: 34480
	private bool IsPlayerInfoIconReady;

	// Token: 0x040086B1 RID: 34481
	[Nullable(1)]
	private readonly Vector TmpVector = Vector.Create();

	// Token: 0x040086B2 RID: 34482
	private bool IsSelfVisibleInner;

	// Token: 0x040086B3 RID: 34483
	private bool IsNpcVisibleInner = true;

	// Token: 0x040086B4 RID: 34484
	private Action NpcIconCreateCallback;

	// Token: 0x040086B5 RID: 34485
	private bool IsInteractionSpotVisible;

	// Token: 0x040086B6 RID: 34486
	private GCHandle GameBudgetGCHandle;
}
