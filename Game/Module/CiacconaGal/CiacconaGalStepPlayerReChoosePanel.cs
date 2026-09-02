using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EC5 RID: 24261
	[NullableContext(2)]
	[Nullable(0)]
	public class CiacconaGalStepPlayerReChoosePanel : UiPanelBase
	{
		// Token: 0x0603CF9A RID: 249754 RVA: 0x00F7C214 File Offset: 0x00F7A414
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CF9B RID: 249755 RVA: 0x00F7C2C0 File Offset: 0x00F7A4C0
		protected override UniTask OnBeforeStartAsync()
		{
			CiacconaGalStepPlayerReChoosePanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaGalStepPlayerReChoosePanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CF9C RID: 249756 RVA: 0x00F7C303 File Offset: 0x00F7A503
		protected override void OnStart()
		{
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603CF9D RID: 249757 RVA: 0x00F7C318 File Offset: 0x00F7A518
		[NullableContext(1)]
		public void Refresh(CiacconaGalStepData stepData, CiacconaGalChoiceData choiceData)
		{
			this.PlainTextTop.Refresh(stepData.Content);
			this.PlainTextTop.SetUiActive(!StringUtils.IsEmpty(stepData.Content));
			CiacconaGalReChooseChoiceParam data = new CiacconaGalReChooseChoiceParam
			{
				Text = choiceData.Content,
				TogState = EToggleState.ETT_UnDetermined,
				IconResId = "T_PlotReasoningIcon03"
			};
			this.ChoiceTop.Refresh(data, false, 0);
			this.ChoiceTop.SetInteractive(false);
			this.PlainTextBottom.Refresh("Xkjsx_Option_Title");
			this.ChoiceListBottom.Refresh(delegate
			{
				Singleton<EventSystem>.Instance.Emit<CiacconaGalStepData, CiacconaGalChoiceData>(EEventName.OnCiacconaReChooseConfirm, stepData, choiceData);
			}, delegate
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnCiacconaReChooseCancel);
			});
		}

		// Token: 0x0603CF9E RID: 249758 RVA: 0x00F7C3F8 File Offset: 0x00F7A5F8
		public void PlayStart()
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer == null)
			{
				return;
			}
			seqPlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x0603CF9F RID: 249759 RVA: 0x00F7C428 File Offset: 0x00F7A628
		public UniTask PlayCloseAsync()
		{
			CiacconaGalStepPlayerReChoosePanel.<PlayCloseAsync>d__11 <PlayCloseAsync>d__;
			<PlayCloseAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCloseAsync>d__.<>4__this = this;
			<PlayCloseAsync>d__.<>1__state = -1;
			<PlayCloseAsync>d__.<>t__builder.Start<CiacconaGalStepPlayerReChoosePanel.<PlayCloseAsync>d__11>(ref <PlayCloseAsync>d__);
			return <PlayCloseAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0402238D RID: 140173
		private CiacconaGalReChoosePlainTextItem PlainTextTop;

		// Token: 0x0402238E RID: 140174
		private CiacconaGalReChooseChoiceItem ChoiceTop;

		// Token: 0x0402238F RID: 140175
		private CiacconaGalReChoosePlainTextItem PlainTextBottom;

		// Token: 0x04022390 RID: 140176
		private CiacconaGalReChooseChoiceList ChoiceListBottom;

		// Token: 0x04022391 RID: 140177
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0200BEBA RID: 48826
		[NullableContext(0)]
		public class EMainComponentDefine
		{
			// Token: 0x0403AB51 RID: 240465
			public const int ItemChoiceTop = 1;

			// Token: 0x0403AB52 RID: 240466
			public const int ItemPlainTextBottom = 2;

			// Token: 0x0403AB53 RID: 240467
			public const int ItemChoiceListBottom = 3;

			// Token: 0x0403AB54 RID: 240468
			public const int ItemPlainTextTop = 4;
		}
	}
}
