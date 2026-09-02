using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053BC RID: 21436
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotHintView : UiViewBase
	{
		// Token: 0x06036A8F RID: 223887 RVA: 0x00DD9207 File Offset: 0x00DD7407
		public PlotHintView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036A90 RID: 223888 RVA: 0x00DD9228 File Offset: 0x00DD7428
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036A91 RID: 223889 RVA: 0x00DD9294 File Offset: 0x00DD7494
		protected override void OnStart()
		{
			TransitionPopupViewParams transitionPopupViewParams = this.OpenParam as TransitionPopupViewParams;
			UUIText text = base.GetText(0);
			if (((transitionPopupViewParams != null) ? transitionPopupViewParams.Style : null) != null)
			{
				string styleTitle = this.GetStyleTitle(transitionPopupViewParams.Style);
				if (!string.IsNullOrEmpty(styleTitle))
				{
					if (text != null)
					{
						text.ShowTextNew(styleTitle);
					}
				}
				else if (text != null)
				{
					text.SetUIActive(false);
				}
				this.InitTweenAnim(1);
				return;
			}
			TransitionPopup? transitionPopup = (transitionPopupViewParams != null && transitionPopupViewParams.BoardId != null) ? ConfigTransitionPopupById.GetConfig(transitionPopupViewParams.BoardId.Value, true) : null;
			if (transitionPopup == null)
			{
				if (text != null)
				{
					text.SetUIActive(false);
				}
				return;
			}
			if (!string.IsNullOrEmpty(transitionPopup.Value.Title))
			{
				if (text != null)
				{
					text.ShowTextNew(transitionPopup.Value.Title);
				}
			}
			else if (text != null)
			{
				text.SetUIActive(false);
			}
			this.InitTweenAnim(1);
		}

		// Token: 0x06036A92 RID: 223890 RVA: 0x00DD9384 File Offset: 0x00DD7584
		[return: Nullable(2)]
		private string GetStyleTitle(ITransitionPopupStyle style)
		{
			ITransitionPopupLeftTopTip transitionPopupLeftTopTip = style as ITransitionPopupLeftTopTip;
			string result;
			if (transitionPopupLeftTopTip == null)
			{
				ITransitionPopupLeftBottomTransition transitionPopupLeftBottomTransition = style as ITransitionPopupLeftBottomTransition;
				if (transitionPopupLeftBottomTransition == null)
				{
					result = null;
				}
				else
				{
					result = transitionPopupLeftBottomTransition.TitleText;
				}
			}
			else
			{
				result = transitionPopupLeftTopTip.TitleText;
			}
			return result;
		}

		// Token: 0x06036A93 RID: 223891 RVA: 0x00DD93BC File Offset: 0x00DD75BC
		private void InitTweenAnim(int componentType)
		{
			List<ULGUIPlayTweenComponent> list = new List<ULGUIPlayTweenComponent>();
			TArray<UActorComponent> tarray = base.GetItem(componentType).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				list.Add(tarray.Get(i) as ULGUIPlayTweenComponent);
			}
			if (this.TweenAnimMap == null)
			{
				this.TweenAnimMap = new Dictionary<int, List<ULGUIPlayTweenComponent>>();
			}
			this.TweenAnimMap.Add(componentType, list);
		}

		// Token: 0x06036A94 RID: 223892 RVA: 0x00DD9430 File Offset: 0x00DD7630
		protected override void OnAfterShow()
		{
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap != null && this.TweenAnimMap.TryGetValue(1, out list) && list.Count > 0)
			{
				this.TotalAnimCount = list.Count;
				this.CompletedAnimCount = 0;
				for (int i = 0; i < list.Count; i++)
				{
					ULGUIPlayTweenComponent ulguiplayTweenComponent = list[i];
					ULGUIPlayTween playTween = ulguiplayTweenComponent.GetPlayTween();
					if (playTween != null)
					{
						Action action = this.CreateAnimCompleteCallback(i);
						this.AnimCompleteCallbacks.Add(action);
						ULGUIPlayTween ulguiplayTween = playTween;
						FLGUIPlayTweenCompleteDynamicDelegate flguiplayTweenCompleteDynamicDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLGUIPlayTweenCompleteDynamicDelegate>(action);
						FLGUIDelegateHandleWrapper item = ulguiplayTween.RegisterOnComplete(flguiplayTweenCompleteDynamicDelegate);
						this.AnimCompleteHandles.Add(item);
						ulguiplayTweenComponent.Play();
					}
				}
			}
		}

		// Token: 0x06036A95 RID: 223893 RVA: 0x00DD94D3 File Offset: 0x00DD76D3
		private Action CreateAnimCompleteCallback(int index)
		{
			return delegate()
			{
				this.OnAnimComplete(index);
			};
		}

		// Token: 0x06036A96 RID: 223894 RVA: 0x00DD94F3 File Offset: 0x00DD76F3
		private void OnAnimComplete(int index)
		{
			this.CompletedAnimCount++;
			if (this.CompletedAnimCount >= this.TotalAnimCount)
			{
				base.CloseMe(null);
			}
		}

		// Token: 0x06036A97 RID: 223895 RVA: 0x00DD9518 File Offset: 0x00DD7718
		protected override void OnBeforeDestroy()
		{
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap != null && this.TweenAnimMap.TryGetValue(1, out list) && list.Count > 0)
			{
				for (int i = 0; i < this.AnimCompleteHandles.Count; i++)
				{
					FLGUIDelegateHandleWrapper flguidelegateHandleWrapper = this.AnimCompleteHandles[i];
					if (flguidelegateHandleWrapper.IsValid() && i < list.Count)
					{
						ULGUIPlayTween playTween = list[i].GetPlayTween();
						if (playTween != null)
						{
							playTween.UnregisterOnComplete(flguidelegateHandleWrapper);
						}
					}
				}
			}
			this.AnimCompleteHandles.Clear();
			foreach (Action callBack in this.AnimCompleteCallbacks)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(callBack);
			}
			this.AnimCompleteCallbacks.Clear();
		}

		// Token: 0x0401F7C5 RID: 128965
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<int, List<ULGUIPlayTweenComponent>> TweenAnimMap;

		// Token: 0x0401F7C6 RID: 128966
		private readonly List<FLGUIDelegateHandleWrapper> AnimCompleteHandles = new List<FLGUIDelegateHandleWrapper>();

		// Token: 0x0401F7C7 RID: 128967
		private readonly List<Action> AnimCompleteCallbacks = new List<Action>();

		// Token: 0x0401F7C8 RID: 128968
		private int TotalAnimCount;

		// Token: 0x0401F7C9 RID: 128969
		private int CompletedAnimCount;

		// Token: 0x0200B325 RID: 45861
		[NullableContext(0)]
		private enum EChildComp
		{
			// Token: 0x04037802 RID: 227330
			ContentText,
			// Token: 0x04037803 RID: 227331
			AniStart
		}
	}
}
