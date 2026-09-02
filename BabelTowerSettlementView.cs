using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Scene.NewGacha.BP;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001245 RID: 4677
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerSettlementView : UiViewBase
{
	// Token: 0x06007C97 RID: 31895 RVA: 0x0020C6F7 File Offset: 0x0020A8F7
	public BabelTowerSettlementView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007C98 RID: 31896 RVA: 0x0020C700 File Offset: 0x0020A900
	protected unsafe override void OnRegisterComponent()
	{
		int num = 24;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnShareButtonClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(17, new Action(this.OnConfirmButtonClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(19, new Action(this.OnBuff1ButtonClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(20, new Action(this.OnBuff2ButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007C99 RID: 31897 RVA: 0x0020CAF9 File Offset: 0x0020ACF9
	protected override void OnBeforeCreate()
	{
		this.GachaSequence = new UiBehaviorGachaSequence();
		base.AddUiBehavior(this.GachaSequence);
	}

	// Token: 0x06007C9A RID: 31898 RVA: 0x0020CB14 File Offset: 0x0020AD14
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerSettlementView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerSettlementView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007C9B RID: 31899 RVA: 0x0020CB58 File Offset: 0x0020AD58
	protected override void OnHandleLoadScene()
	{
		this.SceneSequenceCamera = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("SceneCamera1").Value, ECollectActorType.Default);
		this.GachaSequence.BindSceneSequenceCamera(this.SceneSequenceCamera);
		this.UpdateInteractBp = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("UpdateInteractBP").Value, ECollectActorType.Default) as BP_UpdateInteract_C);
		if (this.UpdateInteractBp != null)
		{
			this.UpdateInteractBp.SetTickableWhenPaused(true);
		}
		this.GachaSequence.BindUpdateInteractBp(this.UpdateInteractBp);
	}

	// Token: 0x06007C9C RID: 31900 RVA: 0x0020CBDC File Offset: 0x0020ADDC
	protected override void OnBeforeShow()
	{
		this.TryPlayRoleSequence();
	}

	// Token: 0x06007C9D RID: 31901 RVA: 0x0020CBE4 File Offset: 0x0020ADE4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnFirstShare, new Action(this.OnRewardShare));
	}

	// Token: 0x06007C9E RID: 31902 RVA: 0x0020CC02 File Offset: 0x0020AE02
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFirstShare, new Action(this.OnRewardShare));
	}

	// Token: 0x06007C9F RID: 31903 RVA: 0x0020CC20 File Offset: 0x0020AE20
	private static bool IsRankImproved(int oldRank, int newRank)
	{
		return newRank > 0 && (oldRank <= 0 || newRank < oldRank);
	}

	// Token: 0x06007CA0 RID: 31904 RVA: 0x0020CC32 File Offset: 0x0020AE32
	private BabelTowerSettlementDeTermLayoutItem CreateDeTermLayoutItem()
	{
		return new BabelTowerSettlementDeTermLayoutItem
		{
			TemplateActor = (base.GetItem(12).GetOwner() as AUIBaseActor)
		};
	}

	// Token: 0x06007CA1 RID: 31905 RVA: 0x0020CC51 File Offset: 0x0020AE51
	private BabelTowerSettlementRoleItem CreateRoleItem()
	{
		return new BabelTowerSettlementRoleItem();
	}

	// Token: 0x06007CA2 RID: 31906 RVA: 0x0020CC58 File Offset: 0x0020AE58
	private void OnShareButtonClick()
	{
		this.OpenShareView();
	}

	// Token: 0x06007CA3 RID: 31907 RVA: 0x0020CC60 File Offset: 0x0020AE60
	private void OpenShareView()
	{
		UiAsyncTask task = new UiAsyncTask("OpenShareView", delegate()
		{
			BabelTowerSettlementView.<<OpenShareView>b__24_0>d <<OpenShareView>b__24_0>d;
			<<OpenShareView>b__24_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OpenShareView>b__24_0>d.<>4__this = this;
			<<OpenShareView>b__24_0>d.<>1__state = -1;
			<<OpenShareView>b__24_0>d.<>t__builder.Start<BabelTowerSettlementView.<<OpenShareView>b__24_0>d>(ref <<OpenShareView>b__24_0>d);
			return <<OpenShareView>b__24_0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x06007CA4 RID: 31908 RVA: 0x0020CC90 File Offset: 0x0020AE90
	private UniTask WaitFrame()
	{
		BabelTowerSettlementView.<WaitFrame>d__25 <WaitFrame>d__;
		<WaitFrame>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitFrame>d__.<>1__state = -1;
		<WaitFrame>d__.<>t__builder.Start<BabelTowerSettlementView.<WaitFrame>d__25>(ref <WaitFrame>d__);
		return <WaitFrame>d__.<>t__builder.Task;
	}

	// Token: 0x06007CA5 RID: 31909 RVA: 0x0020CCCC File Offset: 0x0020AECC
	private UniTask OpenShareViewAsync()
	{
		BabelTowerSettlementView.<OpenShareViewAsync>d__26 <OpenShareViewAsync>d__;
		<OpenShareViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenShareViewAsync>d__.<>4__this = this;
		<OpenShareViewAsync>d__.<>1__state = -1;
		<OpenShareViewAsync>d__.<>t__builder.Start<BabelTowerSettlementView.<OpenShareViewAsync>d__26>(ref <OpenShareViewAsync>d__);
		return <OpenShareViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007CA6 RID: 31910 RVA: 0x0020CD10 File Offset: 0x0020AF10
	private void OnConfirmButtonClick()
	{
		BabelTowerHardLevelChoseViewData param = new BabelTowerHardLevelChoseViewData
		{
			IfReturnToBabelTowerMainView = true,
			IfLeaveInstanceDungeonWhenMainViewClose = true
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerHardLevelChoseView, param, null);
		base.CloseMe(null);
	}

	// Token: 0x06007CA7 RID: 31911 RVA: 0x0020CD4C File Offset: 0x0020AF4C
	private void OnBuff1ButtonClick()
	{
		BabelTowerItemInfoViewInfo babelTowerItemInfoViewInfo = new BabelTowerItemInfoViewInfo();
		babelTowerItemInfoViewInfo.IsDeTerm = false;
		IBabelTowerSettlementViewData data = this.Data;
		int? num;
		if (data == null)
		{
			num = null;
		}
		else
		{
			List<int> buffIdList = data.BuffIdList;
			num = ((buffIdList != null) ? buffIdList.GetValueOrNull(0) : null);
		}
		int? num2 = num;
		babelTowerItemInfoViewInfo.ConfigId = num2.GetValueOrDefault();
		babelTowerItemInfoViewInfo.ShowWays = false;
		BabelTowerItemInfoViewInfo param = babelTowerItemInfoViewInfo;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerItemInfoView, param, null);
	}

	// Token: 0x06007CA8 RID: 31912 RVA: 0x0020CDBC File Offset: 0x0020AFBC
	private void OnBuff2ButtonClick()
	{
		BabelTowerItemInfoViewInfo babelTowerItemInfoViewInfo = new BabelTowerItemInfoViewInfo();
		babelTowerItemInfoViewInfo.IsDeTerm = false;
		IBabelTowerSettlementViewData data = this.Data;
		int? num;
		if (data == null)
		{
			num = null;
		}
		else
		{
			List<int> buffIdList = data.BuffIdList;
			num = ((buffIdList != null) ? buffIdList.GetValueOrNull(1) : null);
		}
		int? num2 = num;
		babelTowerItemInfoViewInfo.ConfigId = num2.GetValueOrDefault();
		babelTowerItemInfoViewInfo.ShowWays = false;
		BabelTowerItemInfoViewInfo param = babelTowerItemInfoViewInfo;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerItemInfoView, param, null);
	}

	// Token: 0x06007CA9 RID: 31913 RVA: 0x0020CE2B File Offset: 0x0020B02B
	private void OnRewardShare()
	{
		this.RefreshShareRewardTip();
	}

	// Token: 0x06007CAA RID: 31914 RVA: 0x0020CE34 File Offset: 0x0020B034
	public UniTask RefreshAsync()
	{
		BabelTowerSettlementView.<RefreshAsync>d__31 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<BabelTowerSettlementView.<RefreshAsync>d__31>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007CAB RID: 31915 RVA: 0x0020CE78 File Offset: 0x0020B078
	private void RefreshShareRewardTip()
	{
		if (this.ShareId <= 0)
		{
			return;
		}
		bool flag = ModelBase<ChannelModel>.Instance.CouldGetShareReward((EShareActionId)this.ShareId);
		base.GetItem(18).SetUIActive(flag);
		if (flag)
		{
			ShareReward? config = ConfigShareRewardById.GetConfig(this.ShareId, true);
			if (config == null)
			{
				return;
			}
			int itemConfigId = 0;
			int num = 0;
			if (config.Value.RewardLength > 0)
			{
				DicIntInt? dicIntInt = config.Value.Reward(0);
				if (dicIntInt != null)
				{
					itemConfigId = dicIntInt.Value.Key;
					num = dicIntInt.Value.Value;
				}
			}
			string iconSmall = ConfigBase<ItemConfig>.Instance.GetConfig(itemConfigId).Value.IconSmall;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), "BabelTowerResultShare_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				iconSmall,
				num
			}));
		}
	}

	// Token: 0x06007CAC RID: 31916 RVA: 0x0020CF70 File Offset: 0x0020B170
	public void SetShareState(bool showShareBtn)
	{
		UUIButtonComponent button = base.GetButton(17);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(showShareBtn);
			}
		}
		UUIItem item = base.GetItem(13);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(showShareBtn);
	}

	// Token: 0x06007CAD RID: 31917 RVA: 0x0020CFB7 File Offset: 0x0020B1B7
	protected void TryPlayRoleSequence()
	{
		if (this.IsPlayingRoleSequence)
		{
			return;
		}
		this.IsPlayingRoleSequence = true;
		this.GachaSequence.PlayRoleSequence(this.SequenceRoleId, 0);
	}

	// Token: 0x04003B99 RID: 15257
	[Nullable(2)]
	private IBabelTowerSettlementViewData Data;

	// Token: 0x04003B9A RID: 15258
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<BabelTowerSettlementDeTermLayoutItem, int[]> DeTermLayout;

	// Token: 0x04003B9B RID: 15259
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<BabelTowerSettlementRoleItem, int> RoleLayout;

	// Token: 0x04003B9C RID: 15260
	private UiBehaviorGachaSequence GachaSequence;

	// Token: 0x04003B9D RID: 15261
	[Nullable(2)]
	private AActor SceneSequenceCamera;

	// Token: 0x04003B9E RID: 15262
	[Nullable(2)]
	private BP_UpdateInteract_C UpdateInteractBp;

	// Token: 0x04003B9F RID: 15263
	private bool IsPlayingRoleSequence;

	// Token: 0x04003BA0 RID: 15264
	private FMargin? OddLinePadding;

	// Token: 0x04003BA1 RID: 15265
	private FMargin? EvenLinePadding;

	// Token: 0x04003BA2 RID: 15266
	private int SequenceRoleId;

	// Token: 0x04003BA3 RID: 15267
	private int ShareId;

	// Token: 0x020075B6 RID: 30134
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040289B5 RID: 166325
		public const int StarNumText = 0;

		// Token: 0x040289B6 RID: 166326
		public const int DifficultySprite = 1;

		// Token: 0x040289B7 RID: 166327
		public const int DifficultyText = 2;

		// Token: 0x040289B8 RID: 166328
		public const int DungeonNameText = 3;

		// Token: 0x040289B9 RID: 166329
		public const int DungeonSubTitleText = 4;

		// Token: 0x040289BA RID: 166330
		public const int PassTimeText = 5;

		// Token: 0x040289BB RID: 166331
		public const int NoneBuffItem = 6;

		// Token: 0x040289BC RID: 166332
		public const int FirstBuffIconTexture = 7;

		// Token: 0x040289BD RID: 166333
		public const int SecondBuffIconTexture = 8;

		// Token: 0x040289BE RID: 166334
		public const int DeTermVerticalLayout = 9;

		// Token: 0x040289BF RID: 166335
		public const int OddLineHorizontalLayout = 10;

		// Token: 0x040289C0 RID: 166336
		public const int EvenLineHorizontalLayout = 11;

		// Token: 0x040289C1 RID: 166337
		public const int DeTermItem = 12;

		// Token: 0x040289C2 RID: 166338
		public const int ShareItem = 13;

		// Token: 0x040289C3 RID: 166339
		public const int ShareButton = 14;

		// Token: 0x040289C4 RID: 166340
		public const int ShareText = 15;

		// Token: 0x040289C5 RID: 166341
		public const int RoleTeamVerticalLayout = 16;

		// Token: 0x040289C6 RID: 166342
		public const int ConfirmButton = 17;

		// Token: 0x040289C7 RID: 166343
		public const int ShareRewardTipItem = 18;

		// Token: 0x040289C8 RID: 166344
		public const int Buff1Btn = 19;

		// Token: 0x040289C9 RID: 166345
		public const int Buff2Btn = 20;

		// Token: 0x040289CA RID: 166346
		public const int RankTipsItem = 21;

		// Token: 0x040289CB RID: 166347
		public const int RankItem = 22;

		// Token: 0x040289CC RID: 166348
		public const int BuffNumText = 23;
	}
}
