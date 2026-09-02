using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x0200571A RID: 22298
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleScoreProgressActivityPanel : UiPanelBase
	{
		// Token: 0x06038C04 RID: 232452 RVA: 0x00E5EB50 File Offset: 0x00E5CD50
		public UniTask Init(UUIItem item)
		{
			MoraleScoreProgressActivityPanel.<Init>d__3 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleScoreProgressActivityPanel.<Init>d__3>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038C05 RID: 232453 RVA: 0x00E5EB9C File Offset: 0x00E5CD9C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
		}

		// Token: 0x06038C06 RID: 232454 RVA: 0x00E5EC38 File Offset: 0x00E5CE38
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleScoreProgressActivityPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleScoreProgressActivityPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038C07 RID: 232455 RVA: 0x00E5EC7C File Offset: 0x00E5CE7C
		public void UpdateData()
		{
			MoraleModel instance = ModelBase<MoraleModel>.Instance;
			GenericLayout<MoraleScoreProgressPercentItem, MoraleProgressRewardData> percentLayout = this.PercentLayout;
			if (percentLayout != null)
			{
				percentLayout.RefreshByData(instance.ProgressRewardList, new Action(this.UpdatePercentHandle), false);
			}
			List<MoraleAreaProgressData> list = new List<MoraleAreaProgressData>(instance.ProgressRewardList.Count);
			foreach (MoraleProgressRewardData moraleProgressRewardData in instance.ProgressRewardList)
			{
				MoraleAreaProgressData item = new MoraleAreaProgressData
				{
					TargetScore = moraleProgressRewardData.TargetScore,
					LastTargetScore = moraleProgressRewardData.LastTargetScore,
					StartScore = moraleProgressRewardData.StartScore
				};
				list.Add(item);
			}
			GenericLayout<MoraleAreaProgressPointItem, MoraleAreaProgressData> pointLayout = this.PointLayout;
			if (pointLayout != null)
			{
				pointLayout.RefreshByData(list, null, false);
			}
			GenericLayout<MoraleScoreProgressPercentItem, MoraleProgressRewardData> percentLayout2 = this.PercentLayout;
			if (percentLayout2 != null)
			{
				percentLayout2.BindLateUpdate(delegate(float _)
				{
					TimerSystem.Instance.Next(new TTimerAction(this.TimerUpdatePercentHandle), null, null);
					GenericLayout<MoraleScoreProgressPercentItem, MoraleProgressRewardData> percentLayout3 = this.PercentLayout;
					if (percentLayout3 == null)
					{
						return;
					}
					percentLayout3.UnBindLateUpdate();
				});
			}
			int currentProgressScore = instance.GetCurrentProgressScore();
			int progressTotalScore = instance.GetProgressTotalScore();
			UUIText text = base.GetText(0);
			string textStringId = "Morale_title_17";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, new <>z__ReadOnlyArray<object>(new object[]
			{
				currentProgressScore,
				progressTotalScore
			}));
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.ShowTextNew("Morale_title_1");
		}

		// Token: 0x06038C08 RID: 232456 RVA: 0x00E5EDCC File Offset: 0x00E5CFCC
		protected void TimerUpdatePercentHandle(float _)
		{
			this.UpdatePercentHandle();
		}

		// Token: 0x06038C09 RID: 232457 RVA: 0x00E5EDD4 File Offset: 0x00E5CFD4
		protected void UpdatePercentHandle()
		{
			GenericLayout<MoraleScoreProgressPercentItem, MoraleProgressRewardData> percentLayout = this.PercentLayout;
			List<MoraleScoreProgressPercentItem> list = (percentLayout != null) ? percentLayout.GetLayoutItemList() : null;
			if (list == null)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				list[i].UpdatePercentHandle();
			}
		}

		// Token: 0x06038C0A RID: 232458 RVA: 0x00E5EE15 File Offset: 0x00E5D015
		private MoraleScoreProgressPercentItem CreatePercentItem()
		{
			return new MoraleScoreProgressPercentItem();
		}

		// Token: 0x06038C0B RID: 232459 RVA: 0x00E5EE1C File Offset: 0x00E5D01C
		private MoraleAreaProgressPointItem CreatePointItem()
		{
			return new MoraleAreaProgressPointItem();
		}

		// Token: 0x04020553 RID: 132435
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericLayout<MoraleScoreProgressPercentItem, MoraleProgressRewardData> PercentLayout;

		// Token: 0x04020554 RID: 132436
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericLayout<MoraleAreaProgressPointItem, MoraleAreaProgressData> PointLayout;

		// Token: 0x0200B7BE RID: 47038
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038D62 RID: 232802
			public const int TxtSumScoreProgress = 0;

			// Token: 0x04038D63 RID: 232803
			public const int TxtSumProgressTitle = 1;

			// Token: 0x04038D64 RID: 232804
			public const int LayoutPercent = 2;

			// Token: 0x04038D65 RID: 232805
			public const int ItemPercent = 3;

			// Token: 0x04038D66 RID: 232806
			public const int LayoutProgressPoint = 4;

			// Token: 0x04038D67 RID: 232807
			public const int ItemProgressPointTemplate = 5;
		}
	}
}
