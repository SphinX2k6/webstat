using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ED9 RID: 24281
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalRewardButtonItem : UiPanelBase
	{
		// Token: 0x0603D02A RID: 249898 RVA: 0x00F7F030 File Offset: 0x00F7D230
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D02B RID: 249899 RVA: 0x00F7F0DC File Offset: 0x00F7D2DC
		protected override UniTask OnBeforeStartAsync()
		{
			CiacconaGalRewardButtonItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaGalRewardButtonItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D02C RID: 249900 RVA: 0x00F7F11F File Offset: 0x00F7D31F
		protected override void OnStart()
		{
			if (this.NeedRemainTime)
			{
				this.RefreshTimeStr();
				this.TimerHandle = TimerSystem.Instance.Forever(new TTimerAction(this.OnTick), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
			}
		}

		// Token: 0x0603D02D RID: 249901 RVA: 0x00F7F15E File Offset: 0x00F7D35E
		protected override void OnBeforeDestroy()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
			}
		}

		// Token: 0x0603D02E RID: 249902 RVA: 0x00F7F179 File Offset: 0x00F7D379
		public void SetNeedRemainTime(bool need)
		{
			this.NeedRemainTime = need;
		}

		// Token: 0x0603D02F RID: 249903 RVA: 0x00F7F182 File Offset: 0x00F7D382
		public void SetOnClick(Action callback)
		{
			this.OnClick = callback;
		}

		// Token: 0x0603D030 RID: 249904 RVA: 0x00F7F18B File Offset: 0x00F7D38B
		public void BindRedDot(ERedDotName redDotName, int uId = 0)
		{
			this.Button.BindRedDot(redDotName, uId);
		}

		// Token: 0x0603D031 RID: 249905 RVA: 0x00F7F19A File Offset: 0x00F7D39A
		public void UnBindRedDot()
		{
			this.Button.UnBindRedDot();
		}

		// Token: 0x0603D032 RID: 249906 RVA: 0x00F7F1A7 File Offset: 0x00F7D3A7
		public void SetRedDotVisible(bool visible)
		{
			this.Button.SetRedDotVisible(visible);
		}

		// Token: 0x0603D033 RID: 249907 RVA: 0x00F7F1B5 File Offset: 0x00F7D3B5
		public void SetProgressText(string text)
		{
			base.GetText(2).SetText(text, true);
		}

		// Token: 0x0603D034 RID: 249908 RVA: 0x00F7F1C5 File Offset: 0x00F7D3C5
		public void SetTitle(string textId)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, Array.Empty<object>());
		}

		// Token: 0x0603D035 RID: 249909 RVA: 0x00F7F1E0 File Offset: 0x00F7D3E0
		private void RefreshTimeStr()
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Xkjsx_Rewards_Timeless", null);
			string rewardRemainTimeStr = ModelBase<CiacconaGalModel>.Instance.ActivityData.RewardRemainTimeStr;
			string newText = localTextNew + " " + rewardRemainTimeStr;
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.SetText(newText, true);
		}

		// Token: 0x0603D036 RID: 249910 RVA: 0x00F7F228 File Offset: 0x00F7D428
		private void OnTick(float _)
		{
			this.RefreshTimeStr();
			CiacconaGalActivityData activityData = ModelBase<CiacconaGalModel>.Instance.ActivityData;
			bool? flag = (activityData != null) ? new bool?(activityData.IsInRewardTime) : null;
			if (flag == null || !flag.Value)
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
				this.TimerHandle = null;
				this.SetActive(false);
			}
		}

		// Token: 0x0603D037 RID: 249911 RVA: 0x00F7F290 File Offset: 0x00F7D490
		private void OnClickInternal()
		{
			this.OnClick();
		}

		// Token: 0x040223D1 RID: 140241
		[Nullable(2)]
		private ButtonSpriteItem Button;

		// Token: 0x040223D2 RID: 140242
		private bool NeedRemainTime;

		// Token: 0x040223D3 RID: 140243
		[Nullable(2)]
		private TimerHandle TimerHandle;

		// Token: 0x040223D4 RID: 140244
		private Action OnClick = delegate()
		{
		};

		// Token: 0x0200BED6 RID: 48854
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403ABC5 RID: 240581
			public const int ItemBtn = 0;

			// Token: 0x0403ABC6 RID: 240582
			public const int TextName = 1;

			// Token: 0x0403ABC7 RID: 240583
			public const int TextNum = 2;

			// Token: 0x0403ABC8 RID: 240584
			public const int TextTime = 3;
		}
	}
}
