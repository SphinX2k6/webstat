using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002343 RID: 9027
[NullableContext(1)]
[Nullable(0)]
public class OnlineChallengeStateView : UiTickViewBase
{
	// Token: 0x060113A9 RID: 70569 RVA: 0x004BB24A File Offset: 0x004B944A
	public OnlineChallengeStateView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060113AA RID: 70570 RVA: 0x004BB26C File Offset: 0x004B946C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060113AB RID: 70571 RVA: 0x004BB318 File Offset: 0x004B9518
	protected override void OnStart()
	{
		this.CountDownNumber = (float)ModelBase<OnlineModel>.Instance.ApplyCd;
		this.CountDownBar = base.GetSprite(3);
		this.PlayerLayout = new GenericLayout<OnlineChallengePlayerStateItem, int>(base.GetHorizontalLayout(1), new Func<OnlineChallengePlayerStateItem>(this.InitPlayerItem), null, false, true);
		this.RefreshView();
	}

	// Token: 0x060113AC RID: 70572 RVA: 0x004BB36A File Offset: 0x004B956A
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, EContinuingChallenge>(EEventName.PlayerChallengeStateChange, new Action<int, EContinuingChallenge>(this.OnlineTeamPlayerAccept));
	}

	// Token: 0x060113AD RID: 70573 RVA: 0x004BB388 File Offset: 0x004B9588
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PlayerChallengeStateChange, new Action<int, EContinuingChallenge>(this.OnlineTeamPlayerAccept));
	}

	// Token: 0x060113AE RID: 70574 RVA: 0x004BB3A6 File Offset: 0x004B95A6
	protected override void OnBeforeDestroy()
	{
		this.CountDownBar = null;
		this.CountDownNumber = -1f;
		this.PlayerStateItemList = new List<OnlineChallengePlayerStateItem>();
	}

	// Token: 0x060113AF RID: 70575 RVA: 0x004BB3C8 File Offset: 0x004B95C8
	protected override void OnTick(float delta)
	{
		this.CountDownNumber -= delta * (float)Singleton<TimeUtil>.Instance.Millisecond;
		if (this.CountDownNumber <= 0f)
		{
			base.CloseMe(null);
			return;
		}
		this.CountDownBar.SetFillAmount(this.CountDownNumber / (float)ModelBase<OnlineModel>.Instance.ApplyCd);
	}

	// Token: 0x060113B0 RID: 70576 RVA: 0x004BB424 File Offset: 0x004B9624
	public void RefreshView()
	{
		OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(ModelBase<OnlineModel>.Instance.OwnerId);
		string item = (currentTeamListById != null) ? currentTeamListById.Name : null;
		if (!ModelBase<SceneTeamModel>.Instance.IsAllDid())
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "ContinueChallenge", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "HasInviteContinueChallenge", new <>z__ReadOnlySingleElementList<object>(item));
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "ChallengeAgain", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "HasInviteChallengeAgain", new <>z__ReadOnlySingleElementList<object>(item));
		}
		List<ScenePlayerData> allScenePlayers = ModelBase<CreatureModel>.Instance.GetAllScenePlayers();
		List<int> list = new List<int>();
		foreach (ScenePlayerData scenePlayerData in allScenePlayers)
		{
			list.Add(scenePlayerData.GetPlayerId());
		}
		this.PlayerLayout.RefreshByData(list, null, false);
	}

	// Token: 0x060113B1 RID: 70577 RVA: 0x004BB534 File Offset: 0x004B9734
	private OnlineChallengePlayerStateItem InitPlayerItem()
	{
		OnlineChallengePlayerStateItem onlineChallengePlayerStateItem = new OnlineChallengePlayerStateItem();
		this.PlayerStateItemList.Add(onlineChallengePlayerStateItem);
		return onlineChallengePlayerStateItem;
	}

	// Token: 0x060113B2 RID: 70578 RVA: 0x004BB554 File Offset: 0x004B9754
	private void OnlineTeamPlayerAccept(int playerId, EContinuingChallenge state)
	{
		if (state == EContinuingChallenge.Leave)
		{
			base.CloseMe(null);
			return;
		}
		foreach (OnlineChallengePlayerStateItem onlineChallengePlayerStateItem in this.PlayerStateItemList)
		{
			onlineChallengePlayerStateItem.SetTeamPlayerSprite(playerId, state);
		}
	}

	// Token: 0x0400876D RID: 34669
	private float CountDownNumber = -1f;

	// Token: 0x0400876E RID: 34670
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<OnlineChallengePlayerStateItem, int> PlayerLayout;

	// Token: 0x0400876F RID: 34671
	[Nullable(2)]
	private UUISprite CountDownBar;

	// Token: 0x04008770 RID: 34672
	private List<OnlineChallengePlayerStateItem> PlayerStateItemList = new List<OnlineChallengePlayerStateItem>();

	// Token: 0x02008651 RID: 34385
	[NullableContext(0)]
	private enum EOnlineChallengeStateView
	{
		// Token: 0x0402D6D0 RID: 186064
		TitleText,
		// Token: 0x0402D6D1 RID: 186065
		PlayerLayout,
		// Token: 0x0402D6D2 RID: 186066
		TeamLeaderText,
		// Token: 0x0402D6D3 RID: 186067
		CountDownProgressBar
	}
}
