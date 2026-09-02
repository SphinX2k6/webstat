using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FA9 RID: 4009
[NullableContext(2)]
[Nullable(0)]
public class ProjectionPhotoView : UiTickViewBase
{
	// Token: 0x170007F7 RID: 2039
	// (get) Token: 0x060066AA RID: 26282 RVA: 0x0019DD96 File Offset: 0x0019BF96
	private new ProjectionPhotoViewParams OpenParam
	{
		get
		{
			return this.OpenParam as ProjectionPhotoViewParams;
		}
	}

	// Token: 0x060066AB RID: 26283 RVA: 0x0019DDA4 File Offset: 0x0019BFA4
	[NullableContext(1)]
	public ProjectionPhotoView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x060066AC RID: 26284 RVA: 0x0019DE00 File Offset: 0x0019C000
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(3, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText))
		};
	}

	// Token: 0x060066AD RID: 26285 RVA: 0x0019DF0C File Offset: 0x0019C10C
	protected override UniTask OnBeforeStartAsync()
	{
		ProjectionPhotoView.<OnBeforeStartAsync>d__23 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ProjectionPhotoView.<OnBeforeStartAsync>d__23>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060066AE RID: 26286 RVA: 0x0019DF50 File Offset: 0x0019C150
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnProjectionPhotoItemPointDown, new Action(this.OnProjectionPhotoItemPointDown));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnProjectionPhotoItemPointUp, new Action(this.OnProjectionPhotoItemPointUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnProjectionPhotoItemStartDrag, new Action(this.OnProjectionPhotoItemPointDown));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnProjectionPhotoItemEndDrag, new Action(this.OnProjectionPhotoItemPointUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnProjectionPhotoFinishDrag, new Action(this.OnProjectionPhotoFinishDrag));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnProjectionPhotoSliderEndDrag, new Action(this.OnSliderEndDrag));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHorizontalSliderValueFirstChange, new Action(this.OnHorizontalSliderValueFirstChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
	}

	// Token: 0x060066AF RID: 26287 RVA: 0x0019E03D File Offset: 0x0019C23D
	[NullableContext(1)]
	private void OnSequenceClose(string sequenceName)
	{
		if (sequenceName == "Close2" || sequenceName == "Activate")
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x060066B0 RID: 26288 RVA: 0x0019E060 File Offset: 0x0019C260
	private void OnSliderEndDrag()
	{
		this.CheckAllFinish();
	}

	// Token: 0x060066B1 RID: 26289 RVA: 0x0019E068 File Offset: 0x0019C268
	private void OnHorizontalSliderValueFirstChange()
	{
		UUIItem pnlDescTips = this.PnlDescTips;
		if (pnlDescTips == null)
		{
			return;
		}
		pnlDescTips.SetUIActive(false);
	}

	// Token: 0x060066B2 RID: 26290 RVA: 0x0019E07B File Offset: 0x0019C27B
	private void OnProjectionPhotoItemPointDown()
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.SetCloseBtnActive(false);
	}

	// Token: 0x060066B3 RID: 26291 RVA: 0x0019E08E File Offset: 0x0019C28E
	private void OnProjectionPhotoItemPointUp()
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.SetCloseBtnActive(true);
	}

	// Token: 0x060066B4 RID: 26292 RVA: 0x0019E0A1 File Offset: 0x0019C2A1
	private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.SetCloseBtnActive(true);
	}

	// Token: 0x060066B5 RID: 26293 RVA: 0x0019E0B4 File Offset: 0x0019C2B4
	private void SyncPnlDescTipsAnchorX()
	{
		if (this.PnlDescTips == null || this.IsSliderDisabled || this.OpenParam == null)
		{
			return;
		}
		IProjectionMachinePhotoFilter photoFilter = this.OpenParam.Config.PhotoFilter;
		float num = (photoFilter != null) ? photoFilter.DefaultParam1 : -1f;
		float num2 = (photoFilter != null) ? photoFilter.TargetParam1 : -1f;
		if (num == -1f && num2 == -1f)
		{
			return;
		}
		float num3 = Math.Clamp(num, 0f, 1f);
		float num4 = 1620f;
		float inX = -565f + num3 * num4;
		FVector2D anchorOffset = this.PnlDescTips.GetAnchorOffset();
		this.PnlDescTips.SetAnchorOffset(new FVector2D(inX, anchorOffset.Y));
	}

	// Token: 0x060066B6 RID: 26294 RVA: 0x0019E168 File Offset: 0x0019C368
	private void CheckAllFinish()
	{
		if (this.SliderHorizontalPanel.IsFinish() && this.SliderVerticalPanel.IsFinish())
		{
			this.FinishCallback(true);
			this.RequestHandInItem();
			if (this.IsSliderDisabled)
			{
				LevelSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer == null)
				{
					return;
				}
				sequencePlayer.PlayLevelSequenceByName("Activate", false, null, false);
				return;
			}
			else
			{
				TimerSystem.Instance.Delay(delegate(float _)
				{
					LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
					if (sequencePlayer2 == null)
					{
						return;
					}
					sequencePlayer2.PlayLevelSequenceByName("Close2", false, null, false);
				}, 0.7f, null, null, true, 1f);
			}
		}
	}

	// Token: 0x060066B7 RID: 26295 RVA: 0x0019E1F0 File Offset: 0x0019C3F0
	protected override void OnTick(float delta)
	{
		if (this.AutoFinishTimer > 0f)
		{
			this.AutoFinishTimer -= delta / 1000f;
			if (this.AutoFinishTimer <= 0f)
			{
				this.AutoFinishTimer = -1f;
				this.CheckAllFinish();
			}
		}
	}

	// Token: 0x060066B8 RID: 26296 RVA: 0x0019E23C File Offset: 0x0019C43C
	private void OnProjectionPhotoFinishDrag()
	{
		if (this.OpenParam != null)
		{
			LevelGeneralNetworks.RequestEntitySendEvent(this.OpenParam.EntityId, "ProjectionMachine_Choice");
		}
		this.PhotoItem.SetHidden(true);
		if (!this.IsSliderDisabled)
		{
			ProjectionPhotoViewParams openParam = this.OpenParam;
			if (openParam != null && openParam.PbDataId == 687700167)
			{
				UUIItem pnlDescTips = this.PnlDescTips;
				if (pnlDescTips != null)
				{
					pnlDescTips.SetUIActive(true);
				}
			}
		}
		if (this.IsSliderDisabled)
		{
			this.AutoFinishTimer = this.AutoFinishTime;
			return;
		}
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.PlayLevelSequenceByName("Change", false, null, false);
	}

	// Token: 0x060066B9 RID: 26297 RVA: 0x0019E2DC File Offset: 0x0019C4DC
	private void RequestHandInItem()
	{
		NewHandInItemRequest newHandInItemRequest = NewHandInItemRequest.Create();
		NewHandInItemsProjectionMachinePb newHandInItemsProjectionMachinePb = NewHandInItemsProjectionMachinePb.Create();
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(this.OpenParam.EntityId);
		WorldEntity worldEntity = (entity != null) ? entity.Entity : null;
		if (!worldEntity)
		{
			return;
		}
		CreatureDataComponent component = worldEntity.GetComponent<CreatureDataComponent>();
		newHandInItemsProjectionMachinePb.EntityCfgId = component.GetPbDataId();
		newHandInItemsProjectionMachinePb.ItemId = this.OpenParam.Config.ItemId;
		newHandInItemRequest.ProjectionMachine = newHandInItemsProjectionMachinePb;
		Singleton<Net>.Instance.Call<NewHandInItemResponse>(ERequestMessageId.NewHandInItemRequest, newHandInItemRequest, delegate(NewHandInItemResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.CH;
				string message = "ProjectionPhotoView RequestHandInItem failed";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ErrorCode", (response != null) ? new ErrorCode?(response.ErrorCode) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}, 0);
	}

	// Token: 0x040030CA RID: 12490
	[Nullable(1)]
	private const string DragFinishEvent = "ProjectionMachine_Choice";

	// Token: 0x040030CB RID: 12491
	private const int SHOW_TIPS_ENTITY_ID = 687700167;

	// Token: 0x040030CC RID: 12492
	private const float PnlDescTipsAnchorXAtSliderMin = -565f;

	// Token: 0x040030CD RID: 12493
	private const float PnlDescTipsAnchorXAtSliderMax = 1055f;

	// Token: 0x040030CE RID: 12494
	private PopupCaptionItem CaptionItem;

	// Token: 0x040030CF RID: 12495
	private ProjectionPhotoItem PhotoItem;

	// Token: 0x040030D0 RID: 12496
	private ProjectionPhotoItem FixedPhotoItem;

	// Token: 0x040030D1 RID: 12497
	private ProjectionPhotoDragItem PhotoDragItem;

	// Token: 0x040030D2 RID: 12498
	private ProjectionPhotoShowItem ItemShow;

	// Token: 0x040030D3 RID: 12499
	private ProjectionPhotoSlider SliderHorizontalPanel;

	// Token: 0x040030D4 RID: 12500
	private ProjectionPhotoSlider SliderVerticalPanel;

	// Token: 0x040030D5 RID: 12501
	private UUIItem PnlDescTips;

	// Token: 0x040030D6 RID: 12502
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x040030D7 RID: 12503
	private float SliderTolerance = 0.1f;

	// Token: 0x040030D8 RID: 12504
	[Nullable(1)]
	private Action<bool> FinishCallback = delegate(bool _)
	{
	};

	// Token: 0x040030D9 RID: 12505
	private bool IsSliderDisabled;

	// Token: 0x040030DA RID: 12506
	private float AutoFinishTime = 1.5f;

	// Token: 0x040030DB RID: 12507
	private float AutoFinishTimer = -1f;

	// Token: 0x020073A0 RID: 29600
	[NullableContext(0)]
	private enum EViewComponent
	{
		// Token: 0x0402803E RID: 163902
		ItemCaption,
		// Token: 0x0402803F RID: 163903
		ItemShow,
		// Token: 0x04028040 RID: 163904
		SliderHorizontal,
		// Token: 0x04028041 RID: 163905
		SliderVertical,
		// Token: 0x04028042 RID: 163906
		BtnPhotoA,
		// Token: 0x04028043 RID: 163907
		BtnPhotoB,
		// Token: 0x04028044 RID: 163908
		PnlTouch,
		// Token: 0x04028045 RID: 163909
		BtnDragPhoto,
		// Token: 0x04028046 RID: 163910
		PnlPhoto,
		// Token: 0x04028047 RID: 163911
		PnlDescTips,
		// Token: 0x04028048 RID: 163912
		TxtDescTips
	}
}
