using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006332 RID: 25394
	[NullableContext(2)]
	[Nullable(0)]
	public class SpringManorRewardQuestItem : GridProxyAbstract<int>
	{
		// Token: 0x0603FCA6 RID: 261286 RVA: 0x0105B5A8 File Offset: 0x010597A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickSkip));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603FCA7 RID: 261287 RVA: 0x0105B6F4 File Offset: 0x010598F4
		protected override UniTask OnBeforeStartAsync()
		{
			SpringManorRewardQuestItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpringManorRewardQuestItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FCA8 RID: 261288 RVA: 0x0105B738 File Offset: 0x01059938
		protected override void OnStart()
		{
			this.RewardScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(6), () => new CommonItemSmallItemGrid(), null, false, null);
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetUIActive(true);
			}
			ButtonItem receiveButton = this.ReceiveButton;
			if (receiveButton == null)
			{
				return;
			}
			receiveButton.SetRedDotVisible(true);
		}

		// Token: 0x0603FCA9 RID: 261289 RVA: 0x0105B7A0 File Offset: 0x010599A0
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			ActivitySpringManorTaskData rewardTaskData = ModelBase<SpringManorModel>.Instance.ActivityData.GetRewardTaskData(data);
			if (rewardTaskData == null)
			{
				return;
			}
			SpringFestivalReward? rewardTaskConfigById = ConfigBase<SpringManorConfig>.Instance.GetRewardTaskConfigById(data);
			if (rewardTaskConfigById == null)
			{
				return;
			}
			this.TaskId = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), rewardTaskConfigById.Value.Desc, Array.Empty<object>());
			UUIText text = base.GetText(5);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(rewardTaskData.Current);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(rewardTaskData.Target);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(rewardTaskConfigById.Value.DropId);
			GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardScroll = this.RewardScroll;
			if (rewardScroll != null)
			{
				rewardScroll.RefreshByData(dropPackagePreviewItemList, null, false);
			}
			bool uiActive = rewardTaskData.Status == EActivityTaskState.FinishedAndUnclaimed;
			bool uiactive = rewardTaskData.Status == EActivityTaskState.FinishedAndClaimed;
			bool flag = rewardTaskData.Status == EActivityTaskState.Active;
			bool flag2 = rewardTaskConfigById.Value.SkipType > 0;
			ButtonItem receiveButton = this.ReceiveButton;
			if (receiveButton != null)
			{
				receiveButton.SetUiActive(uiActive);
			}
			base.GetButton(0).RootUIComp.Get().SetUIActive(flag && flag2);
			base.GetItem(2).SetUIActive(flag && !flag2);
			base.GetItem(3).SetUIActive(uiactive);
		}

		// Token: 0x0603FCAA RID: 261290 RVA: 0x0105B903 File Offset: 0x01059B03
		[NullableContext(1)]
		public void SetReceiveClickCallback(Action callback)
		{
			this.ReceiveClickCallback = callback;
		}

		// Token: 0x0603FCAB RID: 261291 RVA: 0x0105B90C File Offset: 0x01059B0C
		private void OnClickSkip()
		{
			if (this.TaskId == 0)
			{
				return;
			}
			if (!ModelBase<SpringManorModel>.Instance.CheckInInstance())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Spring26_BanSkipTips", Array.Empty<object>());
				return;
			}
			SpringFestivalReward? rewardTaskConfigById = ConfigBase<SpringManorConfig>.Instance.GetRewardTaskConfigById(this.TaskId);
			if (rewardTaskConfigById == null)
			{
				return;
			}
			int skipType = rewardTaskConfigById.Value.SkipType;
			if (skipType != 1)
			{
				if (skipType == 2)
				{
					ControllerBase<SpringManorController>.Instance.TrackRewardTask(this.TaskId);
				}
			}
			else
			{
				EUiViewName name = (EUiViewName)rewardTaskConfigById.Value.SkipParam(0);
				int skipParamLength = rewardTaskConfigById.Value.SkipParamLength;
				if (skipParamLength == 1)
				{
					Singleton<UiManager>.Instance.OpenView(name, null, null);
				}
				else if (skipParamLength == 2)
				{
					string text = rewardTaskConfigById.Value.SkipParam(1);
					double num;
					object param;
					if (double.TryParse(text, out num))
					{
						param = num;
					}
					else
					{
						param = text;
					}
					Singleton<UiManager>.Instance.OpenView(name, param, null);
				}
				else
				{
					List<string> list = new List<string>();
					for (int i = 1; i < rewardTaskConfigById.Value.SkipParamLength; i++)
					{
						list.Add(rewardTaskConfigById.Value.SkipParam(i));
					}
					Singleton<UiManager>.Instance.OpenView(name, list.ToArray(), null);
				}
			}
			Action<ESpringRewardTaskSkipType> onSkipClick = this.OnSkipClick;
			if (onSkipClick == null)
			{
				return;
			}
			onSkipClick((ESpringRewardTaskSkipType)rewardTaskConfigById.Value.SkipType);
		}

		// Token: 0x0603FCAC RID: 261292 RVA: 0x0105BA81 File Offset: 0x01059C81
		private void OnClickReceive(int _)
		{
			Action receiveClickCallback = this.ReceiveClickCallback;
			if (receiveClickCallback == null)
			{
				return;
			}
			receiveClickCallback();
		}

		// Token: 0x04023D2B RID: 146731
		private int TaskId;

		// Token: 0x04023D2C RID: 146732
		private Action ReceiveClickCallback;

		// Token: 0x04023D2D RID: 146733
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScroll;

		// Token: 0x04023D2E RID: 146734
		private ButtonItem ReceiveButton;

		// Token: 0x04023D2F RID: 146735
		public Action<ESpringRewardTaskSkipType> OnSkipClick;
	}
}
