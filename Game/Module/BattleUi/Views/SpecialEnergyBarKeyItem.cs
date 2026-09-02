using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Input;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060F7 RID: 24823
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarKeyItem : UiPanelBase
	{
		// Token: 0x0603EB7A RID: 256890 RVA: 0x0100E776 File Offset: 0x0100C976
		public void SetConfig(SpecialEnergyBarInfo config)
		{
			this.Config = config;
		}

		// Token: 0x0603EB7B RID: 256891 RVA: 0x0100E780 File Offset: 0x0100C980
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EB7C RID: 256892 RVA: 0x0100E7C8 File Offset: 0x0100C9C8
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarKeyItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarKeyItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB7D RID: 256893 RVA: 0x0100E80B File Offset: 0x0100CA0B
		protected override void OnStart()
		{
			this.SwitchToKeyInfoListInner(this.Config.KeyInfoList);
		}

		// Token: 0x0603EB7E RID: 256894 RVA: 0x0100E81E File Offset: 0x0100CA1E
		public void SwitchToDefault()
		{
			this.SwitchToKeyInfoListInner(this.Config.KeyInfoList);
		}

		// Token: 0x0603EB7F RID: 256895 RVA: 0x0100E831 File Offset: 0x0100CA31
		public void SwitchToKeyInfoList(List<SpecialEnergyBarKeyInfo> keyInfoList)
		{
			this.SwitchToKeyInfoListInner(keyInfoList);
		}

		// Token: 0x0603EB80 RID: 256896 RVA: 0x0100E83C File Offset: 0x0100CA3C
		protected void SwitchToKeyInfoListInner(List<SpecialEnergyBarKeyInfo> keyInfoList)
		{
			SpecialEnergyBarKeyInfo keyInfo = keyInfoList[0];
			SpecialEnergyBarKeyInfo valueOrDefault = keyInfoList.GetValueOrDefault(1);
			string linkString;
			if (this.Config.KeyType == 0)
			{
				linkString = string.Empty;
			}
			else
			{
				int keyType = this.Config.KeyType;
				if (keyType != 1)
				{
					if (keyType != 2)
					{
						linkString = "";
					}
					else
					{
						linkString = "/";
					}
				}
				else
				{
					linkString = "+";
				}
			}
			InputActionOrAxisKeyItemGroup inputActionOrAxisKeyItemGroup = new InputActionOrAxisKeyItemGroup
			{
				SingleActionOrAxisKeyItem = this.ConvertToInputActionOrAxisKeyItem(keyInfo),
				DoubleActionOrAxisKeyItem = ((valueOrDefault != null) ? this.ConvertToInputActionOrAxisKeyItem(valueOrDefault) : null),
				LinkString = linkString
			};
			InputMultiKeyItemGroup keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.Refresh(inputActionOrAxisKeyItemGroup);
			}
			InputMultiKeyItemGroup keyItem2 = this.KeyItem;
			if (keyItem2 == null)
			{
				return;
			}
			keyItem2.SetActive(true);
		}

		// Token: 0x0603EB81 RID: 256897 RVA: 0x0100E8F0 File Offset: 0x0100CAF0
		private InputActionOrAxisKeyItem ConvertToInputActionOrAxisKeyItem(SpecialEnergyBarKeyInfo keyInfo)
		{
			bool value = keyInfo.Action == 1;
			return new InputActionOrAxisKeyItem
			{
				ActionOrAxisName = EInputAction.Defines[keyInfo.ActionType].Name,
				IsLongPressProcessVisible = new bool?(value),
				IsTextArrowVisible = new bool?(value)
			};
		}

		// Token: 0x0603EB82 RID: 256898 RVA: 0x0100E93F File Offset: 0x0100CB3F
		public void RefreshKeyEnable(bool enable, bool bForce)
		{
			InputMultiKeyItemGroup keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.SetEnable(enable, bForce);
		}

		// Token: 0x040232C0 RID: 144064
		[Nullable(2)]
		private InputMultiKeyItemGroup KeyItem;

		// Token: 0x040232C1 RID: 144065
		[Nullable(2)]
		private SpecialEnergyBarInfo Config;

		// Token: 0x0200C279 RID: 49785
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BF4B RID: 245579
			InputMultiKeyItemGroupItem
		}
	}
}
