using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PreWarm
{
	// Token: 0x02006582 RID: 25986
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityPreWarmMainView : UiViewBase
	{
		// Token: 0x06040E43 RID: 265795 RVA: 0x010A5341 File Offset: 0x010A3541
		public ActivityPreWarmMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040E44 RID: 265796 RVA: 0x010A534C File Offset: 0x010A354C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 5;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickBtnLeft));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickBtnRight));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickBtnExpand));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickBtnShrink));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnClickBtnJump));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040E45 RID: 265797 RVA: 0x010A5614 File Offset: 0x010A3814
		protected override UniTask OnBeforeStartAsync()
		{
			ActivityPreWarmMainView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityPreWarmMainView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040E46 RID: 265798 RVA: 0x010A5658 File Offset: 0x010A3858
		private UniTask LoadMaterial()
		{
			ActivityPreWarmMainView.<LoadMaterial>d__13 <LoadMaterial>d__;
			<LoadMaterial>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadMaterial>d__.<>4__this = this;
			<LoadMaterial>d__.<>1__state = -1;
			<LoadMaterial>d__.<>t__builder.Start<ActivityPreWarmMainView.<LoadMaterial>d__13>(ref <LoadMaterial>d__);
			return <LoadMaterial>d__.<>t__builder.Task;
		}

		// Token: 0x06040E47 RID: 265799 RVA: 0x010A569C File Offset: 0x010A389C
		private void InitText()
		{
			this.TextAnimDataComp = (base.GetText(5).GetOwner().GetComponentByClass(UUIEffectTextAnimation.StaticClass()) as UUIEffectTextAnimation);
			this.TextPlayTweenComp = (base.GetText(5).GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			UUIEffectTextAnimation textAnimDataComp = this.TextAnimDataComp;
			if (textAnimDataComp != null)
			{
				textAnimDataComp.SetSelectorOffset(1f);
			}
			this.TextPlayTweenEndCb = global::DelegateUtils.ToManualReleaseDelegate<FLGUIPlayTweenCompleteDynamicDelegate>(new Action(this.OnTweenEnd));
			this.TextPlayTweenEndCbWrapper = this.TextPlayTweenComp.GetPlayTween().RegisterOnComplete(this.TextPlayTweenEndCb);
			base.GetText(5).SetUIActive(false);
		}

		// Token: 0x06040E48 RID: 265800 RVA: 0x010A574C File Offset: 0x010A394C
		private void ShowText()
		{
			if (this.TextAnimDataComp == null || this.TextPlayTweenComp == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.ActivityPreWarm, ELogAuthor.CB, "打字机组件未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ActivityPreWarm;
			ELogAuthor author = ELogAuthor.CB;
			string message = "播放打字动画";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("时长", this.ParsingDuration);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.TextAnimDataComp.SetSelectorOffset(1f);
			this.TextPlayTweenComp.GetPlayTween().duration = this.ParsingDuration;
			this.TextPlayTweenComp.Play();
		}

		// Token: 0x06040E49 RID: 265801 RVA: 0x010A57EE File Offset: 0x010A39EE
		private void OnTweenEnd()
		{
			this.TextPlayTweenComp.Stop();
			this.TextAnimDataComp.SetSelectorOffset(0f);
		}

		// Token: 0x06040E4A RID: 265802 RVA: 0x010A580C File Offset: 0x010A3A0C
		private void OnChangeInfo(int direction)
		{
			this.CurrentId += direction;
			this.RefreshInfo();
			if (this.UiViewSequence != null && this.UiViewSequence.HasSequenceNameInPlaying("Switch"))
			{
				this.UiViewSequence.ReplaySequence("Switch");
				return;
			}
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlaySequence("Switch", false, null);
		}

		// Token: 0x06040E4B RID: 265803 RVA: 0x010A5878 File Offset: 0x010A3A78
		private void OnClickBtnJump()
		{
			Singleton<Log>.Instance.Info(ELogModule.ActivityPreWarm, ELogAuthor.CB, "点击跳过,设置5倍数", default(ReadOnlySpan<ValueTuple<string, object>>));
			ULGUIPlayTweenComponent textPlayTweenComp = this.TextPlayTweenComp;
			if (textPlayTweenComp != null)
			{
				ULGUIPlayTween playTween = textPlayTweenComp.GetPlayTween();
				if (playTween != null)
				{
					ULTweener tweener = playTween.GetTweener();
					if (tweener != null)
					{
						tweener.SetSpeed(5f);
					}
				}
			}
			AUIBaseActor rootActor = this.RootActor;
			if (rootActor == null)
			{
				return;
			}
			ALevelSequenceActor sequencePlayerByKey = rootActor.GetSequencePlayerByKey("Start01");
			if (sequencePlayerByKey == null)
			{
				return;
			}
			ULevelSequencePlayer sequencePlayer = sequencePlayerByKey.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.SetPlayRate(5f);
		}

		// Token: 0x06040E4C RID: 265804 RVA: 0x010A58FF File Offset: 0x010A3AFF
		protected override void OnStart()
		{
			this.InitCaptionItem();
			this.InitText();
		}

		// Token: 0x06040E4D RID: 265805 RVA: 0x010A5910 File Offset: 0x010A3B10
		protected override void OnBeforeShow()
		{
			if (this.IsParsing)
			{
				base.PlaySequence("Start01", delegate
				{
					Singleton<Log>.Instance.Info(ELogModule.ActivityPreWarm, ELogAuthor.CB, "解析动画播放完成", default(ReadOnlySpan<ValueTuple<string, object>>));
					PopupCaptionItem captionItem = this.CaptionItem;
					if (captionItem != null)
					{
						captionItem.SetCloseBtnActive(true);
					}
					UUIItem item2 = base.GetItem(6);
					if (item2 == null)
					{
						return;
					}
					item2.SetUIActive(false);
				}, false);
				AUIBaseActor rootActor = this.RootActor;
				FQualifiedFrameTime fqualifiedFrameTime;
				if (rootActor == null)
				{
					fqualifiedFrameTime = null;
				}
				else
				{
					ALevelSequenceActor sequencePlayerByKey = rootActor.GetSequencePlayerByKey("Start01");
					if (sequencePlayerByKey == null)
					{
						fqualifiedFrameTime = null;
					}
					else
					{
						ULevelSequencePlayer sequencePlayer = sequencePlayerByKey.SequencePlayer;
						fqualifiedFrameTime = ((sequencePlayer != null) ? sequencePlayer.GetDuration() : null);
					}
				}
				FQualifiedFrameTime fqualifiedFrameTime2 = fqualifiedFrameTime;
				if (fqualifiedFrameTime2 != null)
				{
					float num = (float)fqualifiedFrameTime2.Time.FrameNumber.Value + fqualifiedFrameTime2.Time.SubFrame;
					float num2 = (float)fqualifiedFrameTime2.Rate.Denominator / (float)fqualifiedFrameTime2.Rate.Numerator;
					float parsingDuration = num * num2;
					this.ParsingDuration = parsingDuration;
				}
			}
			else
			{
				UUIItem item = base.GetItem(6);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				base.PlaySequence("Start02", null, false);
			}
			this.RefreshInfo();
		}

		// Token: 0x06040E4E RID: 265806 RVA: 0x010A59E2 File Offset: 0x010A3BE2
		private void InitCaptionItem()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnCloseBtnClick));
			this.CaptionItem.SetCloseBtnActive(!this.IsParsing);
		}

		// Token: 0x06040E4F RID: 265807 RVA: 0x010A5A21 File Offset: 0x010A3C21
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06040E50 RID: 265808 RVA: 0x010A5A2A File Offset: 0x010A3C2A
		private void RefreshInfo()
		{
			this.RefreshTitle();
			this.RefreshContentBg();
			this.RefreshLeftRightBtnState();
			this.RefreshDesc();
			this.RefreshShadowIcon();
			this.LastTime = Singleton<Time>.Instance.Now;
		}

		// Token: 0x06040E51 RID: 265809 RVA: 0x010A5A5C File Offset: 0x010A3C5C
		private void RefreshTitle()
		{
			ActivityPreWarmModel instance = ModelBase<ActivityPreWarmModel>.Instance;
			ActivityPreWarmCollectItemData activityPreWarmCollectItemData = (instance != null) ? instance.GetCollectItemDataById(this.CurrentId) : null;
			base.TrySetSpriteByPath((activityPreWarmCollectItemData != null) ? activityPreWarmCollectItemData.GetTitleNumIconPath() : null, base.GetSprite(1), false, null, null);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), (activityPreWarmCollectItemData != null) ? activityPreWarmCollectItemData.GetTitle() : null, Array.Empty<object>());
		}

		// Token: 0x06040E52 RID: 265810 RVA: 0x010A5AC8 File Offset: 0x010A3CC8
		private void RefreshDesc()
		{
			ActivityPreWarmModel instance = ModelBase<ActivityPreWarmModel>.Instance;
			ActivityPreWarmCollectItemData activityPreWarmCollectItemData = (instance != null) ? instance.GetCollectItemDataById(this.CurrentId) : null;
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(5), (activityPreWarmCollectItemData != null) ? activityPreWarmCollectItemData.GetDesc() : null, Array.Empty<object>());
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetUIActive(true);
			}
			if (this.IsParsing)
			{
				this.ShowText();
			}
		}

		// Token: 0x06040E53 RID: 265811 RVA: 0x010A5B30 File Offset: 0x010A3D30
		private void RefreshContentBg()
		{
			ActivityPreWarmModel instance = ModelBase<ActivityPreWarmModel>.Instance;
			ActivityPreWarmCollectItemData activityPreWarmCollectItemData = (instance != null) ? instance.GetCollectItemDataById(this.CurrentId) : null;
			base.TrySetTextureByPath((activityPreWarmCollectItemData != null) ? activityPreWarmCollectItemData.GetBgPath() : null, base.GetTexture(3), null, null);
		}

		// Token: 0x06040E54 RID: 265812 RVA: 0x010A5B78 File Offset: 0x010A3D78
		private void RefreshShadowIcon()
		{
			if (this.IsParsing)
			{
				ActivityPreWarmModel instance = ModelBase<ActivityPreWarmModel>.Instance;
				ActivityPreWarmCollectItemData activityPreWarmCollectItemData = (instance != null) ? instance.GetCollectItemDataById(this.CurrentId) : null;
				base.TrySetTextureByPath((activityPreWarmCollectItemData != null) ? activityPreWarmCollectItemData.GetShadowIconPath() : null, base.GetTexture(4), null, null);
			}
		}

		// Token: 0x06040E55 RID: 265813 RVA: 0x010A5BC8 File Offset: 0x010A3DC8
		private void OnClickBtnExpand()
		{
			this.OnDescInfoStateChange(true);
		}

		// Token: 0x06040E56 RID: 265814 RVA: 0x010A5BD1 File Offset: 0x010A3DD1
		private void OnClickBtnShrink()
		{
			this.OnDescInfoStateChange(false);
		}

		// Token: 0x06040E57 RID: 265815 RVA: 0x010A5BDC File Offset: 0x010A3DDC
		private void OnDescInfoStateChange(bool isExpand)
		{
			UUIButtonComponent button = base.GetButton(10);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(!isExpand);
			}
			UUIButtonComponent button2 = base.GetButton(11);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(isExpand);
			}
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.StopSequenceByKey(isExpand ? "InfoHide" : "InfoShow", false, false);
			}
			UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
			if (uiViewSequence2 == null)
			{
				return;
			}
			uiViewSequence2.PlaySequence(isExpand ? "InfoShow" : "InfoHide", false, null);
		}

		// Token: 0x06040E58 RID: 265816 RVA: 0x010A5C79 File Offset: 0x010A3E79
		private void OnClickBtnLeft()
		{
			this.LogReport();
			this.OnChangeInfo(-1);
		}

		// Token: 0x06040E59 RID: 265817 RVA: 0x010A5C88 File Offset: 0x010A3E88
		private void OnClickBtnRight()
		{
			this.LogReport();
			this.OnChangeInfo(1);
		}

		// Token: 0x06040E5A RID: 265818 RVA: 0x010A5C98 File Offset: 0x010A3E98
		public void RefreshLeftRightBtnState()
		{
			if (this.IsParsing)
			{
				UUIButtonComponent button = base.GetButton(8);
				if (button != null)
				{
					button.RootUIComp.Get().SetUIActive(false);
				}
				UUIButtonComponent button2 = base.GetButton(9);
				if (button2 == null)
				{
					return;
				}
				button2.RootUIComp.Get().SetUIActive(false);
				return;
			}
			else
			{
				UUIButtonComponent button3 = base.GetButton(8);
				if (button3 != null)
				{
					button3.RootUIComp.Get().SetUIActive(this.CurrentId > 1);
				}
				UUIButtonComponent button4 = base.GetButton(9);
				if (button4 == null)
				{
					return;
				}
				UUIItem uuiitem = button4.RootUIComp.Get();
				int currentId = this.CurrentId;
				ActivityPreWarmModel instance = ModelBase<ActivityPreWarmModel>.Instance;
				uuiitem.SetUIActive(currentId < ((instance != null) ? instance.GetLastFinishedId() : 1));
				return;
			}
		}

		// Token: 0x06040E5B RID: 265819 RVA: 0x010A5D50 File Offset: 0x010A3F50
		protected override void OnBeforeDestroy()
		{
			if (this.TextPlayTweenEndCbWrapper != null)
			{
				ULGUIPlayTweenComponent textPlayTweenComp = this.TextPlayTweenComp;
				if (textPlayTweenComp != null)
				{
					ULGUIPlayTween playTween = textPlayTweenComp.GetPlayTween();
					if (playTween != null)
					{
						playTween.UnregisterOnComplete(this.TextPlayTweenEndCbWrapper);
					}
				}
				this.TextPlayTweenEndCbWrapper = null;
			}
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnTweenEnd));
			this.TextPlayTweenEndCb = null;
			this.LogReport();
		}

		// Token: 0x06040E5C RID: 265820 RVA: 0x010A5DB4 File Offset: 0x010A3FB4
		private void LogReport()
		{
			if (this.LastTime == 0.0)
			{
				return;
			}
			double num = Singleton<Time>.Instance.Now - this.LastTime;
			if (num <= 1000.0)
			{
				return;
			}
			ActivityPreWarmStayLogEvent activityPreWarmStayLogEvent = new ActivityPreWarmStayLogEvent();
			activityPreWarmStayLogEvent.i_activity_id = this.ActivityId;
			activityPreWarmStayLogEvent.i_chapter_id = this.CurrentId;
			activityPreWarmStayLogEvent.i_cost_time = num * Singleton<TimeUtil>.Instance.Millisecond;
			ControllerBase<LogReportController>.Instance.LogReport(activityPreWarmStayLogEvent);
		}

		// Token: 0x040246CA RID: 149194
		private PopupCaptionItem CaptionItem;

		// Token: 0x040246CB RID: 149195
		private UUIEffectTextAnimation TextAnimDataComp;

		// Token: 0x040246CC RID: 149196
		private ULGUIPlayTweenComponent TextPlayTweenComp;

		// Token: 0x040246CD RID: 149197
		private FLGUIPlayTweenCompleteDynamicDelegate TextPlayTweenEndCb;

		// Token: 0x040246CE RID: 149198
		private FLGUIDelegateHandleWrapper TextPlayTweenEndCbWrapper;

		// Token: 0x040246CF RID: 149199
		private int CurrentId;

		// Token: 0x040246D0 RID: 149200
		private bool IsParsing;

		// Token: 0x040246D1 RID: 149201
		private float ParsingDuration;

		// Token: 0x040246D2 RID: 149202
		private int ActivityId;

		// Token: 0x040246D3 RID: 149203
		private double LastTime;

		// Token: 0x0200C55E RID: 50526
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403CBD7 RID: 248791
			public const int CaptionItem = 0;

			// Token: 0x0403CBD8 RID: 248792
			public const int CurrentNum = 1;

			// Token: 0x0403CBD9 RID: 248793
			public const int TitleTxt = 2;

			// Token: 0x0403CBDA RID: 248794
			public const int ContentBg = 3;

			// Token: 0x0403CBDB RID: 248795
			public const int ShadowIcon = 4;

			// Token: 0x0403CBDC RID: 248796
			public const int TxtDesc = 5;

			// Token: 0x0403CBDD RID: 248797
			public const int LoadingRoot = 6;

			// Token: 0x0403CBDE RID: 248798
			public const int DetailRoot = 7;

			// Token: 0x0403CBDF RID: 248799
			public const int BtnLeft = 8;

			// Token: 0x0403CBE0 RID: 248800
			public const int BtnRight = 9;

			// Token: 0x0403CBE1 RID: 248801
			public const int BtnExpand = 10;

			// Token: 0x0403CBE2 RID: 248802
			public const int BtnShrink = 11;

			// Token: 0x0403CBE3 RID: 248803
			public const int BtnJump = 12;

			// Token: 0x0403CBE4 RID: 248804
			public const int TexGlitch = 13;
		}
	}
}
