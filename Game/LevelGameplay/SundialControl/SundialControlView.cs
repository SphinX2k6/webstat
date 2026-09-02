using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SundialControl
{
	// Token: 0x02006AB7 RID: 27319
	[NullableContext(1)]
	[Nullable(0)]
	public class SundialControlView : UiViewBase
	{
		// Token: 0x060438C1 RID: 276673 RVA: 0x0116A89F File Offset: 0x01168A9F
		public SundialControlView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060438C2 RID: 276674 RVA: 0x0116A8A8 File Offset: 0x01168AA8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnResetClicked));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnBtnSwitchClicked));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnBtnBackClicked));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnRotateClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060438C3 RID: 276675 RVA: 0x0116AA80 File Offset: 0x01168C80
		protected override void OnStart()
		{
			this.BtnReset = base.GetButton(0);
			this.BtnSwitch = base.GetButton(1);
			this.BtnRotate = base.GetButton(2);
			this.BtnBack = base.GetButton(3);
			this.BtnBack.RootUIComp.Get().SetUIActive(false);
			this.BtnReset.RootUIComp.Get().SetUIActive(false);
			UUIText text = base.GetText(4);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "PrefabTextItem_2335089801_Text", Array.Empty<object>());
			UUIText text2 = base.GetText(5);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "PrefabTextItem_2335089802_Text", Array.Empty<object>());
			UUIText text3 = base.GetText(6);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, "PrefabTextItem_2335089799_Text", Array.Empty<object>());
			UUIText text4 = base.GetText(7);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text4, "PrefabTextItem_2335089800_Text", Array.Empty<object>());
			ControllerBase<SundialControlController>.Instance.SetOnFinishCallback(delegate
			{
				this.BtnReset.RootUIComp.Get().SetUIActive(false);
				this.BtnSwitch.RootUIComp.Get().SetUIActive(false);
				this.BtnRotate.RootUIComp.Get().SetUIActive(false);
				this.BtnBack.RootUIComp.Get().SetUIActive(false);
			});
			this.WaitModelLoad();
			TimerSystem.Instance.Delay(delegate(float delta)
			{
				ControllerBase<SundialControlController>.Instance.GenerateModel(delegate
				{
					this.AfterModelLoad();
				});
			}, 100f, null, null, true, 1f);
		}

		// Token: 0x060438C4 RID: 276676 RVA: 0x0116ABAA File Offset: 0x01168DAA
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnNeedUpdateSundialTips, new Action<int, int>(this.OnNeedUpdateSundialTips));
		}

		// Token: 0x060438C5 RID: 276677 RVA: 0x0116ABC8 File Offset: 0x01168DC8
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnNeedUpdateSundialTips, new Action<int, int>(this.OnNeedUpdateSundialTips));
		}

		// Token: 0x060438C6 RID: 276678 RVA: 0x0116ABE8 File Offset: 0x01168DE8
		private UniTask WaitModelLoad()
		{
			SundialControlView.<WaitModelLoad>d__16 <WaitModelLoad>d__;
			<WaitModelLoad>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitModelLoad>d__.<>4__this = this;
			<WaitModelLoad>d__.<>1__state = -1;
			<WaitModelLoad>d__.<>t__builder.Start<SundialControlView.<WaitModelLoad>d__16>(ref <WaitModelLoad>d__);
			return <WaitModelLoad>d__.<>t__builder.Task;
		}

		// Token: 0x060438C7 RID: 276679 RVA: 0x0116AC2C File Offset: 0x01168E2C
		private UniTask AfterModelLoad()
		{
			SundialControlView.<AfterModelLoad>d__17 <AfterModelLoad>d__;
			<AfterModelLoad>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AfterModelLoad>d__.<>4__this = this;
			<AfterModelLoad>d__.<>1__state = -1;
			<AfterModelLoad>d__.<>t__builder.Start<SundialControlView.<AfterModelLoad>d__17>(ref <AfterModelLoad>d__);
			return <AfterModelLoad>d__.<>t__builder.Task;
		}

		// Token: 0x060438C8 RID: 276680 RVA: 0x0116AC6F File Offset: 0x01168E6F
		protected override void OnBeforeDestroy()
		{
			ControllerBase<SundialControlController>.Instance.SetOnFinishCallback(null);
			ControllerBase<SundialControlController>.Instance.DestroyModel();
		}

		// Token: 0x060438C9 RID: 276681 RVA: 0x0116AC86 File Offset: 0x01168E86
		private void OnBtnResetClicked()
		{
			this.OnBtnResetClickedImp();
		}

		// Token: 0x060438CA RID: 276682 RVA: 0x0116AC90 File Offset: 0x01168E90
		private UniTask OnBtnResetClickedImp()
		{
			SundialControlView.<OnBtnResetClickedImp>d__20 <OnBtnResetClickedImp>d__;
			<OnBtnResetClickedImp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBtnResetClickedImp>d__.<>4__this = this;
			<OnBtnResetClickedImp>d__.<>1__state = -1;
			<OnBtnResetClickedImp>d__.<>t__builder.Start<SundialControlView.<OnBtnResetClickedImp>d__20>(ref <OnBtnResetClickedImp>d__);
			return <OnBtnResetClickedImp>d__.<>t__builder.Task;
		}

		// Token: 0x060438CB RID: 276683 RVA: 0x0116ACD3 File Offset: 0x01168ED3
		private void OnBtnSwitchClicked()
		{
			ControllerBase<SundialControlController>.Instance.SwitchCurrentRing();
		}

		// Token: 0x060438CC RID: 276684 RVA: 0x0116ACDF File Offset: 0x01168EDF
		private void OnBtnRotateClicked()
		{
			this.SetAllBtnInteractive(false);
			ControllerBase<SundialControlController>.Instance.StartRotate(delegate
			{
				this.SetAllBtnInteractive(true);
			});
		}

		// Token: 0x060438CD RID: 276685 RVA: 0x0116ACFE File Offset: 0x01168EFE
		private void OnBtnBackClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x060438CE RID: 276686 RVA: 0x0116AD07 File Offset: 0x01168F07
		private void SetAllBtnInteractive(bool interactiveEnable)
		{
			this.BtnReset.SetSelfInteractive(interactiveEnable);
			this.BtnSwitch.SetSelfInteractive(interactiveEnable);
			this.BtnRotate.SetSelfInteractive(interactiveEnable);
			this.BtnBack.SetSelfInteractive(interactiveEnable);
		}

		// Token: 0x060438CF RID: 276687 RVA: 0x0116AD3C File Offset: 0x01168F3C
		private void OnNeedUpdateSundialTips(int ring, int socket)
		{
			string[] array = (ring == 0) ? SundialControlView.ringOneTips : SundialControlView.ringTwoTips;
			string textStringId = array[socket % array.Length];
			UUIText text = base.GetText(4);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
		}

		// Token: 0x04025BD6 RID: 154582
		public const string TIPS_TEXT = "PrefabTextItem_2335089801_Text";

		// Token: 0x04025BD7 RID: 154583
		public const string RESET_TEXT = "PrefabTextItem_2335089802_Text";

		// Token: 0x04025BD8 RID: 154584
		public const string SWITCH_TEXT = "PrefabTextItem_2335089799_Text";

		// Token: 0x04025BD9 RID: 154585
		public const string ROTATE_TEXT = "PrefabTextItem_2335089800_Text";

		// Token: 0x04025BDA RID: 154586
		[StaticVariableRuleIgnore]
		public static readonly string[] ringOneTips = new string[]
		{
			"PrefabTextItem_2335089803_Text",
			"PrefabTextItem_2335089814_Text",
			"PrefabTextItem_2335089813_Text",
			"PrefabTextItem_2335089812_Text",
			"PrefabTextItem_2335089811_Text",
			"PrefabTextItem_2335089810_Text",
			"PrefabTextItem_2335089809_Text",
			"PrefabTextItem_2335089808_Text",
			"PrefabTextItem_2335089807_Text",
			"PrefabTextItem_2335089806_Text",
			"PrefabTextItem_2335089805_Text",
			"PrefabTextItem_2335089804_Text"
		};

		// Token: 0x04025BDB RID: 154587
		[StaticVariableRuleIgnore]
		public static readonly string[] ringTwoTips = new string[]
		{
			"PrefabTextItem_2335089818_Text",
			"PrefabTextItem_2335089817_Text",
			"PrefabTextItem_2335089815_Text",
			"PrefabTextItem_2335089816_Text"
		};

		// Token: 0x04025BDC RID: 154588
		[Nullable(2)]
		private UUIButtonComponent BtnReset;

		// Token: 0x04025BDD RID: 154589
		[Nullable(2)]
		private UUIButtonComponent BtnSwitch;

		// Token: 0x04025BDE RID: 154590
		[Nullable(2)]
		private UUIButtonComponent BtnRotate;

		// Token: 0x04025BDF RID: 154591
		[Nullable(2)]
		private UUIButtonComponent BtnBack;

		// Token: 0x0200C9EB RID: 51691
		[NullableContext(0)]
		public enum ESundialControlView
		{
			// Token: 0x0403E0B9 RID: 254137
			BtnReset,
			// Token: 0x0403E0BA RID: 254138
			BtnSwitch,
			// Token: 0x0403E0BB RID: 254139
			BtnRotate,
			// Token: 0x0403E0BC RID: 254140
			BtnBack,
			// Token: 0x0403E0BD RID: 254141
			TextTip,
			// Token: 0x0403E0BE RID: 254142
			TextReset,
			// Token: 0x0403E0BF RID: 254143
			TextSwitch,
			// Token: 0x0403E0C0 RID: 254144
			TextRotate
		}
	}
}
