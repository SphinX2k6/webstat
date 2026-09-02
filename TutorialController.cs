using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02002C22 RID: 11298
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class TutorialController : UiControllerBase<TutorialController>
{
	// Token: 0x060169CC RID: 92620 RVA: 0x006465B2 File Offset: 0x006447B2
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
	}

	// Token: 0x060169CD RID: 92621 RVA: 0x006465D0 File Offset: 0x006447D0
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
	}

	// Token: 0x060169CE RID: 92622 RVA: 0x006465EE File Offset: 0x006447EE
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<TutorialUnlockNotify>(ENotifyMessageId.TutorialUnlockNotify, new Action<TutorialUnlockNotify, Net.CallbackStatus>(this.OnTutorialUnlockedIdsNotify));
	}

	// Token: 0x060169CF RID: 92623 RVA: 0x0064660C File Offset: 0x0064480C
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TutorialUnlockNotify);
	}

	// Token: 0x060169D0 RID: 92624 RVA: 0x00646620 File Offset: 0x00644820
	public void OpenExclusiveTutorial(EExclusiveTutorialType type)
	{
		TutorialViewParam param = new TutorialViewParam
		{
			ExclusiveType = new EExclusiveTutorialType?(type)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TutorialPopView, param, null);
	}

	// Token: 0x060169D1 RID: 92625 RVA: 0x00646650 File Offset: 0x00644850
	private void OnTutorialUnlockedIdsNotify(TutorialUnlockNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		foreach (TutorialInfo tutorialInfo in notify.UnLockList)
		{
			ModelBase<TutorialModel>.Instance.UpdateUnlockTutorials(tutorialInfo);
		}
	}

	// Token: 0x060169D2 RID: 92626 RVA: 0x006466A4 File Offset: 0x006448A4
	private void OnDataDone()
	{
		ModelBase<TutorialModel>.Instance.InitDefaultUnlockTutorials();
		TutorialInfoRequest message = TutorialInfoRequest.Create();
		Singleton<Net>.Instance.Call<TutorialInfoResponse>(ERequestMessageId.TutorialInfoRequest, message, delegate(TutorialInfoResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			ModelBase<TutorialModel>.Instance.InitUnlockTutorials(response.UnLockList);
			List<TutorialItemData> unlockedTutorialDataByType = ModelBase<TutorialModel>.Instance.GetUnlockedTutorialDataByType(ETutorialType.All, EExclusiveTutorialType.None);
			if (unlockedTutorialDataByType != null && unlockedTutorialDataByType.Count > 0)
			{
				ModelBase<TutorialModel>.Instance.InvokeTutorialRedDot(unlockedTutorialDataByType[0].SavedData);
			}
			ModelBase<TutorialModel>.Instance.InitTutorialTotalData();
		}, 0);
	}

	// Token: 0x060169D3 RID: 92627 RVA: 0x006466F1 File Offset: 0x006448F1
	protected override void OnAddOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.TutorialView, new Func<EUiViewName, object, bool>(this.CanOpenView), "TutorialController.CanOpenView");
	}

	// Token: 0x060169D4 RID: 92628 RVA: 0x00646713 File Offset: 0x00644913
	protected override void OnRemoveOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.TutorialView, new Func<EUiViewName, object, bool>(this.CanOpenView));
	}

	// Token: 0x060169D5 RID: 92629 RVA: 0x00646730 File Offset: 0x00644930
	public void OnTutorialTipExistChanged(bool isExist)
	{
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnTutorialTipExistChanged, isExist);
	}

	// Token: 0x060169D6 RID: 92630 RVA: 0x00646744 File Offset: 0x00644944
	private bool CanOpenView(EUiViewName viewName, object param)
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10022) && (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GuideTutorialTipsView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FunctionView) || ModelBase<GuideModel>.Instance.HaveCurrentTutorial());
	}

	// Token: 0x060169D7 RID: 92631 RVA: 0x00646795 File Offset: 0x00644995
	public void OpenTutorialView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TutorialView, null, null);
	}

	// Token: 0x060169D8 RID: 92632 RVA: 0x006467A8 File Offset: 0x006449A8
	public void GmUnlockOneTutorial(int tutorialId)
	{
		TutorialUnlockRequest tutorialUnlockRequest = TutorialUnlockRequest.Create();
		tutorialUnlockRequest.Id = tutorialId;
		Singleton<Net>.Instance.Call<TutorialUnlockResponse>(ERequestMessageId.TutorialUnlockRequest, tutorialUnlockRequest, delegate(TutorialUnlockResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				return;
			}
			ModelBase<TutorialModel>.Instance.UpdateUnlockTutorials(response.UnLockInfo);
		}, 0);
	}

	// Token: 0x060169D9 RID: 92633 RVA: 0x006467F4 File Offset: 0x006449F4
	public void RemoveRedDotTutorialId(int tutorialId)
	{
		ModelBase<TutorialModel>.Instance.RemoveRedDotTutorialId(tutorialId);
		GuideTutorial? guideTutorial = ConfigBase<GuideConfig>.Instance.GetGuideTutorial(tutorialId);
		if (guideTutorial != null && guideTutorial.GetValueOrDefault().DefaultUnlock)
		{
			this.TryUnlockAndOpenTutorialTip(tutorialId, delegate(bool success)
			{
				if (success)
				{
					this.SendGetAwardRequest(tutorialId);
				}
			});
			return;
		}
		this.SendGetAwardRequest(tutorialId);
	}

	// Token: 0x060169DA RID: 92634 RVA: 0x00646878 File Offset: 0x00644A78
	private void SendGetAwardRequest(int tutorialId)
	{
		if (!ConfigBase<TutorialConfig>.Instance.HasUnlockReward(tutorialId))
		{
			return;
		}
		TutorialReceiveRequest tutorialReceiveRequest = TutorialReceiveRequest.Create();
		tutorialReceiveRequest.Id = tutorialId;
		Singleton<Net>.Instance.Call<TutorialReceiveResponse>(ERequestMessageId.TutorialReceiveRequest, tutorialReceiveRequest, delegate(TutorialReceiveResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				return;
			}
			int num = response.ItemMap.Keys.First<int>();
			int num2 = response.ItemMap[num];
			List<ValueTuple<int, int>> rewardList = ModelBase<TutorialModel>.Instance.RewardList;
			if (rewardList.Count > 0)
			{
				for (int i = 0; i < rewardList.Count; i++)
				{
					int item = rewardList[i].Item1;
					int item2 = rewardList[i].Item2;
					if (item == num)
					{
						rewardList[i] = new ValueTuple<int, int>(item, item2 + num2);
						return;
					}
				}
				return;
			}
			rewardList.Add(new ValueTuple<int, int>(num, num2));
		}, 0);
	}

	// Token: 0x060169DB RID: 92635 RVA: 0x006468D0 File Offset: 0x00644AD0
	public void TryOpenAwardUiViewPending()
	{
		if (ModelBase<TutorialModel>.Instance.RewardList.Count > 0)
		{
			ControllerBase<ItemHintController>.Instance.AddItemRewardInfoList(ModelBase<TutorialModel>.Instance.RewardList);
			ModelBase<TutorialModel>.Instance.RewardList.Clear();
		}
	}

	// Token: 0x060169DC RID: 92636 RVA: 0x00646908 File Offset: 0x00644B08
	[NullableContext(2)]
	public void TryUnlockAndOpenTutorialTip(int tutorialId, Action<bool> finishCallback = null)
	{
		TutorialController.<>c__DisplayClass16_0 CS$<>8__locals1 = new TutorialController.<>c__DisplayClass16_0();
		CS$<>8__locals1.finishCallback = finishCallback;
		CS$<>8__locals1.tutorialCfg = ConfigBase<GuideConfig>.Instance.GetGuideTutorial(tutorialId);
		TutorialController.<>c__DisplayClass16_0 CS$<>8__locals2 = CS$<>8__locals1;
		int num = (CS$<>8__locals2.tutorialCfg != null && CS$<>8__locals2.tutorialCfg.GetValueOrDefault().CopiedFrom != 0) ? CS$<>8__locals1.tutorialCfg.Value.CopiedFrom : tutorialId;
		GuideTutorial? guideTutorial = ConfigBase<GuideConfig>.Instance.GetGuideTutorial(num);
		TutorialController.<>c__DisplayClass16_0 CS$<>8__locals3 = CS$<>8__locals1;
		int? num2 = (CS$<>8__locals3.tutorialCfg != null) ? new int?(CS$<>8__locals3.tutorialCfg.GetValueOrDefault().PageId().Length) : null;
		int? num3;
		if (guideTutorial == null)
		{
			num3 = null;
		}
		else
		{
			int[] array = guideTutorial.GetValueOrDefault().PageId();
			num3 = ((array != null) ? new int?(array.Length) : null);
		}
		int? num4 = num3;
		if (num2.GetValueOrDefault() == num4.GetValueOrDefault() & num2 != null == (num4 != null))
		{
			TutorialController.<>c__DisplayClass16_0 CS$<>8__locals4 = CS$<>8__locals1;
			int? num5 = (CS$<>8__locals4.tutorialCfg != null) ? new int?(CS$<>8__locals4.tutorialCfg.GetValueOrDefault().PageId().Length) : null;
			int num6 = 0;
			for (;;)
			{
				int num7 = num6;
				num2 = num5;
				if (!(num7 < num2.GetValueOrDefault() & num2 != null))
				{
					goto Block_13;
				}
				TutorialController.<>c__DisplayClass16_0 CS$<>8__locals5 = CS$<>8__locals1;
				int? num8 = (CS$<>8__locals5.tutorialCfg != null) ? new int?(CS$<>8__locals5.tutorialCfg.GetValueOrDefault().PageId()[num6]) : null;
				int? num9 = (guideTutorial != null) ? new int?(guideTutorial.GetValueOrDefault().PageId()[num6]) : null;
				num4 = num8;
				num2 = num9;
				if (!(num4.GetValueOrDefault() == num2.GetValueOrDefault() & num4 != null == (num2 != null)))
				{
					break;
				}
				num6++;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Tutorial;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "复制图文引导和源图文引导内容不一致";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", tutorialId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Action<bool> finishCallback2 = CS$<>8__locals1.finishCallback;
			if (finishCallback2 == null)
			{
				return;
			}
			finishCallback2(false);
			return;
			Block_13:
			if (ModelBase<TutorialModel>.Instance.GetSavedDataById(num) != null)
			{
				TutorialController.<>c__DisplayClass16_0 CS$<>8__locals6 = CS$<>8__locals1;
				if (CS$<>8__locals6.tutorialCfg == null || !CS$<>8__locals6.tutorialCfg.GetValueOrDefault().DefaultUnlock)
				{
					Action<bool> finishCallback3 = CS$<>8__locals1.finishCallback;
					if (finishCallback3 == null)
					{
						return;
					}
					finishCallback3(true);
					return;
				}
			}
			TutorialUnlockRequest tutorialUnlockRequest = TutorialUnlockRequest.Create();
			tutorialUnlockRequest.Id = num;
			Singleton<Net>.Instance.Call<TutorialUnlockResponse>(ERequestMessageId.TutorialUnlockRequest, tutorialUnlockRequest, delegate(TutorialUnlockResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					Action<bool> finishCallback5 = CS$<>8__locals1.finishCallback;
					if (finishCallback5 == null)
					{
						return;
					}
					finishCallback5(false);
					return;
				}
				else if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					Action<bool> finishCallback6 = CS$<>8__locals1.finishCallback;
					if (finishCallback6 == null)
					{
						return;
					}
					finishCallback6(false);
					return;
				}
				else
				{
					if (CS$<>8__locals1.tutorialCfg == null || !CS$<>8__locals1.tutorialCfg.GetValueOrDefault().DefaultUnlock)
					{
						ModelBase<TutorialModel>.Instance.UpdateUnlockTutorials(response.UnLockInfo);
					}
					Action<bool> finishCallback7 = CS$<>8__locals1.finishCallback;
					if (finishCallback7 == null)
					{
						return;
					}
					finishCallback7(true);
					return;
				}
			}, 0);
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Tutorial;
		ELogAuthor author2 = ELogAuthor.HYF;
		string message2 = "复制图文引导和源图文引导内容不一致";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Id", tutorialId);
		instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		Action<bool> finishCallback4 = CS$<>8__locals1.finishCallback;
		if (finishCallback4 == null)
		{
			return;
		}
		finishCallback4(false);
	}
}
