using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay.WriteLetter;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Letter.View
{
	// Token: 0x02005A24 RID: 23076
	[NullableContext(1)]
	[Nullable(0)]
	public class WriteLetterView : UiViewBase
	{
		// Token: 0x0603A6CF RID: 239311 RVA: 0x00ED0A1F File Offset: 0x00ECEC1F
		public WriteLetterView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A6D0 RID: 239312 RVA: 0x00ED0A34 File Offset: 0x00ECEC34
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUILayoutBase));
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
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickSkip));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickHelp));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickBlankClose));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickNextFull));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A6D1 RID: 239313 RVA: 0x00ED0C94 File Offset: 0x00ECEE94
		protected override UniTask OnBeforeStartAsync()
		{
			WriteLetterView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WriteLetterView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A6D2 RID: 239314 RVA: 0x00ED0CD8 File Offset: 0x00ECEED8
		protected override void OnBeforeDestroy()
		{
			this.BlackScreenSuppressor.Restore().Forget();
			if (this.SentFinishRequest)
			{
				return;
			}
			IWriteLetterViewOpenParam writeLetterViewOpenParam = this.OpenParam as IWriteLetterViewOpenParam;
			int? num = (writeLetterViewOpenParam != null) ? writeLetterViewOpenParam.LetterId : null;
			if (num != null)
			{
				ControllerBase<WriteLetterController>.Instance.RequestWriteLetterSaveContent(num.Value);
			}
			string text = (writeLetterViewOpenParam != null) ? writeLetterViewOpenParam.GameplayId : null;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			this.SentFinishRequest = true;
			ControllerBase<WriteLetterController>.Instance.RequestWriteLetterComplete(text);
		}

		// Token: 0x0603A6D3 RID: 239315 RVA: 0x00ED0D64 File Offset: 0x00ECEF64
		private UniTask CloseWithBlackScreen()
		{
			WriteLetterView.<CloseWithBlackScreen>d__12 <CloseWithBlackScreen>d__;
			<CloseWithBlackScreen>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseWithBlackScreen>d__.<>4__this = this;
			<CloseWithBlackScreen>d__.<>1__state = -1;
			<CloseWithBlackScreen>d__.<>t__builder.Start<WriteLetterView.<CloseWithBlackScreen>d__12>(ref <CloseWithBlackScreen>d__);
			return <CloseWithBlackScreen>d__.<>t__builder.Task;
		}

		// Token: 0x0603A6D4 RID: 239316 RVA: 0x00ED0DA8 File Offset: 0x00ECEFA8
		private void ApplyStyle(ELetterStyle letterStyle)
		{
			bool flag = letterStyle == ELetterStyle.A;
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(flag);
			}
			UUIItem item3 = base.GetItem(2);
			if (item3 != null)
			{
				item3.SetUIActive(!flag);
			}
			UUIItem item4 = base.GetItem(3);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(!flag);
		}

		// Token: 0x0603A6D5 RID: 239317 RVA: 0x00ED0E0C File Offset: 0x00ECF00C
		[NullableContext(2)]
		private void RefreshOptions(ITalkItem talkItem)
		{
			List<ITalkOption> list = (talkItem != null) ? talkItem.Options : null;
			bool flag = ((list != null) ? list.Count : 0) > 0 && this.OptionList != null;
			LetterPanel innerLetterPanel = this.InnerLetterPanel;
			if (innerLetterPanel != null && innerLetterPanel.IsAllShowTalkExhausted() && this.LastShowTalkFinishReached)
			{
				LetterPanel innerLetterPanel2 = this.InnerLetterPanel;
				if (innerLetterPanel2 != null)
				{
					innerLetterPanel2.SetNextButtonVisible(false);
				}
				UUIButtonComponent button = base.GetButton(11);
				if (button != null)
				{
					UUIItem uuiitem = button.RootUIComp.Get();
					if (uuiitem != null)
					{
						uuiitem.SetUIActive(false);
					}
				}
				if (!this.SwitchSeqStarted)
				{
					this.SwitchSeqStarted = true;
					this.PlaySwitchSequence().Forget();
				}
			}
			else
			{
				LetterPanel innerLetterPanel3 = this.InnerLetterPanel;
				if (innerLetterPanel3 != null)
				{
					innerLetterPanel3.SetNextButtonVisible(!flag);
				}
				UUIButtonComponent button2 = base.GetButton(11);
				if (button2 != null)
				{
					UUIItem uuiitem2 = button2.RootUIComp.Get();
					if (uuiitem2 != null)
					{
						uuiitem2.SetUIActive(!flag);
					}
				}
			}
			if (list != null && list.Count != 0 && this.OptionList != null)
			{
				UUIItem item = base.GetItem(5);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				this.OptionList.RefreshByData(list.ToList<ITalkOption>(), null, false);
				return;
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x0603A6D6 RID: 239318 RVA: 0x00ED0F40 File Offset: 0x00ECF140
		private UniTask PlaySwitchSequence()
		{
			WriteLetterView.<PlaySwitchSequence>d__15 <PlaySwitchSequence>d__;
			<PlaySwitchSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySwitchSequence>d__.<>4__this = this;
			<PlaySwitchSequence>d__.<>1__state = -1;
			<PlaySwitchSequence>d__.<>t__builder.Start<WriteLetterView.<PlaySwitchSequence>d__15>(ref <PlaySwitchSequence>d__);
			return <PlaySwitchSequence>d__.<>t__builder.Task;
		}

		// Token: 0x0603A6D7 RID: 239319 RVA: 0x00ED0F83 File Offset: 0x00ECF183
		private LetterOptionItem CreateOptionItem()
		{
			LetterOptionItem letterOptionItem = new LetterOptionItem();
			letterOptionItem.SetOnClick(new Action<ITalkOption>(this.OnClickOption));
			return letterOptionItem;
		}

		// Token: 0x0603A6D8 RID: 239320 RVA: 0x00ED0F9C File Offset: 0x00ECF19C
		[NullableContext(2)]
		private void OnCurrentTalkChanged(ITalkItem talkItem)
		{
			this.RefreshOptions(talkItem);
			if (talkItem == null)
			{
				return;
			}
			ITalkItemDialog talkItemDialog = talkItem as ITalkItemDialog;
			bool flag;
			if (talkItemDialog == null)
			{
				flag = false;
			}
			else
			{
				ITalkItemStyle style = talkItemDialog.Style;
				ETalkItemStyle? etalkItemStyle = (style != null) ? new ETalkItemStyle?(style.Type) : null;
				ETalkItemStyle etalkItemStyle2 = ETalkItemStyle.InnerVoice;
				flag = (etalkItemStyle.GetValueOrDefault() == etalkItemStyle2 & etalkItemStyle != null);
			}
			if (flag)
			{
				return;
			}
			IWriteLetterViewOpenParam writeLetterViewOpenParam = this.OpenParam as IWriteLetterViewOpenParam;
			int? num = (writeLetterViewOpenParam != null) ? writeLetterViewOpenParam.LetterId : null;
			if (num == null)
			{
				return;
			}
			ControllerBase<WriteLetterController>.Instance.RecordWriteLetterContent(num.Value, talkItem);
		}

		// Token: 0x0603A6D9 RID: 239321 RVA: 0x00ED1034 File Offset: 0x00ECF234
		private void OnClickOption(ITalkOption option)
		{
			List<ActionInfo> actions = option.Actions;
			ActionInfo actionInfo;
			if (actions == null)
			{
				actionInfo = null;
			}
			else
			{
				actionInfo = actions.Find((ActionInfo action) => action.Name == EAction.JumpTalk);
			}
			ActionInfo actionInfo2 = actionInfo;
			if (actionInfo2 == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[WriteLetterView] 选项未配置JumpTalk";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TidTalkOption", option.TidTalkOption);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			JumpTalk jumpTalk = actionInfo2.Params as JumpTalk;
			LetterPanel innerLetterPanel = this.InnerLetterPanel;
			if (innerLetterPanel == null)
			{
				return;
			}
			innerLetterPanel.RevealTalkById(jumpTalk.TalkId);
		}

		// Token: 0x0603A6DA RID: 239322 RVA: 0x00ED10C5 File Offset: 0x00ECF2C5
		private void OnClickSkip()
		{
			LetterPanel innerLetterPanel = this.InnerLetterPanel;
			if (innerLetterPanel != null)
			{
				innerLetterPanel.SkipToFinish();
			}
			this.CloseWithBlackScreen().Forget();
		}

		// Token: 0x0603A6DB RID: 239323 RVA: 0x00ED10E4 File Offset: 0x00ECF2E4
		private void OnLastShowTalkFinished()
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.YZH;
			string message = "[WL-Finish] View.OnLastShowTalkFinished 被调用";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AlreadyReached", this.LastShowTalkFinishReached);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (this.LastShowTalkFinishReached)
			{
				return;
			}
			this.LastShowTalkFinishReached = true;
			LetterPanel innerLetterPanel = this.InnerLetterPanel;
			this.RefreshOptions((innerLetterPanel != null) ? innerLetterPanel.GetCurrentTalkItem() : null);
		}

		// Token: 0x0603A6DC RID: 239324 RVA: 0x00ED1149 File Offset: 0x00ECF349
		private void OnClickHelp()
		{
		}

		// Token: 0x0603A6DD RID: 239325 RVA: 0x00ED114B File Offset: 0x00ECF34B
		private void OnClickBlankClose()
		{
			if (!this.SwitchSeqCompleted)
			{
				return;
			}
			this.CloseWithBlackScreen().Forget();
		}

		// Token: 0x0603A6DE RID: 239326 RVA: 0x00ED1161 File Offset: 0x00ECF361
		private void OnClickNextFull()
		{
			LetterPanel innerLetterPanel = this.InnerLetterPanel;
			if (innerLetterPanel == null)
			{
				return;
			}
			innerLetterPanel.Advance();
		}

		// Token: 0x04021169 RID: 135529
		[Nullable(2)]
		private LetterPanel InnerLetterPanel;

		// Token: 0x0402116A RID: 135530
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<LetterOptionItem, ITalkOption> OptionList;

		// Token: 0x0402116B RID: 135531
		private bool SentFinishRequest;

		// Token: 0x0402116C RID: 135532
		private bool SwitchSeqStarted;

		// Token: 0x0402116D RID: 135533
		private bool SwitchSeqCompleted;

		// Token: 0x0402116E RID: 135534
		private bool LastShowTalkFinishReached;

		// Token: 0x0402116F RID: 135535
		private readonly LetterBlackScreenSuppressor BlackScreenSuppressor = new LetterBlackScreenSuppressor();

		// Token: 0x0200BA0E RID: 47630
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403978C RID: 235404
			public const int ItemBgA = 0;

			// Token: 0x0403978D RID: 235405
			public const int ItemFgA = 1;

			// Token: 0x0403978E RID: 235406
			public const int ItemBgB = 2;

			// Token: 0x0403978F RID: 235407
			public const int ItemFgB = 3;

			// Token: 0x04039790 RID: 235408
			public const int ItemLetterPanel = 4;

			// Token: 0x04039791 RID: 235409
			public const int ItemOptionPanel = 5;

			// Token: 0x04039792 RID: 235410
			public const int OptionLayout = 6;

			// Token: 0x04039793 RID: 235411
			public const int OptionToggle = 7;

			// Token: 0x04039794 RID: 235412
			public const int BtnSkip = 8;

			// Token: 0x04039795 RID: 235413
			public const int BtnHelp = 9;

			// Token: 0x04039796 RID: 235414
			public const int BtnBlankClose = 10;

			// Token: 0x04039797 RID: 235415
			public const int BtnNextFull = 11;
		}
	}
}
