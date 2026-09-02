using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B57 RID: 23383
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreRecord : UiPanelBase
	{
		// Token: 0x0603B27E RID: 242302 RVA: 0x00EF7EC8 File Offset: 0x00EF60C8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0603B27F RID: 242303 RVA: 0x00EF7F5D File Offset: 0x00EF615D
		protected override void OnBeforeDestroy()
		{
			base.OnBeforeDestroy();
			this.DisposeTweener();
			this.DisposeSeqPlayer();
		}

		// Token: 0x0603B280 RID: 242304 RVA: 0x00EF7F74 File Offset: 0x00EF6174
		public void Refresh(IRewardExploreRecord record)
		{
			string titleTextId = record.TitleTextId;
			bool flag = !StringUtils.IsEmpty(titleTextId);
			if (flag)
			{
				this.SetTitleText(titleTextId);
			}
			this.SetTitleTextVisible(flag);
			this.SetNewRecordItemVisible(record.IsNewRecord);
			if (record.RecordRollingTo != null)
			{
				this.SetRollingScore(record.RecordRollingTo.Value);
				return;
			}
			this.SetRecordText(record.Record);
		}

		// Token: 0x0603B281 RID: 242305 RVA: 0x00EF7FE0 File Offset: 0x00EF61E0
		private void SetTitleText(string titleTextId)
		{
			UUIText text = base.GetText(0);
			if (StringUtils.IsEmpty(titleTextId))
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, titleTextId, Array.Empty<object>());
		}

		// Token: 0x0603B282 RID: 242306 RVA: 0x00EF800F File Offset: 0x00EF620F
		private void SetTitleTextVisible(bool bVisible)
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(bVisible);
		}

		// Token: 0x0603B283 RID: 242307 RVA: 0x00EF8023 File Offset: 0x00EF6223
		private void SetRecordText(string record)
		{
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(record, true);
		}

		// Token: 0x0603B284 RID: 242308 RVA: 0x00EF8038 File Offset: 0x00EF6238
		private void SetNewRecordItemVisible(bool bVisible)
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(bVisible);
			}
			if (bVisible)
			{
				if (this.SeqPlayer == null)
				{
					this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
				}
				this.SeqPlayer.PlayLevelSequenceByName("Start", false, null, false);
			}
		}

		// Token: 0x0603B285 RID: 242309 RVA: 0x00EF8090 File Offset: 0x00EF6290
		private void SetRollingScore(int recordTo)
		{
			this.ScoreTweener = ULTweenBPLibrary.IntTo(this.RootActor, global::DelegateUtils.ToManualReleaseDelegate<FLTweenIntSetterDynamic>(new Action<int>(this.ShowRecordInTween)), 0, recordTo, 2f, 0f, LTweenEase.OutQuad);
			ULTweener scoreTweener = this.ScoreTweener;
			if (scoreTweener == null)
			{
				return;
			}
			scoreTweener.OnCompleteCallBack.Bind(new Action(this.DisposeTweener));
		}

		// Token: 0x0603B286 RID: 242310 RVA: 0x00EF80ED File Offset: 0x00EF62ED
		private void ShowRecordInTween(int value)
		{
			this.SetRecordText(value.ToString());
		}

		// Token: 0x0603B287 RID: 242311 RVA: 0x00EF80FC File Offset: 0x00EF62FC
		private void DisposeTweener()
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int>(this.ShowRecordInTween));
			ULTweener scoreTweener = this.ScoreTweener;
			if (scoreTweener != null)
			{
				scoreTweener.Kill(false);
			}
			this.ScoreTweener = null;
		}

		// Token: 0x0603B288 RID: 242312 RVA: 0x00EF8128 File Offset: 0x00EF6328
		private void DisposeSeqPlayer()
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.StopCurrentSequence(false, false);
			}
			this.SeqPlayer = null;
		}

		// Token: 0x04021592 RID: 136594
		private const float ROLLING_DURATION = 2f;

		// Token: 0x04021593 RID: 136595
		[Nullable(2)]
		private ULTweener ScoreTweener;

		// Token: 0x04021594 RID: 136596
		[Nullable(2)]
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0200BB5D RID: 47965
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04039D0E RID: 236814
			public const int TitleText = 0;

			// Token: 0x04039D0F RID: 236815
			public const int RecordText = 1;

			// Token: 0x04039D10 RID: 236816
			public const int NewRecordItem = 2;
		}
	}
}
