using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FAC RID: 8108
public class FollowShootVisionCarUnit : HudUnitBase
{
	// Token: 0x0600F3DE RID: 62430 RVA: 0x0042B7A8 File Offset: 0x004299A8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F3DF RID: 62431 RVA: 0x0042B832 File Offset: 0x00429A32
	protected override void OnStart()
	{
		this.TargetItem = base.GetItem(0);
		this.TargetItem.SetUIActive(false);
		this.IsActive = false;
		this.IsTargetItemActive = false;
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600F3E0 RID: 62432 RVA: 0x0042B86C File Offset: 0x00429A6C
	protected override void OnBeforeDestroy()
	{
		this.TargetItem = null;
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
		base.OnBeforeDestroy();
	}

	// Token: 0x0600F3E1 RID: 62433 RVA: 0x0042B894 File Offset: 0x00429A94
	public override void SetActive(bool active)
	{
		if (base.IsCreateOrCreating)
		{
			return;
		}
		if (active == this.IsActive)
		{
			return;
		}
		this.IsActive = active;
		if (active)
		{
			base.SetActive(true);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopSequenceByKey("Close", false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlaySequencePurely("Start", false, false, null, null, false);
			}
			this.IsTargetItemActive = false;
			this.IsClosing = false;
			return;
		}
		this.SetTargetAimVisible(false, false);
		this.IsClosing = true;
		LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
		if (levelSequencePlayer3 != null)
		{
			levelSequencePlayer3.StopSequenceByKey("Start", false, false);
		}
		this.PlayCloseSequenceAsync().Forget();
	}

	// Token: 0x0600F3E2 RID: 62434 RVA: 0x0042B944 File Offset: 0x00429B44
	private UniTask PlayCloseSequenceAsync()
	{
		FollowShootVisionCarUnit.<PlayCloseSequenceAsync>d__10 <PlayCloseSequenceAsync>d__;
		<PlayCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseSequenceAsync>d__.<>4__this = this;
		<PlayCloseSequenceAsync>d__.<>1__state = -1;
		<PlayCloseSequenceAsync>d__.<>t__builder.Start<FollowShootVisionCarUnit.<PlayCloseSequenceAsync>d__10>(ref <PlayCloseSequenceAsync>d__);
		return <PlayCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F3E3 RID: 62435 RVA: 0x0042B987 File Offset: 0x00429B87
	public void SetTargetItemOffset(float x, float y)
	{
		if (this.TargetItem == null)
		{
			return;
		}
		this.TargetItem.SetAnchorOffsetX(x);
		this.TargetItem.SetAnchorOffsetY(y);
	}

	// Token: 0x0600F3E4 RID: 62436 RVA: 0x0042B9AC File Offset: 0x00429BAC
	public void SetTargetAimVisible(bool isVisible, bool isTargetChanged)
	{
		if (this.IsClosing || this.TargetItem == null)
		{
			return;
		}
		if (this.IsTargetItemActive == isVisible)
		{
			if (isVisible && isTargetChanged)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer == null)
				{
					return;
				}
				levelSequencePlayer.PlaySequencePurely("Start_Red", false, false, null, null, false);
			}
			return;
		}
		this.IsTargetItemActive = isVisible;
		if (!isVisible)
		{
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.StopSequenceByKey("StartL", false, false);
			}
			this.PlayCloseTargetSequenceAsync().Forget();
			return;
		}
		this.TargetItem.SetUIActive(true);
		LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
		if (levelSequencePlayer3 != null)
		{
			levelSequencePlayer3.StopSequenceByKey("CloseL", false, false);
		}
		LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
		if (levelSequencePlayer4 == null)
		{
			return;
		}
		levelSequencePlayer4.PlaySequencePurely("StartL", false, false, null, null, false);
	}

	// Token: 0x0600F3E5 RID: 62437 RVA: 0x0042BA70 File Offset: 0x00429C70
	private UniTask PlayCloseTargetSequenceAsync()
	{
		FollowShootVisionCarUnit.<PlayCloseTargetSequenceAsync>d__13 <PlayCloseTargetSequenceAsync>d__;
		<PlayCloseTargetSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseTargetSequenceAsync>d__.<>4__this = this;
		<PlayCloseTargetSequenceAsync>d__.<>1__state = -1;
		<PlayCloseTargetSequenceAsync>d__.<>t__builder.Start<FollowShootVisionCarUnit.<PlayCloseTargetSequenceAsync>d__13>(ref <PlayCloseTargetSequenceAsync>d__);
		return <PlayCloseTargetSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04007556 RID: 30038
	[Nullable(2)]
	private UUIItem TargetItem;

	// Token: 0x04007557 RID: 30039
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04007558 RID: 30040
	private bool IsActive;

	// Token: 0x04007559 RID: 30041
	private bool IsTargetItemActive;

	// Token: 0x0400755A RID: 30042
	private bool IsClosing;

	// Token: 0x02008330 RID: 33584
	private enum EChildType
	{
		// Token: 0x0402C7ED RID: 182253
		TargetItem,
		// Token: 0x0402C7EE RID: 182254
		Left,
		// Token: 0x0402C7EF RID: 182255
		Right
	}
}
