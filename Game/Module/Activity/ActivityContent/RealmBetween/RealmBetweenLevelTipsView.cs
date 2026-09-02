using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006539 RID: 25913
	[NullableContext(1)]
	[Nullable(0)]
	public class RealmBetweenLevelTipsView : UiViewBase
	{
		// Token: 0x06040C89 RID: 265353 RVA: 0x0109C7C0 File Offset: 0x0109A9C0
		public RealmBetweenLevelTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040C8A RID: 265354 RVA: 0x0109C7F8 File Offset: 0x0109A9F8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
		}

		// Token: 0x06040C8B RID: 265355 RVA: 0x0109C8AC File Offset: 0x0109AAAC
		protected override void OnStart()
		{
			this.OffsetTweenX = new LguiFloatTween();
			this.OffsetTweenX.BindUpdateTween(new Action<float>(this.UpdateOffsetX));
			this.OffsetTweenX.BindCompleteTween(new Action(this.OnCompleteOffsetX));
			ActivityRealmBetweenData activityRealmBetweenData = this.OpenParam as ActivityRealmBetweenData;
			this.PreLevel = activityRealmBetweenData.LastTravelLevel;
			this.CurLevel = activityRealmBetweenData.TravelLevel;
			this.PreExpTotalCount = activityRealmBetweenData.LastExpCount;
			this.CurExpTotalCount = activityRealmBetweenData.GetExpItemCount();
			this.PreCurExpCount = activityRealmBetweenData.LastCurrentExpCount;
			IRealmBetweenLevelData realmBetweenLevelData;
			activityRealmBetweenData.TravelLevelData.TryGetValue(this.PreLevel, out realmBetweenLevelData);
			this.PreLevelTargetExp = realmBetweenLevelData.TargetExp;
			this.CurExpCount = activityRealmBetweenData.GetCurrentExp();
			this.CurTargetExp = activityRealmBetweenData.GetCurrentTargetExp();
			bool flag = this.CurLevel > this.PreLevel;
			bool flag2 = this.CurExpTotalCount > this.PreExpTotalCount;
			if (flag)
			{
				if (flag2)
				{
					this.TipsType = ETipsType.LevelUpAndExpAdd;
				}
				else
				{
					this.TipsType = ETipsType.LevelUp;
				}
			}
			else if (flag2)
			{
				this.TipsType = ETipsType.ExpAdd;
			}
			else
			{
				base.CloseMe(null);
			}
			this.LevelLayout = new GenericLayout<LevelItemGrid, int>(base.GetHorizontalLayout(2), new Func<LevelItemGrid>(this.OnCreateItem), null, false, true);
			this.LevelItemWidth = base.GetItem(3).Width;
			this.LevelItemSpacing = base.GetHorizontalLayout(2).Spacing;
			this.RefreshLayout(activityRealmBetweenData.MaxTravelLevel);
		}

		// Token: 0x06040C8C RID: 265356 RVA: 0x0109CA0A File Offset: 0x0109AC0A
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x06040C8D RID: 265357 RVA: 0x0109CA28 File Offset: 0x0109AC28
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x06040C8E RID: 265358 RVA: 0x0109CA46 File Offset: 0x0109AC46
		private void OnActivitySequenceEmitEvent(string param)
		{
			if (param == "TipsChange")
			{
				this.SetExpMaxText();
			}
		}

		// Token: 0x06040C8F RID: 265359 RVA: 0x0109CA5C File Offset: 0x0109AC5C
		protected override void OnBeforeShow()
		{
			this.TickHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.Refresh), 20f, 1f, null, null, true);
			switch (this.TipsType)
			{
			case ETipsType.ExpAdd:
				this.SetExpText(this.CurExpCount - this.PreCurExpCount);
				this.SetExpTextVisible(true);
				this.RefreshBar((float)this.CurExpCount, (float)this.CurTargetExp);
				this.RefreshBarAdd((float)this.PreCurExpCount, (float)this.CurTargetExp);
				return;
			case ETipsType.LevelUp:
				this.SetExpTextVisible(false);
				this.RefreshBar((float)this.PreLevelTargetExp, (float)this.PreLevelTargetExp);
				this.RefreshBarAdd((float)this.PreLevelTargetExp, (float)this.PreLevelTargetExp);
				return;
			case ETipsType.LevelUpAndExpAdd:
				this.SetExpText(this.CurExpTotalCount - this.PreExpTotalCount);
				this.SetExpTextVisible(true);
				this.RefreshBar((float)this.PreLevelTargetExp, (float)this.PreLevelTargetExp);
				this.RefreshBarAdd((float)this.PreLevelTargetExp, (float)this.PreLevelTargetExp);
				return;
			default:
				return;
			}
		}

		// Token: 0x06040C90 RID: 265360 RVA: 0x0109CB64 File Offset: 0x0109AD64
		protected override void OnAfterShow()
		{
			switch (this.TipsType)
			{
			case ETipsType.ExpAdd:
				this.RunExpAdd().Forget();
				return;
			case ETipsType.LevelUp:
				this.RunLevelUp().Forget();
				return;
			case ETipsType.LevelUpAndExpAdd:
				this.RunLevelUp().Forget();
				return;
			default:
				return;
			}
		}

		// Token: 0x06040C91 RID: 265361 RVA: 0x0109CBAE File Offset: 0x0109ADAE
		protected override void OnBeforeDestroy()
		{
			this.RemoveTick();
			LguiFloatTween offsetTweenX = this.OffsetTweenX;
			if (offsetTweenX == null)
			{
				return;
			}
			offsetTweenX.Destroy();
		}

		// Token: 0x06040C92 RID: 265362 RVA: 0x0109CBC6 File Offset: 0x0109ADC6
		private void UpdateOffsetX(float value)
		{
			UUIItem rootUiItem = this.LevelLayout.GetRootUiItem();
			if (rootUiItem == null)
			{
				return;
			}
			rootUiItem.SetAnchorOffsetX(value);
		}

		// Token: 0x06040C93 RID: 265363 RVA: 0x0109CBDE File Offset: 0x0109ADDE
		private void OnCompleteOffsetX()
		{
			LevelItemGrid layoutItemByIndex = this.LevelLayout.GetLayoutItemByIndex(this.CurLevel);
			if (layoutItemByIndex == null)
			{
				return;
			}
			layoutItemByIndex.PlayLevelUpAnim();
		}

		// Token: 0x06040C94 RID: 265364 RVA: 0x0109CBFC File Offset: 0x0109ADFC
		private void RefreshLayout(int maxLevel)
		{
			List<int> list = new List<int>();
			for (int i = 0; i <= maxLevel; i++)
			{
				list.Add(i);
			}
			this.LevelLayout.RefreshByData(list, delegate
			{
				this.LevelLayout.SelectGridProxy(this.PreLevel, false);
			}, false);
			UUIItem rootUiItem = this.LevelLayout.GetRootUiItem();
			if (rootUiItem == null)
			{
				return;
			}
			rootUiItem.SetAnchorOffsetX(this.GetOffsetX(this.PreLevel));
		}

		// Token: 0x06040C95 RID: 265365 RVA: 0x0109CC5C File Offset: 0x0109AE5C
		private float GetOffsetX(int index)
		{
			return -((float)index * (this.LevelItemWidth + this.LevelItemSpacing) + this.LevelItemWidth * 0.5f);
		}

		// Token: 0x06040C96 RID: 265366 RVA: 0x0109CC7C File Offset: 0x0109AE7C
		private LevelItemGrid OnCreateItem()
		{
			return new LevelItemGrid();
		}

		// Token: 0x06040C97 RID: 265367 RVA: 0x0109CC84 File Offset: 0x0109AE84
		private UniTask RunExpAdd()
		{
			RealmBetweenLevelTipsView.<RunExpAdd>d__27 <RunExpAdd>d__;
			<RunExpAdd>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunExpAdd>d__.<>4__this = this;
			<RunExpAdd>d__.<>1__state = -1;
			<RunExpAdd>d__.<>t__builder.Start<RealmBetweenLevelTipsView.<RunExpAdd>d__27>(ref <RunExpAdd>d__);
			return <RunExpAdd>d__.<>t__builder.Task;
		}

		// Token: 0x06040C98 RID: 265368 RVA: 0x0109CCC8 File Offset: 0x0109AEC8
		private UniTask RunLevelUp()
		{
			RealmBetweenLevelTipsView.<RunLevelUp>d__28 <RunLevelUp>d__;
			<RunLevelUp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunLevelUp>d__.<>4__this = this;
			<RunLevelUp>d__.<>1__state = -1;
			<RunLevelUp>d__.<>t__builder.Start<RealmBetweenLevelTipsView.<RunLevelUp>d__28>(ref <RunLevelUp>d__);
			return <RunLevelUp>d__.<>t__builder.Task;
		}

		// Token: 0x06040C99 RID: 265369 RVA: 0x0109CD0C File Offset: 0x0109AF0C
		protected void Refresh(float delta)
		{
			if (!this.RunBarAnim)
			{
				return;
			}
			this.RunBarAnimTime += delta;
			float current = Singleton<MathUtils>.Instance.Lerp(this.StartValue, this.TargetValue, this.RunBarAnimTime / (float)this.BarAnimTime);
			this.RefreshBarAdd(current, this.EndValue);
			if (this.RunBarAnimTime >= (float)this.BarAnimTime)
			{
				this.EndBarAnim();
			}
		}

		// Token: 0x06040C9A RID: 265370 RVA: 0x0109CD78 File Offset: 0x0109AF78
		private UniTask StartBarAnim(float current, float target, float end)
		{
			RealmBetweenLevelTipsView.<StartBarAnim>d__38 <StartBarAnim>d__;
			<StartBarAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartBarAnim>d__.<>4__this = this;
			<StartBarAnim>d__.current = current;
			<StartBarAnim>d__.target = target;
			<StartBarAnim>d__.end = end;
			<StartBarAnim>d__.<>1__state = -1;
			<StartBarAnim>d__.<>t__builder.Start<RealmBetweenLevelTipsView.<StartBarAnim>d__38>(ref <StartBarAnim>d__);
			return <StartBarAnim>d__.<>t__builder.Task;
		}

		// Token: 0x06040C9B RID: 265371 RVA: 0x0109CDD3 File Offset: 0x0109AFD3
		private void EndBarAnim()
		{
			this.RunBarAnim = false;
			this.BarAnimPromise.SetResult();
		}

		// Token: 0x06040C9C RID: 265372 RVA: 0x0109CDE7 File Offset: 0x0109AFE7
		private void RemoveTick()
		{
			if (this.TickHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TickHandle);
				this.TickHandle = null;
			}
		}

		// Token: 0x06040C9D RID: 265373 RVA: 0x0109CE0C File Offset: 0x0109B00C
		private void RefreshBar(float current, float target)
		{
			float fillAmount = Singleton<MathUtils>.Instance.Clamp(current / target, 0f, 1f);
			base.GetSprite(4).SetFillAmount(fillAmount);
		}

		// Token: 0x06040C9E RID: 265374 RVA: 0x0109CE40 File Offset: 0x0109B040
		private void RefreshBarAdd(float current, float target)
		{
			float fillAmount = Singleton<MathUtils>.Instance.Clamp(current / target, 0f, 1f);
			base.GetSprite(5).SetFillAmount(fillAmount);
		}

		// Token: 0x06040C9F RID: 265375 RVA: 0x0109CE72 File Offset: 0x0109B072
		private void SetExpTextVisible(bool bVisible)
		{
			base.GetItem(6).SetUIActive(bVisible);
		}

		// Token: 0x06040CA0 RID: 265376 RVA: 0x0109CE81 File Offset: 0x0109B081
		private void SetExpText(int expCount)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "RealmBetweenLevelUpTipsExp_Text", new <>z__ReadOnlySingleElementList<object>(expCount));
		}

		// Token: 0x06040CA1 RID: 265377 RVA: 0x0109CEA4 File Offset: 0x0109B0A4
		private void SetExpMaxText()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "RealmBetweenLevelCanUp_Text", Array.Empty<object>());
			this.SetExpTextVisible(true);
		}

		// Token: 0x04024554 RID: 148820
		private ETipsType TipsType;

		// Token: 0x04024555 RID: 148821
		private int PreLevel;

		// Token: 0x04024556 RID: 148822
		private int CurLevel;

		// Token: 0x04024557 RID: 148823
		private int PreExpTotalCount;

		// Token: 0x04024558 RID: 148824
		private int CurExpTotalCount;

		// Token: 0x04024559 RID: 148825
		private int PreLevelTargetExp;

		// Token: 0x0402455A RID: 148826
		private int PreCurExpCount;

		// Token: 0x0402455B RID: 148827
		private int CurExpCount;

		// Token: 0x0402455C RID: 148828
		private int CurTargetExp;

		// Token: 0x0402455D RID: 148829
		private GenericLayout<LevelItemGrid, int> LevelLayout;

		// Token: 0x0402455E RID: 148830
		private float LevelItemWidth;

		// Token: 0x0402455F RID: 148831
		[Nullable(2)]
		private LguiFloatTween OffsetTweenX;

		// Token: 0x04024560 RID: 148832
		private float LevelItemSpacing;

		// Token: 0x04024561 RID: 148833
		[Nullable(2)]
		protected TimerHandle TickHandle;

		// Token: 0x04024562 RID: 148834
		protected int BarAnimTime = ConfigCommonParamById.GetIntConfig("TravelExpBarDisplayTime").Value;

		// Token: 0x04024563 RID: 148835
		protected bool RunBarAnim;

		// Token: 0x04024564 RID: 148836
		protected float RunBarAnimTime;

		// Token: 0x04024565 RID: 148837
		protected float StartValue;

		// Token: 0x04024566 RID: 148838
		protected float TargetValue;

		// Token: 0x04024567 RID: 148839
		protected float EndValue;

		// Token: 0x04024568 RID: 148840
		protected CustomPromise BarAnimPromise = new CustomPromise();
	}
}
