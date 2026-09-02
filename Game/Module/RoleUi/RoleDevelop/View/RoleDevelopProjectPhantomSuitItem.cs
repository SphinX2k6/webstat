using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050BD RID: 20669
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleDevelopProjectPhantomSuitItem : GridProxyAbstract<RoleDevelopPhantomSuitData>
	{
		// Token: 0x0603540C RID: 218124 RVA: 0x00D59E14 File Offset: 0x00D58014
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickFetter));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603540D RID: 218125 RVA: 0x00D59F20 File Offset: 0x00D58120
		private void OnClickFetter()
		{
			bool showFastFilter = ModelBase<RoleModel>.Instance.IsRoleOwned(this.Data.DevelopRoleId);
			ControllerBase<PhantomBattleController>.Instance.OpenPhantomBattleFetterView(this.Data.FetterGroupId, this.Data.DevelopRoleId, showFastFilter, this.Data.VisionFetterRecommendInfo.BuildFetterList()).Forget();
		}

		// Token: 0x0603540E RID: 218126 RVA: 0x00D59F7C File Offset: 0x00D5817C
		protected override UniTask OnBeforeStartAsync()
		{
			RoleDevelopProjectPhantomSuitItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevelopProjectPhantomSuitItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603540F RID: 218127 RVA: 0x00D59FC0 File Offset: 0x00D581C0
		public unsafe override void Refresh(RoleDevelopPhantomSuitData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data.FetterGroupId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), fetterGroupById.FetterGroupName, Array.Empty<object>());
			bool flag = !string.IsNullOrEmpty(fetterGroupById.FetterElementPath);
			this.SuitItem.SetUiActive(flag);
			if (flag)
			{
				this.SuitItem.Update(new PhantomFetterGroup?(fetterGroupById));
			}
			List<RoleDevelopPhantomVisionSuitItemData> list = new List<RoleDevelopPhantomVisionSuitItemData>();
			if (data.FirstVisionMonsterId != null)
			{
				IReadOnlyList<PhantomItem> phantomItemByMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(data.FirstVisionMonsterId.Value);
				if (phantomItemByMonsterId != null && phantomItemByMonsterId.Count > 0 && phantomItemByMonsterId[0].FetterGroup().Contains(data.FetterGroupId))
				{
					RoleDevelopPhantomVisionSuitItemData item = RoleDevelopUtil.CreateFetterGroupVisionSuitItem(data.FetterGroupId, data.DevelopRoleId, data.FirstVisionMonsterId.Value);
					list.Add(item);
				}
			}
			RoleDevPhantomJumpGroup? phantomJumpGroupConfig = ConfigBase<RoleDevConfig>.Instance.GetPhantomJumpGroupConfig(data.FetterGroupId);
			if (phantomJumpGroupConfig != null)
			{
				Span<int> phantomJumpIdBytes = phantomJumpGroupConfig.Value.GetPhantomJumpIdBytes();
				for (int i = 0; i < phantomJumpIdBytes.Length; i++)
				{
					RoleDevelopPhantomVisionSuitItemData roleDevelopPhantomVisionSuitItemData = RoleDevelopUtil.CreateDungeonVisionSuitItem(*phantomJumpIdBytes[i], data.DevelopRoleId);
					if (roleDevelopPhantomVisionSuitItemData != null)
					{
						list.Add(roleDevelopPhantomVisionSuitItemData);
					}
				}
			}
			this.VisionSuitLayout.RefreshByData(list, null, false);
			base.GetButton(4).RootUIComp.Get().SetUIActive(data.IsNeedFetterButton.GetValueOrDefault());
		}

		// Token: 0x06035410 RID: 218128 RVA: 0x00D5A156 File Offset: 0x00D58356
		public override object GetKey(RoleDevelopPhantomSuitData data, int gridIndex)
		{
			return data.FetterGroupId;
		}

		// Token: 0x06035411 RID: 218129 RVA: 0x00D5A163 File Offset: 0x00D58363
		private RoleDevelopProjectPhantomVisionSuitItem CreateVisionSuitItem()
		{
			return new RoleDevelopProjectPhantomVisionSuitItem();
		}

		// Token: 0x0401EA3E RID: 125502
		[Nullable(2)]
		private RoleDevelopPhantomSuitData Data;

		// Token: 0x0401EA3F RID: 125503
		private VisionFetterSuitItem SuitItem;

		// Token: 0x0401EA40 RID: 125504
		private GenericLayout<RoleDevelopProjectPhantomVisionSuitItem, RoleDevelopPhantomVisionSuitItemData> VisionSuitLayout;

		// Token: 0x0200B04A RID: 45130
		[NullableContext(0)]
		public static class EComponentType
		{
			// Token: 0x04036B0F RID: 224015
			public const int PanelElementIcon = 0;

			// Token: 0x04036B10 RID: 224016
			public const int TxtSuitName = 1;

			// Token: 0x04036B11 RID: 224017
			public const int TxtUseRate = 2;

			// Token: 0x04036B12 RID: 224018
			public const int PanelVisionSuitLayout = 3;

			// Token: 0x04036B13 RID: 224019
			public const int ButtonFetter = 4;
		}
	}
}
