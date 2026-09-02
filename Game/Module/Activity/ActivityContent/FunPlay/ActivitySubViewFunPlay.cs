using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FunPlay
{
	// Token: 0x0200677A RID: 26490
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivitySubViewFunPlay : ActivitySubViewBase
	{
		// Token: 0x0604209F RID: 270495 RVA: 0x010F1D1C File Offset: 0x010EFF1C
		protected override void OnSetData()
		{
			this.ActivityData = (ActivityFunPlayData)this.ActivityBaseData;
		}

		// Token: 0x060420A0 RID: 270496 RVA: 0x010F1D30 File Offset: 0x010EFF30
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060420A1 RID: 270497 RVA: 0x010F1D9C File Offset: 0x010EFF9C
		protected override UniTask OnBeforeStartAsync()
		{
			ActivitySubViewFunPlay.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewFunPlay.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060420A2 RID: 270498 RVA: 0x010F1DE0 File Offset: 0x010EFFE0
		private void OnConfirmBtnClick(ActivityBaseData _)
		{
			this.ActivityData.SetClickRedDotState();
			if (!this.ActivityData.GetPreGuideQuestFinishState())
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.ActivityData.GetUnFinishPreGuideQuestId(), null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityFunPlayView, this.ActivityData, null);
		}

		// Token: 0x060420A3 RID: 270499 RVA: 0x010F1E3C File Offset: 0x010F003C
		protected override void OnRefreshView()
		{
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel == null)
			{
				return;
			}
			commonInfoPanel.SetFunctionRedDotVisible(this.ActivityData.CheckRedDot());
		}

		// Token: 0x04024D21 RID: 150817
		protected ActivityFunPlayData ActivityData;

		// Token: 0x04024D22 RID: 150818
		protected ActivitySubViewGeneralInfo CommonInfoPanel;

		// Token: 0x0200C79B RID: 51099
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403D745 RID: 251717
			public const int ItemCommonPanel = 0;

			// Token: 0x0403D746 RID: 251718
			public const int TexBg = 1;
		}
	}
}
