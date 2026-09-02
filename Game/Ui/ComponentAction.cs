using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004995 RID: 18837
	public class ComponentAction
	{
		// Token: 0x170083E8 RID: 33768
		// (get) Token: 0x06031332 RID: 201522 RVA: 0x00C411B1 File Offset: 0x00C3F3B1
		private bool IsAsyncExecuting
		{
			get
			{
				return this.AsyncExecuteSet.Count > 0;
			}
		}

		// Token: 0x06031333 RID: 201523 RVA: 0x00C411C4 File Offset: 0x00C3F3C4
		public ComponentAction()
		{
			ComponentActionId instance = Singleton<ComponentActionId>.Instance;
			int num = instance.SelfIncrementId + 1;
			instance.SelfIncrementId = num;
			this.ComponentId = num;
		}

		// Token: 0x06031334 RID: 201524 RVA: 0x00C41226 File Offset: 0x00C3F426
		public static void SyncComponentId(int id)
		{
			Singleton<ComponentActionId>.Instance.SelfIncrementId = id;
		}

		// Token: 0x170083E9 RID: 33769
		// (get) Token: 0x06031335 RID: 201525 RVA: 0x00C41233 File Offset: 0x00C3F433
		public bool IsRegister
		{
			get
			{
				return this.ComponentState == EComponentState.Register;
			}
		}

		// Token: 0x170083EA RID: 33770
		// (get) Token: 0x06031336 RID: 201526 RVA: 0x00C4123E File Offset: 0x00C3F43E
		public bool IsCreating
		{
			get
			{
				return this.ComponentState == EComponentState.Creating;
			}
		}

		// Token: 0x170083EB RID: 33771
		// (get) Token: 0x06031337 RID: 201527 RVA: 0x00C41249 File Offset: 0x00C3F449
		public bool IsCreate
		{
			get
			{
				return this.ComponentState == EComponentState.Create;
			}
		}

		// Token: 0x170083EC RID: 33772
		// (get) Token: 0x06031338 RID: 201528 RVA: 0x00C41254 File Offset: 0x00C3F454
		public bool IsCreateOrCreating
		{
			get
			{
				return this.IsCreating || this.IsCreate;
			}
		}

		// Token: 0x170083ED RID: 33773
		// (get) Token: 0x06031339 RID: 201529 RVA: 0x00C41266 File Offset: 0x00C3F466
		public bool IsStarting
		{
			get
			{
				return this.ComponentState == EComponentState.Starting;
			}
		}

		// Token: 0x170083EE RID: 33774
		// (get) Token: 0x0603133A RID: 201530 RVA: 0x00C41271 File Offset: 0x00C3F471
		public bool IsStart
		{
			get
			{
				return this.ComponentState == EComponentState.Start;
			}
		}

		// Token: 0x170083EF RID: 33775
		// (get) Token: 0x0603133B RID: 201531 RVA: 0x00C4127C File Offset: 0x00C3F47C
		public bool IsStartOrStarting
		{
			get
			{
				return this.IsStarting || this.IsStart;
			}
		}

		// Token: 0x170083F0 RID: 33776
		// (get) Token: 0x0603133C RID: 201532 RVA: 0x00C4128E File Offset: 0x00C3F48E
		public bool IsShowing
		{
			get
			{
				return this.ComponentState == EComponentState.Showing;
			}
		}

		// Token: 0x170083F1 RID: 33777
		// (get) Token: 0x0603133D RID: 201533 RVA: 0x00C41299 File Offset: 0x00C3F499
		public bool IsShow
		{
			get
			{
				return this.ComponentState == EComponentState.Show;
			}
		}

		// Token: 0x170083F2 RID: 33778
		// (get) Token: 0x0603133E RID: 201534 RVA: 0x00C412A4 File Offset: 0x00C3F4A4
		public bool IsShowOrShowing
		{
			get
			{
				return this.IsShowing || this.IsShow;
			}
		}

		// Token: 0x170083F3 RID: 33779
		// (get) Token: 0x0603133F RID: 201535 RVA: 0x00C412B6 File Offset: 0x00C3F4B6
		public bool IsHiding
		{
			get
			{
				return this.ComponentState == EComponentState.Hiding;
			}
		}

		// Token: 0x170083F4 RID: 33780
		// (get) Token: 0x06031340 RID: 201536 RVA: 0x00C412C1 File Offset: 0x00C3F4C1
		public bool IsHide
		{
			get
			{
				return this.ComponentState == EComponentState.Hide;
			}
		}

		// Token: 0x170083F5 RID: 33781
		// (get) Token: 0x06031341 RID: 201537 RVA: 0x00C412CC File Offset: 0x00C3F4CC
		public bool IsHideOrHiding
		{
			get
			{
				return this.IsHiding || this.IsHide;
			}
		}

		// Token: 0x170083F6 RID: 33782
		// (get) Token: 0x06031342 RID: 201538 RVA: 0x00C412DE File Offset: 0x00C3F4DE
		public bool IsDestroying
		{
			get
			{
				return this.ComponentState == EComponentState.Destroying;
			}
		}

		// Token: 0x170083F7 RID: 33783
		// (get) Token: 0x06031343 RID: 201539 RVA: 0x00C412EA File Offset: 0x00C3F4EA
		public bool IsDestroy
		{
			get
			{
				return this.ComponentState == EComponentState.Destroy;
			}
		}

		// Token: 0x170083F8 RID: 33784
		// (get) Token: 0x06031344 RID: 201540 RVA: 0x00C412F6 File Offset: 0x00C3F4F6
		public bool IsDestroyOrDestroying
		{
			get
			{
				return this.IsDestroy || this.IsDestroying;
			}
		}

		// Token: 0x170083F9 RID: 33785
		// (get) Token: 0x06031345 RID: 201541 RVA: 0x00C41308 File Offset: 0x00C3F508
		public bool IsBusy
		{
			get
			{
				return this.IsCreating || this.IsStarting || this.IsShowing || this.IsHiding || this.IsDestroying || this.IsAsyncExecuting;
			}
		}

		// Token: 0x170083FA RID: 33786
		// (get) Token: 0x06031346 RID: 201542 RVA: 0x00C4133C File Offset: 0x00C3F53C
		public bool IsPendingDestroy
		{
			get
			{
				for (LinkedNode<ActionCommandNode> linkedNode = this.ActionLinkedList.GetHeadNextNode(); linkedNode != null; linkedNode = linkedNode.Next)
				{
					if (linkedNode.Element.ActionCommand == EActionCommandType.Destroy && !linkedNode.Element.Processed)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x06031347 RID: 201543 RVA: 0x00C41380 File Offset: 0x00C3F580
		public UniTask<bool> CreateAsync()
		{
			ComponentAction.<CreateAsync>d__47 <CreateAsync>d__;
			<CreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CreateAsync>d__.<>4__this = this;
			<CreateAsync>d__.<>1__state = -1;
			<CreateAsync>d__.<>t__builder.Start<ComponentAction.<CreateAsync>d__47>(ref <CreateAsync>d__);
			return <CreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031348 RID: 201544 RVA: 0x00C413C4 File Offset: 0x00C3F5C4
		public UniTask<bool> StartAsync()
		{
			ComponentAction.<StartAsync>d__48 <StartAsync>d__;
			<StartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<StartAsync>d__.<>4__this = this;
			<StartAsync>d__.<>1__state = -1;
			<StartAsync>d__.<>t__builder.Start<ComponentAction.<StartAsync>d__48>(ref <StartAsync>d__);
			return <StartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031349 RID: 201545 RVA: 0x00C41408 File Offset: 0x00C3F608
		private UniTask<bool> StartAsyncImplement()
		{
			ComponentAction.<StartAsyncImplement>d__49 <StartAsyncImplement>d__;
			<StartAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<StartAsyncImplement>d__.<>4__this = this;
			<StartAsyncImplement>d__.<>1__state = -1;
			<StartAsyncImplement>d__.<>t__builder.Start<ComponentAction.<StartAsyncImplement>d__49>(ref <StartAsyncImplement>d__);
			return <StartAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603134A RID: 201546 RVA: 0x00C4144C File Offset: 0x00C3F64C
		public UniTask<bool> ShowAsync()
		{
			ComponentAction.<ShowAsync>d__50 <ShowAsync>d__;
			<ShowAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ShowAsync>d__.<>4__this = this;
			<ShowAsync>d__.<>1__state = -1;
			<ShowAsync>d__.<>t__builder.Start<ComponentAction.<ShowAsync>d__50>(ref <ShowAsync>d__);
			return <ShowAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603134B RID: 201547 RVA: 0x00C41490 File Offset: 0x00C3F690
		private UniTask<bool> ShowAsyncImplement()
		{
			ComponentAction.<ShowAsyncImplement>d__51 <ShowAsyncImplement>d__;
			<ShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ShowAsyncImplement>d__.<>4__this = this;
			<ShowAsyncImplement>d__.<>1__state = -1;
			<ShowAsyncImplement>d__.<>t__builder.Start<ComponentAction.<ShowAsyncImplement>d__51>(ref <ShowAsyncImplement>d__);
			return <ShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603134C RID: 201548 RVA: 0x00C414D4 File Offset: 0x00C3F6D4
		public UniTask<bool> HideAsync()
		{
			ComponentAction.<HideAsync>d__52 <HideAsync>d__;
			<HideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<HideAsync>d__.<>4__this = this;
			<HideAsync>d__.<>1__state = -1;
			<HideAsync>d__.<>t__builder.Start<ComponentAction.<HideAsync>d__52>(ref <HideAsync>d__);
			return <HideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603134D RID: 201549 RVA: 0x00C41518 File Offset: 0x00C3F718
		private UniTask<bool> HideAsyncImplement()
		{
			ComponentAction.<HideAsyncImplement>d__53 <HideAsyncImplement>d__;
			<HideAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<HideAsyncImplement>d__.<>4__this = this;
			<HideAsyncImplement>d__.<>1__state = -1;
			<HideAsyncImplement>d__.<>t__builder.Start<ComponentAction.<HideAsyncImplement>d__53>(ref <HideAsyncImplement>d__);
			return <HideAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603134E RID: 201550 RVA: 0x00C4155C File Offset: 0x00C3F75C
		public UniTask<bool> DestroyAsync()
		{
			ComponentAction.<DestroyAsync>d__54 <DestroyAsync>d__;
			<DestroyAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DestroyAsync>d__.<>4__this = this;
			<DestroyAsync>d__.<>1__state = -1;
			<DestroyAsync>d__.<>t__builder.Start<ComponentAction.<DestroyAsync>d__54>(ref <DestroyAsync>d__);
			return <DestroyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603134F RID: 201551 RVA: 0x00C415A0 File Offset: 0x00C3F7A0
		public virtual UniTask<bool> CloseMeAsync()
		{
			ComponentAction.<CloseMeAsync>d__55 <CloseMeAsync>d__;
			<CloseMeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CloseMeAsync>d__.<>4__this = this;
			<CloseMeAsync>d__.<>1__state = -1;
			<CloseMeAsync>d__.<>t__builder.Start<ComponentAction.<CloseMeAsync>d__55>(ref <CloseMeAsync>d__);
			return <CloseMeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031350 RID: 201552 RVA: 0x00C415E4 File Offset: 0x00C3F7E4
		private UniTask<bool> DestroyAsyncImplement()
		{
			ComponentAction.<DestroyAsyncImplement>d__56 <DestroyAsyncImplement>d__;
			<DestroyAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DestroyAsyncImplement>d__.<>4__this = this;
			<DestroyAsyncImplement>d__.<>1__state = -1;
			<DestroyAsyncImplement>d__.<>t__builder.Start<ComponentAction.<DestroyAsyncImplement>d__56>(ref <DestroyAsyncImplement>d__);
			return <DestroyAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06031351 RID: 201553 RVA: 0x00C41628 File Offset: 0x00C3F828
		[NullableContext(2)]
		public void Show(Action callback = null)
		{
			this.ShowAsync().ContinueWith(delegate(bool task)
			{
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			});
		}

		// Token: 0x06031352 RID: 201554 RVA: 0x00C4165C File Offset: 0x00C3F85C
		[NullableContext(2)]
		public void Hide(Action callback = null)
		{
			this.HideAsync().ContinueWith(delegate(bool task)
			{
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			});
		}

		// Token: 0x06031353 RID: 201555 RVA: 0x00C41690 File Offset: 0x00C3F890
		[NullableContext(2)]
		public void Destroy(Action callback = null)
		{
			this.DestroyAsync().ContinueWith(delegate(bool task)
			{
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			});
		}

		// Token: 0x06031354 RID: 201556 RVA: 0x00C416C4 File Offset: 0x00C3F8C4
		protected virtual UniTask<bool> OnCreateAsyncImplement()
		{
			ComponentAction.<OnCreateAsyncImplement>d__60 <OnCreateAsyncImplement>d__;
			<OnCreateAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnCreateAsyncImplement>d__.<>1__state = -1;
			<OnCreateAsyncImplement>d__.<>t__builder.Start<ComponentAction.<OnCreateAsyncImplement>d__60>(ref <OnCreateAsyncImplement>d__);
			return <OnCreateAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06031355 RID: 201557 RVA: 0x00C416FF File Offset: 0x00C3F8FF
		protected virtual UniTask OnStartAsyncImplement()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06031356 RID: 201558 RVA: 0x00C41706 File Offset: 0x00C3F906
		protected virtual UniTask OnShowAsyncImplement()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06031357 RID: 201559 RVA: 0x00C4170D File Offset: 0x00C3F90D
		protected virtual void OnFinishShow()
		{
		}

		// Token: 0x06031358 RID: 201560 RVA: 0x00C4170F File Offset: 0x00C3F90F
		protected virtual UniTask OnHideAsyncImplement()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06031359 RID: 201561 RVA: 0x00C41716 File Offset: 0x00C3F916
		protected virtual UniTask OnDestroyAsyncImplement()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0603135A RID: 201562 RVA: 0x00C41720 File Offset: 0x00C3F920
		private static bool IsPair(EActionCommandType? actionTypeA, EActionCommandType? actionTypeB)
		{
			EActionCommandType? eactionCommandType = actionTypeA;
			EActionCommandType? eactionCommandType2 = actionTypeB;
			return (eactionCommandType.GetValueOrDefault() == eactionCommandType2.GetValueOrDefault() & eactionCommandType != null == (eactionCommandType2 != null)) || (actionTypeA.GetValueOrDefault() == EActionCommandType.Show && actionTypeB.GetValueOrDefault() == EActionCommandType.Hide) || (actionTypeA.GetValueOrDefault() == EActionCommandType.Hide && actionTypeB.GetValueOrDefault() == EActionCommandType.Show);
		}

		// Token: 0x0603135B RID: 201563 RVA: 0x00C41780 File Offset: 0x00C3F980
		private EActionCommandType GetCurrentActionType()
		{
			switch (this.ComponentState)
			{
			case EComponentState.Starting:
			case EComponentState.Start:
				return EActionCommandType.Start;
			case EComponentState.Showing:
			case EComponentState.Show:
				return EActionCommandType.Show;
			case EComponentState.Hiding:
			case EComponentState.Hide:
				return EActionCommandType.Hide;
			case EComponentState.Destroying:
			case EComponentState.Destroy:
				return EActionCommandType.Destroy;
			default:
				return EActionCommandType.Default;
			}
		}

		// Token: 0x0603135C RID: 201564 RVA: 0x00C417C7 File Offset: 0x00C3F9C7
		private void HandleCacheActionFailIfIsPair(EActionCommandType actionTypeA, EActionCommandType actionTypeB)
		{
			if (actionTypeA == actionTypeB)
			{
				return;
			}
			if (actionTypeB == EActionCommandType.Show)
			{
				this.HandleCacheShowActionFailIfIsPair();
			}
		}

		// Token: 0x0603135D RID: 201565 RVA: 0x00C417D8 File Offset: 0x00C3F9D8
		private bool TryCacheAction(EActionCommandType actionType)
		{
			if (!ComponentAction.SwitchCheckSameTypeLogic && this.GetCurrentActionType() == actionType)
			{
				return false;
			}
			LinkedNode<ActionCommandNode> tailNode = this.ActionLinkedList.TailNode;
			EActionCommandType actionCommand = tailNode.Element.ActionCommand;
			if (actionCommand == actionType)
			{
				return false;
			}
			if (actionCommand == EActionCommandType.Destroy)
			{
				return false;
			}
			if (ComponentAction.IsPair(new EActionCommandType?(actionCommand), new EActionCommandType?(actionType)))
			{
				this.HandleCacheActionFailIfIsPair(actionCommand, actionType);
				this.ActionLinkedList.RemoveNode(tailNode);
				return false;
			}
			if (ComponentAction.SwitchCheckSameTypeLogic && this.GetCurrentActionType() == actionType)
			{
				return false;
			}
			ActionCommandNode newElement = new ActionCommandNode
			{
				ActionCommand = actionType,
				Processed = false
			};
			this.ActionLinkedList.AddTail(newElement);
			return true;
		}

		// Token: 0x0603135E RID: 201566 RVA: 0x00C41878 File Offset: 0x00C3FA78
		private UniTask ExecuteCachedActions()
		{
			ComponentAction.<ExecuteCachedActions>d__71 <ExecuteCachedActions>d__;
			<ExecuteCachedActions>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteCachedActions>d__.<>4__this = this;
			<ExecuteCachedActions>d__.<>1__state = -1;
			<ExecuteCachedActions>d__.<>t__builder.Start<ComponentAction.<ExecuteCachedActions>d__71>(ref <ExecuteCachedActions>d__);
			return <ExecuteCachedActions>d__.<>t__builder.Task;
		}

		// Token: 0x0603135F RID: 201567 RVA: 0x00C418BB File Offset: 0x00C3FABB
		protected virtual void HandleCacheShowActionFailIfIsPair()
		{
		}

		// Token: 0x06031360 RID: 201568 RVA: 0x00C418BD File Offset: 0x00C3FABD
		protected virtual void OnStartImplementCompatible()
		{
		}

		// Token: 0x06031361 RID: 201569 RVA: 0x00C418BF File Offset: 0x00C3FABF
		protected virtual void OnShowImplementCompatible()
		{
		}

		// Token: 0x06031362 RID: 201570 RVA: 0x00C418C1 File Offset: 0x00C3FAC1
		protected virtual void OnHideImplementCompatible()
		{
		}

		// Token: 0x06031363 RID: 201571 RVA: 0x00C418C3 File Offset: 0x00C3FAC3
		protected virtual void OnDestroyImplementCompatible()
		{
		}

		// Token: 0x06031364 RID: 201572 RVA: 0x00C418C5 File Offset: 0x00C3FAC5
		public void StartCompatible()
		{
			this.ComponentState = EComponentState.Starting;
			this.OnStartImplementCompatible();
			this.ComponentState = EComponentState.Start;
		}

		// Token: 0x06031365 RID: 201573 RVA: 0x00C418DB File Offset: 0x00C3FADB
		public void ShowCompatible()
		{
			this.ComponentState = EComponentState.Showing;
			this.OnShowImplementCompatible();
			this.ComponentState = EComponentState.Show;
		}

		// Token: 0x06031366 RID: 201574 RVA: 0x00C418F1 File Offset: 0x00C3FAF1
		public void HideCompatible()
		{
			this.ComponentState = EComponentState.Hiding;
			this.OnHideImplementCompatible();
			this.ComponentState = EComponentState.Hide;
		}

		// Token: 0x06031367 RID: 201575 RVA: 0x00C41907 File Offset: 0x00C3FB07
		public void DestroyCompatible()
		{
			if (this.IsShowOrShowing)
			{
				this.HideCompatible();
			}
			this.ComponentState = EComponentState.Destroying;
			this.OnDestroyImplementCompatible();
			this.ComponentState = EComponentState.Destroy;
			this.DeadPromise.SetResult();
		}

		// Token: 0x0401C50B RID: 115979
		[StaticVariableRuleIgnore]
		public static bool OpenLog = true;

		// Token: 0x0401C50C RID: 115980
		[StaticVariableRuleIgnore]
		public static bool SwitchCheckSameTypeLogic = true;

		// Token: 0x0401C50D RID: 115981
		public int ComponentId;

		// Token: 0x0401C50E RID: 115982
		private EComponentState ComponentState;

		// Token: 0x0401C50F RID: 115983
		public bool WaitToDestroy;

		// Token: 0x0401C510 RID: 115984
		[Nullable(1)]
		public CustomPromise DeadPromise = new CustomPromise();

		// Token: 0x0401C511 RID: 115985
		[Nullable(1)]
		private HashSet<EComponentState> AsyncExecuteSet = new HashSet<EComponentState>();

		// Token: 0x0401C512 RID: 115986
		[Nullable(1)]
		private readonly global::LinkedList<ActionCommandNode> ActionLinkedList = new global::LinkedList<ActionCommandNode>(new ActionCommandNode
		{
			ActionCommand = EActionCommandType.Default,
			Processed = true
		});
	}
}
