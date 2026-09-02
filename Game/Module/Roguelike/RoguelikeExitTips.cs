using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005187 RID: 20871
	public class RoguelikeExitTips : UiViewBase
	{
		// Token: 0x06035B2E RID: 219950 RVA: 0x00D7D9CE File Offset: 0x00D7BBCE
		[NullableContext(1)]
		public RoguelikeExitTips(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035B2F RID: 219951 RVA: 0x00D7D9D8 File Offset: 0x00D7BBD8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035B30 RID: 219952 RVA: 0x00D7DA84 File Offset: 0x00D7BC84
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeExitTips.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeExitTips.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035B31 RID: 219953 RVA: 0x00D7DAC8 File Offset: 0x00D7BCC8
		protected override void OnStart()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "RoguelikeExitTipsCurRoom", new <>z__ReadOnlyArray<object>(new object[]
			{
				ModelBase<RoguelikeModel>.Instance.CurRoomCount,
				ModelBase<RoguelikeModel>.Instance.TotalRoomCount
			}));
			this.ButtonItemSettle.GetBtn().RootUIComp.Get().SetUIActive(!ModelBase<RoguelikeModel>.Instance.CheckIsGuideDungeon());
		}

		// Token: 0x06035B32 RID: 219954 RVA: 0x00D7DB44 File Offset: 0x00D7BD44
		private void OnClickBtnSettle(int _)
		{
			Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, delegate(bool success)
			{
				ControllerBase<RoguelikeController>.Instance.RoguelikeResultRequest(0, null);
			});
		}

		// Token: 0x06035B33 RID: 219955 RVA: 0x00D7DB7A File Offset: 0x00D7BD7A
		private void OnClickBtnExit(int _)
		{
			Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, delegate(bool success)
			{
				ControllerBase<RoguelikeController>.Instance.RoguelikeQuitRequest();
			});
		}

		// Token: 0x0401ED16 RID: 126230
		[Nullable(2)]
		private ButtonItem ButtonItemSettle;

		// Token: 0x0401ED17 RID: 126231
		[Nullable(2)]
		private ButtonItem ButtonItemExit;

		// Token: 0x0200B144 RID: 45380
		private class ERoguelikeExitTipsDefine
		{
			// Token: 0x04036F9D RID: 225181
			public const int TxtCurRoom = 0;

			// Token: 0x04036F9E RID: 225182
			public const int BtnSettle = 1;

			// Token: 0x04036F9F RID: 225183
			public const int BtnExit = 2;

			// Token: 0x04036FA0 RID: 225184
			public const int TxtTips = 3;
		}
	}
}
