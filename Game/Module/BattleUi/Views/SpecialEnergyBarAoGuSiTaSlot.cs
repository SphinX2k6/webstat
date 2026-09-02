using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060AD RID: 24749
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarAoGuSiTaSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E7DD RID: 255965 RVA: 0x00FF9636 File Offset: 0x00FF7836
		protected override void OnInitData()
		{
			this.ExtraConfigList.Add(ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(130601));
			this.ExtraConfigList.Add(ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(130602));
		}

		// Token: 0x0603E7DE RID: 255966 RVA: 0x00FF9678 File Offset: 0x00FF7878
		protected override UniTask InitKeyItem(UUIItem keyItemContainer)
		{
			SpecialEnergyBarAoGuSiTaSlot.<InitKeyItem>d__4 <InitKeyItem>d__;
			<InitKeyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitKeyItem>d__.<>4__this = this;
			<InitKeyItem>d__.keyItemContainer = keyItemContainer;
			<InitKeyItem>d__.<>1__state = -1;
			<InitKeyItem>d__.<>t__builder.Start<SpecialEnergyBarAoGuSiTaSlot.<InitKeyItem>d__4>(ref <InitKeyItem>d__);
			return <InitKeyItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E7DF RID: 255967 RVA: 0x00FF96C3 File Offset: 0x00FF78C3
		public void SetKeyItemEnable(int type, bool enable, bool isStart = false)
		{
			this.KeyItemList[type].RefreshKeyEnable(enable, isStart);
		}

		// Token: 0x0603E7E0 RID: 255968 RVA: 0x00FF96D8 File Offset: 0x00FF78D8
		public void SetKeyItemType(int type)
		{
			if (this.KeyItemType == type)
			{
				return;
			}
			this.KeyItemType = type;
			for (int i = 0; i < this.KeyItemList.Count; i++)
			{
				this.KeyItemList[i].SetUiActive(type == i);
			}
		}

		// Token: 0x04023074 RID: 143476
		private readonly List<SpecialEnergyBarInfo> ExtraConfigList = new List<SpecialEnergyBarInfo>();

		// Token: 0x04023075 RID: 143477
		private readonly List<SpecialEnergyBarKeyItem> KeyItemList = new List<SpecialEnergyBarKeyItem>();

		// Token: 0x04023076 RID: 143478
		private int KeyItemType = -1;
	}
}
