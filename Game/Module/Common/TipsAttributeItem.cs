using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common
{
	// Token: 0x02005E47 RID: 24135
	public class TipsAttributeItem : UiPanelBase
	{
		// Token: 0x0603CBB6 RID: 248758 RVA: 0x00F6C4F2 File Offset: 0x00F6A6F2
		[NullableContext(1)]
		public TipsAttributeItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603CBB7 RID: 248759 RVA: 0x00F6C507 File Offset: 0x00F6A707
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x0603CBB8 RID: 248760 RVA: 0x00F6C540 File Offset: 0x00F6A740
		[NullableContext(1)]
		public void UpdateItem(CommonComponentDefine.TipsAttributeData data)
		{
			string propertyIndexName = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexName(data.Id);
			base.GetText(0).ShowTextNew(propertyIndexName);
			base.GetText(1).SetText(ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(data.Id, data.Value, data.IsRatio), true);
		}

		// Token: 0x0200BE73 RID: 48755
		private enum ETipsAttributeItemDefine
		{
			// Token: 0x0403AA44 RID: 240196
			AttributeName,
			// Token: 0x0403AA45 RID: 240197
			AttributeValue
		}
	}
}
