using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Card.Logic;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component.Bvb;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Card
{
	// Token: 0x02005620 RID: 22048
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaCard : CommonBaseCardItem<PhantomCardData>
	{
		// Token: 0x060382EF RID: 230127 RVA: 0x00E3A3A8 File Offset: 0x00E385A8
		protected override void OnRegisterCardComponent()
		{
			if (ModelBase<PhantomArenaBattleModel>.Instance.IsOldBvb)
			{
				this.ComponentsRegisterInfoByItem = new List<TCardComponentsRegisterInfoByItem>
				{
					new TCardComponentsRegisterInfoByItem(ECardItemComponent.BattleCardComponent, base.GetCardRootItem())
				};
			}
			else
			{
				this.ComponentsRegisterInfoByItem = new List<TCardComponentsRegisterInfoByItem>
				{
					new TCardComponentsRegisterInfoByItem(ECardItemComponent.NewBattleCardComponent, base.GetCardRootItem())
				};
			}
			this.ComponentsRegisterInfoByResourceId = new List<TCardComponentsRegisterInfoByResourceId>
			{
				new TCardComponentsRegisterInfoByResourceId(ECardItemComponent.CardSelectedComponent, "PnlStateChoose1", base.GetCardRootItem())
			};
			foreach (Tuple<ECardItemComponent, string> value in this.ComponentsDataList)
			{
				ECardItemComponent ecardItemComponent;
				string text;
				value.Deconstruct(out ecardItemComponent, out text);
				ECardItemComponent componentType = ecardItemComponent;
				string resourceId = text;
				this.ComponentsRegisterInfoByResourceId.Add(new TCardComponentsRegisterInfoByResourceId(componentType, resourceId, base.GetCardRootItem()));
			}
			if (this.CardLogic != null)
			{
				foreach (TCardComponentsRegisterInfoByResourceId tcardComponentsRegisterInfoByResourceId in this.CardLogic.GetComponentsDataList())
				{
					ECardItemComponent ecardItemComponent;
					string text;
					UUIItem uuiitem;
					tcardComponentsRegisterInfoByResourceId.Deconstruct(out ecardItemComponent, out text, out uuiitem);
					ECardItemComponent componentType2 = ecardItemComponent;
					string resourceId2 = text;
					UUIItem parentItem = uuiitem;
					this.ComponentsRegisterInfoByResourceId.Add(new TCardComponentsRegisterInfoByResourceId(componentType2, resourceId2, parentItem));
				}
			}
		}

		// Token: 0x060382F0 RID: 230128 RVA: 0x00E3A4F8 File Offset: 0x00E386F8
		private void CardClick(EToggleState state)
		{
			if (this.IsTriggerDragging)
			{
				this.IsTriggerDragging = false;
				this.SetToggleState(EToggleState.ETT_UnChecked, false);
				return;
			}
			IPhantomCardProxy subProxy = this.GetSubProxy<IPhantomCardProxy>();
			if (subProxy == null)
			{
				return;
			}
			subProxy.PointerClickCard(this.Data.CardId, state);
		}

		// Token: 0x060382F1 RID: 230129 RVA: 0x00E3A530 File Offset: 0x00E38730
		protected override UniTask OnBeforeChildStartAsync()
		{
			PhantomArenaCard.<OnBeforeChildStartAsync>d__24 <OnBeforeChildStartAsync>d__;
			<OnBeforeChildStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeChildStartAsync>d__.<>4__this = this;
			<OnBeforeChildStartAsync>d__.<>1__state = -1;
			<OnBeforeChildStartAsync>d__.<>t__builder.Start<PhantomArenaCard.<OnBeforeChildStartAsync>d__24>(ref <OnBeforeChildStartAsync>d__);
			return <OnBeforeChildStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060382F2 RID: 230130 RVA: 0x00E3A574 File Offset: 0x00E38774
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(base.GetCardRootItem());
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.OnEndSequenceEvent));
			IBattleCardComponent battleCardComponent = this.GetBattleCardComponent();
			battleCardComponent.RootUiSequencePlayer = this.Sequence;
			battleCardComponent.CardClickCallback = new Action<EToggleState>(this.CardClick);
			UUIExtendToggle cardToggle = battleCardComponent.GetCardToggle();
			cardToggle.OnPointEnterCallBack.Bind(new Action<EToggleState>(this.OnPointerEnter));
			cardToggle.OnPointDownCallBack.Bind(new Action<EToggleState>(this.OnPointerDown));
			cardToggle.OnPointUpCallBack.Bind(new Action<EToggleState>(this.OnPointerUp));
			cardToggle.OnPointCancelCallBack.Bind(new Action<EToggleState>(this.OnPointerCancel));
			cardToggle.OnPointerBeginDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnPointerBeginDrag));
			cardToggle.OnPointerDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnPointerDrag));
			cardToggle.OnPointerEndDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnPointerEndDrag));
			PhantomArenaCardLogic cardLogic = this.CardLogic;
			if (cardLogic != null)
			{
				cardLogic.BeforeStart();
			}
			Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.Tick), "LongPressComponent", ETickingGroup.TG_PrePhysics, true, 0, true);
			if (ticker != null)
			{
				this.TickId = ticker.Id;
			}
			this.HalfWidth = base.GetCardRootItem().Width / 2f;
			this.HalfHeight = base.GetCardRootItem().Height / 2f;
			this.TweenLogic = new PhantomArenaCardTweenLogic();
			this.TweenLogic.Init(base.GetRootItem());
		}

		// Token: 0x060382F3 RID: 230131 RVA: 0x00E3A6FC File Offset: 0x00E388FC
		protected override void OnBeforeDestroy()
		{
			if (this.CopyEffect != null)
			{
				ULGUIBPLibrary.DestroyActorWithHierarchy(this.CopyEffect, true);
				this.CopyEffect = null;
			}
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickId);
				this.TickId = -1;
			}
			this.Sequence.Clear();
			this.TweenLogic.Destroy();
		}

		// Token: 0x060382F4 RID: 230132 RVA: 0x00E3A75B File Offset: 0x00E3895B
		private void OnEndSequenceEvent(string sequenceName)
		{
			if (sequenceName == "Dissolve".ToString() || sequenceName == "MagicUse".ToString())
			{
				base.Destroy(null);
			}
		}

		// Token: 0x060382F5 RID: 230133 RVA: 0x00E3A788 File Offset: 0x00E38988
		private void Tick(float delta)
		{
			if (!this.IsCanTick)
			{
				return;
			}
			if (this.TickTime < 1000f)
			{
				this.TickTime += delta;
				return;
			}
			this.SetPress(false);
			IPhantomCardLongPressProxy subProxy = this.GetSubProxy<IPhantomCardLongPressProxy>();
			if (subProxy == null)
			{
				return;
			}
			subProxy.PointerLongPressCard(this.Data.CardId);
		}

		// Token: 0x060382F6 RID: 230134 RVA: 0x00E3A7DC File Offset: 0x00E389DC
		private void SetPress(bool value)
		{
			if (value == this.IsPress)
			{
				return;
			}
			this.TickTime = 0f;
			this.IsCanTick = value;
			this.IsPress = value;
		}

		// Token: 0x060382F7 RID: 230135 RVA: 0x00E3A801 File Offset: 0x00E38A01
		private IBattleCardComponent GetBattleCardComponent()
		{
			if (ModelBase<PhantomArenaBattleModel>.Instance.IsOldBvb)
			{
				return base.GetComponent<BattleCardComponent>(ECardItemComponent.BattleCardComponent);
			}
			return base.GetComponent<NewBattleCardComponent>(ECardItemComponent.NewBattleCardComponent);
		}

		// Token: 0x060382F8 RID: 230136 RVA: 0x00E3A81E File Offset: 0x00E38A1E
		private void SetCardData(PhantomCardData data)
		{
			this.Data = data;
		}

		// Token: 0x060382F9 RID: 230137 RVA: 0x00E3A828 File Offset: 0x00E38A28
		[return: Nullable(2)]
		private T GetSubProxy<T>() where T : class
		{
			if (this.IsProxyChange)
			{
				this.IsProxyChange = false;
				return default(T);
			}
			return this.CardProxy as T;
		}

		// Token: 0x060382FA RID: 230138 RVA: 0x00E3A85E File Offset: 0x00E38A5E
		private void OnPointerEnter(EToggleState _)
		{
			IPhantomCardProxy subProxy = this.GetSubProxy<IPhantomCardProxy>();
			if (subProxy == null)
			{
				return;
			}
			subProxy.PointerEnterCard(this.Data.CardId);
		}

		// Token: 0x060382FB RID: 230139 RVA: 0x00E3A87C File Offset: 0x00E38A7C
		private void OnPointerDown(EToggleState _)
		{
			this.SetPress(true);
			ULGUIPointerEventData pointerEventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false);
			if (pointerEventData != null)
			{
				IPhantomCardProxy subProxy = this.GetSubProxy<IPhantomCardProxy>();
				if (subProxy == null)
				{
					return;
				}
				subProxy.PointerDownCard(this.Data.CardId, pointerEventData);
			}
		}

		// Token: 0x060382FC RID: 230140 RVA: 0x00E3A8BC File Offset: 0x00E38ABC
		private void OnPointerUp(EToggleState _)
		{
			this.SetPress(false);
		}

		// Token: 0x060382FD RID: 230141 RVA: 0x00E3A8C5 File Offset: 0x00E38AC5
		private void OnPointerCancel(EToggleState _)
		{
			this.SetPress(false);
			this.IsTriggerDragging = false;
			this.SetToggleState(EToggleState.ETT_UnChecked, false);
		}

		// Token: 0x060382FE RID: 230142 RVA: 0x00E3A8DD File Offset: 0x00E38ADD
		private bool OnPointerBeginDrag(ULGUIPointerEventData eventData)
		{
			this.IsTriggerDragging = true;
			if (eventData != null)
			{
				IPhantomCardDragProxy subProxy = this.GetSubProxy<IPhantomCardDragProxy>();
				if (subProxy != null)
				{
					subProxy.PointerBeginDrag(this.Data.CardId, eventData);
				}
			}
			return true;
		}

		// Token: 0x060382FF RID: 230143 RVA: 0x00E3A907 File Offset: 0x00E38B07
		private bool OnPointerDrag(ULGUIPointerEventData eventData)
		{
			if (eventData != null)
			{
				IPhantomCardDragProxy subProxy = this.GetSubProxy<IPhantomCardDragProxy>();
				if (subProxy != null)
				{
					subProxy.PointerDragCard(this.Data.CardId, eventData);
				}
			}
			return true;
		}

		// Token: 0x06038300 RID: 230144 RVA: 0x00E3A92A File Offset: 0x00E38B2A
		private bool OnPointerEndDrag(ULGUIPointerEventData eventData)
		{
			if (eventData != null)
			{
				IPhantomCardDragProxy subProxy = this.GetSubProxy<IPhantomCardDragProxy>();
				if (subProxy != null)
				{
					subProxy.PointerEndDrag(this.Data.CardId, eventData);
				}
			}
			return true;
		}

		// Token: 0x06038301 RID: 230145 RVA: 0x00E3A950 File Offset: 0x00E38B50
		public UniTask InitializePhantomArenaCard(PhantomCardData cardData, UUIItem rootItem)
		{
			PhantomArenaCard.<InitializePhantomArenaCard>d__40 <InitializePhantomArenaCard>d__;
			<InitializePhantomArenaCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializePhantomArenaCard>d__.<>4__this = this;
			<InitializePhantomArenaCard>d__.cardData = cardData;
			<InitializePhantomArenaCard>d__.rootItem = rootItem;
			<InitializePhantomArenaCard>d__.<>1__state = -1;
			<InitializePhantomArenaCard>d__.<>t__builder.Start<PhantomArenaCard.<InitializePhantomArenaCard>d__40>(ref <InitializePhantomArenaCard>d__);
			return <InitializePhantomArenaCard>d__.<>t__builder.Task;
		}

		// Token: 0x06038302 RID: 230146 RVA: 0x00E3A9A3 File Offset: 0x00E38BA3
		public void AddComponentsRegisterInfoByResourceId(Tuple<ECardItemComponent, string> data)
		{
			this.ComponentsDataList.Add(data);
		}

		// Token: 0x06038303 RID: 230147 RVA: 0x00E3A9B1 File Offset: 0x00E38BB1
		public override void Refresh(PhantomCardData data)
		{
			this.RefreshAsync(data).Forget();
		}

		// Token: 0x06038304 RID: 230148 RVA: 0x00E3A9C0 File Offset: 0x00E38BC0
		public UniTask RefreshAsync(PhantomCardData data)
		{
			PhantomArenaCard.<RefreshAsync>d__43 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<PhantomArenaCard.<RefreshAsync>d__43>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038305 RID: 230149 RVA: 0x00E3AA0C File Offset: 0x00E38C0C
		public UniTask RefreshSelfAsync()
		{
			PhantomArenaCard.<RefreshSelfAsync>d__44 <RefreshSelfAsync>d__;
			<RefreshSelfAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshSelfAsync>d__.<>4__this = this;
			<RefreshSelfAsync>d__.<>1__state = -1;
			<RefreshSelfAsync>d__.<>t__builder.Start<PhantomArenaCard.<RefreshSelfAsync>d__44>(ref <RefreshSelfAsync>d__);
			return <RefreshSelfAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038306 RID: 230150 RVA: 0x00E3AA4F File Offset: 0x00E38C4F
		public void RegisterCardLogic(PhantomArenaCardLogic logic)
		{
			this.CardLogic = logic;
		}

		// Token: 0x06038307 RID: 230151 RVA: 0x00E3AA58 File Offset: 0x00E38C58
		[NullableContext(2)]
		public void SetCardProxy(IPhantomCardProxyBase proxy)
		{
			if (this.CardProxy == proxy)
			{
				return;
			}
			if (this.IsTriggerDragging)
			{
				this.IsProxyChange = true;
			}
			this.CardProxy = proxy;
		}

		// Token: 0x06038308 RID: 230152 RVA: 0x00E3AA7A File Offset: 0x00E38C7A
		public void RecordLastDragPos(FVector position)
		{
			Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiPosition(position, this.LastDragPos);
		}

		// Token: 0x06038309 RID: 230153 RVA: 0x00E3AA90 File Offset: 0x00E38C90
		public void MoveCard(FVector position)
		{
			if (this.RootItem == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiPosition(position, this.CurDragPos);
			if (Vector2D.Create(this.CurDragPos.X, this.CurDragPos.Y).SubtractionEqual(this.LastDragPos).IsNearlyZero(0.0))
			{
				return;
			}
			double num = this.CurDragPos.X - this.LastDragPos.X;
			double num2 = this.CurDragPos.Y - this.LastDragPos.Y;
			this.TempAnchorOffset.FromUeVector2D(this.RootItem.GetAnchorOffset());
			this.TempAnchorOffset.X += num;
			this.TempAnchorOffset.Y += num2;
			this.RootItem.SetAnchorOffset(this.TempAnchorOffset.ToUeVector2D(false));
			this.LastDragPos.DeepCopy(this.CurDragPos);
		}

		// Token: 0x0603830A RID: 230154 RVA: 0x00E3AB88 File Offset: 0x00E38D88
		public void SetUiParent(UUIItem parentItem, bool reset = false)
		{
			Vector tempWorldPos = this.TempWorldPos;
			FVectorDouble fvectorDouble = this.RootItem.D_K2_GetComponentLocation();
			tempWorldPos.FromUeVector(fvectorDouble);
			Transform itemWorldTrans = this.ItemWorldTrans;
			FTransform ftransform = parentItem.K2_GetComponentToWorld();
			itemWorldTrans.FromUeTransform(ftransform);
			this.ItemWorldTrans.InverseTransformPosition(this.TempWorldPos, this.TempWorldPos);
			this.GetOriginalItem().SetUIParent(parentItem, false);
			this.ParentUiItem = parentItem;
			this.RootItem.SetUIRelativeLocation(this.TempWorldPos.ToUeVectorOld());
			if (reset)
			{
				this.RootItem.SetAnchorOffset(Vector2D.ZeroVector);
			}
		}

		// Token: 0x0603830B RID: 230155 RVA: 0x00E3AC18 File Offset: 0x00E38E18
		public Vector GetWorldLocation()
		{
			Vector worldLocation = this.WorldLocation;
			FVectorDouble fvectorDouble = this.RootItem.D_K2_GetComponentLocation();
			worldLocation.FromUeVector(fvectorDouble);
			return this.WorldLocation;
		}

		// Token: 0x0603830C RID: 230156 RVA: 0x00E3AC44 File Offset: 0x00E38E44
		public void SetToggleState(EToggleState state, bool bFireEvent = true)
		{
			this.GetBattleCardComponent().GetCardToggle().SetToggleState(state, bFireEvent, false, false);
		}

		// Token: 0x0603830D RID: 230157 RVA: 0x00E3AC5B File Offset: 0x00E38E5B
		public EToggleState GetToggleState()
		{
			return this.GetBattleCardComponent().GetCardToggle().GetToggleState();
		}

		// Token: 0x0603830E RID: 230158 RVA: 0x00E3AC6D File Offset: 0x00E38E6D
		public void RefreshDebugText()
		{
			IBattleCardComponent battleCardComponent = this.GetBattleCardComponent();
			if (battleCardComponent == null)
			{
				return;
			}
			battleCardComponent.SetDebugText();
		}

		// Token: 0x0603830F RID: 230159 RVA: 0x00E3AC80 File Offset: 0x00E38E80
		public void OverrideCanvasSortOrder(bool bActive)
		{
			UUIItem originalItem = this.GetOriginalItem();
			ULGUICanvas ulguicanvas = (originalItem != null) ? originalItem.GetRenderCanvas() : null;
			if (ulguicanvas != null)
			{
				ulguicanvas.SetSortOrderNew(bActive ? 2 : 0, true);
			}
		}

		// Token: 0x06038310 RID: 230160 RVA: 0x00E3ACB4 File Offset: 0x00E38EB4
		public UniTask Dissolve()
		{
			PhantomArenaCard.<Dissolve>d__55 <Dissolve>d__;
			<Dissolve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Dissolve>d__.<>4__this = this;
			<Dissolve>d__.<>1__state = -1;
			<Dissolve>d__.<>t__builder.Start<PhantomArenaCard.<Dissolve>d__55>(ref <Dissolve>d__);
			return <Dissolve>d__.<>t__builder.Task;
		}

		// Token: 0x06038311 RID: 230161 RVA: 0x00E3ACF8 File Offset: 0x00E38EF8
		public UniTask MagicUse()
		{
			PhantomArenaCard.<MagicUse>d__56 <MagicUse>d__;
			<MagicUse>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<MagicUse>d__.<>4__this = this;
			<MagicUse>d__.<>1__state = -1;
			<MagicUse>d__.<>t__builder.Start<PhantomArenaCard.<MagicUse>d__56>(ref <MagicUse>d__);
			return <MagicUse>d__.<>t__builder.Task;
		}

		// Token: 0x06038312 RID: 230162 RVA: 0x00E3AD3B File Offset: 0x00E38F3B
		public void PlayStateSequence(string sequenceName)
		{
			IBattleCardComponent battleCardComponent = this.GetBattleCardComponent();
			if (battleCardComponent == null)
			{
				return;
			}
			battleCardComponent.PlaySequence(sequenceName);
		}

		// Token: 0x06038313 RID: 230163 RVA: 0x00E3AD4E File Offset: 0x00E38F4E
		public void PlayLocationByItem(UUIItem fromItem, UUIItem toItem, [Nullable(2)] PhantomArenaTweenLogic data = null)
		{
			this.TweenLogic.PlayLocationByItem(fromItem, toItem, data);
		}

		// Token: 0x06038314 RID: 230164 RVA: 0x00E3AD5E File Offset: 0x00E38F5E
		public void StopSequence(string sequenceName)
		{
			this.Sequence.StopSequenceByKey(sequenceName, false, true);
		}

		// Token: 0x06038315 RID: 230165 RVA: 0x00E3AD6E File Offset: 0x00E38F6E
		public void PlaySequence(string sequenceName, bool isReverse = false)
		{
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequencePurely(sequenceName, false, isReverse);
		}

		// Token: 0x06038316 RID: 230166 RVA: 0x00E3AD8B File Offset: 0x00E38F8B
		public void PlaySequenceWithoutStop(string sequenceName, bool isReverse = false)
		{
			this.Sequence.PlaySequencePurely(sequenceName, false, isReverse);
		}

		// Token: 0x06038317 RID: 230167 RVA: 0x00E3AD9C File Offset: 0x00E38F9C
		public UniTask PlaySequenceAsync(string sequenceName)
		{
			PhantomArenaCard.<PlaySequenceAsync>d__62 <PlaySequenceAsync>d__;
			<PlaySequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySequenceAsync>d__.<>4__this = this;
			<PlaySequenceAsync>d__.sequenceName = sequenceName;
			<PlaySequenceAsync>d__.<>1__state = -1;
			<PlaySequenceAsync>d__.<>t__builder.Start<PhantomArenaCard.<PlaySequenceAsync>d__62>(ref <PlaySequenceAsync>d__);
			return <PlaySequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038318 RID: 230168 RVA: 0x00E3ADE7 File Offset: 0x00E38FE7
		public void PlaySpineAnimAndEffect(string animationName, bool isLoop)
		{
			IBattleCardComponent battleCardComponent = this.GetBattleCardComponent();
			if (battleCardComponent != null)
			{
				battleCardComponent.PlaySpineAnim(animationName, isLoop);
			}
			if (battleCardComponent == null)
			{
				return;
			}
			battleCardComponent.PlayEffect();
		}

		// Token: 0x06038319 RID: 230169 RVA: 0x00E3AE08 File Offset: 0x00E39008
		public void SetSelectedStateWithoutSequence()
		{
			CardCommonComponent component = base.GetComponent<CardCommonComponent>(ECardItemComponent.CardSelectedComponent);
			if (component != null)
			{
				component.SetComponentDisActiveWithoutSequence();
			}
			PhantomArenaCardLogic cardLogic = this.CardLogic;
			if (cardLogic == null)
			{
				return;
			}
			cardLogic.SetSelectedState(false);
		}

		// Token: 0x0603831A RID: 230170 RVA: 0x00E3AE38 File Offset: 0x00E39038
		public void SetSelectedState(bool value)
		{
			CardCommonComponent component = base.GetComponent<CardCommonComponent>(ECardItemComponent.CardSelectedComponent);
			if (component != null)
			{
				component.SetComponentActive(value);
			}
			PhantomArenaCardLogic cardLogic = this.CardLogic;
			if (cardLogic == null)
			{
				return;
			}
			cardLogic.SetSelectedState(value);
		}

		// Token: 0x0603831B RID: 230171 RVA: 0x00E3AE68 File Offset: 0x00E39068
		public void SetSelectedStateByGamepad(bool value)
		{
			PhantomArenaCardLogic cardLogic = this.CardLogic;
			if (cardLogic == null)
			{
				return;
			}
			cardLogic.SetSelectedState(value);
		}

		// Token: 0x0603831C RID: 230172 RVA: 0x00E3AE7C File Offset: 0x00E3907C
		public UniTask RefreshEffect(int curEffectCount)
		{
			PhantomArenaCard.<RefreshEffect>d__67 <RefreshEffect>d__;
			<RefreshEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshEffect>d__.<>4__this = this;
			<RefreshEffect>d__.curEffectCount = curEffectCount;
			<RefreshEffect>d__.<>1__state = -1;
			<RefreshEffect>d__.<>t__builder.Start<PhantomArenaCard.<RefreshEffect>d__67>(ref <RefreshEffect>d__);
			return <RefreshEffect>d__.<>t__builder.Task;
		}

		// Token: 0x0603831D RID: 230173 RVA: 0x00E3AEC8 File Offset: 0x00E390C8
		public UniTask ShowCopyEffect()
		{
			PhantomArenaCard.<ShowCopyEffect>d__68 <ShowCopyEffect>d__;
			<ShowCopyEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowCopyEffect>d__.<>4__this = this;
			<ShowCopyEffect>d__.<>1__state = -1;
			<ShowCopyEffect>d__.<>t__builder.Start<PhantomArenaCard.<ShowCopyEffect>d__68>(ref <ShowCopyEffect>d__);
			return <ShowCopyEffect>d__.<>t__builder.Task;
		}

		// Token: 0x0603831E RID: 230174 RVA: 0x00E3AF0C File Offset: 0x00E3910C
		public UniTask PlayHitEffect(UUIItem toItem)
		{
			PhantomArenaCard.<PlayHitEffect>d__69 <PlayHitEffect>d__;
			<PlayHitEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayHitEffect>d__.<>4__this = this;
			<PlayHitEffect>d__.toItem = toItem;
			<PlayHitEffect>d__.<>1__state = -1;
			<PlayHitEffect>d__.<>t__builder.Start<PhantomArenaCard.<PlayHitEffect>d__69>(ref <PlayHitEffect>d__);
			return <PlayHitEffect>d__.<>t__builder.Task;
		}

		// Token: 0x0603831F RID: 230175 RVA: 0x00E3AF57 File Offset: 0x00E39157
		public UUIItem GetPhantomArenaCardRootItem()
		{
			return base.GetCardRootItem();
		}

		// Token: 0x06038320 RID: 230176 RVA: 0x00E3AF5F File Offset: 0x00E3915F
		public UUIItem GetPhantomArenaCardSpineRootItem()
		{
			return base.GetSpineRootItem();
		}

		// Token: 0x06038321 RID: 230177 RVA: 0x00E3AF68 File Offset: 0x00E39168
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			if (configParams[0] == "BattleCardSkillById")
			{
				CardSkillComponent component = base.GetComponent<CardSkillComponent>(ECardItemComponent.CardSkillComponent);
				UUIItem uuiitem = (component != null) ? component.GetGuideUiItem("T_技能按钮") : null;
				UUIItem uuiitem2 = (component != null) ? component.GetGuideUiItem("V_技能按钮") : null;
				if (uuiitem != null && uuiitem2 != null)
				{
					return new UUIItem[]
					{
						uuiitem,
						uuiitem2
					};
				}
				return null;
			}
			else
			{
				IBattleCardComponent battleCardComponent = this.GetBattleCardComponent();
				UUIItem uuiitem3 = (battleCardComponent != null) ? battleCardComponent.GetRootItem() : null;
				if (uuiitem3 != null)
				{
					return new UUIItem[]
					{
						uuiitem3,
						uuiitem3
					};
				}
				return null;
			}
		}

		// Token: 0x04020179 RID: 131449
		private const int TICK_DURATION = 1000;

		// Token: 0x0402017A RID: 131450
		private readonly Vector2D LastDragPos = Vector2D.Create();

		// Token: 0x0402017B RID: 131451
		private readonly Vector2D CurDragPos = Vector2D.Create();

		// Token: 0x0402017C RID: 131452
		private readonly Vector2D TempAnchorOffset = Vector2D.Create();

		// Token: 0x0402017D RID: 131453
		private readonly Vector WorldLocation = Vector.Create();

		// Token: 0x0402017E RID: 131454
		protected readonly Transform ItemWorldTrans = Transform.Create();

		// Token: 0x0402017F RID: 131455
		protected readonly Vector TempWorldPos = Vector.Create();

		// Token: 0x04020180 RID: 131456
		[Nullable(2)]
		private IPhantomCardProxyBase CardProxy;

		// Token: 0x04020181 RID: 131457
		private bool IsPress;

		// Token: 0x04020182 RID: 131458
		private bool IsTriggerDragging;

		// Token: 0x04020183 RID: 131459
		private bool IsCanTick;

		// Token: 0x04020184 RID: 131460
		private bool IsProxyChange;

		// Token: 0x04020185 RID: 131461
		private int TickId = -1;

		// Token: 0x04020186 RID: 131462
		private float TickTime;

		// Token: 0x04020187 RID: 131463
		protected UiSequencePlayer Sequence;

		// Token: 0x04020188 RID: 131464
		protected PhantomArenaCardTweenLogic TweenLogic;

		// Token: 0x04020189 RID: 131465
		public PhantomArenaCardLogic CardLogic;

		// Token: 0x0402018A RID: 131466
		private readonly List<Tuple<ECardItemComponent, string>> ComponentsDataList = new List<Tuple<ECardItemComponent, string>>();

		// Token: 0x0402018B RID: 131467
		public PhantomCardData Data;

		// Token: 0x0402018C RID: 131468
		public float HalfWidth;

		// Token: 0x0402018D RID: 131469
		public float HalfHeight;

		// Token: 0x0402018E RID: 131470
		protected AActor CopyEffect;
	}
}
