using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.Container;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles;
using CSharpScript.Game.Module.Map.Misc;
using CSharpScript.Game.Module.WorldMap;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005877 RID: 22647
	[NullableContext(1)]
	[Nullable(0)]
	public class MarkItemView : MarkPanelBase
	{
		// Token: 0x170092F2 RID: 37618
		// (get) Token: 0x0603992C RID: 235820 RVA: 0x00E9B333 File Offset: 0x00E99533
		protected MarkItemTopRightIconHandle MarkItemTopRightIconHandle
		{
			get
			{
				return this.MarkItemComponentHandleMap.GetValueOrDefault(EMarkViewComponentType.TopRightIcon) as MarkItemTopRightIconHandle;
			}
		}

		// Token: 0x170092F3 RID: 37619
		// (get) Token: 0x0603992D RID: 235821 RVA: 0x00E9B346 File Offset: 0x00E99546
		protected IMarkItemRangeHandle MarkItemRangeHandle
		{
			get
			{
				return this.MarkItemComponentHandleMap.GetValueOrDefault(EMarkViewComponentType.Range) as IMarkItemRangeHandle;
			}
		}

		// Token: 0x170092F4 RID: 37620
		// (get) Token: 0x0603992E RID: 235822 RVA: 0x00E9B359 File Offset: 0x00E99559
		protected MarkItemNameHandle MarkItemNameHandle
		{
			get
			{
				return (MarkItemNameHandle)this.MarkItemComponentHandleMap.GetValueOrDefault(EMarkViewComponentType.Name);
			}
		}

		// Token: 0x170092F5 RID: 37621
		// (get) Token: 0x0603992F RID: 235823 RVA: 0x00E9B36C File Offset: 0x00E9956C
		protected MarkItemOutOfBoundHandle MarkItemOutOfBoundHandle
		{
			get
			{
				return (MarkItemOutOfBoundHandle)this.MarkItemComponentHandleMap.GetValueOrDefault(EMarkViewComponentType.OutOfBound);
			}
		}

		// Token: 0x170092F6 RID: 37622
		// (get) Token: 0x06039930 RID: 235824 RVA: 0x00E9B37F File Offset: 0x00E9957F
		protected MarkItemSelectHandle MarkItemSelectHandle
		{
			get
			{
				return (MarkItemSelectHandle)this.MarkItemComponentHandleMap.GetValueOrDefault(EMarkViewComponentType.Select);
			}
		}

		// Token: 0x170092F7 RID: 37623
		// (get) Token: 0x06039931 RID: 235825 RVA: 0x00E9B392 File Offset: 0x00E99592
		protected MarkItemTrackHandle MarkItemTrackHandle
		{
			get
			{
				return (MarkItemTrackHandle)this.MarkItemComponentHandleMap.GetValueOrDefault(EMarkViewComponentType.Track);
			}
		}

		// Token: 0x170092F8 RID: 37624
		// (get) Token: 0x06039932 RID: 235826 RVA: 0x00E9B3A5 File Offset: 0x00E995A5
		protected MarkItemChildIconHandle MarkItemChildIconHandle
		{
			get
			{
				return (MarkItemChildIconHandle)this.MarkItemComponentHandleMap.GetValueOrDefault(EMarkViewComponentType.ChildIcon);
			}
		}

		// Token: 0x170092F9 RID: 37625
		// (get) Token: 0x06039933 RID: 235827 RVA: 0x00E9B3B8 File Offset: 0x00E995B8
		protected MarkItemVerticalPointerHandle MarkItemVerticalPointerHandle
		{
			get
			{
				return (MarkItemVerticalPointerHandle)this.MarkItemComponentHandleMap.GetValueOrDefault(EMarkViewComponentType.VerticalPointer);
			}
		}

		// Token: 0x170092FA RID: 37626
		// (get) Token: 0x06039934 RID: 235828 RVA: 0x00E9B3CB File Offset: 0x00E995CB
		protected MarkItemGravityReverseIconHandle MarkItemGravityReverseIconHandle
		{
			get
			{
				return (MarkItemGravityReverseIconHandle)this.MarkItemComponentHandleMap.GetValueOrDefault(EMarkViewComponentType.GravityReverse);
			}
		}

		// Token: 0x170092FB RID: 37627
		// (get) Token: 0x06039935 RID: 235829 RVA: 0x00E9B3DF File Offset: 0x00E995DF
		protected MarkItemAutoPilotTrackHandle MarkItemAutoPilotTrackHandle
		{
			get
			{
				return (MarkItemAutoPilotTrackHandle)this.MarkItemComponentHandleMap.GetValueOrDefault(EMarkViewComponentType.AutoPilotTrack);
			}
		}

		// Token: 0x170092FC RID: 37628
		// (get) Token: 0x06039936 RID: 235830 RVA: 0x00E9B3F3 File Offset: 0x00E995F3
		// (set) Token: 0x06039937 RID: 235831 RVA: 0x00E9B40A File Offset: 0x00E9960A
		public bool IsSelected
		{
			get
			{
				return this.Holder.MarkItemEntity.ViewLifeCircle.IsSelected;
			}
			set
			{
				if (this.Holder.MarkItemEntity.ViewLifeCircle.IsSelectedDirty)
				{
					this.OnSelectedStateChange(value);
				}
			}
		}

		// Token: 0x170092FD RID: 37629
		// (get) Token: 0x06039938 RID: 235832 RVA: 0x00E9B42A File Offset: 0x00E9962A
		public bool ViewInitialized
		{
			get
			{
				return this.ViewInitializedInner;
			}
		}

		// Token: 0x06039939 RID: 235833 RVA: 0x00E9B432 File Offset: 0x00E99632
		public MarkItemView(MarkItem holder)
		{
			this.Holder = holder;
		}

		// Token: 0x0603993A RID: 235834 RVA: 0x00E9B453 File Offset: 0x00E99653
		protected virtual void OnSelectedStateChange(bool newState)
		{
		}

		// Token: 0x0603993B RID: 235835 RVA: 0x00E9B458 File Offset: 0x00E99658
		public UniTask InitializeMarkItemViewNewAsync(Action createCb)
		{
			MarkItemView.<InitializeMarkItemViewNewAsync>d__39 <InitializeMarkItemViewNewAsync>d__;
			<InitializeMarkItemViewNewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeMarkItemViewNewAsync>d__.<>4__this = this;
			<InitializeMarkItemViewNewAsync>d__.createCb = createCb;
			<InitializeMarkItemViewNewAsync>d__.<>1__state = -1;
			<InitializeMarkItemViewNewAsync>d__.<>t__builder.Start<MarkItemView.<InitializeMarkItemViewNewAsync>d__39>(ref <InitializeMarkItemViewNewAsync>d__);
			return <InitializeMarkItemViewNewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603993C RID: 235836 RVA: 0x00E9B4A3 File Offset: 0x00E996A3
		public void InitializeData(MarkItem holder)
		{
			this.Holder = holder;
			this.OnDataInitialized(this.Holder);
		}

		// Token: 0x0603993D RID: 235837 RVA: 0x00E9B4B8 File Offset: 0x00E996B8
		public unsafe void InitializeView()
		{
			if (this.ViewInitializedInner)
			{
				return;
			}
			this.ViewInitializedInner = true;
			base.GetSprite(2).SetUIActive(false);
			base.GetSprite(1).SetUIActive(false);
			this.RefreshActorLabel();
			this.RefreshParentSocketTransform();
			this.ResetScale();
			this.InitComponentHandles();
			this.ApplyRootAnchorOffset();
			this.OnViewInitialize();
			if (this.Holder.MapType == EMapType.WorldMap)
			{
				UUISprite sprite = base.GetSprite(4);
				object key = this.Holder.MarkId;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "MapMarkSprite";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MarkId", this.Holder.MarkId);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "className";
				object item2;
				if (sprite == null)
				{
					item2 = null;
				}
				else
				{
					ULGUISpriteData_BaseObject sprite2 = sprite.GetSprite();
					item2 = ((sprite2 != null) ? sprite2.GetClass().GetName() : null);
				}
				ptr = new ValueTuple<string, object>(item, item2);
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
				string item3 = "GetAtlasTexture";
				object item4;
				if (sprite == null)
				{
					item4 = null;
				}
				else
				{
					ULGUISpriteData_BaseObject sprite3 = sprite.sprite;
					item4 = ((sprite3 != null) ? sprite3.GetAtlasTexture() : null);
				}
				ptr2 = new ValueTuple<string, object>(item3, item4);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("bNotUseDynamicSpriteAtlas", (sprite != null) ? new bool?(sprite.bNotUseDynamicSpriteAtlas) : null);
				MapLogger.InfoOnce(key, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
		}

		// Token: 0x0603993E RID: 235838 RVA: 0x00E9B61C File Offset: 0x00E9981C
		public void RefreshView()
		{
			this.IsShowIcon = true;
			this.RefreshActorLabel();
			this.ApplyRootAnchorOffset();
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetAlpha(1f);
			}
			this.MarkComponentContext.MarkItemEntity = this.Holder.MarkItemEntity;
			this.MarkComponentContext.MarkItem = this.Holder;
			this.MarkComponentContext.MarkParentItem = this.RootItem.GetParentAsUIItem();
			this.MarkComponentContext.MarkRootItem = this.RootItem;
			this.ResetScale();
			this.ResetIcon();
			this.OnViewRefresh();
			base.DoRegisterEvents();
		}

		// Token: 0x0603993F RID: 235839 RVA: 0x00E9B6B9 File Offset: 0x00E998B9
		public void RecycleView(bool? recycleToPoolImmediately)
		{
			base.DoUnRegisterEvents();
			this.OnViewRecycle();
			if (recycleToPoolImmediately.GetValueOrDefault())
			{
				this.RecycleToPool();
				return;
			}
			base.SetVisible(false);
			MarkSpritePool.UnRef(this.ComponentId);
			this.OnRecycle();
		}

		// Token: 0x06039940 RID: 235840 RVA: 0x00E9B6EF File Offset: 0x00E998EF
		public override void RecycleToPool()
		{
			this.DestroyView();
			base.RecycleToPool();
		}

		// Token: 0x06039941 RID: 235841 RVA: 0x00E9B6FD File Offset: 0x00E998FD
		public void DestroyView()
		{
			this.DisposeComponentHandles();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
			Singleton<EventSystem>.Instance.Emit<MarkItemView>(EEventName.OnMarkItemViewDestroy, this);
			this.ClearData();
		}

		// Token: 0x06039942 RID: 235842 RVA: 0x00E9B734 File Offset: 0x00E99934
		public void ClearData()
		{
			this.AttachParentSocketTransform = null;
			this.Holder = null;
		}

		// Token: 0x06039943 RID: 235843 RVA: 0x00E9B749 File Offset: 0x00E99949
		protected virtual void OnDataInitialized(MarkItem holder)
		{
		}

		// Token: 0x06039944 RID: 235844 RVA: 0x00E9B74B File Offset: 0x00E9994B
		protected virtual void OnViewInitialize()
		{
		}

		// Token: 0x06039945 RID: 235845 RVA: 0x00E9B74D File Offset: 0x00E9994D
		protected virtual void OnViewRefresh()
		{
		}

		// Token: 0x06039946 RID: 235846 RVA: 0x00E9B74F File Offset: 0x00E9994F
		protected virtual void OnViewRecycle()
		{
		}

		// Token: 0x06039947 RID: 235847 RVA: 0x00E9B751 File Offset: 0x00E99951
		[NullableContext(2)]
		public virtual UUIItem GetIconItem()
		{
			return base.GetSprite(1);
		}

		// Token: 0x06039948 RID: 235848 RVA: 0x00E9B75C File Offset: 0x00E9995C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06039949 RID: 235849 RVA: 0x00E9B828 File Offset: 0x00E99A28
		protected override void OnStart()
		{
			if (this.Holder == null)
			{
				return;
			}
			this.CreateComponentHandles();
			this.InitLevelSequencePlayer();
			Singleton<EventSystem>.Instance.Emit<MarkItemView>(EEventName.OnMarkItemViewCreate, this);
		}

		// Token: 0x0603994A RID: 235850 RVA: 0x00E9B850 File Offset: 0x00E99A50
		protected override void OnBeforeDestroy()
		{
			this.DisposeComponentHandles();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
			this.LoadingTaskCompletionSource = null;
			Singleton<EventSystem>.Instance.Emit<MarkItemView>(EEventName.OnMarkItemViewDestroy, this);
			this.AttachParentSocketTransform = null;
			this.Holder = null;
		}

		// Token: 0x0603994B RID: 235851 RVA: 0x00E9B8A6 File Offset: 0x00E99AA6
		protected void RefreshActorLabel()
		{
		}

		// Token: 0x0603994C RID: 235852 RVA: 0x00E9B8A8 File Offset: 0x00E99AA8
		protected void RefreshParentSocketTransform()
		{
			FName attachSocketName = this.RootItem.GetAttachSocketName();
			USceneComponent attachParent = this.RootItem.GetAttachParent();
			this.AttachParentSocketTransform = new FTransformDouble?(attachParent.D_GetSocketTransform(attachSocketName, ERelativeTransformSpace.RTS_World));
		}

		// Token: 0x0603994D RID: 235853 RVA: 0x00E9B8E0 File Offset: 0x00E99AE0
		protected void InitLevelSequencePlayer()
		{
			if (this.LevelSequencePlayer != null)
			{
				return;
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceStartEvent(new TSequenceStartEvent(this.OnLevelSequenceStart));
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnLevelSequenceStop), false);
		}

		// Token: 0x0603994E RID: 235854 RVA: 0x00E9B938 File Offset: 0x00E99B38
		public virtual void SetScale(float scale)
		{
			if (!this.IsHolderValid())
			{
				return;
			}
			bool flag = this.Holder.MapType == EMapType.MiniMap;
			float num = flag ? 1f : ModelBase<WorldMapModel>.Instance.MapScale;
			float num2 = 1f / num;
			FVector fvector = flag ? this.AttachParentSocketTransform.Value.GetScale3D() : global::Vector.OneVector;
			float inX = scale * num2 / fvector.X;
			float inY = scale * num2 / fvector.Y;
			float inZ = scale * num2 / fvector.Z;
			FVector fvector2 = new FVector(inX, inY, inZ);
			this.RootItem.SetUIRelativeScale3D(fvector2);
		}

		// Token: 0x0603994F RID: 235855 RVA: 0x00E9B9D6 File Offset: 0x00E99BD6
		protected bool IsHolderValid()
		{
			return this.Holder != null && this.AttachParentSocketTransform != null;
		}

		// Token: 0x170092FE RID: 37630
		// (get) Token: 0x06039950 RID: 235856 RVA: 0x00E9B9F2 File Offset: 0x00E99BF2
		public bool IsViewReady
		{
			get
			{
				return !base.IsCreating && !base.IsDestroyOrDestroying && !base.IsHideOrHiding;
			}
		}

		// Token: 0x06039951 RID: 235857 RVA: 0x00E9BA10 File Offset: 0x00E99C10
		public void OnUpdate(global::Vector playerLocation, bool bDragging = false, bool bIsScale = false)
		{
			if (this.Holder == null || base.IsRegister)
			{
				return;
			}
			this.IsScaleChangedLast = bIsScale;
			this.CheckPlayShowHideSequence();
			if (this.Holder.MapType == EMapType.WorldMap)
			{
				UUIItem rootItem = this.RootItem;
				if (rootItem != null && rootItem.bIsUIActive)
				{
					this.PlayAndSetScaleSelected(this.IsSelected);
				}
			}
			bool isCanShowView = this.Holder.IsCanShowView;
			if (!isCanShowView)
			{
				return;
			}
			if (isCanShowView)
			{
				UUIItem rootItem2 = this.RootItem;
				if (rootItem2 == null || !rootItem2.bIsUIActive)
				{
					base.SetUiActive(true);
				}
			}
			if (this.MarkComponentContext == null)
			{
				return;
			}
			this.UpdateComponents(playerLocation, bDragging);
			this.OnSafeUpdate(playerLocation, bDragging, bIsScale);
			this.OnLateUpdate();
			if (!isCanShowView && this.Holder.NeedPlayShowOrHideSeq == null)
			{
				base.SetUiActive(false);
			}
		}

		// Token: 0x06039952 RID: 235858 RVA: 0x00E9BAD1 File Offset: 0x00E99CD1
		public void ApplyOutOfBoundActive()
		{
			MarkItemOutOfBoundHandle markItemOutOfBoundHandle = this.MarkItemOutOfBoundHandle;
			if (markItemOutOfBoundHandle == null)
			{
				return;
			}
			markItemOutOfBoundHandle.ApplyModified();
		}

		// Token: 0x06039953 RID: 235859 RVA: 0x00E9BAE4 File Offset: 0x00E99CE4
		private void UpdateComponents(global::Vector playerLocation, bool bDragging = false)
		{
			MarkItemTrackHandle markItemTrackHandle = this.MarkItemTrackHandle;
			if (markItemTrackHandle != null)
			{
				markItemTrackHandle.SetVisible(this.Holder.IsTracked && !bDragging);
			}
			MarkItemSelectHandle markItemSelectHandle = this.MarkItemSelectHandle;
			if (markItemSelectHandle != null)
			{
				markItemSelectHandle.SetVisible(this.IsSelected);
			}
			MarkItemVerticalPointerHandle markItemVerticalPointerHandle = this.MarkItemVerticalPointerHandle;
			if (markItemVerticalPointerHandle != null)
			{
				markItemVerticalPointerHandle.UpdateVerticalPointerType(this.Holder.WorldPosition, playerLocation);
			}
			MarkItemAutoPilotTrackHandle markItemAutoPilotTrackHandle = this.MarkItemAutoPilotTrackHandle;
			if (markItemAutoPilotTrackHandle != null)
			{
				markItemAutoPilotTrackHandle.SetVisible(this.Holder.IsAutoPilotTracked);
			}
			this.UpdateComponentHandles();
		}

		// Token: 0x06039954 RID: 235860 RVA: 0x00E9BB6C File Offset: 0x00E99D6C
		protected virtual void OnSafeUpdate(global::Vector playerLocation, bool bDragging = false, bool bIsScale = false)
		{
		}

		// Token: 0x06039955 RID: 235861 RVA: 0x00E9BB6E File Offset: 0x00E99D6E
		protected virtual void OnLateUpdate()
		{
			this.UpdateGravityIcon();
			this.ApplyComponentHandlesModified();
		}

		// Token: 0x06039956 RID: 235862 RVA: 0x00E9BB7C File Offset: 0x00E99D7C
		private void CheckPlayShowHideSequence()
		{
			if (this.Holder == null)
			{
				return;
			}
			if (this.IsScaleChangedLast)
			{
				if (this.Holder.NeedPlayShowOrHideSeq != null)
				{
					string needPlayShowOrHideSeq = this.Holder.NeedPlayShowOrHideSeq;
					if (!(needPlayShowOrHideSeq == "ShowView"))
					{
						if (needPlayShowOrHideSeq == "HideView")
						{
							this.PlayOutShowScaleRangeSequence();
						}
					}
					else
					{
						this.PlayInShowScaleRangeSequence();
					}
					this.Holder.NeedPlayShowOrHideSeq = null;
				}
			}
			else
			{
				this.Holder.NeedPlayShowOrHideSeq = null;
				this.Holder.OnLevelSequenceStop("HideView");
			}
			this.IsScaleChangedLast = false;
		}

		// Token: 0x06039957 RID: 235863 RVA: 0x00E9BC0E File Offset: 0x00E99E0E
		public virtual void OnStartTrack()
		{
		}

		// Token: 0x06039958 RID: 235864 RVA: 0x00E9BC10 File Offset: 0x00E99E10
		public virtual void OnEndTrack()
		{
		}

		// Token: 0x06039959 RID: 235865 RVA: 0x00E9BC12 File Offset: 0x00E99E12
		private void ResetIcon()
		{
			this.OnIconPathChanged(this.Holder.IconPath);
			this.UpdateGravityIcon();
		}

		// Token: 0x0603995A RID: 235866 RVA: 0x00E9BC2C File Offset: 0x00E99E2C
		private void UpdateGravityIcon()
		{
			if (this.Holder.MarkItemEntity.ViewLifeCircle.IsChildViewStateDirty(EMarkViewComponentType.GravityReverse))
			{
				base.GetSprite(1).SetAlpha(this.Holder.MarkItemEntity.GamePlay.InGravityLayer ? 1f : 0.4f);
			}
		}

		// Token: 0x0603995B RID: 235867 RVA: 0x00E9BC84 File Offset: 0x00E99E84
		public virtual void OnIconPathChanged(string iconPath)
		{
			UUISprite sprite = base.GetSprite(1);
			this.LoadIcon(sprite, iconPath);
		}

		// Token: 0x0603995C RID: 235868 RVA: 0x00E9BCA4 File Offset: 0x00E99EA4
		protected void LoadIcon(UUISprite iconComponent, string iconPath)
		{
			if (ObjectUtils.IsValid(iconComponent))
			{
				if (!string.IsNullOrEmpty(iconPath))
				{
					this.SetSpriteByPath(iconPath, iconComponent, false, null, delegate(bool result)
					{
						if (iconComponent.IsValid())
						{
							iconComponent.SetUIActive(this.IsShowIcon);
						}
					});
					return;
				}
				iconComponent.SetUIActive(false);
			}
		}

		// Token: 0x0603995D RID: 235869 RVA: 0x00E9BD0A File Offset: 0x00E99F0A
		public virtual bool GetInteractiveFlag()
		{
			MarkItem holder = this.Holder;
			return holder != null && holder.IsCanShowView;
		}

		// Token: 0x0603995E RID: 235870 RVA: 0x00E9BD1D File Offset: 0x00E99F1D
		protected virtual void OnLevelSequenceStart(string sequenceName)
		{
			MarkItem holder = this.Holder;
			if (holder == null)
			{
				return;
			}
			holder.OnLevelSequenceStart(sequenceName);
		}

		// Token: 0x0603995F RID: 235871 RVA: 0x00E9BD30 File Offset: 0x00E99F30
		protected virtual void OnLevelSequenceStop(string sequenceName)
		{
			MarkItem holder = this.Holder;
			if (holder != null)
			{
				holder.OnLevelSequenceStop(sequenceName);
			}
			if (sequenceName == "HideView")
			{
				bool uiActive = this.Holder.MarkItemEntity.ViewLifeCircle.IsChildViewVisible(EMarkViewComponentType.MarkView, false);
				base.SetUiActive(uiActive);
				UUIItem item = base.GetItem(0);
				if (item == null)
				{
					return;
				}
				item.SetAlpha(1f);
			}
		}

		// Token: 0x06039960 RID: 235872 RVA: 0x00E9BD94 File Offset: 0x00E99F94
		protected void PlayInShowScaleRangeSequence()
		{
			this.LevelSequencePlayer.StopCurrentSequence(false, false);
			this.LevelSequencePlayer.PlayLevelSequenceByName("ShowView", false, null, false);
		}

		// Token: 0x06039961 RID: 235873 RVA: 0x00E9BDCC File Offset: 0x00E99FCC
		protected void PlayOutShowScaleRangeSequence()
		{
			this.LevelSequencePlayer.StopCurrentSequence(false, false);
			this.LevelSequencePlayer.PlayLevelSequenceByName("HideView", false, null, false);
		}

		// Token: 0x06039962 RID: 235874 RVA: 0x00E9BE01 File Offset: 0x00E9A001
		public virtual UniTask PlayUnlockSequence()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06039963 RID: 235875 RVA: 0x00E9BE08 File Offset: 0x00E9A008
		private void PlayAndSetScaleSelected(bool selected)
		{
			if (this.MarkLogicSelected != selected)
			{
				this.MarkLogicSelected = selected;
				this.MarkSelectedTime = Singleton<Time>.Instance.NowSeconds;
				this.ClearTimer();
				this.RefreshTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnTimerRefresh), 50f, 1f, null, null, true);
				return;
			}
			if (this.IsOnScaleTween())
			{
				return;
			}
			float num = this.MarkLogicSelected ? ConfigCommonParamById.GetFloatConfig("MapMarkSelectedAdditionScale").Value : 0f;
			float scale = this.Holder.MarkScale + num;
			this.SetScale(scale);
		}

		// Token: 0x06039964 RID: 235876 RVA: 0x00E9BEA8 File Offset: 0x00E9A0A8
		private void OnTimerRefresh(float delta)
		{
			if (this.Holder == null)
			{
				this.ClearTimer();
				return;
			}
			float value = ConfigCommonParamById.GetFloatConfig("MapMarkSelectedAdditionScale").Value;
			float num = this.Holder.MarkScale + value;
			if (this.IsOnScaleTween())
			{
				double alpha = (Singleton<Time>.Instance.NowSeconds - this.MarkSelectedTime) / 0.20000000298023224;
				float num2 = this.MarkLogicSelected ? this.Holder.MarkScale : num;
				float num3 = this.MarkLogicSelected ? num : this.Holder.MarkScale;
				double num4 = Singleton<MathUtils>.Instance.Lerp((double)num2, (double)num3, alpha);
				this.SetScale((float)num4);
				return;
			}
			this.ClearTimer();
			this.PlayAndSetScaleSelected(this.MarkLogicSelected);
		}

		// Token: 0x06039965 RID: 235877 RVA: 0x00E9BF68 File Offset: 0x00E9A168
		private bool IsOnScaleTween()
		{
			return this.MarkSelectedTime > 0.0 && this.MarkSelectedTime + 0.20000000298023224 >= Singleton<Time>.Instance.NowSeconds;
		}

		// Token: 0x06039966 RID: 235878 RVA: 0x00E9BF9C File Offset: 0x00E9A19C
		private void ClearTimer()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.RefreshTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimer);
				this.RefreshTimer = null;
			}
		}

		// Token: 0x06039967 RID: 235879 RVA: 0x00E9BFC8 File Offset: 0x00E9A1C8
		public void OnRecycle()
		{
			this.RecycleHandles();
			this.LevelSequencePlayer.StopCurrentSequence(false, true);
			MarkSpritePool.UnRef(this.ComponentId);
			this.ClearTimer();
		}

		// Token: 0x06039968 RID: 235880 RVA: 0x00E9BFEE File Offset: 0x00E9A1EE
		protected void ApplyRootAnchorOffset()
		{
			this.RootItem.SetAnchorOffset(Vector2D.Create(this.Holder.InitUiPosition.X, this.Holder.InitUiPosition.Y).ToUeVector2D(false));
		}

		// Token: 0x06039969 RID: 235881 RVA: 0x00E9C028 File Offset: 0x00E9A228
		private void ResetScale()
		{
			this.SetScale(this.Holder.MarkScale);
			float configScale = this.Holder.ConfigScale;
			FVector uiitemScale = new FVector(configScale, configScale, configScale);
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetUIItemScale(uiitemScale);
			}
			UUISprite sprite2 = base.GetSprite(4);
			if (sprite2 == null)
			{
				return;
			}
			FVectorDouble fvectorDouble = this.Holder.CornerScaleVector.ToUeVector(false);
			sprite2.SetUIItemScale(fvectorDouble);
		}

		// Token: 0x0603996A RID: 235882 RVA: 0x00E9C09C File Offset: 0x00E9A29C
		private void InitComponentHandles()
		{
			foreach (IMarkItemHandle markItemHandle in this.MarkItemComponentHandleMap.Values)
			{
				markItemHandle.Init();
			}
		}

		// Token: 0x0603996B RID: 235883 RVA: 0x00E9C0F4 File Offset: 0x00E9A2F4
		protected virtual void CreateComponentHandles()
		{
			base.GetSprite(4).bNotUseDynamicSpriteAtlas = true;
			this.MarkComponentContext = new MarkItemComponentContext
			{
				MarkItemEntity = this.Holder.MarkItemEntity,
				TopRightIconSprite = base.GetSprite(4),
				SetSpriteByPathAction = new TSetSpriteByPathAction(this.SetSpriteByPath),
				MarkComponentContainer = base.GetItem(0),
				MarkParentItem = this.RootItem.GetParentAsUIItem(),
				MarkRootItem = this.RootItem,
				MarkItem = this.Holder
			};
			this.MarkItemComponentHandleMap[EMarkViewComponentType.TopRightIcon] = this.CreateTopRightHandle(this.MarkComponentContext);
			this.MarkItemComponentHandleMap[EMarkViewComponentType.Range] = this.CreateRangeHandle<MarkRangeImageComponent>(this.MarkComponentContext);
			this.MarkItemComponentHandleMap[EMarkViewComponentType.Name] = this.CreateNameHandle(this.MarkComponentContext);
			this.MarkItemComponentHandleMap[EMarkViewComponentType.OutOfBound] = this.CreateOutOfBoundHandle(this.MarkComponentContext);
			this.MarkItemComponentHandleMap[EMarkViewComponentType.Select] = this.CreateSelectHandle(this.MarkComponentContext);
			this.MarkItemComponentHandleMap[EMarkViewComponentType.Track] = this.CreateTrackHandle(this.MarkComponentContext);
			this.MarkItemComponentHandleMap[EMarkViewComponentType.ChildIcon] = this.CreateChildIconHandle(this.MarkComponentContext);
			this.MarkItemComponentHandleMap[EMarkViewComponentType.VerticalPointer] = this.CreateVerticalPointerHandle(this.MarkComponentContext);
			this.MarkItemComponentHandleMap[EMarkViewComponentType.GravityReverse] = this.CreateGravityReverseIconHandle(this.MarkComponentContext);
			this.MarkItemComponentHandleMap[EMarkViewComponentType.AutoPilotTrack] = this.CreateAutoPilotTrackHandle(this.MarkComponentContext);
		}

		// Token: 0x0603996C RID: 235884 RVA: 0x00E9C274 File Offset: 0x00E9A474
		private void UpdateComponentHandles()
		{
			if (!this.MarkComponentContext.CanExecuteComponentLogic())
			{
				return;
			}
			foreach (IMarkItemHandle markItemHandle in this.MarkItemComponentHandleMap.Values)
			{
				markItemHandle.UpdateNoCheck();
			}
		}

		// Token: 0x0603996D RID: 235885 RVA: 0x00E9C2D8 File Offset: 0x00E9A4D8
		private void ApplyComponentHandlesModified()
		{
			if (!this.MarkComponentContext.CanExecuteComponentLogic())
			{
				return;
			}
			foreach (IMarkItemHandle markItemHandle in this.MarkItemComponentHandleMap.Values)
			{
				markItemHandle.ApplyModifiedNoCheck();
			}
		}

		// Token: 0x0603996E RID: 235886 RVA: 0x00E9C33C File Offset: 0x00E9A53C
		private void RecycleHandles()
		{
			foreach (IMarkItemHandle markItemHandle in this.MarkItemComponentHandleMap.Values)
			{
				markItemHandle.SetVisible(false);
				markItemHandle.ApplyModified();
			}
		}

		// Token: 0x0603996F RID: 235887 RVA: 0x00E9C398 File Offset: 0x00E9A598
		private void DisposeComponentHandles()
		{
			foreach (IMarkItemHandle markItemHandle in this.MarkItemComponentHandleMap.Values)
			{
				markItemHandle.Dispose();
			}
			this.MarkItemComponentHandleMap.Clear();
		}

		// Token: 0x06039970 RID: 235888 RVA: 0x00E9C3F8 File Offset: 0x00E9A5F8
		protected virtual IMarkItemHandle CreateTopRightHandle(IMarkItemComponentContext markComponentContext)
		{
			return new MarkItemTopRightIconHandle(markComponentContext);
		}

		// Token: 0x06039971 RID: 235889 RVA: 0x00E9C400 File Offset: 0x00E9A600
		protected virtual IMarkItemHandle CreateRangeHandle<[Nullable(0)] T>(IMarkItemComponentContext markComponentContext) where T : MarkPanelBase, new()
		{
			return new MarkItemRangeHandle<T>(markComponentContext);
		}

		// Token: 0x06039972 RID: 235890 RVA: 0x00E9C408 File Offset: 0x00E9A608
		protected virtual IMarkItemHandle CreateNameHandle(IMarkItemComponentContext markComponentContext)
		{
			return new MarkItemNameHandle(markComponentContext);
		}

		// Token: 0x06039973 RID: 235891 RVA: 0x00E9C410 File Offset: 0x00E9A610
		protected virtual IMarkItemHandle CreateOutOfBoundHandle(IMarkItemComponentContext markComponentContext)
		{
			return new MarkItemOutOfBoundHandle(markComponentContext);
		}

		// Token: 0x06039974 RID: 235892 RVA: 0x00E9C418 File Offset: 0x00E9A618
		protected virtual IMarkItemHandle CreateSelectHandle(IMarkItemComponentContext markComponentContext)
		{
			return new MarkItemSelectHandle(markComponentContext);
		}

		// Token: 0x06039975 RID: 235893 RVA: 0x00E9C420 File Offset: 0x00E9A620
		protected virtual IMarkItemHandle CreateTrackHandle(IMarkItemComponentContext markComponentContext)
		{
			return new MarkItemTrackHandle(markComponentContext);
		}

		// Token: 0x06039976 RID: 235894 RVA: 0x00E9C428 File Offset: 0x00E9A628
		protected virtual IMarkItemHandle CreateChildIconHandle(IMarkItemComponentContext markComponentContext)
		{
			return new MarkItemChildIconHandle(markComponentContext);
		}

		// Token: 0x06039977 RID: 235895 RVA: 0x00E9C430 File Offset: 0x00E9A630
		protected virtual IMarkItemHandle CreateVerticalPointerHandle(IMarkItemComponentContext markComponentContext)
		{
			return new MarkItemVerticalPointerHandle(markComponentContext);
		}

		// Token: 0x06039978 RID: 235896 RVA: 0x00E9C438 File Offset: 0x00E9A638
		protected virtual IMarkItemHandle CreateGravityReverseIconHandle(IMarkItemComponentContext markComponentContext)
		{
			return new MarkItemGravityReverseIconHandle(markComponentContext);
		}

		// Token: 0x06039979 RID: 235897 RVA: 0x00E9C440 File Offset: 0x00E9A640
		protected virtual IMarkItemHandle CreateAutoPilotTrackHandle(IMarkItemComponentContext markComponentContext)
		{
			return new MarkItemAutoPilotTrackHandle(markComponentContext);
		}

		// Token: 0x04020ABC RID: 133820
		public const float SCALE_TWEEN_DURATION = 0.2f;

		// Token: 0x04020ABD RID: 133821
		[Nullable(2)]
		public MarkItem Holder;

		// Token: 0x04020ABE RID: 133822
		private bool MarkLogicSelected;

		// Token: 0x04020ABF RID: 133823
		private double MarkSelectedTime;

		// Token: 0x04020AC0 RID: 133824
		[Nullable(2)]
		private TimerHandle RefreshTimer;

		// Token: 0x04020AC1 RID: 133825
		public bool IsShowIcon = true;

		// Token: 0x04020AC2 RID: 133826
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04020AC3 RID: 133827
		protected FTransformDouble? AttachParentSocketTransform;

		// Token: 0x04020AC4 RID: 133828
		private bool IsScaleChangedLast;

		// Token: 0x04020AC5 RID: 133829
		[Nullable(2)]
		protected IMarkItemComponentContext MarkComponentContext;

		// Token: 0x04020AC6 RID: 133830
		protected readonly Dictionary<EMarkViewComponentType, IMarkItemHandle> MarkItemComponentHandleMap = new Dictionary<EMarkViewComponentType, IMarkItemHandle>();

		// Token: 0x04020AC7 RID: 133831
		private bool ViewInitializedInner;
	}
}
