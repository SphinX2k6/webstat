using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067BF RID: 26559
	public class DockyardQteSkipPanel : UiPanelBase, IDockyardLeftTipsInterface
	{
		// Token: 0x1700A110 RID: 41232
		// (get) Token: 0x06042425 RID: 271397 RVA: 0x010FF4CC File Offset: 0x010FD6CC
		// (set) Token: 0x06042426 RID: 271398 RVA: 0x010FF4D4 File Offset: 0x010FD6D4
		public bool LockState { get; set; }

		// Token: 0x06042427 RID: 271399 RVA: 0x010FF4E0 File Offset: 0x010FD6E0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnContinueClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnExitClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06042428 RID: 271400 RVA: 0x010FF5CA File Offset: 0x010FD7CA
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(delegate(string eventName)
			{
				if (eventName == "Hide")
				{
					this.SetActive(false);
				}
			}, false);
		}

		// Token: 0x06042429 RID: 271401 RVA: 0x010FF5F8 File Offset: 0x010FD7F8
		public void SetPanelVisible(bool bVisible)
		{
			if (this.LockState)
			{
				return;
			}
			if (bVisible)
			{
				this.LevelSequencePlayer.StopCurrentSequence(true, true);
				this.LevelSequencePlayer.PlaySequencePurely("Show", false, false, null, null, false);
				this.SetActive(true);
				return;
			}
			this.LevelSequencePlayer.StopCurrentSequence(true, true);
			this.LevelSequencePlayer.PlaySequencePurely("Hide", false, false, null, null, false);
		}

		// Token: 0x0604242A RID: 271402 RVA: 0x010FF66D File Offset: 0x010FD86D
		public void SetQtePanelText(int currentCount, int maxCount)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Fishing_QTE_Unfish", new <>z__ReadOnlySingleElementList<object>(maxCount - currentCount));
		}

		// Token: 0x0604242B RID: 271403 RVA: 0x010FF692 File Offset: 0x010FD892
		public void SetQtePanelTextVisible(bool bVisible)
		{
			base.GetText(0).SetUIActive(bVisible);
		}

		// Token: 0x0604242C RID: 271404 RVA: 0x010FF6A4 File Offset: 0x010FD8A4
		public void SetButtonContinueVisible(bool bVisible)
		{
			base.GetButton(1).RootUIComp.Get().SetUIActive(bVisible);
		}

		// Token: 0x0604242D RID: 271405 RVA: 0x010FF6CC File Offset: 0x010FD8CC
		public void SetButtonExitVisible(bool bVisible)
		{
			base.GetButton(2).RootUIComp.Get().SetUIActive(bVisible);
		}

		// Token: 0x0604242E RID: 271406 RVA: 0x010FF6F3 File Offset: 0x010FD8F3
		private void OnContinueClick()
		{
			Action continueFunc = this.ContinueFunc;
			if (continueFunc == null)
			{
				return;
			}
			continueFunc();
		}

		// Token: 0x0604242F RID: 271407 RVA: 0x010FF705 File Offset: 0x010FD905
		private void OnExitClick()
		{
			Action exitFunc = this.ExitFunc;
			if (exitFunc == null)
			{
				return;
			}
			exitFunc();
		}

		// Token: 0x04024E64 RID: 151140
		[Nullable(1)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04024E65 RID: 151141
		[Nullable(2)]
		public Action ContinueFunc;

		// Token: 0x04024E66 RID: 151142
		[Nullable(2)]
		public Action ExitFunc;

		// Token: 0x0200C800 RID: 51200
		private class EComponentDefine
		{
			// Token: 0x0403D8E4 RID: 252132
			public const int Content = 0;

			// Token: 0x0403D8E5 RID: 252133
			public const int Continue = 1;

			// Token: 0x0403D8E6 RID: 252134
			public const int Exit = 2;
		}
	}
}
