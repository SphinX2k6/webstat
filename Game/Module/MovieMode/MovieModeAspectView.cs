using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056E0 RID: 22240
	[NullableContext(1)]
	[Nullable(0)]
	public class MovieModeAspectView : UiPanelBase
	{
		// Token: 0x170090D4 RID: 37076
		// (get) Token: 0x06038988 RID: 231816 RVA: 0x00E560FB File Offset: 0x00E542FB
		// (set) Token: 0x06038989 RID: 231817 RVA: 0x00E56108 File Offset: 0x00E54308
		public new MovieModeAspectViewParams OpenParam
		{
			get
			{
				return (MovieModeAspectViewParams)this.OpenParam;
			}
			set
			{
				this.OpenParam = value;
			}
		}

		// Token: 0x0603898A RID: 231818 RVA: 0x00E56114 File Offset: 0x00E54314
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603898B RID: 231819 RVA: 0x00E56180 File Offset: 0x00E54380
		protected override void OnStart()
		{
			this.Texture1 = base.GetTexture(0);
			UUITexture texture = this.Texture1;
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
			UUITexture texture2 = this.Texture1;
			if (texture2 != null)
			{
				texture2.SetAlpha(1f);
			}
			this.Texture2 = base.GetTexture(1);
			UUITexture texture3 = this.Texture2;
			if (texture3 != null)
			{
				texture3.SetUIActive(false);
			}
			UUITexture texture4 = this.Texture2;
			if (texture4 != null)
			{
				texture4.SetAlpha(1f);
			}
			base.GetRootItem().GetRenderCanvas().bPostTickUpdate = true;
			base.GetRootItem().SetRaycastTarget(false);
			this.AdaptUiLayers = (this.OpenParam.AdaptUiLayers ?? this.DefaultAdaptUiLayers);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MovieMode;
			ELogAuthor author = ELogAuthor.CB;
			string message = "设置适配的UI层级";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AdaptUiLayers", (from layer in this.AdaptUiLayers
			select layer.ToString()).ToArray<string>());
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.IsBanAdaptation = this.OpenParam.IsBanAdaptation;
			this.SaveUiLayerSafeZoneInfo();
		}

		// Token: 0x0603898C RID: 231820 RVA: 0x00E5629E File Offset: 0x00E5449E
		protected override void OnBeforeDestroy()
		{
			CustomPromise fadeCompletePromise = this.FadeCompletePromise;
			if (fadeCompletePromise != null)
			{
				fadeCompletePromise.SetResult();
			}
			this.RemoveTick();
			this.SetAdaptUiLayerVisible(true);
			this.AdaptUiLayer(false);
		}

		// Token: 0x0603898D RID: 231821 RVA: 0x00E562C8 File Offset: 0x00E544C8
		public UniTask Fade(bool isFadeIn, float blendTime)
		{
			MovieModeAspectView.<Fade>d__28 <Fade>d__;
			<Fade>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Fade>d__.<>4__this = this;
			<Fade>d__.isFadeIn = isFadeIn;
			<Fade>d__.blendTime = blendTime;
			<Fade>d__.<>1__state = -1;
			<Fade>d__.<>t__builder.Start<MovieModeAspectView.<Fade>d__28>(ref <Fade>d__);
			return <Fade>d__.<>t__builder.Task;
		}

		// Token: 0x0603898E RID: 231822 RVA: 0x00E5631C File Offset: 0x00E5451C
		public void FadeReverse()
		{
			this.IsFadeIn = !this.IsFadeIn;
			this.Speed = -this.Speed;
			this.Duration = this.BlendTime - this.Duration;
			float num = this.IsWidthBlend ? this.OriginalUiWidth : this.OriginalUiHeight;
			float num2 = this.IsWidthBlend ? (this.OriginalUiHeight * this.CacheRatio) : (this.OriginalUiWidth / this.CacheRatio);
			float num3 = num / 2f + num2 / 2f;
			this.TargetValue = (this.IsFadeIn ? num3 : num);
		}

		// Token: 0x0603898F RID: 231823 RVA: 0x00E563B8 File Offset: 0x00E545B8
		private void OnTick(float delta)
		{
			if (this.Duration >= this.BlendTime)
			{
				this.OnFadeComplete();
				return;
			}
			this.Duration += delta;
			this.CurrentValue += delta * this.Speed;
			this.CurrentValue = (this.IsFadeIn ? Math.Max(this.CurrentValue, this.TargetValue) : Math.Min(this.CurrentValue, this.TargetValue));
			this.ApplyStretchValues(this.CurrentValue);
			this.AspectOffset.IsFadeIn = this.IsFadeIn;
			this.AspectOffset.IsWidthBlend = this.IsWidthBlend;
			this.AspectOffset.Offset = (this.IsWidthBlend ? (this.OriginalUiWidth - this.CurrentValue) : (this.OriginalUiHeight - this.CurrentValue));
			this.AspectOffset.Progress = ((this.TotalOffset == 0f) ? 0f : (this.AspectOffset.Offset / this.TotalOffset));
			Singleton<EventSystem>.Instance.Emit<IMovieModeAspectOffset>(EEventName.MovieModeAspectOffsetUpdate, this.AspectOffset);
		}

		// Token: 0x06038990 RID: 231824 RVA: 0x00E564D4 File Offset: 0x00E546D4
		private void OnFadeComplete()
		{
			CustomPromise fadeCompletePromise = this.FadeCompletePromise;
			if (fadeCompletePromise != null)
			{
				fadeCompletePromise.SetResult();
			}
			this.RemoveTick();
			Singleton<Log>.Instance.Info(ELogModule.MovieMode, ELogAuthor.CB, "电影模式黑边设置完成", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06038991 RID: 231825 RVA: 0x00E56517 File Offset: 0x00E54717
		private void RemoveTick()
		{
			ControllerBase<MovieModeController>.Instance.RemoveTick(this.TickHandle);
			this.TickHandle = -1;
		}

		// Token: 0x06038992 RID: 231826 RVA: 0x00E56530 File Offset: 0x00E54730
		private unsafe void StartTransform()
		{
			if (!this.Enable)
			{
				return;
			}
			this.Enable = false;
			UUITexture texture = this.Texture1;
			if (texture != null)
			{
				texture.SetUIActive(!this.IsBanAdaptation);
			}
			UUITexture texture2 = this.Texture2;
			if (texture2 != null)
			{
				texture2.SetUIActive(!this.IsBanAdaptation);
			}
			this.OriginalUiWidth = Singleton<UiLayer>.Instance.UiRootItem.GetWidth();
			this.OriginalUiHeight = Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
			float num = this.OriginalUiWidth / this.OriginalUiHeight;
			this.IsWidthBlend = (this.CacheRatio < num);
			this.AspectOffset.IsWidthBlend = this.IsWidthBlend;
			float num2 = this.IsWidthBlend ? this.OriginalUiWidth : this.OriginalUiHeight;
			float num3 = this.IsWidthBlend ? (this.OriginalUiHeight * this.CacheRatio) : (this.OriginalUiWidth / this.CacheRatio);
			float targetValue = num2 / 2f + num3 / 2f;
			this.SetupAnimation(num2, targetValue);
			this.Duration = 0f;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MovieMode;
			ELogAuthor author = ELogAuthor.CB;
			string message = "进出电影模式，更新黑边";
			<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("uiWidth", this.OriginalUiWidth);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("uiHeight", this.OriginalUiHeight);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("isFadeIn", this.IsFadeIn);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("currentValue", this.CurrentValue);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("targetValue", this.TargetValue);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("BlendTime", this.BlendTime);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
			if (this.BlendTime <= 0f)
			{
				this.CurrentValue = this.TargetValue;
				this.ApplyStretchValues(this.CurrentValue);
				this.AspectOffset.IsFadeIn = this.IsFadeIn;
				this.AspectOffset.IsWidthBlend = this.IsWidthBlend;
				this.AspectOffset.Offset = (this.IsWidthBlend ? (this.OriginalUiWidth - this.CurrentValue) : (this.OriginalUiHeight - this.CurrentValue));
				this.AspectOffset.Progress = 1f;
				Singleton<EventSystem>.Instance.Emit<IMovieModeAspectOffset>(EEventName.MovieModeAspectOffsetUpdate, this.AspectOffset);
				this.OnFadeComplete();
				return;
			}
			this.TickHandle = ControllerBase<MovieModeController>.Instance.AddTick(new Action<float>(this.OnTick));
		}

		// Token: 0x06038993 RID: 231827 RVA: 0x00E567EC File Offset: 0x00E549EC
		private void SetupAnimation(float screenSize, float targetValue)
		{
			this.CurrentValue = (this.IsFadeIn ? screenSize : targetValue);
			this.TargetValue = (this.IsFadeIn ? targetValue : screenSize);
			this.TotalOffset = Math.Abs(this.TargetValue - this.CurrentValue);
			this.Speed = ((this.BlendTime == 0f) ? 0f : ((this.TargetValue - this.CurrentValue) / this.BlendTime));
			this.ApplyStretchValues(this.CurrentValue);
		}

		// Token: 0x06038994 RID: 231828 RVA: 0x00E56870 File Offset: 0x00E54A70
		private void ApplyStretchValues(float value)
		{
			if (this.IsWidthBlend)
			{
				UUITexture texture = this.Texture1;
				if (texture != null)
				{
					texture.SetStretchRight(value);
				}
				UUITexture texture2 = this.Texture2;
				if (texture2 != null)
				{
					texture2.SetStretchLeft(value);
				}
				UUITexture texture3 = this.Texture1;
				if (texture3 != null)
				{
					texture3.SetStretchTop(0f);
				}
				UUITexture texture4 = this.Texture2;
				if (texture4 == null)
				{
					return;
				}
				texture4.SetStretchBottom(0f);
				return;
			}
			else
			{
				UUITexture texture5 = this.Texture1;
				if (texture5 != null)
				{
					texture5.SetStretchTop(value);
				}
				UUITexture texture6 = this.Texture2;
				if (texture6 != null)
				{
					texture6.SetStretchBottom(value);
				}
				UUITexture texture7 = this.Texture1;
				if (texture7 != null)
				{
					texture7.SetStretchRight(0f);
				}
				UUITexture texture8 = this.Texture2;
				if (texture8 == null)
				{
					return;
				}
				texture8.SetStretchLeft(0f);
				return;
			}
		}

		// Token: 0x06038995 RID: 231829 RVA: 0x00E56924 File Offset: 0x00E54B24
		private void AdaptUiLayer(bool bAdapt)
		{
			if (this.AdaptUiLayers == null)
			{
				return;
			}
			if (this.IsBanAdaptation)
			{
				Singleton<Log>.Instance.Info(ELogModule.MovieMode, ELogAuthor.CB, "没有黑边,不需要适配UI", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			float num = bAdapt ? (this.IsWidthBlend ? (this.OriginalUiWidth - this.CurrentValue) : 0f) : 0f;
			float num2 = bAdapt ? (this.IsWidthBlend ? 0f : (this.OriginalUiHeight - this.CurrentValue)) : 0f;
			foreach (ELayerType elayerType in this.AdaptUiLayers)
			{
				UUIItem layerRootUiItem = Singleton<UiLayer>.Instance.GetLayerRootUiItem(elayerType);
				if (layerRootUiItem == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.MovieMode;
					ELogAuthor author = ELogAuthor.CB;
					string message = "获取UI层失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("layer", elayerType.ToString());
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					float width = Singleton<UiLayer>.Instance.UiRootItem.GetWidth() - num * 2f;
					float height = Singleton<UiLayer>.Instance.UiRootItem.GetHeight() - num2 * 2f;
					Vector vector = Vector.Create(Singleton<UiLayer>.Instance.UiRootItem.RelativeScale3D);
					float width2 = 0f;
					float height2 = 0f;
					float num3 = 0f;
					UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
					if (uiRootItem != null)
					{
						ULGUICanvasScaler canvasScaler = uiRootItem.GetCanvasScaler();
						if (canvasScaler != null)
						{
							canvasScaler.CalculateAdaptedSizeAndScale(width, height, ref width2, ref height2, ref num3);
						}
					}
					vector.MultiplyEqual((double)num3);
					layerRootUiItem.SetAnchorOffset(Vector2D.ZeroVector);
					layerRootUiItem.SetWidth(width2);
					layerRootUiItem.SetHeight(height2);
					layerRootUiItem.SetUIItemScale(vector.ToUeVectorOld());
					float stretchTop = layerRootUiItem.GetStretchTop();
					float stretchBottom = layerRootUiItem.GetStretchBottom();
					float stretchLeft = layerRootUiItem.GetStretchLeft();
					float stretchRight = layerRootUiItem.GetStretchRight();
					layerRootUiItem.SetStretchTop(stretchTop + this.UiLayerSafeZoneInfos[elayerType].StretchTop);
					layerRootUiItem.SetStretchBottom(stretchBottom + this.UiLayerSafeZoneInfos[elayerType].StretchBottom);
					layerRootUiItem.SetStretchLeft(stretchLeft + this.UiLayerSafeZoneInfos[elayerType].StretchLeft);
					layerRootUiItem.SetStretchRight(stretchRight + this.UiLayerSafeZoneInfos[elayerType].StretchRight);
				}
			}
		}

		// Token: 0x06038996 RID: 231830 RVA: 0x00E56B7C File Offset: 0x00E54D7C
		private unsafe void SetAdaptUiLayerVisible(bool bVisible)
		{
			if (this.AdaptUiLayers == null || this.OpenParam.IsIgnoreUiLayerVisible.GetValueOrDefault())
			{
				return;
			}
			foreach (ELayerType layerType in this.AdaptUiLayers)
			{
				UUIItem layerRootUiItem = Singleton<UiLayer>.Instance.GetLayerRootUiItem(layerType);
				if (layerRootUiItem != null)
				{
					layerRootUiItem.SetUIActive(bVisible);
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MovieMode;
				ELogAuthor author = ELogAuthor.CB;
				string message = "设置UI层可见状态";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("layer", layerType.ToString());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("bVisible", bVisible);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x06038997 RID: 231831 RVA: 0x00E56C48 File Offset: 0x00E54E48
		private unsafe void SaveUiLayerSafeZoneInfo()
		{
			if (this.AdaptUiLayers == null)
			{
				return;
			}
			foreach (ELayerType elayerType in this.AdaptUiLayers)
			{
				UUIItem layerRootUiItem = Singleton<UiLayer>.Instance.GetLayerRootUiItem(elayerType);
				float num = (layerRootUiItem != null) ? layerRootUiItem.GetStretchLeft() : 0f;
				float num2 = (layerRootUiItem != null) ? layerRootUiItem.GetStretchRight() : 0f;
				float num3 = (layerRootUiItem != null) ? layerRootUiItem.GetStretchTop() : 0f;
				float num4 = (layerRootUiItem != null) ? layerRootUiItem.GetStretchBottom() : 0f;
				this.UiLayerSafeZoneInfos[elayerType] = new UiLayerSafeZone
				{
					StretchLeft = num,
					StretchRight = num2,
					StretchTop = num3,
					StretchBottom = num4
				};
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MovieMode;
				ELogAuthor author = ELogAuthor.CB;
				string message = "保存UI层安全区信息";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("layer", elayerType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("stretchLeft", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("stretchRight", num2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("stretchTop", num3);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("stretchBottom", num4);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			}
		}

		// Token: 0x06038998 RID: 231832 RVA: 0x00E56DBF File Offset: 0x00E54FBF
		public IMovieModeAspectOffset GetAspectOffset()
		{
			return this.AspectOffset;
		}

		// Token: 0x06038999 RID: 231833 RVA: 0x00E56DC8 File Offset: 0x00E54FC8
		public unsafe void UpdateTransform()
		{
			this.OriginalUiWidth = Singleton<UiLayer>.Instance.UiRootItem.GetWidth();
			this.OriginalUiHeight = Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
			float num = this.OriginalUiWidth / this.OriginalUiHeight;
			this.IsWidthBlend = (this.CacheRatio < num);
			this.AspectOffset.IsWidthBlend = this.IsWidthBlend;
			float num2 = this.IsWidthBlend ? this.OriginalUiWidth : this.OriginalUiHeight;
			float num3 = this.IsWidthBlend ? (this.OriginalUiHeight * this.CacheRatio) : (this.OriginalUiWidth / this.CacheRatio);
			float num4 = num2 / 2f + num3 / 2f;
			float num5 = this.IsFadeIn ? num2 : num4;
			float num6 = this.IsFadeIn ? num4 : num2;
			float num7 = Singleton<MathUtils>.Instance.Clamp(this.Duration / this.BlendTime, 0f, 1f);
			this.CurrentValue = num5 + (num6 - num5) * num7;
			this.TargetValue = num6;
			this.TotalOffset = Math.Abs(num6 - num5);
			this.Speed = ((this.BlendTime == 0f) ? 0f : ((num6 - num5) / this.BlendTime));
			this.ApplyStretchValues(this.CurrentValue);
			this.AdaptUiLayer(true);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MovieMode;
			ELogAuthor author = ELogAuthor.CB;
			string message = "屏幕分辨率有改变，更新黑边";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("uiWidth", this.OriginalUiWidth);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("uiHeight", this.OriginalUiHeight);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("isFadeIn", this.IsFadeIn);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("currentValue", this.CurrentValue);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("targetValue", this.TargetValue);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
		}

		// Token: 0x04020497 RID: 132247
		private bool Enable;

		// Token: 0x04020498 RID: 132248
		[Nullable(2)]
		private UUITexture Texture1;

		// Token: 0x04020499 RID: 132249
		[Nullable(2)]
		private UUITexture Texture2;

		// Token: 0x0402049A RID: 132250
		private readonly float CacheRatio = 2.3703704f;

		// Token: 0x0402049B RID: 132251
		private float BlendTime;

		// Token: 0x0402049C RID: 132252
		private float Duration;

		// Token: 0x0402049D RID: 132253
		private float Speed;

		// Token: 0x0402049E RID: 132254
		private float CurrentValue;

		// Token: 0x0402049F RID: 132255
		private float TargetValue;

		// Token: 0x040204A0 RID: 132256
		private bool IsWidthBlend;

		// Token: 0x040204A1 RID: 132257
		private int TickHandle = -1;

		// Token: 0x040204A2 RID: 132258
		private bool IsFadeIn = true;

		// Token: 0x040204A3 RID: 132259
		[Nullable(2)]
		private CustomPromise FadeCompletePromise;

		// Token: 0x040204A4 RID: 132260
		private float OriginalUiWidth;

		// Token: 0x040204A5 RID: 132261
		private float OriginalUiHeight;

		// Token: 0x040204A6 RID: 132262
		private readonly IMovieModeAspectOffset AspectOffset = new MovieModeAspectOffset
		{
			IsFadeIn = true,
			IsWidthBlend = false,
			Offset = 0f,
			Progress = 0f
		};

		// Token: 0x040204A7 RID: 132263
		private float TotalOffset;

		// Token: 0x040204A8 RID: 132264
		private readonly ELayerType[] DefaultAdaptUiLayers = new ELayerType[]
		{
			ELayerType.HUD,
			ELayerType.Normal,
			ELayerType.Plot,
			ELayerType.BattleFloat,
			ELayerType.Pop,
			ELayerType.Float
		};

		// Token: 0x040204A9 RID: 132265
		[Nullable(2)]
		private ELayerType[] AdaptUiLayers;

		// Token: 0x040204AA RID: 132266
		private bool IsBanAdaptation;

		// Token: 0x040204AB RID: 132267
		private readonly Dictionary<ELayerType, IUiLayerSafeZone> UiLayerSafeZoneInfos = new Dictionary<ELayerType, IUiLayerSafeZone>();

		// Token: 0x0200B759 RID: 46937
		[NullableContext(0)]
		private enum EChildItem
		{
			// Token: 0x04038B59 RID: 232281
			Texture1,
			// Token: 0x04038B5A RID: 232282
			Texture2
		}
	}
}
