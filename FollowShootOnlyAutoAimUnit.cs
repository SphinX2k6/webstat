using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FAB RID: 8107
[NullableContext(2)]
[Nullable(0)]
public class FollowShootOnlyAutoAimUnit : HudUnitBase
{
	// Token: 0x0600F3D5 RID: 62421 RVA: 0x0042B4AC File Offset: 0x004296AC
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

	// Token: 0x0600F3D6 RID: 62422 RVA: 0x0042B538 File Offset: 0x00429738
	protected override void OnStart()
	{
		this.TargetItem = base.GetItem(0);
		this.Left = base.GetItem(1);
		this.Right = base.GetItem(2);
		UUIItem targetItem = this.TargetItem;
		if (targetItem != null)
		{
			targetItem.SetUIActive(false);
		}
		UUIItem left = this.Left;
		if (left != null)
		{
			left.SetUIActive(false);
		}
		UUIItem right = this.Right;
		if (right != null)
		{
			right.SetUIActive(false);
		}
		this.IsActive = false;
		this.IsTargetItemActive = false;
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600F3D7 RID: 62423 RVA: 0x0042B5C1 File Offset: 0x004297C1
	protected override void OnBeforeDestroy()
	{
		this.TargetItem = null;
		this.Left = null;
		this.Right = null;
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
		base.OnBeforeDestroy();
	}

	// Token: 0x0600F3D8 RID: 62424 RVA: 0x0042B5F8 File Offset: 0x004297F8
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
		UUIItem left = this.Left;
		if (left != null)
		{
			left.SetUIActive(false);
		}
		UUIItem right = this.Right;
		if (right != null)
		{
			right.SetUIActive(false);
		}
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

	// Token: 0x0600F3D9 RID: 62425 RVA: 0x0042B6CC File Offset: 0x004298CC
	private UniTask PlayCloseSequenceAsync()
	{
		FollowShootOnlyAutoAimUnit.<PlayCloseSequenceAsync>d__12 <PlayCloseSequenceAsync>d__;
		<PlayCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseSequenceAsync>d__.<>4__this = this;
		<PlayCloseSequenceAsync>d__.<>1__state = -1;
		<PlayCloseSequenceAsync>d__.<>t__builder.Start<FollowShootOnlyAutoAimUnit.<PlayCloseSequenceAsync>d__12>(ref <PlayCloseSequenceAsync>d__);
		return <PlayCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F3DA RID: 62426 RVA: 0x0042B70F File Offset: 0x0042990F
	public void SetTargetItemOffset(float x, float y)
	{
		if (this.TargetItem == null)
		{
			return;
		}
		this.TargetItem.SetAnchorOffsetX(x);
		this.TargetItem.SetAnchorOffsetY(y);
	}

	// Token: 0x0600F3DB RID: 62427 RVA: 0x0042B734 File Offset: 0x00429934
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
		this.TargetItem.SetUIActive(isVisible);
	}

	// Token: 0x0400754F RID: 30031
	private UUIItem TargetItem;

	// Token: 0x04007550 RID: 30032
	private UUIItem Left;

	// Token: 0x04007551 RID: 30033
	private UUIItem Right;

	// Token: 0x04007552 RID: 30034
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04007553 RID: 30035
	private bool IsActive;

	// Token: 0x04007554 RID: 30036
	private bool IsTargetItemActive;

	// Token: 0x04007555 RID: 30037
	private bool IsClosing;

	// Token: 0x0200832E RID: 33582
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402C7E5 RID: 182245
		TargetItem,
		// Token: 0x0402C7E6 RID: 182246
		Left,
		// Token: 0x0402C7E7 RID: 182247
		Right
	}
}
