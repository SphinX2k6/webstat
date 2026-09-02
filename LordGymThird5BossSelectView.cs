using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002209 RID: 8713
[NullableContext(1)]
[Nullable(0)]
public class LordGymThird5BossSelectView : LordGymLordEntranceSelectView
{
	// Token: 0x17001457 RID: 5207
	// (get) Token: 0x06010719 RID: 67353 RVA: 0x0047DC6B File Offset: 0x0047BE6B
	protected override string ShopTextId
	{
		get
		{
			return "GymShopNew3.5_Text";
		}
	}

	// Token: 0x17001458 RID: 5208
	// (get) Token: 0x0601071A RID: 67354 RVA: 0x0047DC72 File Offset: 0x0047BE72
	protected override string ConfirmTextId
	{
		get
		{
			return "BossChanllengeStart";
		}
	}

	// Token: 0x17001459 RID: 5209
	// (get) Token: 0x0601071B RID: 67355 RVA: 0x0047DC79 File Offset: 0x0047BE79
	protected override int ShopTabIndex
	{
		get
		{
			return 5;
		}
	}

	// Token: 0x0601071C RID: 67356 RVA: 0x0047DC7C File Offset: 0x0047BE7C
	public LordGymThird5BossSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601071D RID: 67357 RVA: 0x0047DC85 File Offset: 0x0047BE85
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(6, typeof(UUIItem)));
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(7, typeof(UUIVerticalLayout)));
	}

	// Token: 0x0601071E RID: 67358 RVA: 0x0047DCC4 File Offset: 0x0047BEC4
	protected override void OpenSelectView()
	{
		ModelBase<LordGymModel>.Instance.EntranceEntityId = this.SelectedEntranceId;
		LordGymDifficultySelectViewParam param = new LordGymDifficultySelectViewParam
		{
			LordEntranceSetId = this.EntranceSetId,
			LordEntranceId = this.SelectedEntranceId,
			IsPlaySpecialSequence = false
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymThird5DifficultySelectView, param, delegate(bool _, int _)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.LordGymThird5BossSelectView, null);
		});
	}

	// Token: 0x0601071F RID: 67359 RVA: 0x0047DD38 File Offset: 0x0047BF38
	protected override void OnStart()
	{
		if (this.LordEntranceList != null && this.LordEntranceList.Count > 7)
		{
			base.GetVerticalLayout(7).SetAlign(ELGUILayoutAlignmentType.UpperLeft);
			base.GetVerticalLayout(7).SetHeightFitToChildren(true);
		}
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem != null)
		{
			captionItem.SetHomeBtnShowState(true);
		}
		PopupCaptionItem captionItem2 = this.CaptionItem;
		if (captionItem2 != null)
		{
			captionItem2.SetCloseCallBack(new Action(this.OnClickClose));
		}
		UUIItem item = base.GetItem(6);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.AddHomeBtnExitDungeonCallback();
		LordGymLordEntranceSelectViewParam lordGymLordEntranceSelectViewParam = this.OpenParam as LordGymLordEntranceSelectViewParam;
		if (lordGymLordEntranceSelectViewParam != null && lordGymLordEntranceSelectViewParam.IsPlaySpecialSequence.GetValueOrDefault())
		{
			this.UiViewSequence.StartSequenceName = "StartZ";
			return;
		}
		this.UiViewSequence.StartSequenceName = "Start01";
	}

	// Token: 0x06010720 RID: 67360 RVA: 0x0047DDFC File Offset: 0x0047BFFC
	public override string GetBlackScreenTypeOnOpenViewLoadScene()
	{
		LordGymLordEntranceSelectViewParam lordGymLordEntranceSelectViewParam = this.OpenParam as LordGymLordEntranceSelectViewParam;
		if (lordGymLordEntranceSelectViewParam != null && lordGymLordEntranceSelectViewParam.NeedBlackScreenAnim)
		{
			return "Start";
		}
		return "None";
	}

	// Token: 0x06010721 RID: 67361 RVA: 0x0047DE22 File Offset: 0x0047C022
	protected override void InitSelect()
	{
	}

	// Token: 0x06010722 RID: 67362 RVA: 0x0047DE24 File Offset: 0x0047C024
	protected override UniTask OnBeforeStartAsync()
	{
		LordGymThird5BossSelectView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LordGymThird5BossSelectView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010723 RID: 67363 RVA: 0x0047DE68 File Offset: 0x0047C068
	protected UniTask InitSelectAsync()
	{
		LordGymThird5BossSelectView.<InitSelectAsync>d__15 <InitSelectAsync>d__;
		<InitSelectAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSelectAsync>d__.<>4__this = this;
		<InitSelectAsync>d__.<>1__state = -1;
		<InitSelectAsync>d__.<>t__builder.Start<LordGymThird5BossSelectView.<InitSelectAsync>d__15>(ref <InitSelectAsync>d__);
		return <InitSelectAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010724 RID: 67364 RVA: 0x0047DEAB File Offset: 0x0047C0AB
	protected override LordGymLordEntranceItem CreateItem()
	{
		return new LordGymThirdBossItem
		{
			OnToggleClick = new Action<int>(base.OnLordEntranceToggleClick),
			CanExecuteChangeCallBack = new Func<int, bool>(base.CanLordEntranceToggleChange)
		};
	}

	// Token: 0x06010725 RID: 67365 RVA: 0x0047DED6 File Offset: 0x0047C0D6
	protected override void ReBuildLordEntranceList()
	{
		if (this.LordEntranceList != null && this.LordEntranceList.Count < 2)
		{
			this.LordEntranceList.Add(0);
		}
	}

	// Token: 0x06010726 RID: 67366 RVA: 0x0047DEFC File Offset: 0x0047C0FC
	protected override void OnHandleLoadScene()
	{
		if (!Singleton<UiSceneManager>.Instance.HasLordSkeletalHandle())
		{
			Singleton<UiSceneManager>.Instance.InitLordSkeletalHandle();
			ControllerBase<LordGymController>.Instance.CreateLordModelByEntranceId();
			ControllerBase<LordGymController>.Instance.LoadLordModelByEntranceIdThird5(this.SelectedEntranceId, true, true);
		}
		else
		{
			ControllerBase<LordGymController>.Instance.CreateLordModelByEntranceId();
		}
		ControllerBase<LordGymController>.Instance.PlayLordModelMaterialAnimationByEntranceIdThird5(this.SelectedEntranceId, null, null, this.HasPlayEffect, !this.HasPlayEffect);
		this.HasPlayEffect = true;
	}

	// Token: 0x06010727 RID: 67367 RVA: 0x0047DF70 File Offset: 0x0047C170
	protected override UniTask OnHandlePostLoadSceneAsync(bool isSceneLoad)
	{
		LordGymThird5BossSelectView.<OnHandlePostLoadSceneAsync>d__19 <OnHandlePostLoadSceneAsync>d__;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePostLoadSceneAsync>d__.<>4__this = this;
		<OnHandlePostLoadSceneAsync>d__.isSceneLoad = isSceneLoad;
		<OnHandlePostLoadSceneAsync>d__.<>1__state = -1;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder.Start<LordGymThird5BossSelectView.<OnHandlePostLoadSceneAsync>d__19>(ref <OnHandlePostLoadSceneAsync>d__);
		return <OnHandlePostLoadSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010728 RID: 67368 RVA: 0x0047DFBC File Offset: 0x0047C1BC
	protected override UniTask OnHandlePreReleaseSceneAsync(bool isSceneRelease)
	{
		LordGymThird5BossSelectView.<OnHandlePreReleaseSceneAsync>d__20 <OnHandlePreReleaseSceneAsync>d__;
		<OnHandlePreReleaseSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePreReleaseSceneAsync>d__.isSceneRelease = isSceneRelease;
		<OnHandlePreReleaseSceneAsync>d__.<>1__state = -1;
		<OnHandlePreReleaseSceneAsync>d__.<>t__builder.Start<LordGymThird5BossSelectView.<OnHandlePreReleaseSceneAsync>d__20>(ref <OnHandlePreReleaseSceneAsync>d__);
		return <OnHandlePreReleaseSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010729 RID: 67369 RVA: 0x0047DFFF File Offset: 0x0047C1FF
	protected override void OnHandleReleaseScene()
	{
		Singleton<UiSceneManager>.Instance.DestroyLordSkeletalHandle();
	}

	// Token: 0x0601072A RID: 67370 RVA: 0x0047E00C File Offset: 0x0047C20C
	public override void SelectLordEntranceByIndex(int index)
	{
		int num = this.LordEntranceList[index];
		if (num == 0)
		{
			return;
		}
		GenericScrollViewNew<LordGymLordEntranceItem, int> lordEntranceScrollView = this.LordEntranceScrollView;
		if (lordEntranceScrollView != null)
		{
			GenericLayout<LordGymLordEntranceItem, int> genericLayout = lordEntranceScrollView.GetGenericLayout();
			if (genericLayout != null)
			{
				genericLayout.SelectGridProxy(index, false);
			}
		}
		this.SelectedEntranceId = num;
		ControllerBase<LordGymController>.Instance.LoadLordModelByEntranceIdThird5(this.SelectedEntranceId, true, true);
		base.PlaySequence("Switch", null, false);
	}

	// Token: 0x0601072B RID: 67371 RVA: 0x0047E070 File Offset: 0x0047C270
	protected UniTask SelectLordEntranceByIndexAsync(int index)
	{
		LordGymThird5BossSelectView.<SelectLordEntranceByIndexAsync>d__23 <SelectLordEntranceByIndexAsync>d__;
		<SelectLordEntranceByIndexAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SelectLordEntranceByIndexAsync>d__.<>4__this = this;
		<SelectLordEntranceByIndexAsync>d__.index = index;
		<SelectLordEntranceByIndexAsync>d__.<>1__state = -1;
		<SelectLordEntranceByIndexAsync>d__.<>t__builder.Start<LordGymThird5BossSelectView.<SelectLordEntranceByIndexAsync>d__23>(ref <SelectLordEntranceByIndexAsync>d__);
		return <SelectLordEntranceByIndexAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601072C RID: 67372 RVA: 0x0047E0BB File Offset: 0x0047C2BB
	protected override void OnBeforeDestroy()
	{
		ControllerBase<InstanceDungeonEntranceController>.Instance.RestoreDungeonEntranceEntity();
	}

	// Token: 0x0601072D RID: 67373 RVA: 0x0047E0C7 File Offset: 0x0047C2C7
	private void AddHomeBtnExitDungeonCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			LordGymThird5BossSelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__25_0>d <<AddHomeBtnExitDungeonCallback>b__25_0>d;
			<<AddHomeBtnExitDungeonCallback>b__25_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExitDungeonCallback>b__25_0>d.<>1__state = -1;
			<<AddHomeBtnExitDungeonCallback>b__25_0>d.<>t__builder.Start<LordGymThird5BossSelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__25_0>d>(ref <<AddHomeBtnExitDungeonCallback>b__25_0>d);
			return <<AddHomeBtnExitDungeonCallback>b__25_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x0601072E RID: 67374 RVA: 0x0047E0F8 File Offset: 0x0047C2F8
	private void OnClickClose()
	{
		if (ControllerBase<LordGymController>.Instance.IsInLordGymDungeon())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.LordGymThird5BossSelectExitConfirm);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().ContinueWith(delegate(bool _)
				{
					base.CloseMe(null);
				});
			};
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0400817F RID: 33151
	private bool HasPlayEffect;

	// Token: 0x020084D7 RID: 34007
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402D00B RID: 184331
		public const int ShopHotDot = 6;

		// Token: 0x0402D00C RID: 184332
		public const int Content = 7;
	}
}
