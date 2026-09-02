using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050BB RID: 20667
	public class RoleDevelopProjectPhantomItem : UiPanelBase
	{
		// Token: 0x060353F8 RID: 218104 RVA: 0x00D594C4 File Offset: 0x00D576C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickHeadItem));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060353F9 RID: 218105 RVA: 0x00D59674 File Offset: 0x00D57874
		protected override UniTask OnBeforeStartAsync()
		{
			RoleDevelopProjectPhantomItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevelopProjectPhantomItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060353FA RID: 218106 RVA: 0x00D596B8 File Offset: 0x00D578B8
		[NullableContext(1)]
		public void Refresh(RoleDevelopData developData, int phantomIncId, int index)
		{
			this.DevelopData = developData;
			this.PhantomIncId = phantomIncId;
			this.Index = index;
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(this.PhantomIncId);
			if (phantomBattleData == null)
			{
				base.GetItem(8).SetUIActive(false);
				base.GetItem(9).SetUIActive(true);
				return;
			}
			base.GetItem(8).SetUIActive(true);
			base.GetItem(9).SetUIActive(false);
			this.VisionFetterSuitItem.Update(new PhantomFetterGroup?(phantomBattleData.GetFetterGroupConfig()));
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(phantomBattleData.GetConfigId(true));
			base.SetTextureByPath(itemConfigData.Icon, base.GetTexture(1), null, null);
			int quality = phantomBattleData.GetQuality();
			this.SetSpriteByPath(ConfigBase<PhantomBattleConfig>.Instance.GetPhantomQualityBgSprite(quality), base.GetSprite(2), false, null, null);
			base.GetText(4).SetText(phantomBattleData.GetCost().ToString(), true);
			base.GetText(7).SetText("+" + phantomBattleData.GetPhantomLevel().ToString(), true);
		}

		// Token: 0x060353FB RID: 218107 RVA: 0x00D597D8 File Offset: 0x00D579D8
		private void OnClickHeadItem()
		{
			if (this.DevelopData == null)
			{
				return;
			}
			int id = this.DevelopData.GetId();
			ModelBase<PhantomBattleModel>.Instance.CurrentEquipmentSelectIndex = this.Index;
			int equipByIndex = ControllerBase<PhantomBattleController>.Instance.GetEquipByIndex(id, this.Index);
			ModelBase<PhantomBattleModel>.Instance.CurrentSelectUniqueId = equipByIndex;
			PhantomUtil.OpenVisionEquipmentView(id, this.Index, null);
		}

		// Token: 0x0401EA34 RID: 125492
		[Nullable(2)]
		private RoleDevelopData DevelopData;

		// Token: 0x0401EA35 RID: 125493
		private int PhantomIncId;

		// Token: 0x0401EA36 RID: 125494
		[Nullable(1)]
		private VisionFetterSuitItem VisionFetterSuitItem;

		// Token: 0x0401EA37 RID: 125495
		private int Index;

		// Token: 0x0200B044 RID: 45124
		public static class EComponentType
		{
			// Token: 0x04036AEA RID: 223978
			public const int ButtonHeadItem = 0;

			// Token: 0x04036AEB RID: 223979
			public const int CircleItemTexture = 1;

			// Token: 0x04036AEC RID: 223980
			public const int QualitySprite = 2;

			// Token: 0x04036AED RID: 223981
			public const int CostItem = 3;

			// Token: 0x04036AEE RID: 223982
			public const int CostNumText = 4;

			// Token: 0x04036AEF RID: 223983
			public const int SuitElementItem = 5;

			// Token: 0x04036AF0 RID: 223984
			public const int LevelItem = 6;

			// Token: 0x04036AF1 RID: 223985
			public const int LevelText = 7;

			// Token: 0x04036AF2 RID: 223986
			public const int PanelNor = 8;

			// Token: 0x04036AF3 RID: 223987
			public const int PanelEmpty = 9;
		}
	}
}
