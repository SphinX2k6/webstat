using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005705 RID: 22277
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleAreaProgressTips : UiTickViewBase
	{
		// Token: 0x06038B10 RID: 232208 RVA: 0x00E5B012 File Offset: 0x00E59212
		public MoraleAreaProgressTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038B11 RID: 232209 RVA: 0x00E5B01C File Offset: 0x00E5921C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(4, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIText))
			};
		}

		// Token: 0x06038B12 RID: 232210 RVA: 0x00E5B0E4 File Offset: 0x00E592E4
		private void InitDataParam()
		{
		}

		// Token: 0x06038B13 RID: 232211 RVA: 0x00E5B0E8 File Offset: 0x00E592E8
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleAreaProgressTips.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleAreaProgressTips.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038B14 RID: 232212 RVA: 0x00E5B12B File Offset: 0x00E5932B
		protected override void OnStart()
		{
			this.UpdateData();
		}

		// Token: 0x06038B15 RID: 232213 RVA: 0x00E5B133 File Offset: 0x00E59333
		protected override void OnAfterShow()
		{
			this.PlayAllProgress().Forget();
		}

		// Token: 0x06038B16 RID: 232214 RVA: 0x00E5B140 File Offset: 0x00E59340
		protected override void OnBeforeDestroy()
		{
			this.IsPlayingGridProgress = false;
			this.IsPlayingNewProgress = false;
			CustomPromise newProgressPromise = this.NewProgressPromise;
			if (newProgressPromise != null)
			{
				newProgressPromise.SetResult();
			}
			CustomPromise gridProgressPromise = this.GridProgressPromise;
			if (gridProgressPromise == null)
			{
				return;
			}
			gridProgressPromise.SetResult();
		}

		// Token: 0x06038B17 RID: 232215 RVA: 0x00E5B174 File Offset: 0x00E59374
		public void UpdateData()
		{
			this.UpdateProgressDesc();
			MoraleAreaProgressTips.Params @params = this.OpenParam as MoraleAreaProgressTips.Params;
			IReadOnlyList<MoraleAreaProgressData> readOnlyList = (@params != null) ? @params.InfoList : null;
			IReadOnlyList<MoraleAreaProgressData> data = readOnlyList ?? Array.Empty<MoraleAreaProgressData>();
			GenericLayout<MoraleAreaProgressItem, MoraleAreaProgressData> percentLayout = this.PercentLayout;
			if (percentLayout != null)
			{
				percentLayout.RefreshByData(data, null, false);
			}
			GenericLayout<MoraleAreaProgressPointItem, MoraleAreaProgressData> pointLayout = this.PointLayout;
			if (pointLayout != null)
			{
				pointLayout.RefreshByData(data, null, false);
			}
			this.UpdateNewProgress(0f);
			this.UpdateGridProgress(0f);
		}

		// Token: 0x06038B18 RID: 232216 RVA: 0x00E5B1E8 File Offset: 0x00E593E8
		public void UpdateProgressText(float score)
		{
			UUIText text = base.GetText(6);
			float totalValue = this.GetTotalValue();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>((int)score);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<float>(totalValue);
			string newText = defaultInterpolatedStringHandler.ToStringAndClear();
			if (text == null)
			{
				return;
			}
			text.SetText(newText, true);
		}

		// Token: 0x06038B19 RID: 232217 RVA: 0x00E5B240 File Offset: 0x00E59440
		public float GetTotalValue()
		{
			MoraleAreaProgressTips.Params @params = this.OpenParam as MoraleAreaProgressTips.Params;
			IReadOnlyList<MoraleAreaProgressData> readOnlyList = (@params != null) ? @params.InfoList : null;
			IReadOnlyList<MoraleAreaProgressData> readOnlyList2 = readOnlyList ?? Array.Empty<MoraleAreaProgressData>();
			if (readOnlyList2.Count == 0)
			{
				return 1f;
			}
			IReadOnlyList<MoraleAreaProgressData> readOnlyList3 = readOnlyList2;
			return (float)readOnlyList3[readOnlyList3.Count - 1].TargetScore;
		}

		// Token: 0x06038B1A RID: 232218 RVA: 0x00E5B292 File Offset: 0x00E59492
		public float GetStartValue()
		{
			MoraleAreaProgressTips.Params @params = this.OpenParam as MoraleAreaProgressTips.Params;
			return (float)((@params != null) ? @params.StartNum : 0);
		}

		// Token: 0x06038B1B RID: 232219 RVA: 0x00E5B2AC File Offset: 0x00E594AC
		public float GetAddValue()
		{
			MoraleAreaProgressTips.Params @params = this.OpenParam as MoraleAreaProgressTips.Params;
			return (float)((@params != null) ? @params.AddNum : 0);
		}

		// Token: 0x06038B1C RID: 232220 RVA: 0x00E5B2C6 File Offset: 0x00E594C6
		public float GetTargetValue()
		{
			return this.GetStartValue() + this.GetAddValue();
		}

		// Token: 0x06038B1D RID: 232221 RVA: 0x00E5B2D8 File Offset: 0x00E594D8
		public void UpdateProgressDesc()
		{
			float addValue = this.GetAddValue();
			UUIText text = base.GetText(7);
			MoraleAreaProgressTips.Params @params = this.OpenParam as MoraleAreaProgressTips.Params;
			string textStringId = ((@params != null) ? @params.SourceDescKey : null) ?? "";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, new <>z__ReadOnlySingleElementList<object>(addValue));
		}

		// Token: 0x06038B1E RID: 232222 RVA: 0x00E5B32C File Offset: 0x00E5952C
		private MoraleAreaProgressItem CreatePercentItem()
		{
			return new MoraleAreaProgressItem();
		}

		// Token: 0x06038B1F RID: 232223 RVA: 0x00E5B333 File Offset: 0x00E59533
		private MoraleAreaProgressPointItem CreatePercentPointItem()
		{
			return new MoraleAreaProgressPointItem();
		}

		// Token: 0x06038B20 RID: 232224 RVA: 0x00E5B33C File Offset: 0x00E5953C
		public void UpdateNewProgress(float percent)
		{
			float num = Math.Max(0f, Math.Min(percent, 1f));
			UUISliderComponent slider = base.GetSlider(3);
			float startValue = this.GetStartValue();
			float totalValue = this.GetTotalValue();
			float addValue = this.GetAddValue();
			float num2 = addValue * num / totalValue;
			float inValue = startValue / totalValue + num2;
			if (slider != null)
			{
				slider.SetValue(inValue, true);
			}
			if (this.GridProgressTime <= 0f)
			{
				float score = startValue + addValue * num;
				this.UpdateProgressText(score);
			}
		}

		// Token: 0x06038B21 RID: 232225 RVA: 0x00E5B3B4 File Offset: 0x00E595B4
		public void UpdateGridProgress(float percent)
		{
			float num = Math.Max(0f, Math.Min(percent, 1f));
			float startValue = this.GetStartValue();
			float addValue = this.GetAddValue();
			float num2 = startValue + addValue * num;
			GenericLayout<MoraleAreaProgressItem, MoraleAreaProgressData> percentLayout = this.PercentLayout;
			List<MoraleAreaProgressItem> list = (percentLayout != null) ? percentLayout.GetLayoutItemList() : null;
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					list[i].SetUiProgressByScore((int)num2);
				}
			}
			GenericLayout<MoraleAreaProgressPointItem, MoraleAreaProgressData> pointLayout = this.PointLayout;
			List<MoraleAreaProgressPointItem> list2 = (pointLayout != null) ? pointLayout.GetLayoutItemList() : null;
			if (list2 != null)
			{
				for (int j = 0; j < list2.Count; j++)
				{
					list2[j].SetUiProgressByScore((int)num2);
				}
			}
			this.UpdateProgressText(num2);
		}

		// Token: 0x06038B22 RID: 232226 RVA: 0x00E5B468 File Offset: 0x00E59668
		public UniTask InitCurve()
		{
			MoraleAreaProgressTips.<InitCurve>d__32 <InitCurve>d__;
			<InitCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCurve>d__.<>4__this = this;
			<InitCurve>d__.<>1__state = -1;
			<InitCurve>d__.<>t__builder.Start<MoraleAreaProgressTips.<InitCurve>d__32>(ref <InitCurve>d__);
			return <InitCurve>d__.<>t__builder.Task;
		}

		// Token: 0x06038B23 RID: 232227 RVA: 0x00E5B4AC File Offset: 0x00E596AC
		public float GetCurveTime(UCurveFloat curve)
		{
			int num = curve.FloatCurve.Keys.Num();
			if (num <= 0)
			{
				return 1000f;
			}
			return curve.FloatCurve.Keys.Get(num - 1).Time * 1000f;
		}

		// Token: 0x06038B24 RID: 232228 RVA: 0x00E5B4F2 File Offset: 0x00E596F2
		public float GetCurveValue(UCurveFloat curve, float time)
		{
			return curve.GetFloatValue(time / 1000f);
		}

		// Token: 0x06038B25 RID: 232229 RVA: 0x00E5B504 File Offset: 0x00E59704
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<UCurveFloat> LoadCurveFloat(string resId)
		{
			MoraleAreaProgressTips.<LoadCurveFloat>d__35 <LoadCurveFloat>d__;
			<LoadCurveFloat>d__.<>t__builder = AsyncUniTaskMethodBuilder<UCurveFloat>.Create();
			<LoadCurveFloat>d__.resId = resId;
			<LoadCurveFloat>d__.<>1__state = -1;
			<LoadCurveFloat>d__.<>t__builder.Start<MoraleAreaProgressTips.<LoadCurveFloat>d__35>(ref <LoadCurveFloat>d__);
			return <LoadCurveFloat>d__.<>t__builder.Task;
		}

		// Token: 0x06038B26 RID: 232230 RVA: 0x00E5B548 File Offset: 0x00E59748
		public UniTask PlayNewProgress()
		{
			MoraleAreaProgressTips.<PlayNewProgress>d__36 <PlayNewProgress>d__;
			<PlayNewProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayNewProgress>d__.<>4__this = this;
			<PlayNewProgress>d__.<>1__state = -1;
			<PlayNewProgress>d__.<>t__builder.Start<MoraleAreaProgressTips.<PlayNewProgress>d__36>(ref <PlayNewProgress>d__);
			return <PlayNewProgress>d__.<>t__builder.Task;
		}

		// Token: 0x06038B27 RID: 232231 RVA: 0x00E5B58C File Offset: 0x00E5978C
		public UniTask PlayGridProgress()
		{
			MoraleAreaProgressTips.<PlayGridProgress>d__37 <PlayGridProgress>d__;
			<PlayGridProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayGridProgress>d__.<>4__this = this;
			<PlayGridProgress>d__.<>1__state = -1;
			<PlayGridProgress>d__.<>t__builder.Start<MoraleAreaProgressTips.<PlayGridProgress>d__37>(ref <PlayGridProgress>d__);
			return <PlayGridProgress>d__.<>t__builder.Task;
		}

		// Token: 0x06038B28 RID: 232232 RVA: 0x00E5B5D0 File Offset: 0x00E597D0
		public UniTask PlayAllProgress()
		{
			MoraleAreaProgressTips.<PlayAllProgress>d__38 <PlayAllProgress>d__;
			<PlayAllProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAllProgress>d__.<>4__this = this;
			<PlayAllProgress>d__.<>1__state = -1;
			<PlayAllProgress>d__.<>t__builder.Start<MoraleAreaProgressTips.<PlayAllProgress>d__38>(ref <PlayAllProgress>d__);
			return <PlayAllProgress>d__.<>t__builder.Task;
		}

		// Token: 0x06038B29 RID: 232233 RVA: 0x00E5B613 File Offset: 0x00E59813
		protected override void OnTick(float delta)
		{
			this.TickNewProgress(delta);
			this.TickGridProgress(delta);
		}

		// Token: 0x06038B2A RID: 232234 RVA: 0x00E5B624 File Offset: 0x00E59824
		public void TickNewProgress(float delta)
		{
			if (!this.IsPlayingNewProgress)
			{
				return;
			}
			this.DeltaNewProgressTime += delta;
			float time = this.DeltaNewProgressTime;
			if (this.DeltaNewProgressTime >= this.NewProgressTime)
			{
				time = this.NewProgressTime;
				this.IsPlayingNewProgress = false;
				CustomPromise newProgressPromise = this.NewProgressPromise;
				if (newProgressPromise != null)
				{
					newProgressPromise.SetResult();
				}
			}
			float curveValue = this.GetCurveValue(this.NewProgressCurve, time);
			this.UpdateNewProgress(curveValue);
		}

		// Token: 0x06038B2B RID: 232235 RVA: 0x00E5B694 File Offset: 0x00E59894
		public void TickGridProgress(float delta)
		{
			if (!this.IsPlayingGridProgress)
			{
				return;
			}
			this.DeltaGridProgressTime += delta;
			float time = this.DeltaGridProgressTime;
			if (this.DeltaGridProgressTime >= this.GridProgressTime)
			{
				time = this.GridProgressTime;
				this.IsPlayingGridProgress = false;
				CustomPromise gridProgressPromise = this.GridProgressPromise;
				if (gridProgressPromise != null)
				{
					gridProgressPromise.SetResult();
				}
			}
			float curveValue = this.GetCurveValue(this.GridProgressCurve, time);
			this.UpdateGridProgress(curveValue);
		}

		// Token: 0x06038B2C RID: 232236 RVA: 0x00E5B701 File Offset: 0x00E59901
		public void LogInfo()
		{
		}

		// Token: 0x04020518 RID: 132376
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericLayout<MoraleAreaProgressItem, MoraleAreaProgressData> PercentLayout;

		// Token: 0x04020519 RID: 132377
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericLayout<MoraleAreaProgressPointItem, MoraleAreaProgressData> PointLayout;

		// Token: 0x0402051A RID: 132378
		public UCurveFloat NewProgressCurve;

		// Token: 0x0402051B RID: 132379
		public UCurveFloat GridProgressCurve;

		// Token: 0x0402051C RID: 132380
		[Nullable(2)]
		public CustomPromise NewProgressPromise;

		// Token: 0x0402051D RID: 132381
		[Nullable(2)]
		public CustomPromise GridProgressPromise;

		// Token: 0x0402051E RID: 132382
		public bool IsPlayingNewProgress;

		// Token: 0x0402051F RID: 132383
		public bool IsPlayingGridProgress;

		// Token: 0x04020520 RID: 132384
		public float NewProgressTime;

		// Token: 0x04020521 RID: 132385
		public float GridProgressTime;

		// Token: 0x04020522 RID: 132386
		public float DeltaNewProgressTime;

		// Token: 0x04020523 RID: 132387
		public float DeltaGridProgressTime;

		// Token: 0x0200B787 RID: 46983
		[Nullable(0)]
		public class Params
		{
			// Token: 0x04038C37 RID: 232503
			public int StartNum;

			// Token: 0x04038C38 RID: 232504
			public int AddNum;

			// Token: 0x04038C39 RID: 232505
			public string SourceDescKey;

			// Token: 0x04038C3A RID: 232506
			public List<MoraleAreaProgressData> InfoList;

			// Token: 0x04038C3B RID: 232507
			public bool IsMultipleView;
		}

		// Token: 0x0200B788 RID: 46984
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038C3C RID: 232508
			public const int LayoutProgress = 0;

			// Token: 0x04038C3D RID: 232509
			public const int ItemProgressTemplate = 1;

			// Token: 0x04038C3E RID: 232510
			public const int ItemNewProgressRoot = 2;

			// Token: 0x04038C3F RID: 232511
			public const int SliderNewProgress = 3;

			// Token: 0x04038C40 RID: 232512
			public const int LayoutProgressPoint = 4;

			// Token: 0x04038C41 RID: 232513
			public const int ItemProgressPointTemplate = 5;

			// Token: 0x04038C42 RID: 232514
			public const int TxtProgressValue = 6;

			// Token: 0x04038C43 RID: 232515
			public const int TxtSourceDesc = 7;
		}
	}
}
