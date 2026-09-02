using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BE2 RID: 23522
	public class InstanceDungeonBuffItem : UiPanelBase
	{
		// Token: 0x0603B8C6 RID: 243910 RVA: 0x00F1818C File Offset: 0x00F1638C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnMonster));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B8C7 RID: 243911 RVA: 0x00F18254 File Offset: 0x00F16454
		[NullableContext(2)]
		public void RefreshItem(string buffText, bool showMonsterPreview, InstanceDungeonBuffItem.EBuffInfoType buffInfoType = InstanceDungeonBuffItem.EBuffInfoType.Buff)
		{
			this.ItemDataHandle = new InstanceDungeonBuffItemData
			{
				BuffText = buffText,
				ShowMonsterPreview = showMonsterPreview,
				BuffInfoType = buffInfoType
			};
			InstanceDungeonBuffItem.EBuffInfoType buffInfoType2 = this.ItemDataHandle.BuffInfoType;
			if (buffInfoType2 != InstanceDungeonBuffItem.EBuffInfoType.Buff)
			{
				if (buffInfoType2 == InstanceDungeonBuffItem.EBuffInfoType.Resistance)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "WeeklyBossInfo_OuterTitle", Array.Empty<object>());
				}
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "PrefabTextItem_3585581324_Text", Array.Empty<object>());
			}
			base.GetButton(1).RootUIComp.Get().SetUIActive(showMonsterPreview);
			if (string.IsNullOrEmpty(buffText))
			{
				base.GetText(0).SetUIActive(false);
				return;
			}
			base.GetText(0).SetUIActive(true);
			base.GetText(0).ShowTextNew(buffText);
		}

		// Token: 0x0603B8C8 RID: 243912 RVA: 0x00F18318 File Offset: 0x00F16518
		private void OnClickBtnMonster()
		{
			int selectInstanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId;
			InstanceDungeonMonsterView.InstanceDungeonMonsterViewOpenParam instanceDungeonMonsterViewOpenParam = new InstanceDungeonMonsterView.InstanceDungeonMonsterViewOpenParam();
			instanceDungeonMonsterViewOpenParam.InstanceId = selectInstanceId;
			InstanceDungeonBuffItemData itemDataHandle = this.ItemDataHandle;
			instanceDungeonMonsterViewOpenParam.InfoType = new InstanceDungeonBuffItem.EBuffInfoType?((itemDataHandle != null) ? itemDataHandle.BuffInfoType : InstanceDungeonBuffItem.EBuffInfoType.Buff);
			InstanceDungeonMonsterView.InstanceDungeonMonsterViewOpenParam param = instanceDungeonMonsterViewOpenParam;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonMonsterPreView, param, null);
		}

		// Token: 0x0402186A RID: 137322
		[Nullable(2)]
		private InstanceDungeonBuffItemData ItemDataHandle;

		// Token: 0x0200BC4A RID: 48202
		public enum EBuffInfoType
		{
			// Token: 0x0403A121 RID: 237857
			Buff,
			// Token: 0x0403A122 RID: 237858
			Resistance
		}

		// Token: 0x0200BC4B RID: 48203
		private enum EChildType
		{
			// Token: 0x0403A124 RID: 237860
			BuffText,
			// Token: 0x0403A125 RID: 237861
			BtnMonsterPreView,
			// Token: 0x0403A126 RID: 237862
			TitleText
		}
	}
}
