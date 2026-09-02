using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052FD RID: 21245
	[NullableContext(2)]
	[Nullable(0)]
	public class QuickHackMarksIconItem : UiPanelBase
	{
		// Token: 0x060363AB RID: 222123 RVA: 0x00DAA338 File Offset: 0x00DA8538
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060363AC RID: 222124 RVA: 0x00DAA404 File Offset: 0x00DA8604
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
		}

		// Token: 0x060363AD RID: 222125 RVA: 0x00DAA418 File Offset: 0x00DA8618
		protected override void OnBeforeDestroy()
		{
			this.StopLoopAudio();
			TimerHandle timer = this.Timer;
			if (timer != null)
			{
				timer.Remove();
			}
			this.Timer = null;
			this.OnFinish = null;
			QuickHackMarkInstance mark = this.Mark;
			if (mark != null)
			{
				mark.UnRegisterOnProgressChange();
			}
			this.Mark = null;
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
		}

		// Token: 0x060363AE RID: 222126 RVA: 0x00DAA47B File Offset: 0x00DA867B
		public int GetMarkId()
		{
			return this.MarkId;
		}

		// Token: 0x060363AF RID: 222127 RVA: 0x00DAA484 File Offset: 0x00DA8684
		[NullableContext(1)]
		public void StartPerform(QuickHackMarkInstance mark, Action<int> onFinish)
		{
			this.Mark = mark;
			this.MarkId = mark.GetId();
			string iconPath = mark.GetIconPath();
			bool flag = !StringUtils.IsBlank(iconPath);
			UUITexture iconTexture = base.GetTexture(2);
			UUITexture iconMaskTexture = base.GetTexture(3);
			this.SequencePlayer.PlaySequencePurely("Start", false, false);
			this.UpdateColorStyle(true);
			iconTexture.SetUIActive(false);
			iconMaskTexture.SetUIActive(false);
			if (flag)
			{
				base.SetTextureByPath(iconPath, iconTexture, null, delegate(bool result)
				{
					if (result)
					{
						iconTexture.SetUIActive(true);
					}
				});
				base.SetTextureByPath(iconPath, iconMaskTexture, null, delegate(bool result)
				{
					if (result)
					{
						iconMaskTexture.SetUIActive(true);
					}
				});
			}
			this.OnFinish = onFinish;
			mark.RegisterOnProgressChange(new Action<double>(this.UpdateProgress));
			mark.RegisterOnStateChange(new Action<EQuickHackMarkState, EQuickHackMarkState>(this.OnStateChange));
			this.UpdateState(null, mark.GetCurrentState());
			this.UpdateProgress(mark.GetCurrentProgress());
		}

		// Token: 0x060363B0 RID: 222128 RVA: 0x00DAA597 File Offset: 0x00DA8797
		private void UpdateProgress(double progress)
		{
			base.GetSprite(1).SetFillAmount((float)progress);
			base.GetTexture(3).SetFillAmount((float)progress);
		}

		// Token: 0x060363B1 RID: 222129 RVA: 0x00DAA5B5 File Offset: 0x00DA87B5
		private void OnStateChange(EQuickHackMarkState lastState, EQuickHackMarkState state)
		{
			this.UpdateState(new EQuickHackMarkState?(lastState), state);
		}

		// Token: 0x060363B2 RID: 222130 RVA: 0x00DAA5C4 File Offset: 0x00DA87C4
		private void UpdateState(EQuickHackMarkState? lastState, EQuickHackMarkState state)
		{
			if (state == EQuickHackMarkState.Upload)
			{
				this.StartLoopAudio();
				return;
			}
			if (lastState.GetValueOrDefault() == EQuickHackMarkState.Upload)
			{
				this.StopLoopAudio();
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_focus_mode_scanning_qh_done");
			}
			if (state == EQuickHackMarkState.Duration)
			{
				QuickHackMarkInstance mark = this.Mark;
				bool flag;
				if (mark == null)
				{
					flag = (null != null);
				}
				else
				{
					EntityHandle owner = mark.GetOwner();
					if (owner == null)
					{
						flag = (null != null);
					}
					else
					{
						WorldEntity entity = owner.Entity;
						flag = (((entity != null) ? entity.GetComponent<SceneItemQuickHackComponent>() : null) != null);
					}
				}
				if (flag)
				{
					this.UpdateColorStyle(false);
				}
			}
			if (state == EQuickHackMarkState.Finish)
			{
				QuickHackMarkInstance mark2 = this.Mark;
				if (mark2 != null)
				{
					mark2.UnRegisterOnProgressChange();
				}
				QuickHackMarkInstance mark3 = this.Mark;
				if (mark3 != null)
				{
					mark3.UnRegisterOnStateChange();
				}
				this.Timer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					this.FinishPerform();
				}, 100f, null, null, true, 1f);
			}
		}

		// Token: 0x060363B3 RID: 222131 RVA: 0x00DAA684 File Offset: 0x00DA8884
		private void FinishPerform()
		{
			this.Timer = null;
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.StopSequenceByKey("Start", false, false);
			}
			Action<int> onFinish = this.OnFinish;
			if (onFinish != null)
			{
				onFinish(this.MarkId);
			}
			this.OnFinish = null;
			this.Mark = null;
		}

		// Token: 0x060363B4 RID: 222132 RVA: 0x00DAA6D8 File Offset: 0x00DA88D8
		private void StartLoopAudio()
		{
			if (this.LoopAudioEventHandle != 0)
			{
				return;
			}
			int num = Singleton<AudioSystem>.Instance.PostEvent("play_ui_focus_mode_scanning_loop");
			if (num != 0)
			{
				this.LoopAudioEventHandle = num;
				Singleton<EventSystem>.Instance.Add(EEventName.OnQuickHackClose, new Action(this.OnQuickHackClose));
			}
		}

		// Token: 0x060363B5 RID: 222133 RVA: 0x00DAA724 File Offset: 0x00DA8924
		private void OnQuickHackClose()
		{
			this.StopLoopAudio();
		}

		// Token: 0x060363B6 RID: 222134 RVA: 0x00DAA72C File Offset: 0x00DA892C
		private void StopLoopAudio()
		{
			if (this.LoopAudioEventHandle == 0)
			{
				return;
			}
			Singleton<AudioSystem>.Instance.ExecuteAction(this.LoopAudioEventHandle, EAudioActionType.Stop, null);
			this.LoopAudioEventHandle = 0;
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuickHackClose, new Action(this.OnQuickHackClose));
		}

		// Token: 0x060363B7 RID: 222135 RVA: 0x00DAA780 File Offset: 0x00DA8980
		private void UpdateColorStyle(bool isRed)
		{
			string hexStr = isRed ? "#FF4F4BFF" : "#6CF4F8FF";
			base.GetTexture(2).SetColor(FColor.FromHex(hexStr));
			this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(isRed ? "QuickHackMarkBackgroundRed" : "QuickHackMarkBackgroundBlue"), base.GetSprite(4), false, null, null);
			this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(isRed ? "QuickHackMarkProgressRed" : "QuickHackMarkProgressBlue"), base.GetSprite(1), false, null, null);
		}

		// Token: 0x0401F2E4 RID: 127716
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0401F2E5 RID: 127717
		private QuickHackMarkInstance Mark;

		// Token: 0x0401F2E6 RID: 127718
		private int MarkId;

		// Token: 0x0401F2E7 RID: 127719
		private Action<int> OnFinish;

		// Token: 0x0401F2E8 RID: 127720
		private TimerHandle Timer;

		// Token: 0x0401F2E9 RID: 127721
		private int LoopAudioEventHandle;

		// Token: 0x0200B22D RID: 45613
		[NullableContext(0)]
		private class EComponentType
		{
			// Token: 0x040373A7 RID: 226215
			public const int IconItem = 0;

			// Token: 0x040373A8 RID: 226216
			public const int ProgressSprite = 1;

			// Token: 0x040373A9 RID: 226217
			public const int SkillIconTexture = 2;

			// Token: 0x040373AA RID: 226218
			public const int SkillIconMaskTexture = 3;

			// Token: 0x040373AB RID: 226219
			public const int BgSprite = 4;
		}
	}
}
