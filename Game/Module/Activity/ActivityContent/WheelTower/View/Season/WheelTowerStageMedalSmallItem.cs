using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season
{
	// Token: 0x02006249 RID: 25161
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class WheelTowerStageMedalSmallItem : GridProxyAbstract<IWheelTowerMedalItemData>
	{
		// Token: 0x0603F6ED RID: 259821 RVA: 0x01042BA4 File Offset: 0x01040DA4
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F6EE RID: 259822 RVA: 0x01042C50 File Offset: 0x01040E50
		public override void Refresh(IWheelTowerMedalItemData data, bool isSelected, int gridIndex)
		{
			IWheelTowerMedalGroupData medalGroupData = ModelBase<WheelTowerModel>.Instance.GetMedalGroupData(data.GroupId);
			bool flag = medalGroupData == null || medalGroupData.CurrentMedalId == 0;
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			if (flag || medalGroupData == null)
			{
				return;
			}
			NewTowerMedal? medalConfigById = ConfigBase<WheelTowerConfig>.Instance.GetMedalConfigById(medalGroupData.CurrentMedalId);
			if (medalConfigById == null)
			{
				return;
			}
			base.SetTextureByPath(medalConfigById.Value.Background, base.GetTexture(2), null, null);
			base.SetTextureByPath(medalConfigById.Value.Icon, base.GetTexture(3), null, null);
		}
	}
}
