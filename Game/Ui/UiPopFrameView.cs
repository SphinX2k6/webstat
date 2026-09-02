using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049AE RID: 18862
	[NullableContext(1)]
	[Nullable(0)]
	public class UiPopFrameView : UiPanelBase, IUiPopFrameInterface
	{
		// Token: 0x17008408 RID: 33800
		// (get) Token: 0x060314AB RID: 201899 RVA: 0x00C454ED File Offset: 0x00C436ED
		// (set) Token: 0x060314AC RID: 201900 RVA: 0x00C454F5 File Offset: 0x00C436F5
		public CommonPopViewBase PopItem { get; set; }

		// Token: 0x060314AD RID: 201901 RVA: 0x00C454FE File Offset: 0x00C436FE
		public UiPopFrameView(UiViewInfo viewInfo)
		{
			this.ParentViewInfo = viewInfo;
		}

		// Token: 0x060314AE RID: 201902 RVA: 0x00C45510 File Offset: 0x00C43710
		protected override void OnBeforeCreate()
		{
			UiPopFrameViewInfo uiBehaviourPopInfo = Singleton<UiPopFrameViewStorage>.Instance.GetUiBehaviourPopInfo((int)this.ParentViewInfo.CommonPopBg);
			if (uiBehaviourPopInfo == null)
			{
				return;
			}
			string resourceId = uiBehaviourPopInfo.ResourceId;
			this.PopItem = uiBehaviourPopInfo.Ctor();
			base.SetRootActorLoadInfo(resourceId, Singleton<UiLayer>.Instance.GetLayerRootUiItem(this.ParentViewInfo.Type), false, false);
		}

		// Token: 0x060314AF RID: 201903 RVA: 0x00C45570 File Offset: 0x00C43770
		protected override UniTask OnBeforeHideAsync()
		{
			UiPopFrameView.<OnBeforeHideAsync>d__8 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<UiPopFrameView.<OnBeforeHideAsync>d__8>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060314B0 RID: 201904 RVA: 0x00C455B4 File Offset: 0x00C437B4
		protected override UniTask OnBeforeStartAsync()
		{
			UiPopFrameView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<UiPopFrameView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060314B1 RID: 201905 RVA: 0x00C455F8 File Offset: 0x00C437F8
		protected override UniTask OnShowAsyncImplementImplement()
		{
			UiPopFrameView.<OnShowAsyncImplementImplement>d__10 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<UiPopFrameView.<OnShowAsyncImplementImplement>d__10>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x060314B2 RID: 201906 RVA: 0x00C4563B File Offset: 0x00C4383B
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x060314B3 RID: 201907 RVA: 0x00C45640 File Offset: 0x00C43840
		protected override void OnAutoDestroy()
		{
			Singleton<Log>.Instance.Info(ELogModule.UiCommon, ELogAuthor.XXJ, "UiPopFrameView执行自动销毁", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.SequencePlayer.Clear();
		}

		// Token: 0x060314B4 RID: 201908 RVA: 0x00C45674 File Offset: 0x00C43874
		public void SetCloseBtnInteractive(bool state)
		{
			this.PopItem.SetCloseBtnInteractive(state);
		}

		// Token: 0x060314B5 RID: 201909 RVA: 0x00C45682 File Offset: 0x00C43882
		public void SetTitleByTextIdAndArg(string textId, params object[] args)
		{
			this.PopItem.SetTitleByTextIdAndArg(textId, args);
		}

		// Token: 0x060314B6 RID: 201910 RVA: 0x00C45691 File Offset: 0x00C43891
		public void SetBackBtnShowState(bool state)
		{
			this.PopItem.SetBackBtnShowState(state);
		}

		// Token: 0x060314B7 RID: 201911 RVA: 0x00C4569F File Offset: 0x00C4389F
		public AActor GetPopViewRootActor()
		{
			return base.GetRootActor();
		}

		// Token: 0x060314B8 RID: 201912 RVA: 0x00C456A7 File Offset: 0x00C438A7
		public UUIItem GetPopViewRootItem()
		{
			return base.GetRootItem();
		}

		// Token: 0x060314B9 RID: 201913 RVA: 0x00C456AF File Offset: 0x00C438AF
		public AActor GetPopViewOriginalActor()
		{
			return base.GetOriginalActor();
		}

		// Token: 0x060314BA RID: 201914 RVA: 0x00C456B7 File Offset: 0x00C438B7
		public void HidePopView()
		{
			base.Hide(null);
		}

		// Token: 0x060314BB RID: 201915 RVA: 0x00C456C0 File Offset: 0x00C438C0
		public void ShowPopView()
		{
			base.Show(null);
		}

		// Token: 0x060314BC RID: 201916 RVA: 0x00C456C9 File Offset: 0x00C438C9
		public void SetViewPermanent()
		{
			Singleton<LguiUtil>.Instance.SetActorIsPermanent(base.GetOriginalActor(), true, true);
		}

		// Token: 0x060314BD RID: 201917 RVA: 0x00C456E0 File Offset: 0x00C438E0
		public void PlayLevelSequenceByName(string sequenceName, bool blockClick = false)
		{
			this.SequencePlayer.PlaySequence(sequenceName, blockClick, null);
		}

		// Token: 0x060314BE RID: 201918 RVA: 0x00C45704 File Offset: 0x00C43904
		public UniTask PlaySequenceAsync(string sequenceName, CustomPromise<bool> stopPromise, bool blockClick = false, bool playReverse = false)
		{
			UiPopFrameView.<PlaySequenceAsync>d__23 <PlaySequenceAsync>d__;
			<PlaySequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySequenceAsync>d__.<>4__this = this;
			<PlaySequenceAsync>d__.sequenceName = sequenceName;
			<PlaySequenceAsync>d__.stopPromise = stopPromise;
			<PlaySequenceAsync>d__.blockClick = blockClick;
			<PlaySequenceAsync>d__.playReverse = playReverse;
			<PlaySequenceAsync>d__.<>1__state = -1;
			<PlaySequenceAsync>d__.<>t__builder.Start<UiPopFrameView.<PlaySequenceAsync>d__23>(ref <PlaySequenceAsync>d__);
			return <PlaySequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060314BF RID: 201919 RVA: 0x00C45768 File Offset: 0x00C43968
		public Action GetCloseCallback()
		{
			return null;
		}

		// Token: 0x060314C0 RID: 201920 RVA: 0x00C4576B File Offset: 0x00C4396B
		public void SetCloseCallback(Action callback)
		{
		}

		// Token: 0x060314C1 RID: 201921 RVA: 0x00C4576D File Offset: 0x00C4396D
		public void AddButtonClickEvent(string btnName, Action callback)
		{
		}

		// Token: 0x060314C2 RID: 201922 RVA: 0x00C4576F File Offset: 0x00C4396F
		public void HidePopFrame()
		{
			this.HidePopView();
		}

		// Token: 0x17008409 RID: 33801
		// (get) Token: 0x060314C3 RID: 201923 RVA: 0x00C45777 File Offset: 0x00C43977
		public int PopFrameId
		{
			get
			{
				return this.ComponentId;
			}
		}

		// Token: 0x0401C55B RID: 116059
		private readonly UiViewInfo ParentViewInfo;

		// Token: 0x0401C55C RID: 116060
		private UiSequencePlayer SequencePlayer;
	}
}
