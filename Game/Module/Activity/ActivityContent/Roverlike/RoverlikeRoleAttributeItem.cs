using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063ED RID: 25581
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeRoleAttributeItem : GridProxyAbstract<CSharpScript.Game.Module.Common.AttributeData>
	{
		// Token: 0x060403A8 RID: 263080 RVA: 0x01075A20 File Offset: 0x01073C20
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060403A9 RID: 263081 RVA: 0x01075B10 File Offset: 0x01073D10
		[NullableContext(1)]
		public override void Refresh(CSharpScript.Game.Module.Common.AttributeData data, bool isSelected, int gridIndex)
		{
			PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(data.Id);
			if (propertyIndexInfo == null)
			{
				return;
			}
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			RoverlikeActivityData roverlikeActivityData = (instance != null) ? instance.GetCurrentActivityData() : null;
			string priorityAttributeName = this.GetPriorityAttributeName(roverlikeActivityData.GetParamConfig().Value, data.Id);
			if (!StringUtils.IsEmpty(priorityAttributeName))
			{
				UUIText text = base.GetText(1);
				if (text != null)
				{
					text.ShowTextNew(priorityAttributeName);
				}
			}
			else
			{
				UUIText text2 = base.GetText(1);
				if (text2 != null)
				{
					text2.ShowTextNew(propertyIndexInfo.Value.Name);
				}
			}
			UUITexture texture = base.GetTexture(0);
			if (texture != null)
			{
				base.SetTextureByPath(propertyIndexInfo.Value.Icon, texture, null, null);
			}
			string formatAttributeValueString = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(data.Id, (double)data.CurValue, data.IsRatio);
			UUIText text3 = base.GetText(2);
			if (text3 != null)
			{
				text3.SetText(formatAttributeValueString, true);
			}
			this.SetBgActive(data.BgActive.GetValueOrDefault());
		}

		// Token: 0x060403AA RID: 263082 RVA: 0x01075C18 File Offset: 0x01073E18
		private void SetBgActive(bool bActive)
		{
			UUIItem item = base.GetItem(5);
			UUIItem uuiitem = item;
			bool bUseChangeColor = !bActive;
			FColor? fcolor = new FColor?(item.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x060403AB RID: 263083 RVA: 0x01075C48 File Offset: 0x01073E48
		[NullableContext(2)]
		private string GetPriorityAttributeName(RoverRogueActivity activityConfig, int attrId)
		{
			for (int i = 0; i < activityConfig.AttributeNameLength; i++)
			{
				DicIntString? dicIntString = activityConfig.AttributeName(i);
				if (dicIntString != null && dicIntString.GetValueOrDefault().Key == attrId)
				{
					return dicIntString.Value.Value;
				}
			}
			return null;
		}

		// Token: 0x0200C451 RID: 50257
		private enum EComponents
		{
			// Token: 0x0403C6E7 RID: 247527
			TexIcon,
			// Token: 0x0403C6E8 RID: 247528
			TxtAttributeTxt,
			// Token: 0x0403C6E9 RID: 247529
			TxtNumber,
			// Token: 0x0403C6EA RID: 247530
			Sprite1,
			// Token: 0x0403C6EB RID: 247531
			Sprite2,
			// Token: 0x0403C6EC RID: 247532
			Bg
		}
	}
}
