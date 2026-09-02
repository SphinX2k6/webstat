using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006078 RID: 24696
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleUiHoverTipsC : BattleChildView
	{
		// Token: 0x0603E467 RID: 255079 RVA: 0x00FE650C File Offset: 0x00FE470C
		protected override UniTask InitializeAsync(object param = null)
		{
			BattleUiHoverTipsC.<InitializeAsync>d__6 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<BattleUiHoverTipsC.<InitializeAsync>d__6>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E468 RID: 255080 RVA: 0x00FE6550 File Offset: 0x00FE4750
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E469 RID: 255081 RVA: 0x00FE65BC File Offset: 0x00FE47BC
		protected override void OnStart()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetAnchorHAlign(UIAnchorHorizontalAlign.Center);
			}
			UUIItem rootItem2 = this.RootItem;
			if (rootItem2 != null)
			{
				rootItem2.SetAnchorVAlign(UIAnchorVerticalAlign.Top);
			}
			UUIItem rootItem3 = this.RootItem;
			if (rootItem3 != null)
			{
				rootItem3.SetAnchorOffsetX(0f);
			}
			UUIItem rootItem4 = this.RootItem;
			if (rootItem4 != null)
			{
				rootItem4.SetAnchorOffsetY(0f);
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(delegate(string sequenceName)
			{
				if (sequenceName == "Close")
				{
					this.SetActive(false);
				}
			}, false);
		}

		// Token: 0x0603E46A RID: 255082 RVA: 0x00FE6644 File Offset: 0x00FE4844
		[NullableContext(1)]
		public void CreateAndShow(UUIItem parent, IBattleUiHoverTipsC info)
		{
			string resourceId = "UiItem_HoverTipsC";
			if (this.Created)
			{
				this.UpdateInfo(info);
				this.SetActive(true);
				this.StartCountdown();
				return;
			}
			base.NewByResourceId(parent, resourceId, false, null).ContinueWith(delegate()
			{
				this.Created = true;
				this.UpdateInfo(info);
				this.StartCountdown();
			}).Forget();
		}

		// Token: 0x0603E46B RID: 255083 RVA: 0x00FE66B0 File Offset: 0x00FE48B0
		protected override void OnShowBattleChildView()
		{
			this.LevelSequencePlayer.StopCurrentSequence(false, false);
			this.LevelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
		}

		// Token: 0x0603E46C RID: 255084 RVA: 0x00FE66E7 File Offset: 0x00FE48E7
		[NullableContext(1)]
		public void UpdateInfo(IBattleUiHoverTipsC info)
		{
			this.Info = info;
			if (!this.Created)
			{
				return;
			}
			BattleUiInfoItem infoItem = this.InfoItem;
			if (infoItem == null)
			{
				return;
			}
			infoItem.Refresh(info);
		}

		// Token: 0x0603E46D RID: 255085 RVA: 0x00FE670C File Offset: 0x00FE490C
		private void StartCountdown()
		{
			int num = 8000;
			this.TimerHandle = TimerSystem.Instance.Delay(new TTimerAction(this.OnTimerEnd), (float)num, null, null, true, 1f);
		}

		// Token: 0x0603E46E RID: 255086 RVA: 0x00FE6748 File Offset: 0x00FE4948
		public void EndShow()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.PlayLevelSequenceByName("Close", false, null, false);
		}

		// Token: 0x0603E46F RID: 255087 RVA: 0x00FE67A8 File Offset: 0x00FE49A8
		private void OnTimerEnd(float _ = 0f)
		{
			if (this.TimerHandle == null)
			{
				return;
			}
			this.EndShow();
			Singleton<EventSystem>.Instance.Emit(EEventName.BattleUiToggleMoraleBuffInfo);
		}

		// Token: 0x0603E470 RID: 255088 RVA: 0x00FE67C9 File Offset: 0x00FE49C9
		protected override void OnBeforeDestroy()
		{
			this.OnTimerEnd(0f);
		}

		// Token: 0x04022E8B RID: 142987
		private bool Created;

		// Token: 0x04022E8C RID: 142988
		private TimerHandle TimerHandle;

		// Token: 0x04022E8D RID: 142989
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022E8E RID: 142990
		private IBattleUiHoverTipsC Info;

		// Token: 0x04022E8F RID: 142991
		private BattleUiInfoItem InfoItem;

		// Token: 0x0200C145 RID: 49477
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B850 RID: 243792
			SpriteBg,
			// Token: 0x0403B851 RID: 243793
			ItemInfo
		}
	}
}
