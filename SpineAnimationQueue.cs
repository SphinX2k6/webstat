using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001A56 RID: 6742
[NullableContext(1)]
[Nullable(0)]
public class SpineAnimationQueue
{
	// Token: 0x0600C0B8 RID: 49336 RVA: 0x0032D6F9 File Offset: 0x0032B8F9
	public SpineAnimationQueue(USpineSkeletonAnimationComponent spine)
	{
		this.Spine = spine;
	}

	// Token: 0x0600C0B9 RID: 49337 RVA: 0x0032D708 File Offset: 0x0032B908
	public void PushAnimation(int layerIndex, string animationName, bool loop)
	{
		if (this.Spine == null)
		{
			return;
		}
		if (this.TrackEntry != null)
		{
			if (this.AnimationQueue == null)
			{
				this.AnimationQueue = new List<ISpineAnimationQueueParam>();
			}
			this.AnimationQueue.Add(new SpineAnimationQueueParam
			{
				LayerIndex = layerIndex,
				AnimationName = animationName,
				Loop = loop
			});
			return;
		}
		this.TrackEntry = this.Spine.SetAnimation(layerIndex, animationName, loop);
		UTrackEntry trackEntry = this.TrackEntry;
		if (trackEntry == null)
		{
			return;
		}
		trackEntry.AnimationComplete.Add(new Action<UTrackEntry>(this.OnAnimationCompleted));
	}

	// Token: 0x0600C0BA RID: 49338 RVA: 0x0032D794 File Offset: 0x0032B994
	private void OnAnimationCompleted(UTrackEntry _)
	{
		this.TrackEntry = null;
		if (this.AnimationQueue != null && this.AnimationQueue.Count > 0)
		{
			ISpineAnimationQueueParam spineAnimationQueueParam = this.AnimationQueue[0];
			this.AnimationQueue.RemoveAt(0);
			USpineSkeletonAnimationComponent spine = this.Spine;
			this.TrackEntry = ((spine != null) ? spine.SetAnimation(spineAnimationQueueParam.LayerIndex, spineAnimationQueueParam.AnimationName, spineAnimationQueueParam.Loop) : null);
			UTrackEntry trackEntry = this.TrackEntry;
			if (trackEntry == null)
			{
				return;
			}
			trackEntry.AnimationComplete.Add(new Action<UTrackEntry>(this.OnAnimationCompleted));
		}
	}

	// Token: 0x04005A58 RID: 23128
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ISpineAnimationQueueParam> AnimationQueue;

	// Token: 0x04005A59 RID: 23129
	[Nullable(2)]
	private UTrackEntry TrackEntry;

	// Token: 0x04005A5A RID: 23130
	private readonly USpineSkeletonAnimationComponent Spine;
}
