using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020024DE RID: 9438
[NullableContext(1)]
[Nullable(0)]
public class PhantomInteractSummonView : UiViewBase
{
	// Token: 0x06012524 RID: 75044 RVA: 0x005090A9 File Offset: 0x005072A9
	public PhantomInteractSummonView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012525 RID: 75045 RVA: 0x005090C8 File Offset: 0x005072C8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent))
		};
		List<ValueTuple<int, Delegate>> list = new List<ValueTuple<int, Delegate>>();
		int item = 2;
		Action item2;
		if ((item2 = PhantomInteractSummonView.<>O.<0>__OnClickEditBtn) == null)
		{
			item2 = (PhantomInteractSummonView.<>O.<0>__OnClickEditBtn = new Action(PhantomInteractSummonView.OnClickEditBtn));
		}
		list.Add(new ValueTuple<int, Delegate>(item, item2));
		list.Add(new ValueTuple<int, Delegate>(7, new Action(this.OnClickBlank)));
		this.BtnBindInfo = list;
	}

	// Token: 0x06012526 RID: 75046 RVA: 0x005091DA File Offset: 0x005073DA
	private void OnClickedCloseButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x06012527 RID: 75047 RVA: 0x005091E4 File Offset: 0x005073E4
	protected override UniTask OnBeforeStartAsync()
	{
		PhantomInteractSummonView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomInteractSummonView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012528 RID: 75048 RVA: 0x00509228 File Offset: 0x00507428
	private UniTask PreloadSceneEffect(string effectPath)
	{
		PhantomInteractSummonView.<PreloadSceneEffect>d__16 <PreloadSceneEffect>d__;
		<PreloadSceneEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PreloadSceneEffect>d__.<>4__this = this;
		<PreloadSceneEffect>d__.effectPath = effectPath;
		<PreloadSceneEffect>d__.<>1__state = -1;
		<PreloadSceneEffect>d__.<>t__builder.Start<PhantomInteractSummonView.<PreloadSceneEffect>d__16>(ref <PreloadSceneEffect>d__);
		return <PreloadSceneEffect>d__.<>t__builder.Task;
	}

	// Token: 0x06012529 RID: 75049 RVA: 0x00509274 File Offset: 0x00507474
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.Clear();
		}
		this.SeqPlayer = null;
		if (this.PostFxHandle != null)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.PostFxHandle.Value, "PhantomInteractSummonView_Destroy", true, null);
			this.PostFxHandle = null;
		}
	}

	// Token: 0x0601252A RID: 75050 RVA: 0x005092D8 File Offset: 0x005074D8
	protected override void OnStart()
	{
		bool uiactive = Singleton<Info>.Instance.IsInTouch();
		base.GetItem(3).SetUIActive(uiactive);
		ModelBase<PhantomInteractModel>.Instance.DisableAutoExposureOnViewOpen();
	}

	// Token: 0x0601252B RID: 75051 RVA: 0x00509307 File Offset: 0x00507507
	protected override void OnAddEventListener()
	{
		if (Singleton<EventSystem>.Instance.HasWithTarget<HitInformation, HitContext>(SceneTeam.Local, EEventName.CharBeHitLocal, new Action<HitInformation, HitContext>(this.OnCharBeHit)))
		{
			return;
		}
		Singleton<EventSystem>.Instance.AddWithTarget(SceneTeam.Local, EEventName.CharBeHitLocal, new Action<HitInformation, HitContext>(this.OnCharBeHit));
	}

	// Token: 0x0601252C RID: 75052 RVA: 0x00509347 File Offset: 0x00507547
	protected override void OnRemoveEventListener()
	{
		this.RemoveCharBeHitListener();
	}

	// Token: 0x0601252D RID: 75053 RVA: 0x00509350 File Offset: 0x00507550
	protected override void OnBeforeShow()
	{
		PhantomInteractModel instance = ModelBase<PhantomInteractModel>.Instance;
		this.Refresh(instance.InteractInfoData);
		PhantomInteractDetailPanelGroup detailPanelGroup = this.DetailPanelGroup;
		if (detailPanelGroup != null)
		{
			detailPanelGroup.RefreshDetailPanel(false, null);
		}
		PhantomInteractListPanel visionList = this.VisionList;
		if (visionList != null)
		{
			visionList.SetSelectedItem(-1);
		}
		if (this.RedDotItem != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotPhantomInteractEditEntry, this.RedDotItem, null, 0);
		}
		this.SetOtherTeamEntitiesEnable(false);
	}

	// Token: 0x0601252E RID: 75054 RVA: 0x005093BC File Offset: 0x005075BC
	protected override void OnAfterHide()
	{
		PhantomInteractDetailPanelGroup detailPanelGroup = this.DetailPanelGroup;
		if (detailPanelGroup != null)
		{
			detailPanelGroup.RefreshDetailPanel(false, null);
		}
		this.ShowDetail = false;
		if (this.RedDotItem != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotPhantomInteractEditEntry, this.RedDotItem, 0);
		}
		this.SetOtherTeamEntitiesEnable(true);
	}

	// Token: 0x0601252F RID: 75055 RVA: 0x00509408 File Offset: 0x00507608
	protected override void OnAfterDestroy()
	{
		PhantomInteractModel instance = ModelBase<PhantomInteractModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.ReEnableAutoExposureOnViewClose();
	}

	// Token: 0x06012530 RID: 75056 RVA: 0x00509419 File Offset: 0x00507619
	public void Refresh(PhantomInteractInfoData viewData)
	{
		this.VisionList.Refresh(viewData.EquippedVisionData.Cast<IPhantomInteractItemData>().ToList<IPhantomInteractItemData>(), false, false);
	}

	// Token: 0x06012531 RID: 75057 RVA: 0x00509438 File Offset: 0x00507638
	private void OnListItemClick(IPhantomInteractItemData itemData)
	{
		this.VisionList.SetSelectedItem(itemData.ItemIndex);
		if (itemData.MonsterId > 0)
		{
			ControllerBase<PhantomInteractController>.Instance.BeginVisionSkill(itemData.MonsterId);
			base.CloseMe(null);
			return;
		}
		ControllerBase<PhantomInteractController>.Instance.OpenPhantomVisionEditView(itemData.ItemIndex, true);
	}

	// Token: 0x06012532 RID: 75058 RVA: 0x00509488 File Offset: 0x00507688
	private void OnListItemLongPress(IPhantomInteractItemData itemData, bool isHover)
	{
		if (!isHover)
		{
			return;
		}
		if (this.ShowDetail && this.LongPressDetailMonsterId == itemData.MonsterId)
		{
			return;
		}
		PhantomInteractEditViewModel editViewModel = ModelBase<PhantomInteractModel>.Instance.EditViewModel;
		IPhantomInteractGridViewModel gridViewModel = null;
		PhantomInteractEditGridViewModel phantomInteractEditGridViewModel;
		if (editViewModel.GridViewModelMap.TryGetValue(itemData.MonsterId, out phantomInteractEditGridViewModel))
		{
			gridViewModel = phantomInteractEditGridViewModel;
		}
		PhantomInteractListPanel visionList = this.VisionList;
		if (visionList != null)
		{
			visionList.SetSelectedItem(itemData.ItemIndex);
		}
		this.DetailViewModel.RefreshData(gridViewModel);
		PhantomInteractDetailPanelGroup detailPanelGroup = this.DetailPanelGroup;
		if (detailPanelGroup != null)
		{
			detailPanelGroup.RefreshDetailPanel(true, this.DetailViewModel);
		}
		this.LongPressDetailMonsterId = itemData.MonsterId;
		this.ShowDetail = true;
	}

	// Token: 0x06012533 RID: 75059 RVA: 0x00509520 File Offset: 0x00507720
	private void OnListItemHover(IPhantomInteractItemData itemData, bool isHover)
	{
		bool flag = isHover && ((itemData != null) ? itemData.MonsterId : 0) > 0;
		if (flag && !this.ShowDetail)
		{
			PhantomInteractEditViewModel editViewModel = ModelBase<PhantomInteractModel>.Instance.EditViewModel;
			IPhantomInteractGridViewModel gridViewModel = null;
			PhantomInteractEditGridViewModel phantomInteractEditGridViewModel;
			if (editViewModel.GridViewModelMap.TryGetValue(itemData.MonsterId, out phantomInteractEditGridViewModel))
			{
				gridViewModel = phantomInteractEditGridViewModel;
			}
			this.DetailViewModel.RefreshData(gridViewModel);
			PhantomInteractDetailPanelGroup detailPanelGroup = this.DetailPanelGroup;
			if (detailPanelGroup != null)
			{
				detailPanelGroup.RefreshDetailPanel(true, this.DetailViewModel);
			}
		}
		else
		{
			PhantomInteractDetailPanelGroup detailPanelGroup2 = this.DetailPanelGroup;
			if (detailPanelGroup2 != null)
			{
				detailPanelGroup2.RefreshDetailPanel(false, null);
			}
		}
		this.ShowDetail = flag;
	}

	// Token: 0x06012534 RID: 75060 RVA: 0x005095B0 File Offset: 0x005077B0
	private static void OnClickEditBtn()
	{
		ControllerBase<PhantomInteractController>.Instance.OpenPhantomVisionEditView(0, true);
	}

	// Token: 0x06012535 RID: 75061 RVA: 0x005095BE File Offset: 0x005077BE
	private void OnClickBlank()
	{
		if (!this.ShowDetail)
		{
			base.CloseMe(null);
			return;
		}
		this.ShowDetail = false;
		PhantomInteractDetailPanelGroup detailPanelGroup = this.DetailPanelGroup;
		if (detailPanelGroup != null)
		{
			detailPanelGroup.RefreshDetailPanel(false, null);
		}
		PhantomInteractListPanel visionList = this.VisionList;
		if (visionList == null)
		{
			return;
		}
		visionList.SetSelectedItem(-1);
	}

	// Token: 0x06012536 RID: 75062 RVA: 0x005095FB File Offset: 0x005077FB
	private void OnCharBeHit(HitInformation hitData, HitContext hitContext)
	{
		this.RemoveCharBeHitListener();
		Singleton<UiManager>.Instance.ResetToBattleView(null);
	}

	// Token: 0x06012537 RID: 75063 RVA: 0x0050960E File Offset: 0x0050780E
	private void RemoveCharBeHitListener()
	{
		if (!Singleton<EventSystem>.Instance.HasWithTarget<HitInformation, HitContext>(SceneTeam.Local, EEventName.CharBeHitLocal, new Action<HitInformation, HitContext>(this.OnCharBeHit)))
		{
			return;
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget(SceneTeam.Local, EEventName.CharBeHitLocal, new Action<HitInformation, HitContext>(this.OnCharBeHit));
	}

	// Token: 0x06012538 RID: 75064 RVA: 0x00509650 File Offset: 0x00507850
	private void SetOtherTeamEntitiesEnable(bool isEnable)
	{
		foreach (EntityHandle entityHandle in ModelBase<SceneTeamModel>.Instance.GetTeamEntities(false))
		{
			Entity entity = entityHandle.Entity;
			if (!(!entity) && !entity.GetComponent<CharacterActorComponent>().IsAutonomousProxy)
			{
				if (isEnable)
				{
					int handle;
					if (this.DisabledEntityHandles.TryGetValue(entity.Id, out handle))
					{
						entity.Enable(handle, "PhantomInteractSummonView_Show");
						this.DisabledEntityHandles.Remove(entity.Id);
					}
				}
				else
				{
					int value = entity.Disable("PhantomInteractSummonView_Show");
					this.DisabledEntityHandles[entity.Id] = value;
				}
			}
		}
		if (isEnable)
		{
			this.DisabledEntityHandles.Clear();
		}
	}

	// Token: 0x04008EEA RID: 36586
	private const string POST_FX_PATH = "/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_Post_SimpleLight.DA_Fx_Group_Post_SimpleLight";

	// Token: 0x04008EEB RID: 36587
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04008EEC RID: 36588
	[Nullable(2)]
	private PhantomInteractListPanel VisionList;

	// Token: 0x04008EED RID: 36589
	[Nullable(2)]
	private PhantomInteractDetailPanelGroup DetailPanelGroup;

	// Token: 0x04008EEE RID: 36590
	private bool ShowDetail;

	// Token: 0x04008EEF RID: 36591
	private readonly PhantomInteractDetailViewModel DetailViewModel = new PhantomInteractDetailViewModel();

	// Token: 0x04008EF0 RID: 36592
	[Nullable(2)]
	private UUIItem RedDotItem;

	// Token: 0x04008EF1 RID: 36593
	[Nullable(2)]
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x04008EF2 RID: 36594
	private int? PostFxHandle;

	// Token: 0x04008EF3 RID: 36595
	private int LongPressDetailMonsterId;

	// Token: 0x04008EF4 RID: 36596
	private readonly Dictionary<int, int> DisabledEntityHandles = new Dictionary<int, int>();

	// Token: 0x020087E9 RID: 34793
	[NullableContext(0)]
	private enum ENode
	{
		// Token: 0x0402DEAB RID: 188075
		ItemVisionList,
		// Token: 0x0402DEAC RID: 188076
		ItemCaption,
		// Token: 0x0402DEAD RID: 188077
		BtnEdit,
		// Token: 0x0402DEAE RID: 188078
		ItemLongPressTip,
		// Token: 0x0402DEAF RID: 188079
		TxtLongPressTip,
		// Token: 0x0402DEB0 RID: 188080
		ItemPanelPhantomTip,
		// Token: 0x0402DEB1 RID: 188081
		ItemRedDot,
		// Token: 0x0402DEB2 RID: 188082
		BtnBlank
	}

	// Token: 0x020087EA RID: 34794
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402DEB3 RID: 188083
		[Nullable(0)]
		public static Action <0>__OnClickEditBtn;
	}
}
