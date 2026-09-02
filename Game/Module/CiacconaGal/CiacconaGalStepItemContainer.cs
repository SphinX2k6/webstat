using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EBD RID: 24253
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CiacconaGalStepItemContainer : GridProxyAbstract<CiacconaGalStepData>
	{
		// Token: 0x0603CF56 RID: 249686 RVA: 0x00F7B4E8 File Offset: 0x00F796E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CF57 RID: 249687 RVA: 0x00F7B594 File Offset: 0x00F79794
		protected override UniTask OnBeforeStartAsync()
		{
			CiacconaGalStepItemContainer.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaGalStepItemContainer.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CF58 RID: 249688 RVA: 0x00F7B5D8 File Offset: 0x00F797D8
		[NullableContext(1)]
		public override void Refresh(CiacconaGalStepData data, bool isSelected, int gridIndex)
		{
			this.StepData = data;
			this.ChosenItem.SetActive(this.ShouldShowChosenItem());
			this.TextItem.SetActive(this.ShouldShowTextItem());
			this.SubEndingItem.SetActive(this.ShouldShowSubEndingItem());
			this.ChoiceListItem.SetActive(this.ShouldShowChoiceListItem());
			if (this.ShouldShowChosenItem())
			{
				CiacconaGalChoiceData choiceDataById = ModelBase<CiacconaGalModel>.Instance.GetChoiceDataById(data.ChosenId);
				this.ChosenItem.Refresh(choiceDataById);
			}
			if (this.ShouldShowTextItem())
			{
				this.TextItem.Refresh(data);
			}
			if (this.ShouldShowSubEndingItem())
			{
				CiacconaGalSubEndingData subEndingDataById = ModelBase<CiacconaGalModel>.Instance.GetSubEndingDataById(data.SubEndingId);
				this.SubEndingItem.Refresh(subEndingDataById);
				bool flag = ControllerBase<CiacconaGalController>.Instance.GalPlayer.GetCurState() == ECiacconaGalPlayerState.SubEnding;
				this.SubEndingItem.GetRootItem().SetAlpha(flag > false);
				if (flag)
				{
					this.SubEndingItem.PlayStart();
				}
			}
			if (this.ShouldShowChoiceListItem())
			{
				this.ChoiceListItem.Refresh(data);
			}
		}

		// Token: 0x0603CF59 RID: 249689 RVA: 0x00F7B6D8 File Offset: 0x00F798D8
		private bool ShouldShowChosenItem()
		{
			return this.StepData.Type == ECiacconaGalStepType.Choice && this.StepData.Id != ControllerBase<CiacconaGalController>.Instance.GalPlayer.CurHandlingStepId;
		}

		// Token: 0x0603CF5A RID: 249690 RVA: 0x00F7B709 File Offset: 0x00F79909
		private bool ShouldShowTextItem()
		{
			return this.StepData.HasText;
		}

		// Token: 0x0603CF5B RID: 249691 RVA: 0x00F7B716 File Offset: 0x00F79916
		private bool ShouldShowSubEndingItem()
		{
			return this.StepData.Type == ECiacconaGalStepType.End;
		}

		// Token: 0x0603CF5C RID: 249692 RVA: 0x00F7B728 File Offset: 0x00F79928
		private bool ShouldShowChoiceListItem()
		{
			ECiacconaGalPlayerState curState = ControllerBase<CiacconaGalController>.Instance.GalPlayer.GetCurState();
			return this.StepData.Type == ECiacconaGalStepType.Choice && this.StepData.Id == ControllerBase<CiacconaGalController>.Instance.GalPlayer.CurHandlingStepId && (curState == ECiacconaGalPlayerState.Choosing || curState == ECiacconaGalPlayerState.ChoiceProtecting);
		}

		// Token: 0x0603CF5D RID: 249693 RVA: 0x00F7B77C File Offset: 0x00F7997C
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "ChoicesSelect" && this.StepData.ChoiceIds.Length > 1 && this.ShouldShowChoiceListItem())
			{
				UUIItem item = base.GetItem(3);
				return new UUIItem[]
				{
					item,
					item
				};
			}
			if (!(a == "FirstChoice") || !this.ShouldShowChoiceListItem())
			{
				return null;
			}
			CiacconaGalStepChoiceList choiceListItem = this.ChoiceListItem;
			if (choiceListItem == null)
			{
				return null;
			}
			return choiceListItem.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x04022378 RID: 140152
		private CiacconaGalStepChosenItem ChosenItem;

		// Token: 0x04022379 RID: 140153
		private CiacconaGalStepTextItem TextItem;

		// Token: 0x0402237A RID: 140154
		private CiacconaGalStepSubEndingItem SubEndingItem;

		// Token: 0x0402237B RID: 140155
		private CiacconaGalStepChoiceList ChoiceListItem;

		// Token: 0x0402237C RID: 140156
		private CiacconaGalStepData StepData;

		// Token: 0x0200BEAD RID: 48813
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403AB25 RID: 240421
			public const int ChosenItem = 0;

			// Token: 0x0403AB26 RID: 240422
			public const int TextItem = 1;

			// Token: 0x0403AB27 RID: 240423
			public const int SubEndingItem = 2;

			// Token: 0x0403AB28 RID: 240424
			public const int ChoiceListItem = 3;
		}
	}
}
