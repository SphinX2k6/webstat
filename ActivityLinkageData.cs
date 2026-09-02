using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x0200117C RID: 4476
[NullableContext(1)]
[Nullable(0)]
public class ActivityLinkageData : ActivityBaseData
{
	// Token: 0x170009F2 RID: 2546
	// (get) Token: 0x060075D2 RID: 30162 RVA: 0x001ED3D4 File Offset: 0x001EB5D4
	public Dictionary<int, ActivityLinkageTabData> TabDataMap { get; } = new Dictionary<int, ActivityLinkageTabData>();

	// Token: 0x060075D3 RID: 30163 RVA: 0x001ED3DC File Offset: 0x001EB5DC
	protected override void PhraseEx(ActivityData data)
	{
		Aki.Protocol.ActivityLinkageData activityLinkageData = data.ActivityLinkageData;
		if (activityLinkageData == null || activityLinkageData.Data == null)
		{
			return;
		}
		foreach (ActivityLinkagePageData activityLinkagePageData in activityLinkageData.Data)
		{
			ActivityLinkageTabData activityLinkageTabData;
			if (!this.TabDataMap.TryGetValue(activityLinkagePageData.PageActivityId, out activityLinkageTabData))
			{
				activityLinkageTabData = new ActivityLinkageTabData();
			}
			activityLinkageTabData.TabId = activityLinkagePageData.PageActivityId;
			activityLinkageTabData.StartTimeStamp = activityLinkagePageData.StartTime;
			activityLinkageTabData.EndTimeStamp = activityLinkagePageData.EndTime;
			activityLinkageTabData.IsReceive = activityLinkagePageData.Receive;
			activityLinkageTabData.IsInShowTimeChange();
			this.TabDataMap[activityLinkagePageData.PageActivityId] = activityLinkageTabData;
		}
	}

	// Token: 0x060075D4 RID: 30164 RVA: 0x001ED49C File Offset: 0x001EB69C
	public void ReceiveReward(int tabId)
	{
		ActivityLinkageTabData activityLinkageTabData;
		if (!this.TabDataMap.TryGetValue(tabId, out activityLinkageTabData))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "活动联合页领取奖励，页签数据错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tabId", tabId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		activityLinkageTabData.IsReceive = true;
		this.TabDataMap[tabId] = activityLinkageTabData;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x060075D5 RID: 30165 RVA: 0x001ED513 File Offset: 0x001EB713
	public void ReadRedDot()
	{
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 100, 0, 0, 1);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x060075D6 RID: 30166 RVA: 0x001ED540 File Offset: 0x001EB740
	public override bool GetExDataRedPointShowState()
	{
		if (ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 100, 0, 0) == 0)
		{
			return true;
		}
		using (List<ActivityLinkageTabData>.Enumerator enumerator = (from tabInfo in this.TabDataMap.Values
		where tabInfo.IsInShowTime
		select tabInfo).ToList<ActivityLinkageTabData>().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.IsReceive)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060075D7 RID: 30167 RVA: 0x001ED5E0 File Offset: 0x001EB7E0
	public bool IsReceiveReward(int tabId)
	{
		ActivityLinkageTabData activityLinkageTabData;
		if (!this.TabDataMap.TryGetValue(tabId, out activityLinkageTabData))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "活动联动页页签id未找到";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tabId", tabId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		return activityLinkageTabData.IsReceive;
	}

	// Token: 0x060075D8 RID: 30168 RVA: 0x001ED634 File Offset: 0x001EB834
	public bool IsNeedShowTabsChange()
	{
		bool result = false;
		using (Dictionary<int, ActivityLinkageTabData>.ValueCollection.Enumerator enumerator = this.TabDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsInShowTimeChange())
				{
					result = true;
				}
			}
		}
		return result;
	}

	// Token: 0x060075D9 RID: 30169 RVA: 0x001ED690 File Offset: 0x001EB890
	public List<ActivityLinkageTabData> GetTabInfoList()
	{
		this.IsNeedShowTabsChange();
		return (from tabData in (from tabInfo in this.TabDataMap.Values
		where tabInfo.IsInShowTime
		select tabInfo).ToList<ActivityLinkageTabData>()
		orderby ConfigActivityLinkageById.GetConfig(tabData.TabId, true).Value.Rank descending, tabData.TabId descending
		select tabData).ToList<ActivityLinkageTabData>();
	}

	// Token: 0x04003911 RID: 14609
	private const int ACTIVITYLINKAGE_RED_DOT_CACHE_KEY = 100;
}
