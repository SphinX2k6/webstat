using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E1A RID: 24090
	[NullableContext(1)]
	[Nullable(0)]
	public class ConfirmItem : UiPanelBase
	{
		// Token: 0x0603C9CA RID: 248266 RVA: 0x00F64320 File Offset: 0x00F62520
		public UniTask Initialize(UUIItem uiItem)
		{
			ConfirmItem.<Initialize>d__2 <Initialize>d__;
			<Initialize>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Initialize>d__.<>4__this = this;
			<Initialize>d__.uiItem = uiItem;
			<Initialize>d__.<>1__state = -1;
			<Initialize>d__.<>t__builder.Start<ConfirmItem.<Initialize>d__2>(ref <Initialize>d__);
			return <Initialize>d__.<>t__builder.Task;
		}

		// Token: 0x0603C9CB RID: 248267 RVA: 0x00F6436C File Offset: 0x00F6256C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(delegate()
			{
				this.OnConfirm();
			}));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C9CC RID: 248268 RVA: 0x00F64433 File Offset: 0x00F62633
		protected override void OnStart()
		{
			base.GetButton(0).SetCanClickWhenDisable(true);
		}

		// Token: 0x0603C9CD RID: 248269 RVA: 0x00F64442 File Offset: 0x00F62642
		public void ShowConfirmItem(bool isShow)
		{
			this.SetActive(isShow);
		}

		// Token: 0x0603C9CE RID: 248270 RVA: 0x00F6444C File Offset: 0x00F6264C
		public void SetEnable()
		{
			int cookerMaxLevel = ModelBase<CookModel>.Instance.GetCookerMaxLevel();
			int cookingLevel = ModelBase<CookModel>.Instance.GetCookerInfo().CookingLevel;
			int selectedCookerLevel = ModelBase<CookModel>.Instance.SelectedCookerLevel;
			AUIBaseActor auibaseActor = base.GetButton(0).GetOwner() as AUIBaseActor;
			if (cookingLevel >= cookerMaxLevel || selectedCookerLevel >= cookerMaxLevel || selectedCookerLevel < cookingLevel)
			{
				auibaseActor.GetUIItem().SetUIActive(false);
				return;
			}
			auibaseActor.GetUIItem().SetUIActive(true);
			int totalProficiencys = ModelBase<CookModel>.Instance.GetCookerInfo().TotalProficiencys;
			int sumExpByLevel = ModelBase<CookModel>.Instance.GetSumExpByLevel(ModelBase<CookModel>.Instance.SelectedCookerLevel);
			base.GetButton(0).SetSelfInteractive(totalProficiencys >= sumExpByLevel);
			base.GetItem(2).SetUIActive(totalProficiencys >= sumExpByLevel);
		}

		// Token: 0x0603C9CF RID: 248271 RVA: 0x00F64507 File Offset: 0x00F62707
		[NullableContext(2)]
		public UUIItem GetRedDot()
		{
			return base.GetItem(2);
		}

		// Token: 0x0603C9D0 RID: 248272 RVA: 0x00F64510 File Offset: 0x00F62710
		public void BindOnClickedCallback(Action onConfirmCallback)
		{
			this.OnConfirmCallback = onConfirmCallback;
		}

		// Token: 0x0603C9D1 RID: 248273 RVA: 0x00F64519 File Offset: 0x00F62719
		private void OnConfirm()
		{
			if (this.OnConfirmCallback != null)
			{
				if (base.GetButton(0).GetSelfInteractive())
				{
					this.OnConfirmCallback();
					return;
				}
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("CookUpgrade", Array.Empty<object>());
			}
		}

		// Token: 0x040220F4 RID: 139508
		[Nullable(2)]
		private Action OnConfirmCallback;
	}
}
