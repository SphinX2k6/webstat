using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200597A RID: 22906
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueGridSelectBase : UiPanelBase
	{
		// Token: 0x0603A059 RID: 237657 RVA: 0x00EAF411 File Offset: 0x00EAD611
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x0603A05A RID: 237658 RVA: 0x00EAF44A File Offset: 0x00EAD64A
		protected override void OnStart()
		{
			this.InteractAnimationPlayer = new LevelSequencePlayer(this.RootItem);
			this.StateAnimationPlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603A05B RID: 237659 RVA: 0x00EAF46E File Offset: 0x00EAD66E
		public void SetSelected(bool isSelectOn)
		{
			this.IsSelectOn = isSelectOn;
		}

		// Token: 0x0603A05C RID: 237660 RVA: 0x00EAF477 File Offset: 0x00EAD677
		public void SetState(bool groupEnable)
		{
			base.GetItem(0).SetUIActive(groupEnable);
			base.GetItem(1).SetUIActive(!groupEnable);
		}

		// Token: 0x0603A05D RID: 237661 RVA: 0x00EAF496 File Offset: 0x00EAD696
		public void SetSequenceToStart(string seqDefine)
		{
			this.JumpToFirstFrame(this.RootItem.GetOwner() as AUIBaseActor, seqDefine);
		}

		// Token: 0x0603A05E RID: 237662 RVA: 0x00EAF4B0 File Offset: 0x00EAD6B0
		public void ResetAllSequence()
		{
			this.SetSequenceToStart("Float");
			string currentSequence = this.InteractAnimationPlayer.GetCurrentSequence();
			if (currentSequence != null)
			{
				this.JumpToFirstFrame(this.RootItem.GetOwner() as AUIBaseActor, currentSequence);
				this.InteractAnimationPlayer.StopPlayingSequence(false, true);
			}
			this.StateAnimationPlayer.PlayLevelSequenceByName("UnSle", false, null, false);
			this.StateAnimationPlayer.StopSequenceByKey("UnSle", false, true);
		}

		// Token: 0x0603A05F RID: 237663 RVA: 0x00EAF528 File Offset: 0x00EAD728
		public void PlaySequence(string seqDefine, bool notDistribute = false)
		{
			if (!(seqDefine == "Float") && !(seqDefine == "Move") && !(seqDefine == "Pre") && !(seqDefine == "PreUp"))
			{
				if (!(seqDefine == "Sle") && !(seqDefine == "UnSle"))
				{
					return;
				}
				string currentSequence = this.StateAnimationPlayer.GetCurrentSequence();
				if (currentSequence != null)
				{
					if (notDistribute && seqDefine == currentSequence)
					{
						return;
					}
					this.JumpToFirstFrame(this.RootItem.GetOwner() as AUIBaseActor, currentSequence);
					this.StateAnimationPlayer.StopPlayingSequence(false, true);
				}
				this.StateAnimationPlayer.PlayLevelSequenceByName(seqDefine, false, null, false);
				return;
			}
			else
			{
				string currentSequence2 = this.InteractAnimationPlayer.GetCurrentSequence();
				if (currentSequence2 != null)
				{
					this.JumpToFirstFrame(this.RootItem.GetOwner() as AUIBaseActor, currentSequence2);
					this.InteractAnimationPlayer.StopPlayingSequence(false, true);
				}
				if (this.IsSelectOn)
				{
					return;
				}
				this.InteractAnimationPlayer.PlayLevelSequenceByName(seqDefine, false, null, false);
				return;
			}
		}

		// Token: 0x0603A060 RID: 237664 RVA: 0x00EAF630 File Offset: 0x00EAD830
		private void JumpToFirstFrame(AUIBaseActor actor, string sequenceName)
		{
			FFrameTime fframeTime = new FFrameTime();
			actor.SequenceJumpToSecondByKey(sequenceName, fframeTime);
		}

		// Token: 0x04020E70 RID: 134768
		[Nullable(2)]
		protected LevelSequencePlayer InteractAnimationPlayer;

		// Token: 0x04020E71 RID: 134769
		[Nullable(2)]
		protected LevelSequencePlayer StateAnimationPlayer;

		// Token: 0x04020E72 RID: 134770
		private bool IsSelectOn;
	}
}
