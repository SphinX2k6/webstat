using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200134D RID: 4941
public class LifePointDrawItem : UiPanelBase
{
	// Token: 0x06008710 RID: 34576 RVA: 0x00238EF8 File Offset: 0x002370F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 23;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUISpriteTransition));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUISpriteTransition));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06008711 RID: 34577 RVA: 0x00239262 File Offset: 0x00237462
	protected override void OnStart()
	{
		this.SequencePlayer = new UiSequencePlayer(base.GetButton(0).RootUIComp);
	}

	// Token: 0x06008712 RID: 34578 RVA: 0x00239280 File Offset: 0x00237480
	[NullableContext(1)]
	public void PlaySequence(string sequenceType)
	{
		if (this.SequencePlayer != null)
		{
			this.SequencePlayer.PlaySequence(sequenceType, false, null);
		}
	}

	// Token: 0x06008713 RID: 34579 RVA: 0x002392AC File Offset: 0x002374AC
	private void OnClickBtn()
	{
		int id = this.LifePointDrawActivityData.Id;
		int groupId = this.GroupId;
		if (!ModelBase<LifePointDrawModel>.Instance.GetGroupUnlockState(id, groupId))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Colorful_Challenge_LockTime", Array.Empty<object>());
			return;
		}
		LifePointDrawViewModel lifePointDrawViewModel = new LifePointDrawViewModel();
		lifePointDrawViewModel.GroupId = this.GroupId;
		lifePointDrawViewModel.LifePointDrawActivityData = this.LifePointDrawActivityData;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LifePointDrawDetailView, lifePointDrawViewModel, null);
	}

	// Token: 0x06008714 RID: 34580 RVA: 0x0023931E File Offset: 0x0023751E
	public void SetIndex(int index)
	{
		if (index % 2 == 0)
		{
			this.IfUpItem = true;
			return;
		}
		this.IfUpItem = false;
	}

	// Token: 0x06008715 RID: 34581 RVA: 0x00239334 File Offset: 0x00237534
	[NullableContext(1)]
	public void RefreshView(int groupId, LifePointDrawActivityData data)
	{
		this.GroupId = groupId;
		this.LifePointDrawActivityData = data;
		this.RefreshColorTexture(data.Id, groupId);
		this.RefreshLine(data.Id, groupId);
		this.RefreshLevelNumSpriteTransition(data.Id, groupId);
		this.RefreshSpriteColor(data.Id, groupId);
		this.RefreshRoundItem(data.Id, groupId);
		this.RefreshTitleBgSprite(data.Id, groupId);
		this.RefreshNameTextColor(data.Id, groupId);
		this.RefreshName(groupId);
		this.RefreshHintItem(data.Id, groupId);
		this.RefreshProgressDesc(data.Id, groupId);
		this.RefreshUnlockDesc(data.Id, groupId);
		this.RefreshRedDot(groupId);
	}

	// Token: 0x06008716 RID: 34582 RVA: 0x002393E0 File Offset: 0x002375E0
	private void RefreshRedDot(int groupId)
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.LifePointDrawGroupRedDot, base.GetItem(17), groupId);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.LifePointDrawGroupRedDot, base.GetItem(17), null, groupId);
	}

	// Token: 0x06008717 RID: 34583 RVA: 0x00239414 File Offset: 0x00237614
	private void RefreshLine(int activityId, int groupId)
	{
		bool groupUnlockState = ModelBase<LifePointDrawModel>.Instance.GetGroupUnlockState(activityId, groupId);
		bool ifUpItem = this.IfUpItem;
		base.GetItem(4).SetUIActive(groupUnlockState && ifUpItem);
		base.GetItem(5).SetUIActive(groupUnlockState && !ifUpItem);
		base.GetItem(6).SetUIActive(!groupUnlockState && ifUpItem);
		base.GetItem(7).SetUIActive(!groupUnlockState && !ifUpItem);
	}

	// Token: 0x06008718 RID: 34584 RVA: 0x00239484 File Offset: 0x00237684
	private UniTask RefreshLevelNumSpriteTransition(int activityId, int groupId)
	{
		LifePointDrawItem.<RefreshLevelNumSpriteTransition>d__12 <RefreshLevelNumSpriteTransition>d__;
		<RefreshLevelNumSpriteTransition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshLevelNumSpriteTransition>d__.<>4__this = this;
		<RefreshLevelNumSpriteTransition>d__.activityId = activityId;
		<RefreshLevelNumSpriteTransition>d__.groupId = groupId;
		<RefreshLevelNumSpriteTransition>d__.<>1__state = -1;
		<RefreshLevelNumSpriteTransition>d__.<>t__builder.Start<LifePointDrawItem.<RefreshLevelNumSpriteTransition>d__12>(ref <RefreshLevelNumSpriteTransition>d__);
		return <RefreshLevelNumSpriteTransition>d__.<>t__builder.Task;
	}

	// Token: 0x06008719 RID: 34585 RVA: 0x002394D8 File Offset: 0x002376D8
	private void RefreshColorTexture(int activityId, int groupId)
	{
		string resourceId = ModelBase<LifePointDrawModel>.Instance.GetGroupUnlockState(activityId, groupId) ? "T_ColorBoardUnLock" : "T_ColorBoardLock";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.SetTextureByPath(resourcePath, base.GetTexture(3), null, null);
	}

	// Token: 0x0600871A RID: 34586 RVA: 0x00239524 File Offset: 0x00237724
	private void RefreshRoundItem(int activityId, int groupId)
	{
		bool groupUnlockState = ModelBase<LifePointDrawModel>.Instance.GetGroupUnlockState(activityId, groupId);
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(groupUnlockState);
		}
		UUIItem item2 = base.GetItem(2);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(!groupUnlockState);
	}

	// Token: 0x0600871B RID: 34587 RVA: 0x00239568 File Offset: 0x00237768
	private void RefreshSpriteColor(int activityId, int groupId)
	{
		bool groupUnlockState = ModelBase<LifePointDrawModel>.Instance.GetGroupUnlockState(activityId, groupId);
		UUISprite sprite = base.GetSprite(9);
		FColor? fcolor;
		if (sprite != null)
		{
			bool bUseChangeColor = groupUnlockState;
			fcolor = new FColor?(base.GetSprite(9).changeColor);
			sprite.SetChangeColor(bUseChangeColor, fcolor);
		}
		UUITexture texture = base.GetTexture(10);
		if (texture != null)
		{
			bool bUseChangeColor2 = groupUnlockState;
			fcolor = new FColor?(base.GetTexture(10).changeColor);
			texture.SetChangeColor(bUseChangeColor2, fcolor);
		}
		UUITexture texture2 = base.GetTexture(11);
		if (texture2 == null)
		{
			return;
		}
		bool bUseChangeColor3 = groupUnlockState;
		fcolor = new FColor?(base.GetTexture(10).changeColor);
		texture2.SetChangeColor(bUseChangeColor3, fcolor);
	}

	// Token: 0x0600871C RID: 34588 RVA: 0x002395FC File Offset: 0x002377FC
	private void RefreshTitleBgSprite(int activityId, int groupId)
	{
		bool groupUnlockState = ModelBase<LifePointDrawModel>.Instance.GetGroupUnlockState(activityId, groupId);
		base.GetSprite(12).SetUIActive(groupUnlockState);
		base.GetItem(22).SetUIActive(!groupUnlockState);
	}

	// Token: 0x0600871D RID: 34589 RVA: 0x00239638 File Offset: 0x00237838
	private void RefreshNameTextColor(int activityId, int groupId)
	{
		string hexStr = ModelBase<LifePointDrawModel>.Instance.GetGroupUnlockState(activityId, groupId) ? "654A17" : "354061";
		base.GetText(13).outlineColor = FColor.FromHex(hexStr);
	}

	// Token: 0x0600871E RID: 34590 RVA: 0x00239674 File Offset: 0x00237874
	private void RefreshName(int groupId)
	{
		string name = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointGroupByGroupId(groupId).Value.Name;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), name, Array.Empty<object>());
	}

	// Token: 0x0600871F RID: 34591 RVA: 0x002396B8 File Offset: 0x002378B8
	private void RefreshHintItem(int activityId, int groupId)
	{
		bool groupUnlockState = ModelBase<LifePointDrawModel>.Instance.GetGroupUnlockState(activityId, groupId);
		bool groupRewardState = ModelBase<LifePointDrawModel>.Instance.GetGroupRewardState(activityId, groupId);
		bool uiactive = groupUnlockState && groupRewardState;
		bool uiactive2 = groupUnlockState && !groupRewardState;
		bool uiactive3 = !groupUnlockState;
		base.GetItem(14).SetUIActive(uiactive);
		base.GetItem(15).SetUIActive(uiactive2);
		base.GetItem(16).SetUIActive(uiactive3);
	}

	// Token: 0x06008720 RID: 34592 RVA: 0x0023971C File Offset: 0x0023791C
	private void RefreshProgressDesc(int activityId, int groupId)
	{
		bool groupUnlockState = ModelBase<LifePointDrawModel>.Instance.GetGroupUnlockState(activityId, groupId);
		bool groupRewardState = ModelBase<LifePointDrawModel>.Instance.GetGroupRewardState(activityId, groupId);
		if (!groupUnlockState || groupRewardState)
		{
			base.GetText(18).SetText("", true);
			return;
		}
		string groupRewardProgress = ModelBase<LifePointDrawModel>.Instance.GetGroupRewardProgress(activityId, groupId);
		base.GetText(18).SetText(groupRewardProgress, true);
	}

	// Token: 0x06008721 RID: 34593 RVA: 0x00239780 File Offset: 0x00237980
	private void RefreshUnlockDesc(int activityId, int groupId)
	{
		if (ModelBase<LifePointDrawModel>.Instance.GetGroupUnlockState(activityId, groupId))
		{
			base.GetText(19).SetText("", true);
			return;
		}
		long groupUnlockTime = ModelBase<LifePointDrawModel>.Instance.GetGroupUnlockTime(activityId, groupId);
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat((double)groupUnlockTime - Singleton<TimeUtil>.Instance.GetServerTime());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(19), "LifePointUnlockText", new <>z__ReadOnlySingleElementList<object>(remainTimeDataFormat.CountDownText));
	}

	// Token: 0x06008722 RID: 34594 RVA: 0x002397F6 File Offset: 0x002379F6
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.LifePointDrawGroupRedDot, base.GetItem(17), this.GroupId);
	}

	// Token: 0x04003FB6 RID: 16310
	[Nullable(2)]
	private UiSequencePlayer SequencePlayer;

	// Token: 0x04003FB7 RID: 16311
	private bool IfUpItem;

	// Token: 0x04003FB8 RID: 16312
	private int GroupId;

	// Token: 0x04003FB9 RID: 16313
	[Nullable(2)]
	private LifePointDrawActivityData LifePointDrawActivityData;

	// Token: 0x020076F1 RID: 30449
	private class ELifePointDrawItemComponent
	{
		// Token: 0x04028F63 RID: 167779
		public const int Button = 0;

		// Token: 0x04028F64 RID: 167780
		public const int RoundUnlockItem = 1;

		// Token: 0x04028F65 RID: 167781
		public const int RoundLockItem = 2;

		// Token: 0x04028F66 RID: 167782
		public const int ColorTexture = 3;

		// Token: 0x04028F67 RID: 167783
		public const int LineUpActiveItem = 4;

		// Token: 0x04028F68 RID: 167784
		public const int LineDownActiveItem = 5;

		// Token: 0x04028F69 RID: 167785
		public const int LineUpInActiveItem = 6;

		// Token: 0x04028F6A RID: 167786
		public const int LineDownInActiveItem = 7;

		// Token: 0x04028F6B RID: 167787
		public const int LevelNumSprite = 8;

		// Token: 0x04028F6C RID: 167788
		public const int LevelNumBg = 9;

		// Token: 0x04028F6D RID: 167789
		public const int ArrowItem1 = 10;

		// Token: 0x04028F6E RID: 167790
		public const int ArrowItem2 = 11;

		// Token: 0x04028F6F RID: 167791
		public const int TitleBgSprite = 12;

		// Token: 0x04028F70 RID: 167792
		public const int TitleName = 13;

		// Token: 0x04028F71 RID: 167793
		public const int PassItem = 14;

		// Token: 0x04028F72 RID: 167794
		public const int ProgressItem = 15;

		// Token: 0x04028F73 RID: 167795
		public const int LockItem = 16;

		// Token: 0x04028F74 RID: 167796
		public const int TitleRedDot = 17;

		// Token: 0x04028F75 RID: 167797
		public const int ProgressDesc = 18;

		// Token: 0x04028F76 RID: 167798
		public const int UnlockDesc = 19;

		// Token: 0x04028F77 RID: 167799
		public const int LevelNumSpriteTransition = 20;

		// Token: 0x04028F78 RID: 167800
		public const int TitleBgSpriteTransition = 21;

		// Token: 0x04028F79 RID: 167801
		public const int LockBgItem = 22;
	}
}
