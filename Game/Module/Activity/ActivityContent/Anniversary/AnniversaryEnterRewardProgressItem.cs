using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Anniversary
{
	// Token: 0x020069E4 RID: 27108
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AnniversaryEnterRewardProgressItem : GridProxyAbstract<AnniversarySubActivityDataBase>
	{
		// Token: 0x06043309 RID: 275209 RVA: 0x01143FE4 File Offset: 0x011421E4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x0604330A RID: 275210 RVA: 0x01144020 File Offset: 0x01142220
		[NullableContext(1)]
		public override void Refresh(AnniversarySubActivityDataBase data, bool isSelected, int gridIndex)
		{
			ValueTuple<int, int> currentProgress = data.GetCurrentProgress();
			int item = currentProgress.Item1;
			int item2 = currentProgress.Item2;
			UUIText text = base.GetText(1);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(item);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			Activity? activityConfig = ConfigBase<ActivityConfig>.Instance.GetActivityConfig(data.GetActivityId());
			UUIText text2 = base.GetText(0);
			if (text2 == null)
			{
				return;
			}
			text2.ShowTextNew((activityConfig != null) ? activityConfig.Value.Title : "");
		}

		// Token: 0x0200C95F RID: 51551
		private class EComponents
		{
			// Token: 0x0403DEE8 RID: 253672
			public const int TxtTitle = 0;

			// Token: 0x0403DEE9 RID: 253673
			public const int TxtValue = 1;
		}
	}
}
