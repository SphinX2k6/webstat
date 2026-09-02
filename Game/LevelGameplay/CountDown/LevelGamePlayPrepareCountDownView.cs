using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.CountDown
{
	// Token: 0x02006F25 RID: 28453
	public class LevelGamePlayPrepareCountDownView : UiViewBase
	{
		// Token: 0x06044E74 RID: 282228 RVA: 0x011EF534 File Offset: 0x011ED734
		[NullableContext(1)]
		public LevelGamePlayPrepareCountDownView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044E75 RID: 282229 RVA: 0x011EF544 File Offset: 0x011ED744
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044E76 RID: 282230 RVA: 0x011EF5D0 File Offset: 0x011ED7D0
		protected override void OnStart()
		{
			ILevelGamePlayPrepareCountDownViewParams levelGamePlayPrepareCountDownViewParams = this.OpenParam as ILevelGamePlayPrepareCountDownViewParams;
			this.CountDownNum = levelGamePlayPrepareCountDownViewParams.CountDownNum;
			this.SetNumText();
			if (levelGamePlayPrepareCountDownViewParams != null && levelGamePlayPrepareCountDownViewParams.TidText != null)
			{
				string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(levelGamePlayPrepareCountDownViewParams.TidText);
				UUIText text = base.GetText(2);
				if (text != null)
				{
					text.SetText(configTextByKey, true);
				}
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
		}

		// Token: 0x06044E77 RID: 282231 RVA: 0x011EF654 File Offset: 0x011ED854
		protected override void OnAfterShow()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Start01", false, null, false);
			}
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_fx_com_count_number");
		}

		// Token: 0x06044E78 RID: 282232 RVA: 0x011EF694 File Offset: 0x011ED894
		[NullableContext(1)]
		private void OnSequenceClose(string sequenceName)
		{
			if (!(sequenceName == "Start01"))
			{
				if (!(sequenceName == "Start02"))
				{
					return;
				}
				base.CloseMe(null);
				return;
			}
			else
			{
				this.CountDownNum--;
				if (this.CountDownNum > 0)
				{
					this.SetNumText();
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer != null)
					{
						levelSequencePlayer.PlayLevelSequenceByName("Start01", false, null, false);
					}
					Singleton<AudioSystem>.Instance.PostEvent("play_ui_fx_com_count_number");
					return;
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.LevelGamePlayPrepareCountDownEnd);
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null)
				{
					levelSequencePlayer2.PlayLevelSequenceByName("Start02", false, null, false);
				}
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_fx_com_count_start");
				return;
			}
		}

		// Token: 0x06044E79 RID: 282233 RVA: 0x011EF759 File Offset: 0x011ED959
		private void SetNumText()
		{
			UUIArtText artText = base.GetArtText(0);
			if (artText != null)
			{
				artText.SetText(this.CountDownNum.ToString());
			}
			UUIArtText artText2 = base.GetArtText(1);
			if (artText2 == null)
			{
				return;
			}
			artText2.SetText(this.CountDownNum.ToString());
		}

		// Token: 0x04026699 RID: 157337
		private int CountDownNum = 3;

		// Token: 0x0402669A RID: 157338
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200CBDD RID: 52189
		private class EViewComponent
		{
			// Token: 0x0403E864 RID: 256100
			public const int NumText = 0;

			// Token: 0x0403E865 RID: 256101
			public const int NumText2 = 1;

			// Token: 0x0403E866 RID: 256102
			public const int CustomText = 2;
		}
	}
}
