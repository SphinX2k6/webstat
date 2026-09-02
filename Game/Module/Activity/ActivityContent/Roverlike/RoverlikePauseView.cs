using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006410 RID: 25616
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikePauseView : UiViewBase
	{
		// Token: 0x060404F6 RID: 263414 RVA: 0x0107BAA5 File Offset: 0x01079CA5
		public RoverlikePauseView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060404F7 RID: 263415 RVA: 0x0107BAB0 File Offset: 0x01079CB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickQuit));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickSettle));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickSetting));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060404F8 RID: 263416 RVA: 0x0107BCA8 File Offset: 0x01079EA8
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikePauseView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikePauseView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060404F9 RID: 263417 RVA: 0x0107BCEC File Offset: 0x01079EEC
		protected override void OnBeforeShow()
		{
			RoverlikeInstanceData instanceData = ModelBase<RoverlikeModel>.Instance.InstanceData;
			if (instanceData == null)
			{
				return;
			}
			this.RefreshTitle(instanceData);
			this.RefreshLevelTips(instanceData);
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			RoverRogueIns? insConfig = ConfigBase<RoverlikeConfig>.Instance.GetInsConfig(instanceId);
			if (insConfig == null)
			{
				return;
			}
			RoverlikeLevelInfoList infoList = this.InfoList;
			if (infoList == null)
			{
				return;
			}
			infoList.RefreshByConfig(new RoverRogueIns?(insConfig.Value));
		}

		// Token: 0x060404FA RID: 263418 RVA: 0x0107BD53 File Offset: 0x01079F53
		private void RefreshTitle(RoverlikeInstanceData instanceData)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "RoverRogue_ProcessingStage", new <>z__ReadOnlyArray<object>(new object[]
			{
				instanceData.CurLayer,
				instanceData.MaxLayer
			}));
		}

		// Token: 0x060404FB RID: 263419 RVA: 0x0107BD92 File Offset: 0x01079F92
		private void RefreshLevelTips(RoverlikeInstanceData instanceData)
		{
			RoverlikeLevelTipsItem levelTips = this.LevelTips;
			if (levelTips == null)
			{
				return;
			}
			levelTips.Refresh(instanceData, true, null);
		}

		// Token: 0x060404FC RID: 263420 RVA: 0x0107BDA8 File Offset: 0x01079FA8
		private void OnClickQuit()
		{
			int? currentActivityId = ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityId();
			if (currentActivityId != null)
			{
				ControllerBase<RoverlikeController>.Instance.RoverRogueQuitRequest(currentActivityId.Value, null);
			}
		}

		// Token: 0x060404FD RID: 263421 RVA: 0x0107BDDC File Offset: 0x01079FDC
		private void OnClickSettle()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoverlikeResultConfirm);
			confirmBoxDataNew.FunctionMap[2] = new Action(this.<OnClickSettle>g__settle|11_0);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x060404FE RID: 263422 RVA: 0x0107BE18 File Offset: 0x0107A018
		private void OnClickSetting()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MenuView, null, null);
		}

		// Token: 0x060404FF RID: 263423 RVA: 0x0107BE2B File Offset: 0x0107A02B
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06040501 RID: 263425 RVA: 0x0107BE40 File Offset: 0x0107A040
		[CompilerGenerated]
		private void <OnClickSettle>g__settle|11_0()
		{
			int? currentActivityId = ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityId();
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			if (currentActivityId != null)
			{
				ControllerBase<RoverlikeController>.Instance.RoverRogueResultRequest(currentActivityId.Value, instanceId, delegate(bool success)
				{
					if (!success)
					{
						return;
					}
					base.CloseMe(null);
				});
			}
		}

		// Token: 0x040240B1 RID: 147633
		[Nullable(2)]
		private PopupCaptionItem Caption;

		// Token: 0x040240B2 RID: 147634
		[Nullable(2)]
		private RoverlikeLevelTipsItem LevelTips;

		// Token: 0x040240B3 RID: 147635
		[Nullable(2)]
		private RoverlikeLevelInfoList InfoList;

		// Token: 0x0200C47B RID: 50299
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C79C RID: 247708
			public const int CaptionItem = 0;

			// Token: 0x0403C79D RID: 247709
			public const int BtnQuit = 1;

			// Token: 0x0403C79E RID: 247710
			public const int BtnSettle = 2;

			// Token: 0x0403C79F RID: 247711
			public const int BtnSetting = 3;

			// Token: 0x0403C7A0 RID: 247712
			public const int BtnClose = 4;

			// Token: 0x0403C7A1 RID: 247713
			public const int ItemLevelTips = 5;

			// Token: 0x0403C7A2 RID: 247714
			public const int SvInfo = 6;

			// Token: 0x0403C7A3 RID: 247715
			public const int ItemSkillTips = 7;

			// Token: 0x0403C7A4 RID: 247716
			public const int TxtTitle = 8;
		}
	}
}
