using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x02006613 RID: 26131
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballItemTipsComponentContentComponent : UiPanelBase
	{
		// Token: 0x060414B9 RID: 267449 RVA: 0x010BFB0C File Offset: 0x010BDD0C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060414BA RID: 267450 RVA: 0x010BFC3B File Offset: 0x010BDE3B
		protected override void OnStart()
		{
			base.GetTexture(1).SetUIActive(false);
			this.SubComponent = new TipsMaterialComponent(base.GetItem(4));
		}

		// Token: 0x060414BB RID: 267451 RVA: 0x010BFC5C File Offset: 0x010BDE5C
		public void Refresh(ItemTipsData data)
		{
			this.RefreshBase(data);
			this.SubComponent.Refresh((TipsMaterialData)data);
			this.SetActive(true);
		}

		// Token: 0x060414BC RID: 267452 RVA: 0x010BFC7D File Offset: 0x010BDE7D
		private void RefreshBase(ItemTipsData data)
		{
			this.RefreshBaseName(data);
			this.RefreshBaseQuality(data);
			this.RefreshBaseIcon(data);
			this.SetDebugText(data.ConfigId);
		}

		// Token: 0x060414BD RID: 267453 RVA: 0x010BFCA0 File Offset: 0x010BDEA0
		private void RefreshBaseName(ItemTipsData data)
		{
			UUIText text = base.GetText(0);
			if (data.IsQualityByType)
			{
				text.SetUIActive(false);
				return;
			}
			FColor color = FColor.FromHex(ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetQualityConfig(data.QualityId).Value.TypeADropColor);
			base.GetText(0).SetColor(color);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.Title, Array.Empty<object>());
		}

		// Token: 0x060414BE RID: 267454 RVA: 0x010BFD10 File Offset: 0x010BDF10
		private void RefreshBaseQuality(ItemTipsData data)
		{
			UUIItem item = base.GetItem(7);
			if (data.IsQualityByType)
			{
				item.SetUIActive(false);
				return;
			}
			FColor color = FColor.FromHex(ConfigBase<InventoryConfig>.Instance.GetItemQualityConfig(data.QualityId).Value.TypeAItemTipsEffectColor);
			item.SetColor(color);
			item.SetUIActive(true);
		}

		// Token: 0x060414BF RID: 267455 RVA: 0x010BFD6C File Offset: 0x010BDF6C
		private void RefreshBaseIcon(ItemTipsData data)
		{
			base.GetTexture(2).SetUIActive(false);
			base.GetTexture(6).SetUIActive(false);
			UUITexture texture = base.GetTexture(2);
			if (data.IsShowIconBig())
			{
				texture = base.GetTexture(6);
			}
			if (data.IsIconByType)
			{
				texture.SetUIActive(false);
				return;
			}
			texture.SetUIActive(true);
			base.SetItemIcon(texture, data.ConfigId, null, null);
		}

		// Token: 0x060414C0 RID: 267456 RVA: 0x010BFDDC File Offset: 0x010BDFDC
		private void SetDebugText(int debugId)
		{
			UUIText text = base.GetText(5);
			if (!GlobalData.IsPlayInEditor)
			{
				text.SetUIActive(false);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalText(text, "CommonTipsDebugItemId", new <>z__ReadOnlySingleElementList<object>(debugId));
			text.SetUIActive(true);
		}

		// Token: 0x04024896 RID: 149654
		[Nullable(2)]
		public TipsMaterialComponent SubComponent;

		// Token: 0x0200C63A RID: 50746
		[NullableContext(0)]
		private enum EItemTipsComponentContent
		{
			// Token: 0x0403D045 RID: 249925
			Title,
			// Token: 0x0403D046 RID: 249926
			TexQuality,
			// Token: 0x0403D047 RID: 249927
			TexItemIcon256,
			// Token: 0x0403D048 RID: 249928
			NiagaraQuality,
			// Token: 0x0403D049 RID: 249929
			PanelContent,
			// Token: 0x0403D04A RID: 249930
			TxtDebug,
			// Token: 0x0403D04B RID: 249931
			TextureItemIcon732,
			// Token: 0x0403D04C RID: 249932
			QualityItem
		}
	}
}
