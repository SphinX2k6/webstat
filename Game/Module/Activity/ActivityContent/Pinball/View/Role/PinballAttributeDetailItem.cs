using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065C4 RID: 26052
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballAttributeDetailItem : GridProxyAbstract<IPinballAttributeDetailItemData>
	{
		// Token: 0x0604118E RID: 266638 RVA: 0x010B3B44 File Offset: 0x010B1D44
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnItemToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604118F RID: 266639 RVA: 0x010B3CD4 File Offset: 0x010B1ED4
		[NullableContext(1)]
		public override void Refresh(IPinballAttributeDetailItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			PinballPropertyIndex attributeConfig = data.AttributeConfig;
			base.SetTextureByPath(attributeConfig.Icon, base.GetTexture(2), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), attributeConfig.Name, Array.Empty<object>());
			string formatAttributeValueString = ModelBase<PinballModel>.Instance.GetFormatAttributeValueString(attributeConfig, (float)data.AttributeValue);
			base.GetText(4).SetText(formatAttributeValueString, true);
			base.GetSprite(1).SetUIActive(data.IsBgShow);
			base.GetText(5).SetUIActive(false);
			this.HasDesc = !StringUtils.IsBlank(attributeConfig.Desc);
			base.GetSprite(6).SetUIActive(this.HasDesc);
			if (this.HasDesc)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), attributeConfig.Desc, Array.Empty<object>());
			}
			base.GetExtendToggle(0).SetToggleState(data.IsExpanded ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			this.RefreshExpanded();
		}

		// Token: 0x06041190 RID: 266640 RVA: 0x010B3DD8 File Offset: 0x010B1FD8
		public void RefreshExpanded()
		{
			base.GetLayoutBase(7).RootUIComp.Get().SetUIActive(this.HasDesc && this.Data.IsExpanded);
		}

		// Token: 0x06041191 RID: 266641 RVA: 0x010B3E14 File Offset: 0x010B2014
		private void OnItemToggleClick(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.Data.IsExpanded = true;
			}
			else
			{
				this.Data.IsExpanded = false;
			}
			this.RefreshExpanded();
		}

		// Token: 0x04024780 RID: 149376
		[Nullable(2)]
		protected IPinballAttributeDetailItemData Data;

		// Token: 0x04024781 RID: 149377
		protected bool HasDesc;

		// Token: 0x0200C5C7 RID: 50631
		private enum EComponent
		{
			// Token: 0x0403CDFC RID: 249340
			ItemToggle,
			// Token: 0x0403CDFD RID: 249341
			BgSprite,
			// Token: 0x0403CDFE RID: 249342
			AttrIconTexture,
			// Token: 0x0403CDFF RID: 249343
			AttrNameText,
			// Token: 0x0403CE00 RID: 249344
			AttrValueText,
			// Token: 0x0403CE01 RID: 249345
			AttrAdditionValueText,
			// Token: 0x0403CE02 RID: 249346
			ArrowSprite,
			// Token: 0x0403CE03 RID: 249347
			DescLayout,
			// Token: 0x0403CE04 RID: 249348
			DescText
		}
	}
}
