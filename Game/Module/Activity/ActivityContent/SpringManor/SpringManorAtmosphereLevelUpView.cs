using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x0200635A RID: 25434
	[NullableContext(1)]
	[Nullable(0)]
	public class SpringManorAtmosphereLevelUpView : UiViewBase
	{
		// Token: 0x0603FDAA RID: 261546 RVA: 0x010613E9 File Offset: 0x0105F5E9
		public SpringManorAtmosphereLevelUpView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FDAB RID: 261547 RVA: 0x01061400 File Offset: 0x0105F600
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603FDAC RID: 261548 RVA: 0x0106148C File Offset: 0x0105F68C
		protected override void OnStart()
		{
			SpringManorAtmosphereLevelUpViewData springManorAtmosphereLevelUpViewData = this.OpenParam as SpringManorAtmosphereLevelUpViewData;
			this.PreLevel = springManorAtmosphereLevelUpViewData.OldLevel;
			this.CurLevel = springManorAtmosphereLevelUpViewData.NewLevel;
			this.PreAtmosphere = springManorAtmosphereLevelUpViewData.OldAtmosphere;
			this.CurAtmosphere = springManorAtmosphereLevelUpViewData.NewAtmosphere;
			this.CurMaxAtmosphere = springManorAtmosphereLevelUpViewData.MaxAtmosphere;
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			AtmosphereLevel? levelConfigById = instance.GetLevelConfigById(this.PreLevel);
			this.PreNeed = levelConfigById.Value.AtmosphereNeed;
			this.PreNext = levelConfigById.Value.AtmosphereNext;
			AtmosphereLevel? levelConfigById2 = instance.GetLevelConfigById(this.CurLevel);
			this.CurNeed = levelConfigById2.Value.AtmosphereNeed;
			this.CurNext = levelConfigById2.Value.AtmosphereNext;
			if (this.CurLevel > this.PreLevel)
			{
				this.TipsType = ETipsType.LevelUp;
			}
			else
			{
				this.TipsType = ETipsType.ExpAdd;
			}
			UUIText text = base.GetText(0);
			(((text != null) ? text.GetOwner() : null) as AUIBaseActor).OnSequencePlayEvent.Bind(new Action<string, string>(this.OnSequencePlayEvent));
			UUIText text2 = base.GetText(2);
			(((text2 != null) ? text2.GetOwner() : null) as AUIBaseActor).OnSequencePlayEvent.Bind(new Action<string, string>(this.OnSequencePlayEvent));
		}

		// Token: 0x0603FDAD RID: 261549 RVA: 0x010615D0 File Offset: 0x0105F7D0
		private void OnSequencePlayEvent(string seqName, string eventName)
		{
			if (!(eventName == "Max"))
			{
				if (eventName == "LevelChange")
				{
					UUIText text = base.GetText(0);
					if (text == null)
					{
						return;
					}
					text.SetText(this.CurLevel.ToString(), true);
				}
				return;
			}
			UUIText text2 = base.GetText(2);
			if (text2 == null)
			{
				return;
			}
			text2.ShowTextNew("Spring26_Atmosphere_Max");
		}

		// Token: 0x0603FDAE RID: 261550 RVA: 0x0106162B File Offset: 0x0105F82B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x0603FDAF RID: 261551 RVA: 0x01061649 File Offset: 0x0105F849
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x0603FDB0 RID: 261552 RVA: 0x01061667 File Offset: 0x0105F867
		private void OnActivitySequenceEmitEvent(string param)
		{
			if (param == "TipsChange")
			{
				this.SetExpMaxText();
			}
		}

		// Token: 0x0603FDB1 RID: 261553 RVA: 0x0106167C File Offset: 0x0105F87C
		protected override void OnBeforeShow()
		{
			this.TickHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.Refresh), 20f, 1f, null, null, true);
			this.RefreshBar(0f, 1f);
			this.SetLevelText(this.PreLevel);
			this.SetExpText(this.CurAtmosphere, this.CurMaxAtmosphere);
			ETipsType tipsType = this.TipsType;
			if (tipsType != ETipsType.ExpAdd)
			{
				if (tipsType == ETipsType.LevelUp)
				{
					this.RefreshBar((float)(this.PreAtmosphere - this.PreNeed), (float)this.PreNext);
					return;
				}
			}
			else
			{
				this.RefreshBar((float)(this.PreAtmosphere - this.PreNeed), (float)this.PreNext);
			}
		}

		// Token: 0x0603FDB2 RID: 261554 RVA: 0x01061728 File Offset: 0x0105F928
		protected override void OnAfterShow()
		{
			ETipsType tipsType = this.TipsType;
			if (tipsType != ETipsType.ExpAdd)
			{
				if (tipsType == ETipsType.LevelUp)
				{
					this.RunLevelUp();
					return;
				}
			}
			else
			{
				this.RunExpAdd();
			}
		}

		// Token: 0x0603FDB3 RID: 261555 RVA: 0x01061752 File Offset: 0x0105F952
		protected override void OnBeforeDestroy()
		{
			this.RemoveTick();
		}

		// Token: 0x0603FDB4 RID: 261556 RVA: 0x0106175C File Offset: 0x0105F95C
		private UniTask RunExpAdd()
		{
			SpringManorAtmosphereLevelUpView.<RunExpAdd>d__21 <RunExpAdd>d__;
			<RunExpAdd>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunExpAdd>d__.<>4__this = this;
			<RunExpAdd>d__.<>1__state = -1;
			<RunExpAdd>d__.<>t__builder.Start<SpringManorAtmosphereLevelUpView.<RunExpAdd>d__21>(ref <RunExpAdd>d__);
			return <RunExpAdd>d__.<>t__builder.Task;
		}

		// Token: 0x0603FDB5 RID: 261557 RVA: 0x010617A0 File Offset: 0x0105F9A0
		private UniTask RunLevelUp()
		{
			SpringManorAtmosphereLevelUpView.<RunLevelUp>d__22 <RunLevelUp>d__;
			<RunLevelUp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunLevelUp>d__.<>4__this = this;
			<RunLevelUp>d__.<>1__state = -1;
			<RunLevelUp>d__.<>t__builder.Start<SpringManorAtmosphereLevelUpView.<RunLevelUp>d__22>(ref <RunLevelUp>d__);
			return <RunLevelUp>d__.<>t__builder.Task;
		}

		// Token: 0x0603FDB6 RID: 261558 RVA: 0x010617E4 File Offset: 0x0105F9E4
		protected void Refresh(float delta)
		{
			if (!this.RunBarAnim)
			{
				return;
			}
			this.RunBarAnimTime += delta;
			float current = Singleton<MathUtils>.Instance.Lerp((float)this.StartValue, (float)this.TargetValue, this.RunBarAnimTime / 750f);
			this.RefreshBar(current, (float)this.EndValue);
			if (this.RunBarAnimTime >= 750f)
			{
				this.EndBarAnim();
			}
		}

		// Token: 0x0603FDB7 RID: 261559 RVA: 0x01061850 File Offset: 0x0105FA50
		private UniTask StartBarAnim(int current, int target, int end)
		{
			SpringManorAtmosphereLevelUpView.<StartBarAnim>d__31 <StartBarAnim>d__;
			<StartBarAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartBarAnim>d__.<>4__this = this;
			<StartBarAnim>d__.current = current;
			<StartBarAnim>d__.target = target;
			<StartBarAnim>d__.end = end;
			<StartBarAnim>d__.<>1__state = -1;
			<StartBarAnim>d__.<>t__builder.Start<SpringManorAtmosphereLevelUpView.<StartBarAnim>d__31>(ref <StartBarAnim>d__);
			return <StartBarAnim>d__.<>t__builder.Task;
		}

		// Token: 0x0603FDB8 RID: 261560 RVA: 0x010618AC File Offset: 0x0105FAAC
		private void EndBarAnim()
		{
			this.RunBarAnim = false;
			this.BarAnimPromise.SetResult(default(UniTaskVoid));
		}

		// Token: 0x0603FDB9 RID: 261561 RVA: 0x010618D4 File Offset: 0x0105FAD4
		private void RemoveTick()
		{
			if (this.TickHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TickHandle);
				this.TickHandle = null;
			}
		}

		// Token: 0x0603FDBA RID: 261562 RVA: 0x010618F8 File Offset: 0x0105FAF8
		private void RefreshBar(float current, float target)
		{
			float fillAmount = Singleton<MathUtils>.Instance.Clamp(current / target, 0f, 1f);
			base.GetSprite(1).SetFillAmount(fillAmount);
		}

		// Token: 0x0603FDBB RID: 261563 RVA: 0x0106192A File Offset: 0x0105FB2A
		private void SetExpTextVisible(bool bVisible)
		{
			base.GetText(2).SetUIActive(bVisible);
		}

		// Token: 0x0603FDBC RID: 261564 RVA: 0x0106193C File Offset: 0x0105FB3C
		private void SetExpText(int current, int currentMax)
		{
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(current);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(currentMax);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0603FDBD RID: 261565 RVA: 0x01061987 File Offset: 0x0105FB87
		private void SetExpMaxText()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "MapTravelLevelCanUp_Text", Array.Empty<object>());
			this.SetExpTextVisible(true);
		}

		// Token: 0x0603FDBE RID: 261566 RVA: 0x010619AB File Offset: 0x0105FBAB
		private void SetLevelText(int level)
		{
			base.GetText(0).SetText(level.ToString(), true);
		}

		// Token: 0x04023E43 RID: 147011
		private const int BAR_ANIM_TIME = 750;

		// Token: 0x04023E44 RID: 147012
		private ETipsType TipsType;

		// Token: 0x04023E45 RID: 147013
		private int PreLevel;

		// Token: 0x04023E46 RID: 147014
		private int PreAtmosphere;

		// Token: 0x04023E47 RID: 147015
		private int CurLevel;

		// Token: 0x04023E48 RID: 147016
		private int CurAtmosphere;

		// Token: 0x04023E49 RID: 147017
		private int CurMaxAtmosphere;

		// Token: 0x04023E4A RID: 147018
		private int PreNeed;

		// Token: 0x04023E4B RID: 147019
		private int PreNext;

		// Token: 0x04023E4C RID: 147020
		private int CurNeed;

		// Token: 0x04023E4D RID: 147021
		private int CurNext;

		// Token: 0x04023E4E RID: 147022
		[Nullable(2)]
		protected TimerHandle TickHandle;

		// Token: 0x04023E4F RID: 147023
		protected bool RunBarAnim;

		// Token: 0x04023E50 RID: 147024
		protected float RunBarAnimTime;

		// Token: 0x04023E51 RID: 147025
		protected int StartValue;

		// Token: 0x04023E52 RID: 147026
		protected int TargetValue;

		// Token: 0x04023E53 RID: 147027
		protected int EndValue;

		// Token: 0x04023E54 RID: 147028
		protected CustomPromise<UniTaskVoid> BarAnimPromise = new CustomPromise<UniTaskVoid>();
	}
}
