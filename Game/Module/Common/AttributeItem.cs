using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common
{
	// Token: 0x02005E40 RID: 24128
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AttributeItem : GridProxyAbstract<AttributeData>
	{
		// Token: 0x0603CB76 RID: 248694 RVA: 0x00F6B5DC File Offset: 0x00F697DC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CB77 RID: 248695 RVA: 0x00F6B6C9 File Offset: 0x00F698C9
		protected override void OnStart()
		{
			this.NextItem = base.GetItem(2);
			UUIItem nextItem = this.NextItem;
			if (nextItem == null)
			{
				return;
			}
			nextItem.SetUIActive(false);
		}

		// Token: 0x0603CB78 RID: 248696 RVA: 0x00F6B6EC File Offset: 0x00F698EC
		private void InitCommon()
		{
			PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(this.Id);
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.ShowTextNew(propertyIndexInfo.Value.Name);
			}
			UUITexture texture = base.GetTexture(4);
			if (texture != null)
			{
				base.SetTextureByPath(propertyIndexInfo.Value.Icon, texture, null, null);
			}
		}

		// Token: 0x0603CB79 RID: 248697 RVA: 0x00F6B756 File Offset: 0x00F69956
		public void UpdateParam(int id, bool isRatio)
		{
			this.Id = id;
			this.IsRatio = isRatio;
			this.InitCommon();
		}

		// Token: 0x0603CB7A RID: 248698 RVA: 0x00F6B76C File Offset: 0x00F6996C
		public void SetCurrentValue(float currentValue)
		{
			string formatAttributeValueString = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(this.Id, (double)currentValue, this.IsRatio);
			this.CurrentValue = formatAttributeValueString;
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(this.CurrentValue, true);
		}

		// Token: 0x0603CB7B RID: 248699 RVA: 0x00F6B7B4 File Offset: 0x00F699B4
		public void SetNextValue(float nextValue)
		{
			string formatAttributeValueString = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(this.Id, (double)nextValue, this.IsRatio);
			if (!string.IsNullOrEmpty(this.CurrentValue) && this.CurrentValue == formatAttributeValueString)
			{
				this.SetNextItemActive(false);
				return;
			}
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.SetText(formatAttributeValueString, true);
		}

		// Token: 0x0603CB7C RID: 248700 RVA: 0x00F6B810 File Offset: 0x00F69A10
		public void SetNextItemActive(bool bActive)
		{
			UUIItem nextItem = this.NextItem;
			if (nextItem != null)
			{
				nextItem.SetUIActive(bActive);
			}
			base.GetText(3).SetUIActive(bActive);
		}

		// Token: 0x0603CB7D RID: 248701 RVA: 0x00F6B831 File Offset: 0x00F69A31
		public int GetAttributeId()
		{
			return this.Id;
		}

		// Token: 0x0603CB7E RID: 248702 RVA: 0x00F6B83C File Offset: 0x00F69A3C
		public virtual void SetBgActive(bool bActive)
		{
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(bActive);
			}
		}

		// Token: 0x0603CB7F RID: 248703 RVA: 0x00F6B85C File Offset: 0x00F69A5C
		public void RefreshNameByAnotherName()
		{
			PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(this.Id);
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(propertyIndexInfo.Value.AnotherName);
		}

		// Token: 0x0603CB80 RID: 248704 RVA: 0x00F6B89C File Offset: 0x00F69A9C
		public override void Refresh(AttributeData data, bool isSelected, int gridIndex)
		{
			this.UpdateParam(data.Id, data.IsRatio);
			this.SetCurrentValue(data.CurValue);
			this.SetNextItemActive(data.ShowNext.GetValueOrDefault());
			if (data.NextValue != null)
			{
				this.SetNextValue(data.NextValue.Value);
			}
			if (data.UseAnotherName != null && data.UseAnotherName.Value)
			{
				this.RefreshNameByAnotherName();
			}
			this.SetBgActive(data.BgActive.GetValueOrDefault());
		}

		// Token: 0x0402217A RID: 139642
		[Nullable(2)]
		protected UUIItem NextItem;

		// Token: 0x0402217B RID: 139643
		private string CurrentValue = "";

		// Token: 0x0402217C RID: 139644
		private int Id;

		// Token: 0x0402217D RID: 139645
		private bool IsRatio;

		// Token: 0x0200BE6F RID: 48751
		[NullableContext(0)]
		private class EAttributeItemDefine
		{
			// Token: 0x0403AA27 RID: 240167
			public const int Name = 0;

			// Token: 0x0403AA28 RID: 240168
			public const int CurrentValue = 1;

			// Token: 0x0403AA29 RID: 240169
			public const int NextItem = 2;

			// Token: 0x0403AA2A RID: 240170
			public const int NextValue = 3;

			// Token: 0x0403AA2B RID: 240171
			public const int Icon = 4;

			// Token: 0x0403AA2C RID: 240172
			public const int Bg = 5;
		}
	}
}
