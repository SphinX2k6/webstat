using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.AdventureGuide.Views
{
	// Token: 0x020061BC RID: 25020
	public class ShipTowerItem : GridProxyAbstract<int>
	{
		// Token: 0x0603F270 RID: 258672 RVA: 0x01034ECC File Offset: 0x010330CC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F271 RID: 258673 RVA: 0x01034F98 File Offset: 0x01033198
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			ShipTowerStageData stageDataById = ModelBase<ShipTowerModel>.Instance.GetStageDataById(data);
			if (stageDataById == null)
			{
				return;
			}
			if (stageDataById.IsEndLess)
			{
				base.GetText(0).SetText("∞", true);
			}
			else
			{
				int orderIndex = stageDataById.OrderIndex;
				string newText = (orderIndex < 10) ? ("0" + orderIndex.ToString()) : orderIndex.ToString();
				base.GetText(0).SetText(newText, true);
			}
			bool flag = stageDataById.IsUnLocked();
			base.GetItem(1).SetUIActive(!flag);
			bool flag2 = stageDataById.IsPassed();
			base.GetItem(2).SetUIActive(!flag2 && flag && !stageDataById.IsEndLess);
			string stageGradeResIdByScore = stageDataById.GetStageGradeResIdByScore(stageDataById.CurrentScore);
			bool flag3 = stageGradeResIdByScore != null;
			UUITexture texture = base.GetTexture(3);
			if (texture != null)
			{
				texture.SetUIActive(flag3);
			}
			if (flag3)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(stageGradeResIdByScore);
				base.SetTextureByPath(resourcePath, texture, null, null);
			}
		}

		// Token: 0x0603F272 RID: 258674 RVA: 0x01035097 File Offset: 0x01033297
		public void SetNextItemClose()
		{
			base.GetItem(4).SetUIActive(false);
		}
	}
}
