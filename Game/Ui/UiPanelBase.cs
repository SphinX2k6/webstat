using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Ui.Base;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049AC RID: 18860
	[NullableContext(2)]
	[Nullable(0)]
	public class UiPanelBase : ComponentAction
	{
		// Token: 0x17008405 RID: 33797
		// (get) Token: 0x060313DB RID: 201691 RVA: 0x00C42B29 File Offset: 0x00C40D29
		// (set) Token: 0x060313DC RID: 201692 RVA: 0x00C42B31 File Offset: 0x00C40D31
		public bool SkipDestroyActor { get; set; }

		// Token: 0x060313DD RID: 201693 RVA: 0x00C42B3C File Offset: 0x00C40D3C
		public UiPanelBase()
		{
			this.MemoryTag = base.GetType().Name;
		}

		// Token: 0x060313DE RID: 201694 RVA: 0x00C42BD9 File Offset: 0x00C40DD9
		protected virtual void OnRegisterComponent()
		{
		}

		// Token: 0x060313DF RID: 201695 RVA: 0x00C42BDB File Offset: 0x00C40DDB
		protected virtual void OnBeforeCreate()
		{
		}

		// Token: 0x060313E0 RID: 201696 RVA: 0x00C42BDD File Offset: 0x00C40DDD
		protected virtual UniTask OnCreateAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x060313E1 RID: 201697 RVA: 0x00C42BE4 File Offset: 0x00C40DE4
		protected virtual UniTask OnBeforeStartAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x060313E2 RID: 201698 RVA: 0x00C42BEB File Offset: 0x00C40DEB
		protected virtual void OnStart()
		{
		}

		// Token: 0x060313E3 RID: 201699 RVA: 0x00C42BED File Offset: 0x00C40DED
		protected virtual void OnBeforeShow()
		{
		}

		// Token: 0x060313E4 RID: 201700 RVA: 0x00C42BEF File Offset: 0x00C40DEF
		protected virtual void OnAfterShow()
		{
		}

		// Token: 0x060313E5 RID: 201701 RVA: 0x00C42BF1 File Offset: 0x00C40DF1
		protected virtual UniTask OnBeforeHideAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x060313E6 RID: 201702 RVA: 0x00C42BF8 File Offset: 0x00C40DF8
		protected virtual void OnBeforeHide()
		{
		}

		// Token: 0x060313E7 RID: 201703 RVA: 0x00C42BFA File Offset: 0x00C40DFA
		protected virtual void OnAfterHide()
		{
		}

		// Token: 0x060313E8 RID: 201704 RVA: 0x00C42BFC File Offset: 0x00C40DFC
		protected virtual void OnBeforeDestroy()
		{
		}

		// Token: 0x060313E9 RID: 201705 RVA: 0x00C42BFE File Offset: 0x00C40DFE
		protected virtual void OnAfterDestroy()
		{
		}

		// Token: 0x060313EA RID: 201706 RVA: 0x00C42C00 File Offset: 0x00C40E00
		protected virtual void OnAutoDestroy()
		{
		}

		// Token: 0x060313EB RID: 201707 RVA: 0x00C42C02 File Offset: 0x00C40E02
		protected virtual void OnBeforeCreateImplement()
		{
		}

		// Token: 0x060313EC RID: 201708 RVA: 0x00C42C04 File Offset: 0x00C40E04
		protected virtual UniTask OnCreateAsyncImplementImplement()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x060313ED RID: 201709 RVA: 0x00C42C0B File Offset: 0x00C40E0B
		protected virtual void OnAfterCreateImplement()
		{
		}

		// Token: 0x060313EE RID: 201710 RVA: 0x00C42C0D File Offset: 0x00C40E0D
		protected virtual void OnStartImplement()
		{
		}

		// Token: 0x060313EF RID: 201711 RVA: 0x00C42C0F File Offset: 0x00C40E0F
		protected virtual UniTask OnBeforeShowAsyncImplement()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x060313F0 RID: 201712 RVA: 0x00C42C16 File Offset: 0x00C40E16
		protected virtual void OnBeforeShowImplement()
		{
		}

		// Token: 0x060313F1 RID: 201713 RVA: 0x00C42C18 File Offset: 0x00C40E18
		protected virtual void OnAfterShowImplement()
		{
		}

		// Token: 0x060313F2 RID: 201714 RVA: 0x00C42C1A File Offset: 0x00C40E1A
		protected virtual UniTask OnShowAsyncImplementImplement()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x060313F3 RID: 201715 RVA: 0x00C42C21 File Offset: 0x00C40E21
		protected virtual UniTask OnHideAsyncImplementImplement()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x060313F4 RID: 201716 RVA: 0x00C42C28 File Offset: 0x00C40E28
		protected virtual UniTask OnDestroyAsyncImplementImplement()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x060313F5 RID: 201717 RVA: 0x00C42C2F File Offset: 0x00C40E2F
		protected virtual void OnBeforeHideImplement()
		{
		}

		// Token: 0x060313F6 RID: 201718 RVA: 0x00C42C31 File Offset: 0x00C40E31
		protected virtual void OnAfterHideImplement()
		{
		}

		// Token: 0x060313F7 RID: 201719 RVA: 0x00C42C33 File Offset: 0x00C40E33
		protected virtual void OnBeforeDestroyImplement()
		{
		}

		// Token: 0x060313F8 RID: 201720 RVA: 0x00C42C35 File Offset: 0x00C40E35
		protected virtual void OnAfterDestroyImplement()
		{
		}

		// Token: 0x060313F9 RID: 201721 RVA: 0x00C42C38 File Offset: 0x00C40E38
		[NullableContext(0)]
		protected override UniTask<bool> OnCreateAsyncImplement()
		{
			UiPanelBase.<OnCreateAsyncImplement>d__51 <OnCreateAsyncImplement>d__;
			<OnCreateAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnCreateAsyncImplement>d__.<>4__this = this;
			<OnCreateAsyncImplement>d__.<>1__state = -1;
			<OnCreateAsyncImplement>d__.<>t__builder.Start<UiPanelBase.<OnCreateAsyncImplement>d__51>(ref <OnCreateAsyncImplement>d__);
			return <OnCreateAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x060313FA RID: 201722 RVA: 0x00C42C7C File Offset: 0x00C40E7C
		protected override UniTask OnStartAsyncImplement()
		{
			UiPanelBase.<OnStartAsyncImplement>d__52 <OnStartAsyncImplement>d__;
			<OnStartAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnStartAsyncImplement>d__.<>4__this = this;
			<OnStartAsyncImplement>d__.<>1__state = -1;
			<OnStartAsyncImplement>d__.<>t__builder.Start<UiPanelBase.<OnStartAsyncImplement>d__52>(ref <OnStartAsyncImplement>d__);
			return <OnStartAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x060313FB RID: 201723 RVA: 0x00C42CC0 File Offset: 0x00C40EC0
		protected override void OnStartImplementCompatible()
		{
			this.OnStartImplement();
			this.OnStart();
			foreach (UiBehaviorBaseProxy uiBehaviorBaseProxy in this.UiBehaviorProxies)
			{
				uiBehaviorBaseProxy.StartCompatible();
			}
			foreach (UiPanelBase uiPanelBase in this.Children)
			{
				uiPanelBase.StartCompatible();
			}
		}

		// Token: 0x060313FC RID: 201724 RVA: 0x00C42D5C File Offset: 0x00C40F5C
		protected override UniTask OnShowAsyncImplement()
		{
			UiPanelBase.<OnShowAsyncImplement>d__54 <OnShowAsyncImplement>d__;
			<OnShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplement>d__.<>4__this = this;
			<OnShowAsyncImplement>d__.<>1__state = -1;
			<OnShowAsyncImplement>d__.<>t__builder.Start<UiPanelBase.<OnShowAsyncImplement>d__54>(ref <OnShowAsyncImplement>d__);
			return <OnShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x060313FD RID: 201725 RVA: 0x00C42D9F File Offset: 0x00C40F9F
		protected virtual void OnShowAsyncImplementImplementCompatible()
		{
		}

		// Token: 0x060313FE RID: 201726 RVA: 0x00C42DA4 File Offset: 0x00C40FA4
		protected override void OnShowImplementCompatible()
		{
			this.OnBeforeShowImplement();
			this.OnBeforeShow();
			this.SetUiActive(true);
			this.OnShowAsyncImplementImplementCompatible();
			foreach (UiBehaviorBaseProxy uiBehaviorBaseProxy in this.UiBehaviorProxies)
			{
				uiBehaviorBaseProxy.ShowCompatible();
			}
			foreach (UiPanelBase uiPanelBase in this.Children)
			{
				uiPanelBase.ShowCompatible();
			}
			this.OnAfterShowImplement();
			this.OnAfterShow();
		}

		// Token: 0x060313FF RID: 201727 RVA: 0x00C42E58 File Offset: 0x00C41058
		protected override UniTask OnHideAsyncImplement()
		{
			UiPanelBase.<OnHideAsyncImplement>d__57 <OnHideAsyncImplement>d__;
			<OnHideAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplement>d__.<>4__this = this;
			<OnHideAsyncImplement>d__.<>1__state = -1;
			<OnHideAsyncImplement>d__.<>t__builder.Start<UiPanelBase.<OnHideAsyncImplement>d__57>(ref <OnHideAsyncImplement>d__);
			return <OnHideAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06031400 RID: 201728 RVA: 0x00C42E9B File Offset: 0x00C4109B
		protected virtual void OnHideAsyncImplementImplementCompatible()
		{
		}

		// Token: 0x06031401 RID: 201729 RVA: 0x00C42EA0 File Offset: 0x00C410A0
		protected override void OnHideImplementCompatible()
		{
			this.OnBeforeHide();
			this.OnBeforeHideImplement();
			foreach (UiBehaviorBaseProxy uiBehaviorBaseProxy in this.UiBehaviorProxies)
			{
				uiBehaviorBaseProxy.HideCompatible();
			}
			foreach (UiPanelBase uiPanelBase in this.Children)
			{
				uiPanelBase.HideCompatible();
			}
			this.OnHideAsyncImplementImplementCompatible();
			this.SetUiActive(false);
			this.OnAfterHide();
			this.OnAfterHideImplement();
		}

		// Token: 0x06031402 RID: 201730 RVA: 0x00C42F54 File Offset: 0x00C41154
		protected override UniTask OnDestroyAsyncImplement()
		{
			UiPanelBase.<OnDestroyAsyncImplement>d__60 <OnDestroyAsyncImplement>d__;
			<OnDestroyAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnDestroyAsyncImplement>d__.<>4__this = this;
			<OnDestroyAsyncImplement>d__.<>1__state = -1;
			<OnDestroyAsyncImplement>d__.<>t__builder.Start<UiPanelBase.<OnDestroyAsyncImplement>d__60>(ref <OnDestroyAsyncImplement>d__);
			return <OnDestroyAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06031403 RID: 201731 RVA: 0x00C42F97 File Offset: 0x00C41197
		protected virtual void OnDestroyAsyncImplementImplementCompatible()
		{
		}

		// Token: 0x06031404 RID: 201732 RVA: 0x00C42F9C File Offset: 0x00C4119C
		protected override void OnDestroyImplementCompatible()
		{
			this.CancelAllAsyncTask();
			this.OnBeforeDestroy();
			this.OnBeforeDestroyImplement();
			foreach (UiBehaviorBaseProxy uiBehaviorBaseProxy in this.UiBehaviorProxies)
			{
				uiBehaviorBaseProxy.DestroyCompatible();
			}
			foreach (UiPanelBase uiPanelBase in new List<UiPanelBase>(this.Children))
			{
				uiPanelBase.DestroyCompatible();
			}
			this.OnDestroyAsyncImplementImplementCompatible();
			this.DestroyPrivate();
			this.OnAfterDestroy();
			this.OnAfterDestroyImplement();
		}

		// Token: 0x06031405 RID: 201733 RVA: 0x00C4305C File Offset: 0x00C4125C
		[NullableContext(1)]
		public void SetRootActorLoadInfoByPath(string actorPath, [Nullable(2)] UUIItem parentItem = null, bool usePool = false, bool isPermanent = false)
		{
			this._actorPath = actorPath;
			this.ParentUiItem = parentItem;
			this.UsePool = usePool;
			this._isPermanent = isPermanent;
		}

		// Token: 0x06031406 RID: 201734 RVA: 0x00C4307B File Offset: 0x00C4127B
		[NullableContext(1)]
		public void SetRootActorLoadInfo(string resourceId, [Nullable(2)] UUIItem parentItem = null, bool usePool = false, bool isPermanent = false)
		{
			this._actorPath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			this.ParentUiItem = parentItem;
			this.UsePool = usePool;
			this._isPermanent = isPermanent;
		}

		// Token: 0x06031407 RID: 201735 RVA: 0x00C430A4 File Offset: 0x00C412A4
		[NullableContext(1)]
		public UniTask CreateThenShowByResourceIdAsync(string resourceId, [Nullable(2)] UUIItem parentItem = null, bool usePool = false)
		{
			UiPanelBase.<CreateThenShowByResourceIdAsync>d__65 <CreateThenShowByResourceIdAsync>d__;
			<CreateThenShowByResourceIdAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateThenShowByResourceIdAsync>d__.<>4__this = this;
			<CreateThenShowByResourceIdAsync>d__.resourceId = resourceId;
			<CreateThenShowByResourceIdAsync>d__.parentItem = parentItem;
			<CreateThenShowByResourceIdAsync>d__.usePool = usePool;
			<CreateThenShowByResourceIdAsync>d__.<>1__state = -1;
			<CreateThenShowByResourceIdAsync>d__.<>t__builder.Start<UiPanelBase.<CreateThenShowByResourceIdAsync>d__65>(ref <CreateThenShowByResourceIdAsync>d__);
			return <CreateThenShowByResourceIdAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031408 RID: 201736 RVA: 0x00C43100 File Offset: 0x00C41300
		[NullableContext(1)]
		public UniTask CreateByResourceIdAsync(string resourceId, [Nullable(2)] UUIItem parentItem = null, bool usePool = false)
		{
			UiPanelBase.<CreateByResourceIdAsync>d__66 <CreateByResourceIdAsync>d__;
			<CreateByResourceIdAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateByResourceIdAsync>d__.<>4__this = this;
			<CreateByResourceIdAsync>d__.resourceId = resourceId;
			<CreateByResourceIdAsync>d__.parentItem = parentItem;
			<CreateByResourceIdAsync>d__.usePool = usePool;
			<CreateByResourceIdAsync>d__.<>1__state = -1;
			<CreateByResourceIdAsync>d__.<>t__builder.Start<UiPanelBase.<CreateByResourceIdAsync>d__66>(ref <CreateByResourceIdAsync>d__);
			return <CreateByResourceIdAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031409 RID: 201737 RVA: 0x00C4315C File Offset: 0x00C4135C
		[NullableContext(1)]
		public UniTask CreateByPathAsync(string path, [Nullable(2)] UUIItem parentItem = null, bool usePool = false)
		{
			UiPanelBase.<CreateByPathAsync>d__67 <CreateByPathAsync>d__;
			<CreateByPathAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateByPathAsync>d__.<>4__this = this;
			<CreateByPathAsync>d__.path = path;
			<CreateByPathAsync>d__.parentItem = parentItem;
			<CreateByPathAsync>d__.usePool = usePool;
			<CreateByPathAsync>d__.<>1__state = -1;
			<CreateByPathAsync>d__.<>t__builder.Start<UiPanelBase.<CreateByPathAsync>d__67>(ref <CreateByPathAsync>d__);
			return <CreateByPathAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603140A RID: 201738 RVA: 0x00C431B8 File Offset: 0x00C413B8
		[NullableContext(1)]
		public UniTask OnlyCreateByPathAsync(string path, [Nullable(2)] UUIItem parentItem = null, bool usePool = false)
		{
			UiPanelBase.<OnlyCreateByPathAsync>d__68 <OnlyCreateByPathAsync>d__;
			<OnlyCreateByPathAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnlyCreateByPathAsync>d__.<>4__this = this;
			<OnlyCreateByPathAsync>d__.path = path;
			<OnlyCreateByPathAsync>d__.parentItem = parentItem;
			<OnlyCreateByPathAsync>d__.usePool = usePool;
			<OnlyCreateByPathAsync>d__.<>1__state = -1;
			<OnlyCreateByPathAsync>d__.<>t__builder.Start<UiPanelBase.<OnlyCreateByPathAsync>d__68>(ref <OnlyCreateByPathAsync>d__);
			return <OnlyCreateByPathAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603140B RID: 201739 RVA: 0x00C43214 File Offset: 0x00C41414
		[NullableContext(1)]
		public UniTask CreateThenShowByPathAsync(string path, [Nullable(2)] UUIItem parentItem = null, bool usePool = false)
		{
			UiPanelBase.<CreateThenShowByPathAsync>d__69 <CreateThenShowByPathAsync>d__;
			<CreateThenShowByPathAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateThenShowByPathAsync>d__.<>4__this = this;
			<CreateThenShowByPathAsync>d__.path = path;
			<CreateThenShowByPathAsync>d__.parentItem = parentItem;
			<CreateThenShowByPathAsync>d__.usePool = usePool;
			<CreateThenShowByPathAsync>d__.<>1__state = -1;
			<CreateThenShowByPathAsync>d__.<>t__builder.Start<UiPanelBase.<CreateThenShowByPathAsync>d__69>(ref <CreateThenShowByPathAsync>d__);
			return <CreateThenShowByPathAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603140C RID: 201740 RVA: 0x00C43270 File Offset: 0x00C41470
		[NullableContext(1)]
		public UniTask CreateThenShowByActorAsync(AActor actor, [Nullable(2)] object parameters = null, bool usePool = false)
		{
			UiPanelBase.<CreateThenShowByActorAsync>d__70 <CreateThenShowByActorAsync>d__;
			<CreateThenShowByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateThenShowByActorAsync>d__.<>4__this = this;
			<CreateThenShowByActorAsync>d__.actor = actor;
			<CreateThenShowByActorAsync>d__.parameters = parameters;
			<CreateThenShowByActorAsync>d__.usePool = usePool;
			<CreateThenShowByActorAsync>d__.<>1__state = -1;
			<CreateThenShowByActorAsync>d__.<>t__builder.Start<UiPanelBase.<CreateThenShowByActorAsync>d__70>(ref <CreateThenShowByActorAsync>d__);
			return <CreateThenShowByActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603140D RID: 201741 RVA: 0x00C432CC File Offset: 0x00C414CC
		[NullableContext(1)]
		public UniTask CreateByActorAsync(AActor actor, [Nullable(2)] object parameters = null, bool usePool = false)
		{
			UiPanelBase.<CreateByActorAsync>d__71 <CreateByActorAsync>d__;
			<CreateByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateByActorAsync>d__.<>4__this = this;
			<CreateByActorAsync>d__.actor = actor;
			<CreateByActorAsync>d__.parameters = parameters;
			<CreateByActorAsync>d__.usePool = usePool;
			<CreateByActorAsync>d__.<>1__state = -1;
			<CreateByActorAsync>d__.<>t__builder.Start<UiPanelBase.<CreateByActorAsync>d__71>(ref <CreateByActorAsync>d__);
			return <CreateByActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603140E RID: 201742 RVA: 0x00C43328 File Offset: 0x00C41528
		[NullableContext(1)]
		public UniTask OnlyCreateByActorAsync(AActor actor, [Nullable(2)] object parameters = null, bool usePool = false)
		{
			UiPanelBase.<OnlyCreateByActorAsync>d__72 <OnlyCreateByActorAsync>d__;
			<OnlyCreateByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnlyCreateByActorAsync>d__.<>4__this = this;
			<OnlyCreateByActorAsync>d__.actor = actor;
			<OnlyCreateByActorAsync>d__.parameters = parameters;
			<OnlyCreateByActorAsync>d__.usePool = usePool;
			<OnlyCreateByActorAsync>d__.<>1__state = -1;
			<OnlyCreateByActorAsync>d__.<>t__builder.Start<UiPanelBase.<OnlyCreateByActorAsync>d__72>(ref <OnlyCreateByActorAsync>d__);
			return <OnlyCreateByActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603140F RID: 201743 RVA: 0x00C43383 File Offset: 0x00C41583
		public virtual void SetActive(bool visibility)
		{
			if (visibility)
			{
				base.Show(null);
				return;
			}
			base.Hide(null);
		}

		// Token: 0x06031410 RID: 201744 RVA: 0x00C43397 File Offset: 0x00C41597
		public bool GetActive()
		{
			return this.RootItem != null && this.RootItem.IsValid() && this.RootItem.IsUIActiveSelf();
		}

		// Token: 0x06031411 RID: 201745 RVA: 0x00C433BB File Offset: 0x00C415BB
		public bool IsUiActiveInHierarchy()
		{
			return this.RootItem != null && this.RootItem.IsValid() && this.RootItem.IsUIActiveInHierarchy();
		}

		// Token: 0x06031412 RID: 201746 RVA: 0x00C433DF File Offset: 0x00C415DF
		public void SetUiActive(bool visibility)
		{
			if (this.RootItem == null || !this.RootItem.IsValid())
			{
				return;
			}
			this.RootItem.SetUIActive(visibility);
		}

		// Token: 0x06031413 RID: 201747 RVA: 0x00C43403 File Offset: 0x00C41603
		public bool InAsyncLoading()
		{
			return base.IsCreating;
		}

		// Token: 0x06031414 RID: 201748 RVA: 0x00C4340C File Offset: 0x00C4160C
		private UniTask LoadRootActorAsync()
		{
			UiPanelBase.<LoadRootActorAsync>d__78 <LoadRootActorAsync>d__;
			<LoadRootActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadRootActorAsync>d__.<>4__this = this;
			<LoadRootActorAsync>d__.<>1__state = -1;
			<LoadRootActorAsync>d__.<>t__builder.Start<UiPanelBase.<LoadRootActorAsync>d__78>(ref <LoadRootActorAsync>d__);
			return <LoadRootActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031415 RID: 201749 RVA: 0x00C43450 File Offset: 0x00C41650
		[NullableContext(1)]
		private unsafe bool SetActor(AActor actor)
		{
			AUIBaseActor auibaseActor = actor as AUIBaseActor;
			if (auibaseActor == null || !auibaseActor.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.TL;
				string message = "[SetActor] actor is not UIBaseActor";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("uiActor", (auibaseActor != null) ? auibaseActor.GetName() : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("path", Singleton<LguiUtil>.Instance.GetActorFullPath(auibaseActor));
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			this._originalActor = auibaseActor;
			this._originalItem = (this._originalActor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem);
			this.InitRootActorAndComponentRegistry();
			this.InitGuideRegistry();
			this.BindOnClickEvents();
			this.SetUiActive(false);
			this._originalActor.OnPreDestroyed.Add(new Action<AActor>(this.AutoDestroy));
			if (this.RootActor != this._originalActor)
			{
				AUIBaseActor rootActor = this.RootActor;
				if (rootActor != null)
				{
					rootActor.OnPreDestroyed.Add(new Action<AActor>(this.DestroyCheck));
				}
			}
			return true;
		}

		// Token: 0x06031416 RID: 201750 RVA: 0x00C43566 File Offset: 0x00C41766
		private void RefreshMemoryTag()
		{
			if (this._originalItem != null && this._originalItem.IsValid())
			{
				this.MemoryTag = Singleton<LguiUtil>.Instance.GetRootActorMemoryTag(this._originalItem, null);
			}
		}

		// Token: 0x06031417 RID: 201751 RVA: 0x00C43594 File Offset: 0x00C41794
		private void InitRootActorAndComponentRegistry()
		{
			this.OnRegisterComponent();
			this.RootActor = (this.FindInitedComponentRegistryActor() ?? this._originalActor);
			AUIBaseActor rootActor = this.RootActor;
			this.RootItem = (((rootActor != null) ? rootActor.GetComponentByClass(UUIItem.StaticClass()) : null) as UUIItem);
		}

		// Token: 0x06031418 RID: 201752 RVA: 0x00C435E4 File Offset: 0x00C417E4
		private unsafe AUIBaseActor FindInitedComponentRegistryActor()
		{
			AUIBaseActor originalActor = this._originalActor;
			ULGUIComponentsRegistry componentsRegistry = Singleton<LguiUtil>.Instance.GetComponentsRegistry(originalActor);
			AUIBaseActor auibaseActor = originalActor;
			if (componentsRegistry == null)
			{
				if (originalActor != null)
				{
					auibaseActor = Singleton<LguiUtil>.Instance.GetChildActorByHierarchyIndex(originalActor, 0);
				}
				if (auibaseActor != null)
				{
					componentsRegistry = Singleton<LguiUtil>.Instance.GetComponentsRegistry(auibaseActor);
					if (componentsRegistry == null)
					{
						auibaseActor = Singleton<LguiUtil>.Instance.GetChildActorByHierarchyIndex(auibaseActor, 0);
						if (auibaseActor != null)
						{
							componentsRegistry = Singleton<LguiUtil>.Instance.GetComponentsRegistry(auibaseActor);
						}
					}
				}
			}
			if (componentsRegistry == null)
			{
				return null;
			}
			int num = componentsRegistry.Components.Num();
			foreach (ValueTuple<int, Type> valueTuple in this.ComponentRegisterInfos)
			{
				int item = valueTuple.Item1;
				if (item < num)
				{
					AActor aactor = componentsRegistry.Components.Get(item);
					Func<UClassStackOnlyPtr> func;
					if (UiPanelBase.StaticClassGetters.TryGetValue(valueTuple.Item2, out func))
					{
						UActorComponent uactorComponent = (aactor != null) ? aactor.GetComponentByClass(func()) : null;
						if (uactorComponent == null)
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.UiCore;
							ELogAuthor author = ELogAuthor.TL;
							string message = "[FindInitedComponentRegistryActor]请该UI负责人和程序检查以下路径的LGUIComponentsRegistry组件, 检查是否缺失以下类型的组件";
							<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("节点全路径为", Singleton<LguiUtil>.Instance.GetActorFullPath(auibaseActor));
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("缺失组件的索引为", valueTuple.Item1);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("缺失的组件类型为", valueTuple.Item2.Name);
							instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
						}
						else
						{
							this.BaseComponentMap[valueTuple.Item1] = new Tuple<Type, UActorComponent>(uactorComponent.GetType(), uactorComponent);
							this.BindAudioEvents(uactorComponent.GetType(), uactorComponent);
						}
					}
					else
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.UiCore;
						ELogAuthor author2 = ELogAuthor.TL;
						string message2 = "[FindInitedComponentRegistryActor] C#环境下, 组件类型未在StaticClassGetters中注册, 请在UiPanelBase.StaticClassGetters中补充该类型";
						<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("节点全路径为", Singleton<LguiUtil>.Instance.GetActorFullPath(auibaseActor));
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("组件的索引为", valueTuple.Item1);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("未注册的组件类型为", valueTuple.Item2.Name);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("TsClassName", base.GetType().Name);
						instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
					}
				}
			}
			return auibaseActor;
		}

		// Token: 0x06031419 RID: 201753 RVA: 0x00C4387C File Offset: 0x00C41A7C
		protected virtual bool DestroyOverride()
		{
			return false;
		}

		// Token: 0x0603141A RID: 201754 RVA: 0x00C43880 File Offset: 0x00C41A80
		private void DestroyPrivate()
		{
			this.UnBindOnClickEvents();
			this.UnBindAllAudioEvents();
			this.ClearUiResourceLoadModule();
			this.ClearUiPrefabLoadModule();
			this.BaseComponentMap.Clear();
			this.BtnBindInfo.Clear();
			this.Children.Clear();
			this.RemoveFromParent();
			this.UiBehaviorProxies.Clear();
			this.OpenParam = null;
			this.DestroyActor();
		}

		// Token: 0x0603141B RID: 201755 RVA: 0x00C438E4 File Offset: 0x00C41AE4
		private void DestroyActor()
		{
			if (this.SkipDestroyActor)
			{
				return;
			}
			AUIBaseActor originalActor = this._originalActor;
			if (originalActor != null && originalActor.IsValid())
			{
				this._originalActor.OnPreDestroyed.Remove(new Action<AActor>(this.AutoDestroy));
			}
			AUIBaseActor rootActor = this.RootActor;
			if (rootActor != null && rootActor.IsValid())
			{
				this.RootActor.OnPreDestroyed.Remove(new Action<AActor>(this.DestroyCheck));
			}
			if (!this.DestroyOverride())
			{
				if (this.UsePool)
				{
					this.RecycleAsyncLoad();
				}
				else if (this._originalActor != null && this._originalActor.IsValid())
				{
					ULGUIBPLibrary.DestroyActorWithHierarchy(this._originalActor, true);
				}
			}
			this._originalActor = null;
			this.RootActor = null;
			this.RootItem = null;
		}

		// Token: 0x0603141C RID: 201756 RVA: 0x00C439A8 File Offset: 0x00C41BA8
		private void AutoDestroy(AActor aActor)
		{
			if (base.IsDestroyOrDestroying)
			{
				return;
			}
			this.OnAutoDestroy();
			base.Destroy(null);
		}

		// Token: 0x0603141D RID: 201757 RVA: 0x00C439C0 File Offset: 0x00C41BC0
		private void DestroyCheck(AActor aActor)
		{
			if (base.IsDestroyOrDestroying || this.WaitToDestroy)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiComponent;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "对象已销毁,生命周期不同步请检查";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Ts类名", base.GetType().Name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0603141E RID: 201758 RVA: 0x00C43A0F File Offset: 0x00C41C0F
		public UUIItem GetRootItem()
		{
			return this.RootItem;
		}

		// Token: 0x0603141F RID: 201759 RVA: 0x00C43A17 File Offset: 0x00C41C17
		public AActor GetRootActor()
		{
			return this.RootActor;
		}

		// Token: 0x06031420 RID: 201760 RVA: 0x00C43A1F File Offset: 0x00C41C1F
		public AActor GetOriginalActor()
		{
			return this._originalActor;
		}

		// Token: 0x06031421 RID: 201761 RVA: 0x00C43A27 File Offset: 0x00C41C27
		public virtual UUIItem GetOriginalItem()
		{
			return this._originalItem;
		}

		// Token: 0x06031422 RID: 201762 RVA: 0x00C43A2F File Offset: 0x00C41C2F
		public virtual CustomPromise GetClosePromiseImplement()
		{
			return null;
		}

		// Token: 0x06031423 RID: 201763 RVA: 0x00C43A32 File Offset: 0x00C41C32
		private void RecycleAsyncLoad()
		{
			Singleton<UiActorPool>.Instance.RecycleAsync(this.UiPoolActorNew, this._actorPath);
			this.UiPoolActorNew = null;
		}

		// Token: 0x06031424 RID: 201764 RVA: 0x00C43A54 File Offset: 0x00C41C54
		[NullableContext(1)]
		private void BindAudioEvents(Type type, UActorComponent component)
		{
			if (!(type == typeof(UUIButtonComponent)))
			{
				if (type == typeof(UUIExtendToggle))
				{
					UUIExtendToggle uuiextendToggle = component as UUIExtendToggle;
					if (uuiextendToggle != null)
					{
						uuiextendToggle.OnPostAudioEvent.Bind(new Action<string>(this.PostClickAudioEvent));
					}
					if (uuiextendToggle == null)
					{
						return;
					}
					uuiextendToggle.OnPostAudioStateEvent.Bind(delegate(EToggleAudioTransitionState state, string eventPath)
					{
						this.PostClickAudioEvent(eventPath);
					});
				}
				return;
			}
			UUIButtonComponent uuibuttonComponent = component as UUIButtonComponent;
			if (uuibuttonComponent != null)
			{
				uuibuttonComponent.OnPostAudioEvent.Bind(new Action<string>(this.PostClickAudioEvent));
			}
			if (uuibuttonComponent == null)
			{
				return;
			}
			uuibuttonComponent.OnPostAudioStateEvent.Bind(delegate(EButtonAudioStateTransferType state, string eventPath)
			{
				this.PostClickAudioEvent(eventPath);
			});
		}

		// Token: 0x06031425 RID: 201765 RVA: 0x00C43B04 File Offset: 0x00C41D04
		private void UnBindAllAudioEvents()
		{
			foreach (KeyValuePair<int, Tuple<Type, UActorComponent>> keyValuePair in this.BaseComponentMap)
			{
				Type item = keyValuePair.Value.Item1;
				UActorComponent item2 = keyValuePair.Value.Item2;
				if (item == typeof(UUIButtonComponent))
				{
					UUIButtonComponent uuibuttonComponent = item2 as UUIButtonComponent;
					if (uuibuttonComponent != null)
					{
						uuibuttonComponent.OnPostAudioEvent.Unbind();
					}
					if (uuibuttonComponent != null)
					{
						uuibuttonComponent.OnPostAudioStateEvent.Unbind();
					}
				}
				else if (item == typeof(UUIExtendToggle))
				{
					UUIExtendToggle uuiextendToggle = item2 as UUIExtendToggle;
					if (uuiextendToggle != null)
					{
						uuiextendToggle.OnPostAudioEvent.Unbind();
					}
					if (uuiextendToggle != null)
					{
						uuiextendToggle.OnPostAudioStateEvent.Unbind();
					}
				}
			}
		}

		// Token: 0x06031426 RID: 201766 RVA: 0x00C43BE4 File Offset: 0x00C41DE4
		protected unsafe void BindOnClickEvents()
		{
			foreach (ValueTuple<int, Delegate> valueTuple in this.BtnBindInfo)
			{
				if (this.BaseComponentMap.ContainsKey(valueTuple.Item1))
				{
					this.BindOnClickEvent(valueTuple.Item1, valueTuple.Item2);
				}
				else
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiComponent;
					ELogAuthor author = ELogAuthor.HCW;
					string message = "检查BtnBindInfo中的项是否没有在ComponentsRegisterInfo中注册";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", base.GetType().Name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ComponentId", valueTuple.Item1);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
		}

		// Token: 0x06031427 RID: 201767 RVA: 0x00C43CC4 File Offset: 0x00C41EC4
		[NullableContext(1)]
		protected void BindOnClickEvent(int name, Delegate fn)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return;
			}
			UActorComponent item = tuple.Item2;
			UUIButtonComponent uuibuttonComponent = item as UUIButtonComponent;
			if (uuibuttonComponent != null)
			{
				UiComponentActionBinder.BindClickEvent(name, uuibuttonComponent, fn);
				return;
			}
			UUIToggleComponent uuitoggleComponent = item as UUIToggleComponent;
			if (uuitoggleComponent != null)
			{
				UiComponentActionBinder.BindClickEvent(name, uuitoggleComponent, fn);
				return;
			}
			UUIExtendToggle uuiextendToggle = item as UUIExtendToggle;
			if (uuiextendToggle != null)
			{
				UiComponentActionBinder.BindClickEvent(name, uuiextendToggle, fn);
				return;
			}
			UUISliderComponent uuisliderComponent = item as UUISliderComponent;
			if (uuisliderComponent != null)
			{
				UiComponentActionBinder.BindClickEvent(name, uuisliderComponent, fn);
				return;
			}
			UUITextInputComponent uuitextInputComponent = item as UUITextInputComponent;
			if (uuitextInputComponent == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 2);
				defaultInterpolatedStringHandler.AppendLiteral("未支持的事件绑定组件类型: ");
				defaultInterpolatedStringHandler.AppendFormatted(tuple.Item1.Name);
				defaultInterpolatedStringHandler.AppendLiteral(" (组件ID: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(name);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				throw new NotImplementedException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			UiComponentActionBinder.BindClickEvent(name, uuitextInputComponent, fn);
		}

		// Token: 0x06031428 RID: 201768 RVA: 0x00C43DAC File Offset: 0x00C41FAC
		protected void UnBindOnClickEvents()
		{
			foreach (ValueTuple<int, Delegate> valueTuple in this.BtnBindInfo)
			{
				this.UnBindOnClickEvent(valueTuple.Item1);
			}
		}

		// Token: 0x06031429 RID: 201769 RVA: 0x00C43E04 File Offset: 0x00C42004
		protected void UnBindOnClickEvent(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return;
			}
			UActorComponent item = tuple.Item2;
			UUIButtonComponent uuibuttonComponent = item as UUIButtonComponent;
			if (uuibuttonComponent != null)
			{
				uuibuttonComponent.OnClickCallBack.Unbind();
				return;
			}
			UUIToggleComponent uuitoggleComponent = item as UUIToggleComponent;
			if (uuitoggleComponent != null)
			{
				uuitoggleComponent.OnToggleEvent.Unbind();
				return;
			}
			UUIExtendToggle uuiextendToggle = item as UUIExtendToggle;
			if (uuiextendToggle != null)
			{
				uuiextendToggle.OnStateChange.Clear();
				uuiextendToggle.CanExecuteChange.Unbind();
				return;
			}
			UUISliderComponent uuisliderComponent = item as UUISliderComponent;
			if (uuisliderComponent != null)
			{
				uuisliderComponent.OnValueChangeCb.Unbind();
				return;
			}
			UUITextInputComponent uuitextInputComponent = item as UUITextInputComponent;
			if (uuitextInputComponent == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 2);
				defaultInterpolatedStringHandler.AppendLiteral("未支持的取消事件绑定组件类型: ");
				defaultInterpolatedStringHandler.AppendFormatted(tuple.Item1.Name);
				defaultInterpolatedStringHandler.AppendLiteral(" (组件ID: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(name);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				throw new NotImplementedException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			uuitextInputComponent.OnInputActivateDelegate.Unbind();
		}

		// Token: 0x0603142A RID: 201770 RVA: 0x00C43F04 File Offset: 0x00C42104
		[NullableContext(1)]
		protected void PostClickAudioEvent(string eventPath)
		{
			string text = Singleton<AudioSystem>.Instance.parseAudioEventPath(eventPath);
			if (text != null)
			{
				Singleton<AudioSystem>.Instance.PostEvent(text);
			}
		}

		// Token: 0x0603142B RID: 201771 RVA: 0x00C43F2C File Offset: 0x00C4212C
		protected UUIButtonComponent GetButton(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIButtonComponent;
		}

		// Token: 0x0603142C RID: 201772 RVA: 0x00C43F58 File Offset: 0x00C42158
		protected UUIItem GetItem(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIItem;
		}

		// Token: 0x0603142D RID: 201773 RVA: 0x00C43F84 File Offset: 0x00C42184
		protected USpineSkeletonAnimationComponent GetSpine(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as USpineSkeletonAnimationComponent;
		}

		// Token: 0x0603142E RID: 201774 RVA: 0x00C43FB0 File Offset: 0x00C421B0
		protected UUIInteractionGroup GetInteractionGroup(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIInteractionGroup;
		}

		// Token: 0x0603142F RID: 201775 RVA: 0x00C43FDC File Offset: 0x00C421DC
		protected UUIText GetText(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIText;
		}

		// Token: 0x06031430 RID: 201776 RVA: 0x00C44008 File Offset: 0x00C42208
		protected UUIArtText GetArtText(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIArtText;
		}

		// Token: 0x06031431 RID: 201777 RVA: 0x00C44034 File Offset: 0x00C42234
		protected UUISprite GetSprite(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUISprite;
		}

		// Token: 0x06031432 RID: 201778 RVA: 0x00C44060 File Offset: 0x00C42260
		protected UUITexture GetTexture(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUITexture;
		}

		// Token: 0x06031433 RID: 201779 RVA: 0x00C4408C File Offset: 0x00C4228C
		protected UUISliderComponent GetSlider(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUISliderComponent;
		}

		// Token: 0x06031434 RID: 201780 RVA: 0x00C440B8 File Offset: 0x00C422B8
		protected UUIToggleComponent GetToggle(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIToggleComponent;
		}

		// Token: 0x06031435 RID: 201781 RVA: 0x00C440E4 File Offset: 0x00C422E4
		protected UUIExtendToggle GetExtendToggle(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIExtendToggle;
		}

		// Token: 0x06031436 RID: 201782 RVA: 0x00C44110 File Offset: 0x00C42310
		protected UUIExtendToggleGroup GetExtendToggleGroup(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIExtendToggleGroup;
		}

		// Token: 0x06031437 RID: 201783 RVA: 0x00C4413C File Offset: 0x00C4233C
		protected UUIScrollViewWithScrollbarComponent GetScrollViewWithScrollbar(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIScrollViewWithScrollbarComponent;
		}

		// Token: 0x06031438 RID: 201784 RVA: 0x00C44168 File Offset: 0x00C42368
		protected UUIDynScrollViewComponent GetUIDynScrollViewComponent(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIDynScrollViewComponent;
		}

		// Token: 0x06031439 RID: 201785 RVA: 0x00C44194 File Offset: 0x00C42394
		protected UUIScrollbarComponent GetScrollScrollbar(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIScrollbarComponent;
		}

		// Token: 0x0603143A RID: 201786 RVA: 0x00C441C0 File Offset: 0x00C423C0
		protected UUIScrollViewComponent GetScrollView(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIScrollViewComponent;
		}

		// Token: 0x0603143B RID: 201787 RVA: 0x00C441EC File Offset: 0x00C423EC
		protected UUILoopScrollViewComponent GetLoopScrollViewComponent(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUILoopScrollViewComponent;
		}

		// Token: 0x0603143C RID: 201788 RVA: 0x00C44218 File Offset: 0x00C42418
		protected UUIMultiTemplateScrollViewComponent GetMultiTemplateScrollViewComponent(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIMultiTemplateScrollViewComponent;
		}

		// Token: 0x0603143D RID: 201789 RVA: 0x00C44244 File Offset: 0x00C42444
		protected UUIDropdownComponent GetDropdown(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIDropdownComponent;
		}

		// Token: 0x0603143E RID: 201790 RVA: 0x00C44270 File Offset: 0x00C42470
		protected UUITextInputComponent GetInputText(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUITextInputComponent;
		}

		// Token: 0x0603143F RID: 201791 RVA: 0x00C4429C File Offset: 0x00C4249C
		protected UUIDraggableComponent GetDraggable(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIDraggableComponent;
		}

		// Token: 0x06031440 RID: 201792 RVA: 0x00C442C8 File Offset: 0x00C424C8
		protected UUINiagara GetUiNiagara(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUINiagara;
		}

		// Token: 0x06031441 RID: 201793 RVA: 0x00C442F4 File Offset: 0x00C424F4
		protected UUIVerticalLayout GetVerticalLayout(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIVerticalLayout;
		}

		// Token: 0x06031442 RID: 201794 RVA: 0x00C44320 File Offset: 0x00C42520
		protected UUIHorizontalLayout GetHorizontalLayout(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIHorizontalLayout;
		}

		// Token: 0x06031443 RID: 201795 RVA: 0x00C4434C File Offset: 0x00C4254C
		protected UUIMultiTemplateLayout GetMultiTemplateLayout(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIMultiTemplateLayout;
		}

		// Token: 0x06031444 RID: 201796 RVA: 0x00C44378 File Offset: 0x00C42578
		protected UUIGridLayout GetGridLayout(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIGridLayout;
		}

		// Token: 0x06031445 RID: 201797 RVA: 0x00C443A4 File Offset: 0x00C425A4
		protected UUILayoutBase GetLayoutBase(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUILayoutBase;
		}

		// Token: 0x06031446 RID: 201798 RVA: 0x00C443D0 File Offset: 0x00C425D0
		protected UUITextTransition GetUITextTransition(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUITextTransition;
		}

		// Token: 0x06031447 RID: 201799 RVA: 0x00C443FC File Offset: 0x00C425FC
		protected UUITextureTransitionComponent GetUiTextureTransitionComponent(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUITextureTransitionComponent;
		}

		// Token: 0x06031448 RID: 201800 RVA: 0x00C44428 File Offset: 0x00C42628
		protected UUISpriteTransition GetUiSpriteTransition(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUISpriteTransition;
		}

		// Token: 0x06031449 RID: 201801 RVA: 0x00C44454 File Offset: 0x00C42654
		protected UUIExtendToggleSpriteTransition GetUiExtendToggleSpriteTransition(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIExtendToggleSpriteTransition;
		}

		// Token: 0x0603144A RID: 201802 RVA: 0x00C44480 File Offset: 0x00C42680
		protected UUIExtendToggleTextureTransition GetUiExtendToggleTextureTransition(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIExtendToggleTextureTransition;
		}

		// Token: 0x0603144B RID: 201803 RVA: 0x00C444AC File Offset: 0x00C426AC
		protected UUIExtendToggleTextTransition GetUiExtendToggleTextTransition(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIExtendToggleTextTransition;
		}

		// Token: 0x0603144C RID: 201804 RVA: 0x00C444D8 File Offset: 0x00C426D8
		protected UUISizeControlByOther GetUiSizeControlByOther(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUISizeControlByOther;
		}

		// Token: 0x0603144D RID: 201805 RVA: 0x00C44504 File Offset: 0x00C42704
		protected UUIDynamicBatchMesh GetDynamicBatchMesh(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIDynamicBatchMesh;
		}

		// Token: 0x0603144E RID: 201806 RVA: 0x00C44530 File Offset: 0x00C42730
		protected UUIInturnAnimController GetUiInturnAnimController(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUIInturnAnimController;
		}

		// Token: 0x0603144F RID: 201807 RVA: 0x00C4455C File Offset: 0x00C4275C
		protected UUI2DLineRaw GetUiLineRaw(int name)
		{
			Tuple<Type, UActorComponent> tuple;
			if (!this.BaseComponentMap.TryGetValue(name, out tuple))
			{
				return null;
			}
			return tuple.Item2 as UUI2DLineRaw;
		}

		// Token: 0x06031450 RID: 201808 RVA: 0x00C44586 File Offset: 0x00C42786
		private void InitGuideRegistry()
		{
			AActor rootActor = this.GetRootActor();
			this._guideRegistry = (((rootActor != null) ? rootActor.GetComponentByClass(UGuideHookRegistry.StaticClass()) : null) as UGuideHookRegistry);
		}

		// Token: 0x06031451 RID: 201809 RVA: 0x00C445B0 File Offset: 0x00C427B0
		[NullableContext(1)]
		[return: Nullable(2)]
		public UUIItem GetGuideUiItem(string name)
		{
			if (this._guideRegistry == null)
			{
				return null;
			}
			TWeakObjectPtr<AActor>? valueOrNull = this._guideRegistry.GuideHookComponents.GetValueOrNull(name);
			if (valueOrNull == null)
			{
				return null;
			}
			AUIBaseActor auibaseActor = valueOrNull.Value.Get() as AUIBaseActor;
			if (auibaseActor == null)
			{
				return null;
			}
			return auibaseActor.GetUIItem();
		}

		// Token: 0x06031452 RID: 201810 RVA: 0x00C44604 File Offset: 0x00C42804
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public virtual UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			Singleton<Log>.Instance.Error(ELogModule.Guide, ELogAuthor.TL, "引导步骤已配置的聚焦界面未实现GetGuideUiItemEx函数", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}

		// Token: 0x06031453 RID: 201811 RVA: 0x00C4462E File Offset: 0x00C4282E
		public virtual UUIScrollViewComponent GetGuideScrollViewToLock()
		{
			return null;
		}

		// Token: 0x06031454 RID: 201812 RVA: 0x00C44634 File Offset: 0x00C42834
		protected void SetButtonUiActive(int name, bool value)
		{
			UUIButtonComponent button = this.GetButton(name);
			if (button == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCommon, ELogAuthor.TL, "设置Button可见性错误，Button组件为空！", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			UUIItem rootComponent = button.GetRootComponent();
			if (rootComponent == null)
			{
				return;
			}
			rootComponent.SetUIActive(value);
		}

		// Token: 0x06031455 RID: 201813 RVA: 0x00C4467C File Offset: 0x00C4287C
		[NullableContext(1)]
		protected virtual void SetSpriteByPath(string path, UUISprite uiSprite, bool setSize, EUiViewName? syncLoadViewName = null, [Nullable(2)] Action<bool> callback = null)
		{
			EUiViewName? euiViewName = syncLoadViewName;
			if (!string.IsNullOrEmpty((euiViewName != null) ? euiViewName.GetValueOrDefault() : null))
			{
				this._uiImageSettingModule.SetSpriteByPathSync(path, uiSprite, setSize, syncLoadViewName.Value, callback);
				return;
			}
			this._uiImageSettingModule.SetSpriteByPathAsync(path, uiSprite, setSize, callback);
		}

		// Token: 0x06031456 RID: 201814 RVA: 0x00C446D3 File Offset: 0x00C428D3
		protected void TrySetSpriteByPath(string path, UUISprite uiSprite, bool setSize, EUiViewName? syncLoadViewName = null, Action<bool> callback = null)
		{
			if (path == null || uiSprite == null)
			{
				if (uiSprite != null)
				{
					uiSprite.SetUIActive(false);
					return;
				}
			}
			else
			{
				uiSprite.SetUIActive(true);
				this.SetSpriteByPath(path, uiSprite, setSize, syncLoadViewName, callback);
			}
		}

		// Token: 0x06031457 RID: 201815 RVA: 0x00C446FC File Offset: 0x00C428FC
		[NullableContext(1)]
		protected UniTask SetSpriteTransitionByPath(string path, UUISpriteTransition uiSpriteTransition, EUISelectableSelectionState state = EUISelectableSelectionState.EUISelectableSelectionState_MAX)
		{
			UiPanelBase.<SetSpriteTransitionByPath>d__148 <SetSpriteTransitionByPath>d__;
			<SetSpriteTransitionByPath>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetSpriteTransitionByPath>d__.<>4__this = this;
			<SetSpriteTransitionByPath>d__.path = path;
			<SetSpriteTransitionByPath>d__.uiSpriteTransition = uiSpriteTransition;
			<SetSpriteTransitionByPath>d__.state = state;
			<SetSpriteTransitionByPath>d__.<>1__state = -1;
			<SetSpriteTransitionByPath>d__.<>t__builder.Start<UiPanelBase.<SetSpriteTransitionByPath>d__148>(ref <SetSpriteTransitionByPath>d__);
			return <SetSpriteTransitionByPath>d__.<>t__builder.Task;
		}

		// Token: 0x06031458 RID: 201816 RVA: 0x00C44757 File Offset: 0x00C42957
		protected void SetTextureByPath([Nullable(1)] string path, UUITexture uiTexture, EUiViewName? syncLoadViewName = null, Action<bool> callback = null)
		{
			if (syncLoadViewName != null)
			{
				this._uiImageSettingModule.SetTextureByPathSync(path, uiTexture, syncLoadViewName.Value, callback);
				return;
			}
			this._uiImageSettingModule.SetTextureByPathAsync(path, uiTexture, callback);
		}

		// Token: 0x06031459 RID: 201817 RVA: 0x00C44788 File Offset: 0x00C42988
		protected void TrySetTextureByPath(string path, UUITexture uiTexture, EUiViewName? syncLoadViewName = null, Action<bool> callback = null)
		{
			if (path == null)
			{
				if (uiTexture != null)
				{
					uiTexture.SetUIActive(false);
					return;
				}
			}
			else
			{
				if (uiTexture != null)
				{
					uiTexture.SetUIActive(true);
				}
				this.SetTextureByPath(path, uiTexture, syncLoadViewName, callback);
			}
		}

		// Token: 0x0603145A RID: 201818 RVA: 0x00C447B0 File Offset: 0x00C429B0
		[NullableContext(1)]
		protected UniTask SetTextureTransitionByPath(string path, UUITextureTransitionComponent uiTextureTransition, EUISelectableSelectionState state = EUISelectableSelectionState.EUISelectableSelectionState_MAX)
		{
			UiPanelBase.<SetTextureTransitionByPath>d__151 <SetTextureTransitionByPath>d__;
			<SetTextureTransitionByPath>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetTextureTransitionByPath>d__.<>4__this = this;
			<SetTextureTransitionByPath>d__.path = path;
			<SetTextureTransitionByPath>d__.uiTextureTransition = uiTextureTransition;
			<SetTextureTransitionByPath>d__.state = state;
			<SetTextureTransitionByPath>d__.<>1__state = -1;
			<SetTextureTransitionByPath>d__.<>t__builder.Start<UiPanelBase.<SetTextureTransitionByPath>d__151>(ref <SetTextureTransitionByPath>d__);
			return <SetTextureTransitionByPath>d__.<>t__builder.Task;
		}

		// Token: 0x0603145B RID: 201819 RVA: 0x00C4480C File Offset: 0x00C42A0C
		[NullableContext(1)]
		protected UniTask SetExtendToggleTextureTransitionByPath(string path, UUIExtendToggleTextureTransition uiExtendToggleTextureTransition, EToggleTransitionState state = EToggleTransitionState.ETT_MAX)
		{
			UiPanelBase.<SetExtendToggleTextureTransitionByPath>d__152 <SetExtendToggleTextureTransitionByPath>d__;
			<SetExtendToggleTextureTransitionByPath>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetExtendToggleTextureTransitionByPath>d__.<>4__this = this;
			<SetExtendToggleTextureTransitionByPath>d__.path = path;
			<SetExtendToggleTextureTransitionByPath>d__.uiExtendToggleTextureTransition = uiExtendToggleTextureTransition;
			<SetExtendToggleTextureTransitionByPath>d__.state = state;
			<SetExtendToggleTextureTransitionByPath>d__.<>1__state = -1;
			<SetExtendToggleTextureTransitionByPath>d__.<>t__builder.Start<UiPanelBase.<SetExtendToggleTextureTransitionByPath>d__152>(ref <SetExtendToggleTextureTransitionByPath>d__);
			return <SetExtendToggleTextureTransitionByPath>d__.<>t__builder.Task;
		}

		// Token: 0x0603145C RID: 201820 RVA: 0x00C44868 File Offset: 0x00C42A68
		[NullableContext(1)]
		protected UniTask SetExtendToggleTextureTransitionGroupByPath(string path, UUIExtendToggleTextureTransition uiExtendToggleTextureTransition, EToggleTransitionState[] states)
		{
			UiPanelBase.<SetExtendToggleTextureTransitionGroupByPath>d__153 <SetExtendToggleTextureTransitionGroupByPath>d__;
			<SetExtendToggleTextureTransitionGroupByPath>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetExtendToggleTextureTransitionGroupByPath>d__.<>4__this = this;
			<SetExtendToggleTextureTransitionGroupByPath>d__.path = path;
			<SetExtendToggleTextureTransitionGroupByPath>d__.uiExtendToggleTextureTransition = uiExtendToggleTextureTransition;
			<SetExtendToggleTextureTransitionGroupByPath>d__.states = states;
			<SetExtendToggleTextureTransitionGroupByPath>d__.<>1__state = -1;
			<SetExtendToggleTextureTransitionGroupByPath>d__.<>t__builder.Start<UiPanelBase.<SetExtendToggleTextureTransitionGroupByPath>d__153>(ref <SetExtendToggleTextureTransitionGroupByPath>d__);
			return <SetExtendToggleTextureTransitionGroupByPath>d__.<>t__builder.Task;
		}

		// Token: 0x0603145D RID: 201821 RVA: 0x00C448C4 File Offset: 0x00C42AC4
		[NullableContext(1)]
		protected UniTask SetTextureCustomMaterialAsync(string materialPath, [Nullable(2)] UUITexture uiTexture)
		{
			UiPanelBase.<SetTextureCustomMaterialAsync>d__154 <SetTextureCustomMaterialAsync>d__;
			<SetTextureCustomMaterialAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetTextureCustomMaterialAsync>d__.<>4__this = this;
			<SetTextureCustomMaterialAsync>d__.materialPath = materialPath;
			<SetTextureCustomMaterialAsync>d__.uiTexture = uiTexture;
			<SetTextureCustomMaterialAsync>d__.<>1__state = -1;
			<SetTextureCustomMaterialAsync>d__.<>t__builder.Start<UiPanelBase.<SetTextureCustomMaterialAsync>d__154>(ref <SetTextureCustomMaterialAsync>d__);
			return <SetTextureCustomMaterialAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603145E RID: 201822 RVA: 0x00C44918 File Offset: 0x00C42B18
		[NullableContext(1)]
		protected UniTask SetExtendToggleSpriteTransitionByPath(string path, UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition, EToggleTransitionState? state = null)
		{
			UiPanelBase.<SetExtendToggleSpriteTransitionByPath>d__155 <SetExtendToggleSpriteTransitionByPath>d__;
			<SetExtendToggleSpriteTransitionByPath>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetExtendToggleSpriteTransitionByPath>d__.<>4__this = this;
			<SetExtendToggleSpriteTransitionByPath>d__.path = path;
			<SetExtendToggleSpriteTransitionByPath>d__.uiExtendToggleSpriteTransition = uiExtendToggleSpriteTransition;
			<SetExtendToggleSpriteTransitionByPath>d__.state = state;
			<SetExtendToggleSpriteTransitionByPath>d__.<>1__state = -1;
			<SetExtendToggleSpriteTransitionByPath>d__.<>t__builder.Start<UiPanelBase.<SetExtendToggleSpriteTransitionByPath>d__155>(ref <SetExtendToggleSpriteTransitionByPath>d__);
			return <SetExtendToggleSpriteTransitionByPath>d__.<>t__builder.Task;
		}

		// Token: 0x0603145F RID: 201823 RVA: 0x00C44974 File Offset: 0x00C42B74
		[NullableContext(1)]
		protected UniTask SetExtendToggleSpriteTransitionByStateList(string path, UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition, EToggleTransitionState[] states)
		{
			UiPanelBase.<SetExtendToggleSpriteTransitionByStateList>d__156 <SetExtendToggleSpriteTransitionByStateList>d__;
			<SetExtendToggleSpriteTransitionByStateList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetExtendToggleSpriteTransitionByStateList>d__.<>4__this = this;
			<SetExtendToggleSpriteTransitionByStateList>d__.path = path;
			<SetExtendToggleSpriteTransitionByStateList>d__.uiExtendToggleSpriteTransition = uiExtendToggleSpriteTransition;
			<SetExtendToggleSpriteTransitionByStateList>d__.states = states;
			<SetExtendToggleSpriteTransitionByStateList>d__.<>1__state = -1;
			<SetExtendToggleSpriteTransitionByStateList>d__.<>t__builder.Start<UiPanelBase.<SetExtendToggleSpriteTransitionByStateList>d__156>(ref <SetExtendToggleSpriteTransitionByStateList>d__);
			return <SetExtendToggleSpriteTransitionByStateList>d__.<>t__builder.Task;
		}

		// Token: 0x06031460 RID: 201824 RVA: 0x00C449D0 File Offset: 0x00C42BD0
		[NullableContext(1)]
		protected UniTask SetTextureAsync(string path, UUITexture uiTexture)
		{
			UiPanelBase.<SetTextureAsync>d__157 <SetTextureAsync>d__;
			<SetTextureAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetTextureAsync>d__.<>4__this = this;
			<SetTextureAsync>d__.path = path;
			<SetTextureAsync>d__.uiTexture = uiTexture;
			<SetTextureAsync>d__.<>1__state = -1;
			<SetTextureAsync>d__.<>t__builder.Start<UiPanelBase.<SetTextureAsync>d__157>(ref <SetTextureAsync>d__);
			return <SetTextureAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031461 RID: 201825 RVA: 0x00C44A24 File Offset: 0x00C42C24
		[NullableContext(1)]
		protected UniTask SetSpriteAsync(string path, UUISprite uiSprite, bool setSize)
		{
			UiPanelBase.<SetSpriteAsync>d__158 <SetSpriteAsync>d__;
			<SetSpriteAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetSpriteAsync>d__.<>4__this = this;
			<SetSpriteAsync>d__.path = path;
			<SetSpriteAsync>d__.uiSprite = uiSprite;
			<SetSpriteAsync>d__.setSize = setSize;
			<SetSpriteAsync>d__.<>1__state = -1;
			<SetSpriteAsync>d__.<>t__builder.Start<UiPanelBase.<SetSpriteAsync>d__158>(ref <SetSpriteAsync>d__);
			return <SetSpriteAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031462 RID: 201826 RVA: 0x00C44A80 File Offset: 0x00C42C80
		protected void SetTextureShowUntilLoaded([Nullable(1)] string path, UUITexture uiTexture, Action<bool> callback = null)
		{
			if (uiTexture == null)
			{
				return;
			}
			uiTexture.SetUIActive(false);
			this._uiImageSettingModule.SetTextureByPathAsync(path, uiTexture, delegate(bool result)
			{
				uiTexture.SetUIActive(true);
				if (callback != null)
				{
					callback(result);
				}
			});
		}

		// Token: 0x06031463 RID: 201827 RVA: 0x00C44AD4 File Offset: 0x00C42CD4
		[NullableContext(1)]
		protected void SetItemIcon(UUITexture texture, int itemId, EUiViewName? syncLoadViewName = null, [Nullable(2)] Action<bool> action = null)
		{
			if (syncLoadViewName != null)
			{
				this._uiImageSettingModule.SetItemIconSync(texture, itemId, syncLoadViewName.Value, action);
				return;
			}
			this._uiImageSettingModule.SetItemIconAsync(texture, itemId, action);
		}

		// Token: 0x06031464 RID: 201828 RVA: 0x00C44B08 File Offset: 0x00C42D08
		[NullableContext(1)]
		protected UniTask SetItemIconAsync(UUITexture texture, int itemId)
		{
			UiPanelBase.<SetItemIconAsync>d__161 <SetItemIconAsync>d__;
			<SetItemIconAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetItemIconAsync>d__.<>4__this = this;
			<SetItemIconAsync>d__.texture = texture;
			<SetItemIconAsync>d__.itemId = itemId;
			<SetItemIconAsync>d__.<>1__state = -1;
			<SetItemIconAsync>d__.<>t__builder.Start<UiPanelBase.<SetItemIconAsync>d__161>(ref <SetItemIconAsync>d__);
			return <SetItemIconAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031465 RID: 201829 RVA: 0x00C44B5C File Offset: 0x00C42D5C
		[NullableContext(1)]
		protected void SetQualityIconById(UUISprite sprite, int qualityId, EUiViewName? syncLoadViewName = null, CommonDefine.EQualityIconType? type = null, [Nullable(2)] Action<bool> action = null)
		{
			CommonDefine.EQualityIconType valueOrDefault = type.GetValueOrDefault();
			if (syncLoadViewName != null)
			{
				this._uiImageSettingModule.SetQualityIconByIdSync(sprite, qualityId, syncLoadViewName.Value, valueOrDefault, action);
				return;
			}
			this._uiImageSettingModule.SetQualityIconByIdAsync(sprite, qualityId, valueOrDefault, action);
		}

		// Token: 0x06031466 RID: 201830 RVA: 0x00C44BA2 File Offset: 0x00C42DA2
		[NullableContext(1)]
		protected void SetItemQualityIcon(UUISprite sprite, int itemId, EUiViewName? syncLoadViewName = null, CommonDefine.EQualityIconType type = CommonDefine.EQualityIconType.BackgroundSprite, [Nullable(2)] Action<bool> action = null)
		{
			if (syncLoadViewName != null)
			{
				this._uiImageSettingModule.SetItemQualityIconSync(sprite, itemId, syncLoadViewName.Value, type, action);
				return;
			}
			this._uiImageSettingModule.SetItemQualityIconAsync(sprite, itemId, type, action);
		}

		// Token: 0x06031467 RID: 201831 RVA: 0x00C44BD7 File Offset: 0x00C42DD7
		[NullableContext(1)]
		protected void SetRoleIcon(string path, UUITexture texture, int roleId, EUiViewName? syncLoadViewName = null, [Nullable(2)] Action<bool> callback = null)
		{
			if (syncLoadViewName != null)
			{
				this._uiImageSettingModule.SetRoleIconSync(path, texture, roleId, syncLoadViewName.Value, callback);
				return;
			}
			this._uiImageSettingModule.SetRoleIconAsync(path, texture, roleId, callback);
		}

		// Token: 0x06031468 RID: 201832 RVA: 0x00C44C0A File Offset: 0x00C42E0A
		[NullableContext(1)]
		protected void SetRoleSkinIcon(string path, UUITexture texture, int skinId, EUiViewName? syncLoadViewName = null, [Nullable(2)] Action<bool> callback = null)
		{
			if (syncLoadViewName != null)
			{
				this._uiImageSettingModule.SetRoleSkinIconSync(path, texture, skinId, syncLoadViewName.Value, callback);
				return;
			}
			this._uiImageSettingModule.SetRoleSkinIconAsync(path, texture, skinId, callback);
		}

		// Token: 0x06031469 RID: 201833 RVA: 0x00C44C40 File Offset: 0x00C42E40
		[NullableContext(1)]
		protected void SetRoleIconByRoleIdOrSkinId(string path, UUITexture texture, int roleId, int? skinId = null, [Nullable(2)] Action<bool> callback = null, EUiViewName? syncLoadViewName = null)
		{
			if (skinId != null)
			{
				int? num = skinId;
				int num2 = 0;
				if (!(num.GetValueOrDefault() <= num2 & num != null))
				{
					this.SetRoleSkinIcon(path, texture, skinId.Value, syncLoadViewName, callback);
					return;
				}
			}
			this.SetRoleIcon(path, texture, roleId, syncLoadViewName, callback);
		}

		// Token: 0x0603146A RID: 201834 RVA: 0x00C44C93 File Offset: 0x00C42E93
		[NullableContext(1)]
		protected void SetElementIcon(string path, UUITexture texture, int elementId, EUiViewName? syncLoadViewName = null)
		{
			if (syncLoadViewName != null)
			{
				this._uiImageSettingModule.SetElementIconSync(path, texture, elementId, syncLoadViewName.Value);
				return;
			}
			this._uiImageSettingModule.SetElementIcon(path, texture, elementId);
		}

		// Token: 0x0603146B RID: 201835 RVA: 0x00C44CC2 File Offset: 0x00C42EC2
		[NullableContext(1)]
		protected void SetMonsterIcon(string path, UUITexture texture, int monsterInfoId, EUiViewName? syncLoadViewName = null)
		{
			if (syncLoadViewName != null)
			{
				this._uiImageSettingModule.SetMonsterIconSync(path, texture, monsterInfoId, syncLoadViewName.Value);
				return;
			}
			this._uiImageSettingModule.SetMonsterIconAsync(path, texture, monsterInfoId);
		}

		// Token: 0x0603146C RID: 201836 RVA: 0x00C44CF1 File Offset: 0x00C42EF1
		[NullableContext(1)]
		protected void SetDungeonEntranceIconSync(string path, UUITexture texture, int entranceId, EUiViewName? syncLoadViewName = null)
		{
			if (syncLoadViewName != null)
			{
				this._uiImageSettingModule.SetDungeonEntranceIconSync(path, texture, entranceId, syncLoadViewName.Value);
				return;
			}
			this._uiImageSettingModule.SetDungeonEntranceIconAsync(path, texture, entranceId);
		}

		// Token: 0x0603146D RID: 201837 RVA: 0x00C44D20 File Offset: 0x00C42F20
		[NullableContext(1)]
		protected void SetNiagaraTextureByPath(string iconPath, UUINiagara niagara, string emitterName, string variableName, EUiViewName? syncLoadViewName = null, [Nullable(2)] Action<bool> callback = null)
		{
			if (syncLoadViewName != null)
			{
				this._uiImageSettingModule.SetNiagaraTextureSync(iconPath, niagara, emitterName, variableName, syncLoadViewName.Value, callback);
				return;
			}
			this._uiImageSettingModule.SetNiagaraTextureAsync(iconPath, niagara, emitterName, variableName, callback);
		}

		// Token: 0x0603146E RID: 201838 RVA: 0x00C44D57 File Offset: 0x00C42F57
		[NullableContext(1)]
		protected void SetNiagaraSystemByPath(string niagaraPath, UUINiagara niagara, [Nullable(2)] Action<bool> callback = null)
		{
			this._uiNiagaraSettingModule.SetNiagaraByPath(niagaraPath, niagara, callback);
		}

		// Token: 0x0603146F RID: 201839 RVA: 0x00C44D68 File Offset: 0x00C42F68
		[NullableContext(1)]
		protected UniTask SetNiagaraSystemByPathAsync(string niagaraPath, UUINiagara niagara)
		{
			UiPanelBase.<SetNiagaraSystemByPathAsync>d__172 <SetNiagaraSystemByPathAsync>d__;
			<SetNiagaraSystemByPathAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetNiagaraSystemByPathAsync>d__.<>4__this = this;
			<SetNiagaraSystemByPathAsync>d__.niagaraPath = niagaraPath;
			<SetNiagaraSystemByPathAsync>d__.niagara = niagara;
			<SetNiagaraSystemByPathAsync>d__.<>1__state = -1;
			<SetNiagaraSystemByPathAsync>d__.<>t__builder.Start<UiPanelBase.<SetNiagaraSystemByPathAsync>d__172>(ref <SetNiagaraSystemByPathAsync>d__);
			return <SetNiagaraSystemByPathAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031470 RID: 201840 RVA: 0x00C44DBC File Offset: 0x00C42FBC
		[NullableContext(1)]
		protected UniTask SetSpineAssetByPath(string atlasPath, string skeletonPath, USpineSkeletonAnimationComponent spine)
		{
			UiPanelBase.<SetSpineAssetByPath>d__173 <SetSpineAssetByPath>d__;
			<SetSpineAssetByPath>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetSpineAssetByPath>d__.<>4__this = this;
			<SetSpineAssetByPath>d__.atlasPath = atlasPath;
			<SetSpineAssetByPath>d__.skeletonPath = skeletonPath;
			<SetSpineAssetByPath>d__.spine = spine;
			<SetSpineAssetByPath>d__.<>1__state = -1;
			<SetSpineAssetByPath>d__.<>t__builder.Start<UiPanelBase.<SetSpineAssetByPath>d__173>(ref <SetSpineAssetByPath>d__);
			return <SetSpineAssetByPath>d__.<>t__builder.Task;
		}

		// Token: 0x06031471 RID: 201841 RVA: 0x00C44E17 File Offset: 0x00C43017
		private void ClearUiResourceLoadModule()
		{
			this._uiImageSettingModule.Clear();
			this._uiNiagaraSettingModule.Clear();
			this._uiSpineLoadModule.Clear();
		}

		// Token: 0x06031472 RID: 201842 RVA: 0x00C44E3C File Offset: 0x00C4303C
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<AActor> LoadPrefabAsync(string path, [Nullable(2)] UUIItem parent = null)
		{
			UiPanelBase.<LoadPrefabAsync>d__176 <LoadPrefabAsync>d__;
			<LoadPrefabAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<AActor>.Create();
			<LoadPrefabAsync>d__.<>4__this = this;
			<LoadPrefabAsync>d__.path = path;
			<LoadPrefabAsync>d__.parent = parent;
			<LoadPrefabAsync>d__.<>1__state = -1;
			<LoadPrefabAsync>d__.<>t__builder.Start<UiPanelBase.<LoadPrefabAsync>d__176>(ref <LoadPrefabAsync>d__);
			return <LoadPrefabAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031473 RID: 201843 RVA: 0x00C44E8F File Offset: 0x00C4308F
		protected void ClearUiPrefabLoadModule()
		{
			this._uiPrefabLoadModule.Clear();
		}

		// Token: 0x06031474 RID: 201844 RVA: 0x00C44E9C File Offset: 0x00C4309C
		[NullableContext(1)]
		protected UniTask RunAsyncTask(UiAsyncTask task)
		{
			UiPanelBase.<RunAsyncTask>d__179 <RunAsyncTask>d__;
			<RunAsyncTask>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunAsyncTask>d__.<>4__this = this;
			<RunAsyncTask>d__.task = task;
			<RunAsyncTask>d__.<>1__state = -1;
			<RunAsyncTask>d__.<>t__builder.Start<UiPanelBase.<RunAsyncTask>d__179>(ref <RunAsyncTask>d__);
			return <RunAsyncTask>d__.<>t__builder.Task;
		}

		// Token: 0x06031475 RID: 201845 RVA: 0x00C44EE7 File Offset: 0x00C430E7
		protected void CancelAllAsyncTask()
		{
			UiAsyncTaskManager taskManager = this.TaskManager;
			if (taskManager == null)
			{
				return;
			}
			taskManager.CancelAllTask();
		}

		// Token: 0x06031476 RID: 201846 RVA: 0x00C44EF9 File Offset: 0x00C430F9
		[NullableContext(1)]
		public void AddUiBehavior(IUiBehavior behavior)
		{
			this.AddUiBehaviorProxy(new UiBehaviorBaseProxy(behavior));
		}

		// Token: 0x06031477 RID: 201847 RVA: 0x00C44F07 File Offset: 0x00C43107
		[NullableContext(1)]
		public void AddUiBehaviorProxy(UiBehaviorBaseProxy proxy)
		{
			this.UiBehaviorProxies.Add(proxy);
		}

		// Token: 0x06031478 RID: 201848 RVA: 0x00C44F15 File Offset: 0x00C43115
		[NullableContext(1)]
		public void AddChild(UiPanelBase child)
		{
			this.Children.Add(child);
			child.Parent = this;
		}

		// Token: 0x06031479 RID: 201849 RVA: 0x00C44F2C File Offset: 0x00C4312C
		private void RemoveFromParent()
		{
			if (this.Parent == null)
			{
				return;
			}
			int num = this.Parent.Children.IndexOf(this);
			if (num < 0)
			{
				return;
			}
			this.Parent.Children.RemoveAt(num);
			this.Parent = null;
		}

		// Token: 0x0603147A RID: 201850 RVA: 0x00C44F74 File Offset: 0x00C43174
		public UiPanelBase GetLastChild()
		{
			int count = this.Children.Count;
			if (count == 0)
			{
				return null;
			}
			return this.Children[count - 1];
		}

		// Token: 0x0603147B RID: 201851 RVA: 0x00C44FA0 File Offset: 0x00C431A0
		public void Register()
		{
		}

		// Token: 0x0603147C RID: 201852 RVA: 0x00C44FA2 File Offset: 0x00C431A2
		protected void Begin()
		{
		}

		// Token: 0x0603147D RID: 201853 RVA: 0x00C44FA4 File Offset: 0x00C431A4
		protected virtual void OnBegin(object parameters = null)
		{
		}

		// Token: 0x0603147E RID: 201854 RVA: 0x00C44FA6 File Offset: 0x00C431A6
		protected virtual void OnChangeComponentActiveState(bool visibility)
		{
		}

		// Token: 0x0603147F RID: 201855 RVA: 0x00C44FA8 File Offset: 0x00C431A8
		protected virtual void OnRegister()
		{
		}

		// Token: 0x06031480 RID: 201856 RVA: 0x00C44FAA File Offset: 0x00C431AA
		protected virtual void OnCreate()
		{
		}

		// Token: 0x06031481 RID: 201857 RVA: 0x00C44FAC File Offset: 0x00C431AC
		protected virtual void OnShow()
		{
		}

		// Token: 0x06031482 RID: 201858 RVA: 0x00C44FAE File Offset: 0x00C431AE
		protected virtual void OnHide()
		{
		}

		// Token: 0x06031483 RID: 201859 RVA: 0x00C44FB0 File Offset: 0x00C431B0
		protected virtual void OnPrepareHide(bool inClose = false)
		{
		}

		// Token: 0x06031484 RID: 201860 RVA: 0x00C44FB2 File Offset: 0x00C431B2
		protected virtual void OnEnd()
		{
		}

		// Token: 0x06031485 RID: 201861 RVA: 0x00C44FB4 File Offset: 0x00C431B4
		protected virtual void OnDestroy()
		{
		}

		// Token: 0x06031486 RID: 201862 RVA: 0x00C44FB6 File Offset: 0x00C431B6
		protected virtual void OnStartSequenceFinish()
		{
		}

		// Token: 0x06031487 RID: 201863 RVA: 0x00C44FB8 File Offset: 0x00C431B8
		[NullableContext(1)]
		protected virtual void OnSequenceEvent(string sequenceName, string eventName)
		{
		}

		// Token: 0x06031488 RID: 201864 RVA: 0x00C44FBA File Offset: 0x00C431BA
		protected virtual bool OnPlayCloseSequence()
		{
			return false;
		}

		// Token: 0x06031489 RID: 201865 RVA: 0x00C44FBD File Offset: 0x00C431BD
		protected virtual void OnStackShow()
		{
		}

		// Token: 0x0603148A RID: 201866 RVA: 0x00C44FBF File Offset: 0x00C431BF
		protected virtual void OnShowSequenceFinish()
		{
		}

		// Token: 0x0603148B RID: 201867 RVA: 0x00C44FC1 File Offset: 0x00C431C1
		protected virtual void OnActiveSequenceFinish()
		{
		}

		// Token: 0x0603148C RID: 201868 RVA: 0x00C44FC3 File Offset: 0x00C431C3
		protected virtual bool OnCheckLoadSceneCondition()
		{
			return true;
		}

		// Token: 0x0603148D RID: 201869 RVA: 0x00C44FC6 File Offset: 0x00C431C6
		protected virtual bool OnCheckReleaseSceneCondition()
		{
			return true;
		}

		// Token: 0x0603148E RID: 201870 RVA: 0x00C44FC9 File Offset: 0x00C431C9
		public void Start()
		{
		}

		// Token: 0x0603148F RID: 201871 RVA: 0x00C44FCB File Offset: 0x00C431CB
		public void End()
		{
		}

		// Token: 0x06031490 RID: 201872 RVA: 0x00C44FCD File Offset: 0x00C431CD
		protected void InitParam()
		{
		}

		// Token: 0x06031491 RID: 201873 RVA: 0x00C44FCF File Offset: 0x00C431CF
		protected void InitComponentsData()
		{
		}

		// Token: 0x06031492 RID: 201874 RVA: 0x00C44FD1 File Offset: 0x00C431D1
		protected void OnClearComponentsData()
		{
		}

		// Token: 0x06031493 RID: 201875 RVA: 0x00C44FD3 File Offset: 0x00C431D3
		public void Create()
		{
		}

		// Token: 0x06031494 RID: 201876 RVA: 0x00C44FD5 File Offset: 0x00C431D5
		public bool ClearComponentsData()
		{
			base.Destroy(null);
			return true;
		}

		// Token: 0x06031495 RID: 201877 RVA: 0x00C44FE0 File Offset: 0x00C431E0
		[NullableContext(1)]
		public UniTask ConstructorAsync(string resourceId, UUIItem parentItem, bool usePool = false)
		{
			UiPanelBase.<ConstructorAsync>d__212 <ConstructorAsync>d__;
			<ConstructorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ConstructorAsync>d__.<>4__this = this;
			<ConstructorAsync>d__.resourceId = resourceId;
			<ConstructorAsync>d__.parentItem = parentItem;
			<ConstructorAsync>d__.usePool = usePool;
			<ConstructorAsync>d__.<>1__state = -1;
			<ConstructorAsync>d__.<>t__builder.Start<UiPanelBase.<ConstructorAsync>d__212>(ref <ConstructorAsync>d__);
			return <ConstructorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x17008406 RID: 33798
		// (get) Token: 0x06031496 RID: 201878 RVA: 0x00C4503B File Offset: 0x00C4323B
		// (set) Token: 0x06031497 RID: 201879 RVA: 0x00C45043 File Offset: 0x00C43243
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		protected List<ValueTuple<int, Type>> ComponentsRegisterInfo
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				return this.ComponentRegisterInfos;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.ComponentRegisterInfos = value;
			}
		}

		// Token: 0x06031498 RID: 201880 RVA: 0x00C4504C File Offset: 0x00C4324C
		[NullableContext(1)]
		public void SetRootActor(AActor actor, bool isBegin = true)
		{
			if (isBegin)
			{
				this.CreateThenShowByActor(actor, null);
				return;
			}
			this.CreateByActor(actor, null);
		}

		// Token: 0x06031499 RID: 201881 RVA: 0x00C45062 File Offset: 0x00C43262
		[NullableContext(1)]
		public void CreateThenShowByActor(AActor actor, [Nullable(2)] object parameters = null)
		{
			if (parameters != null)
			{
				this.OpenParam = parameters;
			}
			this.SetActor(actor);
			base.StartCompatible();
			base.ShowCompatible();
		}

		// Token: 0x0603149A RID: 201882 RVA: 0x00C45082 File Offset: 0x00C43282
		[NullableContext(1)]
		public void CreateByActor(AActor actor, [Nullable(2)] object parameters = null)
		{
			if (parameters != null)
			{
				this.OpenParam = parameters;
			}
			this.SetActor(actor);
			base.StartCompatible();
		}

		// Token: 0x0401C541 RID: 116033
		protected UUIItem RootItem;

		// Token: 0x0401C542 RID: 116034
		protected AUIBaseActor RootActor;

		// Token: 0x0401C543 RID: 116035
		private AUIBaseActor _originalActor;

		// Token: 0x0401C544 RID: 116036
		private UUIItem _originalItem;

		// Token: 0x0401C545 RID: 116037
		protected UUIItem ParentUiItem;

		// Token: 0x0401C546 RID: 116038
		protected bool UsePool;

		// Token: 0x0401C547 RID: 116039
		[Nullable(1)]
		protected string MemoryTag = "js_undefined";

		// Token: 0x0401C549 RID: 116041
		private bool _isPermanent;

		// Token: 0x0401C54A RID: 116042
		public object OpenParam;

		// Token: 0x0401C54B RID: 116043
		[Nullable(1)]
		private string _actorPath = "";

		// Token: 0x0401C54C RID: 116044
		[Nullable(1)]
		private readonly List<UiBehaviorBaseProxy> UiBehaviorProxies = new List<UiBehaviorBaseProxy>();

		// Token: 0x0401C54D RID: 116045
		[Nullable(1)]
		private readonly List<UiPanelBase> Children = new List<UiPanelBase>();

		// Token: 0x0401C54E RID: 116046
		public UiPanelBase Parent;

		// Token: 0x0401C54F RID: 116047
		[Nullable(1)]
		private readonly Dictionary<int, Tuple<Type, UActorComponent>> BaseComponentMap = new Dictionary<int, Tuple<Type, UActorComponent>>();

		// Token: 0x0401C550 RID: 116048
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<Type, Func<UClassStackOnlyPtr>> StaticClassGetters = new Dictionary<Type, Func<UClassStackOnlyPtr>>
		{
			{
				typeof(UUIItem),
				new Func<UClassStackOnlyPtr>(UUIItem.StaticClass)
			},
			{
				typeof(UUIText),
				new Func<UClassStackOnlyPtr>(UUIText.StaticClass)
			},
			{
				typeof(UUIArtText),
				new Func<UClassStackOnlyPtr>(UUIArtText.StaticClass)
			},
			{
				typeof(UUIButtonComponent),
				new Func<UClassStackOnlyPtr>(UUIButtonComponent.StaticClass)
			},
			{
				typeof(UUIToggleComponent),
				new Func<UClassStackOnlyPtr>(UUIToggleComponent.StaticClass)
			},
			{
				typeof(UUIExtendToggle),
				new Func<UClassStackOnlyPtr>(UUIExtendToggle.StaticClass)
			},
			{
				typeof(UUIExtendToggleGroup),
				new Func<UClassStackOnlyPtr>(UUIExtendToggleGroup.StaticClass)
			},
			{
				typeof(UUISliderComponent),
				new Func<UClassStackOnlyPtr>(UUISliderComponent.StaticClass)
			},
			{
				typeof(UUITextInputComponent),
				new Func<UClassStackOnlyPtr>(UUITextInputComponent.StaticClass)
			},
			{
				typeof(UUIDropdownComponent),
				new Func<UClassStackOnlyPtr>(UUIDropdownComponent.StaticClass)
			},
			{
				typeof(UUIDraggableComponent),
				new Func<UClassStackOnlyPtr>(UUIDraggableComponent.StaticClass)
			},
			{
				typeof(UUIScrollViewComponent),
				new Func<UClassStackOnlyPtr>(UUIScrollViewComponent.StaticClass)
			},
			{
				typeof(UUIScrollbarComponent),
				new Func<UClassStackOnlyPtr>(UUIScrollbarComponent.StaticClass)
			},
			{
				typeof(UUILoopScrollViewComponent),
				new Func<UClassStackOnlyPtr>(UUILoopScrollViewComponent.StaticClass)
			},
			{
				typeof(UUIMultiTemplateScrollViewComponent),
				new Func<UClassStackOnlyPtr>(UUIMultiTemplateScrollViewComponent.StaticClass)
			},
			{
				typeof(UUIDynScrollViewComponent),
				new Func<UClassStackOnlyPtr>(UUIDynScrollViewComponent.StaticClass)
			},
			{
				typeof(UUIScrollViewWithScrollbarComponent),
				new Func<UClassStackOnlyPtr>(UUIScrollViewWithScrollbarComponent.StaticClass)
			},
			{
				typeof(UUILayoutBase),
				new Func<UClassStackOnlyPtr>(UUILayoutBase.StaticClass)
			},
			{
				typeof(UUIVerticalLayout),
				new Func<UClassStackOnlyPtr>(UUIVerticalLayout.StaticClass)
			},
			{
				typeof(UUIHorizontalLayout),
				new Func<UClassStackOnlyPtr>(UUIHorizontalLayout.StaticClass)
			},
			{
				typeof(UUIGridLayout),
				new Func<UClassStackOnlyPtr>(UUIGridLayout.StaticClass)
			},
			{
				typeof(UUIMultiTemplateLayout),
				new Func<UClassStackOnlyPtr>(UUIMultiTemplateLayout.StaticClass)
			},
			{
				typeof(UUISizeControlByOther),
				new Func<UClassStackOnlyPtr>(UUISizeControlByOther.StaticClass)
			},
			{
				typeof(UUISprite),
				new Func<UClassStackOnlyPtr>(UUISprite.StaticClass)
			},
			{
				typeof(UUITexture),
				new Func<UClassStackOnlyPtr>(UUITexture.StaticClass)
			},
			{
				typeof(UUIExtendToggleSpriteTransition),
				new Func<UClassStackOnlyPtr>(UUIExtendToggleSpriteTransition.StaticClass)
			},
			{
				typeof(UUIExtendToggleTextureTransition),
				new Func<UClassStackOnlyPtr>(UUIExtendToggleTextureTransition.StaticClass)
			},
			{
				typeof(UUIExtendToggleTextTransition),
				new Func<UClassStackOnlyPtr>(UUIExtendToggleTextTransition.StaticClass)
			},
			{
				typeof(UUISpriteTransition),
				new Func<UClassStackOnlyPtr>(UUISpriteTransition.StaticClass)
			},
			{
				typeof(UUITextTransition),
				new Func<UClassStackOnlyPtr>(UUITextTransition.StaticClass)
			},
			{
				typeof(UUITextureTransitionComponent),
				new Func<UClassStackOnlyPtr>(UUITextureTransitionComponent.StaticClass)
			},
			{
				typeof(UUINiagara),
				new Func<UClassStackOnlyPtr>(UUINiagara.StaticClass)
			},
			{
				typeof(USpineSkeletonAnimationComponent),
				new Func<UClassStackOnlyPtr>(USpineSkeletonAnimationComponent.StaticClass)
			},
			{
				typeof(UUISelectableStateHolder),
				new Func<UClassStackOnlyPtr>(UUISelectableStateHolder.StaticClass)
			},
			{
				typeof(UUIInteractionGroup),
				new Func<UClassStackOnlyPtr>(UUIInteractionGroup.StaticClass)
			},
			{
				typeof(UUIDynamicBatchMesh),
				new Func<UClassStackOnlyPtr>(UUIDynamicBatchMesh.StaticClass)
			},
			{
				typeof(UUIInturnAnimController),
				new Func<UClassStackOnlyPtr>(UUIInturnAnimController.StaticClass)
			},
			{
				typeof(UUI2DLineRaw),
				new Func<UClassStackOnlyPtr>(UUI2DLineRaw.StaticClass)
			}
		};

		// Token: 0x0401C551 RID: 116049
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		protected List<ValueTuple<int, Type>> ComponentRegisterInfos = new List<ValueTuple<int, Type>>();

		// Token: 0x0401C552 RID: 116050
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		protected List<ValueTuple<int, Delegate>> BtnBindInfo = new List<ValueTuple<int, Delegate>>();

		// Token: 0x0401C553 RID: 116051
		private UGuideHookRegistry _guideRegistry;

		// Token: 0x0401C554 RID: 116052
		protected UiPoolActor UiPoolActorNew;

		// Token: 0x0401C555 RID: 116053
		[Nullable(1)]
		private readonly UiImageSettingModule _uiImageSettingModule = new UiImageSettingModule();

		// Token: 0x0401C556 RID: 116054
		[Nullable(1)]
		private readonly UiNiagaraSettingModule _uiNiagaraSettingModule = new UiNiagaraSettingModule();

		// Token: 0x0401C557 RID: 116055
		[Nullable(1)]
		private readonly UiSpineLoadModule _uiSpineLoadModule = new UiSpineLoadModule();

		// Token: 0x0401C558 RID: 116056
		[Nullable(1)]
		private readonly UiPrefabLoadModule _uiPrefabLoadModule = new UiPrefabLoadModule();

		// Token: 0x0401C559 RID: 116057
		protected UiAsyncTaskManager TaskManager;
	}
}
