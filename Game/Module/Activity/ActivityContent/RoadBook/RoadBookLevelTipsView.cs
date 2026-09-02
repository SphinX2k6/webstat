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

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x02006496 RID: 25750
	[NullableContext(1)]
	[Nullable(0)]
	public class RoadBookLevelTipsView : UiViewBase
	{
		// Token: 0x06040932 RID: 264498 RVA: 0x0108D340 File Offset: 0x0108B540
		public RoadBookLevelTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040933 RID: 264499 RVA: 0x0108D378 File Offset: 0x0108B578
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUISprite))
			};
		}

		// Token: 0x06040934 RID: 264500 RVA: 0x0108D414 File Offset: 0x0108B614
		protected override void OnStart()
		{
			this.OffsetTweenX = new LguiFloatTween();
			this.OffsetTweenX.BindUpdateTween(new Action<float>(this.UpdateOffsetX));
			this.OffsetTweenX.BindCompleteTween(new Action(this.OnCompleteOffsetX));
			ActivityRoadBookData activityRoadBookData = this.OpenParam as ActivityRoadBookData;
			this.PreLevel = activityRoadBookData.LastTravelLevel;
			this.CurLevel = activityRoadBookData.TravelLevel;
			this.PreExpTotalCount = activityRoadBookData.LastExpCount;
			this.CurExpTotalCount = activityRoadBookData.GetExpItemCount();
			this.PreCurExpCount = activityRoadBookData.LastCurrentExpCount;
			IRoadBookLevelData roadBookLevelData;
			activityRoadBookData.TravelLevelData.TryGetValue(this.PreLevel, out roadBookLevelData);
			this.PreLevelTargetExp = roadBookLevelData.TargetExp;
			this.CurExpCount = activityRoadBookData.GetCurrentExp();
			this.CurTargetExp = activityRoadBookData.GetCurrentTargetExp();
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
			this.RefreshLayout(activityRoadBookData.MaxTravelLevel);
		}

		// Token: 0x06040935 RID: 264501 RVA: 0x0108D572 File Offset: 0x0108B772
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x06040936 RID: 264502 RVA: 0x0108D590 File Offset: 0x0108B790
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x06040937 RID: 264503 RVA: 0x0108D5AE File Offset: 0x0108B7AE
		private void OnActivitySequenceEmitEvent(string param)
		{
			if (param == "TipsChange")
			{
				this.SetExpMaxText();
			}
		}

		// Token: 0x06040938 RID: 264504 RVA: 0x0108D5C4 File Offset: 0x0108B7C4
		protected override void OnBeforeShow()
		{
			this.TickHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.Refresh), 20f, 1f, null, null, true);
			this.RefreshBar(0f, 1f);
			switch (this.TipsType)
			{
			case ETipsType.ExpAdd:
				this.SetExpText(this.CurExpCount - this.PreCurExpCount);
				this.SetExpTextVisible(true);
				this.RefreshBar((float)this.PreCurExpCount, (float)this.CurTargetExp);
				return;
			case ETipsType.LevelUp:
				this.SetExpTextVisible(false);
				this.RefreshBar((float)this.PreCurExpCount, (float)this.PreLevelTargetExp);
				return;
			case ETipsType.LevelUpAndExpAdd:
				this.SetExpText(this.CurExpTotalCount - this.PreExpTotalCount);
				this.SetExpTextVisible(true);
				this.RefreshBar((float)this.PreCurExpCount, (float)this.PreLevelTargetExp);
				return;
			default:
				return;
			}
		}

		// Token: 0x06040939 RID: 264505 RVA: 0x0108D6A0 File Offset: 0x0108B8A0
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

		// Token: 0x0604093A RID: 264506 RVA: 0x0108D6EA File Offset: 0x0108B8EA
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

		// Token: 0x0604093B RID: 264507 RVA: 0x0108D702 File Offset: 0x0108B902
		private void UpdateOffsetX(float value)
		{
			UUIItem rootUiItem = this.LevelLayout.GetRootUiItem();
			if (rootUiItem == null)
			{
				return;
			}
			rootUiItem.SetAnchorOffsetX(value);
		}

		// Token: 0x0604093C RID: 264508 RVA: 0x0108D71A File Offset: 0x0108B91A
		private void OnCompleteOffsetX()
		{
			LevelItemGrid layoutItemByIndex = this.LevelLayout.GetLayoutItemByIndex(this.CurLevel);
			if (layoutItemByIndex == null)
			{
				return;
			}
			layoutItemByIndex.PlayLevelUpAnim();
		}

		// Token: 0x0604093D RID: 264509 RVA: 0x0108D738 File Offset: 0x0108B938
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

		// Token: 0x0604093E RID: 264510 RVA: 0x0108D798 File Offset: 0x0108B998
		private float GetOffsetX(int index)
		{
			return -((float)index * (this.LevelItemWidth + this.LevelItemSpacing) + this.LevelItemWidth * 0.5f);
		}

		// Token: 0x0604093F RID: 264511 RVA: 0x0108D7B8 File Offset: 0x0108B9B8
		private LevelItemGrid OnCreateItem()
		{
			return new LevelItemGrid();
		}

		// Token: 0x06040940 RID: 264512 RVA: 0x0108D7C0 File Offset: 0x0108B9C0
		private UniTask RunExpAdd()
		{
			RoadBookLevelTipsView.<RunExpAdd>d__27 <RunExpAdd>d__;
			<RunExpAdd>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunExpAdd>d__.<>4__this = this;
			<RunExpAdd>d__.<>1__state = -1;
			<RunExpAdd>d__.<>t__builder.Start<RoadBookLevelTipsView.<RunExpAdd>d__27>(ref <RunExpAdd>d__);
			return <RunExpAdd>d__.<>t__builder.Task;
		}

		// Token: 0x06040941 RID: 264513 RVA: 0x0108D804 File Offset: 0x0108BA04
		private UniTask RunLevelUp()
		{
			RoadBookLevelTipsView.<RunLevelUp>d__28 <RunLevelUp>d__;
			<RunLevelUp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunLevelUp>d__.<>4__this = this;
			<RunLevelUp>d__.<>1__state = -1;
			<RunLevelUp>d__.<>t__builder.Start<RoadBookLevelTipsView.<RunLevelUp>d__28>(ref <RunLevelUp>d__);
			return <RunLevelUp>d__.<>t__builder.Task;
		}

		// Token: 0x06040942 RID: 264514 RVA: 0x0108D848 File Offset: 0x0108BA48
		protected void Refresh(float delta)
		{
			if (!this.RunBarAnim)
			{
				return;
			}
			this.RunBarAnimTime += delta;
			float current = Singleton<MathUtils>.Instance.Lerp(this.StartValue, this.TargetValue, this.RunBarAnimTime / (float)this.BarAnimTime);
			this.RefreshBar(current, this.EndValue);
			if (this.RunBarAnimTime >= (float)this.BarAnimTime)
			{
				this.EndBarAnim();
			}
		}

		// Token: 0x06040943 RID: 264515 RVA: 0x0108D8B4 File Offset: 0x0108BAB4
		private UniTask StartBarAnim(float current, float target, float end)
		{
			RoadBookLevelTipsView.<StartBarAnim>d__38 <StartBarAnim>d__;
			<StartBarAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartBarAnim>d__.<>4__this = this;
			<StartBarAnim>d__.current = current;
			<StartBarAnim>d__.target = target;
			<StartBarAnim>d__.end = end;
			<StartBarAnim>d__.<>1__state = -1;
			<StartBarAnim>d__.<>t__builder.Start<RoadBookLevelTipsView.<StartBarAnim>d__38>(ref <StartBarAnim>d__);
			return <StartBarAnim>d__.<>t__builder.Task;
		}

		// Token: 0x06040944 RID: 264516 RVA: 0x0108D90F File Offset: 0x0108BB0F
		private void EndBarAnim()
		{
			this.RunBarAnim = false;
			this.BarAnimPromise.SetResult();
		}

		// Token: 0x06040945 RID: 264517 RVA: 0x0108D923 File Offset: 0x0108BB23
		private void RemoveTick()
		{
			if (this.TickHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TickHandle);
				this.TickHandle = null;
			}
		}

		// Token: 0x06040946 RID: 264518 RVA: 0x0108D948 File Offset: 0x0108BB48
		private void RefreshBar(float current, float target)
		{
			float fillAmount = Singleton<MathUtils>.Instance.Clamp(current / target, 0f, 1f);
			base.GetSprite(5).SetFillAmount(fillAmount);
		}

		// Token: 0x06040947 RID: 264519 RVA: 0x0108D97A File Offset: 0x0108BB7A
		private void SetExpTextVisible(bool bVisible)
		{
			base.GetText(1).SetUIActive(bVisible);
		}

		// Token: 0x06040948 RID: 264520 RVA: 0x0108D989 File Offset: 0x0108BB89
		private void SetExpText(int expCount)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "RoadBookLevelUpTipsExp_Text", new <>z__ReadOnlySingleElementList<object>(expCount));
		}

		// Token: 0x06040949 RID: 264521 RVA: 0x0108D9AC File Offset: 0x0108BBAC
		private void SetExpMaxText()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "RoadBookLevelCanUp_Text", Array.Empty<object>());
			this.SetExpTextVisible(true);
		}

		// Token: 0x0402424A RID: 148042
		private ETipsType TipsType;

		// Token: 0x0402424B RID: 148043
		private int PreLevel;

		// Token: 0x0402424C RID: 148044
		private int CurLevel;

		// Token: 0x0402424D RID: 148045
		private int PreExpTotalCount;

		// Token: 0x0402424E RID: 148046
		private int CurExpTotalCount;

		// Token: 0x0402424F RID: 148047
		private int PreLevelTargetExp;

		// Token: 0x04024250 RID: 148048
		private int PreCurExpCount;

		// Token: 0x04024251 RID: 148049
		private int CurExpCount;

		// Token: 0x04024252 RID: 148050
		private int CurTargetExp;

		// Token: 0x04024253 RID: 148051
		private GenericLayout<LevelItemGrid, int> LevelLayout;

		// Token: 0x04024254 RID: 148052
		private float LevelItemWidth;

		// Token: 0x04024255 RID: 148053
		[Nullable(2)]
		private LguiFloatTween OffsetTweenX;

		// Token: 0x04024256 RID: 148054
		private float LevelItemSpacing;

		// Token: 0x04024257 RID: 148055
		[Nullable(2)]
		protected TimerHandle TickHandle;

		// Token: 0x04024258 RID: 148056
		protected int BarAnimTime = ConfigCommonParamById.GetIntConfig("TravelExpBarDisplayTime").Value;

		// Token: 0x04024259 RID: 148057
		protected bool RunBarAnim;

		// Token: 0x0402425A RID: 148058
		protected float RunBarAnimTime;

		// Token: 0x0402425B RID: 148059
		protected float StartValue;

		// Token: 0x0402425C RID: 148060
		protected float TargetValue;

		// Token: 0x0402425D RID: 148061
		protected float EndValue;

		// Token: 0x0402425E RID: 148062
		protected CustomPromise BarAnimPromise = new CustomPromise();
	}
}
