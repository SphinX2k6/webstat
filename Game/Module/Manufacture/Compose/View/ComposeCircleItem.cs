using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.Item;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Compose.View
{
	// Token: 0x020059C4 RID: 22980
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ComposeCircleItem : AutoAttachItem<IBaseItemData>
	{
		// Token: 0x0603A370 RID: 238448 RVA: 0x00EBF7FC File Offset: 0x00EBD9FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.SelectedItem));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A371 RID: 238449 RVA: 0x00EBF926 File Offset: 0x00EBDB26
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CheckCanClick));
		}

		// Token: 0x0603A372 RID: 238450 RVA: 0x00EBF94C File Offset: 0x00EBDB4C
		protected override void OnMoveItem()
		{
			float currentMovePercentage = base.GetCurrentMovePercentage();
			float floatValue = this.ItemCurve.GetFloatValue(currentMovePercentage);
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.RootUIComp.Get().SetUIItemScale(new FVector(floatValue, floatValue, 1f));
		}

		// Token: 0x0603A373 RID: 238451 RVA: 0x00EBF998 File Offset: 0x00EBDB98
		protected override void OnRefreshItem(IBaseItemData data)
		{
			this.CurrentData = data;
			if (data == null)
			{
				return;
			}
			SynthesisFormula? synthesisFormula;
			int? num = (data.MainType == EComposeListType.Exchange) ? new int?(data.ConfigId) : ((ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(data.ConfigId) != null) ? new int?(synthesisFormula.GetValueOrDefault().ItemId) : null);
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(num.Value, 0);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(5), "ItemTipsHaveNum", new <>z__ReadOnlySingleElementList<object>(commonItemCount));
			ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(num.Value);
			if (config == null)
			{
				return;
			}
			base.SetTextureByPath(config.Value.Icon, base.GetTexture(3), null, null);
			QualityInfo? qualityConfig = ConfigBase<ItemConfig>.Instance.GetQualityConfig(config.Value.QualityId);
			if (qualityConfig == null)
			{
				return;
			}
			this.SetSpriteByPath(qualityConfig.Value.ComposeQualityBg, base.GetSprite(2), false, null, null);
			List<IBaseItemData> sameGroupItem = ModelBase<ComposeModel>.Instance.GetSameGroupItem(this.CurrentData);
			IBaseItemData currentData = this.CurrentData;
			int? num2 = (currentData != null) ? new int?(currentData.ConfigId) : null;
			int configId = sameGroupItem[0].ConfigId;
			if (num2.GetValueOrDefault() == configId & num2 != null)
			{
				UUISprite sprite = base.GetSprite(0);
				if (sprite != null)
				{
					sprite.SetUIActive(false);
				}
			}
			if (data.IsUnlock > 0)
			{
				return;
			}
			base.GetItem(4).SetUIActive(true);
		}

		// Token: 0x0603A374 RID: 238452 RVA: 0x00EBFB48 File Offset: 0x00EBDD48
		public override void OnSelect()
		{
			Action<IBaseItemData, EComposeListType, bool?> buttonFunction = this.ButtonFunction;
			if (buttonFunction != null)
			{
				buttonFunction(this.CurrentData, this.CurrentData.MainType, null);
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x0603A375 RID: 238453 RVA: 0x00EBFB95 File Offset: 0x00EBDD95
		private void SelectedItem(EToggleState toggleState)
		{
			Action<IBaseItemData, EComposeListType, bool?> buttonFunction = this.ButtonFunction;
			if (buttonFunction != null)
			{
				buttonFunction(this.CurrentData, this.CurrentData.MainType, new bool?(true));
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x0603A376 RID: 238454 RVA: 0x00EBFBD4 File Offset: 0x00EBDDD4
		protected override void OnUnSelect()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603A377 RID: 238455 RVA: 0x00EBFBEB File Offset: 0x00EBDDEB
		private bool CheckCanClick()
		{
			return this.CheckToggleCanClick == null || this.CheckToggleCanClick();
		}

		// Token: 0x0603A378 RID: 238456 RVA: 0x00EBFC02 File Offset: 0x00EBDE02
		public ComposeCircleItem() : base(null)
		{
		}

		// Token: 0x0402100C RID: 135180
		public Action<IBaseItemData, EComposeListType, bool?> ButtonFunction;

		// Token: 0x0402100D RID: 135181
		public Func<bool> CheckToggleCanClick;

		// Token: 0x0402100E RID: 135182
		private IBaseItemData CurrentData;

		// Token: 0x0402100F RID: 135183
		public UCurveFloat ItemCurve;

		// Token: 0x0200B991 RID: 47505
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04039555 RID: 234837
			public const int LineSprite = 0;

			// Token: 0x04039556 RID: 234838
			public const int Toggle = 1;

			// Token: 0x04039557 RID: 234839
			public const int QualitySprite = 2;

			// Token: 0x04039558 RID: 234840
			public const int ItemTexture = 3;

			// Token: 0x04039559 RID: 234841
			public const int LockItem = 4;

			// Token: 0x0403955A RID: 234842
			public const int NumberText = 5;
		}
	}
}
