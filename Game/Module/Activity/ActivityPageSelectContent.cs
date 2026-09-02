using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity
{
	// Token: 0x020061D4 RID: 25044
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ActivityPageSelectContent : GridProxyAbstract<ActivityBaseData>
	{
		// Token: 0x0603F315 RID: 258837 RVA: 0x01039044 File Offset: 0x01037244
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickItem));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F316 RID: 258838 RVA: 0x0103925C File Offset: 0x0103745C
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
			this.ActivityBubbleComponent = new ActivityBubbleComponent(base.GetItem(10), base.GetSprite(11), base.GetText(12), delegate(string path, UUISprite uiSprite, bool setSize)
			{
				this.SetSpriteByPath(path, uiSprite, setSize, null, null);
			});
		}

		// Token: 0x0603F317 RID: 258839 RVA: 0x010392B5 File Offset: 0x010374B5
		protected void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RefreshActivityTab, new Action<int>(this.OnRefreshActivityTab));
		}

		// Token: 0x0603F318 RID: 258840 RVA: 0x010392D3 File Offset: 0x010374D3
		protected void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshActivityTab, new Action<int>(this.OnRefreshActivityTab));
		}

		// Token: 0x0603F319 RID: 258841 RVA: 0x010392F1 File Offset: 0x010374F1
		protected override void OnBeforeShow()
		{
			this.AddEventListener();
		}

		// Token: 0x0603F31A RID: 258842 RVA: 0x010392F9 File Offset: 0x010374F9
		protected override void OnBeforeHide()
		{
			this.RemoveEventListener();
		}

		// Token: 0x0603F31B RID: 258843 RVA: 0x01039301 File Offset: 0x01037501
		private void AddTimer()
		{
			ControllerBase<ActivityController>.Instance.RegisterRefreshTimerDelegate(new Action<float>(this.OnTimerRefresh));
			this.IsTimerEnable = true;
		}

		// Token: 0x0603F31C RID: 258844 RVA: 0x01039320 File Offset: 0x01037520
		private void RemoveTimer()
		{
			ControllerBase<ActivityController>.Instance.UnregisterRefreshTimerDelegate(new Action<float>(this.OnTimerRefresh));
			this.IsTimerEnable = false;
		}

		// Token: 0x0603F31D RID: 258845 RVA: 0x0103933F File Offset: 0x0103753F
		private bool TryAddTimer()
		{
			if (this.IsTimerEnable)
			{
				return false;
			}
			this.AddTimer();
			return true;
		}

		// Token: 0x0603F31E RID: 258846 RVA: 0x01039352 File Offset: 0x01037552
		private bool TryRemoveTimer()
		{
			if (!this.IsTimerEnable)
			{
				return false;
			}
			this.RemoveTimer();
			return true;
		}

		// Token: 0x0603F31F RID: 258847 RVA: 0x01039365 File Offset: 0x01037565
		private void OnTimerRefresh(float delta)
		{
			this.ActivityBubbleComponent.RefreshBubble(this.Data);
		}

		// Token: 0x0603F320 RID: 258848 RVA: 0x01039379 File Offset: 0x01037579
		protected override void OnBeforeDestroy()
		{
			this.UnBindRedDot();
			this.RemoveTimer();
		}

		// Token: 0x0603F321 RID: 258849 RVA: 0x01039388 File Offset: 0x01037588
		private void OnRefreshActivityTab(int activityId)
		{
			ActivityBaseData data = this.Data;
			bool flag;
			if (data == null)
			{
				flag = false;
			}
			else
			{
				int id = data.Id;
				flag = true;
			}
			if (flag && this.Data.Id == activityId)
			{
				this.RefreshName();
				this.RefreshTime();
				this.RefreshIcon();
				this.RefreshTagIcon();
				this.RefreshRecommendIcon();
				this.RefreshTypeIcon();
				this.RefreshBubbleAndCheckTimer();
			}
		}

		// Token: 0x0603F322 RID: 258850 RVA: 0x010393E4 File Offset: 0x010375E4
		private void RefreshToggleState(bool selectOn, bool bFireEvent = false)
		{
			EToggleState state = selectOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state, bFireEvent, false, false);
			if (!bFireEvent && selectOn)
			{
				this.UpdateBubbleClickStateAndRefresh();
			}
		}

		// Token: 0x0603F323 RID: 258851 RVA: 0x01039418 File Offset: 0x01037618
		private void OnClickItem(EToggleState toggleState)
		{
			Action<ActivityBaseData, bool> toggleClickInternal = this.ToggleClickInternal;
			if (toggleClickInternal != null)
			{
				toggleClickInternal(this.Data, toggleState == EToggleState.ETT_Checked);
			}
			if (toggleState == EToggleState.ETT_Checked)
			{
				this.UpdateBubbleClickStateAndRefresh();
			}
		}

		// Token: 0x0603F324 RID: 258852 RVA: 0x0103943F File Offset: 0x0103763F
		public void SetToggleState(bool bSelectOn, bool bFireEvent = true)
		{
			this.RefreshToggleState(bSelectOn, bFireEvent);
		}

		// Token: 0x0603F325 RID: 258853 RVA: 0x01039449 File Offset: 0x01037649
		public void BindToggleClick(Action<ActivityBaseData, bool> func)
		{
			this.ToggleClickInternal = func;
		}

		// Token: 0x0603F326 RID: 258854 RVA: 0x01039452 File Offset: 0x01037652
		public void BindCanToggleExecuteChange(Func<int, bool, bool> func)
		{
			this.CanToggleExecuteChangeInternal = func;
		}

		// Token: 0x0603F327 RID: 258855 RVA: 0x0103945C File Offset: 0x0103765C
		public unsafe override void Refresh(ActivityBaseData data, bool isSelected, int gridIndex)
		{
			try
			{
				if (this.Data != null)
				{
					this.UnBindRedDot();
				}
				this.Data = data;
				this.BindRedDot(data);
				this.RefreshToggleState(isSelected, false);
				this.RefreshName();
				this.RefreshTime();
				this.RefreshIcon();
				this.RefreshTagIcon();
				this.RefreshRecommendIcon();
				this.RefreshTypeIcon();
				this.RefreshBubbleAndCheckTimer();
			}
			catch (Exception ex)
			{
				ActivityModel instance = ModelBase<ActivityModel>.Instance;
				ActivityBaseData data2 = this.Data;
				int activityId = (data2 != null) ? data2.Id : 0;
				ActivityBaseData data3 = this.Data;
				bool flag;
				if (data3 == null)
				{
					flag = false;
				}
				else
				{
					ActivityType type = data3.Type;
					flag = true;
				}
				instance.OpenActivityErrorConfirmBox(activityId, (int)(flag ? this.Data.Type : ActivityType.Parkour));
				if (ex != null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Activity;
					ELogAuthor author = ELogAuthor.YYZ;
					string message = "[Activity] 活动页签状态异常";
					Exception error = ex;
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
					string item = "id";
					ActivityBaseData data4 = this.Data;
					ptr = new ValueTuple<string, object>(item, (data4 != null) ? data4.Id : 0);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
					instance2.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				else
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Activity;
					ELogAuthor author2 = ELogAuthor.YYZ;
					string message2 = "[Activity] 活动页签状态异常";
					string item2 = "id";
					ActivityBaseData data5 = this.Data;
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item2, (data5 != null) ? data5.Id : 0);
					instance3.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
		}

		// Token: 0x0603F328 RID: 258856 RVA: 0x010395C8 File Offset: 0x010377C8
		public override void Clear()
		{
			this.TryRemoveTimer();
		}

		// Token: 0x0603F329 RID: 258857 RVA: 0x010395D1 File Offset: 0x010377D1
		private bool CanToggleExecuteChange()
		{
			Func<int, bool, bool> canToggleExecuteChangeInternal = this.CanToggleExecuteChangeInternal;
			return canToggleExecuteChangeInternal == null || canToggleExecuteChangeInternal(this.Data.Id, base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_Checked);
		}

		// Token: 0x0603F32A RID: 258858 RVA: 0x01039600 File Offset: 0x01037800
		private void RefreshName()
		{
			Regex regex = new Regex("<.*?>");
			string title = this.Data.GetTitle();
			base.GetText(1).SetText(regex.Replace(title, ""), true);
		}

		// Token: 0x0603F32B RID: 258859 RVA: 0x01039640 File Offset: 0x01037840
		private void RefreshTime()
		{
			bool forceHideActivityTimeTextFlag = ModelBase<ActivityModel>.Instance.GetForceHideActivityTimeTextFlag();
			bool flag = false;
			if (forceHideActivityTimeTextFlag || !flag)
			{
				base.GetText(3).SetUIActive(false);
				base.GetItem(4).SetUIActive(false);
				return;
			}
			DateTime dataFromTimeStamp = Singleton<TimeUtil>.Instance.GetDataFromTimeStamp((double)this.Data.BeginOpenTime);
			DateTime dataFromTimeStamp2 = Singleton<TimeUtil>.Instance.GetDataFromTimeStamp((double)this.Data.EndOpenTime);
			string newText = StringUtils.Format("{0}/{1}-{2}/{3}", new string[]
			{
				dataFromTimeStamp.Month.ToString(),
				dataFromTimeStamp.Day.ToString(),
				dataFromTimeStamp2.Month.ToString(),
				dataFromTimeStamp2.Day.ToString()
			});
			base.GetText(3).SetText(newText, true);
			base.GetText(3).SetUIActive(true);
			base.GetItem(4).SetUIActive(false);
		}

		// Token: 0x0603F32C RID: 258860 RVA: 0x0103972C File Offset: 0x0103792C
		private void RefreshIcon()
		{
			string[] array = this.Data.LocalConfig.Value.TabTexture();
			UUITexture texture = base.GetTexture(5);
			texture.SetUIActive(false);
			if (array == null || array.Length == 0)
			{
				return;
			}
			int num = 0;
			if (array.Length >= 2)
			{
				num = ((ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() > EPlayerGender.Female) ? 1 : 0);
			}
			base.SetTextureByPath(array[num], texture, null, delegate(bool _)
			{
				texture.SetUIActive(true);
			});
			bool finishShowState = this.Data.FinishShowState;
			base.GetItem(6).SetUIActive(finishShowState);
		}

		// Token: 0x0603F32D RID: 258861 RVA: 0x010397D0 File Offset: 0x010379D0
		private void RefreshTagIcon()
		{
			string tabTagIcon = this.Data.LocalConfig.Value.TabTagIcon;
			UUISprite tagIcon = base.GetSprite(7);
			bool flag = !string.IsNullOrEmpty(tabTagIcon);
			tagIcon.SetUIActive(flag);
			if (flag)
			{
				this.SetSpriteByPath(tabTagIcon, tagIcon, true, null, delegate(bool _)
				{
					(tagIcon.GetOwner().GetComponentByClass(UUIExtendToggleSpriteTransition.StaticClass()) as UUIExtendToggleSpriteTransition).SetAllStateSprite(tagIcon.GetSprite());
				});
			}
		}

		// Token: 0x0603F32E RID: 258862 RVA: 0x01039848 File Offset: 0x01037A48
		private void RefreshRecommendIcon()
		{
			bool finishShowState = this.Data.FinishShowState;
			bool flag = this.Data.TimeType == EActivityTimeType.TimeLimit;
			base.GetSprite(9).SetUIActive(this.Data.LocalConfig.Value.IsTabEffectNotice && !finishShowState && flag);
		}

		// Token: 0x0603F32F RID: 258863 RVA: 0x010398A0 File Offset: 0x01037AA0
		private void RefreshTypeIcon()
		{
			int showTabTypeId = this.Data.LocalConfig.Value.ShowTabTypeId;
			ActivityTitleTags? activityTitleTags = ConfigBase<ActivityConfig>.Instance.GetActivityTitleTags(showTabTypeId);
			if (activityTitleTags == null)
			{
				return;
			}
			string tagIcon = activityTitleTags.Value.TagIcon;
			UUISprite sprite = base.GetSprite(8);
			bool flag = !string.IsNullOrEmpty(tagIcon);
			sprite.SetUIActive(flag);
			if (flag)
			{
				this.SetSpriteByPath(tagIcon, sprite, true, null, null);
			}
		}

		// Token: 0x0603F330 RID: 258864 RVA: 0x01039921 File Offset: 0x01037B21
		private void BindRedDot(ActivityBaseData data)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.CommonActivityPage, base.GetItem(2), null, data.Id);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, data.Id);
			this.IsBindRed = true;
		}

		// Token: 0x0603F331 RID: 258865 RVA: 0x0103995A File Offset: 0x01037B5A
		private void UnBindRedDot()
		{
			if (this.IsBindRed)
			{
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.CommonActivityPage, base.GetItem(2), this.Data.Id);
				this.IsBindRed = false;
			}
		}

		// Token: 0x0603F332 RID: 258866 RVA: 0x01039989 File Offset: 0x01037B89
		public void RefreshBubbleAndCheckTimer()
		{
			if (this.ActivityBubbleComponent.RefreshBubble(this.Data))
			{
				this.TryAddTimer();
				return;
			}
			this.TryRemoveTimer();
		}

		// Token: 0x0603F333 RID: 258867 RVA: 0x010399AD File Offset: 0x01037BAD
		private void UpdateBubbleClickStateAndRefresh()
		{
			if (this.ActivityBubbleComponent.CheckToUpdateBubbleClickState())
			{
				this.RefreshBubbleAndCheckTimer();
			}
		}

		// Token: 0x0603F334 RID: 258868 RVA: 0x010399C2 File Offset: 0x01037BC2
		public override object GetKey(ActivityBaseData data, int displayIndex)
		{
			return data.Id;
		}

		// Token: 0x040237DF RID: 145375
		[Nullable(2)]
		private ActivityBaseData Data;

		// Token: 0x040237E0 RID: 145376
		[Nullable(2)]
		private Func<int, bool, bool> CanToggleExecuteChangeInternal;

		// Token: 0x040237E1 RID: 145377
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<ActivityBaseData, bool> ToggleClickInternal;

		// Token: 0x040237E2 RID: 145378
		private bool IsBindRed;

		// Token: 0x040237E3 RID: 145379
		[Nullable(2)]
		private ActivityBubbleComponent ActivityBubbleComponent;

		// Token: 0x040237E4 RID: 145380
		private bool IsTimerEnable;

		// Token: 0x0200C313 RID: 49939
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403C214 RID: 246292
			public const int Toggle = 0;

			// Token: 0x0403C215 RID: 246293
			public const int NameText = 1;

			// Token: 0x0403C216 RID: 246294
			public const int RedDot = 2;

			// Token: 0x0403C217 RID: 246295
			public const int TimeText = 3;

			// Token: 0x0403C218 RID: 246296
			public const int SpriteTime = 4;

			// Token: 0x0403C219 RID: 246297
			public const int TextureIcon = 5;

			// Token: 0x0403C21A RID: 246298
			public const int PanelFinish = 6;

			// Token: 0x0403C21B RID: 246299
			public const int TagIcon = 7;

			// Token: 0x0403C21C RID: 246300
			public const int SpriteTypeIcon = 8;

			// Token: 0x0403C21D RID: 246301
			public const int SpriteRecommend = 9;

			// Token: 0x0403C21E RID: 246302
			public const int ItemBubble = 10;

			// Token: 0x0403C21F RID: 246303
			public const int SpriteBubble = 11;

			// Token: 0x0403C220 RID: 246304
			public const int TxtRemainTime = 12;
		}
	}
}
