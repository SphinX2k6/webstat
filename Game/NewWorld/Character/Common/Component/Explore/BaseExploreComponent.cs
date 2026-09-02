using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Custom.Components;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Explore
{
	// Token: 0x02004950 RID: 18768
	[NullableContext(2)]
	[Nullable(0)]
	public class BaseExploreComponent : EntityComponent
	{
		// Token: 0x170083B6 RID: 33718
		// (get) Token: 0x0603110D RID: 200973 RVA: 0x00C332A8 File Offset: 0x00C314A8
		// (set) Token: 0x0603110E RID: 200974 RVA: 0x00C33318 File Offset: 0x00C31518
		public GrapplingHookPointComponent InteractingTarget
		{
			get
			{
				if (this.InteractingTargetInternal != null && !this.InteractingTargetInternal.Valid)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Character;
					ELogAuthor author = ELogAuthor.CK;
					string message = this.LogKey + "获取InteractingTarget时钩锁点实体已失效, 重置为undefined";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", base.Entity.Id);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					this.InteractingTargetInternal = null;
				}
				return this.InteractingTargetInternal;
			}
			set
			{
				GrapplingHookPointComponent interactingTargetInternal = this.InteractingTargetInternal;
				if (interactingTargetInternal != null && interactingTargetInternal.Valid && value != this.InteractingTargetInternal)
				{
					this.InteractingTargetInternal.ChangeHookPointState(EHookPointState.Normal);
				}
				this.InteractingTargetInternal = value;
				this.InteractingTargetEntityId = ((value != null) ? new int?(value.Entity.Id) : null);
			}
		}

		// Token: 0x170083B7 RID: 33719
		// (get) Token: 0x0603110F RID: 200975 RVA: 0x00C3337C File Offset: 0x00C3157C
		// (set) Token: 0x06031110 RID: 200976 RVA: 0x00C333EC File Offset: 0x00C315EC
		public GrapplingHookPointComponent FocusTarget
		{
			get
			{
				if (this.FocusTargetInternal != null && !this.FocusTargetInternal.Valid)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Character;
					ELogAuthor author = ELogAuthor.CK;
					string message = this.LogKey + "获取FocusTarget时钩锁点实体已失效, 重置为undefined";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", base.Entity.Id);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					this.FocusTargetInternal = null;
				}
				return this.FocusTargetInternal;
			}
			set
			{
				this.FocusTargetInternal = value;
			}
		}

		// Token: 0x170083B8 RID: 33720
		// (get) Token: 0x06031111 RID: 200977 RVA: 0x00C333F5 File Offset: 0x00C315F5
		// (set) Token: 0x06031112 RID: 200978 RVA: 0x00C333FD File Offset: 0x00C315FD
		public bool FocusTargetLegal
		{
			get
			{
				return this.FocusTargetLegalInternal;
			}
			set
			{
				this.FocusTargetLegalInternal = value;
			}
		}

		// Token: 0x170083B9 RID: 33721
		// (get) Token: 0x06031113 RID: 200979 RVA: 0x00C33406 File Offset: 0x00C31606
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public new static Type[] Dependencies
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				return new Type[]
				{
					typeof(BaseActorComponent),
					typeof(BaseSkillComponent),
					typeof(BaseTagComponent)
				};
			}
		}

		// Token: 0x06031114 RID: 200980 RVA: 0x00C33438 File Offset: 0x00C31638
		protected unsafe override bool OnStart()
		{
			this.ActorComponent = base.Entity.GetComponent<BaseActorComponent>();
			this.SkillComponent = base.Entity.GetComponent<BaseSkillComponent>();
			this.TagComponent = base.Entity.GetComponent<BaseTagComponent>();
			if (this.CheckDisableComponent())
			{
				base.Disable("CheckDisableComponent");
				return true;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = this.LogKey + "OnExploreComponentStart";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ClientEntityId", base.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PendingHighlightSkill", this.PendingHighlightSkill != null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return true;
		}

		// Token: 0x06031115 RID: 200981 RVA: 0x00C33509 File Offset: 0x00C31709
		protected virtual bool CheckDisableComponent()
		{
			return false;
		}

		// Token: 0x06031116 RID: 200982 RVA: 0x00C3350C File Offset: 0x00C3170C
		protected override bool OnEnd()
		{
			if (this.CheckDisableComponent())
			{
				return true;
			}
			HighlightExploreSkillLogic highlightLogic = this.HighlightLogic;
			if (highlightLogic != null)
			{
				highlightLogic.Dispose();
			}
			this.HighlightLogic = null;
			return true;
		}

		// Token: 0x06031117 RID: 200983 RVA: 0x00C33531 File Offset: 0x00C31731
		protected override void OnTick(float delta)
		{
			if (!this.ExploreComponentEnabled)
			{
				return;
			}
			this.OnExploreComponentTick(delta);
		}

		// Token: 0x06031118 RID: 200984 RVA: 0x00C33544 File Offset: 0x00C31744
		[NullableContext(1)]
		protected unsafe virtual bool OnExploreComponentEnable(string reason)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = this.LogKey + "OnExploreComponentEnable";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExploreComponentEnabled", this.ExploreComponentEnabled);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (this.ExploreComponentEnabled)
			{
				return false;
			}
			ModelBase<CharacterExploreModel>.Instance.RegisterExploreComponent(this);
			this.ExploreComponentEnabled = true;
			this.InitHighlightHandle();
			return true;
		}

		// Token: 0x06031119 RID: 200985 RVA: 0x00C33604 File Offset: 0x00C31804
		[NullableContext(1)]
		protected unsafe virtual bool OnExploreComponentDisable(string reason)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = this.LogKey + "OnExploreComponentDisable";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExploreComponentEnabled", this.ExploreComponentEnabled);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (!this.ExploreComponentEnabled)
			{
				return false;
			}
			GrapplingHookPointComponent interactingTarget = this.InteractingTarget;
			if (interactingTarget != null)
			{
				interactingTarget.ChangeHookPointState(EHookPointState.Normal);
			}
			ICompositeSkillSession activeCompositeSession = ModelBase<CharacterExploreModel>.Instance.CompositeExploreSkillSession.ActiveCompositeSession;
			if (activeCompositeSession != null && activeCompositeSession.EnterSent && !this.IsHookEndByInterrupt)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Character;
				ELogAuthor author2 = ELogAuthor.CK;
				string message2 = this.LogKey + "OnExploreComponentDisable: 复合技能流程中, 跳过SendHookEndRequest, 等待终止技能发送";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CompositeName", activeCompositeSession.Config.Name);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				this.SendHookEndRequest(this.InteractingTarget, null);
			}
			this.InteractingTarget = null;
			this.CancelLockTarget("OnExploreComponentDisable", true);
			this.ExploreComponentEnabled = false;
			return true;
		}

		// Token: 0x0603111A RID: 200986 RVA: 0x00C3374B File Offset: 0x00C3194B
		protected virtual void OnExploreComponentTick(float delta)
		{
		}

		// Token: 0x0603111B RID: 200987 RVA: 0x00C3374D File Offset: 0x00C3194D
		protected virtual void OnDetectedTargetChanged(GrapplingHookPointComponent prevTarget)
		{
		}

		// Token: 0x0603111C RID: 200988 RVA: 0x00C3374F File Offset: 0x00C3194F
		[NullableContext(1)]
		public virtual void ClearDetectedTarget(string reason)
		{
		}

		// Token: 0x0603111D RID: 200989 RVA: 0x00C33754 File Offset: 0x00C31954
		[NullableContext(1)]
		public unsafe bool ForceLockTarget([Nullable(2)] GrapplingHookPointComponent target, string reason)
		{
			if (target == null || !target.Valid)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.CK;
				string message = this.LogKey + "锁定目标失败, 钩锁点实体不合法";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", (target != null) ? new int?(target.EntityConfigId) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Reason", reason);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			if (target == this.InteractingTarget)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Character;
				ELogAuthor author2 = ELogAuthor.CK;
				string message2 = this.LogKey + "锁定目标失败, 锁定目标和当前正在交互的目标相同";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Character;
			ELogAuthor author3 = ELogAuthor.CK;
			string message3 = this.LogKey + "锁定目标";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("TargetEntityConfigId", target.EntityConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Reason", reason);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			this.IsLockingTarget = true;
			this.FocusTargetLegalExceptSkill = true;
			this.SetFocusTarget(target, true);
			return true;
		}

		// Token: 0x0603111E RID: 200990 RVA: 0x00C338AC File Offset: 0x00C31AAC
		[NullableContext(1)]
		public void CancelLockTarget(string reason, bool resetFocusTarget)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = this.LogKey + "取消目标锁定";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.IsLockingTarget = false;
			if (resetFocusTarget)
			{
				this.SetFocusTarget(null, true);
			}
		}

		// Token: 0x0603111F RID: 200991 RVA: 0x00C33900 File Offset: 0x00C31B00
		public unsafe void SetFocusTarget(GrapplingHookPointComponent target, bool targetLegal = true)
		{
			GrapplingHookPointComponent focusTarget = this.FocusTarget;
			this.FocusTargetLegal = (target != null && target.Valid && targetLegal);
			this.FocusTargetInternal = target;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = this.LogKey + "设置当前焦距目标";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TargetEntityConfigId", (target != null) ? new int?(target.EntityConfigId) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TargetLegal", target != null && target.Valid && targetLegal);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Type", (target != null && target.Valid) ? target.GetHookInteractType() : "None");
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			Singleton<EventSystem>.Instance.Emit(EEventName.ExploreComponentTargetChanged);
			this.OnDetectedTargetChanged(focusTarget);
		}

		// Token: 0x06031120 RID: 200992 RVA: 0x00C33A08 File Offset: 0x00C31C08
		public global::Vector GetInteractingTargetLocation()
		{
			BaseActorComponent actorComponent = this.ActorComponent;
			if (actorComponent == null || !actorComponent.IsAutonomousProxy)
			{
				GrapplingHookPointComponent simulateInteractingTarget = this.SimulateInteractingTarget;
				return ((simulateInteractingTarget != null) ? simulateInteractingTarget.HookLocation : null) ?? this.SimulateInteractingTargetLocation;
			}
			GrapplingHookPointComponent interactingTarget = this.InteractingTarget;
			if (interactingTarget == null)
			{
				return null;
			}
			return interactingTarget.HookLocation;
		}

		// Token: 0x06031121 RID: 200993 RVA: 0x00C33A5C File Offset: 0x00C31C5C
		public void InitHighlightHandle()
		{
			if (this.HighlightLogic != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.CK;
				string message = this.LogKey + "高亮模块已经完成初始化";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ClientEntityId", base.Entity.Id);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.HighlightLogic = new HighlightExploreSkillLogic();
			this.HighlightLogic.Init(this);
			Action pendingHighlightSkill = this.PendingHighlightSkill;
			if (pendingHighlightSkill != null)
			{
				pendingHighlightSkill();
			}
			this.PendingHighlightSkill = null;
		}

		// Token: 0x06031122 RID: 200994 RVA: 0x00C33AE4 File Offset: 0x00C31CE4
		public unsafe void ShowHighlightExploreSkill(int exploreToolId, float duration, bool? needRevertSkill, string tagName = null, int? itemId = null, bool? needTips = null, bool? autoHideAfterUseExploreSkill = null)
		{
			if (this.HighlightLogic == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.CK;
				string message = this.LogKey + "尝试高亮探索技能时, 组件还未初始化完成, 缓存高亮操作, 考虑修改配置";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ClientEntityId", base.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExploreToolId", exploreToolId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Duration", duration);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				this.PendingHighlightSkill = delegate()
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Character;
					ELogAuthor author2 = ELogAuthor.CK;
					string message2 = this.LogKey + "执行缓存的高亮操作";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("ClientEntityId", this.Entity.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ExploreToolId", exploreToolId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Duration", duration);
					instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
					this.ShowHighlightExploreSkill(exploreToolId, duration, needRevertSkill, tagName, itemId, needTips, autoHideAfterUseExploreSkill);
				};
				return;
			}
			this.HighlightLogic.ShowHighlightExploreSkill(exploreToolId, duration, new bool?(needRevertSkill.GetValueOrDefault()), tagName, itemId, new bool?(needTips.GetValueOrDefault()), autoHideAfterUseExploreSkill);
		}

		// Token: 0x06031123 RID: 200995 RVA: 0x00C33C34 File Offset: 0x00C31E34
		public unsafe void HideHighlightExploreSkill()
		{
			if (this.HighlightLogic == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.CK;
				string message = this.LogKey + "尝试取消探索技能高亮时, 组件还未初始化完成, 考虑修改配置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ClientEntityId", base.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PendingHighlightSkill", this.PendingHighlightSkill != null);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.PendingHighlightSkill = null;
				return;
			}
			this.HighlightLogic.HideHighlightExploreSkill();
		}

		// Token: 0x06031124 RID: 200996 RVA: 0x00C33CDC File Offset: 0x00C31EDC
		public int? GetHighlightSkillId()
		{
			HighlightExploreSkillLogic highlightLogic = this.HighlightLogic;
			if (highlightLogic == null)
			{
				return null;
			}
			return new int?(highlightLogic.GetHighlightSkillId());
		}

		// Token: 0x06031125 RID: 200997 RVA: 0x00C33D08 File Offset: 0x00C31F08
		public int? GetHighlightExploreToolId()
		{
			HighlightExploreSkillLogic highlightLogic = this.HighlightLogic;
			if (highlightLogic == null)
			{
				return null;
			}
			return new int?(highlightLogic.GetHighlightExploreToolId());
		}

		// Token: 0x06031126 RID: 200998 RVA: 0x00C33D34 File Offset: 0x00C31F34
		[NullableContext(1)]
		public void HandleSkillIconLogic(bool isAdd, string reason)
		{
			GrapplingHookPointComponent focusTarget = this.FocusTarget;
			int? num = (focusTarget != null) ? focusTarget.GetTagId() : null;
			GrapplingHookPointComponent focusTarget2 = this.FocusTarget;
			int? num2 = (focusTarget2 != null) ? new int?(focusTarget2.GetHighlightTagId()) : null;
			if (this.LevelEventLightingSkill)
			{
				this.CurrentIconTagId = num;
				this.CurrentIconHighlightTagId = num2;
				return;
			}
			this.UpdateHookIconTag(isAdd, num, reason);
			this.UpdateHookIconHighlightTag(isAdd, num2);
		}

		// Token: 0x06031127 RID: 200999 RVA: 0x00C33DA4 File Offset: 0x00C31FA4
		public virtual bool CheckAllowLevelEventHighlightSkill()
		{
			return true;
		}

		// Token: 0x06031128 RID: 201000 RVA: 0x00C33DA7 File Offset: 0x00C31FA7
		public virtual void OnLevelEventHighlightSkillUpdate(bool enabled)
		{
		}

		// Token: 0x06031129 RID: 201001 RVA: 0x00C33DAC File Offset: 0x00C31FAC
		[NullableContext(1)]
		public unsafe void UpdateHookIconTag(bool add, int? tagId, string reason)
		{
			int? currentIconTagId = this.CurrentIconTagId;
			if (add)
			{
				if (currentIconTagId != null)
				{
					int? num = currentIconTagId;
					int num2 = 0;
					if (!(num.GetValueOrDefault() == num2 & num != null))
					{
						num = tagId;
						int? num3 = currentIconTagId;
						if (!(num.GetValueOrDefault() == num3.GetValueOrDefault() & num != null == (num3 != null)) && this.TagComponent.HasTag(currentIconTagId.Value))
						{
							this.TagComponent.RemoveTag(new int?(currentIconTagId.Value));
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.Character;
							ELogAuthor author = ELogAuthor.CK;
							string message = this.LogKey + "添加定点钩索可用标签时删除旧的定点钩索标签";
							<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("OldTag", GameplayTagUtils.GetNameByTagId(currentIconTagId.Value));
							instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
						}
					}
				}
				if (tagId != null)
				{
					int? num3 = tagId;
					int num2 = 0;
					if (!(num3.GetValueOrDefault() == num2 & num3 != null) && !this.TagComponent.HasTag(tagId.Value))
					{
						this.TagComponent.AddTag(new int?(tagId.Value));
						this.CurrentIconTagId = tagId;
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Character;
						ELogAuthor author2 = ELogAuthor.CK;
						string message2 = this.LogKey + "添加定点钩索可用标签";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Reason", reason);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Tag", GameplayTagUtils.GetNameByTagId(tagId.Value));
						instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
						return;
					}
				}
			}
			else if (this.CurrentIconTagId != null)
			{
				int? num3 = this.CurrentIconTagId;
				int num2 = 0;
				if (!(num3.GetValueOrDefault() == num2 & num3 != null) && this.TagComponent.HasTag(this.CurrentIconTagId.Value))
				{
					this.TagComponent.RemoveTag(new int?(this.CurrentIconTagId.Value));
					int value = this.CurrentIconTagId.Value;
					this.CurrentIconTagId = null;
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Character;
					ELogAuthor author3 = ELogAuthor.CK;
					string message3 = this.LogKey + "删除定点钩索可用标签";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Reason", reason);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("OldTag", GameplayTagUtils.GetNameByTagId(value));
					instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
				}
			}
		}

		// Token: 0x0603112A RID: 201002 RVA: 0x00C340DC File Offset: 0x00C322DC
		public unsafe void UpdateHookIconHighlightTag(bool add, int? tagId)
		{
			int? currentIconHighlightTagId = this.CurrentIconHighlightTagId;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = this.LogKey + "更新按钮高亮Tag";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Add", add);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("CurrentIconHighlightTagId", this.CurrentIconHighlightTagId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("TryAddTagId", tagId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("HasTag", tagId != null && this.TagComponent.HasTag(tagId.Value));
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			if ((currentIconHighlightTagId ?? 1) == 0)
			{
				return;
			}
			if (add)
			{
				if (currentIconHighlightTagId != null && currentIconHighlightTagId.GetValueOrDefault() != 0)
				{
					int? num = tagId;
					int? num2 = currentIconHighlightTagId;
					if (!(num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null)) && this.TagComponent.HasTag(currentIconHighlightTagId.Value))
					{
						this.TagComponent.RemoveTag(new int?(currentIconHighlightTagId.Value));
					}
				}
				if (tagId != null && tagId.GetValueOrDefault() != 0 && !this.TagComponent.HasTag(tagId.Value))
				{
					this.TagComponent.AddTag(new int?(tagId.Value));
					this.CurrentIconHighlightTagId = tagId;
					return;
				}
			}
			else
			{
				int? num2 = this.CurrentIconHighlightTagId;
				if (num2 != null && num2.GetValueOrDefault() != 0 && this.TagComponent.HasTag(this.CurrentIconHighlightTagId.Value))
				{
					this.TagComponent.RemoveTag(new int?(this.CurrentIconHighlightTagId.Value));
					this.CurrentIconHighlightTagId = null;
				}
			}
		}

		// Token: 0x0603112B RID: 201003 RVA: 0x00C34300 File Offset: 0x00C32500
		protected void SendHookMovePush()
		{
			GrapplingHookPointComponent interactingTarget = this.InteractingTarget;
			if (interactingTarget != null && interactingTarget.Valid)
			{
				BaseActorComponent actorComponent = this.ActorComponent;
				if (actorComponent != null && actorComponent.IsAutonomousProxy)
				{
					RoleSceneInteractController.SendHookMovePush(base.Entity, interactingTarget);
					return;
				}
			}
		}

		// Token: 0x0603112C RID: 201004 RVA: 0x00C3434C File Offset: 0x00C3254C
		protected unsafe void SendHookTargetRequest(GrapplingHookPointComponent target, [Nullable(1)] Action onFailure, string compositeSessionName = null)
		{
			GrapplingHookPointComponent target2 = target;
			if (target2 != null && target2.Valid)
			{
				BaseActorComponent actorComponent = this.ActorComponent;
				if (actorComponent != null && actorComponent.IsAutonomousProxy)
				{
					HookLockPointRequest hookLockPointRequest = HookLockPointRequest.Create();
					hookLockPointRequest.EntityId = target.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Character;
					ELogAuthor author = ELogAuthor.CK;
					string message = this.LogKey + "SendHookTargetRequest";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", target.EntityConfigId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CompositeSession", compositeSessionName ?? "None");
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					FixHookClientLevelEventExecutor.ExecuteHookActions(FixHookClientLevelEventExecutor.EHookPointStage.ClientHook, target);
					Singleton<Net>.Instance.Call<HookLockPointResponse>(ERequestMessageId.HookLockPointRequest, hookLockPointRequest, delegate(HookLockPointResponse response, Net.CallbackStatus _)
					{
						ErrorCode? errorCode = (response != null) ? new ErrorCode?(response.ErrorCode) : null;
						if (errorCode != null)
						{
							ErrorCode valueOrDefault = errorCode.GetValueOrDefault();
							if (valueOrDefault <= ErrorCode.ErrSceneEntityNotExist)
							{
								if (valueOrDefault == ErrorCode.Success)
								{
									goto IL_17F;
								}
								if (valueOrDefault == ErrorCode.ErrSceneEntityNotExist)
								{
									Log instance2 = Singleton<Log>.Instance;
									ELogModule module2 = ELogModule.Character;
									ELogAuthor author2 = ELogAuthor.CK;
									string message2 = "SendHookTargetRequest错误, 钩锁点不存在";
									<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
									*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityConfigId", target.EntityConfigId);
									*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ServerEntityId", target.ServerEntityId);
									instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
									goto IL_17F;
								}
							}
							else if (valueOrDefault == ErrorCode.HookLockPointLocked || valueOrDefault == ErrorCode.HookLockPointConditionNotMet)
							{
								goto IL_17F;
							}
						}
						Log instance3 = Singleton<Log>.Instance;
						ELogModule module3 = ELogModule.Character;
						ELogAuthor author3 = ELogAuthor.CK;
						string message3 = "SendHookTargetRequest错误";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("EntityConfigId", target.EntityConfigId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("ServerEntityId", target.ServerEntityId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("ErrorCode", (response != null) ? new ErrorCode?(response.ErrorCode) : null);
						instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
						IL_17F:
						if (response == null || response.ErrorCode > ErrorCode.Success)
						{
							Action onFailure2 = onFailure;
							if (onFailure2 == null)
							{
								return;
							}
							onFailure2();
						}
					}, 0);
					return;
				}
			}
		}

		// Token: 0x0603112D RID: 201005 RVA: 0x00C3445C File Offset: 0x00C3265C
		protected unsafe void SendHookEndRequest(GrapplingHookPointComponent target, string compositeSessionName = null)
		{
			if (target != null && target.Valid)
			{
				BaseActorComponent actorComponent = this.ActorComponent;
				if (actorComponent != null && actorComponent.IsAutonomousProxy)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Character;
					ELogAuthor author = ELogAuthor.CK;
					string message = this.LogKey + "SendHookEndRequest";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", target.EntityConfigId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CompositeSession", compositeSessionName ?? "None");
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					long creatureDataId = target.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
					HookLockPointExitRequest hookLockPointExitRequest = HookLockPointExitRequest.Create();
					hookLockPointExitRequest.EntityId = creatureDataId;
					hookLockPointExitRequest.HookLockPointExitWay = (this.IsHookEndByInterrupt ? HookLockPointExitWay.Midway : HookLockPointExitWay.Endpoint);
					FixHookClientLevelEventExecutor.ExecuteHookActions(this.IsHookEndByInterrupt ? FixHookClientLevelEventExecutor.EHookPointStage.ClientMidway : FixHookClientLevelEventExecutor.EHookPointStage.ClientEndpoint, target);
					Singleton<Net>.Instance.Call<HookLockPointExitResponse>(ERequestMessageId.HookLockPointExitRequest, hookLockPointExitRequest, null, 0);
					if (target.WillBeDestroyedAfterHook)
					{
						HookLockPointFinishRequest hookLockPointFinishRequest = HookLockPointFinishRequest.Create();
						hookLockPointFinishRequest.EntityId = creatureDataId;
						Singleton<Net>.Instance.Call<HookLockPointFinishResponse>(ERequestMessageId.HookLockPointFinishRequest, hookLockPointFinishRequest, null, 0);
						return;
					}
					if (target.WillBeHideAfterHook)
					{
						ControllerBase<CreatureController>.Instance.SetEntityEnable(target.Entity, false, this.LogKey + "SendHookEndRequest", true);
					}
					return;
				}
			}
		}

		// Token: 0x0603112E RID: 201006 RVA: 0x00C345A9 File Offset: 0x00C327A9
		public void SetIsHookEndByInterruptProxy(bool isHookEndByInterrupt)
		{
			this.IsHookEndByInterrupt = isHookEndByInterrupt;
		}

		// Token: 0x0603112F RID: 201007 RVA: 0x00C345B4 File Offset: 0x00C327B4
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			BaseExploreComponent baseExploreComponent = (BaseExploreComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComponent"))
			{
				if (baseExploreComponent.ActorComponent == null)
				{
					this.ActorComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComponent), "ActorComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SkillComponent"))
			{
				if (baseExploreComponent.SkillComponent == null)
				{
					this.SkillComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseSkillComponent>(this.SkillComponent), "SkillComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TagComponent"))
			{
				if (baseExploreComponent.TagComponent == null)
				{
					this.TagComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("HighlightLogic"))
			{
				if (baseExploreComponent.HighlightLogic == null)
				{
					this.HighlightLogic = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<HighlightExploreSkillLogic>(this.HighlightLogic), "HighlightLogic"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CurrentIconTagId"))
			{
				this.CurrentIconTagId = baseExploreComponent.CurrentIconTagId;
			}
			if (base.CanResetComponentProperty("CurrentIconHighlightTagId"))
			{
				this.CurrentIconHighlightTagId = baseExploreComponent.CurrentIconHighlightTagId;
			}
			if (base.CanResetComponentProperty("LevelEventLightingSkill"))
			{
				this.LevelEventLightingSkill = baseExploreComponent.LevelEventLightingSkill;
			}
			if (base.CanResetComponentProperty("InteractingTargetInternal"))
			{
				if (baseExploreComponent.InteractingTargetInternal == null)
				{
					this.InteractingTargetInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<GrapplingHookPointComponent>(this.InteractingTargetInternal), "InteractingTargetInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("InteractingTargetEntityId"))
			{
				this.InteractingTargetEntityId = baseExploreComponent.InteractingTargetEntityId;
			}
			if (base.CanResetComponentProperty("FocusTargetInternal"))
			{
				if (baseExploreComponent.FocusTargetInternal == null)
				{
					this.FocusTargetInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<GrapplingHookPointComponent>(this.FocusTargetInternal), "FocusTargetInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FocusTargetLegalExceptSkill"))
			{
				this.FocusTargetLegalExceptSkill = baseExploreComponent.FocusTargetLegalExceptSkill;
			}
			if (base.CanResetComponentProperty("FocusTargetLegalInternal"))
			{
				this.FocusTargetLegalInternal = baseExploreComponent.FocusTargetLegalInternal;
			}
			if (base.CanResetComponentProperty("SimulateInteractingTarget"))
			{
				if (baseExploreComponent.SimulateInteractingTarget == null)
				{
					this.SimulateInteractingTarget = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<GrapplingHookPointComponent>(this.SimulateInteractingTarget), "SimulateInteractingTarget"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SimulateInteractingTargetLocation"))
			{
				if (baseExploreComponent.SimulateInteractingTargetLocation == null)
				{
					this.SimulateInteractingTargetLocation = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.SimulateInteractingTargetLocation), "SimulateInteractingTargetLocation"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SyncEnabled"))
			{
				this.SyncEnabled = baseExploreComponent.SyncEnabled;
			}
			if (base.CanResetComponentProperty("IsHookEndByInterrupt"))
			{
				this.IsHookEndByInterrupt = baseExploreComponent.IsHookEndByInterrupt;
			}
			if (base.CanResetComponentProperty("LogKey"))
			{
				this.LogKey = baseExploreComponent.LogKey;
			}
			if (base.CanResetComponentProperty("ExploreComponentEnabled"))
			{
				this.ExploreComponentEnabled = baseExploreComponent.ExploreComponentEnabled;
			}
			if (base.CanResetComponentProperty("PendingHighlightSkill"))
			{
				if (baseExploreComponent.PendingHighlightSkill == null)
				{
					this.PendingHighlightSkill = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Action>(this.PendingHighlightSkill), "PendingHighlightSkill"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsLockingTarget"))
			{
				this.IsLockingTarget = baseExploreComponent.IsLockingTarget;
			}
			return true;
		}

		// Token: 0x0401C3F1 RID: 115697
		public BaseActorComponent ActorComponent;

		// Token: 0x0401C3F2 RID: 115698
		protected BaseSkillComponent SkillComponent;

		// Token: 0x0401C3F3 RID: 115699
		public BaseTagComponent TagComponent;

		// Token: 0x0401C3F4 RID: 115700
		protected HighlightExploreSkillLogic HighlightLogic;

		// Token: 0x0401C3F5 RID: 115701
		protected int? CurrentIconTagId;

		// Token: 0x0401C3F6 RID: 115702
		protected int? CurrentIconHighlightTagId;

		// Token: 0x0401C3F7 RID: 115703
		protected bool LevelEventLightingSkill;

		// Token: 0x0401C3F8 RID: 115704
		private GrapplingHookPointComponent InteractingTargetInternal;

		// Token: 0x0401C3F9 RID: 115705
		protected int? InteractingTargetEntityId;

		// Token: 0x0401C3FA RID: 115706
		protected GrapplingHookPointComponent FocusTargetInternal;

		// Token: 0x0401C3FB RID: 115707
		public bool FocusTargetLegalExceptSkill;

		// Token: 0x0401C3FC RID: 115708
		protected bool FocusTargetLegalInternal;

		// Token: 0x0401C3FD RID: 115709
		public GrapplingHookPointComponent SimulateInteractingTarget;

		// Token: 0x0401C3FE RID: 115710
		public global::Vector SimulateInteractingTargetLocation;

		// Token: 0x0401C3FF RID: 115711
		public bool SyncEnabled = true;

		// Token: 0x0401C400 RID: 115712
		protected bool IsHookEndByInterrupt;

		// Token: 0x0401C401 RID: 115713
		[Nullable(1)]
		public string LogKey = "";

		// Token: 0x0401C402 RID: 115714
		protected bool ExploreComponentEnabled;

		// Token: 0x0401C403 RID: 115715
		protected Action PendingHighlightSkill;

		// Token: 0x0401C404 RID: 115716
		public bool IsLockingTarget;
	}
}
