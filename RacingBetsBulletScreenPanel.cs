using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002714 RID: 10004
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsBulletScreenPanel : UiPanelBase
{
	// Token: 0x06013BB4 RID: 80820 RVA: 0x0057DD24 File Offset: 0x0057BF24
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x06013BB5 RID: 80821 RVA: 0x0057DD48 File Offset: 0x0057BF48
	protected override void OnStart()
	{
		this.TimerHandle = TimerSystem.FlowTimeInstance.Forever(new TTimerAction(this.OnTick), 20f, 1f, null, null, false);
		UUIItem rootItem = base.GetRootItem();
		object obj;
		if (rootItem == null)
		{
			obj = null;
		}
		else
		{
			UUIItem attachUIChild = rootItem.GetAttachUIChild(0);
			obj = ((attachUIChild != null) ? attachUIChild.GetOwner() : null);
		}
		this.TemplateGridActor = (obj as AUIBaseActor);
		if (this.TemplateGridActor == null)
		{
			return;
		}
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			this.ViewportHeight = item.GetHeight();
			this.ViewportWidth = item.GetWidth();
		}
		this.BulletTrackCount = (int)Math.Floor((double)(this.ViewportHeight / this.BulletScreenItemHeight));
		UUIItem uiitem = this.TemplateGridActor.GetUIItem();
		if (uiitem == null)
		{
			return;
		}
		uiitem.SetUIActive(false);
	}

	// Token: 0x06013BB6 RID: 80822 RVA: 0x0057DE04 File Offset: 0x0057C004
	private void OnTick(float delta)
	{
		this.MoveBulletScreen(delta);
		this.BulletScreenCurInternal += delta;
		if (this.BulletScreenCurInternal < this.BulletScreenInternal)
		{
			return;
		}
		if (!this.CheckCanPushBulletScreen())
		{
			return;
		}
		this.BulletScreenCurInternal %= this.BulletScreenInternal;
		this.ShowBulletScreenAsync().Forget();
	}

	// Token: 0x06013BB7 RID: 80823 RVA: 0x0057DE5C File Offset: 0x0057C05C
	private void MoveBulletScreen(float delta)
	{
		float num = delta * this.BulletScreenSpeed;
		foreach (RacingBetsBulletScreenItem racingBetsBulletScreenItem in this.BulletScreenItemList)
		{
			UUIItem rootItem = racingBetsBulletScreenItem.GetRootItem();
			float num2 = rootItem.GetAnchorOffsetX() - num;
			rootItem.SetAnchorOffsetX(num2);
			float num3 = -racingBetsBulletScreenItem.GetBulletScreenItemWidth();
			if (num2 < num3)
			{
				this.PendingRemoveList.Add(racingBetsBulletScreenItem);
			}
		}
		if (this.PendingRemoveList.Count > 0)
		{
			foreach (RacingBetsBulletScreenItem bulletScreenItem in this.PendingRemoveList)
			{
				this.RemoveBulletScreen(bulletScreenItem);
			}
			this.PendingRemoveList.Clear();
		}
	}

	// Token: 0x06013BB8 RID: 80824 RVA: 0x0057DF40 File Offset: 0x0057C140
	private UniTask ShowBulletScreenAsync()
	{
		RacingBetsBulletScreenPanel.<ShowBulletScreenAsync>d__21 <ShowBulletScreenAsync>d__;
		<ShowBulletScreenAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowBulletScreenAsync>d__.<>4__this = this;
		<ShowBulletScreenAsync>d__.<>1__state = -1;
		<ShowBulletScreenAsync>d__.<>t__builder.Start<RacingBetsBulletScreenPanel.<ShowBulletScreenAsync>d__21>(ref <ShowBulletScreenAsync>d__);
		return <ShowBulletScreenAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013BB9 RID: 80825 RVA: 0x0057DF84 File Offset: 0x0057C184
	private void RemoveBulletScreen(RacingBetsBulletScreenItem bulletScreenItem)
	{
		this.BulletScreenItemList.Remove(bulletScreenItem);
		bulletScreenItem.GetRootItem().SetUIActive(false);
		this.BulletScreenItemPool.Add(bulletScreenItem);
		foreach (int key in bulletScreenItem.OccupiedTracks)
		{
			this.BulletTrackMap.Remove(key);
		}
		bulletScreenItem.OccupiedTracks.Clear();
	}

	// Token: 0x06013BBA RID: 80826 RVA: 0x0057E010 File Offset: 0x0057C210
	private void InitBulletScreenBornPosition(int bulletScreenId, RacingBetsBulletScreenItem bulletScreenItem)
	{
		int bulletScreenTrackCount = this.GetBulletScreenTrackCount(bulletScreenId);
		int randomTrack = this.GetRandomTrack(bulletScreenTrackCount);
		float num = this.BulletScreenItemHeight * (float)bulletScreenTrackCount - bulletScreenItem.GetBulletScreenItemHeight();
		float num2;
		if (num <= 0f)
		{
			num2 = 0f;
		}
		else
		{
			num2 = (float)(Random.Shared.NextDouble() * (double)num - (double)(num / 2f));
		}
		UUIItem rootItem = bulletScreenItem.GetRootItem();
		rootItem.SetAnchorOffsetX(this.ViewportWidth);
		rootItem.SetAnchorOffsetY((float)(-(float)randomTrack) * this.BulletScreenItemHeight - num2);
		bulletScreenItem.OccupiedTracks.Clear();
		for (int i = 0; i < bulletScreenTrackCount; i++)
		{
			int num3 = randomTrack + i;
			this.BulletTrackMap[num3] = bulletScreenItem;
			bulletScreenItem.OccupiedTracks.Add(num3);
		}
	}

	// Token: 0x06013BBB RID: 80827 RVA: 0x0057E0CB File Offset: 0x0057C2CB
	protected override void OnBeforeDestroy()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.FlowTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06013BBC RID: 80828 RVA: 0x0057E0F0 File Offset: 0x0057C2F0
	private int GetRandomTrack(int trackCount)
	{
		int i = 0;
		while (i < this.MaxRandomTime)
		{
			i++;
			int num = Random.Shared.Next(this.BulletTrackCount + 1 - trackCount);
			if (this.CheckMultiTrackCanPushBulletScreen(num, trackCount))
			{
				return num;
			}
		}
		for (int j = 0; j < this.BulletTrackCount; j++)
		{
			if (this.CheckMultiTrackCanPushBulletScreen(j, trackCount))
			{
				return j;
			}
		}
		return 0;
	}

	// Token: 0x06013BBD RID: 80829 RVA: 0x0057E150 File Offset: 0x0057C350
	private bool CheckCanPushBulletScreen()
	{
		int bulletScreenId;
		if (this.SelfBulletScreenIdList.Count > 0)
		{
			bulletScreenId = this.SelfBulletScreenIdList[0];
		}
		else
		{
			if (this.BulletScreenIdList.Count <= 0)
			{
				return false;
			}
			bulletScreenId = this.BulletScreenIdList[0];
		}
		int bulletScreenTrackCount = this.GetBulletScreenTrackCount(bulletScreenId);
		for (int i = 0; i < this.BulletTrackCount; i++)
		{
			if (this.CheckMultiTrackCanPushBulletScreen(i, bulletScreenTrackCount))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06013BBE RID: 80830 RVA: 0x0057E1C4 File Offset: 0x0057C3C4
	private bool CheckMultiTrackCanPushBulletScreen(int track, int trackCount)
	{
		for (int i = 0; i < trackCount; i++)
		{
			if (!this.CheckTrackCanPushBulletScreen(track + i))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06013BBF RID: 80831 RVA: 0x0057E1EC File Offset: 0x0057C3EC
	private bool CheckTrackCanPushBulletScreen(int track)
	{
		RacingBetsBulletScreenItem racingBetsBulletScreenItem;
		if (!this.BulletTrackMap.TryGetValue(track, out racingBetsBulletScreenItem))
		{
			return true;
		}
		UUIItem rootItem = racingBetsBulletScreenItem.GetRootItem();
		return rootItem == null || rootItem.GetAnchorOffsetX() + racingBetsBulletScreenItem.GetBulletScreenItemWidth() < this.ViewportWidth;
	}

	// Token: 0x06013BC0 RID: 80832 RVA: 0x0057E22C File Offset: 0x0057C42C
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<RacingBetsBulletScreenItem> GetBulletScreenItemAsync()
	{
		RacingBetsBulletScreenPanel.<GetBulletScreenItemAsync>d__29 <GetBulletScreenItemAsync>d__;
		<GetBulletScreenItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<RacingBetsBulletScreenItem>.Create();
		<GetBulletScreenItemAsync>d__.<>4__this = this;
		<GetBulletScreenItemAsync>d__.<>1__state = -1;
		<GetBulletScreenItemAsync>d__.<>t__builder.Start<RacingBetsBulletScreenPanel.<GetBulletScreenItemAsync>d__29>(ref <GetBulletScreenItemAsync>d__);
		return <GetBulletScreenItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013BC1 RID: 80833 RVA: 0x0057E270 File Offset: 0x0057C470
	private int GetBulletScreenTrackCount(int bulletScreenId)
	{
		RacingBetsBulletScreen? racingBetsBulletScreen = ConfigBase<RacingBetsConfig>.Instance.GetRacingBetsBulletScreen(bulletScreenId);
		if (racingBetsBulletScreen == null)
		{
			return 1;
		}
		if (racingBetsBulletScreen.Value.Type == 1)
		{
			return 2;
		}
		return 1;
	}

	// Token: 0x06013BC2 RID: 80834 RVA: 0x0057E2A9 File Offset: 0x0057C4A9
	[NullableContext(2)]
	private UUIItem CreateBulletActor()
	{
		if (this.TemplateGridActor == null)
		{
			return null;
		}
		return Singleton<LguiUtil>.Instance.CopyItem(this.TemplateGridActor.GetUIItem(), base.GetRootItem());
	}

	// Token: 0x06013BC3 RID: 80835 RVA: 0x0057E2D0 File Offset: 0x0057C4D0
	public void SetBulletScreenShowType(ERacingBetsBulletScreenShowType showType)
	{
		if (showType == ERacingBetsBulletScreenShowType.Full)
		{
			this.BulletTrackCount = (int)Math.Floor((double)(this.ViewportHeight / this.BulletScreenItemHeight));
			return;
		}
		this.BulletTrackCount = (int)Math.Floor((double)(this.ViewportHeight / this.BulletScreenItemHeight / 2f));
	}

	// Token: 0x06013BC4 RID: 80836 RVA: 0x0057E31C File Offset: 0x0057C51C
	public void PushBulletScreen(IReadOnlyList<int> bulletScreenIdList, bool isSelf)
	{
		if (isSelf)
		{
			this.SelfBulletScreenIdList.AddRange(bulletScreenIdList);
			return;
		}
		this.BulletScreenIdList = new List<int>(bulletScreenIdList);
	}

	// Token: 0x040099AD RID: 39341
	private float ViewportHeight;

	// Token: 0x040099AE RID: 39342
	private float ViewportWidth;

	// Token: 0x040099AF RID: 39343
	private readonly float BulletScreenItemHeight = 80f;

	// Token: 0x040099B0 RID: 39344
	private readonly float BulletScreenInternal = 200f;

	// Token: 0x040099B1 RID: 39345
	private readonly float BulletScreenSpeed = 0.2f;

	// Token: 0x040099B2 RID: 39346
	private readonly int MaxRandomTime = 5;

	// Token: 0x040099B3 RID: 39347
	private float BulletScreenCurInternal;

	// Token: 0x040099B4 RID: 39348
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x040099B5 RID: 39349
	private readonly Dictionary<int, RacingBetsBulletScreenItem> BulletTrackMap = new Dictionary<int, RacingBetsBulletScreenItem>();

	// Token: 0x040099B6 RID: 39350
	private int BulletTrackCount;

	// Token: 0x040099B7 RID: 39351
	private readonly HashSet<RacingBetsBulletScreenItem> BulletScreenItemList = new HashSet<RacingBetsBulletScreenItem>();

	// Token: 0x040099B8 RID: 39352
	private readonly List<RacingBetsBulletScreenItem> BulletScreenItemPool = new List<RacingBetsBulletScreenItem>();

	// Token: 0x040099B9 RID: 39353
	private List<int> BulletScreenIdList = new List<int>();

	// Token: 0x040099BA RID: 39354
	private readonly List<int> SelfBulletScreenIdList = new List<int>();

	// Token: 0x040099BB RID: 39355
	private readonly List<RacingBetsBulletScreenItem> PendingRemoveList = new List<RacingBetsBulletScreenItem>();

	// Token: 0x040099BC RID: 39356
	[Nullable(2)]
	private AUIBaseActor TemplateGridActor;

	// Token: 0x02008AB2 RID: 35506
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402EC4A RID: 191562
		BulletContent
	}
}
