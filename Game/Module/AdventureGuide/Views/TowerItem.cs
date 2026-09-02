using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.AdventureGuide.Views
{
	// Token: 0x020061BA RID: 25018
	public class TowerItem : GridProxyAbstract<int>
	{
		// Token: 0x0603F26D RID: 258669 RVA: 0x01034D24 File Offset: 0x01032F24
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F26E RID: 258670 RVA: 0x01034DD0 File Offset: 0x01032FD0
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			TowerConfig? towerInfo = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(data);
			if (towerInfo == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), towerInfo.Value.AreaName, Array.Empty<object>());
			int areaAllStars = ModelBase<TowerModel>.Instance.GetAreaAllStars(towerInfo.Value.Difficulty, towerInfo.Value.AreaNum);
			int areaStars = ModelBase<TowerModel>.Instance.GetAreaStars(towerInfo.Value.Difficulty, towerInfo.Value.AreaNum, false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "PeriodicityChallenge_ScoreText", new <>z__ReadOnlyArray<object>(new object[]
			{
				areaStars.ToString(),
				areaAllStars.ToString()
			}));
			base.GetItem(0).SetUIActive(areaStars < areaAllStars);
			base.GetItem(1).SetUIActive(areaStars >= areaAllStars);
		}
	}
}
