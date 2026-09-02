using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Vision.View
{
	// Token: 0x02005460 RID: 21600
	[NullableContext(1)]
	[Nullable(0)]
	public class AttributeItem : UiPanelBase
	{
		// Token: 0x06037055 RID: 225365 RVA: 0x00DF71BB File Offset: 0x00DF53BB
		public AttributeItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x06037056 RID: 225366 RVA: 0x00DF71D0 File Offset: 0x00DF53D0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06037057 RID: 225367 RVA: 0x00DF72DE File Offset: 0x00DF54DE
		protected override void OnStart()
		{
			this.Layout = new GenericLayoutNew<AttributePhantomItem>(base.GetLayoutBase(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<AttributePhantomItem>(this.InitItem), null);
		}

		// Token: 0x06037058 RID: 225368 RVA: 0x00DF7300 File Offset: 0x00DF5500
		private ILayoutItem<AttributePhantomItem> InitItem(object data, UUIItem uiItem, int index)
		{
			AttributePhantomItem attributePhantomItem = new AttributePhantomItem(uiItem);
			attributePhantomItem.Update((int)data, this.CurrentFetter.Value);
			return new LayoutItem<AttributePhantomItem>
			{
				Key = index,
				Value = attributePhantomItem
			};
		}

		// Token: 0x06037059 RID: 225369 RVA: 0x00DF7343 File Offset: 0x00DF5543
		protected override void OnBeforeDestroy()
		{
			this.Layout.ClearChildren();
		}

		// Token: 0x0603705A RID: 225370 RVA: 0x00DF7350 File Offset: 0x00DF5550
		public void Update(VisionAttributeVariantTwoData data)
		{
			base.GetItem(3).SetUIActive(false);
			base.GetItem(4).SetUIActive(false);
			base.GetItem(5).SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			PhantomFetter phantomFetterById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomFetterById(data.FetterId);
			this.CurrentFetter = new PhantomFetter?(phantomFetterById);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), phantomFetterById.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), phantomFetterById.EffectDescription, phantomFetterById.EffectDescriptionParam());
			string hexStr = "AEAEABFF";
			if (data.State == EFetterCompare.Decrease)
			{
				hexStr = "D05656FF";
				base.GetItem(6).SetUIActive(true);
			}
			else if (data.State == EFetterCompare.Add)
			{
				hexStr = "87C583FF";
				base.GetItem(5).SetUIActive(true);
			}
			else
			{
				int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
				if (ControllerBase<PhantomBattleController>.Instance.CheckFetterActivate(data.FetterId, curSelectMainRoleId.GetValueOrDefault()))
				{
					hexStr = "87C583FF";
					base.GetItem(4).SetUIActive(true);
				}
				else
				{
					base.GetItem(3).SetUIActive(true);
				}
			}
			FColor color = FColor.FromHex(hexStr);
			base.GetText(0).SetColor(color);
			base.GetText(2).SetColor(color);
		}

		// Token: 0x0401FA7B RID: 129659
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected GenericLayoutNew<AttributePhantomItem> Layout;

		// Token: 0x0401FA7C RID: 129660
		private PhantomFetter? CurrentFetter;

		// Token: 0x0200B3C2 RID: 46018
		[NullableContext(0)]
		private enum EAttributeItemComponent
		{
			// Token: 0x04037AA9 RID: 228009
			Title,
			// Token: 0x04037AAA RID: 228010
			ItemLayout,
			// Token: 0x04037AAB RID: 228011
			Desc,
			// Token: 0x04037AAC RID: 228012
			StateItem1,
			// Token: 0x04037AAD RID: 228013
			StateItem2,
			// Token: 0x04037AAE RID: 228014
			StateItem3,
			// Token: 0x04037AAF RID: 228015
			StateItem4
		}
	}
}
