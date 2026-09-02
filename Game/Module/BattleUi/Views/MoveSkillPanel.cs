using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Input;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FAE RID: 24494
	[NullableContext(1)]
	[Nullable(0)]
	public class MoveSkillPanel : BattleVisibleChildView, IBattleUiCenterPanelOtherMovePanel
	{
		// Token: 0x0603D8BC RID: 252092 RVA: 0x00FAB7D2 File Offset: 0x00FA99D2
		public void CreateDynamic(UUIItem parentItem)
		{
			base.CreateThenShowByResourceIdAsync("UiItem_SkillVisionB", parentItem, false).Forget();
		}

		// Token: 0x0603D8BD RID: 252093 RVA: 0x00FAB7E8 File Offset: 0x00FA99E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D8BE RID: 252094 RVA: 0x00FAB854 File Offset: 0x00FA9A54
		protected override UniTask OnBeforeStartAsync()
		{
			MoveSkillPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoveSkillPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D8BF RID: 252095 RVA: 0x00FAB898 File Offset: 0x00FA9A98
		public UniTask NewAllSkillItems()
		{
			MoveSkillPanel.<NewAllSkillItems>d__6 <NewAllSkillItems>d__;
			<NewAllSkillItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewAllSkillItems>d__.<>4__this = this;
			<NewAllSkillItems>d__.<>1__state = -1;
			<NewAllSkillItems>d__.<>t__builder.Start<MoveSkillPanel.<NewAllSkillItems>d__6>(ref <NewAllSkillItems>d__);
			return <NewAllSkillItems>d__.<>t__builder.Task;
		}

		// Token: 0x0603D8C0 RID: 252096 RVA: 0x00FAB8DC File Offset: 0x00FA9ADC
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<MoveSkillItem> NewSkillItem(AActor rootActor, int inputIndex)
		{
			MoveSkillPanel.<NewSkillItem>d__7 <NewSkillItem>d__;
			<NewSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<MoveSkillItem>.Create();
			<NewSkillItem>d__.<>4__this = this;
			<NewSkillItem>d__.rootActor = rootActor;
			<NewSkillItem>d__.inputIndex = inputIndex;
			<NewSkillItem>d__.<>1__state = -1;
			<NewSkillItem>d__.<>t__builder.Start<MoveSkillPanel.<NewSkillItem>d__7>(ref <NewSkillItem>d__);
			return <NewSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D8C1 RID: 252097 RVA: 0x00FAB930 File Offset: 0x00FA9B30
		private void RefreshAllSkillItems()
		{
			this.SkillItemList[0].RefreshByMoveType(EInputAxis.MoveForward, 1f, true);
			this.SkillItemList[1].RefreshByMoveType(EInputAxis.MoveForward, -1f, true);
			this.SkillItemList[0].RefreshKeyByActionName("向前移动");
			this.SkillItemList[1].RefreshKeyByActionName("向后移动");
			this.SkillItemList[0].RefreshSkillIconByResId("SP_IconVision01A");
			this.SkillItemList[1].RefreshSkillIconByResId("SP_IconVision01B");
		}

		// Token: 0x0603D8C2 RID: 252098 RVA: 0x00FAB9D0 File Offset: 0x00FA9BD0
		public void Tick(float delta)
		{
			foreach (MoveSkillItem moveSkillItem in this.SkillItemList)
			{
				moveSkillItem.Tick(delta);
			}
		}

		// Token: 0x0603D8C3 RID: 252099 RVA: 0x00FABA24 File Offset: 0x00FA9C24
		protected override void OnBeforeDestroy()
		{
			foreach (MoveSkillItem moveSkillItem in this.SkillItemList)
			{
				moveSkillItem.Destroy(null);
			}
			this.SkillItemList.Clear();
			this.RemoveEvents();
		}

		// Token: 0x0603D8C4 RID: 252100 RVA: 0x00FABA88 File Offset: 0x00FA9C88
		private void AddEvents()
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				ControllerBase<InputDistributeController>.Instance.BindActions(MoveSkillPanel.ActionNameList, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
		}

		// Token: 0x0603D8C5 RID: 252101 RVA: 0x00FABAB1 File Offset: 0x00FA9CB1
		private void RemoveEvents()
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				ControllerBase<InputDistributeController>.Instance.UnBindActions(MoveSkillPanel.ActionNameList, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
		}

		// Token: 0x0603D8C6 RID: 252102 RVA: 0x00FABADC File Offset: 0x00FA9CDC
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionType != InputDistributeDefine.EActionType.Press)
			{
				return;
			}
			if (actionName == "向前移动")
			{
				this.SkillItemList[0].OnInputAction(false);
				return;
			}
			if (actionName == "向后移动")
			{
				this.SkillItemList[1].OnInputAction(false);
			}
		}

		// Token: 0x0603D8C8 RID: 252104 RVA: 0x00FABB40 File Offset: 0x00FA9D40
		// Note: this type is marked as 'beforefieldinit'.
		unsafe static MoveSkillPanel()
		{
			int num = 2;
			List<string> list = new List<string>(num);
			CollectionsMarshal.SetCount<string>(list, num);
			Span<string> span = CollectionsMarshal.AsSpan<string>(list);
			int num2 = 0;
			*span[num2] = "向前移动";
			num2++;
			*span[num2] = "向后移动";
			MoveSkillPanel.ActionNameList = list;
		}

		// Token: 0x040228FF RID: 141567
		[StaticVariableRuleIgnore]
		private static readonly List<string> ActionNameList;

		// Token: 0x04022900 RID: 141568
		private readonly List<MoveSkillItem> SkillItemList = new List<MoveSkillItem>();

		// Token: 0x0200BFCC RID: 49100
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B09B RID: 241819
			Item1,
			// Token: 0x0403B09C RID: 241820
			Item2
		}
	}
}
