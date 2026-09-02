using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02001C81 RID: 7297
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class FragmentMemoryController : ControllerBase<FragmentMemoryController>
{
	// Token: 0x0600D537 RID: 54583 RVA: 0x0038E23B File Offset: 0x0038C43B
	protected override bool OnInit()
	{
		this.OnAddEvents();
		this.OnRegisterNetEvent();
		return true;
	}

	// Token: 0x0600D538 RID: 54584 RVA: 0x0038E24A File Offset: 0x0038C44A
	protected override bool OnClear()
	{
		this.OnRemoveEvents();
		this.OnUnRegisterNetEvent();
		return true;
	}

	// Token: 0x0600D539 RID: 54585 RVA: 0x0038E25C File Offset: 0x0038C45C
	protected void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Add(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSpecialItemUse, new Action<int, int>(this.OnItemUse));
		Singleton<EventSystem>.Instance.Add<UiViewBase>(EEventName.CreateViewInstance, new Action<UiViewBase>(this.OnCreateViewInstance));
	}

	// Token: 0x0600D53A RID: 54586 RVA: 0x0038E2D8 File Offset: 0x0038C4D8
	protected void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSpecialItemUse, new Action<int, int>(this.OnItemUse));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
		Singleton<EventSystem>.Instance.Remove(EEventName.CreateViewInstance, new Action<UiViewBase>(this.OnCreateViewInstance));
	}

	// Token: 0x0600D53B RID: 54587 RVA: 0x0038E352 File Offset: 0x0038C552
	protected void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<PhotoMemoryUpdateNotify>(ENotifyMessageId.PhotoMemoryUpdateNotify, new Action<PhotoMemoryUpdateNotify, Net.CallbackStatus>(this.OnPhotoMemoryUpdateNotify));
		Singleton<Net>.Instance.Register<PhotoMemoryCollectNotify>(ENotifyMessageId.PhotoMemoryCollectNotify, new Action<PhotoMemoryCollectNotify, Net.CallbackStatus>(this.OnPhotoMemoryCollectNotify));
	}

	// Token: 0x0600D53C RID: 54588 RVA: 0x0038E38C File Offset: 0x0038C58C
	protected void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhotoMemoryUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhotoMemoryCollectNotify);
	}

	// Token: 0x0600D53D RID: 54589 RVA: 0x0038E3AE File Offset: 0x0038C5AE
	private void OnLoadingNetDataDone()
	{
		this.RequestPhotoMemory();
	}

	// Token: 0x0600D53E RID: 54590 RVA: 0x0038E3B8 File Offset: 0x0038C5B8
	private void OnPhotoMemoryUpdateNotify(PhotoMemoryUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		List<int> collectedIds = ModelBase<FragmentMemoryModel>.Instance.GetCollectedIds();
		ModelBase<FragmentMemoryModel>.Instance.OnPhotoMemoryUpdate(notify);
		List<int> collectedIds2 = ModelBase<FragmentMemoryModel>.Instance.GetCollectedIds();
		List<int> list = new List<int>();
		foreach (int item in collectedIds2)
		{
			if (!collectedIds.Contains(item))
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			ModelBase<FragmentMemoryModel>.Instance.CurrentUnlockCollectId = list[0];
		}
		this.DoShowNewItemView();
		foreach (ActivityBaseData activityBaseData in ModelBase<ActivityModel>.Instance.GetAllActivityMap().Values)
		{
			if (activityBaseData is FragmentMemoryActivityData)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityBaseData.Id);
			}
		}
	}

	// Token: 0x0600D53F RID: 54591 RVA: 0x0038E4BC File Offset: 0x0038C6BC
	private void OnActiveBattleView()
	{
		this.DoShowNewItemView();
	}

	// Token: 0x0600D540 RID: 54592 RVA: 0x0038E4C4 File Offset: 0x0038C6C4
	private void DoShowNewItemView()
	{
		if (ModelBase<FragmentMemoryModel>.Instance.CurrentUnlockCollectId == 0)
		{
			return;
		}
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ObtainFragmentView) && Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView))
		{
			if (ModelBase<FragmentMemoryModel>.Instance.CurrentUnlockCollectId == ModelBase<FragmentMemoryModel>.Instance.CurrentTrackFragmentId)
			{
				ModelBase<FragmentMemoryModel>.Instance.TryRemoveCurrentTrackEntity();
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ObtainFragmentView, ModelBase<FragmentMemoryModel>.Instance.CurrentUnlockCollectId, null);
		}
	}

	// Token: 0x0600D541 RID: 54593 RVA: 0x0038E53F File Offset: 0x0038C73F
	private void OnPhotoMemoryCollectNotify(PhotoMemoryCollectNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<FragmentMemoryModel>.Instance.OnPhotoMemoryCollectUpdate(notify);
		ModelBase<FragmentMemoryModel>.Instance.TryRemoveCurrentTrackEntity();
	}

	// Token: 0x0600D542 RID: 54594 RVA: 0x0038E556 File Offset: 0x0038C756
	public void RequestPhotoMemory()
	{
		Singleton<Net>.Instance.Call<PhotoMemoryResponse>(ERequestMessageId.PhotoMemoryRequest, PhotoMemoryRequest.Create(), delegate(PhotoMemoryResponse response, Net.CallbackStatus _)
		{
			ModelBase<FragmentMemoryModel>.Instance.OnPhotoMemoryResponse(response);
		}, 0);
	}

	// Token: 0x0600D543 RID: 54595 RVA: 0x0038E58C File Offset: 0x0038C78C
	public void RequestMemoryReward(int[] ids)
	{
		PhotoMemoryRewardRequest photoMemoryRewardRequest = PhotoMemoryRewardRequest.Create();
		photoMemoryRewardRequest.CollectIds.Clear();
		photoMemoryRewardRequest.CollectIds.AddRange(ids);
		Singleton<Net>.Instance.Call<PhotoMemoryRewardResponse>(ERequestMessageId.PhotoMemoryRewardRequest, photoMemoryRewardRequest, delegate(PhotoMemoryRewardResponse response, Net.CallbackStatus _)
		{
			if (response != null && response.Error != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Error, 26935, null, true, true);
			}
		}, 0);
	}

	// Token: 0x0600D544 RID: 54596 RVA: 0x0038E5E6 File Offset: 0x0038C7E6
	private void OnItemUse(int configId, int useCount)
	{
		if (configId == 70140004)
		{
			this.OpenFragmentMemoryView();
		}
	}

	// Token: 0x0600D545 RID: 54597 RVA: 0x0038E5F6 File Offset: 0x0038C7F6
	private void OnCreateViewInstance(UiViewBase view)
	{
		if (view.ViewInfo.Name == EUiViewName.CommonActivityView)
		{
			ModelBase<FragmentMemoryModel>.Instance.ActivitySubViewTryPlayAnimation = "";
		}
	}

	// Token: 0x0600D546 RID: 54598 RVA: 0x0038E61E File Offset: 0x0038C81E
	public void OpenFragmentMemoryView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MemoryDetailView, null, null);
	}

	// Token: 0x04006543 RID: 25923
	public const int INFO_FRAGMENTMEMORYITEM = 70140004;
}
