using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.AdventureGuide.Views
{
	// Token: 0x020061B4 RID: 25012
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PeriodicityChallengeItem : GridProxyAbstract<IPeriodicityChallengeItem>
	{
		// Token: 0x0603F24E RID: 258638 RVA: 0x010336DC File Offset: 0x010318DC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F24F RID: 258639 RVA: 0x01033788 File Offset: 0x01031988
		protected override UniTask OnBeforeStartAsync()
		{
			PeriodicityChallengeItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PeriodicityChallengeItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F250 RID: 258640 RVA: 0x010337CC File Offset: 0x010319CC
		[NullableContext(1)]
		public override void Refresh(IPeriodicityChallengeItem data, bool isSelected, int gridIndex)
		{
			if (!data.Title)
			{
				this.PeriodicityChallengeTitleItem.SetUiActive(false);
			}
			else
			{
				this.PeriodicityChallengeTitleItem.SetUiActive(true);
				this.PeriodicityChallengeTitleItem.RefreshItem(data.Data);
			}
			if (data.TopTips != null)
			{
				this.TipsTopItem.SetUiActive(true);
				this.TipsTopItem.Refresh(data.TopTips);
			}
			else
			{
				this.TipsTopItem.SetUiActive(false);
			}
			PeriodicityChallengeDetectionItem periodicityChallengeDetectionItem = this.PeriodicityChallengeDetectionItem;
			if (periodicityChallengeDetectionItem != null)
			{
				periodicityChallengeDetectionItem.SetUiActive(true);
			}
			PeriodicityChallengeDetectionItem periodicityChallengeDetectionItem2 = this.PeriodicityChallengeDetectionItem;
			if (periodicityChallengeDetectionItem2 == null)
			{
				return;
			}
			periodicityChallengeDetectionItem2.RefreshItem(data.Data);
		}

		// Token: 0x0402373F RID: 145215
		private PeriodicityChallengeTitleItem PeriodicityChallengeTitleItem;

		// Token: 0x04023740 RID: 145216
		private PeriodicityChallengeDetectionItem PeriodicityChallengeDetectionItem;

		// Token: 0x04023741 RID: 145217
		private PeriodicityChallengeItemTopTips TipsTopItem;
	}
}
