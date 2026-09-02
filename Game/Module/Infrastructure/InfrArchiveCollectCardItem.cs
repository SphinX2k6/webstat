using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C4E RID: 23630
	public class InfrArchiveCollectCardItem : GridProxyAbstract<int>
	{
		// Token: 0x0603BB32 RID: 244530 RVA: 0x00F1F448 File Offset: 0x00F1D648
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnItem));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnGo));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BB33 RID: 244531 RVA: 0x00F1F63D File Offset: 0x00F1D83D
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.ArchiveId = data;
			this.RefreshCardView();
		}

		// Token: 0x0603BB34 RID: 244532 RVA: 0x00F1F64C File Offset: 0x00F1D84C
		private void RefreshCardView()
		{
			InfrArchiveItem? archiveItemConfig = ConfigBase<InfrastructureConfig>.Instance.GetArchiveItemConfig(this.ArchiveId);
			bool flag = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(archiveItemConfig.Value.ItemId, 0) > 0;
			ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(archiveItemConfig.Value.ItemId);
			base.GetItem(1).SetUIActive(!flag);
			base.GetItem(5).SetUIActive(flag);
			base.SetTextureByPath(config.Value.Icon, base.GetTexture(2), null, null);
			base.SetTextureByPath(config.Value.Icon, base.GetTexture(6), null, null);
			base.GetText(7).ShowTextNew(config.Value.Name);
			string archiveItemQualityPath = ConfigBase<InfrastructureConfig>.Instance.GetArchiveItemQualityPath(config.Value.QualityId);
			base.SetTextureByPath(archiveItemQualityPath, base.GetTexture(8), null, null);
			base.GetItem(9).SetUIActive(ModelBase<InfrastructureModel>.Instance.GetArchiveIsUnRead(this.ArchiveId));
			base.GetUiNiagara(10).SetNiagaraVarInt("Subuv", archiveItemConfig.Value.EffectId);
		}

		// Token: 0x0603BB35 RID: 244533 RVA: 0x00F1F7A0 File Offset: 0x00F1D9A0
		private void OnClickBtnItem()
		{
			InfrArchiveItem? archiveItemConfig = ConfigBase<InfrastructureConfig>.Instance.GetArchiveItemConfig(this.ArchiveId);
			bool flag = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(archiveItemConfig.Value.ItemId, 0) > 0;
			if (archiveItemConfig != null && flag)
			{
				if (ModelBase<InfrastructureModel>.Instance.GetArchiveIsUnRead(this.ArchiveId))
				{
					ControllerBase<InfrastructureController>.Instance.RequestInfrArchiveReadRequest(new int[]
					{
						this.ArchiveId
					});
				}
				ControllerBase<InfoDisplayController>.Instance.OpenInfoDisplay(archiveItemConfig.Value.InfoDisplayId, null, null, false, new ELayerType?(ELayerType.Pop));
			}
		}

		// Token: 0x0603BB36 RID: 244534 RVA: 0x00F1F838 File Offset: 0x00F1DA38
		private void OnClickBtnGo()
		{
			InfrArchiveItem? archiveItemConfig = ConfigBase<InfrastructureConfig>.Instance.GetArchiveItemConfig(this.ArchiveId);
			if (archiveItemConfig != null)
			{
				SkipTaskManager.RunByConfigId(archiveItemConfig.Value.AccessPath, null);
			}
		}

		// Token: 0x04021918 RID: 137496
		private int ArchiveId;

		// Token: 0x0200BCBF RID: 48319
		private class EChildType
		{
			// Token: 0x0403A264 RID: 238180
			public const int BtnItem = 0;

			// Token: 0x0403A265 RID: 238181
			public const int PanelLock = 1;

			// Token: 0x0403A266 RID: 238182
			public const int TextureCardIconLock = 2;

			// Token: 0x0403A267 RID: 238183
			public const int TextLockTitle = 3;

			// Token: 0x0403A268 RID: 238184
			public const int BtnGo = 4;

			// Token: 0x0403A269 RID: 238185
			public const int PanelUnlock = 5;

			// Token: 0x0403A26A RID: 238186
			public const int TextureCardIconUnlock = 6;

			// Token: 0x0403A26B RID: 238187
			public const int TextTitle = 7;

			// Token: 0x0403A26C RID: 238188
			public const int TextureQuality = 8;

			// Token: 0x0403A26D RID: 238189
			public const int PanelNew = 9;

			// Token: 0x0403A26E RID: 238190
			public const int NiagaraIcon = 10;
		}
	}
}
