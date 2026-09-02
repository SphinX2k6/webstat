using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E28 RID: 20008
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseResultOrganUnlockItem : GridProxyAbstract<ITrapDefenseResultUnlockInfo>
	{
		// Token: 0x06033B8E RID: 211854 RVA: 0x00CED98C File Offset: 0x00CEBB8C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033B8F RID: 211855 RVA: 0x00CEDA74 File Offset: 0x00CEBC74
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetItem(3));
		}

		// Token: 0x06033B90 RID: 211856 RVA: 0x00CEDA88 File Offset: 0x00CEBC88
		public override void Refresh(ITrapDefenseResultUnlockInfo data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			if (data.Type != ETrapDefenseResultUnlockType.Organ && data.Type != ETrapDefenseResultUnlockType.OrganShare)
			{
				return;
			}
			if (this.OrganData == null || this.OrganData.Id != data.Id)
			{
				ITrapDefenseMachineIdInfo trapDefenseMachineIdInfo = ModelBase<TrapDefenseModel>.Instance.DecomposeMachineId(data.Id);
				this.OrganData = TrapDefenseBuildingDevelopItemData.Create(data.Id, trapDefenseMachineIdInfo.MachineType);
			}
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(data.IsFinish.GetValueOrDefault());
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(data.IsNewUnlock.GetValueOrDefault());
			}
			base.SetTextureByPath(this.OrganData.GetIconPath(), base.GetTexture(1), null, null);
			this.Data.IsNewUnlock = null;
		}

		// Token: 0x06033B91 RID: 211857 RVA: 0x00CEDB67 File Offset: 0x00CEBD67
		private void OnClicked()
		{
			if (this.Data.Type != ETrapDefenseResultUnlockType.Organ)
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseBuildingMachineInfoView, this.OrganData, null);
		}

		// Token: 0x06033B92 RID: 211858 RVA: 0x00CEDB90 File Offset: 0x00CEBD90
		public void PlayUnlockAnim()
		{
			if (this.Data.Type != ETrapDefenseResultUnlockType.Organ)
			{
				return;
			}
			this.LevelSequencePlayer.PlayOrReplaySequenceByName("Unlock", false, null);
		}

		// Token: 0x0401DF23 RID: 122659
		protected ITrapDefenseResultUnlockInfo Data;

		// Token: 0x0401DF24 RID: 122660
		protected TrapDefenseBuildingDevelopItemData OrganData;

		// Token: 0x0401DF25 RID: 122661
		protected LevelSequencePlayer LevelSequencePlayer;
	}
}
