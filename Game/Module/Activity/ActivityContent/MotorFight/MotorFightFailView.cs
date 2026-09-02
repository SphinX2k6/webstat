using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066EA RID: 26346
	public class MotorFightFailView : UiViewBase
	{
		// Token: 0x06041C43 RID: 269379 RVA: 0x010DE945 File Offset: 0x010DCB45
		[NullableContext(1)]
		public MotorFightFailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041C44 RID: 269380 RVA: 0x010DE950 File Offset: 0x010DCB50
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041C45 RID: 269381 RVA: 0x010DEA20 File Offset: 0x010DCC20
		protected override UniTask OnBeforeStartAsync()
		{
			MotorFightFailView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorFightFailView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041C46 RID: 269382 RVA: 0x010DEA64 File Offset: 0x010DCC64
		protected override void OnBeforeShow()
		{
			UUIText text = base.GetText(1);
			UUIEffectOutline uuieffectOutline = (UUIEffectOutline)text.GetOwner().GetComponentByClass(UUIEffectOutline.StaticClass());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "GenericPromptTypes_4_GeneralText", Array.Empty<object>());
			text.SetColor(FColor.FromHex("F08086FF"));
			text.outlineColor = FColor.FromHex("B33100FF");
			uuieffectOutline.SetOutlineColor(FColor.FromHex("B33100FF"));
			base.PlaySequence("Fail", null, false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "MotorFightGame_FailInfo", Array.Empty<object>());
			UUIText text2 = base.GetText(14);
			if (text2 == null)
			{
				return;
			}
			text2.SetUIActive(true);
		}

		// Token: 0x06041C47 RID: 269383 RVA: 0x010DEB14 File Offset: 0x010DCD14
		private UniTask InitButtonAsync()
		{
			MotorFightFailView.<InitButtonAsync>d__7 <InitButtonAsync>d__;
			<InitButtonAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitButtonAsync>d__.<>4__this = this;
			<InitButtonAsync>d__.<>1__state = -1;
			<InitButtonAsync>d__.<>t__builder.Start<MotorFightFailView.<InitButtonAsync>d__7>(ref <InitButtonAsync>d__);
			return <InitButtonAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041C48 RID: 269384 RVA: 0x010DEB58 File Offset: 0x010DCD58
		[NullableContext(1)]
		private UniTask CreateButton(UUIItem uiItem, int buttonIndex, Action clickFunction)
		{
			MotorFightFailView.<CreateButton>d__8 <CreateButton>d__;
			<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateButton>d__.<>4__this = this;
			<CreateButton>d__.buttonIndex = buttonIndex;
			<CreateButton>d__.clickFunction = clickFunction;
			<CreateButton>d__.<>1__state = -1;
			<CreateButton>d__.<>t__builder.Start<MotorFightFailView.<CreateButton>d__8>(ref <CreateButton>d__);
			return <CreateButton>d__.<>t__builder.Task;
		}

		// Token: 0x06041C49 RID: 269385 RVA: 0x010DEBAB File Offset: 0x010DCDAB
		private void OnReChallengeBtnClick()
		{
			ControllerBase<MotorFightController>.Instance.ReChallengeMotorFightDungeon();
		}

		// Token: 0x06041C4A RID: 269386 RVA: 0x010DEBB7 File Offset: 0x010DCDB7
		private void OnExitBtnClick()
		{
			ControllerBase<MotorFightController>.Instance.LeaveInstanceDungeon();
		}

		// Token: 0x04024B0E RID: 150286
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected Dictionary<int, ActivityCorniceMeetingButton> ButtonMap;

		// Token: 0x0200C725 RID: 50981
		private class EComponents
		{
			// Token: 0x0403D4EB RID: 251115
			public const int TxtTitle = 1;

			// Token: 0x0403D4EC RID: 251116
			public const int TextureIcon = 2;

			// Token: 0x0403D4ED RID: 251117
			public const int ButtonHorizontalItem = 4;

			// Token: 0x0403D4EE RID: 251118
			public const int ButtonItem = 5;

			// Token: 0x0403D4EF RID: 251119
			public const int TextFailTip = 14;
		}

		// Token: 0x0200C726 RID: 50982
		private class EButtons
		{
			// Token: 0x0403D4F0 RID: 251120
			public const int LeftButton = 0;

			// Token: 0x0403D4F1 RID: 251121
			public const int RightButton = 1;
		}
	}
}
