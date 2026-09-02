using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D69 RID: 23913
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FlagChallengeLevelTabItem : GridProxyAbstract<FlagChallengeLevelData>
	{
		// Token: 0x0603C3E2 RID: 246754 RVA: 0x00F481C4 File Offset: 0x00F463C4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIArtText)),
				new ValueTuple<int, Type>(8, typeof(UUISprite)),
				new ValueTuple<int, Type>(9, typeof(UUISprite)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
			};
		}

		// Token: 0x0603C3E3 RID: 246755 RVA: 0x00F4830C File Offset: 0x00F4650C
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			extendToggle.CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
			extendToggle.OnUndeterminedClicked.Add(new Action(this.OnUndeterminedClicked));
			Singleton<EventSystem>.Instance.Add(EEventName.OnFlagChallengeUpdateLevelData, new Action(this.OnLevelDataUpdate));
		}

		// Token: 0x0603C3E4 RID: 246756 RVA: 0x00F4836C File Offset: 0x00F4656C
		protected override void OnBeforeDestroy()
		{
			if (this.IsInitRedDot && this.Data != null)
			{
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotFlagChallengeActivityLevelNewlyUnlocked, base.GetItem(10), this.Data.Id);
				this.IsInitRedDot = false;
			}
			this.RemoveTimer();
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFlagChallengeUpdateLevelData, new Action(this.OnLevelDataUpdate));
		}

		// Token: 0x0603C3E5 RID: 246757 RVA: 0x00F483D4 File Offset: 0x00F465D4
		public override void Refresh(FlagChallengeLevelData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.RefreshView(isSelected);
		}

		// Token: 0x0603C3E6 RID: 246758 RVA: 0x00F483E4 File Offset: 0x00F465E4
		public override object GetKey(FlagChallengeLevelData data, int displayIndex)
		{
			return data.Id;
		}

		// Token: 0x0603C3E7 RID: 246759 RVA: 0x00F483F4 File Offset: 0x00F465F4
		private void RefreshView(bool isSelected)
		{
			this.RemoveTimer();
			if (!this.IsInitRedDot)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotFlagChallengeActivityLevelNewlyUnlocked, base.GetItem(10), null, this.Data.Id);
				this.IsInitRedDot = true;
			}
			UUIArtText artText = base.GetArtText(7);
			UUISprite sprite = base.GetSprite(9);
			if (this.Data.IsHiddenLevel())
			{
				sprite.SetUIActive(true);
				artText.SetUIActive(false);
			}
			else
			{
				sprite.SetUIActive(false);
				artText.SetUIActive(true);
				artText.SetText(this.Data.Index.ToString().PadLeft(2, '0'));
			}
			base.GetSprite(8).SetUIActive(this.Data.IsCompleted());
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			bool flag = this.Data.IsLocked();
			base.GetItem(11).SetUIActive(flag);
			UUIItem uuiitem = artText;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(artText.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			if (flag)
			{
				extendToggle.SetToggleStateForce(EToggleState.ETT_UnDetermined, false, false, false);
				UUISprite sprite2 = base.GetSprite(5);
				UUIText text = base.GetText(6);
				if (!this.Data.IsReachUnlockTime())
				{
					this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconMorale3"), sprite2, false, null, null);
					string countDownText = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat7(this.Data.GetRemainTime() * 0.0010000000474974513).CountDownText;
					text.SetText(countDownText, true);
					this.AddTimer();
				}
				else
				{
					this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconMorale4"), sprite2, false, null, null);
					text.SetText(this.Data.GetUnlockLevel().ToString(), true);
				}
			}
			else
			{
				this.SetToggleState(isSelected, false);
			}
			UUITexture texture = base.GetTexture(1);
			texture.SetUIActive(!flag);
			Dictionary<string, string> dictionary;
			if (!Singleton<FlagChallengeDefine>.Instance.flagChallengeStyleRes.TryGetValue(this.Data.GetUiStyle(), out dictionary))
			{
				return;
			}
			base.SetTextureByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(dictionary["LevelTabItemNormal"]), texture, null, null);
			base.SetTextureByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(dictionary["LevelTabItemHover"]), base.GetTexture(2), null, null);
			base.SetTextureByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(dictionary["LevelTabItemSelect"]), base.GetTexture(4), null, null);
		}

		// Token: 0x0603C3E8 RID: 246760 RVA: 0x00F48671 File Offset: 0x00F46871
		private void AddTimer()
		{
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				this.RefreshRemainTime();
			}, (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
		}

		// Token: 0x0603C3E9 RID: 246761 RVA: 0x00F486A2 File Offset: 0x00F468A2
		private void RemoveTimer()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x0603C3EA RID: 246762 RVA: 0x00F486C4 File Offset: 0x00F468C4
		private void RefreshRemainTime()
		{
			double remainTime = this.Data.GetRemainTime();
			if (remainTime <= 0.0)
			{
				this.RefreshView(false);
				return;
			}
			string countDownText = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat7(remainTime * 0.0010000000474974513).CountDownText;
			UUIText text = base.GetText(6);
			if (text == null)
			{
				return;
			}
			text.SetText(countDownText, true);
		}

		// Token: 0x0603C3EB RID: 246763 RVA: 0x00F48720 File Offset: 0x00F46920
		public void SetToggleState(bool state, bool fireEvent = false)
		{
			if (state)
			{
				int id = this.Data.Id;
				int levelActivityId = FlagChallengeUtils.GetLevelActivityId(id);
				FlagChallengeData flagChallengeData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(levelActivityId);
				if (flagChallengeData.IsLevelNewlyUnlocked(id))
				{
					flagChallengeData.SetLevelNewlyUnlocked(id, false);
				}
			}
			EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleStateForce(state2, fireEvent, false, false);
		}

		// Token: 0x0603C3EC RID: 246764 RVA: 0x00F48778 File Offset: 0x00F46978
		public override void OnSelected(bool fireEvent)
		{
			this.SetToggleState(true, fireEvent);
		}

		// Token: 0x0603C3ED RID: 246765 RVA: 0x00F48782 File Offset: 0x00F46982
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleState(false, fireEvent);
		}

		// Token: 0x0603C3EE RID: 246766 RVA: 0x00F4878C File Offset: 0x00F4698C
		public void SetToggleCallback(Action<int> cb)
		{
			this.ToggleCallback = cb;
		}

		// Token: 0x0603C3EF RID: 246767 RVA: 0x00F48795 File Offset: 0x00F46995
		public void SetCanExecuteCallback(Func<int, bool> cb)
		{
			this.CanExecuteCallback = cb;
		}

		// Token: 0x0603C3F0 RID: 246768 RVA: 0x00F4879E File Offset: 0x00F4699E
		private void OnClickToggle(EToggleState state)
		{
			Action<int> toggleCallback = this.ToggleCallback;
			if (toggleCallback == null)
			{
				return;
			}
			toggleCallback(this.Data.Id);
		}

		// Token: 0x0603C3F1 RID: 246769 RVA: 0x00F487BB File Offset: 0x00F469BB
		private bool OnCanExecuteChange()
		{
			if (this.Data.IsLocked())
			{
				return false;
			}
			Func<int, bool> canExecuteCallback = this.CanExecuteCallback;
			return canExecuteCallback == null || canExecuteCallback(this.Data.Id);
		}

		// Token: 0x0603C3F2 RID: 246770 RVA: 0x00F487E8 File Offset: 0x00F469E8
		private void OnUndeterminedClicked()
		{
			if (!this.Data.IsLocked())
			{
				return;
			}
			if (!this.Data.IsReachUnlockTime())
			{
				string countDownText = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat7(this.Data.GetRemainTime() * 0.0010000000474974513).CountDownText;
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Morale_32_Main_LvLocked_Tips", new object[]
				{
					countDownText
				});
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Morale_32_Main_TimeLocked_Tips", new object[]
			{
				this.Data.GetUnlockLevel()
			});
		}

		// Token: 0x0603C3F3 RID: 246771 RVA: 0x00F48878 File Offset: 0x00F46A78
		private void OnLevelDataUpdate()
		{
			if (this.Data == null)
			{
				return;
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			this.RefreshView(extendToggle.GetToggleState() == EToggleState.ETT_Checked);
		}

		// Token: 0x04021DAD RID: 138669
		private FlagChallengeLevelData Data;

		// Token: 0x04021DAE RID: 138670
		[Nullable(2)]
		private Action<int> ToggleCallback;

		// Token: 0x04021DAF RID: 138671
		[Nullable(2)]
		private Func<int, bool> CanExecuteCallback;

		// Token: 0x04021DB0 RID: 138672
		private bool IsInitRedDot;

		// Token: 0x04021DB1 RID: 138673
		[Nullable(2)]
		protected TimerHandle TimerHandle;
	}
}
