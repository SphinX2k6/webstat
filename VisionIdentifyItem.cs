using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002520 RID: 9504
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionIdentifyItem : GridProxyAbstract<VisionSubPropViewData>
{
	// Token: 0x06012764 RID: 75620 RVA: 0x00514F22 File Offset: 0x00513122
	public override void Refresh(VisionSubPropViewData data, bool isSelected, int gridIndex)
	{
		if (data != null)
		{
			this.Update(data, data.SourceView);
		}
	}

	// Token: 0x06012765 RID: 75621 RVA: 0x00514F34 File Offset: 0x00513134
	public override object GetKey(VisionSubPropViewData data, int displayIndex)
	{
		return base.GridIndex;
	}

	// Token: 0x06012766 RID: 75622 RVA: 0x00514F44 File Offset: 0x00513144
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickButton))
		};
	}

	// Token: 0x06012767 RID: 75623 RVA: 0x00515074 File Offset: 0x00513274
	private void OnClickButton()
	{
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.VisionIntensifyView))
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnClickVisionIntensifyItemJump);
			return;
		}
		if (this.VisionData != null)
		{
			VisionIntensifyViewPassData visionIntensifyViewPassData = new VisionIntensifyViewPassData();
			visionIntensifyViewPassData.UniqueId = this.VisionData.GetIncrId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionIntensifyView, visionIntensifyViewPassData, delegate(bool _1, int _2)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnClickVisionIntensifyItemJump);
			});
		}
	}

	// Token: 0x06012768 RID: 75624 RVA: 0x005150F1 File Offset: 0x005132F1
	protected override void OnStart()
	{
		this.LevelSequence = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x06012769 RID: 75625 RVA: 0x00515104 File Offset: 0x00513304
	public UniTask PlaySequenceAndUpdate(float delayTime, float animateTime)
	{
		VisionIdentifyItem.<PlaySequenceAndUpdate>d__16 <PlaySequenceAndUpdate>d__;
		<PlaySequenceAndUpdate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaySequenceAndUpdate>d__.<>4__this = this;
		<PlaySequenceAndUpdate>d__.delayTime = delayTime;
		<PlaySequenceAndUpdate>d__.animateTime = animateTime;
		<PlaySequenceAndUpdate>d__.<>1__state = -1;
		<PlaySequenceAndUpdate>d__.<>t__builder.Start<VisionIdentifyItem.<PlaySequenceAndUpdate>d__16>(ref <PlaySequenceAndUpdate>d__);
		return <PlaySequenceAndUpdate>d__.<>t__builder.Task;
	}

	// Token: 0x0601276A RID: 75626 RVA: 0x00515158 File Offset: 0x00513358
	public void Update(VisionSubPropViewData data, string sourceView)
	{
		this.ViewData = data;
		VisionSubPropData data2 = data.Data;
		this.SourceViewName = sourceView;
		this.VisionData = data.CurrentVisionData;
		this.CurrentData = data2;
		if (data.IfPreCache)
		{
			return;
		}
		this.RefreshAttributeName(data2);
		this.RefreshAttributeNum(data2);
		this.RefreshButtonJumpState(data2);
		this.RefreshSpriteBg(data2);
		this.RefreshTransitionColor(data2);
		this.RefreshHighLight(data);
		this.RefreshTextColor(data2);
	}

	// Token: 0x0601276B RID: 75627 RVA: 0x005151C8 File Offset: 0x005133C8
	private void RefreshButtonJumpState(VisionSubPropData data)
	{
		bool flag = data.SlotState == EVisionSlotState.UnlockAndNoProp && this.CheckCanJump();
		base.GetButton(5).RootUIComp.Get().SetRaycastTarget(flag);
		base.GetItem(2).SetUIActive(flag);
	}

	// Token: 0x0601276C RID: 75628 RVA: 0x00515210 File Offset: 0x00513410
	private bool CheckCanJump()
	{
		bool flag = ModelBase<PhantomBattleModel>.Instance.GetVisionLevelUpIdentify() == EVisionLevelUpIdentify.EnableIdentify;
		return (this.SourceViewName == "VisionLevelUpView" && !flag) || this.SourceViewName == "VisionEquipmentView";
	}

	// Token: 0x0601276D RID: 75629 RVA: 0x00515254 File Offset: 0x00513454
	private string GetColor(VisionSubPropData data)
	{
		string result = "";
		if (data.SlotState == EVisionSlotState.Lock)
		{
			result = "F9FFFF66";
		}
		else if (data.SlotState == EVisionSlotState.UnlockAndNoProp)
		{
			if (this.IfShowLikeLevelUpView())
			{
				result = "F7EBA6FF";
			}
			else
			{
				result = "F9FFFFCC";
			}
		}
		else if (data.SlotState == EVisionSlotState.UnlockAndHaveProp)
		{
			result = "F9FFFFCC";
		}
		else if (data.SlotState == EVisionSlotState.PreviewUnLock)
		{
			result = "F9FFFFCC";
		}
		else if (data.SlotState == EVisionSlotState.PrepareToIdentify)
		{
			result = "F7EBA6FF";
		}
		else if (data.SlotState == EVisionSlotState.PreviewCanIdentify)
		{
			result = "F7EBA6FF";
		}
		return result;
	}

	// Token: 0x0601276E RID: 75630 RVA: 0x005152DC File Offset: 0x005134DC
	private void RefreshTextColor(VisionSubPropData data)
	{
		FColor color = FColor.FromHex(this.GetColor(data));
		base.GetText(0).SetColor(color);
		base.GetText(1).SetColor(color);
		base.GetItem(2).SetColor(color);
	}

	// Token: 0x0601276F RID: 75631 RVA: 0x00515320 File Offset: 0x00513520
	private void RefreshTransitionColor(VisionSubPropData data)
	{
		FColor fcolor = FColor.FromHex(this.GetColor(data));
		UUIItem item = base.GetItem(7);
		FSpriteTransitionInfo transitionInfo = (item.GetOwner().GetComponentByClass(UUISpriteTransition.StaticClass()) as UUISpriteTransition).TransitionInfo;
		transitionInfo.HighlightedTransition.Color = fcolor;
		transitionInfo.NormalTransition.Color = fcolor;
		transitionInfo.DisabledTransition.Color = fcolor;
		item.SetColor(fcolor);
		UUIItem item2 = base.GetItem(8);
		FTextTransitionInfo transitionInfo2 = (item2.GetOwner().GetComponentByClass(UUITextTransition.StaticClass()) as UUITextTransition).TransitionInfo;
		transitionInfo2.HighlightedTransition.FontColor = fcolor;
		transitionInfo2.DisabledTransition.FontColor = fcolor;
		transitionInfo2.NormalTransition.FontColor = fcolor;
		item2.SetColor(fcolor);
		UUIItem item3 = base.GetItem(10);
		FSpriteTransitionInfo transitionInfo3 = (item3.GetOwner().GetComponentByClass(UUISpriteTransition.StaticClass()) as UUISpriteTransition).TransitionInfo;
		transitionInfo3.HighlightedTransition.Color = fcolor;
		transitionInfo3.DisabledTransition.Color = fcolor;
		transitionInfo3.NormalTransition.Color = fcolor;
		item3.SetColor(fcolor);
	}

	// Token: 0x06012770 RID: 75632 RVA: 0x00515428 File Offset: 0x00513628
	private void RefreshAttributeName(VisionSubPropData data)
	{
		bool flag = ModelBase<PhantomBattleModel>.Instance.GetVisionLevelUpIdentify() == EVisionLevelUpIdentify.EnableIdentify;
		bool flag2 = this.SourceViewName == "VisionLevelUpView" && flag;
		int? num = null;
		string textStringId;
		switch (data.SlotState)
		{
		case EVisionSlotState.Lock:
			textStringId = (flag2 ? "TuneEchoesProject_Warning01" : "LevelUpAndIdentify");
			num = new int?(data.GetUnlockLevel());
			break;
		case EVisionSlotState.UnlockAndNoProp:
			textStringId = (flag2 ? "TuneEchoesProject_Tips01" : "WaitForIdentify");
			break;
		case EVisionSlotState.PreviewUnLock:
			textStringId = (flag2 ? "TuneEchoesProject_Warning01" : "LevelUpAndIdentify");
			num = new int?(data.GetUnlockLevel());
			break;
		case EVisionSlotState.UnlockAndHaveProp:
			textStringId = data.GetSubPropName();
			break;
		case EVisionSlotState.PreviewCanIdentify:
			textStringId = "CurrentIdentifyUnlockText";
			break;
		case EVisionSlotState.PrepareToIdentify:
			textStringId = "CurrentIdentifyUnlockText";
			break;
		default:
			textStringId = "";
			break;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textStringId, new <>z__ReadOnlySingleElementList<object>(num));
	}

	// Token: 0x06012771 RID: 75633 RVA: 0x00515518 File Offset: 0x00513718
	private void RefreshAttributeNum(VisionSubPropData data)
	{
		bool flag = data.SlotState == EVisionSlotState.UnlockAndHaveProp;
		base.GetText(1).SetUIActive(flag);
		if (flag)
		{
			base.GetText(1).SetText(data.GetAttributeValueString(), true);
		}
	}

	// Token: 0x06012772 RID: 75634 RVA: 0x00515552 File Offset: 0x00513752
	private void RefreshHighLight(VisionSubPropViewData data)
	{
		base.GetItem(9).SetUIActive(data.NeedHighLight);
	}

	// Token: 0x06012773 RID: 75635 RVA: 0x00515567 File Offset: 0x00513767
	private bool IfShowLikeLevelUpView()
	{
		return this.SourceViewName == "VisionLevelUpView" || this.SourceViewName == "VisionEquipmentView";
	}

	// Token: 0x06012774 RID: 75636 RVA: 0x0051558D File Offset: 0x0051378D
	private void RefreshSpriteBg(VisionSubPropData data)
	{
		base.GetItem(3).SetUIActive(data.SlotState == EVisionSlotState.UnlockAndNoProp && this.IfShowLikeLevelUpView());
	}

	// Token: 0x04009011 RID: 36881
	private const string NORMALCOLOR = "F9FFFFCC";

	// Token: 0x04009012 RID: 36882
	private const string GREENCOLOR = "F7EBA6FF";

	// Token: 0x04009013 RID: 36883
	private const string WHITECOLOR = "F9FFFFCC";

	// Token: 0x04009014 RID: 36884
	private const string GRAYCOLOR = "F9FFFF66";

	// Token: 0x04009015 RID: 36885
	private string SourceViewName = "";

	// Token: 0x04009016 RID: 36886
	[Nullable(2)]
	private VisionSubPropData CurrentData;

	// Token: 0x04009017 RID: 36887
	[Nullable(2)]
	private LevelSequencePlayer LevelSequence;

	// Token: 0x04009018 RID: 36888
	[Nullable(2)]
	private CustomPromise AnimationCustomPromise;

	// Token: 0x04009019 RID: 36889
	[Nullable(2)]
	private PhantomDataBase VisionData;

	// Token: 0x0400901A RID: 36890
	[Nullable(2)]
	private VisionSubPropViewData ViewData;

	// Token: 0x0200883B RID: 34875
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E033 RID: 188467
		AttributeText,
		// Token: 0x0402E034 RID: 188468
		NumText,
		// Token: 0x0402E035 RID: 188469
		ArrowItem,
		// Token: 0x0402E036 RID: 188470
		BgSprite,
		// Token: 0x0402E037 RID: 188471
		PointText,
		// Token: 0x0402E038 RID: 188472
		Button,
		// Token: 0x0402E039 RID: 188473
		PointTextTransition,
		// Token: 0x0402E03A RID: 188474
		ArrowSpriteTransition,
		// Token: 0x0402E03B RID: 188475
		AttributeTextTransition,
		// Token: 0x0402E03C RID: 188476
		HighLightItem,
		// Token: 0x0402E03D RID: 188477
		SprPointTransition
	}
}
