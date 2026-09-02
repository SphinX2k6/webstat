using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FB5 RID: 24501
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleChildView : UiPanelBase
	{
		// Token: 0x0603D9B4 RID: 252340 RVA: 0x00FB2190 File Offset: 0x00FB0390
		public UniTask NewByResourceId(UUIItem parentItem, string resourceId, bool bFromPool = false, [Nullable(2)] object param = null)
		{
			BattleChildView.<NewByResourceId>d__0 <NewByResourceId>d__;
			<NewByResourceId>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewByResourceId>d__.<>4__this = this;
			<NewByResourceId>d__.parentItem = parentItem;
			<NewByResourceId>d__.resourceId = resourceId;
			<NewByResourceId>d__.bFromPool = bFromPool;
			<NewByResourceId>d__.param = param;
			<NewByResourceId>d__.<>1__state = -1;
			<NewByResourceId>d__.<>t__builder.Start<BattleChildView.<NewByResourceId>d__0>(ref <NewByResourceId>d__);
			return <NewByResourceId>d__.<>t__builder.Task;
		}

		// Token: 0x0603D9B5 RID: 252341 RVA: 0x00FB21F4 File Offset: 0x00FB03F4
		public UniTask NewByRootActorAsync(AActor rootActor, [Nullable(2)] object param = null)
		{
			BattleChildView.<NewByRootActorAsync>d__1 <NewByRootActorAsync>d__;
			<NewByRootActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewByRootActorAsync>d__.<>4__this = this;
			<NewByRootActorAsync>d__.rootActor = rootActor;
			<NewByRootActorAsync>d__.param = param;
			<NewByRootActorAsync>d__.<>1__state = -1;
			<NewByRootActorAsync>d__.<>t__builder.Start<BattleChildView.<NewByRootActorAsync>d__1>(ref <NewByRootActorAsync>d__);
			return <NewByRootActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D9B6 RID: 252342 RVA: 0x00FB2247 File Offset: 0x00FB0447
		[NullableContext(2)]
		public virtual void Initialize(object param = null)
		{
		}

		// Token: 0x0603D9B7 RID: 252343 RVA: 0x00FB2249 File Offset: 0x00FB0449
		[NullableContext(2)]
		protected virtual UniTask InitializeAsync(object param = null)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0603D9B8 RID: 252344 RVA: 0x00FB2250 File Offset: 0x00FB0450
		public virtual void Reset()
		{
		}

		// Token: 0x0603D9B9 RID: 252345 RVA: 0x00FB2252 File Offset: 0x00FB0452
		protected sealed override void OnAfterShowImplement()
		{
			this.OnShowBattleChildView();
		}

		// Token: 0x0603D9BA RID: 252346 RVA: 0x00FB225A File Offset: 0x00FB045A
		protected sealed override void OnBeforeHideImplement()
		{
			this.OnHideBattleChildView();
		}

		// Token: 0x0603D9BB RID: 252347 RVA: 0x00FB2262 File Offset: 0x00FB0462
		protected virtual void OnShowBattleChildView()
		{
		}

		// Token: 0x0603D9BC RID: 252348 RVA: 0x00FB2264 File Offset: 0x00FB0464
		protected virtual void OnHideBattleChildView()
		{
		}

		// Token: 0x0603D9BD RID: 252349 RVA: 0x00FB2266 File Offset: 0x00FB0466
		protected virtual void OnBeforeDestroyImplementImplement()
		{
		}

		// Token: 0x0603D9BE RID: 252350 RVA: 0x00FB2268 File Offset: 0x00FB0468
		protected sealed override void OnBeforeDestroyImplement()
		{
			this.OnBeforeDestroyImplementImplement();
			this.Reset();
		}
	}
}
