using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.CountDown
{
	// Token: 0x02006F21 RID: 28449
	public class LevelGamePlayMotorPrepareCountDownView : UiViewBase, IUiViewResource
	{
		// Token: 0x06044E61 RID: 282209 RVA: 0x011EF3D5 File Offset: 0x011ED5D5
		[NullableContext(1)]
		public LevelGamePlayMotorPrepareCountDownView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044E62 RID: 282210 RVA: 0x011EF3E0 File Offset: 0x011ED5E0
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

		// Token: 0x06044E63 RID: 282211 RVA: 0x011EF428 File Offset: 0x011ED628
		[NullableContext(1)]
		public string GetExtraResourceId([Nullable(2)] object param)
		{
			ILevelGamePlayPrepareCountDownViewParams levelGamePlayPrepareCountDownViewParams = param as ILevelGamePlayPrepareCountDownViewParams;
			if (levelGamePlayPrepareCountDownViewParams == null || levelGamePlayPrepareCountDownViewParams.UiStyle == null)
			{
				return "";
			}
			string result;
			if (LevelGamePlayPrepareCountDownDefine.countDownUiStyleToResourceId.TryGetValue(levelGamePlayPrepareCountDownViewParams.UiStyle.Value, out result))
			{
				return result;
			}
			return "";
		}

		// Token: 0x06044E64 RID: 282212 RVA: 0x011EF480 File Offset: 0x011ED680
		protected override void OnStart()
		{
			ILevelGamePlayPrepareCountDownViewParams levelGamePlayPrepareCountDownViewParams = this.OpenParam as ILevelGamePlayPrepareCountDownViewParams;
			if (levelGamePlayPrepareCountDownViewParams != null && levelGamePlayPrepareCountDownViewParams.TidText != null)
			{
				string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(levelGamePlayPrepareCountDownViewParams.TidText);
				UUIText text = base.GetText(0);
				if (text == null)
				{
					return;
				}
				text.SetText(configTextByKey, true);
			}
		}

		// Token: 0x06044E65 RID: 282213 RVA: 0x011EF4C8 File Offset: 0x011ED6C8
		protected override void OnAfterPlayStartSequence()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.LevelGamePlayPrepareCountDownEnd);
			base.CloseMe(null);
		}

		// Token: 0x0200CBDC RID: 52188
		private class EViewComponent
		{
			// Token: 0x0403E863 RID: 256099
			public const int TextTip = 0;
		}
	}
}
