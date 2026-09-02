using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EDA RID: 24282
	public class CiacconaTitleInspirationItem : UiPanelBase
	{
		// Token: 0x0603D039 RID: 249913 RVA: 0x00F7F2CA File Offset: 0x00F7D4CA
		[NullableContext(1)]
		public CiacconaTitleInspirationItem(CiacconaGalActivityData activityData)
		{
			this.ActivityData = activityData;
		}

		// Token: 0x0603D03A RID: 249914 RVA: 0x00F7F2DC File Offset: 0x00F7D4DC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D03B RID: 249915 RVA: 0x00F7F3E8 File Offset: 0x00F7D5E8
		protected override void OnStart()
		{
			this.Refresh();
			this.TimerHandle = TimerSystem.Instance.Forever(new TTimerAction(this.Tick), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
			Singleton<EventSystem>.Instance.Add(EEventName.OnCiacconaInspirationDataUpdate, new Action(this.OnCiacconaInspirationDataUpdate));
		}

		// Token: 0x0603D03C RID: 249916 RVA: 0x00F7F446 File Offset: 0x00F7D646
		protected override void OnBeforeDestroy()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCiacconaInspirationDataUpdate, new Action(this.OnCiacconaInspirationDataUpdate));
		}

		// Token: 0x0603D03D RID: 249917 RVA: 0x00F7F484 File Offset: 0x00F7D684
		private void Refresh()
		{
			int inspirationCount = this.ActivityData.InspirationCount;
			int maxInspirationCount = this.ActivityData.MaxInspirationCount;
			string value = (inspirationCount == 0) ? "#c25757" : "#ffffff";
			UUIText text = base.GetText(0);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 3);
			defaultInterpolatedStringHandler.AppendLiteral("<color=");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral(">");
			defaultInterpolatedStringHandler.AppendFormatted<int>(inspirationCount);
			defaultInterpolatedStringHandler.AppendLiteral("</color>/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(maxInspirationCount);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			string remainTimeToNextRefreshStr = this.ActivityData.RemainTimeToNextRefreshStr;
			if (!StringUtils.IsEmpty(remainTimeToNextRefreshStr))
			{
				base.GetText(1).SetText(remainTimeToNextRefreshStr, true);
			}
			base.GetSprite(2).SetUIActive(inspirationCount < maxInspirationCount);
			base.GetItem(3).SetUIActive(inspirationCount < maxInspirationCount);
		}

		// Token: 0x0603D03E RID: 249918 RVA: 0x00F7F555 File Offset: 0x00F7D755
		private void Tick(float _)
		{
			this.Refresh();
		}

		// Token: 0x0603D03F RID: 249919 RVA: 0x00F7F55D File Offset: 0x00F7D75D
		private void OnCiacconaInspirationDataUpdate()
		{
			this.Refresh();
		}

		// Token: 0x0603D040 RID: 249920 RVA: 0x00F7F565 File Offset: 0x00F7D765
		private void OnClick()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(250);
		}

		// Token: 0x040223D5 RID: 140245
		[Nullable(1)]
		private CiacconaGalActivityData ActivityData;

		// Token: 0x040223D6 RID: 140246
		[Nullable(2)]
		private TimerHandle TimerHandle;

		// Token: 0x0200BED9 RID: 48857
		private class EInspirationComponentDefine
		{
			// Token: 0x0403ABCF RID: 240591
			public const int TextNum = 0;

			// Token: 0x0403ABD0 RID: 240592
			public const int TextTime = 1;

			// Token: 0x0403ABD1 RID: 240593
			public const int SpriteSplitLine = 2;

			// Token: 0x0403ABD2 RID: 240594
			public const int ItemTime = 3;

			// Token: 0x0403ABD3 RID: 240595
			public const int BtnSelf = 4;
		}
	}
}
