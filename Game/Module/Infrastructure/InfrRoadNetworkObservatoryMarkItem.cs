using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C6C RID: 23660
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrRoadNetworkObservatoryMarkItem : UiPanelBase
	{
		// Token: 0x0603BCA3 RID: 244899 RVA: 0x00F285E4 File Offset: 0x00F267E4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickBtnToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BCA4 RID: 244900 RVA: 0x00F286CC File Offset: 0x00F268CC
		protected override void OnStart()
		{
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
			this.SeqPlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
			this.Refresh();
		}

		// Token: 0x0603BCA5 RID: 244901 RVA: 0x00F28700 File Offset: 0x00F26900
		protected override void OnAfterShow()
		{
			if (!this.NeedPlayFinishSeq)
			{
				LevelSequencePlayer seqPlayer = this.SeqPlayer;
				if (seqPlayer == null)
				{
					return;
				}
				seqPlayer.PlayLevelSequenceByName("Start", false, null, false);
			}
		}

		// Token: 0x0603BCA6 RID: 244902 RVA: 0x00F28735 File Offset: 0x00F26935
		public void Refresh()
		{
			this.RefreshIcon();
			this.RefreshStageName();
		}

		// Token: 0x0603BCA7 RID: 244903 RVA: 0x00F28743 File Offset: 0x00F26943
		private void RefreshIcon()
		{
			if (ModelBase<InfrastructureModel>.Instance.FireLevel == ConfigBase<InfrastructureConfig>.Instance.GetMaxLevel())
			{
				UUIItem item = base.GetItem(2);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIItem item2 = base.GetItem(1);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(true);
			}
		}

		// Token: 0x0603BCA8 RID: 244904 RVA: 0x00F28780 File Offset: 0x00F26980
		private void RefreshStageName()
		{
			InfrLevel? levelConfigById = ConfigBase<InfrastructureConfig>.Instance.GetLevelConfigById(ModelBase<InfrastructureModel>.Instance.FireLevel);
			if (levelConfigById != null)
			{
				UUIText text = base.GetText(3);
				if (text == null)
				{
					return;
				}
				text.ShowTextNew(levelConfigById.Value.Description);
				return;
			}
			else
			{
				UUIText text2 = base.GetText(3);
				if (text2 == null)
				{
					return;
				}
				text2.SetUIActive(false);
				return;
			}
		}

		// Token: 0x0603BCA9 RID: 244905 RVA: 0x00F287DE File Offset: 0x00F269DE
		public void SetOnClickToggleCb(Action cb)
		{
			this.OnClickToggleCb = cb;
		}

		// Token: 0x0603BCAA RID: 244906 RVA: 0x00F287E7 File Offset: 0x00F269E7
		public void SetNeedPlayFinishSeq(bool needPlayFinishSeq)
		{
			this.NeedPlayFinishSeq = needPlayFinishSeq;
		}

		// Token: 0x0603BCAB RID: 244907 RVA: 0x00F287F0 File Offset: 0x00F269F0
		private void OnClickBtnToggle(EToggleState _)
		{
			Action onClickToggleCb = this.OnClickToggleCb;
			if (onClickToggleCb == null)
			{
				return;
			}
			onClickToggleCb();
		}

		// Token: 0x0603BCAC RID: 244908 RVA: 0x00F28802 File Offset: 0x00F26A02
		public void SetSelected(bool selected)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			if (selected)
			{
				Action onClickToggleCb = this.OnClickToggleCb;
				if (onClickToggleCb == null)
				{
					return;
				}
				onClickToggleCb();
			}
		}

		// Token: 0x0603BCAD RID: 244909 RVA: 0x00F28834 File Offset: 0x00F26A34
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Finish")
			{
				Action onFinishPlayEnd = this.OnFinishPlayEnd;
				if (onFinishPlayEnd != null)
				{
					onFinishPlayEnd();
				}
				this.OnFinishPlayEnd = null;
			}
		}

		// Token: 0x0603BCAE RID: 244910 RVA: 0x00F2885C File Offset: 0x00F26A5C
		public void ShowMarkFinish(Action cb)
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.PlayLevelSequenceByName("Finish", false, null, false);
			}
			this.OnFinishPlayEnd = cb;
		}

		// Token: 0x0603BCAF RID: 244911 RVA: 0x00F28894 File Offset: 0x00F26A94
		public void ShowLevelUpSeq()
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer == null)
			{
				return;
			}
			seqPlayer.PlayLevelSequenceByName("LevelUp", false, null, false);
		}

		// Token: 0x0402198E RID: 137614
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0402198F RID: 137615
		private bool NeedPlayFinishSeq;

		// Token: 0x04021990 RID: 137616
		private Action OnClickToggleCb;

		// Token: 0x04021991 RID: 137617
		private Action OnFinishPlayEnd;

		// Token: 0x0200BD19 RID: 48409
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403A470 RID: 238704
			public const int Toggle = 0;

			// Token: 0x0403A471 RID: 238705
			public const int PanelLock = 1;

			// Token: 0x0403A472 RID: 238706
			public const int PanelNor = 2;

			// Token: 0x0403A473 RID: 238707
			public const int TextStageName = 3;
		}
	}
}
