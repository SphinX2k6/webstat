using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Scene.NewGacha.BP;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CDB RID: 7387
public class DrawMainViewNew : UiTickViewBase
{
	// Token: 0x0600D89D RID: 55453 RVA: 0x0039FFE2 File Offset: 0x0039E1E2
	[NullableContext(1)]
	public DrawMainViewNew(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600D89E RID: 55454 RVA: 0x0039FFF4 File Offset: 0x0039E1F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIDraggableComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickSkip));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D89F RID: 55455 RVA: 0x003A009C File Offset: 0x0039E29C
	protected override UniTask OnBeforeStartAsync()
	{
		DrawMainViewNew.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DrawMainViewNew.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D8A0 RID: 55456 RVA: 0x003A00D8 File Offset: 0x0039E2D8
	protected override void OnBeforeShow()
	{
		if (this.IsFirstShow)
		{
			int times = ModelBase<GachaModel>.Instance.CurGachaResult.Length;
			int num = 0;
			foreach (GachaResult gachaResult in ModelBase<GachaModel>.Instance.CurGachaResult)
			{
				int itemId = gachaResult.Proto_GachaReward.ItemId;
				ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
				int num2 = (itemConfigData != null) ? itemConfigData.QualityId : 0;
				this.HasNewItems = (this.HasNewItems || (num2 >= 4 && gachaResult.IsNew));
				num = Math.Max(num, num2);
			}
			this.InitGachaBp(times, num);
			this.InitAudioState(times, num);
			this.IsFirstShow = false;
		}
		if (Singleton<Info>.Instance.IsMacPlatform())
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.AllowHardwareOcclusion 0", null);
		}
		ControllerBase<MenuController>.Instance.CloseAllFilter();
	}

	// Token: 0x0600D8A1 RID: 55457 RVA: 0x003A01AC File Offset: 0x0039E3AC
	protected override void OnStart()
	{
		base.GetButton(1).RootUIComp.Get().SetUIActive(true);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600D8A2 RID: 55458 RVA: 0x003A01E4 File Offset: 0x0039E3E4
	protected override void OnTick(float delta)
	{
		if (!this.IsHold && !this.IsShowTips && !this.IsEnd)
		{
			this.Delay += delta;
			if (this.Delay > 2000f)
			{
				this.IsShowTips = true;
			}
		}
	}

	// Token: 0x0600D8A3 RID: 55459 RVA: 0x003A0220 File Offset: 0x0039E420
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.EndGachaScene, new Action(this.OnEndGacha));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.GachaClick, new Action<bool>(this.OnGachaClick));
		Singleton<EventSystem>.Instance.Add(EEventName.GachaInteractFinish, new Action(this.OnGachaInteractFinish));
	}

	// Token: 0x0600D8A4 RID: 55460 RVA: 0x003A0284 File Offset: 0x0039E484
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.EndGachaScene, new Action(this.OnEndGacha));
		Singleton<EventSystem>.Instance.Remove(EEventName.GachaClick, new Action<bool>(this.OnGachaClick));
		Singleton<EventSystem>.Instance.Remove(EEventName.GachaInteractFinish, new Action(this.OnGachaInteractFinish));
	}

	// Token: 0x0600D8A5 RID: 55461 RVA: 0x003A02E8 File Offset: 0x0039E4E8
	protected void InitGachaBp(int times, int maxQuality)
	{
		E_GachaResultNew gachaResult = E_GachaResultNew.OneShotNormal;
		if (times == 1)
		{
			if (maxQuality == 3)
			{
				gachaResult = E_GachaResultNew.OneShotNormal;
			}
			else if (maxQuality == 4)
			{
				gachaResult = E_GachaResultNew.OneShotPurple;
			}
			else if (maxQuality == 5)
			{
				gachaResult = E_GachaResultNew.OneShotGolden;
			}
		}
		else if (maxQuality == 4)
		{
			gachaResult = E_GachaResultNew.TenShotsPurple;
		}
		else if (maxQuality == 5)
		{
			gachaResult = E_GachaResultNew.TenShotsGolden;
		}
		this.MaxQuality = maxQuality;
		this.GachaBP = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("GachaBP").Value, ECollectActorType.Default) as BP_GachaInteract_C);
		this.GachaBP.TSInitParameters(gachaResult);
		this.GachaBP.SetTickableWhenPaused(true);
		UTimelineComponent timeline_ = this.GachaBP.Timeline_0;
		if (timeline_ == null)
		{
			return;
		}
		timeline_.SetTickableWhenPaused(true);
	}

	// Token: 0x0600D8A6 RID: 55462 RVA: 0x003A037C File Offset: 0x0039E57C
	protected void InitAudioState(int times, int maxQuality)
	{
		Singleton<AudioSystem>.Instance.SetState("ui_gacha_times", (times == 1) ? "one" : "ten", true);
		if (maxQuality == 3)
		{
			Singleton<AudioSystem>.Instance.SetState("ui_gacha_quality_max", "normal", true);
			return;
		}
		if (maxQuality == 4)
		{
			Singleton<AudioSystem>.Instance.SetState("ui_gacha_quality_max", "purple", true);
			return;
		}
		if (maxQuality == 5)
		{
			Singleton<AudioSystem>.Instance.SetState("ui_gacha_quality_max", "golden", true);
		}
	}

	// Token: 0x0600D8A7 RID: 55463 RVA: 0x003A03F8 File Offset: 0x0039E5F8
	protected override void OnBeforeDestroyImplement()
	{
		BP_GachaInteract_C gachaBP = this.GachaBP;
		if (gachaBP != null && gachaBP.IsValid())
		{
			BP_GachaInteract_C gachaBP2 = this.GachaBP;
			if (gachaBP2 != null)
			{
				gachaBP2.EndGachaSequence();
			}
			BP_GachaInteract_C gachaBP3 = this.GachaBP;
			if (gachaBP3 == null)
			{
				return;
			}
			ALevelSequenceActor levelSequenceShow = gachaBP3.LevelSequenceShow;
			if (levelSequenceShow == null)
			{
				return;
			}
			ULevelSequencePlayer sequencePlayer = levelSequenceShow.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.Stop();
		}
	}

	// Token: 0x0600D8A8 RID: 55464 RVA: 0x003A0450 File Offset: 0x0039E650
	protected void OnClickSkip()
	{
		this.GachaBP.IsSkip = true;
		if (this.GachaBP.WhiteScreen)
		{
			UTimelineComponent timeline_ = this.GachaBP.Timeline_0;
			if (timeline_ != null)
			{
				timeline_.Stop();
			}
			this.GachaBP.WhiteScreenOff();
		}
		this.OnEndGacha();
	}

	// Token: 0x0600D8A9 RID: 55465 RVA: 0x003A04A0 File Offset: 0x0039E6A0
	protected void OnEndGacha()
	{
		this.IsShowTips = true;
		if (this.IsFireEndGacha)
		{
			return;
		}
		if (this.GachaBP.IsSkip)
		{
			ControllerBase<BlackScreenController>.Instance.AddBlackScreenAsync("Start", "GachaSkip", "Black").ContinueWith(delegate()
			{
				if (this.MaxQuality == 5 || this.HasNewItems)
				{
					object obj = this.OpenParam;
					if (obj != null)
					{
						(obj as IGachaViewOpenData).IsOnlyShowGold = true;
					}
					else
					{
						obj = new GachaViewOpenData
						{
							SkipOnLoadResourceFinish = false,
							ResultViewHideExtraReward = false,
							IsOnlyShowGold = true
						};
					}
					Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaScanView, obj, delegate(bool _, int _)
					{
						Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
					});
					return;
				}
				Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaResultView, this.OpenParam, delegate(bool _, int _)
				{
					Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
				});
				BP_UpdateInteract_C bp_UpdateInteract_C = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("UpdateInteractBP").Value, ECollectActorType.Default) as BP_UpdateInteract_C;
				if (bp_UpdateInteract_C != null)
				{
					bp_UpdateInteract_C.EndGachaScene();
				}
				if (bp_UpdateInteract_C == null)
				{
					return;
				}
				bp_UpdateInteract_C.SetTickableWhenPaused(true);
			}).Forget();
		}
		else
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaScanView, this.OpenParam, delegate(bool _, int _)
			{
				Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
			});
		}
		this.IsFireEndGacha = true;
	}

	// Token: 0x0600D8AA RID: 55466 RVA: 0x003A0523 File Offset: 0x0039E723
	protected void OnGachaInteractFinish()
	{
		this.IsEnd = true;
		bool isShowTips = this.IsShowTips;
	}

	// Token: 0x0600D8AB RID: 55467 RVA: 0x003A0533 File Offset: 0x0039E733
	protected void OnGachaClick(bool isPress)
	{
		if (isPress)
		{
			this.IsHold = true;
			this.Delay = 0f;
			this.IsShowTips = false;
			return;
		}
		this.IsHold = false;
	}

	// Token: 0x0400676C RID: 26476
	private const int SHOW_TIPS_DELAY = 2000;

	// Token: 0x0400676D RID: 26477
	protected float Delay;

	// Token: 0x0400676E RID: 26478
	protected bool IsHold;

	// Token: 0x0400676F RID: 26479
	protected bool IsShowTips;

	// Token: 0x04006770 RID: 26480
	protected bool IsEnd;

	// Token: 0x04006771 RID: 26481
	protected int MaxQuality;

	// Token: 0x04006772 RID: 26482
	protected bool HasNewItems;

	// Token: 0x04006773 RID: 26483
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04006774 RID: 26484
	[Nullable(2)]
	protected BP_GachaInteract_C GachaBP;

	// Token: 0x04006775 RID: 26485
	protected bool IsFirstShow = true;

	// Token: 0x04006776 RID: 26486
	protected bool IsFireEndGacha;

	// Token: 0x02008023 RID: 32803
	private enum EDrawMainViewNewDefine
	{
		// Token: 0x0402B98D RID: 178573
		DragArea,
		// Token: 0x0402B98E RID: 178574
		SkipBtn
	}
}
