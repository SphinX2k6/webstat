using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006038 RID: 24632
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleHonamiStoryMapLevelView : BattleVisibleChildView
	{
		// Token: 0x0603E226 RID: 254502 RVA: 0x00FDBDAC File Offset: 0x00FD9FAC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603E227 RID: 254503 RVA: 0x00FDBF60 File Offset: 0x00FDA160
		protected override UniTask OnBeforeStartAsync()
		{
			BattleHonamiStoryMapLevelView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleHonamiStoryMapLevelView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E228 RID: 254504 RVA: 0x00FDBFA4 File Offset: 0x00FDA1A4
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.MiniMap);
			this.TweenPlayer = new BattleUiTweenAnimPlayer();
			this.TweenPlayer.InitTweenAnim(6, base.GetItem(6), false);
			this.TweenPlayer.InitTweenAnim(7, base.GetItem(7), false);
			this.OnPollutionInit();
			this.AddEvents();
			if (!ModelBase<FunctionModel>.Instance.IsOpen(10114))
			{
				base.SetVisible(1, false);
				Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
				Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			}
		}

		// Token: 0x0603E229 RID: 254505 RVA: 0x00FDC04F File Offset: 0x00FDA24F
		public override void Reset()
		{
			this.RemoveEvents();
			TimerHandle pollutionTimer = this.PollutionTimer;
			if (pollutionTimer != null)
			{
				pollutionTimer.Remove();
			}
			this.PollutionTimer = null;
			BattleUiTweenAnimPlayer tweenPlayer = this.TweenPlayer;
			if (tweenPlayer != null)
			{
				tweenPlayer.Clear(false);
			}
			this.TweenPlayer = null;
			base.Reset();
		}

		// Token: 0x0603E22A RID: 254506 RVA: 0x00FDC08F File Offset: 0x00FDA28F
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnHonamiStoryInstInfoUpdate, new Action(this.OnPollutionInit));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnHonamiStoryPollutionUpdate, new Action<int>(this.OnPollutionUpdate));
		}

		// Token: 0x0603E22B RID: 254507 RVA: 0x00FDC0C9 File Offset: 0x00FDA2C9
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStoryInstInfoUpdate, new Action(this.OnPollutionInit));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStoryPollutionUpdate, new Action<int>(this.OnPollutionUpdate));
			this.RemoveFunctionOpenEvents();
		}

		// Token: 0x0603E22C RID: 254508 RVA: 0x00FDC10C File Offset: 0x00FDA30C
		private void RemoveFunctionOpenEvents()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			}
		}

		// Token: 0x0603E22D RID: 254509 RVA: 0x00FDC18B File Offset: 0x00FDA38B
		private void OnPollutionInit()
		{
			this.RefreshPollution(true);
		}

		// Token: 0x0603E22E RID: 254510 RVA: 0x00FDC194 File Offset: 0x00FDA394
		private void OnPollutionUpdate(int _)
		{
			this.RefreshPollution(false);
			BattleHonamiStoryMapLevelHoverItem hoverItem = this.HoverItem;
			if (hoverItem == null)
			{
				return;
			}
			hoverItem.Refresh();
		}

		// Token: 0x0603E22F RID: 254511 RVA: 0x00FDC1AD File Offset: 0x00FDA3AD
		private void OnFunctionOpenUpdate(EFunctionType functionType, bool isOpen)
		{
			if (functionType == EFunctionType.HonamiStoryPollution && isOpen)
			{
				base.SetVisible(1, true);
				this.RemoveFunctionOpenEvents();
			}
		}

		// Token: 0x0603E230 RID: 254512 RVA: 0x00FDC1CC File Offset: 0x00FDA3CC
		private void RefreshPollution(bool isInit = false)
		{
			int pollutionLevel = ModelBase<HonamiStoryModel>.Instance.PollutionLevel;
			int pollutionMaxLevel = ModelBase<HonamiStoryModel>.Instance.PollutionMaxLevel;
			bool flag = pollutionMaxLevel > 0 && pollutionLevel == pollutionMaxLevel;
			BattleHonamiStoryMapLevelView.EPollutionStateType epollutionStateType = flag ? BattleHonamiStoryMapLevelView.EPollutionStateType.Danger : this.GetPollutionState(pollutionLevel);
			if (isInit || epollutionStateType != this.CurrentState)
			{
				this.RefreshPollutionState(epollutionStateType);
				this.CurrentState = epollutionStateType;
			}
			string text = "#ffffff";
			base.GetSprite(0).SetColor(FColor.FromHex(flag ? "#a02649" : text));
			base.GetTexture(1).SetColor(FColor.FromHex(flag ? "#f54667" : text));
			base.GetText(4).SetText(flag ? "Max" : pollutionLevel.ToString(), true);
			if (this.TweenPlayer != null && pollutionLevel > this.LastLevel)
			{
				this.TweenPlayer.PlayTweenAnim(6);
				if (flag)
				{
					this.TweenPlayer.PlayTweenAnim(7);
				}
			}
			this.LastLevel = pollutionLevel;
			bool flag2 = HonamiStoryUtil.CheckInHonamiStoryTopTower();
			if (flag || flag2)
			{
				TimerHandle pollutionTimer = this.PollutionTimer;
				if (pollutionTimer != null)
				{
					pollutionTimer.Remove();
				}
				this.PollutionTimer = null;
				float yaw = flag ? 76f : 10f;
				float fillAmount = flag ? 0.186f : 0f;
				base.GetSprite(2).SetFillAmount(fillAmount);
				UUIItem item = base.GetItem(3);
				FRotator frotator = new FRotator();
				frotator.Yaw = yaw;
				item.SetUIRelativeRotation(frotator);
				return;
			}
			if (this.PollutionTimer == null)
			{
				this.PollutionTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
				{
					int pollutionLevel2 = ModelBase<HonamiStoryModel>.Instance.PollutionLevel;
					float pollutionStarTime = ModelBase<HonamiStoryModel>.Instance.PollutionStarTime;
					float value = (pollutionStarTime > 0f) ? ((float)Singleton<TimeUtil>.Instance.GetServerStopTimeStamp() - pollutionStarTime) : 0f;
					Dictionary<int, IHonamiStoryPollution> pollutionLevelMap = ModelBase<HonamiStoryModel>.Instance.PollutionLevelMap;
					int? num;
					if (pollutionLevelMap == null)
					{
						num = null;
					}
					else
					{
						IHonamiStoryPollution valueOrDefault = pollutionLevelMap.GetValueOrDefault(pollutionLevel2);
						num = ((valueOrDefault != null) ? new int?(valueOrDefault.PersistMilliseconds) : null);
					}
					int? num2 = num;
					int valueOrDefault2 = num2.GetValueOrDefault(1);
					float fillAmount2 = Singleton<MathUtils>.Instance.RangeClamp(value, 0f, (float)valueOrDefault2, 0f, 0.186f);
					base.GetSprite(2).SetFillAmount(fillAmount2);
					UUIItem item2 = base.GetItem(3);
					FRotator frotator2 = new FRotator();
					frotator2.Yaw = Singleton<MathUtils>.Instance.RangeClamp(value, 0f, (float)valueOrDefault2, 10f, 76f);
					item2.SetUIRelativeRotation(frotator2);
				}, 500f, 1f, null, null, true);
			}
		}

		// Token: 0x0603E231 RID: 254513 RVA: 0x00FDC35C File Offset: 0x00FDA55C
		private void RefreshPollutionState(BattleHonamiStoryMapLevelView.EPollutionStateType state)
		{
			string hexStr;
			string hexStr2;
			if (state == BattleHonamiStoryMapLevelView.EPollutionStateType.Safe)
			{
				hexStr = "#bbf0b4";
				hexStr2 = "#ffffff";
			}
			else if (state == BattleHonamiStoryMapLevelView.EPollutionStateType.Warning)
			{
				hexStr = "#e9ce83";
				hexStr2 = "#fff6c9";
			}
			else
			{
				hexStr = "#f54667";
				hexStr2 = "#f51818";
			}
			FColor color = FColor.FromHex(hexStr);
			FColor color2 = FColor.FromHex(hexStr2);
			base.GetSprite(2).SetColor(color);
			base.GetText(4).SetColor(color);
			base.GetTexture(5).SetColor(color2);
		}

		// Token: 0x0603E232 RID: 254514 RVA: 0x00FDC3D0 File Offset: 0x00FDA5D0
		private BattleHonamiStoryMapLevelView.EPollutionStateType GetPollutionState(int level)
		{
			int pollutionWarningLevel = ModelBase<HonamiStoryModel>.Instance.PollutionWarningLevel;
			int pollutionDangerLevel = ModelBase<HonamiStoryModel>.Instance.PollutionDangerLevel;
			if (pollutionDangerLevel > 0 && level >= pollutionDangerLevel)
			{
				return BattleHonamiStoryMapLevelView.EPollutionStateType.Danger;
			}
			if (pollutionWarningLevel > 0 && level >= pollutionWarningLevel)
			{
				return BattleHonamiStoryMapLevelView.EPollutionStateType.Warning;
			}
			return BattleHonamiStoryMapLevelView.EPollutionStateType.Safe;
		}

		// Token: 0x0603E233 RID: 254515 RVA: 0x00FDC408 File Offset: 0x00FDA608
		private void OnClickToggle(EToggleState toggleState)
		{
			BattleHonamiStoryMapLevelHoverItem hoverItem = this.HoverItem;
			if (hoverItem == null)
			{
				return;
			}
			hoverItem.SetActive(toggleState == EToggleState.ETT_Checked);
		}

		// Token: 0x0603E234 RID: 254516 RVA: 0x00FDC420 File Offset: 0x00FDA620
		private void OnAutoClose()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(9);
			if (extendToggle != null)
			{
				if (extendToggle.GetToggleState() == EToggleState.ETT_Checked)
				{
					extendToggle.SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
					return;
				}
				extendToggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
			}
		}

		// Token: 0x04022D4F RID: 142671
		private const float BAR_MAX_FILL = 0.186f;

		// Token: 0x04022D50 RID: 142672
		private const float BAR_MIN_YAW = 10f;

		// Token: 0x04022D51 RID: 142673
		private const float BAR_MAX_YAW = 76f;

		// Token: 0x04022D52 RID: 142674
		private BattleHonamiStoryMapLevelView.EPollutionStateType CurrentState;

		// Token: 0x04022D53 RID: 142675
		private TimerHandle PollutionTimer;

		// Token: 0x04022D54 RID: 142676
		private BattleUiTweenAnimPlayer TweenPlayer;

		// Token: 0x04022D55 RID: 142677
		private int LastLevel;

		// Token: 0x04022D56 RID: 142678
		private BattleHonamiStoryMapLevelHoverItem HoverItem;

		// Token: 0x0200C0F5 RID: 49397
		[NullableContext(0)]
		private enum EPollutionStateType
		{
			// Token: 0x0403B6B0 RID: 243376
			Safe,
			// Token: 0x0403B6B1 RID: 243377
			Warning,
			// Token: 0x0403B6B2 RID: 243378
			Danger
		}

		// Token: 0x0200C0F6 RID: 49398
		[NullableContext(0)]
		private enum EComponentType
		{
			// Token: 0x0403B6B4 RID: 243380
			IconBgSprite,
			// Token: 0x0403B6B5 RID: 243381
			IconTexture,
			// Token: 0x0403B6B6 RID: 243382
			LevelBarSprite,
			// Token: 0x0403B6B7 RID: 243383
			BarLightItem,
			// Token: 0x0403B6B8 RID: 243384
			LevelText,
			// Token: 0x0403B6B9 RID: 243385
			ShineTexture,
			// Token: 0x0403B6BA RID: 243386
			LevelUpItem,
			// Token: 0x0403B6BB RID: 243387
			LevelUpMaxItem,
			// Token: 0x0403B6BC RID: 243388
			HoverItem,
			// Token: 0x0403B6BD RID: 243389
			Toggle
		}
	}
}
