using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleMorph.View
{
	// Token: 0x020050E4 RID: 20708
	[NullableContext(1)]
	[Nullable(0)]
	public class LiuLiDaoLingView : UiTickViewBase
	{
		// Token: 0x06035619 RID: 218649 RVA: 0x00D63D46 File Offset: 0x00D61F46
		public LiuLiDaoLingView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603561A RID: 218650 RVA: 0x00D63D5C File Offset: 0x00D61F5C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickReset));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603561B RID: 218651 RVA: 0x00D63EEC File Offset: 0x00D620EC
		protected override UniTask OnBeforeStartAsync()
		{
			LiuLiDaoLingView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<LiuLiDaoLingView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603561C RID: 218652 RVA: 0x00D63F30 File Offset: 0x00D62130
		public UniTask NewAllSkillItems()
		{
			LiuLiDaoLingView.<NewAllSkillItems>d__5 <NewAllSkillItems>d__;
			<NewAllSkillItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewAllSkillItems>d__.<>4__this = this;
			<NewAllSkillItems>d__.<>1__state = -1;
			<NewAllSkillItems>d__.<>t__builder.Start<LiuLiDaoLingView.<NewAllSkillItems>d__5>(ref <NewAllSkillItems>d__);
			return <NewAllSkillItems>d__.<>t__builder.Task;
		}

		// Token: 0x0603561D RID: 218653 RVA: 0x00D63F74 File Offset: 0x00D62174
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<LiuLiDaoLingSkillItem> NewSkillItem(AActor rootActor, int inputIndex)
		{
			LiuLiDaoLingView.<NewSkillItem>d__6 <NewSkillItem>d__;
			<NewSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<LiuLiDaoLingSkillItem>.Create();
			<NewSkillItem>d__.<>4__this = this;
			<NewSkillItem>d__.rootActor = rootActor;
			<NewSkillItem>d__.inputIndex = inputIndex;
			<NewSkillItem>d__.<>1__state = -1;
			<NewSkillItem>d__.<>t__builder.Start<LiuLiDaoLingView.<NewSkillItem>d__6>(ref <NewSkillItem>d__);
			return <NewSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603561E RID: 218654 RVA: 0x00D63FC8 File Offset: 0x00D621C8
		private void RefreshAllSkillItems()
		{
			this.SkillItemList[0].RefreshByMoveType(0, EInputAxis.MoveRight, -1f, new Action<int>(this.OnPressItem));
			this.SkillItemList[1].RefreshByMoveType(1, EInputAxis.MoveRight, 1f, new Action<int>(this.OnPressItem));
			this.SkillItemList[2].RefreshByMoveType(2, EInputAxis.MoveForward, 1f, new Action<int>(this.OnPressItem));
			this.SkillItemList[3].RefreshByMoveType(3, EInputAxis.MoveForward, -1f, new Action<int>(this.OnPressItem));
		}

		// Token: 0x0603561F RID: 218655 RVA: 0x00D64078 File Offset: 0x00D62278
		private void OnPressItem(int index)
		{
			for (int i = 0; i < this.SkillItemList.Count; i++)
			{
				if (i != index)
				{
					this.SkillItemList[i].Press(false);
				}
			}
		}

		// Token: 0x06035620 RID: 218656 RVA: 0x00D640B4 File Offset: 0x00D622B4
		protected override void OnAddEventListener()
		{
			ControllerBase<InputDistributeController>.Instance.BindActions(new List<string>
			{
				"UI方向上",
				"UI方向下",
				"UI方向左",
				"UI方向右"
			}, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			Singleton<EventSystem>.Instance.Add<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
		}

		// Token: 0x06035621 RID: 218657 RVA: 0x00D64124 File Offset: 0x00D62324
		protected override void OnRemoveEventListener()
		{
			this.ClearPress();
			ControllerBase<InputDistributeController>.Instance.UnBindActions(new List<string>
			{
				"UI方向上",
				"UI方向下",
				"UI方向左",
				"UI方向右"
			}, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			Singleton<EventSystem>.Instance.Remove<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
		}

		// Token: 0x06035622 RID: 218658 RVA: 0x00D6419C File Offset: 0x00D6239C
		protected override void OnBeforeDestroy()
		{
			foreach (LiuLiDaoLingSkillItem liuLiDaoLingSkillItem in this.SkillItemList)
			{
				liuLiDaoLingSkillItem.Destroy(null);
			}
			this.SkillItemList.Clear();
		}

		// Token: 0x06035623 RID: 218659 RVA: 0x00D641F8 File Offset: 0x00D623F8
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification _)
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			bool isPress = actionType == InputDistributeDefine.EActionType.Press;
			if (actionName == "UI方向左")
			{
				this.SkillItemList[0].Press(isPress);
				return;
			}
			if (actionName == "UI方向右")
			{
				this.SkillItemList[1].Press(isPress);
				return;
			}
			if (actionName == "UI方向上")
			{
				this.SkillItemList[2].Press(isPress);
				return;
			}
			if (actionName == "UI方向下")
			{
				this.SkillItemList[3].Press(isPress);
			}
		}

		// Token: 0x06035624 RID: 218660 RVA: 0x00D64298 File Offset: 0x00D62498
		private void OnInputControllerMainTypeChange(EInputControllerMainType last, EInputControllerMainType now)
		{
			if (last == EInputControllerMainType.Gamepad)
			{
				this.ClearPress();
			}
		}

		// Token: 0x06035625 RID: 218661 RVA: 0x00D642A4 File Offset: 0x00D624A4
		private void ClearPress()
		{
			foreach (LiuLiDaoLingSkillItem liuLiDaoLingSkillItem in this.SkillItemList)
			{
				liuLiDaoLingSkillItem.Press(false);
			}
		}

		// Token: 0x06035626 RID: 218662 RVA: 0x00D642F8 File Offset: 0x00D624F8
		private void OnClickReset()
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.ChallengeAgain, "重新挑战");
		}

		// Token: 0x06035627 RID: 218663 RVA: 0x00D6430F File Offset: 0x00D6250F
		private void OnClickClose()
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.ChallengeAgain, "玩法放弃");
		}

		// Token: 0x06035628 RID: 218664 RVA: 0x00D64328 File Offset: 0x00D62528
		protected override void OnTick(float delta)
		{
			foreach (LiuLiDaoLingSkillItem liuLiDaoLingSkillItem in this.SkillItemList)
			{
				liuLiDaoLingSkillItem.Tick(delta);
			}
		}

		// Token: 0x0401EABF RID: 125631
		private readonly List<LiuLiDaoLingSkillItem> SkillItemList = new List<LiuLiDaoLingSkillItem>();

		// Token: 0x0200B081 RID: 45185
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x04036C3C RID: 224316
			LeftContainer,
			// Token: 0x04036C3D RID: 224317
			Item1,
			// Token: 0x04036C3E RID: 224318
			Item2,
			// Token: 0x04036C3F RID: 224319
			Item3,
			// Token: 0x04036C40 RID: 224320
			Item4,
			// Token: 0x04036C41 RID: 224321
			BtnReset,
			// Token: 0x04036C42 RID: 224322
			BtnClose,
			// Token: 0x04036C43 RID: 224323
			BtnHelp
		}
	}
}
