using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066BD RID: 26301
	[NullableContext(2)]
	[Nullable(0)]
	public class MotorParkourActivitySubView : ActivitySubViewBase
	{
		// Token: 0x1700A051 RID: 41041
		// (get) Token: 0x06041ABA RID: 268986 RVA: 0x010D6E54 File Offset: 0x010D5054
		protected new MotorParkourActivityData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as MotorParkourActivityData;
			}
		}

		// Token: 0x06041ABB RID: 268987 RVA: 0x010D6E64 File Offset: 0x010D5064
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041ABC RID: 268988 RVA: 0x010D6EF0 File Offset: 0x010D50F0
		protected override UniTask OnBeforeStartAsync()
		{
			MotorParkourActivitySubView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorParkourActivitySubView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041ABD RID: 268989 RVA: 0x010D6F33 File Offset: 0x010D5133
		protected override void OnRefreshView()
		{
			this.CommonInfoPanel.SetFunctionRedDotVisible(this.ActivityBaseData.RedPointShowState);
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel == null)
			{
				return;
			}
			commonInfoPanel.OnRefreshView();
		}

		// Token: 0x06041ABE RID: 268990 RVA: 0x010D6F5C File Offset: 0x010D515C
		private void OnConfirmBtnClick(ActivityBaseData data)
		{
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorParkourMainView, this.ActivityBaseData, null);
		}

		// Token: 0x04024A7E RID: 150142
		protected ActivitySubViewGeneralInfo CommonInfoPanel;

		// Token: 0x0200C6E5 RID: 50917
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D3C6 RID: 250822
			public const int CommonActionInfo = 0;

			// Token: 0x0403D3C7 RID: 250823
			public const int TextureBg = 1;

			// Token: 0x0403D3C8 RID: 250824
			public const int TextureCharacterBg = 2;
		}
	}
}
