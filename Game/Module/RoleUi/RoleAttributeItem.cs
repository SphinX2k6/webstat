using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi
{
	// Token: 0x02005059 RID: 20569
	public class RoleAttributeItem : UiPanelBase
	{
		// Token: 0x06034F43 RID: 216899 RVA: 0x00D475E0 File Offset: 0x00D457E0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
		}

		// Token: 0x06034F44 RID: 216900 RVA: 0x00D4767C File Offset: 0x00D4587C
		[NullableContext(1)]
		public void Refresh(IAttributeInfo attrInfo)
		{
			this.RefreshName(attrInfo.Name);
			this.RefreshIcon(attrInfo.IconPath);
			base.GetItem(2).SetUIActive(attrInfo.ShowArrow.GetValueOrDefault(true));
			UUIText[] array = new UUIText[]
			{
				base.GetText(3),
				base.GetText(1)
			};
			string[] array2 = new string[]
			{
				attrInfo.PreText,
				attrInfo.CurText
			};
			for (int i = 0; i < array.Length; i++)
			{
				this.RefreshValueText(array[i], array2[i]);
			}
			if (attrInfo.InnerShowBg != null)
			{
				this.RefreshBgActive(attrInfo.InnerShowBg.Value);
			}
		}

		// Token: 0x06034F45 RID: 216901 RVA: 0x00D47730 File Offset: 0x00D45930
		[NullableContext(2)]
		private void RefreshIcon(string path)
		{
			if (path != null)
			{
				base.SetTextureByPath(path, base.GetTexture(4), null, null);
			}
			base.GetTexture(4).SetUIActive(path != null);
		}

		// Token: 0x06034F46 RID: 216902 RVA: 0x00D47768 File Offset: 0x00D45968
		[NullableContext(2)]
		private void RefreshName(string textId)
		{
			if (textId != null)
			{
				base.GetText(0).ShowTextNew(textId);
			}
			base.GetText(0).SetUIActive(textId != null);
		}

		// Token: 0x06034F47 RID: 216903 RVA: 0x00D4778A File Offset: 0x00D4598A
		[NullableContext(1)]
		private void RefreshValueText(UUIText textItem, [Nullable(2)] string text)
		{
			if (text != null)
			{
				textItem.SetText(text, true);
			}
			textItem.SetUIActive(text != null);
		}

		// Token: 0x06034F48 RID: 216904 RVA: 0x00D477A4 File Offset: 0x00D459A4
		private void RefreshBgActive(bool bActive)
		{
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(bActive);
			}
		}

		// Token: 0x0200AFFC RID: 45052
		private enum EAttributeItemNode
		{
			// Token: 0x0403697E RID: 223614
			AttributeText,
			// Token: 0x0403697F RID: 223615
			ValueText,
			// Token: 0x04036980 RID: 223616
			ArrowItem,
			// Token: 0x04036981 RID: 223617
			PreValueText,
			// Token: 0x04036982 RID: 223618
			AttributeIcon,
			// Token: 0x04036983 RID: 223619
			Bg
		}
	}
}
