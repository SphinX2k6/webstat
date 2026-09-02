using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Dango
{
	// Token: 0x02005DDF RID: 24031
	[NullableContext(1)]
	[Nullable(0)]
	internal class RoleInfoPanel : UiPanelBase
	{
		// Token: 0x0603C7DE RID: 247774 RVA: 0x00F5D01C File Offset: 0x00F5B21C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIMultiTemplateLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x0603C7DF RID: 247775 RVA: 0x00F5D076 File Offset: 0x00F5B276
		protected override void OnStart()
		{
			this.Layout = new GenericLayout<AttributeItem, AttributeItemData>(base.GetMultiTemplateLayout(1), new Func<AttributeItem>(this.CreateAttributeItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x0603C7E0 RID: 247776 RVA: 0x00F5D0A9 File Offset: 0x00F5B2A9
		private AttributeItem CreateAttributeItem()
		{
			return new AttributeItem();
		}

		// Token: 0x0603C7E1 RID: 247777 RVA: 0x00F5D0B0 File Offset: 0x00F5B2B0
		public void Refresh(AbyssDangoRoleData data)
		{
			string name = data.GetName();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), name, Array.Empty<object>());
			this.RefreshAttribute(data);
		}

		// Token: 0x0603C7E2 RID: 247778 RVA: 0x00F5D0E4 File Offset: 0x00F5B2E4
		private void RefreshAttribute(AbyssDangoRoleData data)
		{
			AttributeItemData attributeItemData = new AttributeItemData();
			attributeItemData.DangoRoleData = data;
			GenericLayout<AttributeItem, AttributeItemData> layout = this.Layout;
			if (layout == null)
			{
				return;
			}
			layout.RefreshByData(new <>z__ReadOnlySingleElementList<AttributeItemData>(attributeItemData), null, false);
		}

		// Token: 0x0402202F RID: 139311
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<AttributeItem, AttributeItemData> Layout;

		// Token: 0x0200BE37 RID: 48695
		[NullableContext(0)]
		internal enum ERoleInfoComponent
		{
			// Token: 0x0403A8FC RID: 239868
			NameText,
			// Token: 0x0403A8FD RID: 239869
			AttributeTagLayout,
			// Token: 0x0403A8FE RID: 239870
			AttributeItem
		}
	}
}
