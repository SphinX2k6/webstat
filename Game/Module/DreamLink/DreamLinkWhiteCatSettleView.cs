using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DAF RID: 23983
	public class DreamLinkWhiteCatSettleView : UiViewBase
	{
		// Token: 0x0603C63B RID: 247355 RVA: 0x00F545A6 File Offset: 0x00F527A6
		[NullableContext(1)]
		public DreamLinkWhiteCatSettleView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603C63C RID: 247356 RVA: 0x00F545B0 File Offset: 0x00F527B0
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
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C63D RID: 247357 RVA: 0x00F54680 File Offset: 0x00F52880
		protected override UniTask OnBeforeStartAsync()
		{
			DreamLinkWhiteCatSettleView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DreamLinkWhiteCatSettleView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C63E RID: 247358 RVA: 0x00F546C3 File Offset: 0x00F528C3
		protected override void OnBeforeShow()
		{
			this.InitAutoLeaveTimer();
			this.RefreshTitle();
		}

		// Token: 0x0603C63F RID: 247359 RVA: 0x00F546D1 File Offset: 0x00F528D1
		protected override void OnBeforeDestroy()
		{
			this.ClearAutoLeaveTimer();
		}

		// Token: 0x0603C640 RID: 247360 RVA: 0x00F546DC File Offset: 0x00F528DC
		protected void RefreshTitle()
		{
			if (this.Data == null)
			{
				return;
			}
			UUIText text = base.GetText(1);
			UUITexture texture = base.GetTexture(2);
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Text_ChallengeFinish_Text", Array.Empty<object>());
			base.PlaySequence("Success", null, false);
		}

		// Token: 0x0603C641 RID: 247361 RVA: 0x00F5472F File Offset: 0x00F5292F
		private void ClearAutoLeaveTimer()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.AutoLeaveTimerId))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.AutoLeaveTimerId);
			}
			this.AutoLeaveTimerId = null;
		}

		// Token: 0x0603C642 RID: 247362 RVA: 0x00F5475B File Offset: 0x00F5295B
		private void OnClickContinueButton()
		{
			base.CloseMe(delegate(bool success)
			{
				if (success)
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon();
				}
			});
		}

		// Token: 0x0603C643 RID: 247363 RVA: 0x00F54782 File Offset: 0x00F52982
		private void OnClickBtnLeave()
		{
			base.CloseMe(delegate(bool success)
			{
				if (success)
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
				}
			});
		}

		// Token: 0x0603C644 RID: 247364 RVA: 0x00F547AC File Offset: 0x00F529AC
		private void InitAutoLeaveTimer()
		{
			int leftSecondToAutoLeave = 31;
			this.AutoLeaveTimerId = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				int leftSecondToAutoLeave;
				if (leftSecondToAutoLeave <= 0)
				{
					TimerSystem.GameplayTimeInstance.Remove(this.AutoLeaveTimerId);
					this.OnClickBtnLeave();
					return;
				}
				ActivityCorniceMeetingButton activityCorniceMeetingButton;
				this.ButtonMap.TryGetValue(0, out activityCorniceMeetingButton);
				if (activityCorniceMeetingButton != null)
				{
					ActivityCorniceMeetingButton activityCorniceMeetingButton2 = activityCorniceMeetingButton;
					string textId = "InstanceDungeonLeftTimeToAutoLeave";
					string[] array = new string[1];
					int num = 0;
					leftSecondToAutoLeave = leftSecondToAutoLeave;
					leftSecondToAutoLeave--;
					array[num] = leftSecondToAutoLeave.ToString();
					activityCorniceMeetingButton2.SetFloatText(textId, array);
				}
			}, 1000f, 1f, null, null, true);
		}

		// Token: 0x0603C645 RID: 247365 RVA: 0x00F547F8 File Offset: 0x00F529F8
		private UniTask InitButtonAsync()
		{
			DreamLinkWhiteCatSettleView.<InitButtonAsync>d__17 <InitButtonAsync>d__;
			<InitButtonAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitButtonAsync>d__.<>4__this = this;
			<InitButtonAsync>d__.<>1__state = -1;
			<InitButtonAsync>d__.<>t__builder.Start<DreamLinkWhiteCatSettleView.<InitButtonAsync>d__17>(ref <InitButtonAsync>d__);
			return <InitButtonAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C646 RID: 247366 RVA: 0x00F5483C File Offset: 0x00F52A3C
		[NullableContext(1)]
		private UniTask CreateButton(UUIItem uiItem, int buttonIndex, Action clickFunction)
		{
			DreamLinkWhiteCatSettleView.<CreateButton>d__18 <CreateButton>d__;
			<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateButton>d__.<>4__this = this;
			<CreateButton>d__.buttonIndex = buttonIndex;
			<CreateButton>d__.clickFunction = clickFunction;
			<CreateButton>d__.<>1__state = -1;
			<CreateButton>d__.<>t__builder.Start<DreamLinkWhiteCatSettleView.<CreateButton>d__18>(ref <CreateButton>d__);
			return <CreateButton>d__.<>t__builder.Task;
		}

		// Token: 0x04021F4A RID: 139082
		private const int LEAVETIME = 30;

		// Token: 0x04021F4B RID: 139083
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected Dictionary<int, ActivityCorniceMeetingButton> ButtonMap;

		// Token: 0x04021F4C RID: 139084
		[Nullable(2)]
		private TimerHandle AutoLeaveTimerId;

		// Token: 0x04021F4D RID: 139085
		[Nullable(2)]
		protected RogueBossLinkSettleNotify Data;

		// Token: 0x04021F4E RID: 139086
		[Nullable(2)]
		protected DreamLinkWhiteCatSettlePanel RewardExploreTargetReachedList;

		// Token: 0x0200BDF8 RID: 48632
		private class EComponents
		{
			// Token: 0x0403A7BE RID: 239550
			public const int TxtTitle = 1;

			// Token: 0x0403A7BF RID: 239551
			public const int TextureIcon = 2;

			// Token: 0x0403A7C0 RID: 239552
			public const int ButtonHorizontalItem = 4;

			// Token: 0x0403A7C1 RID: 239553
			public const int ButtonItem = 5;

			// Token: 0x0403A7C2 RID: 239554
			public const int Content = 20;
		}

		// Token: 0x0200BDF9 RID: 48633
		private class EButtons
		{
			// Token: 0x0403A7C3 RID: 239555
			public const int LeftButton = 0;

			// Token: 0x0403A7C4 RID: 239556
			public const int RightButton = 1;
		}
	}
}
