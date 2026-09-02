using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E9B RID: 28315
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingQteTipsItem : UiPanelBase
	{
		// Token: 0x06044AAA RID: 281258 RVA: 0x011D93B0 File Offset: 0x011D75B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044AAB RID: 281259 RVA: 0x011D93F8 File Offset: 0x011D75F8
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
		}

		// Token: 0x06044AAC RID: 281260 RVA: 0x011D9423 File Offset: 0x011D7623
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x06044AAD RID: 281261 RVA: 0x011D9425 File Offset: 0x011D7625
		protected override void OnBeforeHide()
		{
			this.InProgressType = EFishingTipsType.None;
		}

		// Token: 0x06044AAE RID: 281262 RVA: 0x011D942E File Offset: 0x011D762E
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x06044AAF RID: 281263 RVA: 0x011D9448 File Offset: 0x011D7648
		private void ShowTips(string sequenceName)
		{
			if (this.LevelSequencePlayer.GetCurrentSequence() == sequenceName)
			{
				this.LevelSequencePlayer.ReplaySequenceByKey(sequenceName);
			}
			else
			{
				this.LevelSequencePlayer.StopPlayingSequence(false, true);
				this.LevelSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
			}
			this.SetActive(true);
		}

		// Token: 0x06044AB0 RID: 281264 RVA: 0x011D94A4 File Offset: 0x011D76A4
		private void OnSequenceClose(string sequenceName)
		{
			EFishingTipsType efishingTipsType = EFishingTipsType.None;
			if (sequenceName == "Fail")
			{
				efishingTipsType = EFishingTipsType.Miss;
			}
			else if (sequenceName == "QteSuccess")
			{
				efishingTipsType = EFishingTipsType.QteOn;
			}
			else if (sequenceName == "Success")
			{
				efishingTipsType = EFishingTipsType.GetFish;
			}
			if (efishingTipsType == this.InProgressType)
			{
				Action sequenceCallback = this.SequenceCallback;
				if (sequenceCallback != null)
				{
					sequenceCallback();
				}
				this.SequenceCallback = null;
				this.SetActive(false);
			}
		}

		// Token: 0x06044AB1 RID: 281265 RVA: 0x011D950C File Offset: 0x011D770C
		public void ShowTip(EFishingTipsType tipsType, string extraParam, [Nullable(2)] Action callback = null)
		{
			string sequenceName = "Success";
			switch (tipsType)
			{
			case EFishingTipsType.Miss:
				this.SetTipMiss();
				sequenceName = "Fail";
				break;
			case EFishingTipsType.QteOn:
				this.SetTipSuccess();
				sequenceName = "QteSuccess";
				break;
			case EFishingTipsType.GetFish:
				this.SetTipGetFish(extraParam);
				sequenceName = "Success";
				break;
			}
			if (this.SequenceCallback != null)
			{
				Action sequenceCallback = this.SequenceCallback;
				if (sequenceCallback != null)
				{
					sequenceCallback();
				}
			}
			this.SequenceCallback = callback;
			this.InProgressType = tipsType;
			this.ShowTips(sequenceName);
		}

		// Token: 0x06044AB2 RID: 281266 RVA: 0x011D958C File Offset: 0x011D778C
		private void SetTipMiss()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Fishing_QTE_Miss", Array.Empty<object>());
		}

		// Token: 0x06044AB3 RID: 281267 RVA: 0x011D95A9 File Offset: 0x011D77A9
		private void SetTipSuccess()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Fishing_QTE_Success", Array.Empty<object>());
		}

		// Token: 0x06044AB4 RID: 281268 RVA: 0x011D95C6 File Offset: 0x011D77C6
		private void SetTipGetFish(string count)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Fishing_QTE_Catch", new <>z__ReadOnlySingleElementList<object>(count));
		}

		// Token: 0x040263AE RID: 156590
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040263AF RID: 156591
		protected EFishingTipsType InProgressType;

		// Token: 0x040263B0 RID: 156592
		[Nullable(2)]
		protected Action SequenceCallback;

		// Token: 0x0200CB67 RID: 52071
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403E6C8 RID: 255688
			public const int TxtTips = 0;
		}
	}
}
