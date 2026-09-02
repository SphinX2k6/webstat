using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DigitalScreen
{
	// Token: 0x02006F1D RID: 28445
	[NullableContext(1)]
	[Nullable(0)]
	public class DigitalScreenaView : UiTickViewBase
	{
		// Token: 0x06044E48 RID: 282184 RVA: 0x011EE39C File Offset: 0x011EC59C
		public DigitalScreenaView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044E49 RID: 282185 RVA: 0x011EE40C File Offset: 0x011EC60C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044E4A RID: 282186 RVA: 0x011EE4D8 File Offset: 0x011EC6D8
		protected override void OnStart()
		{
			ModelBase<PlotModel>.Instance.InDigitalScreen = true;
			this.InitInfo();
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_digital_screen");
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.TextPlayTweenComp = (base.GetText(2).GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
			this.LevelSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
			if (ModelBase<DigitalScreenModel>.Instance.StartTimes[0] == 0f)
			{
				this.ResumeNextLine();
			}
			else
			{
				this.TimerHandleNextLine = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.ResumeNextLine();
				}, (float)((int)Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)ModelBase<DigitalScreenModel>.Instance.StartTimes[0])), null, null, true, 1f);
			}
			this.TimerHandleCloseUi = TimerSystem.Instance.Delay(delegate(float _)
			{
				base.CloseMe(null);
			}, (float)((int)Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)ModelBase<DigitalScreenModel>.Instance.ExistTime)), null, null, true, 1f);
		}

		// Token: 0x06044E4B RID: 282187 RVA: 0x011EE608 File Offset: 0x011EC808
		protected override void OnBeforeHide()
		{
			ModelBase<PlotModel>.Instance.InDigitalScreen = false;
			this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
			Singleton<AudioSystem>.Instance.ExecuteAction("play_ui_digital_screen", EAudioActionType.Stop, null);
			this.RemoveTimerCheck();
		}

		// Token: 0x06044E4C RID: 282188 RVA: 0x011EE65C File Offset: 0x011EC85C
		private void RemoveTimerCheck()
		{
			if (this.TimerHandleCloseUi != null && TimerSystem.Instance.Has(this.TimerHandleCloseUi))
			{
				TimerSystem.Instance.Remove(this.TimerHandleCloseUi);
			}
			if (this.TimerHandleNextLine != null && TimerSystem.Instance.Has(this.TimerHandleNextLine))
			{
				TimerSystem.Instance.Remove(this.TimerHandleNextLine);
			}
		}

		// Token: 0x06044E4D RID: 282189 RVA: 0x011EE6C0 File Offset: 0x011EC8C0
		protected override void OnTick(float deltaTime)
		{
			if (!this.IsTweening)
			{
				this.TickDeltaTime += deltaTime;
				if (this.TickDeltaTime >= 300f)
				{
					if (this.ContentPos == 0)
					{
						if (this.IsTextWithLine)
						{
							UUIText text = base.GetText(1);
							if (text != null)
							{
								text.SetText(this.LeftTextWithoutLine, true);
							}
							this.IsTextWithLine = false;
						}
						else
						{
							UUIText text2 = base.GetText(1);
							if (text2 != null)
							{
								text2.SetText(this.LeftTextWithLine, true);
							}
							this.IsTextWithLine = true;
						}
					}
					else if (this.ContentPos == 1)
					{
						if (this.IsTextWithLine)
						{
							UUIText text3 = base.GetText(2);
							if (text3 != null)
							{
								text3.SetText(this.MiddleTextWithoutLine, true);
							}
							this.IsTextWithLine = false;
						}
						else
						{
							UUIText text4 = base.GetText(2);
							if (text4 != null)
							{
								text4.SetText(this.MiddleTextWithLine, true);
							}
							this.IsTextWithLine = true;
						}
					}
					this.TickDeltaTime = 0f;
				}
			}
		}

		// Token: 0x06044E4E RID: 282190 RVA: 0x011EE7A8 File Offset: 0x011EC9A8
		private void OnUpdateInternal(float progress)
		{
			ULGUIPlayTween_Int ulguiplayTween_Int = this.TextPlayTweenComp.GetPlayTween() as ULGUIPlayTween_Int;
			int num = (int)Math.Round((double)(progress * (float)(ulguiplayTween_Int.to - ulguiplayTween_Int.from))) + ulguiplayTween_Int.from;
			if (this.Progress < num)
			{
				this.Progress = num;
				string fontPrefix = this.FontPrefix;
				string text = ModelBase<DigitalScreenModel>.Instance.Text;
				string str = fontPrefix + ((text != null) ? text.Substring(this.TextStart, this.Progress - this.TextStart) : null) + "</size>";
				string fontPrefix2 = this.FontPrefix;
				string text2 = ModelBase<DigitalScreenModel>.Instance.Text;
				string str2 = fontPrefix2 + ((text2 != null) ? text2.Substring(this.TextStart, this.Progress - this.TextStart) : null) + "_</size>";
				if (this.ContentPos == 1)
				{
					this.LeftTextWithLine = this.LeftText + str2;
					this.LeftTextWithoutLine = this.LeftText + str;
					UUIText text3 = base.GetText(1);
					if (text3 == null)
					{
						return;
					}
					text3.SetText(this.LeftTextWithLine, true);
					return;
				}
				else if (this.ContentPos == 0)
				{
					this.MiddleTextWithLine = this.MiddleText + str2;
					this.MiddleTextWithoutLine = this.MiddleText + str;
					UUIText text4 = base.GetText(2);
					if (text4 == null)
					{
						return;
					}
					text4.SetText(this.MiddleTextWithLine, true);
				}
			}
		}

		// Token: 0x06044E4F RID: 282191 RVA: 0x011EE8F8 File Offset: 0x011ECAF8
		private void InitInfo()
		{
			this.CurLine = -1;
			this.LineCount = ModelBase<DigitalScreenModel>.Instance.StartTimes.Length;
			this.From = 0;
			if (!StringUtils.IsBlank(ModelBase<DigitalScreenModel>.Instance.BackgroundPicture))
			{
				base.SetTextureByPath(ModelBase<DigitalScreenModel>.Instance.BackgroundPicture, base.GetTexture(3), null, null);
			}
			if (ModelBase<DigitalScreenModel>.Instance.ViewType == 0 && !StringUtils.IsBlank(ModelBase<DigitalScreenModel>.Instance.LogoIcon))
			{
				this.SetSpriteByPath(ModelBase<DigitalScreenModel>.Instance.LogoIcon, base.GetSprite(4), false, null, null);
			}
			this.LeftTextWithoutLine = "";
			this.LeftTextWithLine = "_";
			this.MiddleTextWithoutLine = "";
			this.MiddleTextWithLine = "_";
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetText("", true);
			}
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.SetText("", true);
			}
			UUIText text3 = base.GetText(2);
			if (text3 != null)
			{
				text3.SetCustomMaterialScalarParameter(DigitalScreenaView.factor, ModelBase<DigitalScreenModel>.Instance.TextFactor);
			}
			UUIText text4 = base.GetText(1);
			if (text4 == null)
			{
				return;
			}
			text4.SetCustomMaterialScalarParameter(DigitalScreenaView.factor, ModelBase<DigitalScreenModel>.Instance.TextFactor);
		}

		// Token: 0x06044E50 RID: 282192 RVA: 0x011EEA34 File Offset: 0x011ECC34
		private void SetTweenAndPlay(int from, int to, float time, int startDelay)
		{
			ULGUIPlayTweenComponent textPlayTweenComp = this.TextPlayTweenComp;
			ULGUIPlayTween_Int ulguiplayTween_Int = ((textPlayTweenComp != null) ? textPlayTweenComp.GetPlayTween() : null) as ULGUIPlayTween_Int;
			if (ulguiplayTween_Int == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiManager;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "[DigitalScreenaView] SetTweenAndPlay 获取 ULGUIPlayTween_Int 失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("hasComp", this.TextPlayTweenComp != null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			ulguiplayTween_Int.from = from;
			ulguiplayTween_Int.to = to;
			ulguiplayTween_Int.duration = time;
			ulguiplayTween_Int.startDelay = (float)startDelay;
			this.TextPlayTweenComp.Play();
			this.From = to;
			this.IsTweening = true;
			ULTweener tweener = ulguiplayTween_Int.GetTweener();
			if (tweener != null)
			{
				this.OnUpdateDelegate = new Action<float>(this.OnUpdateInternal);
				ULTweener ultweener = tweener;
				FTweenerFloatDynamicDelegate ftweenerFloatDynamicDelegate = global::DelegateUtils.ToManualReleaseDelegate<FTweenerFloatDynamicDelegate>(new Action<float>(this.OnUpdateInternal));
				ultweener.OnUpdate(ftweenerFloatDynamicDelegate);
			}
		}

		// Token: 0x06044E51 RID: 282193 RVA: 0x011EEB04 File Offset: 0x011ECD04
		private void SetMultiLineTextAnimTimer()
		{
			this.TimerHandleNextLine = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.SetMultiLineWaitingSkipTimer();
			}, (float)((int)Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)ModelBase<DigitalScreenModel>.Instance.DuringTimes[this.CurLine])), null, null, true, 1f);
		}

		// Token: 0x06044E52 RID: 282194 RVA: 0x011EEB54 File Offset: 0x011ECD54
		private void SetMultiLineWaitingSkipTimer()
		{
			if (this.CurLine >= this.LineCount)
			{
				return;
			}
			this.IsTweening = false;
			ULGUIPlayTweenComponent textPlayTweenComp = this.TextPlayTweenComp;
			ULGUIPlayTween ulguiplayTween = (textPlayTweenComp != null) ? textPlayTweenComp.GetPlayTween() : null;
			ULTweener ultweener = (ulguiplayTween != null) ? ulguiplayTween.GetTweener() : null;
			if (ultweener != null)
			{
				ULTweener ultweener2 = ultweener;
				FTweenerFloatDynamicDelegate ftweenerFloatDynamicDelegate = null;
				ultweener2.OnUpdate(ftweenerFloatDynamicDelegate);
				if (this.OnUpdateDelegate != null)
				{
					global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.OnUpdateInternal));
					this.OnUpdateDelegate = null;
				}
			}
			if (ModelBase<DigitalScreenModel>.Instance.DelayTimes[this.CurLine] == 0f)
			{
				this.ResumeNextLine();
				return;
			}
			this.TimerHandleNextLine = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.ResumeNextLine();
			}, (float)((int)Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)ModelBase<DigitalScreenModel>.Instance.DelayTimes[this.CurLine])), null, null, true, 1f);
		}

		// Token: 0x06044E53 RID: 282195 RVA: 0x011EEC28 File Offset: 0x011ECE28
		private void ResumeNextLine()
		{
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText(this.LeftTextWithoutLine, true);
			}
			UUIText text2 = base.GetText(2);
			if (text2 != null)
			{
				text2.SetText(this.MiddleTextWithoutLine, true);
			}
			this.CurLine++;
			if (this.CurLine >= ModelBase<DigitalScreenModel>.Instance.Size)
			{
				return;
			}
			this.ContentPos = ((ModelBase<DigitalScreenModel>.Instance.ContentPos[this.CurLine] != 0) ? 1 : 0);
			this.TextStart = this.Progress;
			this.LeftText = this.LeftTextWithoutLine;
			this.MiddleText = this.MiddleTextWithoutLine;
			this.FontPrefix = "<size=" + ModelBase<DigitalScreenModel>.Instance.Font[this.CurLine].ToString() + ">";
			this.SetTweenAndPlay(this.From, this.From + ModelBase<DigitalScreenModel>.Instance.TextLength[this.CurLine], ModelBase<DigitalScreenModel>.Instance.DuringTimes[this.CurLine], 0);
			this.SetMultiLineTextAnimTimer();
		}

		// Token: 0x06044E54 RID: 282196 RVA: 0x011EED34 File Offset: 0x011ECF34
		protected override UniTask OnBeforeHideAsync()
		{
			DigitalScreenaView.<OnBeforeHideAsync>d__37 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<DigitalScreenaView.<OnBeforeHideAsync>d__37>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044E55 RID: 282197 RVA: 0x011EED77 File Offset: 0x011ECF77
		protected override void OnBeforeDestroy()
		{
			if (this.OnUpdateDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.OnUpdateInternal));
				this.OnUpdateDelegate = null;
			}
		}

		// Token: 0x0402666E RID: 157294
		private static readonly FName factor = new FName("factor");

		// Token: 0x0402666F RID: 157295
		private const string FONTSUFFIX = "</size>";

		// Token: 0x04026670 RID: 157296
		private const string LOOP_DIGITAL_SCREEN = "play_ui_digital_screen";

		// Token: 0x04026671 RID: 157297
		[Nullable(2)]
		private ULGUIPlayTweenComponent TextPlayTweenComp;

		// Token: 0x04026672 RID: 157298
		private int CurLine;

		// Token: 0x04026673 RID: 157299
		private int LineCount = 1;

		// Token: 0x04026674 RID: 157300
		private int From = 1;

		// Token: 0x04026675 RID: 157301
		private string LeftText = "";

		// Token: 0x04026676 RID: 157302
		private string MiddleText = "";

		// Token: 0x04026677 RID: 157303
		private int ContentPos;

		// Token: 0x04026678 RID: 157304
		private string LeftTextWithLine = "";

		// Token: 0x04026679 RID: 157305
		private string LeftTextWithoutLine = "";

		// Token: 0x0402667A RID: 157306
		private string MiddleTextWithLine = "";

		// Token: 0x0402667B RID: 157307
		private string MiddleTextWithoutLine = "";

		// Token: 0x0402667C RID: 157308
		private bool IsTweening;

		// Token: 0x0402667D RID: 157309
		private bool IsTextWithLine;

		// Token: 0x0402667E RID: 157310
		private int Progress;

		// Token: 0x0402667F RID: 157311
		private int TextStart;

		// Token: 0x04026680 RID: 157312
		private string FontPrefix = "";

		// Token: 0x04026681 RID: 157313
		private float TickDeltaTime;

		// Token: 0x04026682 RID: 157314
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04026683 RID: 157315
		[Nullable(2)]
		private TimerHandle TimerHandleCloseUi;

		// Token: 0x04026684 RID: 157316
		[Nullable(2)]
		private TimerHandle TimerHandleNextLine;

		// Token: 0x04026685 RID: 157317
		[Nullable(2)]
		private Action<float> OnUpdateDelegate;

		// Token: 0x0200CBD8 RID: 52184
		[NullableContext(0)]
		private class EDigitalScreenView
		{
			// Token: 0x0403E850 RID: 256080
			public const int ButtonMask = 0;

			// Token: 0x0403E851 RID: 256081
			public const int TextName = 1;

			// Token: 0x0403E852 RID: 256082
			public const int TextList = 2;

			// Token: 0x0403E853 RID: 256083
			public const int TextureBg = 3;

			// Token: 0x0403E854 RID: 256084
			public const int LogoIcon = 4;
		}
	}
}
