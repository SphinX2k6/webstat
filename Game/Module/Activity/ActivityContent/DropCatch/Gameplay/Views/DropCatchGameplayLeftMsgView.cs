using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x02006902 RID: 26882
	[NullableContext(2)]
	[Nullable(0)]
	public class DropCatchGameplayLeftMsgView : UiPanelBase
	{
		// Token: 0x06042C8C RID: 273548 RVA: 0x01123944 File Offset: 0x01121B44
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUISprite))
			};
		}

		// Token: 0x06042C8D RID: 273549 RVA: 0x011239B4 File Offset: 0x01121BB4
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.SequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.OnEndSequence));
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x06042C8E RID: 273550 RVA: 0x01123A10 File Offset: 0x01121C10
		protected override void OnBeforeShow()
		{
			IDropCatchGameplayLeftMsgParams dropCatchGameplayLeftMsgParams = this.OpenParam as IDropCatchGameplayLeftMsgParams;
			EDropCatchGameplayLeftMsgType type = dropCatchGameplayLeftMsgParams.Type;
			if (type != EDropCatchGameplayLeftMsgType.Gameplay)
			{
				if (type == EDropCatchGameplayLeftMsgType.DropItem)
				{
					UUIItem item = base.GetItem(1);
					if (item != null)
					{
						item.SetUIActive(false);
					}
					UUIItem item2 = base.GetItem(2);
					if (item2 != null)
					{
						item2.SetUIActive(true);
					}
				}
			}
			else
			{
				UUIItem item3 = base.GetItem(1);
				if (item3 != null)
				{
					item3.SetUIActive(true);
				}
				UUIItem item4 = base.GetItem(2);
				if (item4 != null)
				{
					item4.SetUIActive(false);
				}
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), dropCatchGameplayLeftMsgParams.TextId, Array.Empty<object>());
			if (!StringUtils.IsEmpty(dropCatchGameplayLeftMsgParams.Icon))
			{
				base.TrySetSpriteByPath(dropCatchGameplayLeftMsgParams.Icon, base.GetSprite(3), true, null, null);
			}
		}

		// Token: 0x06042C8F RID: 273551 RVA: 0x01123AD0 File Offset: 0x01121CD0
		protected override void OnAfterShow()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null && sequencePlayer.IsSequenceInPlaying("Start"))
			{
				UiSequencePlayer sequencePlayer2 = this.SequencePlayer;
				if (sequencePlayer2 != null)
				{
					sequencePlayer2.ReplaySequence("Start");
				}
			}
			else
			{
				UiSequencePlayer sequencePlayer3 = this.SequencePlayer;
				if (sequencePlayer3 != null)
				{
					sequencePlayer3.StopSequenceByKey("Close", false, false);
				}
				UiSequencePlayer sequencePlayer4 = this.SequencePlayer;
				if (sequencePlayer4 != null)
				{
					sequencePlayer4.PlaySequence("Start", false, null);
				}
			}
			Action<bool> activeCallback = this.ActiveCallback;
			if (activeCallback != null)
			{
				activeCallback(true);
			}
			this.ClearTimer();
			IDropCatchGameplayLeftMsgParams dropCatchGameplayLeftMsgParams = this.OpenParam as IDropCatchGameplayLeftMsgParams;
			if (dropCatchGameplayLeftMsgParams.Duration == null)
			{
				return;
			}
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				UiSequencePlayer sequencePlayer5 = this.SequencePlayer;
				if (sequencePlayer5 == null)
				{
					return;
				}
				sequencePlayer5.PlaySequence("Close", false, null);
			}, dropCatchGameplayLeftMsgParams.Duration.Value * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
		}

		// Token: 0x06042C90 RID: 273552 RVA: 0x01123BB3 File Offset: 0x01121DB3
		[NullableContext(1)]
		private void OnEndSequence(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				base.Hide(null);
			}
		}

		// Token: 0x06042C91 RID: 273553 RVA: 0x01123BC9 File Offset: 0x01121DC9
		private void ClearTimer()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.TimerHandle))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			}
			this.TimerHandle = null;
		}

		// Token: 0x06042C92 RID: 273554 RVA: 0x01123BF5 File Offset: 0x01121DF5
		protected override void OnAfterHide()
		{
			Action<bool> activeCallback = this.ActiveCallback;
			if (activeCallback == null)
			{
				return;
			}
			activeCallback(false);
		}

		// Token: 0x06042C93 RID: 273555 RVA: 0x01123C08 File Offset: 0x01121E08
		protected override void OnBeforeDestroy()
		{
			this.ClearTimer();
		}

		// Token: 0x04025357 RID: 152407
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04025358 RID: 152408
		private TimerHandle TimerHandle;

		// Token: 0x04025359 RID: 152409
		public Action<bool> ActiveCallback;
	}
}
